Imports Essy.Lis.LIS02A2
Imports slf4net
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection

<Assembly: log4net.Config.XmlConfigurator(Watch:=True)>

Public Class InterfaceUI
    Implements INotifyPropertyChanged
    'Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Shared ReadOnly _logger As ILogger = LoggerFactory.GetLogger(GetType(InterfaceUI))
    Dim WithEvents LisQueryInit As Timer = New Timer With {.Enabled = False, .Interval = My.Settings.LisQueryIntervalMinutes * 1000 * 60}
    Dim WithEvents DataTransmitInit As Timer = New Timer With {.Enabled = False, .Interval = 20}
    Private Event RequireLogsDisplay(ByVal logMessage As String, ByVal logType As LogItem.LogType)
    Private Event OnAppSettingsRefreshed(ByVal settings As Settings)
    Private Event OnRefreshAppSettings()
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Delegate Sub UpdateGrid(dgv As DataGridView, row As DataGridViewRow)
    Private Delegate Sub UpdateLabels(lbl As Label, ByVal content As String)
    Private Delegate Sub UpdateProgressBar(ProgressUI As ProgressBar, Progress As Decimal)
    Dim AppSettings As Settings
    Dim DisplaySeq As Integer = 0
    Dim _astmConnection As Connection
    Dim _fetchWithTime As String
    Private Property FetchWithTime As String
        Get
            Return _fetchWithTime
        End Get
        Set
            If _fetchWithTime Is Value Then
                Return
            End If
            _fetchWithTime = Value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(FetchWithTime)))
        End Set
    End Property

    Dim IsSendModeEstablished As Boolean = False

    Private Sub UpdateLabel(label As Label, ByVal content As String)
        If label.InvokeRequired Then
            label.Invoke(New UpdateLabels(AddressOf UpdateLabel), New Object() {label, content})
        Else
            label.Text = content
        End If
    End Sub
    Private Sub UpdateProgress(ProgressUI As ProgressBar, ByVal Progress As Decimal)
        If ProgressUI.InvokeRequired Then
            ProgressUI.Invoke(New UpdateProgressBar(AddressOf UpdateProgress), New Object() {ProgressUI, Progress})
        Else
            ProgressUI.Value = Progress
            _logger.Info(Progress)
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        LisQueryInit.Enabled = True
        DataTransmitInit.Enabled = True
        'Setting up method name for logging.
        Dim myName As String = MethodBase.GetCurrentMethod().Name
        DisplayLogItem("Sub: [" & myName & "]- Initializing...", LogItem.LogType.Information)

        RaiseEvent OnRefreshAppSettings()
        _astmConnection = New Connection(AppSettings)
        AddHandler LisQueryInit.Tick, AddressOf QueryLisServer
        AddHandler DataTransmitInit.Tick, AddressOf PrepTransmissionToAnalyser
        AddHandler Me.RequireLogsDisplay, AddressOf DisplayLogItem
        AddHandler Connection.PushingLogs, AddressOf DisplayLogItem
        AddHandler SqliteDataAccess.PushingLogs, AddressOf DisplayLogItem
        AddHandler Connection.ReceivedHeader, AddressOf UpdateUIBasedOnHeader
        AddHandler Connection.ReportProgress, AddressOf ProgressDisplayUI
        AddHandler ButtonStartServer.Click, AddressOf _astmConnection.InitializeConnection
        AddHandler ButtonSendData.Click, AddressOf PrepTransmissionToAnalyser

        AddHandler _astmConnection.IsConnectionEstablished, AddressOf DisplayConnectionStatus
        AddHandler _astmConnection.StartServerButtonState, AddressOf EnableDisableButton


    End Sub

    Private Sub EnableDisableButton(enabled As Boolean)
        Me.ButtonStartServer.Enabled = enabled
    End Sub

    Private Sub DisplayConnectionStatus(sender As Object, isConnected As Boolean, connectionStatus As String)
        Dim icons As New Icons
        Select Case isConnected
            Case True
                ButtonSocketStatus.Image = Icons.GetIcon(icons.Connected)
                IsSendModeEstablished = True
            Case False
                ButtonSocketStatus.Image = Icons.GetIcon(icons.Disconnected)
                IsSendModeEstablished = False
        End Select
        LabelConnectionStatus.Text = connectionStatus
    End Sub

    Private Sub QueryLisServer(sender As Object, e As EventArgs)
        If ButtonStartServer.Enabled = False Then
            ButtonSendData.Enabled = False
            If FetchWithTime = Nothing Then
                FetchWithTime = Now.ToString("yyyy/MM/dd" & " 00:00:00.000")
            End If

            RaiseEvent RequireLogsDisplay("Querying LIS server for samples.", LogItem.LogType.Information)

            Try
                Dim Data As IList(Of LisRequestDataModel) = LisEnquiry.GetData(FetchWithTime).ToList

                'If the query result does not have any samples then exit sub.
                If Data.Count = 0 Then
                    RaiseEvent RequireLogsDisplay("LIS didn't return any samples...", LogItem.LogType.Information)

                    Exit Sub
                End If

                LabelLastFetchedOn.Text = LabelLastFetchedOn.Tag & FetchWithTime
                FetchWithTime = Data(Data.Count - 1).created_at.AddMinutes(1).ToString("yyyy/MM/dd HH:mm:ss.fff")

                LabelNextQueryOn.Text = LabelNextQueryOn.Tag & FetchWithTime
                ButtonSendData.Enabled = True
                SqliteDataAccess.SaveRequest(Data)
            Catch ex As Exception
                ButtonSendData.Enabled = True
                RaiseEvent RequireLogsDisplay(ex.Message, LogItem.LogType.Exception)
            End Try
        End If
    End Sub
    Private Function QueryLocalDB() As List(Of LisRequestDataModel)
        Try
            RaiseEvent RequireLogsDisplay("2.1", LogItem.LogType.Information)
            Dim Data As List(Of LisRequestDataModel) = SqliteDataAccess.LoadOneRequests()
            RaiseEvent RequireLogsDisplay("2.2", LogItem.LogType.Information)
            Return Data
        Catch ex As Exception
            RaiseEvent RequireLogsDisplay(ex.Message, LogItem.LogType.Exception)
            Return New List(Of LisRequestDataModel)
        End Try
    End Function


    Private Sub PrepTransmissionToAnalyser(sender As Object, e As EventArgs)

        DataTransmitInit.Enabled = False
        If ButtonStartServer.Enabled = True Then
            DataTransmitInit.Enabled = True
            Exit Sub
        End If

        RaiseEvent RequireLogsDisplay("1.0", LogItem.LogType.Information)

        Dim Data As List(Of LisRequestDataModel) = QueryLocalDB()
        If Data Is Nothing Then Exit Sub
        RaiseEvent RequireLogsDisplay("1.1", LogItem.LogType.Information)

        RaiseEvent RequireLogsDisplay($"Count of data list read from localDB: {Data.Count}", LogItem.LogType.Information)

        If Not Data.Count = 0 Then
            'Increase the checking job rate... since samples are present
            DataTransmitInit.Interval = 20
            RaiseEvent RequireLogsDisplay($"Checking for new samples after {DataTransmitInit.Interval} milliseconds", LogItem.LogType.Information)

            RaiseEvent RequireLogsDisplay("1.2", LogItem.LogType.Information)

            Try

                Dim Requests As New RequestDataEventArgs
                Requests.RequestData.Clear()
                RaiseEvent RequireLogsDisplay("2", LogItem.LogType.Information)

                For Each d In Data
                    Dim Sex As PatientSex
                    If d.Genders_id = 1 Then Sex = PatientSex.Male
                    If d.Genders_id = 2 Then Sex = PatientSex.Female
                    Dim LastName As String = ""
                    Dim FirstName As String = ""
                    Dim PatientNamesSplit = d.PatientName.Split(" ")
                    LastName = PatientNamesSplit(PatientNamesSplit.Count - 1)
                    Dim RequestedTestsGroup As String = ""
                    If My.Settings.ActiveTestOrders.ToUpper = "ALL" Then RequestedTestsGroup = My.Settings.ParametersAll
                    If My.Settings.ActiveTestOrders.ToUpper = "CHM" Then RequestedTestsGroup = My.Settings.ParametersCHM
                    If My.Settings.ActiveTestOrders.ToUpper = "FCM" Then RequestedTestsGroup = My.Settings.ParametersFCM

                    For Each n In PatientNamesSplit
                        If Not n = LastName Then
                            FirstName = FirstName & " " & n
                        End If
                        FirstName.Trim()
                    Next

                    RaiseEvent RequireLogsDisplay("3", LogItem.LogType.Information)

                    'Note Action code will be set during transmission
                    Requests.RequestData.Add(New Request With {.Priority = OrderPriority.Routine,
                                             .SampleCollectionTime = d.created_at,
                                             .Patient = New Patient With {.PatientID = d.PatientNo,
                                                            .BirthDate = d.DateOfBirth,
                                                            .PatientSex = Sex,
                                                            .PatientName = New PatientName With {.LastName = LastName, .FirstName = FirstName}},
                                              .Specimen = New Sample With {.SpecimenID = d.Barcode},
                                              .RequestedTests = RequestedTestsGroup})
                Next

                _astmConnection.PrepAndSendData(Requests)
                RaiseEvent RequireLogsDisplay("4", LogItem.LogType.Information)
            Catch ex As Exception
                RaiseEvent RequireLogsDisplay(ex.Message, LogItem.LogType.Exception)
                RaiseEvent RequireLogsDisplay("5", LogItem.LogType.Information)

            End Try

        Else
            'Since there are no samples on LocalDB, increase the time interval to check for samples.
            DataTransmitInit.Interval = 5000
            RaiseEvent RequireLogsDisplay($"Checking for new samples after {DataTransmitInit.Interval} milliseconds", LogItem.LogType.Information)

        End If
        DataTransmitInit.Enabled = True
        RaiseEvent RequireLogsDisplay("6", LogItem.LogType.Information)

    End Sub

    Private Sub ProgressDisplayUI(progress As Double)
        UpdateProgress(ProgressBarSendProgress, progress)
    End Sub


    Private Sub AppSettingsRefreshed(ByVal settings As Settings) Handles Me.OnAppSettingsRefreshed
        'Setting up method name for logging.
        Dim myName As String = MethodBase.GetCurrentMethod().Name
        AppSettings = settings

        Me.Text = AppSettings.AppName
        Me.NotifyIcon.Text = AppSettings.NotifyIconText
        TabControlOrders.TabPages.Item(1).Text = AppSettings.TabPage2Name
        LabelIPAddress.Text = AppSettings.IPAddress
        LabelPort.Text = AppSettings.Port
        LabelModeIndicator.Text = If(AppSettings.IsServer = True, "Server", "Client")
        ButtonStartServer.Text = If(AppSettings.IsServer = True, "Start Server", "Connect")
        TextBoxOrdersPath.Text = AppSettings.OrdersFilePath

        _logger.Info("Sub: [" & myName & "]- Application settings refreshed")
        DisplayLogItem("Sub: [" & myName & "]- Application settings refreshed", LogItem.LogType.Information)

    End Sub

    Private Sub ButtonSelectOrdersFile_Click(sender As Object, e As EventArgs) Handles ButtonSelectOrdersFile.Click
        'Setting up method name for logging.
        Dim myName As String = MethodBase.GetCurrentMethod().Name
        _logger.Info("Sub: [" & myName & "]- Selecting orders file")

        Dim EpisodeNo() As String
        Try
            'OPEN DIALOG AND STORES ALL EPIDSODE NUMBERS IN ARRAY
            If OrdersFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                My.Settings.OrdersFilePath = OrdersFileDialog.FileName
                RaiseEvent OnRefreshAppSettings()
                _logger.Info("Sub: [" & myName & "]- Orders File Name: " & OrdersFileDialog.FileName)
                EpisodeNo = File.ReadAllLines(OrdersFileDialog.FileName)
                _logger.Info("Sub: [" & myName & "]- Episode Numbers: " & EpisodeNo.ToString)

            ElseIf DialogResult.Cancel Then
                _logger.Info("Sub: [" & myName & "]- Cancelled selection of orders file.")
                Exit Sub
            End If
        Catch ex As Exception
            DisplayLogItem(ex.Message, LogItem.LogType.Exception)
        End Try
    End Sub

    Public Sub DisplayLogItem(ByVal logMessage As String, ByVal logType As LogItem.LogType)
        Try
            DisplaySeq += 1
            Dim Row As New DataGridViewRow
            Row.Cells.Add(New DataGridViewTextBoxCell With {.Value = DisplaySeq})
            Row.Cells.Add(New DataGridViewTextBoxCell With {.Value = Date.Now().ToString})
            Row.Cells.Add(New DataGridViewTextBoxCell With {.Value = logType.ToString & ": " & logMessage.ToString})
            UpdateGridView(DataGridViewDisplayLogs, Row)
            _logger.Info(String.Format("{0}. {1}", logType, logMessage))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
    Private Sub UpdateGridView(dgv As DataGridView, row As DataGridViewRow)
        If dgv.InvokeRequired = True Then
            dgv.Invoke(New UpdateGrid(AddressOf UpdateGridView), New Object() {dgv, row})
        Else
            dgv.Rows.Add(row)
        End If
    End Sub
    Private Sub RefreshAppSettings() Handles Me.OnRefreshAppSettings
        'Setting up method name for logging.
        Dim myName As String = MethodBase.GetCurrentMethod().Name
        _logger.Info("Sub: [" & myName & "]- Refreshing application settings")

        Dim settings As New Settings With {.AppName = My.Settings.AppName,
            .IsServer = My.Settings.IsServer,
            .NotifyIconText = My.Settings.NotifyIconText,
            .IPAddress = My.Settings.IPAddress,
            .Port = My.Settings.Port,
            .SerialPort = My.Settings.PortCOM,
            .ConnectionType = My.Settings.EthernetOrSerial,
            .OrdersFilePath = My.Settings.OrdersFilePath,
            .ActiveTestOrders = My.Settings.ActiveTestOrders}


        _logger.Info(String.Format("Sub: [{0}]- Settings: IsServer: {1} NotifyIconText: {2} IP: {3} Port: {4} COM Port: {5} ConnectionType: {6} OrdersFilePath: {7}",
                               myName, settings.IsServer, settings.NotifyIconText, settings.IPAddress, settings.Port,
                               settings.SerialPort, settings.ConnectionType, settings.OrdersFilePath))
        RaiseEvent OnAppSettingsRefreshed(settings)

    End Sub

    Private Sub DataGridViewDisplayLogs_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewDisplayLogs.RowsAdded
        DataGridViewDisplayLogs.Sort(ColSerial, ListSortDirection.Descending)
        'Do something to remove rows before it gets too slow.
    End Sub
    Private Sub UpdateUIBasedOnHeader(ByVal sender As Object, ByVal record As HeaderRecord)
        Dim senderID() As String = record.SenderID.Split("^")
        Dim DisplayID As String = Nothing
        For Each field In senderID
            If Not DisplayID = Nothing Then
                If Not field = Nothing Then DisplayID += vbCr & field
            Else
                DisplayID = field
            End If
        Next

        UpdateLabel(LabelAnalyserName, DisplayID)
        UpdateLabel(LabelProtocolName, record.Version)
    End Sub

    Private Sub CheckBoxQueryStatus_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxQueryStatus.CheckedChanged
        If CheckBoxQueryStatus.Checked = True Then
            CheckBoxQueryStatus.Text = "Query ON"
            LisQueryInit.Enabled = True

        Else
            CheckBoxQueryStatus.Text = "Query OFF"
            LisQueryInit.Enabled = False
        End If
    End Sub

    Private Sub ButtonSaveOptions_Click(sender As Object, e As EventArgs) Handles ButtonSaveOptions.Click
        FetchWithTime = DatePicker.Text & " " & TimePicker.Text
    End Sub
End Class