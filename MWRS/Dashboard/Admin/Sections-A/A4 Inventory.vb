Public Class A4_Inventory

    Private Sub A_Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fill()
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        If DlgAddProduct.ShowDialog() = DialogResult.OK Then
            Fill()

        End If
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        EditSelectedProduct()
    End Sub

    Private Sub lvproducts_DoubleClick(sender As Object, e As EventArgs) Handles lvproducts.DoubleClick
        EditSelectedProduct()
    End Sub

    Private Sub btncategories_Click(sender As Object, e As EventArgs) Handles btncategories.Click
        If DlgCategories.ShowDialog() = DialogResult.OK Then
            fill()
        End If
    End Sub

    Public Sub Fill(Optional ByVal keyword As String = "")
        lvproducts.Items.Clear()

        Dim sql As String =
            "SELECT p.productid, p.name AS productname, c.name AS category, " &
            "p.unitprice, u.unittype, p.stockqty, p.reorderlevel, p.status " &
            "FROM tblproducts p " &
            "LEFT JOIN tblproductcategories c ON p.categoryid = c.categoryid " &
            "LEFT JOIN tblproductunit u ON p.unitid = u.unitid"

        If keyword <> "" Then
            sql &= " WHERE p.name LIKE '%" & keyword & "%' " &
                   "OR c.name LIKE '%" & keyword & "%' " &
                   "OR u.unittype LIKE '%" & keyword & "%' " &
                   "OR p.status LIKE '%" & keyword & "%'"
        End If

        sql &= " ORDER BY p.name"

        ds.Tables.Clear()
        GetQuery(sql, "tblproducts")

        If ds.Tables("tblproducts").Rows.Count = 0 Then Exit Sub

        For Each row As DataRow In ds.Tables("tblproducts").Rows
            Dim item As New ListViewItem(row("productid").ToString())
            item.SubItems.Add(row("productname").ToString())
            item.SubItems.Add(row("category").ToString())
            item.SubItems.Add(Format(CDec(row("unitprice")), "0.00"))
            item.SubItems.Add(row("unittype").ToString())
            item.SubItems.Add(row("stockqty").ToString())
            item.SubItems.Add(row("reorderlevel").ToString())
            item.SubItems.Add(row("status").ToString())

            Dim stockQty As Integer = CInt(row("stockqty"))
            Dim reorderLevel As Integer = CInt(row("reorderlevel"))

            Select Case True
                Case stockQty = 0
                    item.ForeColor = Color.Red
                Case stockQty <= reorderLevel
                    item.ForeColor = Color.DarkOrange   ' Low or critical stock
            End Select

            lvproducts.Items.Add(item)
        Next
    End Sub


    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Fill(txtsearch.Text)
    End Sub

    Private Sub EditSelectedProduct()
        If lvproducts.SelectedItems.Count = 0 Then
            MsgBox("Please select a product to edit.", MsgBoxStyle.Exclamation, "No Selection")
            Exit Sub
        End If

        Dim selectedItem As ListViewItem = lvproducts.SelectedItems(0)
        Dim productId As Integer = CInt(selectedItem.SubItems(0).Text)

        ' Open dialog and pass Product ID
        With DlgEditProduct
            .SelectedProductID = productId
            If .ShowDialog() = DialogResult.OK Then
                Fill()
            End If
        End With
    End Sub

    Private Sub btntransaction_Click(sender As Object, e As EventArgs) Handles btntransaction.Click
        Dim dlg As New DlgInventoryTransaction
        If dlg.ShowDialog = DialogResult.OK Then
            Fill()
        End If
    End Sub

    Private Sub btnunits_Click(sender As Object, e As EventArgs) Handles btnunits.Click
        If DlgUnits.ShowDialog() = DialogResult.OK Then
            Fill()
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If lvproducts.SelectedItems.Count = 0 Then
            MsgBox("Please select a product to delete.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim selectedItem As ListViewItem = lvproducts.SelectedItems(0)
        Dim productId As Integer = CInt(selectedItem.SubItems(0).Text)

        ' --- Check if product is used elsewhere ---
        Dim checkSql As String =
            "SELECT COUNT(*) AS refcount FROM (" &
            " SELECT productid FROM tblinventorytransactions WHERE productid = " & productId &
            " UNION ALL " &
            " SELECT productid FROM tblorderitems WHERE productid = " & productId &
            " ) AS refs"

        GetQuery(checkSql, "refCheck")
        Dim refCount As Integer = 0
        If ds.Tables("refCheck").Rows.Count > 0 Then
            refCount = CInt(ds.Tables("refCheck").Rows(0)("refcount"))
        End If

        ' --- No references → safe to delete ---
        If refCount = 0 Then
            If MsgBox("Are you sure you want to permanently delete this product?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Dim deleteSql As String = "DELETE FROM tblproducts WHERE productid = " & productId
                SetQuery(deleteSql)
                LogActivity("Products", "Delete product", productId)
                MsgBox("Product deleted successfully.", MsgBoxStyle.Information)
                Fill()
            End If
            Exit Sub
        End If

        ' --- Has references → cannot delete ---
        Dim result As MsgBoxResult = MsgBox(
            "This product has existing transactions or orders. It cannot be deleted." & vbCrLf &
            "Would you like to set its status to Inactive instead?",
            MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Cannot Delete")

        If result = MsgBoxResult.Yes Then
            Dim updateSql As String = "UPDATE tblproducts SET status = 'Inactive' WHERE productid = " & productId
            SetQuery(updateSql)
            LogActivity("Products", "Set Inactive", productId)
            MsgBox("Product status set to Inactive.", MsgBoxStyle.Information)
            Fill()
        End If
    End Sub


    Private Sub btnservices_Click(sender As Object, e As EventArgs) Handles btnservices.Click
        DlgServices.Show()
    End Sub
End Class
