Imports System.Globalization
Imports System.Runtime.CompilerServices

Friend Module LISExtensions
    <Extension>
    Public Function LisStringToDateTime(ByVal lisString As String, ByVal aLisDateTimeUsage As DateTimeUsage) As DateTime
        Dim Result As DateTime = New DateTime()
        Select Case CInt(aLisDateTimeUsage)
            Case 0
                Result = DateTime.ParseExact(lisString, "yyyyMMddHHmmss", CultureInfo.InvariantCulture)
                Exit Select
            Case 1
                Result = DateTime.ParseExact(lisString, "yyyyMMdd", CultureInfo.InvariantCulture)
                Exit Select
            Case 2
                Result = DateTime.ParseExact(lisString, "HHmmss", CultureInfo.InvariantCulture)
                Exit Select
        End Select
        Return Result
    End Function

    <Extension>
    Public Function ToLISDate(ByVal aDateTime As DateTime, ByVal aLisDateTimeUsage As DateTimeUsage) As String
        Dim Result As String = Nothing
        Dim year As Integer
        Select Case CInt(aLisDateTimeUsage)
            Case 0
                Dim str(5) As String
                year = aDateTime.Year
                str(0) = year.ToString("D4")
                year = aDateTime.Month
                str(1) = year.ToString("D2")
                year = aDateTime.Day
                str(2) = year.ToString("D2")
                year = aDateTime.Hour
                str(3) = year.ToString("D2")
                year = aDateTime.Minute
                str(4) = year.ToString("D2")
                year = aDateTime.Second
                str(5) = year.ToString("D2")
                Result = String.Concat(str)
                Exit Select
            Case 1
                year = aDateTime.Year
                Dim str1 As String = year.ToString("D4")
                year = aDateTime.Month
                Dim str2 As String = year.ToString("D2")
                year = aDateTime.Day
                Result = String.Concat(str1, str2, year.ToString("D2"))
                Exit Select
            Case 2
                year = aDateTime.Hour
                Dim str3 As String = year.ToString("D2")
                year = aDateTime.Minute
                Dim str4 As String = year.ToString("D2")
                year = aDateTime.Second
                Result = String.Concat(str3, str4, year.ToString("D2"))
                Exit Select
        End Select
        Return Result
    End Function
End Module

