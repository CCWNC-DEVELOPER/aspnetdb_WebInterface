Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel   '<============
Imports System.Data.SqlTypes

Namespace ns_USER_APPLICATION_ROLE


    Public Class c_USER_APPLICATION_ROLE_Record

        '-------- in the CREATE SP
        Private _ApplicationName As String = ""
        Private _UserName As String = ""
        Private _RoleName As String = ""
        Private _ApplicationId As Object
        Private _UserId As Object
        Private _RoleId As Object
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
        Property Rolename As String
            Get
                Return _RoleName
            End Get
            Set(ByVal value As String)
                _RoleName = value
            End Set
        End Property
        '---

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
        Property UserId As Object
            Get
                Return _UserId
            End Get
            Set(ByVal value As Object)
                _UserId = value
            End Set
        End Property
        '---
        Property RoleId As Object
            Get
                Return _RoleId
            End Get
            Set(ByVal value As Object)
                _RoleId = value
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

        '=======================================================

        Public Sub New()
        End Sub
    End Class       'c_USER_APPLICATION_ROLE_Record

    Public Class c_USER_APPLICATION_ROLE_DL

        Private Const k_ClassName As String = "c_USER_APPLICATION_ROLE_DL"

        Private _connectionString As String

        Public Sub New()
            Initialize()
        End Sub

        Public Sub Initialize()

        End Sub

        Public Shared Function GetAllUsers_Given_ApplicationAndRole_Name(ApplicationName As String, RoleName As String) As List(Of c_USER_APPLICATION_ROLE_Record)

            If ApplicationName Is Nothing Then
                ApplicationName = "No Application Chosen"
            End If

            If RoleName Is Nothing Then
                RoleName = "No Role Chosen"
            End If

            Dim USER_APPLICATION_ROLE_LIST As List(Of c_USER_APPLICATION_ROLE_Record) = New List(Of c_USER_APPLICATION_ROLE_Record)

            Try
                Using connection As SqlConnection = c_Database_Connection.GetConnection

                    Using selectCommand As New SqlCommand()

                        selectCommand.Connection = connection
                        selectCommand.CommandText = "aspnet_UsersInRoles_GetUsersInRoles"
                        selectCommand.CommandType = CommandType.StoredProcedure
                        selectCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName)
                        selectCommand.Parameters.AddWithValue("@RoleName", RoleName)

                        connection.Open()
                        Using reader As SqlDataReader = selectCommand.ExecuteReader
                            Dim c_USER_APPLICATION_ROLE_Record As c_USER_APPLICATION_ROLE_Record
                            Do While reader.Read

                                c_USER_APPLICATION_ROLE_Record = New c_USER_APPLICATION_ROLE_Record

                                c_USER_APPLICATION_ROLE_Record.UserName = reader("UserName").ToString

                                USER_APPLICATION_ROLE_LIST.Add(c_USER_APPLICATION_ROLE_Record)
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

            Return USER_APPLICATION_ROLE_LIST

        End Function

        Public Shared Function InsertUser_Given_ApplicationAndRole_Name(sUserName As String, sApplicationName As String, sRoleName As String) As Integer


            Dim CurrentTimeUtc As SqlDateTime = fn_DotNetDateTime_to_SQLDateTime(Now())
            Dim iReturn As Integer = 0

            Try


                Using connection As SqlConnection = c_Database_Connection.GetConnection
                    '====================================================================

                    Using cmd As New SqlCommand("aspnet_UsersInRoles_AddUsersToRoles", connection)
                        '=========================================================
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        cmd.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue

                        ''---
                        ''REQUIRED
                        cmd.Parameters.Add(New SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256)).Value = sApplicationName
                        cmd.Parameters.Add(New SqlParameter("@UserNames", SqlDbType.NVarChar, 256)).Value = sUserName
                        cmd.Parameters.Add(New SqlParameter("@RoleNames", SqlDbType.NVarChar, 256)).Value = sRoleName
                        cmd.Parameters.Add(New SqlParameter("@CurrentTimeUtc", SqlDbType.DateTime)).Value = CurrentTimeUtc
                        '---

                        connection.Open()
                        cmd.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer)

                        '=========================================================
                    End Using   'cmd
                    '====================================================================
                End Using 'connection 

            Catch ex As SqlException
                Throw New ApplicationException(ex.Message)
                'c_Error.UnhandledSqlClientExceptionHandler(ex, "InsertUser_Given_ApplicationAndRole_Name", k_ClassName)
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
                'c_Error.UnhandledExceptionHandler(ex, "InsertUser_Given_ApplicationAndRole_Name", k_ClassName)
                Throw ex
            Finally

            End Try

            Return iReturn
        End Function

        Public Shared Function DeleteUser_Given_ApplicationAndRole_Name(sUserName As String, sApplicationName As String, sRoleName As String) As Integer
            Dim iReturn As Integer = 0

            Try

                Using connection As New SqlConnection(c_Database_Connection.GetConnectionString)

                    Using DeleteCommand As New SqlCommand()

                        DeleteCommand.Connection = connection
                        DeleteCommand.CommandText = "aspnet_UsersInRoles_RemoveUsersFromRoles"
                        ' .. and sets the command type.
                        DeleteCommand.CommandType = CommandType.StoredProcedure

                        'The return value PARM
                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        DeleteCommand.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue
                        'The PK PARM
                        'DeleteCommand.Parameters.AddWithValue("@ApplicationName", Role.ApplicationName)
                        'DeleteCommand.Parameters.AddWithValue("@RoleName", Role.RoleName)
                        DeleteCommand.Parameters.AddWithValue("@ApplicationName", sApplicationName)
                        DeleteCommand.Parameters.AddWithValue("@RoleNames", sRoleName)
                        DeleteCommand.Parameters.AddWithValue("@UserNames", sUserName)


                        connection.Open()
                        DeleteCommand.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer) 'Error code: 2 means it did not delete the Role b/c there were users assigned to the role

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

        Public Shared Function GetAllUsers_Not_in_Application_Role_combination(ApplicationName As String, RoleName As String) As List(Of c_USER_APPLICATION_ROLE_Record)
            'This returns the list of users that are in the given Application, but not in the specified role

            If ApplicationName Is Nothing Then
                ApplicationName = "None"
            End If

            If RoleName Is Nothing Then
                RoleName = "None"
            End If


            Dim USER_APPLICATION_ROLE_LIST As List(Of c_USER_APPLICATION_ROLE_Record) = New List(Of c_USER_APPLICATION_ROLE_Record)

            Try
                Using connection As SqlConnection = c_Database_Connection.GetConnection

                    Using selectCommand As New SqlCommand()

                        selectCommand.Connection = connection
                        selectCommand.CommandText = "prj_0031_WA003_SP_002_SELECT_User_Not_in_Application_Role_combination"
                        selectCommand.CommandType = CommandType.StoredProcedure
                        selectCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName)
                        selectCommand.Parameters.AddWithValue("@RoleName", RoleName)
                        connection.Open()
                        Using reader As SqlDataReader = selectCommand.ExecuteReader
                            Dim c_USER_APPLICATION_ROLE_Record As c_USER_APPLICATION_ROLE_Record
                            Do While reader.Read

                                c_USER_APPLICATION_ROLE_Record = New c_USER_APPLICATION_ROLE_Record

                                c_USER_APPLICATION_ROLE_Record.UserName = reader("UserName").ToString

                                USER_APPLICATION_ROLE_LIST.Add(c_USER_APPLICATION_ROLE_Record)
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

            Return USER_APPLICATION_ROLE_LIST

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
