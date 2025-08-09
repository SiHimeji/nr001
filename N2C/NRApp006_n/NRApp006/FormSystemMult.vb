Public Class FormSystemMult


    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        SystemMsg = Me.TextBoxMSG.Text
        Me.Close()
    End Sub

    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        Me.Close()

    End Sub

    Private Sub FormSystemMult_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextBoxMSG.Text = SystemMsg

    End Sub
End Class