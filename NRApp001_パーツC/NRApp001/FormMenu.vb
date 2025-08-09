Public Class FormMenu
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
    Public Function chkForm(frm As String)
        Dim fm As String
        Dim i As Integer

        Dim message As String = "既に起動しています"
        Dim caption As String = ""
        Dim buttons As MessageBoxButtons = MessageBoxButtons.OK
        Dim icon As MessageBoxIcon = MessageBoxIcon.Exclamation
        Dim defaultBtn As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1

        For i = 0 To Application.OpenForms.Count - 1
            fm = Application.OpenForms.Item(i).Name
            If fm = frm Then
                MessageBox.Show(message, caption, buttons, icon, defaultBtn)
                Return True
            End If
        Next
        Return False

    End Function
    '-------------------------------------------------------------------------

    Private Sub ButtonShopBuhin_Click(sender As Object, e As EventArgs) Handles buttonShopBuhin.Click
        If Kengen = "0" Or Kengen = "1" Then
            'Dim Fm As New FormShop

            If chkForm("FormShop") Then Exit Sub

            FormShop.UserID = UserID
            FormShop.UserName = UserName
            FormShop.Kengen = Kengen
            If Logent(UserID, UserName, "2") Then
                '   FormShop.ShowDialog()
                FormShop.Show()
            End If
            'FormShop.Dispose()
        End If

    End Sub

    '    Private Sub buttonKataroguBuhin_Click(sender As Object, e As EventArgs)
    '   End Sub

    Private Sub ButtonBuhinTekigou_Click(sender As Object, e As EventArgs) Handles buttonBuhinTekigou.Click
        If Kengen = "0" Or Kengen = "1" Then
            If chkForm("FormKisyu") Then Exit Sub

            'Dim Fm As New FormKisyu
            FormKisyu.UserID = UserID
            FormKisyu.UserName = UserName
            FormKisyu.Kengen = Kengen
            If Logent(UserID, UserName, "3") Then
                'FormKisyu.ShowDialog()
                FormKisyu.Show()
            End If
            'FormKisyu.Dispose()
        End If
    End Sub

    Private Sub ButtonBuhinSpec_Click(sender As Object, e As EventArgs) Handles buttonBuhinSpec.Click
        'Dim Fm As New FormSpec
        If Kengen = "0" Or Kengen = "1" Then
            If chkForm("FormSpec") Then Exit Sub

            FormSpec.UserID = UserID
            FormSpec.UserName = UserName
            FormSpec.Kengen = Kengen
            If Logent(UserID, UserName, "4") Then
                'FormSpec.ShowDialog()
                FormSpec.Show()
            End If
            'FormSpec.Dispose()
        End If

    End Sub

    Private Sub ButtonZaiko_Click(sender As Object, e As EventArgs) Handles buttonZaiko.Click
        'Dim Fm As New FormZaiko
        If Kengen = "0" Or Kengen = "1" Then
            If chkForm("FormZaiko") Then Exit Sub

            FormZaiko.UserID = UserID
            FormZaiko.UserName = UserName
            FormZaiko.Kengen = Kengen
            If Logent(UserID, UserName, "50") Then
                FormZaiko.Show()
            End If
            'FormZaiko.Dispose()
        ElseIf Kengen = "2" Then
            If chkForm("FormZaiko2") Then Exit Sub
            FormZaiko2.UserID = UserID
            FormZaiko2.UserName = UserName
            FormZaiko2.Kengen = Kengen
            If Logent(UserID, UserName, "53") Then
                FormZaiko2.Show()
                'FormZaiko2.ShowDialog()
            End If
        End If

    End Sub

    Private Sub ButtonTOrikomi_Click(sender As Object, e As EventArgs) Handles ButtonTOrikomi.Click
        'Dim Fm As New FormUriage
        If Kengen = "0" Or Kengen = "1" Then
            If chkForm("FormUriage") Then Exit Sub
            FormUriage.UserID = UserID
            FormUriage.UserName = UserName
            FormUriage.Kengen = Kengen
            If Logent(UserID, UserName, "60") Then
                'FormUriage.ShowDialog()
                FormUriage.Show()
            Else
                FormUriage.Dispose()
            End If
        End If
    End Sub
    Private Sub ButtonTyouhyou_Click(sender As Object, e As EventArgs) Handles ButtonTyouhyou.Click
        'Dim Fm As New FormOUTPUT
        If Kengen = "0" Or Kengen = "1" Then
            If chkForm("FormOUTPUT") Then Exit Sub
            FormOUTPUT.UserID = UserID
            FormOUTPUT.UserName = UserName
            FormOUTPUT.Kengen = Kengen
            If logent(UserID, UserName, "7") Then
                FormOUTPUT.ShowDialog()
            End If
            FormOUTPUT.Dispose()
        End If
    End Sub
    Private Sub ButtonMaster_Click(sender As Object, e As EventArgs) Handles ButtonMaster.Click
        If Kengen = "0" Or Kengen = "1" Then
            If chkForm("FormMaster") Then Exit Sub
            'Dim Fm As New FormMaster
            FormMaster.UserID = UserID
            FormMaster.UserName = UserName
            FormMaster.Kengen = Kengen
            If Logent(UserID, UserName, "8") Then
                'FormMaster.ShowDialog()
                FormMaster.Show()
            End If
            'FormMaster.Dispose()
        End If
    End Sub
    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        'Dim dt = Now
        'Me.Text = " Club NORITZ (" & UserName & ") [" & GetVersion() & " ]"

        Me.LabelVer.Text = "" & UserName & "  Ver[" & Now_Var & " ]"

        Select Case (Kengen)
            Case "0" ''管理者
                Me.ButtonMaster.Text = "マスタ"
                Me.buttonShopBuhin.Text = "ショップ登録用部品"
                Me.buttonBuhinTekigou.Text = "部品適合機種"
                Me.buttonBuhinSpec.Text = "部品スペック"
                Me.buttonZaiko.Text = "在庫管理"
                Me.ButtonTOrikomi.Text = "売上処理"
                Me.ButtonTyouhyou.Text = "帳票出力"


            Case "1"
                Me.ButtonMaster.Text = "マスタ"
                Me.buttonShopBuhin.Text = "ショップ登録用部品"
                Me.buttonBuhinTekigou.Text = "部品適合機種"
                Me.buttonBuhinSpec.Text = "部品スペック"
                Me.buttonZaiko.Text = "在庫管理"
                Me.ButtonTOrikomi.Text = "売上処理"
                Me.ButtonTyouhyou.Text = "帳票出力"

            Case "2"
                Me.ButtonMaster.Text = ""
                Me.buttonShopBuhin.Text = ""
                Me.buttonBuhinTekigou.Text = ""
                Me.buttonBuhinSpec.Text = ""
                Me.buttonZaiko.Text = "在庫管理"
                Me.ButtonTOrikomi.Text = ""
                Me.ButtonTyouhyou.Text = ""

            Case "3"

        End Select
        'logent(UserID, UserID, "1")
    End Sub

    Private Sub パスワード変更ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles パスワード変更ToolStripMenuItem.Click
        If chkForm("FormPass") Then Exit Sub
        FormPass.UserID = UserID
        FormPass.UserName = UserName
        FormPass.Kengen = Kengen
        FormPass.ShowDialog()
        FormPass.Dispose()
    End Sub

    Private Sub LOGINToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGINToolStripMenuItem.Click
        Dim i As Integer
        Dim length As Integer = Application.OpenForms.Count

        Dim arr As String() = New String(length - 1) {}

        For i = 0 To length - 1
            arr(i) = Application.OpenForms.Item(i).Name
        Next
        For i = 0 To length - 1
            If arr(i) <> "FormLogin" And arr(i) <> "FormMenu" Then
                Application.OpenForms.Item(arr(i)).Close()
            End If
        Next
        Logent(UserID, UserName, "0")

        FormLogin.Show()
        Me.Hide()
        Me.Dispose()

    End Sub

    Private Sub ButtonEND_Click(sender As Object, e As EventArgs) Handles buttonEND.Click
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        'FormLogin.Dispose()

        If Application.OpenForms.Count = 2 Then

            Logent(UserID, UserName, "0")

            If UserID <> "SYSTEM" And Kengen = "0" Then
                strSQL = "DELETE FROM " & schema & "t_log WHERE entry_day < CURRENT_DATE - (select cast(naiyou as int) from " & schema & "m_system  where kbn ='99' and seq ='0')"
                ClassPostgeDB.EXEC(strSQL)
            End If
            Application.Exit()
        Else

            MessageBox.Show("画面を全て閉じてください")
        End If
    End Sub
    '×で閉じれないようにする
    Private Sub FormMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            MessageBox.Show("(^_^)V")
            e.Cancel = True
        End If
    End Sub

    Private Sub LabelVer_MouseClick(sender As Object, e As MouseEventArgs) Handles LabelVer.MouseClick
        Dim f As New FormMsg()
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub
End Class
