<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgInventoryTransaction
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvtransactions = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.product = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.user = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.transtype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.qty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.transdate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.remark = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnedittransaction = New System.Windows.Forms.Button()
        Me.btndeletetransaction = New System.Windows.Forms.Button()
        Me.btnaddtransaction = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(7, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "List of Inventory Transactions"
        '
        'lvtransactions
        '
        Me.lvtransactions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvtransactions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.product, Me.user, Me.transtype, Me.qty, Me.transdate, Me.remark})
        Me.lvtransactions.FullRowSelect = True
        Me.lvtransactions.GridLines = True
        Me.lvtransactions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvtransactions.Location = New System.Drawing.Point(12, 47)
        Me.lvtransactions.Name = "lvtransactions"
        Me.lvtransactions.Size = New System.Drawing.Size(958, 311)
        Me.lvtransactions.TabIndex = 0
        Me.lvtransactions.UseCompatibleStateImageBehavior = False
        Me.lvtransactions.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        '
        'product
        '
        Me.product.Text = "Product"
        Me.product.Width = 140
        '
        'user
        '
        Me.user.Text = "User"
        Me.user.Width = 100
        '
        'transtype
        '
        Me.transtype.Text = "Transaction Type"
        Me.transtype.Width = 133
        '
        'qty
        '
        Me.qty.Text = "Quantity"
        Me.qty.Width = 88
        '
        'transdate
        '
        Me.transdate.Text = "Date"
        Me.transdate.Width = 200
        '
        'remark
        '
        Me.remark.Text = "Remark"
        Me.remark.Width = 208
        '
        'btnedittransaction
        '
        Me.btnedittransaction.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnedittransaction.BackColor = System.Drawing.Color.White
        Me.btnedittransaction.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnedittransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedittransaction.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnedittransaction.Location = New System.Drawing.Point(715, 39)
        Me.btnedittransaction.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnedittransaction.Name = "btnedittransaction"
        Me.btnedittransaction.Size = New System.Drawing.Size(128, 40)
        Me.btnedittransaction.TabIndex = 1
        Me.btnedittransaction.Text = "✏️  Edit"
        Me.btnedittransaction.UseVisualStyleBackColor = False
        '
        'btndeletetransaction
        '
        Me.btndeletetransaction.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btndeletetransaction.BackColor = System.Drawing.Color.Red
        Me.btndeletetransaction.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btndeletetransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndeletetransaction.ForeColor = System.Drawing.Color.White
        Me.btndeletetransaction.Location = New System.Drawing.Point(853, 38)
        Me.btndeletetransaction.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btndeletetransaction.Name = "btndeletetransaction"
        Me.btndeletetransaction.Size = New System.Drawing.Size(128, 42)
        Me.btndeletetransaction.TabIndex = 2
        Me.btndeletetransaction.Text = "🗑️  Delete"
        Me.btndeletetransaction.UseVisualStyleBackColor = False
        '
        'btnaddtransaction
        '
        Me.btnaddtransaction.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnaddtransaction.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnaddtransaction.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnaddtransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaddtransaction.ForeColor = System.Drawing.Color.White
        Me.btnaddtransaction.Location = New System.Drawing.Point(528, 38)
        Me.btnaddtransaction.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnaddtransaction.Name = "btnaddtransaction"
        Me.btnaddtransaction.Size = New System.Drawing.Size(177, 40)
        Me.btnaddtransaction.TabIndex = 0
        Me.btnaddtransaction.Text = "➕ Add Transaction"
        Me.btnaddtransaction.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtsearch)
        Me.Panel1.Controls.Add(Me.lvtransactions)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(0, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(983, 395)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(647, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "🔍"
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(686, 11)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(270, 30)
        Me.txtsearch.TabIndex = 4
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(983, 395)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.Enabled = False
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(3, 0)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(977, 392)
        '
        'DlgInventoryTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(982, 483)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnedittransaction)
        Me.Controls.Add(Me.btndeletetransaction)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnaddtransaction)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgInventoryTransaction"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgInventoryTransaction"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvtransactions As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents product As System.Windows.Forms.ColumnHeader
    Friend WithEvents user As System.Windows.Forms.ColumnHeader
    Friend WithEvents transtype As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty As System.Windows.Forms.ColumnHeader
    Friend WithEvents transdate As System.Windows.Forms.ColumnHeader
    Friend WithEvents remark As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnedittransaction As System.Windows.Forms.Button
    Friend WithEvents btndeletetransaction As System.Windows.Forms.Button
    Friend WithEvents btnaddtransaction As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
