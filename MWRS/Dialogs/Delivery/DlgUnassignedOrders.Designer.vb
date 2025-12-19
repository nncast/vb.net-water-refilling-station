<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgUnassignedOrders
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
        Me.btnadd = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.lvreadyorders = New System.Windows.Forms.ListView()
        Me.oid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.custadd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.orddate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalamount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnadd, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btncancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(419, 340)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(219, 52)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btnadd
        '
        Me.btnadd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnadd.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnadd.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.ForeColor = System.Drawing.Color.White
        Me.btnadd.Location = New System.Drawing.Point(5, 6)
        Me.btnadd.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(99, 40)
        Me.btnadd.TabIndex = 0
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = False
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
        'lvreadyorders
        '
        Me.lvreadyorders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvreadyorders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.oid, Me.custname, Me.custadd, Me.orddate, Me.totalamount, Me.balance})
        Me.lvreadyorders.FullRowSelect = True
        Me.lvreadyorders.GridLines = True
        Me.lvreadyorders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvreadyorders.Location = New System.Drawing.Point(12, 60)
        Me.lvreadyorders.Name = "lvreadyorders"
        Me.lvreadyorders.Size = New System.Drawing.Size(626, 271)
        Me.lvreadyorders.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvreadyorders.TabIndex = 4
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 32)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Orders Ready To Deliver"
        '
        'DlgUnassignedOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(652, 407)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvreadyorders)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgUnassignedOrders"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DlgUnassignedOrders"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents lvreadyorders As System.Windows.Forms.ListView
    Friend WithEvents oid As System.Windows.Forms.ColumnHeader
    Friend WithEvents custname As System.Windows.Forms.ColumnHeader
    Friend WithEvents custadd As System.Windows.Forms.ColumnHeader
    Friend WithEvents orddate As System.Windows.Forms.ColumnHeader
    Friend WithEvents totalamount As System.Windows.Forms.ColumnHeader
    Friend WithEvents balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
