Public Class Roles_for_User_Applications
    Inherits System.Web.UI.Page


    Private m_bBind_DataToTheGrid As Boolean = False
    Private m_bBind_DataTo_User_DropDown As Boolean = False

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

    Protected Sub btn_View_Users_in_RoleApplication_Click(sender As Object, e As System.EventArgs) Handles btn_View_Users_in_RoleApplication.Click

        Try
            If (DropDownList_Application.SelectedValue <> "0") And (DropDownList_Role.SelectedValue <> "0") Then

                lbl_Message.ForeColor = Drawing.Color.White


                m_bBind_DataToTheGrid = True    'This lets the GridView know that it is alright to load the data


                'Populate the GridView
                ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
                ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", (CType(Session.Item("RoleName"), String)))
                GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"
                GridView_UsersInApplicationRole.DataBind()



            Else

                lbl_Message.ForeColor = Drawing.Color.Black
                lbl_Message.Text = "You need to select an Application first"
            End If
        Catch ex As Exception
            lbl_Message.ForeColor = Drawing.Color.Black
            lbl_Message.Text = ex.Message
        End Try
    End Sub


    Protected Sub btn_AddUser_to_RoleApplication_Click(sender As Object, e As EventArgs) Handles btn_AddUser_to_RoleApplication.Click

        Try

            If (DropDownList_Application.SelectedValue <> "0") And (DropDownList_Role.SelectedValue <> "0") Then

                Dim sUserName As String = txt_NewUserToAddToRoleApplication.Text
                Dim sApplicationName As String = (CType(Session.Item("ApplicationName"), String))
                Dim sRoleName As String = (CType(Session.Item("RoleName"), String))


                If Len(sUserName) > 0 Then




                    ns_USER_APPLICATION_ROLE.c_USER_APPLICATION_ROLE_DL.InsertUser_Given_ApplicationAndRole_Name(sUserName, sApplicationName, sRoleName)

                    '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                    ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
                    ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                    ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", (CType(Session.Item("RoleName"), String)))

                    GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"
                    GridView_UsersInApplicationRole.DataBind()

                    '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                    DropDownList_User.Items.Clear()
                    DropDownList_User.Items.Add(New ListItem("---Select---", "0"))
                    m_bBind_DataTo_User_DropDown = True
                    ods_DropDownList_User.SelectParameters.Clear()

                    ods_DropDownList_User.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                    ods_DropDownList_User.SelectParameters.Add("RoleName", (CType(Session.Item("RoleName"), String)))
                    DropDownList_User.DataSourceID = "ods_DropDownList_User"
                    DropDownList_User.DataBind()
                    '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

                    txt_NewUserToAddToRoleApplication.Text = ""
                Else
                    lbl_Message.Text = "You can not add a blank User Name"
                End If

            Else

                lbl_Message.ForeColor = Drawing.Color.Black
                lbl_Message.Text = "You need to select an Application, before adding a role"
            End If



        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try

    End Sub


    '|||||| DropDown - Application |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Public Sub DropDownList_Application_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList_Application.SelectedIndexChanged

        'If Session("ApplicationName") Is Nothing Then

        '    Session("ApplicationName") = DropDownList_Application.SelectedValue

        'Else
        Try


            Session("ApplicationName") = DropDownList_Application.SelectedValue

            DropDownList_Role.Items.Clear()
            DropDownList_User.Items.Clear()
            DropDownList_Role.Items.Add(New ListItem("---Select---", "0"))
            DropDownList_User.Items.Add(New ListItem("---Select---", "0"))
            '=========================================I want the gridview to show no records ========================
            ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
            ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", "whatever")
            ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", "whatever")
            GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"
            '=========================================I want the Role drop-down to show no records ========================
            SqlDataSource_DropDownList_Role.SelectParameters.Clear()
            'SqlDataSource_DropDownList_Role.SelectCommand = "SELECT DISTINCT RoleName, RoleId FROM prj_0031_vw_001_ApplicationName_RoleName_UserName_and_IDs Where ApplicationName = '" & Session("ApplicationName") & "'"
            SqlDataSource_DropDownList_Role.SelectCommand = "SELECT DISTINCT RoleName, RoleId FROM prj_0031_vw_002_ApplicationName_RoleName_and_IDs Where ApplicationName = '" & Session("ApplicationName") & "'"
            DropDownList_Role.DataSourceID = "SqlDataSource_DropDownList_Role"
            DropDownList_Role.DataBind()
            '=========================================I want the User drop-down to show no records ========================
            ods_DropDownList_User.SelectParameters.Clear()
            ods_DropDownList_User.SelectParameters.Add("ApplicationName", "whatever")
            ods_DropDownList_User.SelectParameters.Add("RoleName", "whatever")
            DropDownList_User.DataSourceID = "ods_DropDownList_User"
            DropDownList_User.DataBind()


            m_bBind_DataTo_User_DropDown = False
            m_bBind_DataToTheGrid = False


            'End If


        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try

    End Sub

    '|||||| DropDown - Role |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Protected Sub DropDownList_Role_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList_Role.SelectedIndexChanged

        Try

            'If Session("RoleName") Is Nothing Then

            '    Session("RoleName") = DropDownList_Role.SelectedValue

            'Else

            Session("RoleName") = DropDownList_Role.SelectedValue


            'DropDownList_Role.Items.Clear()
            DropDownList_User.Items.Clear()
            'DropDownList_Role.Items.Add(New ListItem("---Select---", "0"))
            DropDownList_User.Items.Add(New ListItem("---Select---", "0"))
            '=========================================I want the gridview to show no records ========================
            ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
            ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", "whatever")
            ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", "whatever")
            GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"
            ''=========================================I want the Role drop-down to show no records ========================
            'SqlDataSource_DropDownList_Role.SelectParameters.Clear()
            'SqlDataSource_DropDownList_Role.SelectCommand = "SELECT DISTINCT RoleName, RoleId FROM prj_0031_vw_001_ApplicationName_RoleName_UserName_and_IDs Where ApplicationName = '" & Session("ApplicationName") & "'"
            'DropDownList_Role.DataSourceID = "SqlDataSource_DropDownList_Role"
            'DropDownList_Role.DataBind()
            '=========================================Determine whether the drop-down should  show  records ========================
            If (DropDownList_Application.SelectedValue <> "0") And (DropDownList_Role.SelectedValue <> "0") Then

                m_bBind_DataTo_User_DropDown = True
                ods_DropDownList_User.SelectParameters.Clear()

                ods_DropDownList_User.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                ods_DropDownList_User.SelectParameters.Add("RoleName", (CType(Session.Item("RoleName"), String)))
                DropDownList_User.DataSourceID = "ods_DropDownList_User"
                DropDownList_User.DataBind()

            Else
                m_bBind_DataTo_User_DropDown = False
                'ods_DropDownList_User.SelectParameters.Clear()
                'ods_DropDownList_User.SelectParameters.Add("ApplicationName", "whatever")
                'ods_DropDownList_User.SelectParameters.Add("RoleName", "whatever")
                'DropDownList_User.DataSourceID = "ods_DropDownList_User"
                'DropDownList_User.DataBind()

            End If





            m_bBind_DataToTheGrid = False

            ''=========================================I want the Role Drop-Down to show no records ========================


            'ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
            'ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", "whatever")
            'ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", "whatever")
            'GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"
            ''=========================================I want it to show no records ========================
            'm_bBind_DataToTheGrid = False


            'End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try


    End Sub

 
    '|||||| DropDown - User |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    'protected Sub DropDownList_User_DataBinding(sender As Object, e As System.EventArgs) Handles DropDownList_User.DataBinding



    'End Sub

    'protected Sub DropDownList_User_DataBound(sender As Object, e As System.EventArgs) Handles DropDownList_User.DataBound

    'End Sub

    Protected Sub DropDownList_User_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList_User.SelectedIndexChanged

        Try

            Session("UserName") = DropDownList_User.SelectedValue

            If (DropDownList_Application.SelectedValue <> "0") And (DropDownList_Role.SelectedValue <> "0") And (DropDownList_User.SelectedValue <> "0") Then

                txt_NewUserToAddToRoleApplication.Text = DropDownList_User.SelectedItem.ToString

            Else
                txt_NewUserToAddToRoleApplication.Text = ""
            End If

            'If (DropDownList_Application.SelectedValue <> "0") And (DropDownList_Role.SelectedValue <> "0") And (DropDownList_User.SelectedValue <> "0") Then

            '    m_bBind_DataToTheGrid = True
            '    ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
            '    ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
            '    ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", (CType(Session.Item("RoleName"), String)))
            '    GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"


            'Else
            '    m_bBind_DataToTheGrid = False
            '    ods_GridView_UsersInApplicationRole.SelectParameters.Clear()
            '    ods_GridView_UsersInApplicationRole.SelectParameters.Add("ApplicationName", "none")
            '    ods_GridView_UsersInApplicationRole.SelectParameters.Add("RoleName", "none")
            '    GridView_UsersInApplicationRole.DataSourceID = "ods_GridView_UsersInApplicationRole"

            'End If






        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try


    End Sub

    Private Sub ods_DropDownList_User_Selected(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ods_DropDownList_User.Selected





    End Sub



    '|||||| ODS for the: DropDown - User |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||


    Protected Sub ods_DropDownList_User_Selecting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ods_DropDownList_User.Selecting

        If m_bBind_DataTo_User_DropDown = False Then
            e.Cancel = True
        Else

        End If

    End Sub

    'protected Sub ods_DropDownList_User_Updating(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ods_DropDownList_User.Updating

    '    If m_bBind_DataTo_User_DropDown = True Then
    '        e.Cancel = True
    '    End If

    'End Sub

    'm_bBind_DataTo_User_DropDown
    '||||||GridView|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Protected Sub GridView_UsersInApplicationRole_DataBound(sender As Object, e As System.EventArgs) Handles GridView_UsersInApplicationRole.DataBound

    End Sub


    Protected Sub GridView_UsersInApplicationRole_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView_UsersInApplicationRole.RowCommand

        Dim index As Integer
        Dim sRoleName As String = (CType(Session.Item("RoleName"), String))
        Dim sApplicationName As String = (CType(Session.Item("ApplicationName"), String))
        Dim sUserName As String        '= (CType(Session.Item("UserName"), String))


        If e.CommandName = "DeleteUser_FromApplicationRole" Then
            ' Convert the row index stored in the CommandArgument
            ' property to an Integer.
            index = Convert.ToInt32(e.CommandArgument)

            Dim selectedRow As GridViewRow = GridView_UsersInApplicationRole.Rows(index)
            Dim cell_User As TableCell = selectedRow.Cells(1)
            sUserName = cell_User.Text

            Dim iResponse As Integer
            iResponse = ns_USER_APPLICATION_ROLE.c_USER_APPLICATION_ROLE_DL.DeleteUser_Given_ApplicationAndRole_Name(sUserName, sApplicationName, sRoleName)


            'If (DropDownList_Application.SelectedValue <> "0") And (DropDownList_Role.SelectedValue <> "0") Then

            '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            DropDownList_User.Items.Clear()
            DropDownList_User.Items.Add(New ListItem("---Select---", "0"))
            m_bBind_DataTo_User_DropDown = True
            ods_DropDownList_User.SelectParameters.Clear()

            ods_DropDownList_User.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
            ods_DropDownList_User.SelectParameters.Add("RoleName", (CType(Session.Item("RoleName"), String)))
            DropDownList_User.DataSourceID = "ods_DropDownList_User"
            DropDownList_User.DataBind()
            '|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
            'Else
            '    m_bBind_DataTo_User_DropDown = False
            '    'ods_DropDownList_User.SelectParameters.Clear()
            '    'ods_DropDownList_User.SelectParameters.Add("ApplicationName", "whatever")
            '    'ods_DropDownList_User.SelectParameters.Add("RoleName", "whatever")
            '    'DropDownList_User.DataSourceID = "ods_DropDownList_User"
            '    'DropDownList_User.DataBind()

            'End If


        End If




        ''These messages don't seem to work
        'If iResponse = 0 Then
        '    lbl_Message.Text = "Role: " & sRoleName & " was deleted"
        'Else
        '    lbl_Message.Text = "Role: " & sRoleName & " was not deleted, Error Code: " & iResponse.ToString
        'End If
        'DropDownList_User.DataBind()

        GridView_UsersInApplicationRole.DataBind()

    End Sub


    '||||||GridView - ODS |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Protected Sub ods_GridView_UsersInApplicationRole_Deleted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ods_GridView_UsersInApplicationRole.Deleted

        Dim retvalue = Convert.ToInt32(e.ReturnValue)

        'Select Case retvalue
        '    Case 2
        '        lbl_Message.Text = "The User was not Deleted b/c there are still Users associated with it. Remove the users from the Role first."
        '    Case Else

        'End Select

    End Sub

    Protected Sub ods_DropDownList_User_ObjectCreated(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceEventArgs) Handles ods_DropDownList_User.ObjectCreated
        'e.
    End Sub





    Protected Sub ods_DropDownList_User_ObjectCreating(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceEventArgs) Handles ods_DropDownList_User.ObjectCreating
        'e.
    End Sub


End Class