Public Class FormKaisyuuZanmeisai
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
    '残明細
    '---------------------------
    Private Sub FormKaisyuuZanmeisai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '画面クリア
        crear()
    End Sub

    '---------------------------
    'メニュー　閉じる
    '---------------------------
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click

        Me.Close()

    End Sub

    '---------------------------
    'メニュー　検索
    '---------------------------
    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click

        '残明細データ検索
        Kensaku()
        '各種項目セット・遺産計算
        Koumokuset()

    End Sub

    '---------------------------
    'メニュー　EXCEL
    '---------------------------
    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("出力するデータがありません。")
            Exit Sub
        End If
        excelOutDataGred4(Me.DataGridView1, False, Me.ToolStripProgressBar1, 3)
    End Sub

    '--- 2025/01/06 k.s start ---
    ' t_kaisyuを複数件持つようになった。
    '入金日が入っていないものを全て対象とする、

    ''---------------------------------------------------
    ''SQL1
    ''---------------------------------------------------
    'Private Function setSQL1() As String
    '    Dim strSQL As String = String.Empty

    '    strSQL = ",tmp.uketukeno   as ""点検受付番号"" "
    '    strSQL &= ",tmp.tyoufuku   as ""重複"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.nextb       else null end) as ""売上年月日"" "            '3 
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.cst_cd      else null end) as ""得意先コード"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.scst_nm     else null end) as ""得意先名"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.itm_cd      else null end) as ""品コード"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.cst_po_no   else null end) as ""発注ＮＯ"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.intr_rmrks  else null end) as ""請求書番号"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.slip_rmrks  else null end) as ""備考_漢字"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.ord_psn_nm  else null end) as ""発注担当者"" "
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.qty         else null end) as ""数"" "
    '    strSQL &= ",CAST(max(case tmp.seq when 1  then tmp.upri   else null end) as INT) as ""回収金額"" "      '12
    '    strSQL &= ",max(case tmp.seq when 1  then tmp.entry_date  else null end) as ""更新日"" "
    '    strSQL &= ",s.保証規定区分 "
    '    strSQL &= ",s.回収区分 "
    '    strSQL &= ",sum(cast(s.請求合計金額 as numeric)) as ""請求合計金額"" "
    '    strSQL &= ",s.ｄｍ番号 "
    '    strSQL &= ",s.承認番号 "
    '    strSQL &= ",s.点検受付番号 "
    '    strSQL &= ",s.代表受付番号 "
    '    strSQL &= ",s.請求日 "
    '    strSQL &= ",s.請求先宛名 "
    '    strSQL &= ",s.請求先住所 "
    '    strSQL &= ",s.請求先電話 "
    '    strSQL &= ",s.都道府県名 "
    '    strSQL &= ",s.市区町村名 "
    '    strSQL &= ",s.町域 "
    '    strSQL &= ",s.番地 "
    '    strSQL &= ",s.建物 "
    '    strSQL &= ",s.部屋 "
    '    strSQL &= ",tk.入金日 "
    '    strSQL &= ",tk.入金予定日 "
    '    strSQL &= ",tk.入金確認内容 "
    '    strSQL &= ",tk.請求書再発行日 "
    '    strSQL &= ",tk.振込期日 "
    '    strSQL &= ",tk.未入金架電日１回目 "
    '    strSQL &= ",tk.未入金架電日１回目結果 "
    '    strSQL &= ",tk.未入金架電日２回目 "
    '    strSQL &= ",tk.未入金架電日２回目結果 "
    '    strSQL &= ",tk.督促状発行日 "
    '    strSQL &= ",tk.振込期日督促状発行 "
    '    strSQL &= ",tk.未入金架電１回目 "
    '    strSQL &= ",tk.未入金架電１回目結果 "
    '    strSQL &= ",tk.未入金架電２回目 "
    '    strSQL &= ",tk.未入金架電２回目結果 "
    '    strSQL &= ",tk.受付拒否設定日 "
    '    strSQL &= ",tk.債権放棄通知書発行日 "
    '    strSQL &= ",tk.決裁書発行日 "
    '    strSQL &= ",tk.ss請求 "
    '    strSQL &= ",tk.未回収架電確認日 "
    '    strSQL &= ",tk.確認者 "
    '    strSQL &= ",tk.備考 "
    '    strSQL &= ",tk.色 "
    '    strSQL &= ",tk.入金予定日担当者 "
    '    strSQL &= ",tk.残明細削除フラグ "
    '    strSQL &= "from "
    '    strSQL &= "( "
    '    strSQL &= "    select "
    '    strSQL &= "         uketukeno "
    '    strSQL &= "        ,nextb "
    '    strSQL &= "        ,cst_cd "
    '    strSQL &= "        ,scst_nm "
    '    strSQL &= "        ,itm_cd "
    '    strSQL &= "        ,cst_po_no "
    '    strSQL &= "        ,intr_rmrks "
    '    strSQL &= "        ,slip_rmrks "
    '    strSQL &= "        ,ord_psn_nm "
    '    strSQL &= "        ,qty "
    '    strSQL &= "        ,upri "
    '    strSQL &= "        ,out_flg "
    '    strSQL &= "        ,entry_date "
    '    strSQL &= "        ,sls_typ "
    '    strSQL &= "        ,tyoufuku "          '重複
    '    strSQL &= "        ,row_number() over (partition by uketukeno order by entry_date desc) as seq "
    '    strSQL &= "    from "
    '    strSQL &= "        " & schema & "t_002 "
    '    strSQL &= "    where out_flg ='1' "
    '    strSQL &= ") as tmp "
    '    strSQL &= "inner join " & schema & "v_yuryo_tenken_syuyaku as s  on s.点検受付番号 = tmp.uketukeno "
    '    strSQL &= "left outer join " & schema & "t_kaisyu          as tk on tk.uketukeno   = tmp.uketukeno "
    '    strSQL &= "where tmp.out_flg ='1'  and "                                     '出荷済
    '    strSQL &= "      tmp.sls_typ <>'3' and "                                     '削除済
    '    strSQL &= "      tmp.seq ='1'      and "                                     '複数データの1件名
    '    strSQL &= "      s.依頼区分 Not in ('15','17','16','19','20','21') and "     'TS・PT契約を除く
    '    strSQL &= "      tk.残明細削除フラグ ='' and "                               '残明細削除対象は除く

    '    setSQL1 = strSQL
    'End Function

    '---------------------------------------------------
    'SQL1
    '---------------------------------------------------
    Private Function setSQL1() As String
        Dim strSQL As String = String.Empty

        strSQL = " ,tmp.uketukeno    as ""点検受付番号"" "
        strSQL &= ",tmp.tyoufuku    as ""重複"" "
        strSQL &= ",tmp.nextb       as ""売上年月日"" "            '3 
        strSQL &= ",tmp.cst_cd      as ""得意先コード"" "
        strSQL &= ",tmp.scst_nm     as ""得意先名"" "
        strSQL &= ",tmp.itm_cd      as ""品コード"" "
        strSQL &= ",tmp.cst_po_no   as ""発注ＮＯ"" "
        strSQL &= ",tmp.intr_rmrks  as ""請求書番号"" "
        strSQL &= ",tmp.slip_rmrks  as ""備考_漢字"" "
        strSQL &= ",tmp.ord_psn_nm  as ""発注担当者"" "
        strSQL &= ",tmp.qty         as ""数"" "
        strSQL &= ",tmp.upri        as ""回収金額"" "             '12
        strSQL &= ",tmp.entry_date  as ""更新日"" "
        strSQL &= ",s.保証規定区分 "
        strSQL &= ",s.回収区分 "
        strSQL &= ",s.請求合計金額  as ""請求合計金額"" "
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
        strSQL &= ",tmp.seq  as ""seq"" "
        strSQL &= "from " & schema & "t_002 as tmp "
        strSQL &= "inner join " & schema & "v_yuryo_tenken_syuyaku As s  On s.点検受付番号 = tmp.uketukeno "
        strSQL &= "left outer join " & schema & "t_kaisyu          As tk On tk.uketukeno   = tmp.uketukeno And tk.seq = tmp.seq "
        strSQL &= "where tmp.out_flg ='1'  and "                                     '出荷済
        strSQL &= " (tmp.entry = '' or tmp.entry is null ) and " 　　　　　　　　　　'削除済は対象外（"DELETE"以外)
        strSQL &= " s.依頼区分 Not in ('15','17','16','19','20','21') and "          'TS・PT契約を除く
        strSQL &= " (tk.残明細削除フラグ ='' or  tk.残明細削除フラグ is null) and "  '残明細削除対象は除く

        setSQL1 = strSQL
    End Function
    '--- 2025/01/06 k.s end ---

    '--- 2025/01/06 k.s start ---
    ''---------------------------------------------------
    ''SQL2
    ''---------------------------------------------------
    'Private Function setSQL2() As String
    '    Dim strSQL As String = String.Empty

    '    strSQL = " group by "
    '    'strSQL &= "tmp.uketukeno "
    '    strSQL &= " tmp.uketukeno ,tmp.tyoufuku  "
    '    strSQL &= ",s.保証規定区分, s.回収区分   , cast(s.請求合計金額 as numeric), s.ｄｍ番号, s.承認番号, s.点検受付番号, s.代表受付番号,s.請求日 "
    '    strSQL &= ",s.請求先宛名  , s.請求先住所 , s.請求先電話   , s.都道府県名     , s.市区町村名, s.町域, s.番地, s.建物, s.部屋 "
    '    strSQL &= ",tk.入金日     , tk.入金予定日, tk.入金確認内容, tk.請求書再発行日, tk.振込期日 "
    '    strSQL &= ",tk.未入金架電日１回目, tk.未入金架電日１回目結果 , tk.未入金架電日２回目, tk.未入金架電日２回目結果, tk.督促状発行日  , tk.振込期日督促状発行 "
    '    strSQL &= ",tk.未入金架電１回目  , tk.未入金架電１回目結果   , tk.未入金架電２回目  , tk.未入金架電２回目結果  , tk.受付拒否設定日, tk.債権放棄通知書発行日 "
    '    strSQL &= ",tk.決裁書発行日, tk.ss請求, tk.未回収架電確認日, tk.確認者, tk.備考, tk.色 , tk.入金予定日担当者   , tk.残明細削除フラグ"

    '    setSQL2 = strSQL
    'End Function

    '---------------------------------------------------
    'SQL2
    '---------------------------------------------------
    Private Function setSQL2() As String
        Dim strSQL As String = String.Empty

        strSQL = " order by tmp.uketukeno asc )"

        setSQL2 = strSQL
    End Function
    '--- 2025/01/06 k.s end ---

    '---------------------------------------------------
    '遺産抽出　SQL作成
    '---------------------------------------------------
    Private Function setSQL3()
        Dim strSQL As String

        '処理月(例：5月の時)
        '残明細作成（月）(例：4月の時)

        '売上期間　(例：3月売上)
        Dim strKikan3_S As String
        strKikan3_S = Me.DateTimePicker1.Value.AddMonths(-1).ToString("yyyy/MM/") & "01"

        '売上期間 (例：2月売上)
        Dim strKikan4_S As String
        strKikan4_S = Me.DateTimePicker1.Value.AddMonths(-2).ToString("yyyy/MM/") & "01"

        strSQL = " union all "
        strSQL &= " ( "                                             '2025/01/06 k.s
        strSQL &= " select "
        strSQL &= " '遺'            as ""遺先"" "                   '0
        strSQL &= ",null            as ""売上年"" "                 '1
        strSQL &= ",null            as ""売上月"" "                 '2
        strSQL &= setSQL1()
        strSQL &= " ( "
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan3_S & "' and tmp.cst_cd ='901000' and tk.入金日 Is NULL ) or "    '別途
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan3_S & "' and tmp.cst_cd ='904000' and tk.入金日 Is NULL ) or "    'HN別途
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan4_S & "' and tmp.cst_cd ='010574' and tk.入金日 Is NULL ) or "    '直収
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan4_S & "' and tmp.cst_cd ='903000' and tk.入金日 Is NULL ) or "    'HN直収
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan3_S & "' and tmp.cst_cd ='902000' and tk.入金日 Is NULL )  "      '安心プラン
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan3_S & "' and tmp.cst_cd ='901000' and ( tk.入金日 Is NULL Or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    '別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan3_S & "' and tmp.cst_cd ='904000' and ( tk.入金日 Is NULL Or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    'HN別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan4_S & "' and tmp.cst_cd ='010574' and ( tk.入金日 Is NULL Or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    '直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan4_S & "' and tmp.cst_cd ='903000' and ( tk.入金日 Is NULL Or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    'HN直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') < '" & strKikan3_S & "' and tmp.cst_cd ='902000' and ( tk.入金日 Is NULL Or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) )  "      '安心プラン
        strSQL &= " ) "
        strSQL &= setSQL2()

        setSQL3 = strSQL
    End Function


    '---------------------------------------------------
    '先入れ抽出　SQL作成
    '---------------------------------------------------
    Private Function setSQL4()
        Dim strSQL As String

        '処理月(例：5月の時)
        '残明細作成（月）(例：4月の時)

        '売上期間　(例：5月売上)
        Dim strKikan1_S As String
        strKikan1_S = DateTime.Now().ToString("yyyy/MM/") & "01"
        Dim strKikan1_E As String
        strKikan1_E = DateTime.Now().ToString("yyyy/MM/dd")

        '売上期間　(例：4月売上)
        Dim strKikan2_S As String
        strKikan2_S = Me.DateTimePicker1.Value.ToString("yyyy/MM/") & "01"
        Dim strKikan2_E As String
        strKikan2_E = DateTime.Parse(strKikan2_S).AddMonths(+1).AddDays(-1).ToString("yyyy/MM/dd")

        '売上期間　(例：3月売上)
        Dim strKikan3_S As String
        strKikan3_S = Me.DateTimePicker1.Value.AddMonths(-1).ToString("yyyy/MM/") & "01"
        Dim strKikan3_E As String
        strKikan3_E = DateTime.Parse(strKikan3_S).AddMonths(+1).AddDays(-1).ToString("yyyy/MM/dd")

        ''売上期間 (例：2月売上)
        'Dim strKikan4_S As String
        'strKikan4_S = Me.DateTimePicker1.Value.AddMonths(-2).ToString("yyyy/MM/") & "01"
        'Dim strKikan4_E As String
        'strKikan4_E = DateTime.Parse(strKikan4_S).AddMonths(+1).AddDays(-1).ToString("yyyy/MM/dd")

        strSQL = " union all "
        strSQL &= " ( "                                             '2025/01/06 k.s
        strSQL &= " select "
        strSQL &= " '先'            as ""遺先"" "                   '0
        strSQL &= ",null            as ""売上年"" "                 '1
        strSQL &= ",null            as ""売上月"" "                 '2
        strSQL &= setSQL1()
        '先入れもの
        strSQL &= " ( "
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan1_S & "' and '" & strKikan1_E & "' and  tmp.cst_cd ='901000' and  tk.入金日 <= '" & DateTime.Now().ToString("yyyy/MM/dd") & "'  ) or "     '別途
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='901000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '別途
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan1_S & "' and '" & strKikan1_E & "' and  tmp.cst_cd ='904000' and  tk.入金日 <= '" & DateTime.Now().ToString("yyyy/MM/dd") & "'  ) or "     'HN別途
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='904000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  'HN別途
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='010574' and  tk.入金日 <= '" & DateTime.Now().ToString("yyyy/MM/dd") & "'  ) or "     '直収
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='010574' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '直収
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='903000' and  tk.入金日 <= '" & DateTime.Now().ToString("yyyy/MM/dd") & "'  ) or "     'HN直収
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='903000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  'HN直収
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan1_S & "' and '" & strKikan1_E & "' and  tmp.cst_cd ='902000' and  tk.入金日 <= '" & DateTime.Now().ToString("yyyy/MM/dd") & "'  ) or "     '安心プラン
        'strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='902000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  )  "                    '安心プラン
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan1_S & "' and '" & strKikan1_E & "' and  tmp.cst_cd ='901000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='901000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan1_S & "' and '" & strKikan1_E & "' and  tmp.cst_cd ='904000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  'HN別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='904000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  'HN別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='010574' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='010574' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='903000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  'HN直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='903000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  'HN直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan1_S & "' and '" & strKikan1_E & "' and  tmp.cst_cd ='902000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  ) or "                  '安心プラン
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan2_S & "' and '" & strKikan2_E & "' and  tmp.cst_cd ='902000' and  tk.入金日 <= '" & Me.DateTimePicker2.Value & "'  )  "                    '安心プラン
        strSQL &= " ) "
        strSQL &= setSQL2()

        setSQL4 = strSQL
    End Function

    '---------------------------
    '残明細検索
    '---------------------------
    Private Sub Kensaku()
        Dim strSQL As String
        Dim ro As Integer
        Dim dt As DataTable

        Me.Cursor = Cursors.WaitCursor

        '処理月(例：5月の時)
        '残明細作成（月）(例：4月の時)

        '売上期間　(例：3月売上)
        Dim strKikan3_S As String
        strKikan3_S = Me.DateTimePicker1.Value.AddMonths(-1).ToString("yyyy/MM/") & "01"
        Dim strKikan3_E As String
        strKikan3_E = DateTime.Parse(strKikan3_S).AddMonths(+1).AddDays(-1).ToString("yyyy/MM/dd")

        '売上期間 (例：2月売上)
        Dim strKikan4_S As String
        strKikan4_S = Me.DateTimePicker1.Value.AddMonths(-2).ToString("yyyy/MM/") & "01"
        Dim strKikan4_E As String
        strKikan4_E = DateTime.Parse(strKikan4_S).AddMonths(+1).AddDays(-1).ToString("yyyy/MM/dd")

        strSQL = "( "                                         '2024 12/24 k.s
        strSQL &= "Select"
        strSQL &= " null            As ""遺先"" "              '0
        strSQL &= ",null            As ""売上年"" "            '1
        strSQL &= ",null            As ""売上月"" "            '2
        strSQL &= setSQL1()
        '残
        strSQL &= " ( "
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='901000' and ( tk.入金日 Is NULL or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    '別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='904000' and ( tk.入金日 Is NULL or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    'HN別途
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan4_S & "' and '" & strKikan4_E & "' and  tmp.cst_cd ='010574' and ( tk.入金日 Is NULL or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    '直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan4_S & "' and '" & strKikan4_E & "' and  tmp.cst_cd ='903000' and ( tk.入金日 Is NULL or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) ) or "    'HN直収
        strSQL &= " ( to_date(tmp.nextb, 'YYYY/MM/DD') between '" & strKikan3_S & "' and '" & strKikan3_E & "' and  tmp.cst_cd ='902000' and ( tk.入金日 Is NULL or tk.入金日 > '" & Me.DateTimePicker2.Value & "' ) )  "      '安心プラン
        strSQL &= " ) "
        strSQL &= setSQL2()
        '遺産
        strSQL &= setSQL3()
        '先入れ
        strSQL &= setSQL4()


        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "遺先", "遺先", 40, True)                         '0
        ro = settextColumn(Me.DataGridView1, ro, "売上年", "売上年", 60, True)                     '1
        ro = settextColumn(Me.DataGridView1, ro, "売上月", "売上月", 40, True)                     '2

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 120, True)        '3
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 120, True)        '4
        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 120, True)                '5

        ro = settextColumn(Me.DataGridView1, ro, "重複", "重複", 40, True)             　          '** 6 **
        ro = settextColumn(Me.DataGridView1, ro, "売上年月日", "売上年月日", 130, True)            '6 7
        ro = settextColumn(Me.DataGridView1, ro, "得意先コード", "得意先コード", 100, True)        '7 8
        ro = settextColumn(Me.DataGridView1, ro, "得意先名", "得意先名", 160, True)                '8 9
        ro = settextColumn(Me.DataGridView1, ro, "品コード", "品コード", 120, True)                '9 10
        ro = settextColumn(Me.DataGridView1, ro, "発注ＮＯ", "発注ＮＯ", 130, True)                '10 11
        ro = settextColumn(Me.DataGridView1, ro, "請求書番号", "請求書番号", 130, True)            '11 12
        ro = settextColumn(Me.DataGridView1, ro, "備考_漢字", "備考_漢字", 120, True)              '12 13
        ro = settextColumn(Me.DataGridView1, ro, "発注担当者", "発注担当者", 130, True)            '13 14
        ro = settextColumn(Me.DataGridView1, ro, "数", "数", 50, True)                             '(14) (15)
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 120, True)                '(15) (16)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 120, True)                    '16 17

        ro = settextColumn(Me.DataGridView1, ro, "請求合計金額", "請求合計金額", 120, True)       '(17) (18)
        ro = settextColumn(Me.DataGridView1, ro, "入金日", "入金日", 130, True)              　　 '18 19
        ro = settextColumn(Me.DataGridView1, ro, "入金予定日", "入金予定日", 130, True)     　　  '19 20
        ro = settextColumn(Me.DataGridView1, ro, "入金確認内容", "入金確認内容", 120, True) 　    '20 21
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 120, True)               '21 22
        ro = settextColumn(Me.DataGridView1, ro, "承認番号", "承認番号", 120, True)         　    '22 23
        ro = settextColumn(Me.DataGridView1, ro, "代表受付番号", "代表受付番号", 120, True)       '23 24

        ro = settextColumn(Me.DataGridView1, ro, "請求日", "請求日", 130, True)                   '24 25
        ro = settextColumn(Me.DataGridView1, ro, "請求先宛名", "請求先宛名", 150, True)           '25 26
        ro = settextColumn(Me.DataGridView1, ro, "請求先住所", "請求先住所", 100, True)           '26 27
        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 100, True)           '27 28
        ro = settextColumn(Me.DataGridView1, ro, "都道府県名", "訪問先都道府県名", 100, True)     '28 29
        ro = settextColumn(Me.DataGridView1, ro, "市区町村名", "訪問先市区町村名", 100, True)     '29 30
        ro = settextColumn(Me.DataGridView1, ro, "町域", "訪問先町域", 100, True)                 '30 31
        ro = settextColumn(Me.DataGridView1, ro, "番地", "訪問先番地", 100, True)                 '31 32
        ro = settextColumn(Me.DataGridView1, ro, "建物", "訪問先建物", 100, True)                 '32 33
        ro = settextColumn(Me.DataGridView1, ro, "部屋", "訪問先部屋", 100, True)                 '33 34

        ro = settextColumn(Me.DataGridView1, ro, "ss請求", "ss請求", 120, True)                                   '34 35
        ro = settextColumn(Me.DataGridView1, ro, "未回収架電確認日", "未回収架電確認日", 120, True)               '35 36
        ro = settextColumn(Me.DataGridView1, ro, "確認者", "確認者", 120, True)                     　            '36 37
        ro = settextColumn(Me.DataGridView1, ro, "備考", "備考", 120, True)                                       '37 38

        ro = settextColumn(Me.DataGridView1, ro, "請求書再発行日", "請求書再発行日", 120, True)                   '38 39
        ro = settextColumn(Me.DataGridView1, ro, "振込期日", "振込期日", 120, True)                               '39 40
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日１回目", "未入金架電日１回目", 150, True)           '40 41 
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日１回目結果", "未入金架電日１回目結果", 150, True)   '41 42
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日２回目", "未入金架電日２回目", 150, True)           '42 43
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電日２回目結果", "未入金架電日２回目結果", 150, True)   '43 44

        ro = settextColumn(Me.DataGridView1, ro, "督促状発行日", "督促状発行日", 120, True)                       '44 54
        ro = settextColumn(Me.DataGridView1, ro, "振込期日督促状発行", "振込期日督促状発行", 120, True)           '45 46
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電１回目", "未入金架電１回目", 140, True)               '46 47
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電１回目結果", "未入金架電１回目結果", 140, True)       '47 48
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電２回目", "未入金架電２回目", 140, True)               '48 49
        ro = settextColumn(Me.DataGridView1, ro, "未入金架電２回目結果", "未入金架電２回目結果", 140, True)       '49 50

        ro = settextColumn(Me.DataGridView1, ro, "受付拒否設定日", "受付拒否設定日", 120, True)                   '50 51 
        ro = settextColumn(Me.DataGridView1, ro, "債権放棄通知書発行日", "債権放棄通知書発行日", 120, True)       '51 52
        ro = settextColumn(Me.DataGridView1, ro, "決裁書発行日", "決裁書発行日", 120, True)                       '52 53
        ro = settextColumn(Me.DataGridView1, ro, "色", "色", 50, True)                              　　　　　    '53 54　　
        ro = settextColumn(Me.DataGridView1, ro, "入金予定日担当者", "入金予定日(担当者用ﾒﾓ)", 120, True)     　  '54 55
        ro = settextColumn(Me.DataGridView1, ro, "残明細削除フラグ", "残明細削除フラグ", 120, True)               '55 56
        ro = settextColumn(Me.DataGridView1, ro, "seq", "seq", 50, True)             　                           '57  2025/01/06 k.s

        Me.DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight  　　  '数
        Me.DataGridView1.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight        '回収金額
        Me.DataGridView1.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight        '請求金額

        Me.DataGridView1.Columns(15).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(16).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(18).DefaultCellStyle.Format = "#,0"

        'ヘッダーの色を変える
        Me.DataGridView1.EnableHeadersVisualStyles = False
        For i As Integer = 7 To 17
            Me.DataGridView1.Columns(i).HeaderCell.Style.ForeColor = Color.Blue
        Next i

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        Me.Cursor = Cursors.Default

    End Sub

    '---------------------------------------------------
    '項目セット（年、月）
    '回収金額合計セット
    '請求金額合計セット
    '---------------------------------------------------
    Private Sub Koumokuset()
        Dim intZanSum As Integer = 0
        Dim intIsanSum As Integer = 0
        Dim intSakiireSum As Integer = 0
        Dim intSeikyuSum As Integer = 0

        ToolStripProgressBar1.Maximum = DataGridView1.Rows.Count
        ToolStripProgressBar1.Minimum = 0
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Step = 1

        '----------出力チェック----------
        If Me.DataGridView1.Rows.Count = 0 Then
            Exit Sub
        End If

        '----------年月セット----------
        Dim rowMaxNum As Integer = Me.DataGridView1.Rows.Count - 1
        For row As Integer = 0 To rowMaxNum
            Dim strTXT As String = ""
            Dim intKingaku As Integer = 0

            strTXT = Me.DataGridView1.Rows(row).Cells(7).Value.ToString         '売上年月
            intKingaku = Me.DataGridView1.Rows(row).Cells(16).Value             '回収金額
            '残集計
            If Me.DataGridView1.Rows(row).Cells(0).Value.ToString = "" Then
                intZanSum += intKingaku
            End If
            '遺産集計
            If Me.DataGridView1.Rows(row).Cells(0).Value.ToString = "遺" Then
                intIsanSum += intKingaku
            End If
            '先入れ集計
            If Me.DataGridView1.Rows(row).Cells(0).Value.ToString = "先" Then
                intSakiireSum += intKingaku
            End If
            'nextbは「yyyy/mm/dd」になっていないものが有るため日付型に変更してから年と月を取得する
            Me.DataGridView1.Rows(row).Cells(1).Value = DateTime.Parse(strTXT).ToString("yyyy")    '年　　　
            Me.DataGridView1.Rows(row).Cells(2).Value = DateTime.Parse(strTXT).ToString("MM")      '月

            '安心プランの税込み金額を計算（8%　または　10％）
            If Me.DataGridView1.Rows(row).Cells(18).Value Is DBNull.Value Then                     '2025/01/06 k.s 請求合計金額がNULLの時の対応
                Me.DataGridView1.Rows(row).Cells(18).Value = 0
            End If
            If Me.DataGridView1.Rows(row).Cells(4).Value.ToString = "安心プラン" And intKingaku <> "0" Then

                'Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)    'テスト用

                '「安心プランS2」を承認番号で検索し、施工年月日<2018年10月1日時　8％
                If GetZeiRitu(Me.DataGridView1.Rows(row).Cells(23).Value.ToString.Trim) = 8 Then
                    Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.08)
                Else
                    Me.DataGridView1.Rows(row).Cells(18).Value = Math.Truncate(intKingaku * 1.1)
                End If
            End If

            '請求合計金額集計
            intSeikyuSum += Me.DataGridView1.Rows(row).Cells(18).Value

            ToolStripProgressBar1.Value = row
        Next

        Me.Label残.Text = intZanSum.ToString("#,0") & " 円"
        Me.Label遺産.Text = intIsanSum.ToString("#,0") & " 円"
        Me.Label先入れ.Text = intSakiireSum.ToString("#,0") & " 円"
        ToolStripStatusLabel1.Text = "　税抜き合計金額＝" & (intZanSum + intIsanSum + intSakiireSum).ToString("#,0")
        ToolStripStatusLabel2.Text = "　税込み合計金額＝" & intSeikyuSum.ToString("#,0")

        ToolStripProgressBar1.Value = 0
    End Sub

    '---------------------------------------------------
    'クリア
    '---------------------------------------------------
    Private Sub crear()
        '残明細月
        Me.DateTimePicker1.Value = DateTime.Now().AddMonths(-1)
        '売上入金締め日(NR後日用)
        Me.DateTimePicker2.Value = DateTime.Now().ToString("yyyy/MM/") & "03"

        Me.Label残.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label遺産.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label先入れ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label残.Text = "円"
        Me.Label遺産.Text = "円"
        Me.Label先入れ.Text = "円"

        If Me.DataGridView1.Rows.Count = 0 Then
            ToolStripStatusLabel1.Alignment = ToolStripItemAlignment.Right
            ToolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right
            ToolStripStatusLabel1.Text = "　税抜き合計金額＝"
            ToolStripStatusLabel2.Text = "　税込み合計金額＝"
        End If
    End Sub


End Class