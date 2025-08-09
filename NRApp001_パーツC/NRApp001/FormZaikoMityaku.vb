Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class FormZaikoMityaku
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

    Private Sub FormZaikoMityaku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.RowHeadersVisible = False
        DataGridView2.RowHeadersVisible = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView2.AllowUserToAddRows = False

    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown

        If (e.Control) Then
            If (e.KeyValue = Keys.V) Then
                paset(Me.DataGridView1)
            End If
        End If
    End Sub
    Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView2.KeyDown
        If (e.Control) Then
            If (e.KeyValue = Keys.V) Then
                paset(Me.DataGridView2)
            End If
        End If
    End Sub

    Private Sub paset(grd As DataGridView)
        'クリップボードの内容を取得して、行で分ける
        Dim pasteText As String = Clipboard.GetText()
        If String.IsNullOrEmpty(pasteText) Then
            Return
        End If
        grd.DataSource = Nothing
        grd.Rows.Clear()

        'pasteText = pasteText.Replace(vbCrLf, "")
        pasteText = pasteText.Replace(vbCr, "")
        pasteText = pasteText.TrimEnd(New Char() {vbLf})
        Dim lines As String() = pasteText.Split(vbLf)

        Dim isHeader As Boolean = True

        For Each line As String In lines
            '列ヘッダーならば飛ばす
            grd.Rows.Add(line)

        Next line
        grd.AllowUserToAddRows = False
    End Sub

    Private Sub 取り込みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取り込みToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count <> Me.DataGridView2.Rows.Count Then
            MessageBox.Show("品コードと未入庫数の数が違います")
            Return
        End If
        Dim ro As Integer
        Dim strSQL As String
        Dim dt As DataTable
        Dim jyutyuusuu As Integer

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            strSQL = "select sinacd , COALESCE(jyutyuusuu,0)  from " & schema & "t_idou_zaiko SET "
            strSQL &= " where sinacd = '" & DataGridView1.Rows(ro).Cells(0).Value.ToString & "'"
            dt = ClassPostgeDB.SetTable(strSQL)

            If dt.Rows.Count > 0 Then

                jyutyuusuu = Integer.Parse(dt.Rows(0).Item(1).ToString()) + Integer.Parse(DataGridView2.Rows(ro).Cells(0).Value.ToString)

                strSQL = "UPDATE " & schema & "t_idou_zaiko SET "
                strSQL &= " jyutyuusuu =" & jyutyuusuu & ""
                strSQL &= ", updateday= now()"
                strSQL &= ",   updatesya= '" & UserName & "'"
                strSQL &= " where sinacd = '" & DataGridView1.Rows(ro).Cells(0).Value.ToString & "'"
                ClassPostgeDB.EXEC(strSQL)
            Else

                strSQL = "select  sinacd ,kijunzaiko ,ruuru ,kobetu ,inputkbn ,seihinmei  from " & schema & "m_seihin where sinacd = '" & DataGridView1.Rows(ro).Cells(0).Value.ToString & "'"
                dt = ClassPostgeDB.SetTable(strSQL)
                If dt.Rows.Count > 0 Then

                    strSQL = "INSERT INTO " & schema & "t_idou_zaiko(sinacd, zaikosuu,entryday,entrysya, sinamei)VALUES("
                    strSQL &= "'" & dt.Rows(0).Item(0).ToString & "'"
                    strSQL &= ",0"
                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",'エビスマートに在庫なし'"
                    strSQL &= ")"

                    ClassPostgeDB.EXEC(strSQL)

                    strSQL = "UPDATE  " & schema & "t_idou_zaiko  SET "

                    strSQL &= "  kijunnzaiko = " & dt.Rows(0).Item(1).ToString & ""

                    If dt.Rows(0).Item(3).ToString = "1" Then
                        strSQL &= " , ruuru  = '個別'"
                    ElseIf dt.Rows(0).Item(2).ToString <> "" Then
                        strSQL &= " , ruuru  = '" & dt.Rows(0).Item(2).ToString & "'"
                    Else
                        strSQL &= " , ruuru  = ''"
                    End If
                    strSQL &= " , souko  = '" & dt.Rows(0).Item(4).ToString & "'"
                    strSQL &= " , sinamei  = '" & dt.Rows(0).Item(5).ToString & "'"

                    strSQL &= " , bikou  = 'エビスマートに在庫なし'"

                    strSQL &= " , updateday  = now()"
                    strSQL &= " , updatesya   = '" & UserName & "'"

                    strSQL &= " where sinacd ='" & dt.Rows(0).Item(0).ToString & "'"
                    ClassPostgeDB.EXEC(strSQL)

                End If
            End If

        Next
        strSQL = "update  " & schema & "t_idou_zaiko set  hojyusuu = COALESCE(kijunnzaiko,0)- COALESCE(zaikosuu,0) - COALESCE(jyutyuusuu,0)"
        ClassPostgeDB.EXEC(strSQL)
        strSQL = "update  " & schema & "t_idou_zaiko set  hojyusuu = 0 where hojyusuu <0"
        ClassPostgeDB.EXEC(strSQL)
        MessageBox.Show("未入庫登録完了しました")
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing


        objWorkBook.Sheets(1).Cells(1, 1) = "品コード"
        objWorkBook.Sheets(1).Cells(1, 2) = "数"

        For i As Integer = 1 To Me.DataGridView1.Rows.Count - 1
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(i, 1) = DataGridView1.Rows(i).Cells(0).Value
            objWorkBook.Sheets(1).Cells(i, 2) = DataGridView2.Rows(i).Cells(0).Value

            ' 罫線を設定
            'objWorkBook.Sheets(1).Cells(1, i + 1).Borders.LineStyle = True
        Next


        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing

    End Sub

    Private Sub クリアToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles クリアToolStripMenuItem.Click
        Dim strSQL As String
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView2.Rows.Clear()

        strSQL = "UPDATE  " & schema & "t_idou_zaiko  SET jyutyuusuu =0"
        ClassPostgeDB.EXEC(strSQL)

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick


    End Sub
End Class