' A short message near the bottom of the window that fades away by itself, so a
' successful save doesn't need an OK click. Click it to dismiss it sooner.
Public Class Toast
    Inherits Form

    Private ReadOnly closeTimer As New Timer With {.Interval = 2500}

    Private Sub New(message As String)
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        StartPosition = FormStartPosition.Manual
        ShowInTaskbar = False
        BackColor = Color.FromArgb(33, 37, 41)
        Opacity = 0

        Dim text As New Label With {.Text = message, .AutoSize = True, .MaximumSize = New Size(480, 0),
                                    .ForeColor = Color.White, .Font = New Font("Segoe UI", 10.0F),
                                    .Location = New Point(18, 12)}
        Controls.Add(text)
        ClientSize = New Size(text.PreferredWidth + 36, text.PreferredHeight + 24)
        AddHandler text.Click, Sub() Close()
        AddHandler Click, Sub() Close()
        AddHandler closeTimer.Tick, Sub() Close()
    End Sub

    ' Showing the message must not take the keyboard away from the form being used,
    ' so it stays on top without ever becoming the active window.
    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Const WS_EX_TOPMOST As Integer = &H8, WS_EX_TOOLWINDOW As Integer = &H80, WS_EX_NOACTIVATE As Integer = &H8000000
            Dim params As CreateParams = MyBase.CreateParams
            params.ExStyle = params.ExStyle Or WS_EX_TOPMOST Or WS_EX_TOOLWINDOW Or WS_EX_NOACTIVATE
            Return params
        End Get
    End Property

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        closeTimer.Dispose()
        MyBase.OnFormClosed(e)
    End Sub

    Public Shared Sub Notify(message As String)
        Dim over As Form = Form.ActiveForm
        Dim area As Rectangle = If(over Is Nothing, Screen.PrimaryScreen.WorkingArea, over.Bounds)
        Dim toast As New Toast(message)
        toast.Show()
        toast.Location = New Point(area.Left + (area.Width - toast.Width) \ 2, area.Bottom - toast.Height - 40)
        toast.Opacity = 0.95
        toast.closeTimer.Start()
    End Sub
End Class
