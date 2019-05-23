Public Class Request
    Public Property Specimen As Sample
    Public Property Patient As Patient
    Public Property RequestedTests As String
    Public Property Priority As RequestPriority = RequestPriority.R
    Property SampleCollectionTime As String = Now.ToString("yyyyMMddHHmmss")
    Public Property TestActionCode As TestActionCode
    Public Property SpecimenDescriptor As String = "Urine"
    Public Property OrderNumber As String 'MemoNumber
    Public Property ReportType As String = "O" 'O-New Order, F-Final Result

End Class
Public Enum RequestPriority
    R 'Routine
    A 'Urgent
    S 'Emergency
End Enum

Public Enum TestActionCode
    C 'Parameter Cancellation
    A 'Add parameter to an existing order
    N 'New Order
End Enum