Public Class FormKaisyuukanri
    Dim strFDM As String = String.Empty
    Dim strLDM As String = String.Empty
    Dim dtColor As DataTable                'システムマスタ情報

    Dim intTorikomiFlag As Integer = 0      '0：通常検索　1：データ取込み処理中

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

    '---------------------------
    '回収管理 
    '---------------------------
    Private Sub FormKaisyuukanri_Load(sender As Object, e As EventArgs) Handles MyBase.Load

#If DEBUG Then
        Me.ButtonTEST.Visible = True
#Else
        Me.ButtonTEST.Visible = false
#End If

        '初期設定
        crear()

    End Sub

    '--------------------------------------------
    'メニュー　終了
    '--------------------------------------------
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click

        Me.Close()

    End Sub

    '--------------------------------------------
    'メニュー　検索
    '--------------------------------------------
    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click

        'システムマスタ取得(色、日数）
        dtColor = GetSystemtoKaisyuu("200")

        '検索
        kensaku()

        '各種項目セット
        Koumokuset()

    End Sub

    '--------------------------------------------
    'メニュー　EXCEL出力
    '--------------------------------------------
    Private Sub EXCLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCLToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("出力するデータがありません。")
            Exit Sub
        End If

        'EXCELへ出力
        excelOutDataGred4(Me.DataGridView1, False, Me.ToolStripProgressBar1, 3)

    End Sub

    '--------------------------------------------
    'メニュー　入金予定日登録（一括更新）
    '  2025/01/06 k.s　
    ' 現在この機能は未使用。今回の案件対応を行わない
    ' （変更案件） 回収データを複数件持たせる
    '--------------------------------------------
    Private Sub 入金予定日登録ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 入金予定日登録ToolStripMenuItem.Click
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Integer
        Dim msgRt As DialogResult
        Dim dateYday As DateTime

        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("対象データがありません。")
            Exit Sub
        End If

        '--- 2025/01/06 k.s start ---
        MessageBox.Show("このボタンは現在使用できません")
        Exit Sub
        '--- 2025/01/06 k.s end ---

        msgRt = MessageBox.Show("チェックを付けた入金予定日を一括登録します。" & vbCrLf & vbCrLf &
                                "【注意】入金予定日には売上年月の「翌々月末日」が登録されます", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgRt = DialogResult.No Then
            Exit Sub
        End If

        ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.DataGridView1.CurrentCell = Nothing
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(ro).Cells(0).Value = True Then

                '売上年月の翌々月末
                dateYday = DateTime.Parse(Me.DataGridView1.Rows(ro).Cells(1).Value & "/" & Me.DataGridView1.Rows(ro).Cells(2).Value & "/01").AddMonths(3).AddDays(-1)

                strSQL = "SELECT uketukeno FROM " & schema & "t_kaisyu where uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString & "'"

                dt = ClassPostgeDB.SetTable(strSQL)
                If dt.Rows.Count = 0 Then
                    strSQL = "INSERT INTO " & schema & "t_kaisyu "
                    strSQL &= "( "
                    strSQL &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno      , 請求書再発行日     , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
                    strSQL &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
                    strSQL &= " 決裁書発行日           , ss請求      , 未回収架電確認日      , 確認者 , 備考 ,色, 入金予定日担当者 , 残明細削除フラグ, "
                    'strSQL &= " 更新日      , 更新者 "           '2024/07/10 k.s
                    strSQL &= " 更新日 , 更新者 , 特別消費税フラグ "
                    strSQL &= ")"
                    strSQL &= "VALUES("
                    strSQL &= "   NULL"
                    strSQL &= " , " & DateKata(dateYday)
                    strSQL &= " , '' "
                    strSQL &= " , '" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString & "' "
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
                    strSQL &= " , ''"                   '2024/07/10 k.s 特別消費税フラグ
                    strSQL &= ")"
                Else
                    strSQL = "UPDATE " & schema & "t_kaisyu "
                    strSQL &= "SET "
                    strSQL &= " 入金予定日            = " & DateKata(dateYday)
                    strSQL &= ",更新日=now() "
                    strSQL &= ",更新者='" & UserID & "'"
                    strSQL &= " WHERE uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString & "'"
                End If
                ClassPostgeDB.EXEC(strSQL)

                Me.ToolStripProgressBar1.Value = ro

            End If
        Next

        Me.ToolStripProgressBar1.Value = 0

        '検索
        kensaku()

        '各種項目セット
        Koumokuset()

        MessageBox.Show("完了しました")
    End Sub

    '--------------------------------------------
    'メニュー　取込み（一括更新用取込み）
    '　EXCELの1行の項目が多いため取込みに1件0.4秒かかる
    '--------------------------------------------
    Private Sub 取込みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取込みToolStripMenuItem.Click
        Dim msgRt As DialogResult

        msgRt = MessageBox.Show("入金連絡データを取込みます。" & vbCrLf & vbCrLf &
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
        Dim ExcelDt As DataTable = ClassExcelToDataTable.ExcelToDataTable(strFile, "", 2)

        '取り込みファイルの件数チェック
        If ExcelDt.Rows.Count = 0 Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("取込み出来ませんでした")
            Exit Sub
        End If
        '取り込みファイルのヘッダー存在チェック
        Dim clmName As String = ""
        For Each clm As DataColumn In ExcelDt.Columns
            If clm.ColumnName = "ﾁｪｯｸ" Then
                clmName = clm.ColumnName
            End If
        Next
        If clmName = "" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("回収管理以外のファイルが選択されています")
            Exit Sub
        End If

        '一覧表表示
        intTorikomiFlag = 1
        Disp(ExcelDt, intTorikomiFlag)

        Cursor.Current = Cursors.Default

        MessageBox.Show("内容を確認し「更新」を行ってください。")

    End Sub

    '--------------------------------------------
    'メニュー　更新（一括更新用取込み）
    '--------------------------------------------
    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Integer
        Dim msgRt As DialogResult

        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("対象データがありません。")
            Exit Sub
        End If

        msgRt = MessageBox.Show("一覧表の内容をDBに一括登録します。" & vbCrLf & vbCrLf &
                                "回収情報は全て上書き登録されます。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgRt = DialogResult.No Then
            Exit Sub
        End If

        ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.DataGridView1.CurrentCell = Nothing
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(ro).Cells(1).Value = True Then

                '検索有りの場合は上書きする
                strSQL = "SELECT uketukeno FROM " & schema & "t_kaisyu where uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString & "'"
                strSQL &= " and SEQ  = '" & Me.DataGridView1.Rows(ro).Cells(58).Value.ToString & "'"                                '2025/01/06 k,s 
                dt = ClassPostgeDB.SetTable(strSQL)

                If dt.Rows.Count = 0 Then
                    strSQL = "INSERT INTO " & schema & "t_kaisyu "
                    strSQL &= "( "
                    strSQL &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno       , 請求書再発行日      , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
                    strSQL &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
                    strSQL &= " 決裁書発行日           , ss請求      , 未回収架電確認日  , 確認者          , 備考                , 色              , 入金予定日担当者    , 残明細削除フラグ, "
                    'strSQL &= " 更新日      , 更新者 "                       '2024/07/10 k.s
                    strSQL &= " 更新日 , 更新者 , 特別消費税フラグ "          '2024/07/10 k.s
                    strSQL &= " ,SEQ "                                        '2025/01/06 k.s
                    strSQL &= ")"
                    strSQL &= "VALUES("
                    strSQL &= "   " & DateKata3(Me.DataGridView1.Rows(ro).Cells(19).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(20).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(21).Value.ToString.Trim & "'"
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString.Trim & "'"
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(39).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(40).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(41).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(42).Value.ToString.Trim & "'"
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(43).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(44).Value.ToString.Trim & "'"
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(45).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(46).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(47).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(48).Value.ToString.Trim & "'"
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(49).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(50).Value.ToString.Trim & "'"
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(51).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(52).Value.ToString)
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(53).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(35).Value.ToString.Trim & "'"
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(36).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(37).Value.ToString.Trim & "'"                                 '確認者
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(38).Value.ToString.Trim & "'"
                    'strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(54).Value.ToString.Trim & "'"
                    strSQL &= " ,'' "                                                                                               '色は一括更新では更新しない 
                    strSQL &= " , " & DateKata3(Me.DataGridView1.Rows(ro).Cells(55).Value.ToString)
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(56).Value.ToString.Trim & "'"
                    strSQL &= " ,now()"
                    strSQL &= " ,'" & UserID & "'"
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(57).Value.ToString.Trim & "'"                                 '2024/07/10 k.s 特別消費税フラグ
                    strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(58).Value.ToString.Trim & "'"                                 '2025/01/06 k.s
                    strSQL &= ")"
                Else
                    strSQL = "UPDATE " & schema & "t_kaisyu "
                    strSQL &= "SET "
                    strSQL &= " 入金日                = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(19).Value.ToString)
                    strSQL &= ",入金予定日            = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(20).Value.ToString)
                    strSQL &= ",入金確認内容          ='" & Me.DataGridView1.Rows(ro).Cells(21).Value.ToString.Trim & "'"
                    strSQL &= ",UketukeNo             ='" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString.Trim & "'"
                    strSQL &= ",請求書再発行日        = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(39).Value.ToString)
                    strSQL &= ",振込期日              = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(40).Value.ToString)
                    strSQL &= ",未入金架電日１回目    = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(41).Value.ToString)
                    strSQL &= ",未入金架電日１回目結果='" & Me.DataGridView1.Rows(ro).Cells(42).Value.ToString.Trim & "'"
                    strSQL &= ",未入金架電日２回目    = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(43).Value.ToString)
                    strSQL &= ",未入金架電日２回目結果='" & Me.DataGridView1.Rows(ro).Cells(44).Value.ToString.Trim & "'"
                    strSQL &= ",督促状発行日          = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(45).Value.ToString)
                    strSQL &= ",振込期日督促状発行    = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(46).Value.ToString)
                    strSQL &= ",未入金架電１回目      = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(47).Value.ToString)
                    strSQL &= ",未入金架電１回目結果  ='" & Me.DataGridView1.Rows(ro).Cells(48).Value.ToString.Trim & "'"
                    strSQL &= ",未入金架電２回目      = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(49).Value.ToString)
                    strSQL &= ",未入金架電２回目結果  ='" & Me.DataGridView1.Rows(ro).Cells(50).Value.ToString.Trim & "'"
                    strSQL &= ",受付拒否設定日        = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(51).Value.ToString)
                    strSQL &= ",債権放棄通知書発行日  = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(52).Value.ToString)
                    strSQL &= ",決裁書発行日          = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(53).Value.ToString)
                    strSQL &= ",ss請求                ='" & Me.DataGridView1.Rows(ro).Cells(35).Value.ToString.Trim & "'"
                    strSQL &= ",未回収架電確認日      = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(36).Value.ToString)
                    strSQL &= ",確認者                ='" & Me.DataGridView1.Rows(ro).Cells(37).Value.ToString.Trim & "'"           '確認者
                    strSQL &= ",備考                  ='" & Me.DataGridView1.Rows(ro).Cells(38).Value.ToString.Trim & "'"
                    'strSQL &= ",色                    ='" & Me.DataGridView1.Rows(ro).Cells(54).Value.ToString.Trim & "'"          '色は一括更新では変更しない
                    strSQL &= ",入金予定日担当者      = " & DateKata3(Me.DataGridView1.Rows(ro).Cells(55).Value.ToString)
                    strSQL &= ",残明細削除フラグ      ='" & Me.DataGridView1.Rows(ro).Cells(56).Value.ToString.Trim & "'"
                    strSQL &= ",更新日=now() "
                    strSQL &= ",更新者='" & UserID & "'"
                    strSQL &= ",特別消費税フラグ      ='" & Me.DataGridView1.Rows(ro).Cells(57).Value.ToString.Trim & "'"           '2024/07/10 k.s
                    strSQL &= ",SEQ                   ='" & Me.DataGridView1.Rows(ro).Cells(58).Value.ToString.Trim & "'"           '2025/01/06 k.s
                    strSQL &= " WHERE uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(3).Value.ToString & "'"
                    strSQL &= " and SEQ  = '" & Me.DataGridView1.Rows(ro).Cells(58).Value.ToString & "'"                            '2025/01/06 k,s   
                End If
                ClassPostgeDB.EXEC(strSQL)

            End If
            Me.ToolStripProgressBar1.Value = ro
        Next

        Me.ToolStripProgressBar1.Value = 0

        MessageBox.Show("完了しました")
    End Sub

    '--------------------------------------------
    '検索
    '--------------------------------------------
    Private Sub kensaku()
        Dim msg As String = String.Empty
        Dim strSQL As String
        'Dim ro As Integer
        Dim dt As DataTable
        Dim st As DateTime
        Dim en As DateTime

        '売上年月
        st = DateTime.Parse(Me.DateTimePicker1.Value)
        en = DateTime.Parse(Me.DateTimePicker2.Value)

        If st > en Then
            MessageBox.Show("売上月期間が正しくありません")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        '今月の最初の日
        Dim dtFDM As New DateTime(st.Year, st.Month, 1)
        strFDM = dtFDM.ToString("yyyy/MM/dd")
        '今月の最後の日
        Dim dtLDM As DateTime = New DateTime(en.Year, en.Month, 1).AddMonths(1).AddDays(-1)
        strLDM = dtLDM.ToString("yyyy/MM/dd")
        '----2024/09/04 start ---
        strSQL = "select"
        strSQL &= " null              as ""売上年"" "
        strSQL &= ",null              as ""売上月"" "
        strSQL &= ",tmp.uketukeno     as ""点検受付番号"" "
        strSQL &= ",tmp.tyoufuku      as ""重複"" "
        strSQL &= ",tmp.nextb         as ""売上年月日"" "
        strSQL &= ",tmp.cst_cd        as ""得意先コード"" "
        strSQL &= ",tmp.scst_nm       as ""得意先名"" "
        strSQL &= ",tmp.itm_cd        as ""品コード"" "
        strSQL &= ",tmp.cst_po_no     as ""発注ＮＯ"" "
        strSQL &= ",tmp.intr_rmrks    as ""請求書番号"" "
        strSQL &= ",tmp.slip_rmrks    as ""備考_漢字"" "
        strSQL &= ",tmp.ord_psn_nm    as ""発注担当者"" "
        strSQL &= ",tmp.qty           as ""数"" "
        strSQL &= ",CAST(tmp.upri as INT) as ""回収金額"" "
        strSQL &= ",tmp.entry_date    as ""更新日"" "
        strSQL &= ",s.保証規定区分 "
        strSQL &= ",s.回収区分 "
        strSQL &= ", COALESCE(cast(s.請求合計金額 as numeric),0) as ""請求合計金額"" "
        strSQL &= ",s.ｄｍ番号 "
        strSQL &= ",s.承認番号 "
        strSQL &= ",s.点検受付番号 "
        strSQL &= ",s.代表受付番号 "
        strSQL &= ",s.請求日 "
        strSQL &= ",s.請求先宛名 "
        strSQL &= ",s.請求先住所 "
        strSQL &= ",s.請求先電話 "
        strSQL &= ",s.都道府県名 "
        strSQL &= ",s.市区町村名 "
        strSQL &= ",s.町域 "
        strSQL &= ",s.番地 "
        strSQL &= ",s.建物 "
        strSQL &= ",s.部屋 "
        strSQL &= ",tk.入金日 "
        strSQL &= ",tk.入金予定日 "
        strSQL &= ",tk.入金確認内容 "
        strSQL &= ",tk.請求書再発行日 "
        strSQL &= ",tk.振込期日 "
        strSQL &= ",tk.未入金架電日１回目 "
        strSQL &= ",tk.未入金架電日１回目結果 "
        strSQL &= ",tk.未入金架電日２回目 "
        strSQL &= ",tk.未入金架電日２回目結果 "
        strSQL &= ",tk.督促状発行日 "
        strSQL &= ",tk.振込期日督促状発行 "
        strSQL &= ",tk.未入金架電１回目 "
        strSQL &= ",tk.未入金架電１回目結果 "
        strSQL &= ",tk.未入金架電２回目 "
        strSQL &= ",tk.未入金架電２回目結果 "
        strSQL &= ",tk.受付拒否設定日 "
        strSQL &= ",tk.債権放棄通知書発行日 "
        strSQL &= ",tk.決裁書発行日 "
        strSQL &= ",tk.ss請求 "
        strSQL &= ",tk.未回収架電確認日 "
        strSQL &= ",tk.確認者 "
        strSQL &= ",tk.備考 "
        strSQL &= ",tk.色 "
        strSQL &= ",tk.入金予定日担当者 "
        strSQL &= ",tk.残明細削除フラグ "
        strSQL &= ",tk.特別消費税フラグ "
        strSQL &= ",tmp.seq  as ""SEQ"" "    '2025/01/06 k.s
        strSQL &= " , s.開始日"
        strSQL &= " from " & schema & "t_002 as tmp "
        strSQL &= " inner join " & schema & "v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
        'strSQL &= "left outer join " & schema & "t_kaisyu          as tk on tk.uketukeno = tmp.uketukeno "                         '2025/01/06 k.s
        strSQL &= " left outer join " & schema & "t_kaisyu          as tk on tk.uketukeno = tmp.uketukeno and tk.seq = tmp.seq "     '2025/01/06 k.s
        strSQL &= " where tmp.out_flg ='1' and "                                     '出荷済
        strSQL &= "      s.依頼区分 Not in ('15','17','16','19','20','21') and "    'TS・PT契約を除く
        strSQL &= "      ( tmp.entry = '' or tmp.entry is null ) and " 　　　　　　 '削除済は対象外（"DELETE"以外) 2025/03/11 k.s
        '受付番号が入力されている時は受付番号のみで検索する
        If Me.TextBox点検受付番号.Text.Trim = "" Then
            strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD')  between '" & strFDM & "' and '" & strLDM & "' ) "
            strSQL &= JyouKen2()
            strSQL &= JyouKen3()
            strSQL &= JyouKen4()
        Else
            strSQL &= JyouKen1()
        End If
        strSQL &= " order by  tmp.uketukeno asc, tmp.nextb asc"
        '----2024/09/04 end ---

        dt = ClassPostgeDB.SetTable(strSQL)

        '一覧表表示
        intTorikomiFlag = 0
        Disp(dt, intTorikomiFlag)

        Me.Cursor = Cursors.Default

    End Sub

    '--------------------------------------------
    'ダブルクリックでサブ画面を表示
    '--------------------------------------------
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim ro As Integer = 0
        Dim co As Integer = 0

        If intTorikomiFlag = 1 Then
            Exit Sub     　　　　　　　　　　　　　　　　　　　　　　　　　　　  '取込みデータはサブ画面を開かない
        End If

        If e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Left Then
                '入金画面を開く
                ro = e.RowIndex
                co = Me.DataGridView1.CurrentCell.ColumnIndex
                Dim f As New FormKaisyuuSub

                f.UserID = UserID
                f.UserName = UserName
                f.Kengen = Kengen
                'f.NID = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString       '点検受付番号
                f.NID = Me.DataGridView1.Rows(ro).Cells(GetHeaderColNo("点検受付番号", Me.DataGridView1)).Value.ToString       '点検受付番号
                f.UDAY = Me.DataGridView1.Rows(ro).Cells(GetHeaderColNo("売上年月日", Me.DataGridView1)).Value               '売上年月日
                f.SKIN = Me.DataGridView1.Rows(ro).Cells(GetHeaderColNo("請求合計金額", Me.DataGridView1)).Value              '請求合計金額
                f.SEQ = Me.DataGridView1.Rows(ro).Cells(GetHeaderColNo("SEQ", Me.DataGridView1)).Value               'SEQ 2025/01/06　k.s

                f.ShowDialog(Me)
                f.Dispose()

                Me.DataGridView1.CurrentCell = Me.DataGridView1(co, ro)

                '入金画面から戻ってきたとき一覧表を更新する
                '--- 2025/01/06 k.s start ---
                '入金画面から戻ってきたとき一覧表を更新しない　　　　　　　　　　 
                '入金画面の中で複数件の更新を行えるようにした為、戻った時に現在の行の再更新では対応できなくなった為
                '対応策として「検索」ボタンを再度押すようにメッセージで促す

                'ReturnDisp(ro, Me.DataGridView1.Rows(ro).Cells(3).Value.ToString)
                '
                '--- 2025/01/06 k.s end ---
            End If
        End If

    End Sub

    '--------------------------------------------
    'ボタン　条件クリア
    '--------------------------------------------
    Private Sub Buttonクリア_Click(sender As Object, e As EventArgs) Handles Buttonクリア.Click
        crear()
    End Sub

    '--------------------------------------------
    'ボタン　検索（受付番号検索用）
    '--------------------------------------------
    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click

        'システムマスタ取得(色、日数）
        dtColor = GetSystemtoKaisyuu("200")

        '検索
        kensaku()

        '各種項目セット
        Koumokuset()
    End Sub

    '--------------------------------------------
    '検索条件
    '--------------------------------------------
    Private Function JyouKen1() As String
        Dim strSQL As String = String.Empty

        If Me.TextBox点検受付番号.Text.Trim <> "" Then
            strSQL &= " tmp.uketukeno = '" & Me.TextBox点検受付番号.Text.Trim & "' "
        End If

        Return strSQL
    End Function

    Private Function JyouKen2() As String
        Dim strSQL As String = String.Empty
        Dim strAnd As String = String.Empty

        ' 選択されている全ての項目の文字列を取得する
        For Each item In ListBox得意先コード.SelectedItems
            If strSQL <> "" Then
                strAnd = " or "
            End If
            strSQL &= strAnd & " tmp.cst_cd = '" & item.trim & "' "
        Next
        If strSQL = "" Then
            Return strSQL
        Else
            Return " and ( " & strSQL & " ) "
        End If

    End Function

    Private Function JyouKen3() As String
        Dim strSQL As String = String.Empty

        If Me.ComboBox回収区分.Text.Trim <> "" Then
            strSQL &= " And s.回収区分 = '" & Me.ComboBox回収区分.Text.Trim & "'"
        End If
        If TextBox請求書番号.Text.Trim <> "" Then
            strSQL &= " And tmp.intr_rmrks = '" & TextBox請求書番号.Text.Trim & "'"
        End If
        If TextBox品コード.Text.Trim <> "" Then
            strSQL &= " And tmp.itm_cd = '" & TextBox品コード.Text.Trim & "'"
        End If
        If TextBox発注担当者.Text.Trim <> "" Then
            strSQL &= " And tmp.ord_psn_nm like '%" & TextBox発注担当者.Text.Trim & "%'"        '含む
        End If

        If TextBox請求先宛名.Text.Trim <> "" Then
            strSQL &= " And s.請求先宛名 like '%" & TextBox請求先宛名.Text.Trim & "%'"          '含む
        End If
        If TextBox備考_漢字.Text.Trim <> "" Then
            strSQL &= " And tmp.slip_rmrks like '%" & TextBox備考_漢字.Text.Trim & "%'"         '含む
        End If

        If TextBox入金内容確認.Text.Trim <> "" Then
            strSQL &= " And tk.入金確認内容 like '%" & TextBox入金内容確認.Text.Trim & "%'"     '含む
        End If
        If TextBox確認者.Text.Trim <> "" Then
            strSQL &= " And tk.確認者 = '" & TextBox確認者.Text.Trim & "'"
        End If
        If TextBox備考.Text.Trim <> "" Then
            strSQL &= " And tk.備考 like '%" & TextBox備考.Text.Trim & "%'"                      '含む
        End If
        If TextBoxss請求.Text.Trim <> "" Then
            strSQL &= " And tk.ss請求 = '" & TextBoxss請求.Text.Trim & "'"
        End If

        '売上日
        If IsDate(Me.MaskedTextBox売上日s.Text) = True And IsDate(Me.MaskedTextBox売上日e.Text) = True Then
            If DateTime.Parse(Me.MaskedTextBox売上日s.Text) <= DateTime.Parse(Me.MaskedTextBox売上日e.Text) Then
                'strSQL &= " and ( tmp.nextb between '" & Me.MaskedTextBox売上日s.Text & "' and '" & Me.MaskedTextBox売上日e.Text & "' )"
                strSQL &= " and ( to_date(tmp.nextb, 'YYYY/MM/DD')  between '" & Me.MaskedTextBox売上日s.Text & "' and '" & Me.MaskedTextBox売上日e.Text & "' )"
            Else
                '検索条件エラー
            End If
        ElseIf IsDate(Me.MaskedTextBox売上日s.Text) = True And IsDate(Me.MaskedTextBox売上日e.Text) = False Then
            'strSQL &= " and ( tmp.nextb >= '" & Me.MaskedTextBox売上日s.Text & "' )"
            strSQL &= " and ( to_date(tmp.nextb, 'YYYY/MM/DD')  >= '" & Me.MaskedTextBox売上日s.Text & "' )"

        ElseIf IsDate(Me.MaskedTextBox売上日s.Text) = False And IsDate(Me.MaskedTextBox売上日e.Text) = True Then
            'strSQL &= " and ( tmp.nextb <= '" & Me.MaskedTextBox売上日e.Text & "' )"
            strSQL &= " and ( to_date(tmp.nextb, 'YYYY/MM/DD')  <= '" & Me.MaskedTextBox売上日e.Text & "' )"
        End If

        '回収金額
        If IsInteger(Me.TextBox回収金額s.Text) = True And IsInteger(Me.TextBox回収金額e.Text) = True Then
            If Integer.Parse(Me.TextBox回収金額s.Text) <= Integer.Parse(Me.TextBox回収金額e.Text) Then
                strSQL &= " and ( tmp.upri  between  '" & Me.TextBox回収金額s.Text & "' and '" & Me.TextBox回収金額e.Text & "' )"
            Else
                '検索条件エラー
            End If
        ElseIf IsInteger(Me.TextBox回収金額s.Text) = True And IsInteger(Me.TextBox回収金額e.Text) = False Then
            strSQL &= " and ( tmp.upri >= '" & Me.TextBox回収金額s.Text & "' )"
        ElseIf IsInteger(Me.TextBox回収金額s.Text) = False And IsInteger(Me.TextBox回収金額e.Text) = True Then
            strSQL &= " and ( tmp.upri <= '" & Me.TextBox回収金額e.Text & "' )"
        End If

        '請求金額
        If IsInteger(Me.TextBox請求金額s.Text) = True And IsInteger(Me.TextBox請求金額e.Text) = True Then
            If Integer.Parse(Me.TextBox請求金額s.Text) <= Integer.Parse(Me.TextBox請求金額e.Text) Then
                strSQL &= " and ( tmp.upri  between  '" & Me.TextBox請求金額s.Text & "' and '" & Me.TextBox請求金額e.Text & "' )"
            Else
                '検索条件エラー
            End If
        ElseIf IsInteger(Me.TextBox請求金額s.Text) = True And IsInteger(Me.TextBox請求金額s.Text) = False Then
            strSQL &= " and ( tmp.upri >= '" & Me.TextBox請求金額s.Text & "' )"
        ElseIf IsInteger(Me.TextBox請求金額s.Text) = False And IsInteger(Me.TextBox請求金額e.Text) = True Then
            strSQL &= " and ( tmp.upri <= '" & Me.TextBox請求金額e.Text & "' )"
        End If

        '入金日
        If IsDate(Me.MaskedTextBox入金日s.Text) = True And IsDate(MaskedTextBox入金日e.Text) = True Then
            If DateTime.Parse(Me.MaskedTextBox入金日s.Text) <= DateTime.Parse(Me.MaskedTextBox入金日e.Text) Then
                strSQL &= " and ( tk.入金日  between  '" & Me.MaskedTextBox入金日s.Text & "' and '" & Me.MaskedTextBox入金日e.Text & "' )"
            Else
                '検索条件エラー
            End If
        ElseIf IsDate(Me.MaskedTextBox入金日s.Text) = True And IsDate(Me.MaskedTextBox入金日e.Text) = False Then
            strSQL &= " and ( tk.入金日  >= '" & Me.MaskedTextBox入金日s.Text & "' )"
        ElseIf IsDate(Me.MaskedTextBox入金日s.Text) = False And IsDate(Me.MaskedTextBox入金日e.Text) = True Then
            strSQL &= " and ( tk.入金日  <= '" & Me.MaskedTextBox入金日e.Text & "' )"
        End If

        '入金予定日
        If IsDate(Me.MaskedTextBox入金予定日s.Text) = True And IsDate(MaskedTextBox入金予定日e.Text) = True Then
            If DateTime.Parse(Me.MaskedTextBox入金予定日s.Text) <= DateTime.Parse(Me.MaskedTextBox入金予定日e.Text) Then
                strSQL &= " and ( tk.入金予定日  between  '" & Me.MaskedTextBox入金予定日s.Text & "' and '" & Me.MaskedTextBox入金予定日e.Text & "' )"
            Else
                '検索条件エラー
            End If
        ElseIf IsDate(Me.MaskedTextBox入金予定日s.Text) = True And IsDate(Me.MaskedTextBox入金予定日e.Text) = False Then
            strSQL &= " and ( tk.入金予定日  >= '" & Me.MaskedTextBox入金予定日s.Text & "' "
        ElseIf IsDate(Me.MaskedTextBox入金日s.Text) = False And IsDate(Me.MaskedTextBox入金予定日e.Text) = True Then
            strSQL &= " and ( tk.入金予定日  <= '" & Me.MaskedTextBox入金予定日e.Text & "' )"
        End If

        Return strSQL
    End Function

    Private Function JyouKen4() As String
        Dim strSQL As String = String.Empty

        '【未入金】：請求書番号が有りの入金日が入っていないもの全て
        If Me.CheckBox未入金.Checked = True Then
            strSQL &= " and ( tmp.intr_rmrks <> '' and s.回収区分='NR後日請求' and tk.入金日 is NULL ) "
        End If

        '【請求書再発行済】：請求書が再発行されたもの（入金済・未入金全て）
        If Me.CheckBox請求書再発行済.Checked = True Then
            strSQL &= " and ( s.回収区分='NR後日請求' and tk.請求書再発行日 is not NULL ) "
        End If

        '【請求書再発行超過】：請求書再発行日から基準日（14日）を過ぎた未入金のもの（１回目架電対象）
        If Me.CheckBox請求書再発行超過.Checked = True Then
            Dim strSQL_sys As String = String.Empty
            Dim dt As DataTable
            strSQL_sys = "Select bikou from " & schema & "m_system where kbn= '200' and seq= '3'"
            dt = ClassPostgeDB.SetTable(strSQL_sys)
            If dt.Rows.Count = 1 Then
                strSQL &= " and ( s.回収区分='NR後日請求' and tk.入金日 is NULL and tk.請求書再発行日 is not NULL "
                strSQL &= " and to_char(tk.請求書再発行日 + cast( '" & dt.Rows(0).Item(0).ToString.Trim & " day' as INTERVAL),'yyyy/mm/dd') < to_char(now(),'yyyy/dmm/dd') "
                strSQL &= " and 残明細削除フラグ='' ) "
            End If
        End If

        '【督促状発行済】：督促状が発行されたもの（入金済・未入金全て）
        If Me.CheckBox督促状発行済.Checked = True Then
            strSQL &= " and ( s.回収区分='NR後日請求' and tk.督促状発行日 is not NULL ) "
        End If

        '【督促状発行未入金】：督促状発行後の未入金
        If Me.CheckBox督促状発行未入金.Checked = True Then
            'strSQL &= "　and ( s.回収区分='NR後日請求' and tk.督促状発行日 is not NULL and tk.入金日 is null and tk.残明細削除フラグ='' ) "    '2024/07/22 k.s 
            strSQL &= " and ( s.回収区分='NR後日請求' and tk.督促状発行日 is not NULL and tk.入金日 is null and tk.残明細削除フラグ='' ) "       '2024/07/22 k.s
        End If

        '【SS請求未請求】：SS現金徴収、SS後日請求でSS請求が空欄のもの
        If Me.CheckBoxSS未請求.Checked = True Then
            strSQL &= " and ( (s.回収区分 ='SS現金徴収' or s.回収区分='SS後日請求' ) and  tk.ss請求='' ) "
        End If

        '【債権放棄】：債権放棄通知書が発行されたもの（入金済・未入金全て）
        If Me.CheckBox債権放棄.Checked = True Then
            strSQL &= " and ( tk.債権放棄通知書発行日 is not NULL ) "
        End If

        '【債権放棄非表示】：債権放棄通知書が発行されたものは表示しない
        If Me.CheckBox債権放棄非表示.Checked = True Then
            strSQL &= " and ( tk.債権放棄通知書発行日 is NULL ) "
        End If

        Return strSQL
    End Function



    '--------------------------------------------
    '画面クリアー
    '--------------------------------------------
    Private Sub crear()
        DateTimePicker1().Value = Now()
        DateTimePicker1().Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy年MM月"
        DateTimePicker2().Value = Now()
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy年MM月"

        Me.ComboBox回収区分.Items.Clear()
        Me.ComboBox回収区分.Items.Add("")
        Me.ComboBox回収区分.Items.Add("SS後日請求")
        Me.ComboBox回収区分.Items.Add("SS現金徴収")
        Me.ComboBox回収区分.Items.Add("NR後日請求")
        Me.ComboBox回収区分.Items.Add("支払拒否")
        Me.ComboBox回収区分.Items.Add("無償指示")

        Me.ListBox得意先コード.SelectionMode = SelectionMode.MultiSimple
        Me.ListBox得意先コード.Items.Clear()
        Me.ListBox得意先コード.Items.Add("901000")       '点検売上（別途請求）
        Me.ListBox得意先コード.Items.Add("010574")       '点検売上（直収）
        Me.ListBox得意先コード.Items.Add("902000")       '点検売上（安心Ｐ点検付）
        Me.ListBox得意先コード.Items.Add("903000")       '点検売上（ＨＮ直収）
        Me.ListBox得意先コード.Items.Add("904000")       '点検売上（ＨＮ別途）

        'Me.ComboBox得意先コード.Items.Clear()
        'Me.ComboBox得意先コード.Items.Add("")
        'Me.ComboBox得意先コード.Items.Add("901000")       '点検売上（別途請求）
        'Me.ComboBox得意先コード.Items.Add("010574")       '点検売上（直収）
        'Me.ComboBox得意先コード.Items.Add("902000")       '点検売上（安心Ｐ点検付）
        'Me.ComboBox得意先コード.Items.Add("903000")       '点検売上（ＨＮ直収）
        'Me.ComboBox得意先コード.Items.Add("904000")       '点検売上（ＨＮ別途）

        'Me.ComboBox保証規定区分.Items.Clear()
        'Me.ComboBox保証規定区分.Items.Add("")
        'Me.ComboBox保証規定区分.Items.Add("安心プラン")
        'Me.ComboBox保証規定区分.Items.Add("あんしん点検")
        'Me.ComboBox保証規定区分.Items.Add("法定点検")

        Me.TextBox請求書番号.Text = ""
        Me.TextBox点検受付番号.Text = ""
        Me.TextBox品コード.Text = ""
        Me.TextBox発注担当者.Text = ""
        Me.TextBox品コード.Text = ""
        Me.MaskedTextBox売上日s.Text = ""
        Me.MaskedTextBox売上日e.Text = ""
        Me.TextBox回収金額s.Text = ""
        Me.TextBox回収金額e.Text = ""
        Me.TextBox請求金額s.Text = ""
        Me.TextBox請求金額e.Text = ""
        Me.TextBox請求先宛名.Text = ""
        Me.TextBox請求金額e.Text = ""
        Me.TextBox備考_漢字.Text = ""
        Me.MaskedTextBox入金日s.Text = ""
        Me.MaskedTextBox入金日e.Text = ""
        Me.MaskedTextBox入金予定日s.Text = ""
        Me.MaskedTextBox入金予定日e.Text = ""
        Me.TextBox入金内容確認.Text = ""
        Me.TextBox確認者.Text = ""
        Me.TextBox備考.Text = ""
        Me.TextBoxss請求.Text = ""

        Me.CheckBox未入金.Checked = False
        Me.CheckBox請求書再発行済.Checked = False
        Me.CheckBox請求書再発行超過.Checked = False
        Me.CheckBox督促状発行済.Checked = False
        Me.CheckBox督促状発行未入金.Checked = False
        Me.CheckBoxSS未請求.Checked = False
        Me.CheckBox債権放棄.Checked = False
        Me.CheckBox債権放棄非表示.Checked = True

        If Me.DataGridView1.Rows.Count = 0 Then
            ToolStripStatusLabel1.Text = "　税抜き合計金額＝"
            ToolStripStatusLabel2.Text = "　税込み合計金額＝"
            ToolStripStatusLabel3.Text = "　件数＝"                     '2024/07/10 k.s
        End If
    End Sub

    '--------------------------------------------
    '一覧表に項目を追加でセット
    '--------------------------------------------
    Private Sub Koumokuset()
        Dim intKingakuSum As Integer = 0                '回収金額集計
        Dim intSeikyuSum As Integer = 0                 '請求合計金額集計
        Dim strSeikyuNo As String = String.Empty        '請求書番号

        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        '----------出力チェック----------
        If Me.DataGridView1.Rows.Count = 0 Then
            Exit Sub
        End If

        '----------年月、安心プラン税込み金額計算、色のセット----------
        Dim rowMaxNum As Integer = Me.DataGridView1.Rows.Count - 1
        For row As Integer = 0 To rowMaxNum

            Dim strTXT As String = ""
            Dim intKingaku As Integer = 0

            intKingaku = Me.DataGridView1.Rows(row).Cells(16).Value                 '回収金額
            strSeikyuNo = Me.DataGridView1.Rows(row).Cells(12).Value.ToString.Trim  '請求書番号

            strTXT = Me.DataGridView1.Rows(row).Cells(7).Value.ToString             '売上年月

            'nextbは「yyyy/mm/dd」になっていないものが有るため日付型に変更してから年と月を取得する
            'Me.DataGridView1.Rows(row).Cells(1).Value = strTXT.Substring(0, 4)                    '年
            'Me.DataGridView1.Rows(row).Cells(2).Value = strTXT.Substring(5, 2)                    '月 
            Me.DataGridView1.Rows(row).Cells(1).Value = DateTime.Parse(strTXT).ToString("yyyy")    '年
            Me.DataGridView1.Rows(row).Cells(2).Value = DateTime.Parse(strTXT).ToString("MM")      '月

            '安心プランの税込み金額を計算（8%　または　10％）
            If Me.DataGridView1.Rows(row).Cells(4).Value.ToString = "安心プラン" And intKingaku <> "0" Then
                '--- 2021/07/10k.s start ---
                '「安心プランS2」を承認番号で検索し、施工年月日<2018年10月1日時　8％
                If GetZeiRitu(Me.DataGridView1.Rows(row).Cells(GetHeaderColNo("開始日", Me.DataGridView1)).Value.ToString.Trim) = 8 Then
                    Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.08)
                Else
                    Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)
                End If

                If Me.DataGridView1.Rows(row).Cells(57).Value.ToString.Trim = "1" Then
                        '特別消費税フラグが「1」の時、消費税率を10％とする
                        Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)
                    Else
                    '「安心プランS2」を承認番号で検索し、施工年月日<2018年10月1日時　8％
                    If GetZeiRitu(Me.DataGridView1.Rows(row).Cells(GetHeaderColNo("開始日", Me.DataGridView1)).Value.ToString.Trim) = 8 Then
                        Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.08)
                    Else
                        Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)
                        End If
                    End If
                    '--- 2024/07/10 k.s end ---
                End If

                '行カラー設定
                SetColor(row, strSeikyuNo, dtColor)

            intKingakuSum += intKingaku                                     '回収金額集計
            intSeikyuSum += Me.DataGridView1.Rows(row).Cells(18).Value      '請求金額集計

            ToolStripProgressBar1.Value = row

        Next
        ToolStripStatusLabel1.Text = "　税抜き合計金額＝" & intKingakuSum.ToString("#,0")
        ToolStripStatusLabel2.Text = "　税込み合計金額＝" & intSeikyuSum.ToString("#,0")
        ToolStripStatusLabel3.Text = "　件数＝" & Me.DataGridView1.Rows.Count.ToString("#,0")           '2024/07/10 k.s
        ToolStripProgressBar1.Value = 0
    End Sub

    '--------------------------------------------
    '行カラーセット
    '--------------------------------------------
    Private Sub SetColor(row As Integer, sno As String, dt As DataTable)
        Dim dMin As DateTime
        Dim dTok As DateTime
        Dim dNow As DateTime = DateTime.Now

        '予定日の有無で入金日期日が違う
        If Me.DataGridView1.Rows(row).Cells(19).Value.ToString = "" Then
            '未入金対象になる日、督促状発行対象になる
            dMin = DateTime.Parse(Me.DataGridView1.Rows(row).Cells(1).Value.ToString & "/" & Me.DataGridView1.Rows(row).Cells(2).Value.ToString & "/01").AddMonths(2)
            dTok = DateTime.Parse(Me.DataGridView1.Rows(row).Cells(1).Value.ToString & "/" & Me.DataGridView1.Rows(row).Cells(2).Value.ToString & "/01").AddMonths(3)
        Else
            'サイト用　未入金対象になる日、督促状発行対象になる
            dMin = DateTime.Parse(Me.DataGridView1.Rows(row).Cells(19).Value.ToString).AddDays(+1)
            dTok = DateTime.Parse(Me.DataGridView1.Rows(row).Cells(1).Value.ToString & "/" & Me.DataGridView1.Rows(row).Cells(2).Value.ToString & "/01").AddMonths(4)
        End If

        '行のカラーに初期値セット
        Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName("white")

        '行のカラーをセット
        '請求NO、回収区分、入金日、残明細削除フラグ
        If sno <> "" And Me.DataGridView1.Rows(row).Cells(5).Value.ToString = "NR後日請求" And Me.DataGridView1.Rows(row).Cells(19).Value.ToString.Trim = "" And Me.DataGridView1.Rows(row).Cells(56).Value.ToString.Trim = "" Then
            '請求書再発行対象
            If dMin.ToString("yyyy/MM/dd") <= dNow.ToString("yyyy/MM/dd") Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(0).Item(0).ToString)
            End If
            '請求書再発行済
            If Me.DataGridView1.Rows(row).Cells(39).Value.ToString <> "" Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(1).Item(0).ToString)
            End If
            '請求書再発行から期日が過ぎた時
            If Me.DataGridView1.Rows(row).Cells(39).Value.ToString <> "" Then
                Dim strMday As String = dt.Rows(2).Item(1).ToString
                If DateTime.Parse(Me.DataGridView1.Rows(row).Cells(39).Value.ToString).AddDays(strMday).ToString("yyyy/MM/dd") < dNow.ToString("yyyy/MM/dd") Then
                    Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(2).Item(0).ToString)
                End If
            End If
            '1回目架電日・2回目架電日が登録済
            If Me.DataGridView1.Rows(row).Cells(41).Value.ToString <> "" Or Me.DataGridView1.Rows(row).Cells(43).Value.ToString <> "" Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(2).Item(0).ToString)
            End If

            '----------------個別カラー指定がある場合は、個別カラーを優先させる------------------
            If Me.DataGridView1.Rows(row).Cells(54).Value.ToString.Trim <> "" Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = ColorTranslator.FromHtml(Me.DataGridView1.Rows(row).Cells(54).Value.ToString.Trim)
            End If
            '------------------------------------------------------------------------------------

            '督促状発行対象
            If dTok.ToString("yyyy/MM/dd") <= dNow.ToString("yyyy/MM/dd") Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(6).Item(0).ToString)
            End If
            '督促状発行済
            If Me.DataGridView1.Rows(row).Cells(45).Value.ToString <> "" Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(7).Item(0).ToString)
            End If
            '督促状発行から期日が過ぎた時
            If Me.DataGridView1.Rows(row).Cells(45).Value.ToString <> "" Then
                Dim strTday As String = dt.Rows(8).Item(1).ToString       '期日
                If DateTime.Parse(Me.DataGridView1.Rows(row).Cells(45).Value.ToString).AddDays(strTday).ToString("yyyy/MM/dd") < dNow.ToString("yyyy/MM/dd") Then
                    Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(8).Item(0).ToString)
                End If
            End If
            '1回目架電日・2回目架電日・受付拒否・受付拒否設定・債権放棄・決裁書が登録済
            If Me.DataGridView1.Rows(row).Cells(47).Value.ToString <> "" Or
               Me.DataGridView1.Rows(row).Cells(49).Value.ToString <> "" Or
               Me.DataGridView1.Rows(row).Cells(51).Value.ToString <> "" Or
               Me.DataGridView1.Rows(row).Cells(52).Value.ToString <> "" Or
               Me.DataGridView1.Rows(row).Cells(53).Value.ToString <> "" Then
                Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.FromName(dt.Rows(8).Item(0).ToString)
            End If
        End If
    End Sub

    '--------------------------------------------
    'SUB画面→一覧表の再表示
    '--------------------------------------------
    Private Sub ReturnDisp(row As Integer, No As String)
        Dim strSQL As String
        Dim dt As DataTable

        strSQL = " select "
        strSQL &= " tk.入金日 "
        strSQL &= ",tk.入金予定日 "
        strSQL &= ",tk.入金確認内容 "
        strSQL &= ",tk.ss請求 "
        strSQL &= ",tk.未回収架電確認日 "
        strSQL &= ",tk.確認者 "
        strSQL &= ",tk.備考 "
        strSQL &= ",tk.請求書再発行日 "
        strSQL &= ",tk.振込期日 "
        strSQL &= ",tk.未入金架電日１回目 "
        strSQL &= ",tk.未入金架電日１回目結果 "
        strSQL &= ",tk.未入金架電日２回目 "
        strSQL &= ",tk.未入金架電日２回目結果 "
        strSQL &= ",tk.督促状発行日 "
        strSQL &= ",tk.振込期日督促状発行 "
        strSQL &= ",tk.未入金架電１回目 "
        strSQL &= ",tk.未入金架電１回目結果 "
        strSQL &= ",tk.未入金架電２回目 "
        strSQL &= ",tk.未入金架電２回目結果 "
        strSQL &= ",tk.受付拒否設定日 "
        strSQL &= ",tk.債権放棄通知書発行日 "
        strSQL &= ",tk.決裁書発行日 "
        strSQL &= ",tk.色 "
        strSQL &= ",tk.入金予定日担当者 "
        strSQL &= ",tk.残明細削除フラグ "
        strSQL &= ",tk.特別消費税フラグ "               '2024/07/10 k.s
        strSQL &= " from " & schema & "t_kaisyu as tk where tk.uketukeno = '" & No & "'"

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 1 Then
            Me.DataGridView1.Rows(row).Cells(19).Value = SetDBNull(dt.Rows(0).Item(0).ToString.Trim)    '入金日
            Me.DataGridView1.Rows(row).Cells(20).Value = SetDBNull(dt.Rows(0).Item(1).ToString.Trim)    '入金予定日
            Me.DataGridView1.Rows(row).Cells(21).Value = dt.Rows(0).Item(2).ToString.Trim               '入金確認内容
            Me.DataGridView1.Rows(row).Cells(35).Value = dt.Rows(0).Item(3).ToString.Trim               'ss請求
            Me.DataGridView1.Rows(row).Cells(36).Value = SetDBNull(dt.Rows(0).Item(4).ToString.Trim)    '未回収架電確認日
            Me.DataGridView1.Rows(row).Cells(37).Value = dt.Rows(0).Item(5).ToString.Trim               '確認者
            Me.DataGridView1.Rows(row).Cells(38).Value = dt.Rows(0).Item(6).ToString.Trim               '備考
            Me.DataGridView1.Rows(row).Cells(39).Value = SetDBNull(dt.Rows(0).Item(7).ToString.Trim)    '請求書再発行日
            Me.DataGridView1.Rows(row).Cells(40).Value = SetDBNull(dt.Rows(0).Item(8).ToString.Trim)    '振込期日
            Me.DataGridView1.Rows(row).Cells(41).Value = SetDBNull(dt.Rows(0).Item(9).ToString.Trim)    '未入金架電日１回目
            Me.DataGridView1.Rows(row).Cells(42).Value = dt.Rows(0).Item(10).ToString.Trim              '未入金架電日１回目結果
            Me.DataGridView1.Rows(row).Cells(43).Value = SetDBNull(dt.Rows(0).Item(11).ToString.Trim)   '未入金架電日２回目
            Me.DataGridView1.Rows(row).Cells(44).Value = dt.Rows(0).Item(12).ToString.Trim              '未入金架電日２回目結果
            Me.DataGridView1.Rows(row).Cells(45).Value = SetDBNull(dt.Rows(0).Item(13).ToString.Trim)   '督促状発行日
            Me.DataGridView1.Rows(row).Cells(46).Value = SetDBNull(dt.Rows(0).Item(14).ToString.Trim)   '振込期日督促状発行
            Me.DataGridView1.Rows(row).Cells(47).Value = SetDBNull(dt.Rows(0).Item(15).ToString.Trim)   '未入金架電１回目
            Me.DataGridView1.Rows(row).Cells(48).Value = dt.Rows(0).Item(16).ToString.Trim              '未入金架電１回目結果
            Me.DataGridView1.Rows(row).Cells(49).Value = SetDBNull(dt.Rows(0).Item(17).ToString.Trim)   '未入金架電２回目
            Me.DataGridView1.Rows(row).Cells(50).Value = dt.Rows(0).Item(18).ToString.Trim              '未入金架電２回目結果
            Me.DataGridView1.Rows(row).Cells(51).Value = SetDBNull(dt.Rows(0).Item(19).ToString.Trim)   '受付拒否設定日
            Me.DataGridView1.Rows(row).Cells(52).Value = SetDBNull(dt.Rows(0).Item(20).ToString.Trim)   '債権放棄通知書発行日
            Me.DataGridView1.Rows(row).Cells(53).Value = SetDBNull(dt.Rows(0).Item(21).ToString.Trim)   '決裁書発行日
            Me.DataGridView1.Rows(row).Cells(54).Value = dt.Rows(0).Item(22).ToString.Trim              '色                  
            Me.DataGridView1.Rows(row).Cells(55).Value = SetDBNull(dt.Rows(0).Item(23).ToString.Trim)   '入金予定日担当者
            Me.DataGridView1.Rows(row).Cells(56).Value = dt.Rows(0).Item(24).ToString.Trim              '残明細削除フラグ
            Me.DataGridView1.Rows(row).Cells(57).Value = dt.Rows(0).Item(25).ToString.Trim              '特別消費税フラグ    2024/07/10 k.s    
            '行カラー設定
            SetColor(row, No, dtColor)

            '--- 2024/07/10 k.s start ---
            '税込み金額の計算
            Dim intKingaku As Integer = 0
            intKingaku = Me.DataGridView1.Rows(row).Cells(16).Value
            '安心プランの税込み金額を計算（8%　または　10％）
            If Me.DataGridView1.Rows(row).Cells(4).Value.ToString = "安心プラン" And intKingaku <> "0" Then
                If Me.DataGridView1.Rows(row).Cells(57).Value.ToString.Trim = "1" Then
                    '特別消費税フラグが「1」の時、消費税率を10％とする
                    Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)
                Else
                    '「安心プランS2」を承認番号で検索し、施工年月日<2018年10月1日時　8％
                    If GetZeiRitu(Me.DataGridView1.Rows(row).Cells(GetHeaderColNo("開始日", Me.DataGridView1)).Value.ToString.Trim) = 8 Then
                        Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.08)
                    Else
                        Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)
                    End If
                End If
            End If
            '--- 2024/07/10 k.s end ---

        End If

    End Sub

    '--------------------------------------------
    '一覧表でソート→行カラー再セット
    '--------------------------------------------
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        Dim strSeikyuNo As String = String.Empty        '請求書番号

        If Me.DataGridView1.Rows.Count <> 0 Then
            For row As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                '売上年月日で判断し請求書番号を取得
                If Me.DataGridView1.Rows(row).Cells(7).Value.ToString <> "" Then
                    strSeikyuNo = Me.DataGridView1.Rows(row).Cells(12).Value.ToString.Trim
                End If
                '行カラーセット
                SetColor(row, strSeikyuNo, dtColor)
            Next
        End If
    End Sub

    '---------------------------
    '一覧表示
    '　0：検索表示　1:取込み表示
    '---------------------------
    Private Sub Disp(Dt As DataTable, flag As Integer)
        Dim ro As Integer = 0
        Dim intKingakuSum As Integer = 0                '回収金額集計
        Dim intSeikyuSum As Integer = 0                 '請求合計金額集計

        ToolStripStatusLabel1.Text = "　税抜き合計金額＝"
        ToolStripStatusLabel2.Text = "　税込み合計金額＝"
        ToolStripStatusLabel3.Text = "　件数＝"                 '2024/07/10 k.s

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = Dt

        ro = 0
        If flag = 0 Then
            '＊＊＊＊＊＊＊　検索データ表示　＊＊＊＊＊＊＊
            'チェックボックスの追加
            Dim CheckBoxColumn As New DataGridViewCheckBoxColumn()
            CheckBoxColumn.DataPropertyName = "ﾁｪｯｸ"
            CheckBoxColumn.Name = "Column1"
            CheckBoxColumn.HeaderText = "ﾁｪｯｸ"
            Me.DataGridView1.Columns.Add(CheckBoxColumn)
            Me.DataGridView1.Columns(ro).Width = 50                                                '0
            ro = ro + 1
        Else
            '＊＊＊＊＊＊＊　取込みデータ表示　＊＊＊＊＊＊＊
            ro = settextColumn(Me.DataGridView1, ro, "ﾁｪｯｸ", "ﾁｪｯｸ", 50, True)                     '0
        End If
        ro = settextColumn(Me.DataGridView1, ro, "売上年", "売上年", 60, True)                     '1
        ro = settextColumn(Me.DataGridView1, ro, "売上月", "売上月", 40, True)                     '2

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 120, True)        '3
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 120, True)        '4
        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 120, True)                '5

        ro = settextColumn(Me.DataGridView1, ro, "重複", "重複", 40, True)                         '6
        ro = settextColumn(Me.DataGridView1, ro, "売上年月日", "売上年月日", 130, True)            '7
        ro = settextColumn(Me.DataGridView1, ro, "得意先コード", "得意先コード", 100, True)        '8
        ro = settextColumn(Me.DataGridView1, ro, "得意先名", "得意先名", 160, True)                '9
        ro = settextColumn(Me.DataGridView1, ro, "品コード", "品コード", 120, True)                '10
        ro = settextColumn(Me.DataGridView1, ro, "発注ＮＯ", "発注ＮＯ", 130, True)                '11
        ro = settextColumn(Me.DataGridView1, ro, "請求書番号", "請求書番号", 130, True)            '12
        ro = settextColumn(Me.DataGridView1, ro, "備考_漢字", "備考_漢字", 120, True)              '13
        ro = settextColumn(Me.DataGridView1, ro, "発注担当者", "発注担当者", 130, True)            '14
        ro = settextColumn(Me.DataGridView1, ro, "数", "数", 50, True)                             '(15)
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 120, True)                '(16)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 120, True)                    '17

        ro = settextColumn(Me.DataGridView1, ro, "請求合計金額", "請求合計金額", 120, True)        '(18)
        ro = settextColumn(Me.DataGridView1, ro, "入金日", "入金日", 130, True)                    '19
        ro = settextColumn(Me.DataGridView1, ro, "入金予定日", "入金予定日", 130, True)            '20
        ro = settextColumn(Me.DataGridView1, ro, "入金確認内容", "入金確認内容", 120, True)        '21
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 120, True)                '22
        ro = settextColumn(Me.DataGridView1, ro, "承認番号", "承認番号", 120, True)                '23

        ro = settextColumn(Me.DataGridView1, ro, "代表受付番号", "代表受付番号", 120, True)        '24

        ro = settextColumn(Me.DataGridView1, ro, "請求日", "請求日", 130, True)                    '25 
        ro = settextColumn(Me.DataGridView1, ro, "請求先宛名", "請求先宛名", 150, True)            '26 
        ro = settextColumn(Me.DataGridView1, ro, "請求先住所", "請求先住所", 100, True)            '27
        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 100, True)            '28
        ro = settextColumn(Me.DataGridView1, ro, "都道府県名", "訪問先都道府県名", 100, True)      '29
        ro = settextColumn(Me.DataGridView1, ro, "市区町村名", "訪問先市区町村名", 100, True)      '30
        ro = settextColumn(Me.DataGridView1, ro, "町域", "訪問先町域", 100, True)                  '31
        ro = settextColumn(Me.DataGridView1, ro, "番地", "訪問先番地", 100, True)                  '32
        ro = settextColumn(Me.DataGridView1, ro, "建物", "訪問先建物", 100, True)                  '33
        ro = settextColumn(Me.DataGridView1, ro, "部屋", "訪問先部屋", 100, True)                  '34 

        ro = settextColumn(Me.DataGridView1, ro, "ss請求", "ss請求", 120, True)                                   '35 
        ro = settextColumn(Me.DataGridView1, ro, "未回収架電確認日", "未回収架電確認日", 130, True)               '36
        ro = settextColumn(Me.DataGridView1, ro, "確認者", "確認者", 120, True)                                   '37
        ro = settextColumn(Me.DataGridView1, ro, "備考", "備考", 120, True)                                       '38

        ro = settextColumn(Me.DataGridView1, ro, "請求書再発行日", "請求書再発行日", 130, True)                   '39
        ro = settextColumn(Me.DataGridView1, ro, "振込期日", "振込期日", 130, True)                               '40
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日１回目", "未入金架電日１回目", 130, True)           '41
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日１回目結果", "未入金架電日１回目結果", 150, True)   '42
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日２回目", "未入金架電日２回目", 130, True)           '43
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日２回目結果", "未入金架電日２回目結果", 150, True)   '44

        ro = settextColumn(Me.DataGridView1, ro, "督促状発行日", "督促状発行日", 130, True)                       '45
        ro = settextColumn(Me.DataGridView1, ro, "振込期日督促状発行", "振込期日督促状発行", 130, True)           '46
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電１回目", "未入金架電１回目", 130, True)               '47
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電１回目結果", "未入金架電１回目結果", 140, True)       '48
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電２回目", "未入金架電２回目", 130, True)               '49
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電２回目結果", "未入金架電２回目結果", 140, True)       '50

        ro = settextColumn(Me.DataGridView1, ro, "受付拒否設定日", "受付拒否設定日", 130, True)                   '51
        ro = settextColumn(Me.DataGridView1, ro, "債権放棄通知書発行日", "債権放棄通知書発行日", 130, True)       '52
        ro = settextColumn(Me.DataGridView1, ro, "決裁書発行日", "決裁書発行日", 130, True)                       '53 
        ro = settextColumn(Me.DataGridView1, ro, "色", "色", 50, True)                                            '54　
        If flag = 0 Then
            ro = settextColumn(Me.DataGridView1, ro, "入金予定日担当者", "入金予定日(担当者用ﾒﾓ)", 130, True)         '55
        Else
            ro = settextColumn(Me.DataGridView1, ro, "入金予定日(担当者用ﾒﾓ)", "入金予定日(担当者用ﾒﾓ)", 130, True)   '55　
        End If
        ro = settextColumn(Me.DataGridView1, ro, "残明細削除フラグ", "残明細削除フラグ", 120, True)               '56

        ro = settextColumn(Me.DataGridView1, ro, "特別消費税フラグ", "特別消費税フラグ", 120, True)               '57
        ro = settextColumn(Me.DataGridView1, ro, "開始日", "開始日", 1, True)        '24

        ro = settextColumn(Me.DataGridView1, ro, "SEQ", "SEQ", 50, True)                                          '58  2025/01/06 k.s

        '金額右寄せ
        Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight        '数
        Me.DataGridView1.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight        '回収金額
        Me.DataGridView1.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight        '請求金額

        Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(16).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(18).DefaultCellStyle.Format = "#,0"

        If flag = 1 Then
            '合計計算
            Dim intgoukei As Integer = 0
            Dim intKaisyuGoukei As Integer = 0
            For row As Integer = 0 To DataGridView1.Rows.Count - 2
                intKingakuSum += Integer.Parse(Me.DataGridView1.Rows(row).Cells(16).Value.ToString)              '金額（税抜き）の合計
                intSeikyuSum += Integer.Parse(Me.DataGridView1.Rows(row).Cells(18).Value.ToString)               '回収金額（税抜き）の合計
            Next
            ToolStripStatusLabel1.Text = "　税抜き合計金額＝" & intKingakuSum.ToString("#,0")
            ToolStripStatusLabel2.Text = "　税込み合計金額＝" & intSeikyuSum.ToString("#,0")
            ToolStripStatusLabel3.Text = "　税込み合計金額＝" & Me.DataGridView1.Rows.Count.ToString("#,0")      '2024/07/10 k.s
        End If

        'ヘッダーの色を変える
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Columns(6).HeaderCell.Style.ForeColor = Color.Red
        For i As Integer = 7 To 17
            Me.DataGridView1.Columns(i).HeaderCell.Style.ForeColor = Color.Blue
        Next i

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

    End Sub


    Private Sub ButtonTEST_Click(sender As Object, e As EventArgs) Handles ButtonTEST.Click
        Dim a = GetZeiRitu("2014/01/02 12:00:00")
        MessageBox.Show(a)

    End Sub
End Class