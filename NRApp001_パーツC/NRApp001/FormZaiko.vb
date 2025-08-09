Public Class FormZaiko
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


    Private Sub FormZaiko_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.FixedSingle

    End Sub
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormZaiko_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Logent(UserID, UserName, "5Z") Then
        End If

    End Sub

    Private Sub Button在庫管理_Click(sender As Object, e As EventArgs) Handles Button在庫管理.Click
        FormZaikoKanri.UserID = UserID
        FormZaikoKanri.UserName = UserName
        FormZaikoKanri.Kengen = Kengen
        FormZaikoKanri.ShowDialog()
        FormZaikoKanri.Dispose()


    End Sub

    Private Sub ButtonNextB_Click(sender As Object, e As EventArgs) Handles ButtonNextB.Click
        FormZaikoNextB.UserID = UserID
        FormZaikoNextB.UserName = UserName
        FormZaikoNextB.Kengen = Kengen
        FormZaikoNextB.ShowDialog()
        FormZaikoNextB.Dispose()

    End Sub

    Private Sub Button未着取り込み_Click(sender As Object, e As EventArgs) Handles Button未着取り込み.Click
        FormZaikoMityaku.UserID = UserID
        FormZaikoMityaku.UserName = UserName
        FormZaikoMityaku.Kengen = Kengen
        FormZaikoMityaku.ShowDialog()
        FormZaikoMityaku.Dispose()

    End Sub

    Private Sub ebisumart在庫取込_Click(sender As Object, e As EventArgs) Handles ebisumart在庫取込.Click
        FormZaikoEbisuIn.UserID = UserID
        FormZaikoEbisuIn.UserName = UserName
        FormZaikoEbisuIn.Kengen = Kengen
        FormZaikoEbisuIn.ShowDialog()
        FormZaikoEbisuIn.Dispose()

    End Sub
End Class