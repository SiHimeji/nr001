Public Class FormMain

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


    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " Version[" & Ver & "] "
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報 & vAsm.v説明

        Me.管理ToolStripMenuItem.Visible = True
        Me.ToolStripMenuItem不備内容マスタ.Visible = True

        If Kengen = 0 Then

            Me.ユーザーToolStripMenuItem.Visible = True
            Me.更新ToolStripMenuItem.Visible = False
            Me.システムマスタToolStripMenuItem.Visible = True

            If UserID = "SYSTEM" Then
                Me.SQLToolStripMenuItem.Visible = True
            Else
                Me.SQLToolStripMenuItem.Visible = False
            End If
            Me.ログ表示ToolStripMenuItem.Visible = True

        Else

            Me.ユーザーToolStripMenuItem.Visible = False
            Me.システムマスタToolStripMenuItem.Visible = False
            Me.SQLToolStripMenuItem.Visible = False

            Me.更新ToolStripMenuItem.Visible = False

            Me.ToolStripMenuItem2.Visible = True

            Me.ログ表示ToolStripMenuItem.Visible = False

        End If
        GetBtnColorDT()

    End Sub


    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click

        If Logent(UserID, UserName, "0") Then
            If UserID <> "SYSTEM" And Kengen = "0" Then
                LogDelete()
            End If
        End If
        If Application.OpenForms.Count = 2 Then
            'Me.Close()
            Application.Exit()
        Else
            MessageBox.Show("画面を全て閉じてください")
        End If

    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
    Private Sub Button入力_Click(sender As Object, e As EventArgs) Handles Button入力.Click
        If Logent(UserID, UserName, "2") Then
            FormCSV.UserID = UserID
            FormCSV.Kengen = Kengen
            FormCSV.UserName = UserName
            FormCSV.Show()
            FormCSV.Activate()
        End If

    End Sub

    Private Sub Buttonチェック_Click(sender As Object, e As EventArgs) Handles Buttonチェック.Click
        If Logent(UserID, UserName, "3") Then
            FormCheck.UserID = UserID
            FormCheck.Kengen = Kengen
            FormCheck.UserName = UserName
            FormCheck.Show()
            FormCheck.Activate()
        End If

    End Sub

    Private Sub Button売上管理_Click(sender As Object, e As EventArgs) Handles Button売上管理.Click
        If Logent(UserID, UserName, "4") Then
            FormUriage.UserID = UserID
            FormUriage.Kengen = Kengen
            FormUriage.UserName = UserName
            FormUriage.Show()
            FormUriage.Activate()
        End If

    End Sub

    Private Sub Button請求管理_Click(sender As Object, e As EventArgs) Handles Button請求管理.Click
        If Logent(UserID, UserName, "5") Then
            FormSeikyu.UserID = UserID
            FormSeikyu.Kengen = Kengen
            FormSeikyu.UserName = UserName
            FormSeikyu.Show()
            FormSeikyu.Activate()
        End If

    End Sub

    Private Sub システムマスタToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles システムマスタToolStripMenuItem.Click
        If Logent(UserID, UserName, "6") Then
            FormMstSystem.UserID = UserID
            FormMstSystem.UserName = UserName
            FormMstSystem.Kengen = Kengen
            FormMstSystem.ShowDialog()
            GetBtnColorDT()
        End If

    End Sub

    Private Sub ユーザーToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ユーザーToolStripMenuItem.Click
        If Logent(UserID, UserName, "7") Then
            FormMstUser.UserID = UserID
            FormMstUser.UserName = UserName
            FormMstUser.Kengen = Kengen
            FormMstUser.ShowDialog()
        End If

    End Sub

    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click
        FormSQL.ShowDialog()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click
        Dim Fm As New FormMsg()
        Fm.StartPosition = FormStartPosition.CenterScreen
        Fm.ShowDialog()

    End Sub


    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

        If Logent(UserID, UserName, "10") Then
            FormPass.UserID = UserID
            FormPass.UserName = UserName
            FormPass.Kengen = Kengen
            FormPass.ShowDialog()
        End If

    End Sub

    Private Sub Button出庫管理_Click(sender As Object, e As EventArgs) Handles Button出庫管理.Click

        If Logent(UserID, UserName, "8") Then
            Form002.UserID = UserID
            Form002.Kengen = Kengen
            Form002.UserName = UserName
            Form002.Show()
            Form002.Activate()
        End If

    End Sub

    Private Sub StatusStrip1_MouseClick(sender As Object, e As MouseEventArgs) Handles StatusStrip1.MouseClick
        Dim Fm As New FormMsg()
        Fm.StartPosition = FormStartPosition.CenterScreen
        Fm.ShowDialog()
    End Sub

    Private Sub 不備ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 不備ToolStripMenuItem.Click
        If Logent(UserID, UserName, "9") Then
            '  Form不備.UserID = UserID
            ' Form不備.Kengen = Kengen
            'Form不備.UserName = UserName
            'Form不備.ShowDialog()
        End If

    End Sub

    Private Sub 技術ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 技術ToolStripMenuItem.Click
        If Logent(UserID, UserName, "12") Then
            'FormGijyutuUp.UserID = UserID
            'FormGijyutuUp.Kengen = Kengen
            'FormGijyutuUp.UserName = UserName
            'FormGijyutuUp.ShowDialog()
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button物件管理.Click

        If Logent(UserID, UserName, "11") Then
            Form物件管理.UserID = UserID
            Form物件管理.Kengen = Kengen
            Form物件管理.UserName = UserName
            Form物件管理.Show()
            Form物件管理.Activate()
        End If
    End Sub


    Private Sub Button点検チェック_Click(sender As Object, e As EventArgs) Handles Button点検チェック.Click
        If Logent(UserID, UserName, "13") Then
            FormTenkenMenu.UserID = UserID
            FormTenkenMenu.Kengen = Kengen
            FormTenkenMenu.UserName = UserName
            FormTenkenMenu.Show()
        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        If Logent(UserID, UserName, "15") Then
            FormMstComento.UserID = UserID
            FormMstComento.Kengen = Kengen
            FormMstComento.UserName = UserName
            FormMstComento.ShowDialog()
        End If


    End Sub

    Private Sub ToolStripMenuItem不備内容マスタ_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem不備内容マスタ.Click
        'ToolStripMenuItem不備内容マスタ
        If Logent(UserID, UserName, "14") Then
            FormMstFubinaiyou.UserID = UserID
            FormMstFubinaiyou.Kengen = Kengen
            FormMstFubinaiyou.UserName = UserName
            FormMstFubinaiyou.Show()
            FormMstFubinaiyou.Activate()
        End If

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If Logent(UserID, UserName, "16") Then
            FormMSTfubinaiyou2.UserID = UserID
            FormMSTfubinaiyou2.Kengen = Kengen
            FormMSTfubinaiyou2.UserName = UserName
            FormMSTfubinaiyou2.Show()
            FormMSTfubinaiyou2.Activate()
        End If
    End Sub

    Private Sub ログ表示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ログ表示ToolStripMenuItem.Click
        FormLog.ShowDialog()
    End Sub

    Private Sub Button入力_MouseEnter(sender As Object, e As EventArgs) Handles Button入力.MouseEnter
        Button入力.BackColor = GetBtnColorDT("点検集約データ")
    End Sub

    Private Sub Button入力_MouseLeave(sender As Object, e As EventArgs) Handles Button入力.MouseLeave
        Button入力.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub Buttonチェック_MouseEnter(sender As Object, e As EventArgs) Handles Buttonチェック.MouseEnter
        Buttonチェック.BackColor = GetBtnColorDT("点検チェック")
    End Sub

    Private Sub Buttonチェック_MouseLeave(sender As Object, e As EventArgs) Handles Buttonチェック.MouseLeave
        Buttonチェック.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub Button請求管理_MouseEnter(sender As Object, e As EventArgs) Handles Button請求管理.MouseEnter
        Button請求管理.BackColor = GetBtnColorDT("請求管理")
    End Sub

    Private Sub Button請求管理_MouseLeave(sender As Object, e As EventArgs) Handles Button請求管理.MouseLeave
        Button請求管理.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub Button売上管理_MouseEnter(sender As Object, e As EventArgs) Handles Button売上管理.MouseEnter
        Button売上管理.BackColor = GetBtnColorDT("売上管理")
    End Sub

    Private Sub Button売上管理_MouseLeave(sender As Object, e As EventArgs) Handles Button売上管理.MouseLeave
        Button売上管理.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub Button出庫管理_MouseEnter(sender As Object, e As EventArgs) Handles Button出庫管理.MouseEnter
        Button出庫管理.BackColor = GetBtnColorDT("出庫管理")
    End Sub

    Private Sub Button出庫管理_MouseLeave(sender As Object, e As EventArgs) Handles Button出庫管理.MouseLeave
        Button出庫管理.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub Button物件管理_MouseEnter(sender As Object, e As EventArgs) Handles Button物件管理.MouseEnter
        Button物件管理.BackColor = GetBtnColorDT("物件管理")
    End Sub

    Private Sub Button物件管理_MouseLeave(sender As Object, e As EventArgs) Handles Button物件管理.MouseLeave
        Button物件管理.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub Button点検チェック_MouseEnter(sender As Object, e As EventArgs) Handles Button点検チェック.MouseEnter
        Button点検チェック.BackColor = GetBtnColorDT("品質チェック")
    End Sub

    Private Sub Button点検チェック_MouseLeave(sender As Object, e As EventArgs) Handles Button点検チェック.MouseLeave
        Button点検チェック.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub Button回収管理_Click(sender As Object, e As EventArgs) Handles Button回収管理.Click

        If Logent(UserID, UserName, "30") Then
            FormKaisyuMenu.UserID = UserID
            FormKaisyuMenu.Kengen = Kengen
            FormKaisyuMenu.UserName = UserName
            FormKaisyuMenu.Show()
        End If
    End Sub

    Private Sub Button承認_Click(sender As Object, e As EventArgs) Handles Button承認.Click

        If Logent(UserID, UserName, "25") Then
            FormSyouNin.UserID = UserID
            FormSyouNin.Kengen = Kengen
            FormSyouNin.UserName = UserName
            FormSyouNin.Show()
            FormSyouNin.Activate()
        End If
    End Sub

    Private Sub ButtonRIreki_Click(sender As Object, e As EventArgs) Handles ButtonRIreki.Click

        FormRirekiSyusei.UserID = UserID
        FormRirekiSyusei.Kengen = Kengen
        FormRirekiSyusei.UserName = UserName
        FormRirekiSyusei.Show()
        FormRirekiSyusei.Activate()
    End Sub
End Class
