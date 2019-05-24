<AttributeUsage(AttributeTargets.Field)>
Friend Class LisEnumAttribute
    Inherits Attribute
    Public Property LisID As String

    Public Sub New(ByVal aLisID As String)
        MyBase.New()
        Me.LisID = aLisID
    End Sub
End Class
