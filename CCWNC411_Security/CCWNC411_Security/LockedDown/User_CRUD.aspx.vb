Public Class User_CRUD
    Inherits System.Web.UI.Page

    Private m_bApplicationNameIsEmpty As Boolean = True
    Private m_bBind_DataToTheGrid As Boolean = False
    Private m_bBind_DataToTheDetailsView As Boolean = False

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

    Protected Sub btn_ListUsersForSelectedApplication_Click(sender As Object, e As EventArgs) Handles btn_ListUsersForSelectedApplication.Click



        Try
            If DropDownList_Application.SelectedValue <> "0" Then

                lbl_Message.ForeColor = Drawing.Color.White


                m_bBind_DataToTheGrid = True    'This lets the GridView know that it is alright to load the data
                m_bBind_DataToTheDetailsView = False   'This lets the DetailsView know that it is not yet alright to load the data

                'Populate the GridView
                ods_GridView_Users.SelectParameters.Clear()
                ods_GridView_Users.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))
                GridView_UsersInApplication.DataSourceID = "ods_GridView_Users"
                GridView_UsersInApplication.DataBind()



            Else

                lbl_Message.ForeColor = Drawing.Color.Black
                lbl_Message.Text = "You need to select an Application first"
            End If
        Catch ex As Exception
            lbl_Message.ForeColor = Drawing.Color.Black
            lbl_Message.Text = ex.Message
        End Try
    End Sub

    '||||||DropDown|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Public Sub DropDownList_Application_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownList_Application.SelectedIndexChanged

        If Session("ApplicationName") Is Nothing Then

            Session("ApplicationName") = DropDownList_Application.SelectedValue

        Else

            Session("ApplicationName") = DropDownList_Application.SelectedValue

            '=========================================I want it to show no records ========================
            ods_GridView_Users.SelectParameters.Clear()
            ods_GridView_Users.SelectParameters.Add("ApplicationName", "whatever")
            GridView_UsersInApplication.DataSourceID = "ods_GridView_Users"
            '=========================================I want it to show no records ========================
            ods_ViewDetails_User.SelectParameters.Clear()
            ods_ViewDetails_User.SelectParameters.Add("ApplicationName", "whatever")
            ods_ViewDetails_User.SelectParameters.Add("UserName", "whatever")
            DetailsView_User.DataSourceID = "ods_ViewDetails_User"
            DetailsView_User.DataBind()
            '==============================================================================================
            m_bBind_DataToTheDetailsView = False
            m_bBind_DataToTheGrid = False


        End If




    End Sub

    '||||||DetailsView_User|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
    Protected Sub DetailsView_User_ItemDeleted(sender As Object, e As System.Web.UI.WebControls.DetailsViewDeletedEventArgs) 'Handles DetailsView_User.ItemDeleted
        'Not sure if this is needed
    End Sub

    Protected Sub DetailsView_User_ItemInserted(sender As Object, e As System.Web.UI.WebControls.DetailsViewInsertedEventArgs) 'Handles DetailsView_User.ItemInserted
        'Not sure if this is needed
    End Sub

    Protected Sub DetailsView_User_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) 'Handles DetailsView_User.ItemUpdated
        'Does the Update for the Details View
    End Sub


    Private Sub DetailsView_User_ItemCommand(sender As Object, e As System.Web.UI.WebControls.DetailsViewCommandEventArgs) Handles DetailsView_User.ItemCommand

        'You can only get to this sub if you click on a DetailsView command, which means that the Data is already bound to the Grid
        '   and therefore it is alright for the Details view to go ahead and SELECT. This variable is used to communicate that

        m_bBind_DataToTheDetailsView = True


    End Sub

    '||||||||GridView_UsersInApplication|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Private Sub GridView_UsersInApplication_SelectedIndexChanged1(sender As Object, e As System.EventArgs) Handles GridView_UsersInApplication.SelectedIndexChanged
        'You can only get to this sub if you click clicked on the 'Details' hyperlink in the GridView, which means that the Data is already bound to the Grid
        '   and therefore it is alright for the Details view to go ahead and SELECT. This variable is used to communicate that
        m_bBind_DataToTheDetailsView = True
    End Sub

    Protected Sub ods_GridView_Users_Selecting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) 'Handles ods_GridView_Users.Selecting


        If CType(Session.Item("ApplicationName"), String) Is Nothing Then
            e.Cancel = True
        End If

    End Sub

    Protected Sub GridView_UsersInApplication_SelectedIndexChanged(sender As Object, e As System.EventArgs) 'Handles GridView_UsersInApplication.SelectedIndexChanged

        'Whenever the user selects a row in the GridView, it reloads the PARMS for the DetailsView
        Dim sX As String
        sX = GridView_UsersInApplication.SelectedDataKey.Value.ToString()
        ods_ViewDetails_User.SelectParameters.Clear()
        ods_ViewDetails_User.SelectParameters.Add("UserName", sX)
        ods_ViewDetails_User.SelectParameters.Add("ApplicationName", (CType(Session.Item("ApplicationName"), String)))

        'When the GridView binds, it sets off the DetailsView select method which uses the parameters that were just added
        GridView_UsersInApplication.DataBind()

    End Sub

    Private Sub GridView_UsersInApplication_DataBound(sender As Object, e As System.EventArgs) Handles GridView_UsersInApplication.DataBound
        'This will be used to let the ODS for the Details view know that that it is ok to SELECT data
        If m_bBind_DataToTheGrid Then
            m_bBind_DataToTheDetailsView = True
        End If

    End Sub
    '||||||||ods_ViewDetails_User|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    Protected Sub ods_ViewDetails_User_Selecting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) 'Handles ods_ViewDetails_User.Selecting

        'If there is no application name set, then don't bother SELECTing data for the DetailsView

        If (CType(Session.Item("ApplicationName"), String) Is Nothing) Or (m_bBind_DataToTheDetailsView = False) Then
            e.Cancel = True
        End If

    End Sub


    Protected Sub ods_ViewDetails_User_Inserted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) 'Handles ods_ViewDetails_User.Inserted
        'Required if the ODS refers to this sub


    End Sub

    Protected Sub ods_ViewDetails_User_Updated(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) 'Handles ods_ViewDetails_User.Updated
        'Required if the ODS refers to this sub

    End Sub

    Protected Sub ods_ViewDetails_User_Deleted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) 'Handles ods_ViewDetails_User.Deleted
        'Required if the ODS refers to this sub
        m_bBind_DataToTheDetailsView = False
        GridView_UsersInApplication.DataBind()

    End Sub

    '||||||functions|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||



End Class