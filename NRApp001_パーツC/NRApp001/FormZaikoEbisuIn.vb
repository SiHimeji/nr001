Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection
Public Class FormZaikoEbisuIn
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
    Private Sub FormZaikoEbisuIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        GetIniFile()
        Me.TextBoxFileName1.Text = Filesentaku(ZaikoFolder)
        ZaikoFolder = Me.TextBoxFileName1.Text

    End Sub

    Private Sub Button取り込み_Click(sender As Object, e As EventArgs) Handles Button取り込み.Click
        If Me.TextBoxFileName1.Text <> "" Then
            Csv取り込み()
        End If
    End Sub

    Private Sub Csv取り込み()
        Dim c商品コード As String = -1
        Dim c在庫数 As String = -1

        Dim fileName As String = Me.TextBoxFileName1.Text
        Dim parser As TextFieldParser = New TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"))
        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(",") ' 区切り文字はコンマ

        Dim rowH As String() = parser.ReadFields() ' 1行読み込み
        Dim col As Integer = 0
        Dim strSQL As String

        For Each field As String In rowH
            If field.IndexOf("商品コード") <> -1 And c商品コード = -1 Then 'SAGAWA
                c商品コード = col
            End If
            If field.IndexOf("在庫数") <> -1 And c在庫数 = -1 Then
                c在庫数 = col
            End If
            col = col + 1
        Next
        If c商品コード < 0 Or c在庫数 < 0 Then
            MessageBox.Show("ファイルが違います")
            Return
        End If
        SetBer()
        strSQL = "DELETE FROM " & schema & "t_idou_zaiko "
        ClassPostgeDB.EXEC(strSQL)

        While Not parser.EndOfData
            Dim row As String() = parser.ReadFields() ' 1行読み込み

            Try
                strSQL = "INSERT INTO " & schema & "t_idou_zaiko(sinacd, zaikosuu,entryday,entrysya)VALUES("
                strSQL &= "'" & row(c商品コード) & "'"
                strSQL &= ",'" & chgSuji(row(c在庫数)) & "'"
                strSQL &= ",now()"
                strSQL &= ",'" & UserName & "'"
                strSQL &= ")"

                ClassPostgeDB.EXEC(strSQL)
                AddBer()

            Catch ex As Exception

            End Try
            AddBer()
        End While
        SetBer()
        Dim dt As DataTable
        Dim dtSeihin As DataTable

        strSQL = "select  sinacd  from " & schema & "t_idou_zaiko"
        dt = ClassPostgeDB.SetTable(strSQL)

        For Each dtrow In dt.Rows
            AddBer()
            strSQL = "select  sinacd ,kijunzaiko ,ruuru ,kobetu ,inputkbn ,seihinmei  from " & schema & "m_seihin where sinacd = '" & dtrow(0).ToString & "'"
            dtSeihin = ClassPostgeDB.SetTable(strSQL)
            If dtSeihin.Rows.Count > 0 Then

                strSQL = "UPDATE  " & schema & "t_idou_zaiko  SET "

                strSQL &= " kijunnzaiko = " & dtSeihin.Rows(0).Item(1).ToString & ""

                If dtSeihin.Rows(0).Item(3).ToString = "1" Then
                    strSQL &= " , ruuru  = '個別'"
                ElseIf dtSeihin.Rows(0).Item(2).ToString <> "" Then
                    strSQL &= " , ruuru  = '" & dtSeihin.Rows(0).Item(2).ToString & "'"
                Else
                    strSQL &= " , ruuru  = ''"
                End If

                strSQL &= " , souko  = '" & dtSeihin.Rows(0).Item(4).ToString & "'"
                strSQL &= " , sinamei  = '" & dtSeihin.Rows(0).Item(5).ToString & "'"


                strSQL &= " , updateday  = now()"
                strSQL &= " , updatesya   = '" & UserName & "'"

                strSQL &= " where sinacd ='" & dtSeihin.Rows(0).Item(0).ToString & "'"
                ClassPostgeDB.EXEC(strSQL)
                AddBer()

            End If
        Next
        AddBer()
        strSQL = "update  " & schema & "t_idou_zaiko set  hojyusuu = COALESCE(kijunnzaiko,0)- COALESCE(zaikosuu,0) - COALESCE(jyutyuusuu,0)"
        ClassPostgeDB.EXEC(strSQL)
        AddBer()
        strSQL = "update  " & schema & "t_idou_zaiko set  hojyusuu = 0 where hojyusuu <0"
        ClassPostgeDB.EXEC(strSQL)
        SetBer()

        MessageBox.Show("取り込み完了しました")

    End Sub
    Private Function chgSuji(s As String) As String
        s = System.Text.RegularExpressions.Regex.Replace(s, "[^0-9]", "")
        Return s
    End Function

    Private Sub SetBer()
        Me.ToolStripProgressBar1.Maximum = 100
        Me.ToolStripProgressBar1.Minimum = 0
        Me.ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub AddBer()
        Dim val = Me.ToolStripProgressBar1.Value
        val = val + 1
        If val > 100 Then
            SetBer()
        Else
            Me.ToolStripProgressBar1.Value = val
        End If
    End Sub

End Class