Public Class E2_Sales
    Public IsUpdateMode As Boolean = False
    Public CurrentOrderID As Integer = 0

    ' DataTables to hold database data
    Private dtProducts As New DataTable()
    Private dtCustomers As New DataTable()
    Private dtServices As New DataTable()

    ' Form Load
    Private Sub A_Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill dropdowns and listviews
        LoadCustomers()
        LoadProducts()
        LoadServices()
        LoadOrderTypes()
        LoadNextOrderID()
        SetSalesFormState("new")

    End Sub

    ' Load all customers into cmbcustomer
    Public Sub LoadCustomers()

        GetQuery("SELECT custid, fullname FROM tblcustomers ORDER BY fullname ASC", "customers")

        dtCustomers = ds.Tables("customers").Copy()

        cmbcustomer.DataSource = dtCustomers
        cmbcustomer.DisplayMember = "fullname"
        cmbcustomer.ValueMember = "custid"
        cmbcustomer.SelectedIndex = -1

    End Sub


    ' Load all products into lvproducts
    Public Sub LoadProducts()
        ' Join products with category and unit tables to get names
        Dim query As String = "SELECT p.productid, p.name AS productname, " & _
                              "c.name AS category, u.unittype AS unit, " & _
                              "p.unitprice, p.stockqty, p.reorderlevel " & _
                              "FROM tblproducts p " & _
                              "LEFT JOIN tblproductcategories c ON p.categoryid = c.categoryid " & _
                              "LEFT JOIN tblproductunit u ON p.unitid = u.unitid " & _
                              "WHERE p.status='Active'"

        GetQuery(query, "products")
        dtProducts = ds.Tables("products").Copy()

        lvproducts.Items.Clear()
        For Each row As DataRow In dtProducts.Rows
            Dim item As ListViewItem = lvproducts.Items.Add(row("productid").ToString())       ' ID
            item.SubItems.Add(row("productname").ToString())                                  ' Product Name
            item.SubItems.Add(If(IsDBNull(row("category")), "", row("category").ToString()))  ' Category
            item.SubItems.Add(CDec(row("unitprice")).ToString("F2"))                          ' Price
            item.SubItems.Add(If(IsDBNull(row("unit")), "", row("unit").ToString()))          ' Unit
            item.SubItems.Add(row("stockqty").ToString())                                     ' Stock

            ' Extract stock and reorder level
            Dim stockqty As Integer = Convert.ToInt32(row("stockqty"))
            Dim reorderLevel As Integer = Convert.ToInt32(row("reorderlevel"))

            ' Apply color based on stock level
            Select Case True
                Case stockqty = 0
                    item.ForeColor = Color.Red
                Case stockqty <= reorderLevel
                    item.ForeColor = Color.DarkOrange
                Case Else
                    item.ForeColor = Color.Black
            End Select
        Next
    End Sub


    ' Load all services into lvservices
    Public Sub LoadServices()
        Dim query As String = "SELECT serviceid, name AS servicename, price, status " &
                              "FROM tblservices " &
                              "WHERE status = 'Active'"

        GetQuery(query, "services")
        dtServices = ds.Tables("services").Copy()

        lvservices.Items.Clear()
        For Each row As DataRow In dtServices.Rows
            Dim item As ListViewItem = lvservices.Items.Add(row("serviceid").ToString())   ' ID
            item.SubItems.Add(row("servicename").ToString())                               ' Service Name
            item.SubItems.Add(CDec(row("price")).ToString("F2"))                           ' Price
            item.SubItems.Add(row("status").ToString())                                    ' Status
        Next
    End Sub

    Public Sub LoadOrderTypes()
        cmbordertype.Items.Clear()
        cmbordertype.Items.Add("Delivery")
        cmbordertype.Items.Add("Pickup")
        cmbordertype.SelectedIndex = -1
    End Sub

    Private Function GetAvailableStock(productId As Integer, Optional excludeRow As ListViewItem = Nothing) As Integer
        ' Get total stock from DB
        GetQuery("SELECT stockqty FROM tblproducts WHERE productid = " & productId, "productstock")
        Dim totalStock As Integer = 0
        If ds.Tables("productstock").Rows.Count > 0 Then
            totalStock = CInt(ds.Tables("productstock").Rows(0)("stockqty"))
        End If

        ' Subtract qty already in cart (excluding current row if editing)
        Dim qtyInCart As Integer = 0
        For Each item As ListViewItem In lvorderitems.Items
            If item.SubItems(7).Text = "Product" AndAlso CInt(item.SubItems(6).Text) = productId Then
                If excludeRow IsNot Nothing AndAlso item Is excludeRow Then Continue For
                qtyInCart += CInt(item.SubItems(2).Text)
            End If
        Next

        Return totalStock - qtyInCart
    End Function


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            ' --- Validation ---
            If cmbcustomer.SelectedIndex = -1 Then
                MsgBox("Please select a customer.", MsgBoxStyle.Information, "Validation Error")
                Exit Sub
            End If

            If cmbordertype.SelectedIndex = -1 Then
                MsgBox("Please select an order type (Delivery or Pickup).", MsgBoxStyle.Information, "Validation Error")
                Exit Sub
            End If

            If lvorderitems.Items.Count = 0 Then
                MsgBox("No items in the order.", MsgBoxStyle.Information, "Validation Error")
                Exit Sub
            End If

            If MsgBox("Do you want to save this order?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If

            ' --- Extract order info ---
            Dim custid As Integer = CInt(cmbcustomer.SelectedValue)
            Dim ordertype As String = cmbordertype.Text
            Dim userid As Integer = 1 ' Replace with actual logged-in user ID
            Dim orderTotal As Decimal = CDec(lbltotalprice.Text)
            Dim paymentStatus As String = "Unpaid"

            ' --- Insert Order Header ---
            Dim sqlOrder As String =
                "INSERT INTO tblorders (custid, userid, ordertype, status) " &
                "VALUES (" & custid & ", " & userid & ", '" & ordertype & "', 'Pending')"
            SetQuery(sqlOrder)

            ' --- Get new OrderID ---
            GetQuery("SELECT LAST_INSERT_ID() AS neworderid", "newid")
            Dim newOrderID As Integer = CInt(ds.Tables("newid").Rows(0)("neworderid"))

            ' --- Insert Order Items ---
            For Each item As ListViewItem In lvorderitems.Items
                Dim itemType As String = item.SubItems(7).Text
                Dim qty As Integer = CInt(item.SubItems(2).Text)
                Dim price As Decimal = CDec(item.SubItems(3).Text)
                Dim sqlItem As String = ""

                If itemType = "Product" Then
                    Dim productid As Integer = CInt(item.SubItems(6).Text)
                    sqlItem = "INSERT INTO tblorderitems (orderid, productid, qty, price, itemtype) " &
                              "VALUES (" & newOrderID & ", " & productid & ", " & qty & ", " & price & ", 'Product')"
                    SetQuery(sqlItem)

                    ' Deduct stock
                    SetQuery("UPDATE tblproducts SET stockqty = stockqty - " & qty & " WHERE productid = " & productid)

                    ' Log inventory transaction
                    SetQuery("INSERT INTO tblinventorytransactions (productid, userid, transtype, qty, remarks) " &
                             "VALUES (" & productid & ", " & userid & ", 'Stock Out', " & qty & ", 'Order #" & newOrderID & "')")
                ElseIf itemType = "Service" Then
                    Dim serviceid As Integer = CInt(item.SubItems(6).Text)
                    sqlItem = "INSERT INTO tblorderitems (orderid, serviceid, qty, price, itemtype) " &
                              "VALUES (" & newOrderID & ", " & serviceid & ", " & qty & ", " & price & ", 'Service')"
                    SetQuery(sqlItem)
                    ' No stock deduction for services
                End If
            Next

            ' --- Insert into tblsales and get SaleID ---
            Dim sqlSale As String =
                "INSERT INTO tblsales (orderid, custid, userid, totalamount, paymentstatus) " &
                "VALUES (" & newOrderID & ", " & custid & ", " & userid & ", " & orderTotal & ", '" & paymentStatus & "')"
            SetQuery(sqlSale)

            ' --- Get new SaleID correctly ---
            GetQuery("SELECT LAST_INSERT_ID() AS newsaleid", "newsale")
            Dim newSaleID As Integer = CInt(ds.Tables("newsale").Rows(0)("newsaleid"))

            ' --- Get current customer balance ---
            GetQuery("SELECT balance FROM tblcustomerbalance WHERE custid = " & custid, "custbal")
            Dim currentBalance As Decimal = 0
            If ds.Tables("custbal").Rows.Count > 0 Then
                currentBalance = CDec(ds.Tables("custbal").Rows(0)("balance"))
                ' Update balance with order total
                SetQuery("UPDATE tblcustomerbalance SET balance = balance + " & orderTotal & ", lastupdate = NOW() WHERE custid = " & custid)
            Else
                ' Insert new balance record
                SetQuery("INSERT INTO tblcustomerbalance (custid, balance, lastupdate) VALUES (" & custid & ", " & orderTotal & ", NOW())")
            End If

            ' --- Log customer transaction for sale ---
            SetQuery("INSERT INTO tblcustomertransactions (custid, saleid, amount, type) " &
                     "VALUES (" & custid & ", " & newSaleID & ", " & orderTotal & ", 'Sale')")

            ' --- Apply negative balance automatically ---
            Dim paymentToApply As Decimal = 0
            If currentBalance < 0 Then
                paymentToApply = Math.Min(-currentBalance, orderTotal)

                ' Insert into tblpayments
                SetQuery("INSERT INTO tblpayments (saleid, amountpaid, paymentdate) VALUES (" & newSaleID & ", " & paymentToApply & ", NOW())")
                SetQuery("INSERT INTO tblcustomertransactions (custid, saleid, amount, type) VALUES (" & custid & ", " & newSaleID & ", " & paymentToApply & ", 'Payment')")

                ' Update customer balance after payment
                Dim newBalance As Decimal = orderTotal - paymentToApply
                SetQuery("UPDATE tblcustomerbalance SET balance = " & newBalance & ", lastupdate = NOW() WHERE custid = " & custid)

                ' Update sale payment status
                Dim newStatus As String = If(paymentToApply >= orderTotal, "Full", "Partial")
                SetQuery("UPDATE tblsales SET paymentstatus = '" & newStatus & "' WHERE saleid = " & newSaleID)
            End If

            LogActivity("Sales", "Created Order", newSaleID)

            ' --- Feedback & reset form ---
            MsgBox("Order and sale recorded successfully! Order #" & newOrderID & " / Sale #" & newSaleID, MsgBoxStyle.Information, "Success")

            lvorderitems.Items.Clear()
            lbltotalprice.Text = "0.00"
            cmbcustomer.SelectedIndex = -1
            cmbordertype.SelectedIndex = -1
            LoadProducts()
            LoadNextOrderID()

        Catch ex As Exception
            MsgBox("An error occurred while saving the order: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub lvproducts_DoubleClick(sender As Object, e As EventArgs) Handles lvproducts.DoubleClick
        If lvproducts.SelectedItems.Count = 0 Then Exit Sub

        Dim row As ListViewItem = lvproducts.SelectedItems(0)

        Dim productId As Integer = CInt(row.SubItems(0).Text)
        Dim productName As String = row.SubItems(1).Text
        Dim unitPrice As Decimal = CDec(row.SubItems(3).Text)
        Dim stockQty As Integer = CInt(row.SubItems(5).Text)
        Dim category As String = row.SubItems(2).Text
        Dim unit As String = row.SubItems(4).Text

        ' Calculate available stock correctly for new addition
        Dim availableStock As Integer = GetAvailableStock(productId)   ' all items in cart counted
        If availableStock <= 0 Then
            MsgBox("No more stock available for this product.", MsgBoxStyle.Information, "Stock Limit")
            Exit Sub
        End If

        ' Open dialog and pass data
        Dim dlg As New DlgAddOrderItem()
        dlg.ProductID = productId
        dlg.PName = productName
        dlg.UnitPrice = unitPrice
        dlg.StockQty = availableStock
        dlg.CurrentCartQty = 0       ' new addition
        dlg.Category = category
        dlg.Unit = unit

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim quantity As Integer = dlg.nudqty.Value
            Dim total As Decimal = quantity * dlg.UnitPrice

            ' Check if item already exists in cart
            Dim existingItem As ListViewItem = Nothing
            For Each item As ListViewItem In lvorderitems.Items
                ' Only check products for product addition
                If item.SubItems(7).Text = "Product" AndAlso CInt(item.SubItems(6).Text) = productId Then
                    existingItem = item
                    Exit For
                End If
            Next


            If existingItem IsNot Nothing Then
                ' Update existing row
                existingItem.SubItems(2).Text = (CInt(existingItem.SubItems(2).Text) + quantity).ToString()
                existingItem.SubItems(4).Text = (CInt(existingItem.SubItems(2).Text) * dlg.UnitPrice).ToString("F2")
            Else
                ' Add new row
                Dim itemNo As Integer = lvorderitems.Items.Count + 1
                Dim item As ListViewItem = lvorderitems.Items.Add(itemNo.ToString())  ' #
                item.SubItems.Add(dlg.PName)                                         ' Product
                item.SubItems.Add(quantity.ToString())                                 ' Qty
                item.SubItems.Add(dlg.UnitPrice.ToString("F2"))                        ' Price
                item.SubItems.Add(total.ToString("F2"))                                 ' Total
                item.SubItems.Add("0")                                                  ' OrderID (new)
                item.SubItems.Add(dlg.ProductID.ToString())                             ' ProductID
                item.SubItems.Add("Product")                                            ' ItemType

            End If

            UpdateTotal()
        End If
    End Sub



    Private Sub UpdateTotal()
        Dim totalPrice As Decimal = 0
        For Each item As ListViewItem In lvorderitems.Items
            totalPrice += CDec(item.SubItems(4).Text)
        Next
        lbltotalprice.Text = totalPrice.ToString("F2")
    End Sub

    Private Sub btnremoveitem_Click(sender As Object, e As EventArgs) Handles btnremoveitem.Click
        Try
            If lvorderitems.SelectedItems.Count = 0 Then
                MsgBox("Please select an item to remove.", MsgBoxStyle.Information, "Validation Error")
                Exit Sub
            End If

            Dim itemToRemove As ListViewItem = lvorderitems.SelectedItems(0)
            Dim isDeliveryService As Boolean = False

            ' Check if the item is a delivery service
            If itemToRemove.SubItems.Count > 7 AndAlso itemToRemove.SubItems(7).Text = "Service" Then
                Dim sName As String = itemToRemove.SubItems(1).Text
                If sName.ToLower().Contains("delivery") Then
                    isDeliveryService = True
                End If
            End If

            Dim confirm As DialogResult = MsgBox("Are you sure you want to remove the selected item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Removal")
            If confirm = DialogResult.Yes Then
                lvorderitems.Items.Remove(itemToRemove)
                UpdateTotal()

                For i As Integer = 0 To lvorderitems.Items.Count - 1
                    lvorderitems.Items(i).SubItems(0).Text = (i + 1).ToString()
                Next

                If isDeliveryService Then
                    cmbordertype.SelectedIndex = -1
                End If
            End If

        Catch ex As Exception
            MsgBox("An error occurred while removing the item: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub lvorderitems_DoubleClick(sender As Object, e As EventArgs) Handles lvorderitems.DoubleClick
        Try
            If lvorderitems.SelectedItems.Count = 0 Then Exit Sub
            Dim row As ListViewItem = lvorderitems.SelectedItems(0)
            Dim itemType As String = row.SubItems(7).Text

            If itemType = "Product" Then
                ' --- Product Editing ---
                Dim dlg As New DlgAddOrderItem()
                dlg.ProductID = CInt(row.SubItems(6).Text)
                dlg.PName = row.SubItems(1).Text
                dlg.UnitPrice = CDec(row.SubItems(3).Text)

                ' Get current DB stock
                GetQuery("SELECT stockqty FROM tblproducts WHERE productid = " & dlg.ProductID, "productstock")
                Dim totalStock As Integer = 0
                If ds.Tables("productstock").Rows.Count > 0 Then
                    totalStock = CInt(ds.Tables("productstock").Rows(0)("stockqty"))
                End If

                ' Calculate available stock excluding the current row
                dlg.StockQty = GetAvailableStock(dlg.ProductID, row)
                dlg.CurrentCartQty = CInt(row.SubItems(2).Text)
                dlg.Category = "" ' optional
                dlg.Unit = "" ' optional

                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim newQty As Integer = dlg.nudqty.Value
                    Dim total As Decimal = newQty * dlg.UnitPrice

                    row.SubItems(2).Text = newQty.ToString()
                    row.SubItems(4).Text = total.ToString("F2")
                    UpdateTotal()
                End If

            ElseIf itemType = "Service" Then
                ' --- Service Editing ---
                Dim dlg As New DlgAddServiceItem()
                dlg.ServiceID = CInt(row.SubItems(6).Text)
                dlg.SName = row.SubItems(1).Text
                dlg.UnitPrice = CDec(row.SubItems(3).Text)
                dlg.CurrentQty = CInt(row.SubItems(2).Text)

                If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim newQty As Integer = dlg.nudqty.Value
                    Dim total As Decimal = newQty * dlg.UnitPrice

                    row.SubItems(2).Text = newQty.ToString()
                    row.SubItems(4).Text = total.ToString("F2")
                    UpdateTotal()
                End If
            End If

        Catch ex As Exception
            MsgBox("An error occurred while editing the item: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub LoadNextOrderID()
        Try
            Dim query As String = "SELECT IFNULL(MAX(orderid), 0) + 1 AS nextid FROM tblorders"
            GetQuery(query, "nextorderid")

            If ds.Tables("nextorderid").Rows.Count > 0 Then
                lblorderid.Text = ds.Tables("nextorderid").Rows(0)("nextid").ToString()
            Else
                lblorderid.Text = "1"
            End If

        Catch ex As Exception
            MsgBox("An error occurred while loading the next Order ID: " & ex.Message, MsgBoxStyle.Critical, "Error")
            lblorderid.Text = "1"
        End Try
    End Sub


    Public Sub LoadExistingOrder(orderId As Integer)
        Try
            ' --- Load order header ---
            Dim sqlOrder As String = "SELECT o.*, c.custid, CONCAT(c.fname, ' ', IFNULL(c.lname,'')) AS fullname " &
                                     "FROM tblorders o " &
                                     "JOIN tblcustomers c ON o.custid = c.custid " &
                                     "WHERE o.orderid = " & orderId
            GetQuery(sqlOrder, "orderheader")

            If ds.Tables("orderheader").Rows.Count = 0 Then Exit Sub
            Dim row = ds.Tables("orderheader").Rows(0)

            ' --- Fill fields ---
            lblorderid.Text = row("orderid").ToString()
            cmbcustomer.SelectedValue = row("custid")
            cmbordertype.Text = row("ordertype").ToString()

            ' Disable customer & ordertype to prevent edits
            cmbcustomer.Enabled = False

            ' --- Load order items (Products + Services) ---
            Dim sqlItems As String =
                "SELECT oi.orderid, oi.itemtype, oi.productid, oi.serviceid, " &
                "COALESCE(p.name, s.name) AS itemname, oi.qty, oi.price, (oi.qty * oi.price) AS total " &
                "FROM tblorderitems oi " &
                "LEFT JOIN tblproducts p ON oi.productid = p.productid " &
                "LEFT JOIN tblservices s ON oi.serviceid = s.serviceid " &
                "WHERE oi.orderid = " & orderId

            GetQuery(sqlItems, "orderitems")

            lvorderitems.Items.Clear()
            For Each itemRow As DataRow In ds.Tables("orderitems").Rows
                Dim itemNo As Integer = lvorderitems.Items.Count + 1
                Dim item As ListViewItem = lvorderitems.Items.Add(itemNo.ToString())        ' #
                item.SubItems.Add(itemRow("itemname").ToString())                           ' Product or Service Name
                item.SubItems.Add(itemRow("qty").ToString())                                ' Qty
                item.SubItems.Add(CDec(itemRow("price")).ToString("F2"))                    ' Price
                item.SubItems.Add(CDec(itemRow("total")).ToString("F2"))                    ' Total
                item.SubItems.Add(orderId.ToString())                                       ' OrderID

                ' Store either ProductID or ServiceID based on itemtype
                If itemRow("itemtype").ToString() = "Product" Then
                    item.SubItems.Add(If(IsDBNull(itemRow("productid")), "0", itemRow("productid").ToString()))   ' ProductID
                Else
                    item.SubItems.Add(If(IsDBNull(itemRow("serviceid")), "0", itemRow("serviceid").ToString()))   ' ServiceID
                End If

                ' Add the item type (Product/Service)
                item.SubItems.Add(itemRow("itemtype").ToString())
            Next

            UpdateTotal()
            SetSalesFormState("edit")

        Catch ex As Exception
            MsgBox("An error occurred while loading the order: " & ex.Message, MsgBoxStyle.Critical, "Error")
            lvorderitems.Items.Clear()
            lblorderid.Text = "0"
            cmbcustomer.SelectedIndex = -1
            cmbordertype.SelectedIndex = -1
        End Try
    End Sub

   

    Private Sub lvservices_DoubleClick(sender As Object, e As EventArgs) Handles lvservices.DoubleClick
        If lvservices.SelectedItems.Count = 0 Then Exit Sub

        Dim row As ListViewItem = lvservices.SelectedItems(0)

        Dim serviceId As Integer = CInt(row.SubItems(0).Text)
        Dim serviceName As String = row.SubItems(1).Text
        Dim price As Decimal = CDec(row.SubItems(2).Text)

        ' Open dialog
        Dim dlg As New DlgAddServiceItem()
        dlg.ServiceID = serviceId
        dlg.SName = serviceName
        dlg.UnitPrice = price
        dlg.CurrentQty = 0  ' new addition

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim qty As Integer = dlg.nudqty.Value
            Dim total As Decimal = qty * dlg.UnitPrice

            ' Check if service already exists in cart
            Dim existingItem As ListViewItem = Nothing
            For Each item As ListViewItem In lvorderitems.Items
                If item.SubItems(7).Text = "Service" AndAlso CInt(item.SubItems(6).Text) = serviceId Then
                    existingItem = item
                    Exit For
                End If
            Next


            If existingItem IsNot Nothing Then
                ' Update existing service item
                existingItem.SubItems(2).Text = (CInt(existingItem.SubItems(2).Text) + qty).ToString()
                existingItem.SubItems(4).Text = (CInt(existingItem.SubItems(2).Text) * dlg.UnitPrice).ToString("F2")
            Else
                ' Add new service item
                Dim itemNo As Integer = lvorderitems.Items.Count + 1
                Dim item As ListViewItem = lvorderitems.Items.Add(itemNo.ToString())   ' #
                item.SubItems.Add(serviceName)                                         ' Name
                item.SubItems.Add(qty.ToString())                                      ' Qty
                item.SubItems.Add(price.ToString("F2"))                                ' Price
                item.SubItems.Add(total.ToString("F2"))                                ' Total
                item.SubItems.Add("0")                                                 ' OrderID placeholder
                item.SubItems.Add(serviceId.ToString())                                ' ServiceID
                item.SubItems.Add("Service")                                           ' ItemType
            End If

            UpdateTotal()
        End If
    End Sub




    ' Centralized control manager for A_Sales form
    Public Sub SetSalesFormState(ByVal mode As String)
        ' mode options: "new", "edit", "view", "reset"
        Select Case mode.ToLower()

            Case "new"
                ' Adding new order
                cmbcustomer.Enabled = True
                cmbordertype.Enabled = True
                lvproducts.Enabled = True
                lvorderitems.Enabled = True

                btnsave.Visible = True
                btnremoveitem.Enabled = True

                lvorderitems.Items.Clear()
                dtpdate.Value = Now
                lbltotalprice.Text = "0.00"

                ' Properly reset dropdowns
                cmbcustomer.DataSource = Nothing
                LoadCustomers() ' repopulate after reset
                cmbcustomer.SelectedIndex = -1

                cmbordertype.SelectedIndex = -1
                cmbordertype.Text = String.Empty

            Case "edit"
                ' Editing existing order
                cmbcustomer.Enabled = False
                cmbordertype.Enabled = True
                lvproducts.Enabled = True
                lvorderitems.Enabled = True

                btnsave.Visible = False
                btnremoveitem.Enabled = True
        End Select
    End Sub

    Private Sub cmbordertype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbordertype.SelectedIndexChanged
        If cmbordertype.SelectedIndex = -1 Then Exit Sub

        Dim selectedType As String = cmbordertype.Text

        ' Remove existing delivery service if switching away
        For i As Integer = lvorderitems.Items.Count - 1 To 0 Step -1
            Dim item As ListViewItem = lvorderitems.Items(i)
            If item.SubItems.Count > 7 AndAlso item.SubItems(7).Text = "Service" Then
                Dim sid As Integer = CInt(item.SubItems(6).Text)
                Dim sname As String = item.SubItems(1).Text
                If sname.ToLower().Contains("delivery") Then
                    lvorderitems.Items.RemoveAt(i)
                End If
            End If
        Next

        ' If selected is "Delivery", auto-add delivery service
        If selectedType = "Delivery" Then
            ' Find delivery service in dtServices
            Dim foundRows() As DataRow = dtServices.Select("servicename LIKE '%Delivery%' AND status = 'Active'")

            If foundRows.Length > 0 Then
                Dim sRow As DataRow = foundRows(0)
                Dim serviceId As Integer = CInt(sRow("serviceid"))
                Dim serviceName As String = sRow("servicename").ToString()
                Dim price As Decimal = CDec(sRow("price"))
                Dim qty As Integer = 1
                Dim total As Decimal = price * qty

                ' Check if already exists (just in case)
                Dim existingItem As ListViewItem = Nothing
                For Each item As ListViewItem In lvorderitems.Items
                    If item.SubItems.Count > 7 AndAlso item.SubItems(7).Text = "Service" AndAlso CInt(item.SubItems(6).Text) = serviceId Then
                        existingItem = item
                        Exit For
                    End If
                Next

                If existingItem Is Nothing Then
                    ' Add new delivery service
                    Dim itemNo As Integer = lvorderitems.Items.Count + 1
                    Dim item As ListViewItem = lvorderitems.Items.Add(itemNo.ToString())  ' #
                    item.SubItems.Add(serviceName)                                       ' Name
                    item.SubItems.Add(qty.ToString())                                    ' Qty
                    item.SubItems.Add(price.ToString("F2"))                              ' Price
                    item.SubItems.Add(total.ToString("F2"))                              ' Total
                    item.SubItems.Add("0")                                               ' OrderID placeholder
                    item.SubItems.Add(serviceId.ToString())                              ' ServiceID
                    item.SubItems.Add("Service")                                         ' ItemType
                End If

                UpdateTotal()
            Else
                MsgBox("No active 'Delivery' service found in tblservices.", MsgBoxStyle.Information, "Missing Service")
            End If
        End If
    End Sub

    Private Sub btnaddcustomer_Click(sender As Object, e As EventArgs) Handles btnaddcustomer.Click
        If DlgAddCustomer.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadCustomers()
        End If
    End Sub


    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Optional safety check
        If lvorderitems.Items.Count > 0 Then
            If MsgBox("You have an unsaved order. Continue anyway?", _
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ' Open Orders form
        labelclickedE(EmployeeDashboard.lblorders)
        EmployeeDashboard.switchPanel(E3_Orders)
        EmployeeDashboard.lbltitle.Text = "Orders"
        E3_Orders.FillOrders()
    End Sub
End Class