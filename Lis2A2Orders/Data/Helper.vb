﻿Imports System.Configuration

Public Class Helper
    Public Shared Function GetConnectionString(name As String, Optional ByVal IsSqlite As Boolean = False) As String


        Dim CnxString As String = ConfigurationManager.ConnectionStrings(name).ConnectionString

        Select Case IsSqlite
            Case False
                CnxString = CnxString.Replace("USERNAME", Crypto.Decrypt(My.Settings.usr))
                CnxString = CnxString.Replace("PASSWORD", Crypto.Decrypt(My.Settings.epd))
                CnxString = CnxString.Replace("SERVER", Crypto.Decrypt(My.Settings.svr))
                CnxString = CnxString.Replace("DATABASE", Crypto.Decrypt(My.Settings.dbs))

        End Select

        Return CnxString
    End Function
End Class
