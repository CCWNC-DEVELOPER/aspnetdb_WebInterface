Public Class User_InsertNewUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub




    Private Sub ods_dv_User_Inserted(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ods_dv_User.Inserted
        If e.Exception Is Nothing Then
            'lblConfirmation.Text = "Value Returned " + e.ReturnValue.ToString() + " ( 0 if no errors, or the error code from SP: [aspnet_Membership_CreateUser]"
            Response.Redirect("~/LockedDown/Users_Main.aspx")
        Else
            lblConfirmation.Text = "Error - Did you supply all the required values?"
            e.ExceptionHandled = True
        End If
    End Sub

    Protected Sub ods_dv_User_Inserting(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) 'Handles ods_dv_User.Inserting
        Try

            If DirectCast(dv_User.FindControl("ddl_ApplicationName"), DropDownList).SelectedValue <> "" Then

                'If ddl_ApplicationName.SelectedValue <> "0" Then

            Else
                e.Cancel = True
                lblConfirmation.ForeColor = Drawing.Color.Black
                lblConfirmation.Text = "You need to select an Application first"
            End If
        Catch ex As Exception
            lblConfirmation.ForeColor = Drawing.Color.Black
            lblConfirmation.Text = ex.Message
        End Try
    End Sub
End Class