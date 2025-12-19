Imports System.Windows.Forms

Public Class DlgAddServiceItem
    ' === Properties passed from parent form ===
    Public Property ServiceID As Integer
    Public Property SName As String
    Public Property UnitPrice As Decimal
    Public Property CurrentQty As Integer = 0     ' if already in cart

    Private Sub DlgAddServiceItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblServiceName.Text = SName
        lblPrice.Text = UnitPrice.ToString("F2")

        ' Set numeric up-down default
        nudqty.Minimum = 1
        nudqty.Maximum = 99     ' arbitrary upper limit; services don't track stock
        nudqty.Value = If(CurrentQty > 0, CurrentQty, 1)
        lblTotal.Text = (UnitPrice * nudqty.Value).ToString("F2")
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        ' Validation
        If nudqty.Value <= 0 Then
            MessageBox.Show("Quantity must be at least 1.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub nudqty_ValueChanged(sender As Object, e As EventArgs) Handles nudqty.ValueChanged
        lblTotal.Text = (UnitPrice * nudqty.Value).ToString("F2")
    End Sub
End Class
