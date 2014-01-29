Public Class Applications_subChild
    Inherits System.Web.UI.Page


    Protected Sub DetailsView_ItemInsert(sender As Object, e As DetailsViewInsertedEventArgs)

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

End Class