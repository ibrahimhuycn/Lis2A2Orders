Imports System.Data.SqlClient
Imports Dapper
Imports Essy.Lis.LIS02A2

Public Class LisEnquiry
    Public Shared Function GetData(Created_at As String) As IEnumerable(Of LisRequestData)
        Using cnn As IDbConnection = New SqlConnection(Helper.GetConnectionString("lis"))

            Dim p = New With {Key .created_at = Created_at}

            Dim sql As String = "SELECT DISTINCT(pt.PatientNo),lg.Barcode,lg.created_at,pt.Patient AS PatientName,pt.DateOfBirth,pt.Genders_id" &
            " FROM dbo.machineorderlog lg " &
            "INNER JOIN dbo.patients pt ON lg.Patients_id = pt.id " &
            "WHERE lg.created_at BETWEEN @created_at AND '" & Now.ToString("yyyy/MM/dd") & " 23:59:59.999' AND lg.Barcode LIKE '%CU%'"

#Region "Production Code"
            'Dim data As IEnumerable(Of LisRequestData) = cnn.Query(Of LisRequestData)(sql, p)
#End Region



#Region "Development Code"
            Dim Data As IList(Of LisRequestData) = New List(Of LisRequestData)
            Data.Add(New LisRequestData() With {.Barcode = "CU7894561", .created_at = Now, .DateOfBirth = Now, .Genders_id = 2, .PatientName = "IBRAHIM HUSSAIN", .PatientNo = 151517552})
            'Data.Add(New LisRequestData() With {.Barcode = "CU1234567", .created_at = Now, .DateOfBirth = Now, .Genders_id = 2, .PatientName = "AHMED HISAAN", .PatientNo = 262526})
            ' Data.Add(New LisRequestData() With {.Barcode = "CU4567896", .created_at = Now, .DateOfBirth = Now, .Genders_id = 2, .PatientName = "HUSSAIN MOHAMED", .PatientNo = 548482500})

#End Region

            Dim Sorted = From d In Data
                         Order By d.created_at Ascending

            Return Sorted
        End Using
    End Function
End Class
