Public Class FormMstcouponSub1
    Dim ClassPostgeDB As New ClassPostgeDB

    Public CpNo As String
    Public kikan1 As String
    Public kikan2 As String

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


    Private Sub FormMstcouponSub1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBoxクーポン番号.Text = CpNo
        Me.DateTimePicker期間1.Value = kikan1
        Me.DateTimePicker期間2.Value = kikan2

    End Sub
    Private Sub Button一括更新_Click(sender As Object, e As EventArgs) Handles Button一括更新.Click
        Dim strSQL As String
        strSQL = "UPDATE  " & schema & "m_coupon"
        strSQL &= " SET kikanfrom='" & DateTime.Parse(DateTimePicker期間1.Text) & "' ,  kikanto='" & DateTime.Parse(DateTimePicker期間2.Text) & "' , update_day= now() , entry_sya= '" & UserName & "'"
        strSQL &= " WHERE couponno = '" & Me.TextBoxクーポン番号.Text & "' "
        ClassPostgeDB.EXEC(strSQL)
        Me.Close()

    End Sub

    Private Sub Button中止_Click(sender As Object, e As EventArgs) Handles Button中止.Click
        Me.Close()
    End Sub
End Class