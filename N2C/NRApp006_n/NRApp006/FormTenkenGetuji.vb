Public Class FormTenkenGetuji
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim DbWork As New DataTable

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
        Select Case ToolStripComboBox1.SelectedIndex
            Case 0
                Me.DataGridView1.Visible = True
                Me.DataGridView2.Visible = False
                Kobetu()
            Case 2
                Me.DataGridView1.Visible = True
                Me.DataGridView2.Visible = False
                Man別不備()
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub FormTenkenGetuji_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ToolStripComboBox1.SelectedIndex = -1
        ToolStripComboBoxYYMM.SelectedIndex = -1

        DataGridViewSet()

        ToolStripComboBox1.Enabled = True
        ToolStripComboBoxYYMM.Enabled = False
        検索ToolStripMenuItem.Enabled = False
        出力ToolStripMenuItem.Enabled = False
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        Dim d As DateTime

        DataGridViewSet()

        Select Case ToolStripComboBox1.SelectedIndex
            Case 0
                ToolStripComboBoxYYMM.Enabled = True
                検索ToolStripMenuItem.Enabled = True
                出力ToolStripMenuItem.Enabled = True

                ToolStripComboBoxYYMM.Items.Clear()

                d = DateTime.Today
                For i As Integer = 1 To 13
                    ToolStripComboBoxYYMM.Items.Add(d.ToString("yyyy年MM月"))
                    d = d.AddMonths(-1)
                Next
                ToolStripComboBoxYYMM.SelectedIndex = 0

            Case 1
                ToolStripComboBoxYYMM.Enabled = True
                検索ToolStripMenuItem.Enabled = False
                出力ToolStripMenuItem.Enabled = True

                ToolStripComboBoxYYMM.Items.Clear()

                d = DateTime.Today
                For i As Integer = 1 To 13
                    ToolStripComboBoxYYMM.Items.Add(d.ToString("yyyy年"))
                    d = d.AddYears(-1)
                Next

                ToolStripComboBoxYYMM.SelectedIndex = 0
            Case 2

                ToolStripComboBoxYYMM.Enabled = True
                検索ToolStripMenuItem.Enabled = True
                出力ToolStripMenuItem.Enabled = True

                ToolStripComboBoxYYMM.Items.Clear()

                d = DateTime.Today
                For i As Integer = 1 To 13
                    ToolStripComboBoxYYMM.Items.Add(d.ToString("yyyy年MM月"))
                    d = d.AddMonths(-1)
                Next
                ToolStripComboBoxYYMM.SelectedIndex = 0


            Case Else
                ToolStripComboBoxYYMM.Enabled = False
                検索ToolStripMenuItem.Enabled = False
                出力ToolStripMenuItem.Enabled = False
        End Select

    End Sub

    Private Sub Kobetu()
        Dim strSQL As String = String.Empty
        Dim dtSrc As DataTable
        Me.DataGridView1.DataSource = Nothing

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()


        strSQL &= "select "
        strSQL &= " a.商圏 "
        strSQL &= ",a.店名略称 "
        strSQL &= ",a.サービスマン名 "
        strSQL &= ",b.点検受付番号 "
        strSQL &= ",a.製品名"
        strSQL &= ",b.不備内容 "
        strSQL &= ",b.チェック "
        strSQL &= ",b.再訪問指示日 "
        strSQL &= ",b.再訪問指示内容 "
        strSQL &= ",to_char(b.確認完了日,'yyyy/mm/dd') 確認完了日 "
        strSQL &= " from " & schema & "v_tenken_kekka a ," & schema & "t_check b"
        strSQL &= " where a.受付ＮＯ  = b.点検受付番号 "
        strSQL &= " and b.チェック日 between '" & CDate(Me.ToolStripComboBoxYYMM.Text & "1日").ToString("yyyy/MM/dd") & "' and '" & DateAdd("d", -1, DateAdd("M", 1, CDate(Me.ToolStripComboBoxYYMM.Text & "1日").ToString("yyyy/,MM/dd"))) & "'"
        strSQL &= " order by a.商圏 , a.店名略称"

        dtSrc = ClassPostgeDB.SetTable(strSQL)
        DbWork = dtSrc.Copy

        DataGridViewSet()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dtSrc
        Dim ro As Integer = 0


        ro = settextColumn(Me.DataGridView1, ro, "商圏", "支店", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "店名略称", "ｻｰﾋﾞｽｼｮｯﾌﾟ", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "サービスマン名", "ｻｰﾋﾞｽﾏﾝ", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "受付番号", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "製品名", "製品名", 140, True)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "不備内容", "不備内容", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示日", "再訪問指示日", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示内容", "再訪問指示内容", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 100, True)

        Me.DataGridView1.AllowUserToAddRows = False
        'Me.DataGridView1.ReadOnly = True

        Exit Sub

    End Sub
    Private Function settextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean) As Integer

        Dim textColumn As New DataGridViewTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        ro = ro + 1
        Return ro

    End Function

    Private Sub DataGridViewSet()

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView2.DataSource = Nothing
        Me.DataGridView2.Rows.Clear()
        Me.DataGridView2.Columns.Clear()
    End Sub
    Private Sub Shitenbetu2()

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        excelOutDataGred6(Me.DataGridView2, True, Me.ToolStripProgressBar1, Me.ToolStripComboBoxYYMM.Text)
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub
    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        Select Case ToolStripComboBox1.SelectedIndex
            Case 0 '個別
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                excelOutDataGred8(DbWork, True, Me.ToolStripProgressBar1, Me.ToolStripComboBoxYYMM.Text)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("出力しました")

            Case 1 '支店
                Me.DataGridView2.Visible = True
                Me.DataGridView1.Visible = False
                Shitenbetu2()
                MsgBox("出力しました")
            Case 2
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                'excelOutDataGred(Me.DataGridView1)
                excelOutDataGred2(Me.DataGridView1, False, Me.ToolStripProgressBar1, 0)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("出力しました")
            Case Else
                Exit Sub
        End Select

    End Sub
    Private Function DataTableSwapXY2(ByVal src As DataTable, ByVal newColName As String) As DataTable

        Dim ret As New DataTable(src.TableName)
        '列の追加
        ret.Columns.Add(newColName)
        For y As Integer = 0 To src.Rows.Count - 1
            ret.Columns.Add(src.Rows(y)(0))
        Next
        '列を行に変換
        For x As Integer = 2 To src.Columns.Count - 1

            Dim dr As DataRow = ret.NewRow()
            dr(newColName) = src.Columns(x).ColumnName

            For y As Integer = 0 To src.Rows.Count - 1
                dr(ret.Columns(y + 1).ColumnName) = src.Rows(y)(x)
            Next
            ret.Rows.Add(dr)
        Next

        DataTableSwapXY2 = ret

    End Function
    Private Sub Man別不備()
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Integer = 0
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = "select vtk.店コード"  '0
        strSQL &= "	,vtk.サービスマンコード"   '1
        strSQL &= "    ,vtk.商圏 " '2
        strSQL &= "    ,vtk.店名略称 " '3
        strSQL &= "	,vtk.サービスマン名 " '4
        strSQL &= "	, count(*) 品質チェック件数" '5
        strSQL &= " from  " & schema & "t_check tc ," & schema & "v_tenken_kekka vtk "
        strSQL &= " where tc.点検受付番号 =vtk.受付ＮＯ "
        strSQL &= " and  tc.チェック in('1','2','3')"
        strSQL &= " and   to_char(tc.チェック日,'yyyyMM')='" & Me.ToolStripComboBoxYYMM.Text.Replace("年", "").Replace("月", "") & "'  "
        strSQL &= " GROUP BY vtk.店コード"
        strSQL &= "	,vtk.サービスマンコード"
        strSQL &= "	,vtk.サービスマン名"
        strSQL &= "	,vtk.店名略称 "
        strSQL &= "	,vtk.商圏 "
        strSQL &= " ORDER BY vtk.店コード ,vtk.サービスマンコード"

        dt = ClassPostgeDB.SetTable(strSQL)
        dt.Columns.Add("不備件数")  '6
        dt.Columns.Add("内再訪問件数")   '7
        dt.Columns.Add("内軽微")   '8
        dt.Columns.Add("不備率")   '9

        dt = Getマン別(dt)

        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = settextColumn(Me.DataGridView1, ro, "店コード", "店コード", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "サービスマンコード", "サービスマンコード", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "商圏", "商圏", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "店名略称", "店名略称", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "サービスマン名", "サービスマン名", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "品質チェック件数", "品質チェック件数", 80, True)

        ro = settextColumn(Me.DataGridView1, ro, "不備件数", "不備件数", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "内再訪問件数", "内再訪問件数", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "内軽微", "内軽微", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "不備率", "不備率", 80, True)



        Me.DataGridView1.AllowUserToAddRows = False
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Function Getマン別不備(shopcd As String, mancd As String) As DataTable
        Dim strSQL As String
        Dim dt As DataTable

        strSQL = "select t.チェック ,count(*)"
        strSQL &= " from  " & schema & "t_check t ," & schema & "v_tenken_kekka v"
        strSQL &= " where t.点検受付番号 =v.受付ＮＯ"
        strSQL &= " and  to_char(t.チェック日,'yyyyMM')='" & Me.ToolStripComboBoxYYMM.Text.Replace("年", "").Replace("月", "") & "'  "
        strSQL &= " and t.チェック in ('2','3')"
        strSQL &= " and v.店コード = '" & shopcd & "'"
        strSQL &= " and v.サービスマンコード = '" & mancd & "'"
        strSQL &= " group by t.チェック"
        strSQL &= " order by t.チェック"
        dt = ClassPostgeDB.SetTable(strSQL)

        Return dt
    End Function


    Private Function Getマン別(dt As DataTable) As DataTable
        Dim x As Integer
        Dim dta As DataTable

        Me.ToolStripProgressBar1.Minimum = 0
        Me.ToolStripProgressBar1.Maximum = dt.Rows.Count - 1
        Me.ToolStripProgressBar1.Value = 0

        For x = 0 To dt.Rows.Count - 1
            Me.ToolStripProgressBar1.Value = x
            dta = Getマン別不備(dt.Rows(x).Item(0).ToString(), dt.Rows(x).Item(1).ToString())
            dt.Rows(x).Item(6) = 0
            dt.Rows(x).Item(7) = 0
            dt.Rows(x).Item(8) = 0
            dt.Rows(x).Item(9) = 0
            For Each ro As DataRow In dta.Rows
                If ro(0).ToString() = "2" Then
                    dt.Rows(x).Item(8) = ro(1)
                ElseIf ro(0).ToString() = "3" Then
                    dt.Rows(x).Item(9) = ro(1)
                End If
            Next

            dt.Rows(x).Item(6) = Integer.Parse(dt.Rows(x).Item(7)) + Integer.Parse(dt.Rows(x).Item(8))
            '不備率計算
            If (Double.Parse(dt.Rows(x).Item(6)) = 0) Or (Double.Parse(dt.Rows(x).Item(5)) = 0) Then
                dt.Rows(x).Item(9) = "0%"

            Else

                dt.Rows(x).Item(9) = (Double.Parse(dt.Rows(x).Item(6)) / Double.Parse(dt.Rows(x).Item(5))) * 100
                dt.Rows(x).Item(9) = Math.Round(Double.Parse(dt.Rows(x).Item(9)), 2, MidpointRounding.AwayFromZero).ToString & "%"

            End If


        Next
        Me.ToolStripProgressBar1.Value = 0
        Return dt
    End Function

End Class