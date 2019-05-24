Imports Essy.Lis.LIS02A2

Public Class RecordFields
    Private fItems As String()

    Public ReadOnly Property Count As Integer
        Get
            Return Me.fItems.Length
        End Get
    End Property

    Public Property Value As String

    Public Sub New(ByVal lisString As String, ByVal aSeporatorChar As Char, ByVal aNumberOfFields As Integer)
        MyBase.New()
        Me.Value = lisString
        Me.fItems = lisString.Split(New Char() {aSeporatorChar}, aNumberOfFields)
    End Sub

    Public Function GetField(ByVal indx As Integer) As String
        If (Me.fItems.Length < indx) Then
            Return String.Empty
        End If
        Dim Result As String = Me.fItems(indx - 1)
        Result = Result.Replace(String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "F"), New String(LISDelimiters.EscapeCharacter, 1)), New String(LISDelimiters.FieldDelimiter, 1))
        Result = Result.Replace(String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "S"), New String(LISDelimiters.EscapeCharacter, 1)), New String(LISDelimiters.ComponentDelimiter, 1))
        Result = Result.Replace(String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "R"), New String(LISDelimiters.EscapeCharacter, 1)), New String(LISDelimiters.RepeatDelimiter, 1))
        Return Result.Replace(String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "E"), New String(LISDelimiters.EscapeCharacter, 1)), New String(LISDelimiters.EscapeCharacter, 1))
    End Function
End Class

