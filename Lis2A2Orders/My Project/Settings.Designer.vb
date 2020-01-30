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
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
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
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property IsServer() As Boolean
            Get
                Return CType(Me("IsServer"),Boolean)
            End Get
            Set
                Me("IsServer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10.0.110.168")>  _
        Public Property IPAddress() As String
            Get
                Return CType(Me("IPAddress"),String)
            End Get
            Set
                Me("IPAddress") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("40001")>  _
        Public Property Port() As String
            Get
                Return CType(Me("Port"),String)
            End Get
            Set
                Me("Port") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Log Display")>  _
        Public ReadOnly Property LogPageName() As String
            Get
                Return CType(Me("LogPageName"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("U-WAM Orders")>  _
        Public Property NotifyIconText() As String
            Get
                Return CType(Me("NotifyIconText"),String)
            End Get
            Set
                Me("NotifyIconText") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("COM1")>  _
        Public Property PortCOM() As String
            Get
                Return CType(Me("PortCOM"),String)
            End Get
            Set
                Me("PortCOM") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Ethernet")>  _
        Public Property EthernetOrSerial() As String
            Get
                Return CType(Me("EthernetOrSerial"),String)
            End Get
            Set
                Me("EthernetOrSerial") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("URO\^^^BLD\^^^BIL\^^^KET\^^^GLU\^^^PRO\^^^PH\^^^NIT\^^^LEU\^^^S.G.(Ref)\^^^COLOR\"& _ 
            "^^^ColorRANK\^^^CLOUD\")>  _
        Public Property ParametersCHM() As String
            Get
                Return CType(Me("ParametersCHM"),String)
            End Get
            Set
                Me("ParametersCHM") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("RBC\^^^WBC\^^^WBC Clumps\^^^EC\^^^Squa.EC\^^^Non SEC\^^^CAST\^^^Hy.CAST\^^^Path.C"& _ 
            "AST\^^^BACT\^^^X'TAL\^^^YLC\^^^SPERM\^^^MUCUS\")>  _
        Public Property ParametersFCM() As String
            Get
                Return CType(Me("ParametersFCM"),String)
            End Get
            Set
                Me("ParametersFCM") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("ORD")>  _
        Public Property OrdersFilePrefix() As String
            Get
                Return CType(Me("OrdersFilePrefix"),String)
            End Get
            Set
                Me("OrdersFilePrefix") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".ord")>  _
        Public Property OrdersFileExtension() As String
            Get
                Return CType(Me("OrdersFileExtension"),String)
            End Get
            Set
                Me("OrdersFileExtension") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".ok")>  _
        Public Property OrdersFileCheckIndicatorExtension() As String
            Get
                Return CType(Me("OrdersFileCheckIndicatorExtension"),String)
            End Get
            Set
                Me("OrdersFileCheckIndicatorExtension") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("ALL")>  _
        Public Property ActiveTestOrders() As String
            Get
                Return CType(Me("ActiveTestOrders"),String)
            End Get
            Set
                Me("ActiveTestOrders") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("URO\^^^BLD\^^^BIL\^^^KET\^^^GLU\^^^PRO\^^^PH\^^^NIT\^^^LEU\^^^S.G.(Ref)\^^^COLOR\"& _ 
            "^^^ColorRANK\^^^CLOUD\^^^RBC\^^^WBC\^^^WBC Clumps\^^^EC\^^^Squa.EC\^^^Non SEC\^^"& _ 
            "^CAST\^^^Hy.CAST\^^^Path.CAST\^^^BACT\^^^X'TAL\^^^YLC\^^^SPERM\^^^MUCUS\")>  _
        Public Property ParametersAll() As String
            Get
                Return CType(Me("ParametersAll"),String)
            End Get
            Set
                Me("ParametersAll") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Server=SERVER;Database=DATABASE;User Id=USERNAME;Password=PASSWORD;")>  _
        Public Property ConnectionString() As String
            Get
                Return CType(Me("ConnectionString"),String)
            End Get
            Set
                Me("ConnectionString") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("mBJEHsjmio49LOQXj2TPTw==")>  _
        Public Property dbs() As String
            Get
                Return CType(Me("dbs"),String)
            End Get
            Set
                Me("dbs") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("+HQrGL6OoQYSZFEr9eaCPw==")>  _
        Public Property epd() As String
            Get
                Return CType(Me("epd"),String)
            End Get
            Set
                Me("epd") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("X9Sqb8uVyC0=")>  _
        Public Property svr() As String
            Get
                Return CType(Me("svr"),String)
            End Get
            Set
                Me("svr") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("9DL0Ltq+1XGOW2AH9Cceqjz7Qxidq1BC")>  _
        Public Property usr() As String
            Get
                Return CType(Me("usr"),String)
            End Get
            Set
                Me("usr") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastSampleTime() As String
            Get
                Return CType(Me("LastSampleTime"),String)
            End Get
            Set
                Me("LastSampleTime") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property OrdersFilePath() As String
            Get
                Return CType(Me("OrdersFilePath"),String)
            End Get
            Set
                Me("OrdersFilePath") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
        Public Property LisQueryIntervalMinutes() As Integer
            Get
                Return CType(Me("LisQueryIntervalMinutes"),Integer)
            End Get
            Set
                Me("LisQueryIntervalMinutes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Swat,Inc. Interface")>  _
        Public Property AppName() As String
            Get
                Return CType(Me("AppName"),String)
            End Get
            Set
                Me("AppName") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Lis2A2Orders.My.MySettings
            Get
                Return Global.Lis2A2Orders.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
