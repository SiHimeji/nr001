Public Class FormUserLog
    Dim ClassPostgeDB As New ClassPostgeDB

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Disp()
        Dim StrSQL As String
        Me.DataGridView1.ColumnCount = 6
        Me.DataGridView1.Columns(0).HeaderText = "ID"
        Me.DataGridView1.Columns(1).HeaderText = "氏名"
        Me.DataGridView1.Columns(2).HeaderText = "メニューNo"
        Me.DataGridView1.Columns(3).HeaderText = "Next-B画面"
        Me.DataGridView1.Columns(4).HeaderText = "ｵｰﾀﾞｰ画面"
        Me.DataGridView1.Columns(5).HeaderText = "時間"
        Me.DataGridView1.Columns(5).Width = 150

        StrSQL = "Select id, nm, mn, nextb, ordr, entry_day FROM " & schema & "t_user_log"
        ClassPostgeDB.SetDataGredv(StrSQL, Me.DataGridView1)

    End Sub

    Private Sub FormUserLog_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Disp()

    End Sub


    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro <> -1 Then
                If ro >= 0 And Me.DataGridView1.Rows(ro).Cells(0).Value <> "" Then
                    'Dim Fm As New FormUserLogSub
                    FormUserLogSub.UserID = Me.DataGridView1.Rows(ro).Cells(0).Value
                    FormUserLogSub.UserName = Me.DataGridView1.Rows(ro).Cells(1).Value
                    FormUserLogSub.Kengen = ""
                    FormUserLogSub.ShowDialog()
                    Disp()
                End If
            End If
        End If


    End Sub


    Private Sub FormUserLog_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DataGridView1.ReadOnly = True

    End Sub
End Class