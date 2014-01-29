Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel   '<============
Imports System.Data.SqlTypes

Namespace ns_USER

    Public Class c_User_Record

        '-------- in the CREATE SP
        Private _ApplicationName As String = ""
        Private _UserName As String = ""
        Private _Password As String = ""
        Private _PasswordSalt As String = ""
        Private _Email As String = ""
        Private _PasswordQuestion As String = ""
        Private _PasswordAnswer As String = ""
        Private _IsApproved As Object
        Private _PasswordFormat As Object
        Private _UserId As Object


        '------- in the SELECT SP, but not in the CREATE SP

        Private _IsLockedOut As Object
        Private _LastLoginDate As Object
        Private _FailedPasswordAttemptCount As Object
        Private _LastActivityDate As Object
        Private _ApplicationId As Object


        'NOT USED that I know of

        Private _CreateDate As Object
        Private _UniqueEmail As Object
        Private _Comment As String = ""
        Private _TablesToDeleteFrom As SqlInt16 = 15
        Private _NumTablesDeletedFrom As SqlInt16 = 0
        Private _IsPasswordCorrect As Object
        Private _MaxInvalidPasswordAttempts As Object
        Private _PasswordAttemptWindow As Object
        Private _UpdateLastLoginActivityDate As Object
        Private _LastPasswordChangedDate As Object
        Private _LastLockoutDate As Object
        Private _CurrentTimeUtc As Object


        '---
        Property ApplicationName As String
            Get
                Return _ApplicationName
            End Get
            Set(ByVal value As String)
                _ApplicationName = value
            End Set
        End Property
        '---
        Property UserName As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property
        '---
        Property Password As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
        '---
        Property PasswordSalt As String
            Get
                Return _PasswordSalt
            End Get
            Set(ByVal value As String)
                _PasswordSalt = value
            End Set
        End Property
        '---
        Property Email As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property
        '---
        Property PasswordQuestion As String
            Get
                Return _PasswordQuestion
            End Get
            Set(ByVal value As String)
                _PasswordQuestion = value
            End Set
        End Property
        '---
        Property PasswordAnswer As String
            Get
                Return _PasswordAnswer
            End Get
            Set(ByVal value As String)
                _PasswordAnswer = value
            End Set
        End Property
        '---
        Property IsApproved As Object
            Get
                Return _IsApproved
            End Get
            Set(ByVal value As Object)
                _IsApproved = value
            End Set
        End Property

        '---
        Property CurrentTimeUtc As Object
            Get
                Return _CurrentTimeUtc
            End Get
            Set(ByVal value As Object)
                _CurrentTimeUtc = value
            End Set
        End Property

        '---
        Property CreateDate As Object
            Get
                Return _CreateDate
            End Get
            Set(ByVal value As Object)
                _CreateDate = value
            End Set
        End Property

        '---
        Property UniqueEmail As Object
            Get
                Return _UniqueEmail
            End Get
            Set(ByVal value As Object)
                _UniqueEmail = value
            End Set
        End Property

        Property PasswordFormat As Object
            Get
                Return _PasswordFormat
            End Get
            Set(ByVal value As Object)
                _PasswordFormat = value
            End Set
        End Property
        '---
        Property UserId As Object
            Get
                Return _UserId
            End Get
            Set(ByVal value As Object)
                _UserId = value
            End Set
        End Property
        '---
        Property Comment As String
            Get
                Return _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        '---
        Property LastLoginDate As Object
            Get
                Return _LastLoginDate
            End Get
            Set(ByVal value As Object)
                _LastLoginDate = value
            End Set
        End Property

        '---
        Property LastActivityDate As Object
            Get
                Return _LastActivityDate
            End Get
            Set(ByVal value As Object)
                _LastActivityDate = value
            End Set
        End Property

        Property TablesToDeleteFrom As Object
            Get
                Return _TablesToDeleteFrom
            End Get
            Set(ByVal value As Object)
                _TablesToDeleteFrom = value
            End Set
        End Property
        '---

        Property NumTablesDeletedFrom As Object
            Get
                Return _NumTablesDeletedFrom
            End Get
            Set(ByVal value As Object)
                _NumTablesDeletedFrom = value
            End Set
        End Property
        '---

        Property IsPasswordCorrect As Object
            Get
                Return _IsPasswordCorrect
            End Get
            Set(ByVal value As Object)
                _IsPasswordCorrect = value
            End Set
        End Property
        '--- 

        Property MaxInvalidPasswordAttempts As Object
            Get
                Return _MaxInvalidPasswordAttempts
            End Get
            Set(ByVal value As Object)
                _MaxInvalidPasswordAttempts = value
            End Set
        End Property
        '--- 

        Property PasswordAttemptWindow As Object
            Get
                Return _PasswordAttemptWindow
            End Get
            Set(ByVal value As Object)
                _PasswordAttemptWindow = value
            End Set
        End Property
        '---

        Property UpdateLastLoginActivityDate As Object
            Get
                Return _UpdateLastLoginActivityDate
            End Get
            Set(ByVal value As Object)
                _UpdateLastLoginActivityDate = value
            End Set
        End Property
        '---
        Property LastPasswordChangedDate As Object
            Get
                Return _LastPasswordChangedDate
            End Get
            Set(ByVal value As Object)
                _LastPasswordChangedDate = value
            End Set
        End Property
        '---


        Property IsLockedOut As Object
            Get
                Return _IsLockedOut
            End Get
            Set(ByVal value As Object)
                _IsLockedOut = value
            End Set
        End Property
        '---
        Property LastLockoutDate As Object
            Get
                Return _LastLockoutDate
            End Get
            Set(ByVal value As Object)
                _LastLockoutDate = value
            End Set
        End Property

        Property FailedPasswordAttemptCount As Object
            Get
                Return _FailedPasswordAttemptCount
            End Get
            Set(ByVal value As Object)
                _FailedPasswordAttemptCount = value
            End Set
        End Property
        '---
        Property ApplicationId As Object
            Get
                Return _ApplicationId
            End Get
            Set(ByVal value As Object)

                If (value Is DBNull.Value) Then
                    value = Guid.Parse("{00000000-0000-0000-0000-000000000000}").ToString
                    _ApplicationId = value
                Else
                    _ApplicationId = value
                End If


            End Set
        End Property
        '---

        '=======================================================


        Public Sub New(
            ByVal sApplicationName As String,
            ByVal sUserName As String
            )

            Me.ApplicationName = sApplicationName
            Me.UserName = sUserName

        End Sub

        Public Sub New()
        End Sub
    End Class       'c_User_Record

    Public Class c_USER_DL

        Private Const k_ClassName As String = "c_USER_DL"

        Private _connectionString As String

        Public Sub New()
            Initialize()
        End Sub

        Public Sub Initialize()

        End Sub

        Public Shared Function GetAllUsers_GivenApplicationName(ApplicationName As String) As List(Of c_User_Record)

            If ApplicationName Is Nothing Then
                ApplicationName = "No Application Chosen"
            End If

            Dim UsersForApplication_LIST As List(Of c_User_Record) = New List(Of c_User_Record)

            Try
                Using connection As SqlConnection = c_Database_Connection.GetConnection

                    Using selectCommand As New SqlCommand()

                        selectCommand.Connection = connection
                        selectCommand.CommandText = "aspnet_Membership_GetAllUsers"
                        selectCommand.CommandType = CommandType.StoredProcedure
                        selectCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName)
                        selectCommand.Parameters.AddWithValue("@PageIndex", 0)
                        selectCommand.Parameters.AddWithValue("@PageSize", 100)

                        connection.Open()
                        Using reader As SqlDataReader = selectCommand.ExecuteReader
                            Dim c_User_Record As c_User_Record
                            Do While reader.Read

                                c_User_Record = New c_User_Record

                                c_User_Record.UserName = reader("UserName").ToString
                                c_User_Record.Email = reader("Email").ToString
                                c_User_Record.PasswordQuestion = reader("PasswordQuestion").ToString
                                c_User_Record.Comment = reader("Comment").ToString
                                c_User_Record.IsApproved = c_CustomFunctions.CsqlBIT(reader("IsApproved").ToString)
                                c_User_Record.CreateDate = c_CustomFunctions.CSqlDateTime(reader("CreateDate").ToString)
                                c_User_Record.LastLoginDate = c_CustomFunctions.CSqlDateTime(reader("LastLoginDate").ToString)
                                c_User_Record.LastActivityDate = c_CustomFunctions.CSqlDateTime(reader("LastActivityDate").ToString)
                                c_User_Record.LastPasswordChangedDate = c_CustomFunctions.CSqlDateTime(reader("LastPasswordChangedDate").ToString)
                                ' *********
                                c_User_Record.UserId = reader("UserId").ToString
                                ' *********                                
                                'c_User_Record.IsLockedOut = c_CustomFunctions.CsqlBIT(reader("IsLockedOut").ToString)
                                c_User_Record.LastLockoutDate = c_CustomFunctions.CSqlDateTime(reader("LastLockoutDate").ToString)

                                UsersForApplication_LIST.Add(c_User_Record)
                            Loop
                        End Using    'reader

                    End Using  'selectCommand

                End Using   'connection

            Catch ex As System.Data.SqlClient.SqlException

                Throw New ApplicationException(ex.Message)

            Catch ex As Exception
                Throw New ApplicationException(ex.Message)

            Finally

            End Try

            Return UsersForApplication_LIST

        End Function

        ' Select an employee.

        Public Shared Function GetUser(ByVal UserName As String, ByVal ApplicationName As String) As List(Of c_User_Record)

            Dim c_User_Record As c_User_Record
            Dim Users As List(Of c_User_Record) = New List(Of c_User_Record)()
            Try
                Using connection As New SqlConnection(c_Database_Connection.GetConnectionString)

                    Using selectCommand As New SqlCommand()


                        selectCommand.Connection = connection
                        selectCommand.CommandText = "prj_0031_WA003_SP_001_SELECT_User_Given_ApplicationName_and_UserName"
                        ' .. and sets the command type.
                        selectCommand.CommandType = CommandType.StoredProcedure
                        selectCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName)
                        selectCommand.Parameters.AddWithValue("@UserName ", UserName)

                        connection.Open()

                        Using reader As SqlDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow)



                            If reader.Read Then

                                c_User_Record = New c_User_Record
                                c_User_Record.ApplicationName = reader("ApplicationName").ToString
                                c_User_Record.UserName = reader("UserName").ToString
                                c_User_Record.Password = reader("Password").ToString
                                c_User_Record.PasswordSalt = reader("PasswordSalt").ToString
                                c_User_Record.Email = reader("Email").ToString
                                c_User_Record.PasswordQuestion = reader("PasswordQuestion").ToString
                                c_User_Record.PasswordAnswer = reader("PasswordAnswer").ToString
                                c_User_Record.IsApproved = c_CustomFunctions.CsqlBIT(reader("IsApproved"))
                                c_User_Record.CreateDate = c_CustomFunctions.CSqlDateTime(reader("CreateDate"))
                                c_User_Record.PasswordFormat = reader("PasswordFormat").ToString
                                c_User_Record.UserId = Guid.Parse(reader("UserId").ToString())
                                c_User_Record.IsLockedOut = c_CustomFunctions.CsqlBIT(reader("IsLockedOut"))
                                c_User_Record.LastLoginDate = c_CustomFunctions.CSqlDateTime(reader("LastLoginDate"))
                                c_User_Record.FailedPasswordAttemptCount = c_CustomFunctions.CsqlInt16(reader("FailedPasswordAttemptCount"))
                                c_User_Record.LastActivityDate = c_CustomFunctions.CSqlDateTime(reader("LastActivityDate"))
                                c_User_Record.ApplicationId = Guid.Parse(reader("ApplicationId").ToString())


                            Else
                                c_User_Record = Nothing
                            End If

                            Users.Add(c_User_Record)

                        End Using ' reader

                    End Using '  selectCommand

                End Using   'connection

            Catch ex As System.Data.SqlClient.SqlException
                c_Error.UnhandledSqlClientExceptionHandler(ex, "Get_User", k_ClassName)


            Catch ex As Exception
                c_Error.UnhandledExceptionHandler(ex, "Get_User", k_ClassName)
            Finally

            End Try

            Return Users

        End Function

        Public Shared Function UpdateUser(User As c_User_Record) As Integer 'Just updates the Password


            User.CurrentTimeUtc = fn_DotNetDateTime_to_SQLDateTime(Now())
            User.PasswordSalt = User.Password
            User.PasswordFormat = 0
            User.MaxInvalidPasswordAttempts = 100
            User.PasswordAttemptWindow = 100
            User.PasswordAnswer = String.Empty


            Dim iReturn As Integer = 99

            Try

                Using connection As SqlConnection = c_Database_Connection.GetConnection
                    '====================================================================

                    Using cmd As New SqlCommand("aspnet_Membership_ResetPassword", connection)

                        cmd.CommandType = CommandType.StoredProcedure

                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        cmd.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue


                        '---
                        'REQUIRED:
                        cmd.Parameters.Add(New SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256)).Value = User.ApplicationName
                        cmd.Parameters.Add(New SqlParameter("@UserName", SqlDbType.NVarChar, 256)).Value = User.UserName
                        cmd.Parameters.Add(New SqlParameter("@NewPassword", SqlDbType.NVarChar, 128)).Value = User.Password
                        '---
                        '=============== START NEW Training PARMs ============================================================================

                        '---
                        FixNullValues_Then_AddParameter(User.MaxInvalidPasswordAttempts, cmd, "@MaxInvalidPasswordAttempts", TheDataType._Int)
                        FixNullValues_Then_AddParameter(User.PasswordAttemptWindow, cmd, "@PasswordAttemptWindow", TheDataType._Int)
                        FixNullValues_Then_AddParameter(User.PasswordSalt, cmd, "@PasswordSalt", TheDataType._NVarChar, 128)
                        FixNullValues_Then_AddParameter(User.CurrentTimeUtc, cmd, "@CurrentTimeUtc ", TheDataType._SqlDateTime)
                        FixNullValues_Then_AddParameter(User.PasswordFormat, cmd, "@PasswordFormat", TheDataType._Int)
                        FixNullValues_Then_AddParameter(User.PasswordAnswer, cmd, "@PasswordAnswer", TheDataType._NVarChar, 128)

                        '---

                        '=========================================================
                        connection.Open()
                        c_Error.PrintParameterListInSQLCommand(cmd)     '<== Just for debugging
                        ' c_Error.PrintParameterListInSQLCommand(cmd)
                        Debug.Print("After Open, before ExecuteNonQuery")

                        cmd.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer)     'returns SQL ErrorCode

                    End Using 'cmd
                End Using 'connection

                '=========================================================
            Catch ex As SqlException

                'If ex.Number = 2627 Then
                Throw New ApplicationException(ex.Message)



            Catch ex As Exception
                Throw New ApplicationException(ex.Message)

                Throw ex
            Finally
                'connection.Close()
            End Try

            Return iReturn

        End Function

        Public Function InsertUser(User As c_User_Record) As Integer
            Dim iReturn As Integer = 99

            User.PasswordSalt = User.Password
            User.CurrentTimeUtc = fn_DotNetDateTime_to_SQLDateTime(Now())
            User.CreateDate = fn_DotNetDateTime_to_SQLDateTime(Now())
            User.PasswordFormat = 0
            User.UserId = System.Guid.NewGuid
            User.IsApproved = 1


            Try


                Using connection As SqlConnection = c_Database_Connection.GetConnection
                    '====================================================================

                    Using cmd As New SqlCommand("aspnet_Membership_CreateUser", connection)
                        '=========================================================
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        cmd.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue

                        ''---
                        ''REQUIRED
                        'cmd.Parameters.Add(New SqlParameter("@iT05_FK", SqlDbType.Int)).Value = User.T05_FK
                        ''---
                        FixNullValues_Then_AddParameter(User.ApplicationName, cmd, "@ApplicationName", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.UserName, cmd, "@UserName", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.Password, cmd, "@Password", TheDataType._NVarChar, 128)
                        FixNullValues_Then_AddParameter(User.PasswordSalt, cmd, "@PasswordSalt", TheDataType._NVarChar, 128)
                        FixNullValues_Then_AddParameter(User.Email, cmd, "@Email ", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.PasswordQuestion, cmd, "@PasswordQuestion ", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.PasswordAnswer, cmd, "@PasswordAnswer", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.IsApproved, cmd, "@IsApproved", TheDataType._Bit)
                        FixNullValues_Then_AddParameter(User.CurrentTimeUtc, cmd, "@CurrentTimeUtc", TheDataType._SqlDateTime)
                        FixNullValues_Then_AddParameter(User.CreateDate, cmd, "@CreateDate ", TheDataType._SqlDateTime)
                        FixNullValues_Then_AddParameter(User.UniqueEmail, cmd, "@UniqueEmail", TheDataType._SmallInt)
                        FixNullValues_Then_AddParameter(User.PasswordFormat, cmd, "@PasswordFormat ", TheDataType._SmallInt)
                        FixNullValues_Then_AddParameter(User.UserId, cmd, "@UserId", TheDataType._SqlGUID)

                        '---

                        connection.Open()
                        cmd.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer)

                        '=========================================================
                    End Using   'cmd
                    '====================================================================
                End Using 'connection 

            Catch ex As SqlException
                c_Error.UnhandledSqlClientExceptionHandler(ex, "InsertUser", k_ClassName)
            Catch ex As Exception
                c_Error.UnhandledExceptionHandler(ex, "InsertUser", k_ClassName)
                Throw ex
            Finally

            End Try

            Return iReturn
        End Function

        '
        ' Delete the Employee by ID.
        '   This method assumes that ConflictDetection is Set to OverwriteValues.
        Public Shared Function DeleteUser(User As c_User_Record) As Integer

            Dim iReturn As Integer = 0

            Try

                Using connection As New SqlConnection(c_Database_Connection.GetConnectionString)

                    Using DeleteCommand As New SqlCommand()

                        DeleteCommand.Connection = connection
                        DeleteCommand.CommandText = "aspnet_Users_DeleteUser"
                        ' .. and sets the command type.
                        DeleteCommand.CommandType = CommandType.StoredProcedure

                        'The return value PARM
                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        DeleteCommand.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue
                        'The PK PARM
                        DeleteCommand.Parameters.AddWithValue("@ApplicationName", User.ApplicationName)
                        DeleteCommand.Parameters.AddWithValue("@UserName", User.UserName)
                        DeleteCommand.Parameters.AddWithValue("@TablesToDeleteFrom", 15)
                        DeleteCommand.Parameters.AddWithValue("@NumTablesDeletedFrom", 0)
                        connection.Open()
                        DeleteCommand.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer)

                    End Using 'DeleteCommand

                End Using 'connection 



            Catch ex As System.Data.SqlClient.SqlException

                Throw New ApplicationException(ex.Message)
            Catch ex As Exception

                Throw New ApplicationException(ex.Message)
            Finally

            End Try

            Return iReturn      'Error Code

        End Function


    End Class

    Public Class c_Database_Connection

        Public Shared Function GetConnection() As SqlConnection

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("SHAREPOINT01_aspnetdb").ConnectionString

            Return New SqlConnection(connectionString)
        End Function

        Public Shared Function GetConnectionString() As String

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("SHAREPOINT01_aspnetdb").ConnectionString
          
            Return connectionString

        End Function

    End Class


    Public Class c_CustomFunctions

        Public Shared Function fn_boolStringIsPresent(ByVal strStringToSearch As String, ByVal strStringToSearchFor As String) As Boolean
            ' Returns true if the strStringToSearchFor is in strStringToSearch
            Dim iX As Integer
            Dim boolX As Boolean
            iX = InStr(1, strStringToSearch, strStringToSearchFor)
            If iX = 0 Then
                boolX = False
            Else
                boolX = True
            End If
            Return boolX

        End Function


        Public Shared Function CsqlBIT(o As Object) As Boolean
            Dim bX As Boolean

            If IsDBNull(o) Then
                bX = False
            Else
                bX = CType(o, Boolean)
            End If

            Return bX

        End Function


        Public Shared Function CsqlInt32(o As Object) As SqlInt32
            Dim iX As SqlInt32

            If IsDBNull(o) Then
                iX = SqlInt32.Null
            Else
                iX = CType(CInt(o), SqlInt32)
            End If

            Return CType(iX, SqlInt32)

        End Function

        Public Shared Function CsqlInt16(o As Object) As SqlInt16
            Dim iX As SqlInt16

            If IsDBNull(o) Then
                iX = SqlInt16.Null
            Else
                iX = CType(CInt(o), SqlInt16)
            End If

            Return CType(iX, SqlInt16)

        End Function


        Public Shared Function CSqlDateTime(o As Object) As SqlDateTime
            Dim dX As SqlDateTime

            Try


                If IsDBNull(o) Then
                    dX = SqlDateTime.Null
                Else
                    dX = CType(o.ToString, SqlDateTime)
                End If

                Return dX

            Catch ex As SqlException

                c_Error.UnhandledSqlClientExceptionHandler(ex, "CSqlDateTime", "c_CustomFunctions")
            End Try
        End Function

        Public Shared Function CSqlDecimal(o As Object) As SqlDecimal
            Dim dX As SqlDecimal
            Try


                If IsDBNull(o) Then
                    dX = SqlDecimal.Null
                Else
                    dX = CType(o.ToString, SqlDecimal)
                End If

                Return dX

            Catch ex As SqlException

                c_Error.UnhandledSqlClientExceptionHandler(ex, "CSqlDecimal", "c_CustomFunctions")
            End Try

        End Function

        Public Shared Function NullableINTisNothing(iX As Nullable(Of Integer)) As Boolean

            Dim bX As Boolean = False
            '===================================
            If IsNothing(iX) Then bX = True
            If Not iX.HasValue Then bX = True
            '===================================
            Return bX

        End Function



    End Class
End Namespace

