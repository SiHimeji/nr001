Public Class FormLogin
    Dim dlver As String
    Dim exever As String
    Dim ClassPostgeDB As New ClassPostgeDB


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ''Me.Close()
        Application.Exit()
    End Sub

    Private Sub Entry()
        Dim strSQL As String
        Dim ct As String

        strSQL = "SELECT count(u_name) FROM " & schema & "m_user where UPPER(u_id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "' And  UPPER(u_pass) = '" & Me.TextBoxパスワード.Text.ToUpper.Trim & "'"
        ct = ClassPostgeDB.DbSel(strSQL)

        If ct = "1" Then

            strSQL = "SELECT u_name FROM " & schema & "m_user where UPPER(u_id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "' And  UPPER(u_pass) = '" & Me.TextBoxパスワード.Text.ToUpper.Trim & "'"
            FormMenu.UserName = ClassPostgeDB.DbSel(strSQL)

            strSQL = "SELECT u_kengen FROM " & schema & "m_user where UPPER(u_id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "' And  UPPER(u_pass) = '" & Me.TextBoxパスワード.Text.ToUpper.Trim & "'"

            FormMenu.Kengen = Strings.Left(ClassPostgeDB.DbSel(strSQL) & " ", 1)

            FormMenu.UserID = Me.TextBoxログイン.Text.ToUpper.Trim


            strSQL = "SELECT count(id)  FROM " & schema & "t_user_log WHERE UPPER(id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "'"
            ct = ClassPostgeDB.DbSel(strSQL)

            If ct = "0" Then
                If Logent(FormMenu.UserID, FormMenu.UserName, "1") Then

                    FormMenu.Show()
                    Me.Hide()
                End If
            Else
                MessageBox.Show(FormMenu.UserID & "は使用中です")
            End If
        Else
            MessageBox.Show("ID、パスワードが間違っているか、もしくは存在しません")
        End If
    End Sub

    Private Sub Buttonlogin_Click(sender As Object, e As EventArgs) Handles Buttonlogin.Click
        Entry()
    End Sub

    Private Sub TextBoxパスワード_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxパスワード.KeyDown

        If e.KeyCode = Keys.Enter Then
            Entry()
        End If
        If e.Alt And e.KeyCode = Keys.F1 Then
            FormUserLog.ShowDialog()

        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAsm()

        '        Me.Text = "パーツセンターシステム ログイン  [ " & GetVersion() & " ]" & " TEST Version"
        Me.Text = "パーツセンターシステム ログイン  [ " & Now_Var & " ]" & ""
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        VersionCHK()

    End Sub
    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub TextBoxログイン_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxログイン.KeyDown

        If e.Alt And e.KeyCode = Keys.F11 Then
            FormMenu.Kengen = "0"
            FormMenu.UserID = "SYSTEM"
            FormMenu.UserName = "SYSTEM"

            If Logent(FormMenu.UserID, FormMenu.UserName, "0") Then

            End If
            If Logent(FormMenu.UserID, FormMenu.UserName, "1") Then
                FormMenu.Show()
                Me.Hide()
            End If
        End If
        If e.Alt And e.KeyCode = Keys.F12 Then
            FormMenu.Kengen = "1"
            FormMenu.UserID = "SYSTEM"
            FormMenu.UserName = "SYSTEM"

            If Logent(FormMenu.UserID, FormMenu.UserName, "0") Then

            End If
            If Logent(FormMenu.UserID, FormMenu.UserName, "1") Then
                FormMenu.Show()
                Me.Hide()
            End If
        End If

        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean
            'Me.TextBoxパスワード.
            forward = e.Modifiers <> Keys.Shift
            ' タブオーダー順で次のコントロールにフォーカスを移動
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
        End If

    End Sub

    Private Sub FormLogin_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.TextBoxログイン.Text = ""
        Me.TextBoxパスワード.Text = ""
        Me.TextBoxログイン.Focus()
    End Sub
    Private Sub VersionCHK()
        Dim ApUp As New ClassTransV4()

        New_Var = GetDbVer()
        If New_Var <> Now_Var Then
            ApUp.TransExecV3()
        End If

    End Sub


End Class
