Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlTypes
Imports System.Web.Configuration  ' For DatabaseComponent ?
Imports System.ComponentModel  ' For DatabaseComponent ?

Namespace DatabaseComponent
    <DataObject()>
    Public Class User_DL
        Private Const k_ClassName As String = "User_DL"

        Public Sub New()

        End Sub

        <DataObjectMethod(DataObjectMethodType.Insert, True)>
        Public Function Add_User_Record(User As User_Record) As SqlGuid
            Dim iReturn As Integer = 99
            Dim new_UserId As SqlGuid
            Try


                Using connection As SqlConnection = c_DataBase.GetConnection

                    '====================================================================

                    Using cmd As New SqlCommand("aspnet_Membership_CreateUser", connection)
                        '=========================================================
                        cmd.CommandType = CommandType.StoredProcedure
                        'create but don't return the RETURN parm
                        Dim prm As New SqlParameter("RETURN", SqlDbType.Int)
                        cmd.Parameters.Add(prm)
                        prm.Direction = ParameterDirection.ReturnValue

                        '---

                        FixNullValues_Then_AddParameter(User.ApplicationName, cmd, "@ApplicationName", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.UserName, cmd, "@UserName", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.Password, cmd, "@Password", TheDataType._NVarChar, 128)
                        FixNullValues_Then_AddParameter(User.UserName, cmd, "@PasswordSalt", TheDataType._NVarChar, 128)
                        FixNullValues_Then_AddParameter(User.Email, cmd, "@Email", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.PasswordQuestion, cmd, "@PasswordQuestion", TheDataType._NVarChar, 256)
                        FixNullValues_Then_AddParameter(User.PasswordAnswer, cmd, "@PasswordAnswer", TheDataType._NVarChar, 128)
                        FixNullValues_Then_AddParameter(CBool(User.IsApproved), cmd, "@IsApproved", TheDataType._Bit)
                        FixNullValues_Then_AddParameter(CInt(User.UniqueEmail), cmd, "@UniqueEmail", TheDataType._SmallInt)
                        FixNullValues_Then_AddParameter(CInt(User.PasswordFormat), cmd, "@PasswordFormat", TheDataType._SmallInt)
                        FixNullValues_Then_AddParameter(fn_DotNetDateTime_to_SQLDateTime(User.CurrentTimeUtc), cmd, "@CurrentTimeUtc", TheDataType._SqlDateTime)
                        FixNullValues_Then_AddParameter(fn_DotNetDateTime_to_SQLDateTime(User.CreateDate), cmd, "@CreateDate", TheDataType._SqlDateTime)


                        '---
                        'cmd.Parameters.Add(New SqlParameter("@UserId", SqlDbType.UniqueIdentifier)).Value = User.UserId
                        Dim p As SqlParameter = cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier)
                        p.Direction = ParameterDirection.Output

                        '---

                        connection.Open()
                        cmd.ExecuteNonQuery()
                        iReturn = CType(prm.Value, Integer)
                        new_UserId = p.SqlValue
                        '=========================================================
                    End Using   'cmd
                    '====================================================================
                End Using 'connection 

            Catch ex As SqlException
                c_Error.UnhandledSqlClientExceptionHandler(ex, "Add_User_Record", k_ClassName)
            Catch ex As Exception
                c_Error.UnhandledExceptionHandler(ex, "Add_User_Record", k_ClassName)
                Throw ex
            Finally

            End Try

            Return new_UserId
        End Function

        <DataObjectMethod(DataObjectMethodType.[Select], False)> _
        Public Shared Function Get_New_UserRecord() As User_Record

            Dim userRecordX As User_Record = New User_Record

            'userRecordX.UserId = System.Guid.NewGuid
            Return userRecordX

        End Function


    End Class



    '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Public Class User_Record

        'Public Property ApplicationName As String
        'Public Property UserName As String
        'Public Property Password As String
        'Public Property PasswordSalt As String
        'Public Property Email As String
        'Public Property PasswordQuestion As String
        'Public Property PasswordAnswer As String
        'Public Property IsApproved As Boolean
        'Public Property CurrentTimeUtc As SqlDateTime
        'Public Property CreateDate As SqlDateTime
        'Public Property UniqueEmail As SqlInt16
        'Public Property PasswordFormat As SqlInt16
        'Public Property UserId As SqlGuid
        'Public Property Comment As String
        'Public Property LastLoginDate As SqlDateTime
        'Public Property LastActivityDate As SqlDateTime
        'Public Property TablesToDeleteFrom As SqlInt16
        'Public Property NumTablesDeletedFrom As SqlInt16
        'Public Property IsPasswordCorrect As Boolean
        'Public Property MaxInvalidPasswordAttempts As SqlInt16
        'Public Property PasswordAttemptWindow As SqlInt16
        'Public Property UpdateLastLoginActivityDate As SqlDateTime

        '=======================================================

        Public Sub New()

        End Sub

        '=======================================================

        '---

        Private _ApplicationName As String = ""
        Property ApplicationName As String
            Get
                Return _ApplicationName
            End Get
            Set(ByVal value As String)
                _ApplicationName = value
            End Set
        End Property

        '---

        Private _UserName As String = ""
        Property UserName As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
            End Set
        End Property

        '---

        Private _Password As String = ""
        Property Password As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property

        '---

        Private _PasswordSalt As String = ""
        Property PasswordSalt As String
            Get
                Return _PasswordSalt
            End Get
            Set(ByVal value As String)
                _PasswordSalt = value
            End Set
        End Property

        '---

        Private _Email As String = ""
        Property Email As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property

        '---

        Private _PasswordQuestion As String = ""
        Property PasswordQuestion As String
            Get
                Return _PasswordQuestion
            End Get
            Set(ByVal value As String)
                _PasswordQuestion = value
            End Set
        End Property

        '---

        Private _PasswordAnswer As String = ""
        Property PasswordAnswer As String
            Get
                Return _PasswordAnswer
            End Get
            Set(ByVal value As String)
                _PasswordAnswer = value
            End Set
        End Property

        '---

        Private _IsApproved As Boolean = 1
        Property IsApproved As Boolean
            Get
                Return _IsApproved
            End Get
            Set(ByVal value As Boolean)
                _IsApproved = value
            End Set
        End Property

        '---

        Private _CurrentTimeUtc As SqlDateTime = Now()
        Property CurrentTimeUtc As SqlDateTime
            Get
                Return _CurrentTimeUtc
            End Get
            Set(ByVal value As SqlDateTime)
                _CurrentTimeUtc = value
            End Set
        End Property

        '---

        Private _CreateDate As SqlDateTime = Now()
        Property CreateDate As SqlDateTime
            Get
                Return _CreateDate
            End Get
            Set(ByVal value As SqlDateTime)
                _CreateDate = value
            End Set
        End Property

        '---

        Private _UniqueEmail As SqlInt16 = 0
        Property UniqueEmail As SqlInt16
            Get
                Return _UniqueEmail
            End Get
            Set(ByVal value As SqlInt16)
                _UniqueEmail = value
            End Set
        End Property

        '---

        Private _PasswordFormat As SqlInt16 = 0
        Property PasswordFormat As SqlInt16
            Get
                Return _PasswordFormat
            End Get
            Set(ByVal value As SqlInt16)
                _PasswordFormat = value
            End Set
        End Property

        '---

        Private _UserId As SqlGuid '= System.Guid.NewGuid
        Property UserId As SqlGuid
            Get
                Return _UserId
            End Get
            Set(ByVal value As SqlGuid)
                _UserId = value
            End Set
        End Property

        '---

        Private _Comment As String = ""
        Property Comment As String
            Get
                Return _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property

        '---


        Private _LastLoginDate As SqlDateTime = #1/1/1900#
        Property LastLoginDate As SqlDateTime
            Get
                Return _LastLoginDate
            End Get
            Set(ByVal value As SqlDateTime)
                _LastLoginDate = value
            End Set
        End Property

        '---

        Private _LastActivityDate As SqlDateTime = #1/1/1900#
        Property LastActivityDate As SqlDateTime
            Get
                Return _LastActivityDate
            End Get
            Set(ByVal value As SqlDateTime)
                _LastActivityDate = value
            End Set
        End Property

        '---

        Private _TablesToDeleteFrom As SqlInt16 = 15
        Property TablesToDeleteFrom As SqlInt16
            Get
                Return _TablesToDeleteFrom
            End Get
            Set(ByVal value As SqlInt16)
                _TablesToDeleteFrom = value
            End Set
        End Property

        '---

        Private _NumTablesDeletedFrom As SqlInt16 = 0
        Property NumTablesDeletedFrom As SqlInt16
            Get
                Return _NumTablesDeletedFrom
            End Get
            Set(ByVal value As SqlInt16)
                _NumTablesDeletedFrom = value
            End Set
        End Property

        '---

        Private _IsPasswordCorrect As Boolean = 1
        Property IsPasswordCorrect As Boolean
            Get
                Return _IsPasswordCorrect
            End Get
            Set(ByVal value As Boolean)
                _IsPasswordCorrect = value
            End Set
        End Property

        '--- 

        Private _MaxInvalidPasswordAttempts As SqlInt16 = 100
        Property MaxInvalidPasswordAttempts As SqlInt16
            Get
                Return _MaxInvalidPasswordAttempts
            End Get
            Set(ByVal value As SqlInt16)
                _MaxInvalidPasswordAttempts = value
            End Set
        End Property

        '--- 

        Private _PasswordAttemptWindow As SqlInt16 = 1
        Property PasswordAttemptWindow As SqlInt16
            Get
                Return _PasswordAttemptWindow
            End Get
            Set(ByVal value As SqlInt16)
                _PasswordAttemptWindow = value
            End Set
        End Property

        '---

        Private _UpdateLastLoginActivityDate As Boolean = 1
        Property UpdateLastLoginActivityDate As Boolean
            Get
                Return _UpdateLastLoginActivityDate
            End Get
            Set(ByVal value As Boolean)
                _UpdateLastLoginActivityDate = value
            End Set
        End Property

        '---

        '=======================================================

    End Class

    '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||



End Namespace


