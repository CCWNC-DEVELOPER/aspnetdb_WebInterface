Imports System.Data.SqlClient

Public Class c_DataBase

    Public Shared Function GetConnection() As SqlConnection


        'Dim connectionString As String =
        '    "Data Source=SQL-SERVER\PRODUCTION;Initial Catalog=DB2_CRM;" &
        '"Integrated Security=True"


        Dim connectionString As String =
            "Data Source=HOMETOWER\DEV;Initial Catalog=aspnetdb;" &
            "Integrated Security=True"


        Return New SqlConnection(connectionString)
    End Function

End Class
