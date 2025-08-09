Public Class FormOUTPUT
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    Dim dt As DataTable

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

        If Logent(UserID, UserName, "10") Then

        End If
        Me.Close()
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs)
        GetIniFile()
        Me.TextBoxFileName.Text = FileSave("NextHanyou")
        NextHanyou = Me.TextBoxFileName.Text
        SetIniFile()
    End Sub

    Private Sub Button実行_Click(sender As Object, e As EventArgs) Handles Button実行.Click

        If dt Is Nothing Then
            MessageBox.Show("データがありません")
            Return
        End If

        Select Case Me.TabControl1.SelectedIndex
            Case "0"  '
                If Me.RadioButtonEXCEL.Checked Then
                    If Me.RadioButton商品登録.Checked Then
                        ExcelOout2(dt)
                    Else
                        '横展開が必要
                        ExcelOout3(dt, Me.TextBoxFileName.Text)

                    End If
                Else
                    If Me.TextBoxFileName.Text = "" Then
                        MessageBox.Show("ファイル名を入力してください")
                        Exit Sub
                    End If

                    If Me.RadioButton商品登録.Checked Then
                        CSVOut2(dt, Me.TextBoxFileName.Text.Trim)
                    Else
                        '横展開が必要
                        CSVOut3(dt, Me.TextBoxFileName.Text.Trim)


                    End If
                End If
            Case "1"  '出力
                If Me.RadioButtonEXCEL.Checked Then

                    dt = Me.DataGridView1.DataSource

                    ExcelOut(dt, "shop.xlsx", Me.TextBoxFileName.Text.Trim)
                Else
                    If Me.TextBoxFileName.Text.Trim <> "" Then

                        CSVOut2(dt, Me.TextBoxFileName.Text.Trim)
                    Else
                        MessageBox.Show("ファイル名が選択されていません")
                    End If
                End If

            Case "2"  '出力
                If Me.RadioButtonEXCEL.Checked Then
                    ExcelOout2(dt)
                    'ExcelOut(dt, "売上伝票.xlsx", Me.TextBoxFileName.Text.Trim)
                Else
                    If Me.TextBoxFileName.Text.Trim <> "" Then

                        CSVOut2(dt, Me.TextBoxFileName.Text.Trim)
                    Else
                        MessageBox.Show("ファイル名が選択されていません")
                    End If
                End If
        End Select
    End Sub
    Private Sub Button抽出_Click(sender As Object, e As EventArgs) Handles Button抽出.Click
        Dim strSQL As String
        Dim strSQL1 As String
        'Dim dt As DataTable
        'Dim Head As String
        Dim rowloop As Integer
        Dim sw As Integer
        Dim syouhizei As String

        Select Case Me.TabControl1.SelectedIndex
            Case "0"  '力
                If Me.RadioButton商品登録.Checked Then

                    '単価計算 消費税をマイナス 
                    syouhizei = "1." & GetTax()

                    'strSQL = "select ms.seihinmei as ""1:商品名"",ms.sinacd as ""2:ノーリツ品番"",ms.aitesakihinban as ""3:ハーマン品番"""
                    'strSQL &= ", '' as ""4：画像ファイル名"""
                    'strSQL &= ",round(ms.hanbai * " & syouhizei & ") as ""5：値段  ※税込"""
                    'strSQL &= ",'' as ""6：カラー"" ,'' as ""7：表示切り替えグループ"""
                    'strSQL &= "From " & schema & "m_seihin ms "
                    'strSQL &= "where ms.categori ='コンロ'"

                    strSQL = "select tpc.s_web_tourokumei As ""1:商品名"", tb.sinacd As ""2: ノーリツ品番"", ms1.aitesakihinban  As ""3: ハーマン品番"", '' as ""4： 画像ファイル名"""
                    strSQL &= ", '' as ""4：画像ファイル名"""
                    strSQL &= ",round(ms1.hanbai * " & syouhizei & ") as ""5：値段  ※税込"""
                    strSQL &= ",'' as ""6：カラー"" ,'' as ""7：表示切り替えグループ"""
                    strSQL &= " from " & schema & "m_seihin ms1 , " & schema & "t_buhintekigou tb , " & schema & "t_parts_center tpc "
                    strSQL &= " where ms1.sinacd = tb.sinacd"
                    strSQL &= " and   ms1.sinacd = tpc.sinacd"
                    strSQL &= " and   ms1.seihinflg ='1'"
                    strSQL &= " group by tpc.s_web_tourokumei , tb.sinacd, ms1.aitesakihinban, round(ms1.hanbai * " & syouhizei & ")"

                    dt = ClassPostgeDB.SetTable(strSQL)
                    Me.DataGridView0.DataSource = dt
                    Me.DataGridView0.AllowUserToAddRows = False

                End If
                If Me.RadioButton適応機種.Checked Then
                    'strSQL = "select tb.tekigoukisyu as ""商品名"",ms.gas as ""ガス種類"" ,tb.sinacd as ""パーツ品番"""
                    'strSQL &= " From " & schema & "m_seihin ms "
                    'strSQL &= " ," & schema & "m_seihin ms2 "
                    'strSQL &= " ," & schema & "t_buhintekigou tb "
                    'StrSQL &= " where ms.sinacd = tb.kisyucd"
                    'strSQL &= " And   ms2.categori ='コンロ'"
                    'strSQL &= " And   ms2.sinacd  =tb.sinacd "
                    'strSQL &= " order by tb.kisyucd "

                    strSQL = "select ms2.seihinmei  as ""商品名"" ,ms2.gas as ""ガス種類"" ,ms1.sinacd as ""パーツ品番"""
                    strSQL &= " from " & schema & "m_seihin ms1 , " & schema & "m_seihin ms2  ," & schema & "t_buhintekigou tb "
                    strSQL &= "where ms1.sinacd = tb.sinacd "
                    strSQL &= "and   ms2.sinacd = tb.kisyucd "
                    strSQL &= "and ms2.categori ='親品目'"

                    If Me.RadioButtonLPG.Checked Then

                        strSQL &= "and ms2.gas =  'ＬＰ' "

                    ElseIf Me.RadioButton12A13A.Checked Then

                        strSQL &= "and ms2.gas =  '１２Ａ１３Ａ' "

                    End If

                    strSQL &= "order by ms2.sinacd "
                        dt = ClassPostgeDB.SetTable(strSQL)
                        If dt.Rows.Count > 0 Then
                            Dim cnt As Integer
                            For cnt = 0 To dt.Rows.Count - 1
                                dt.Rows(cnt).Item(0) = StrConv(dt.Rows(cnt).Item(0), VbStrConv.Narrow)

                                dt.Rows(cnt).Item(0) = Replace(Replace(dt.Rows(cnt).Item(0), "*", ""), "$", "").Trim

                                Select Case dt.Rows(cnt).Item(1)
                                    Case "ＬＰ"
                                        dt.Rows(cnt).Item(1) = "LPG"
                                    Case "１２Ａ１３Ａ"
                                    dt.Rows(cnt).Item(1) = "12A13A"
                            End Select



                            Next
                            Me.DataGridView0.DataSource = dt
                            Me.DataGridView0.AllowUserToAddRows = False
                        End If
                    End If


                    Case "1"  'ショップ出力

                strSQL = "Select tpc.sinacd as ""品コード:ITEM_CD"",tpc.s_web_tourokumei as ""WEB登録名:ITEM_NAME"",tpc.s_kanjimei as ""商品名(カナ):ITEM_KANA"""
                strSQL &= " ,ms.hanbai as ""販売価格:TEIKA"",ms.kijunzaiko as ""基準在庫:MAX_QUANTITY"",tpc.s_hatyuu_lot as ""発注ロット"""
                strSQL &= " ,tpc.s_shopkbn as ""ショップ区分:ITEM.FREE_ITEM31"",tpc.s_gazou as ""在庫フラグ:ITEM.FREE_ITEM11"",tpc.s_categori as ""カテゴリコード1:CATEGORY_CD1"", tpc.s_web_hanbai_syuryoubi as ""WEB販売終了日,NEXT-B廃止日"""
                strSQL &= " ,ms.haisibi as ""公開情報"", tpc.s_koukai_jyouhou,tpc.s_gazou as "",商品画像"""
                strSQL &= " FROM " & schema & "m_seihin ms ," & schema & "t_parts_center tpc "
                strSQL &= " WHERE tpc.update_day Is Not null"
                strSQL &= " And ms.sinacd  = tpc.sinacd "

                dt = ClassPostgeDB.SetTable(strSQL)

                Me.DataGridView1.DataSource = dt
                Me.DataGridView1.AllowUserToAddRows = False


            Case "2" '売上伝票
                sw = 0
                strSQL = ""
                strSQL1 = "Select sinacd as ""品コード"", ord_no as ""オーダＮＯ"", sls_typ as ""売上区分"", xpns_cd as ""管理区分"""
                strSQL1 &= ", ship_wh_cd as ""出庫倉庫"", route_cd as ""運送便"", fare_typ as ""運賃区分"", cst_cd as ""得意先"""
                strSQL1 &= ", cst_note as ""得意先記事"", scnd_dler_ten as ""２次店"", thrd_dler_ten as ""３次店"", scst_nm as ""送り先名"""
                strSQL1 &= ", cst_po_no as ""発注NO"", ord_psn_nm as ""発注者漢字"", ord_psn_nm1 as ""発注者カナ"", slip_rmrks as ""備考漢字"""
                strSQL1 &= ", intr_rmrks as ""備考カナ"", chrg_dpt_cd as ""負担部門"", bf_no as ""資金予算NO"", ac_cd as ""勘定科目"""
                strSQL1 &= ", fa_no as ""固定資産管理NO"", zn_rcv_psn_cd as ""荷受人ＣＤ"", qty as ""数量"", upri as ""明細発注NO"", rate as ""単価"""
                strSQL1 &= ", cst_dsnt_subno as ""売価率"", ja_inst_no as ""枝番"", ja_upri as ""農協価格"", ja_upri_rate as ""農協価格率"""
                strSQL1 &= ", sts_typ_nm as ""状況区分"", kessaihouhou as ""決済方法"", syorikubun as ""処理区分"""
                strSQL1 &= ", nyukinn as ""入金フラグ"", nyukinkakuninbi as ""入金確認日"", goukei as ""合計"""
                strSQL1 &= ", coupon_waribiki as ""クーポン割引額"", tesuuryou as ""手数料"", seikyukingaku as ""請求金額"", coupon_cd as ""クーポンコード"", syouryou as ""送料"""
                strSQL1 &= " From " & schema & "t_uriage"
                strSQL1 &= " Where "


                If Me.TextBox品コード.Text.Trim <> "" Then
                    sw = sw + 1
                    Select Case Me.ComboBoxJy00.Text
                        Case "一致"
                            strSQL &= " sinacd = '" & Me.TextBox品コード.Text.Trim & "'"
                        Case "一部"
                            strSQL &= " sinacd LIKE '%" & Me.TextBox品コード.Text.Trim & "%'"
                        Case "前方"
                            strSQL &= " sinacd LIKE '" & Me.TextBox品コード.Text.Trim & "%'"
                        Case "後方"
                            strSQL &= " sinacd LIKE '%" & Me.TextBox品コード.Text.Trim & "'"
                        Case Else
                            MessageBox.Show("条件を選択してください")
                            Exit Sub
                    End Select
                End If

                If Me.TextBoxオーダーNO.Text.Trim <> "" Then
                    sw = sw + 1
                    If sw > 0 Then
                        Select Case Me.ComboBoxJy1.Text
                            Case "かつ"
                                strSQL &= " and "
                            Case Else
                                strSQL &= " or "
                        End Select
                    End If
                    Select Case Me.ComboBoxJy01.Text
                        Case "一致"
                            strSQL &= " ord_no = '" & Me.TextBoxオーダーNO.Text.Trim & "'"
                        Case "一部"
                            strSQL &= " ord_no LIKE '%" & Me.TextBoxオーダーNO.Text.Trim & "%'"
                        Case "前方"
                            strSQL &= " ord_no LIKE '" & Me.TextBoxオーダーNO.Text.Trim & "%'"
                        Case "後方"
                            strSQL &= " ord_no LIKE '%" & Me.TextBoxオーダーNO.Text.Trim & "'"
                        Case Else
                            MessageBox.Show("条件を選択してください")
                            Exit Sub
                    End Select
                End If

                If Mid(Me.MaskedTextBox取り込み日.Text, 1, 1).Trim <> "" And Mid(Me.MaskedTextBox取り込み日1.Text, 1, 1).Trim <> "" Then
                    If sw > 0 Then
                        Select Case Me.ComboBoxJy2.Text
                            Case "かつ"
                                strSQL &= " and "
                            Case Else
                                strSQL &= " or "
                        End Select
                    End If
                    strSQL &= " to_char(entry_day,'yyyy/mm/dd')  between '" & Me.MaskedTextBox取り込み日.Text.Trim.ToString & "' and '" & Me.MaskedTextBox取り込み日1.Text.Trim.ToString & "'"
                    sw = sw + 1
                End If

                If Me.TextBox得意先コード.Text.Trim <> "" Then
                    If sw > 0 Then
                        Select Case Me.ComboBoxJy4.Text
                            Case "かつ"
                                strSQL &= " and "
                            Case Else
                                strSQL &= " or "
                        End Select
                    End If
                    Select Case Me.ComboBoxJy03.Text
                        Case "一致"
                            strSQL &= " cst_cd = '" & Me.TextBox品コード.Text.Trim & "'"
                        Case "一部"
                            strSQL &= " cst_cd LIKE '%" & Me.TextBox品コード.Text.Trim & "%'"
                        Case "前方"
                            strSQL &= " cst_cd LIKE '" & Me.TextBox品コード.Text.Trim & "%'"
                        Case "後方"
                            strSQL &= " cst_cd LIKE '%" & Me.TextBox品コード.Text.Trim & "'"
                        Case Else
                            MessageBox.Show("条件を選択してください")
                            Exit Sub
                    End Select
                    sw = sw + 1
                End If

                If Me.TextBox備考カナ.Text.Trim <> "" Then
                    If sw > 0 Then
                        Select Case Me.ComboBoxJy4.Text
                            Case "かつ"
                                strSQL &= " and "
                            Case Else
                                strSQL &= " or "
                        End Select
                    End If
                    Select Case Me.ComboBoxJy04.Text
                        Case "一致"
                            strSQL &= " intr_rmrks = '" & Me.TextBox備考カナ.Text.Trim & "'"
                        Case "一部"
                            strSQL &= " intr_rmrks LIKE '%" & Me.TextBox備考カナ.Text.Trim & "%'"
                        Case "前方"
                            strSQL &= " intr_rmrks LIKE '" & Me.TextBox備考カナ.Text.Trim & "%'"
                        Case "後方"
                            strSQL &= " intr_rmrks LIKE '%" & Me.TextBox備考カナ.Text.Trim & "'"
                        Case Else
                            MessageBox.Show("条件を選択してください")
                            Exit Sub
                    End Select
                    sw = sw + 1
                End If
                If strSQL = "" Then
                    MessageBox.Show("条件入力択してください")
                    Return
                End If

                strSQL = strSQL1 & strSQL

                dt = ClassPostgeDB.SetTable(strSQL)

                '機種の展開
                For rowloop = 0 To dt.Rows.Count - 1

                    strSQL = "select tb.tekigoukisyu from " & schema & "t_buhintekigou tb where  tb.sinacd = '" & dt.Rows(rowloop).Item(0).ToString() & "'"
                    dt.Rows(rowloop).Item(5) = ClassPostgeDB.DbALLSel(strSQL)

                Next

                Me.DataGridView4.DataSource = dt
                Me.DataGridView4.AllowUserToAddRows = False

        End Select

    End Sub
    Private Sub Button検索_Click_1(sender As Object, e As EventArgs) Handles Button検索.Click

        GetIniFile()
        Me.TextBoxFileName.Text = FileSave(OrderFolder)
        OrderFolder = Me.TextBoxFileName.Text


    End Sub

    Private Sub FormOUTPUT_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Me.MaskedTextBox取り込み日.Text = Me.DateTimePicker1.Value
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Me.MaskedTextBox取り込み日1.Text = Me.DateTimePicker2.Value
    End Sub

    Private Sub FormOUTPUT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Logent(UserID, UserName, "10") Then

        End If

    End Sub

    Private Sub Button条件クリア_Click(sender As Object, e As EventArgs) Handles Button条件クリア.Click

        Me.TextBox品コード.Text = ""
        Me.TextBoxオーダーNO.Text = ""
        Me.MaskedTextBox取り込み日.Text = ""
        Me.MaskedTextBox取り込み日1.Text = ""
        Me.TextBox得意先コード.Text = ""
        Me.TextBox備考カナ.Text = ""
        Me.ComboBoxJy00.SelectedIndex = -1
        Me.ComboBoxJy01.SelectedIndex = -1
        Me.ComboBoxJy03.SelectedIndex = -1
        Me.ComboBoxJy04.SelectedIndex = -1
        Me.ComboBoxJy1.SelectedIndex = -1
        Me.ComboBoxJy2.SelectedIndex = -1
        Me.ComboBoxJy3.SelectedIndex = -1
        Me.ComboBoxJy4.SelectedIndex = -1


    End Sub
End Class