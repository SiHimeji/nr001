Public Class FormMstSeihin
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    Dim w廃止日 As String
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

    Private Sub 検索(Cob As ComboBox, jy As String, txt As String)
        Dim strSQL As String

        'strSQL = "SELECT  sinacd, seihinmei, categori,inputkbn, makerkbn, furikae, tokuisakicd, kijunzaiko,to_char(askyoukyuu,'yyyy/mm/dd') as askyoukyuu,to_char(haisiyotei,'yyyy/mm/dd') as haisiyotei,to_char(haisibi,'yyyy/mm/dd') as haisibi, souko ,  hanbai ,seihinflg, genka , hoyunen, update_day ,entry_sya FROM m_seihin where entry_day is not null"
        'strSQL = "SELECT  sinacd, seihinmei, categori,inputkbn, makerkbn,  tokuisakicd, kijunzaiko,to_char(haisiyotei,'yyyy/mm/dd') as haisiyotei,to_char(haisibi,'yyyy/mm/dd') as haisibi, souko ,  hanbai ,seihinflg, genka , hoyunen, aitesakihinban, update_day ,entry_sya "
        strSQL = "SELECT  sinacd, seihinmei, categori,inputkbn, makerkbn, gas, tokuisakicd, kijunzaiko,to_char(haisiyotei,'yyyy/mm/dd') as haisiyotei,to_char(haisibi,'yyyy/mm/dd') as haisibi, souko ,  hanbai ,seihinflg, genka , hoyunen, aitesakihinban,shop,buhin, update_day ,entry_sya "
        strSQL &= ",ruuru , kobetu"
        strSQL &= " FROM " & schema & "m_seihin where entry_day Is Not null"
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

    End Sub

    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Clear("1")
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード.Text)
    End Sub

    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        Clear("2")
        Call 検索(Me.ComboBoxJy2, "seihinmei", Me.TextBox商品名.Text)

    End Sub
    Private Sub Button検索３_Click(sender As Object, e As EventArgs) Handles Button検索３.Click
        Clear("3")
        Call 検索(Me.ComboBoxJy3, "categori", Me.ComboBoxカテゴリ.Text)

    End Sub
    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL_t_buhin_spec As String
        Dim strSQL_t_parts_center As String
        Dim strSQL As String
        Dim wsendmail As String
        Dim Ret
        Dim dt As DateTime

        If Strings.Left(Me.MaskedTextBox廃止日.Text, 1) <> " " Then
            If DateTime.TryParse(Me.MaskedTextBox廃止日.Text, dt) Then
                '変換出来たら、dtにその値が入る
                'MessageBox.Show("{0}はDateTime{1}に変換できます。")
            Else
                MessageBox.Show("廃止日が日付けではりません")
                Exit Sub
            End If
        End If
        If Me.TextBoxk基準在庫.Text <> "" Then
            If Chksuji(Me.TextBoxk基準在庫.Text) = False Then
                MessageBox.Show("基準在庫が数字ではありません")
                Exit Sub
            End If
        End If
        If Me.TextBox販売価格.Text <> "" Then
            If Chksuji(Me.TextBox販売価格.Text) = False Then
                MessageBox.Show("販売価格が数字ではありません")
                Exit Sub
            End If
        End If
        If Me.TextBox現在庫.Text <> "" Then
            If Chksuji(Me.TextBox現在庫.Text) = False Then
                MessageBox.Show("現在庫が数字ではありません")
                Exit Sub
            End If
        End If
        If Me.TextBox注文残.Text <> "" Then
            If Chksuji(Me.TextBox注文残.Text) = False Then
                MessageBox.Show("注文残が数字ではありません")
                Exit Sub
            End If
        End If
        If Me.TextBox納入数.Text <> "" Then
            If Chksuji(Me.TextBox納入数.Text) = False Then
                MessageBox.Show("受注数が数字ではありません")
                Exit Sub
            End If
        End If
        If Me.TextBox保有年.Text <> "" Then
            If Chksuji(Me.TextBox保有年.Text) = False Then
                MessageBox.Show("保有年が数字ではありません")
                Exit Sub
            End If
        End If
        If Me.TextBox原価.Text <> "" Then
            If Chksuji(Me.TextBox原価.Text) = False Then
                MessageBox.Show("原価が数字ではありません")
                Exit Sub
            End If
        End If
        wsendmail = ""

        If Me.TextBox品コード.Text.Trim <> "" Then
            strSQL = "select count(sinacd) from " & schema & "m_seihin where sinacd ='" & Me.TextBox品コード.Text.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = "INSERT INTO " & schema & "m_seihin (categori, sinacd, seihinmei, inputkbn, makerkbn, furikae, tokuisakicd, entry_day,update_day,entry_sya ,kijunzaiko, haisibi,souko,hanbai ,seihinflg, genka , hoyunen,askyoukyuu,haisiyotei,aitesakihinban,gas,shop,buhin,sendmail, ruuru ,kobetu) VALUES("
                strSQL &= " '" & Me.ComboBoxカテゴリ.Text.ToString() & "'"
                strSQL &= ",'" & Me.TextBox品コード.Text.ToString() & "'"
                strSQL &= ",'" & Me.TextBox商品名.Text.ToString() & "'"
                strSQL &= ",'" & Me.ComboBox倉庫.Text.ToString() & "'"
                strSQL &= ",'" & Me.ComboBoxメーカー.Text.ToString() & "'"
                strSQL &= ",'" & Me.ComboBox入力振分.Text.ToString() & "'"
                strSQL &= ",'" & Me.ComboBox得意先コード.Text.ToString() & "'"
                strSQL &= ",now()"
                strSQL &= ",now()"
                strSQL &= ",'" & UserName & "'"

                If IsNumeric(Me.TextBoxk基準在庫.Text.TrimEnd.ToString) = True Then
                    strSQL &= ",'" & Me.TextBoxk基準在庫.Text.TrimEnd.ToString & "'"
                Else
                    strSQL &= ",'0'"
                End If

                If Strings.Left(Me.MaskedTextBox廃止日.Text, 1) = " " Then
                    strSQL &= " ,NULL "
                Else
                    strSQL &= ",'" & Me.MaskedTextBox廃止日.Text & "'"
                End If
                strSQL &= ",'" & Me.ComboBox在庫種類.Text.ToString() & "'"

                If IsNumeric(Me.TextBox販売価格.Text.TrimEnd.ToString) = True Then
                    strSQL &= ",'" & Me.TextBox販売価格.Text.TrimEnd.ToString & "'"
                Else
                    strSQL &= ",'0'"
                End If
                strSQL &= ",'" & Me.ComboBox製品.Text & "'"

                If IsNumeric(Me.TextBox原価.Text.TrimEnd.ToString) = True Then
                    strSQL &= ",'" & Me.TextBox原価.Text.TrimEnd.ToString & "'"
                Else
                    strSQL &= ",'0'"
                End If
                If IsNumeric(Me.TextBox保有年.Text.TrimEnd.ToString) = True Then
                    strSQL &= ",'" & Me.TextBox保有年.Text.TrimEnd.ToString & "'"
                Else
                    strSQL &= ",'0'"
                End If

                If Strings.Left(Me.MaskedTextBoxAS供給停止日.Text, 1) = " " Then
                    strSQL &= " ,NULL "
                Else
                    strSQL &= ",'" & Me.MaskedTextBoxAS供給停止日.Text & "'"
                End If
                If Strings.Left(Me.MaskedTextBox廃止予定日.Text, 1) = " " Then
                    strSQL &= " ,NULL "
                Else
                    strSQL &= ",'" & Me.MaskedTextBox廃止予定日.Text & "'"
                End If
                strSQL &= ",'" & Me.TextBox相手先品番.Text.TrimEnd.ToString & "'"

                strSQL &= ",'" & Me.ComboBoxガス種.Text & "'"


                If Me.CheckBoxショップ登録用部品.Checked Then
                    strSQL &= ",'1'"
                Else
                    strSQL &= ",'0'"
                End If
                If Me.CheckBox部品スペック.Checked Then
                    strSQL &= ",'1'"
                Else
                    strSQL &= ",'0'"
                End If

                strSQL &= ",'" & wsendmail & "'"

                If Me.NumericUpDown単位.Value > 0 Then
                    strSQL &= ",'" & Me.NumericUpDown単位.Value & "'"
                Else
                    strSQL &= ",''"
                End If

                If Me.CheckBox個別.Checked Then
                    strSQL &= ",'1'"
                Else
                    strSQL &= ",'0'"
                End If

                strSQL &= ")"

                Else

                    strSQL = "Select update_day from " & schema & "m_seihin where sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
                Ret = ClassPostgeDB.DbSel(strSQL)
                If Ret = Me.TextBox更新日.Text Then


                    strSQL = "UPDATE " & schema & "m_seihin SET categori = '" & Me.ComboBoxカテゴリ.Text.ToString() & "'"
                    strSQL &= ", seihinmei = '" & Me.TextBox商品名.Text.ToString() & "'"
                    strSQL &= ", inputkbn = '" & Me.ComboBox倉庫.Text.ToString() & "'"
                    strSQL &= ", makerkbn = '" & Me.ComboBoxメーカー.Text.ToString() & "'"
                    strSQL &= ", furikae  = '" & Me.ComboBox入力振分.Text.ToString() & "'"
                    strSQL &= ", tokuisakicd   = '" & Me.ComboBox得意先コード.Text.ToString() & "'"
                    strSQL &= ", update_day = now() "
                    strSQL &= ", entry_sya = '" & UserName & "'"

                    If IsNumeric(Me.TextBoxk基準在庫.Text.TrimEnd.ToString) = True Then

                        strSQL &= ",kijunzaiko = '" & Me.TextBoxk基準在庫.Text & "'"
                    Else
                        strSQL &= ",kijunzaiko = NULL"
                    End If
                    strSQL &= ", souko = '" & Me.ComboBox在庫種類.Text.ToString() & "'"
                    If Strings.Left(Me.MaskedTextBoxAS供給停止日.Text, 1) = " " Then
                        strSQL &= ", askyoukyuu = NULL"
                    Else
                        strSQL &= ", askyoukyuu ='" & Me.MaskedTextBoxAS供給停止日.Text & "'"
                    End If
                    If Strings.Left(Me.MaskedTextBox廃止予定日.Text, 1) = " " Then
                        strSQL &= ", haisiyotei = NULL"
                    Else
                        strSQL &= ", haisiyotei ='" & Me.MaskedTextBox廃止予定日.Text & "'"
                    End If

                    If Strings.Left(Me.MaskedTextBox廃止日.Text, 1) = " " Then
                        strSQL &= ", haisibi = NULL"
                    Else
                        strSQL &= ", haisibi ='" & Me.MaskedTextBox廃止日.Text & "'"
                    End If

                    If IsNumeric(Me.TextBox販売価格.Text.TrimEnd.ToString) = True Then
                        strSQL &= ",hanbai ='" & Me.TextBox販売価格.Text.TrimEnd.ToString & "'"
                    Else
                        strSQL &= ",hanbai ='0'"
                    End If

                    strSQL &= ", seihinflg = '" & Me.ComboBox製品.Text & "'"

                    If IsNumeric(Me.TextBox原価.Text.TrimEnd.ToString) = True Then
                        strSQL &= ",genka = '" & Me.TextBox原価.Text.TrimEnd.ToString & "'"
                    Else
                        strSQL &= ",genka ='0'"
                    End If
                    If IsNumeric(Me.TextBox保有年.Text.TrimEnd.ToString) = True Then
                        strSQL &= ", hoyunen ='" & Me.TextBox保有年.Text.TrimEnd.ToString & "'"
                    Else
                        strSQL &= ", hoyunen = '0'"
                    End If
                    strSQL &= " , aitesakihinban ='" & Me.TextBox相手先品番.Text.TrimEnd.ToString & "'"
                    strSQL &= " , gas ='" & Me.ComboBoxガス種.Text.ToString() & "'"

                    '//
                    If Me.CheckBoxショップ登録用部品.Checked Then
                        strSQL &= ",shop='1'"
                    Else
                        strSQL &= ",shop='0'"
                    End If
                    If Me.CheckBox部品スペック.Checked Then
                        strSQL &= ",buhin='1'"
                    Else
                        strSQL &= ",buhin='0'"
                    End If
                    strSQL &= ",sendmail = '" & wsendmail & "'"

                    strSQL &= ",ruuru ='" & Me.NumericUpDown単位.Value & "'"

                    If Me.CheckBox個別.Checked Then
                        strSQL &= ",kobetu = '1'"
                    Else
                        strSQL &= ",kobetu = '0'"
                    End If



                    strSQL &= " where sinacd = '" & Me.TextBox品コード.Text.ToString & "'"

                Else
                    MessageBox.Show("データが更新されています。再検索してください")
                    Exit Sub
                End If
            End If

            If ClassPostgeDB.EXEC(strSQL) Then

                SetZaiko(Me.TextBox品コード.Text.ToString, Me.TextBox現在庫.Text.ToString, Me.TextBox注文残.Text.ToString, "0")
                '======  t_parts_center への更新　　t_buhin_specへの追加

                If Me.CheckBox部品スペック.Checked Then

                    strSQL_t_buhin_spec = "select count(sinacd) from " & schema & "t_buhin_spec where sinacd ='" & Me.TextBox品コード.Text.ToString & "'"

                    Ret = ClassPostgeDB.DbSel(strSQL_t_buhin_spec)
                    If Ret = "0" Then
                        strSQL_t_buhin_spec = "INSERT INTO " & schema & "t_buhin_spec (sinacd, syouhinmei,categori, oem ,entry_day, entry_sya,  update_day)VALUES("
                        strSQL_t_buhin_spec &= "'" & Me.TextBox品コード.Text.ToString() & "'"
                        strSQL_t_buhin_spec &= ",'" & Me.TextBox商品名.Text.ToString() & "'"
                        strSQL_t_buhin_spec &= ",'" & Me.ComboBoxカテゴリ.Text.ToString() & "'"
                        strSQL_t_buhin_spec &= ",'" & Me.TextBox相手先品番.Text.ToString() & "'"
                        strSQL_t_buhin_spec &= ",now()"
                        strSQL_t_buhin_spec &= ",'" & UserName & "'"
                        strSQL_t_buhin_spec &= ",now()"
                        strSQL_t_buhin_spec &= ")"
                    Else
                        strSQL_t_buhin_spec = "UPDATE " & schema & "t_buhin_spec SET "
                        strSQL_t_buhin_spec &= " syouhinmei = '" & Me.TextBox商品名.Text.ToString() & "'"
                        strSQL_t_buhin_spec &= ", categori = '" & Me.ComboBoxカテゴリ.Text.ToString() & "'"
                        strSQL_t_buhin_spec &= ", oem ='" & Me.TextBox相手先品番.Text.TrimEnd.ToString() & "'"
                        strSQL_t_buhin_spec &= ", entry_sya ='" & UserName & "'"
                        strSQL_t_buhin_spec &= ", update_day =now()"
                        strSQL_t_buhin_spec &= " WHERE sinacd "
                        strSQL_t_buhin_spec &= " = '" & Me.TextBox品コード.Text.ToString() & "'"
                    End If

                    If Not ClassPostgeDB.EXEC(strSQL_t_buhin_spec) Then
                        MessageBox.Show("部品スペック更新エラーです")
                        Exit Sub
                    End If



                Else
                    strSQL_t_buhin_spec = "DELETE FROM " & schema & "t_buhin_spec  "
                    strSQL_t_buhin_spec &= " WHERE sinacd "
                    strSQL_t_buhin_spec &= " = '" & Me.TextBox品コード.Text.ToString() & "'"
                    'If Not ClassPostgeDB.EXEC(strSQL_t_buhin_spec) Then
                    'MessageBox.Show("部品スペック更新エラーです")
                    'Exit Sub
                    'End If
                End If
                If Me.CheckBoxショップ登録用部品.Checked Then

                    strSQL_t_parts_center = "select count(sinacd) from " & schema & "t_parts_center where sinacd ='" & Me.TextBox品コード.Text.ToString & "'"

                    Ret = ClassPostgeDB.DbSel(strSQL_t_parts_center)
                    If Ret = "0" Then
                        strSQL_t_parts_center = "INSERT INTO " & schema & "t_parts_center(sinacd, s_kanjimei,  s_categori,haisiyouteibi, s_haisi_bi,  entry_day, entry_sya,  update_day)VALUES("
                        strSQL_t_parts_center &= "'" & Me.TextBox品コード.Text.ToString() & "'"
                        strSQL_t_parts_center &= ",'" & Me.TextBox商品名.Text.ToString() & "'"
                        strSQL_t_parts_center &= ",'" & Me.ComboBoxカテゴリ.Text.ToString() & "'"
                        If Strings.Left(Me.MaskedTextBox廃止予定日.Text, 1) = " " Then
                            strSQL_t_parts_center &= ",NULL"
                        Else
                            strSQL_t_parts_center &= ", '" & Me.MaskedTextBox廃止予定日.Text & "'"
                        End If

                        If Strings.Left(Me.MaskedTextBox廃止日.Text, 1) = " " Then
                            strSQL_t_parts_center &= " ,NULL "
                        Else
                            strSQL_t_parts_center &= ",'" & Me.MaskedTextBox廃止日.Text & "'"
                        End If
                        strSQL_t_parts_center &= ",now()"
                        strSQL_t_parts_center &= ",'" & UserName & "'"
                        strSQL_t_parts_center &= ",now()"
                        strSQL_t_parts_center &= ")"
                    Else
                        strSQL_t_parts_center = "UPDATE  " & schema & "t_parts_center SET"
                        strSQL_t_parts_center &= " s_kanjimei = '" & Me.TextBox商品名.Text.ToString() & "'"
                        strSQL_t_parts_center &= ",s_categori = '" & Me.ComboBoxカテゴリ.Text.ToString() & "'"
                        If Strings.Left(Me.MaskedTextBox廃止予定日.Text, 1) = " " Then
                            strSQL_t_parts_center &= ",  haisiyouteibi=NULL "
                        Else
                            strSQL_t_parts_center &= ",  haisiyouteibi='" & Me.MaskedTextBox廃止予定日.Text & "'"
                        End If

                        If Strings.Left(Me.MaskedTextBox廃止日.Text, 1) = " " Then
                            strSQL_t_parts_center &= " ,s_haisi_bi =NULL "
                        Else
                            strSQL_t_parts_center &= ",s_haisi_bi ='" & Me.MaskedTextBox廃止日.Text & "'"
                        End If
                        strSQL_t_parts_center &= ",entry_sya = '" & UserName & "'"
                        strSQL_t_parts_center &= ",update_day = now()"
                        strSQL_t_parts_center &= " WHERE sinacd "
                        strSQL_t_parts_center &= " ='" & Me.TextBox品コード.Text.ToString() & "'"
                    End If
                    If Not ClassPostgeDB.EXEC(strSQL_t_parts_center) Then
                        MessageBox.Show("ショップ登録用部品更新エラーです")
                        Exit Sub
                    End If
                Else
                    strSQL_t_parts_center = "DELETE FROM " & schema & "t_parts_center "
                    strSQL_t_parts_center &= " WHERE sinacd "
                    strSQL_t_parts_center &= " ='" & Me.TextBox品コード.Text.ToString() & "'"
                    'If Not ClassPostgeDB.EXEC(strSQL_t_parts_center) Then
                    'MessageBox.Show("ショップ登録用部品更新エラーです")
                    'Exit Sub
                    'End If
                End If
                廃止予定日更新()

                MessageBox.Show("更新しました")
                strSQL = "Select update_day from " & schema & "m_seihin where sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
                Me.TextBox更新日.Text = ClassPostgeDB.DbSel(strSQL)

                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

            End If
        End If
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub 廃止予定日更新()
        Dim strSQL As String
        strSQL = "UPDATE " & schema & "t_parts_center SET "
        If Strings.Left(Me.MaskedTextBox廃止予定日.Text, 1) = " " Then
            strSQL &= " haisiyouteibi=NULL "
        Else
            strSQL &= " haisiyouteibi='" & Me.MaskedTextBox廃止予定日.Text & "'"

        End If
        strSQL &= " WHERE sinacd "
        strSQL &= " ='" & Me.TextBox品コード.Text.ToString() & "'"
        ClassPostgeDB.EXEC(strSQL)

        If Strings.Left(Me.MaskedTextBox廃止予定日.Text, 1) = " " Then
            '空白
            ClassPostgeDB.EXEC("update " & schema & "m_seihin set sendmail ='' where sinacd  ='" & Me.TextBox品コード.Text.ToString() & "'")
        Else
            Dim sw As String = ClassPostgeDB.DbSel("select replace (COALESCE(sendmail,'0') || ' ',' ','0')  from " & schema & "m_seihin  where sinacd ='" & Me.TextBox品コード.Text.ToString() & "'")
            If sw = "0" Or sw = "00" Then
                ClassPostgeDB.EXEC("update " & schema & "m_seihin set sendmail ='1' where sinacd  ='" & Me.TextBox品コード.Text.ToString() & "'")
            End If
        End If
    End Sub

    Public Sub SetZaiko(sinacd As String, ggenzko As String, tyuuzan As String, jyutyuu As String)
        Dim strSQL As String
        Dim ret As String

        If IsNumeric(ggenzko) = False Then
            ggenzko = "0"
        End If
        If IsNumeric(tyuuzan) = False Then
            tyuuzan = "0"
        End If
        If IsNumeric(jyutyuu) = False Then
            jyutyuu = "0"
        End If

        strSQL = "SELECT count(sinacd) FROM " & schema & "t_genzaiko where sinacd = '" & sinacd & "'"
        ret = ClassPostgeDB.DbSel(strSQL)
        If ret = "0" Then
            strSQL = "INSERT INTO " & schema & "t_genzaiko(sinacd, genzaiko, tyuuzan, entry_day, entry_sya,jyutyuu)VALUES("
            strSQL &= " '" & sinacd & "'"
            strSQL &= ",'" & ggenzko & "'"
            strSQL &= ",'" & tyuuzan & "'"
            strSQL &= ",now()"
            strSQL &= ",'" & UserName & "'"
            strSQL &= ",'0'"
            strSQL &= ")"
        Else
            strSQL = "Update " & schema & "t_genzaiko SET "
            strSQL &= " genzaiko = '" & ggenzko & "'"
            strSQL &= ",tyuuzan = '" & tyuuzan & "'"
            strSQL &= ",entry_day = now()"
            strSQL &= ",entry_sya ='" & UserName & "'"
            strSQL &= ",jyutyuu ='0'" ' & jyutyuu & "'"
            strSQL &= " where sinacd = '" & sinacd & "'"
        End If

        If ClassPostgeDB.EXEC(strSQL) Then

        Else

        End If

    End Sub

    Private Sub Clear(sw As String)

        Select Case sw
            Case "1"
                'Me.TextBox品コード.Text = ""
                Me.TextBox商品名.Text = ""
                Me.ComboBoxカテゴリ.SelectedIndex = -1
            Case "2"
                Me.TextBox品コード.Text = ""
                'Me.TextBox商品名.Text = ""
                Me.ComboBoxカテゴリ.SelectedIndex = -1
            Case "3"
                Me.TextBox品コード.Text = ""
                Me.TextBox商品名.Text = ""
                'Me.TextBoxメイングループ.Text = ""
            Case Else
                Me.TextBox品コード.Text = ""
                Me.TextBox商品名.Text = ""
                Me.ComboBoxカテゴリ.SelectedIndex = -1
        End Select

        Me.ComboBox倉庫.SelectedIndex = -1
        Me.ComboBoxメーカー.SelectedIndex = -1
        Me.ComboBox入力振分.SelectedIndex = -1
        Me.ComboBoxガス種.SelectedIndex = -1
        Me.ComboBox得意先コード.SelectedIndex = -1
        Me.ComboBox製品.SelectedIndex = -1
        Me.ComboBox在庫種類.SelectedIndex = -1

        Me.TextBoxk基準在庫.Text = ""
        Me.MaskedTextBoxAS供給停止日.Text = ""
        Me.MaskedTextBox廃止予定日.Text = ""
        Me.MaskedTextBox廃止日.Text = ""
        Me.TextBox販売価格.Text = ""
        Me.TextBox原価.Text = ""
        Me.TextBox保有年.Text = ""
        Me.TextBox更新日.Text = ""

        Me.TextBox現在庫.Text = ""
        Me.TextBox納入数.Text = ""
        Me.TextBox注文残.Text = ""
        Me.TextBox相手先品番.Text = ""
        w廃止日 = ""
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro As Integer

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then

                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox商品名.Text = Me.DataGridView1.Rows(ro).Cells(1).Value

                SetComboBox(Me.ComboBoxカテゴリ, Me.DataGridView1.Rows(ro).Cells(2).Value)   '

                SetComboBox(ComboBox倉庫, Me.DataGridView1.Rows(ro).Cells(3).Value)
                SetComboBox(ComboBoxメーカー, Me.DataGridView1.Rows(ro).Cells(4).Value)
                SetComboBox(ComboBoxガス種, Me.DataGridView1.Rows(ro).Cells(5).Value)
                SetComboBox(ComboBox得意先コード, Me.DataGridView1.Rows(ro).Cells(6).Value)
                Me.TextBoxk基準在庫.Text = Me.DataGridView1.Rows(ro).Cells(7).Value

                If IsDate(Me.DataGridView1.Rows(ro).Cells(8).Value, "yyyy/mm/dd") Then
                    Me.MaskedTextBox廃止予定日.Text = Me.DataGridView1.Rows(ro).Cells(8).Value
                    w廃止日 = Me.DataGridView1.Rows(ro).Cells(8).Value
                Else
                    Me.MaskedTextBox廃止予定日.Text = ""
                    w廃止日 = ""
                End If

                If IsDate(Me.DataGridView1.Rows(ro).Cells(9).Value, "yyyy/mm/dd") Then
                    Me.MaskedTextBox廃止日.Text = Me.DataGridView1.Rows(ro).Cells(9).Value
                Else
                    Me.MaskedTextBox廃止日.Text = ""
                End If

                SetComboBox(ComboBox在庫種類, Me.DataGridView1.Rows(ro).Cells(10).Value)

                Me.TextBox販売価格.Text = Me.DataGridView1.Rows(ro).Cells(11).Value

                SetComboBox(Me.ComboBox製品, Me.DataGridView1.Rows(ro).Cells(12).Value)   '製品フラグ

                Me.TextBox原価.Text = Me.DataGridView1.Rows(ro).Cells(13).Value
                Me.TextBox保有年.Text = Me.DataGridView1.Rows(ro).Cells(14).Value

                Me.TextBox相手先品番.Text = Me.DataGridView1.Rows(ro).Cells(15).Value
                '//
                If Me.DataGridView1.Rows(ro).Cells(16).Value = "1" Then
                    Me.CheckBoxショップ登録用部品.Checked = True
                Else
                    Me.CheckBoxショップ登録用部品.Checked = False
                End If

                If Me.DataGridView1.Rows(ro).Cells(17).Value = "1" Then
                    Me.CheckBox部品スペック.Checked = True
                Else
                    Me.CheckBox部品スペック.Checked = False
                End If


                '//
                Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(18).Value

                Me.TextBox現在庫.Text = Get_genzaiko(Me.TextBox品コード.Text.Trim)
                Me.TextBox注文残.Text = Get_tyuuzan(Me.TextBox品コード.Text.Trim)
                Me.TextBox納入数.Text = Get_nounyusu(Me.TextBox品コード.Text.Trim)

                If Me.DataGridView1.Rows(ro).Cells(20).Value = "" Then
                    Me.NumericUpDown単位.Value = 0
                Else
                    Me.NumericUpDown単位.Value = Me.DataGridView1.Rows(ro).Cells(20).Value
                End If

                If Me.DataGridView1.Rows(ro).Cells(21).Value = "1" Then
                    Me.CheckBox個別.Checked = True
                Else
                    Me.CheckBox個別.Checked = False
                End If
            Else
                Clear("")

            End If
            'MessageBox.Show(a)
        End If
    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String

        strSQL = "DELETE FROM " & schema & "m_seihin WHERE sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "DELETE FROM " & schema & "t_buhin_spec WHERE sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "DELETE FROM " & schema & "t_parts_center WHERE sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
        ClassPostgeDB.EXEC(strSQL)

        MessageBox.Show("削除しました")
        Clear("")

        If zenkaiSQL <> "" Then
            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
        End If

    End Sub

    Private Sub FormMstSeihin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL

        Me.StartPosition = FormStartPosition.CenterScreen

        strSQL = "SELECT  naiyou FROM " & schema & "m_system where kbn='2' order by seq"
        ClassPostgeDB.SetComboBox(Me.ComboBox倉庫, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='11' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBoxメーカー, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='12' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox製品, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='14' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBoxガス種, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='6' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox得意先コード, strSQL)


        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='9' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBoxカテゴリ, strSQL)

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='20' order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBox在庫種類, strSQL)

        Me.DataGridView1.ReadOnly = True

        Clear("")

    End Sub

    Private Sub DateTimePicker廃止日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker廃止日.ValueChanged
        Me.MaskedTextBox廃止日.Text = Me.DateTimePicker廃止日.Value
    End Sub


    Private Sub DateTimePicker廃止予定日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker廃止予定日.ValueChanged

        Me.MaskedTextBox廃止予定日.Text = Me.DateTimePicker廃止予定日.Value

    End Sub

    Private Sub DateTimePickerAS供給停止日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerAS供給停止日.ValueChanged
        Me.MaskedTextBoxAS供給停止日.Text = Me.DateTimePickerAS供給停止日.Value
    End Sub



    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        Dim fileName As String
        GetIniFile()
        fileName = FileSave(MaserFolder)
        csvOutDataGred(Me.DataGridView1, fileName, 0, False)

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred(Me.DataGridView1, False)

    End Sub

    Private Sub CSVToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem1.Click

        'Dim fileName As String
        'GetIniFile()
        'fileName = Filesentaku(MaserFolder)
        'If fileName <> "" Then
        Dim FormInput As New FormSEIHINInput
        '  If fileName.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0 Then
        FormInput.UserID = UserID
        FormInput.UserName = UserName
        FormInput.Kengen = Kengen
        '       FormInput.FileName = fileName
        FormInput.ShowDialog()
        '    Else
        'MessageBox.Show("ＣＳＶではありません")
        'End If
        'End If

    End Sub

    Private Sub 出力ToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub
    '在庫更新
    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        'Dim fileName As String

        Dim FormZaikoInput As New FormZaikoInput

        FormZaikoInput.UserID = UserID
        FormZaikoInput.UserName = UserName
        FormZaikoInput.Kengen = Kengen
        'FormZaikoInput.FileName = fileName
        FormZaikoInput.ShowDialog()

    End Sub

    Private Sub ブランドからマージToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ブランドからマージToolStripMenuItem.Click
        Dim dt As DataTable
        Dim strSQL As String
        Dim ClassPostgeDB2 As New ClassPostgeDB2
        Dim rowloop As Integer
        Dim FormMeter As New FormMeter
        Dim tokusisaki_Cd As String


        If MessageBox.Show("ブランドシステムから品コードを移行しますか？",
                                             "品コードを移行確認",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2) = vbCancel Then
            Exit Sub
        End If

        tokusisaki_Cd = GetSystemMst("6", "3")

        strSQL = "SELECT  sinacd, seihinmei, cast(genka as integer) genka,kijunzaiko, cast(hanbai as integer) hanbai, hoyunen,entry_day, entry_sya,update_day FROM " & schema2 & "m_seihin"
        dt = ClassPostgeDB2.SetTable(strSQL)

        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        For rowloop = 0 To dt.Rows.Count - 1
            strSQL = "Delete from " & schema & "m_seihin where sinacd ='" & dt.Rows(rowloop).Item("sinacd").ToString & "'"
            ClassPostgeDB.EXEC(strSQL)

            strSQL = "INSERT INTO " & schema & "m_seihin (sinacd, seihinmei, makerkbn,   entry_day, entry_sya,"
            strSQL &= "kijunzaiko, update_day, hanbai, hoyunen, genka, tokuisakicd) VALUES("
            strSQL &= "'" & dt.Rows(rowloop).Item("sinacd").ToString & "'"
            strSQL &= ",'" & dt.Rows(rowloop).Item("seihinmei").ToString & "'"
            strSQL &= ",'2'"
            strSQL &= ",'" & IsDate3(dt.Rows(rowloop).Item("entry_day").ToString) & "'"
            strSQL &= ",'" & dt.Rows(rowloop).Item("entry_sya").ToString & "'"
            strSQL &= ",'" & IsDecimal2(dt.Rows(rowloop).Item("kijunzaiko").ToString) & "'"
            strSQL &= ",'" & IsDate3(dt.Rows(rowloop).Item("update_day").ToString) & "'"
            strSQL &= ",'" & IsDecimal2(dt.Rows(rowloop).Item("hanbai").ToString) & "'"
            strSQL &= ",'" & IsDecimal2(dt.Rows(rowloop).Item("hoyunen").ToString) & "'"
            strSQL &= ",'" & IsDecimal2(dt.Rows(rowloop).Item("genka").ToString) & "'"
            strSQL &= ",'" & tokusisaki_Cd & "')"
            ClassPostgeDB.EXEC(strSQL)

            FormMeter.GEN = rowloop
            FormMeter.Disp()
        Next

        FormMeter.CLos()



    End Sub


    Private Sub CheckBox個別_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox個別.CheckedChanged
        If Me.CheckBox個別.Checked Then
            Me.NumericUpDown単位.Value = 0
        End If
    End Sub

    Private Sub NumericUpDown単位_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown単位.ValueChanged
        If Me.NumericUpDown単位.Value > 0 Then
            Me.CheckBox個別.Checked = False
        End If
    End Sub

End Class