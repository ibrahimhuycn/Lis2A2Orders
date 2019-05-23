Public Class Settings
    Private _AnalysisCategory As String
    Private _connectionType As String
    Private _isServer As Boolean
    Private _tabPage2Name As String

    Public Sub New()
        ChemistryParameters = My.Settings.ParametersCHM.Split("|")
        DepositParameters = My.Settings.ParametersFCM.Split("|")
    End Sub

    Private Enum AnalysisCategories
        Both
        Chemistry
        Deposit
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

    Public Property AnalysisCategory As String
        Get
            Return _AnalysisCategory
        End Get
        Set
            Select Case Value
                Case AnalysisCategories.Both
                    AnalysisCategories.Both.ToString()

                Case AnalysisCategories.Chemistry
                    AnalysisCategories.Chemistry.ToString()

                Case AnalysisCategories.Deposit
                    AnalysisCategories.Deposit.ToString()
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
    Public Property OrdersDir As String

    Public Property Port As Integer
    Public Property SerialPort As String
    Public Property OrdersFileCheckIndicatorExtension As String
    Public Property OrdersFileExtension As String
    Public Property OrdersFilePrefix As String
    Public Property SelectedOrdersFile As String


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



                Dim saves As New My.MySettings With {.AnalysisCategories = newSettings.AnalysisCategory,
                    .AppName = newSettings.AppName,
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
                    .SelectedOrdersFile = newSettings.SelectedOrdersFile}
            End If
        Catch ex As InvalidExpressionException
            MsgBox(String.Format("Could not save settings.{0}Error: {1}", vbCr, ex.Message), vbExclamation, "Settings: Invalid Expression")

        Catch ex As Exception
            MsgBox(String.Format("Could not save settings.{0}Error: {1}", vbCr, ex.Message))
        End Try




    End Sub
End Class