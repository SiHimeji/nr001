Public Class FormMstComento
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
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
    '-------------------------------------------------------------------------
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Disp()
        Dim strSQL As String

        If Me.ComboBox点検項目名.Text = "" Then
            strSQL = "select  seq, bikou ,naiyou  ,naiyou2 from " & schema & "m_system  where kbn ='110' order by bikou"
        Else
            strSQL = "select  seq, bikou ,naiyou , naiyou2 from " & schema & "m_system  where kbn ='110' and bikou  ='" & Me.ComboBox点検項目名.Text & "' order by bikou"

        End If

        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.AllowUserToAddRows = False

        strSQL = "select  COALESCE(max(seq),'0')  from " & schema & "m_system  where kbn ='110' "
        Me.NumericUpDownNo.Value = Integer.Parse(ClassPostgeDB.DbSel(strSQL)) + 1
        'Me.NumericUpDownNo.Value = "0"
        Me.TextBox内容.Text = ""
        Me.TextBox検索条件.Text = ""
    End Sub

    Private Sub FormMstComento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        strSQL = "select m.naiyou ,m.naiyou2  from " & schema & "m_system m where m.kbn ='102' order by m.seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox点検項目名, strSQL)

        Disp()


    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String
        strSQL = "delete  from " & schema & "m_system where kbn ='110'  and seq = '" & Me.NumericUpDownNo.Value.ToString & "'"
        ClassPostgeDB.EXEC(strSQL)
        Disp()
    End Sub
    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim ret As String
        If Me.NumericUpDownNo.Value.ToString = "" Then

            strSQL = "select  COALESCE(max(seq),'0')  from " & schema & "m_system  where kbn ='110' "
            Me.NumericUpDownNo.Value = Integer.Parse(ClassPostgeDB.DbSel(strSQL)) + 1

        End If

        strSQL = "select  count(*)  from " & schema & "m_system  where kbn ='110'  and seq = '" & Me.NumericUpDownNo.Value.ToString & "'"
        ret = ClassPostgeDB.DbSel(strSQL)
        If Ret = "0" Then
            strSQL = "INSERT INTO " & schema & "m_system (kbn, seq, naiyou, naiyou2,bikou ,koumoku,atai, jouken, entry_day,update_day, entry_sya) VALUES("
            strSQL &= " '110'"
            strSQL &= " ,'" & Me.NumericUpDownNo.Value.ToString & "'"
            strSQL &= " ,'" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
            strSQL &= " ,'" & Me.TextBox検索条件.Text.TrimEnd.ToString & "'"
            strSQL &= " ,'" & Me.ComboBox点検項目名.Text.ToString & "'"
            strSQL &= " ,''"
            strSQL &= " ,''"
            strSQL &= " ,''"
            strSQL &= " ,now()"
            strSQL &= " ,now()"
            strSQL &= " ,'" & UserName & "'"
            strSQL &= " )"

        Else
            Dim result As DialogResult = MessageBox.Show("上書しますか？", "確認",
                 MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Exclamation,
                 MessageBoxDefaultButton.Button2)

            If result = DialogResult.OK Then
                strSQL = "UPDATE " & schema & "m_system SET "
                strSQL &= " naiyou2 = '" & Me.TextBox検索条件.Text.TrimEnd.ToString & "'"
                strSQL &= ",naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
                strSQL &= ",bikou = '" & Me.ComboBox点検項目名.Text.ToString & "'"
                strSQL &= ",koumoku = ''"
                strSQL &= ",atai  = ''"
                strSQL &= ",jouken =''"

                strSQL &= ",update_day = now() "
                strSQL &= ",entry_sya = '" & UserName & "'"
                strSQL &= " WHERE  kbn ='110' and seq = '" & Me.NumericUpDownNo.Value.ToString & "'"
            Else
                Return
            End If
        End If

        If ClassPostgeDB.EXEC(strSQL) Then
            MessageBox.Show("更新しました")
            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
        Else
            MessageBox.Show("更新エラーです")
        End If

        Disp()

    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then

                Me.NumericUpDownNo.Value = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox内容.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
                Me.TextBox検索条件.Text = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString
                Me.ComboBox点検項目名.Text = Me.DataGridView1.Rows(ro).Cells(1).Value

            End If
        End If

    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred2(Me.DataGridView1, False, Me.ToolStripProgressBar1, 0)
    End Sub

    Private Sub ComboBox点検項目名_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox点検項目名.SelectedIndexChanged
        Disp()
    End Sub
End Class