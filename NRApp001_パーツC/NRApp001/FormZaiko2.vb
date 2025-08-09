Public Class FormZaiko2
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
    Private Sub FormZaiko2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If Kengen = "2" Then
            'Me.TextBox品コード.ReadOnly = True
            'Me.TextBox商品名.ReadOnly = True

            Me.DateTimePicker日付.Visible = False
            Me.DateTimePicker入庫予定.Visible = False
            Me.TextBox受注数.ReadOnly = True
            Me.TextBox日付.ReadOnly = True
            Me.MaskedTextBox入庫予定.ReadOnly = True
            Me.TextBox備考.ReadOnly = True
            Me.在庫出力ToolStripMenuItem.Visible = False
            Me.Button削除.Visible = False
            Me.TextBoxWEB登録日1.ReadOnly = True
            Me.TextBoxWEB登録日2.Visible = True
            Me.DateTimePickeWEB登録日1.Visible = False
            Me.DateTimePickeWEB登録日2.Visible = False
            Me.Button検索4.Visible = False
        End If
    End Sub


    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String

        If Me.TextBoxSEQ.Text <> "" Then
            strSQL = "UPDATE " & schema & "t_zaiko SET update_day = null Where update_day Is Not null"
            strSQL &= " and  seq= '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("削除しました")
                Clear("")
                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Else
                MessageBox.Show("更新エラーです")
            End If
        End If
    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim Ret As String
        Dim nyukoflg As String
        Dim dt As DateTime
        Dim fastseq As String
        Dim zaikokousinflg As Integer
        Dim zaiko As String
        Dim ZaikokanriFLG As String



        If Me.TextBox品コード.Text.Trim <> "" Then
            If ChkSinaCd(Me.TextBox品コード.Text.Trim) Then

                If Strings.Left(Me.MaskedTextBox入庫予定.Text, 1) <> " " Then
                    If DateTime.TryParse(Me.MaskedTextBox入庫予定.Text, dt) Then
                        '変換出来たら、dtにその値が入る
                        'MessageBox.Show("{0}はDateTime{1}に変換できます。")
                    Else
                        MessageBox.Show("入庫予定日が日付けではりません")
                        Exit Sub
                    End If
                End If

                If Strings.Left(Me.MaskedTextBox入庫日.Text, 1) <> " " Then
                    If DateTime.TryParse(Me.MaskedTextBox入庫日.Text, dt) Then
                        '変換出来たら、dtにその値が入る
                        'MessageBox.Show("{0}はDateTime{1}に変換できます。")
                    Else
                        MessageBox.Show("入庫日が日付けではりません")
                        Exit Sub
                    End If
                End If

                If IsNumeric(Me.TextBox受注数.Text.TrimEnd.ToString) = True Then
                    zaiko = Me.TextBox受注数.Text.TrimEnd.ToString
                Else
                    zaiko = "0"
                End If

                If Strings.Left(Me.DateTimePickeWEB登録日1.Text, 1) <> " " Then
                    If DateTime.TryParse(Me.DateTimePickeWEB登録日1.Text, dt) Then
                        '変換出来たら、dtにその値が入る
                        'MessageBox.Show("{0}はDateTime{1}に変換できます。")
                    Else
                        MessageBox.Show("WEB登録日が日付けではりません")
                        Exit Sub
                    End If
                End If


                If Me.TextBoxSEQ.Text = "" Then

                    fastseq = ClassPostgeDB.DbSel("SELECT nextval('" & schema & "seqzaiko')")
                    Me.TextBoxSEQ.Text = fastseq

                Else
                    fastseq = Me.TextBoxSEQ.Text.Trim
                End If

                ZaikokanriFLG = Zaikokanri(Me.TextBox品コード.Text.TrimEnd.ToString)

                strSQL = "SELECT update_day from " & schema & "t_zaiko where seq ='" & fastseq & "'"
                Ret = ClassPostgeDB.DbSel(strSQL)
                If Ret = "" Then

                    strSQL = "INSERT INTO " & schema & "t_zaiko (orderno, hituke,  sinacd, syouhinmei"
                    strSQL &= ", goukei, nyuukoyoteibi, nyukobi, fsturokubi,nyuryokukakuninn, bikou, entry_day, update_day,entry_sya,seq) VALUES("

                    strSQL &= " '" & Me.TextBoxオーダーNo.Text.TrimEnd.ToString & "'"

                    If IsDate(Me.TextBox日付.Text, "yyyy/MM/dd") = True Then
                        strSQL &= ",'" & Me.TextBox日付.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    strSQL &= ",'" & Me.TextBox品コード.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBox商品名.Text.TrimEnd.ToString & "'"

                    strSQL &= ",'" & zaiko & "'"

                    If IsDate(Me.MaskedTextBox入庫予定.Text, "yyyy/MM/dd") = True Then
                        strSQL &= ",'" & Me.MaskedTextBox入庫予定.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If

                    If IsDate(Me.MaskedTextBox入庫日.Text, "yyyy/MM/dd") = True Then
                        strSQL &= ",'" & Me.MaskedTextBox入庫日.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If


                    If IsDate(Me.DateTimePickeWEB登録日1.Text, "yyyy/MM/dd") = True Then
                        strSQL &= ",'" & Me.DateTimePickeWEB登録日1.Text.ToString & "'"
                    Else
                        strSQL &= ",NULL"
                    End If


                    strSQL &= ",'" & Me.TextBox入力確認.Text.TrimEnd.ToString & "'"
                    strSQL &= ",'" & Me.TextBox備考.Text.TrimEnd.ToString & "'"

                    strSQL &= ",now()"
                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",'" & fastseq & "'"
                    strSQL &= ")"
                Else
                    If Me.TextBox更新日.Text = Ret Then
                        If Me.TextBox入庫フラグ.Text = "1" Then
                            nyukoflg = "1"
                            zaikokousinflg = 0
                        Else
                            If Me.TextBox入庫フラグ.Text = "" And IsDate(Me.MaskedTextBox入庫日.Text, "yyyy/MM/dd") = True Then
                                nyukoflg = "1"
                                zaikokousinflg = 1
                            Else
                                nyukoflg = ""
                                zaikokousinflg = 0
                            End If
                        End If

                        strSQL = "UPDATE " & schema & "t_zaiko set "
                        strSQL &= " update_day = now()"
                        strSQL &= ",entry_sya = '" & UserName & "'"

                        If kenken <> "2" Then

                            strSQL &= " ,orderno  = '" & Me.TextBoxオーダーNo.Text.TrimEnd.ToString & "'"

                            If Strings.Left(Me.TextBox日付.Text, 1) = " " Then
                                strSQL &= ",hituke= NULL"
                            Else
                                strSQL &= ",hituke='" & Me.TextBox日付.Text.ToString & "'"
                            End If
                            strSQL &= " ,syouhinmei = '" & Me.TextBox商品名.Text.TrimEnd.ToString & "'"
                            'If IsNumeric(Me.TextBoxR数.Text.TrimEnd.ToString) = True Then
                            'strSQL &= ",rsuu = '" & Me.TextBoxR数.Text.TrimEnd.ToString & "'"
                            'Else
                            '   strSQL &= ",rsuu = '0'"
                            'End If
                            strSQL &= ",goukei = '" & zaiko & "'"

                            If Strings.Left(Me.MaskedTextBox入庫予定.Text, 1) = " " Then
                                strSQL &= ",nyuukoyoteibi = NULL"
                            Else
                                strSQL &= ",nyuukoyoteibi = '" & Me.MaskedTextBox入庫予定.Text.ToString & "'"
                            End If

                            strSQL &= ", bikou = '" & Me.TextBox備考.Text.TrimEnd.ToString & "'"


                            If IsDate(Me.DateTimePickeWEB登録日1.Text, "yyyy/MM/dd") = True Then
                                strSQL &= ",fsturokubi ='" & Me.DateTimePickeWEB登録日1.Text.ToString & "'"
                            Else
                                strSQL &= ",fsturokubi = NULL"
                            End If


                        End If

                        If Strings.Left(Me.MaskedTextBox入庫日.Text, 1) = " " Then
                            strSQL &= ",nyukobi = NULL"
                        Else
                            strSQL &= ",nyukobi = '" & Me.MaskedTextBox入庫日.Text.ToString & "'"
                        End If

                        strSQL &= ",nyuryokukakuninn='" & Me.TextBox入力確認.Text.TrimEnd.ToString & "'"
                        strSQL &= ",nyukoflg='" & nyukoflg & "'"

                        strSQL &= " where "
                        strSQL &= " seq= '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"

                    Else
                        MessageBox.Show("データが更新されています。再検索してください")
                        Exit Sub
                    End If

                End If
                If ClassPostgeDB.EXEC(strSQL) Then
                    If zaikokousinflg = 1 Then
                        If ZaikokanriFLG = "1" Then
                            '現在庫更新
                            strSQL = "UPDATE " & schema & "t_genzaiko SET"
                            strSQL &= " tyuuzan = tyuuzan - " & zaiko
                            strSQL &= ", nouhinsu = nouhinsu + " & zaiko
                            strSQL &= " where sinacd = '" & Me.TextBox品コード.Text.Trim & "'"
                            ClassPostgeDB.EXEC(strSQL)
                        End If
                    End If

                    MessageBox.Show("更新しました")
                    ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

                    strSQL = "SELECT update_day from " & schema & "t_zaiko where seq ='" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
                    Me.TextBox更新日.Text = ClassPostgeDB.DbSel(strSQL)

                Else
                    MessageBox.Show("更新エラーです")
                End If
            End If
        End If
    End Sub

    '
    ' 1　= 在庫管理する
    '
    Private Function Zaikokanri(sinacd As String)
        Dim strSQL As String
        strSQL = "select ms2.naiyou2  from " & schema & "m_seihin ms ," & schema & "m_system ms2  where ms.sinacd  = '" & sinacd & "' and ms2.kbn ='20' and ms2.naiyou = ms.souko"

        Return ClassPostgeDB.DbSel(strSQL)

    End Function



    Private Sub Button一括処理_Click(sender As Object, e As EventArgs) Handles Button一括処理.Click
        Dim strSQL As String
        Dim bRet As Boolean
        Dim ZaikokanriFLG As String
        Dim rowloop As Integer

        If Not IsDate(Me.MaskedTextBox入庫日.Text, "yyyy/MM/dd") = True Then
            MessageBox.Show("入庫日が未入力です")
            Return
        End If
        If Me.TextBox入力確認.Text = "" Then
            MessageBox.Show("入力確認が未入力です")
            Return
        End If

        Dim FormMeter As New FormMeter
        FormMeter.MAX = Me.DataGridView1.Rows.Count
        rowloop = 0
        FormMeter.Show()

        Me.DataGridView1.ReadOnly = True

        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            bRet = CBool(dr.Cells(0).Value)

            If bRet Then
                If ChkSinaCd1(dr.Cells(0 + 1).Value) Then
                    ZaikokanriFLG = Zaikokanri(dr.Cells(0 + 1).Value)

                    strSQL = "UPDATE " & schema & "t_zaiko set "
                    strSQL &= " update_day = now()"
                    strSQL &= ",entry_sya = '" & UserName & "'"

                    If Strings.Left(Me.MaskedTextBox入庫日.Text, 1) = " " Then
                        strSQL &= ",nyukobi = NULL"
                    Else
                        strSQL &= ",nyukobi = '" & Me.MaskedTextBox入庫日.Text.ToString & "'"
                    End If

                    strSQL &= ", nyuryokukakuninn='" & Me.TextBox入力確認.Text.TrimEnd.ToString & "'"
                    strSQL &= ", nyukoflg = '1' "

                    strSQL &= " where "
                    strSQL &= " seq= '" & dr.Cells(14 + 1).Value & "'"

                    ClassPostgeDB.EXEC(strSQL)

                    If ZaikokanriFLG = "1" Then
                        '現在庫更新
                        strSQL = "UPDATE " & schema & "t_genzaiko SET"
                        'strSQL &= " jyutyuu = jyutyuu - " & hojyu
                        strSQL &= " tyuuzan = tyuuzan - " & dr.Cells(4 + 1).Value
                        strSQL &= ", nouhinsu = nouhinsu + " & dr.Cells(4 + 1).Value
                        strSQL &= " where sinacd = '" & dr.Cells(0 + 1).Value & "'"
                        ClassPostgeDB.EXEC(strSQL)
                    End If
                End If
            End If

            FormMeter.GEN = rowloop
            FormMeter.Disp()
            rowloop = rowloop + 1
        Next

        FormMeter.CLos()

        MessageBox.Show("更新完了")

        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

    End Sub

    Private Function 検索SQL()
        Dim strSQL As String

        strSQL = "SELECT 'false',sinacd, syouhinmei,orderno, to_char(hituke,'yyyy/mm/dd')"
        strSQL &= ", goukei , to_char(nyuukoyoteibi,'yyyy/mm/dd')"
        strSQL &= ",to_char(nyukobi,'yyyy/mm/dd'),to_char(fsturokubi,'yyyy/mm/dd'),  nyuryokukakuninn, bikou,update_day,entry_day,entry_sya,nyukoflg,seq"
        strSQL &= " FROM " & schema & "t_zaiko where update_day Is Not null"

        Select Case Me.ToolStripComboBox1.Text
            Case "全て"

            Case "未入庫"
                strSQL = strSQL & " and nyukobi is null"

            Case "入庫済"
                strSQL = strSQL & " and nyukobi is not null"

        End Select

        Return strSQL

    End Function




    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String

        strSQL = 検索SQL()

        If Cob.Text = "" Then Cob.Text = "一致"

        Select Case Cob.Text
            Case "一致"
                strSQL = strSQL & " And " & jy & "  = '" & txt.Text.Trim.ToString & "'"
            Case "一部"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "%'"
            Case "前方"
                strSQL = strSQL & " and " & jy & " like '" & txt.Text.Trim.ToString & "%'"
            Case "後方"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "'"
            Case "空白"
                strSQL = strSQL & " and " & jy & " is null"
            Case Else
                MessageBox.Show("条件を選択してください")
                Exit Sub
        End Select

        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

        If Me.ToolStripComboBox1.Text = "未入庫" Then
            Me.DataGridView1.ReadOnly = False
        Else
            Me.DataGridView1.ReadOnly = True
        End If

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
        If Me.ToolStripComboBox1.Text = "未入庫" Then
            Me.DataGridView1.ReadOnly = False
        Else
            Me.DataGridView1.ReadOnly = True
        End If


    End Sub



    Private Sub Button未入庫_Click(sender As Object, e As EventArgs) Handles Button未入庫.Click

        Dim strSQL As String

        Me.ToolStripComboBox1.Text = "未入庫"

        Clear("")
        strSQL = 検索SQL()
        strSQL &= " and nyukobi is null"

        zenkaiSQL = strSQL

        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        If Me.ToolStripComboBox1.Text = "未入庫" Then
            Me.DataGridView1.ReadOnly = False
        Else
            Me.DataGridView1.ReadOnly = True
        End If

    End Sub

    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)
        Clear("1")

    End Sub
    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        Call 検索(Me.ComboBoxJy2, "syouhinmei", Me.TextBox商品名)
        Clear("2")
    End Sub

    Private Sub Button検索３_Click(sender As Object, e As EventArgs) Handles Button検索３.Click
        Call 検索(Me.ComboBoxJy3, "orderno", Me.TextBoxオーダーNo)
        Clear("3")
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ButtonName_Click(sender As Object, e As EventArgs) Handles ButtonName.Click

        Me.TextBox入力確認.Text = UserName

    End Sub

    Private Sub Button品コード検索_Click(sender As Object, e As EventArgs) Handles Button品コード検索.Click

        ' Dim Fm As New FormSelectSeihin
        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text

        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            'MessageBox.Show(Fm.SeihinName)
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox商品名.Text = FormSelectSeihin.SeihinName
        End If
        FormSelectSeihin.Dispose()

    End Sub
    Private Sub Clear(sw As String)

        Select Case sw
            Case "1"
                'Me.TextBox品コード.Text = ""
                Me.TextBox商品名.Text = ""
                Me.TextBoxオーダーNo.Text = ""
            Case "2"
                Me.TextBox品コード.Text = ""
                'Me.TextBox商品名.Text = ""
                Me.TextBoxオーダーNo.Text = ""
            Case "3"
                Me.TextBox品コード.Text = ""
                Me.TextBox商品名.Text = ""
                'Me.TextBoxオーダーNo.Text = ""
            Case Else
                Me.TextBox品コード.Text = ""
                Me.TextBox商品名.Text = ""
                Me.TextBoxオーダーNo.Text = ""
        End Select

        Me.TextBox日付.Text = ""

        Me.MaskedTextBox入庫予定.Text = ""
        Me.MaskedTextBox入庫日.Text = ""
        Me.DateTimePickeWEB登録日1.Text = ""
        Me.TextBox入力確認.Text = ""
        Me.TextBox備考.Text = ""
        Me.TextBox更新日.Text = ""
        Me.TextBox入庫フラグ.Text = ""

        Me.TextBox現在庫.Text = ""
        Me.TextBox注文残.Text = ""
        Me.TextBox受注数.Text = ""
        Me.TextBoxSEQ.Text = ""
        Me.TextBox基準在庫.Text = ""

    End Sub


    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        Dim co
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            co = e.ColumnIndex

            If ro >= 0 Then
                If co > 0 Then

                    Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0 + 1).Value
                    Me.TextBox商品名.Text = Me.DataGridView1.Rows(ro).Cells(1 + 1).Value
                    Me.TextBoxオーダーNo.Text = Me.DataGridView1.Rows(ro).Cells(2 + 1).Value
                    Me.TextBox日付.Text = Me.DataGridView1.Rows(ro).Cells(3 + 1).Value
                    'Me.TextBoxR数.Text = Me.DataGridView1.Rows(ro).Cells(7).Value

                    Me.TextBox受注数.Text = Me.DataGridView1.Rows(ro).Cells(4 + 1).Value

                    Me.MaskedTextBox入庫予定.Text = Me.DataGridView1.Rows(ro).Cells(5 + 1).Value
                    Me.MaskedTextBox入庫日.Text = Me.DataGridView1.Rows(ro).Cells(6 + 1).Value
                    Me.DateTimePickeWEB登録日1.Text = Me.DataGridView1.Rows(ro).Cells(7 + 1).Value
                    'Me.MaskedTextBox楽天登録日.Text = Me.DataGridView1.Rows(ro).Cells(13).Value
                    Me.TextBox入力確認.Text = Me.DataGridView1.Rows(ro).Cells(8 + 1).Value
                    Me.TextBox備考.Text = Me.DataGridView1.Rows(ro).Cells(9 + 1).Value
                    Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(10 + 1).Value

                    Me.TextBox入庫フラグ.Text = Me.DataGridView1.Rows(ro).Cells(13 + 1).Value
                    Me.TextBoxSEQ.Text = Me.DataGridView1.Rows(ro).Cells(14 + 1).Value


                    Me.TextBox現在庫.Text = Get_genzaiko(Me.TextBox品コード.Text.Trim)
                    Me.TextBox注文残.Text = Get_tyuuzan(Me.TextBox品コード.Text.Trim)
                    'Me.TextBox受注数.Text = Get_jyutyusu(Me.TextBox品コード.Text.Trim)
                    Me.TextBox基準在庫.Text = Get_kijun(Me.TextBox品コード.Text.Trim)
                End If
            Else
                Clear("")
            End If
        End If

    End Sub

    Private Sub DateTimePicker日付_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker日付.ValueChanged
        Me.TextBox日付.Text = Me.DateTimePicker日付.Value

    End Sub

    Private Sub DateTimePicker入庫予定_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker入庫予定.ValueChanged
        Me.MaskedTextBox入庫予定.Text = Me.DateTimePicker入庫予定.Value
    End Sub

    Private Sub DateTimePicker入庫日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker入庫日.ValueChanged
        Me.MaskedTextBox入庫日.Text = Me.DateTimePicker入庫日.Value
    End Sub

    Private Sub DateTimePickerFS登録日_ValueChanged(sender As Object, e As EventArgs)
        Me.DateTimePickeWEB登録日1.Text = Me.DateTimePickeWEB登録日1.Value
    End Sub


    Private Sub FormZaiko2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        Me.ToolStripComboBox1.SelectedIndex = 0
        'Me.DataGridView1.ReadOnly = True

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred(Me.DataGridView1, False)
        MessageBox.Show("出力しました")
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        Dim fileName As String
        GetIniFile()
        fileName = FileSave(MaserFolder)
        csvOutDataGred(Me.DataGridView1, fileName, 0, False)
        MessageBox.Show("出力しました")

    End Sub


    Private Sub ALLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ALLToolStripMenuItem.Click
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

    Private Sub DateTimePickerWEB登録日1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickeWEB登録日1.ValueChanged
        Me.TextBoxWEB登録日1.Text = Me.DateTimePickeWEB登録日1.Value
    End Sub

    Private Sub DateTimePickerWEB登録日2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickeWEB登録日2.ValueChanged
        Me.TextBoxWEB登録日2.Text = Me.DateTimePickeWEB登録日2.Value

    End Sub

    Private Sub Button検索4_Click(sender As Object, e As EventArgs) Handles Button検索4.Click

        検索２("to_char(fsturokubi,'yyyy/mm/dd')", Me.TextBoxWEB登録日1.Text, Me.TextBoxWEB登録日2.Text)
    End Sub
    '在庫出力
    Private Function ECzaikoUpData() As DataTable

        Dim strSQL As String
        Dim dt = New DataTable

        strSQL = "Select  t_genzaiko.sinacd ""商品コード"",m_seihin.seihinmei ""商品名"",'0' ""バリエーション文字列"" , genzaiko + nouhinsu - tyuuzan ""在庫数"",'' ""入荷お知らせ受付フラグ"",'' ""予約商品フラグ"",'' ""予約商品自動有効化フラグ"",'1' ""在庫数プラスマイナスフラグ""    "
        strSQL &= " From " & schema & "t_genzaiko , " & schema & "m_seihin , " & schema & "t_zaiko"
        strSQL &= " Where t_genzaiko.sinacd  = m_seihin.sinacd "
        strSQL &= " And   t_genzaiko.sinacd  = t_zaiko.sinacd "
        strSQL &= " And   t_zaiko.nyukoflg = '1'"

        'strSQL &= " Where nouhinsu > 0"
        dt = ClassPostgeDB.SetTable(strSQL)
        Return (dt)
    End Function

    Private Sub EXCELToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem1.Click
        Dim dt = New DataTable
        '商品コード   商品名	バリエーション文字列	在庫数	入荷お知らせ受付フラグ	予約商品フラグ	予約商品自動有効化フラグ
        '                              0                ?
        dt = ECzaikoUpData()
        ExcelOout2(dt)

    End Sub

    Private Sub CSVToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem1.Click
        Dim dt = New DataTable
        Dim fm As String

        dt = ECzaikoUpData()
        GetIniFile()
        fm = FileSave(StockFolder)
        CSVOut2(dt, fm)
    End Sub

    Private Sub 確定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 確定ToolStripMenuItem.Click
        Dim dt = New DataTable
        Dim rowloop As Integer
        Dim strSQL As String

        dt = ECzaikoUpData()

        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        For rowloop = 0 To dt.Rows.Count - 1

            strSQL = "update " & schema & "t_genzaiko set ecflg='0',  genzaiko = (genzaiko + nouhinsu - tyuuzan) , nouhinsu=0 ,entry_day=now() ,entry_sya='" & UserName & "' where sinacd ='" & dt.Rows(rowloop).Item(0).ToString() & "'"
            ClassPostgeDB.EXEC(strSQL)

            strSQL = "update " & schema & "t_zaiko set "
            strSQL &= " nyukoflg = ''"
            strSQL &= ",fsturokubi=now()"
            strSQL &= ",update_day=now()"
            strSQL &= ",entry_sya ='" & UserName & "'"
            strSQL &= " where sinacd = '" & dt.Rows(rowloop).Item(0).ToString() & "'"
            strSQL &= " And nyukoflg = '1'"
            'strSQL &= " And goukei ='" & dt.Rows(rowloop).Item(3).ToString() & "'"
            ClassPostgeDB.EXEC(strSQL)

            FormMeter.GEN = rowloop
            FormMeter.Disp()

        Next
        FormMeter.CLos()

    End Sub

    Private Sub Button今日_Click(sender As Object, e As EventArgs) Handles Button今日.Click
        Me.MaskedTextBox入庫日.Text = Now
    End Sub

    Private Sub FormZaiko2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "5") Then

        End If
        Me.Dispose()
    End Sub
End Class