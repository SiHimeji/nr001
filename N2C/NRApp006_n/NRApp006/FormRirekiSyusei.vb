Public Class FormRirekiSyusei
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

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
    Private Sub FormRirekiSyusei_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateTimePickerFrom.Value = Now.ToString("yyyy") & "/01/01"
        Me.DateTimePickerTo.Value = Now

        disp()
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub disp()
        Dim strSQL As String = String.Empty

        strSQL &= "select *  from " & schema & "t_002  where uketukeno in ("
        strSQL &= "	select t.uketukeno  from " & schema & "t_002 t where t.sls_typ ='3'"
        strSQL &= " and  t.nextb between '" & Me.DateTimePickerFrom.Value.ToString("yyyy/MM/dd") & "' and '" & Me.DateTimePickerTo.Value.ToString("yyyy/MM/dd") & "'"
        strSQL &= " and t.nextb   Is Not null And t.nextb <>'' "
        strSQL &= ")"
        strSQL &= " order by uketukeno,nextb "

        Dim dt As DataTable

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = dt



    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        disp()
    End Sub
End Class