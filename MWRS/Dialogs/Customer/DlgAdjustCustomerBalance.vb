Public Class DlgAdjustCustomerBalance
    Public Property SelectedCustID As Integer  ' passed from parent form
    Private currentBalance As Decimal

    Private Sub DlgAdjustCustomerBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadCustomerInfo()
        Catch ex As Exception
            MsgBox("Error loading customer info: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Me.Close()
        End Try
    End Sub

    Private Sub LoadCustomerInfo()
        Try
            ' Fetch customer name and balance
            Dim sql As String =
    "SELECT c.fullname, b.balance " &
    "FROM tblcustomers c " &
    "LEFT JOIN tblcustomerbalance b ON c.custid = b.custid " &
    "WHERE c.custid = " & SelectedCustID



            ds.Tables.Clear()
            GetQuery(sql, "customerinfo")

            If ds.Tables("customerinfo").Rows.Count = 0 Then
                MsgBox("Customer record not found.", MsgBoxStyle.Critical, "Error")
                Me.Close()
                Exit Sub
            End If

            Dim row As DataRow = ds.Tables("customerinfo").Rows(0)
            lblcust.Text = row("fullname").ToString()

            currentBalance = CDec(row("balance"))
            txtcustbalance.Text = Format(currentBalance, "0.00")

        Catch ex As Exception
            MsgBox("Error fetching customer info: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Me.Close()
        End Try
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Dim newBalance As Decimal

            If Not Decimal.TryParse(txtcustbalance.Text, newBalance) Then
                MsgBox("Please enter a valid balance amount.", MsgBoxStyle.Exclamation)
                txtcustbalance.Focus()
                Exit Sub
            End If

            ' Optional: add confirmation
            If MsgBox("Update customer balance?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            ' Update balance
            Dim sql As String =
                "UPDATE tblcustomerbalance SET balance = " & newBalance & ", lastupdate = NOW() " &
                "WHERE custid = " & SelectedCustID

            SetQuery(sql)
            LogActivity("Customer", "Adjusted balance to: " & newBalance, SelectedCustID)
            MsgBox("Customer balance updated successfully.", MsgBoxStyle.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error updating customer balance: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            MsgBox("Error closing the dialog: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
