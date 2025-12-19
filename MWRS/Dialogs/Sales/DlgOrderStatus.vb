
Public Class DlgOrderStatus

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
