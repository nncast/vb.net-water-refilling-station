Public Class DlgPayment
    Public Property OrderID As Integer
    Public Property CustomerName As String
    Public Property OrderDate As Date
    Public Property TotalAmount As Decimal
    Public Property PaidAmount As Decimal
    Public Property Balance As Decimal

    Public Property CustomerID As Integer
    Public Property CurrentUserID As Integer ' Logged-in user ID

    Private Sub DlgPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate labels
        lblorderid.Text = OrderID.ToString()
        lblcustomername.Text = CustomerName
        lblDate.Text = OrderDate.ToString("yyyy-MM-dd")
        lbltotal.Text = TotalAmount.ToString("F2")
        lblpaid.Text = PaidAmount.ToString("F2")
        lblbalance.Text = Balance.ToString("F2")

        ' Default payment amount = remaining balance
        txtpaymentamount.Text = (TotalAmount - PaidAmount).ToString("F2")
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

        If paymentAmount > Balance Then
            MsgBox("Payment amount cannot exceed the remaining balance.", MsgBoxStyle.Exclamation, "Invalid Payment")
            txtpaymentamount.Text = Balance.ToString("F2")
            txtpaymentamount.Focus()
            Exit Sub
        End If


        ' --- 2. Get the related SALE ID for this order ---
        Dim saleid As Integer = 0
        GetQuery("SELECT saleid FROM tblsales WHERE orderid = " & OrderID, "saleLookup")

        If ds.Tables("saleLookup").Rows.Count > 0 Then
            saleid = CInt(ds.Tables("saleLookup").Rows(0)("saleid"))
        Else
            MsgBox("No sales record found for this order. Cannot proceed with payment.", MsgBoxStyle.Exclamation, "Missing Sale")
            Exit Sub
        End If


        Try
            ' --- 3. Insert payment record ---
            Dim paymentQuery As String =
                "INSERT INTO tblpayments (saleid, amountpaid, paymentdate) " &
                "VALUES (" & saleid & ", " & paymentAmount & ", NOW())"
            SetQuery(paymentQuery)
            Dim paymentID As Integer = GetLastInsertedID()

            ' --- 4. Record in customer transaction log ---
            Dim txnQuery As String =
                "INSERT INTO tblcustomertransactions (custid, saleid, amount, type, date) " &
                "VALUES (" & Me.CustomerID & ", " & saleid & ", " & paymentAmount & ", 'Payment', NOW())"
            SetQuery(txnQuery)

            ' --- 5. Update customer balance ---
            Dim balanceQuery As String =
                "UPDATE tblcustomerbalance SET balance = balance - " & paymentAmount & ", lastupdate = NOW() WHERE custid = " & Me.CustomerID
            SetQuery(balanceQuery)

            ' --- 6. Update sales payment status ---
            Dim newBalance As Decimal = Balance - paymentAmount
            Dim status As String = If(newBalance <= 0, "Full", "Partial")

            Dim saleQuery As String =
                "UPDATE tblsales SET paymentstatus = '" & status & "' WHERE saleid = " & saleid
            SetQuery(saleQuery)

            ' --- 7. Log user activity ---
            Dim logQuery As String =
                "INSERT INTO tblactivitylogs (userid, module, action, recordid) " &
                "VALUES (" & Globals.UserID & ", 'Sales', 'Payment of " & paymentAmount.ToString("F2") & " added', " & saleid & ")"
            SetQuery(logQuery)

            ' --- 8. Confirmation ---
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


    ' --- Optional: Prevent user from entering more than balance ---
    Private Sub txtpaymentamount_TextChanged(sender As Object, e As EventArgs) Handles txtpaymentamount.TextChanged
        Dim value As Decimal
        If Decimal.TryParse(txtpaymentamount.Text, value) Then
            If value > Balance Then
                txtpaymentamount.Text = Balance.ToString("F2")
                txtpaymentamount.SelectionStart = txtpaymentamount.Text.Length
            End If
        End If
    End Sub

End Class
