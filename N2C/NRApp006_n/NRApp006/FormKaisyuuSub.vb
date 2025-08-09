Public Class FormKaisyuuSub
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim _NID As String = String.Empty
    Dim _SKIN As Integer = 0
    Dim _UDAY As String = String.Empty

    Dim _SEQ As String = String.Empty       '2025/01/06 k.s

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

    Public Property NID As String
        Get
            NID = _NID
        End Get
        Set(value As String)
            _NID = value
        End Set
    End Property
    Public Property SKIN As Integer
        Get
            SKIN = _SKIN
        End Get
        Set(value As Integer)
            _SKIN = value
        End Set
    End Property
    Public Property UDAY As String
        Get
            UDAY = _UDAY
        End Get
        Set(value As String)
            _UDAY = value
        End Set
    End Property

    '----2025/01/06 k.s start ---
    Public Property SEQ As String
        Get
            SEQ = _SEQ
        End Get
        Set(value As String)
            _SEQ = value
        End Set
    End Property
    '----2025/01/06 k.s end ---

    '---------------------------
    '請求合計金額
    '---------------------------
    Private Sub FormKaisyuuSub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '集約データ、回収データ検索
        kensaku()
        '出庫データ検索
        kensaku_meisai()


    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click

        '更新
        koushin()

    End Sub


    Private Sub kensaku()
        Dim strSQL As String
        Dim dt As DataTable

        '--- 2025/01/06 k.s start ---
        'strSQL = "select "
        'strSQL &= " s.点検受付番号"
        'strSQL &= ",s.保証規定区分"
        'strSQL &= ",s.回収区分"
        'strSQL &= ",s.代表受付番号"
        'strSQL &= ",s.ｄｍ番号 "
        'strSQL &= ",s.承認番号"
        'strSQL &= ",s.請求合計金額"
        'strSQL &= ",s.請求日"
        'strSQL &= ",s.請求先宛名"
        'strSQL &= ",s.請求先住所"
        'strSQL &= ",s.請求先電話"
        'strSQL &= ",s.都道府県名"
        'strSQL &= ",s.市区町村名"
        'strSQL &= ",s.町域"
        'strSQL &= ",s.番地"
        'strSQL &= ",s.建物"
        'strSQL &= ",s.部屋"
        'strSQL &= ",tk.入金日"
        'strSQL &= ",tk.入金予定日"
        'strSQL &= ",tk.入金確認内容"
        'strSQL &= ",tk.請求書再発行日"
        'strSQL &= ",tk.振込期日"
        'strSQL &= ",tk.未入金架電日１回目"
        'strSQL &= ",tk.未入金架電日１回目結果"
        'strSQL &= ",tk.未入金架電日２回目"
        'strSQL &= ",tk.未入金架電日２回目結果"
        'strSQL &= ",tk.督促状発行日"
        'strSQL &= ",tk.振込期日督促状発行"
        'strSQL &= ",tk.未入金架電１回目"
        'strSQL &= ",tk.未入金架電１回目結果"
        'strSQL &= ",tk.未入金架電２回目"
        'strSQL &= ",tk.未入金架電２回目結果"
        'strSQL &= ",tk.受付拒否設定日"
        'strSQL &= ",tk.債権放棄通知書発行日"
        'strSQL &= ",tk.決裁書発行日"
        'strSQL &= ",tk.ss請求"
        'strSQL &= ",tk.未回収架電確認日"
        'strSQL &= ",tk.確認者"
        'strSQL &= ",tk.備考"
        'strSQL &= ",tk.色"
        'strSQL &= ",tk.入金予定日担当者 "
        'strSQL &= ",tk.残明細削除フラグ "
        'strSQL &= ",tk.特別消費税フラグ "           '2024/07/10 k.s
        'strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku As s "
        'strSQL &= " left outer join " & schema & "t_kaisyu  As tk On s.点検受付番号 = tk.uketukeno "
        'strSQL &= " WHERE "
        'strSQL &= " s.点検受付番号 = '" & NID & "'"

        'dt = ClassPostgeDB.SetTable(strSQL)

        'If dt.Rows.Count = 1 Then

        '    For Each row As DataRow In dt.Rows
        '        Me.Label受付番号.Text = row("点検受付番号").ToString
        '        Me.Label保証規定区分.Text = row("保証規定区分").ToString
        '        Me.Label回収区分.Text = row("回収区分").ToString
        '        Me.Label代表受付番号.Text = row("代表受付番号").ToString
        '        Me.Labelｄｍ番号.Text = row("ｄｍ番号").ToString
        '        Me.Label承認番号.Text = row("承認番号").ToString
        '        Me.Label請求先宛名.Text = row("請求先宛名").ToString
        '        Me.Label請求先住所.Text = row("請求先住所").ToString
        '        Me.Label請求先電話.Text = row("請求先電話").ToString
        '        Me.Label請求合計金額.Text = SKIN.ToString("#,0")
        '        Me.Label請求日.Text = row("請求日").ToString
        '        Me.Label訪問先都道府県名.Text = row("都道府県名").ToString
        '        Me.Label市区町村名.Text = row("市区町村名").ToString
        '        Me.Label町域.Text = row("町域").ToString
        '        Me.Label番地.Text = row("番地").ToString
        '        Me.Label建物.Text = row("建物").ToString
        '        Me.Label部屋.Text = row("部屋").ToString

        '        Me.MaskedTextBox入金日.Text = row("入金日").ToString
        '        Me.MaskedTextBox入金予定日.Text = row("入金予定日").ToString
        '        Me.TextBox入金確認内容.Text = row("入金確認内容").ToString
        '        Me.MaskedTextBox請求書再発行日.Text = row("請求書再発行日").ToString
        '        Me.MaskedTextBox振込期日.Text = row("振込期日").ToString
        '        Me.MaskedTextBox請求_未入金架電日１回目.Text = row("未入金架電日１回目").ToString
        '        Me.TextBox請求_未入金架電日１回目_結果.Text = row("未入金架電日１回目結果").ToString
        '        Me.MaskedTextBox請求_未入金架電日２回目.Text = row("未入金架電日２回目").ToString
        '        Me.TextBox請求_未入金架電日２回目_結果.Text = row("未入金架電日２回目結果").ToString
        '        Me.MaskedTextBox督促状発行日.Text = row("督促状発行日").ToString
        '        Me.MaskedTextBox振込期日督促状発行.Text = row("振込期日督促状発行").ToString
        '        Me.MaskedTextBox督促_未入金架電１回目.Text = row("未入金架電１回目").ToString
        '        Me.TextBox督促_未入金架電１回目_結果.Text = row("未入金架電１回目結果").ToString
        '        Me.MaskedTextBox督促_未入金架電２回目.Text = row("未入金架電２回目").ToString
        '        Me.TextBox督促_未入金架電２回目_結果.Text = row("未入金架電２回目結果").ToString
        '        Me.MaskedTextBox受付拒否設定日.Text = row("受付拒否設定日").ToString
        '        Me.MaskedTextBox債権放棄通知書発行日.Text = row("債権放棄通知書発行日").ToString
        '        Me.MaskedTextBox決裁書発行日.Text = row("決裁書発行日").ToString
        '        Me.TextBoxss請求.Text = row("ss請求").ToString
        '        Me.MaskedTextBox未回収架電確認日.Text = row("未回収架電確認日").ToString
        '        Me.TextBox確認者.Text = row("確認者").ToString
        '        Me.TextBox備考.Text = row("備考").ToString

        '        Me.TextBox色.ReadOnly = False      '色変更可
        '        Me.TextBox色.Text = row("色").ToString
        '        Me.TextBox色.ReadOnly = True       '色変不可

        '        Me.MaskedTextBox入金予定日担当者.Text = row("入金予定日担当者").ToString
        '        Me.TextBox残明細削除フラグ.Text = row("残明細削除フラグ").ToString

        '        Me.TextBox特別消費税フラグ.Text = row("特別消費税フラグ").ToString          '2024/07/10 k.s

        '        If Me.TextBox色.Text.Trim <> "" Then
        '            'Me.TextBox色.BackColor = Color.FromName(Me.TextBox色.Text)
        '            Me.TextBox色.BackColor = ColorTranslator.FromHtml(Me.TextBox色.Text)
        '        End If

        '    Next
        'Else
        '    MessageBox.Show("明細データが表示出来ませんでした")
        '    Me.Close()
        'End If

        '画面クリア
        crear()
        '--------------------------------<syuyaku>
        strSQL = "select "
        strSQL &= " s.点検受付番号"
        strSQL &= ",s.保証規定区分"
        strSQL &= ",s.回収区分"
        strSQL &= ",s.代表受付番号"
        strSQL &= ",s.ｄｍ番号 "
        strSQL &= ",s.承認番号"
        strSQL &= ",s.請求合計金額"
        strSQL &= ",s.請求日"
        strSQL &= ",s.請求先宛名"
        strSQL &= ",s.請求先住所"
        strSQL &= ",s.請求先電話"
        strSQL &= ",s.都道府県名"
        strSQL &= ",s.市区町村名"
        strSQL &= ",s.町域"
        strSQL &= ",s.番地"
        strSQL &= ",s.建物"
        strSQL &= ",s.部屋"
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku As s "
        strSQL &= " WHERE "
        strSQL &= " s.点検受付番号 = '" & NID & "'"

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 1 Then
            For Each row As DataRow In dt.Rows
                Me.Label受付番号.Text = row("点検受付番号").ToString
                Me.Label保証規定区分.Text = row("保証規定区分").ToString
                Me.Label回収区分.Text = row("回収区分").ToString
                Me.Label代表受付番号.Text = row("代表受付番号").ToString
                Me.Labelｄｍ番号.Text = row("ｄｍ番号").ToString
                Me.Label承認番号.Text = row("承認番号").ToString
                Me.Label請求先宛名.Text = row("請求先宛名").ToString
                Me.Label請求先住所.Text = row("請求先住所").ToString
                Me.Label請求先電話.Text = row("請求先電話").ToString
                Me.Label請求合計金額.Text = SKIN.ToString("#,0")
                Me.Label請求日.Text = row("請求日").ToString
                Me.Label訪問先都道府県名.Text = row("都道府県名").ToString
                Me.Label市区町村名.Text = row("市区町村名").ToString
                Me.Label町域.Text = row("町域").ToString
                Me.Label番地.Text = row("番地").ToString
                Me.Label建物.Text = row("建物").ToString
                Me.Label部屋.Text = row("部屋").ToString
            Next
        Else
            MessageBox.Show("明細データが表示出来ませんでした")
            Me.Close()
        End If

        '--------------------------------<kaisyu>
        If dt.Rows.Count = 1 Then
            strSQL = "select "
            strSQL &= " tk.入金日"
            strSQL &= ",tk.入金予定日"
            strSQL &= ",tk.入金確認内容"
            strSQL &= ",tk.請求書再発行日"
            strSQL &= ",tk.振込期日"
            strSQL &= ",tk.未入金架電日１回目"
            strSQL &= ",tk.未入金架電日１回目結果"
            strSQL &= ",tk.未入金架電日２回目"
            strSQL &= ",tk.未入金架電日２回目結果"
            strSQL &= ",tk.督促状発行日"
            strSQL &= ",tk.振込期日督促状発行"
            strSQL &= ",tk.未入金架電１回目"
            strSQL &= ",tk.未入金架電１回目結果"
            strSQL &= ",tk.未入金架電２回目"
            strSQL &= ",tk.未入金架電２回目結果"
            strSQL &= ",tk.受付拒否設定日"
            strSQL &= ",tk.債権放棄通知書発行日"
            strSQL &= ",tk.決裁書発行日"
            strSQL &= ",tk.ss請求"
            strSQL &= ",tk.未回収架電確認日"
            strSQL &= ",tk.確認者"
            strSQL &= ",tk.備考"
            strSQL &= ",tk.色"
            strSQL &= ",tk.入金予定日担当者 "
            strSQL &= ",tk.残明細削除フラグ "
            strSQL &= ",tk.特別消費税フラグ "
            strSQL &= ",tk.seq "
            strSQL &= " from " & schema & "t_kaisyu  As tk "
            strSQL &= " WHERE "
            strSQL &= " tk.uketukeno = '" & NID & "' and tk.seq='" & SEQ & "'"

            dt = ClassPostgeDB.SetTable(strSQL)

            If dt.Rows.Count = 1 Then
                For Each row As DataRow In dt.Rows
                    Me.MaskedTextBox入金日.Text = row("入金日").ToString
                    Me.MaskedTextBox入金予定日.Text = row("入金予定日").ToString
                    Me.TextBox入金確認内容.Text = row("入金確認内容").ToString
                    Me.MaskedTextBox請求書再発行日.Text = row("請求書再発行日").ToString
                    Me.MaskedTextBox振込期日.Text = row("振込期日").ToString
                    Me.MaskedTextBox請求_未入金架電日１回目.Text = row("未入金架電日１回目").ToString
                    Me.TextBox請求_未入金架電日１回目_結果.Text = row("未入金架電日１回目結果").ToString
                    Me.MaskedTextBox請求_未入金架電日２回目.Text = row("未入金架電日２回目").ToString
                    Me.TextBox請求_未入金架電日２回目_結果.Text = row("未入金架電日２回目結果").ToString
                    Me.MaskedTextBox督促状発行日.Text = row("督促状発行日").ToString
                    Me.MaskedTextBox振込期日督促状発行.Text = row("振込期日督促状発行").ToString
                    Me.MaskedTextBox督促_未入金架電１回目.Text = row("未入金架電１回目").ToString
                    Me.TextBox督促_未入金架電１回目_結果.Text = row("未入金架電１回目結果").ToString
                    Me.MaskedTextBox督促_未入金架電２回目.Text = row("未入金架電２回目").ToString
                    Me.TextBox督促_未入金架電２回目_結果.Text = row("未入金架電２回目結果").ToString
                    Me.MaskedTextBox受付拒否設定日.Text = row("受付拒否設定日").ToString
                    Me.MaskedTextBox債権放棄通知書発行日.Text = row("債権放棄通知書発行日").ToString
                    Me.MaskedTextBox決裁書発行日.Text = row("決裁書発行日").ToString
                    Me.TextBoxss請求.Text = row("ss請求").ToString
                    Me.MaskedTextBox未回収架電確認日.Text = row("未回収架電確認日").ToString
                    Me.TextBox確認者.Text = row("確認者").ToString
                    Me.TextBox備考.Text = row("備考").ToString

                    Me.TextBox色.ReadOnly = False      '色変更可
                    Me.TextBox色.Text = row("色").ToString
                    Me.TextBox色.ReadOnly = True       '色変不可

                    Me.MaskedTextBox入金予定日担当者.Text = row("入金予定日担当者").ToString
                    Me.TextBox残明細削除フラグ.Text = row("残明細削除フラグ").ToString

                    Me.TextBox特別消費税フラグ.Text = row("特別消費税フラグ").ToString

                    If Me.TextBox色.Text.Trim <> "" Then
                        'Me.TextBox色.BackColor = Color.FromName(Me.TextBox色.Text)
                        Me.TextBox色.BackColor = ColorTranslator.FromHtml(Me.TextBox色.Text)
                    End If

                Next
            End If
        End If
        '--- 2025/01/06 k.s end ---

    End Sub


    Private Sub kensaku_meisai()
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Integer

        strSQL = "select "
        strSQL &= " tmp.nextb                  as ""売上年月日"" "
        strSQL &= ",tmp.cst_cd                 as ""得意先コード"" "
        strSQL &= ",tmp.scst_nm                as ""得意先名"" "
        strSQL &= ",tmp.itm_cd                 as ""品コード"" "
        strSQL &= ",tmp.cst_po_no              as ""発注ＮＯ"" "
        strSQL &= ",tmp.intr_rmrks             as ""請求書番号"" "
        strSQL &= ",tmp.slip_rmrks             as ""備考_漢字"" "
        strSQL &= ",tmp.ord_psn_nm             as ""発注担当者"" "
        strSQL &= ",tmp.qty                    as ""数"" "
        strSQL &= ",CAST(tmp.upri as INT)      as ""回収金額"" "
        strSQL &= ",tmp.entry_date             as ""更新日"" "
        strSQL &= ",tmp.SEQ                    as ""SEQ"" "      '2025/01/06 k.s
        strSQL &= " from " & schema & "t_002 as tmp "
        strSQL &= " where tmp.out_flg ='1' "                    '出荷済
        strSQL &= "   and tmp.uketukeno = '" & NID & "' "       '受付番号
        strSQL &= " order by tmp.entry_date desc"

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = 0

        ro = settextColumn(Me.DataGridView1, ro, "売上年月日", "売上年月日", 130, True)            '1
        ro = settextColumn(Me.DataGridView1, ro, "得意先コード", "得意先コード", 100, True)        '2
        ro = settextColumn(Me.DataGridView1, ro, "得意先名", "得意先名", 160, True)                '3
        ro = settextColumn(Me.DataGridView1, ro, "品コード", "品コード", 120, True)                '4
        ro = settextColumn(Me.DataGridView1, ro, "発注ＮＯ", "発注ＮＯ", 130, True)                '5
        ro = settextColumn(Me.DataGridView1, ro, "請求書番号", "請求書番号", 130, True)            '6
        ro = settextColumn(Me.DataGridView1, ro, "備考_漢字", "備考_漢字", 120, True)              '7
        ro = settextColumn(Me.DataGridView1, ro, "発注担当者", "発注担当者", 130, True)            '8
        ro = settextColumn(Me.DataGridView1, ro, "数", "数", 50, True)                             '(9)
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 120, True)                '(10)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 120, True)                    '11 
        ro = settextColumn(Me.DataGridView1, ro, "SEQ", "SEQ", 20, True)                           '12 2025/01/06 k.s

        Me.DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '数
        Me.DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '回収金額

        Me.DataGridView1.Columns(8).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(9).DefaultCellStyle.Format = "#,0"


        '行の色を変える
        'Me.DataGridView1.Rows(0).DefaultCellStyle.BackColor = Color.Cyan       '2025/01/06 k.s
        RowColor()                                                              '2025/01/06 k.s

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub koushin()
        Dim msg As String = String.Empty
        Dim strSQL As String
        Dim dt As DataTable

        If TextBoxss請求.Text.Trim.Length > 0 And TextBoxss請求.Text.Trim.Length < 6 Then
            MsgBox("ss請求が正しくありません")
            Exit Sub
        End If

        If TextBox残明細削除フラグ.Text.Trim = "" Or TextBox残明細削除フラグ.Text.Trim = "1" Then
        Else
            MsgBox("残明細削除フラグが正しくありません")
            Exit Sub
        End If

        '請求書再発行日の登録時、期日が空欄の場合自動的にセットする
        If DateKata(Me.MaskedTextBox請求書再発行日.Text) <> "NULL" Then
            If DateKata(Me.MaskedTextBox振込期日.Text) = "NULL" Then
                Me.MaskedTextBox振込期日.Text = KijituSet(Me.MaskedTextBox請求書再発行日.Text, 1)
            End If
        End If
        '督促発行日の登録時、期日が空欄の場合自動的にセットする
        If DateKata(Me.MaskedTextBox督促状発行日.Text) <> "NULL" Then
            If DateKata(Me.MaskedTextBox振込期日督促状発行.Text) = "NULL" Then
                Me.MaskedTextBox振込期日督促状発行.Text = KijituSet(Me.MaskedTextBox督促状発行日.Text, 1)
            End If
        End If

        strSQL = "SELECT uketukeno FROM " & schema & "t_kaisyu where uketukeno  = '" & NID & "'"
        strSQL &= " and seq = '" & SEQ & "'"                                                        '2025/01/06 k.s 

        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 0 Then
            strSQL = "INSERT INTO " & schema & "t_kaisyu "
            strSQL &= "( "
            strSQL &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno      , 請求書再発行日     , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
            strSQL &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
            strSQL &= " 決裁書発行日           , ss請求      , 未回収架電確認日      , 確認者 , 備考 ,色, 入金予定日担当者 , 残明細削除フラグ, "
            'strSQL &= " 更新日      , 更新者 "                   '2024/07/10 k.s
            strSQL &= " 更新日 , 更新者 , 特別消費税フラグ "      '2024/07/10 k.s
            strSQL &= " ,SEQ "                                    '2025/01/06 k.s
            strSQL &= ")"
            strSQL &= "VALUES("
            strSQL &= "   " & DateKata(Me.MaskedTextBox入金日.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox入金予定日.Text)
            strSQL &= " ,'" & Me.TextBox入金確認内容.Text.Trim & "'"
            strSQL &= " ,'" & Me.Label受付番号.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox請求書再発行日.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox振込期日.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox請求_未入金架電日１回目.Text)
            strSQL &= " ,'" & Me.TextBox請求_未入金架電日１回目_結果.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox請求_未入金架電日２回目.Text)
            strSQL &= " ,'" & Me.TextBox請求_未入金架電日２回目_結果.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox督促状発行日.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox振込期日督促状発行.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox督促_未入金架電１回目.Text)
            strSQL &= " ,'" & Me.TextBox督促_未入金架電１回目_結果.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox督促_未入金架電２回目.Text)
            strSQL &= " ,'" & Me.TextBox督促_未入金架電２回目_結果.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox受付拒否設定日.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox債権放棄通知書発行日.Text)
            strSQL &= " , " & DateKata(Me.MaskedTextBox決裁書発行日.Text)
            strSQL &= " ,'" & Me.TextBoxss請求.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox未回収架電確認日.Text)
            strSQL &= " ,'" & Me.TextBox確認者.Text.Trim & "'"
            strSQL &= " ,'" & Me.TextBox備考.Text.Trim & "'"
            strSQL &= " ,'" & Me.TextBox色.Text.Trim & "'"
            strSQL &= " , " & DateKata(Me.MaskedTextBox入金予定日担当者.Text)
            strSQL &= " ,'" & Me.TextBox残明細削除フラグ.Text.Trim & "'"
            strSQL &= " ,now()"
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ,'" & Me.TextBox特別消費税フラグ.Text.Trim & "'"            '2024/07/10 k.s
            strSQL &= " ,'" & SEQ & "'"                                             '2025/01/06 k.s
            strSQL &= ")"
        Else
            strSQL = "UPDATE " & schema & "t_kaisyu "
            strSQL &= "SET "
            strSQL &= " 入金日                = " & DateKata(Me.MaskedTextBox入金日.Text)
            strSQL &= ",入金予定日            = " & DateKata(Me.MaskedTextBox入金予定日.Text)
            strSQL &= ",入金確認内容          ='" & Me.TextBox入金確認内容.Text.Trim & "'"
            strSQL &= ",UketukeNo             ='" & Me.Label受付番号.Text.Trim & "'"
            strSQL &= ",請求書再発行日        = " & DateKata(Me.MaskedTextBox請求書再発行日.Text)
            strSQL &= ",振込期日              = " & DateKata(Me.MaskedTextBox振込期日.Text)
            strSQL &= ",未入金架電日１回目    = " & DateKata(Me.MaskedTextBox請求_未入金架電日１回目.Text)
            strSQL &= ",未入金架電日１回目結果='" & Me.TextBox請求_未入金架電日１回目_結果.Text.Trim & "'"
            strSQL &= ",未入金架電日２回目    = " & DateKata(Me.MaskedTextBox請求_未入金架電日２回目.Text)
            strSQL &= ",未入金架電日２回目結果='" & Me.TextBox請求_未入金架電日２回目_結果.Text.Trim & "'"
            strSQL &= ",督促状発行日          = " & DateKata(Me.MaskedTextBox督促状発行日.Text)
            strSQL &= ",振込期日督促状発行    = " & DateKata(Me.MaskedTextBox振込期日督促状発行.Text)
            strSQL &= ",未入金架電１回目      = " & DateKata(Me.MaskedTextBox督促_未入金架電１回目.Text)
            strSQL &= ",未入金架電１回目結果  ='" & Me.TextBox督促_未入金架電１回目_結果.Text.Trim & "'"
            strSQL &= ",未入金架電２回目      = " & DateKata(Me.MaskedTextBox督促_未入金架電２回目.Text)
            strSQL &= ",未入金架電２回目結果  ='" & Me.TextBox督促_未入金架電２回目_結果.Text.Trim & "'"
            strSQL &= ",受付拒否設定日        = " & DateKata(Me.MaskedTextBox受付拒否設定日.Text)
            strSQL &= ",債権放棄通知書発行日  = " & DateKata(Me.MaskedTextBox債権放棄通知書発行日.Text)
            strSQL &= ",決裁書発行日          = " & DateKata(Me.MaskedTextBox決裁書発行日.Text)
            strSQL &= ",ss請求                ='" & Me.TextBoxss請求.Text.Trim & "'"
            strSQL &= ",未回収架電確認日      = " & DateKata(Me.MaskedTextBox未回収架電確認日.Text)
            strSQL &= ",確認者                ='" & Me.TextBox確認者.Text.Trim & "'"
            strSQL &= ",備考                  ='" & Me.TextBox備考.Text.Trim & "'"
            strSQL &= ",色                    ='" & Me.TextBox色.Text.Trim & "'"
            strSQL &= ",入金予定日担当者      = " & DateKata(Me.MaskedTextBox入金予定日担当者.Text)
            strSQL &= ",残明細削除フラグ      ='" & Me.TextBox残明細削除フラグ.Text.Trim & "'"
            strSQL &= ",更新日=now() "
            strSQL &= ",更新者='" & UserID & "'"
            strSQL &= ",特別消費税フラグ      ='" & Me.TextBox特別消費税フラグ.Text.Trim & "'"          '2024/07/10 k.s
            strSQL &= " WHERE  uketukeno = '" & NID & "'"
            strSQL &= " and seq = '" & SEQ & "'"                                                        '2025/01/06 k.s 
        End If

        '--- 2025/01/06 k.s start ----
        'If ClassPostgeDB.EXEC(strSQL) = True Then
        '    'MsgBox("更新しました")
        'End If
        'Me.Close()
        Dim intOK As Integer = 0            '0：1：更新OK
        If ClassPostgeDB.EXEC(strSQL) = True Then
            strSQL = "SELECT uketukeno FROM " & schema & "t_kaisyu where uketukeno  = '" & NID & "'"
            dt = ClassPostgeDB.SetTable(strSQL)
            If dt.Rows.Count > 1 Then
                '同じ受付番号が複数件存在する場合、更新時に「残明細削除フラグ」をすべて同じにする
                strSQL = "UPDATE " & schema & "t_kaisyu "
                strSQL &= "SET "
                strSQL &= " 残明細削除フラグ  ='" & Me.TextBox残明細削除フラグ.Text.Trim & "'"
                strSQL &= " WHERE  uketukeno  ='" & NID & "'"
                If ClassPostgeDB.EXEC(strSQL) = True Then
                    intOK = 1
                End If
            Else
                intOK = 1
            End If
        End If
        If intOK = 1 Then
            Dim msgRt As DialogResult
            msgRt = MessageBox.Show("更新しました。" & vbCrLf &
                                    "一覧表に更新内容を反映させるには再度「検索」ボタンを押してください。" & vbCrLf & vbCrLf & "入力を終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If msgRt = DialogResult.Yes Then
                Me.Close()
            End If
        End If
        '--- 2025/01/06 end ----

    End Sub


    Private Sub Buttonカラーパレット_Click(sender As Object, e As EventArgs) Handles Buttonカラーパレット.Click
        Dim cd As New ColorDialog()

        Me.TextBox色.ReadOnly = False     '色変更可

        cd.AllowFullOpen = True
        cd.SolidColorOnly = False

        'ダイアログを表示する
        If cd.ShowDialog() = DialogResult.OK Then
            '選択された色の取得
            'Me.TextBox色.BackColor = cd.Color
            'TextBox色.Text = cd.Color.Name
            If cd.Color.IsKnownColor = True Then
                Dim c As Color = ColorTranslator.FromHtml(cd.Color.Name)
                Me.TextBox色.Text = String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B)
                Me.TextBox色.BackColor = ColorTranslator.FromHtml(Me.TextBox色.Text)
            Else
                Me.TextBox色.Text = "#" & cd.Color.Name
                Me.TextBox色.BackColor = ColorTranslator.FromHtml(Me.TextBox色.Text)
            End If
        End If
        Me.TextBox色.ReadOnly = True     '色変不可
    End Sub
    Private Sub Button色クリア_Click(sender As Object, e As EventArgs) Handles Button色クリア.Click
        Me.TextBox色.ReadOnly = False      '色変更可
        Me.TextBox色.Text = ""
        Me.TextBox色.BackColor = Color.WhiteSmoke
        Me.TextBox色.ReadOnly = True       '色変不可
    End Sub

    Private Sub Button今日_入金日_Click(sender As Object, e As EventArgs) Handles Button今日_入金日.Click
        Me.MaskedTextBox入金日.Text = Now()
    End Sub

    Private Sub Button今日_確認_Click(sender As Object, e As EventArgs) Handles Button今日_確認.Click
        Me.MaskedTextBox未回収架電確認日.Text = Now()
    End Sub

    Private Sub Button今日_請求書再発行日_Click(sender As Object, e As EventArgs) Handles Button今日_請求書再発行日.Click
        Me.MaskedTextBox請求書再発行日.Text = Now()
    End Sub

    Private Sub Button今日_架電1_Click(sender As Object, e As EventArgs) Handles Button今日_架電1.Click
        Me.MaskedTextBox請求_未入金架電日１回目.Text = Now()
    End Sub

    Private Sub Button今日_架電2_Click(sender As Object, e As EventArgs) Handles Button今日_架電2.Click
        Me.MaskedTextBox請求_未入金架電日２回目.Text = Now()
    End Sub

    Private Sub Button今日_督促_Click(sender As Object, e As EventArgs) Handles Button今日_督促.Click
        Me.MaskedTextBox督促状発行日.Text = Now()
    End Sub

    Private Sub Button今日_督促架電1_Click(sender As Object, e As EventArgs) Handles Button今日_督促架電1.Click
        Me.MaskedTextBox督促_未入金架電１回目.Text = Now()
    End Sub
    Private Sub Button今日_督促架電2_Click(sender As Object, e As EventArgs) Handles Button今日_督促架電2.Click
        Me.MaskedTextBox督促_未入金架電２回目.Text = Now()
    End Sub

    Private Sub Button今日_拒否_Click(sender As Object, e As EventArgs) Handles Button今日_拒否.Click
        Me.MaskedTextBox受付拒否設定日.Text = Now()
    End Sub

    Private Sub Button今日_放棄_Click(sender As Object, e As EventArgs) Handles Button今日_放棄.Click
        Me.MaskedTextBox債権放棄通知書発行日.Text = Now()
    End Sub

    Private Sub Button今日_決済_Click(sender As Object, e As EventArgs) Handles Button今日_決済.Click
        Me.MaskedTextBox決裁書発行日.Text = Now()
    End Sub



    Private Sub 点検集約データ子画面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 点検集約データ子画面ToolStripMenuItem.Click

        FormInput.TextBox得意先コード.Text = ""
        FormInput.TextBox点検受付番号.Text = Label受付番号.Text.Trim
        FormInput.TextBoxDM番号.Text = Labelｄｍ番号.Text.Trim
        FormInput.UserID = UserID
        FormInput.UserName = UserName
        FormInput.Kengen = Kengen
        FormInput.ShowDialog()

    End Sub


    Private Sub Button請求書再発行期日セット_Click(sender As Object, e As EventArgs) Handles Button請求書再発行期日セット.Click

        If DateKata(Me.MaskedTextBox請求書再発行日.Text) <> "NULL" Then
            Me.MaskedTextBox振込期日.Text = KijituSet(Me.MaskedTextBox請求書再発行日.Text, 1)
        End If

    End Sub

    Private Sub Button督促状発行期日セット_Click(sender As Object, e As EventArgs) Handles Button督促状発行期日セット.Click

        If DateKata(Me.MaskedTextBox督促状発行日.Text) <> "NULL" Then
            Me.MaskedTextBox振込期日督促状発行.Text = KijituSet(Me.MaskedTextBox督促状発行日.Text, 1)
        End If
    End Sub

    Private Function KijituSet(msk As DateTime, intseq As Integer) As String
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        KijituSet = ""

        'システムマスタの期日自動セット用の日の取得
        If DateKata(msk) <> "NULL" Then
            strSQL = "SELECT m.bikou FROM " & schema & "m_system as m where m.kbn='201' and m.seq='" & intseq & "'"
            dt = ClassPostgeDB.SetTable(strSQL)
            If dt.Rows.Count = 1 Then
                If dt.Rows(0).Item(0).ToString.Trim <> "" Then
                    KijituSet = msk.AddDays(Integer.Parse(dt.Rows(0).Item(0).ToString.Trim))
                End If
            End If
        End If

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button入金予定日セット.Click
        MaskedTextBox入金予定日.Text = DateTime.Parse(UDAY.Substring(0, 7) & "/01").AddMonths(3).AddDays(-1)
    End Sub

    '---2025/01/06 k.s start ---
    '--------------------------------------------
    '画面クリアー
    '--------------------------------------------
    Private Sub crear()

        Me.LabelUDAY.Text = UDAY

        Me.MaskedTextBox入金日.Text = ""
        Me.MaskedTextBox入金予定日.Text = ""
        Me.TextBox入金確認内容.Text = ""
        Me.MaskedTextBox請求書再発行日.Text = ""
        Me.MaskedTextBox振込期日.Text = ""
        Me.MaskedTextBox請求_未入金架電日１回目.Text = ""
        Me.TextBox請求_未入金架電日１回目_結果.Text = ""
        Me.MaskedTextBox請求_未入金架電日２回目.Text = ""
        Me.TextBox請求_未入金架電日２回目_結果.Text = ""
        Me.MaskedTextBox督促状発行日.Text = ""
        Me.MaskedTextBox振込期日督促状発行.Text = ""
        Me.MaskedTextBox督促_未入金架電１回目.Text = ""
        Me.TextBox督促_未入金架電１回目_結果.Text = ""
        Me.MaskedTextBox督促_未入金架電２回目.Text = ""
        Me.TextBox督促_未入金架電２回目_結果.Text = ""
        Me.MaskedTextBox受付拒否設定日.Text = ""
        Me.MaskedTextBox債権放棄通知書発行日.Text = ""
        Me.MaskedTextBox決裁書発行日.Text = ""
        Me.TextBoxss請求.Text = ""
        Me.MaskedTextBox未回収架電確認日.Text = ""
        Me.TextBox確認者.Text = ""
        Me.TextBox備考.Text = ""

        Me.TextBox色.ReadOnly = False      '色変更可
        Me.TextBox色.Text = ""
        Me.TextBox色.ReadOnly = True       '色変不可

        Me.MaskedTextBox入金予定日担当者.Text = ""
        Me.TextBox残明細削除フラグ.Text = ""
        Me.TextBox特別消費税フラグ.Text = ""

    End Sub

    '--------------------------------------------
    '行の色を変える
    '--------------------------------------------
    Private Sub RowColor()

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).DefaultCellStyle.BackColor = Color.White
            If SEQ = Me.DataGridView1.Rows(ro).Cells(11).Value Then
                '行の色を変える
                Me.DataGridView1.Rows(ro).DefaultCellStyle.BackColor = Color.Cyan
                Me.DataGridView1.CurrentCell = DataGridView1(0, ro)
            End If
        Next
        Me.MaskedTextBox入金日.Focus()

    End Sub
    '--------------------------------------------
    'ダブルクリックでサブ画面を表示
    '--------------------------------------------
    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim ro As Integer = 0
        Dim co As Integer = 0


        If e.RowIndex >= 0 Then
            If e.Button = MouseButtons.Left Then
                '入金画面を開く
                ro = e.RowIndex
                co = Me.DataGridView1.CurrentCell.ColumnIndex

                UDAY = Me.DataGridView1.Rows(ro).Cells(0).Value               '売上年月
                SEQ = Me.DataGridView1.Rows(ro).Cells(11).Value               'SEQ

                '画面クリアー
                crear()
                '集約データ、回収データ検索
                kensaku()
                '行の色を変える
                RowColor()

            End If
        End If

    End Sub
    '---2025/01/06 k.s end ---
End Class