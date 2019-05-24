Imports Essy.Lis.LIS02A2

Public Class Request
    Public Property Specimen As Sample
    Public Property Patient As Patient
    Public Property RequestedTests As String
    Public Property Priority As OrderPriority = OrderPriority.Routine
    Property SampleCollectionTime As Date
    Public Property TestActionCode As TestActionCode
    Public Property SpecimenDescriptor As String = "Urine"
    Public Property OrderNumber As String 'MemoNumber
    Public Property ReportType As OrderReportType = OrderReportType.Order 'O-New Order, F-Final Result

End Class

Public Enum TestActionCode
    C = 1 'Parameter Cancellation
    A = 2 'Add parameter to an existing order
    N = 3 'New Order
End Enum