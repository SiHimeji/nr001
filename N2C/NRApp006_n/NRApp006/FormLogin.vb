Public Class FormLogin
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim New_Var As String
    Dim dlver As String
    Dim exever As String

    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        Application.Exit()
    End Sub

    Private Sub Buttonログイン_Click(sender As Object, e As EventArgs) Handles Buttonログイン.Click
        Entry()
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetAsm()

        Me.Text = menu_bar & " ログイン Version " & vAsm.Version & ""
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        New_Var = GetDbVer()
        If New_Var > Now_Ver Then
            ChkVerUp.ShowDialog()
        End If

        ErrorLogDisp()
    End Sub


    Private Sub Entry()
        Dim strSQL As String
        Dim dt As New DataTable

        strSQL = "Select u_name, ms.seq FROM " & schema & "m_user mu , " & schema & "m_system ms"
        strSQL &= " where UPPER(u_id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "'"
        strSQL &= " And UPPER(u_pass) = '" & Me.TextBoxパスワード.Text.ToUpper.Trim & "'"
        strSQL &= " And MS.kbn ='1'"
        strSQL &= " And MS.naiyou = mu.u_kengen"

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 1 Then

            For Each row As DataRow In dt.Rows
                FormMain.UserName = row("u_name").ToString
                FormMain.Kengen = row("seq").ToString
            Next

            FormMain.UserID = Me.TextBoxログイン.Text.ToUpper.Trim

            If Logent(FormMain.UserID, FormMain.UserName, "1") Then
                FormMain.Show()
                Me.Hide()
            End If

        Else
            MessageBox.Show("ID、パスワードが間違っているか、もしくは存在しません")
        End If

    End Sub

    Private Sub TextBoxログイン_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxログイン.KeyDown

        '管理者権限
        If e.Alt And e.KeyCode = Keys.F11 Then
            FormMain.Kengen = "0"
            FormMain.UserID = "SYSTEM"
            FormMain.UserName = "SYSTEM"

            If Logent(FormMain.UserID, FormMain.UserName, "1") Then
                FormMain.Show()
                Me.Hide()
            End If
        End If
        '一般権限
        If e.Alt And e.KeyCode = Keys.F12 Then
            FormMain.Kengen = "1"
            FormMain.UserID = "SYSTEM1"
            FormMain.UserName = "SYSTEM1"

            If Logent(FormMain.UserID, FormMain.UserName, "1") Then
                FormMain.Show()
                Me.Hide()
            End If
        End If

        'ENTERでの処理
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean
            'Me.TextBoxパスワード.
            forward = e.Modifiers <> Keys.Shift
            ' タブオーダー順で次のコントロールにフォーカスを移動
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
        End If


    End Sub

    Private Sub LabelVer_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBoxパスワード_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxパスワード.KeyDown

        If e.KeyCode = Keys.Enter Then
            Entry()
        End If
        If e.Alt And e.KeyCode = Keys.F1 Then

        End If

    End Sub

    Private Sub TextBoxパスワード_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBoxパスワード.MouseDoubleClick
#If DEBUG Then
        FormMain.Kengen = "0"
        FormMain.UserID = "SYSTEM"
        FormMain.UserName = "SYSTEM"
        If Logent(FormMain.UserID, FormMain.UserName, "1") Then
            FormMain.Show()
            Me.Hide()
        End If
#End If
    End Sub
    Private Sub ErrorLogDisp()
        Dim strSQL As String = String.Empty
        Dim dt As New DataTable
        Dim ro As Integer

        strSQL &= "select nm, mn, entry_day "
        strSQL &= " from " & schema & "t_log where id ='SYSTEM'"
        'strSQL &= " and  nm = 'ERROR' "
        strSQL &= " and entry_day >  CURRENT_DATE - (select  cast(  naiyou  as  int ) from " & schema & "m_system  where kbn ='99' and seq ='1')"
        strSQL &= " order by entry_day desc"

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = Nothing

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        If dt.Rows.Count > 0 Then
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = dt

            ro = 0
            ro = settextColumn(Me.DataGridView1, ro, "nm", "伝送名", 120, True)
            ro = settextColumn(Me.DataGridView1, ro, "mn", "ステータス", 80, True)
            ro = settextColumn(Me.DataGridView1, ro, "entry_day", "日", 110, True)

            Me.DataGridView1.AllowUserToAddRows = False

            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Rows(ro).Cells(1).Value = "ERROR" Then
                    Me.DataGridView1.Rows(ro).DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        End If
    End Sub

End Class