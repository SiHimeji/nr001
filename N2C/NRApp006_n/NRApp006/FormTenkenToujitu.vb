Public Class FormTenkenToujitu
    Dim ClassPostgeDB As New ClassPostgeDB()
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


    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Function SetSQL() As String
        Dim strSQL As String
        Dim yymm As String
        yymm = DateTime.ParseExact(Me.ToolStripComboBoxYYMM.Text & "01日", "yyyy年MM月dd日", Nothing).ToString("yyyyMM")

        strSQL = ""
        strSQL &= "select "
        strSQL &= " Zen.dy 日"
        strSQL &= " ,COALESCE(Zen.kazu,0) 品質チェック件数"
        strSQL &= " ,COALESCE(Furyo.kazu,0) 不備件数"
        strSQL &= " ,COALESCE(Saihoumon.kazu,0) 内再訪問件数"
        strSQL &= " ,COALESCE(Keibi.kazu,0) 内軽微"
        strSQL &= " ,CASE COALESCE(Furyo.kazu,0) WHEN 0 THEN 0"
        strSQL &= " else (cast(Furyo.kazu as float)/cast(Zen.kazu as float) ) * 100"
        strSQL &= " end 不備率"
        strSQL &= "  from "
        strSQL &= "  (select "
        strSQL &= "  to_char(t_check.チェック日,'dd') dy"
        strSQL &= "  ,count(*) kazu"
        strSQL &= "  from " & schema & "t_check"
        strSQL &= "  where to_char(t_check.チェック日,'yyyyMM')='" & yymm & "'"
        strSQL &= "  group by to_char(t_check.チェック日,'dd')"
        strSQL &= "  ) Zen"
        strSQL &= " left outer join "
        strSQL &= "  (select "
        strSQL &= "  to_char(t_check.チェック日,'dd') dy"
        strSQL &= "  ,count(*) kazu"
        strSQL &= "  from " & schema & "t_check"
        strSQL &= "  where to_char(t_check.チェック日,'yyyyMM')='" & yymm & "'"
        strSQL &= "  and   t_check.チェック <>'1'"
        strSQL &= "  group by to_char(t_check.チェック日,'dd')"
        strSQL &= "  ) Furyo on Zen.dy = Furyo.dy"
        strSQL &= "  left outer join "
        strSQL &= "  (select "
        strSQL &= "  to_char(t_check.チェック日,'dd') dy"
        strSQL &= "  ,count(*) kazu"
        strSQL &= "  from " & schema & "t_check"
        strSQL &= "  where to_char(t_check.チェック日,'yyyyMM')='" & yymm & "'"
        strSQL &= "  and   t_check.チェック ='3'"
        strSQL &= "  group by to_char(t_check.チェック日,'dd')"
        strSQL &= "  ) Saihoumon on Zen.dy = Saihoumon.dy"
        strSQL &= "  left outer join "
        strSQL &= "  (select "
        strSQL &= "  to_char(t_check.チェック日,'dd') dy"
        strSQL &= "  ,count(*) kazu"
        strSQL &= "  from " & schema & "t_check"
        strSQL &= "  where to_char(t_check.チェック日,'yyyyMM')='" & yymm & "'"
        strSQL &= " and   t_check.チェック ='2'"
        strSQL &= " group by to_char(t_check.チェック日,'dd')"
        strSQL &= " ) Keibi on Zen.dy = Keibi.dy"
        Return strSQL

    End Function



    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        Dim dt As DataTable
        Dim col As Integer
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        dt = ClassPostgeDB.SetTable(SetSQL())

        dt = SetSUM(dt)

        dt = DataTableSwapXY(dt, Me.ToolStripComboBoxYYMM.Text)

        Me.DataGridView1.DataSource = dt

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ReadOnly = True

        For Each c As DataGridViewColumn In Me.DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        For col = 1 To Me.DataGridView1.ColumnCount - 2
            Me.DataGridView1.Columns(col).HeaderText = Me.DataGridView1.Columns(col).HeaderText & "日"
        Next
        For col = 1 To Me.DataGridView1.ColumnCount - 1
            Me.DataGridView1.Rows(4).Cells(col).Value = Math.Round(Double.Parse(Me.DataGridView1.Rows(4).Cells(col).Value), 2, MidpointRounding.AwayFromZero).ToString & "%"
        Next
        Me.DataGridView1.Rows(0).HeaderCell.Value = "チェック総数"
        Me.DataGridView1.Rows(1).HeaderCell.Value = "不備総数"
        Me.DataGridView1.Rows(2).HeaderCell.Value = "技術不備数"

        'Me.DataGridView1.Columns(0).Frozen = False

        Me.DataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Private Function SetSUM(dt As DataTable) As DataTable
        Dim x As Integer
        Dim sousu As Double = 0
        Dim fubi As Double = 0
        Dim fubiritu As Double
        Dim fubi1 As Double = 0
        Dim fubi2 As Double = 0

        For x = 0 To dt.Rows.Count - 1
            sousu = sousu + Double.Parse(dt.Rows(x).Item(1).ToString)
            fubi = fubi + Double.Parse(dt.Rows(x).Item(2).ToString)

            fubi1 = fubi1 + Double.Parse(dt.Rows(x).Item(3).ToString)
            fubi2 = fubi2 + Double.Parse(dt.Rows(x).Item(4).ToString)

        Next

        fubiritu = (fubi / sousu) * 100
        dt.Rows.Add("合計", sousu, fubi, fubi1, fubi2, fubiritu)

        Return dt
    End Function




    Private Sub FormTenkenToujitu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim d As DateTime

        ToolStripComboBoxYYMM.Items.Clear()

        d = DateTime.Today
        For i As Integer = 1 To 13
            ToolStripComboBoxYYMM.Items.Add(d.ToString("yyyy年MM月"))
            d = d.AddMonths(-1)
        Next
        ToolStripComboBoxYYMM.SelectedIndex = 0
        Me.DataGridView1.DataSource = Nothing


    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count < 1 Then
            MsgBox("検索を行ってから出力してください", vbOKOnly, "警告")
            Return
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        excelOutDataGred3(Me.DataGridView1, True, Me.ToolStripProgressBar1)
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub ToolStripComboBoxYYMM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBoxYYMM.SelectedIndexChanged
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()



    End Sub
End Class