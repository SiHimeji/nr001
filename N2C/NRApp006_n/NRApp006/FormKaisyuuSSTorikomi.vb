Public Class FormKaisyuuSSTorikomi
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim intSyoriFlag As Integer = 0        '1:明細取込み　2:明細取込みキャンセル　3:入金日セット

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
    'SS請求取込み
    '---------------------------
    Private Sub FormKaisyuuSSTorikomi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TextBoxss請求指定.Text = ""

        Me.TextBoxss請求.Text = ""
        Me.MaskedTextBoxss請求入金日.Text = Now()

        ToolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right
        ToolStripStatusLabel1.Text = "　合計金額（税抜き）＝"
        ToolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right
        ToolStripStatusLabel2.Text = "　合計金額（税込み）＝"
    End Sub

    '---------------------------
    'メニュー―　閉じる
    '---------------------------
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click

        Me.Close()

    End Sub

    '---------------------------
    'メニュー　EXCEL出力
    '---------------------------
    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If

    End Sub
    '---------------------------
    'メニュー　ss請求 取込み
    '---------------------------
    Private Sub 取込みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取込みToolStripMenuItem.Click
        Dim msgRt As DialogResult
        Dim ro As Integer = 0

        intSyoriFlag = 1
        '一覧表クリアー
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        msgRt = MessageBox.Show("EXCELファイルの取込みを開始します" & vbCrLf & vbCrLf &
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
        Dim ExcelDt As DataTable = ClassExcelToDataTable.ExcelToDataTable2(strFile, "", 1)

        '取り込みデータのチェック
        If ExcelDt.Rows.Count = 0 Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("取込み出来ませんでした")
            Exit Sub
        End If

        '一覧表へ表示
        disp(ExcelDt)

        Cursor.Current = Cursors.Default
        MessageBox.Show("内容を確認し「更新」を行ってください。")

    End Sub

    '---------------------------
    'メニュー　ss請求 取込みキャンセル
    '---------------------------
    Private Sub キャンセルToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取込みキャンセルToolStripMenuItem.Click
        Dim msgRt As DialogResult
        Dim ro As Integer = 0

        intSyoriFlag = 2
        '一覧表クリアー
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        msgRt = MessageBox.Show("EXCELファイルを取込み「ss請求」を更新前に戻します" & vbCrLf & vbCrLf &
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
        Dim ExcelDt As DataTable = ClassExcelToDataTable.ExcelToDataTable2(strFile, "", 1)

        '取り込みファイルの件数チェック
        If ExcelDt.Rows.Count = 0 Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("取込み出来ませんでした")
            Exit Sub
        End If

        '一覧表へ表示
        disp(ExcelDt)
        Me.Update()

        Cursor.Current = Cursors.Default
        MessageBox.Show("内容を確認し「更新」を行ってください。")
    End Sub

    '---------------------------
    'メニュー　ss請求入金日　一括更新表示
    '---------------------------
    Private Sub 一括更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 一括更新ToolStripMenuItem.Click

        intSyoriFlag = 3
        '一覧表クリアー
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        If Me.TextBoxss請求.Text.Trim = "" Or Me.TextBoxss請求.Text.Trim.Length < 6 Then
            MessageBox.Show("ss請求を入力してください")
            Exit Sub
        Else
            '一覧表へ表示
            disp2()
            MessageBox.Show("内容を確認し「更新」を行ってください。")
        End If

    End Sub

    '---------------------------
    'メニュー　更新
    '---------------------------
    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        Dim msgRt As DialogResult

        If Me.DataGridView1.Rows.Count = 0 Then
            Exit Sub
        End If

        If intSyoriFlag = 1 Then

            '----------条件チェック---------
            If Me.TextBoxss請求指定.Text.Trim = "" Or Me.TextBoxss請求指定.Text.Trim.Length <> 6 Then
                MessageBox.Show("ss請求を入力してください")
                Exit Sub
            End If
            If Me.TextBoxss請求指定.Text.Trim <> Me.DataGridView1.Rows(0).Cells(0).Value.ToString.Trim() Then
                msgRt = MessageBox.Show("「ss請求」と「作成年月」が違います。" & vbCrLf & vbCrLf &
                                        "このままＤＢを更新してもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            Else
                msgRt = MessageBox.Show("ＤＢを更新します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            End If

            If msgRt = DialogResult.No Then
                Exit Sub
            End If
            '更新
            koushin(0)
            MessageBox.Show("更新が完了しました")

        ElseIf intSyoriFlag = 2 Then
            msgRt = MessageBox.Show("キャンセルとしてＤＢを更新します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If msgRt = DialogResult.No Then
                Exit Sub
            End If
            '更新
            koushin(1)
            MessageBox.Show("更新が完了しました")

        ElseIf intSyoriFlag = 3 Then
            Dim strNday As String = String.Empty

            If DataGridView1.Rows.Count = 0 Then
                Exit Sub
            Else
                Me.MaskedTextBoxss請求入金日.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals    'ﾌｫｰﾏｯﾄ無し
                strNday = Me.MaskedTextBoxss請求入金日.Text.Trim                                     'ss請求入金日
                Me.MaskedTextBoxss請求入金日.TextMaskFormat = MaskFormat.IncludeLiterals             'ﾌｫｰﾏｯﾄ有りに戻す

                If strNday = "" Then
                    strNday = "NULL"
                Else
                    If DateKata(Me.MaskedTextBoxss請求入金日.Text.Trim) = "NULL" Then
                        strNday = ""
                        MessageBox.Show("ss請求入金日が正しくありません")
                        Exit Sub
                    Else
                        strNday = "'" & Me.MaskedTextBoxss請求入金日.Text.Trim & "'"
                    End If
                End If
            End If

            msgRt = MessageBox.Show("一括でＤＢを更新します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If msgRt = DialogResult.No Then
                Exit Sub
            End If
            '更新
            koushin2(strNday)
            MessageBox.Show("更新が完了しました")
        End If

    End Sub


    '---------------------------
    'ss請求 取込み表示
    '---------------------------
    Private Sub disp(Dt As DataTable)
        Dim ro As Integer = 0

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = Dt

        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "作成年月", "作成年月", 120, True)             '0
        ro = settextColumn(Me.DataGridView1, ro, "№", "№", 60, True)                          '1
        ro = settextColumn(Me.DataGridView1, ro, "ブランド", "ブランド", 100, True)             '2
        ro = settextColumn(Me.DataGridView1, ro, "メーカー", "メーカー", 100, True)             '3
        ro = settextColumn(Me.DataGridView1, ro, "所課名", "所課名", 200, True)                 '4
        ro = settextColumn(Me.DataGridView1, ro, "ＳＳコード", "ＳＳコード", 120, True)         '5
        ro = settextColumn(Me.DataGridView1, ro, "ＳＳ名", "ＳＳ名", 100, True)                 '6
        ro = settextColumn(Me.DataGridView1, ro, "受付№", "受付№", 100, True)                 '7 
        ro = settextColumn(Me.DataGridView1, ro, "受付日", "受付日", 100, True)                 '8
        ro = settextColumn(Me.DataGridView1, ro, "完了日", "完了日", 120, True)                 '9

        ro = settextColumn(Me.DataGridView1, ro, "点検技術料", "点検技術料", 120, True)         '10
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 100, True)                 '11
        ro = settextColumn(Me.DataGridView1, ro, "諸経費", "諸経費", 100, True)                 '12
        ro = settextColumn(Me.DataGridView1, ro, "サポート料", "サポート料", 120, True)         '13
        ro = settextColumn(Me.DataGridView1, ro, "その他", "その他", 100, True)                 '14
        ro = settextColumn(Me.DataGridView1, ro, "値引き", "値引き", 100, True)                 '15
        ro = settextColumn(Me.DataGridView1, ro, "合計（税抜き）", "合計（税抜き）", 120, True) '16

        ro = settextColumn(Me.DataGridView1, ro, "承認日", "承認日", 100, True)                 '17
        ro = settextColumn(Me.DataGridView1, ro, "業務区分", "業務区分", 120, True)             '18
        ro = settextColumn(Me.DataGridView1, ro, "製品名", "製品名", 120, True)                 '19
        ro = settextColumn(Me.DataGridView1, ro, "点検料金分類", "点検料金分類", 120, True)     '20

        Dim TextColumn1 As New DataGridViewTextBoxColumn()
        TextColumn1.DataPropertyName = "回収合計金額"
        TextColumn1.Name = "Column21"
        TextColumn1.HeaderText = "回収合計金額"
        Me.DataGridView1.Columns.Add(TextColumn1)
        Me.DataGridView1.Columns(21).Width = 120                                                '21

        Dim TextColumn2 As New DataGridViewTextBoxColumn()
        TextColumn2.DataPropertyName = "ﾁｪｯｸ"
        TextColumn2.Name = "Column22"
        TextColumn2.HeaderText = "ﾁｪｯｸ"
        Me.DataGridView1.Columns.Add(TextColumn2)
        Me.DataGridView1.Columns(22).Width = 50                                                '22

        '--- 2025/01/06 k.s start --
        Dim TextColumn3 As New DataGridViewTextBoxColumn()
        TextColumn3.DataPropertyName = "SEQ"
        TextColumn3.Name = "Column23"
        TextColumn3.HeaderText = "SEQ"
        Me.DataGridView1.Columns.Add(TextColumn3)
        Me.DataGridView1.Columns(23).Width = 50                                                '23
        '--- 2025/01/06 k.s end --

        '金額右寄せ
        Me.DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        Me.DataGridView1.Columns(10).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(11).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(12).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(13).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(14).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(16).DefaultCellStyle.Format = "#,0"

        Me.DataGridView1.Columns(6).HeaderCell.Style.ForeColor = Color.Red         '受付№

        '金額取得、チェック、合計計算
        Dim intgoukei As Integer = 0
        Dim intKaisyuGoukei As Integer = 0
        For row As Integer = 0 To DataGridView1.Rows.Count - 2
            '回収合計金額取得とチェック
            GetKingakuChk(row)

            intgoukei += Integer.Parse(Me.DataGridView1.Rows(row).Cells(16).Value.ToString)         '金額（税抜き）の合計
            intKaisyuGoukei += Integer.Parse(Me.DataGridView1.Rows(row).Cells(21).Value.ToString)　 '回収金額（税抜き）の合計
        Next
        ToolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right
        ToolStripStatusLabel1.Text = "　合計金額（税抜き）＝" & intgoukei.ToString("#,0")
        ToolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right
        ToolStripStatusLabel2.Text = "　回収合計金額（税抜き）＝" & intKaisyuGoukei.ToString("#,0")

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        '---2025/01/06 k.s start ---
        '並び替えができないようにする(取込みデータの並びをそのまま固定)
        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        '---2025/01/06 k.s end ---
    End Sub

    '---------------------------
    'ss請求入金日 一括更新用表示
    '---------------------------
    Private Sub disp2()
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Integer = 0

        '--- 2025/01/06 k.s start ---
        'strSQL = "select"
        'strSQL &= " tmp.uketukeno   as ""点検受付番号"" "
        'strSQL &= ",CAST(max(case tmp.seq when 1  then tmp.upri    else null end) as INT) as ""回収金額"" "
        'strSQL &= ",max(case tmp.seq when 1  then tmp.entry_date   else null end)         as ""更新日"" "
        'strSQL &= ",sum(cast(s.請求合計金額 as numeric))                                  as ""請求合計金額"" "
        'strSQL &= ",tk.入金日 "
        'strSQL &= ",tk.ss請求 "
        'strSQL &= "from "
        'strSQL &= "( "
        'strSQL &= "    select "
        'strSQL &= "         uketukeno "
        'strSQL &= "        ,nextb "
        'strSQL &= "        ,cst_cd "
        'strSQL &= "        ,scst_nm "
        'strSQL &= "        ,itm_cd "
        'strSQL &= "        ,cst_po_no "
        'strSQL &= "        ,intr_rmrks "
        'strSQL &= "        ,slip_rmrks "
        'strSQL &= "        ,ord_psn_nm "
        'strSQL &= "        ,qty "
        'strSQL &= "        ,upri "
        'strSQL &= "        ,out_flg "
        'strSQL &= "        ,entry_date "
        'strSQL &= "        ,tyoufuku "                           '重複
        'strSQL &= "        ,sls_typ"                             '削除の時は3
        'strSQL &= "        ,row_number() over (partition by uketukeno order by entry_date desc) as seq "
        'strSQL &= "    from  " & schema & "t_002 "
        'strSQL &= "    where out_flg ='1' "
        'strSQL &= ") as tmp "
        'strSQL &= "inner join " & schema & "v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
        'strSQL &= "left outer join " & schema & "t_kaisyu          as tk on tk.uketukeno = tmp.uketukeno "
        'strSQL &= "where tmp.out_flg ='1'  and "                                    '出荷済
        'strSQL &= "      tmp.sls_typ <>'3' and "                                    '削除済以外
        'strSQL &= "      tmp.seq ='1'     and "                                     '複数データの1件名
        'strSQL &= "      s.依頼区分 Not in ('15','17','16','19','20','21') and "    'TS・PT契約を除く
        'strSQL &= "      tk.ss請求 = '" & Me.TextBoxss請求.Text.Trim & "' "
        'strSQL &= "group by "
        'strSQL &= " tmp.uketukeno , cast(s.請求合計金額 as numeric),tk.入金日 , tk.ss請求"

        strSQL = "select"
        strSQL &= " tmp.uketukeno         as ""点検受付番号"" "
        strSQL &= ",CAST(tmp.upri as INT) as ""回収金額"" "
        strSQL &= ",tmp.entry_date        as ""更新日"" "
        strSQL &= ", COALESCE(cast(s.請求合計金額 as numeric),0) as ""請求合計金額"" "
        strSQL &= ",tk.入金日 "
        strSQL &= ",tk.ss請求 "
        strSQL &= ",tmp.SEQ "
        strSQL &= "from " & schema & "t_002 as tmp "
        strSQL &= "inner join " & schema & "v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
        strSQL &= "left outer join " & schema & "t_kaisyu          as tk on tk.uketukeno = tmp.uketukeno and tk.seq = tmp.seq "
        strSQL &= "where tmp.out_flg ='1'  and "                                    '出荷済
        'strSQL &= "      tmp.sls_typ <>'3' and "                                   '削除済以外（赤伝は対象)
        strSQL &= "     (tmp.entry = '' or tmp.entry is null ) and " 　       　  　'削除済は対象外（"DELETE"以外)
        strSQL &= "      s.依頼区分 Not in ('15','17','16','19','20','21') and "    'TS・PT契約を除く
        strSQL &= "      tk.ss請求 = '" & Me.TextBoxss請求.Text.Trim & "' "
        strSQL &= "order by "
        strSQL &= " tmp.uketukeno , tmp.SEQ"
        '--- 2025/01/06 k.s end ---
        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 0 Then
            Exit Sub
        End If

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 100, True)        '0
        ro = settextColumn(Me.DataGridView1, ro, "ss請求", "ss請求", 100, True)                    '1
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 120, True)                '2
        ro = settextColumn(Me.DataGridView1, ro, "請求合計金額", "請求合計金額", 120, True)        '3
        ro = settextColumn(Me.DataGridView1, ro, "入金日", "入金日", 120, True)                    '4
        ro = settextColumn(Me.DataGridView1, ro, "SEQ", "SEQ", 50, True)                           '5 2025/01/06 k.s

        Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

        Me.DataGridView1.Columns(2).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"

        '合計計算
        Dim intgoukei As Double = 0
        Dim intKaisyuGoukei As Double = 0
        For row As Integer = 0 To Me.DataGridView1.Rows.Count - 2
            If Me.DataGridView1.Rows(row).Cells(2).Value.ToString <> "" Then
                intgoukei += Double.Parse(Me.DataGridView1.Rows(row).Cells(2).Value.ToString)              '回収金額（税抜き）の合計
            End If
            If Me.DataGridView1.Rows(row).Cells(3).Value.ToString <> "" Then
                intKaisyuGoukei += Double.Parse(Me.DataGridView1.Rows(row).Cells(3).Value.ToString)        '請求金額（税込み）の合計
            End If
        Next

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        ToolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right
        ToolStripStatusLabel1.Text = "　合計金額（税抜き）＝" & intgoukei.ToString("#,0")
        ToolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right
        ToolStripStatusLabel2.Text = "　合計金額（税込み）＝" & intKaisyuGoukei.ToString("#,0")


    End Sub

    '---------------------------
    'DB更新
    '---------------------------
    Private Sub koushin(intFlag As Integer)
        Dim strSQL As String
        Dim dt As DataTable
        'Dim intRow As Integer = 0

        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count - 1
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        For ro As Integer = 0 To DataGridView1.Rows.Count - 1

            ToolStripProgressBar1.Value = ro

            '金額チェックでOKのもののみ更新するように修正　--- 2025/01/06 k.s ---
            If Me.DataGridView1.Rows(ro).Cells(22).Value.ToString.Trim = "OK" Then

                If intFlag = 0 Then
                    '【取込み】
                    strSQL = "SELECT uketukeno,入金日,ss請求 FROM " & schema & "t_kaisyu where uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(7).Value.ToString.Trim & "'"
                    strSQL &= " AND SEQ  = '" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"       '2025/01/06 k.s
                    dt = ClassPostgeDB.SetTable(strSQL)
                    If dt.Rows.Count = 0 Then
                        strSQL = "INSERT INTO " & schema & "t_kaisyu "
                        strSQL &= "( "
                        strSQL &= " 入金日                 , 入金予定日  , 入金確認内容      , uketukeno      , 請求書再発行日     , 振込期日        , 未入金架電日１回目  , 未入金架電日１回目結果, 未入金架電日２回目  ,"
                        strSQL &= " 未入金架電日２回目結果 , 督促状発行日, 振込期日督促状発行, 未入金架電１回目, 未入金架電１回目結果, 未入金架電２回目, 未入金架電２回目結果, 受付拒否設定日        , 債権放棄通知書発行日,"
                        strSQL &= " 決裁書発行日           , ss請求      , 未回収架電確認日  , 確認者 , 備考 , 色 , 入金予定日担当者 , 残明細削除フラグ , "
                        'strSQL &= " 更新日                 , 更新者 "                '2024/07/10 k.s 
                        strSQL &= " 更新日 , 更新者 , 特別消費税フラグ "              '2024/07/10 k.s
                        strSQL &= " ,SEQ "                             '2025/01/06 k.s
                        strSQL &= ")"
                        strSQL &= "VALUES("
                        strSQL &= "   NULL "        '入金日
                        strSQL &= " , NULL "        '入金予定日 
                        strSQL &= " ,'' "           '入金確認内容
                        strSQL &= " , '" & Me.DataGridView1.Rows(ro).Cells(7).Value.ToString.Trim & "'"      '点検受付番号
                        strSQL &= " , NULL "        '請求書再発行日
                        strSQL &= " , NULL "        '振込期日
                        strSQL &= " , NULL "        '未入金架電日１回目
                        strSQL &= " ,'' "           '未入金架電日１回目結果
                        strSQL &= " , NULL "        '未入金架電日２回目
                        strSQL &= " ,'' "           '未入金架電日２回目結果
                        strSQL &= " , NULL "        '督促状発行日
                        strSQL &= " , NULL "        '振込期日督促状発行
                        strSQL &= " , NULL "        '未入金架電１回目
                        strSQL &= " ,'' "           '未入金架電１回目結果
                        strSQL &= " , NULL "        '未入金架電２回目
                        strSQL &= " ,'' "           '未入金架電２回目結果
                        strSQL &= " , NULL "        '受付拒否設定日
                        strSQL &= " , NULL "        '債権放棄通知書発行日
                        strSQL &= " , NULL "        '決裁書発行日
                        'strSQL &= " ,'" & Me.DataGridView1.Rows(ro).Cells(0).Value.ToString.Trim & "'"      '作成年月
                        strSQL &= " ,'" & Me.TextBoxss請求指定.Text.Trim & "'"                               'ss請求
                        strSQL &= " , NULL  "       '未回収架電確認日
                        strSQL &= " ,'' "           '確認者
                        strSQL &= " ,'' "           '備考
                        strSQL &= " ,'' "           '色
                        strSQL &= " , NULL "        '入金予定日担当者
                        strSQL &= " ,'' "           '残明細削除フラグ
                        strSQL &= " ,now()"
                        strSQL &= " ,'" & UserID & "'"
                        strSQL &= " ,'' "           '2024/07/10 k.s 特別消費税フラグ
                        strSQL &= " , '" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"              '2025/01/06 k.s SEQ
                        strSQL &= ")"
                        ClassPostgeDB.EXEC(strSQL)
                    Else
                        strSQL = "UPDATE " & schema & "t_kaisyu "
                        strSQL &= "SET "
                        'strSQL &= " ss請求 ='" & Me.DataGridView1.Rows(ro).Cells(0).Value.ToString.Trim & "'"        '作成年月
                        strSQL &= " ss請求 ='" & Me.TextBoxss請求指定.Text.Trim & "'"                                 'ss請求
                        strSQL &= ",更新日 =now() "
                        strSQL &= ",更新者 ='" & UserID & "'"
                        strSQL &= ",SEQ ='" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"
                        strSQL &= " WHERE uketukeno = '" & Me.DataGridView1.Rows(ro).Cells(7).Value.ToString.Trim & "'"
                        strSQL &= " AND   SEQ = '" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"     '2025/01/06 k.s SEQ
                        ClassPostgeDB.EXEC(strSQL)
                    End If

                Else
                    '【取込み（キャンセル）】
                    strSQL = "SELECT uketukeno,入金日,ss請求  FROM " & schema & "t_kaisyu where uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(7).Value.ToString.Trim & "'"
                    strSQL &= " AND SEQ  = '" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"         '2025/01/06 k.s
                    dt = ClassPostgeDB.SetTable(strSQL)
                    If dt.Rows.Count = 1 Then
                        strSQL = "UPDATE " & schema & "t_kaisyu "
                        strSQL &= "SET "
                        strSQL &= " ss請求 =''"
                        strSQL &= ",更新日 =now() "
                        strSQL &= ",更新者 ='" & UserID & "'"
                        strSQL &= ",SEQ ='" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"
                        strSQL &= " WHERE uketukeno = '" & Me.DataGridView1.Rows(ro).Cells(7).Value.ToString.Trim & "'"
                        strSQL &= " AND   SEQ = '" & Me.DataGridView1.Rows(ro).Cells(23).Value.ToString.Trim & "'"     '2025/01/06 k.s SEQ
                        ClassPostgeDB.EXEC(strSQL)
                    End If
                End If
                'intRow += 1

            End If

        Next

        ToolStripProgressBar1.Value = 0
    End Sub

    '---------------------------
    'DB更新（ss請求入金日）
    '---------------------------
    Private Sub koushin2(strNday As String)
        Dim strSQL As String

        '--- 2025/01/06 k.s start ---
        'Cursor.Current = Cursors.WaitCursor
        'If strNday <> "" Then
        '    strSQL = "UPDATE " & schema & "t_kaisyu "
        '    strSQL &= "SET "
        '    strSQL &= " 入金日 =" & strNday & ""
        '    strSQL &= ",更新日 =now() "
        '    strSQL &= ",更新者 ='" & UserID & "'"
        '    strSQL &= " WHERE  ss請求 = '" & Me.TextBoxss請求.Text.Trim & "' "
        'Else
        '    strSQL = "UPDATE " & schema & "t_kaisyu "
        '    strSQL &= "SET "
        '    strSQL &= " 入金日 =NULL"
        '    strSQL &= ",更新日 =now() "
        '    strSQL &= ",更新者 ='" & UserID & "'"
        '    strSQL &= " WHERE ss請求 = '" & Me.TextBoxss請求.Text.Trim & "' "
        'End If
        'ClassPostgeDB.EXEC(strSQL)
        '
        ''一覧表再表示
        'disp2()
        '
        'Cursor.Current = Cursors.Default

        Dim dt As DataTable
        Dim strJYOUKEN As String = ""

        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count - 1
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        For ro As Integer = 0 To DataGridView1.Rows.Count - 1

            ToolStripProgressBar1.Value = ro

            strJYOUKEN = " WHERE ss請求 = '" & Me.TextBoxss請求.Text.Trim & "' "
            strJYOUKEN &= " AND   uketukeno  = '" & Me.DataGridView1.Rows(ro).Cells(0).Value.ToString.Trim & "'"
            strJYOUKEN &= " AND   SEQ  = '" & Me.DataGridView1.Rows(ro).Cells(5).Value.ToString.Trim & "'"

            strSQL = "SELECT uketukeno,入金日,ss請求,SEQ FROM " & schema & "t_kaisyu "
            strSQL &= strJYOUKEN
            dt = ClassPostgeDB.SetTable(strSQL)
            If dt.Rows.Count > 0 Then

                If strNday <> "" Then
                    '入金日を登録したい時
                    strSQL = "UPDATE " & schema & "t_kaisyu "
                    strSQL &= "SET "
                    strSQL &= " 入金日 =" & strNday & ""
                    strSQL &= ",更新日 =now() "
                    strSQL &= ",更新者 ='" & UserID & "'"
                    strSQL &= strJYOUKEN
                Else
                    '入金日をクリアしたい時
                    strSQL = "UPDATE " & schema & "t_kaisyu "
                    strSQL &= "SET "
                    strSQL &= " 入金日 =NULL"
                    strSQL &= ",更新日 =now() "
                    strSQL &= ",更新者 ='" & UserID & "'"
                    strSQL &= strJYOUKEN
                End If
                ClassPostgeDB.EXEC(strSQL)
            End If
        Next
        ToolStripProgressBar1.Value = 0

        '一覧表再表示
        disp2()

        '--- 2025/01/06 k.s  ---
    End Sub

    '--------------------------------
    '回収金額の取得と金額チェック   
    '--------------------------------
    Private Sub GetKingakuChk(row As Integer)
        Dim strSQL As String = String.Empty
        Dim dt As DataTable
        Dim strNo As String = String.Empty

        strNo = Me.DataGridView1.Rows(row).Cells(7).Value.ToString.Trim()           '受付番号
        strNo = Me.DataGridView1.Rows(row).Cells(7).Value.ToString.Trim()           '回収金額

        strSQL = "select"
        strSQL &= " tmp.uketukeno   as ""点検受付番号"" "
        strSQL &= ",cast( tmp.upri as numeric ) as ""回収金額"" "
        strSQL &= ",tmp.entry_date as ""更新日"" "
        strSQL &= ",tmp.SEQ as ""SEQ"" "　　　　　　　　　　　　　　　　　　   　 　'2025/01/06 k.s SEQ
        strSQL &= " from " & schema & "t_002 as tmp "
        strSQL &= " where tmp.out_flg ='1' and "                                    '出荷済
        strSQL &= "      tmp.sls_typ <>'3' and "                                    '削除済以外
        strSQL &= " tmp.uketukeno = '" & strNo & "' "                               '受付NO
        '--- 2025/01/06 k.s ---
        '得意先が 010574：直収 OR 903000：HN直収、　受付番号、回収金額　が同じものを更新OKとする
        strSQL &= " AND ( tmp.cst_cd = '010574' or tmp.cst_cd = '903000' )"                                                '得意先（直収、HN直収）
        strSQL &= " AND cast( tmp.upri as numeric )='" & Integer.Parse(Me.DataGridView1.Rows(row).Cells(16).Value) & "'"   '回収金額
        '--- 2025/01/06 end ---
        strSQL &= " order by tmp.uketukeno asc, tmp.entry_date desc"

        dt = ClassPostgeDB.SetTable(strSQL)

        '--- 2025/01/06 k.s start ---
        'If dt.Rows.Count = 0 Then
        '    Me.DataGridView1.Rows(row).Cells(21).Value = 0
        '    Me.DataGridView1.Rows(row).Cells(22).Value = ""
        'Else
        '    '更新日の一番新しい回収金額
        '    Me.DataGridView1.Rows(row).Cells(21).Value = Integer.Parse(dt.Rows(0).Item(1))
        '    Me.DataGridView1.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        '    'Me.DataGridView1.Columns(21).DefaultCellStyle.Format = "#,0"

        '    'EXCELから取込んだ金額（税抜き）と回収金額（税抜き）が違うときエラー
        '    If Integer.Parse(Me.DataGridView1.Rows(row).Cells(16).Value) = Integer.Parse(Me.DataGridView1.Rows(row).Cells(21).Value) Then
        '        Me.DataGridView1.Rows(row).Cells(22).Value = "OK"
        '    Else
        '        Me.DataGridView1.Rows(row).Cells(22).Value = "ERR"
        '    End If
        'End If
        If dt.Rows.Count = 1 Then
            '検索有りの時
            Me.DataGridView1.Rows(row).Cells(21).Value = Integer.Parse(dt.Rows(0).Item(1))      '回収金額
            Me.DataGridView1.Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            Me.DataGridView1.Rows(row).Cells(22).Value = "OK"                       'チェック結果
            Me.DataGridView1.Rows(row).Cells(23).Value = dt.Rows(0).Item(3)         'SEQ
        Else
            '検索無し、検索結果が複数件ある時
            Me.DataGridView1.Rows(row).Cells(21).Value = "0"                        '回収金額
            Me.DataGridView1.Rows(row).Cells(22).Value = "ERR"                      'チェック結果
            Me.DataGridView1.Rows(row).Cells(23).Value = ""                         'SEQ
            Me.DataGridView1.Rows(row).DefaultCellStyle.BackColor = Color.Red       'ERR行を赤色
        End If
        '--- 2025/01/06 k.s end ---


    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub
End Class