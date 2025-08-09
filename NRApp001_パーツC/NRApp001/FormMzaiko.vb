Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class FormMzaiko
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

    Private Function SetSQL()

        Dim strSQL As String
        strSQL = "Select oderno, sinacd, seihinmei, zaikosuu, upri, syouryou, tesuuryou, goukei"
        strSQL &= ",hatyuubi,renraku,jimurenraku,sagawano,syukoflg"
        strSQL &= ",entry_day, entry_sya, update_day, update_sya, syori_flg ,ebisuoda,idoudenno"
        strSQL &= ",seq FROM " & schema & "t_m_zaiko"
        strSQL &= " WHERE update_day Is Not null"

        Return strSQL
    End Function

    Private Sub 検索２(Cob As ComboBox)

        Dim strSQL As String
        strSQL = SetSQL()

        Select Case Cob.Text
            Case "引当待"
                strSQL = strSQL & " And syori_flg ='0'"
            Case "引当済"
                strSQL = strSQL & " and  syori_flg ='1'"
        End Select

        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.ReadOnly = True

    End Sub



    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)

        Dim strSQL As String
        strSQL = SetSQL()

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
            Case Else
                MessageBox.Show("条件を選択してください")
                Exit Sub
        End Select
        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.ReadOnly = True

    End Sub

    Private Sub Button検索1_Click(sender As Object, e As EventArgs) Handles Button検索1.Click
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)


    End Sub
    Private Sub Button検索2_Click(sender As Object, e As EventArgs) Handles Button検索2.Click
        Call 検索(Me.ComboBoxjy2, "seihinmei", Me.TextBox品名)

    End Sub
    Private Sub ButtonIy検索3_Click(sender As Object, e As EventArgs) Handles ButtonIy検索3.Click
        Call 検索２(ComboBox処理)
    End Sub
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBoxオーダーNo.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBox品名.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                Me.TextBox数量.Text = Me.DataGridView1.Rows(ro).Cells(3).Value

                Me.TextBox単価.Text = Me.DataGridView1.Rows(ro).Cells(4).Value
                Me.TextBox送料.Text = Me.DataGridView1.Rows(ro).Cells(5).Value
                Me.TextBox手数料.Text = Me.DataGridView1.Rows(ro).Cells(6).Value
                Me.TextBox合計.Text = Me.DataGridView1.Rows(ro).Cells(7).Value
                If Me.DataGridView1.Rows(ro).Cells(8).Value <> "" Then
                    Me.DateTimePicker発注日.Value = Me.DataGridView1.Rows(ro).Cells(8).Value
                Else
                    Me.MaskedTextBox発注日.Text = ""
                End If
                Me.TextBox連絡事項.Text = Me.DataGridView1.Rows(ro).Cells(9).Value
                Me.TextBox事務処理事項.Text = Me.DataGridView1.Rows(ro).Cells(10).Value
                Me.TextBox佐川番号.Text = Me.DataGridView1.Rows(ro).Cells(11).Value


                SetComboBox(Me.ComboBox出庫不要, Me.DataGridView1.Rows(ro).Cells(12).Value)


                Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(15).Value

                If Me.DataGridView1.Rows(ro).Cells(17).Value = "1" Then
                    Me.ComboBox処理.SelectedIndex = 1
                Else
                    Me.ComboBox処理.SelectedIndex = 0
                End If


                Me.TextBoxエビスオーダーNo.Text = Me.DataGridView1.Rows(ro).Cells(18).Value
                Me.TextBox移動伝票No.Text = Me.DataGridView1.Rows(ro).Cells(19).Value


                Me.TextBoxSEQ.Text = Me.DataGridView1.Rows(ro).Cells(20).Value

            Else
                Clear()
            End If
        End If

    End Sub
    Private Sub Clear()
        Me.TextBoxオーダーNo.Text = ""
        Me.TextBox品コード.Text = ""
        Me.TextBox品名.Text = ""
        Me.TextBox数量.Text = ""
        Me.TextBox更新日.Text = ""
        Me.ComboBox出庫不要.SelectedIndex = -1

        Me.TextBox単価.Text = "0"
        Me.TextBox送料.Text = "0"
        Me.TextBox手数料.Text = "0"
        Me.TextBox合計.Text = "0"

        Me.TextBox連絡事項.Text = ""
        Me.TextBox事務処理事項.Text = ""
        Me.TextBox佐川番号.Text = ""
        Me.TextBoxエビスオーダーNo.Text = ""
        Me.TextBox移動伝票No.Text = ""
        Me.MaskedTextBox発注日.Text = ""

        Me.TextBoxSEQ.Text = ""

    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim ret As String

        If Me.TextBox品コード.Text.Trim <> "" Then
            If ChkSinaCd(Me.TextBox品コード.Text.Trim) Then

                If Me.TextBox数量.Text <> "" Then
                    If Chksuji(Me.TextBox数量.Text) = False Then
                        MessageBox.Show("数量が数字ではありません")
                        Exit Sub
                    End If
                Else
                    Me.TextBox数量.Text = "0"
                End If

                If Me.TextBox単価.Text <> "" Then
                    If Chksuji(Me.TextBox数量.Text) = False Then
                        MessageBox.Show("数量が数字ではありません")
                        Exit Sub
                    End If
                Else
                    Me.TextBox単価.Text = "0"
                End If

                If Me.TextBox手数料.Text <> "" Then
                    If Chksuji(Me.TextBox数量.Text) = False Then
                        MessageBox.Show("数量が数字ではありません")
                        Exit Sub
                    End If
                Else
                    Me.TextBox手数料.Text = "0"
                End If

                If Me.TextBox送料.Text <> "" Then
                    If Chksuji(Me.TextBox数量.Text) = False Then
                        MessageBox.Show("数量が数字ではありません")
                        Exit Sub
                    End If
                Else
                    Me.TextBox送料.Text = "0"
                End If

                If Me.TextBoxオーダーNo.Text = "" Then
                    MessageBox.Show("オーダーNoが未入力です")
                    Exit Sub
                End If


                If Me.TextBox合計.Text <> "" Then
                    If Chksuji(Me.TextBox数量.Text) = False Then
                        MessageBox.Show("数量が数字ではありません")
                        Exit Sub
                    End If
                Else
                    Me.TextBox合計.Text = "0"
                End If

                If Me.ComboBox処理.SelectedIndex = -1 Then
                    MessageBox.Show("処理が選択されていません")
                    Exit Sub
                End If

                If Me.ComboBox出庫不要.SelectedIndex = -1 Then
                    MessageBox.Show("出庫が選択されていません")
                    Exit Sub
                End If


                If Me.TextBoxSEQ.Text = "" Then
                    ret = ""
                Else
                    strSQL = "select update_day from " & schema & "t_m_zaiko "
                    strSQL &= " where seq ='" & Me.TextBoxSEQ.Text & "'"
                    ret = ClassPostgeDB.DbSelnon(strSQL)
                End If

                If ret = "" Then
                    strSQL = "select seihinmei from " & schema & "m_seihin "
                    strSQL &= " where sinacd ='" & Me.TextBox品コード.Text & "'"
                    Me.TextBox品名.Text = ClassPostgeDB.DbSel(strSQL)

                    Me.TextBoxSEQ.Text = ClassPostgeDB.DbSel("SELECT nextval('" & schema & "seqorder')")

                    strSQL = "INSERT INTO " & schema & "t_m_zaiko(seq,oderno, sinacd, zaikosuu, entry_day, entry_sya, update_day, update_sya, syori_flg,"
                    strSQL &= "seihinmei, upri, syouryou, tesuuryou, goukei, hatyuubi, renraku, jimurenraku, sagawano, syukoflg,ebisuoda,idoudenno)VALUES("

                    strSQL &= " '" & Me.TextBoxSEQ.Text & "'"
                    strSQL &= ",'" & Me.TextBoxオーダーNo.Text & "'"
                    strSQL &= ",'" & Me.TextBox品コード.Text & "'"
                    strSQL &= "," & Me.TextBox数量.Text & ""
                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",'0'"
                    strSQL &= ",'" & Me.TextBox品名.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox単価.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox送料.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox手数料.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox合計.Text.Trim() & "'"
                    'hatyuubi,renraku,jimurenraku,sagawano,syukoflg
                    If IsDate(Me.MaskedTextBox発注日.Text) Then
                        strSQL &= ",'" & Me.MaskedTextBox発注日.Text & "'"
                    Else
                        strSQL &= ",NULL"
                    End If
                    strSQL &= ",'" & Me.TextBox連絡事項.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox事務処理事項.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox佐川番号.Text.Trim() & "'"
                    strSQL &= ",'" & Me.ComboBox出庫不要.Text.Trim() & "'"

                    strSQL &= ",'" & Me.TextBoxエビスオーダーNo.Text.Trim() & "'"
                    strSQL &= ",'" & Me.TextBox移動伝票No.Text.Trim() & "'"


                    strSQL &= ")"
                    ClassPostgeDB.EXEC(strSQL)
                    ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                    Clear()
                    MessageBox.Show("更新しました")

                Else

                    If ret = TextBox更新日.Text Then
                        strSQL = "UPDATE " & schema & "t_m_zaiko  SET "

                        strSQL &= " zaikosuu = " & Me.TextBox数量.Text & ""
                        strSQL &= ",oderno   = '" & Me.TextBoxオーダーNo.Text.Trim() & "'"
                        strSQL &= ",sinacd   ='" & Me.TextBox品コード.Text.Trim() & "'"
                        strSQL &= ",seihinmei='" & Me.TextBox品名.Text.Trim() & "'"
                        strSQL &= ", upri    = '" & Me.TextBox単価.Text.Trim() & "'"
                        strSQL &= ", syouryou = '" & Me.TextBox送料.Text.Trim() & "'"
                        strSQL &= ", tesuuryou = '" & Me.TextBox手数料.Text.Trim() & "'"
                        strSQL &= ", goukei  = '" & Me.TextBox合計.Text.Trim() & "'"
                        strSQL &= ", syori_flg = '" & Me.ComboBox処理.SelectedIndex.ToString() & "'"

                        'strSQL &= ", hatyuubi = '" & Me.DateTimePicker発注日.Value & "'"

                        If IsDate(Me.MaskedTextBox発注日.Text) Then
                            strSQL &= ",hatyuubi = '" & Me.MaskedTextBox発注日.Text & "'"
                        Else
                            strSQL &= ",hatyuubi = NULL"
                        End If

                        strSQL &= ", renraku = '" & Me.TextBox連絡事項.Text.Trim() & "'"
                        strSQL &= ", jimurenraku = '" & Me.TextBox事務処理事項.Text.Trim() & "'"
                        strSQL &= ", sagawano = '" & Me.TextBox佐川番号.Text.Trim() & "'"
                        strSQL &= ", syukoflg = '" & Me.ComboBox出庫不要.Text & "'"


                        strSQL &= ",ebisuoda='" & Me.TextBoxエビスオーダーNo.Text.Trim() & "'"
                        strSQL &= ",idoudenno='" & Me.TextBox移動伝票No.Text.Trim() & "'"


                        strSQL &= ", update_day = now()"
                        strSQL &= ", update_sya ='" & UserName & "'"
                        strSQL &= " where seq ='" & Me.TextBoxSEQ.Text & "'"

                        ClassPostgeDB.EXEC(strSQL)
                        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                        Clear()
                        MessageBox.Show("更新しました")
                    Else
                        MessageBox.Show("データが更新されています。再検索してください")
                    End If

                End If
            End If
        End If

    End Sub



    Private Sub Button品コード検索_Click(sender As Object, e As EventArgs) Handles Button品コード検索.Click
        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text
        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox品名.Text = FormSelectSeihin.SeihinName
        End If
        FormSelectSeihin.Dispose()
    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String
        Dim ret As String
        strSQL = "SELECT update_day FROM " & schema & "t_m_zaiko "
        strSQL &= " where sinacd ='" & Me.TextBox品コード.Text & "'"
        strSQL &= " and  seq  ='" & Me.TextBoxSEQ.Text.Trim() & "'"

        ret = ClassPostgeDB.DbSel(strSQL)

        If ret = TextBox更新日.Text Then
            strSQL = "DELETE FROM  " & schema & "t_m_zaiko "
            strSQL &= " where sinacd ='" & Me.TextBox品コード.Text & "'"
            strSQL &= " and  seq  ='" & Me.TextBoxSEQ.Text.Trim() & "'"

            ClassPostgeDB.EXEC(strSQL)

            ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Clear()
        Else
            MessageBox.Show("データが更新されています。再検索してください")
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

    Private Sub FormMzaiko_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "6") Then

        End If

    End Sub

    Private Sub FormMzaiko_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSQL As String
        strSQL = "SELECT ms.naiyou FROM " & schema & "m_system ms where ms.kbn ='22' order by seq"
        ClassPostgeDB.SetComboBox(Me.ComboBox出庫不要, strSQL)

    End Sub

    Private Sub DateTimePicker発注日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker発注日.ValueChanged
        Me.MaskedTextBox発注日.Text = Me.DateTimePicker発注日.Value
    End Sub


End Class