Imports CCWNC411_Security

Public Class Roles_for_Application
    Inherits System.Web.UI.Page

    Private m_bBind_DataToTheGrid As Boolean = False

    'NOTES:
    '1] Uses return value from Deleted event (ods_for_GridView_Deleted) to put a message in the Label
    '2] Button "btn_AddNewRoleToApplication_Click" calls the backend via the namespace
    '3] Button in the GridView does not use the standared "Delete" command b/ rather "DeleteRole" command so that I don't have to use the 
    '       Object but rather 2 string parms. I have to do this b/c the 'ApplicationName' is coming from a session variable rather than a row value of the GridView


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Form.Target = "_self"
        lbl_Message.ForeColor = Drawing.Color.White

        If IsPostBack Then
            Debug.Print("IsPostBack")

        Else
            DropDownList_Application.Items.Add(New ListItem("---Select---", "0"))
            Debug.Print("Is Not PostBack")

        End If
    End Sub

    '||||||Button|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Protected Sub btn_GetListOfRolesForTheApplication_Click(sender As Object, e As EventArgs) Handles btn_GetListOfRolesForTheApplication.Click



        Try
            If DropDownList_Application.SelectedValue <> "0" Then

                lbl_Message.ForeColor = Drawing.Color.White


                m_bBind_DataToTheGrid = True    'This lets the GridView know that it is alright to load the data


                'Populate the GridView
                ods_for_GridView.SelectParameters.Clear()
                ods_for_GridView.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                GridView_RolesInTheApplication.DataSourceID = "ods_for_GridView"
                GridView_RolesInTheApplication.DataBind()



            Else

                lbl_Message.ForeColor = Drawing.Color.Black
                lbl_Message.Text = "You need to select an Application first"
            End If
        Catch ex As Exception
            lbl_Message.ForeColor = Drawing.Color.Black
            lbl_Message.Text = ex.Message
        End Try
    End Sub

    Private Sub btn_AddNewRoleToApplication_Click(sender As Object, e As System.EventArgs) Handles btn_AddNewRoleToApplication.Click
        Try

            If DropDownList_Application.SelectedValue <> "0" Then



                Dim sApplicationName As String = (CType(Session.Item("ApplicationName"), String))
                Dim sRoleName As String = txt_NewRoleToAddToApplication.Text

                If Len(sRoleName) > 0 Then


                    ns_ROLE.c_ROLE_DL.InsertRole(sApplicationName, sRoleName)


                    ods_for_GridView.SelectParameters.Clear()
                    ods_for_GridView.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                    GridView_RolesInTheApplication.DataSourceID = "ods_for_GridView"
                    GridView_RolesInTheApplication.DataBind()
                Else
                    lbl_Message.Text = "You can not create a blank role"
                End If

            Else

                lbl_Message.ForeColor = Drawing.Color.Black
                lbl_Message.Text = "You need to select an Application, before adding a role"
            End If



        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try

    End Sub

    '||||||DropDown|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Public Sub DropDownList_Application_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList_Application.SelectedIndexChanged

        If Session("ApplicationName") Is Nothing Then

            Session("ApplicationName") = DropDownList_Application.SelectedValue

        Else

            Session("ApplicationName") = DropDownList_Application.SelectedValue

            '=========================================I want it to show no records ========================
            ods_for_GridView.SelectParameters.Clear()
            ods_for_GridView.SelectParameters.Add("ApplicationName", "whatever")
            GridView_RolesInTheApplication.DataSourceID = "ods_for_GridView"
            '=========================================I want it to show no records ========================
            m_bBind_DataToTheGrid = False


        End If




    End Sub


    '||||||GridView|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
 
    Protected Sub GridView_RolesInTheApplication_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView_RolesInTheApplication.RowCommand

        Dim index As Integer
        Dim sRoleName As String = ""


        If e.CommandName = "DeleteRole" Then
            ' Convert the row index stored in the CommandArgument
            ' property to an Integer.
            index = Convert.ToInt32(e.CommandArgument)

            Dim selectedRow As GridViewRow = GridView_RolesInTheApplication.Rows(index)
            Dim cell_Role As TableCell = selectedRow.Cells(1)
            sRoleName = cell_Role.Text

        End If


        Dim iResponse As Integer
        iResponse = ns_ROLE.c_ROLE_DL.DeleteRole((CType(Session.Item("ApplicationName"), String)), sRoleName)

        'These messages don't seem to work
        If iResponse = 0 Then
            lbl_Message.Text = "Role: " & sRoleName & " was deleted"
        Else
            lbl_Message.Text = "Role: " & sRoleName & " was not deleted, Error Code: " & iResponse.ToString
        End If

        GridView_RolesInTheApplication.DataBind()

    End Sub


    '||||||GridView - ODS |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Private Sub ods_for_GridView_Deleted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ods_for_GridView.Deleted

        Dim retvalue = Convert.ToInt32(e.ReturnValue)

        Select Case retvalue
            Case 2
                lbl_Message.Text = "The Role was not Deleted b/c there are still Users associated with it. Remove the users from the Role first."
            Case Else

        End Select

    End Sub


End Class