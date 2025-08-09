Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.FileIO
Imports System.Windows.Forms
Imports System.Text

Public Class ClassSagawa

    Dim ClassPostgeDB As New ClassPostgeDB()

    Public Function GetFile(getName As String, getPath As String)
        Dim strMdbPathFile As String
        Dim ofd As New OpenFileDialog()

        '3.ファイルを開くを実行
        ofd.FileName = getName
        ofd.InitialDirectory = getPath
        '[ファイルの種類]に表示される選択肢を指定する
        ofd.Filter = "CSVファイル(*.CSV)|*.csv|EXCEL(*.xlsx)|*.xlsx|ファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        ofd.FilterIndex = 1
        'タイトルを設定する
        ofd.Title = "ファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then

            strMdbPathFile = ofd.FileName
        Else
            strMdbPathFile = ""
        End If

        Return strMdbPathFile
    End Function
    Private Sub SetBer()
        FormZanmeisai.ToolStripProgressBar1.Maximum = 100
        FormZanmeisai.ToolStripProgressBar1.Minimum = 0
        FormZanmeisai.ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub AddBer()
        Dim val = FormZanmeisai.ToolStripProgressBar1.Value
        val = val + 1
        If val > 100 Then
            SetBer()
        Else
            FormZanmeisai.ToolStripProgressBar1.Value = val
        End If
    End Sub

    Public Sub GetExcel(FileName As String)
        Dim excelApp As New Excel.Application()
        Dim excelBooks As Excel.Workbooks
        Dim colloop As Integer
        Dim rowloop As Integer

        Dim cお問い合せNo As Integer = -1
        Dim c代引金 As Integer = -1
        Dim c代引手数料 As Integer = -1

        Dim txt As String
        Dim strSQL As String

        excelBooks = excelApp.Workbooks
        Dim excelBook As Excel.Workbook = excelBooks.Open(FileName)
        Dim sheet As Excel.Worksheet = excelBook.Worksheets(1)

        Try
            colloop = 1
            While sheet.Cells(1, colloop).value <> Nothing
                txt = sheet.Cells(1, colloop).value

                If txt.IndexOf("お問い合せNo") <> -1 And cお問い合せNo = -1 Then
                    cお問い合せNo = colloop
                End If

                If txt.IndexOf("代引金") <> -1 And c代引金 = -1 Then
                    c代引金 = colloop
                End If

                If txt.IndexOf("代引手数料") <> -1 And c代引手数料 = -1 Then
                    c代引手数料 = colloop
                End If



                colloop = colloop + 1
            End While
            If cお問い合せNo < 0 Or c代引金 < 0 Or c代引手数料 < 0 Then
                MessageBox.Show("ファイルが違います")
                Return
            End If
            SetBer()

            rowloop = 2
            While sheet.Cells(rowloop, cお問い合せNo).value <> Nothing
                Try
                    If Chksuji(sheet.Cells(rowloop, cお問い合せNo).value) Then

                        strSQL = "DELETE FROM " & schema & "t_soufu_sagawa WHERE お問い合せno='" & sheet.Cells(rowloop, cお問い合せNo).value & "'"
                        ClassPostgeDB.EXEC(strSQL)

                        strSQL = "INSERT INTO " & schema & "t_soufu_sagawa(お問い合せno, 代引金, 代引手数料 , 更新日)VALUES("
                        strSQL &= "'" & sheet.Cells(rowloop, cお問い合せNo).value & "'"
                        strSQL &= ",'" & chgSuji(sheet.Cells(rowloop, c代引金).value) & "'"
                        strSQL &= ",'" & sheet.Cells(rowloop, c代引手数料).value & "'"
                        strSQL &= ",now()"
                        strSQL &= ")"

                        ClassPostgeDB.EXEC(strSQL)
                    End If

                Catch ex As Exception
                    excelApp.Visible = True
                    MessageBox.Show("取り込みエラーです")
                    excelApp.Quit()
                    Return
                End Try
                AddBer()
                rowloop = rowloop + 1
                System.Windows.Forms.Application.DoEvents()
            End While
            excelApp.Visible = True
            SetBer()

            Using f As New Form()
                f.TopMost = True ' 親フォームを常に最前面に表示する
                MessageBox.Show(f, "取り込み完了しました")
                f.TopMost = False
            End Using

        Catch ex As Exception
            Throw ex
        Finally
            'オブジェクト解放
            excelApp.Quit()
            Marshal.ReleaseComObject(excelApp)
            Marshal.ReleaseComObject(excelBooks)
        End Try


    End Sub

    Public Sub GetCSV(FileName As String)

        Dim cお問い合せNo As Integer = -1
        Dim c代引金 As Integer = -1
        Dim c代引手数料 As Integer = -1
        Dim strSQL As String

        Using parser As New TextFieldParser(FileName, System.Text.Encoding.GetEncoding("Shift_JIS"))
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",") ' 区切り文字はコンマ

            Dim rowH As String() = parser.ReadFields() ' 1行読み込み
            Dim col As Integer = 0
            For Each field As String In rowH
                If field.IndexOf("お問い合せNo") <> -1 And cお問い合せNo = -1 Then 'SAGAWA
                    cお問い合せNo = col
                End If
                If field.IndexOf("代引金") <> -1 And c代引金 = -1 Then
                    c代引金 = col
                End If
                If field.IndexOf("代引手数料") <> -1 And c代引手数料 = -1 Then
                    c代引手数料 = col
                End If
                col = col + 1
            Next
            If cお問い合せNo < 0 Or c代引金 < 0 Or c代引手数料 < 0 Then
                MessageBox.Show("ファイルが違います")
                Return
            End If

            SetBer()
            While Not parser.EndOfData
                Dim row As String() = parser.ReadFields() ' 1行読み込み

                Try
                    If Chksuji(row(cお問い合せNo)) Then
                        strSQL = "DELETE FROM " & schema & "t_soufu_sagawa WHERE お問い合せno='" & row(cお問い合せNo) & "'"
                        ClassPostgeDB.EXEC(strSQL)

                        strSQL = "INSERT INTO " & schema & "t_soufu_sagawa(お問い合せno, 代引金, 代引手数料 , 更新日)VALUES("
                        strSQL &= "'" & row(cお問い合せNo) & "'"
                        strSQL &= ",'" & chgSuji(row(c代引金)) & "'"
                        strSQL &= ",'" & row(c代引手数料) & "'"
                        strSQL &= ",now()"
                        strSQL &= ")"

                        ClassPostgeDB.EXEC(strSQL)
                    End If

                Catch ex As Exception

                End Try
                AddBer()
            End While
            SetBer()

            Using f As New Form()
                f.TopMost = True ' 親フォームを常に最前面に表示する
                MessageBox.Show(f, "取り込み完了しました")
                f.TopMost = False
            End Using
        End Using
    End Sub
    Private Function Chksuji(s As String) As Boolean
        '        Dim r As New System.Text.RegularExpressions.Regex(“^[a-zA-Z0-9]+$”)
        Dim r As New System.Text.RegularExpressions.Regex(“^[0-9.]+$”)
        If r.IsMatch(s) = False Then
            Chksuji = False
        Else
            Chksuji = True
        End If
    End Function

    Private Function chgSuji(s As String) As String

        s = System.Text.RegularExpressions.Regex.Replace(s, "[^0-9]", "")
        Return s

    End Function



End Class
