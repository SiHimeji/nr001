Public Class FormZanmeisai

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

    Private Sub FormZanmeisai_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 取り込み一覧ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DIspIn()

    End Sub
    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub DIspIn()
        Dim ro As Integer = 0
        Dim strSQL As String
        Dim dt As DataTable

        strSQL = ""
        strSQL &= "select t_ebisu.宅配伝票番号 ,t_ebisu.受注番号 ,t_uriage.ord_no ,t_sagawa.代引金 ,t_sagawa.代引手数料 ,t_uriage.goukei , t_uriage.tesuuryou  "
        strSQL &= " from " & schema & "t_sagawa ," & schema & "t_ebisu ," & schema & "t_uriage "
        strSQL &= " where  t_sagawa.お問い合せno = t_ebisu.宅配伝票番号 "
        strSQL &= " and t_ebisu.受注番号 = t_uriage.intr_rmrks "
        strSQL &= " and  t_ebisu.flg ='0'"
        strSQL &= " union "
        strSQL &= " select t_ebisu.宅配伝票番号 ,t_ebisu.受注番号 ,t_uriage.ord_no ,t_sagawa.代引金 ,t_sagawa.代引手数料 ,t_uriage.goukei , t_uriage.tesuuryou "
        strSQL &= " from " & schema & "t_sagawa ," & schema & "t_ebisu ," & schema & "t_uriage "
        strSQL &= " where  t_sagawa.お問い合せno = t_ebisu.宅配伝票番号 "
        strSQL &= " and t_ebisu.受注番号 = t_uriage.cst_po_no  "
        strSQL &= " and  t_ebisu.flg ='0'"


        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = SettextColumn(Me.DataGridView1, ro, "宅配伝票番号", "宅配伝票番号", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "受注番号", "受注番号", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "ord_no", "オーダー番号", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "代引金", "代引金", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "代引手数料", "代引手数料", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "goukei", "合計", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "tesuuryou", "手数料", 100, True, DataGridViewContentAlignment.MiddleRight)

        Me.DataGridView1.AllowUserToAddRows = False

    End Sub


    Private Sub Kousin()
        Dim strSQL As String
        Me.ToolStripProgressBar1.Maximum = 12
        Me.ToolStripProgressBar1.Value = 0

        Try
            strSQL = "update " & schema & "t_uriage set nyukinn ='1' where t_uriage.intr_rmrks  in (select a.受注番号  from " & schema & "t_ebisu_sagawa a," & schema & "t_soufu_sagawa b where  b.お問い合せno = a.宅配伝票番号 and a.flg ='0') and nyukinn ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 1

            strSQL = "update " & schema & "t_uriage set nyukinn ='1' where t_uriage.cst_po_no   in (select a.受注番号  from " & schema & "t_ebisu_sagawa a," & schema & "t_soufu_sagawa b where  b.お問い合せno = a.宅配伝票番号 and a.flg ='0') and nyukinn ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 2

            strSQL = "update " & schema & "t_uriage set nyukinn ='1' where t_uriage.intr_rmrks  in (select a.受注番号  from " & schema & "t_ebisu_smbc a," & schema & "t_soufu_smbc b where b.受注id =a.決済連携id  and a.flg ='0') and nyukinn ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 3

            strSQL = "update " & schema & "t_uriage set nyukinn ='1' where t_uriage.cst_po_no   in (select a.受注番号  from " & schema & "t_ebisu_smbc a," & schema & "t_soufu_smbc b where b.受注id =a.決済連携id and a.flg ='0') and nyukinn ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 4

            strSQL = "update " & schema & "t_uriage set nyukinn ='1' where t_uriage.intr_rmrks  in (select a.受注番号  from " & schema & "t_ebisu_np  a," & schema & "t_soufu_np  b where  b.加盟店取引id = a.決済連携id and a.flg ='0' ) and nyukinn ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 5

            strSQL = "update " & schema & "t_uriage set nyukinn ='1' where t_uriage.cst_po_no   in (select a.受注番号  from " & schema & "t_ebisu_np  a," & schema & "t_soufu_np  b where  b.加盟店取引id = a.決済連携id  and a.flg ='0') and nyukinn ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 6

            strSQL = "update " & schema & "t_ebisu_sagawa set flg ='1' where 受注番号 in (select intr_rmrks from " & schema & "t_uriage where nyukinn ='1') and  flg ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 7

            strSQL = "update " & schema & "t_ebisu_sagawa set flg ='1' where 受注番号 in (select cst_po_no from " & schema & "t_uriage where nyukinn ='1') and  flg ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 8

            strSQL = "update " & schema & "t_ebisu_smbc set flg ='1' where 受注番号 in (select intr_rmrks from " & schema & "t_uriage where nyukinn ='1') and  flg ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 9

            strSQL = "update " & schema & "t_ebisu_smbc set flg ='1' where 受注番号 in (select cst_po_no from " & schema & "t_uriage where nyukinn ='1') and  flg ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 10

            strSQL = "update " & schema & "t_ebisu_np set flg ='1' where 受注番号 in (select intr_rmrks from " & schema & "t_uriage where nyukinn ='1') and  flg ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 11

            strSQL = "update " & schema & "t_ebisu_np set flg ='1' where 受注番号 in (select cst_po_no from " & schema & "t_uriage where nyukinn ='1') and  flg ='0';"
            ClassPostgeDB.EXEC(strSQL)
            Me.ToolStripProgressBar1.Value = 12

            MessageBox.Show("更新しました")
            Me.ToolStripProgressBar1.Value = 0

        Catch ex As Exception
            MessageBox.Show("更新エラーです")
            Me.ToolStripProgressBar1.Value = 0

        End Try
    End Sub



    Private Sub Button_sagawa_ebisu_Click(sender As Object, e As EventArgs) Handles Button_sagawa_ebisu.Click

        'ebisuデータの入力
        Dim ClassEBISU As New ClassEBISU()
        Dim filename As String = ClassEBISU.GetFile("", "")
        If filename = "" Then
            Return
        End If
        If filename.IndexOf(".xlsx") = -1 Then
            Cursor.Current = Cursors.WaitCursor
            ClassEBISU.GetCSV_sagawa(filename)
            Cursor.Current = Cursors.Default
        Else
            Cursor.Current = Cursors.WaitCursor
            ClassEBISU.GetExcel_sagawa(filename)
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub Button_sagawa_Click(sender As Object, e As EventArgs) Handles Button_sagawa.Click
        Dim ClassSagawa As New ClassSagawa()
        Dim filename As String = ClassSagawa.GetFile("", "")
        If filename = "" Then
            Return
        End If
        If filename.IndexOf(".xlsx") = -1 Then

            Cursor.Current = Cursors.WaitCursor
            ClassSagawa.GetCSV(filename)
            Cursor.Current = Cursors.Default

        Else
            Cursor.Current = Cursors.WaitCursor
            ClassSagawa.GetExcel(filename)
            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub Button_smbc_ebisu_Click(sender As Object, e As EventArgs) Handles Button_smbc_ebisu.Click
        'ebisuデータの入力
        Dim ClassEBISU As New ClassEBISU()
        Dim filename As String = ClassEBISU.GetFile("", "")
        If filename = "" Then
            Return
        End If
        If filename.IndexOf(".xlsx") = -1 Then
            Cursor.Current = Cursors.WaitCursor
            ClassEBISU.GetCSV_smbc(filename)
            Cursor.Current = Cursors.Default

        Else
            Cursor.Current = Cursors.WaitCursor
            ClassEBISU.GetExcel_smbc(filename)
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub Button_smbc_Click(sender As Object, e As EventArgs) Handles Button_smbc.Click
        Dim ClassSB As New ClassSB()
        Dim filename As String = ClassSB.GetFile("", "")
        If filename = "" Then
            Return
        End If
        If filename.IndexOf(".xlsx") = -1 Then
            Cursor.Current = Cursors.WaitCursor
            ClassSB.GetCSV(filename)
            Cursor.Current = Cursors.Default
        Else
            Cursor.Current = Cursors.WaitCursor
            ClassSB.GetExcel(filename)
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub Button_np_ebisu_Click(sender As Object, e As EventArgs) Handles Button_np_ebisu.Click
        Dim ClassEBISU As New ClassEBISU()
        Dim filename As String = ClassEBISU.GetFile("", "")
        If filename = "" Then
            Return
        End If
        If filename.IndexOf(".xlsx") = -1 Then
            Cursor.Current = Cursors.WaitCursor
            ClassEBISU.GetCSV_np(filename)
            Cursor.Current = Cursors.Default
        Else
            Cursor.Current = Cursors.WaitCursor
            ClassEBISU.GetExcel_np(filename)
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub Button_np_Click(sender As Object, e As EventArgs) Handles Button_np.Click
        Dim ClassNp As New ClassNp()
        Dim filename As String = ClassNp.GetFile("", "")
        If filename = "" Then
            Return
        End If
        If filename.IndexOf(".xlsx") = -1 Then
            Cursor.Current = Cursors.WaitCursor
            ClassNp.GetCSV(filename)
            Cursor.Current = Cursors.Default
        Else
            Cursor.Current = Cursors.WaitCursor
            ClassNp.GetExcel(filename)
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub Button更新01_Click(sender As Object, e As EventArgs) Handles Button更新01.Click
        Kousin()
    End Sub

    Private Sub 残明細()

        Dim ro As Integer = 0
        Dim strSQL As String
        Dim dt As DataTable
        Dim st As DateTime
        Dim en As DateTime

        st = DateTime.Parse(Me.DateTimePicker1.Value)
        en = DateTime.Parse(Me.DateTimePicker2.Value)

        '今月の最初の日
        Dim dtFDM As New DateTime(st.Year, st.Month, 1)
        '今月の最後の日
        Dim dtLDM As DateTime = New DateTime(en.Year, en.Month, 1).AddMonths(1).AddDays(-1)


        strSQL = ""
        strSQL &= "select t.cst_cd as ""得意先"" "
        strSQL &= ",(select sum(coalesce(cast(t_uriage.qty as numeric),0)* coalesce(cast(t_uriage.upri as numeric),0) )  from " & schema & "t_uriage where cst_cd = t.cst_cd and entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "') as ""ALL"""
        strSQL &= ",(select coalesce((sum(coalesce(cast(t_uriage.qty as numeric),0) * coalesce(cast(t_uriage.upri as numeric),0))),0)  from " & schema & "t_uriage where cst_cd = t.cst_cd and nyukinn='1'  and entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "') as ""入金"""
        strSQL &= ",(select coalesce((sum(coalesce(cast(t_uriage.qty as numeric),0) * coalesce(cast(t_uriage.upri as numeric),0))),0) from " & schema & "t_uriage where cst_cd = t.cst_cd  and entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "')"
        strSQL &= "-(select coalesce((sum(coalesce(cast(t_uriage.qty as numeric),0) * coalesce(cast(t_uriage.upri as numeric),0))),0) from " & schema & "t_uriage where cst_cd = t.cst_cd and nyukinn='1'  and entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "') as ""差額"""
        strSQL &= " from " & schema & "t_uriage t"
        strSQL &= " where t.cst_cd <> ''"
        strSQL &= " group by t.cst_cd"
        strSQL &= ""

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = SettextColumn(Me.DataGridView1, ro, "得意先", "得意先ＣＤ", 120, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "ALL", "ALL", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "入金", "入金分", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "差額", "差異", 140, True, DataGridViewContentAlignment.MiddleRight)

        Me.DataGridView1.Columns(1).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(2).DefaultCellStyle.Format = "#,0"
        Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"

        Me.DataGridView1.AllowUserToAddRows = False

    End Sub

    Private Sub 明細入金済み()
        Dim ro As Integer = 0
        Dim strSQL As String
        Dim dt As DataTable
        Dim st As DateTime
        Dim en As DateTime

        st = DateTime.Parse(Me.DateTimePicker1.Value)
        en = DateTime.Parse(Me.DateTimePicker2.Value)

        '今月の最初の日
        Dim dtFDM As New DateTime(st.Year, st.Month, 1)
        '今月の最後の日
        Dim dtLDM As DateTime = New DateTime(en.Year, en.Month, 1).AddMonths(1).AddDays(-1)


        strSQL = ""
        strSQL &= "select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks "
        strSQL &= ",t_ebisu_np.受注番号 ,'NP' GY"
        strSQL &= " from " & schema & "t_uriage tu "
        strSQL &= " inner join " & schema & "t_ebisu_np on t_ebisu_np.受注番号 =tu.cst_po_no "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= " And tu.nyukinn ='1'"

        strSQL &= " union all"
        strSQL &= " select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks "
        strSQL &= ",t_ebisu_np.受注番号 ,'NP' GY"
        strSQL &= " from " & schema & "t_uriage tu "
        strSQL &= " inner join " & schema & "t_ebisu_np on t_ebisu_np.受注番号 =tu.intr_rmrks  "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= " And tu.nyukinn ='1'"

        strSQL &= " union all"
        strSQL &= " select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks "
        strSQL &= ",t_ebisu_sagawa.受注番号 ,'SA' GY"
        strSQL &= " from " & schema & "t_uriage tu "
        strSQL &= " inner join " & schema & "t_ebisu_sagawa  on t_ebisu_sagawa.受注番号 =tu.cst_po_no "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= " And tu.nyukinn ='1'"

        strSQL &= " union all"
        strSQL &= " select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks "
        strSQL &= ",t_ebisu_sagawa.受注番号 ,'SA' GY"
        strSQL &= " from " & schema & "t_uriage tu "
        strSQL &= " inner join " & schema & "t_ebisu_sagawa on t_ebisu_sagawa.受注番号 =tu.intr_rmrks  "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= " And tu.nyukinn ='1'"

        strSQL &= " union all"
        strSQL &= " select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks "
        strSQL &= ",t_ebisu_smbc.受注番号 ,'SB' GY"
        strSQL &= " from " & schema & "t_uriage tu "
        strSQL &= " inner join " & schema & "t_ebisu_smbc  on t_ebisu_smbc.受注番号 =tu.cst_po_no "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= " And tu.nyukinn ='1'"

        strSQL &= " union all"
        strSQL &= " select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks "
        strSQL &= ",t_ebisu_smbc.受注番号 ,'SB' GY"
        strSQL &= " from " & schema & "t_uriage tu "
        strSQL &= " inner join " & schema & "t_ebisu_smbc on t_ebisu_smbc.受注番号 =tu.intr_rmrks  "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= " And tu.nyukinn ='1'"

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = SettextColumn(Me.DataGridView1, ro, "sinacd", "品コード", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "ord_no", "オーダーNO", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "cst_cd", "得意先コード", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "cst_po_no", "発注NO", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "qty", "数", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "upri", "単価", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "intr_rmrks", "備考カナ", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "受注番号", "受注番号", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "GY", "集金", 100, True, DataGridViewContentAlignment.MiddleRight)

        Me.DataGridView1.Columns(5).DefaultCellStyle.Format = "#,0"
        'Me.DataGridView1.Columns(2).DefaultCellStyle.Format = "#,0"
        ' Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"

        Me.DataGridView1.AllowUserToAddRows = False

    End Sub

    Private Sub 明細未入金()

        Dim ro As Integer = 0
        Dim strSQL As String
        Dim dt As DataTable
        Dim st As DateTime
        Dim en As DateTime

        st = DateTime.Parse(Me.DateTimePicker1.Value)
        en = DateTime.Parse(Me.DateTimePicker2.Value)

        '今月の最初の日
        Dim dtFDM As New DateTime(st.Year, st.Month, 1)
        '今月の最後の日
        Dim dtLDM As DateTime = New DateTime(en.Year, en.Month, 1).AddMonths(1).AddDays(-1)


        strSQL = ""

        strSQL &= "select tu.sinacd ,tu.ord_no ,tu.cst_cd ,tu.cst_po_no ,tu.qty ,tu.upri ,tu.intr_rmrks  "
        strSQL &= "from " & schema & "t_uriage tu  "
        strSQL &= " where tu.entry_day between '" & dtFDM.ToString("yyyy/MM/dd") & "' and '" & dtLDM.ToString("yyyy/MM/dd") & "'"
        strSQL &= "and tu.nyukinn ='0'"


        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = SettextColumn(Me.DataGridView1, ro, "sinacd", "品コード", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "ord_no", "オーダーNO", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "cst_cd", "得意先コード", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "cst_po_no", "発注NO", 140, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "qty", "数", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "upri", "単価", 100, True, DataGridViewContentAlignment.MiddleRight)
        ro = SettextColumn(Me.DataGridView1, ro, "intr_rmrks", "備考カナ", 140, True, DataGridViewContentAlignment.MiddleRight)

        Me.DataGridView1.Columns(5).DefaultCellStyle.Format = "#,0"
        'Me.DataGridView1.Columns(2).DefaultCellStyle.Format = "#,0"
        ' Me.DataGridView1.Columns(3).DefaultCellStyle.Format = "#,0"

        Me.DataGridView1.AllowUserToAddRows = False

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        If Me.RadioButton1.Checked Then '残明細
            残明細()
            Return
        End If

        If Me.RadioButton2.Checked Then '明細(入金済)
            明細入金済み()
            Return
        End If

        If Me.RadioButton3.Checked Then '明細(未金済)
            明細未入金()
            Return
        End If
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred(Me.DataGridView1, False)
        MessageBox.Show("出力しました")

    End Sub

End Class