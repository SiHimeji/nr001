Public Class FormTenkenMenu
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

    Private Sub Button点検チェック_Click(sender As Object, e As EventArgs) Handles Button点検チェック.Click
        If Logent(UserID, UserName, "17") Then
            FormTenkenKekka.UserID = UserID
            FormTenkenKekka.Kengen = Kengen
            FormTenkenKekka.UserName = UserName
            FormTenkenKekka.Show()
        End If

    End Sub

    Private Sub Button点検結果表チェック数日計表_Click(sender As Object, e As EventArgs) Handles Button点検結果表チェック数日計表.Click
        If Logent(UserID, UserName, "18") Then
            FormTenkenToujitu.UserID = UserID
            FormTenkenToujitu.Kengen = Kengen
            FormTenkenToujitu.UserName = UserName
            FormTenkenToujitu.ShowDialog()
        End If

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'FormTenkenSaiHoumon.UserID = UserID
        ' FormTenkenSaiHoumon.Kengen = Kengen
        'FormTenkenSaiHoumon.UserName = UserName
        'FormTenkenSaiHoumon.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'FormTenkenALLChk.UserID = UserID
        'FormTenkenALLChk.Kengen = Kengen
        ' FormTenkenALLChk.UserName = UserName
        'FormTenkenALLChk.ShowDialog()

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'FormTenkenGetujiChk.UserID = UserID
        'FormTenkenGetujiChk.Kengen = Kengen
        'FormTenkenGetujiChk.UserName = UserName
        'FormTenkenGetujiChk.ShowDialog()

    End Sub

    Private Sub Button点検結果表チェック3_Click(sender As Object, e As EventArgs) Handles Button点検結果表チェック3.Click
        If Logent(UserID, UserName, "19") Then
            FormTenkenToujitu3.UserID = UserID
            FormTenkenToujitu3.Kengen = Kengen
            FormTenkenToujitu3.UserName = UserName
            FormTenkenToujitu3.ShowDialog()
        End If

    End Sub

    Private Sub Button点検結果表チェック不備_Click(sender As Object, e As EventArgs) Handles Button点検結果表チェック不備.Click
        If Logent(UserID, UserName, "20") Then
            FormTenkenGetuji.UserID = UserID
            FormTenkenGetuji.Kengen = Kengen
            FormTenkenGetuji.UserName = UserName
            FormTenkenGetuji.ShowDialog()
        End If

    End Sub

    Private Sub Button点検結果表チェック明細_Click(sender As Object, e As EventArgs) Handles Button点検結果表チェック明細.Click
        If Logent(UserID, UserName, "21") Then
            FormTenkenKekkaMeisai.UserID = UserID
            FormTenkenKekkaMeisai.Kengen = Kengen
            FormTenkenKekkaMeisai.UserName = UserName
            FormTenkenKekkaMeisai.ShowDialog()
        End If

    End Sub

    Private Sub Button点検チェック_MouseEnter(sender As Object, e As EventArgs) Handles Button点検チェック.MouseEnter
        Me.Button点検チェック.BackColor = GetBtnColorDT("チェック画面")
    End Sub

    Private Sub Button点検チェック_MouseLeave(sender As Object, e As EventArgs) Handles Button点検チェック.MouseLeave
        Me.Button点検チェック.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub Button点検結果表チェック数日計表_MouseEnter(sender As Object, e As EventArgs) Handles Button点検結果表チェック数日計表.MouseEnter
        Me.Button点検結果表チェック数日計表.BackColor = GetBtnColorDT("点検結果表チェック数日計表")
    End Sub

    Private Sub Button点検結果表チェック数日計表_MouseLeave(sender As Object, e As EventArgs) Handles Button点検結果表チェック数日計表.MouseLeave
        Me.Button点検結果表チェック数日計表.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub Button点検結果表チェック明細_MouseEnter(sender As Object, e As EventArgs) Handles Button点検結果表チェック明細.MouseEnter
        Me.Button点検結果表チェック明細.BackColor = GetBtnColorDT("点検結果表チェック明細")
    End Sub

    Private Sub Button点検結果表チェック明細_MouseLeave(sender As Object, e As EventArgs) Handles Button点検結果表チェック明細.MouseLeave
        Me.Button点検結果表チェック明細.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub Button点検結果表チェック3_MouseEnter(sender As Object, e As EventArgs) Handles Button点検結果表チェック3.MouseEnter
        Me.Button点検結果表チェック3.BackColor = GetBtnColorDT("点検結果表チェック「3」再訪問依頼リスト")
    End Sub

    Private Sub Button点検結果表チェック3_MouseLeave(sender As Object, e As EventArgs) Handles Button点検結果表チェック3.MouseLeave
        Me.Button点検結果表チェック3.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub Button点検結果表チェック不備_MouseEnter(sender As Object, e As EventArgs) Handles Button点検結果表チェック不備.MouseEnter
        Me.Button点検結果表チェック不備.BackColor = GetBtnColorDT("点検結果表チェック不備")
    End Sub

    Private Sub Button点検結果表チェック不備_MouseLeave(sender As Object, e As EventArgs) Handles Button点検結果表チェック不備.MouseLeave
        Me.Button点検結果表チェック不備.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub
End Class