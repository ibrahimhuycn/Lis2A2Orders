Imports Essy.Lis.LIS02A2
Imports Lis2A2Orders

Partial Public Class OrderInformationRecord
    Inherits AbstractLisRecordV1
    <LisRecordField(12)>
    Public Property ActionCode As OrderActionCode

    <LisRecordField(6)>
    Public Property Priority As OrderPriority

    <DateTimeUsage(DateTimeUsage.DateTime)>
    <LisRecordField(7)>
    Public Property RequestedDateTime As Nullable(Of DateTime)

    <LisRecordField(26)>
    Public Property ReportType As OrderReportType

    <LisRecordField(2)>
    Public Property SequenceNumber As Integer

    <LisRecordField(3)>
    Public Property SpecimenID As String

    <LisRecordField(5)>
    Public Property TestID As UniversalTestID

    Public Sub New(ByVal aLisString As String)
        MyBase.New(aLisString)
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function ToLISString() As String
        Dim a As String = MyBase.ToLISString()
        Dim s As String = String.Concat(String.Concat("O", New String(LISDelimiters.FieldDelimiter, 1)), a)
        Return s
    End Function

End Class

