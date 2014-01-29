Imports System.Data.SqlClient
Imports System.Data.SqlTypes


Module mod_Backend_Common

    Friend Function fn_MDYY_to_MMDDYY(sMDYY As String) As String
        Dim sX As String = ""

        Try


            Dim arrX() As String
            Dim stringSeparators() As String = {"/"}

            arrX = sMDYY.Split(stringSeparators, StringSplitOptions.None)

            sX = fn_Pad1DigitValuesInto2DigitStrings(arrX(0)) & "/" & fn_Pad1DigitValuesInto2DigitStrings(arrX(1)) & "/" & arrX(2)



        Catch ex As Exception
            c_Error.UnhandledExceptionHandler(ex, "fn_MDYY_to_MMDDYY", "mod_Backend_Common")
        End Try

        Return sX

    End Function

    Friend Function ReturnPartOfStringUpToBreakCharacter(ByVal strInputString As String, _
                                                     ByVal sBreakCharacter As Char) _
                                                     As String

        Dim strX As String = ""

        Try
            Dim iBreakPoint As Integer = InStr(1, strInputString, sBreakCharacter)
            strX = Trim(Mid(strInputString, 1, iBreakPoint - 1))
        Catch ex As Exception
            c_Error.UnhandledExceptionHandler(ex, "ReturnPartOfStringUpToBreakCharacter", "mod_Backend_Common")
        End Try

        Return strX

    End Function


    Friend Function FixNull_Convert_ToString(oValueToFixAndConvert As Object, eVariableType As TheDataType_FrontEnd) As String

        Dim sX As String
        Try





            Select Case eVariableType

                Case TheDataType_FrontEnd._Boolean
                    ''---
                    'If IsNothing(oValueToFixAndConvert) Then
                    '    sX = ""
                    'Else
                    '    sX = oValueToFixAndConvert.ToString
                    'End If
                    ''---

                    '---
                    Dim bX As Boolean
                    bX = DirectCast(oValueToFixAndConvert, Boolean)


                    If (IsDBNull(bX)) Then
                        sX = "{Null}"
                    Else
                        sX = oValueToFixAndConvert.ToString()
                    End If
                    '---
                Case TheDataType_FrontEnd._String
                    '---
                    Dim s As String
                    s = DirectCast(oValueToFixAndConvert, String)


                    If (String.IsNullOrEmpty(s)) Then
                        sX = "{Null}"
                    Else
                        sX = oValueToFixAndConvert.ToString()
                    End If
                    '---
                Case TheDataType_FrontEnd._SqlDateTime


                    '---
                    Dim dtX As SqlDateTime
                    dtX = DirectCast(oValueToFixAndConvert, SqlDateTime)


                    If (dtX.IsNull) Then
                        sX = "{Null}"
                    Else
                        sX = oValueToFixAndConvert.ToString()
                    End If

                    '---

                Case TheDataType_FrontEnd._SqlInt16



                    '---
                    Dim int16X As SqlInt16
                    int16X = DirectCast(oValueToFixAndConvert, SqlInt16)


                    If (int16X.IsNull) Then
                        sX = "{Null}"
                    Else
                        sX = oValueToFixAndConvert.ToString()
                    End If

                    '---

                Case TheDataType_FrontEnd._SqlInt32

                    '---
                    Dim int32X As SqlInt32
                    int32X = DirectCast(oValueToFixAndConvert, SqlInt32)


                    If (int32X.IsNull) Then
                        sX = "{Null}"
                    Else
                        sX = oValueToFixAndConvert.ToString()
                    End If

                    '---

                Case TheDataType_FrontEnd._SqlGUID

                    '---
                    Dim sqlguidX As SqlGuid
                    sqlguidX = DirectCast(oValueToFixAndConvert, SqlGuid)


                    If (sqlguidX = SqlGuid.Null) Then
                        sX = "{Null}"
                    Else
                        sX = oValueToFixAndConvert.ToString()
                    End If

                    '---

                Case Else


            End Select
            'End If


        Catch ex As NullReferenceException
            sX = "{Null}"
        Catch ex As Exception
            c_Error.UnhandledExceptionHandler(ex, "FixNull_Convert_ToString", "mod_Backend_Common")
        Finally

        End Try

        Return sX

    End Function


    Friend Sub FixNullValues_Then_AddParameter(ByVal oRecord_Field As Object, ByRef cmdX As SqlCommand, ByVal sNameOfSQLVariable As String, eVariableType As TheDataType, Optional iLenth As Integer = 255)
        'iLenth is -1 for nvarchar(max)

        Try


            Select Case eVariableType
                Case TheDataType._Bit
                    '---
                    'If Trim(CStr(oRecord_Field)) = "" Then
                    '    cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Bit, iLenth)).Value = DBNull.Value
                    'Else

                    'NOT sure if I need to do something about a NULL bit
                    '---
                    If IsNothing(oRecord_Field) Then
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Bit)).Value = False
                    Else
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Bit)).Value = oRecord_Field
                    End If
                    '---


                    'End If
                    '---

                Case TheDataType._VarChar
                    '---
                    If Trim(CStr(oRecord_Field)) = "" Then
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.VarChar, iLenth)).Value = DBNull.Value
                    Else
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.VarChar, iLenth)).Value = Trim(CStr(oRecord_Field))
                    End If
                    '---

                Case TheDataType._Int

                    '---
                    'If c_CustomFunctions.NullableINTisNothing(CType(oRecord_Field, Integer?)) Then
                    '    cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Int)).Value = SqlInt32.Null
                    'Else
                    'I think there is no need to convert it to something special, it is already a nullable
                    cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Int)).Value = oRecord_Field
                    'End If
                    '---

                Case TheDataType._Date
                    '---
                    If IsNothing(oRecord_Field) Then
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Date)).Value = DBNull.Value
                    Else
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.Date)).Value = oRecord_Field
                    End If
                    '---

                Case TheDataType._SmallInt

                    '---
                    'If c_CustomFunctions.NullableSmallINTisNothing(CType(oRecord_Field, SqlInt16)) Then     'Integer?
                    '    cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.SmallInt)).Value = SqlInt16.Null        '.DBNull.Value
                    'Else

                    'I think there is no need to convert it to something special, it is already a nullable
                    cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.SmallInt)).Value = oRecord_Field
                    'End If
                    '---
                Case TheDataType._NVarChar
                    '---
                    If Trim(CStr(oRecord_Field)) = "" Then
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.NVarChar, iLenth)).Value = DBNull.Value
                    Else
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.NVarChar, iLenth)).Value = Trim(CStr(oRecord_Field))     'iLenth is -1 for nvarchar(max)
                    End If
                    '---
                Case TheDataType._SqlDateTime
                    '---
                    If IsNothing(oRecord_Field) Then
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.DateTime)).Value = DBNull.Value
                    Else

                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.DateTime)).Value = oRecord_Field

                    End If
                    '---
                Case TheDataType._SqlGUID
                    '---
                    If IsNothing(oRecord_Field) Then
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.UniqueIdentifier)).Value = SqlGuid.Null
                    Else
                        cmdX.Parameters.Add(New SqlParameter(sNameOfSQLVariable, SqlDbType.UniqueIdentifier)).Value = oRecord_Field

                    End If
                    '---
                Case Else


            End Select

        Catch ex As Exception
            c_Error.UnhandledExceptionHandler(ex, "FixNullValues_Then_AddParameter", "mod_Backend_Common")
        End Try
    End Sub


    Friend Enum TheDataType_FrontEnd

        _Boolean
        _SqlDateTime
        _SqlInt32
        _SqlInt16
        _String
        _SqlGUID

    End Enum

    Friend Enum TheDataType
        _Bit
        _Date
        _Int
        _NVarChar
        _SmallInt
        _SqlDateTime
        _VarChar
        _SqlGUID
    End Enum

    Friend Function fn_Pad1DigitValuesInto2DigitStrings(ByVal strStringToCheckAndPad As String) As String
        Dim iLen As Integer
        Dim strX As String

        iLen = Len(strStringToCheckAndPad)
        Select Case iLen

            Case 1
                strX = "0" & strStringToCheckAndPad
            Case 2
                strX = strStringToCheckAndPad
            Case Else
                strX = "I thought that Pad1DigitValuesInto2DigitStrings would only recieve a 1 or 2 digit string"
        End Select
        Return strX


    End Function

    Friend Function fn_DotNetDateTime_to_SQLDateTime(DotNetDateTime As Date) As SqlDateTime
        Try
            Dim sqlDateTimeX As New System.Data.SqlTypes.SqlDateTime(DotNetDateTime)
            Return sqlDateTimeX
        Catch ex As Exception
            c_Error.UnhandledExceptionHandler(ex, "fn_DotNetDateTime_to_SQLDateTime", "mod_Backend_Common")
        End Try
    End Function

End Module
