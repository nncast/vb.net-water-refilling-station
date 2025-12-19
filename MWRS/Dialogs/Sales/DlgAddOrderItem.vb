Public Class DlgAddOrderItem
    Public Property CurrentCartQty As Integer = 0
    ' Properties to receive data
    Public Property ProductID As Integer
    Public Property PName As String              ' renamed from ProductName
    Public Property UnitPrice As Decimal
    Public Property StockQty As Integer
    Public Property Unit As String
    Public Property Category As String

    Private Sub DlgAddOrderItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProductName.Text = PName

        ' StockQty is already the "true available stock" passed from the parent
        nudqty.Maximum = StockQty

        ' Prefill quantity
        nudqty.Value = If(CurrentCartQty > 0, CurrentCartQty, 1)

        lblAvailableStock.Text = "Available: " & StockQty
        lblPrice.Text = UnitPrice.ToString("F2")
        lblTotal.Text = (UnitPrice * nudqty.Value).ToString("F2")
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
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
