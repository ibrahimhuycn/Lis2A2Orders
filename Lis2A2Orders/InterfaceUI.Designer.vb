<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InterfaceUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterfaceUI))
        Me.TabControlOrders = New System.Windows.Forms.TabControl()
        Me.TabPageDetails = New System.Windows.Forms.TabPage()
        Me.CheckBoxQueryStatus = New System.Windows.Forms.CheckBox()
        Me.ButtonSettings = New System.Windows.Forms.Button()
        Me.ButtonSendData = New System.Windows.Forms.Button()
        Me.ButtonStartServer = New System.Windows.Forms.Button()
        Me.GroupBoxOrderTransmission = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBarSendProgress = New System.Windows.Forms.ProgressBar()
        Me.LabelProtocolName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelProtocol = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelAnalyserName = New System.Windows.Forms.Label()
        Me.GroupBoxSocketInfo = New System.Windows.Forms.GroupBox()
        Me.LabelConnectionStatus = New System.Windows.Forms.Label()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.ButtonSocketStatus = New System.Windows.Forms.Button()
        Me.LabelModeIndicator = New System.Windows.Forms.Label()
        Me.LabelIPAddress = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelConnectionIPAddress = New System.Windows.Forms.Label()
        Me.ButtonSelectOrdersFile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxOrdersPath = New System.Windows.Forms.TextBox()
        Me.TabPageLogs = New System.Windows.Forms.TabPage()
        Me.DataGridViewDisplayLogs = New System.Windows.Forms.DataGridView()
        Me.ColSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLogMessage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemSendOrders = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdersFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TabPageOptions = New System.Windows.Forms.TabPage()
        Me.LabelLastFetchedOn = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DatePicker = New System.Windows.Forms.DateTimePicker()
        Me.TimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ButtonSaveOptions = New System.Windows.Forms.Button()
        Me.LabelNextQueryOn = New System.Windows.Forms.Label()
        Me.TabControlOrders.SuspendLayout()
        Me.TabPageDetails.SuspendLayout()
        Me.GroupBoxOrderTransmission.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxSocketInfo.SuspendLayout()
        Me.TabPageLogs.SuspendLayout()
        CType(Me.DataGridViewDisplayLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripNotifyIcon.SuspendLayout()
        Me.TabPageOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlOrders
        '
        Me.TabControlOrders.Controls.Add(Me.TabPageDetails)
        Me.TabControlOrders.Controls.Add(Me.TabPageLogs)
        Me.TabControlOrders.Controls.Add(Me.TabPageOptions)
        Me.TabControlOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlOrders.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlOrders.Location = New System.Drawing.Point(0, 0)
        Me.TabControlOrders.Name = "TabControlOrders"
        Me.TabControlOrders.SelectedIndex = 0
        Me.TabControlOrders.Size = New System.Drawing.Size(428, 158)
        Me.TabControlOrders.TabIndex = 0
        '
        'TabPageDetails
        '
        Me.TabPageDetails.Controls.Add(Me.CheckBoxQueryStatus)
        Me.TabPageDetails.Controls.Add(Me.ButtonSettings)
        Me.TabPageDetails.Controls.Add(Me.ButtonSendData)
        Me.TabPageDetails.Controls.Add(Me.ButtonStartServer)
        Me.TabPageDetails.Controls.Add(Me.GroupBoxOrderTransmission)
        Me.TabPageDetails.Controls.Add(Me.GroupBox1)
        Me.TabPageDetails.Controls.Add(Me.GroupBoxSocketInfo)
        Me.TabPageDetails.Controls.Add(Me.ButtonSelectOrdersFile)
        Me.TabPageDetails.Controls.Add(Me.Label3)
        Me.TabPageDetails.Controls.Add(Me.TextBoxOrdersPath)
        Me.TabPageDetails.Location = New System.Drawing.Point(4, 23)
        Me.TabPageDetails.Name = "TabPageDetails"
        Me.TabPageDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDetails.Size = New System.Drawing.Size(420, 131)
        Me.TabPageDetails.TabIndex = 0
        Me.TabPageDetails.Text = "Details"
        Me.TabPageDetails.UseVisualStyleBackColor = True
        '
        'CheckBoxQueryStatus
        '
        Me.CheckBoxQueryStatus.AutoSize = True
        Me.CheckBoxQueryStatus.Checked = True
        Me.CheckBoxQueryStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxQueryStatus.Location = New System.Drawing.Point(187, 3)
        Me.CheckBoxQueryStatus.Name = "CheckBoxQueryStatus"
        Me.CheckBoxQueryStatus.Size = New System.Drawing.Size(77, 18)
        Me.CheckBoxQueryStatus.TabIndex = 22
        Me.CheckBoxQueryStatus.Text = "Query ON"
        Me.CheckBoxQueryStatus.UseVisualStyleBackColor = True
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Image = CType(resources.GetObject("ButtonSettings.Image"), System.Drawing.Image)
        Me.ButtonSettings.Location = New System.Drawing.Point(330, 27)
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(22, 23)
        Me.ButtonSettings.TabIndex = 21
        Me.ButtonSettings.UseVisualStyleBackColor = True
        '
        'ButtonSendData
        '
        Me.ButtonSendData.Image = CType(resources.GetObject("ButtonSendData.Image"), System.Drawing.Image)
        Me.ButtonSendData.Location = New System.Drawing.Point(302, 27)
        Me.ButtonSendData.Name = "ButtonSendData"
        Me.ButtonSendData.Size = New System.Drawing.Size(22, 23)
        Me.ButtonSendData.TabIndex = 19
        Me.ButtonSendData.UseVisualStyleBackColor = True
        '
        'ButtonStartServer
        '
        Me.ButtonStartServer.Location = New System.Drawing.Point(272, 0)
        Me.ButtonStartServer.Name = "ButtonStartServer"
        Me.ButtonStartServer.Size = New System.Drawing.Size(80, 23)
        Me.ButtonStartServer.TabIndex = 18
        Me.ButtonStartServer.Text = "Start Server"
        Me.ButtonStartServer.UseVisualStyleBackColor = True
        '
        'GroupBoxOrderTransmission
        '
        Me.GroupBoxOrderTransmission.Controls.Add(Me.Label5)
        Me.GroupBoxOrderTransmission.Controls.Add(Me.Label4)
        Me.GroupBoxOrderTransmission.Controls.Add(Me.ProgressBarSendProgress)
        Me.GroupBoxOrderTransmission.Controls.Add(Me.LabelProtocolName)
        Me.GroupBoxOrderTransmission.Controls.Add(Me.Label2)
        Me.GroupBoxOrderTransmission.Controls.Add(Me.LabelProtocol)
        Me.GroupBoxOrderTransmission.Location = New System.Drawing.Point(283, 55)
        Me.GroupBoxOrderTransmission.Name = "GroupBoxOrderTransmission"
        Me.GroupBoxOrderTransmission.Size = New System.Drawing.Size(129, 70)
        Me.GroupBoxOrderTransmission.TabIndex = 17
        Me.GroupBoxOrderTransmission.TabStop = False
        Me.GroupBoxOrderTransmission.Text = "Order Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ASTM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 12)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Version: "
        '
        'ProgressBarSendProgress
        '
        Me.ProgressBarSendProgress.Location = New System.Drawing.Point(6, 29)
        Me.ProgressBarSendProgress.Maximum = 10
        Me.ProgressBarSendProgress.Name = "ProgressBarSendProgress"
        Me.ProgressBarSendProgress.Size = New System.Drawing.Size(119, 10)
        Me.ProgressBarSendProgress.Step = 1
        Me.ProgressBarSendProgress.TabIndex = 16
        '
        'LabelProtocolName
        '
        Me.LabelProtocolName.AutoSize = True
        Me.LabelProtocolName.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProtocolName.Location = New System.Drawing.Point(58, 53)
        Me.LabelProtocolName.Name = "LabelProtocolName"
        Me.LabelProtocolName.Size = New System.Drawing.Size(66, 12)
        Me.LabelProtocolName.TabIndex = 17
        Me.LabelProtocolName.Text = "AstmVersion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Progress"
        '
        'LabelProtocol
        '
        Me.LabelProtocol.AutoSize = True
        Me.LabelProtocol.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProtocol.Location = New System.Drawing.Point(6, 42)
        Me.LabelProtocol.Name = "LabelProtocol"
        Me.LabelProtocol.Size = New System.Drawing.Size(49, 12)
        Me.LabelProtocol.TabIndex = 16
        Me.LabelProtocol.Text = "Protocol:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelAnalyserName)
        Me.GroupBox1.Location = New System.Drawing.Point(148, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(129, 70)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Analyser Infomation"
        '
        'LabelAnalyserName
        '
        Me.LabelAnalyserName.AutoSize = True
        Me.LabelAnalyserName.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAnalyserName.Location = New System.Drawing.Point(6, 17)
        Me.LabelAnalyserName.Name = "LabelAnalyserName"
        Me.LabelAnalyserName.Size = New System.Drawing.Size(73, 12)
        Me.LabelAnalyserName.TabIndex = 15
        Me.LabelAnalyserName.Text = "AnalyserName"
        '
        'GroupBoxSocketInfo
        '
        Me.GroupBoxSocketInfo.Controls.Add(Me.LabelConnectionStatus)
        Me.GroupBoxSocketInfo.Controls.Add(Me.LabelPort)
        Me.GroupBoxSocketInfo.Controls.Add(Me.ButtonSocketStatus)
        Me.GroupBoxSocketInfo.Controls.Add(Me.LabelModeIndicator)
        Me.GroupBoxSocketInfo.Controls.Add(Me.LabelIPAddress)
        Me.GroupBoxSocketInfo.Controls.Add(Me.Label1)
        Me.GroupBoxSocketInfo.Controls.Add(Me.LabelConnectionIPAddress)
        Me.GroupBoxSocketInfo.Location = New System.Drawing.Point(13, 55)
        Me.GroupBoxSocketInfo.Name = "GroupBoxSocketInfo"
        Me.GroupBoxSocketInfo.Size = New System.Drawing.Size(129, 70)
        Me.GroupBoxSocketInfo.TabIndex = 13
        Me.GroupBoxSocketInfo.TabStop = False
        Me.GroupBoxSocketInfo.Text = "Socket Infomation"
        '
        'LabelConnectionStatus
        '
        Me.LabelConnectionStatus.AutoSize = True
        Me.LabelConnectionStatus.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConnectionStatus.Location = New System.Drawing.Point(36, 53)
        Me.LabelConnectionStatus.Name = "LabelConnectionStatus"
        Me.LabelConnectionStatus.Size = New System.Drawing.Size(54, 12)
        Me.LabelConnectionStatus.TabIndex = 21
        Me.LabelConnectionStatus.Text = "Con Status"
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPort.Location = New System.Drawing.Point(46, 28)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(29, 12)
        Me.LabelPort.TabIndex = 15
        Me.LabelPort.Text = "0000"
        '
        'ButtonSocketStatus
        '
        Me.ButtonSocketStatus.Image = CType(resources.GetObject("ButtonSocketStatus.Image"), System.Drawing.Image)
        Me.ButtonSocketStatus.Location = New System.Drawing.Point(8, 43)
        Me.ButtonSocketStatus.Name = "ButtonSocketStatus"
        Me.ButtonSocketStatus.Size = New System.Drawing.Size(22, 23)
        Me.ButtonSocketStatus.TabIndex = 20
        Me.ButtonSocketStatus.UseVisualStyleBackColor = True
        '
        'LabelModeIndicator
        '
        Me.LabelModeIndicator.AutoSize = True
        Me.LabelModeIndicator.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelModeIndicator.Location = New System.Drawing.Point(36, 40)
        Me.LabelModeIndicator.Name = "LabelModeIndicator"
        Me.LabelModeIndicator.Size = New System.Drawing.Size(52, 12)
        Me.LabelModeIndicator.TabIndex = 17
        Me.LabelModeIndicator.Text = "TCP Mode"
        '
        'LabelIPAddress
        '
        Me.LabelIPAddress.AutoSize = True
        Me.LabelIPAddress.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIPAddress.Location = New System.Drawing.Point(46, 15)
        Me.LabelIPAddress.Name = "LabelIPAddress"
        Me.LabelIPAddress.Size = New System.Drawing.Size(35, 12)
        Me.LabelIPAddress.TabIndex = 14
        Me.LabelIPAddress.Text = "0.0.0.0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Port:"
        '
        'LabelConnectionIPAddress
        '
        Me.LabelConnectionIPAddress.AutoSize = True
        Me.LabelConnectionIPAddress.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConnectionIPAddress.Location = New System.Drawing.Point(6, 17)
        Me.LabelConnectionIPAddress.Name = "LabelConnectionIPAddress"
        Me.LabelConnectionIPAddress.Size = New System.Drawing.Size(18, 12)
        Me.LabelConnectionIPAddress.TabIndex = 12
        Me.LabelConnectionIPAddress.Text = "IP:"
        '
        'ButtonSelectOrdersFile
        '
        Me.ButtonSelectOrdersFile.Image = Global.Lis2A2Orders.My.Resources.Resources.Browseicon_16x16
        Me.ButtonSelectOrdersFile.Location = New System.Drawing.Point(272, 27)
        Me.ButtonSelectOrdersFile.Name = "ButtonSelectOrdersFile"
        Me.ButtonSelectOrdersFile.Size = New System.Drawing.Size(22, 23)
        Me.ButtonSelectOrdersFile.TabIndex = 11
        Me.ButtonSelectOrdersFile.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 14)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Select Orders File"
        '
        'TextBoxOrdersPath
        '
        Me.TextBoxOrdersPath.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOrdersPath.Location = New System.Drawing.Point(13, 27)
        Me.TextBoxOrdersPath.Name = "TextBoxOrdersPath"
        Me.TextBoxOrdersPath.Size = New System.Drawing.Size(251, 22)
        Me.TextBoxOrdersPath.TabIndex = 9
        '
        'TabPageLogs
        '
        Me.TabPageLogs.Controls.Add(Me.DataGridViewDisplayLogs)
        Me.TabPageLogs.Location = New System.Drawing.Point(4, 23)
        Me.TabPageLogs.Name = "TabPageLogs"
        Me.TabPageLogs.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageLogs.Size = New System.Drawing.Size(420, 131)
        Me.TabPageLogs.TabIndex = 1
        Me.TabPageLogs.Text = "Logs"
        Me.TabPageLogs.UseVisualStyleBackColor = True
        '
        'DataGridViewDisplayLogs
        '
        Me.DataGridViewDisplayLogs.AllowUserToAddRows = False
        Me.DataGridViewDisplayLogs.AllowUserToDeleteRows = False
        Me.DataGridViewDisplayLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridViewDisplayLogs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewDisplayLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDisplayLogs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSerial, Me.ColDate, Me.ColLogMessage})
        Me.DataGridViewDisplayLogs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDisplayLogs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridViewDisplayLogs.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewDisplayLogs.Name = "DataGridViewDisplayLogs"
        Me.DataGridViewDisplayLogs.ReadOnly = True
        Me.DataGridViewDisplayLogs.Size = New System.Drawing.Size(414, 125)
        Me.DataGridViewDisplayLogs.TabIndex = 1
        '
        'ColSerial
        '
        Me.ColSerial.HeaderText = "#"
        Me.ColSerial.Name = "ColSerial"
        Me.ColSerial.ReadOnly = True
        Me.ColSerial.Width = 39
        '
        'ColDate
        '
        Me.ColDate.HeaderText = "Date"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        Me.ColDate.Width = 56
        '
        'ColLogMessage
        '
        Me.ColLogMessage.HeaderText = "Log Message"
        Me.ColLogMessage.Name = "ColLogMessage"
        Me.ColLogMessage.ReadOnly = True
        Me.ColLogMessage.Width = 97
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.ContextMenuStripNotifyIcon
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "NotifyIcon"
        Me.NotifyIcon.Visible = True
        '
        'ContextMenuStripNotifyIcon
        '
        Me.ContextMenuStripNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSendOrders, Me.ToolStripMenuItemExit})
        Me.ContextMenuStripNotifyIcon.Name = "ContextMenuStripNotifyIcon"
        Me.ContextMenuStripNotifyIcon.Size = New System.Drawing.Size(139, 48)
        '
        'ToolStripMenuItemSendOrders
        '
        Me.ToolStripMenuItemSendOrders.Name = "ToolStripMenuItemSendOrders"
        Me.ToolStripMenuItemSendOrders.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemSendOrders.Text = "Send Orders"
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        Me.ToolStripMenuItemExit.Size = New System.Drawing.Size(138, 22)
        Me.ToolStripMenuItemExit.Text = "Exit"
        '
        'OrdersFileDialog
        '
        Me.OrdersFileDialog.FileName = "Orders"
        '
        'TabPageOptions
        '
        Me.TabPageOptions.Controls.Add(Me.LabelNextQueryOn)
        Me.TabPageOptions.Controls.Add(Me.ButtonSaveOptions)
        Me.TabPageOptions.Controls.Add(Me.TimePicker)
        Me.TabPageOptions.Controls.Add(Me.DatePicker)
        Me.TabPageOptions.Controls.Add(Me.Label6)
        Me.TabPageOptions.Controls.Add(Me.LabelLastFetchedOn)
        Me.TabPageOptions.Location = New System.Drawing.Point(4, 23)
        Me.TabPageOptions.Name = "TabPageOptions"
        Me.TabPageOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOptions.Size = New System.Drawing.Size(420, 131)
        Me.TabPageOptions.TabIndex = 2
        Me.TabPageOptions.Text = "LIS Query Options"
        Me.TabPageOptions.UseVisualStyleBackColor = True
        '
        'LabelLastFetchedOn
        '
        Me.LabelLastFetchedOn.AutoSize = True
        Me.LabelLastFetchedOn.Location = New System.Drawing.Point(6, 3)
        Me.LabelLastFetchedOn.Name = "LabelLastFetchedOn"
        Me.LabelLastFetchedOn.Size = New System.Drawing.Size(90, 14)
        Me.LabelLastFetchedOn.TabIndex = 0
        Me.LabelLastFetchedOn.Tag = "Last Query On: "
        Me.LabelLastFetchedOn.Text = "Last Query On:  "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 14)
        Me.Label6.TabIndex = 1
        Me.Label6.Tag = ""
        Me.Label6.Text = "Set Next Query Date and Time: "
        '
        'DatePicker
        '
        Me.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePicker.Location = New System.Drawing.Point(9, 69)
        Me.DatePicker.Name = "DatePicker"
        Me.DatePicker.Size = New System.Drawing.Size(91, 22)
        Me.DatePicker.TabIndex = 2
        '
        'TimePicker
        '
        Me.TimePicker.CustomFormat = "HH:mm"
        Me.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TimePicker.Location = New System.Drawing.Point(106, 69)
        Me.TimePicker.Name = "TimePicker"
        Me.TimePicker.ShowUpDown = True
        Me.TimePicker.Size = New System.Drawing.Size(70, 22)
        Me.TimePicker.TabIndex = 3
        '
        'ButtonSaveOptions
        '
        Me.ButtonSaveOptions.Location = New System.Drawing.Point(182, 68)
        Me.ButtonSaveOptions.Name = "ButtonSaveOptions"
        Me.ButtonSaveOptions.Size = New System.Drawing.Size(70, 23)
        Me.ButtonSaveOptions.TabIndex = 4
        Me.ButtonSaveOptions.Text = "Save"
        Me.ButtonSaveOptions.UseVisualStyleBackColor = True
        '
        'LabelNextQueryOn
        '
        Me.LabelNextQueryOn.AutoSize = True
        Me.LabelNextQueryOn.Location = New System.Drawing.Point(3, 17)
        Me.LabelNextQueryOn.Name = "LabelNextQueryOn"
        Me.LabelNextQueryOn.Size = New System.Drawing.Size(90, 14)
        Me.LabelNextQueryOn.TabIndex = 5
        Me.LabelNextQueryOn.Tag = "Next Query On: "
        Me.LabelNextQueryOn.Text = "Next Query On: "
        '
        'InterfaceUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 158)
        Me.Controls.Add(Me.TabControlOrders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "InterfaceUI"
        Me.TabControlOrders.ResumeLayout(False)
        Me.TabPageDetails.ResumeLayout(False)
        Me.TabPageDetails.PerformLayout()
        Me.GroupBoxOrderTransmission.ResumeLayout(False)
        Me.GroupBoxOrderTransmission.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBoxSocketInfo.ResumeLayout(False)
        Me.GroupBoxSocketInfo.PerformLayout()
        Me.TabPageLogs.ResumeLayout(False)
        CType(Me.DataGridViewDisplayLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripNotifyIcon.ResumeLayout(False)
        Me.TabPageOptions.ResumeLayout(False)
        Me.TabPageOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlOrders As TabControl
    Friend WithEvents TabPageLogs As TabPage
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents ContextMenuStripNotifyIcon As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemSendOrders As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemExit As ToolStripMenuItem
    Friend WithEvents DataGridViewDisplayLogs As DataGridView
    Friend WithEvents TabPageDetails As TabPage
    Friend WithEvents ButtonSelectOrdersFile As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxOrdersPath As TextBox
    Friend WithEvents OrdersFileDialog As OpenFileDialog
    Friend WithEvents GroupBoxSocketInfo As GroupBox
    Friend WithEvents LabelPort As Label
    Friend WithEvents LabelIPAddress As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelConnectionIPAddress As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelAnalyserName As Label
    Friend WithEvents GroupBoxOrderTransmission As GroupBox
    Friend WithEvents ProgressBarSendProgress As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents ColSerial As DataGridViewTextBoxColumn
    Friend WithEvents ColDate As DataGridViewTextBoxColumn
    Friend WithEvents ColLogMessage As DataGridViewTextBoxColumn
    Friend WithEvents LabelProtocolName As Label
    Friend WithEvents LabelProtocol As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonStartServer As Button
    Friend WithEvents ButtonSendData As Button
    Friend WithEvents ButtonSocketStatus As Button
    Friend WithEvents LabelModeIndicator As Label
    Friend WithEvents ButtonSettings As Button
    Friend WithEvents CheckBoxQueryStatus As CheckBox
    Friend WithEvents LabelConnectionStatus As Label
    Friend WithEvents TabPageOptions As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents LabelLastFetchedOn As Label
    Friend WithEvents TimePicker As DateTimePicker
    Friend WithEvents DatePicker As DateTimePicker
    Friend WithEvents ButtonSaveOptions As Button
    Friend WithEvents LabelNextQueryOn As Label
End Class
