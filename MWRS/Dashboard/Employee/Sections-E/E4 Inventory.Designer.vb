<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E4_Inventory
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
        Me.pnlbuttons = New System.Windows.Forms.Panel()
        Me.btnedit = New System.Windows.Forms.Button()
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
        Me.pnlbuttons.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlbuttons
        '
        Me.pnlbuttons.Controls.Add(Me.btnedit)
        Me.pnlbuttons.Location = New System.Drawing.Point(0, 79)
        Me.pnlbuttons.Name = "pnlbuttons"
        Me.pnlbuttons.Size = New System.Drawing.Size(209, 43)
        Me.pnlbuttons.TabIndex = 5
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.White
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnedit.Location = New System.Drawing.Point(0, 1)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(209, 42)
        Me.btnedit.TabIndex = 1
        Me.btnedit.Text = "✏️  Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtsearch)
        Me.Panel2.Controls.Add(Me.lvproducts)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(0, 129)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 532)
        Me.Panel2.TabIndex = 4
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
        'E4_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.pnlbuttons)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "E4_Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E4_Delivery"
        Me.pnlbuttons.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlbuttons As System.Windows.Forms.Panel
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents lvproducts As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents pname As System.Windows.Forms.ColumnHeader
    Friend WithEvents category As System.Windows.Forms.ColumnHeader
    Friend WithEvents price As System.Windows.Forms.ColumnHeader
    Friend WithEvents unit As System.Windows.Forms.ColumnHeader
    Friend WithEvents stockqty As System.Windows.Forms.ColumnHeader
    Friend WithEvents reorderlevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents status As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
