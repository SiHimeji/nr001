Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class FormMstcoupon
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

    Private Sub S終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles S終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)

        Dim strSQL As String
        strSQL = "SELECT couponno, sinacd, offpar,offkin, to_char(kikanfrom,'YYYY/MM/DD'),to_char(kikanto,'YYYY/MM/DD'), update_day,entry_day,  entry_sya "
        strSQL &= " FROM " & schema & "m_coupon"
        strSQL &= " WHERE update_day Is Not null"
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


        Me.件ToolStripMenuItem.Text = Me.DataGridView1.Rows.Count & "件"

        Me.DataGridView1.ReadOnly = True
    End Sub
    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "couponno", Me.TextBoxクーポン番号)
    End Sub

    Private Sub Button検索2_Click(sender As Object, e As EventArgs) Handles Button検索2.Click
        Call 検索(Me.ComboBoxJy2, "sinacd", Me.TextBox品コード)
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBoxクーポン番号.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(1).Value

                If Me.DataGridView1.Rows(ro).Cells(2).Value <> "0" Then
                    Me.TextBox割引.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                    Me.RadioButton1.Checked = True
                Else
                    Me.TextBox割引.Text = Me.DataGridView1.Rows(ro).Cells(3).Value
                    Me.RadioButton2.Checked = True

                End If

                Me.DateTimePicker期間1.Text = Me.DataGridView1.Rows(ro).Cells(4).Value
                Me.DateTimePicker期間2.Text = Me.DataGridView1.Rows(ro).Cells(5).Value

                Me.TextBox更新日.Text = Me.DataGridView1.Rows(ro).Cells(6).Value

            Else
                Clear()
            End If
        End If
    End Sub

    Private Sub Button品コード検索_Click(sender As Object, e As EventArgs) Handles Button品コード検索.Click
        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text
        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            'Me.TextBox品名.Text = FormSelectSeihin.SeihinName
        End If
        FormSelectSeihin.Dispose()
    End Sub
    Private Sub Clear()
        Me.TextBoxクーポン番号.Text = ""
        Me.TextBox品コード.Text = ""
        Me.TextBox割引.Text = ""
        Me.TextBox更新日.Text = ""

    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim strSQL As String
        Dim ret As String

        If Me.TextBoxクーポン番号.Text.Trim = "" Then
            MessageBox.Show("クーポン番号.が未入力です")
            Exit Sub
        End If
        If Me.TextBox品コード.Text.Trim <> "" Then
            If ChkSinaCd(Me.TextBox品コード.Text.Trim) = False Then
                MessageBox.Show("品コードが存在しません")
                Exit Sub
            End If
        Else
            MessageBox.Show("品コードが未入力です")
            Exit Sub
        End If

        'If Me.TextBox割引.Text <> "" Then
        If Chksuji(Me.TextBox割引.Text) = False Then
            If Me.RadioButton1.Checked Then
                MessageBox.Show("割引率が数字ではありません")
            Else
                MessageBox.Show("割引金額が数字ではありません")
            End If

            Exit Sub
        End If

        'End If



        strSQL = "select update_day from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & Me.TextBoxクーポン番号.Text.Trim & "'"
        strSQL &= "  and  sinacd ='" & Me.TextBox品コード.Text.Trim & "'"
        ret = ClassPostgeDB.DbSelnon(strSQL)

        If ret = "" Then
            strSQL = "INSERT INTO " & schema & "m_coupon (couponno, sinacd, offpar,offkin,kikanfrom,kikanto ,update_day, entry_day, entry_sya) VALUES("
            strSQL &= "'" & Me.TextBoxクーポン番号.Text.Trim & "'"
            strSQL &= ",'" & Me.TextBox品コード.Text.Trim & "'"

            If Me.RadioButton1.Checked Then
                strSQL &= ",'" & Me.TextBox割引.Text.Trim & "'"
                strSQL &= ",'0'"
            Else
                strSQL &= ",'0'"
                strSQL &= ",'" & Me.TextBox割引.Text.Trim & "'"
            End If

            strSQL &= ",'" & DateTime.Parse(DateTimePicker期間1.Text) & "'"
            strSQL &= ",'" & DateTime.Parse(DateTimePicker期間2.Text) & "'"

            strSQL &= ",now()"
            strSQL &= ",now()"
            strSQL &= ",'" & UserName & "'"
            strSQL &= ")"

        Else
            If ret = Me.TextBox更新日.Text.Trim Then

                strSQL = "UPDATE " & schema & "m_coupon SET"

                If Me.RadioButton1.Checked Then
                    strSQL &= " offpar ='" & Me.TextBox割引.Text.Trim & "'"
                    strSQL &= ",offkin ='0'"
                Else
                    strSQL &= " offpar ='0'"
                    strSQL &= ",offkin ='" & Me.TextBox割引.Text.Trim & "'"
                End If
                strSQL &= ",kikanfrom ='" & DateTime.Parse(DateTimePicker期間1.Text) & "'"
                strSQL &= ",kikanto   ='" & DateTime.Parse(DateTimePicker期間2.Text) & "'"
                strSQL &= ",update_day = now()"
                strSQL &= ",entry_sya = '" & UserName & "'"
                strSQL &= " where couponno ='" & Me.TextBoxクーポン番号.Text.Trim & "'"
                strSQL &= " and sinacd = '" & Me.TextBox品コード.Text.Trim & "'"
            Else
                MessageBox.Show("データが更新されています。再検索してください")
                Exit Sub
            End If
        End If

        ClassPostgeDB.EXEC(strSQL)
        strSQL = "UPDATE " & schema & "m_coupon SET"
        strSQL &= " kikanfrom ='" & DateTime.Parse(DateTimePicker期間1.Text) & "'"
        strSQL &= ",kikanto   ='" & DateTime.Parse(DateTimePicker期間2.Text) & "'"
        strSQL &= " where couponno ='" & Me.TextBoxクーポン番号.Text.Trim & "'"
        ClassPostgeDB.EXEC(strSQL)

        If Me.RadioButton2.Checked Then
            strSQL = "UPDATE " & schema & "m_coupon SET"
            strSQL &= " offpar ='0'"
            strSQL &= ",offkin ='" & Me.TextBox割引.Text.Trim & "'"
            strSQL &= " where couponno ='" & Me.TextBoxクーポン番号.Text.Trim & "'"
            ClassPostgeDB.EXEC(strSQL)
        Else

            strSQL = "UPDATE " & schema & "m_coupon SET"
            strSQL &= " offkin ='0'"
            strSQL &= " where couponno ='" & Me.TextBoxクーポン番号.Text.Trim & "'"
            ClassPostgeDB.EXEC(strSQL)
        End If

        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
        Clear()
        MessageBox.Show("更新しました")
    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click

        Dim strSQL As String
        Dim ret As String

        strSQL = "select update_day from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & Me.TextBoxクーポン番号.Text.Trim & "'"
        strSQL &= "  and  sinacd ='" & Me.TextBox品コード.Text.Trim & "'"
        ret = ClassPostgeDB.DbSelnon(strSQL)

        If ret = TextBox更新日.Text Then
            strSQL = "DELETE FROM  " & schema & "m_coupon "
            strSQL &= " where sinacd ='" & Me.TextBox品コード.Text & "'"
            strSQL &= " and  couponno  ='" & Me.TextBoxクーポン番号.Text.Trim() & "'"

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
        If fileName <> "" Then
            csvOutDataGred(Me.DataGridView1, fileName, 0, False)
        End If
    End Sub

    Private Sub TextBox品コード_TextChanged(sender As Object, e As EventArgs) Handles TextBox品コード.TextChanged
        Me.TextBox更新日.Text = ""
        Me.TextBox割引.Text = ""

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.Label割引.Text = "割引率(%)"
        Me.TextBox割引.MaxLength = 2
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.Label割引.Text = "割引金額"
        Me.TextBox割引.MaxLength = 5
    End Sub

    Private Sub CSVToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem1.Click
        Dim filename As String
        Dim strSQL As String
        Dim rw As Integer
        Dim fileFlg As Boolean
        Dim i As Integer

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
                        If row.Length = 6 Or row.Length = 9 Then
                            If row(0).IndexOf("クーポン番号") < 0 Then fileFlg = False
                            If row(1).IndexOf("品コード") < 0 Then fileFlg = False
                            If row(2).IndexOf("割引率") < 0 Then fileFlg = False
                            If row(3).IndexOf("割引金額") < 0 Then fileFlg = False
                            If row(4).IndexOf("割引期間から") < 0 Then fileFlg = False
                            If row(5).IndexOf("割引期間まで") < 0 Then fileFlg = False
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
                        If Me.ToolStripComboBox1.Text = "入れ替え" Then
                            strSQL = "delete from " & schema & "m_coupon"
                            ClassPostgeDB.EXEC_tr(strSQL)
                        End If

                        While Not parser.EndOfData
                            ' フィールドを読込
                            row = parser.ReadFields()
                            If Chksuji(row(2)) = False Then row(2) = "0"
                            If Chksuji(row(3)) = False Then row(3) = "0"

                            strSQL = "INSERT INTO " & schema & "m_coupon (couponno, sinacd, offpar, offkin, kikanfrom, kikanto, update_day, entry_day, entry_sya) VALUES("
                            strSQL &= " '" & row(0) & "'"
                            strSQL &= ",'" & row(1) & "'"
                            strSQL &= ",'" & row(2) & "'"
                            strSQL &= ",'" & row(3) & "'"
                            strSQL &= ",'" & row(4) & "'"
                            strSQL &= ",'" & row(5) & "'"
                            strSQL &= ",now(),now()"
                            strSQL &= ",'" & UserName & "')"
                            ClassPostgeDB.EXEC_tr(strSQL)

                            rw = rw + 1
                        End While
                        parser.Close()
                        ClassPostgeDB.Commit()
                        ClassPostgeDB.DbClose()

                        strSQL = "select couponno from " & schema & "m_coupon group by couponno"

                        Dim dt As DataTable = ClassPostgeDB.SetTable(strSQL)

                        For i = 0 To dt.Rows.Count - 1


                            strSQL = dt.Rows(i).Item(0).ToString()


                        Next

                        MessageBox.Show("クーポンマスタを入れ替えました")
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

    Private Sub FormMstcoupon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.件ToolStripMenuItem.Text = "0件"

        Me.ToolStripComboBox1.Items.Clear()
        Me.ToolStripComboBox1.Items.Add("入れ替え")
        Me.ToolStripComboBox1.Items.Add("追加")
        Me.ToolStripComboBox1.SelectedIndex = 0



    End Sub

    Private Sub EXCELToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem1.Click
        'EXCELから入力する
        Dim FormMeter As New FormMeter

        Dim excelApp As New Excel.Application()
        Dim excelBooks As Excel.Workbooks
        excelBooks = excelApp.Workbooks

        Dim colloop As Integer
        Dim rowloop As Integer
        Dim strSQL As String

        Dim colクーポン番号 As Integer = 0
        Dim col品コード As Integer = 0
        Dim col割引率 As Integer = 0
        Dim col割引金額 As Integer = 0
        Dim col割引期間から As Integer = 0
        Dim col割引期間まで As Integer = 0

        Dim TextBoxFileName1 As String

        GetIniFile()
        TextBoxFileName1 = FilesentakuEXELS(ZaikoFolder)

        If TextBoxFileName1 = "" Then Exit Sub
        ZaikoFolder = TextBoxFileName1

        Dim excelBook As Excel.Workbook = excelBooks.Open(TextBoxFileName1)
        Dim sheet As Excel.Worksheet = excelBook.Worksheets(1)

        excelApp.Visible = True

        colloop = 1
        While sheet.Cells(1, colloop).value <> Nothing
                Select Case sheet.Cells(1, colloop).value
                    Case "クーポン番号"
                        colクーポン番号 = colloop
                    Case "品コード"
                        col品コード = colloop
                    Case "割引率"
                        col割引率 = colloop
                    Case "割引金額"
                        col割引金額 = colloop
                    Case "割引期間から"
                        col割引期間から = colloop
                    Case "割引期間まで"
                        col割引期間まで = colloop
                End Select
            colloop = colloop + 1
        End While

        If colクーポン番号 = 0 Or col品コード = 0 Or col割引率 = 0 Or col割引金額 = 0 Or col割引期間から = 0 Or col割引期間まで = 0 Then
            MessageBox.Show("フォーマットが違います")

            excelApp.Quit()
            Marshal.ReleaseComObject(excelApp)
            Marshal.ReleaseComObject(excelBooks)

            Exit Sub
        End If

        rowloop = 2
        While sheet.Cells(rowloop, colクーポン番号).value <> Nothing
            rowloop = rowloop + 1
        End While

        FormMeter.MAX = rowloop
        FormMeter.Show()

        Try
            ClassPostgeDB.DbOpen()
            ClassPostgeDB.BeginTrans()

            If Me.ToolStripComboBox1.Text = "入れ替え" Then
                strSQL = "delete from " & schema & "m_coupon"
                ClassPostgeDB.EXEC_tr(strSQL)
            End If

            rowloop = 2
            While sheet.Cells(rowloop, colクーポン番号).value <> Nothing

                strSQL = ""
                strSQL &= "INSERT INTO " & schema & "m_coupon ("
                strSQL &= "couponno, sinacd, offpar, offkin, kikanfrom, kikanto, update_day, entry_day, entry_sya) VALUES("
                '""'', '', 0, 0, '', '', '', '', '');
                If colクーポン番号 <> 0 Then strSQL &= "'" & sheet.Cells(rowloop, colクーポン番号).value & "'" Else strSQL &= "''"
                If col品コード <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, col品コード).value & "'" Else strSQL &= ",''"
                If col割引率 <> 0 Then strSQL &= "," & sheet.Cells(rowloop, col割引率).value & "" Else strSQL &= ",0"
                If col割引金額 <> 0 Then strSQL &= "," & sheet.Cells(rowloop, col割引金額).value & "" Else strSQL &= ",0"
                If col割引期間から <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, col割引期間から).value & "'" Else strSQL &= ",''"
                If col割引期間まで <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, col割引期間まで).value & "'" Else strSQL &= ",''"

                strSQL &= ",now(),now()"
                strSQL &= ",'" & UserName & "')"

                ClassPostgeDB.EXEC_tr(strSQL)

                rowloop = rowloop + 1
                FormMeter.GEN = rowloop
                FormMeter.Disp()
                System.Windows.Forms.Application.DoEvents()
            End While
            ClassPostgeDB.Commit()
            FormMeter.CLos()
            excelApp.Visible = False

            Using f As New Form()
                f.TopMost = True            ' 親フォームを常に最前面に表示する
                MessageBox.Show("登録完了しました")
                f.TopMost = False
            End Using


        Catch ex As Exception
            ClassPostgeDB.Rollback()
            FormMeter.CLos()
            excelApp.Visible = False
            Using f As New Form()
                f.TopMost = True            ' 親フォームを常に最前面に表示する
                MessageBox.Show(ex.Message & vbCrLf & rowloop & "行目エラーです。ロールバックしました")
                f.TopMost = False
            End Using
        End Try

        ClassPostgeDB.DbClose()

        excelApp.Quit()
        Marshal.ReleaseComObject(excelApp)
        Marshal.ReleaseComObject(excelBooks)

    End Sub

    Private Sub クーポン番号で削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles クーポン番号で削除ToolStripMenuItem.Click
        Dim cpno As String
        Dim strSQL As String
        Dim ret As String


        cpno = InputBox("削除するクーポン番号を入力してください", "削除", "", 200, 100)
        If cpno.Length > 0 Then
            strSQL = "SELECT count(*) FROM " & schema & "m_coupon where couponno= '" & cpno & "';"
            ret = ClassPostgeDB.DbSel(strSQL)

            Dim result As DialogResult = MessageBox.Show(ret & "件　削除しますか？",
                                             "削除",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)

            If result = vbYes Then
                strSQL = "DELETE FROM " & schema & "m_coupon WHERE couponno='" & cpno & "' "
                ClassPostgeDB.EXEC(strSQL)
                'Me.TextBoxクーポン番号.Text = ""
                Call 検索(Me.ComboBoxJy1, "couponno", Me.TextBoxクーポン番号)
            End If

        End If
    End Sub

    Private Sub 期間一括修正ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 期間一括修正ToolStripMenuItem.Click

        FormMstcouponSub1.CpNo = Me.TextBoxクーポン番号.Text
        FormMstcouponSub1.kikan1 = Me.DateTimePicker期間1.Value
        FormMstcouponSub1.kikan2 = Me.DateTimePicker期間2.Value

        FormMstcouponSub1.UserID = UserID
        FormMstcouponSub1.UserName = UserName
        FormMstcouponSub1.Kengen = Kengen

        FormMstcouponSub1.ShowDialog()
        Call 検索(Me.ComboBoxJy1, "couponno", Me.TextBoxクーポン番号)


    End Sub
End Class