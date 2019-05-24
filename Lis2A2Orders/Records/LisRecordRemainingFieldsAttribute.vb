<AttributeUsage(AttributeTargets.[Property])>
Public Class LisRecordRemainingFieldsAttribute
    Inherits LisRecordFieldAttribute
    Public Sub New(ByVal aFieldIndex As Integer)
        MyBase.New(aFieldIndex)
    End Sub
End Class

