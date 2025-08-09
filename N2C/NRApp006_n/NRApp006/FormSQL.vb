Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Public Class FormSQL
    Dim ClassPostgeDB As New ClassPostgeDB

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs)
        Me.TextBoxFileName1.Text = FileSave("C:\*.*")
    End Sub

    Private Sub 実行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 実行ToolStripMenuItem.Click

    End Sub

    Private Sub Button検索_Click_1(sender As Object, e As EventArgs) Handles Button検索.Click

        Me.TextBoxFileName1.Text = Filesentaku("c:\")

    End Sub

    Private Sub FormSQL_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = Now_Ver & "【" & Cmp_day & "】" & vAsm.v説明
        Me.TextBoxFileName1.Text = ""
    End Sub


    Private Sub ファイルからToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ファイルからToolStripMenuItem.Click
        Dim strSQL As String
        If Me.TextBoxFileName1.Text = "" Then
            MessageBox.Show("ファイル選択されていません")
        Else
            Me.ListBoxSQL.Items.Clear()

            Using sr As New System.IO.StreamReader(Me.TextBoxFileName1.Text, System.Text.Encoding.GetEncoding("shift_jis"))
                Do While Not sr.EndOfStream
                    strSQL = sr.ReadLine
                    Me.ListBoxSQL.Items.Add(strSQL)
                    System.Windows.Forms.Application.DoEvents()
                    If ClassPostgeDB.EXEC(strSQL) = False Then
                        If MsgBox("中断しますか", vbYesNo) = vbYes Then
                            Exit Sub
                        End If
                    End If
                Loop
            End Using
        End If

    End Sub

    Private Sub SQL実行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQL実行ToolStripMenuItem.Click
        Dim dt As DataTable
        Dim rowloop As Integer
        Dim colloop As Integer
        Dim msg As String

        Me.ListBoxSQL.Items.Clear()

        dt = ClassPostgeDB.SetTable(Me.TextBoxSQL.Text)

        For rowloop = 0 To dt.Rows.Count - 1

            msg = ""
            For colloop = 0 To dt.Columns.Count - 1
                msg &= " " & dt.Rows(rowloop).Item(colloop).ToString()
            Next
            Me.ListBoxSQL.Items.Add(msg)

        Next

        Me.ListBoxSQL.Items.Add("実行しました")
    End Sub
    Private Function NextVersion(nVer As String)
        '1.0.0.0 →　1.0.0.1　 →　1.0.0.99　 →　1.0.1.0
        Dim Nextver(4) As Integer
        Dim NowVer() As String = nVer.Split(".")

        Nextver(0) = Integer.Parse(NowVer(0))
        Nextver(1) = Integer.Parse(NowVer(1))
        Nextver(2) = Integer.Parse(NowVer(2))
        Nextver(3) = Integer.Parse(NowVer(3)) + 1
        If Nextver(3) > 99 Then
            Nextver(3) = 0
            Nextver(2) = Nextver(2) + 1
            If Nextver(2) > 99 Then
                Nextver(2) = 0
                Nextver(1) = Nextver(1) + 1
                If Nextver(1) > 99 Then
                    Nextver(1) = 0
                    Nextver(0) = Nextver(0) + 1
                End If
            End If
        End If

        Return Nextver(0).ToString() & "." & Nextver(1).ToString() & "." & Nextver(2).ToString() & "." & Nextver(3).ToString()

    End Function

    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click

        Dim msg As String
        Dim strSQL As String
        Dim nextVer As String

        Me.ListBoxSQL.Items.Clear()
        strSQL = "SELECT ver FROM " & schema & "m_ver"
        msg = "UPDATE " & schema & "m_ver SET ver='"
        nextVer = ClassPostgeDB.DbSel(strSQL)

        msg &= NextVersion(nextVer) & "'"

        Me.TextBoxSQL.Text = msg
        Me.ListBoxSQL.Items.Add("現在のバージョンは" & nextVer)


    End Sub
End Class