Public Class AstmConstants
    Public Const ENQ As Byte = 5
    Public Const ACK As Byte = 6
    Public Const NAK As Byte = 21
    Public Const EOT As Byte = 4
    Public Const ETX As Byte = 3
    Public Const ETB As Byte = 23
    Public Const STX As Byte = 2
    Public Const CR As Byte = 13
    Public Const LF As Byte = 10

    Public Shared ACK_BUFF As Byte() = {ACK}
    Public Shared ENQ_BUFF As Byte() = {ENQ}
    Public Shared NAK_BUFF As Byte() = {NAK}
    Public Shared EOT_BUFF As Byte() = {EOT}
End Class
