Public Class FormKaisyuMenu
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

    '---------------------------
    '回収管理メニュー
    '---------------------------
    Private Sub FormKaisyuMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button回収管理_Click(sender As Object, e As EventArgs) Handles Button回収管理.Click
        Dim FormKaisyuukanri As New FormKaisyuukanri

        FormKaisyuukanri.UserID = UserID
        FormKaisyuukanri.Kengen = Kengen
        FormKaisyuukanri.UserName = UserName
        FormKaisyuukanri.Show()
        FormKaisyuukanri.Activate()

    End Sub

    Private Sub Button入金連絡票_Click(sender As Object, e As EventArgs) Handles Button入金連絡票.Click
        Dim FormKaisyuuNyukin = New FormKaisyuuNyukin
        FormKaisyuuNyukin.UserID = UserID
        FormKaisyuuNyukin.Kengen = Kengen
        FormKaisyuuNyukin.UserName = UserName
        FormKaisyuuNyukin.Show()
        FormKaisyuuNyukin.Activate()

    End Sub

    Private Sub Button残明細出力_Click(sender As Object, e As EventArgs) Handles Button残明細出力.Click
        Dim FormKaisyuuZanmeisai = New FormKaisyuuZanmeisai()
        FormKaisyuuZanmeisai.UserID = UserID
        FormKaisyuuZanmeisai.Kengen = Kengen
        FormKaisyuuZanmeisai.UserName = UserName
        FormKaisyuuZanmeisai.Show()
        FormKaisyuuZanmeisai.Activate()


    End Sub

    Private Sub Button得意先別売上_Click(sender As Object, e As EventArgs) 
        Dim FormKaisyuuUriagei = New FormAPSyouhiZei()
        FormKaisyuuUriagei.UserID = UserID
        FormKaisyuuUriagei.Kengen = Kengen
        FormKaisyuuUriagei.UserName = UserName
        FormKaisyuuUriagei.Show()
        FormKaisyuuUriagei.Activate()

    End Sub

    Private Sub Buttonss請求取込み_Click(sender As Object, e As EventArgs) Handles Buttonss請求取込み.Click
        Dim FormKaisyuuSSTorikomi = New FormKaisyuuSSTorikomi()
        FormKaisyuuSSTorikomi.UserID = UserID
        FormKaisyuuSSTorikomi.Kengen = Kengen
        FormKaisyuuSSTorikomi.UserName = UserName
        FormKaisyuuSSTorikomi.Show()
        FormKaisyuuSSTorikomi.Activate()
    End Sub

    Private Sub Button安心プラン消費税_Click(sender As Object, e As EventArgs) Handles Button安心プラン消費税.Click
        Dim FormAPSyouhiZei = New FormAPSyouhiZei()
        FormAPSyouhiZei.UserID = UserID
        FormAPSyouhiZei.Kengen = Kengen
        FormAPSyouhiZei.UserName = UserName
        FormAPSyouhiZei.Show()
        FormAPSyouhiZei.Activate()
    End Sub
End Class