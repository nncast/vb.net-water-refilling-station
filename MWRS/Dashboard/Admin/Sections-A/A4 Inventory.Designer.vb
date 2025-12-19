<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A4_Inventory
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.lvproducts = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.unit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.stockqty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.reorderlevel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btncategories = New System.Windows.Forms.Button()
        Me.btntransaction = New System.Windows.Forms.Button()
        Me.btnunits = New System.Windows.Forms.Button()
        Me.btnservices = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.pnlbuttons.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtsearch)
        Me.Panel2.Controls.Add(Me.lvproducts)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 532)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(787, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 28)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "🔍"
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(830, 15)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(270, 34)
        Me.txtsearch.TabIndex = 0
        '
        'lvproducts
        '
        Me.lvproducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvproducts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.pname, Me.category, Me.price, Me.unit, Me.stockqty, Me.reorderlevel, Me.status})
        Me.lvproducts.FullRowSelect = True
        Me.lvproducts.GridLines = True
        Me.lvproducts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvproducts.Location = New System.Drawing.Point(10, 75)
        Me.lvproducts.Name = "lvproducts"
        Me.lvproducts.Size = New System.Drawing.Size(1100, 440)
        Me.lvproducts.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvproducts.TabIndex = 2
        Me.lvproducts.TabStop = False
        Me.lvproducts.UseCompatibleStateImageBehavior = False
        Me.lvproducts.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        '
        'pname
        '
        Me.pname.Text = "Product Name"
        Me.pname.Width = 189
        '
        'category
        '
        Me.category.Text = "Category"
        Me.category.Width = 150
        '
        'price
        '
        Me.price.Text = "Price"
        Me.price.Width = 150
        '
        'unit
        '
        Me.unit.Text = "Unit"
        Me.unit.Width = 150
        '
        'stockqty
        '
        Me.stockqty.Text = "In Stock"
        Me.stockqty.Width = 150
        '
        'reorderlevel
        '
        Me.reorderlevel.Text = "Reorder Level"
        Me.reorderlevel.Width = 150
        '
        'status
        '
        Me.status.Text = "Status"
        Me.status.Width = 100
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1125, 532)
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
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 0)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(1122, 527)
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.btnnew)
        Me.pnlbuttons.Controls.Add(Me.btnedit)
        Me.pnlbuttons.Controls.Add(Me.btndelete)
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 105)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(501, 43)
        Me.pnlbuttons.TabIndex = 0
        '
        'btnnew
        '
        Me.btnnew.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnnew.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnew.ForeColor = System.Drawing.Color.White
        Me.btnnew.Location = New System.Drawing.Point(1, 1)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(234, 42)
        Me.btnnew.TabIndex = 0
        Me.btnnew.Text = "➕ New Product"
        Me.btnnew.UseVisualStyleBackColor = False
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
        'btncategories
        '
        Me.btncategories.BackColor = System.Drawing.Color.White
        Me.btncategories.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btncategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncategories.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btncategories.Location = New System.Drawing.Point(645, 57)
        Me.btncategories.Name = "btncategories"
        Me.btncategories.Size = New System.Drawing.Size(237, 42)
        Me.btncategories.TabIndex = 2
        Me.btncategories.Text = "Categories"
        Me.btncategories.UseVisualStyleBackColor = False
        '
        'btntransaction
        '
        Me.btntransaction.BackColor = System.Drawing.Color.White
        Me.btntransaction.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btntransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntransaction.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btntransaction.Location = New System.Drawing.Point(888, 105)
        Me.btntransaction.Name = "btntransaction"
        Me.btntransaction.Size = New System.Drawing.Size(237, 42)
        Me.btntransaction.TabIndex = 3
        Me.btntransaction.Text = "Transactions"
        Me.btntransaction.UseVisualStyleBackColor = False
        '
        'btnunits
        '
        Me.btnunits.BackColor = System.Drawing.Color.White
        Me.btnunits.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnunits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnunits.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnunits.Location = New System.Drawing.Point(645, 105)
        Me.btnunits.Name = "btnunits"
        Me.btnunits.Size = New System.Drawing.Size(237, 42)
        Me.btnunits.TabIndex = 4
        Me.btnunits.Text = "Units"
        Me.btnunits.UseVisualStyleBackColor = False
        '
        'btnservices
        '
        Me.btnservices.BackColor = System.Drawing.Color.White
        Me.btnservices.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnservices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnservices.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnservices.Location = New System.Drawing.Point(888, 57)
        Me.btnservices.Name = "btnservices"
        Me.btnservices.Size = New System.Drawing.Size(237, 42)
        Me.btnservices.TabIndex = 5
        Me.btnservices.Text = "Services"
        Me.btnservices.UseVisualStyleBackColor = False
        '
        'A4_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.btnservices)
        Me.Controls.Add(Me.btnunits)
        Me.Controls.Add(Me.btntransaction)
        Me.Controls.Add(Me.btncategories)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "A4_Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory_A"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlbuttons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents lvproducts As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents pname As System.Windows.Forms.ColumnHeader
    Friend WithEvents category As System.Windows.Forms.ColumnHeader
    Friend WithEvents price As System.Windows.Forms.ColumnHeader
    Friend WithEvents unit As System.Windows.Forms.ColumnHeader
    Friend WithEvents stockqty As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btncategories As System.Windows.Forms.Button
    Friend WithEvents btntransaction As System.Windows.Forms.Button
    Friend WithEvents reorderlevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents status As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnunits As System.Windows.Forms.Button
    Friend WithEvents btnservices As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
