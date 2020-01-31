Imports System.Data.SQLite
Imports Dapper

Public Class SqliteDataAccess
    Public Shared Event PushingLogs(ByVal logMessage As String, ByVal logType As LogItem.LogType)

    Public Shared Function LoadRequests() As List(Of LisRequestDataModel)
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            Dim Output As List(Of LisRequestDataModel) = cnn.Query(Of LisRequestDataModel)("SELECT * FROM [AnalysisRequest]", New DynamicParameters)
            Return Output.ToList
        End Using
    End Function
    Public Shared Sub SaveRequest(e As List(Of LisRequestDataModel))

        'Skip saving if sample list does not have any samples
        If e.Count = 0 Then Exit Sub

        For Each request In e
            If IsRecordPresent(request.Barcode) = False Then
                Try
                    Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
                        cnn.Execute("INSERT INTO [AnalysisRequest] ([Barcode],[PatientNo],[PatientName],[Genders_id],[DateOfBirth],[created_at]) values (@Barcode,@PatientNo,@PatientName,@Genders_id,@DateOfBirth,@created_at)", request)
                    End Using

                Catch ex As Exception
                    RaiseEvent PushingLogs(ex.Message, LogItem.LogType.Exception)
                End Try
            Else
                'log the presence of record for the sample barcode.
            End If
        Next

        RaiseEvent PushingLogs($"Queried Orders from LIS: {e.Count()} order(s)", LogItem.LogType.Information)

    End Sub
    Public Shared Sub DeleteRequest(Barcode As String)
        Dim Parameter = New With {Key .Barcode = Barcode}
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            cnn.Execute("DELETE FROM [AnalysisRequest] WHERE Barcode = @Barcode", Parameter)
        End Using

        RaiseEvent PushingLogs($"Deleting sample from localDB after transmission: {Barcode}", LogItem.LogType.Information)

    End Sub

    Public Shared Function LoadOneRequests() As List(Of LisRequestDataModel)
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            Try
                Dim Output As List(Of LisRequestDataModel) = cnn.Query(Of LisRequestDataModel)("SELECT * FROM [AnalysisRequest] LIMIT 1")
                RaiseEvent PushingLogs("3.1", LogItem.LogType.Information)

                RaiseEvent PushingLogs($"Loading one sample from local database to transmit. Sample Number{Output.ToList.FirstOrDefault.Barcode}", LogItem.LogType.Information)
                RaiseEvent PushingLogs("3.2", LogItem.LogType.Information)
                Return Output.ToList

            Catch ex As Exception
                RaiseEvent PushingLogs($"No samples found on LocalDB", LogItem.LogType.Information)
                Return New List(Of LisRequestDataModel)
            End Try
        End Using
    End Function

    Public Shared Function IsRecordPresent(barcode As String) As Boolean
        Dim returnValue As Boolean = False
        RaiseEvent PushingLogs($"Is Record present for: {barcode}", LogItem.LogType.Information)

        Dim Parameter = New With {Key .Barcode = barcode}
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            Dim Output As SampleOrder = cnn.Query(Of SampleOrder)("SELECT COUNT(*) AS IsPresent FROM AnalysisRequest WHERE Barcode = @Barcode", Parameter).First()
            If Not Output.IsPresent = 0 Then
                returnValue = True
            End If
        End Using

        RaiseEvent PushingLogs($"Is Sample Present on LocalDB: {returnValue}", LogItem.LogType.Information)
        Return returnValue
    End Function

End Class

Public Class SampleOrder
    Public Property IsPresent As Integer
End Class
