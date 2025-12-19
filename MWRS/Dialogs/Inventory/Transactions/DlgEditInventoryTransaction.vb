Public Class DlgEditInventoryTransaction
    Public Property TransactionId As Integer
    Private dtProducts As New DataTable()

    Private Sub DlgEditInventoryTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTransType()
        LoadProducts()
        LoadTransactionData()
    End Sub

    ' ---------------- LOAD PRODUCTS ----------------
    Private Sub LoadProducts()
        If ds.Tables.Contains("tblproducts") Then ds.Tables("tblproducts").Clear()

        GetQuery("SELECT productid, name FROM tblproducts WHERE status='Active' ORDER BY name", "tblproducts")
        dtProducts = ds.Tables("tblproducts").Copy()

        cmbproduct.DataSource = dtProducts
        cmbproduct.DisplayMember = "name"
        cmbproduct.ValueMember = "productid"
        cmbproduct.DropDownStyle = ComboBoxStyle.DropDownList
        cmbproduct.SelectedIndex = -1
    End Sub

    ' ---------------- LOAD TRANSACTION TYPES ----------------
    Private Sub LoadTransType()
        cmbtranstype.DropDownStyle = ComboBoxStyle.DropDownList
        cmbtranstype.Items.Clear()
        cmbtranstype.Items.Add("Stock In")
        cmbtranstype.Items.Add("Stock Out")
        cmbtranstype.SelectedIndex = -1
    End Sub

    ' ---------------- LOAD EXISTING TRANSACTION ----------------
    Private Sub LoadTransactionData()
        If TransactionId <= 0 Then Exit Sub

        If ds.Tables.Contains("tbltransaction") Then ds.Tables("tbltransaction").Clear()
        GetQuery("SELECT productid, transtype, qty, transdate, remarks FROM tblinventorytransactions WHERE transid = " & TransactionId, "tbltransaction")

        If ds.Tables("tbltransaction").Rows.Count = 0 Then
            MsgBox("Transaction not found.", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If

        Dim row As DataRow = ds.Tables("tbltransaction").Rows(0)
        Dim productId As Integer = CInt(row("productid"))
        Dim transtype As String = row("transtype").ToString()
        Dim qty As Integer = CInt(row("qty"))
        Dim transdate As Date = CDate(row("transdate"))
        Dim remarks As String = row("remarks").ToString()

        ' --- Ensure comboboxes are populated before setting values ---
        BeginInvoke(Sub()
                        ' Product
                        If cmbproduct.DataSource IsNot Nothing AndAlso dtProducts.Rows.Count > 0 Then
                            cmbproduct.SelectedValue = productId
                        End If

                        ' Transaction type
                        cmbtranstype.SelectedItem = transtype

                        ' Quantity (safe range)
                        If qty < nudqty.Minimum Then
                            nudqty.Value = nudqty.Minimum
                        ElseIf qty > nudqty.Maximum Then
                            nudqty.Value = nudqty.Maximum
                        Else
                            nudqty.Value = qty
                        End If

                        dtptransdate.Value = transdate
                        txtremarks.Text = remarks
                    End Sub)
    End Sub

    ' ---------------- UPDATE TRANSACTION ----------------
    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If cmbproduct.SelectedIndex = -1 OrElse cmbtranstype.SelectedIndex = -1 Then
            MsgBox("Please fill all required fields.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If nudqty.Value <= 0 Then
            MsgBox("Quantity must be greater than zero.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' --- Get previous transaction details ---
        Dim prevSql As String = "SELECT productid, transtype, qty FROM tblinventorytransactions WHERE transid = " & TransactionId
        If ds.Tables.Contains("tblprevtrans") Then ds.Tables("tblprevtrans").Clear()
        GetQuery("SELECT productid, transtype, qty FROM tblinventorytransactions WHERE transid = " & TransactionId, "tblprevtrans")

        If ds.Tables("tblprevtrans").Rows.Count = 0 Then
            MsgBox("Previous transaction not found.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim oldProductId As Integer = CInt(ds.Tables("tblprevtrans").Rows(0)("productid"))
        Dim oldType As String = ds.Tables("tblprevtrans").Rows(0)("transtype").ToString()
        Dim oldQty As Integer = CInt(ds.Tables("tblprevtrans").Rows(0)("qty"))


        Dim newProductId As Integer = CInt(cmbproduct.SelectedValue)
        Dim newType As String = cmbtranstype.Text
        Dim newQty As Integer = CInt(nudqty.Value)

        ' --- Restore old stock effect ---
        Dim sqlUpdate As String = ""
        If oldType = "Stock In" Then
            sqlUpdate = "UPDATE tblproducts SET stockqty = stockqty - " & oldQty & " WHERE productid = " & oldProductId
        ElseIf oldType = "Stock Out" Then
            sqlUpdate = "UPDATE tblproducts SET stockqty = stockqty + " & oldQty & " WHERE productid = " & oldProductId
        End If
        SetQuery(sqlUpdate)

        ' --- Apply new stock effect ---
        If newType = "Stock In" Then
            sqlUpdate = "UPDATE tblproducts SET stockqty = stockqty + " & newQty & " WHERE productid = " & newProductId
        ElseIf newType = "Stock Out" Then
            ' Optional: Check if enough stock exists
            If ds.Tables.Contains("tblstockcheck") Then ds.Tables("tblstockcheck").Clear()
            GetQuery("SELECT stockqty FROM tblproducts WHERE productid = " & newProductId, "tblstockcheck")

            Dim currentStock As Integer = 0
            If ds.Tables("tblstockcheck").Rows.Count > 0 Then
                currentStock = CInt(ds.Tables("tblstockcheck").Rows(0)("stockqty"))
            End If

            sqlUpdate = "UPDATE tblproducts SET stockqty = stockqty - " & newQty & " WHERE productid = " & newProductId
        End If
        SetQuery(sqlUpdate)

        ' --- Update transaction record ---
        Dim sql As String =
            "UPDATE tblinventorytransactions SET " &
            "productid = " & newProductId & ", " &
            "transtype = '" & newType & "', " &
            "qty = " & newQty & ", " &
            "transdate = '" & Format(dtptransdate.Value, "yyyy-MM-dd HH:mm:ss") & "', " &
            "remarks = '" & txtremarks.Text.Replace("'", "''") & "' " &
            "WHERE transid = " & TransactionId
        SetQuery(sql)
        LogActivity("Inventory", "Updated Transaction", TransactionId)

        MsgBox("Transaction updated successfully.", MsgBoxStyle.Information)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


    ' ---------------- CANCEL ----------------
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If MsgBox("Cancel editing this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

End Class
