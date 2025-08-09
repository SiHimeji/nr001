Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Public Class FormOrdertorikomi
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

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click

        Me.Close()
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        GetIniFile()
        Me.TextBoxFileName1.Text = FilesentakuEXELS(ZaikoFolder)
        ZaikoFolder = Me.TextBoxFileName1.Text
        Me.Label件数.Text = "取り込みを押してください"
    End Sub


    Private Sub 取り込みSCV()

        Dim strSQL As String
        Dim ro As Integer
        Dim seq As String
        Dim sinacd As String
        Dim orderno As String
        Dim nyuukoyoteibi As String


        If Me.TextBoxFileName1.Text <> "" Then
            SetIniFile()
            Using parser As New TextFieldParser(Me.TextBoxFileName1.Text, Encoding.GetEncoding("Shift_JIS"))
                ' カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")
                ' フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
                ' フィールドの空白トリム設定
                parser.TrimWhiteSpace = False
                ' ファイルの終端までループ
                ro = 0
                While Not parser.EndOfData
                    ' フィールドを読込
                    Dim row As String() = parser.ReadFields()
                    Try

                        If ro > 1 Then

                            sinacd = row(0).ToString
                            orderno = row(1).ToString
                            nyuukoyoteibi = row(2).ToString



                            strSQL = "SELECT seq FROM " & schema & "t_zaiko where sinacd = '" & sinacd & "' where orderno is null order by update_day"

                            seq = ClassPostgeDB.DbSel(strSQL)

                            strSQL = "UPDATE " & schema & "t_zaiko SET"
                            strSQL &= " orderno = '" & orderno & "'"
                            If IsDate(nyuukoyoteibi, "yyyy/MM/dd") Then
                                strSQL &= " nyuukoyoteibi = '" & nyuukoyoteibi & "'"
                            Else
                                strSQL &= " nyuukoyoteibi = NULL"

                            End If

                            strSQL &= " where seq = '" & seq & "'"

                            ClassPostgeDB.EXEC(strSQL)


                        End If
                    Catch ex As Exception
                        MessageBox.Show("取り込みエラーです")
                        Return
                    End Try
                    ro = ro + 1
                    Me.Labelオーダー取り込み.Text = ro & "件　取り込み"
                    System.Windows.Forms.Application.DoEvents()

                End While
                Me.Labelオーダー取り込み.Text = ro & "件　取り込み完了"
                System.Windows.Forms.Application.DoEvents()
                MessageBox.Show(ro & "件　取り込み完了しました")

            End Using
        End If
    End Sub

    Private Sub 取り込みEXCEL()


        Dim excelApp As New Excel.Application()
        Dim excelBooks As Excel.Workbooks
        excelBooks = excelApp.Workbooks

        'Dim strPath As String
        Dim rowloop As Integer
        'Dim colloop As Integer
        Dim sinacd As String
        Dim hojyu As String
        Dim ordr As String
        Dim yotei As String
        Dim strSQL As String
        Dim seq As String

        Dim excelBook As Excel.Workbook = excelBooks.Open(Me.TextBoxFileName1.Text)
        Dim sheet As Excel.Worksheet = excelBook.Worksheets(1)

        Try
            excelApp.Visible = True
            rowloop = 2
            While sheet.Cells(rowloop, 4).value <> Nothing
                Try

                    sinacd = sheet.Cells(rowloop, 1).value

                    If sinacd = "" Then Exit While

                    hojyu = sheet.Cells(rowloop, 5).value
                    ordr = sheet.Cells(rowloop, 8).value
                    yotei = sheet.Cells(rowloop, 9).value

                    strSQL = "SELECT seq FROM " & schema & "t_zaiko where sinacd = '" & sinacd & "' and  goukei  = '" & hojyu & "' and orderno = '' and nyukobi is null order by update_day"

                    seq = ClassPostgeDB.DbSel(strSQL)

                        If seq <> "" Then
                        strSQL = "UPDATE " & schema & "t_zaiko SET"
                        strSQL &= " orderno = '" & ordr & "'"

                            If IsDate(yotei, "yyyy/MM/dd") Then
                                strSQL &= ", nyuukoyoteibi = '" & yotei & "'"
                            Else
                                strSQL &= ", nyuukoyoteibi = NULL"
                            End If

                            strSQL &= " where seq = '" & seq & "'"

                            ClassPostgeDB.EXEC(strSQL)

                        '現在庫更新
                        strSQL = "UPDATE " & schema & "t_genzaiko SET"
                        strSQL &= " jyutyuu = jyutyuu - " & hojyu
                        strSQL &= ", tyuuzan = tyuuzan + " & hojyu
                        strSQL &= " where sinacd = '" & sinacd & "'"
                        ClassPostgeDB.EXEC(strSQL)

                    Else
                        'MessageBox.Show("品コード:" & sinacd & "を更新するオーダーがありません")
                        'Exit While
                    End If

                Catch ex As Exception
                    MessageBox.Show("取り込みエラーです")
                    excelApp.Quit()
                    Return
                End Try
                Me.Label件数.Text = rowloop & "件取り込み"

                System.Windows.Forms.Application.DoEvents()
                rowloop = rowloop + 1
            End While


        Catch ex As Exception
            Throw ex
        Finally
            'オブジェクト解放
            excelApp.Quit()
        End Try

    End Sub



    Private Sub Button取り込み_Click(sender As Object, e As EventArgs) Handles Button取り込み.Click

        If Me.TextBoxFileName1.Text <> "" Then

            取り込みEXCEL()

        End If
    End Sub


    Private Sub FormOrdertorikomi_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    Private Sub FormOrdertorikomi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "5") Then

        End If

    End Sub

    Private Sub TextBoxFileName1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFileName1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class