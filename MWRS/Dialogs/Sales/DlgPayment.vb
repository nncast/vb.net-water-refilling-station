Public Class DlgPayment
    Public Property OrderID As Integer
    Public Property CustomerName As String
    Public Property OrderDate As Date
    Public Property TotalAmount As Decimal
    Public Property PaidAmount As Decimal
    Public Property Balance As Decimal

    Public Property CustomerID As Integer
    Public Property CurrentUserID As Integer ' Logged-in user ID

    ' What is still unpaid on this order. Payments are checked against this, not
    ' against the customer's overall balance (which also covers other orders).
    Private remaining As Decimal

    Private Sub DlgPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate labels
        lblorderid.Text = OrderID.ToString()
        lblcustomername.Text = CustomerName
        lblDate.Text = OrderDate.ToString("yyyy-MM-dd")
        lbltotal.Text = TotalAmount.ToString("F2")
        lblpaid.Text = PaidAmount.ToString("F2")
        lblbalance.Text = Balance.ToString("F2")

        ' Default payment amount = what is left to pay on this order
        remaining = Math.Max(0, OrderRemaining(OrderID))
        txtpaymentamount.Text = remaining.ToString("F2")
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim paymentAmount As Decimal

        ' --- 1. Validate user input ---
        If Not Decimal.TryParse(txtpaymentamount.Text, paymentAmount) Then
            MsgBox("Please enter a valid numeric payment amount.", MsgBoxStyle.Exclamation, "Invalid Input")
            txtpaymentamount.Focus()
            Exit Sub
        End If

        If paymentAmount <= 0 Then
            MsgBox("Payment amount must be greater than zero.", MsgBoxStyle.Exclamation, "Invalid Payment")
            txtpaymentamount.Focus()
            Exit Sub
        End If

        If paymentAmount > remaining Then
            MsgBox("Payment amount cannot exceed the remaining balance of this order (" & remaining.ToString("F2") & ").", MsgBoxStyle.Exclamation, "Invalid Payment")
            txtpaymentamount.Text = remaining.ToString("F2")
            txtpaymentamount.Focus()
            Exit Sub
        End If

        Try
            ' Payment, customer transaction, customer balance, the sale's payment
            ' status and the activity log are saved together.
            AddPayment(OrderID, paymentAmount)

            MsgBox("Payment of ₱" & paymentAmount.ToString("F2") & " recorded successfully.", MsgBoxStyle.Information, "Payment Success")

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error while saving payment: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        End Try
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    ' --- Prevent user from entering more than this order still owes ---
    Private Sub txtpaymentamount_TextChanged(sender As Object, e As EventArgs) Handles txtpaymentamount.TextChanged
        Dim value As Decimal
        If Decimal.TryParse(txtpaymentamount.Text, value) Then
            If value > remaining Then
                txtpaymentamount.Text = remaining.ToString("F2")
                txtpaymentamount.SelectionStart = txtpaymentamount.Text.Length
            End If
        End If
    End Sub

End Class
