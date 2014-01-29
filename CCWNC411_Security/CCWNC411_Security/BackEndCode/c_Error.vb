Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class c_Error


    Friend Shared Sub UnhandledExceptionHandler(ByRef ex As Exception, ByVal sThisSubName As String, ByVal sThisModuleName As String)


        Debug.Print(ControlChars.Cr & "========== <<<  START - An exception {UnhandledExceptionHandler} occurred in the BACKEND >>>================" & ControlChars.Cr)
        Debug.Print(" Date\Time:::===> " & Now.ToShortDateString & " " & Now.ToShortTimeString)
        Debug.Print(" Module: " & sThisModuleName)
        Debug.Print(" Subroutine/Function:::===> " & sThisSubName)
        Debug.Print(ControlChars.Cr & "========== exception Details ================" & ControlChars.Cr)
        Debug.Print(" Exception Message:::===> " & ex.Message)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Gettype:::===> " & ex.GetType.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception GetBaseException:::===> " & ex.GetBaseException.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception InnerException:::===> " & ex.InnerException.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Source: " & ex.Source.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)





        Select Case ex.GetType

            Case GetType(System.NullReferenceException)


            Case Else

        End Select

        Debug.Print(ControlChars.Cr & "==========<<< END - of exception details in the BACKEND >>>================" & ControlChars.Cr)

        Throw ex    'This throws the exception up to the presentation layer'

    End Sub



    Friend Shared Sub UnhandledSqlClientExceptionHandler(ByRef ex As System.Data.SqlClient.SqlException, ByVal sThisSubName As String, ByVal sThisModuleName As String)


        Debug.Print(ControlChars.Cr & "==========<<< START - An SqlException occurred in the BACKEND >>>================" & ControlChars.Cr)

        Debug.Print(" Date\Time:::===> " & Now.ToShortDateString & " " & Now.ToShortTimeString)
        Debug.Print(" Module: " & sThisModuleName)
        Debug.Print(" Subroutine/Function:::===> " & sThisSubName)
        Debug.Print(ControlChars.Cr & "========== exception Details ================" & ControlChars.Cr)
        Debug.Print(" ex.GetType.ToString Message:::===> " & ex.GetType.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Message:::===> " & ex.Message)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Source (Name of Provider): " & ex.Source.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Number:::===> " & ex.Number.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Class (Severity):::===> " & ex.Class.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception LineNumber (withing T-SQL):::===> " & ex.LineNumber.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Procedure (name of the stored procedure):::===> " & ex.Procedure.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception State(check SQL Online):::===> " & ex.State.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception Data (key/value pairs):::===> " & ex.Data.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
        Debug.Print(" Exception ErrorCode (HRESULT):::===> " & ex.ErrorCode.ToString)
        Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)


        Debug.Print(ControlChars.Cr & "==========<<<< END - of exception details in the BACKEND >>>================" & ControlChars.Cr)

        Select Case ex.Number

            Case 2627
                'This can occur when a record is entered with a unique name originally, 
                ' but then the user attempts to update/change the value 
                ' That is not unique. This exception is then thrown in the Data Layer, and raised to the user's attention by the Presentation Layer 
                Dim sX As String
                sX = "A Constraint on the Database was violated when you tried to add the new Record. It will have to be fixed before you try again." & VbCrLf & VbCrLf & ex.Message.ToString
                Throw New ArgumentException(sX, paramName:="UniqueValueViolation")

            Case Else
                Throw ex    'This throws the exception up to the presentation layer'
        End Select



    End Sub

    Friend Shared Sub PrintParameterListInSQLCommand(cmdX As SqlCommand)
        Dim prm As SqlParameter

        For Each prm In cmdX.Parameters

            Debug.Print(ControlChars.Cr & "==========<<< START - PrintParameterListInSQLCommand in the BACKEND >>>================" & ControlChars.Cr)
            Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)
            Debug.Print(" prm.ParameterName :::===> " & prm.ParameterName)
            Debug.Print("---   ---")
            Debug.Print(" prm.SqlDbType.ToString :::===> " & prm.SqlDbType.ToString)
            Debug.Print("---   ---")
            Debug.Print(" prm.Value.ToString :::===> " & fn_Convert_ParameterValue_ToString(prm.Value))
            Debug.Print("---   ---")
            Debug.Print(" prm.Direction.ToString :::===> " & prm.Direction.ToString)
            Debug.Print("---   ---")
            Debug.Print(" prm.IsNullable.ToString :::===> " & prm.IsNullable.ToString)
            Debug.Print("---   ---")
            Debug.Print(" prm.Precision.ToString :::===> " & prm.Precision.ToString)
            Debug.Print("---   ---")
            Debug.Print(" prm.SourceColumn :::===> " & prm.SourceColumn)
            Debug.Print(ControlChars.Cr & "---   ---" & ControlChars.Cr)



            Debug.Print(ControlChars.Cr & "==========<<<< END - PrintParameterListInSQLCommand in the BACKEND >>>================" & ControlChars.Cr)


        Next
    End Sub

    Friend Shared Function fn_Convert_ParameterValue_ToString(oX As Object) As String
        Dim sX As String = ""
        Dim bThereWasAnError As Boolean = False

        '
        Try

            If (Not IsDBNull(oX)) And Not (oX Is Nothing) Then

                Select Case oX.GetType.ToString

                    Case "System.Data.SqlTypes.SqlDateTime"
                        '================
                        Dim sqlDateX As SqlDateTime
                        sqlDateX = DirectCast(oX, SqlDateTime)

                        If sqlDateX = SqlDateTime.Null Then
                            sX = "SqlDateTime => Null"
                        Else
                            sX = sqlDateX.ToString
                        End If
                        '================
                    Case "System.Data.SqlTypes.SqlInt16"
                        '================
                        Dim SqlInt16X As SqlInt16
                        SqlInt16X = DirectCast(oX, SqlInt16)

                        If SqlInt16X = SqlInt16.Null Then
                            sX = "SqlInt16X => Null"
                        Else

                            sX = SqlInt16X.ToString
                        End If
                        '================
                    Case "System.Data.SqlTypes.SqlInt32"
                        '================
                        Dim SqlInt32X As SqlInt32
                        SqlInt32X = DirectCast(oX, SqlInt32)

                        If SqlInt32X = SqlInt32.Null Then
                            sX = "SqlInt32X => Null"
                        Else

                            sX = SqlInt32X.ToString
                        End If
                        '================
                    Case "System.String"
                        '================
                        Dim TheStringX As String
                        TheStringX = oX.ToString

                        If String.IsNullOrEmpty(TheStringX) Then

                            sX = "String => Null"

                        Else
                            sX = TheStringX.ToString
                        End If
                        '================
                    Case Else
                        sX = "NEED to Identify type"
                        'End If

                End Select



            Else
                sX = "UNKNOWN - NULL"
            End If



        Catch ex As Exception
            bThereWasAnError = True
            Debug.Print(">>>>>>>>>> There was an error for: oX.GetType.ToString: " & oX.GetType.ToString)
            UnhandledExceptionHandler(ex, "fn_Convert_ParameterValue_ToString", "c_Error")
        Finally
            If bThereWasAnError Then
                sX = "Check the Log, there was an Exception"
            End If

        End Try


        Return sX


    End Function



End Class
