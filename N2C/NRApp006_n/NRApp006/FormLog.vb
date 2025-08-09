Public Class FormLog
    Dim ClassPostgeDB As New ClassPostgeDB
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim ro As Integer = 0
        Dim dt As DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()



        strSQL = "SELECT id, nm ,mn, entry_day FROM " & schema & "t_log order by entry_day desc"
        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.ToolStripStatusLabel1.Text = dt.Rows.Count.ToString & "件"


        Me.DataGridView1.DataSource = dt
        ro = settextColumn(Me.DataGridView1, ro, "id", "ID", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "nm", "氏名", 120, True)
        ro = settextColumn(Me.DataGridView1, ro, "mn", "メニュー", 200, True)
        ro = settextColumn(Me.DataGridView1, ro, "entry_day", "時間", 120, True)

        Me.DataGridView1.AllowUserToAddRows = False

        For ro = 1 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(2).Value.ToUpper = "ERROR" Then
                Me.DataGridView1.Rows(ro).DefaultCellStyle.BackColor = Color.Red

            End If
        Next
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub
End Class