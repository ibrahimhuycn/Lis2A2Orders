Imports System.Data.SqlClient
Imports Dapper

Public Class LisEnquiry
    Public Shared Function GetData(Created_at As String) As IEnumerable(Of LisRequestData)
        Using cnn As IDbConnection = New SqlConnection(Helper.GetConnectionString("lis"))

            Dim p = New With {Key .created_at = Created_at}

            Dim sql As String = "SELECT DISTINCT(pt.PatientNo),lg.Barcode,lg.created_at,pt.Patient AS PatientName,pt.DateOfBirth,pt.Genders_id" &
            " FROM dbo.machineorderlog lg " &
            "INNER JOIN dbo.patients pt ON lg.Patients_id = pt.id " &
            "WHERE lg.created_at BETWEEN @created_at AND '" & Now.ToString("yyyy/MM/dd") & " 23:59:59.999' AND lg.Barcode LIKE '%CU%'"

            Dim data As IEnumerable(Of LisRequestData) = cnn.Query(Of LisRequestData)(sql, p)
            Dim Sorted = From d In data
                         Order By d.created_at Ascending

            Return Sorted
        End Using
    End Function
End Class
