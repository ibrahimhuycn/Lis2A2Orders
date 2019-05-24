
<AttributeUsage(AttributeTargets.[Property])>
Public Class DateTimeUsageAttribute
    Inherits Attribute
    Public Property DateTimeUsage As DateTimeUsage

    Public Sub New(ByVal aDateTimeUsage As DateTimeUsage)
        MyBase.New()
        Me.DateTimeUsage = aDateTimeUsage
    End Sub
End Class

