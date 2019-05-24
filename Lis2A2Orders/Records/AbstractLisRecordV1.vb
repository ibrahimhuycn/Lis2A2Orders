Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Essy.Lis.LIS02A2

Public MustInherit Class AbstractLisRecordV1
    Protected Const CR As Char = Strings.ChrW(13)

    Public Sub New(ByVal aLisString As String)
        MyBase.New()
        Dim type As System.Type
        Dim isSubRecord As Boolean = TypeOf Me Is AbstractLisSubRecordV1
        Dim sepChar As Char = If(Not isSubRecord, LISDelimiters.FieldDelimiter, LISDelimiters.ComponentDelimiter)
        Dim abstractLisRecord1 As AbstractLisSubRecordV1 = Me
        If (abstractLisRecord1 IsNot Nothing) Then
            type = abstractLisRecord1.[GetType]()
        Else
            type = Nothing
        End If
        Dim props As PropertyInfo() = type.GetProperties()
        Dim limit As Integer = 2147483647
        If (If(Not isSubRecord, False, props.Length > 0)) Then
            If (Not props(props.Length - 1).PropertyType.IsArray) Then
                limit = props.Length
            End If
        End If
        Dim rf As RecordFields = New RecordFields(aLisString, sepChar, limit)
        Dim num As Integer = 0
        Dim propertyInfoArray As PropertyInfo() = props
        If (propertyInfoArray IsNot Nothing) Then
            While num < propertyInfoArray.Length
                Dim prop As PropertyInfo = propertyInfoArray(num)
                Dim attribs As Object() = prop.GetCustomAttributes(GetType(LisRecordFieldAttribute), False)
                If (attribs.Length > 0) Then
                    Dim attrib As LisRecordFieldAttribute = DirectCast(attribs(0), LisRecordFieldAttribute)
                    Dim field As String = rf.GetField(attrib.FieldIndex)
                    If (Not String.IsNullOrEmpty(field)) Then
                        Dim propType As System.Type = prop.PropertyType
                        Dim nullablePropType As System.Type = Nullable.GetUnderlyingType(propType)
                        If (nullablePropType IsNot Nothing) Then
                            propType = nullablePropType
                        End If
                        If (propType = GetType(Integer)) Then
                            prop.SetValue(Me, Integer.Parse(Me.fRemoveOptionalSubFields(field)), Nothing)
                        ElseIf (propType = GetType(String)) Then
                            prop.SetValue(Me, field, Nothing)
                        ElseIf (propType = GetType(DateTime)) Then
                            Dim dateTimeUsage As DateTimeUsage = DateTimeUsage.DateTime
                            attribs = prop.GetCustomAttributes(GetType(DateTimeUsageAttribute), False)
                            If (attribs.Length = 1) Then
                                dateTimeUsage = DirectCast(attribs(0), DateTimeUsageAttribute).DateTimeUsage
                            End If
                            prop.SetValue(Me, Me.fRemoveOptionalSubFields(field).LisStringToDateTime(dateTimeUsage), Nothing)
                        ElseIf (propType.IsEnum) Then
                            prop.SetValue(Me, Me.fCreateLisEnum(Me.fRemoveOptionalSubFields(field), propType), Nothing)
                        ElseIf (propType.BaseType = GetType(AbstractLisSubRecord)) Then
                            prop.SetValue(Me, Me.fCreateSubrecord(field, propType), Nothing)
                        ElseIf (propType.IsArray) Then
                            If (Not TypeOf attrib Is LisRecordRemainingFieldsAttribute) Then
                                Throw New FormatException("The LIS String was not of the correct format.")
                            End If
                            prop.SetValue(Me, Me.fCreateRemainingFieldsArray(rf, attrib.FieldIndex), Nothing)
                        End If
                    End If
                End If
                num = num + 1
            End While
        End If
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

    Private Function fCreateLisEnum(ByVal aString As String, ByVal aType As Type) As Object
        Dim lisID As String
        Dim fields As FieldInfo()
        Dim fi As FieldInfo
        Dim num As Integer
        Dim attribs As LisEnumAttribute()
        Dim Result As Object = Nothing
        If (aType.GetCustomAttributes(GetType(FlagsAttribute), False).Length <= 0) Then
            lisID = Nothing
            num = 0
            fields = aType.GetFields()
            If (fields IsNot Nothing) Then
                While num < fields.Length
                    fi = fields(num)
                    attribs = TryCast(fi.GetCustomAttributes(GetType(LisEnumAttribute), False), LisEnumAttribute())
                    If (attribs.Length > 0) Then
                        lisID = attribs(0).LisID
                    End If
                    If (String.Compare(lisID, aString, True) = 0) Then
                        Return [Enum].Parse(aType, fi.Name)
                    End If
                    num = num + 1
                End While
            End If
        Else
            lisID = String.Empty
            Dim enumStringValue As String = Nothing
            num = 0
            fields = aType.GetFields()
            If (fields IsNot Nothing) Then
                While num < fields.Length
                    fi = fields(num)
                    attribs = TryCast(fi.GetCustomAttributes(GetType(LisEnumAttribute), False), LisEnumAttribute())
                    If (attribs.Length > 0) Then
                        enumStringValue = attribs(0).LisID
                    End If
                    If (aString IsNot Nothing) Then
                        Dim enumerator As CharEnumerator = aString.GetEnumerator()
                        If (enumerator IsNot Nothing) Then
                            Try
                                While enumerator.MoveNext()
                                    Dim ch As Char = enumerator.Current
                                    If (String.Compare(enumStringValue, New String(ch, 1), True) <> 0) Then
                                        Continue While
                                    End If
                                    lisID = String.Concat(lisID, fi.Name, ",")
                                End While
                            Finally
                                enumerator.Dispose()
                            End Try
                        End If
                    End If
                    num = num + 1
                End While
            End If
            If (lisID.Length > 0) Then
                lisID = lisID.Remove(lisID.Length - 1, 1)
                Return [Enum].Parse(aType, lisID)
            End If
        End If
        Return Result
    End Function

    Private Function fCreateRemainingFieldsArray(ByVal aRecordFields As RecordFields, ByVal aStartIndex As Integer) As String()
        Dim temp As List(Of String) = New List(Of String)()
        Dim count As Integer = aRecordFields.Count
        Dim i As Integer = aStartIndex
        If (i <= count) Then
            count = count + 1
            Do
                temp.Add(aRecordFields.GetField(i))
                i = i + 1
            Loop While i <> count
        End If
        Return temp.ToArray()
    End Function

    Private Function fCreateSubrecord(ByVal aString As String, ByVal aType As Type) As AbstractLisSubRecord
        Return DirectCast(Activator.CreateInstance(aType, New Object() {aString}), AbstractLisSubRecord)
    End Function

    Private Function fEscapeString(ByVal aString As String, ByVal aSubrecord As Boolean) As String
        Dim Result As String = aString
        Result = Result.Replace(New String(LISDelimiters.EscapeCharacter, 1), String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "E"), New String(LISDelimiters.EscapeCharacter, 1)))
        Result = Result.Replace(New String(LISDelimiters.FieldDelimiter, 1), String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "F"), New String(LISDelimiters.EscapeCharacter, 1)))
        If (aSubrecord) Then
            Result = Result.Replace(New String(LISDelimiters.ComponentDelimiter, 1), String.Concat(String.Concat(New String(LISDelimiters.EscapeCharacter, 1), "S"), New String(LISDelimiters.EscapeCharacter, 1)))
        End If
        Return Result
    End Function

    Private Function fGetEnumLisString(ByVal aEnum As Object) As String
        Dim fi As FieldInfo
        Dim attribs As LisEnumAttribute()
        Dim type As System.Type
        Dim lisID As String
        Dim obj As Object = aEnum
        If (obj IsNot Nothing) Then
            type = obj.[GetType]()
        Else
            type = Nothing
        End If
        Dim enumType As System.Type = type
        If (enumType.GetCustomAttributes(GetType(FlagsAttribute), False).Length <= 0) Then
            fi = enumType.GetField(aEnum.ToString())
            attribs = TryCast(fi.GetCustomAttributes(GetType(LisEnumAttribute), False), LisEnumAttribute())
            If (attribs.Length <= 0) Then
                lisID = Nothing
            Else
                lisID = attribs(0).LisID
            End If
            Return lisID
        End If
        Dim Result As String = String.Empty
        Dim inputVals As String() = aEnum.ToString().Split(New Char() {","c})
        Dim enumValues As FieldInfo() = enumType.GetFields()
        Dim num As Integer = 0
        Dim fieldInfoArray As FieldInfo() = enumValues
        If (fieldInfoArray IsNot Nothing) Then
            While num < fieldInfoArray.Length
                fi = fieldInfoArray(num)
                attribs = TryCast(fi.GetCustomAttributes(GetType(LisEnumAttribute), False), LisEnumAttribute())
                If (attribs.Length > 0) Then
                    Dim num1 As Integer = 0
                    Dim strArrays As String() = inputVals
                    If (strArrays IsNot Nothing) Then
                        While num1 < strArrays.Length
                            If (strArrays(num1).Trim() = fi.Name) Then
                                Result = String.Concat(Result, attribs(0).LisID)
                            End If
                            num1 = num1 + 1
                        End While
                    End If
                End If
                num = num + 1
            End While
        End If
        Return Result
    End Function

    Private Function fRemoveOptionalSubFields(ByVal aString As String) As String
        If (Not aString.Contains(New String(LISDelimiters.ComponentDelimiter, 1))) Then
            Return aString
        End If
        Return aString.Split(New Char() {LISDelimiters.ComponentDelimiter})(0)
    End Function

    Public Overridable Function ToLISString() As String
        Dim str As String
        Dim field As String
        Dim type As System.Type
        Dim isSubRecord As Boolean = TypeOf Me Is AbstractLisSubRecordV1
        Dim sepChar As Char = If(Not isSubRecord, LISDelimiters.FieldDelimiter, LISDelimiters.ComponentDelimiter)
        Dim sb As StringBuilder = New StringBuilder()
        Dim fieldList As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
        Dim abstractLisRecord As AbstractLisRecordV1 = Me
        If (abstractLisRecord IsNot Nothing) Then
            type = abstractLisRecord.[GetType]()
        Else
            type = Nothing
        End If
        Dim props As PropertyInfo() = type.GetProperties()
        Dim maxFieldIndex As Integer = -2147483648
        Dim minFieldIndex As Integer = 2147483647
        Dim i As Integer = 0
        Dim propertyInfoArray As PropertyInfo() = props
        If (propertyInfoArray IsNot Nothing) Then
            While i < propertyInfoArray.Length
                Dim prop As PropertyInfo = propertyInfoArray(i)
                Dim attribs As Object() = prop.GetCustomAttributes(GetType(LisRecordFieldAttribute), False)
                If (attribs.Length > 0) Then
                    Dim attrib As LisRecordFieldAttribute = DirectCast(attribs(0), LisRecordFieldAttribute)
                    Dim propType As System.Type = prop.PropertyType
                    Dim nullablePropType As System.Type = Nullable.GetUnderlyingType(propType)
                    If (nullablePropType IsNot Nothing) Then
                        propType = nullablePropType
                    End If
                    field = Nothing
                    Dim propVal As Object = prop.GetValue(Me, Nothing)
                    If (propVal IsNot Nothing) Then
                        If (propType = GetType(DateTime)) Then
                            Dim dateTimeUsage As DateTimeUsage = DateTimeUsage.DateTime
                            attribs = prop.GetCustomAttributes(GetType(DateTimeUsageAttribute), False)
                            If (attribs.Length = 1) Then
                                dateTimeUsage = DirectCast(attribs(0), DateTimeUsageAttribute).DateTimeUsage
                            End If
                            field = DirectCast(propVal, DateTime).ToLISDate(dateTimeUsage)
                        ElseIf (propType.IsEnum) Then
                            field = Me.fGetEnumLisString(propVal)
                        ElseIf (propType.BaseType = GetType(AbstractLisSubRecord)) Then
                            field = TryCast(propVal, AbstractLisSubRecord).ToLISString()
                        ElseIf (Not propType.IsArray) Then
                            field = propVal.ToString()
                        ElseIf (TypeOf attrib Is LisRecordRemainingFieldsAttribute) Then
                            Dim ar As String() = DirectCast(propVal, String())
                            field = String.Join(New String(sepChar, 1), ar)
                        End If
                    End If
                    If (Not String.IsNullOrEmpty(field)) Then
                        fieldList.Add(attrib.FieldIndex, field)
                        If (attrib.FieldIndex > maxFieldIndex) Then
                            maxFieldIndex = attrib.FieldIndex
                        End If
                    End If
                    If (attrib.FieldIndex < minFieldIndex) Then
                        minFieldIndex = attrib.FieldIndex
                    End If
                End If
                i = i + 1
            End While
        End If
        If (minFieldIndex <= maxFieldIndex) Then
            Dim num As Integer = maxFieldIndex - 1
            i = minFieldIndex
            If (i <= num) Then
                num = num + 1
                Do
                    fieldList.TryGetValue(i, field)
                    If (Not String.IsNullOrEmpty(field)) Then
                        sb.Append(Me.fEscapeString(field, isSubRecord))
                    End If
                    sb.Append(sepChar)
                    i = i + 1
                Loop While i <> num
            End If
        End If
        fieldList.TryGetValue(maxFieldIndex, str)
        If (Not String.IsNullOrEmpty(str)) Then
            sb.Append(str)
        End If
        If (Not isSubRecord) Then
            sb.Append(Strings.ChrW(13))
        End If
        Return sb.ToString()
    End Function

    Public Overrides Function ToString() As String
        Dim type As System.Type
        Dim sb As StringBuilder = New StringBuilder()
        Dim abstractLisRecord As AbstractLisRecordV1 = Me
        If (abstractLisRecord IsNot Nothing) Then
            type = abstractLisRecord.[GetType]()
        Else
            type = Nothing
        End If
        Dim props As PropertyInfo() = type.GetProperties()
        Dim num As Integer = 0
        Dim propertyInfoArray As PropertyInfo() = props
        If (propertyInfoArray IsNot Nothing) Then
            While num < propertyInfoArray.Length
                Dim prop As PropertyInfo = propertyInfoArray(num)
                If (prop.GetCustomAttributes(GetType(LisRecordFieldAttribute), False).Length > 0) Then
                    Dim propVal As Object = prop.GetValue(Me, Nothing)
                    Dim propString As String = Nothing
                    If (propVal IsNot Nothing) Then
                        propString = propVal.ToString()
                    End If
                    If (Not String.IsNullOrEmpty(propString)) Then
                        sb.Append(prop.Name)
                        sb.Append(": ")
                        sb.AppendLine(propString)
                    End If
                End If
                num = num + 1
            End While
        End If
        Return sb.ToString()
    End Function
End Class

