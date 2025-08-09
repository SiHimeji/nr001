Public Class FormAPSyouhiZei
    Dim ClassPostgeDB As New ClassPostgeDB

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


    Private Sub FormAPSyouhiZei_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBox安心プラン契約番号.Text = ""
        Me.Label受付番号.Text = ""
    End Sub
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("出力するデータがありません。")
            Exit Sub
        End If

        'EXCELに出力
        excelOutDataGred4(Me.DataGridView1, False, Me.ToolStripProgressBar1, 2)

    End Sub

    Private Sub 一覧表示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 一覧表示ToolStripMenuItem.Click
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Integer = 0

        strSQL = "select "
        strSQL &= " s.承認番号 , s.点検受付番号 ,tk.特別消費税フラグ "
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku As s "
        strSQL &= " left outer join " & schema & "t_kaisyu  As tk On s.点検受付番号 = tk.uketukeno "
        strSQL &= " WHERE "
        strSQL &= " tk.特別消費税フラグ = '1'"
        strSQL &= " order by s.承認番号 asc"

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.Rows.Clear()
            Me.DataGridView1.Columns.Clear()

            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = dt

            ro = 0
            ro = settextColumn(Me.DataGridView1, ro, "承認番号", "契約番号", 130, True)                 '0
            ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "受付番号", 140, True)             '1
            ro = settextColumn(Me.DataGridView1, ro, "特別消費税フラグ", "特別消費税フラグ", 130, True) '2

            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)
        End If
    End Sub


    Private Sub 取込みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取込みToolStripMenuItem.Click
        Dim msgRt As DialogResult

        msgRt = MessageBox.Show("安心プラン契約番号データを取込みます。" & vbCrLf & vbCrLf &
                                "【注意】取込みファイルが開いている場合は終了してください", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgRt = DialogResult.No Then
            Exit Sub
        End If

        '----------EXCELファイル選択---------
        Dim strFile As String                                   '選択ファイル
        Dim MaserFolder As String = ""                          '初期フォルダ（未設定の時現在のフォルダ）

        strFile = FilesentakuEXELS(MaserFolder)
        If strFile.Trim = "" Then
            Exit Sub
        Else
            If System.IO.Path.GetExtension(strFile).Replace(".", "") <> "xlsx" Then
                MessageBox.Show("EXCELファイル以外が選択されています")
                Exit Sub
            End If
        End If

        '----------EXCELファイル取込み・一覧表に表示---------
        Cursor.Current = Cursors.WaitCursor

        Dim ClassExcelToDataTable As New ClassExcelToDataTable     'クラス宣言
        Dim ExcelDt As DataTable = ClassExcelToDataTable.ExcelToDataTable(strFile, "", 1)

        '取り込みファイルの件数チェック
        If ExcelDt.Rows.Count = 0 Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("取込み出来ませんでした")
            Exit Sub
        End If
        '取り込みファイルのヘッダー存在チェック
        Dim clmName As String = ""
        For Each clm As DataColumn In ExcelDt.Columns
            If clm.ColumnName = "CIM契約番号" Then
                clmName = clm.ColumnName
            End If
        Next
        If clmName = "" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("安心プラン契約番号以外のファイルが選択されています")
            Exit Sub
        End If

        '一覧表表示
        disp(ExcelDt)

        Cursor.Current = Cursors.Default

        MessageBox.Show("内容を確認し「更新」を行ってください。")
    End Sub

    Private Sub 一括更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 一括更新ToolStripMenuItem.Click

        '-------一覧に受付番号を書込み
        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count - 1
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        For row As Integer = 0 To DataGridView1.Rows.Count - 1
            ToolStripProgressBar1.Value = row
            If Me.DataGridView1.Rows(row).Cells(1).Value <> Nothing Then
                '更新処理
                Koushin(Me.DataGridView1.Rows(row).Cells(1).Value.ToString.Trim)
            End If
        Next
        MessageBox.Show("更新完了")
        ToolStripProgressBar1.Value = 0

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        Dim strSQL As String
        Dim dt As DataTable

        Me.Label受付番号.Text = ""

        strSQL = "select 点検受付番号 from " & schema & "v_yuryo_tenken_syuyaku where 承認番号 = '" & TextBox安心プラン契約番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            For Each row As DataRow In dt.Rows
                Me.Label受付番号.Text = row("点検受付番号").ToString
            Next
        Else
            MessageBox.Show("入力した契約番号が正しくありません")
        End If

    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        'DB更新
        Koushin(Me.Label受付番号.Text.Trim)

        MessageBox.Show("更新完了")

        Me.TextBox安心プラン契約番号.Text = ""
        Me.Label受付番号.Text = ""
    End Sub

    Private Sub disp(Dt1 As DataTable)
        Dim strSQL As String
        Dim ro As Integer = 0

        '------一覧に表示
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = Dt1

        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "CIM契約番号", "契約番号", 140, True)        '0

        '<一覧表に受付番号追加>
        Dim TextColumn1 As New DataGridViewTextBoxColumn()
        TextColumn1.DataPropertyName = "受付番号"                                             '1
        TextColumn1.Name = "Column1"
        TextColumn1.HeaderText = "受付番号"
        Me.DataGridView1.Columns.Add(TextColumn1)
        Me.DataGridView1.Columns(1).Width = 150

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        '-------一覧に受付番号を書込み
        If DataGridView1.Rows.Count > 0 Then
            Dim dt2 As DataTable

            ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count - 1
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Value = 0
            ToolStripProgressBar1.Step = 1

            For row1 As Integer = 0 To DataGridView1.Rows.Count - 1
                ToolStripProgressBar1.Value = row1

                strSQL = "select 点検受付番号 from " & schema & "v_yuryo_tenken_syuyaku where 承認番号 = '" & Me.DataGridView1.Rows(row1).Cells(0).Value.ToString.Trim & "'"
                dt2 = ClassPostgeDB.SetTable(strSQL)

                If dt2.Rows.Count = 1 Then
                    For Each row2 As DataRow In dt2.Rows
                        Me.DataGridView1.Rows(row1).Cells(1).Value = row2("点検受付番号").ToString
                    Next
                End If
            Next
            ToolStripProgressBar1.Value = 0
        End If

    End Sub

    Private Sub Koushin(Uno As String)
        Dim strSQL As String
        Dim dt As DataTable

        strSQL = "select 特別消費税フラグ from " & schema & "t_kaisyu where uketukeno = '" & Uno.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 0 Then
            strSQL = "INSERT INTO " & schema & "t_kaisyu "
            strSQL &= "( "
            strSQL &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno      , 請求書再発行日     , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
            strSQL &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
            strSQL &= " 決裁書発行日           , ss請求      , 未回収架電確認日      , 確認者 , 備考 ,色, 入金予定日担当者 , 残明細削除フラグ, "
            strSQL &= " 更新日 , 更新者 , 特別消費税フラグ "
            strSQL &= ")"
            strSQL &= "VALUES("
            strSQL &= "   NULL"
            strSQL &= " , NULL"
            strSQL &= " , '' "
            strSQL &= " , '" & Uno.Trim & "' "         '受付番号
            strSQL &= " , NULL "
            strSQL &= " , NULL "
            strSQL &= " , NULL "
            strSQL &= " , '' "
            strSQL &= " , NULL "
            strSQL &= " , '' "
            strSQL &= " , NULL "
            strSQL &= " , NULL "
            strSQL &= " , NULL "
            strSQL &= " , '' "
            strSQL &= " , NULL  "
            strSQL &= " , '' "
            strSQL &= " , NULL "
            strSQL &= " , NULL "
            strSQL &= " , NULL "
            strSQL &= " , '' "
            strSQL &= " , NULL"
            strSQL &= " , '' "
            strSQL &= " , '' "
            strSQL &= " , '' "
            strSQL &= " , NULL "
            strSQL &= " , ''"
            strSQL &= " ,now()"
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " , '1'"                                          '特別消費税フラグ
            strSQL &= ")"
        Else
            strSQL = "UPDATE " & schema & "t_kaisyu "
            strSQL &= "SET "
            strSQL &= " 特別消費税フラグ ='1'"                          '1=10%  1以外=通常通り
            strSQL &= ",更新日 =now() "
            strSQL &= ",更新者 ='" & UserID & "'"
            strSQL &= " where uketukeno = '" & Uno.Trim & "'"
        End If

        ClassPostgeDB.EXEC(strSQL)

    End Sub


End Class