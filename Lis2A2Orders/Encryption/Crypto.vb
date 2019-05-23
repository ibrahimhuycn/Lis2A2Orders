Imports System.Security.Cryptography
Imports System.Text

Public Class Crypto
    Public Sub New()
    End Sub

    Public Shared Function Decrypt(ByVal encryptedMessage As String, ByVal Optional password As String = "Information") As String
        Dim des1 As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        des1.Key = Crypto.MD5Hash(password)
        des1.Mode = CipherMode.ECB
        Dim messageBytes As Byte() = Convert.FromBase64String(encryptedMessage)
        Encoding.ASCII.GetBytes(password)
        Dim str As String = Encoding.ASCII.GetString(des1.CreateDecryptor().TransformFinalBlock(messageBytes, 0, CInt(messageBytes.Length)))
        Return str
    End Function

    Public Shared Function Encrypt(ByVal message As String, ByVal key As String) As String
        Dim des1 As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        des1.Key = Crypto.MD5Hash(key)
        des1.Mode = CipherMode.ECB
        Dim messageBytes As Byte() = Encoding.ASCII.GetBytes(message)
        Encoding.ASCII.GetBytes(key)
        Dim base64String As String = Convert.ToBase64String(des1.CreateEncryptor().TransformFinalBlock(messageBytes, 0, CInt(messageBytes.Length)))
        Return base64String
    End Function

    Public Shared Function MD5Hash(ByVal password As String) As Byte()
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Return md5.ComputeHash(Encoding.ASCII.GetBytes(password))
    End Function
End Class
