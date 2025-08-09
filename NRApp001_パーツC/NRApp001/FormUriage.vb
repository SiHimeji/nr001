Public Class FormUriage
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

    Private Sub Button販売実績_Click(sender As Object, e As EventArgs) Handles Button販売実績.Click
        'Dim Fm As New FormHanbaiJisseki
        FormHanbaiJisseki.UserID = UserID
        FormHanbaiJisseki.UserName = UserName
        FormHanbaiJisseki.Kengen = Kengen
        If logent(UserID, UserName, "61") Then
            FormHanbaiJisseki.ShowDialog()
        End If
        FormHanbaiJisseki.Dispose()
    End Sub

    Private Sub Button伝票画面_Click(sender As Object, e As EventArgs) Handles Button伝票画面.Click
        'Dim Fm As New FormDenpyou
        FormDenpyou.UserID = UserID
        FormDenpyou.UserName = UserName
        FormDenpyou.Kengen = Kengen
        If logent(UserID, UserName, "63") Then
            FormDenpyou.ShowDialog()
        End If
        FormDenpyou.Dispose()

    End Sub

    Private Sub ButtonNEXTB伝票番号_Click(sender As Object, e As EventArgs) Handles ButtonNEXTB伝票番号.Click
        'Dim Fm As New FormNext_B
        FormNext_B.UserID = UserID
        FormNext_B.UserName = UserName
        FormNext_B.Kengen = Kengen
        If logent(UserID, UserName, "62") Then
            FormNext_B.ShowDialog()
        End If
        FormNext_B.Dispose()
    End Sub

    Private Sub FormUriage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

    End Sub

    Private Sub 画面ToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub FormUriage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "6Z") Then

        End If

    End Sub

    Private Sub Buttonキャンセル引当待品_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル引当待品.Click
        FormMzaiko.UserID = UserID
        FormMzaiko.UserName = UserName
        FormMzaiko.Kengen = Kengen
        If Logent(UserID, UserName, "64") Then
            FormMzaiko.ShowDialog()
        End If
        FormMzaiko.Dispose()

    End Sub

    Private Sub Button残明細_Click(sender As Object, e As EventArgs) Handles Button残明細.Click

        FormZanmeisai.UserID = UserID
        FormZanmeisai.UserName = UserName
        FormZanmeisai.Kengen = Kengen
        If Logent(UserID, UserName, "65") Then
            FormZanmeisai.ShowDialog()
        End If
        FormZanmeisai.Dispose()

    End Sub
End Class