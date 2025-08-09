Public Class FormTenkenKekkaMeisai
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB
    Public Property UserID As String
        Get
            UserID = _UserID
        End Get
        Set(value As String)
            _UserID = value
        End Set
    End Property

    Public Property Kengen As String
        Get
            Kengen = _Kengen
        End Get
        Set(value As String)
            _Kengen = value
        End Set
    End Property
    Public Property UserName As String
        Get
            UserName = _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        Me.取り消しToolStripMenuItem.Visible = False
        If Me.RadioButton1.Checked Then
            meisai()
        Else
            kekka()
            Me.取り消しToolStripMenuItem.Visible = True
        End If
        Me.ToolStripStatusLabel1.Text = Me.DataGridView1.Rows.Count & "件"
    End Sub
    Private Sub meisai()
        Dim strSQL As String
        Dim dt As DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        strSQL = "select t.点検受付番号 ,t.点検 ,t.不備内容 ,t.再訪問指示内容 ,t.再訪問指示日 ,t.確認完了日 "
        strSQL &= " from " & schema & "t_tenken_fubi t where to_char(t.更新日,'yyyy/MM/dd') ='" & Me.DateTimePicker1.Value.ToShortDateString & "' and t.反映フラグ ='1'"
        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.AllowUserToAddRows = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Sub kekka()
        Dim strSQL As String
        Dim dt As DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        strSQL = "Select  t.点検受付番号 ,t.チェック ,t.不備内容 ,t.再訪問指示内容 ,t.再訪問指示日 ,t.確認完了日 "
        strSQL &= "From " & schema & "t_check t Where to_char(t.チェック日,'yyyy/MM/dd') ='" & Me.DateTimePicker1.Value.ToShortDateString & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.AllowUserToAddRows = False
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MsgBox("出力しました")
        End If

    End Sub

    Private Sub RadioButton1_MouseClick(sender As Object, e As MouseEventArgs) Handles RadioButton1.MouseClick
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Me.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub RadioButton2_MouseClick(sender As Object, e As MouseEventArgs) Handles RadioButton2.MouseClick
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Me.ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub FormTenkenKekkaMeisai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtToday As DateTime = DateTime.Today
        Me.DateTimePicker1.Value = dtToday
        Me.取り消しToolStripMenuItem.Visible = False
        Me.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub 取り消しToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取り消しToolStripMenuItem.Click
        Dim x As Integer
        Dim strSQL As String
        Dim UkeNo As String

        Dim result As DialogResult = MessageBox.Show("表示されている全てのチェックを全て削除して良いですか？", "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2)
        If result <> DialogResult.OK Then
            Return
        End If
        Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count - 1

        For x = 0 To Me.DataGridView1.Rows.Count - 1
            UkeNo = Me.DataGridView1.Rows(x).Cells(0).Value

            strSQL = "Delete From " & schema & "t_check "
            strSQL &= " WHERE 点検受付番号='" & UkeNo & "'"
            ClassPostgeDB.EXEC(strSQL)

            '------- 点検チェック
            strSQL = "Update " & schema & "v_tenken_kekka set endflag = '0' where ""受付ＮＯ"" ='" & UkeNo & "'"
            ClassPostgeDB.EXEC(strSQL)

            strSQL = "Update  " & schema & "t_tenken_fubi set 反映フラグ = NULL where 点検受付番号 ='" & UkeNo & "'"
            ClassPostgeDB.EXEC(strSQL)

            Me.ToolStripProgressBar1.Value = x

        Next
        kekka()
        Me.ToolStripProgressBar1.Value = 0

    End Sub


End Class