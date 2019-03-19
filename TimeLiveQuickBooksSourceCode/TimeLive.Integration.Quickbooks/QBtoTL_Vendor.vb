﻿Imports QBFC11Lib
Imports System.Net.Mail
Imports System.Data.SqlClient


Public Class QBtoTL_Vendor
    Dim vendorRet As IVendorRet

    Public Class VendorDataStructureQB
        Public NoItems As Integer = 0
        Public DataArray As New List(Of Vendor)
    End Class

    Public Class Vendor
        Public RecSelect As Boolean
        Public QB_Name As String
        Public NewlyAdded As String
        Public QB_ID As String
        Public QBModTime As String
        Public QBCreateTime As String
        Public FirstName As String
        Public LastName As String
        Public HiredDate As String
        Public Email As String
        Public IsVendorEligibleFor1099 As Boolean

        Sub New(ByVal NewlyAdded_in As String, ByVal QB_Name_in As String, ByVal Email_in As String, ByVal QB_ID_in As String, ByVal FirstName_in As String,
                ByVal LastName_in As String, ByVal HiredDate_in As String, QBModTime_in As String, QBCreateTime_in As String, IsVendorEligibleFor1099_in As Boolean)
            RecSelect = False
            QBModTime = QBModTime_in
            NewlyAdded = NewlyAdded_in
            QBCreateTime = QBCreateTime_in
            QB_Name = QB_Name_in
            QB_ID = QB_ID_in
            Email = Email_in
            FirstName = FirstName_in
            LastName = LastName_in
            HiredDate = HiredDate_in
            IsVendorEligibleFor1099 = IsVendorEligibleFor1099_in

        End Sub
    End Class

    Public Function GetVendorQBData(IntegratedUIForm As IntegratedUI, UI As Boolean) As VendorDataStructureQB

        Dim EmailAddress As String
        Dim FirstName As String
        Dim LastName As String
        Dim IsVendorEligibleFor1099 As Boolean = False
        Dim ModTime As String
        Dim CreateTime As String
        Dim VendorData As New VendorDataStructureQB
        Dim pblenth As Integer
        Dim NewlyAdd As String

        'step1: create QBFC session manager and prepare the request
        'Dim sessManager As QBSessionManager
        Dim vendormsgSetRs As IMsgSetResponse

        Try
            'sessManager = New QBSessionManagerClass()

            Dim vendormsgSetRq As IMsgSetRequest = MAIN.SESSMANAGER.CreateMsgSetRequest("US", 2, 0) 'sessManager
            vendormsgSetRq.Attributes.OnError = ENRqOnError.roeContinue

            Dim syncvendor As IVendorQuery = vendormsgSetRq.AppendVendorQueryRq

            syncvendor.ORVendorListQuery.VendorListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly)

            'step2: begin QB session and send the request
            'sessManager.OpenConnection("App", "TimeLive Quickbooks")
            'sessManager.BeginSession("", ENOpenMode.omDontCare)
            vendormsgSetRs = MAIN.SESSMANAGER.DoRequests(vendormsgSetRq) 'sessManager

            Dim vendorrespList As IResponseList
            vendorrespList = vendormsgSetRs.ResponseList

            Dim vendorresp As IResponse
            vendorresp = vendorrespList.GetAt(0)

            Dim vendorRetList As IVendorRetList
            vendorRetList = vendorresp.Detail

            Dim vendorRetListCount As Integer = If(vendorRetList Is Nothing, 0, vendorRetList.Count)

            If vendorresp.StatusCode = 0 Then

                If UI Then
                    pblenth = vendorRetList.Count
                    If pblenth >= 0 Then
                        IntegratedUIForm.ProgressBar1.Maximum = pblenth - 1
                    End If
                End If

                For i As Integer = 0 To vendorRetList.Count - 1
                    vendorRet = vendorRetList.GetAt(i)
                    With vendorRet
                        If Not CBool(My.Settings.SyncElbVendor) Or .IsVendorEligibleFor1099.GetValue Then
                            EmailAddress = If(.Email Is Nothing, "", .Email.GetValue)
                            FirstName = If(.FirstName Is Nothing, "", .FirstName.GetValue)
                            LastName = If(.LastName Is Nothing, "", .LastName.GetValue)
                            CreateTime = If(.TimeCreated Is Nothing, "", .TimeCreated.GetValue.ToString)
                            ModTime = If(.TimeModified Is Nothing, CreateTime, .TimeModified.GetValue.ToString)
                            IsVendorEligibleFor1099 = ((Not .IsVendorEligibleFor1099 Is Nothing) And
                                                    .IsVendorEligibleFor1099.GetValue)
                            ' will check which type data should be added 

                            Dim TL_ID_Count = ISQBID_In_DataTable(.Name.GetValue, .ListID.GetValue)
                            NewlyAdd = If(TL_ID_Count, "", "N") ' N if new
                            VendorData.NoItems += 1
                            VendorData.DataArray.Add(New Vendor(NewlyAdd, .Name.GetValue, EmailAddress, .ListID.GetValue, FirstName, LastName, "", ModTime, CreateTime, IsVendorEligibleFor1099))
                        End If
                    End With
                    If UI Then
                        IntegratedUIForm.ProgressBar1.Value = i
                    End If
                Next
            End If

            If vendormsgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                Throw New Exception(vendormsgSetRs.ResponseList.GetAt(0).StatusMessage)
            End If

        Catch ex As Exception
            MAIN.QUITQBSESSION()
            If ex.Message.Contains("Specified email already") Then
                Throw New Exception("Specified user already exist.")
            Else
                My.Forms.MAIN.History(ex.ToString, "C")
                Throw ex
            End If
            'Finally
            '    If Not sessManager Is Nothing Then
            '       sessManager.EndSession()
            '       sessManager.CloseConnection()
            '    End If
        End Try
        Return VendorData
    End Function

    Public Function QBTransferVendorToTL(ByRef objData As QBtoTL_Vendor.VendorDataStructureQB,
                                   ByVal token As String, IntegratedUIForm As IntegratedUI, UI As Boolean) As Integer

        Dim objEmployeeServices As New Services.TimeLive.Employees.Employees
        Dim authentication As New Services.TimeLive.Employees.SecuredWebServiceHeader
        authentication.AuthenticatedToken = token
        objEmployeeServices.SecuredWebServiceHeaderValue = authentication

        Dim objServices As New Services.TimeLiveServices
        Dim authentication2 As New Services.SecuredWebServiceHeader
        authentication2.AuthenticatedToken = token
        objServices.SecuredWebServiceHeaderValue = authentication2

        Dim nDepartmentId As Integer = objServices.GetDepartmentId()
        Dim nRoleId As Integer = objEmployeeServices.GetUserRoleId()
        Dim nLocationId As Integer = objServices.GetLocationId()
        Dim nEmployeeTypeId As Guid = objEmployeeServices.GetEmployeeTypeId()
        Dim nEmployeeStatusId As Integer = objEmployeeServices.GetEmployeeStatusId()
        Dim nWorkingDayTypeId As Guid = objEmployeeServices.GetEmployeeWorkingDayTypeId()
        Dim nBillingTypeId As Integer = objEmployeeServices.GetEmployeeBillingTypeId()

        'sets status bar. If no, UI skip
        Dim incrementbar As Integer = 0
        If UI = True Then
            Dim pblenth As Integer = objData.DataArray.Count - 1
            If pblenth >= 0 Then
                IntegratedUIForm.ProgressBar1.Maximum = pblenth
                IntegratedUIForm.ProgressBar1.Value = 0
            End If
        End If

        Dim NoRecordsCreatedorUpdated = 0
        For Each element As QBtoTL_Vendor.Vendor In objData.DataArray

            ' check if the check value is true
            If element.RecSelect Then
                'Check number of QB records that match ID

                Dim EmailAddress As String
                Dim FirstName As String
                Dim LastName As String
                Dim EmployeeName As String
                Dim HiredDate As String
                Dim TL_ID_Return = ISQBID_In_DataTable(element.QB_Name, element.QB_ID)
                'if none create
                If TL_ID_Return = 0 Then
                    If MsgBox("New  vendor found: " + element.QB_Name + ". Create?", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
                        NoRecordsCreatedorUpdated += 1
                        ' if it does not exist create a new record on both the sync database and on TL
                        My.Forms.MAIN.History("Inserting QB & TL keys into sync database and inserting to TimeLife:  " + element.QB_Name, "i")

                        'Insert record into Time Life
                        With element
                            Try
                                My.Forms.MAIN.History("1099 : " + .IsVendorEligibleFor1099.ToString, "i")
                                If .IsVendorEligibleFor1099 = True Then
                                    My.Forms.MAIN.History("TL_ID1111 : " + TL_ID_Return.ToString, "i")
                                    EmailAddress = GetEmailAddress(.Email, token, .QB_ID)
                                    FirstName = GetValue(.QB_Name, "FirstName")
                                    LastName = GetValue(.QB_Name, "LastName")
                                    HiredDate = GetValue(.HiredDate, "HiredDate")
                                    EmployeeName = FirstName + " " + LastName

                                    objEmployeeServices.InsertEmployee(EmailAddress, EmailAddress, FirstName,
                                        LastName, EmailAddress, "", nDepartmentId, nRoleId, nLocationId,
                                        233, nBillingTypeId, Now.Date, -1, 0, 6, 0, 0, nEmployeeTypeId, nEmployeeStatusId,
                                        "", Now.Date, Now.Date, nWorkingDayTypeId, System.Guid.Empty, 0, System.Guid.Empty, False,
                                        "", "", "", "", "", "", "", "", "", "Mr.", True)

                                    Dim VendorAdapter As New QB_TL_IDsTableAdapters.VendorsTableAdapter()
                                    VendorAdapter.Insert(element.QB_ID, objEmployeeServices.GetEmployeeId(EmployeeName), element.QB_Name, EmployeeName)
                                End If

                            Catch ex As Exception
                                My.Forms.MAIN.History("Transfer failed." + ex.ToString, "N")
                            End Try
                        End With
                    End If
                End If

                'if it exist check that the TL_ID is not empty ---> 1
                'if not empty, just update
                'if empty, informed the user of a potential error as a record has been created in the sync database without a corresponding TL pointer
                If TL_ID_Return = 1 Then

                    Dim TL_ID As String = ISTLID_In_DataTableForVendor(element.QB_ID)
                    If TL_ID Is Nothing Then
                        My.Forms.MAIN.History("Detected empty sync record (No TL ID). Needs to be manually sync or deleted." + element.QB_Name, "i")

                    Else
                        NoRecordsCreatedorUpdated += 1
                        My.Forms.MAIN.History("Updating TL record for: " + element.QB_Name, "i")
                        'Update TimeLife Record


                        Dim employees As New DataTable
                        employees = objEmployeeServices.GetEmployeesData


                        Dim foundRows() As DataRow

                        ' Use the Select method to find all rows matching the filter.
                        foundRows = employees.Select(String.Format("AccountEmployeeId = '{0}'", 16))


                        'Dim AccountEmployeeId As Integer = 16
                        'If Not IsDBNull(foundRows(0)("AccountEmployeeId")) Then
                        '    AccountEmployeeId = foundRows(0)("AccountEmployeeId")
                        'End If

                        'Dim Password As String = ""
                        'If Not IsDBNull(foundRows(0)("Password")) Then
                        '    Password = foundRows(0)("Password")
                        'End If

                        'Dim Prefix As String = ""
                        'If Not IsDBNull(foundRows(0)("Prefix")) Then
                        '    Prefix = foundRows(0)("Prefix")
                        'End If

                        'Dim EmployeeCode As String = ""
                        'If Not IsDBNull(foundRows(0)("EmployeeCode")) Then
                        '    EmployeeCode = foundRows(0)("EmployeeCode")
                        'End If

                        'Dim MiddleName As String = ""
                        'If Not IsDBNull(foundRows(0)("MiddleName")) Then
                        '    MiddleName = foundRows(0)("MiddleName")
                        'End If

                        'Dim AccountDepartmentID As Integer = nDepartmentId
                        'If Not IsDBNull(foundRows(0)("AccountDepartmentID")) Then
                        '    AccountDepartmentID = foundRows(0)("AccountDepartmentID")
                        'End If

                        'Dim AccountRoleID As Integer = nRoleId
                        'If Not IsDBNull(foundRows(0)("AccountRoleID")) Then
                        '    AccountRoleID = foundRows(0)("AccountRoleID")
                        'End If

                        'Dim AccountLocationID As Integer = nLocationId
                        'If Not IsDBNull(foundRows(0)("AccountLocationID")) Then
                        '    AccountLocationID = foundRows(0)("AccountLocationID")
                        'End If

                        'Dim CountryId As Short = 233
                        'If Not IsDBNull(foundRows(0)("CountryId")) Then
                        '    CountryId = foundRows(0)("CountryId")
                        'End If

                        'Dim BillingTypeId As Integer = nBillingTypeId
                        'If Not IsDBNull(foundRows(0)("BillingTypeId")) Then
                        '    BillingTypeId = foundRows(0)("BillingTypeId")
                        'End If

                        'Dim StartDate As DateTime = Now()
                        'If Not IsDBNull(foundRows(0)("StartDate")) Then
                        '    StartDate = foundRows(0)("StartDate")
                        'End If

                        'Dim TerminationDate As DateTime = Now()
                        'If Not IsDBNull(foundRows(0)("TerminationDate")) Then
                        '    StartDate = foundRows(0)("TerminationDate")
                        'End If

                        'Dim StatusId As Integer = nEmployeeStatusId
                        'If Not IsDBNull(foundRows(0)("StatusId")) Then
                        '    StatusId = foundRows(0)("StatusId")
                        'End If

                        'Dim IsDeleted As Boolean = False
                        'If Not IsDBNull(foundRows(0)("IsDeleted")) Then
                        '    IsDeleted = foundRows(0)("IsDeleted")
                        'End If

                        'Dim IsDisabled As Boolean = False
                        'If Not IsDBNull(foundRows(0)("IsDisabled")) Then
                        '    IsDisabled = foundRows(0)("IsDisabled")
                        'End If

                        'Dim DefaultProjectId As Integer = -1
                        'If Not IsDBNull(foundRows(0)("DefaultProjectId")) Then
                        '    DefaultProjectId = foundRows(0)("DefaultProjectId")
                        'End If

                        'Dim EmployeeManagerId As Integer = 0
                        'If Not IsDBNull(foundRows(0)("EmployeeManagerId")) Then
                        '    EmployeeManagerId = foundRows(0)("EmployeeManagerId")
                        'End If

                        'Dim TimeZoneId As Integer = 6
                        'If Not IsDBNull(foundRows(0)("TimeZoneId")) Then
                        '    TimeZoneId = foundRows(0)("TimeZoneId")
                        'End If

                        'Dim CreatedByEmployeeId As Integer = 0
                        'If Not IsDBNull(foundRows(0)("CreatedByEmployeeId")) Then
                        '    CreatedByEmployeeId = foundRows(0)("CreatedByEmployeeId")
                        'End If

                        'Dim ModifiedByEmployeeId As Integer = 0
                        'If Not IsDBNull(foundRows(0)("ModifiedByEmployeeId")) Then
                        '    ModifiedByEmployeeId = foundRows(0)("ModifiedByEmployeeId")
                        'End If

                        'Dim AllowedAccessFromIP As String = ""
                        'If Not IsDBNull(foundRows(0)("AllowedAccessFromIP")) Then
                        '    AllowedAccessFromIP = foundRows(0)("AllowedAccessFromIP")
                        'End If

                        'Dim EmployeePayTypeId As Guid = nEmployeeTypeId
                        'If Not IsDBNull(foundRows(0)("EmployeePayTypeId")) Then
                        '    EmployeePayTypeId = foundRows(0)("EmployeePayTypeId")
                        'End If

                        'Dim JobTitle As String = ""
                        'If Not IsDBNull(foundRows(0)("JobTitle")) Then
                        '    JobTitle = foundRows(0)("JobTitle")
                        'End If

                        'Dim AccountWorkingDayTypeId As Guid = nWorkingDayTypeId
                        'If Not IsDBNull(foundRows(0)("AccountWorkingDayTypeId")) Then
                        '    AccountWorkingDayTypeId = foundRows(0)("AccountWorkingDayTypeId")
                        'End If

                        'Dim AccountTimeOffPolicyId As Guid = System.Guid.Empty
                        'If Not IsDBNull(foundRows(0)("AccountTimeOffPolicyId")) Then
                        '    AccountTimeOffPolicyId = foundRows(0)("AccountTimeOffPolicyId")
                        'End If

                        'Dim TimeOffApprovalTypeId As Integer = 0
                        'If Not IsDBNull(foundRows(0)("TimeOffApprovalTypeId")) Then
                        '    TimeOffApprovalTypeId = foundRows(0)("TimeOffApprovalTypeId")
                        'End If

                        'Dim AccountHolidayTypeId As Guid = System.Guid.Empty
                        'If Not IsDBNull(foundRows(0)("AccountHolidayTypeId")) Then
                        '    AccountHolidayTypeId = foundRows(0)("AccountHolidayTypeId")
                        'End If

                        'Dim IsForcePasswordChange As Boolean = False
                        'If Not IsDBNull(foundRows(0)("IsForcePasswordChange")) Then
                        '    IsForcePasswordChange = foundRows(0)("IsForcePasswordChange")
                        'End If

                        With element
                            Try
                                EmailAddress = GetEmailAddress(.Email, token, .QB_ID)
                                FirstName = GetValue(.QB_Name, "FirstName")
                                LastName = GetValue(.QB_Name, "LastName")
                                HiredDate = GetValue(.HiredDate, "HiredDate")
                                EmployeeName = FirstName + " " + LastName


                                'objEmployeeServices.UpdateEmployeeAsync(AccountEmployeeId, Password, Prefix, FirstName, LastName,
                                '                       MiddleName, EmailAddress, EmployeeCode, AccountDepartmentID,
                                '                       AccountRoleID, AccountLocationID, "AddressLine1", "ddressLine2",
                                '                       "State", "City", "Zip", CountryId, "HomePhoneNo", "WorkPhoneNo",
                                '                       "MobilePhoneNo", BillingTypeId, StartDate, TerminationDate,
                                '                       StatusId, IsDeleted, IsDisabled, DefaultProjectId, EmployeeManagerId, TimeZoneId,
                                '                       CreatedByEmployeeId, ModifiedByEmployeeId, AllowedAccessFromIP, EmployeePayTypeId,
                                '                       JobTitle, HiredDate, AccountWorkingDayTypeId, AccountTimeOffPolicyId,
                                '                       TimeOffApprovalTypeId, AccountHolidayTypeId, IsForcePasswordChange,
                                '                       "", False)

                                My.Forms.MAIN.History("Record update commented out -- Defect", "N")


                            Catch ex As Exception
                                My.Forms.MAIN.History("Update failed." + ex.ToString, "N")
                            End Try
                        End With

                    End If
                End If
            End If
            'if no, UI skip
            If UI = True Then
                IntegratedUIForm.ProgressBar1.Value = incrementbar
                incrementbar = incrementbar + 1
            End If

        Next

        Return NoRecordsCreatedorUpdated

    End Function

    ''' <summary>
    ''' 'Checks if QBID is in sync database
    ''' </summary>
    ''' <param name="myqbID"></param>
    ''' <returns></returns>
    Public Function ISQBID_In_DataTable(ByVal myqbName As String, ByVal myqbID As String) As Int16
        Dim result As Int16 = 0

        'Dim EmployeeAdapter As New QB_TL_IDsTableAdapters.EmployeesTableAdapter()
        'For Each TimeLiveID As QB_TL_IDs.EmployeesRow In EmployeeAdapter.GetEmployees()
        '    If String.Compare(Trim(TimeLiveID.QuickBooks_ID), Trim(myqbID)) = 0 Then
        '        Return True
        '        Exit For
        '    End If
        'Next
        Dim VendorAdapter As New QB_TL_IDsTableAdapters.VendorsTableAdapter()
        Dim TimeLiveIDs As QB_TL_IDs.VendorsDataTable = VendorAdapter.GetCorrespondingTL_ID(myqbID)

        If TimeLiveIDs.Count = 1 Then
            result = 1
            My.Forms.MAIN.History("One record found in QB sync table for: " + myqbName, "i")
        End If


        If TimeLiveIDs.Count = 0 Then
            result = 0
            My.Forms.MAIN.History("No records found on QB sync table for:" + myqbName, "i")
        End If


        If TimeLiveIDs.Count > 1 Then
            result = 2
            My.Forms.MAIN.History("More than one record found for:" + myqbName, "I")
        End If
        Return result
    End Function

    ''' <summary>
    ''' Check if QBID is in sync database and if it has a corresponding TLID
    ''' </summary>
    ''' <param name="myqbID"></param>
    ''' <returns>
    ''' 0 if not found
    ''' 1 if found
    ''' 2 if more than one is found
    ''' </returns>
    Private Function ISTLID_In_DataTableForVendor(ByVal myqbID As String) As String
        Dim result As String = Nothing
        Dim VendorAdapter As New QB_TL_IDsTableAdapters.VendorsTableAdapter()
        Dim TimeLiveIDs As QB_TL_IDs.VendorsDataTable = VendorAdapter.GetCorrespondingTL_ID(myqbID)

        If String.IsNullOrEmpty(Trim(TimeLiveIDs(0).TimeLive_ID.ToString())) Then
            My.Forms.MAIN.History("Record has a TLID of Nothing", "I")
        Else

            My.Forms.MAIN.History("Record has a TLID of: " + TimeLiveIDs(0).TimeLive_ID.ToString(), "i")
            result = TimeLiveIDs(0).TimeLive_ID.ToString()
        End If

        Return result
    End Function

    Public Function SetLength(ByVal str As String) As String
        If str.Length > 50 Then
            str = str.Substring(0, 50)
        End If
        Return str
    End Function

    Public Function GetValue(Value As String, ColumnName As String) As Object
        If Not Value Is Nothing And ColumnName = "HiredDate" Then
            Return Value
        ElseIf Value Is Nothing And ColumnName = "HiredDate" Then
            Return Now.Date
        Else
            Return GetEmployeeValue(Value, ColumnName)
        End If
    End Function

    Public Function GetEmployeeValue(Value As String, ColumnName As String)
        Dim EmployeeName() As String = Value.Split(" ")
        If EmployeeName.Length = 2 Then
            If ColumnName = "FirstName" Then
                Return EmployeeName(0)
            ElseIf ColumnName = "LastName" Then
                Return EmployeeName(1)
            End If
        ElseIf EmployeeName.Length = 1 Then
            If ColumnName = "FirstName" Then
                Return EmployeeName(0)
            ElseIf ColumnName = "LastName" Then
                Return EmployeeName(0)
            End If
        ElseIf EmployeeName.Length = 3 Then
            If ColumnName = "FirstName" Then
                Return EmployeeName(0)
            ElseIf ColumnName = "LastName" Then
                Return EmployeeName(2)
            End If
        End If
        Return EmployeeName(0) ' Should never get here
    End Function

    Public Function GetEmailAddress(Value As String, p_token As String, ListID As String) As String
        Dim objEmployeeServices As New Services.TimeLive.Employees.Employees
        Dim authentication As New Services.TimeLive.Employees.SecuredWebServiceHeader
        authentication.AuthenticatedToken = p_token
        objEmployeeServices.SecuredWebServiceHeaderValue = authentication
        If Not Value Is Nothing Then
            Dim EmailAddress As String = Value
            If objEmployeeServices.IsEmployeeExistsByEmailAddress(EmailAddress) Then
                Return ListID
            Else
                Return EmailAddress
            End If
        Else
            Return ListID
        End If
    End Function
End Class


