Public Class FormUserLogSub
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

    Private Sub Button中止_Click(sender As Object, e As EventArgs) Handles Button中止.Click
        Me.Close()

    End Sub

    Private Sub Buttonログアプト_Click(sender As Object, e As EventArgs) Handles Buttonログアプト.Click
        Dim strSQL As String
        strSQL = "DELETE FROM " & schema & "t_user_log WHERE id='" & UserID & "' "
        ClassPostgeDB.EXEC(strSQL)
        MessageBox.Show("ログアウト処理を行いました")
    End Sub

    Private Sub Buttonorder_Click(sender As Object, e As EventArgs) Handles Buttonorder.Click
        Dim strSQL As String
        strSQL = "UPDATE " & schema & "t_user_log SET ordr='0' WHERE id='" & UserID & "' "
        ClassPostgeDB.EXEC(strSQL)
        MessageBox.Show("オーダー処理を解除行いました")

    End Sub

    Private Sub ButtonNextB_Click(sender As Object, e As EventArgs) Handles ButtonNextB.Click
        Dim strSQL As String
        strSQL = "UPDATE " & schema & "t_user_log SET nextb='0'  WHERE id='" & UserID & "' "
        ClassPostgeDB.EXEC(strSQL)
        MessageBox.Show("NEXT-B処理を解除行いました")

    End Sub
End Class