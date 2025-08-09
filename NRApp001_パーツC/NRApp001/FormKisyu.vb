Imports Microsoft.VisualBasic.FileIO
Imports System.Text

Public Class FormKisyu
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

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String
        Dim dt As New DataTable
        Me.DataGridView1.DataSource = Nothing

        strSQL = "SELECT sinacd as 品コード, meisyou as 漢字名称, kisyucd as 機種コード ,tekigoukisyu as 適合機種, to_char(tekigoukisyu_haisibi,'yyyy/mm/dd') as 適合機種廃止日, entry_day as 作成日, entry_sya as 更新者,update_day  as 更新日 FROM " & schema & "t_buhintekigou WHERE update_day is not null"
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
        'DataGridView1.DefaultCellStyle.NullValue = "-"

        strSQL = strSQL & " order by sinacd,kisyucd"
        zenkaiSQL = strSQL


        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = dt
            Me.DataGridView1.ReadOnly = True
        End If

        'ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
    End Sub
    Private Sub 検索機種()
        Dim strSQL As String
        Dim dt As New DataTable
        Me.DataGridView1.DataSource = Nothing


        If Me.TextBox品コード1.Text.Length <> 7 Or Me.TextBox品コード2.Text.Length <> 7 Then
            MsgBox("品コードが未入力です")
            Return
        Else

            If Me.TextBox品コード1.Text = Me.TextBox品コード2.Text Then
                MsgBox("同じ品コードです")
                Return
            End If

            If ChkSeihin(Me.TextBox品コード1.Text.ToString) = False Then
                MessageBox.Show("製品マスタに存在しません")
                Return
            End If
            If ChkSeihin(Me.TextBox品コード2.Text.ToString) = False Then
                MessageBox.Show("製品マスタに存在しません")
                Return
            End If
        End If

        strSQL = "select   A.kisyucd  as 機種コード, A.tekigoukisyu  as 適合機種"
        strSQL = strSQL & "  from (select kisyucd,tekigoukisyu ,sinacd from  " & schema & "t_buhintekigou  where sinacd  = '" & Me.TextBox品コード1.Text & "') A"
        strSQL = strSQL & "  ,       (select kisyucd,tekigoukisyu ,sinacd from  " & schema & "t_buhintekigou  where sinacd  = '" & Me.TextBox品コード2.Text & "') B"
        strSQL = strSQL & "  where A.kisyucd = B.kisyucd  "

        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = dt
            Me.DataGridView1.ReadOnly = True
        End If
        'ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

    End Sub

    Private Sub 検索機種2()
        Dim strSQL As String = String.Empty
        Dim dt As New DataTable

        strSQL = "Select"
        strSQL &= " a.kisyucd 機種コード"
        strSQL &= ",a.tekigoukisyu 機種名"
        strSQL &= ",b.sinacd 品コード"
        strSQL &= " from "
        strSQL &= "(select t_buhintekigou.sinacd , t_buhintekigou.kisyucd  ,t_buhintekigou.tekigoukisyu   from t_buhintekigou ) a "
        strSQL &= ",(select t_buhintekigou.sinacd , t_buhintekigou.kisyucd  ,t_buhintekigou.tekigoukisyu   from t_buhintekigou ) b "
        strSQL &= " where a.sinacd <> b.sinacd "
        strSQL &= " And a.kisyucd  = b.kisyucd"
        strSQL &= " And a.sinacd  = '" & Me.TextBox品コード.Text & "'"

        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = dt
            Me.DataGridView1.ReadOnly = True
        End If

    End Sub



    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)
        Clear("1")
    End Sub

    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        Call 検索(Me.ComboBoxjy2, "meisyou", Me.TextBox漢字名称)
        Clear("2")
    End Sub

    Private Sub Button検索３_Click(sender As Object, e As EventArgs) Handles Button検索３.Click
        Call 検索(Me.ComboBoxJy3, "kisyucd", Me.TextBox機種コード)
        Clear("3")
    End Sub

    Private Sub Button検索４_Click(sender As Object, e As EventArgs) Handles Button検索４.Click

        Me.TextBox適合機種.Text = StrConv(Me.TextBox適合機種.Text, vbWide)


        Call 検索(Me.ComboBoxjy4, "tekigoukisyu", Me.TextBox適合機種)
        Clear("4")
    End Sub

    Private Sub Clear(sw As String)
        Select Case sw

            Case "1"
                'Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                Me.TextBox適合機種.Text = ""
                Me.TextBox適合機種廃止日.Text = ""
            Case "2"
                Me.TextBox品コード.Text = ""
                'Me.TextBox漢字名称.Text = ""
                Me.TextBox適合機種.Text = ""
                Me.TextBox適合機種廃止日.Text = ""
            Case "3"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                'Me.TextBox適合機種.Text = ""
                Me.TextBox適合機種廃止日.Text = ""
            Case "4"
                Me.TextBox品コード.Text = ""
                Me.TextBox漢字名称.Text = ""
                'Me.TextBox適合機種.Text = ""
                'Me.TextBox適合機種廃止日.Text = ""
            Case Else



        End Select

        Me.TextBox更新日.Text = ""
        Me.TextBox機種コード.Text = ""

    End Sub


    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim Ret
        Dim dt As DateTime

        If Me.TextBox品コード.Text.Trim <> "" And Me.TextBox機種コード.Text.Trim <> "" Then

            If ChkSinaCd(Me.TextBox品コード.Text.Trim) And
                 ChkSinaCd(Me.TextBox機種コード.Text.Trim) And
                       ChkShop(Me.TextBox品コード.Text.Trim) Then


                If Me.TextBox漢字名称.Text = "" Then
                    Me.TextBox漢字名称.Text = GetSinaNm(Me.TextBox品コード.Text.ToString)
                End If
                If Me.TextBox適合機種.Text = "" Then
                    Me.TextBox適合機種.Text = GetSinaNm(Me.TextBox機種コード.Text.ToString)
                End If

                If Strings.Left(Me.TextBox適合機種廃止日.Text.ToString, 1) <> " " Then
                    If DateTime.TryParse(Me.TextBox適合機種廃止日.Text, dt) Then
                        '変換出来たら、dtにその値が入る
                        'MessageBox.Show("{0}はDateTime{1}に変換できます。")
                    Else
                        MessageBox.Show("適合機種廃止日が日付けではりません")
                        Exit Sub
                    End If
                End If

                strSQL = "select update_day from " & schema & "t_buhintekigou where sinacd ='" & Me.TextBox品コード.Text.ToString & "' and  kisyucd = '" & Me.TextBox機種コード.Text & "'"

                Ret = ClassPostgeDB.DbSel(strSQL)
                If Ret = "" Then
                    strSQL = "INSERT INTO " & schema & "t_buhintekigou (sinacd, meisyou, kisyucd,tekigoukisyu  , tekigoukisyu_haisibi, entry_day, entry_sya,update_day) VALUES("
                    strSQL &= " '" & Me.TextBox品コード.Text.ToString & "'"
                    strSQL &= ",'" & Me.TextBox漢字名称.Text.ToString & "'"
                    strSQL &= ",'" & Me.TextBox機種コード.Text.ToString & "'"

                    strSQL &= ",'" & Me.TextBox適合機種.Text.ToString & "'"
                    If Strings.Left(Me.TextBox適合機種廃止日.Text.ToString, 1) = " " Then
                        strSQL &= ",NULL"
                    Else
                        strSQL &= ",'" & Me.TextBox適合機種廃止日.Text.ToString & "'"
                    End If

                    strSQL &= ", now() "
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ", now() "
                    strSQL &= ")"
                Else
                    If Me.TextBox更新日.Text = Ret Then

                        strSQL = "UPDATE " & schema & "t_buhintekigou set meisyou = '" & Me.TextBox漢字名称.Text.Trim.ToString & "'"
                        If Strings.Left(Me.TextBox適合機種廃止日.Text, 1) = " " Then
                            strSQL &= ", tekigoukisyu_haisibi = NULL"
                        Else
                            strSQL &= ",tekigoukisyu_haisibi = '" & Me.TextBox適合機種廃止日.Text.ToString & "'"
                        End If

                        strSQL &= ",tekigoukisyu = '" & Me.TextBox適合機種.Text.Trim.ToString & "'"

                        strSQL &= ",update_day = now() "
                        strSQL &= ",entry_sya = '" & UserName & "'"

                        strSQL &= " WHERE sinacd = '" & Me.TextBox品コード.Text.ToString & "' and kisyucd = '" & Me.TextBox機種コード.Text & "'"
                    Else
                        MessageBox.Show("データが更新されています。再検索してください")
                        Exit Sub
                    End If
                End If
                If ClassPostgeDB.EXEC(strSQL) Then
                    MessageBox.Show("更新しました")
                    ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                    strSQL = "select update_day from " & schema & "t_buhintekigou where sinacd ='" & Me.TextBox品コード.Text.ToString & "' and kisyucd = '" & Me.TextBox機種コード.Text & "'"
                    Me.TextBox更新日.Text = ClassPostgeDB.DbSel(strSQL)
                Else
                    MessageBox.Show("更新エラーです")
                End If
            End If
        End If

    End Sub
    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) 
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox漢字名称.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBox機種コード.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                Me.TextBox適合機種.Text = Me.DataGridView1.Rows(ro).Cells(3).Value


                If Me.DataGridView1.Rows(ro).Cells(4).Value.ToString.Trim = "" Then
                    Me.TextBox適合機種廃止日.Text = ""
                Else
                    Me.TextBox適合機種廃止日.Text = Me.DataGridView1.Rows(ro).Cells(4).Value
                End If
                Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(7).Value
            Else

                Clear("")

            End If
        End If

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click

        Dim strSQL As String
        strSQL = "DELETE from " & schema & "t_buhintekigou "
        strSQL &= " where sinacd ='" & Me.TextBox品コード.Text.ToString & "' and kisyucd= '" & Me.TextBox機種コード.Text & "'"

        If ClassPostgeDB.EXEC(strSQL) Then
            MessageBox.Show("削除しました")
            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Me.TextBox品コード.Text = ""
            Me.TextBox漢字名称.Text = ""
            Me.TextBox適合機種.Text = ""
            Me.TextBox適合機種廃止日.Text = ""
            Me.TextBox更新日.Text = ""
            Me.TextBox機種コード.Text = ""


        Else
            MessageBox.Show("削除エラーです")
        End If

    End Sub

    Private Sub TextBox適合機種廃止日_ValueChanged(sender As Object, e As EventArgs) Handles TextBox適合機種廃止日1.ValueChanged
        Me.TextBox適合機種廃止日.Text = Me.TextBox適合機種廃止日1.Value
    End Sub


    Private Function ChkSeihin(seihin As String) As Boolean

        Dim strSQL As String
        Dim Ret
        strSQL = "select count(*) from " & schema & "m_seihin where sinacd ='" & seihin & "'"
        Ret = ClassPostgeDB.DbSel(strSQL)
        If Ret = "0" Then
            ChkSeihin = False
        Else
            ChkSeihin = True
        End If
    End Function


    Private Sub TextBox品コード_Leave(sender As Object, e As EventArgs) Handles TextBox品コード.Leave

        If Me.TextBox品コード.Text.ToString.Length = 7 Then
            If ChkSeihin(Me.TextBox品コード.Text.ToString) = False Then
                MessageBox.Show("製品マスタに存在しません")
            Else
                If Me.TextBox漢字名称.Text = "" Then
                    Me.TextBox漢字名称.Text = GetSinaNm(Me.TextBox品コード.Text.ToString)
                End If
            End If
        End If

    End Sub

    Private Sub Button製品検索_Click(sender As Object, e As EventArgs) Handles Button製品検索.Click

        'Dim Fm As New FormSelectSeihin

        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text

        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox漢字名称.Text = FormSelectSeihin.SeihinName
        End If

        FormSelectSeihin.Dispose()

    End Sub

    Private Sub Button機種検索_Click(sender As Object, e As EventArgs) Handles Button機種検索.Click
        ' Dim Fm As New FormSelectSeihin

        FormSelectSeihin.SinaCD = Me.TextBox機種コード.Text

        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            Me.TextBox機種コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox適合機種.Text = FormSelectSeihin.SeihinName
        End If
        FormSelectSeihin.Dispose()

    End Sub

    Private Sub TextBox機種コード_Leave(sender As Object, e As EventArgs) Handles TextBox機種コード.Leave

        If Me.TextBox機種コード.Text.ToString <> "" Then
            If ChkSeihin(Me.TextBox機種コード.Text.ToString) = False Then
                MessageBox.Show("製品マスタに存在しません")
            Else
                If Me.TextBox適合機種.Text = "" Then
                    Me.TextBox適合機種.Text = GetSinaNm(Me.TextBox機種コード.Text.ToString)
                End If
            End If
        End If

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

    Private Sub FormKisyu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "10") Then

        End If

    End Sub

    Private Sub CSVToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem1.Click

        Dim filename As String
        Dim strSQL As String
        Dim rw As Integer
        Dim fileFlg As Boolean
        'Dim i As Integer

        GetIniFile()
        filename = Filesentaku(MaserFolder)
        If filename <> "" Then
            If filename.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0 Then

                Using parser As New TextFieldParser(filename,
                                               Encoding.GetEncoding("Shift_JIS"))

                    ' カンマ区切りの指定
                    parser.TextFieldType = FieldType.Delimited
                    parser.SetDelimiters(",")
                    ' フィールドが引用符で囲まれているか
                    parser.HasFieldsEnclosedInQuotes = True
                    ' フィールドの空白トリム設定
                    parser.TrimWhiteSpace = False

                    Dim row As String() = parser.ReadFields()
                    fileFlg = True
                    Try
                        If row.Length = 8 Then
                            If row(0).IndexOf("品コード") < 0 Then fileFlg = False
                            If row(1).IndexOf("漢字名称") < 0 Then fileFlg = False
                            If row(2).IndexOf("機種コード") < 0 Then fileFlg = False
                            If row(3).IndexOf("適合機種") < 0 Then fileFlg = False
                            If row(4).IndexOf("適合機種廃止日") < 0 Then fileFlg = False
                            If row(5).IndexOf("作成日") < 0 Then fileFlg = False
                            If row(6).IndexOf("更新者") < 0 Then fileFlg = False
                            If row(7).IndexOf("更新日") < 0 Then fileFlg = False
                        Else
                            fileFlg = False
                        End If
                    Catch ex As Exception
                        MessageBox.Show("ファイルが違います")
                        Return
                    End Try

                    If fileFlg = False Then
                        MessageBox.Show("ファイルが違います")
                        Return
                    End If
                    rw = 1

                    Try
                        ClassPostgeDB.DbOpen()
                        ClassPostgeDB.BeginTrans()

                        If Me.ToolStripComboBox1.Text = "削除して追加" Then
                            strSQL = "DELETE FROM " & schema & "t_buhintekigou"
                            ClassPostgeDB.EXEC_tr(strSQL)
                        End If

                        While Not parser.EndOfData
                            ' フィールドを読込
                            row = parser.ReadFields()

                            strSQL = "delete from " & schema & "t_buhintekigou "
                            strSQL &= " where sinacd = '" & row(0) & "'"
                            strSQL &= " and   kisyucd = '" & row(2) & "'"
                            ClassPostgeDB.EXEC_tr(strSQL)


                            strSQL = "INSERT INTO " & schema & "t_buhintekigou (sinacd, meisyou, kisyucd,tekigoukisyu, tekigoukisyu_haisibi, entry_day, update_day,entry_sya) VALUES("
                            strSQL &= " '" & row(0) & "'"
                            strSQL &= ",'" & row(1) & "'"
                            strSQL &= ",'" & row(2) & "'"
                            strSQL &= ",'" & row(3) & "'"

                            If IsDateExpression(row(4)) Then
                                strSQL &= ",'" & row(4) & "'"
                            Else
                                strSQL &= ",null"
                            End If
                            strSQL &= ",now(),now()"
                            strSQL &= ",'" & UserName & "')"
                            ClassPostgeDB.EXEC_tr(strSQL)

                            rw = rw + 1
                        End While
                        parser.Close()
                        ClassPostgeDB.Commit()
                        ClassPostgeDB.DbClose()

                        MessageBox.Show("合機機種を入れ替えました")
                    Catch ex As Exception
                        parser.Close()
                        ClassPostgeDB.Rollback()
                        ClassPostgeDB.DbClose()
                        MessageBox.Show(rw & "行目でエラーがあります" & vbCrLf & ex.Message)
                    End Try
                End Using
            Else
                MessageBox.Show("ＣＳＶではありません")
            End If
        End If



    End Sub

    Private Sub 名称更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 名称更新ToolStripMenuItem.Click
        Dim strSQL As String


        If MessageBox.Show("漢字名称と適合機種を再設定しますか", "更新確認", MessageBoxButtons.YesNo) = vbYes Then

            strSQL = "update " & schema & "t_buhintekigou set meisyou = (select m_seihin.seihinmei from " & schema & "m_seihin where m_seihin.sinacd =t_buhintekigou.sinacd )"
            If ClassPostgeDB.EXEC(strSQL) Then
            Else
                MessageBox.Show("更新エラー")

            End If
            strSQL = "update " & schema & "t_buhintekigou set tekigoukisyu = (select m_seihin.seihinmei from " & schema & "m_seihin where m_seihin.sinacd =t_buhintekigou.kisyucd );"
            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("更新しました")
            Else
                MessageBox.Show("更新エラー")
            End If
        End If
    End Sub

    Private Sub FormKisyu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ToolStripComboBox1.SelectedIndex = 1
        Me.Button品削除.Visible = False
    End Sub

    Private Sub TextBox品コード_TextChanged(sender As Object, e As EventArgs) Handles TextBox品コード.TextChanged

        If Me.TextBox品コード.Text = "" Then
            Me.Button品削除.Visible = False

        Else
            Me.Button品削除.Visible = True
        End If

    End Sub
    Private Function ChkSinaCdBuhon(sinacd As String) As Boolean
        Dim strSQL As String
        strSQL = "SELECT sinacd FROM " & schema & "t_buhintekigou where sinacd ='" & sinacd & "'"

        If ClassPostgeDB.DbSel(strSQL) = sinacd Then
            ChkSinaCdBuhon = True
        Else
            MessageBox.Show("[ " & sinacd & " ]がdデータに存在しません")
            ChkSinaCdBuhon = False
        End If

    End Function


    Private Sub Button品削除_Click(sender As Object, e As EventArgs) Handles Button品削除.Click
        Dim strSQL As String

        If ChkSinaCd(Me.TextBox品コード.Text.Trim) And
                ChkSinaCdBuhon(Me.TextBox品コード.Text.Trim) Then

            Dim result As DialogResult = MessageBox.Show("【" & Me.TextBox品コード.Text.Trim & "】の品コードに関する全データを削除しますか？",
                                             "確認",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)
            If result = 6 Then
                strSQL = "DELETE FROM " & schema & "t_buhintekigou where sinacd ='" & Me.TextBox品コード.Text.Trim & "'"
                ClassPostgeDB.EXEC(strSQL)
                Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)
                Clear("1")

            End If
        End If
    End Sub

    Private Sub Button追加_Click(sender As Object, e As EventArgs) Handles Button追加.Click

        If Me.TextBox品コード1.Text = "" Then
            Me.TextBox品コード1.Text = Me.TextBox品コード.Text
            Me.TextBox品コード.Text = ""
            Me.TextBox漢字名称.Text = ""
            Return
        End If

        If Me.TextBox品コード2.Text = "" Then
            Me.TextBox品コード2.Text = Me.TextBox品コード.Text
            Me.TextBox品コード.Text = ""
            Me.TextBox漢字名称.Text = ""
            Return
        End If


        MsgBox("最大2つまで登録できます")

    End Sub

    Private Sub Button消す1_Click(sender As Object, e As EventArgs)
        Me.TextBox品コード1.Text = ""
    End Sub

    Private Sub Button消す2_Click(sender As Object, e As EventArgs)
        Me.TextBox品コード2.Text = ""

    End Sub

    Private Sub Button消す3_Click(sender As Object, e As EventArgs)
        Me.TextBox品コード3.Text = ""
    End Sub

    Private Sub Button検索機種_Click(sender As Object, e As EventArgs) Handles Button検索機種.Click
        If Me.TextBox品コード.Text <> "" Then
            検索機種2()
        Else
            検索機種()
        End If
    End Sub

End Class