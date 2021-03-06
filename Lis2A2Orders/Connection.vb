﻿Imports Essy.Lis.Connection
Imports Essy.Lis.LIS02A2
Imports slf4net
Imports System.Reflection
Imports System.Text
Imports System.Threading

Public Class Connection
    'Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    Private Shared ReadOnly _logger As ILogger = LoggerFactory.GetLogger(GetType(Connection))
    Private WithEvents _lisParser As LISParser
    Private _connectionSettings As Settings
    Private _lisConnection As Lis01A2Connection
    Public Event StartServerButtonState(enabled As Boolean)
    Public Shared Event PushingLogs(ByVal logMessage As String, ByVal logType As LogItem.LogType)
    Public Shared Event ReportProgress(ByVal progress As Double)
    Public Shared Event ReceivedHeader(ByVal sender As Object, ByVal record As HeaderRecord)
    Public Shared Event ReceivedPatient(ByVal sender As Object, ByVal record As PatientRecord)
    Public Shared Event ReceiveQuery(ByVal sender As Object, ByVal record As QueryRecord)
    Public Shared Event StartListener(ByVal conn As Lis01A02TCPConnection)
    Public Event IsConnectionEstablished(ByVal sender As Object, ByVal isConnected As Boolean, connectionStatus As String)

    Public Sub New(ByVal connectionSettings As Settings)
        Me._connectionSettings = connectionSettings
    End Sub

    Public Sub InitializeConnection()
        RaiseEvent StartServerButtonState(False)
        Dim connectionSettings As Settings = Me._connectionSettings
        Select Case connectionSettings.ConnectionType

            Case ConnectionType.Ethernet

                Dim CnxIP As String = connectionSettings.IPAddress
                Dim CnxPort As Integer = connectionSettings.Port
                Dim lowLevelConnection As New Lis01A02TCPConnection(CnxIP, CnxPort)

                Try

                    _lisConnection = New Lis01A2Connection(lowLevelConnection)
                    _lisParser = New LISParser(_lisConnection)
                    AddHandler _lisParser.OnExceptionHappened, AddressOf OnException
                    Select Case connectionSettings.IsServer
                        Case True
                            Dim a = StartListenerAsync(lowLevelConnection).GetAwaiter()
                            _lisParser.Connection.Status = LisConnectionStatus.Idle
                        Case False

                            _lisParser.Connection.Connect()

                    End Select
                    AddHandler _lisParser.OnSendProgress, AddressOf LISParser_OnSendProgress
                    AddHandler _lisParser.OnReceivedRecord, AddressOf LISParser_OnReceivedRecord
                Catch ex As Exception
                    RaiseEvent StartServerButtonState(True)
                    RaiseEvent PushingLogs(ex.Message, EventLogEntryType.Error)
                    _logger.Error(ex.Message & vbCrLf & ex.StackTrace)
                End Try


            Case ConnectionType.Serial
                Dim SerialPort = New IO.Ports.SerialPort(connectionSettings.SerialPort)
                Dim lowLevelConnection = New Lis01A02RS232Connection(SerialPort)
                Dim lisConnection = New Lis01A2Connection(lowLevelConnection)
        End Select

    End Sub

    Private Sub OnException(sender As Object, e As ThreadExceptionEventArgs)
        RaiseEvent PushingLogs(e.Exception.Message, LogItem.LogType.Exception)
        _logger.Error(e.Exception.Message & e.Exception.StackTrace)
    End Sub

    Private Async Function StartListenerAsync(ByVal conn As Lis01A02TCPConnection) As Task

        'Todo: How do I check whether I am successfully listening or that I am connected to a client on the port?
        Try
            Await Task.Run(Function() conn.StartListeningAsync())
        Catch ex As Exception
            RaiseEvent PushingLogs(ex.Message, EventLogEntryType.Error)
            _logger.Error(ex.StackTrace)
        End Try



    End Function


    Public Enum ConnectionType
        Ethernet
        Serial
    End Enum

    Private Sub LISParser_OnReceivedRecord(ByVal Sender As Object, ByVal e As ReceiveRecordEventArgs)
        Dim record As AbstractLisRecord = e.ReceivedRecord
        RaiseEvent PushingLogs(record.ToLISString, LogItem.LogType.Received)
        RaiseEvent PushingLogs(record.GetType.ToString, LogItem.LogType.Information)

        Select Case e.RecordType
            Case LisRecordType.Header
                Dim Header As HeaderRecord = record
            Case LisRecordType.Patient
                Dim Patient As PatientRecord = record
            Case LisRecordType.Order
            Case LisRecordType.Result
                Dim Query As QueryRecord = record
                RaiseEvent ReceiveQuery(Me, Query)
            Case LisRecordType.Comment
            Case LisRecordType.Query
            Case LisRecordType.Terminator
            Case LisRecordType.Scientific
            Case LisRecordType.Information
        End Select
    End Sub

    Private Sub LISParser_OnSendProgress(ByVal sender As Object, ByVal e As SendProgressEventArgs)
        RaiseEvent ReportProgress(e.Progress * 10)
    End Sub
    Public Function ReplaceControlCharacters(astmFrame As String) As String
        Dim ReplcedAstmFrame As StringBuilder = New StringBuilder(astmFrame)

        ReplcedAstmFrame.Replace(ChrW(AstmConstants.STX), "[STX]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ETX), "[ETX]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.EOT), "[EOT]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ENQ), "[ENQ]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ACK), "[ACK]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.LF), "[LF]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.CR), "[CR]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.NAK), "[NAK]")
        ReplcedAstmFrame.Replace(ChrW(AstmConstants.ETB), "[ETB]")

        Return ReplcedAstmFrame.ToString
    End Function

    Public Sub PrepAndSendData(e As RequestDataEventArgs)
        Dim lisRecordList = New List(Of Essy.Lis.LIS02A2.AbstractLisRecord)()
        Dim hr = New HeaderRecord() With {
            .SenderID = "Path.Clinical"}
        lisRecordList.Add(hr)

        Dim PatientSequence As Integer = 1
        For Each request In e.RequestData
            Dim Patient = New PatientRecord() With {.SequenceNumber = PatientSequence,
                .LaboratoryAssignedPatientID = request.Patient.PatientID,
                .PatientName = request.Patient.PatientName,
                .Birthdate = request.Patient.BirthDate,
                .PatientSex = request.Patient.PatientSex,
                .AdmissionStatus = AdmissionStatus.OutPatient}

            lisRecordList.Add(Patient)

            PatientSequence += 1
            Dim OrderSequenceNo As Integer = 1
            Dim parameters() As String = request.RequestedTests.Split("|")

            For Each param In parameters

                request.TestActionCode = TestActionCode.A
                If OrderSequenceNo = 1 Then request.TestActionCode = TestActionCode.N

                Dim Orders As New OrderRecord With {.SequenceNumber = OrderSequenceNo,
                    .ActionCode = request.TestActionCode,
                    .Priority = request.Priority,
                    .ReportType = request.ReportType,
                    .RequestedDateTime = Nothing,
                    .SpecimenID = request.Specimen.SpecimenID,
                    .TestID = New UniversalTestID() With {.ManufacturerCode = param},
                    .SpecimenCollectionDateTime = request.SampleCollectionTime,
                    .OrderingPhysician = "D1^D^A^^^Dr.",
                    .PhysicianTelephoneNumber = "01-123-4567",
                    .UserFieldNumber1 = Now.ToString("ddMMyyHHmmssfff"),
                    .LocationSpecimenCollection = "OPD^E^C.PATH-5678-0123",
                    .SpecimenInstitution = "C. Path^Clinical Pathology"}  'OrderNumber a SubString of Time


                lisRecordList.Add(Orders)
                OrderSequenceNo += 1
            Next

        Next
        Dim tr = New TerminatorRecord()
        lisRecordList.Add(tr)
        InterfaceUI.ButtonSendData.Enabled = True

        Try
            RaiseEvent IsConnectionEstablished(Me, True, LisConnectionStatus.Sending.ToString)
            If _lisConnection.Status = LisConnectionStatus.Idle Then

                RaiseEvent IsConnectionEstablished(Me, True, _lisConnection.Status.ToString)
                If _lisParser Is Nothing Then
                    InitializeConnection()
                    Exit Sub
                End If
                _lisParser?.SendRecords(lisRecordList)
                RaiseEvent IsConnectionEstablished(Me, True, _lisConnection.Status.ToString)

            End If

            Try
                For Each request In e.RequestData
                    SqliteDataAccess.DeleteRequest(request.Specimen.SpecimenID)
                    RaiseEvent IsConnectionEstablished(Me, True, _lisConnection.Status.ToString)
                Next
                RaiseEvent IsConnectionEstablished(Me, True, _lisConnection.Status.ToString)

            Catch ex As Exception
                RaiseEvent PushingLogs(ex.Message, LogItem.LogType.Exception)
            End Try

        Catch ex As Exception
            RaiseEvent PushingLogs(ex.Message, LogItem.LogType.Exception)
            RaiseEvent IsConnectionEstablished(Me, True, "Error Sending...")
            Exit Sub
        End Try

    End Sub
End Class