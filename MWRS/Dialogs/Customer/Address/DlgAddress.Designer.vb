<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgAddress
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btndeletepurok = New System.Windows.Forms.Button()
        Me.btneditpurok = New System.Windows.Forms.Button()
        Me.btnaddpurok = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvpurok = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Purok = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btndeletebarangay = New System.Windows.Forms.Button()
        Me.btneditbarangay = New System.Windows.Forms.Button()
        Me.lvbarangay = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.categoryname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnaddbarangay = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnsave, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btncancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(456, 444)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(219, 52)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'btnsave
        '
        Me.btnsave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnsave.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.ForeColor = System.Drawing.Color.White
        Me.btnsave.Location = New System.Drawing.Point(5, 6)
        Me.btnsave.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(99, 40)
        Me.btnsave.TabIndex = 5
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btncancel.BackColor = System.Drawing.Color.Gainsboro
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Location = New System.Drawing.Point(114, 6)
        Me.btncancel.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(100, 40)
        Me.btncancel.TabIndex = 6
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btndeletepurok)
        Me.Panel1.Controls.Add(Me.btneditpurok)
        Me.Panel1.Controls.Add(Me.btnaddpurok)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lvpurok)
        Me.Panel1.Controls.Add(Me.btndeletebarangay)
        Me.Panel1.Controls.Add(Me.btneditbarangay)
        Me.Panel1.Controls.Add(Me.lvbarangay)
        Me.Panel1.Controls.Add(Me.btnaddbarangay)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(19, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 412)
        Me.Panel1.TabIndex = 7
        '
        'btndeletepurok
        '
        Me.btndeletepurok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btndeletepurok.BackColor = System.Drawing.Color.Red
        Me.btndeletepurok.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btndeletepurok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndeletepurok.ForeColor = System.Drawing.Color.White
        Me.btndeletepurok.Location = New System.Drawing.Point(338, 346)
        Me.btndeletepurok.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btndeletepurok.Name = "btndeletepurok"
        Me.btndeletepurok.Size = New System.Drawing.Size(177, 42)
        Me.btndeletepurok.TabIndex = 7
        Me.btndeletepurok.Text = "🗑️  Delete Purok"
        Me.btndeletepurok.UseVisualStyleBackColor = False
        '
        'btneditpurok
        '
        Me.btneditpurok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btneditpurok.BackColor = System.Drawing.Color.White
        Me.btneditpurok.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btneditpurok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditpurok.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btneditpurok.Location = New System.Drawing.Point(338, 294)
        Me.btneditpurok.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btneditpurok.Name = "btneditpurok"
        Me.btneditpurok.Size = New System.Drawing.Size(177, 40)
        Me.btneditpurok.TabIndex = 6
        Me.btneditpurok.Text = "✏️  Edit Purok"
        Me.btneditpurok.UseVisualStyleBackColor = False
        '
        'btnaddpurok
        '
        Me.btnaddpurok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnaddpurok.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnaddpurok.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnaddpurok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaddpurok.ForeColor = System.Drawing.Color.White
        Me.btnaddpurok.Location = New System.Drawing.Point(338, 242)
        Me.btnaddpurok.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnaddpurok.Name = "btnaddpurok"
        Me.btnaddpurok.Size = New System.Drawing.Size(177, 40)
        Me.btnaddpurok.TabIndex = 5
        Me.btnaddpurok.Text = "➕ Add Purok"
        Me.btnaddpurok.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(334, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "List of Purok"
        '
        'lvpurok
        '
        Me.lvpurok.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.Purok})
        Me.lvpurok.FullRowSelect = True
        Me.lvpurok.GridLines = True
        Me.lvpurok.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvpurok.Location = New System.Drawing.Point(338, 41)
        Me.lvpurok.Name = "lvpurok"
        Me.lvpurok.Size = New System.Drawing.Size(270, 192)
        Me.lvpurok.TabIndex = 3
        Me.lvpurok.TabStop = False
        Me.lvpurok.UseCompatibleStateImageBehavior = False
        Me.lvpurok.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'Purok
        '
        Me.Purok.Text = "Purok"
        Me.Purok.Width = 204
        '
        'btndeletebarangay
        '
        Me.btndeletebarangay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btndeletebarangay.BackColor = System.Drawing.Color.Red
        Me.btndeletebarangay.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btndeletebarangay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndeletebarangay.ForeColor = System.Drawing.Color.White
        Me.btndeletebarangay.Location = New System.Drawing.Point(18, 346)
        Me.btndeletebarangay.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btndeletebarangay.Name = "btndeletebarangay"
        Me.btndeletebarangay.Size = New System.Drawing.Size(177, 42)
        Me.btndeletebarangay.TabIndex = 2
        Me.btndeletebarangay.Text = "🗑️  Delete Brgy"
        Me.btndeletebarangay.UseVisualStyleBackColor = False
        '
        'btneditbarangay
        '
        Me.btneditbarangay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btneditbarangay.BackColor = System.Drawing.Color.White
        Me.btneditbarangay.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btneditbarangay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditbarangay.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btneditbarangay.Location = New System.Drawing.Point(18, 294)
        Me.btneditbarangay.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btneditbarangay.Name = "btneditbarangay"
        Me.btneditbarangay.Size = New System.Drawing.Size(177, 40)
        Me.btneditbarangay.TabIndex = 1
        Me.btneditbarangay.Text = "✏️  Edit Barangay"
        Me.btneditbarangay.UseVisualStyleBackColor = False
        '
        'lvbarangay
        '
        Me.lvbarangay.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.ColumnHeader3, Me.categoryname})
        Me.lvbarangay.FullRowSelect = True
        Me.lvbarangay.GridLines = True
        Me.lvbarangay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvbarangay.Location = New System.Drawing.Point(18, 41)
        Me.lvbarangay.Name = "lvbarangay"
        Me.lvbarangay.Size = New System.Drawing.Size(270, 192)
        Me.lvbarangay.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvbarangay.TabIndex = 0
        Me.lvbarangay.TabStop = False
        Me.lvbarangay.UseCompatibleStateImageBehavior = False
        Me.lvbarangay.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        Me.id.Width = 0
        '
        'categoryname
        '
        Me.categoryname.Text = "Barangay"
        Me.categoryname.Width = 204
        '
        'btnaddbarangay
        '
        Me.btnaddbarangay.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnaddbarangay.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnaddbarangay.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnaddbarangay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaddbarangay.ForeColor = System.Drawing.Color.White
        Me.btnaddbarangay.Location = New System.Drawing.Point(18, 242)
        Me.btnaddbarangay.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnaddbarangay.Name = "btnaddbarangay"
        Me.btnaddbarangay.Size = New System.Drawing.Size(177, 40)
        Me.btnaddbarangay.TabIndex = 0
        Me.btnaddbarangay.Text = "➕ Add Barangay"
        Me.btnaddbarangay.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "List of Barangays"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "#"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "#"
        '
        'DlgAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(678, 520)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgAddress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Address"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btneditbarangay As System.Windows.Forms.Button
    Friend WithEvents btndeletebarangay As System.Windows.Forms.Button
    Friend WithEvents btnaddbarangay As System.Windows.Forms.Button
    Friend WithEvents lvbarangay As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents categoryname As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvpurok As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Purok As System.Windows.Forms.ColumnHeader
    Friend WithEvents btndeletepurok As System.Windows.Forms.Button
    Friend WithEvents btneditpurok As System.Windows.Forms.Button
    Friend WithEvents btnaddpurok As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader

End Class
