﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/TimeLiveServices.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLiveServices() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLiveServices"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLiveServices") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/Employees.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Employees_Employees() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Employees_Employees"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Employees_Employees") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/Clients.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Clients_Clients() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Clients_Clients"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Clients_Clients") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/Projects.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Projects_Projects() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Projects_Projects"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Projects_Projects") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/Tasks.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Tasks_Tasks() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Tasks_Tasks"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Tasks_Tasks") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/TimeEntries.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_TimeEntries_TimeEntries() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_TimeEntries_TimeEntries"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_TimeEntries_TimeEntries") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://demo.livetecs.com/Services/ExpenseEntries.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_ExpenseEntries_ExpenseEntries() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_ExpenseEntries_ExpenseEntries"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_ExpenseEntries_ExpenseEntries") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(""),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property WebServiceURL() As String
            Get
                Return CType(Me("WebServiceURL"),String)
            End Get
            Set
                Me("WebServiceURL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(""),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property Username() As String
            Get
                Return CType(Me("Username"),String)
            End Get
            Set
                Me("Username") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Password() As String
            Get
                Return CType(Me("Password"),String)
            End Get
            Set
                Me("Password") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property JobHierarchy() As String
            Get
                Return CType(Me("JobHierarchy"),String)
            End Get
            Set
                Me("JobHierarchy") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property QBPayrollItem() As String
            Get
                Return CType(Me("QBPayrollItem"),String)
            End Get
            Set
                Me("QBPayrollItem") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TransferToPayroll() As String
            Get
                Return CType(Me("TransferToPayroll"),String)
            End Get
            Set
                Me("TransferToPayroll") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncConsultants() As String
            Get
                Return CType(Me("SyncConsultants"),String)
            End Get
            Set
                Me("SyncConsultants") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncEmployees() As String
            Get
                Return CType(Me("SyncEmployees"),String)
            End Get
            Set
                Me("SyncEmployees") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncLaborItems() As String
            Get
                Return CType(Me("SyncLaborItems"),String)
            End Get
            Set
                Me("SyncLaborItems") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncAccounts() As String
            Get
                Return CType(Me("SyncAccounts"),String)
            End Get
            Set
                Me("SyncAccounts") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncCustomers() As String
            Get
                Return CType(Me("SyncCustomers"),String)
            End Get
            Set
                Me("SyncCustomers") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncJobOrItem() As String
            Get
                Return CType(Me("SyncJobOrItem"),String)
            End Get
            Set
                Me("SyncJobOrItem") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncElbVendor() As String
            Get
                Return CType(Me("SyncElbVendor"),String)
            End Get
            Set
                Me("SyncElbVendor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncJobs_Items() As String
            Get
                Return CType(Me("SyncJobs_Items"),String)
            End Get
            Set
                Me("SyncJobs_Items") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncTimeEntries() As String
            Get
                Return CType(Me("SyncTimeEntries"),String)
            End Get
            Set
                Me("SyncTimeEntries") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SyncExpenseEntries() As String
            Get
                Return CType(Me("SyncExpenseEntries"),String)
            End Get
            Set
                Me("SyncExpenseEntries") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DebugMode() As String
            Get
                Return CType(Me("DebugMode"),String)
            End Get
            Set
                Me("DebugMode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property AutoRunTime() As String
            Get
                Return CType(Me("AutoRunTime"),String)
            End Get
            Set
                Me("AutoRunTime") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property AutoRunInterval() As String
            Get
                Return CType(Me("AutoRunInterval"),String)
            End Get
            Set
                Me("AutoRunInterval") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property JobORItemHierarchy() As String
            Get
                Return CType(Me("JobORItemHierarchy"),String)
            End Get
            Set
                Me("JobORItemHierarchy") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property QBClass() As String
            Get
                Return CType(Me("QBClass"),String)
            End Get
            Set
                Me("QBClass") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property CustomerLastSync() As String
            Get
                Return CType(Me("CustomerLastSync"),String)
            End Get
            Set
                Me("CustomerLastSync") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property EmployeeLastSync() As String
            Get
                Return CType(Me("EmployeeLastSync"),String)
            End Get
            Set
                Me("EmployeeLastSync") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property VendorLastSync() As String
            Get
                Return CType(Me("VendorLastSync"),String)
            End Get
            Set
                Me("VendorLastSync") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property JobLastSync() As String
            Get
                Return CType(Me("JobLastSync"),String)
            End Get
            Set
                Me("JobLastSync") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ItemlastSync() As String
            Get
                Return CType(Me("ItemlastSync"),String)
            End Get
            Set
                Me("ItemlastSync") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TimeTrackingLastSync() As String
            Get
                Return CType(Me("TimeTrackingLastSync"),String)
            End Get
            Set
                Me("TimeTrackingLastSync") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property QBWageType() As String
            Get
                Return CType(Me("QBWageType"),String)
            End Get
            Set
                Me("QBWageType") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property FromEmailAddress() As String
            Get
                Return CType(Me("FromEmailAddress"),String)
            End Get
            Set
                Me("FromEmailAddress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ToEmailAddress() As String
            Get
                Return CType(Me("ToEmailAddress"),String)
            End Get
            Set
                Me("ToEmailAddress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property EmailPassword() As String
            Get
                Return CType(Me("EmailPassword"),String)
            End Get
            Set
                Me("EmailPassword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SSLEncryption() As String
            Get
                Return CType(Me("SSLEncryption"),String)
            End Get
            Set
                Me("SSLEncryption") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property EmailHost() As String
            Get
                Return CType(Me("EmailHost"),String)
            End Get
            Set
                Me("EmailHost") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property EmailPort() As String
            Get
                Return CType(Me("EmailPort"),String)
            End Get
            Set
                Me("EmailPort") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property MessageToEmployee() As String
            Get
                Return CType(Me("MessageToEmployee"),String)
            End Get
            Set
                Me("MessageToEmployee") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property MessageToSupervisor() As String
            Get
                Return CType(Me("MessageToSupervisor"),String)
            End Get
            Set
                Me("MessageToSupervisor") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SQL01;Initial Catalog=TL_QB_Relationship_Dev;User ID=sa;Password=$bas"& _ 
            "eline00")>  _
        Public ReadOnly Property TL_QB_RelationshipConnectionString() As String
            Get
                Return CType(Me("TL_QB_RelationshipConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=teltriumsrv3;Initial Catalog=TimeLive;User ID=sa;Password=$baseline00"& _ 
            "")>  _
        Public ReadOnly Property TimeLiveDevConnectionString() As String
            Get
                Return CType(Me("TimeLiveDevConnectionString"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.TimeLive.Quickbooks.Integrator.My.MySettings
            Get
                Return Global.TimeLive.Quickbooks.Integrator.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
