Imports Essy.Lis.LIS02A2

Public Class Patient
    Public Property PatientID As Integer
    Public Property PatientName As PatientName
    Private _birthDate As String
    Property BirthDate As Date
        Get
            Return _birthDate
        End Get
        Set
            _birthDate = Value.ToString("yyyyMMdd")
        End Set
    End Property

    Public Property PatientSex As PatientSex

End Class

