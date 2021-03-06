﻿Public Class Settings
    Private _AnalysisCategory As String
    Private _connectionType As String
    Private _isServer As Boolean
    Private _tabPage2Name As String
    Private _LastSampleTime As String
    Dim _ActiveTestOrders As String

    Public Sub New()
        ChemistryParameters = My.Settings.ParametersCHM.Split("|")
        DepositParameters = My.Settings.ParametersFCM.Split("|")
    End Sub

    Private Enum AnalysisCategories
        ALL
        CHM
        FCM
    End Enum

    Private Enum ConnType
        Ethernet
        Serial
    End Enum

    Property IsServer As Boolean
        Get
            Return _isServer
        End Get
        Set
            _isServer = Value
            If _isServer = True Then
                _tabPage2Name = "Server Logs"
            ElseIf Value = False Then
                _tabPage2Name = "Client Logs"
            End If
        End Set
    End Property

    ReadOnly Property TabPage2Name As String
        Get
            Return _tabPage2Name
        End Get
    End Property
    Public Property LastSampleTime As String
        Get
            Return _LastSampleTime
        End Get
        Set
            _LastSampleTime = Value
        End Set
    End Property

    Public Property ActiveTestOrders As String
        Get
            Return _ActiveTestOrders
        End Get
        Set
            Select Case Value
                Case AnalysisCategories.ALL
                    AnalysisCategories.ALL.ToString()

                Case AnalysisCategories.CHM
                    AnalysisCategories.CHM.ToString()

                Case AnalysisCategories.FCM
                    AnalysisCategories.FCM.ToString()
            End Select
        End Set
    End Property

    Public Property AppName As String
    ReadOnly Property ChemistryParameters As String()

    Public Property ConnectionType As String
        Get

            Return _connectionType
        End Get
        Set
            If Value = ConnType.Ethernet.ToString Then _connectionType = ConnType.Ethernet
            If Value = ConnType.Serial.ToString Then _connectionType = ConnType.Serial
        End Set
    End Property

    ReadOnly Property DepositParameters As String()
    Public Property IPAddress As String
    Public Property NotifyIconText As String
    Public Property OrdersFilePath As String

    Public Property Port As Integer
    Public Property SerialPort As String
    Public Property OrdersFileCheckIndicatorExtension As String
    Public Property OrdersFileExtension As String
    Public Property OrdersFilePrefix As String
    Public Shared Sub SaveSettings(ByVal newSettings As Settings, ByVal parametersCHM As String, ByVal parametersFCM As String)
        Try
            If newSettings IsNot Nothing Then
                Dim EthernetOrSerial As Integer
                Dim FCM As String
                Dim Chm As String

                If newSettings.ConnectionType = ConnType.Ethernet.ToString Then EthernetOrSerial = ConnType.Ethernet
                If newSettings.ConnectionType = ConnType.Serial.ToString Then EthernetOrSerial = ConnType.Serial

                If (Not parametersFCM.StartsWith("|") Or parametersFCM.EndsWith("|")) And (parametersCHM.StartsWith("|") Or parametersCHM.EndsWith("|")) Then

                    Chm = parametersCHM.Trim
                    FCM = parametersFCM.Trim
                Else
                    Throw New InvalidExpressionException("FCM parameters string or CHM parameters string cannot start or end with the delimiter, '|'. ")
                End If



                Dim saves As New My.MySettings With {.AppName = newSettings.AppName,
                    .EthernetOrSerial = EthernetOrSerial,
                    .IPAddress = newSettings.IPAddress,
                    .IsServer = newSettings.IsServer,
                    .NotifyIconText = newSettings.NotifyIconText,
                    .OrdersFileCheckIndicatorExtension = newSettings.OrdersFileCheckIndicatorExtension,
                    .OrdersFileExtension = newSettings.OrdersFileExtension,
                    .OrdersFilePrefix = newSettings.OrdersFilePrefix,
                    .ParametersCHM = Chm,
                    .ParametersFCM = FCM,
                    .Port = newSettings.Port,
                    .PortCOM = newSettings.SerialPort,
                    .ActiveTestOrders = newSettings.ActiveTestOrders,
                    .LastSampleTime = newSettings.LastSampleTime,
                    .OrdersFilePath = newSettings.OrdersFilePath}
            End If
        Catch ex As InvalidExpressionException
            MsgBox(String.Format("Could not save settings.{0}Error: {1}", vbCr, ex.Message), vbExclamation, "Settings: Invalid Expression")

        Catch ex As Exception
            MsgBox(String.Format("Could not save settings.{0}Error: {1}", vbCr, ex.Message))
        End Try




    End Sub
End Class