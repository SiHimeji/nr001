Public Class FormTenkenComment
    Dim ClassPostgeDB As New ClassPostgeDB

    Private Sub FormTenkenComment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disp()
    End Sub

    Private Sub disp()
        Dim strSQL As String
        Coment = "-"
        strSQL = "select naiyou  from " & schema & "m_system  where kbn ='110'  and bikou  ='" & 点検項目名 & "' order by seq"
        ClassPostgeDB.SetComboBox(Me.ComboBoxComent, strSQL)
        Me.ComboBoxComent.SelectedIndex = 0
        Coment = ""

    End Sub

    Private Sub ComboBoxComent_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxComent.SelectedValueChanged
        If Coment = "" Then
            Coment = Me.ComboBoxComent.Text
            Me.Close()
        End If
    End Sub

End Class