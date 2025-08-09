Public Class FormStokDsp
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click


        Me.Close()

    End Sub

    Private Sub FormStokDsp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        Dim dt As New DataTable

        Me.StartPosition = FormStartPosition.CenterScreen

        'strSQL = "SELECT sinacd, syouhinmie, vari, zaiko, uketukeflg, yoyakuflg, yukouflg, torikomibi, seq, flg FROM t_goodsstock where flg='0' "
        strSQL = "Select  t_goodsstock.sinacd, syouhinmie, vari, zaiko, uketukeflg, yoyakuflg, yukouflg, torikomibi,m_seihin.kijunzaiko ,m_seihin.souko "
        strSQL &= " From " & schema & "t_goodsstock , " & schema & "m_seihin"
        strSQL &= " Where flg ='0'"
        strSQL &= " And t_goodsstock.sinacd = m_seihin.sinacd"


        dt = ClassPostgeDB.SetTable(strSQL)

        'If dt.Columns.Count = 10 Then

        Me.DataGridView1.DataSource = dt
        'Me.DataGridView1.ReadOnly = True
        ''''---------------
        Me.DataGridView1.Columns(0).HeaderText = "商品コード"
        Me.DataGridView1.Columns(1).HeaderText = "商品名"
        Me.DataGridView1.Columns(2).HeaderText = "バリエーション文字列"
        Me.DataGridView1.Columns(3).HeaderText = "在庫数"
        Me.DataGridView1.Columns(4).HeaderText = "入荷お知らせ受付フラグ"
        Me.DataGridView1.Columns(5).HeaderText = "予約商品フラグ"
        Me.DataGridView1.Columns(6).HeaderText = "予約商品自動有効化フラグ"
        Me.DataGridView1.Columns(7).HeaderText = "取り込み日"
        ''Me.DataGridView1.Columns(8).HeaderText = "シーケンス"
        ''Me.DataGridView1.Columns(9).HeaderText = "フラグ" seq, flg ,
        Me.DataGridView1.Columns(8).HeaderText = "基準在庫"
        Me.DataGridView1.Columns(9).HeaderText = "在庫種類"
        'End If
        dt.Clone()

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred(Me.DataGridView1, False)
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        Dim fileName As String
        GetIniFile()
        fileName = FileSave(MaserFolder)
        csvOutDataGred(Me.DataGridView1, fileName, 0, False)
    End Sub
End Class