<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A2_Sales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbordertype = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnremoveitem = New System.Windows.Forms.Button()
        Me.lblorderid = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvorderitems = New System.Windows.Forms.ListView()
        Me.num = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ordername = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.orderqty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.orderprice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.oid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.psid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pstype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.lbltotalprice = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbcustomer = New System.Windows.Forms.ComboBox()
        Me.btnaddcustomer = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tabItems = New System.Windows.Forms.TabControl()
        Me.tabProducts = New System.Windows.Forms.TabPage()
        Me.lvproducts = New System.Windows.Forms.ListView()
        Me.productid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.product = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.stockqty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabServices = New System.Windows.Forms.TabPage()
        Me.lvservices = New System.Windows.Forms.ListView()
        Me.serviceid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sprice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sstatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tabItems.SuspendLayout()
        Me.tabProducts.SuspendLayout()
        Me.tabServices.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnupdate)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 683)
        Me.Panel1.TabIndex = 0
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.Location = New System.Drawing.Point(328, 621)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(123, 42)
        Me.btnupdate.TabIndex = 12
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        Me.btnupdate.Visible = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.ForeColor = System.Drawing.Color.White
        Me.btnsave.Location = New System.Drawing.Point(328, 621)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(123, 42)
        Me.btnsave.TabIndex = 11
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.cmbordertype)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.btnremoveitem)
        Me.Panel2.Controls.Add(Me.lblorderid)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lvorderitems)
        Me.Panel2.Controls.Add(Me.dtpdate)
        Me.Panel2.Controls.Add(Me.lbltotalprice)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbcustomer)
        Me.Panel2.Controls.Add(Me.btnaddcustomer)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(12, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(446, 556)
        Me.Panel2.TabIndex = 3
        '
        'cmbordertype
        '
        Me.cmbordertype.FormattingEnabled = True
        Me.cmbordertype.Location = New System.Drawing.Point(113, 203)
        Me.cmbordertype.Name = "cmbordertype"
        Me.cmbordertype.Size = New System.Drawing.Size(121, 36)
        Me.cmbordertype.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 28)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Order Type:"
        '
        'btnremoveitem
        '
        Me.btnremoveitem.BackColor = System.Drawing.Color.White
        Me.btnremoveitem.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnremoveitem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnremoveitem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremoveitem.ForeColor = System.Drawing.Color.Red
        Me.btnremoveitem.Location = New System.Drawing.Point(316, 201)
        Me.btnremoveitem.Name = "btnremoveitem"
        Me.btnremoveitem.Size = New System.Drawing.Size(123, 36)
        Me.btnremoveitem.TabIndex = 11
        Me.btnremoveitem.Text = "Remove"
        Me.btnremoveitem.UseVisualStyleBackColor = False
        '
        'lblorderid
        '
        Me.lblorderid.AutoSize = True
        Me.lblorderid.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblorderid.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblorderid.Location = New System.Drawing.Point(127, 129)
        Me.lblorderid.Name = "lblorderid"
        Me.lblorderid.Size = New System.Drawing.Size(24, 28)
        Me.lblorderid.TabIndex = 6
        Me.lblorderid.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(70, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 28)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "#ORD -"
        '
        'lvorderitems
        '
        Me.lvorderitems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvorderitems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.num, Me.ordername, Me.orderqty, Me.orderprice, Me.total, Me.oid, Me.psid, Me.pstype})
        Me.lvorderitems.FullRowSelect = True
        Me.lvorderitems.GridLines = True
        Me.lvorderitems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvorderitems.Location = New System.Drawing.Point(13, 242)
        Me.lvorderitems.Name = "lvorderitems"
        Me.lvorderitems.Size = New System.Drawing.Size(426, 272)
        Me.lvorderitems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvorderitems.TabIndex = 3
        Me.lvorderitems.UseCompatibleStateImageBehavior = False
        Me.lvorderitems.View = System.Windows.Forms.View.Details
        '
        'num
        '
        Me.num.Text = "#"
        Me.num.Width = 34
        '
        'ordername
        '
        Me.ordername.Text = "Item"
        Me.ordername.Width = 161
        '
        'orderqty
        '
        Me.orderqty.Text = "Quantity"
        Me.orderqty.Width = 90
        '
        'orderprice
        '
        Me.orderprice.Text = "Price"
        Me.orderprice.Width = 80
        '
        'total
        '
        Me.total.Text = "Total"
        Me.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'oid
        '
        Me.oid.Text = "OrderID"
        Me.oid.Width = 0
        '
        'psid
        '
        Me.psid.Text = "ProductServiceID"
        Me.psid.Width = 0
        '
        'pstype
        '
        Me.pstype.Text = "Type"
        Me.pstype.Width = 0
        '
        'dtpdate
        '
        Me.dtpdate.CustomFormat = "yyyy/MM/dd"
        Me.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdate.Location = New System.Drawing.Point(62, 166)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(172, 34)
        Me.dtpdate.TabIndex = 9
        Me.dtpdate.Value = New Date(2025, 10, 28, 19, 38, 35, 0)
        '
        'lbltotalprice
        '
        Me.lbltotalprice.AutoSize = True
        Me.lbltotalprice.Location = New System.Drawing.Point(379, 517)
        Me.lbltotalprice.Name = "lbltotalprice"
        Me.lbltotalprice.Size = New System.Drawing.Size(60, 28)
        Me.lbltotalprice.TabIndex = 8
        Me.lbltotalprice.Text = "00.00"
        Me.lbltotalprice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 517)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 28)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Total Amount:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 28)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 28)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Order:"
        '
        'cmbcustomer
        '
        Me.cmbcustomer.FormattingEnabled = True
        Me.cmbcustomer.Location = New System.Drawing.Point(13, 31)
        Me.cmbcustomer.Name = "cmbcustomer"
        Me.cmbcustomer.Size = New System.Drawing.Size(293, 36)
        Me.cmbcustomer.TabIndex = 1
        '
        'btnaddcustomer
        '
        Me.btnaddcustomer.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnaddcustomer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnaddcustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaddcustomer.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaddcustomer.ForeColor = System.Drawing.Color.White
        Me.btnaddcustomer.Location = New System.Drawing.Point(316, 30)
        Me.btnaddcustomer.Name = "btnaddcustomer"
        Me.btnaddcustomer.Size = New System.Drawing.Size(71, 29)
        Me.btnaddcustomer.TabIndex = 1
        Me.btnaddcustomer.Text = "➕ 👤"
        Me.btnaddcustomer.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select a Customer:"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(472, 683)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(1, 1)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(469, 678)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.tabItems)
        Me.Panel3.Location = New System.Drawing.Point(478, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(645, 627)
        Me.Panel3.TabIndex = 1
        '
        'tabItems
        '
        Me.tabItems.Controls.Add(Me.tabProducts)
        Me.tabItems.Controls.Add(Me.tabServices)
        Me.tabItems.Location = New System.Drawing.Point(3, 3)
        Me.tabItems.Name = "tabItems"
        Me.tabItems.SelectedIndex = 0
        Me.tabItems.Size = New System.Drawing.Size(639, 624)
        Me.tabItems.TabIndex = 3
        '
        'tabProducts
        '
        Me.tabProducts.BackColor = System.Drawing.Color.Transparent
        Me.tabProducts.Controls.Add(Me.lvproducts)
        Me.tabProducts.ForeColor = System.Drawing.Color.MidnightBlue
        Me.tabProducts.Location = New System.Drawing.Point(4, 37)
        Me.tabProducts.Name = "tabProducts"
        Me.tabProducts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabProducts.Size = New System.Drawing.Size(631, 583)
        Me.tabProducts.TabIndex = 0
        Me.tabProducts.Text = "🏷️    Products  "
        '
        'lvproducts
        '
        Me.lvproducts.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvproducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvproducts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.productid, Me.product, Me.category, Me.price, Me.unit, Me.stockqty})
        Me.lvproducts.FullRowSelect = True
        Me.lvproducts.GridLines = True
        Me.lvproducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvproducts.HoverSelection = True
        Me.lvproducts.Location = New System.Drawing.Point(0, 0)
        Me.lvproducts.Name = "lvproducts"
        Me.lvproducts.Size = New System.Drawing.Size(631, 582)
        Me.lvproducts.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvproducts.TabIndex = 1
        Me.lvproducts.UseCompatibleStateImageBehavior = False
        Me.lvproducts.View = System.Windows.Forms.View.Details
        '
        'productid
        '
        Me.productid.Text = "ID"
        '
        'product
        '
        Me.product.Text = "Product Name"
        Me.product.Width = 200
        '
        'category
        '
        Me.category.Text = "Category"
        Me.category.Width = 130
        '
        'price
        '
        Me.price.Text = "Price"
        Me.price.Width = 80
        '
        'unit
        '
        Me.unit.Text = "Unit"
        Me.unit.Width = 80
        '
        'stockqty
        '
        Me.stockqty.Text = "Stock"
        Me.stockqty.Width = 80
        '
        'tabServices
        '
        Me.tabServices.BackColor = System.Drawing.Color.Transparent
        Me.tabServices.Controls.Add(Me.lvservices)
        Me.tabServices.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabServices.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabServices.Location = New System.Drawing.Point(4, 37)
        Me.tabServices.Name = "tabServices"
        Me.tabServices.Padding = New System.Windows.Forms.Padding(3)
        Me.tabServices.Size = New System.Drawing.Size(631, 583)
        Me.tabServices.TabIndex = 1
        Me.tabServices.Text = "🛠️    Services  "
        Me.tabServices.UseVisualStyleBackColor = True
        '
        'lvservices
        '
        Me.lvservices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvservices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.serviceid, Me.sname, Me.sprice, Me.sstatus})
        Me.lvservices.FullRowSelect = True
        Me.lvservices.GridLines = True
        Me.lvservices.Location = New System.Drawing.Point(0, 0)
        Me.lvservices.Name = "lvservices"
        Me.lvservices.Size = New System.Drawing.Size(631, 587)
        Me.lvservices.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvservices.TabIndex = 2
        Me.lvservices.UseCompatibleStateImageBehavior = False
        Me.lvservices.View = System.Windows.Forms.View.Details
        '
        'serviceid
        '
        Me.serviceid.Text = "ID"
        '
        'sname
        '
        Me.sname.Text = "Service Name"
        Me.sname.Width = 430
        '
        'sprice
        '
        Me.sprice.Text = "Price"
        Me.sprice.Width = 135
        '
        'sstatus
        '
        Me.sstatus.Text = "Status"
        Me.sstatus.Width = 0
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.ForeColor = System.Drawing.Color.White
        Me.btnNext.Location = New System.Drawing.Point(1002, 641)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(123, 42)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'A2_Sales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "A2_Sales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Z"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.tabItems.ResumeLayout(False)
        Me.tabProducts.ResumeLayout(False)
        Me.tabServices.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbcustomer As System.Windows.Forms.ComboBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents btnaddcustomer As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lvproducts As System.Windows.Forms.ListView
    Friend WithEvents lbltotalprice As System.Windows.Forms.Label
    Friend WithEvents lblorderid As System.Windows.Forms.Label
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents productid As System.Windows.Forms.ColumnHeader
    Friend WithEvents product As System.Windows.Forms.ColumnHeader
    Friend WithEvents category As System.Windows.Forms.ColumnHeader
    Friend WithEvents price As System.Windows.Forms.ColumnHeader
    Friend WithEvents unit As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents lvorderitems As System.Windows.Forms.ListView
    Friend WithEvents orderqty As System.Windows.Forms.ColumnHeader
    Friend WithEvents orderprice As System.Windows.Forms.ColumnHeader
    Friend WithEvents stockqty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnremoveitem As System.Windows.Forms.Button
    Friend WithEvents cmbordertype As System.Windows.Forms.ComboBox
    Friend WithEvents total As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tabItems As System.Windows.Forms.TabControl
    Friend WithEvents tabProducts As System.Windows.Forms.TabPage
    Friend WithEvents tabServices As System.Windows.Forms.TabPage
    Friend WithEvents lvservices As System.Windows.Forms.ListView
    Friend WithEvents serviceid As System.Windows.Forms.ColumnHeader
    Friend WithEvents sname As System.Windows.Forms.ColumnHeader
    Friend WithEvents sprice As System.Windows.Forms.ColumnHeader
    Friend WithEvents sstatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents oid As System.Windows.Forms.ColumnHeader
    Friend WithEvents psid As System.Windows.Forms.ColumnHeader
    Friend WithEvents pstype As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Private WithEvents num As System.Windows.Forms.ColumnHeader
    Private WithEvents ordername As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnNext As System.Windows.Forms.Button
End Class
