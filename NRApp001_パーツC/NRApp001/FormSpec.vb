Public Class FormSpec
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String

    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    '--- 23.12.07 k.s start ---
    Dim UpLoadFileName1 As String        'アップロードファイル名1（パス付き）
    Dim UpLoadFileName2 As String        'アップロードファイル名2（パス付き）
    '--- 23.12.07 k.s end ---
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
    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String
        'Dim dtBuff2 As DataTable

        strSQL = "SELECT sinacd, syouhinmei, yohinsetumei, toriatukai, inyou_moto, oteire, oteire_inyou_moto, doujikoukanbuhin, oem,categori,categori2"
        'strSQL &= ",web_tourokumei,appealpoint,entry_day, entry_sya , update_day "
        '--- 23.12.07 k.s start ---
        strSQL &= ",web_tourokumei,appealpoint,filename01,filename02 ,tyokuhan, tyokuhanriyu   ,entry_day, entry_sya , update_day "
        '--- 23.12.07 k.s end ---


        strSQL &= " FROM " & schema & "t_buhin_spec where update_day is not null"

        If Cob.Text = "" Then Cob.Text = "一致"

        Select Case Cob.Text
            Case "一致"
                strSQL = strSQL & " and " & jy & "  = '" & txt.Text.Trim.ToString & "'"
            Case "一部"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "%'"
            Case "前方"
                strSQL = strSQL & " and " & jy & " like '" & txt.Text.Trim.ToString & "%'"
            Case "後方"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "'"
            Case Else
                MessageBox.Show("条件を選択してください")
                Exit Sub
        End Select
        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

    End Sub

    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)
        Clear("1")
    End Sub
    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        Call 検索(Me.ComboBoxJy2, "syouhinmei", Me.TextBox漢字名称)
        Clear("2")
    End Sub
    Private Sub Button検索３_Click(sender As Object, e As EventArgs) Handles Button検索３.Click
        Call 検索(Me.ComboBoxJy3, "web_tourokumei", Me.TextBoxWEB登録名)
        Clear("3")
    End Sub


    Private Sub Clear(sw As String)
        Select Case sw

            Case "1"
                'Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
            Case "2"
                Me.TextBox品コード.Text = ""
                'Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
            Case "3"
                'Me.TextBoxWEB登録名.Text = ""
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
            Case Else
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBoxWEB登録名.Text = ""
        End Select

        Me.TextBoxアピールポイント.Text = ""
        Me.TextBox商品説明.Text = ""
        Me.TextBox取り扱い説明.Text = ""
        Me.TextBox引用元.Text = ""
        Me.TextBoxお手入れ方法.Text = ""
        Me.TextBox引用元2.Text = ""
        Me.TextBox同時交換部品.Text = ""
        Me.TextBoxＯＥＭ品番.Text = ""

        Me.ComboBoxカテゴリ.SelectedIndex = -1
        Me.ComboBoxカテゴリ2.SelectedIndex = -1

        Me.TextBox更新日.Text = ""

        '--- 23.12.07 k.s start ---
        Me.TextBoxファイル名1.Text = ""
        Me.TextBoxファイル名2.Text = ""
        UpLoadFileName1 = ""
        UpLoadFileName2 = ""
        '--- 23.12.07 k.s end ---
        Me.ComboBox直売可否.SelectedIndex = -1
        Me.TextBox直売可否.Text = ""
    End Sub



    Private Sub FormSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Me.StartPosition = FormStartPosition.CenterScreen

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='9' order by  bikou "
        ClassPostgeDB.SetComboBox(Me.ComboBoxカテゴリ, strSQL)
        Me.DataGridView1.ReadOnly = True

        Me.ComboBox直売可否.Items.Clear()
        Me.ComboBox直売可否.Items.Add("")
        Me.ComboBox直売可否.Items.Add("可")
        Me.ComboBox直売可否.Items.Add("否")
        Me.TextBox直売可否.Text = ""

    End Sub
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button品コード検索_Click(sender As Object, e As EventArgs) Handles Button品コード検索.Click
        ' Dim Fm As New FormSelectSeihin
        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text
        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox漢字名称.Text = FormSelectSeihin.SeihinName
        End If
        FormSelectSeihin.Dispose()
    End Sub
    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim strSQL_t_parts_center As String
        Dim strSQL_m_seihin As String
        Dim Ret
        'MessageBox.Show(TextBoxWEB販売終了日.Text)

        '--- 23.12.07 k.s start ---
        'アップロードファイルチェック
        If FileChk(1) = False Then
            Exit Sub
        End If
        If FileChk(2) = False Then
            Exit Sub
        End If
        '--- 23.12.07 k.s end ---

        If Me.TextBox品コード.Text.Trim <> "" Then
            If ChkSinaCd(Me.TextBox品コード.Text.Trim) Then

                strSQL = "select update_day from " & schema & "t_buhin_spec where sinacd ='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                Ret = ClassPostgeDB.DbSel(strSQL)
                If Ret = "" Then
                    '--- 23.12.07 k.s start ---
                    'strSQL = "INSERT INTO " & schema & "t_buhin_spec (sinacd, syouhinmei, yohinsetumei, toriatukai, inyou_moto, oteire, oteire_inyou_moto, doujikoukanbuhin, oem,categori,categori2, web_tourokumei,appealpoint,entry_day, entry_sya,update_day) VALUES("
                    strSQL = "INSERT INTO " & schema & "t_buhin_spec (sinacd, syouhinmei, yohinsetumei, toriatukai, inyou_moto, oteire, oteire_inyou_moto, doujikoukanbuhin, oem,categori,categori2, web_tourokumei, appealpoint, filename01, filename02, entry_day, entry_sya, update_day,tyokuhan,tyokuhanriyu) VALUES("
                    '--- 23.12.07 k.s end ---
                    strSQL &= " '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBox漢字名称.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Notcrlf(Me.TextBox商品説明.Text.TrimEnd.ToString) & "'"
                    strSQL &= ",'" & Notcrlf(Me.TextBox取り扱い説明.Text.TrimEnd.ToString) & "'"
                    strSQL &= ",'" & Notcrlf(Me.TextBox引用元.Text.TrimEnd.ToString) & "'"
                    strSQL &= ",'" & Notcrlf(Me.TextBoxお手入れ方法.Text.TrimEnd.ToString) & "'"
                    strSQL &= ",'" & Notcrlf(Me.TextBox引用元2.Text.TrimEnd.ToString) & "'"
                    strSQL &= ",'" & Me.TextBox同時交換部品.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBoxＯＥＭ品番.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.ComboBoxカテゴリ2.Text.TrimEnd.ToString & "'"

                    strSQL &= ",'" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBoxアピールポイント.Text.TrimEnd.ToString & "'"
                    '--- 23.12.07 k.s start ---
                    strSQL &= ",'" & Me.TextBoxファイル名1.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBoxファイル名2.Text.TrimEnd.ToString & "'"
                    '--- 23.12.07 k.s end ---

                    strSQL &= ",now()”
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",now()”
                    strSQL &= ",'" & Me.ComboBox直売可否.Text & "'"
                    strSQL &= ",'" & Me.TextBox直売可否.Text & "'"

                    strSQL &= ")"
                    strSQL_t_parts_center = ""
                    strSQL_m_seihin = ""
                Else
                    If Me.TextBox更新日.Text = Ret Then

                        strSQL = "UPDATE " & schema & "t_buhin_spec SET "
                        strSQL &= "syouhinmei='" & Me.TextBox漢字名称.Text.TrimEnd.ToString & "'"
                        strSQL &= ", yohinsetumei = '" & Notcrlf(Me.TextBox商品説明.Text.TrimEnd.ToString) & "'"
                        strSQL &= ", toriatukai = '" & Notcrlf(Me.TextBox取り扱い説明.Text.TrimEnd.ToString) & "'"
                        strSQL &= ", inyou_moto = '" & Notcrlf(Me.TextBox引用元.Text.TrimEnd.ToString) & "'"
                        strSQL &= ", oteire = '" & Notcrlf(Me.TextBoxお手入れ方法.Text.TrimEnd.ToString) & "'"
                        strSQL &= ", oteire_inyou_moto = '" & Notcrlf(Me.TextBox引用元2.Text.TrimEnd.ToString) & "'"
                        strSQL &= ", doujikoukanbuhin = '" & Me.TextBox同時交換部品.Text.TrimEnd.ToString & "'"
                        strSQL &= ", oem = '" & Me.TextBoxＯＥＭ品番.Text.TrimEnd.ToString & "'"
                        strSQL &= ", categori = '" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                        strSQL &= ", categori2 ='" & Me.ComboBoxカテゴリ2.Text.TrimEnd.ToString & "'"

                        strSQL &= ",web_tourokumei='" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"
                        strSQL &= ",appealpoint='" & Me.TextBoxアピールポイント.Text.TrimEnd.ToString & "'"
                        '--- 23.12.07 k.s start ---
                        strSQL &= ", filename01 = '" & Me.TextBoxファイル名1.Text.TrimEnd.ToString & "'"
                        strSQL &= ", filename02 = '" & Me.TextBoxファイル名2.Text.TrimEnd.ToString & "'"
                        '--- 23.12.07 k.s end ---

                        strSQL &= ",tyokuhan = '" & Me.ComboBox直売可否.Text & "'"
                        strSQL &= ", tyokuhanriyu = '" & Me.TextBox直売可否.Text & "'"


                        '------
                        strSQL &= ", update_day=now()”
                        strSQL &= ", entry_sya='" & UserName & "'"
                        strSQL &= " WHERE sinacd='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"

                        strSQL_t_parts_center = "UPDATE " & schema & "t_parts_center SET "
                        strSQL_t_parts_center &= " s_categori = '" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                        strSQL_t_parts_center &= ",s_categori2 = '" & Me.ComboBoxカテゴリ2.Text.TrimEnd.ToString & "'"
                        strSQL_t_parts_center &= ",s_web_tourokumei = '" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"

                        strSQL_t_parts_center &= ", update_day = now() "
                        strSQL_t_parts_center &= ", entry_sya = '" & UserName & "'"
                        strSQL_t_parts_center &= " where sinacd = '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"


                        strSQL_m_seihin = "UPDATE " & schema & "m_seihin SET "
                        strSQL_m_seihin &= " categori = '" & Me.ComboBoxカテゴリ.Text.TrimEnd.ToString & "'"
                        strSQL_m_seihin &= ", aitesakihinban = '" & Me.TextBoxＯＥＭ品番.Text.TrimEnd.ToString & "'"
                        strSQL_m_seihin &= ", web_tourokumei = '" & Me.TextBoxWEB登録名.Text.TrimEnd.ToString & "'"
                        strSQL_m_seihin &= ", update_day = now() "
                        strSQL_m_seihin &= ", entry_sya = '" & UserName & "'"

                        strSQL_m_seihin &= " where sinacd = '" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"


                    Else
                        MessageBox.Show("データが更新されています。再検索してください")
                        Exit Sub
                    End If
                End If

                If ClassPostgeDB.EXEC(strSQL) Then
                    If ClassPostgeDB.EXEC(strSQL_t_parts_center) Then
                        If ClassPostgeDB.EXEC(strSQL_m_seihin) Then
                            MessageBox.Show("更新しました")

                            '--- 23.12.07 k.s start ---
                            'ファイルアップロード
                            Call FtpUpload()
                            '--- 23.12.07 k.s end ---


                            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                            strSQL = "select update_day from " & schema & "t_buhin_spec where sinacd ='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
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

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        'Dim dt As DataTable
        Dim ro
        Dim strSQL As String
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox漢字名称.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBox商品説明.Text = Oncrlf(Me.DataGridView1.Rows(ro).Cells(2).Value)
                Me.TextBox取り扱い説明.Text = Oncrlf(Me.DataGridView1.Rows(ro).Cells(3).Value)
                Me.TextBox引用元.Text = Oncrlf(Me.DataGridView1.Rows(ro).Cells(4).Value)
                Me.TextBoxお手入れ方法.Text = Oncrlf(Me.DataGridView1.Rows(ro).Cells(5).Value)
                Me.TextBox引用元2.Text = Oncrlf(Me.DataGridView1.Rows(ro).Cells(6).Value)
                Me.TextBox同時交換部品.Text = Me.DataGridView1.Rows(ro).Cells(7).Value
                Me.TextBoxＯＥＭ品番.Text = Me.DataGridView1.Rows(ro).Cells(8).Value
                SetComboBox(Me.ComboBoxカテゴリ, Me.DataGridView1.Rows(ro).Cells(9).Value)


                strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='19' and seq like '" & GetKry(Me.ComboBoxカテゴリ.Text) & "%'  order by  seq "
                ClassPostgeDB.SetComboBox(Me.ComboBoxカテゴリ2, strSQL)
                SetComboBox(Me.ComboBoxカテゴリ2, Me.DataGridView1.Rows(ro).Cells(10).Value)

                'Me.ComboBoxカテゴリ.Text = Me.DataGridView1.Rows(ro).Cells(9).Value

                Me.TextBoxWEB登録名.Text = Me.DataGridView1.Rows(ro).Cells(11).Value
                Me.TextBoxアピールポイント.Text = Me.DataGridView1.Rows(ro).Cells(12).Value

                '--- 23.12.07 k.s start ---
                'Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(15).Value
                Me.TextBoxファイル名1.Text = Me.DataGridView1.Rows(ro).Cells(13).Value
                Me.TextBoxファイル名2.Text = Me.DataGridView1.Rows(ro).Cells(14).Value

                Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(19).Value
                '--- 23.12.07 k.s start ---

                SetComboBox(Me.ComboBox直売可否, Me.DataGridView1.Rows(ro).Cells(15).Value)
                Me.TextBox直売可否.Text = Me.DataGridView1.Rows(ro).Cells(16).Value

                'strSQL = "SELECT tyokuhan,tyokuhanriyu FROM " & schema & "'t_buhin_spec where  sinacd='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                'dt = ClassPostgeDB.SetTable(strSQL)
                'If dt.Rows.Count > 0 Then
                'SetComboBox(Me.ComboBox直売可否, dt.Rows(0).Item(0).ToString)
                'Me.TextBox直売可否.Text = dt.Rows(0).Item(1).ToString
                'End If

            Else
                Clear("")

            End If
        End If
    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String

        strSQL = "DELETE from " & schema & "t_buhin_spec ”
        strSQL &= " WHERE sinacd='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
        If ClassPostgeDB.EXEC(strSQL) Then
            MessageBox.Show("削除しました")

            '--- 23.12.07 k.s start ---
            'FTPファイル削除
            Call FtpDelete()
            Me.TextBoxファイル名1.Text = ""
            Me.TextBoxファイル名2.Text = ""
            UpLoadFileName1 = ""
            UpLoadFileName2 = ""

            Me.TextBoxWEB登録名.Text = ""
            Me.TextBoxアピールポイント.Text = ""
            '--- 23.12.07 k.s start ---

            Me.TextBox品コード.Text = ""
            Me.TextBox漢字名称.Text = ""
            Me.TextBox商品説明.Text = ""
            Me.TextBox取り扱い説明.Text = ""
            Me.TextBox引用元.Text = ""
            Me.TextBoxお手入れ方法.Text = ""
            Me.TextBox引用元2.Text = ""
            Me.TextBox同時交換部品.Text = ""
            Me.TextBoxＯＥＭ品番.Text = ""

            Me.ComboBoxカテゴリ.Text = ""
            Me.ComboBoxカテゴリ2.Text = ""
            Me.TextBox更新日.Text = ""

            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

        End If

    End Sub
    Private Sub TextBox品コード_Enter(sender As Object, e As EventArgs) Handles TextBox品コード.Enter
        Dim strSQL As String
        Dim meisyou As String

        strSQL = "select ms.seihinmei from " & schema & "m_seihin ms where ms.sinacd = '" & Me.TextBox品コード.Text.Trim.ToString & "'"
        meisyou = ClassPostgeDB.DbSel(strSQL)

        If Me.TextBox漢字名称.Text = "" Then
            Me.TextBox漢字名称.Text = meisyou
        Else
            If Me.TextBox漢字名称.Text <> meisyou Then
                MessageBox.Show("マスタ名称と相異します")
            End If
        End If
    End Sub

    Private Sub TextBox漢字名称_Leave(sender As Object, e As EventArgs) Handles TextBox漢字名称.Leave

        Dim strSQL As String
        Dim meisyou As String

        If Me.TextBox漢字名称.Text <> "" Then
            strSQL = "select ms.seihinmei from " & schema & "m_seihin ms where ms.sinacd = '" & Me.TextBox品コード.Text.Trim.ToString & "'"
            meisyou = ClassPostgeDB.DbSel(strSQL)
            If Me.TextBox漢字名称.Text <> meisyou Then
                MessageBox.Show("マスタ名称と相異します")
            End If
        End If


    End Sub


    Private Sub ComboBoxカテゴリ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxカテゴリ.SelectedIndexChanged

        Dim strSQL As String
        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='19' and seq like '" & GetKry(Me.ComboBoxカテゴリ.Text) & "%'  order by  seq "
        ClassPostgeDB.SetComboBox(Me.ComboBoxカテゴリ2, strSQL)

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred(Me.DataGridView1, True)
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        Dim fileName As String
        GetIniFile()
        fileName = FileSave(MaserFolder)
        csvOutDataGred(Me.DataGridView1, fileName, 0, True)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub FormSpec_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "10") Then

        End If

    End Sub

    '--- 23.12.07 k.s start ---
    'FTPでアップロード・ダウンロード
    Private Sub ButtonファイルUP1選択_Click(sender As Object, e As EventArgs) Handles ButtonファイルUP1選択.Click
        Dim strExte As String    '拡張子
        Dim strFile As String    '選択したファイル

        'ファイル選択
        strFile = Filesentaku(MaserFolder)
        If strFile.Trim <> "" Then
            'パス付ファイル名をセットする
            UpLoadFileName1 = strFile.Trim
            'ファイル名のみTextBoxへ
            Me.TextBoxファイル名1.Text = System.IO.Path.GetFileName(UpLoadFileName1)
        End If

        '選択ファイルのチェック
        If Me.TextBoxファイル名1.Text.Trim <> "" Then
            strExte = System.IO.Path.GetExtension(Me.TextBoxファイル名1.Text)
            Select Case strExte.ToUpper.Substring(0, 2)
                Case ".X", ".P", ".D"
                Case Else
                    MessageBox.Show("アップロード出来るファイルはEXCEL、WORD、PDFのみです")
                    UpLoadFileName1 = ""
            End Select
        End If
        If FileChk(1) = False Then
            UpLoadFileName1 = ""
            Me.TextBoxファイル名1.Text = ""
        End If
    End Sub

    Private Sub ButtonファイルUP2選択_Click(sender As Object, e As EventArgs) Handles ButtonファイルUP2選択.Click
        Dim strExte As String    '拡張子
        Dim strFile As String    '選択したファイル

        'ファイル選択
        strFile = Filesentaku(MaserFolder)
        If strFile.Trim <> "" Then
            'パス付ファイル名をセットする
            UpLoadFileName2 = strFile.Trim
            'ファイル名のみTextBoxへ
            Me.TextBoxファイル名2.Text = System.IO.Path.GetFileName(UpLoadFileName2)
        End If

        '選択ファイルのチェック
        If Me.TextBoxファイル名2.Text.Trim <> "" Then
            strExte = System.IO.Path.GetExtension(Me.TextBoxファイル名2.Text)
            Select Case strExte.ToUpper.Substring(0, 2)
                Case ".X", ".P", ".D"
                Case Else
                    MessageBox.Show("アップロード出来るファイルはEXCEL、WORD、PDFのみです")
                    UpLoadFileName2 = ""
            End Select
        End If
        If FileChk(2) = False Then
            Me.TextBoxファイル名2.Text = ""
        End If
    End Sub

    Private Sub TextBoxファイル名1_DoubleClick(sender As Object, e As EventArgs)
        Call FtpDownLoadOpen(Me.TextBoxファイル名1.Text.Trim, "_01")
    End Sub

    Private Sub TextBoxファイル名2_DoubleClick(sender As Object, e As EventArgs)
        Call FtpDownLoadOpen(Me.TextBoxファイル名2.Text.Trim, "_02")
    End Sub

    Public Function FileChk(sw As Integer) As Boolean
        Dim strExte As String    '拡張子
        Dim strSize As String    'ファイルサイズ

        FileChk = True

        'ファイルサイズ取得
        strSize = Replace(GetSystemMst("24", "1"), "M", "")

        If strSize = Nothing Then
            MessageBox.Show("マスタにファイルサイズが設定されていません（区分：24）")
            FileChk = False
            Exit Function
        ElseIf strSize.Trim = "" Then
            MessageBox.Show("マスタにファイルサイズが設定されていません（区分：24）")
            FileChk = False
            Exit Function
        End If

        If sw = 1 Then

            'ファイル(1)チェック
            If Me.TextBoxファイル名1.Text.Trim <> "" Then
                If Me.TextBoxファイル名1.Text.Trim <> Me.DataGridView1.Rows(0).Cells(13).Value.trim And UpLoadFileName1.Trim = "" Then
                    MessageBox.Show("アップロードするファイル（１）をもう一度選択しなおしてください")
                    FileChk = False
                ElseIf Me.TextBoxファイル名1.Text.Trim <> "" And UpLoadFileName1.Trim <> "" Then
                    If Me.TextBoxファイル名1.Text.Trim <> System.IO.Path.GetFileName(UpLoadFileName1) Then
                        MessageBox.Show("アップロードするファイル（１）をもう一度選択しなおしてください")
                        FileChk = False
                    Else
                        strExte = System.IO.Path.GetExtension(UpLoadFileName1.Trim)
                        Select Case strExte.ToUpper.Substring(0, 2)
                            Case ".X", ".P", ".D"
                                Dim Fi1 As New System.IO.FileInfo(UpLoadFileName1.Trim)
                                Dim Le1 As Long = Fi1.Length
                                If Le1 > CLng(strSize.Trim) * 1000000 Then
                                    MessageBox.Show("アップロードファイルサイズオーバー：ファイル（１）")
                                    FileChk = False
                                End If
                            Case Else
                                MessageBox.Show("アップロード出来るファイルはEXCEL、WORD、PDFのみです")
                                FileChk = False
                        End Select
                    End If
                End If
            End If
        End If
        If sw = 2 Then
            'ファイル(2)チェック
            If Me.TextBoxファイル名2.Text.Trim <> "" Then
                If Me.TextBoxファイル名2.Text.Trim <> Me.DataGridView1.Rows(0).Cells(14).Value.trim And UpLoadFileName2.Trim = "" Then
                    MessageBox.Show("アップロードするファイル（２）をもう一度選択しなおしてください")
                    FileChk = False

                ElseIf Me.TextBoxファイル名2.Text.Trim <> "" And UpLoadFileName2.Trim <> "" Then
                    If Me.TextBoxファイル名2.Text.Trim <> System.IO.Path.GetFileName(UpLoadFileName2) Then
                        MessageBox.Show("アップロードするファイル（２）をもう一度選択しなおしてください")
                        FileChk = False
                    Else
                        strExte = System.IO.Path.GetExtension(UpLoadFileName2.Trim)
                        Select Case strExte.ToUpper.Substring(0, 2)
                            Case ".X", ".P", ".D"
                                Dim Fi2 As New System.IO.FileInfo(UpLoadFileName2.Trim)
                                Dim Le2 As Long = Fi2.Length
                                If Le2 > CLng(strSize.Trim) * 1000000 Then
                                    MessageBox.Show("アップロードファイルサイズオーバー：ファイル（２）")
                                    FileChk = False
                                End If
                            Case Else
                                MessageBox.Show("アップロード出来るファイルはEXCEL、WORD、PDFのみです")
                                FileChk = False
                        End Select
                    End If
                End If
            End If
        End If
    End Function
    Private Sub FtpUpload()
        Dim strSQL As String
        Dim ClassFTP As New ClassFTP

        ClassFTP.msg = ""

        'ファイル(1)アップロード
        If ClassFTP.msg = "" And Me.TextBoxファイル名1.Text.Trim <> "" And UpLoadFileName1.Trim <> "" Then
            'アップロード
            ClassFTP.Send(TextBox品コード.Text.Trim & "_01", UpLoadFileName1)
            If ClassFTP.msg <> "" Then
                MessageBox.Show("FTP UpLoad Error（ファイル名1）")

                'FTPエラーになった時、DBのファイル1をクリアー
                strSQL = "UPDATE " & schema & "t_buhin_spec SET "
                strSQL &= " filename01 = ''"
                strSQL &= ", update_day=now()”
                strSQL &= ", entry_sya='" & UserName & "'"
                strSQL &= " WHERE sinacd='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                If ClassPostgeDB.EXEC(strSQL) Then
                    MessageBox.Show("FTP UpLoad Error ＤＢよりファイル名1がクリアーされました")
                Else
                    MessageBox.Show("FTP UpLoad Error（ファイル名1 更新エラー）")
                End If
            Else
                UpLoadFileName1 = ""
                MessageBox.Show("アップロードしました")
            End If
        Else
            If Me.TextBoxファイル名1.Text.Trim = "" Then
                ClassFTP.Send4(TextBox品コード.Text & "_01")
            End If
        End If

        'ファイル(2)アップロード
        If ClassFTP.msg = "" And Me.TextBoxファイル名2.Text.Trim <> "" And UpLoadFileName2.Trim <> "" Then
            'アップロード
            ClassFTP.Send(TextBox品コード.Text.Trim & "_02", UpLoadFileName2)
            If ClassFTP.msg <> "" Then
                MessageBox.Show("FTP UpLoad Error（ファイル名2）")

                'FTPエラーになった時、DBのファイル2をクリアー
                strSQL = "UPDATE " & schema & "t_buhin_spec SET "
                strSQL &= " filename02 = ''"
                strSQL &= ", update_day=now()”
                strSQL &= ", entry_sya='" & UserName & "'"
                strSQL &= " WHERE sinacd='" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                If ClassPostgeDB.EXEC(strSQL) Then
                    MessageBox.Show("FTP UpLoad Error ＤＢよりファイル名2がクリアーされました")
                Else
                    MessageBox.Show("FTP UpLoad Error（ファイル名2 更新エラー）")
                End If
            Else
                UpLoadFileName2 = ""
                MessageBox.Show("アップロードしました")
            End If
        Else
            If Me.TextBoxファイル名1.Text.Trim = "" Then
                ClassFTP.Send4(TextBox品コード.Text & "_02")
            End If
        End If
    End Sub

    Private Sub FtpDownLoadOpen(filename As String, fileNo As String)
        Dim strExte As String     '拡張子
        Dim strPath As String     'パス

        'ダウンロード先
        strPath = System.IO.Path.GetTempPath()

        If filename <> "" Then
            'ダウンロード
            Dim ClassFTP As New ClassFTP
            ClassFTP.Send3(TextBox品コード.Text.Trim.ToString & fileNo, strPath & filename)
            If ClassFTP.msg <> "" Then
                MessageBox.Show("FTP DownLoad Error")
                Exit Sub
            End If

            'ダウンロードファイルのオープン
            strExte = System.IO.Path.GetExtension(filename)

            Select Case strExte.ToUpper.Substring(0, 2)
                Case ".X"
                    Call OpenExcel(strPath & filename)
                Case ".P"
                    Call OpenProcess(strPath & filename)
                Case ".D"
                    Call OpenProcess(strPath & filename)
            End Select
        Else
            Exit Sub
        End If
    End Sub

    Private Sub FtpDelete()
        Dim ClassFTP As New ClassFTP

        ClassFTP.msg = ""

        'ファイル(1)削除
        If ClassFTP.msg = "" And Me.TextBoxファイル名1.Text.Trim <> "" Then
            'サーバー上のファイルの削除
            ClassFTP.Send4(TextBox品コード.Text.Trim & "_01")
            If ClassFTP.msg <> "" Then
                MessageBox.Show("ファイル名1　FTP Delete Error(更新エラー）")
            End If
        End If

        'ファイル(2)削除
        If ClassFTP.msg = "" And Me.TextBoxファイル名2.Text.Trim <> "" Then
            'サーバー上のファイルの削除
            ClassFTP.Send4(TextBox品コード.Text.Trim & "_02")
            If ClassFTP.msg <> "" Then
                MessageBox.Show("ファイル名2　FTP Delete Error（更新エラーです）")
            End If
        End If

    End Sub

    '--- 23.12.07 k.s end ---
End Class