Public Class RequestDataEventArgs
    Inherits EventArgs

    Public Sub New()
        RequestData = New List(Of Request)
    End Sub
    Public RequestData As List(Of Request)
End Class
