<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A5_Delivery
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvreadyorders = New System.Windows.Forms.ListView()
        Me.oid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custadd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.orddate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalamount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDeliveryPerson = New System.Windows.Forms.ComboBox()
        Me.txtsearchready = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.btnAssignDelivery = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsearchdeliveries = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvdeliveries = New System.Windows.Forms.ListView()
        Me.deliveryid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.delidate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dstat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.orders = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlbuttons.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lvreadyorders)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.txtsearchready)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 327)
        Me.Panel2.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(856, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 28)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "🔍"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(483, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Orders Ready To Deliver"
        '
        'lvreadyorders
        '
        Me.lvreadyorders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvreadyorders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.oid, Me.custname, Me.custadd, Me.orddate, Me.totalamount, Me.balance})
        Me.lvreadyorders.FullRowSelect = True
        Me.lvreadyorders.GridLines = True
        Me.lvreadyorders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvreadyorders.Location = New System.Drawing.Point(489, 50)
        Me.lvreadyorders.Name = "lvreadyorders"
        Me.lvreadyorders.Size = New System.Drawing.Size(622, 251)
        Me.lvreadyorders.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvreadyorders.TabIndex = 3
        Me.lvreadyorders.TabStop = False
        Me.lvreadyorders.UseCompatibleStateImageBehavior = False
        Me.lvreadyorders.View = System.Windows.Forms.View.Details
        '
        'oid
        '
        Me.oid.Text = "ID"
        '
        'custname
        '
        Me.custname.Text = "Customer Name"
        Me.custname.Width = 100
        '
        'custadd
        '
        Me.custadd.DisplayIndex = 5
        Me.custadd.Text = "Customer Address"
        Me.custadd.Width = 150
        '
        'orddate
        '
        Me.orddate.DisplayIndex = 2
        Me.orddate.Text = "Order Date"
        Me.orddate.Width = 100
        '
        'totalamount
        '
        Me.totalamount.DisplayIndex = 3
        Me.totalamount.Text = "Total Amount"
        Me.totalamount.Width = 100
        '
        'balance
        '
        Me.balance.DisplayIndex = 4
        Me.balance.Text = "Balance"
        Me.balance.Width = 100
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtpDeliveryDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbDeliveryPerson)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 289)
        Me.Panel1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Delivery Date:"
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(159, 62)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(157, 34)
        Me.dtpDeliveryDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Delivery Person:"
        '
        'cmbDeliveryPerson
        '
        Me.cmbDeliveryPerson.FormattingEnabled = True
        Me.cmbDeliveryPerson.Location = New System.Drawing.Point(159, 4)
        Me.cmbDeliveryPerson.Name = "cmbDeliveryPerson"
        Me.cmbDeliveryPerson.Size = New System.Drawing.Size(254, 36)
        Me.cmbDeliveryPerson.TabIndex = 0
        '
        'txtsearchready
        '
        Me.txtsearchready.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearchready.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearchready.Location = New System.Drawing.Point(901, 14)
        Me.txtsearchready.Name = "txtsearchready"
        Me.txtsearchready.Size = New System.Drawing.Size(210, 34)
        Me.txtsearchready.TabIndex = 0
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1125, 327)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape3.CornerRadius = 20
        Me.RectangleShape3.Enabled = False
        Me.RectangleShape3.FillColor = System.Drawing.Color.White
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(467, 1)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(655, 323)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 0)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(459, 323)
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.btnAssignDelivery)
        Me.pnlbuttons.Controls.Add(Me.btnedit)
        Me.pnlbuttons.Controls.Add(Me.btndelete)
        Me.pnlbuttons.Location = New System.Drawing.Point(627, 333)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(498, 43)
        Me.pnlbuttons.TabIndex = 0
        '
        'btnAssignDelivery
        '
        Me.btnAssignDelivery.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnAssignDelivery.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnAssignDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssignDelivery.ForeColor = System.Drawing.Color.White
        Me.btnAssignDelivery.Location = New System.Drawing.Point(1, 1)
        Me.btnAssignDelivery.Name = "btnAssignDelivery"
        Me.btnAssignDelivery.Size = New System.Drawing.Size(234, 42)
        Me.btnAssignDelivery.TabIndex = 0
        Me.btnAssignDelivery.Text = "➕ Assign Delivery"
        Me.btnAssignDelivery.UseVisualStyleBackColor = False
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.White
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnedit.Location = New System.Drawing.Point(242, 1)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(121, 42)
        Me.btnedit.TabIndex = 1
        Me.btnedit.Text = "✏️  Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.Red
        Me.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.ForeColor = System.Drawing.Color.White
        Me.btndelete.Location = New System.Drawing.Point(370, 1)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(121, 42)
        Me.btndelete.TabIndex = 2
        Me.btndelete.Text = "🗑️  Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape2.CornerRadius = 20
        Me.RectangleShape2.Enabled = False
        Me.RectangleShape2.FillColor = System.Drawing.Color.White
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(1, 2)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(1122, 293)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtsearchdeliveries)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.lvdeliveries)
        Me.Panel3.Controls.Add(Me.ShapeContainer2)
        Me.Panel3.Location = New System.Drawing.Point(0, 382)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1125, 299)
        Me.Panel3.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(856, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 28)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "🔍"
        '
        'txtsearchdeliveries
        '
        Me.txtsearchdeliveries.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearchdeliveries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearchdeliveries.Location = New System.Drawing.Point(901, 13)
        Me.txtsearchdeliveries.Name = "txtsearchdeliveries"
        Me.txtsearchdeliveries.Size = New System.Drawing.Size(210, 34)
        Me.txtsearchdeliveries.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(14, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(173, 32)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "⛟   Deliveries"
        '
        'lvdeliveries
        '
        Me.lvdeliveries.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvdeliveries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.deliveryid, Me.user, Me.delidate, Me.dstat, Me.orders})
        Me.lvdeliveries.FullRowSelect = True
        Me.lvdeliveries.GridLines = True
        Me.lvdeliveries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvdeliveries.Location = New System.Drawing.Point(12, 53)
        Me.lvdeliveries.Name = "lvdeliveries"
        Me.lvdeliveries.Size = New System.Drawing.Size(1101, 229)
        Me.lvdeliveries.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvdeliveries.TabIndex = 5
        Me.lvdeliveries.TabStop = False
        Me.lvdeliveries.UseCompatibleStateImageBehavior = False
        Me.lvdeliveries.View = System.Windows.Forms.View.Details
        '
        'deliveryid
        '
        Me.deliveryid.Text = "ID"
        '
        'user
        '
        Me.user.Text = "Delivery Person"
        Me.user.Width = 311
        '
        'delidate
        '
        Me.delidate.Text = "Delivery Date"
        Me.delidate.Width = 233
        '
        'dstat
        '
        Me.dstat.Text = "Delivery Status"
        Me.dstat.Width = 287
        '
        'orders
        '
        Me.orders.Text = "Order ID"
        Me.orders.Width = 210
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1125, 299)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'A5_Delivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "A5_Delivery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery_A"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlbuttons.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtsearchready As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents btnAssignDelivery As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDeliveryPerson As System.Windows.Forms.ComboBox
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents lvreadyorders As System.Windows.Forms.ListView
    Friend WithEvents oid As System.Windows.Forms.ColumnHeader
    Friend WithEvents custname As System.Windows.Forms.ColumnHeader
    Friend WithEvents orddate As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalamount As System.Windows.Forms.ColumnHeader
    Friend WithEvents balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents custadd As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvdeliveries As System.Windows.Forms.ListView
    Friend WithEvents deliveryid As System.Windows.Forms.ColumnHeader
    Friend WithEvents user As System.Windows.Forms.ColumnHeader
    Friend WithEvents delidate As System.Windows.Forms.ColumnHeader
    Friend WithEvents dstat As System.Windows.Forms.ColumnHeader
    Friend WithEvents orders As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtsearchdeliveries As System.Windows.Forms.TextBox
End Class
