Public Class FormDenpyou
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

    Private Sub FormDenpyou_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If Kengen = "0" Then
            Me.Button更新.Visible = True
            Me.Button削除.Visible = True
        Else
            Me.Button更新.Visible = False
            Me.Button削除.Visible = False
        End If


    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub FormDenpyou_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "6") Then

        End If
    End Sub
    Private Sub 検索(Cob As ComboBox, jy As String, txt As String)
        Dim strSQL As String
        Dim strSQLQ As String

        strSQL = "SELECT 'false',sinacd, ord_no, to_char(entry_day,'yyyy/mm/dd'), ship_wh_cd, cst_cd, ord_psn_nm, cst_po_no, "
        strSQL &= "slip_rmrks, intr_rmrks, qty, upri, sts_typ_nm, kessaihouhou, goukei, coupon_waribiki, tesuuryou,"
        strSQL &= "seikyukingaku, coupon_cd, syorikubun, nyukinn, to_char(nyukinkakuninbi,'yyyy/mm/dd') , syouryou,update_day,seq, memo"

        strSQL &= " FROM " & schema & "t_uriage where update_day is not null"

        If Cob.Text = "" Then Cob.Text = "一致"

        Select Case Cob.Text
            Case "一致"
                If jy = "entry_day" Then
                    strSQLQ = " and to_char(" & jy & ",'yyyy/mm/dd')  = '" & txt.Trim.ToString & "'"
                Else
                    strSQLQ = " and " & jy & "  = '" & txt.Trim.ToString & "'"
                End If
            Case "一部"
                strSQLQ = " and " & jy & " like '%" & txt.Trim.ToString & "%'"
            Case "前方"
                strSQLQ = " and " & jy & " like '" & txt.Trim.ToString & "%'"
            Case "後方"
                strSQLQ = " and " & jy & " like '%" & txt.Trim.ToString & "'"
            Case Else
                MessageBox.Show("条件を選択してください")
                Exit Sub
        End Select
        検索２（strSQL, strSQLQ）
    End Sub


    Private Sub 検索２（strSQL As String, strSQLQ As String）

        zenkaiSQL = strSQL & strSQLQ
        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
        '---　件数　請求合計金額
        '//Dim i As Integer
        '//i = Me.DataGridView1.Rows.Count - 1
        Me.TextBox件数.Text = Me.DataGridView1.Rows.Count

        'strSQL = "select sum (cast(goukei as numeric)) from (select to2.goukei  from " & schema & "t_uriage to2 where to2.update_day is not null"
        'strSQL = strSQL & strSQLQ & "  and  (to2.intr_rmrks <>'')) a"

        'Me.TextBox合計請求金額.Text = ClassPostgeDB.DbSel(strSQL)

        strSQL = "select  sum (cast(qty as numeric) * cast(upri as numeric) ) from (select to2.qty ,to2.upri from " & schema & "t_uriage to2 where to2.update_day is not null"
        strSQL = strSQL & strSQLQ & ") a"

        Me.TextBox売り上げ金額.Text = ClassPostgeDB.DbSel(strSQL)

        strSQL = "select sum (cast(seikyukingaku as numeric)) from "

        strSQL &= " ("
        strSQL &= " select to2.seikyukingaku ,  CASE WHEN  to2.intr_rmrks =''  then  to2.cst_po_no  else to2.intr_rmrks  end  intr_rmrks"
        strSQL &= "   from public.t_uriage to2 "
        strSQL &= "	where to2.seikyukingaku <> '0'"
        strSQL &= "	and to2.update_day is not null "
        'strSQL &= "	and to_char(entry_day,'yyyy/mm/dd')  = '2023/11/28'"
        strSQL = strSQL & strSQLQ

        strSQL &= " group by  to2.seikyukingaku "
        strSQL &= " ,CASE WHEN  to2.intr_rmrks ='' then  to2.cst_po_no  else to2.intr_rmrks  end"
        strSQL &= " ) a"

        'strSQL = strSQL & strSQLQ & " group by  to2.seikyukingaku ,to2.intr_rmrks ) a"



        Me.TextBox合計請求金額.Text = ClassPostgeDB.DbSel(strSQL)

        'Me.TextBox合計請求金額.Text = sm.ToString()

    End Sub

    Private Sub 検索３（kikan1 As String, kikan2 As String）

        Dim strSQL As String
        Dim strSQLQ As String

        strSQL = "Select 'false',sinacd, ord_no, to_char(entry_day,'yyyy/mm/dd'), ship_wh_cd, cst_cd, ord_psn_nm, cst_po_no, "
        strSQL &= "slip_rmrks, intr_rmrks, qty, upri, sts_typ_nm, kessaihouhou, goukei, coupon_waribiki, tesuuryou,"
        strSQL &= "seikyukingaku, coupon_cd, syorikubun, nyukinn, to_char(nyukinkakuninbi,'yyyy/mm/dd') , syouryou,update_day,seq"
        strSQL &= " FROM " & schema & "t_uriage where update_day is not null"

        strSQLQ = " and to_char(entry_day,'yyyy/mm/dd') between '" & kikan1 & "' and '" & kikan2 & "'"

        検索２（strSQL, strSQLQ）

    End Sub

    Private Sub Button検索1_Click(sender As Object, e As EventArgs) Handles Button検索1.Click

        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード.Text)
        Clear("1")
    End Sub

    Private Sub Button検索2_Click(sender As Object, e As EventArgs) Handles Button検索2.Click
        Call 検索(Me.ComboBoxJy2, "ord_no", Me.TextBoxオーダーNO.Text)
        Clear("2")

    End Sub

    Private Sub Button検索3_Click(sender As Object, e As EventArgs) Handles Button検索3.Click
        Me.ComboBoxJy3.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy3, "entry_day", Me.MaskedTextBox取り込み日.Text)
        Clear("3")
    End Sub
    Private Sub Button検索4_Click(sender As Object, e As EventArgs) Handles Button検索4.Click
        Call 検索(Me.ComboBoxJy4, "cst_cd", Me.TextBox得意先コード.Text)

        Clear("4")

    End Sub
    Private Sub Button検索5_Click(sender As Object, e As EventArgs) Handles Button検索5.Click
        Call 検索(Me.ComboBoxJy5, "intr_rmrks", Me.TextBox備考カナ.Text)

        Clear("5")
    End Sub

    Private Sub Clear(sw As String)


        Select Case sw
            Case "1"
                'Me.TextBox品コード.Text = ""
                Me.TextBoxオーダーNO.Text = ""
                Me.MaskedTextBox取り込み日.Text = ""
                Me.TextBox得意先コード.Text = ""
                Me.TextBox備考カナ.Text = ""
            Case "2"
                Me.TextBox品コード.Text = ""
                'Me.TextBoxオーダーNO.Text = ""
                Me.MaskedTextBox取り込み日.Text = ""
                Me.TextBox得意先コード.Text = ""
                Me.TextBox備考カナ.Text = ""
            Case "3"
                Me.TextBox品コード.Text = ""
                Me.TextBoxオーダーNO.Text = ""
                'Me.MaskedTextBox取り込み日.Text = ""
                Me.TextBox得意先コード.Text = ""
                Me.TextBox備考カナ.Text = ""
            Case "4"
                Me.TextBox品コード.Text = ""
                Me.TextBoxオーダーNO.Text = ""
                Me.MaskedTextBox取り込み日.Text = ""
                'Me.TextBox得意先コード.Text = ""
                Me.TextBox備考カナ.Text = ""
            Case "5"
                Me.TextBox品コード.Text = ""
                Me.TextBoxオーダーNO.Text = ""
                Me.MaskedTextBox取り込み日.Text = ""
                Me.TextBox得意先コード.Text = ""
                'Me.TextBox備考カナ.Text = ""

            Case Else
                Me.TextBox品コード.Text = ""
                Me.TextBoxオーダーNO.Text = ""
                Me.MaskedTextBox取り込み日.Text = ""
                Me.TextBox得意先コード.Text = ""
                Me.TextBox備考カナ.Text = ""
        End Select

        Me.TextBox出庫倉庫.Text = ""
        Me.TextBox漢字発注者.Text = ""
        Me.TextBox発注NO.Text = ""
        Me.TextBox備考漢字.Text = ""
        Me.TextBox数量.Text = ""

        Me.TextBox単価.Text = ""
        Me.TextBox状況区分.Text = ""
        Me.TextBox決済方法.Text = ""

        Me.TextBox合計.Text = ""
        Me.TextBoxクーポン割引額.Text = ""
        Me.TextBox決済手数料.Text = ""
        Me.TextBox請求金額.Text = ""

        Me.TextBoxクーポンコード.Text = ""
        Me.TextBox処理区分.Text = ""
        Me.TextBox入金フラグ.Text = ""
        Me.TextBox入金確認日.Text = ""
        Me.TextBox更新日.Text = ""
        Me.TextBox発注者カナ.Text = ""
        Me.TextBox送料.Text = ""

        Me.TextBoxSEQ.Text = ""


    End Sub


    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        Dim ro
        Dim ret As String

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                If e.ColumnIndex = 0 Then
                    Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
                Else
                    Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0 + 1).Value
                    Me.TextBoxオーダーNO.Text = Me.DataGridView1.Rows(ro).Cells(1 + 1).Value
                    Me.MaskedTextBox取り込み日.Text = Me.DataGridView1.Rows(ro).Cells(2 + 1).Value
                    Me.TextBox出庫倉庫.Text = Me.DataGridView1.Rows(ro).Cells(3 + 1).Value
                    Me.TextBox得意先コード.Text = Me.DataGridView1.Rows(ro).Cells(4 + 1).Value
                    Me.TextBox漢字発注者.Text = Me.DataGridView1.Rows(ro).Cells(5 + 1).Value
                    Me.TextBox発注NO.Text = Me.DataGridView1.Rows(ro).Cells(6 + 1).Value
                    Me.TextBox備考漢字.Text = Me.DataGridView1.Rows(ro).Cells(7 + 1).Value
                    Me.TextBox備考カナ.Text = Me.DataGridView1.Rows(ro).Cells(8 + 1).Value
                    Me.TextBox数量.Text = Me.DataGridView1.Rows(ro).Cells(9 + 1).Value

                    Me.TextBox単価.Text = Me.DataGridView1.Rows(ro).Cells(10 + 1).Value
                    Me.TextBox状況区分.Text = Me.DataGridView1.Rows(ro).Cells(11 + 1).Value
                    Me.TextBox決済方法.Text = Me.DataGridView1.Rows(ro).Cells(12 + 1).Value

                    Me.TextBox合計.Text = Me.DataGridView1.Rows(ro).Cells(13 + 1).Value
                    Me.TextBoxクーポン割引額.Text = Me.DataGridView1.Rows(ro).Cells(14 + 1).Value
                    Me.TextBox決済手数料.Text = Me.DataGridView1.Rows(ro).Cells(15 + 1).Value
                    Me.TextBox請求金額.Text = Me.DataGridView1.Rows(ro).Cells(16 + 1).Value

                    Me.TextBoxクーポンコード.Text = Me.DataGridView1.Rows(ro).Cells(17 + 1).Value
                    Me.TextBox処理区分.Text = Me.DataGridView1.Rows(ro).Cells(18 + 1).Value
                    Me.TextBox入金フラグ.Text = Me.DataGridView1.Rows(ro).Cells(19 + 1).Value
                    Me.TextBox入金確認日.Text = Me.DataGridView1.Rows(ro).Cells(20 + 1).Value
                    Me.TextBox送料.Text = Me.DataGridView1.Rows(ro).Cells(21 + 1).Value
                    Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(22 + 1).Value
                    Me.TextBoxSEQ.Text = Me.DataGridView1.Rows(ro).Cells(23 + 1).Value
                    'Me.TextBox発注者カナ.Text = Me.DataGridView1.Rows(ro).Cells(23).Value
                    'TM在庫処理から
                    Me.TextBoxメモ.Text = Me.DataGridView1.Rows(ro).Cells(24 + 1).Value.ToString.Replace("~", vbCrLf)
                    ret = GetTM()
                    If ret = "" Then
                        Me.TextBox在庫戻し処理.Text = ""
                        Me.TextBox在庫戻し処理.BackColor = Color.White
                    ElseIf ret = "0" Then
                        Me.TextBox在庫戻し処理.Text = "キャンセル引き当て待ち中"
                        Me.TextBox在庫戻し処理.BackColor = Color.GreenYellow
                    ElseIf ret = "1" Then
                        Me.TextBox在庫戻し処理.Text = "キャンセル引き当て済み"
                        Me.TextBox在庫戻し処理.BackColor = Color.Red
                    End If

                End If
            Else
                Clear("")
            End If
        End If

    End Sub




    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim fastseq As String
        Dim ret As String

        If Me.TextBox品コード.Text = "" Then
            MessageBox.Show("品コードが未入力です")
            Exit Sub
        Else
            If ChkSinaCd(Me.TextBox品コード.Text.Trim) = False Then
                MessageBox.Show("品コードが存在しません")
                Exit Sub
            End If
        End If

        If Me.TextBoxSEQ.Text = "" Then

            fastseq = ClassPostgeDB.DbSel("SELECT nextval('seqorder')")

            strSQL = "INSERT INTO " & schema & "t_uriage (sinacd, ord_no, sls_typ, xpns_cd, ship_wh_cd, route_cd, fare_typ"
            strSQL &= ", cst_cd, cst_note, scnd_dler_ten, thrd_dler_ten, scst_nm, cst_po_no, ord_psn_nm, ord_psn_nm1"
            strSQL &= ", slip_rmrks, intr_rmrks, chrg_dpt_cd, bf_no, ac_cd, fa_no, zn_rcv_psn_cd, qty, upri, rate"
            strSQL &= ",cst_dsnt_subno, ja_inst_no, ja_upri, ja_upri_rate, sts_typ_nm, entry_day, update_day, kessaihouhou, syorikubun, nyukinn, nyukinkakuninbi"
            strSQL &= ",goukei, coupon_waribiki, tesuuryou, seikyukingaku, coupon_cd,syouryou,seq,memo) VALUES("

            strSQL &= "'" & TextBox品コード.Text.Trim & "',"
            strSQL &= "'" & TextBoxオーダーNO.Text.Trim & "',"
            strSQL &= "'" & "'," 'sls_typ & "',"
            strSQL &= "'" & "'," 'xpns_cd & "',"
            strSQL &= "'" & TextBox出庫倉庫.Text.Trim & "',"
            strSQL &= "'" & "'," 'route_cd & "',"
            strSQL &= "'" & "'," 'fare_typ & "',"
            strSQL &= "'" & TextBox得意先コード.Text.Trim & "',"
            strSQL &= "'" & "'," 'cst_note & "',"
            strSQL &= "'" & "'," 'scnd_dler_ten & "',"
            strSQL &= "'" & "'," 'thrd_dler_ten & "',"
            strSQL &= "'" & "'," 'scst_nm & "',"
            strSQL &= "'" & TextBox発注NO.Text.Trim & "',"
            strSQL &= "'" & TextBox漢字発注者.Text.Trim & "',"
            strSQL &= "'" & TextBox発注者カナ.Text.Trim & "',"
            strSQL &= "'" & TextBox備考漢字.Text.Trim & "',"
            strSQL &= "'" & TextBox備考カナ.Text.Trim & "',"
            strSQL &= "'" & "'," 'chrg_dpt_cd & "',"
            strSQL &= "'" & "'," 'bf_no & "',"
            strSQL &= "'" & "'," 'ac_cd & "',"
            strSQL &= "'" & "'," 'fa_no & "',"
            strSQL &= "'" & "'," 'zn_rcv_psn_cd & "',"

            If IsNumeric(TextBox数量.Text.Trim) = True Then
                strSQL &= "'" & TextBox数量.Text.Trim & "',"
            Else
                strSQL &= "'0',"
            End If
            If IsNumeric(TextBox単価.Text.Trim) = True Then
                strSQL &= "'" & TextBox単価.Text.Trim & "',"
            Else
                strSQL &= "'0',"
            End If

            strSQL &= "'" & "'," 'Rate & "',"
            strSQL &= "'" & "'," 'cst_dsnt_subno & "',"
            strSQL &= "'" & "'," 'ja_inst_no & "',"
            strSQL &= "'" & "'," 'ja_upri & "',"
            strSQL &= "'" & "'," 'ja_upri_rate & "',"
            strSQL &= "'" & TextBox状況区分.Text.Trim & "',"
            strSQL &= "now(),"
            strSQL &= "now(),"
            strSQL &= "'" & TextBox決済方法.Text.Trim & "',"
            strSQL &= "'" & TextBox処理区分.Text.Trim & "',"
            strSQL &= "'" & TextBox入金フラグ.Text.Trim & "',"

            If Strings.Left(Me.TextBox入金確認日.Text, 1) = " " Then
                strSQL &= "NULL,"
            Else
                strSQL &= "'" & Me.TextBox入金確認日.Text.ToString & "',"
            End If

            If IsNumeric(TextBox合計.Text.Trim) = True Then
                strSQL &= "'" & TextBox合計.Text.Trim & "',"
            Else
                strSQL &= "'0',"
            End If

            strSQL &= "'" & TextBoxクーポン割引額.Text & "',"

            If IsNumeric(TextBox送料.Text.Trim) = True Then
                strSQL &= "'" & TextBox送料.Text.Trim & "',"
            Else
                strSQL &= "'0',"
            End If
            If IsNumeric(TextBox請求金額.Text.Trim) = True Then
                strSQL &= "'" & TextBox請求金額.Text.Trim & "',"
            Else
                strSQL &= "'0',"
            End If

            strSQL &= "'" & TextBoxクーポンコード.Text & "',"
            If IsNumeric(Me.TextBox送料.Text.TrimEnd.ToString) = True Then
                strSQL &= "'" & Me.TextBox送料.Text.TrimEnd.ToString & "',"
            Else
                strSQL &= "'0',"
            End If
            strSQL &= "" & fastseq & ","
            strSQL &= "'" & Me.TextBoxメモ.Text.Replace(vbCrLf, "~") & "'"
            strSQL &= ")"
            Me.TextBoxSEQ.Text = fastseq

        Else
            strSQL = "Select update_day from " & schema & "t_uriage where seq = '" & Me.TextBoxSEQ.Text.Trim.ToString & "'"
            ret = ClassPostgeDB.DbSel(strSQL)
            If ret = Me.TextBox更新日.Text Then

                strSQL = "update " & schema & "t_uriage set "
                strSQL &= " sinacd = '" & TextBox品コード.Text.Trim & "',"
                strSQL &= " ord_no = '" & TextBoxオーダーNO.Text.Trim & "',"
                strSQL &= " ship_wh_cd = '" & TextBox出庫倉庫.Text.Trim & "',"
                strSQL &= " cst_cd= '" & TextBox得意先コード.Text.Trim & "',"
                strSQL &= " cst_po_no ='" & TextBox発注NO.Text.Trim & "',"
                strSQL &= " ord_psn_nm ='" & TextBox漢字発注者.Text.Trim & "',"
                strSQL &= " slip_rmrks ='" & TextBox備考漢字.Text.Trim & "',"
                strSQL &= " intr_rmrks = '" & TextBox備考カナ.Text.Trim & "',"
                strSQL &= " qty = '" & TextBox数量.Text.Trim & "',"
                strSQL &= " upri = '" & TextBox単価.Text.Trim & "',"
                strSQL &= " sts_typ_nm ='" & TextBox状況区分.Text.Trim & "',"
                strSQL &= " update_day = now(),"
                strSQL &= " kessaihouhou = '" & TextBox決済方法.Text.Trim & "',"
                strSQL &= " syorikubun = '" & TextBox処理区分.Text.Trim & "',"
                strSQL &= " nyukinn = '" & TextBox入金フラグ.Text.Trim & "',"
                strSQL &= " ord_psn_nm1 ='" & TextBox発注者カナ.Text.Trim & "',"


                If Strings.Left(Me.TextBox入金確認日.Text, 1) = " " Then
                    strSQL &= " nyukinkakuninbi = NULL,"
                Else
                    strSQL &= " nyukinkakuninbi = '" & Me.TextBox入金確認日.Text.ToString & "',"
                End If
                strSQL &= " goukei = '" & TextBox合計.Text.Trim & "',"
                strSQL &= " coupon_waribiki = '" & TextBoxクーポン割引額.Text.Trim & "',"
                strSQL &= " tesuuryou = '" & TextBox送料.Text.Trim & "',"
                strSQL &= " seikyukingaku = '" & TextBox請求金額.Text.Trim & "',"
                strSQL &= " coupon_cd = '" & TextBoxクーポンコード.Text.Trim & "',"

                If IsNumeric(Me.TextBox送料.Text.TrimEnd.ToString) = True Then
                    strSQL &= " syouryou = '" & Me.TextBox送料.Text.TrimEnd.ToString & "'"
                Else
                    strSQL &= "syouryou = '0'"
                End If
                strSQL &= ",memo = '" & Me.TextBoxメモ.Text.ToString.Replace(vbCrLf, "~") & "'"
                strSQL &= " where seq = '" & Me.TextBoxSEQ.Text.Trim.ToString & "'"

            Else
                MessageBox.Show("データが更新されています。再検索してください")
                Exit Sub
            End If
        End If

        If ClassPostgeDB.EXEC(strSQL) Then
            MessageBox.Show("更新しました")
            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Me.DataGridView1.ReadOnly = True
            strSQL = "select update_day from " & schema & "t_uriage where seq = '" & Me.TextBoxSEQ.Text.Trim.ToString & "'"
            Me.TextBox更新日.Text = ClassPostgeDB.DbSel(strSQL)
        Else
            MessageBox.Show("更新エラーです")
        End If

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim ClassPostgeDB2 = New ClassPostgeDB2()
        Dim dt As New DataTable
        Dim strSQL As String
        Dim wSEQ As String
        Dim wDay As String
        Dim wToDay As String
        If Me.TextBoxSEQ.Text <> "" Then
            strSQL = "UPDATE " & schema & "t_uriage SET update_day = null where  update_day is not null  "
            strSQL &= " and seq = '" & Me.TextBoxSEQ.Text.Trim.ToString & "'"
            If ClassPostgeDB.EXEC(strSQL) Then


                '***********
                'ECをDELETE
                '***********

                If TextBox備考漢字.Text = "ＥＣグッズ" Then
                    If EC_DENSOU = "1" Then
                        strSQL = "select MAX(tz.seq) , max(tz.syoriday ) from  " & schema2 & "t_zaiko tz "
                        strSQL &= " where tz.sinacd  =  '" & TextBox品コード.Text & "'"
                        strSQL &= " And tz.denpyouno = '" & TextBoxオーダーNO.Text & "' "
                        strSQL &= " And tz.bikou  =  '" & TextBox発注NO.Text & "'"

                        'wSEQ = ClassPostgeDB2.DbSel(strSQL)
                        dt = ClassPostgeDB2.SetTable(strSQL)

                        If dt.Rows.Count > 0 Then
                            wSEQ = dt.Rows(0).Item(0).ToString
                            wDay = dt.Rows(0).Item(1).ToString.Replace("/", "").Substring(1, 6)
                            wToDay = Date.Today.ToString("yyyyMM")
                            If wDay = wToDay Then
                                If wSEQ <> "0" Then
                                    strSQL = "Delete  from  " & schema2 & "t_zaiko  "
                                    strSQL &= " where seq  =  '" & wSEQ & "'"
                                    '//// ECサイト出庫更新
                                    ClassPostgeDB2.EXEC(strSQL)
                                End If
                            End If
                        End If
                    End If
                End If
                '///

                MessageBox.Show("削除しました")
                Clear("")
                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            End If
        End If
    End Sub

    Private Sub FormDenpyou_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DataGridView1.ReadOnly = True
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

    Private Sub DateTimePicker取り込み日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker取り込み日.ValueChanged
        Me.MaskedTextBox取り込み日.Text = ""
        Me.MaskedTextBox取り込み日.Text = Me.DateTimePicker取り込み日.Value

    End Sub

    Private Sub DateTimePicker入金確認日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker入金確認日.ValueChanged
        Me.TextBox入金確認日.Text = ""
        Me.TextBox入金確認日.Text = Me.DateTimePicker入金確認日.Value

    End Sub

    Private Sub 全ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全ONToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = True
        Next

    End Sub

    Private Sub 全OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全OFFToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = False
        Next

    End Sub

    Private Sub 反転ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転ToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
        Next

    End Sub

    Private Sub 実行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 実行ToolStripMenuItem.Click
        Dim ClassPostgeDB2 = New ClassPostgeDB2()

        Dim strSQL As String
        Dim bRet As Boolean
        Dim rowloop As Integer
        Dim wSEQ As String
        Dim dt As New DataTable
        Dim wDay As String
        Dim wToday As String
        Me.DataGridView1.ReadOnly = True

        Dim FormMeter As New FormMeter
        FormMeter.MAX = Me.DataGridView1.Rows.Count
        FormMeter.Show()
        rowloop = 0
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            bRet = CBool(dr.Cells(0).Value)
            If bRet Then
                If dr.Cells(17).Value <> "" Then
                    If dr.Cells(24).Value <> "" Then
                        strSQL = "UPDATE " & schema & "t_uriage SET update_day = null where  update_day is not null  "
                        strSQL &= " and seq = '" & dr.Cells(24).Value & "'"
                        ClassPostgeDB.EXEC(strSQL)

                        '***********
                        'ECをDELETE
                        '***********
                        If dr.Cells(24).Value = "ＥＣグッズ" Then
                            If EC_DENSOU = "1" Then
                                strSQL = "select MAX(TZ.seq) from  " & schema2 & "t_zaiko tz "
                                strSQL &= " where tz.sinacd  =  '" & dr.Cells(1).Value & "'"
                                strSQL &= " And tz.denpyouno = '" & dr.Cells(2).Value & "' "
                                strSQL &= " And tz.bikou  =  '" & dr.Cells(7).Value & "'"

                                'wSEQ = ClassPostgeDB2.DbSel(strSQL)
                                dt = ClassPostgeDB2.SetTable(strSQL)

                                If dt.Rows.Count > 0 Then
                                    wSEQ = dt.Rows(0).Item(0).ToString
                                    wDay = dt.Rows(0).Item(1).ToString.Replace("/", "").Substring(1, 6)
                                    wToday = Date.Today.ToString("yyyyMM")
                                    If wDay = wToday Then
                                        If wSEQ <> "0" Then
                                            strSQL = "Delete  from  " & schema2 & "t_zaiko  "
                                            strSQL &= " where seq  =  '" & wSEQ & "'"
                                            '//// ECサイト出庫更新
                                            ClassPostgeDB2.EXEC(strSQL)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        '///

                    End If
                End If
            End If
            rowloop = rowloop + 1
            FormMeter.GEN = rowloop
            FormMeter.Disp()
        Next
        FormMeter.CLos()

        Me.DataGridView1.ReadOnly = False
        Clear("")
        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

    End Sub


    Private Sub DateTimePicker取り込み日1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker取り込み日1.ValueChanged
        Me.MaskedTextBox取り込み日1.Text = ""
        Me.MaskedTextBox取り込み日1.Text = Me.DateTimePicker取り込み日1.Value
    End Sub

    Private Sub DateTimePicker取り込み日2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker取り込み日2.ValueChanged
        Me.MaskedTextBox取り込み日2.Text = ""
        Me.MaskedTextBox取り込み日2.Text = Me.DateTimePicker取り込み日2.Value
    End Sub

    Private Sub ButtonJy6_Click(sender As Object, e As EventArgs) Handles ButtonJy6.Click

        検索３（Me.MaskedTextBox取り込み日1.Text, Me.MaskedTextBox取り込み日2.Text）

    End Sub
    '
    '戻り在庫処理　t_m_zaikoへ更新する
    Private Function GetTM()
        Dim strSQL As String
        Dim ret As String

        strSQL = "SELECT syori_flg  FROM " & schema & "t_m_zaiko  "
        strSQL &= " where seq ='" & Me.TextBoxSEQ.Text.Trim() & "'"

        ret = ClassPostgeDB.DbSel(strSQL)

        Return ret

    End Function



    Private Sub TM在庫処理()

        Dim strSQL As String
        Dim ret As String
        Dim seihinmei As String

        ret = GetTM()

        If ret = "" Then

            strSQL = "SELECT seihinmei  FROM " & schema & "m_seihin WHERE sinacd = "
            strSQL &= "'" & Me.TextBox品コード.Text & "'"
            seihinmei = ClassPostgeDB.DbSel(strSQL)


            strSQL = "INSERT INTO " & schema & "t_m_zaiko(oderno, sinacd,  zaikosuu, entry_day, entry_sya, update_day, update_sya, syori_flg,seihinmei, upri, syouryou, tesuuryou, goukei,seq,syukoflg,ebisuoda)VALUES("
            strSQL &= "'" & Me.TextBoxオーダーNO.Text & "'"
            strSQL &= ",'" & Me.TextBox品コード.Text & "'"
            strSQL &= ",'" & Me.TextBox数量.Text & "'"
            strSQL &= ",now()"
            strSQL &= ",'" & UserName & "'"
            strSQL &= ",now()"
            strSQL &= ",'" & UserName & "'"
            strSQL &= ",'0'"
            strSQL &= ",'" & seihinmei.ToString().Trim() & "'"
            strSQL &= ",'" & Me.TextBox単価.Text.Trim() & "'"
            strSQL &= ",'" & Me.TextBox送料.Text.Trim() & "'"
            strSQL &= ",'" & Me.TextBox決済手数料.Text.Trim() & "'"
            strSQL &= ",'" & Me.TextBox合計.Text.Trim() & "'"
            strSQL &= ",'" & Me.TextBoxSEQ.Text.Trim.ToString() & "'"
            strSQL &= ",'" & ClassPostgeDB.DbSel("Select naiyou from " & schema & "m_system where kbn='22' order by seq LIMIT 1") & "'"
            strSQL &= ",'" & Me.TextBox備考カナ.Text.Trim & "'"

            strSQL &= ")"
            ClassPostgeDB.EXEC(strSQL)

            Me.TextBox在庫戻し処理.Text = "キャンセル引き当て待ち中"
            Me.TextBox在庫戻し処理.BackColor = Color.GreenYellow

        ElseIf ret = "0" Then

            strSQL = "DELETE  FROM " & schema & "t_m_zaiko  "
            strSQL &= " where oderno ='" & Me.TextBoxオーダーNO.Text.Trim & "'"
            strSQL &= " and sinacd ='" & Me.TextBox品コード.Text.Trim & "'"

            ret = ClassPostgeDB.DbSel(strSQL)
            Me.TextBox在庫戻し処理.Text = ""
            Me.TextBox在庫戻し処理.BackColor = Color.White

        End If

    End Sub

    Private Sub Button在庫戻し処理_Click(sender As Object, e As EventArgs) Handles Button在庫戻し処理.Click

        If Me.TextBox在庫戻し処理.Text.Trim <> "キャンセル引き当て済み" Then
            TM在庫処理()
        End If
    End Sub

    Private Sub 削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 削除ToolStripMenuItem.Click

    End Sub


End Class