Imports Essy.Lis.LIS02A2
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection

<Assembly: log4net.Config.XmlConfigurator(Watch:=True)>

Public Class InterfaceUI
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Event RequireLogsDisplay(ByVal logMessage As String, ByVal logType As LogItem.LogType)
    Private Event OnAppSettingsRefreshed(ByVal settings As Settings)
    Private Event OnRefreshAppSettings()
    Private Delegate Sub UpdateGrid(dgv As DataGridView, row As DataGridViewRow)
    Private Delegate Sub UpdateLabels(lbl As Label, ByVal content As String)
    Private Delegate Sub UpdateProgressBar(ProgressUI As ProgressBar, Progress As Decimal)
    Dim AppSettings As Settings
    Dim DisplaySeq As Integer = 0
    Dim _astmConnection As Connection

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
            log.Info(Progress)
        End If
    End Sub

    Public Sub New()
        InitializeComponent()

        'Setting up method name for logging.
        Dim myName As String = MethodBase.GetCurrentMethod().Name
        DisplayLogItem("Sub: [" & myName & "]- Initializing...", LogItem.LogType.Information)

        RaiseEvent OnRefreshAppSettings()
        _astmConnection = New Connection(AppSettings)

        AddHandler Me.RequireLogsDisplay, AddressOf DisplayLogItem
        AddHandler Connection.PushingLogs, AddressOf DisplayLogItem
        AddHandler Connection.ReceivedHeader, AddressOf UpdateUIBasedOnHeader
        AddHandler Connection.ReportProgress, AddressOf ProgressDisplayUI
        AddHandler ButtonStartServer.Click, AddressOf _astmConnection.InitializeConnection
        AddHandler ButtonSendData.Click, AddressOf PrepInitiateNewRequest
    End Sub

    Private Sub PrepInitiateNewRequest()

        Dim Data As IEnumerable(Of LisRequestData) = LisEnquiry.GetData(Now.ToString("yyyy/MM/dd") & " 13:30:000")
        If Not Data.Count = 0 Then
            Dim LastSampleTime = Data(Data.Count - 1).created_at
            My.Settings.LastSampleTime = LastSampleTime.ToString("yyyy/MMM/dd HH:mm:ss.fff")
            Try
                Dim Requests As New RequestDataEventArgs
                Requests.RequestData.Clear()

                For Each d In Data
                    Dim Sex As PatientSex
                    If d.Genders_id = 1 Then Sex = PatientSex.Male
                    If d.Genders_id = 2 Then Sex = PatientSex.Female
                    Dim LastName As String = ""
                    Dim FirstName As String = ""
                    Dim PatientNamesSplit = d.PatientName.Split(" ")
                    LastName = PatientNamesSplit(PatientNamesSplit.Count - 1)
                    Dim RequestedTestsList As String = ""
                    If My.Settings.ActiveTestOrders.ToUpper = "ALL" Then RequestedTestsList = My.Settings.ParametersAll
                    If My.Settings.ActiveTestOrders.ToUpper = "CHM" Then RequestedTestsList = My.Settings.ParametersCHM
                    If My.Settings.ActiveTestOrders.ToUpper = "FCM" Then RequestedTestsList = My.Settings.ParametersFCM

                    For Each n In PatientNamesSplit
                        If Not n = LastName Then
                            FirstName = FirstName & " " & n
                        End If
                        FirstName.Trim()
                    Next

                    'Note Action code will be set during transmission
                    Requests.RequestData.Add(New Request With {.Priority = OrderPriority.Stat,
                                             .SampleCollectionTime = d.created_at,
                                             .Patient = New Patient With {.PatientID = d.PatientNo,
                                                            .BirthDate = d.DateOfBirth,
                                                            .PatientSex = Sex,
                                                            .PatientName = New PatientName With {.LastName = LastName, .FirstName = FirstName}},
                                              .OrderNumber = Now.ToString("mm:ss.fff"),
                                              .Specimen = New Sample With {.SpecimenID = d.Barcode},
                                              .RequestedTests = RequestedTestsList})
                Next

                _astmConnection.PrepAndSendData(Requests)
            Catch ex As Exception

            End Try
        End If

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

        log.Info("Sub: [" & myName & "]- Application settings refreshed")
        DisplayLogItem("Sub: [" & myName & "]- Application settings refreshed", LogItem.LogType.Information)

    End Sub

    Private Sub ButtonSelectOrdersFile_Click(sender As Object, e As EventArgs) Handles ButtonSelectOrdersFile.Click
        'Setting up method name for logging.
        Dim myName As String = MethodBase.GetCurrentMethod().Name
        log.Info("Sub: [" & myName & "]- Selecting orders file")

        Dim EpisodeNo() As String
        Try
            'OPEN DIALOG AND STORES ALL EPIDSODE NUMBERS IN ARRAY
            If OrdersFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                My.Settings.OrdersFilePath = OrdersFileDialog.FileName
                RaiseEvent OnRefreshAppSettings()
                log.Info("Sub: [" & myName & "]- Orders File Name: " & OrdersFileDialog.FileName)
                EpisodeNo = File.ReadAllLines(OrdersFileDialog.FileName)
                log.Info("Sub: [" & myName & "]- Episode Numbers: " & EpisodeNo.ToString)

            ElseIf DialogResult.Cancel Then
                log.Info("Sub: [" & myName & "]- Cancelled selection of orders file.")
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
            log.Info(String.Format("{0}. {1}", logType, logMessage))
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
        log.Info("Sub: [" & myName & "]- Refreshing application settings")

        Dim settings As New Settings With {.AppName = My.Settings.AppName,
            .IsServer = My.Settings.IsServer,
            .NotifyIconText = My.Settings.NotifyIconText,
            .IPAddress = My.Settings.IPAddress,
            .Port = My.Settings.Port,
            .SerialPort = My.Settings.PortCOM,
            .ConnectionType = My.Settings.EthernetOrSerial,
            .OrdersFilePath = My.Settings.OrdersFilePath,
            .ActiveTestOrders = My.Settings.ActiveTestOrders}


        log.Info(String.Format("Sub: [{0}]- Settings: IsServer: {1} NotifyIconText: {2} IP: {3} Port: {4} COM Port: {5} ConnectionType: {6} OrdersFilePath: {7}",
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



End Class