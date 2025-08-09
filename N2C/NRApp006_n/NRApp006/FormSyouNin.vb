Public Class FormSyouNin

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

    Private Sub FormSyouNin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSystemtoCombo("'10'", Me.ComboBox期間, "")
        Me.ComboBox期間.SelectedIndex = 1
        Me.GroupBox期間.Visible = False
        Me.DateTimePicker期間1.Value = Now().AddMinutes(-12)
        Me.NumericUpDownmax.Minimum = 0
        Me.NumericUpDownmax.Maximum = 10000

        Me.NumericUpDownmax.Value = 200

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        Disp()
    End Sub
    Private Sub Disp()
        Dim strSQL As String = String.Empty
        Dim dt As DataTable
        Dim ro As Integer

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Me.ToolStripStatusLabel1.Text = ""

        strSQL = ""
        strSQL &= "select "
        strSQL &= " v_yuryo_tenken_syuyaku.点検受付番号"
        strSQL &= ",to_char(t_check.チェック日,'YYYY/MM/DD') 品質チェック日"
        strSQL &= ",to_char(t_teisei.完了日,'YYYY/MM/DD')  金額チェック日"
        strSQL &= ",v_yuryo_tenken_syuyaku.第１業務区分内容"
        strSQL &= ",v_yuryo_tenken_syuyaku.第２業務区分内容"
        strSQL &= ",v_yuryo_tenken_syuyaku.回収区分"
        strSQL &= ",v_yuryo_tenken_syuyaku.ステータス"
        strSQL &= ",v_yuryo_tenken_syuyaku.ステータス名"
        strSQL &= ", case when t_teisei.完了='1'     then 'OK'  else ''  end 金額チェック"
        strSQL &= ", case when t_check.チェック ='1' then 'OK'  else ''  end 品質チェック"
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku"
        strSQL &= " inner join " & schema & "t_002  on  t_002.uketukeno != v_yuryo_tenken_syuyaku.点検受付番号"
        strSQL &= " left outer join " & schema & "t_check  on t_check.点検受付番号  = v_yuryo_tenken_syuyaku.点検受付番号"
        strSQL &= " left outer join  " & schema & "t_teisei on t_teisei.点検受付番号 = v_yuryo_tenken_syuyaku.点検受付番号"
        strSQL &= " where v_yuryo_tenken_syuyaku.承認flg  = '0'"
        strSQL &= " and v_yuryo_tenken_syuyaku.ステータス not in ('12','11','22','21','14') "

        If Me.CheckBox料金.Checked Then
            strSQL &= " and t_teisei.完了 = '1'"
        Else
            strSQL &= " and t_teisei.完了 <> '1'"
        End If
        If Me.CheckBox品質.Checked Then
            strSQL &= " and t_check.チェック = '1'"
        Else
            strSQL &= " and t_check.チェック <> '1'"
        End If
        strSQL &= " and ("
        strSQL &= " 		v_yuryo_tenken_syuyaku.無償合計 >0"
        strSQL &= "  		or v_yuryo_tenken_syuyaku.点検料金 >0"
        strSQL &= "  		)"

        If Me.GroupBox期間.Visible Then
            If Me.ComboBox期間.Text <> "" Then
                strSQL &= " and v_yuryo_tenken_syuyaku." & Me.ComboBox期間.Text & " BETWEEN '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
            End If
        End If

        strSQL &= " and  t_teisei.承認出力日 is null"

        strSQL &= " order by v_yuryo_tenken_syuyaku.点検受付番号"

        If Me.NumericUpDownmax.Value > 0 Then
            strSQL &= " LIMIT " & Me.NumericUpDownmax.Value.ToString
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.ToolStripStatusLabel1.Text = dt.Rows.Count

        If dt.Rows.Count > 0 Then

            Me.DataGridView1.DataSource = dt

            ro = 0

            Dim CheckBoxColumn As New DataGridViewCheckBoxColumn()
            CheckBoxColumn.DataPropertyName = "ﾁｪｯｸ"
            CheckBoxColumn.Name = "Column1"
            CheckBoxColumn.HeaderText = "ﾁｪｯｸ"
            Me.DataGridView1.Columns.Add(CheckBoxColumn)
            Me.DataGridView1.Columns(ro).Width = 60
            ro = ro + 1

            ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "受付番号", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "品質チェック日", ”品質チェック日", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "金額チェック日", ”金額チェック日", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "第１業務区分内容", "第１業務区分内容", 120, True)
            ro = settextColumn(Me.DataGridView1, ro, "第２業務区分内容", "第２業務区分内容", 120, True)
            ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "金額チェック", "金額チェック", 100, True)
            ro = settextColumn(Me.DataGridView1, ro, "品質チェック", "品質チェック", 100, True)

            Me.DataGridView1.AllowUserToAddRows = False
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub CheckBox料金_Click(sender As Object, e As EventArgs) Handles CheckBox料金.Click
        Disp期間()
    End Sub

    Private Sub CheckBox品質_Click(sender As Object, e As EventArgs) Handles CheckBox品質.Click
        Disp期間()
    End Sub
    Private Sub Disp期間()
        If Me.CheckBox料金.Checked And Me.CheckBox品質.Checked Then
            Me.GroupBox期間.Visible = False
        Else
            Me.GroupBox期間.Visible = True
        End If
    End Sub

    Private Sub SyouninOUT(uno As String)
        Dim strSQL = "update tenken.t_check  set 承認出力日 = now() where 点検受付番号 = '" & uno & "'"

    End Sub

    Private Sub 全ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全ONToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = True
        Next
        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub 全OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全OFFToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = False
        Next
        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub 反転ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転ToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
        Next
        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        CsvOut(Me.DataGridView1, Me.ToolStripProgressBar1, True)
        Disp()
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        excelOutDataGredSyounin(Me.DataGridView1, True, Me.ToolStripProgressBar1)
        Disp()
    End Sub
End Class