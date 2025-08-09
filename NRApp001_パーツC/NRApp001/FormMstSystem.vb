Public Class FormMstSystem

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

        strSQL = "SELECT kbn, seq, naiyou,naiyou2, bikou, entry_day, entry_sya FROM " & schema & "m_system where entry_day is not null"

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
        strSQL = strSQL & " order by kbn, seq, naiyou"

        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
    End Sub

    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "kbn", Me.TextBox区分)
        Clear("1")
    End Sub

    Private Sub Clear(sw As String)
        Select Case sw
            Case "1"
                Me.TextBox区分.Text = ""
            Case Else

                Me.TextBox区分.Text = ""

        End Select

        Me.TextBox内容２.Text = ""
        Me.TextBox備考.Text = ""
        Me.TextBox内容.Text = ""
        Me.TextBoxSEQ.Text = ""

    End Sub



    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click


        Dim strSQL As String
        Dim Ret
        If Me.TextBox区分.Text.Trim <> "" And Me.TextBoxSEQ.Text.TrimEnd.ToString <> "" And Me.TextBox内容.Text.TrimEnd.ToString <> "" Then

            strSQL = "SELECT count(kbn) FROM " & schema & "m_system WHERE  kbn ='" & Me.TextBox区分.Text.TrimEnd.ToString & "' and seq = '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "' and naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = "INSERT INTO " & schema & "m_system (kbn, seq, naiyou, naiyou2,bikou, entry_day,update_day, entry_sya) VALUES("
                strSQL &= " '" & Me.TextBox区分.Text.TrimEnd.ToString & "'"
                strSQL &= " ,'" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
                strSQL &= " ,'" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
                strSQL &= " ,'" & Me.TextBox内容２.Text.TrimEnd.ToString & "'"
                strSQL &= " ,'" & Me.TextBox備考.Text.TrimEnd.ToString & "'"
                strSQL &= " ,now()"
                strSQL &= " ,now()"
                strSQL &= " ,'" & UserName & "')"
            Else
                strSQL = "UPDATE " & schema & "m_system SET "
                strSQL &= " naiyou2 = '" & Me.TextBox内容２.Text.TrimEnd.ToString & "'"
                strSQL &= ",bikou = '" & Me.TextBox備考.Text.TrimEnd.ToString & "'"
                strSQL &= ",update_day = now() "
                strSQL &= ",entry_sya = '" & UserName & "'"
                strSQL &= " WHERE  kbn ='" & Me.TextBox区分.Text.TrimEnd.ToString & "' and seq = '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "' and naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
            End If

            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("更新しました")
                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Else
                MessageBox.Show("更新エラーです")
            End If

        End If

    End Sub
    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String

        strSQL = "DELETE FROM  " & schema & "m_system "
        strSQL &= " WHERE  kbn ='" & Me.TextBox区分.Text.TrimEnd.ToString & "' and seq = '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
        strSQL &= " and naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"

        ClassPostgeDB.EXEC(strSQL)
        Clear("")
        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

    End Sub
    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then

                Me.TextBox区分.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBoxSEQ.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBox内容.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                Me.TextBox内容２.Text = Me.DataGridView1.Rows(ro).Cells(3).Value
                Me.TextBox備考.Text = Me.DataGridView1.Rows(ro).Cells(4).Value
            Else
                Clear("")

            End If

            'MessageBox.Show(a)
        End If

    End Sub

    Private Sub FormMstSystem_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.DataGridView1.ReadOnly = True

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

    Private Sub FormMstSystem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class