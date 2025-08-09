Public Class FormHaishi
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As StringAlignment
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

    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String

        strSQL = "SELECT sinacd,h_haisibi,h_entry_day,h_update_day FROM " & schema & "t_parts_center where h_entry_day is not null"
        Select Case Cob.Text
            Case "一致"
                strSQL = strSQL & " and " & jy & "  = '" & txt.Text.Trim.ToString & "'"
            Case "一部"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "%'"
            Case "前方"
                strSQL = strSQL & " and " & jy & " like '" & txt.Text.Trim.ToString & "%'"
            Case "後方"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "'"
        End Select

        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)
    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String
        strSQL = "update t_parts_center set h_haisibi = ''" _
                                            & ",h_entry_day ='' ,h_update_day = ''  where sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
        ClassPostgeDB.EXEC(strSQL)
        MessageBox.Show("削除しました")
    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim strSQL As String
        Dim Ret
        If Me.TextBox品コード.Text.Trim <> "" Then
            strSQL = "select count(sinacd) from " & schema & "t_parts_center where sinacd ='" & Me.TextBox品コード.Text.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = "insert into " & schema & "t_parts_center (sinacd ,h_haisibi , h_entry_day )VALUES(" _
                & " '" & Me.TextBox品コード.Text.ToString & "'" _
                & ",'" & Me.TextBox廃止日.Text.ToString & "'" _
                & ", now() )"
            Else
                strSQL = "update t_parts_center set h_haisibi = '" & Me.TextBox廃止日.Text.Trim.ToString & "'" _
                                            & ",h_update_day = now()  where sinacd = '" & Me.TextBox品コード.Text.ToString & "'"
            End If
            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("更新しました")
                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Else
                MessageBox.Show("更新エラーです")
            End If
        End If
    End Sub

    Private Sub FormHaishi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '        SQLiteClass.DbOpen(SQLiteCN)
    End Sub

    Private Sub FormHaishi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        '       SQLiteClass.DbClose(SQLiteCN)
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox廃止日.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
            End If
            'MessageBox.Show(a)
        End If

    End Sub
End Class