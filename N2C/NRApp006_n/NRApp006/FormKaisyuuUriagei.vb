Public Class FormKaisyuuUriagei
    Dim strFDM As String = String.Empty
    Dim strLDM As String = String.Empty

    Dim ClassPostgeDB As New ClassPostgeDB

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

    '-----------------------------------  未使用　-------------------------------
    Private Sub FormKaisyuuUriagei_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy年MM月"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy年MM月"

    End Sub
    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("出力するデータがありません。")
            Exit Sub
        End If

        excelOutDataGred4(Me.DataGridView1, False, Me.ToolStripProgressBar1, 4)

    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click

        kensaku()

    End Sub

    Private Sub kensaku()
        Dim strSQL As String
        Dim ro As Integer
        Dim dt As DataTable
        Dim st As DateTime
        Dim en As DateTime

        'Me.Cursor = Cursors.WaitCursor

        st = DateTime.Parse(Me.DateTimePicker1.Value)
        en = DateTime.Parse(Me.DateTimePicker2.Value)

        If st > en Then
            MessageBox.Show("売上月期間が正しくありません")
            Exit Sub
        End If

        '今月の最初の日
        Dim dtFDM As New DateTime(st.Year, st.Month, 1)
        strFDM = dtFDM.ToString("yyyy/MM/dd")
        '今月の最後の日
        Dim dtLDM As DateTime = New DateTime(en.Year, en.Month, 1).AddMonths(1).AddDays(-1)
        strLDM = dtLDM.ToString("yyyy/MM/dd")

        strSQL = "select "
        strSQL &= "A1.cst_cd                        as ""得意先コード"", "
        strSQL &= "("
        strSQL &= " select sum(cast(A2.upri as numeric)) "
        strSQL &= " from " & schema & " t_002 as A2 "
        strSQL &= " Left outer join " & schema & " t_kaisyu as B2 on A2.uketukeno = B2.uketukeno And A2.out_flg ='1' "
        strSQL &= " where A2.cst_cd = A1.cst_cd and "
        strSQL &= " ( A2.nextb between '" & strFDM & "' and '" & strLDM & "' ) and B2.入金日 is null group by A2.cst_cd "
        strSQL &= " )                               as ""未入金"","
        strSQL &= "("
        strSQL &= " select sum(cast(A3.upri as numeric)) "
        strSQL &= " from " & schema & " t_002 as A3 "
        strSQL &= " Left outer join " & schema & " t_kaisyu as B3 on A3.uketukeno = B3.uketukeno And A3.out_flg ='1' "
        strSQL &= " where A3.cst_cd = A1.cst_cd and "
        strSQL &= " ( A3.nextb between '" & strFDM & "' and '" & strLDM & "' ) and B3.入金日 is not null group by A3.cst_cd "
        strSQL &= " )                               as ""入金済み"","
        strSQL &= "sum(cast(A1.upri as numeric))    as ""回収金額"" "
        strSQL &= " from " & schema & "t_002 as A1"
        strSQL &= " left outer join " & schema & "t_kaisyu as B1 on A1.uketukeno  = B1.uketukeno AND A1.out_flg ='1'"
        strSQL &= " where ( A1.nextb between '" & strFDM & "' and '" & strLDM & "') group by A1.cst_cd order by A1.cst_cd"

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "得意先コード", "得意先コード", 100, True)    '0
        ro = settextColumn(Me.DataGridView1, ro, "未入金", "未入金", 120, True)                '1
        ro = settextColumn(Me.DataGridView1, ro, "入金済み", "入金済", 120, True)              '2
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 120, True)            '3

        Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '未入金
        Me.DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '入金済み
        Me.DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight    '回収金額

        Me.DataGridView1.Columns(1).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(2).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"


        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        'Me.Cursor = Cursors.Default

    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub
End Class