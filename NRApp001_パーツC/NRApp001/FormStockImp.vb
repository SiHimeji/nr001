Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class FormStockImp

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
    Public Sub SetGenzaiko(sinacd As String, kosuu As String, flg As String)
        Dim strSQL As String
        Dim ret As String
        'Dim moto As Integer
        'Dim kousin As Integer


        strSQL = "SELECT genzaiko FROM " & schema & "t_genzaiko where sinacd = '" & sinacd & "'"

        ret = ClassPostgeDB.DbSel(strSQL)

        If ret = "" Then
            strSQL = "INSERT INTO " & schema & "t_genzaiko (sinacd, jyutyuu, tyuuzan, entry_day, entry_sya, genzaiko , ecflg) VALUES('" & sinacd & "', 0, 0, now(), '" & UserName & "', " & kosuu & ",'" & flg & "')"

        Else
            'moto = Integer.Parse(ret)
            'kousin = Integer.Parse(kosuu)
            'moto = moto + kousin

            strSQL = "UPDATE " & schema & "t_genzaiko SET entry_day = now() , entry_sya = '" & UserName & "',  genzaiko = '" & kosuu & "',ecflg = '" & flg & "'  WHERE sinacd='" & sinacd & "'"

        End If


        ClassPostgeDB.EXEC(strSQL)
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click


        GetIniFile()
        Me.TextBoxFileName.Text = Filesentaku(StockFolder)
        StockFolder = Me.TextBoxFileName.Text

    End Sub

    Private Sub Button取り込み_Click(sender As Object, e As EventArgs) Handles Button取り込み.Click
        Dim sinacd As String
        Dim syohinmei As String
        Dim zaiko As String

        Dim vari As String
        Dim uketukeflg As String
        Dim yoyakuflg As String
        Dim yukouflg As String

        Dim kousinbi As String
        Dim torikomibi As String

        Dim strSQL As String
        Dim rw As Int16
        Dim fastseq As String


        If Me.TextBoxFileName.Text <> "" Then
            SetIniFile()
            Me.LabelMSG.Text = "取り込み開始"
            System.Windows.Forms.Application.DoEvents()

            strSQL = "DELETE from " & schema & "t_goodsstock"
            ClassPostgeDB.EXEC(strSQL)

            strSQL = "UPDATE " & schema & "t_genzaiko set genzaiko = 0 , ecflg = '0'"
            ClassPostgeDB.EXEC(strSQL)
            strSQL = "DELETE FROM " & schema & "t_genzaiko where genzaiko =0 and jyutyuu =0 and tyuuzan =0"
            ClassPostgeDB.EXEC(strSQL)

            'strSQL = "UPDATE t_genzaiko SET genzaiko=0 , entry_day=now(), entry_sya='" & UserName & "'"
            'ClassPostgeDB.EXEC(strSQL)

            Using parser As New TextFieldParser(Me.TextBoxFileName.Text,
                                            Encoding.GetEncoding("Shift_JIS"))
                ' カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")

                ' フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
                ' フィールドの空白トリム設定
                parser.TrimWhiteSpace = False

                ' ファイルの終端までループ
                rw = 0


                While Not parser.EndOfData
                    ' フィールドを読込
                    Dim row As String() = parser.ReadFields()

                    If rw = 0 Then
                        If row.Length <> 7 Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(0).ToString <> "商品コード" Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(1).ToString <> "商品名" Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(2).ToString <> "バリエーション文字列" Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(3).ToString <> "在庫数" Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(4).ToString <> "入荷お知らせ受付フラグ" Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(5).ToString <> "予約商品フラグ" Then
                            MessageBox.Show("ファイルが違います")
                            Return
                        End If
                        If row(6).ToString <> "予約商品自動有効化フラグ" Then
                            MessageBox.Show("ファイルが違います")
                            Return

                        End If
                    Else
                        Try

                            sinacd = row(0).ToString           '商品コード
                            syohinmei = row(1).ToString        '商品名
                            vari = row(2).ToString            'バリエーション文字列

                            zaiko = row(3).ToString          '現在庫
                            If zaiko.Trim.ToString = "" Then
                                zaiko = "0"
                            End If

                            uketukeflg = row(4).ToString       '
                            yoyakuflg = row(5).ToString        '
                            yukouflg = row(6).ToString         '

                            kousinbi = Now().ToString           ''最終更新日時
                            torikomibi = Now().ToString         '取り込み日

                            fastseq = ClassPostgeDB.DbSel("SELECT nextval('" & schema & "seqstock')")

                            strSQL = "INSERT INTO " & schema & "t_goodsstock(sinacd, syouhinmie, vari, zaiko, uketukeflg, yoyakuflg, yukouflg, kousinbi, torikomibi, seq, flg)VALUES("
                            strSQL &= " '" & sinacd & "'"
                            strSQL &= ",'" & syohinmei & "'"
                            strSQL &= ",'" & vari & "'"
                            strSQL &= ",'" & zaiko & "'"
                            strSQL &= ",'" & uketukeflg & "'"
                            strSQL &= ",'" & yoyakuflg & "'"
                            strSQL &= ",'" & yukouflg & "'"
                            strSQL &= ",'" & kousinbi & "'"
                            strSQL &= ",'" & torikomibi & "'"
                            strSQL &= ",'" & fastseq & "'"
                            strSQL &= ",'0'"

                            strSQL &= ")"

                            ClassPostgeDB.EXEC(strSQL)

                            SetGenzaiko(sinacd, zaiko, "1")

                        Catch ex As Exception
                            MessageBox.Show("取り込みエラーです")
                            Return
                        End Try
                    End If
                    rw = rw + 1
                    Me.LabelMSG.Text = rw.ToString & "件　取り込み"
                    System.Windows.Forms.Application.DoEvents()

                End While
                '
                '
                MessageBox.Show(rw.ToString + "件取り込みました")
                If logent(UserID, UserName, "5") Then

                End If
                Me.Close()
            End Using
        End If
    End Sub

    Private Sub FormStockImp_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub FormStockImp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "5") Then

        End If

    End Sub
End Class