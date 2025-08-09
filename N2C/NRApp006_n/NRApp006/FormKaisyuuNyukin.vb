Public Class FormKaisyuuNyukin
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
    '入金連絡
    '---------------------------
    Private Sub FormKaisyuuNyukin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '--- 2024/06/26 start ---
        'Me.DateTimePicker請求日s.Text = Now()     '2024/07/10 k.s
        'Me.DateTimePicker請求日e.Text = Now()     '2024/07/10 k.s
        Me.CheckBox全件対象.Checked = False
        '--- 2024/06/26 start ---

        '--- 2024/07/10 k.s start ---
        Me.MaskedTextBox請求日s.Text = ""
        Me.MaskedTextBox請求日e.Text = ""
        Me.MaskedTextBox売上日s.Text = ""
        Me.MaskedTextBox売上日e.Text = ""
        '--- 2024/07/10 k.s end ---
    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click

        '入金連絡データ検索
        kensaku()

        '--- 2024/06/26 start ---
        'If Me.DataGridView1.Rows.Count = 0 Then
        '    MessageBox.Show("出力するデータがありません。")
        '    Exit Sub
        'End If

        ''入金連絡データをEXCELに出力
        'excelOutDataGred4(Me.DataGridView1, False, Me.ToolStripProgressBar1, 2)
        '--- 2024/06/26 end ---
    End Sub


    '--- 2024/06/26 start ---
    Private Sub 出力ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem1.Click

        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("出力するデータがありません。")
            Exit Sub
        End If

        '入金連絡データをEXCELに出力
        excelOutDataGred4(Me.DataGridView1, False, Me.ToolStripProgressBar1, 2)

    End Sub
    '--- 2024/06/26 end ---

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
        'Me.Cursor = Cursors.WaitCursor
        Cursor.Current = Cursors.WaitCursor
        'Me.Update()

        Dim ClassExcelToDataTable As New ClassExcelToDataTable     'クラス宣言
        '--- 2024/09/04 start ---
        'Dim ExcelDt As DataTable = ClassExcelToDataTable.ExcelToDataTable(strFile, "", 1)
        Dim ExcelDt As DataTable = ClassExcelToDataTable.ExcelToDataTable1(strFile, "", 1)
        '--- 2024/09/04 end ---

        '取り込みファイルの件数チェック
        If ExcelDt.Rows.Count = 0 Then
            'Me.Cursor = Cursors.WaitCursor
            Cursor.Current = Cursors.Default
            MessageBox.Show("取込み出来ませんでした")
            Exit Sub
        End If
        '取り込みファイルのヘッダー存在チェック
        Dim clmName As String = ""
        For Each clm As DataColumn In ExcelDt.Columns
            If clm.ColumnName = "得意先コード" Then
                clmName = clm.ColumnName
            End If
        Next
        If clmName = "" Then
            'Me.Cursor = Cursors.WaitCursor
            Cursor.Current = Cursors.Default
            MessageBox.Show("入金連絡票以外のファイルが選択されています")
            Exit Sub
        End If

        '一覧表へ表示
        disp2(ExcelDt)
        'Me.Update()

        'Me.Cursor = Cursors.WaitCursor
        Cursor.Current = Cursors.Default

        MessageBox.Show("内容を確認し「更新」を行ってください。")

    End Sub

    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        Dim msgRt As DialogResult

        '----------検索・DB更新---------
        msgRt = MessageBox.Show("取込みデータをデータベースに書込みます。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If msgRt = DialogResult.No Then
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor

        '点検受付番号を検索、更新
        KOUSHIN()
        Cursor.Current = Cursors.Default

        MessageBox.Show("完了しました")

    End Sub

    'Private Sub kensaku()
    '    Dim strSQL As String
    '    Dim dt As DataTable

    '    '--- 2024/06/26 start ---
    '    ''--- 2024/06/26 start ---
    '    'Dim strJyouken As String = String.Empty

    '    'If Me.CheckBox全件対象.Checked = True Then
    '    '    strJyouken = ""
    '    'Else
    '    '    Dim dtFDM As DateTime
    '    '    Dim dtLDM As DateTime
    '    '    If DateTime.TryParse(Me.DateTimePicker請求日s.Text, dtFDM) = False Or DateTime.TryParse(Me.DateTimePicker請求日e.Text, dtLDM) = False Then
    '    '        MessageBox.Show("請求日期間が正しくありません。")
    '    '        Exit Sub
    '    '        If Me.DateTimePicker請求日s.Text > Me.DateTimePicker請求日s.Text Then
    '    '            MessageBox.Show("請求日期間が正しくありません。")
    '    '            Exit Sub
    '    '        End If
    '    '    End If
    '    '    '期間開始(請求日をyyyy/mm/ddにして検索)
    '    '    strJyouken = " and ( to_date(s.請求日, 'YYYY/MM/DD')  between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "' ) "
    '    'End If
    '    ''--- 2024/06/26 end ---

    '    'strSQL = "Select "
    '    'strSQL &= "  tmp.cst_cd       As ""得意先コード"" "
    '    'strSQL &= ", tmp.intr_rmrks   As ""請求書番号"" "
    '    'strSQL &= ", tmp.uketukeno    As ""点検受付番号"" "
    '    'strSQL &= ", tmp.entry_date   As ""更新日"" "
    '    'strSQL &= ", s.請求先宛名     As ""請求先会社/名"" "
    '    'strSQL &= ", s.請求合計金額   as ""請求合計金額"" "
    '    'strSQL &= ", s.請求日         as ""請求日"" "         '--- 2024/06/25 ---
    '    'strSQL &= " From tenken.t_002 as tmp"
    '    'strSQL &= " inner Join tenken.v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
    '    'strSQL &= " Left outer join tenken.t_kaisyu          as tk on tk.uketukeno   = tmp.uketukeno "
    '    'strSQL &= " where"
    '    'strSQL &= "  tmp.out_flg ='1' and "
    '    'strSQL &= "  tmp.sls_typ <>'3' and "
    '    'strSQL &= "  s.依頼区分 Not in ('15','17','16','19','20','21') and "        'TS・PT契約を除く
    '    'strSQL &= "  ( tmp.cst_cd = '901000' or tmp.cst_cd = '904000' ) and "     　'点検売上（別途請求）、点検売上（ＨＮ別途）
    '    'strSQL &= "  s.回収区分 = 'NR後日請求'            and "
    '    'strSQL &= "  tmp.intr_rmrks <> ''                 and "           　    　  '請求書番号
    '    'strSQL &= "  s.請求合計金額 <> '0'                and "
    '    'strSQL &= "  tk.入金日 Is null                    and "
    '    'strSQL &= "  tk.債権放棄通知書発行日 Is null "
    '    ''--- 2024/06/26 start ---
    '    ''strSQL &= "order by tmp.cst_cd asc , tmp.intr_rmrks asc , tmp.uketukeno asc , tmp.entry_date desc"
    '    'strSQL &= strJyouken
    '    'strSQL &= "order by tmp.cst_cd asc , tmp.intr_rmrks asc , tmp.uketukeno asc , tmp.entry_date desc ,  ""請求日"" asc"
    '    ''--- 2024/06/26 end ---
    '    'dt = ClassPostgeDB.SetTable(strSQL)

    '    'If dt.Rows.Count = 0 Then
    '    '    Exit Sub
    '    'End If

    '    Dim strJyouken As String = String.Empty
    '    Dim strJyouken2 As String = String.Empty
    '    Dim msg As String = String.Empty
    '    If Me.CheckBox全件対象.Checked = True Then
    '        '全件対象
    '        strJyouken = ""
    '    Else
    '        If (Me.MaskedTextBox請求日s.Text.Trim & Me.MaskedTextBox請求日e.Text &
    '            Me.MaskedTextBox売上日s.Text.Trim & Me.MaskedTextBox売上日e.Text).Replace("/", "").Trim = "" Then
    '            msg = "検索条件が指定されていません"
    '        Else
    '            If (Me.MaskedTextBox請求日s.Text.Trim & Me.MaskedTextBox請求日e.Text).Replace("/", "").Trim <> "" Then
    '                '請求日
    '                msg = "請求日の期間が正しく入力されていません"
    '                If IsDate(Me.MaskedTextBox請求日s.Text) = True And IsDate(Me.MaskedTextBox請求日e.Text) = True Then
    '                    If DateTime.Parse(Me.MaskedTextBox請求日s.Text) <= DateTime.Parse(Me.MaskedTextBox請求日e.Text) Then
    '                        strJyouken2 &= " and ( to_date(s.請求日, 'YYYY/MM/DD')  between '" & Me.MaskedTextBox請求日s.Text & "' and '" & Me.MaskedTextBox請求日e.Text & "' ) "
    '                        msg = ""
    '                    End If
    '                End If
    '            Else
    '                '売上日
    '                If msg = "" Then
    '                    msg = "売上日の期間が正しく入力されていません"
    '                    If IsDate(Me.MaskedTextBox売上日s.Text) = True And IsDate(Me.MaskedTextBox売上日e.Text) = True Then
    '                        If DateTime.Parse(Me.MaskedTextBox売上日s.Text) <= DateTime.Parse(Me.MaskedTextBox売上日e.Text) Then
    '                            strJyouken2 &= " and ( to_date(tmp.nextb, 'YYYY/MM/DD')  between '" & Me.MaskedTextBox売上日s.Text & "' and '" & Me.MaskedTextBox売上日e.Text & "' ) "
    '                            msg = ""
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '        If msg <> "" Then
    '            MessageBox.Show(msg)
    '            Exit Sub
    '        End If
    '    End If

    '    strSQL = "Select "
    '    strSQL &= "  tmp.cst_cd       As ""得意先コード"" "
    '    strSQL &= ", tmp.intr_rmrks   As ""請求書番号"" "
    '    strSQL &= ", tmp.uketukeno    As ""点検受付番号"" "
    '    strSQL &= ", tmp.entry_date   As ""更新日"" "
    '    strSQL &= ", s.請求先宛名     As ""請求先会社/名"" "
    '    strSQL &= ", s.請求合計金額   as ""請求合計金額"" "
    '    strSQL &= ", s.請求日         as ""請求日"" "
    '    strSQL &= ", tmp.nextb        as ""売上日"" "
    '    strSQL &= " From tenken.t_002 as tmp"
    '    strSQL &= " inner Join tenken.v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
    '    strSQL &= " Left outer join tenken.t_kaisyu          as tk on tk.uketukeno   = tmp.uketukeno "
    '    strSQL &= " where"
    '    strSQL &= "  tmp.out_flg ='1' and "
    '    strSQL &= "  tmp.sls_typ <>'3' and "
    '    strSQL &= "  s.依頼区分 Not in ('15','17','16','19','20','21') and "        'TS・PT契約を除く
    '    strSQL &= "  ( tmp.cst_cd = '901000' or tmp.cst_cd = '904000' ) and "     　'点検売上（別途請求）、点検売上（ＨＮ別途）
    '    strSQL &= "  s.回収区分 = 'NR後日請求'            and "
    '    strSQL &= "  tmp.intr_rmrks <> ''                 and "           　    　  '請求書番号
    '    strSQL &= "  s.請求合計金額 <> '0'                and "
    '    strSQL &= "  tk.入金日 Is null                    and "
    '    strSQL &= "  tk.債権放棄通知書発行日 Is null "
    '    strSQL &= strJyouken & strJyouken2
    '    strSQL &= "order by tmp.cst_cd asc , tmp.intr_rmrks asc , tmp.uketukeno asc , tmp.entry_date desc ,  ""請求日"" asc"
    '    '--- 2024/07/10 k.s end ---

    '    dt = ClassPostgeDB.SetTable(strSQL)

    '    If dt.Rows.Count = 0 Then
    '        Exit Sub
    '    End If


    '    'DataTableの作成
    '    Dim dt2 As New DataTable
    '    dt2.Columns.Add("得意先コード")
    '    dt2.Columns.Add("請求書番号")
    '    dt2.Columns.Add("請求先会社／名")
    '    dt2.Columns.Add("請求合計金額", GetType(Integer))
    '    dt2.Columns.Add("入金日")
    '    dt2.Columns.Add("請求日")          '--- 2024/06/26 ---
    '    dt2.Columns.Add("売上日")          '--- 2024/07/10  k.s ---
    '    Dim dt2Row As DataRow

    '    '初期値セット
    '    Dim intGoukei As Integer = 0
    '    Dim strOld_t As String = dt.Rows(0).Item("得意先コード").ToString
    '    Dim strOld_s As String = dt.Rows(0).Item("請求書番号").ToString
    '    Dim strOld_u As String = dt.Rows(0).Item("点検受付番号").ToString
    '    Dim strOld_k As String = dt.Rows(0).Item("請求先会社／名").ToString
    '    Dim strOld_d As String = DateFormat(dt.Rows(0).Item("請求日").ToString)    '--- 2024/06/26 ---
    '    Dim strOld_a As String = DateFormat(dt.Rows(0).Item("売上日").ToString)    '--- 2024/07/10 k.s ---

    '    For ro As Integer = 0 To dt.Rows.Count - 1

    '        If ro > 100 Then
    '            Dim test As String = ""
    '        End If

    '        If strOld_s = dt.Rows(ro).Item("請求書番号").ToString Then
    '            If dt.Rows.Count = 1 Then
    '                intGoukei = intGoukei + Math.Round(Double.Parse(dt.Rows(ro).Item("請求合計金額")))    '小数点以下は四捨五入
    '            Else
    '                If ro = 0 Then
    '                    intGoukei = intGoukei + Math.Round(Double.Parse(dt.Rows(ro).Item("請求合計金額")))    '小数点以下は四捨五入
    '                Else
    '                    If strOld_u <> dt.Rows(ro).Item("点検受付番号").ToString Then
    '                        intGoukei = intGoukei + Math.Round(Double.Parse(dt.Rows(ro).Item("請求合計金額")))    '小数点以下は四捨五入
    '                    End If
    '                End If
    '            End If
    '        Else
    '            '請求書番号が違う時
    '            intGoukei = intGoukei + Math.Round(Double.Parse(dt.Rows(ro).Item("請求合計金額")))    '小数点以下は四捨五入
    '        End If

    '        If ro <> dt.Rows.Count - 1 Then
    '            '請求書の番号が変わった時
    '            If dt.Rows(ro).Item("請求書番号").ToString <> dt.Rows(ro + 1).Item("請求書番号").ToString Then
    '                dt2Row = dt2.NewRow
    '                dt2Row("得意先コード") = dt.Rows(ro).Item("得意先コード").ToString
    '                dt2Row("請求書番号") = dt.Rows(ro).Item("請求書番号").ToString
    '                dt2Row("請求先会社／名") = dt.Rows(ro).Item("請求先会社／名").ToString
    '                dt2Row("請求合計金額") = intGoukei
    '                dt2Row("入金日") = ""
    '                dt2Row("請求日") = DateFormat(dt.Rows(ro).Item("請求日").ToString)    '--- 2024/06/26 ---
    '                dt2Row("売上日") = DateFormat(dt.Rows(ro).Item("売上日").ToString)    '--- 2024/07/10 k.s ---
    '                dt2.Rows.Add(dt2Row)
    '                intGoukei = 0
    '            End If
    '        End If

    '        strOld_t = dt.Rows(ro).Item("得意先コード").ToString
    '        strOld_s = dt.Rows(ro).Item("請求書番号").ToString
    '        strOld_u = dt.Rows(ro).Item("点検受付番号").ToString
    '        strOld_k = dt.Rows(ro).Item("請求先会社／名").ToString
    '        strOld_d = DateFormat(dt.Rows(ro).Item("請求日").ToString)   '--- 2024/06/26 ---
    '        strOld_a = DateFormat(dt.Rows(ro).Item("売上日").ToString)   '--- 2024/07/10 k.s ---
    '    Next
    '    '最後のデータの時
    '    dt2Row = dt2.NewRow
    '    dt2Row("得意先コード") = strOld_t
    '    dt2Row("請求書番号") = strOld_s
    '    dt2Row("請求先会社／名") = strOld_k
    '    dt2Row("請求合計金額") = intGoukei
    '    dt2Row("入金日") = ""
    '    dt2Row("請求日") = DateFormat(strOld_d)   '--- 2024/06/26 ---
    '    dt2Row("売上日") = DateFormat(strOld_a)   '--- 2024/07/10 k.s ---
    '    dt2.Rows.Add(dt2Row)

    '    '一覧表へ表示
    '    disp(dt2)
    'End Sub


    '-----------------------------------------------------
    '【検索】ボタン
    '2025/01/06 k.s 
    '回収データを002に合わせて複数件持つように変更
    '請求書番号で集計する時に、入金日が未入力のもの全て対象にし、請求合計金額が0のものも対象とする
    '-----------------------------------------------------
    Private Sub kensaku()
        Dim strSQL As String
        Dim dt As DataTable

        Dim strJyouken As String = String.Empty
        Dim strJyouken2 As String = String.Empty
        Dim msg As String = String.Empty
        If Me.CheckBox全件対象.Checked = True Then
            '全件対象
            strJyouken = ""
        Else
            If (Me.MaskedTextBox請求日s.Text.Trim & Me.MaskedTextBox請求日e.Text &
                Me.MaskedTextBox売上日s.Text.Trim & Me.MaskedTextBox売上日e.Text).Replace("/", "").Trim = "" Then
                msg = "検索条件が指定されていません"
            Else
                If (Me.MaskedTextBox請求日s.Text.Trim & Me.MaskedTextBox請求日e.Text).Replace("/", "").Trim <> "" Then
                    '請求日
                    msg = "請求日の期間が正しく入力されていません"
                    If IsDate(Me.MaskedTextBox請求日s.Text) = True And IsDate(Me.MaskedTextBox請求日e.Text) = True Then
                        If DateTime.Parse(Me.MaskedTextBox請求日s.Text) <= DateTime.Parse(Me.MaskedTextBox請求日e.Text) Then
                            strJyouken2 &= " and ( to_date(s.請求日, 'YYYY/MM/DD')  between '" & Me.MaskedTextBox請求日s.Text & "' and '" & Me.MaskedTextBox請求日e.Text & "' ) "
                            msg = ""
                        End If
                    End If
                Else
                    '売上日
                    If msg = "" Then
                        msg = "売上日の期間が正しく入力されていません"
                        If IsDate(Me.MaskedTextBox売上日s.Text) = True And IsDate(Me.MaskedTextBox売上日e.Text) = True Then
                            If DateTime.Parse(Me.MaskedTextBox売上日s.Text) <= DateTime.Parse(Me.MaskedTextBox売上日e.Text) Then
                                strJyouken2 &= " and ( to_date(tmp.nextb, 'YYYY/MM/DD')  between '" & Me.MaskedTextBox売上日s.Text & "' and '" & Me.MaskedTextBox売上日e.Text & "' ) "
                                msg = ""
                            End If
                        End If
                    End If
                End If
            End If
            If msg <> "" Then
                MessageBox.Show(msg)
                Exit Sub
            End If
        End If

        strSQL = "Select "
        strSQL &= "  tmp.cst_cd            as ""得意先コード"" "
        strSQL &= ", tmp.intr_rmrks        as ""請求書番号"" "
        strSQL &= ", s.請求先宛名          as ""請求先会社／名"" "
        strSQL &= ", sum(cast(s.請求合計金額 as numeric))    as ""請求合計金額"" "
        strSQL &= ", TO_CHAR(to_date(s.請求日, 'YYYY/MM/DD'),'yyyy/mm/dd')         as ""請求日"" "
        strSQL &= ", tmp.nextb             as ""売上日"" "
        strSQL &= " From tenken.t_002 as tmp"
        strSQL &= " inner Join tenken.v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
        strSQL &= " Left outer join tenken.t_kaisyu          as tk on tk.uketukeno   = tmp.uketukeno and tk.seq  = tmp.seq "
        strSQL &= " where"
        strSQL &= "  tmp.out_flg ='1' and "                                              '出庫済
        strSQL &= "  ( tmp.entry = '' or tmp.entry is null ) and " 　　　　　　　　　 　 '削除済は対象外（"DELETE"以外)
        strSQL &= "  s.依頼区分 Not in ('15','17','16','19','20','21') and "             'TS・PT契約を除く
        strSQL &= "  ( tmp.cst_cd = '901000' or tmp.cst_cd = '904000' ) and "          　'点検売上（別途請求）、点検売上（ＨＮ別途）
        strSQL &= "  s.回収区分 = 'NR後日請求'              and "　　　　　　　     　   'NR後日のみ
        strSQL &= "  tmp.intr_rmrks <> ''                   and "                        '請求書番号
        strSQL &= "  tk.入金日 Is null                      and "　　　　　　　　     　 '入金日が未入力のもの全て
        strSQL &= "  tk.債権放棄通知書発行日 is null  "                                  '債権放棄通知書発行日が未入力のもの全て
        strSQL &= strJyouken & strJyouken2
        strSQL &= "group by tmp.cst_cd     , tmp.intr_rmrks     ,  s.請求先宛名  , s.請求日, tmp.nextb "
        strSQL &= "order by tmp.cst_cd asc , tmp.intr_rmrks asc ,  ""請求日"" asc, ""売上日"" asc "

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 0 Then
            Exit Sub
        End If

        '一覧表へ表示
        disp(dt)
    End Sub

    Private Sub disp(Dt As DataTable)
        Dim ro As Integer = 0

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = Dt

        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "得意先コード", "得意先コード", 100, True)     '0
        ro = settextColumn(Me.DataGridView1, ro, "請求書番号", "請求書番号", 130, True)         '1
        ro = settextColumn(Me.DataGridView1, ro, "請求先会社／名", "請求先会社／名", 200, True) '2
        ro = settextColumn(Me.DataGridView1, ro, "請求合計金額", "請求合計金額", 120, True)     '3
        ro = settextColumn(Me.DataGridView1, ro, "入金日", "入金日", 130, True)                 '4
        ro = settextColumn(Me.DataGridView1, ro, "請求日", "請求日", 130, True)                 '5    ---- 2024/06/26 ---
        ro = settextColumn(Me.DataGridView1, ro, "売上日", "売上日", 130, True)                 '6    ---- 2024/07/10 ---

        '金額右寄せ
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '請求合計金額

        Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

    End Sub
    Private Sub disp2(Dt As DataTable)
        Dim ro As Integer = 0

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = Dt

        Me.Update()

        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "得意先コード", "得意先コード", 100, True)       '0
        ro = settextColumn(Me.DataGridView1, ro, "請求書番号", "請求書番号", 130, True)           '1
        ro = settextColumn(Me.DataGridView1, ro, "請求先会社／名", "請求先会社／名", 200, True)   '2
        ro = settextColumn(Me.DataGridView1, ro, "請求合計金額", "請求合計金額", 120, True)       '3
        ro = settextColumn(Me.DataGridView1, ro, "入金日", "入金日", 130, True)                   '4
        ro = settextColumn(Me.DataGridView1, ro, "請求日", "請求日", 125, True)                   '5      --- 2024/06/26 ---
        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 200, True)       '6

        '金額右寄せ
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '請求合計金額

        Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

    End Sub

    Private Sub KOUSHIN()
        Dim strSQL As String
        Dim dt As DataTable
        Dim intCnt As Integer = 0

        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count - 1
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        '---2025/01/06 k.s start --- 回収データを複数件持つようになった為修正 ---
        '
        'For ro As Integer = 0 To DataGridView1.Rows.Count - 1
        '    ToolStripProgressBar1.Value = ro
        '    Dim strSNO As String = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString.Trim                     '請求書番号
        '    Dim strUNO As String = ""                                                                         '点検受付番号
        '    Dim strDAY As String = ""                                                                         '入金日
        '    Dim d As DateTime

        '    'EXCELの入金日が日付以外の場合は取込まない
        '    If DateTime.TryParse(Me.DataGridView1.Rows(ro).Cells(4).Value.ToString.Trim, d) = True Then

        '        '同じ請求書番号の入金日は全て同じ
        '        strDAY = "TO_DATE('" & d.ToShortDateString & "', 'YYYY/MM/DD')"

        '        '請求書番号から点検受付番号、代表点検受付番号を取得する（002には受付番号が重複している為最新の更新日のものを取得する）
        '        strSQL = "select "
        '        strSQL &= "  t_002.intr_rmrks                    as ""請求書番号"" "
        '        strSQL &= " ,v_yuryo_tenken_syuyaku.点検受付番号 as 点検受付番号 "
        '        strSQL &= " from " & schema & "t_002 "
        '        strSQL &= " inner join " & schema & "v_yuryo_tenken_syuyaku on v_yuryo_tenken_syuyaku.点検受付番号 = t_002.uketukeno AND t_002.out_flg ='1' and t_002.sls_typ <>'3' "
        '        strSQL &= " where "
        '        'strSQL &= " t_002.entry_date >= (select Max(A.entry_date) from " & schema & "t_002 as A  where A.uketukeno = t_002.uketukeno)  and "   '2024/07/22 k.s
        '        strSQL &= " t_002.entry_date >= (select Max(A.entry_date) from " & schema & "t_002 as A  where A.uketukeno = t_002.uketukeno and A.out_flg ='1' and A.sls_typ <>'3')  and "    '2024/07/22 k.s
        '        strSQL &= " t_002.intr_rmrks ='" & strSNO & "'"

        '        dt = ClassPostgeDB.SetTable(strSQL)

        '        '一つの請求書番号に複数の点検受付番号が存在する
        '        For Each rows In dt.Rows
        '            If dt.Rows.Count > 0 Then
        '                '--- 2024/06/26 start ---
        '                'If Me.DataGridView1.Rows(ro).Cells(5).Value <> Nothing Then
        '                '    Me.DataGridView1.Rows(ro).Cells(5).Value = Me.DataGridView1.Rows(ro).Cells(5).Value & "、"
        '                'End If
        '                'Me.DataGridView1.Rows(ro).Cells(5).Value = Me.DataGridView1.Rows(ro).Cells(5).Value & rows("点検受付番号").ToString.Trim     '点検受付番号
        '                If Me.DataGridView1.Rows(ro).Cells(6).Value <> Nothing Then
        '                    Me.DataGridView1.Rows(ro).Cells(6).Value = Me.DataGridView1.Rows(ro).Cells(6).Value & "、"
        '                End If
        '                Me.DataGridView1.Rows(ro).Cells(6).Value = Me.DataGridView1.Rows(ro).Cells(6).Value & rows("点検受付番号").ToString.Trim     '点検受付番号
        '                '--- 2024/06/26 start ---
        '                strUNO = rows("点検受付番号").ToString.Trim
        '            End If

        '            Dim strSQL2 As String
        '            Dim dt2 As DataTable
        '            strSQL2 = "Select 入金日, UketukeNo FROM " & schema & "t_kaisyu where uketukeno  = '" & strUNO & "'"

        '            dt2 = ClassPostgeDB.SetTable(strSQL2)
        '            If dt2.Rows.Count = 0 Then
        '                strSQL2 = "INSERT INTO " & schema & "t_kaisyu "
        '                strSQL2 &= "( "
        '                strSQL2 &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno       , 請求書再発行日      , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
        '                strSQL2 &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
        '                strSQL2 &= " 決裁書発行日           , ss請求      , 未回収架電確認日  , 確認者          , 備考                , 色              , 入金予定日担当者    , 残明細削除フラグ      , "
        '                'strSQL2 &= " 更新日                 , 更新者 "           '2024/07/10 k.s
        '                strSQL2 &= " 更新日 , 更新者 , 特別消費税フラグ "         '2024/07/10 k.s
        '                strSQL2 &= ")"
        '                strSQL2 &= "VALUES("
        '                strSQL2 &= "   " & strDAY
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " ,'" & strUNO & "'"
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " , NULL "

        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " , NULL "

        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " , NULL "
        '                strSQL2 &= " ,'' "
        '                strSQL2 &= " ,now()"
        '                strSQL2 &= " ,'" & UserID & "'"
        '                strSQL2 &= " ,'' "                      '2024/07/10 k.s
        '                strSQL2 &= " ,'" & strSEQ & "'"         '2024/12/24 k.s
        '                strSQL2 &= ")"
        '            Else
        '                '検索有り、入金日が入っている場合は上書きする（但し空白には戻さない）
        '                If strDAY <> "NULL" Then
        '                    strSQL2 = "UPDATE " & schema & "t_kaisyu "
        '                    strSQL2 &= " SET "
        '                    strSQL2 &= "  入金日    =" & strDAY
        '                    strSQL2 &= " ,更新日    =now() "
        '                    strSQL2 &= " ,更新者    ='" & UserID & "'"
        '                    strSQL2 &= "  WHERE uketukeno = '" & strUNO & "'"
        '                End If
        '            End If
        '            ClassPostgeDB.EXEC(strSQL2)
        '            intCnt += 1
        '        Next
        '    End If
        'Next
        '
        For ro As Integer = 0 To DataGridView1.Rows.Count - 1
            ToolStripProgressBar1.Value = ro

            Dim strSNO As String = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString.Trim      '請求書番号
            Dim strUNO As String = ""                                                          '点検受付番号
            Dim strDAY As String = ""                                                          '入金日
            Dim d As DateTime
            Dim strUNO_OLD As String = ""                                                      '請求書番号(旧)
            Dim strSEQ As String = ""    　　　　　　　　　　　　　                            'SEQ

            'EXCELの入金日が日付以外の場合は取込まない
            If DateTime.TryParse(Me.DataGridView1.Rows(ro).Cells(4).Value.ToString.Trim, d) = True Then

                '同じ請求書番号の入金日は全て同じ
                strDAY = "TO_DATE('" & d.ToShortDateString & "', 'YYYY/MM/DD')"

                '請求書番号から点検受付番号、代表点検受付番号を取得する
                '（002には受付番号が重複している為最新の更新日のものを取得する）
                '（一番新しい出庫日＝一番新しい更新日＝一番大きいseq　全て同じデータを意味する）
                strSQL = "select "
                strSQL &= "  t_002.intr_rmrks         as ""請求書番号"" "
                strSQL &= " ,t_002.uketukeno          as ""点検受付番号"" "
                strSQL &= " ,t_002.seq                as ""seq"" "
                strSQL &= " from " & schema & "t_002 "
                strSQL &= " where "
                strSQL &= " t_002.out_flg ='1' and t_002.sls_typ <>'3'  and t_002.intr_rmrks ='" & strSNO & "'"
                strSQL &= " ORDER BY t_002.uketukeno asc , t_002.seq desc"

                dt = ClassPostgeDB.SetTable(strSQL)

                '一つの請求書番号に複数の点検受付番号が存在する
                For Each rows In dt.Rows

                    If rows("点検受付番号").ToString.Trim <> strUNO_OLD Then

                        If dt.Rows.Count > 0 Then
                            If Me.DataGridView1.Rows(ro).Cells(6).Value <> Nothing Then
                                Me.DataGridView1.Rows(ro).Cells(6).Value = Me.DataGridView1.Rows(ro).Cells(6).Value & "、"
                            End If
                            Me.DataGridView1.Rows(ro).Cells(6).Value = Me.DataGridView1.Rows(ro).Cells(6).Value & rows("点検受付番号").ToString.Trim     '点検受付番号
                            strUNO = rows("点検受付番号").ToString.Trim
                            strUNO_OLD = rows("点検受付番号").ToString.Trim
                            strSEQ = rows("SEQ").ToString.Trim
                        End If

                        Dim strSQL2 As String
                        Dim dt2 As DataTable
                        strSQL2 = "Select 入金日, UketukeNo FROM " & schema & "t_kaisyu where uketukeno  = '" & strUNO & "'"
                        strSQL2 &= " AND seq='" & strSEQ & "'"

                        dt2 = ClassPostgeDB.SetTable(strSQL2)
                        If dt2.Rows.Count = 0 Then
                            strSQL2 = "INSERT INTO " & schema & "t_kaisyu "
                            strSQL2 &= "( "
                            strSQL2 &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno       , 請求書再発行日      , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
                            strSQL2 &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
                            strSQL2 &= " 決裁書発行日           , ss請求      , 未回収架電確認日  , 確認者          , 備考                , 色              , 入金予定日担当者    , 残明細削除フラグ      , "
                            strSQL2 &= " 更新日 , 更新者 , 特別消費税フラグ , SEQ "
                            strSQL2 &= ")"
                            strSQL2 &= "VALUES("
                            strSQL2 &= "   " & strDAY
                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " ,'" & strUNO & "'"
                            strSQL2 &= " , NULL "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " , NULL "

                            strSQL2 &= " ,'' "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " , NULL "

                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " , NULL "
                            strSQL2 &= " ,'' "
                            strSQL2 &= " ,now()"
                            strSQL2 &= " ,'" & UserID & "'"
                            strSQL2 &= " ,'' "
                            strSQL2 &= " ,'" & strSEQ & "'"
                            strSQL2 &= ")"

                        Else
                            '検索有り、入金日が入っている場合は上書きする（但し空白には戻さない）
                            If strDAY <> "NULL" Then
                                strSQL2 = "UPDATE " & schema & "t_kaisyu "
                                strSQL2 &= " SET "
                                strSQL2 &= "  入金日    =" & strDAY
                                strSQL2 &= " ,更新日    =now() "
                                strSQL2 &= " ,更新者    ='" & UserID & "'"
                                strSQL2 &= "  WHERE uketukeno = '" & strUNO & "'"
                                strSQL2 &= "  AND   seq = '" & strSEQ & "'"
                            End If
                        End If
                        ClassPostgeDB.EXEC(strSQL2)
                        intCnt += 1
                    End If
                Next

            End If
        Next
        '---2025/01/06 k.s end --- 回収データを複数件持つようになった為修正 ---

        ToolStripProgressBar1.Value = 0

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class