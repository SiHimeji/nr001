Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class FormMstKijunzaiko

    Dim ClassPostgeDB As New ClassPostgeDB
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
        Me.TextBoxFileName.Text = Filesentaku(OrderFolder)
        OrderFolder = Me.TextBoxFileName.Text

    End Sub

    Private Sub Button取込み_Click(sender As Object, e As EventArgs) Handles Button取込み.Click
        Dim rw As Int16
        Dim SelSinacd As String
        Dim sinacd As String
        Dim kazu As String
        Dim strSQL As String
        Dim Msg As String

        If Me.TextBoxFileName.Text <> "" Then
            Msg = ""
            SetIniFile()
            Me.LabelMSG.Text = "取り込み開始"
            System.Windows.Forms.Application.DoEvents()

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
                    Try
                        If rw >= 0 Then
                            sinacd = row(0).ToString
                            kazu = row(1).ToString
                            strSQL = "SELECT sinacd FROM " & schema & "m_seihin WHERE  sinacd = '" & sinacd.Trim & "'"
                            SelSinacd = ClassPostgeDB.DbSel(strSQL)
                            If SelSinacd = sinacd Then
                                If IsNumeric(kazu) = False Then
                                    kazu = "0"
                                End If
                                strSQL = "UPDATE " & schema & "m_seihin SET  update_day =now() , entry_sya='" & UserName & "' , kijunzaiko='" & kazu.Trim & "' WHERE  sinacd= '" & sinacd.Trim & "'"
                                ClassPostgeDB.EXEC(strSQL)
                            Else

                                Msg = Msg & sinacd & vbCr
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show(Msg & "　の品コードが存在しませんでした")
                    End Try
                    rw = rw + 1
                End While
                If Msg <> "" Then
                    MessageBox.Show(Msg & "　の品コードが存在しませんでした")
                End If
            End Using
        End If
    End Sub

    Private Sub FormMstKijunzaiko_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    Private Sub FormMstKijunzaiko_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub
End Class