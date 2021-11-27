Public Class 指纹识别
    Private Sub 指纹识别_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("text return 1")
        主页.TextBox2.ReadOnly = True
        Dim ID As String = InputBox("ID")
        Me.Label2.Text = "ID:" + ID
        主页.TextBox2.Text = ID
        Me.Enabled = False
        Me.Close()
    End Sub
End Class