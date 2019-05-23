Imports System.Reflection
Imports Essy.Lis.Connection
Imports Essy.Lis.LIS02A2

Public Class Connection
    Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)

    Public Sub New(ByVal connectionSettings As Settings)
        Select Case connectionSettings.ConnectionType

            Case ConnectionType.Ethernet

                Dim CnxIP As String = connectionSettings.IPAddress
                Dim CnxPort As Integer = connectionSettings.Port
                Dim lowLevelConnection As New Lis01A02TCPConnection(CnxIP, CnxPort)

                Try
                    Select Case connectionSettings.IsServer
                        Case True
                            lowLevelConnection.StartListeningAsync()
                        Case False
                            Dim lisConnection As New Lis01A2Connection(lowLevelConnection)
                            Dim lisParser As New LISParser(lisConnection)
                            lisParser.Connection.Connect()
                            lisParser.Connection.Status = LisConnectionStatus.Idle

                            AddHandler lisParser.OnSendProgress, AddressOf LISParser_OnSendProgress
                            AddHandler lisParser.OnReceivedRecord, AddressOf LISParser_OnReceivedRecord
                    End Select
                Catch ex As Exception
                    log.Error(ex)
                End Try


            Case ConnectionType.Serial
                Dim SerialPort = New IO.Ports.SerialPort(connectionSettings.SerialPort)
                Dim lowLevelConnection = New Lis01A02RS232Connection(SerialPort)
                Dim lisConnection = New Lis01A2Connection(lowLevelConnection)
        End Select

    End Sub


    Public Enum ConnectionType
        Ethernet
        Serial
    End Enum

    Private Shared Sub LISParser_OnReceivedRecord(ByVal Sender As Object, ByVal e As ReceiveRecordEventArgs)

    End Sub

    Private Shared Sub LISParser_OnSendProgress(ByVal sender As Object, ByVal e As SendProgressEventArgs)
        Dim a = 1
    End Sub

End Class