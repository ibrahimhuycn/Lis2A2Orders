<AttributeUsage(AttributeTargets.[Property])>
Public Class LisRecordFieldAttribute
    Inherits Attribute
    Public Property FieldIndex As Integer

    Public Sub New(ByVal aFieldIndex As Integer)
        MyBase.New()
        Me.FieldIndex = aFieldIndex
    End Sub
End Class
