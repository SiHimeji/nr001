Public Class FormUriage002
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim _nentuki As String = String.Empty
    Dim _SinaCd As String = String.Empty
    Dim _AkaKuro As String = String.Empty

    Public Property AkaKuro As String
        Get
            AkaKuro = _AkaKuro
        End Get
        Set(value As String)
            _AkaKuro = value
        End Set
    End Property

    Public Property SinaCd As String
        Get
            SinaCd = _SinaCd
        End Get
        Set(value As String)
            _SinaCd = value
        End Set
    End Property
    Public Property Nentuki As String
        Get
            Nentuki = _nentuki
        End Get
        Set(value As String)
            _nentuki = value
        End Set
    End Property

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

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormUriage002_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "  売り上げ年" & Nentuki & "　品コード" & SinaCd
        Disp()
    End Sub
    Private Sub Disp()
        Dim strSQL As String = String.Empty
        Dim ro As Integer
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim dt As New DataTable

        strSQL = ""
        strSQL &= "select "
        strSQL &= " t.cst_cd"
        strSQL &= ",t.scst_nm"
        strSQL &= ",t.ord_psn_nm"
        strSQL &= ",t.slip_rmrks"
        strSQL &= ",t.cst_po_no "
        strSQL &= ",t.nextb"
        strSQL &= ",t.upri"
        strSQL &= " from tenken.t_002 t"
        strSQL &= "  where LEFT(t.nextb,7) = '" & Nentuki & "'"
        strSQL &= "  and  t.cst_cd  ='" & SinaCd & "'"
        If AkaKuro = "1" Then
            strSQL &= "  and  t.sls_typ  = '1'"
        End If
        If AkaKuro = "3" Then
            strSQL &= "  and  t.sls_typ  = '3'"
        End If

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt


        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "cst_cd", "品コード", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "scst_nm", "品コード名", 140, True)
        ro = settextColumn(Me.DataGridView1, ro, "ord_psn_nm", "会社名", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "slip_rmrks", "氏名", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "cst_po_no", "受付ＮＯ", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "nextb", "売り上げ日", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "upri", "金額", 80, True)


        Me.DataGridView1.AllowUserToAddRows = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 0)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If

    End Sub
End Class