<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgServices
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
        Me.btnok = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btneditservice = New System.Windows.Forms.Button()
        Me.btndeleteservice = New System.Windows.Forms.Button()
        Me.btnaddservice = New System.Windows.Forms.Button()
        Me.lvservices = New System.Windows.Forms.ListView()
        Me.id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sstatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnok, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btncancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(519, 399)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(219, 52)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'btnok
        '
        Me.btnok.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnok.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnok.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.ForeColor = System.Drawing.Color.White
        Me.btnok.Location = New System.Drawing.Point(5, 6)
        Me.btnok.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(99, 40)
        Me.btnok.TabIndex = 0
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btncancel.BackColor = System.Drawing.Color.Gainsboro
        Me.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Location = New System.Drawing.Point(114, 6)
        Me.btncancel.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(100, 40)
        Me.btncancel.TabIndex = 1
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.lvservices)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(721, 362)
        Me.Panel1.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btneditservice, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btndeleteservice, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnaddservice, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(499, 41)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(203, 192)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btneditservice
        '
        Me.btneditservice.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btneditservice.BackColor = System.Drawing.Color.White
        Me.btneditservice.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btneditservice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditservice.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btneditservice.Location = New System.Drawing.Point(13, 76)
        Me.btneditservice.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btneditservice.Name = "btneditservice"
        Me.btneditservice.Size = New System.Drawing.Size(177, 40)
        Me.btneditservice.TabIndex = 1
        Me.btneditservice.Text = "✏️  Edit Service"
        Me.btneditservice.UseVisualStyleBackColor = False
        '
        'btndeleteservice
        '
        Me.btndeleteservice.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btndeleteservice.BackColor = System.Drawing.Color.Red
        Me.btndeleteservice.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btndeleteservice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndeleteservice.ForeColor = System.Drawing.Color.White
        Me.btndeleteservice.Location = New System.Drawing.Point(13, 139)
        Me.btndeleteservice.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btndeleteservice.Name = "btndeleteservice"
        Me.btndeleteservice.Size = New System.Drawing.Size(177, 42)
        Me.btndeleteservice.TabIndex = 2
        Me.btndeleteservice.Text = "🗑️  Delete Service"
        Me.btndeleteservice.UseVisualStyleBackColor = False
        '
        'btnaddservice
        '
        Me.btnaddservice.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnaddservice.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnaddservice.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnaddservice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaddservice.ForeColor = System.Drawing.Color.White
        Me.btnaddservice.Location = New System.Drawing.Point(13, 12)
        Me.btnaddservice.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnaddservice.Name = "btnaddservice"
        Me.btnaddservice.Size = New System.Drawing.Size(177, 40)
        Me.btnaddservice.TabIndex = 0
        Me.btnaddservice.Text = "➕ Add Service"
        Me.btnaddservice.UseVisualStyleBackColor = False
        '
        'lvservices
        '
        Me.lvservices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.id, Me.sname, Me.price, Me.sstatus})
        Me.lvservices.FullRowSelect = True
        Me.lvservices.GridLines = True
        Me.lvservices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvservices.Location = New System.Drawing.Point(18, 41)
        Me.lvservices.Name = "lvservices"
        Me.lvservices.Size = New System.Drawing.Size(464, 290)
        Me.lvservices.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvservices.TabIndex = 0
        Me.lvservices.TabStop = False
        Me.lvservices.UseCompatibleStateImageBehavior = False
        Me.lvservices.View = System.Windows.Forms.View.Details
        '
        'id
        '
        Me.id.Text = "ID"
        '
        'sname
        '
        Me.sname.Text = "Service"
        Me.sname.Width = 204
        '
        'price
        '
        Me.price.Text = "Price"
        Me.price.Width = 80
        '
        'sstatus
        '
        Me.sstatus.Text = "Status"
        Me.sstatus.Width = 112
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "List of Services"
        '
        'DlgServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(752, 466)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgServices"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgServices"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btneditservice As System.Windows.Forms.Button
    Friend WithEvents btndeleteservice As System.Windows.Forms.Button
    Friend WithEvents btnaddservice As System.Windows.Forms.Button
    Friend WithEvents lvservices As System.Windows.Forms.ListView
    Friend WithEvents id As System.Windows.Forms.ColumnHeader
    Friend WithEvents sname As System.Windows.Forms.ColumnHeader
    Friend WithEvents price As System.Windows.Forms.ColumnHeader
    Friend WithEvents sstatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
