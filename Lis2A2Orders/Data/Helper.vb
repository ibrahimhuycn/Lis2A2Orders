Imports System.Configuration

Public Class Helper
    Public Shared Function GetConnectionString(name As String)
        Dim CnxString As String = ConfigurationManager.ConnectionStrings(name).ConnectionString
        CnxString = CnxString.Replace("USERNAME", Crypto.Decrypt(My.Settings.usr))
        CnxString = CnxString.Replace("PASSWORD", Crypto.Decrypt(My.Settings.epd))
        CnxString = CnxString.Replace("SERVER", Crypto.Decrypt(My.Settings.svr))
        CnxString = CnxString.Replace("DATABASE", Crypto.Decrypt(My.Settings.dbs))

        Return CnxString
    End Function
End Class
