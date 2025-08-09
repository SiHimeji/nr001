Public Class FormPass
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
    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        Me.Close()
    End Sub

    Private Sub FormPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBox氏名.Text = UserName
        Me.TextBoxログイン.Text = UserID
    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim ct As String

        strSQL = "SELECT u_name FROM " & schema & "m_user where UPPER(u_id) = '" & Me.TextBoxログイン.Text.ToUpper.Trim & "' And  UPPER(u_pass) = '" & Me.TextBox現パスワード.Text.ToUpper.Trim & "'"
        ct = ClassPostgeDB.DbSel(strSQL)
        If ct = UserName Then
            If Me.TextBox新パスワード１.Text.Trim = Me.TextBox新パスワード２.Text.Trim Then

                strSQL = "UPDATE " & schema & "m_user SET u_pass='" & Me.TextBox新パスワード１.Text.Trim & "', entry_sya='" & UserName & "', update_day=now() WHERE UPPER(u_id)='" & Me.TextBoxログイン.Text.ToUpper.Trim & "'"
                ClassPostgeDB.EXEC(strSQL)

                Me.Close()
            Else
                MessageBox.Show("新パスワードの再入力に違いがあります")
            End If
        Else
            MessageBox.Show("現パスワードが違います")
        End If
    End Sub
End Class