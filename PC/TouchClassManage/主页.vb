Imports System.ComponentModel
Imports System.IO

Public Class 主页

    Function DateGet() As String
        DateGet = Format(DateTime.Now, "yyyy,MM,dd")
    End Function

    Function TimeGet() As String
        TimeGet = Format(DateTime.Now, "yyyy/MM/dd hh:mm:ss")
    End Function
    Function FileProg() As String
        Dim text As String
        Try
            Dim fp As StreamReader
            fp = File.OpenText("C:\qd\" + DateGet() + ".apped")
            text = fp.ReadToEnd
            fp.Close()
        Catch e As Exception
            ' Let the user know what went wrong.'
            File.Create("C:\qd\" + DateGet() + ".apped").Dispose()
            Dim fp As StreamReader
            fp = File.OpenText("C:\qd\" + DateGet() + ".apped")
            text = fp.ReadToEnd
            fp.Close()
        End Try
        FileProg = text
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBox1.Text = FileProg()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TextBox2.Text = "" Then
            指纹识别.Enabled = True
            指纹识别.Visible = True
        End If
        While Me.TextBox2.Text <> ""
            Me.TextBox1.Text = Me.TextBox1.Text + ("ID" + Me.TextBox2.Text + "签到于" + TimeGet()) + vbCrLf
            MsgBox("ID" + Me.TextBox2.Text + "签到于" + TimeGet())
            Me.TextBox2.Text = ""
        End While
        Me.CheckBox1.Checked = False
        Me.TextBox2.ReadOnly = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        指纹识别.Enabled = True
        指纹识别.Visible = True
        If Me.TextBox2.Text = "1" Or Me.TextBox2.Text = "2" Or Me.TextBox2.Text = "3" Then
            Me.TextBox2.ReadOnly = Not (CheckBox1.Checked)
        Else
            MsgBox("Must be administrator")
        End If
    End Sub

    Private Sub 信息录入ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 信息录入ToolStripMenuItem.Click
        MsgBox("input")
    End Sub

    Private Sub 信息删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 信息删除ToolStripMenuItem.Click
        MsgBox("output")
    End Sub

    Private Sub 主页_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim mStreamWriter As New System.IO.StreamWriter("C:\qd\" + DateGet() + ".apped")
        mStreamWriter.WriteLine(Me.TextBox1.Text)
        mStreamWriter.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.TextBox2.Text = ""
    End Sub
End Class
