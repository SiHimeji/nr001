Public Class FormMstUser

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

    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String

        strSQL = "SELECT u_name, u_id, u_pass, u_kengen , entry_day , entry_sya FROM " & schema & "m_user where entry_day is not null"

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
        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
    End Sub


    Private Sub Button検索1_Click(sender As Object, e As EventArgs) Handles Button検索1.Click
        Call 検索(Me.ComboBoxJy1, "u_name", Me.TextBox氏名)
        Clear("1")

    End Sub

    Private Sub Button検索2_Click(sender As Object, e As EventArgs) Handles Button検索2.Click
        Call 検索(Me.ComboBoxjy2, "u_id", Me.TextBoxログイン)
        Clear("2")

    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim strSQL As String
        Dim Ret
        If Me.TextBoxログイン.Text.Trim <> "" And Me.TextBoxパスワード.Text <> "" And Me.TextBox氏名.Text <> "" And Me.ComboBox権限.Text <> "" Then
            strSQL = "select count(u_id) from " & schema & "m_user where u_id ='" & Me.TextBoxログイン.Text.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = "INSERT INTO " & schema & "m_user (u_name, u_id, u_pass, u_kengen, entry_day,entry_sya) VALUES ("
                strSQL &= " '" & Me.TextBox氏名.Text.TrimEnd.ToString & "'"
                strSQL &= ",'" & Me.TextBoxログイン.Text.TrimEnd.ToString & "'"
                strSQL &= ",'" & Me.TextBoxパスワード.Text.TrimEnd.ToString & "" & "'"
                strSQL &= ",'" & Strings.Left(Me.ComboBox権限.Text.ToString & " ", 1) & "'"
                strSQL &= ",now()"
                strSQL &= ",'" & UserName & "')"
            Else
                strSQL = "UPDATE " & schema & "m_user set u_name = '" & Me.TextBox氏名.Text.TrimEnd.ToString & "'"
                strSQL &= ",u_pass = '" & Me.TextBoxパスワード.Text.TrimEnd.ToString & "'"
                strSQL &= ",u_kengen= '" & Me.ComboBox権限.Text.ToString & "'"
                strSQL &= ",update_day = now() "
                strSQL &= ",entry_sya = '" & UserName & "' where u_id = '" & Me.TextBoxログイン.Text.ToString & "'"
            End If
            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("更新しました")
                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
            Else
                MessageBox.Show("更新エラーです")
            End If
        Else
            MessageBox.Show("氏名・ID・パスワード・権限のいずれかが未設定です")
        End If

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click


        Dim strSQL As String
        Dim Ret
        If Me.TextBoxログイン.Text.Trim <> "" Then
            strSQL = "select count(u_id) from " & schema & "m_user where u_id ='" & Me.TextBoxログイン.Text.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = ""
            Else
                strSQL = "DELETE from " & schema & "m_user WHERE u_id = '" & Me.TextBoxログイン.Text.ToString & "'"
            End If
            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("削除しました")
                ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                Clear("")
            Else
                MessageBox.Show("更新エラーです")
            End If

        End If

    End Sub
    Private Sub Clear(sw As String)


        Select Case sw
            Case "1"
                'Me.TextBox氏名.Text = ""
                Me.TextBoxログイン.Text = ""
            Case "2"
                'Me.TextBox氏名.Text = ""
                Me.TextBoxログイン.Text = ""
            Case Else
                Me.TextBox氏名.Text = ""
                Me.TextBoxログイン.Text = ""
        End Select
        Me.TextBoxパスワード.Text = ""
        Me.ComboBox権限.SelectedIndex = -1
    End Sub



    Private Sub FormMstUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Me.StartPosition = FormStartPosition.CenterScreen

        strSQL = "select t.naiyou from " & schema & "m_system t where t.kbn ='1' order by seq"

        ClassPostgeDB.SetComboBox(Me.ComboBox権限, strSQL)

        Me.DataGridView1.ReadOnly = True

    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        Dim ro

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then

                Me.TextBox氏名.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBoxログイン.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBoxパスワード.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                SetComboBox(ComboBox権限, Me.DataGridView1.Rows(ro).Cells(3).Value)
            Else
                Clear("")



            End If

            'MessageBox.Show(a)
        End If

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
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

    Private Sub FormMstUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub
End Class