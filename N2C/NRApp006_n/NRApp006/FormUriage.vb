Public Class FormUriage
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim strSQL1 As String  'ステータス名
    Dim strSQL2 As String  '回収区分
    Dim strSQL31 As String '期間 t
    Dim strSQL32 As String '期間 t1
    Dim strSQL4 As String  '点検状態区分名称
    Dim strSQL5 As String　'請求先

    Dim fast As Boolean

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

    Private Sub FormUriage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = Me.Text & " Version[" & Ver & "] " '& Getasmdc()
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報
        Me.ToolStripStatusLabel2.Text = ""

        Me.DataGridView1.RowHeadersWidth = 10
        'Me.DateTimePicker期間1.Value = Now().AddMonths(-12)
        'GetSystemtoCombo("10", Me.ComboBox期間)
        'Me.ComboBox期間.SelectedIndex = 1

        Me.ToolStripComboBox1.Items.Clear()
        Me.ToolStripComboBox1.Items.Add("")
        Me.ToolStripComboBox1.Items.Add("未売上")
        Me.ToolStripComboBox1.SelectedIndex = 0


        Dim dy As DateTime = Date.Today
        Dim x As Integer

        Me.ToolStripComboBox年.Items.Clear()
        For x = 0 To 24
            Me.ToolStripComboBox年.Items.Add(dy.ToString("yyyy/MM"))
            dy = dy.AddMonths(-1)

        Next
        Me.ToolStripComboBox年.SelectedIndex = 0
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        Dim strSQL As String = String.Empty
        Dim dt0 As DataTable
        Dim dt1 As DataTable

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DataGridView1.DataSource = Nothing
        System.Windows.Forms.Application.DoEvents()

        Dim tuki As String = Me.ToolStripComboBox年.Text

        'If ComboBoxメーカー.Text = "得意先別" Then


        '    strSQL = "select t.itm_cd 得意先"
        '    strSQL &= ",sum(cast(t.qty as numeric) * cast( t.upri as numeric)) 　売上"
        '    strSQL &= " from " & schema & "t_002 t "
        '    strSQL &= " where left(t.nextb,7) = '" & tuki & "'"
        '    strSQL &= " group by t.itm_cd"
        '    strSQL &= " order by t.itm_cd"

        'Else

        '    strSQL = ""
        '    strSQL &= "select '" & tuki & "' 売上年月,'請求済' 結果表,'直集' 分類,sum(cast(COALESCE( t.upri, '0' ) as numeric )) 売上金額,count(*) 台数"
        '    strSQL &= " from " & schema & "t_002 t , " & schema & "v_yuryo_tenken_syuyaku v"
        '    strSQL &= " where t.uketukeno  = v.点検受付番号 "
        '    strSQL &= " and left(t.nextb,7) = '" & tuki & "'"
        '    strSQL &= " and t.out_flg ='1'"
        '    strSQL &= " and v.回収完了日 is not null"
        '    'strSQL &= " and v.回収区分 in ('SS後日請求','SS現金徴収')"
        '    strSQL &= " and t.cst_cd  in (" & GetCstCD("直集") & ")"
        '    If Me.ComboBoxメーカー.Text = "全部" Then

        '    Else
        '        strSQL &= " and v.メーカー ='" & Me.ComboBoxメーカー.Text & "'"
        '    End If


        '    strSQL &= " union "
        '    strSQL &= " select '" & tuki & "' 売上年月,'請求済' 結果表,'別途' 分類,sum(cast(COALESCE( t.upri, '0' ) as numeric )) 売上金額,count(*) 台数"
        '    strSQL &= " from " & schema & "t_002 t , " & schema & "v_yuryo_tenken_syuyaku v"
        '    strSQL &= " where t.uketukeno  = v.点検受付番号 "
        '    strSQL &= " and left(t.nextb,7) = '" & tuki & "'"
        '    strSQL &= " and t.out_flg ='1'"
        '    strSQL &= " and v.回収完了日 is not null"
        '    'strSQL &= " and v.回収区分 not in ('SS後日請求','SS現金徴収')"
        '    strSQL &= " and t.cst_cd  in (" & GetCstCD("別途") & ")"
        '    If Me.ComboBoxメーカー.Text = "全部" Then

        '    Else
        '        strSQL &= " and v.メーカー ='" & Me.ComboBoxメーカー.Text & "'"
        '    End If

        '    strSQL &= " union "
        '    strSQL &= " select '' 売上年月,'点検完了未請求' 結果表,'直集' 分類,sum(" & SQL4() & " ) 売上金額,count(*) 台数"
        '    strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
        '    'strSQL &= " where v.点検受付番号 not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
        '    strSQL &= " where v.ステータス名  = '点検完了'"
        '    strSQL &= " and ( v.回収完了日  is  null  or v.回収完了日 ='')"
        '    'strSQL &= " and v.回収完了日  is not null"
        '    strSQL &= " and v.回収区分 in ('SS後日請求','SS現金徴収')"
        '    '---
        '    strSQL &= " And left(v.点検完了日,7)='" & DateTimePicker期間1.Value.ToShortDateString.Substring(0, 7) & "' "

        '    If Me.ComboBoxメーカー.Text = "全部" Then

        '    Else
        '        strSQL &= " and v.メーカー ='" & Me.ComboBoxメーカー.Text & "'"
        '    End If


        '    strSQL &= " union"
        '    strSQL &= " select '' 売上年月,'点検完了未請求' 結果表,'別途' 分類,sum(" & SQL4() & ") 売上金額,count(*) 台数"
        '    strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
        '    'strSQL &= " where v.点検受付番号 not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
        '    strSQL &= " where v.ステータス名  = '点検完了'"
        '    strSQL &= " and ( v.回収完了日  is  null  or v.回収完了日 ='')"
        '    'strSQL &= " and v.回収区分 not in ('SS後日請求','SS現金徴収')"
        '    strSQL &= " and v.回収区分 in ('NR後日請求')"
        '    '---
        '    strSQL &= " And left(v.点検完了日,7)='" & DateTimePicker期間1.Value.ToShortDateString.Substring(0, 7) & "' "

        '    If Me.ComboBoxメーカー.Text = "全部" Then

        '    Else
        '        strSQL &= " and v.メーカー ='" & Me.ComboBoxメーカー.Text & "'"
        '    End If


        '    strSQL &= " union "
        '    strSQL &= " select '' 売上年月,'受付中' 結果表,'直集' 分類,sum(" & SQL4() & ") 売上金額,count(*) 台数"
        '    strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
        '    'strSQL &= " where v.点検受付番号 not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
        '    strSQL &= " where v.ステータス名  = '点検受付'"
        '    strSQL &= " and v.回収完了日  is not null"
        '    strSQL &= " and v.回収区分 in ('SS後日請求','SS現金徴収')"
        '    If Me.ComboBoxメーカー.Text = "全部" Then

        '    Else
        '        strSQL &= " and v.メーカー ='" & Me.ComboBoxメーカー.Text & "'"
        '    End If

        '    strSQL &= " union "
        '    strSQL &= " select '' 売上年月,'受付中' 結果表,'別途' 分類,sum( " & SQL4() & ") 売上金額,count(*) 台数"
        '    strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
        '    'strSQL &= " where v.点検受付番号 not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
        '    strSQL &= " where v.ステータス名  = '点検受付'"
        '    strSQL &= " and v.回収完了日  is not null"
        '    strSQL &= " and v.回収区分 not in ('SS後日請求','SS現金徴収')"
        '    If Me.ComboBoxメーカー.Text = "全部" Then

        '    Else
        '        strSQL &= " and v.メーカー ='" & Me.ComboBoxメーカー.Text & "'"
        '    End If

        '    strSQL &= " order by 1 desc,2,3 "
        'End If

        '--------------------------------------------------------------------------
        If Me.ToolStripComboBox1.Text = "未売上" Then

            strSQL = ""
            strSQL &= "select "
            strSQL &= " v_yuryo_tenken_syuyaku.点検完了受付日"
            strSQL &= " ,v_yuryo_tenken_syuyaku.点検受付番号"
            strSQL &= " ,v_yuryo_tenken_syuyaku.回収区分 "
            strSQL &= " ,v_yuryo_tenken_syuyaku.修理完了日"
            strSQL &= " ,t_002.nextb 売上日"
            strSQL &= " ,to_char( t_kaisyu.入金日,'yyyy/MM/dd') 入金日"
            strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku "
            strSQL &= " left outer join " & schema & "t_002 on uketukeno = v_yuryo_tenken_syuyaku.点検受付番号 "
            strSQL &= "  left outer join tenken.t_kaisyu on t_kaisyu.uketukeno = v_yuryo_tenken_syuyaku.点検受付番号 "
            strSQL &= " where t_002.nextb is null"
            strSQL &= " And  LEFT(v_yuryo_tenken_syuyaku.点検完了受付日,4)='" & ToolStripComboBox年.Text & "'"
            strSQL &= "group by "
            strSQL &= "v_yuryo_tenken_syuyaku.点検完了受付日"
            strSQL &= ",v_yuryo_tenken_syuyaku.点検受付番号"
            strSQL &= ",v_yuryo_tenken_syuyaku.回収区分 "
            strSQL &= ",v_yuryo_tenken_syuyaku.ステータス名"
            strSQL &= ",v_yuryo_tenken_syuyaku.修理完了日"
            strSQL &= ",v_yuryo_tenken_syuyaku.請求合計金額"
            strSQL &= ",t_002.nextb"
            strSQL &= ",to_char( t_kaisyu.入金日,'yyyy/MM/dd') "
            strSQL &= " order by v_yuryo_tenken_syuyaku"
        Else
            strSQL = ""
            strSQL &= "select"
            strSQL &= " LEFT(t.nextb,7) 年月"
            strSQL &= ",t.cst_cd 品コード"
            strSQL &= ",CASE t.cst_cd WHEN '901000'  THEN '別途請求' "
            strSQL &= "               WHEN '010574'  THEN '直収' "
            strSQL &= "               WHEN '902000'  THEN '安心Ｐ点検付' "
            strSQL &= "               WHEN '903000'  THEN 'ＨＮ直収' "
            strSQL &= "               WHEN '904000'  THEN 'ＨＮ別途' "
            strSQL &= "               END 点検売上"
            strSQL &= ",sum( CAST(COALESCE(t.upri ,'0')AS INTEGER) ) 金額"
            strSQL &= ",count(*) 件数"
            strSQL &= " FROM " & schema & "t_002 t"
            strSQL &= " where t.nextb  between '" & ToolStripComboBox年.Text & "/01'and '" & GetuMatu(ToolStripComboBox年.Text) & "'"
            strSQL &= " and   t.sls_typ='1'  "
            strSQL &= " group by LEFT(t.nextb,7) , t.cst_cd "
            strSQL &= " order by LEFT(t.nextb,7) , t.cst_cd "
        End If


        dt0 = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = dt0

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ReadOnly = True
        '---赤
        strSQL = ""
        strSQL &= "select"
        strSQL &= " LEFT(t.nextb,7) 年月"
        strSQL &= ",t.cst_cd 品コード"
        strSQL &= ",CASE t.cst_cd WHEN '901000'  THEN '別途請求' "
        strSQL &= "               WHEN '010574'  THEN '直収' "
        strSQL &= "               WHEN '902000'  THEN '安心Ｐ点検付' "
        strSQL &= "               WHEN '903000'  THEN 'ＨＮ直収' "
        strSQL &= "               WHEN '904000'  THEN 'ＨＮ別途' "
        strSQL &= "               END 点検売上"
        strSQL &= ",sum( CAST(COALESCE(t.upri ,'0')AS INTEGER) ) 金額"
        strSQL &= ",count(*) 件数"
        strSQL &= " FROM " & schema & "t_002 t"
        strSQL &= " where t.nextb  between '" & ToolStripComboBox年.Text & "/01'and '" & GetuMatu(ToolStripComboBox年.Text) & "'"
        strSQL &= " and   t.sls_typ='3'  "
        strSQL &= " group by LEFT(t.nextb,7) , t.cst_cd "
        strSQL &= " order by LEFT(t.nextb,7) , t.cst_cd "

        dt1 = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView2.DataSource = dt1

        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.ReadOnly = True


        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Function SQL4() As String

        Return "(v.技術料  + v.出張料 + v.その他料金 +cast(( case when v.サポート料 is null then '0' when v.サポート料 = '' then '0' else v.サポート料 end ) as  numeric) -cast(( case when v.値引き is null then '0'  when v.値引き = '' then '0' else v.値引き end )  as  numeric)) "

    End Function
    Private Function GetuMatu(dy As String)
        Dim tu As Date = Date.Parse(dy & "/01")
        tu = tu.AddMonths(1).AddDays(-1)
        Return tu
    End Function



    'Private Sub CmbSetメーカー()
    '    Dim strSQL As String

    '    Dim tuki As String = Me.DateTimePicker期間1.Value.ToString.Substring(0, 7)

    '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    '    strSQL = "select v.メーカー "
    '    strSQL &= " from " & schema & "t_002 t , " & schema & "v_yuryo_tenken_syuyaku v"
    '    strSQL &= " where t.uketukeno  = v.点検受付番号 "
    '    strSQL &= " and left(t.nextb,7)  =  '" & tuki & "'"
    '    strSQL &= " group by v.メーカー"

    '    ClassPostgeDB.SetComboBox(Me.ComboBoxメーカー, strSQL, "")
    '    Me.ComboBoxメーカー.Items.Add("得意先別")
    '    Me.ComboBoxメーカー.Items.Add("全部")
    '    Me.ComboBoxメーカー.SelectedIndex = Me.ComboBoxメーカー.Items.Count - 1

    '    Me.Cursor = System.Windows.Forms.Cursors.Default


    'End Sub

    Private Sub DateTimePicker期間1_ValueChanged(sender As Object, e As EventArgs)
        'CmbSetメーカー()
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count < 1 Then
            MsgBox("検索を行ってから出力してください", vbOKOnly, "警告")
            Return
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        excelOutDataGred2U(Me.DataGridView1, True, Me.ToolStripProgressBar1, "売上【" & Me.ToolStripComboBox年.Text & "】")
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim ro
        ro = e.RowIndex
        If ro >= 0 And e.Button = MouseButtons.Left Then

            'FormUriageSub.UserID = UserID
            'FormUriageSub.Kengen = Kengen
            'FormUriageSub.UserName = UserName

            'FormUriageSub.Nentuki = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            'FormUriageSub.Kekka = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
            'FormUriageSub.Bunrui = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
            'FormUriageSub.KanryouTuki = DateTimePicker期間1.Value.ToShortDateString.Substring(0, 7)

            'FormUriageSub.Maker = Me.ComboBoxメーカー.Text
            'FormUriageSub.ShowDialog()
            FormUriage002.AkaKuro = "1"
            FormUriage002.UserID = UserID
            FormUriage002.Kengen = Kengen
            FormUriage002.UserName = UserName
            FormUriage002.Nentuki = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            FormUriage002.SinaCd = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
            FormUriage002.ShowDialog()

        End If

    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub DataGridView2_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Dim ro
        ro = e.RowIndex
        If ro >= 0 And e.Button = MouseButtons.Left Then

            FormUriage002.AkaKuro = "3"
            FormUriage002.UserID = UserID
            FormUriage002.Kengen = Kengen
            FormUriage002.UserName = UserName
            FormUriage002.Nentuki = Me.DataGridView2.Rows(ro).Cells(0).Value.ToString
            FormUriage002.SinaCd = Me.DataGridView2.Rows(ro).Cells(1).Value.ToString
            FormUriage002.ShowDialog()
        End If

    End Sub
End Class