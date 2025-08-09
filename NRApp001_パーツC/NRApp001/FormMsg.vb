Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection

Public Class FormMsg

    Dim mson As Boolean = False

    Private Sub FormMsg_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.Close()
    End Sub

    Private Sub FormMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mson = False

        Me.Label1.Text = " Version[" & Now_Var & "]   "
        Me.Label3.Text = "株式会社　エス・アイ　姫路本社"


        If Environment.Is64BitProcess Then
            Me.Label4.Text = "64bit"
        Else
            Me.Label4.Text = "32bit"
        End If
        Me.Label5.Text = "CPU 数 : " + Environment.ProcessorCount.ToString()
        Me.Label6.Text = "DB = " & CnString.Substring(CnString.IndexOf("Server") + 6, CnString.IndexOf("Port") - CnString.IndexOf("Server") + 3)
        Me.TextBox1.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Templates)


        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        ListBox1.Items.Add(Info.CompanyName)
        ListBox1.Items.Add(Info.ProductName)
        ListBox1.Items.Add(Info.ProductVersion)
        ListBox1.Items.Add(Info.Comments)
        ListBox1.Items.Add(Info.FileDescription)
        ListBox1.Items.Add(Info.LegalCopyright)
        ListBox1.Items.Add(Info.LegalTrademarks)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Close()
    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Buttonアップデート_Click(sender As Object, e As EventArgs) Handles Buttonアップデート.Click
        Dim ApUp As ClassTransV4 = New ClassTransV4()

        ApUp.TransExecV3(Getasmprd(), Now_Var)
        Application.Exit()
    End Sub

    Private Sub FormMsg_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        'Me.BackColor = Color.Coral
    End Sub

    Private Sub FormMsg_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        If mson Then
            Me.Close()
        End If
    End Sub


    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles ListBox1.MouseEnter
        mson = True

    End Sub
End Class