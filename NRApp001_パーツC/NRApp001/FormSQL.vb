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
        Me.Text = Now_Var & "【" & Cmp_day & "】"
        Me.TextBoxFileName1.Text = ""
    End Sub


    Private Sub アクセスログToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles アクセスログToolStripMenuItem.Click
        Dim strSQL As String
        Dim rowloop As Integer
        Dim msg As String
        Dim dt As DataTable
        strSQL = "SELECT id, nm, mn, entry_day FROM " & schema & "t_log order by entry_day desc"
        dt = ClassPostgeDB.SetTable(strSQL)
        For rowloop = 0 To dt.Rows.Count - 1

            msg = ""
            msg &= Leftstring(dt.Rows(rowloop).Item(0).ToString(), 20, " ")
            msg &= "  " & Leftstring(dt.Rows(rowloop).Item(1).ToString(), 20, " ")
            msg &= "  " & Leftstring(dt.Rows(rowloop).Item(2).ToString(), 10, " ")
            msg &= "  " & Leftstring(dt.Rows(rowloop).Item(3).ToString(), 20, " ")

            Me.ListBoxSQL.Items.Add(msg)

        Next

    End Sub

    Private Sub ファイルからToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ファイルからToolStripMenuItem.Click
        Dim strSQL As String
        If Me.TextBoxFileName1.Text = "" Then
            MessageBox.Show("ファイル選択されていません")
        Else
            Me.ListBoxSQL.Items.Clear()
            ClassPostgeDB.DbOpen()
            ClassPostgeDB.BeginTrans()
            Try
                Using sr As New System.IO.StreamReader(Me.TextBoxFileName1.Text, System.Text.Encoding.GetEncoding("shift_jis"))
                    Do While Not sr.EndOfStream
                        strSQL = sr.ReadLine
                        Me.ListBoxSQL.Items.Add(strSQL)
                        System.Windows.Forms.Application.DoEvents()
                        ClassPostgeDB.EXEC_tr(strSQL)
                    Loop
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                ClassPostgeDB.Rollback()
                ClassPostgeDB.DbClose()

                Return
            End Try
            ClassPostgeDB.Commit()
            ClassPostgeDB.DbClose()
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


    Private Sub TESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TESTToolStripMenuItem.Click

        Dim a As String = Zeinuki("605")
    End Sub
End Class