Public Class Applications_subChild_UpdateRecord
    Inherits System.Web.UI.Page

    Protected Sub DetailsView_ItemUpdate(sender As Object, e As DetailsViewUpdatedEventArgs)

        If e.AffectedRows = 1 Then          'if the number of affected rows = 1 {this is a success}
            Response.Redirect("~/LockedDown/Applications_Child.aspx")
        End If

    End Sub


    Protected Sub DetailsView_ItemCommand(sender As Object, e As DetailsViewCommandEventArgs)
        'This event fires when either 'Insert' or 'Cancel' is clicked in the DetailsView control on the Insert Record page
        '   so this covers the 'cancel' event

        If e.CommandName = "Cancel" Then          'if user chooses  'cancel'
            Response.Redirect("~/LockedDown/Applications_Child.aspx")
        End If

    End Sub

    'Private Sub DetailsView1_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated

    'End Sub

    'Private Sub DetailsView1_ItemUpdating(sender As Object, e As System.Web.UI.WebControls.DetailsViewUpdateEventArgs) Handles DetailsView1.ItemUpdating

    'End Sub
End Class