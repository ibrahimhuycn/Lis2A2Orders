Imports System.Data.SQLite
Imports Dapper

Public Class SqliteDataAccess
    Public Shared Function LoadRequests() As List(Of LisRequestDataModel)
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            Dim Output As List(Of LisRequestDataModel) = cnn.Query(Of LisRequestDataModel)("SELECT * FROM [AnalysisRequest]", New DynamicParameters)
            Return Output.ToList
        End Using
    End Function
    Public Shared Sub SaveRequest(e As List(Of LisRequestDataModel))
        For Each request In e
            Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
                cnn.Execute("INSERT INTO [AnalysisRequest] ([Barcode],[PatientNo],[PatientName],[Genders_id],[DateOfBirth],[created_at]) values (@Barcode,@PatientNo,@PatientName,@Genders_id,@DateOfBirth,@created_at)", request)
            End Using
        Next
    End Sub
    Public Shared Sub DeleteRequest(Barcode As String)
        Dim Parameter = New With {Key .Barcode = Barcode}
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            cnn.Execute("DELETE FROM [AnalysisRequest] WHERE Barcode = @Barcode", Parameter)
        End Using
    End Sub

    Public Shared Function LoadOneRequests() As List(Of LisRequestDataModel)
        Using cnn As IDbConnection = New SQLiteConnection(Helper.GetConnectionString("localdb", True))
            Dim Output As List(Of LisRequestDataModel) = cnn.Query(Of LisRequestDataModel)("SELECT * FROM [AnalysisRequest] LIMIT 1")
            Return Output.ToList
        End Using
    End Function

End Class
