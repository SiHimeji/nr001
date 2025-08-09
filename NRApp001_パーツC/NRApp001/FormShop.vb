Public Class FormShop
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
    Private Sub FormShop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterScreen
        Dim strSQL As String
        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='2' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox倉庫, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='3' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox在庫フラグ, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='4' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox公開情報, strSQL)

        'strSQL = "SELECT naiyou FROM & schema & "m_system where kbn='7' order by  seq "
        'ClassPostgeDB.SetComboBox(Me.ComboBox在庫識別, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='8' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBoxショップ区分, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='9' order by  bikou "
        ClassPostgeDB.SetComboBox(Me.ComboBoxカテゴリ, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='10' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox画像, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='13' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox発送サイズ, strSQL)

        Me.DataGridView1.ReadOnly = True

    End Sub
    Private Sub 検索(Cob As ComboBox, jy As String, txt As String)
        Dim strSQL As String

        strSQL = 検索SQL()
        If Cob.Text = "" Then Cob.Text = "一致"

        Select Case Cob.Text
            Case "一致"
                strSQL = strSQL & " And " & jy & "  = '" & txt.Trim.ToString & "'"
            Case "一部"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Trim.ToString & "%'"
            Case "前方"
                strSQL = strSQL & " and " & jy & " like '" & txt.Trim.ToString & "%'"
            Case "後方"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Trim.ToString & "'"
            Case Else
                MessageBox.Show("条件を選択してください")
                Exit Sub
        End Select
        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.ReadOnly = True
    End Sub

    Private Sub 検索２(jy As String, date1 As String, date2 As String)

        If Not IsDate(date1, "yyyy/MM/dd") Then
            MessageBox.Show("日付型で入力してください")
            Exit Sub

        End If
        If Not IsDate(date2, "yyyy/MM/dd") Then
            MessageBox.Show("日付型で入力してください")
            Exit Sub
        End If
        Dim strSQL As String

        strSQL = 検索SQL()

        strSQL = strSQL & " and " & jy & " between '" & date1 & "'  and  '" & date2 & "'"
        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.ReadOnly = True


    End Sub

    Private Function 検索SQL() As String
        Dim strSQL As String

        strSQL = "SELECT tpc.sinacd, tpc.s_kanjimei, tpc.s_souko, tpc.s_zaiko_flg, tpc.s_web_tourokumei, tpc.s_categori, tpc.s_categori2,tpc.s_koukai_jyouhou"
        strSQL &= ", to_char(tpc.s_haisi_bi,'yyyy/mm/dd') as s_haisi_bi,  to_char(tpc.s_web_hanbai_syuryoubi,'yyyy/mm/dd') as s_web_hanbai_syuryoubi, tpc.s_hatyuu_lot, ms.kijunzaiko , tpc.s_kakunou_kanousu "
        strSQL &= ",tpc.s_shopkbn,tpc.s_gazou, s_konnpou,s_hassou,tpc.koukaibi,tpc.haisiyouteibi, ms.aitesakihinban , tpc.zaikosyori, tpc.zaikosyorihi ,    tpc.satueihaikihi  , tpc.satueitana  ,tpc.entry_day, tpc.entry_sya,tpc.update_day"
        strSQL &= " From " & schema & "m_seihin ms , " & schema & "t_parts_center tpc "
        strSQL &= " Where tpc.update_day Is Not null"
        strSQL &= " And MS.sinacd = tpc.sinacd"

        Return strSQL

    End Function



    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "tpc.sinacd", Me.TextBox品コード.Text)
        Clear("1")
    End Sub

    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        Call 検索(Me.ComboBoxJy2, "tpc.s_kanjimei", Me.TextBox漢字名称.Text)
        Clear("2")

    End Sub
    Private Sub Button検索３_Click(sender As Object, e As EventArgs) Handles Button検索３.Click
        Call 検索(Me.ComboBoxJy3, "tpc.s_web_tourokumei", Me.TextBoxWEB登録名.Text)
        Clear("3")
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub Clear(sw As String)

        Select Case sw
            Case "1"
                'Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""

            Case "2"
                Me.TextBox品コード.Text = ""
                'Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""

            Case "3"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                'Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""

            Case "4"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                'Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""

            Case "5"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                'Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""
            Case "6"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                'Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""
            Case "7"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                'Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""
            Case "8"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                'Me.ComboBoxカテゴリ.SelectedIndex = -1
                'Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""
            Case "9"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                'Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""
            Case "10"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                'Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""

            Case "11"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                'Me.TextBoxWEB販売終了日.Text = ""
                Me.MaskedTextBox廃止予定日.Text = ""
            Case Else
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
                Me.ComboBox倉庫.SelectedIndex = -1
                Me.ComboBox在庫フラグ.SelectedIndex = -1
                Me.ComboBox公開情報.SelectedIndex = -1
                Me.ComboBoxカテゴリ.SelectedIndex = -1
                Me.ComboBoxカテゴリ2.SelectedIndex = -1
                Me.ComboBoxショップ区分.SelectedIndex = -1
                Me.TextBox廃止日.Text = ""
                Me.TextBoxWEB販売終了日.Text = ""
                'Me.MaskedTextBox廃止予定日.Text = ""

        End Select

        Me.TextBoxWEB登録名.Text = ""

        Me.TextBox発注ロット.Text = ""
        Me.TextBox基準在庫.Text = ""
        Me.TextBox格納可能数.Text = ""
        Me.TextBox梱包サイズ.Text = ""

        Me.ComboBox画像.SelectedIndex = -1
        Me.ComboBox発送サイズ.SelectedIndex = -1
        Me.TextBox更新日.Text = ""
        Me.MaskedTextBox公開日.Text = ""
        Me.MaskedTextBox廃止予定日.Text = ""
        Me.TextBox相手先品番.Text = ""

    End Sub


    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim strSQL_t_buhin_spec As String
        Dim strSQL_m_seihin As String

        Dim Ret
        Dim dt As DateTime
        'MessageBox.Show(TextBoxWEB販売終了日.Text)

        If Me.TextBox品コード.Text.Trim <> "" Then


            If Strings.Left(Me.TextBox廃止日.Text, 1) <> " " Then
                If DateTime.TryParse(Me.TextBox廃止日.Text, dt) Then
                    '変換出来たら、dtにその値が入る
                    'MessageBox.Show("{0}はDateTime{1}に変換できます。")
                Else
                    MessageBox.Show("廃止日が日付けではりません")
                    Exit Sub
                End If
            End If
            If Strings.Left(Me.TextBoxWEB販売終了日.Text, 1) <> " " Then
                If DateTime.TryParse(Me.TextBoxWEB販売終了日.Text, dt) Then
                    '変換出来たら、dtにその値が入る
                    'MessageBox.Show("{0}はDateTime{1}に変換できます。")
                Else
                    MessageBox.Show("WEB販売終了日が日付けではりません")
                    Exit Sub
                End If
            End If
            If Me.TextBox発注ロット.Text <> "" Then
                If Chksuji(Me.TextBox発注ロット.Text) = False Then
                    MessageBox.Show("発注ロットが数字ではありません")
                    Exit Sub
                End If
            End If
            If Me.TextBox格納可能数.Text <> "" Then
                If Chksuji(Me.TextBox格納可能数.Text) = False Then
                    MessageBox.Show("格納可能数が数字ではありません")
                    Exit Sub
                End If
            End If

            If ChkSinaCd(Me.TextBox品コード.Text.Trim) Then
                Me.TextBox基準在庫.Text = Get_kijun(Me.TextBox品コード.Text.Trim)

                strSQL = "select update_day from " & schema & "t_parts_center where sinacd ='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                Ret = ClassPostgeDB.DbSel(strSQL)
                If Ret = "" Then
                    strSQL = "INSERT INTO " & schema & "t_parts_center (sinacd, s_kanjimei, s_souko, s_zaiko_flg, s_web_tourokumei, s_categori,s_categori2, s_koukai_jyouhou, s_haisi_bi, s_web_hanbai_syuryoubi"
                    strSQL &= ", s_hatyuu_lot, s_kijun_zaiko, s_kakunou_kanousu,entry_day, entry_sya ,s_shopkbn,s_gazou,s_konnpou,s_hassou,koukaibi , haisiyouteibi ,zaikosyori, zaikosyorihi ,  satueihaikihi  , satueitana    ,update_day)VALUES("
                    strSQL &= " '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBox漢字名称.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBox倉庫.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBox在庫フラグ.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & " '"
                    strSQL &= ",'" & Me.ComboBoxカテゴリ2.Text.TrimEnd.ToString & " '"
                    strSQL &= ",'" & Me.ComboBox公開情報.Text.TrimEnd.ToString & "'"

                    If IsDate(Me.TextBox廃止日.Text, "yyyy/MM/dd") Then
                        strSQL &= ",'" & Me.TextBox廃止日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"

                    End If
                    If IsDate(Me.TextBoxWEB販売終了日.Text, "yyyy/MM/dd") Then
                        strSQL &= ",'" & Me.TextBoxWEB販売終了日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    If IsNumeric(Me.TextBox発注ロット.Text.TrimEnd.ToString) = True Then
                        strSQL &= ",'" & Me.TextBox発注ロット.Text.TrimEnd.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    If IsNumeric(Me.TextBox基準在庫.Text.TrimEnd.ToString) = True Then
                        strSQL &= ",'" & Me.TextBox基準在庫.Text.TrimEnd.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If
                    If IsNumeric(Me.TextBox格納可能数.Text.TrimEnd.ToString) = True Then
                        strSQL &= ",'" & Me.TextBox格納可能数.Text.TrimEnd.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"

                    strSQL &= ",'" & Me.ComboBoxショップ区分.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBox画像.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBox梱包サイズ.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBox発送サイズ.Text.TrimEnd.ToString & "'"

                    If IsDate(Me.MaskedTextBox公開日.Text, "yyyy/MM/dd") Then
                        strSQL &= ",'" & Me.MaskedTextBox公開日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If
                    If IsDate(Me.MaskedTextBox廃止予定日.Text, "yyyy/MM/dd") Then
                        strSQL &= ",'" & Me.MaskedTextBox廃止予定日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If
                    If Me.CheckBox在庫処理.Checked Then
                        strSQL &= ",'1'"
                    Else
                        strSQL &= ",NULL"
                    End If
                    If IsDate(Me.MaskedTextBox在庫処理日.Text, "yyyy/MM/dd") Then
                        strSQL &= ",'" & Me.MaskedTextBox在庫処理日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    If IsDate(Me.MaskedTextBox撮影用部品廃棄日.Text, "yyyy/MM/dd") Then
                        strSQL &= ",'" & Me.MaskedTextBox撮影用部品廃棄日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    strSQL &= ",'" & Me.TextBox撮影用部品保管棚番号.Text.ToString & "'"

                    strSQL &= ",now()"
                        strSQL &= ")"

                        strSQL_t_buhin_spec = ""
                        strSQL_m_seihin = ""
                        ' & ", strftime('%Y-%m-%d %H:%M:%S', datetime(CURRENT_TIMESTAMP, '+9 hours')))"
                    Else
                        If Me.TextBox更新日.Text = Ret Then

                        strSQL = "update " & schema & "t_parts_center set "

                        strSQL &= " s_kanjimei  = '" & Me.TextBox漢字名称.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_souko     ='" & Me.ComboBox倉庫.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_zaiko_flg ='" & Me.ComboBox在庫フラグ.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_web_tourokumei = '" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_koukai_jyouhou ='" & Me.ComboBox公開情報.Text.TrimEnd.ToString & "'"
                        'strSQL &= ",s_haisi_bi='" & Me.TextBox廃止日.Text.ToString & "'"
                        'strSQL &= ",s_web_hanbai_syuryoubi ='" & Me.TextBoxWEB販売終了日.Text.ToString & "'"
                        'If Strings.Left(Me.TextBox廃止日.Text, 1) = " " Then

                        If IsDate(Me.TextBox廃止日.Text, "yyyy/MM/dd") Then
                            strSQL &= ",s_haisi_bi = '" & Me.TextBox廃止日.Text.ToString & "'"
                        Else
                            strSQL &= ",s_haisi_bi = NULL"
                        End If

                        If IsDate(Me.TextBoxWEB販売終了日.Text, "yyyy/MM/dd") Then
                            strSQL &= ",s_web_hanbai_syuryoubi = '" & Me.TextBoxWEB販売終了日.Text.ToString & "'"
                        Else
                            strSQL &= ", s_web_hanbai_syuryoubi = NULL"
                        End If


                        If IsNumeric(Me.TextBox発注ロット.Text.TrimEnd.ToString) = True Then
                            strSQL &= ",s_hatyuu_lot ='" & Me.TextBox発注ロット.Text.TrimEnd.ToString & "'"
                        Else
                            strSQL &= ",s_hatyuu_lot = NULL"
                        End If

                        If IsNumeric(Me.TextBox基準在庫.Text.TrimEnd.ToString) = True Then
                            strSQL &= ",s_kijun_zaiko ='" & Me.TextBox基準在庫.Text.TrimEnd.ToString & "'"
                        Else
                            strSQL &= ",s_kijun_zaiko = NULL"
                        End If

                        If IsNumeric(Me.TextBox格納可能数.Text.TrimEnd.ToString) = True Then
                            strSQL &= ",s_kakunou_kanousu ='" & Me.TextBox格納可能数.Text.TrimEnd.ToString & "'"
                        Else
                            strSQL &= ",s_kakunou_kanousu = NULL"
                        End If

                        strSQL &= ",update_day = now()"
                        strSQL &= ",entry_sya ='" & UserName & "'"

                        strSQL &= ",s_shopkbn = '" & Me.ComboBoxショップ区分.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_categori = '" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_categori2 = '" & Me.ComboBoxカテゴリ2.Text.TrimEnd.ToString & "'"

                        strSQL &= ",s_gazou = '" & Me.ComboBox画像.Text.TrimEnd.ToString & "'"

                        strSQL &= ",s_konnpou = '" & Me.TextBox梱包サイズ.Text.TrimEnd.ToString & "'"
                        strSQL &= ",s_hassou = '" & Me.ComboBox発送サイズ.Text.TrimEnd.ToString & "'"
                        If IsDate(Me.MaskedTextBox公開日.Text, "yyyy/MM/dd") Then
                            strSQL &= ",koukaibi ='" & Me.MaskedTextBox公開日.Text.ToString & "'"
                        Else
                            strSQL &= ",koukaibi =NULL"
                        End If
                        If IsDate(Me.MaskedTextBox廃止予定日.Text, "yyyy/MM/dd") Then
                            strSQL &= ",haisiyouteibi ='" & Me.MaskedTextBox廃止予定日.Text.ToString & "'"
                        Else
                            strSQL &= ",haisiyouteibi = NULL"
                        End If

                        If Me.CheckBox在庫処理.Checked Then
                            strSQL &= ",zaikosyori ='1'"
                        Else
                            strSQL &= ",zaikosyori=NULL"
                        End If
                        If IsDate(Me.MaskedTextBox在庫処理日.Text, "yyyy/MM/dd") Then
                            strSQL &= ",zaikosyorihi  = '" & Me.MaskedTextBox在庫処理日.Text.ToString & "'"
                        Else
                            strSQL &= ",zaikosyorihi = NULL"
                        End If

                        If IsDate(Me.MaskedTextBox撮影用部品廃棄日.Text, "yyyy/MM/dd") Then
                            strSQL &= ", satueihaikihi = '" & Me.MaskedTextBox撮影用部品廃棄日.Text.ToString & "'"
                        Else
                            strSQL &= ", satueihaikihi = NULL"
                        End If

                        strSQL &= ", satueitana = '" & Me.TextBox撮影用部品保管棚番号.Text.ToString & "'"

                        strSQL &= " where sinacd = '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"

                        '//
                        strSQL_t_buhin_spec = "UPDATE " & schema & "t_buhin_spec SET"
                        strSQL_t_buhin_spec &= " categori = '" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                        strSQL_t_buhin_spec &= ",categori2 = '" & Me.ComboBoxカテゴリ2.Text.TrimEnd.ToString & "'"
                        strSQL_t_buhin_spec &= ",update_day = now()"
                        strSQL_t_buhin_spec &= ",web_tourokumei ='" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"

                        strSQL_t_buhin_spec &= ",entry_sya ='" & UserName & "'"
                        strSQL_t_buhin_spec &= " where sinacd = '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"

                        '//
                        strSQL_m_seihin = "UPDATE " & schema & "m_seihin SET "
                        If IsDate(Me.TextBox廃止日.Text, "yyyy/MM/dd") Then
                            strSQL_m_seihin &= " haisibi = '" & Me.TextBox廃止日.Text.ToString & "'"
                        Else
                            strSQL_m_seihin &= " haisibi = NULL"
                        End If
                        strSQL_m_seihin &= ", aitesakihinban = '" & Me.TextBox相手先品番.Text.TrimEnd.ToString & "'"
                        strSQL_m_seihin &= ", categori = '" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                        strSQL_m_seihin &= ", web_tourokumei = '" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"
                        strSQL_m_seihin &= ", update_day = now() "
                        strSQL_m_seihin &= ", entry_sya = '" & UserName & "'"

                        strSQL_m_seihin &= " where sinacd = '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"

                    Else
                        MessageBox.Show("すでに登録済み又はデータが更新されています。再検索してください")
                        Exit Sub
                    End If
                End If
                If ClassPostgeDB.EXEC(strSQL) Then
                    If ClassPostgeDB.EXEC(strSQL_m_seihin) Then

                        If ClassPostgeDB.EXEC(strSQL_t_buhin_spec) Then


                            MessageBox.Show("更新しました")
                            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                            Me.DataGridView1.ReadOnly = True
                            strSQL = "select update_day from " & schema & "t_parts_center where sinacd ='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                            Me.TextBox更新日.Text = ClassPostgeDB.DbSel(strSQL)
                        Else
                            MessageBox.Show("更新エラーです")
                        End If

                    Else
                        MessageBox.Show("更新エラーです")
                    End If
                Else
                    MessageBox.Show("更新エラーです")
                End If
            Else
                MessageBox.Show("品コードがマスタに存在しません")
            End If
        End If
    End Sub
    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click

        Dim strSQL As String
        Dim Ret
        'MessageBox.Show(TextBox廃止日.Value.ToString())

        If Me.TextBox品コード.Text.Trim <> "" Then
            strSQL = "select count(sinacd) from " & schema & "t_parts_center where sinacd ='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "1" Then

                strSQL = "DELETE from  " & schema & "t_parts_center where sinacd ='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                Ret = ClassPostgeDB.DbSel(strSQL)
                MessageBox.Show("削除しました")

                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

                Clear("")

            End If
        End If

    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value

                Me.TextBox漢字名称.Text = Me.DataGridView1.Rows(ro).Cells(1).Value

                'Me.ComboBox倉庫.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                SetComboBox(Me.ComboBox倉庫, Me.DataGridView1.Rows(ro).Cells(2).Value)

                SetComboBox(Me.ComboBox在庫フラグ, Me.DataGridView1.Rows(ro).Cells(3).Value)
                'Me.ComboBox在庫フラグ.Text = Me.DataGridView1.Rows(ro).Cells(3).Value
                Me.TextBoxWEB登録名.Text = Me.DataGridView1.Rows(ro).Cells(4).Value

                'Me.ComboBoxカテゴリ.Text = Me.DataGridView1.Rows(ro).Cells(5).Value
                'Me.ComboBox公開情報.Text = Me.DataGridView1.Rows(ro).Cells(6).Value
                SetComboBox(Me.ComboBoxカテゴリ, Me.DataGridView1.Rows(ro).Cells(5).Value)
                SetComboBox(Me.ComboBoxカテゴリ2, Me.DataGridView1.Rows(ro).Cells(6).Value)
                SetComboBox(Me.ComboBox公開情報, Me.DataGridView1.Rows(ro).Cells(7).Value)

                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(8).Value, 1) = "" Then
                    Me.TextBox廃止日.Text = ""
                Else
                    Me.TextBox廃止日.Text = Me.DataGridView1.Rows(ro).Cells(8).Value
                End If

                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(9).Value, 1) = "" Then
                    Me.TextBoxWEB販売終了日.Text = ""
                Else
                    Me.TextBoxWEB販売終了日.Text = Me.DataGridView1.Rows(ro).Cells(9).Value
                End If

                Me.TextBox発注ロット.Text = Me.DataGridView1.Rows(ro).Cells(10).Value
                Me.TextBox基準在庫.Text = Me.DataGridView1.Rows(ro).Cells(11).Value
                Me.TextBox格納可能数.Text = Me.DataGridView1.Rows(ro).Cells(12).Value

                SetComboBox(Me.ComboBoxショップ区分, Me.DataGridView1.Rows(ro).Cells(13).Value)
                SetComboBox(Me.ComboBox画像, Me.DataGridView1.Rows(ro).Cells(14).Value)

                Me.TextBox梱包サイズ.Text = Me.DataGridView1.Rows(ro).Cells(15).Value
                SetComboBox(Me.ComboBox発送サイズ, Me.DataGridView1.Rows(ro).Cells(16).Value)


                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(17).Value, 1) = "" Then
                    Me.MaskedTextBox公開日.Text = ""
                Else
                    Me.MaskedTextBox公開日.Text = Me.DataGridView1.Rows(ro).Cells(17).Value
                End If

                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(18).Value, 1) = "" Then
                    Me.MaskedTextBox廃止予定日.Text = ""
                Else
                    Me.MaskedTextBox廃止予定日.Text = Me.DataGridView1.Rows(ro).Cells(18).Value
                End If

                Me.TextBox相手先品番.Text = Me.DataGridView1.Rows(ro).Cells(19).Value

                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(20).Value, 1) = "1" Then
                    Me.CheckBox在庫処理.Checked = True
                Else
                    Me.CheckBox在庫処理.Checked = False
                End If

                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(21).Value, 1) = "" Then
                    Me.MaskedTextBox在庫処理日.Text = ""
                Else
                    Me.MaskedTextBox在庫処理日.Text = Me.DataGridView1.Rows(ro).Cells(21).Value
                End If


                If Strings.Left(Me.DataGridView1.Rows(ro).Cells(22).Value, 1) = "" Then
                    Me.MaskedTextBox撮影用部品廃棄日.Text = ""
                Else
                    Me.MaskedTextBox撮影用部品廃棄日.Text = Me.DataGridView1.Rows(ro).Cells(22).Value
                End If
                Me.TextBox撮影用部品保管棚番号.Text = Me.DataGridView1.Rows(ro).Cells(23).Value


                Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(26).Value



            Else
                Clear("")
            End If
        End If

    End Sub

    Private Sub Button品コード検索_Click(sender As Object, e As EventArgs) Handles Button品コード検索.Click
        'Dim Fm As New FormSelectSeihin

        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text

        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            'MessageBox.Show(Fm.SeihinName)
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox漢字名称.Text = FormSelectSeihin.SeihinName
            FormSelectSeihin.Dispose()
        End If

        FormSelectSeihin.Dispose()
    End Sub

    Private Sub TextBoxWEB販売終了日1_ValueChanged(sender As Object, e As EventArgs) Handles TextBoxWEB販売終了日1.ValueChanged
        Me.TextBoxWEB販売終了日.Text = Me.TextBoxWEB販売終了日1.Value
    End Sub

    Private Sub TextBox廃止日12_ValueChanged(sender As Object, e As EventArgs) Handles TextBox廃止日12.ValueChanged
        Me.TextBox廃止日.Text = Me.TextBox廃止日12.Value

    End Sub

    Private Sub ComboBoxカテゴリ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxカテゴリ.SelectedIndexChanged
        Dim strSQL As String
        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='19' and seq like '" & GetKry(Me.ComboBoxカテゴリ.Text) & "%'  order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBoxカテゴリ2, strSQL)

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

    Private Sub DateTimePicker公開日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker公開日.ValueChanged

        Me.MaskedTextBox公開日.Text = Me.DateTimePicker公開日.Value

    End Sub

    Private Sub DateTimePicker廃止予定日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker廃止予定日.ValueChanged
        Me.MaskedTextBox廃止予定日.Text = Me.DateTimePicker廃止予定日.Value

    End Sub

    Private Sub Button検索４_Click(sender As Object, e As EventArgs) Handles Button検索４.Click
        Me.ComboBoxJy4.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy4, "tpc.s_souko", Me.ComboBox倉庫.Text)
        Clear("4")
    End Sub

    Private Sub Button検索５_Click(sender As Object, e As EventArgs) Handles Button検索５.Click
        Me.ComboBoxJy5.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy5, "tpc.s_zaiko_flg", Me.ComboBox在庫フラグ.Text)
        Clear("5")
    End Sub

    Private Sub Button検索６_Click(sender As Object, e As EventArgs) Handles Button検索６.Click
        Me.ComboBoxJy6.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy6, "tpc.s_koukai_jyouhou", Me.ComboBox公開情報.Text)
        Clear("6")
    End Sub

    Private Sub Button検索７_Click(sender As Object, e As EventArgs) Handles Button検索７.Click
        Me.ComboBoxJy7.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy7, "tpc.s_categori", Me.ComboBoxカテゴリ.Text)
        Clear("7")
    End Sub
    Private Sub Button検索８_Click(sender As Object, e As EventArgs) Handles Button検索８.Click
        Me.ComboBoxJy8.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy8, "tpc.s_categori2", Me.ComboBoxカテゴリ2.Text)
        Clear("8")
    End Sub

    Private Sub Button検索９_Click(sender As Object, e As EventArgs) Handles Button検索９.Click
        Me.ComboBoxJy9.SelectedIndex = 0
        Call 検索(Me.ComboBoxJy9, "tpc.s_shopkbn", Me.ComboBoxショップ区分.Text)
        Clear("9")
    End Sub

    Private Sub Button検索10_Click(sender As Object, e As EventArgs) Handles Button検索10.Click

        検索２("s_haisi_bi", Me.DateTimePicker廃止日1.Value.ToString("yyyy/MM/dd"), Me.DateTimePicker廃止日2.Value.ToString("yyyy/MM/dd"))
        Clear("10")

    End Sub

    Private Sub Button検索11_Click(sender As Object, e As EventArgs) Handles Button検索11.Click
        検索２("s_web_hanbai_syuryoubi", Me.DateTimePicker販売終了日1.Value.ToString("yyyy/MM/dd"), Me.DateTimePicker販売終了日2.Value.ToString("yyyy/MM/dd"))
        Clear("11")
    End Sub

    Private Sub Button検索12_Click(sender As Object, e As EventArgs) Handles Button検索12.Click
        検索２("haisiyouteibi", Me.DateTimePicker廃止予定日1.Value.ToString("yyyy/MM/dd"), Me.DateTimePicker廃止予定日2.Value.ToString("yyyy/MM/dd"))
        Clear("12")

    End Sub

    Private Sub FormShop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "10") Then

        End If

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub DateTimePicker撮影用部品廃棄日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker撮影用部品廃棄日.ValueChanged
        Me.MaskedTextBox撮影用部品廃棄日.Text = Me.DateTimePicker撮影用部品廃棄日.Value
    End Sub

    Private Sub DateTimePicker在庫処理日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker在庫処理日.ValueChanged
        Me.MaskedTextBox在庫処理日.Text = Me.DateTimePicker在庫処理日.Value

    End Sub
End Class