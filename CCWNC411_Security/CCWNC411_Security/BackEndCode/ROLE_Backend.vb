Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel   '<============
Imports System.Data.SqlTypes

Namespace ns_ROLE

    Public Class c_Role_Record

        Private _ApplicationName As String = ""
        Private _UserName As String = ""
        Private _RoleName As String = ""
        Private _DeleteOnlyIfRoleIsEmpty As Object   'bit
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
        Property RoleName As String
            Get
                Return _RoleName
            End Get
            Set(ByVal value As String)
                _RoleName = value
            End Set
        End Property
        '---
        Property DeleteOnlyIfRoleIsEmpty As Object
            Get
                Return _DeleteOnlyIfRoleIsEmpty
            End Get
            Set(ByVal value As Object)
                _DeleteOnlyIfRoleIsEmpty = value
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
        Public Sub New()

        End Sub
    End Class

    Public Class c_ROLE_DL

        Private Const k_ClassName As String = "c_Role_DL"

        Private _connectionString As String

        Public Sub New()
            Initialize()
        End Sub

        Public Sub Initialize()

        End Sub

        Public Shared Function GetAllRoles_GivenApplicationName(ApplicationName As String) As List(Of c_Role_Record)

            If ApplicationName Is Nothing Then
                ApplicationName = "No Application Chosen"
            End If

            Dim RolesForApplication_LIST As List(Of c_Role_Record) = New List(Of c_Role_Record)

            Try
                Using connection As SqlConnection = c_Database_Connection.GetConnection

                    Using selectCommand As New SqlCommand()

                        selectCommand.Connection = connection
                        selectCommand.CommandText = "aspnet_Roles_GetAllRoles"
                        selectCommand.CommandType = CommandType.StoredProcedure
                        selectCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName)

                        connection.Open()
                        Using reader As SqlDataReader = selectCommand.ExecuteReader
                            Dim c_Role_Record As c_Role_Record
                            Do While reader.Read

                                c_Role_Record = New c_Role_Record

                                c_Role_Record.RoleName = reader("RoleName").ToString

                                RolesForApplication_LIST.Add(c_Role_Record)

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

            Return RolesForApplication_LIST

        End Function

        ' Select an employee.

 
        Public Shared Function InsertRole(sApplicationName As String, sRoleName As String) As Integer
            Dim iReturn As Integer = 99

            Try


                Using connection As SqlConnection = c_Database_Connection.GetConnection
                    '====================================================================

                    Using cmd As New SqlCommand("aspnet_Roles_CreateRole", connection)
                        '=========================================================
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        cmd.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue

                        ''---
                        ''REQUIRED
                        cmd.Parameters.Add(New SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256)).Value = sApplicationName
                        cmd.Parameters.Add(New SqlParameter("@RoleName", SqlDbType.NVarChar, 256)).Value = sRoleName
                        '---

                        connection.Open()
                        cmd.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer)

                        '=========================================================
                    End Using   'cmd
                    '====================================================================
                End Using 'connection 

            Catch ex As SqlException
                c_Error.UnhandledSqlClientExceptionHandler(ex, "InsertRole", k_ClassName)
            Catch ex As Exception
                c_Error.UnhandledExceptionHandler(ex, "InsertRole", k_ClassName)
                Throw ex
            Finally

            End Try

            Return iReturn
        End Function

 
        Public Shared Function DeleteRole(sApplicationName As String, sRoleName As String) As Integer
            Dim iReturn As Integer = 0

            Try

                Using connection As New SqlConnection(c_Database_Connection.GetConnectionString)

                    Using DeleteCommand As New SqlCommand()

                        DeleteCommand.Connection = connection
                        DeleteCommand.CommandText = "aspnet_Roles_DeleteRole"
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
                        DeleteCommand.Parameters.AddWithValue("@RoleName", sRoleName)
                        DeleteCommand.Parameters.AddWithValue("@DeleteOnlyIfRoleIsEmpty", 1)    'if 0 it will delete the role even if there are users assigned to the role

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
