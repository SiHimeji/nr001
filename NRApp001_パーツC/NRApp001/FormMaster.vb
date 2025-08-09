Class FormMaster
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

    Private Sub DBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DBToolStripMenuItem.Click
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim msg As String

        msg = ""
        msg &= ClassPostgeDB.DbSel("select version()") & vbCrLf
        msg &= ClassPostgeDB.DbSel("select inet_client_addr()") & vbCrLf
        msg &= ClassPostgeDB.GetCone() & vbCrLf
        MessageBox.Show(msg)

    End Sub

    Private Sub Button製品マスタ_Click(sender As Object, e As EventArgs) Handles Button製品マスタ.Click
        ' Dim Fm As New FormMstSeihin
        If Kengen = "0" Or Kengen = "1" Then
            FormMstSeihin.UserID = UserID
            FormMstSeihin.UserName = UserName
            FormMstSeihin.Kengen = Kengen
            FormMstSeihin.ShowDialog()
            FormMstSeihin.Dispose()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim Fm As New FormMstUser
        If Kengen = "0" Then
            FormMstUser.UserID = UserID
            FormMstUser.UserName = UserName
            FormMstUser.Kengen = Kengen
            FormMstUser.ShowDialog()
            FormMstUser.Dispose()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Kengen = "0" Then
            'Dim Fm As New FormMstSystem
            FormMstSystem.UserID = UserID
            FormMstSystem.UserName = UserName
            FormMstSystem.Kengen = Kengen
            FormMstSystem.ShowDialog()
            FormMstSystem.Dispose()
        End If
    End Sub

    Private Sub Button基準在庫一括更新_Click(sender As Object, e As EventArgs)
        If Kengen = "0" Then
            ' Dim Fm As New FormMstKijunzaiko
            FormMstKijunzaiko.UserID = UserID
            FormMstKijunzaiko.UserName = UserName
            FormMstKijunzaiko.Kengen = Kengen
            FormMstKijunzaiko.ShowDialog()
            FormMstKijunzaiko.Dispose()
        End If
    End Sub

    Private Sub 期限ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 期限ToolStripMenuItem.Click
        If Kengen = "0" Then
            Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
            ' カレントディレクトリを表示する
            MessageBox.Show(stCurrentDir)
        End If
    End Sub

    Private Sub ButtonLog_Click(sender As Object, e As EventArgs) Handles ButtonLog.Click
        If Kengen = "0" Then
            Dim Fm As New FormUserLog
            Fm.ShowDialog()
            Fm.Dispose()
        End If
    End Sub

    Private Sub オーダーToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles オーダーToolStripMenuItem.Click
        Dim ClassPostgeDB As New ClassPostgeDB

        MessageBox.Show(ClassPostgeDB.DbSel("SELECT ""last_value"" FROM " & schema & "seqorder") & "番")

    End Sub

    Private Sub 在庫ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 在庫ToolStripMenuItem.Click
        Dim ClassPostgeDB As New ClassPostgeDB
        MessageBox.Show(ClassPostgeDB.DbSel("SELECT ""last_value"" FROM " & schema & "seqzaiko") & "番")
    End Sub

    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click
        'Dim Fm As New FormSQL
        FormSQL.ShowDialog()
        FormSQL.Dispose()

    End Sub

    Private Sub FormMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "マスタ設定  "
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        If UserID = "SYSTEM" Then
            Me.SQLToolStripMenuItem.Visible = True
        Else
            Me.SQLToolStripMenuItem.Visible = False
        End If

        Select Case (Kengen)
            Case "0" ''管理者
                Me.Button1.Text = "ユーザーマスタ"
                Me.Button2.Text = "システムマスタ"
                Me.ButtonLog.Text = "LOG"

            Case "1"
                Me.Button1.Text = ""
                Me.Button2.Text = ""
                Me.ButtonLog.Text = ""
                Me.Buttonクーポン.Text = ""


            Case "2"
                Me.Button1.Text = ""
                Me.Button2.Text = ""
                Me.ButtonLog.Text = ""
                Me.Buttonクーポン.Text = ""

            Case "3"
                Me.Button1.Text = ""
                Me.Button2.Text = ""
                Me.ButtonLog.Text = ""
                Me.Buttonクーポン.Text = ""

        End Select

    End Sub

    Private Sub FormMaster_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub Buttonクーポン_Click(sender As Object, e As EventArgs) Handles Buttonクーポン.Click
        If Kengen = "0" Then
            FormMstcoupon.UserID = UserID
            FormMstcoupon.UserName = UserName
            FormMstcoupon.Kengen = Kengen
            FormMstcoupon.ShowDialog()
            FormMstcoupon.Dispose()
        End If
    End Sub

    Private Sub Button台数割引_Click(sender As Object, e As EventArgs) Handles Button台数割引.Click
        If Kengen = "0" Then
            FormMstDaisuWaribiki.UserID = UserID
            FormMstDaisuWaribiki.UserName = UserName
            FormMstDaisuWaribiki.Kengen = Kengen
            FormMstDaisuWaribiki.ShowDialog()
            FormMstDaisuWaribiki.Dispose()
        End If

    End Sub

    Private Sub Button構成マスタ_Click(sender As Object, e As EventArgs) Handles Button構成マスタ.Click

        FormMSTkousei.UserID = UserID
        FormMSTkousei.UserName = UserName
        FormMSTkousei.Kengen = Kengen
        FormMSTkousei.ShowDialog()
        FormMSTkousei.Dispose()

    End Sub
End Class