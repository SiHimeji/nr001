Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form002
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB()
    Dim ZenkaiSQL As String = String.Empty
    Dim color1 As String = "White"
    Dim color2 As String = "White"


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

    Private Sub Form002_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = Me.Text & " Version[" & Ver & "] " '& Getasmdc()
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報
        Me.DataGridView1.AllowUserToAddRows = False
        Me.ToolStripStatusLabel2.Text = "0件"
        Me.DataGridView1.RowHeadersWidth = 10
        Me.ComboBox期間.Items.Clear()
        Me.ComboBox期間.Items.Add("作成日")
        Me.ComboBox期間.Items.Add("NEXT転送日")
        Me.ComboBox期間.SelectedIndex = 0

        'ClassPostgeDB.EXEC("update  " & schema & "t_002 set tyoufuku ='重' where uketukeno in ( select t.uketukeno from  " & schema & "t_002 t group by t.uketukeno having count(t.uketukeno) >1)")


        Me.DateTimePicker日.Value = Today.Year & "/01/01"
        Me.DateTimePicker日２.Value = Today.ToShortDateString

        color1 = GetSystemto("210", "1")
        color2 = GetSystemto("210", "2")

        Dim dt As DataTable
        dt = ClassPostgeDB.SetTable("select cst_cd  from " & schema & "t_002  group by cst_cd order by cst_cd")
        Me.ComboBox得意先コード.Items.Clear()
        Me.ComboBox得意先コード.Items.Add("")
        For Each dtrow In dt.Rows
            Me.ComboBox得意先コード.Items.Add(dtrow(0).ToString)
        Next

        検索("1", "")

    End Sub
    '///
    '/// sw = 1  出庫済み 
    '///      0　全て
    '///
    Private Sub 検索(sw As String, uno As String)
        Dim strSQL As String
        Dim ro As Integer
        Dim dt As New DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DataGridView1.DataSource = Nothing
        System.Windows.Forms.Application.DoEvents()

        JyuFukuSYori()

        If ZenkaiSQL = String.Empty Then

            strSQL = ""
            strSQL &= "select 'false'"
            strSQL &= ",t.tyoufuku "
            strSQL &= ",t.uketukeno "
            'strSQL &= ",CASE WHEN COALESCE(tt.出庫,'0') = '1' THEN '停止'  ELSE '' END 停止"
            strSQL &= ",case when t.del_flg ='1' then '停止'  when t.del_flg ='0' then ''  else (CASE WHEN COALESCE(tt.出庫,'0') = '1' THEN '停止'  ELSE '' END  )end 停止"
            strSQL &= ",tt.訂正依頼内容 "
            strSQL &= ",t.sls_typ "
            strSQL &= ",t.xpns_cd "
            strSQL &= ",t.ship_wh_cd "
            strSQL &= ",t.route_cd "
            strSQL &= ",t.fare_typ "
            strSQL &= ",t.cst_cd "
            strSQL &= ",t.cst_note "
            strSQL &= ",t.scnd_dler_tel "
            strSQL &= ",t.thrd_dler_tel "
            strSQL &= ",t.scst_nm "
            strSQL &= ",t.cst_po_no "
            strSQL &= ",t.ord_psn_nm "
            strSQL &= ",t.ord_psn_nm1 "
            strSQL &= ",t.slip_rmrks "
            strSQL &= ",t.intr_rmrks "
            strSQL &= ",t.chrg_dpt_cd "
            strSQL &= ",t.bf_no "
            strSQL &= ",t.ac_cd "
            strSQL &= ",t.fa_no "
            strSQL &= ",t.zn_rcv_psn_cd "
            strSQL &= ",t.itm_cd "
            strSQL &= ",t.qty "
            strSQL &= ",t.upri "
            strSQL &= ",t.rate "
            strSQL &= ",t.cst_dsnt_subno "
            strSQL &= ",t.ja_inst_no "
            strSQL &= ",t.ja_upri "
            strSQL &= ",t.ja_upri_rate "
            strSQL &= ",replace(t.entry_date,'/','') entry_date"
            strSQL &= ",t.out_flg "
            strSQL &= ",t.del_flg "
            strSQL &= ",row_number() over() as seq"
            strSQL &= " from " & schema & "t_002 t  left outer join " & schema & "t_teisei tt On t.uketukeno = tt.点検受付番号 "

            If Me.CheckBox未点検チェックを含める.Checked Then

            Else
                strSQL &= " inner join " & schema & "t_check ct  On t.uketukeno = ct.点検受付番号 and ((ct.チェック = '1' or ct.チェック = '2') or (ct.チェック = '3' and ct.確認完了日 is not null)) "
            End If

            strSQL &= " where  t.uketukeno in ( select uketukeno from " & schema & "t_002 "


            Select Case sw
                Case "1"
                    'strSQL &= " where  (t.out_flg != '1' or  t.out_flg is null) "
                    strSQL &= " where  (nextb = '' or  nextb is null) "
                Case "2"
                    strSQL &= " where  uketukeno = '" & uno & "'"
                Case "3"
                    Select Case Me.ComboBox期間.Text
                        Case "作成日"

                            strSQL &= "  where entry_date between '" & Me.DateTimePicker日.Value.ToShortDateString() & "' and '" & Me.DateTimePicker日２.Value.ToShortDateString() & "' and sls_typ ='1'"

                            'strSQL &= " where  t.entry_date  between '" & Me.DateTimePicker日.Value.ToShortDateString() & "' and '" & Me.DateTimePicker日２.Value.ToShortDateString() & "'"

                        Case "NEXT転送日"
                            strSQL &= "  where  (to_date(nextb, 'YYYY/MM/DD')   between '" & Me.DateTimePicker日.Value.ToShortDateString() & "' and '" & Me.DateTimePicker日２.Value.ToShortDateString() & "')"
                    End Select

                    If Me.ComboBox得意先コード.Text.ToString.Trim() <> "" Then
                        strSQL &= " and  cst_cd ='" & Me.ComboBox得意先コード.Text.ToString.Trim() & "'"
                    End If
                    If Me.CheckBox出庫済みを含める.Checked Then

                    Else
                        strSQL &= " and out_flg = '0'"
                    End If
            End Select

            If Me.CheckBoxゼロ円を含める.Checked = True Then

            Else
                strSQL &= " and upri <> '0' )"
            End If

            If Me.CheckBox削除を含める.Checked = False Then
                strSQL &= "and  (t.entry  <> 'DELETE' or t.entry  is null)"
            End If
            If Me.CheckBox出庫済みを含める.Checked Then

            Else
                strSQL &= " and t.uketukeno not in ( select uketukeno from " & schema & "t_002 where tyoufuku ='重' and out_flg ='1')"
            End If
            strSQL &= ""
            'strSQL &= " order by COALESCE(tt.出庫,'0')  desc,t.uketukeno " ' , row_number() over()"
            'strSQL &= " order by  row_number() over()"
            strSQL &= " order by t.uketukeno ,t.entry_date "
            ZenkaiSQL = strSQL
        Else
            strSQL = ZenkaiSQL
        End If
        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        'ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt

        ro = 0
        Dim CheckBoxColumn As New DataGridViewCheckBoxColumn()
        CheckBoxColumn.DataPropertyName = "ﾁｪｯｸ"
        CheckBoxColumn.Name = "Column1"
        CheckBoxColumn.HeaderText = "ﾁｪｯｸ"
        Me.DataGridView1.Columns.Add(CheckBoxColumn)
        Me.DataGridView1.Columns(ro).Width = 40
        ro = ro + 1

        ro = settextColumn(Me.DataGridView1, ro, "tyoufuku", "重複", 40, True)

        ro = settextColumn(Me.DataGridView1, ro, "uketukeno", "受付ＮＯ", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "停止", "停止", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "修正備考", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "out_flg", "NEXT", 30, True)
        ro = settextColumn(Me.DataGridView1, ro, "entry_date", "登録日", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "seq", "順", 20, True)

        ro = settextColumn(Me.DataGridView1, ro, "sls_typ", "売上区分", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "xpns_cd", "管理区分", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "ship_wh_cd", "出庫倉庫", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "route_cd", "運送便", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "fare_typ", "運賃区分", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "cst_cd", "得意先", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "cst_note", "得意先記事", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "scnd_dler_tel", "2次店", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "thrd_dler_tel", "3次店", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "scst_nm", "送り先名", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "cst_po_no", "発注NO", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "ord_psn_nm", "発注者漢字", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "ord_psn_nm1", "発注者カナ", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "slip_rmrks", "備考漢字", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "intr_rmrks", "備考カナ", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "chrg_dpt_cd", "負担部門", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "bf_no", "資金予算NO", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "ac_cd", "勘定科目", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "fa_no", "固定資産管理NO", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "zn_rcv_psn_cd", "荷受人ＣＤ", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "itm_cd", "品コード", 50, True)
        ro = settextColumn(Me.DataGridView1, ro, "qty", "数量", 50, True)
        ro = settextColumn(Me.DataGridView1, ro, "upri", "単価", 50, True)
        ro = settextColumn(Me.DataGridView1, ro, "rate", "売価率", 50, True)
        ro = settextColumn(Me.DataGridView1, ro, "cst_dsnt_subno", "枝番", 50, True)
        ro = settextColumn(Me.DataGridView1, ro, "ja_inst_no", "明細発注NO", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "ja_upri", "農協価格", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "ja_upri_rate", "農協価格率", 60, True)

        Me.DataGridView1.AllowUserToAddRows = False

        TeisiColor()
        BackcolorChg()

        Me.ToolStripStatusLabel2.Text = Me.DataGridView1.Rows.Count.ToString & "件"
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub
    Private Sub TeisiColor()
        Dim ro As Integer

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = False
            If Me.DataGridView1.Rows(ro).Cells(3).Value = "停止" Then
                Me.DataGridView1.Rows(ro).Cells(3).Style.BackColor = Color.Red
            End If
        Next


    End Sub


    '同じ受付番号のバックカラーを変える
    Private Sub BackcolorChg()
        Dim ro As Integer
        Dim defcolor As String
        defcolor = color1

        If Me.DataGridView1.Rows.Count > 0 Then

            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Rows(ro).Cells(1).Value.ToString = "重" Then
                    If ro > 0 Then
                        If Me.DataGridView1.Rows(ro).Cells(2).Value.ToString <> Me.DataGridView1.Rows(ro - 1).Cells(2).Value.ToString Then

                            If defcolor = color1 Then
                                defcolor = color2
                            Else
                                defcolor = color1
                            End If

                        End If
                    End If

                    Me.DataGridView1.Rows(ro).Cells(2).Style.BackColor = Color.FromName(defcolor)

                End If
            Next
        End If

    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        '入力
        Dim fileName As String
        Dim dt As New DataTable
        Dim ro As Integer
        Dim cl As Integer
        Dim strSQL As String
        Dim cnt As String
        Dim errMsg As String = String.Empty
        Dim dupliMsg As String = String.Empty

        Dim day As DateTime = Me.DateTimePicker日.Value

        GetIniFile()
        Me.ToolStripStatusLabel2.Text = "0件"
        fileName = Filesentaku(MaserFolder)
        ReadCSV(dt, True, fileName, ",", True, Me.ToolStripStatusLabel2)

        If dt.Columns.Count <> 28 Or dt.Columns.Count <> 30 Then
            'OK
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.Rows.Clear()
        Else
            MessageBox.Show("ファイルが違います")
            Exit Sub
        End If

        If dt.Columns.Count = 28 Then

            If dt.Rows(0).Item(0).ToString() = "売上区分" And
            dt.Rows(0).Item(1).ToString() = "管理区分" And
            dt.Rows(0).Item(2).ToString() = "出庫倉庫" And
            dt.Rows(0).Item(3).ToString() = "運送便" And
            dt.Rows(0).Item(4).ToString() = "運賃区分" And
            dt.Rows(0).Item(5).ToString() = "得意先" And
            dt.Rows(0).Item(6).ToString() = "得意先記事" And
            dt.Rows(0).Item(7).ToString() = "２次店" And
            dt.Rows(0).Item(8).ToString() = "３次店" And
            dt.Rows(0).Item(9).ToString() = "送り先名" And
            dt.Rows(0).Item(10).ToString() = "発注ＮＯ" And
            dt.Rows(0).Item(11).ToString() = "発注者漢字" And
            dt.Rows(0).Item(12).ToString() = "発注者カナ" And
            dt.Rows(0).Item(13).ToString() = "備考漢字" And
            dt.Rows(0).Item(14).ToString() = "備考カナ" And
            dt.Rows(0).Item(20).ToString() = "品コード" And
            dt.Rows(0).Item(21).ToString() = "数量" And
            dt.Rows(0).Item(22).ToString() = "単価" And
            dt.Rows(0).Item(23).ToString() = "売価率" And
            dt.Rows(0).Item(24).ToString() = "枝番" And
            dt.Rows(0).Item(25).ToString() = "明細発注ＮＯ" And
            dt.Rows(0).Item(26).ToString() = "農協価格" And
            dt.Rows(0).Item(27).ToString() = "農協価格率" Then


                Me.ToolStripStatusLabel2.Text = Integer.Parse(dt.Rows.Count - 1).ToString & "件"
            Else
                MessageBox.Show("ファイルが違います")
                Exit Sub
            End If

            For ro = 1 To dt.Rows.Count - 1
                Try

                    strSQL = "select count(uketukeno) from  " & schema & "t_002 where uketukeno ="
                    strSQL &= "'" & chgsuji(dt.Rows(ro).Item(10).ToString) & "'"
                    strSQL &= "and  entry_date = '" & day.ToString("yyyy/MM/dd") & "'"

                    cnt = ClassPostgeDB.DbSel(strSQL)
                    If cnt = "0" Then
                        strSQL = " INSERT INTO " & schema & "t_002"
                        strSQL &= "(sls_typ, xpns_cd, ship_wh_cd, route_cd, fare_typ, cst_cd, cst_note, scnd_dler_tel, thrd_dler_tel, scst_nm, cst_po_no, ord_psn_nm, ord_psn_nm1, slip_rmrks, intr_rmrks, chrg_dpt_cd, bf_no, ac_cd, fa_no, zn_rcv_psn_cd, itm_cd, qty, upri, rate, cst_dsnt_subno, ja_inst_no, ja_upri, ja_upri_rate, uketukeno ,out_flg,entry_date)VALUES("
                        For cl = 0 To dt.Columns.Count - 1
                            If cl > 0 Then
                                strSQL &= ","
                            End If
                            strSQL &= "'" & dt.Rows(ro).Item(cl).ToString & "'"
                        Next
                        strSQL &= ",'" & chgsuji(dt.Rows(ro).Item(10).ToString) & "'"
                        strSQL &= ",'0'"
                        strSQL &= ",'" & day.ToString("yyyy/MM/dd") & "'"
                        strSQL &= ")"

                        ClassPostgeDB.EXEC(strSQL)
                    Else
                        dupliMsg &= vbCrLf & chgsuji(dt.Rows(ro).Item(10).ToString)
                        'If MsgBox("データが重複します。中断しますか", vbOKCancel) = vbOK Then
                        'MessageBox.Show("読み込みを中断します")
                        'Exit Sub
                        'End If
                    End If
                Catch ex As Exception
                    errMsg &= vbCrLf & chgsuji(dt.Rows(ro).Item(12).ToString)

                End Try
                Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) - 1) & "件"
                System.Windows.Forms.Application.DoEvents()

            Next

        Else

            If dt.Rows(0).Item(0).ToString() = "19700101" And
               dt.Rows(0).Item(2).ToString() = "売上区分" And
                dt.Rows(0).Item(3).ToString() = "管理区分" And
                dt.Rows(0).Item(4).ToString() = "出庫倉庫" And
                dt.Rows(0).Item(5).ToString() = "運送便" And
                dt.Rows(0).Item(6).ToString() = "運賃区分" And
                dt.Rows(0).Item(7).ToString() = "得意先" And
                dt.Rows(0).Item(8).ToString() = "得意先記事" And
                dt.Rows(0).Item(9).ToString() = "２次店" And
                dt.Rows(0).Item(10).ToString() = "３次店" And
                dt.Rows(0).Item(11).ToString() = "送り先名" And
                dt.Rows(0).Item(12).ToString() = "発注ＮＯ" And
                dt.Rows(0).Item(13).ToString() = "発注者漢字" And
                dt.Rows(0).Item(14).ToString() = "発注者カナ" And
                dt.Rows(0).Item(15).ToString() = "備考漢字" And
                dt.Rows(0).Item(16).ToString() = "備考カナ" And
                dt.Rows(0).Item(22).ToString() = "品コード" And
                dt.Rows(0).Item(23).ToString() = "数量" And
                dt.Rows(0).Item(24).ToString() = "単価" And
                dt.Rows(0).Item(25).ToString() = "売価率" And
                dt.Rows(0).Item(26).ToString() = "枝番" And
                dt.Rows(0).Item(27).ToString() = "明細発注ＮＯ" And
                dt.Rows(0).Item(28).ToString() = "農協価格" And
                dt.Rows(0).Item(29).ToString() = "農協価格率" Then


                Me.ToolStripStatusLabel2.Text = Integer.Parse(dt.Rows.Count - 1).ToString & "件"
            Else
                MessageBox.Show("ファイルが違います")
                Exit Sub
            End If

            For ro = 1 To dt.Rows.Count - 1

                Try

                    strSQL = "select count(uketukeno) from  " & schema & "t_002 where uketukeno ="
                    strSQL &= "'" & chgsuji(dt.Rows(ro).Item(12).ToString) & "'"
                    strSQL &= "and  entry_date = '" & yyyyTo(dt.Rows(ro).Item(0).ToString) & "'"

                    cnt = ClassPostgeDB.DbSel(strSQL)

                    If Integer.Parse(cnt) > 0 Then
                        'strSQL = "delete from  " & schema & "t_002 where uketukeno ="
                        'strSQL &= "'" & chgsuji(dt.Rows(ro).Item(12).ToString) & "'"
                        'strSQL &= "and  entry_date = '" & yyyyTo(dt.Rows(ro).Item(0).ToString) & "'"
                        'ClassPostgeDB.EXEC(strSQL)

                        dupliMsg &= vbCrLf & chgsuji(dt.Rows(ro).Item(12).ToString)

                    Else
                        strSQL = " INSERT INTO " & schema & "t_002"
                        strSQL &= "(sls_typ, xpns_cd, ship_wh_cd, route_cd, fare_typ, cst_cd, cst_note, scnd_dler_tel, thrd_dler_tel, scst_nm, cst_po_no, ord_psn_nm, ord_psn_nm1, slip_rmrks, intr_rmrks, chrg_dpt_cd, bf_no, ac_cd, fa_no, zn_rcv_psn_cd, itm_cd, qty, upri, rate, cst_dsnt_subno, ja_inst_no, ja_upri, ja_upri_rate, uketukeno ,out_flg,entry_date)VALUES("
                        For cl = 2 To dt.Columns.Count - 1
                            If cl > 2 Then
                                strSQL &= ","
                            End If
                            strSQL &= "'" & dt.Rows(ro).Item(cl).ToString & "'"
                        Next
                        strSQL &= ",'" & chgsuji(dt.Rows(ro).Item(12).ToString) & "'"
                        strSQL &= ",'0'"
                        strSQL &= ",'" & yyyyTo(dt.Rows(ro).Item(0).ToString) & "'"
                        strSQL &= ")"


                        ClassPostgeDB.EXEC(strSQL)
                    End If
                    'Else
                    'If MsgBox("データが重複します。中断しますか", vbOKCancel) = vbOK Then
                    'MessageBox.Show("読み込みを中断します")
                    'Exit Sub
                    'End If
                    'End If
                Catch ex As Exception
                    errMsg &= vbCrLf & chgsuji(dt.Rows(ro).Item(12).ToString)

                End Try
                Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) - 1) & "件"
                System.Windows.Forms.Application.DoEvents()
            Next
        End If

        If errMsg <> "" Then
            MessageBox.Show("下記受付番号にエラーがあります" & errMsg)
        ElseIf dupliMsg <> "" Then
            MessageBox.Show("下記受付番号に重複があります" & dupliMsg)
        Else
            MessageBox.Show("登録完了しました")
        End If

        ZenkaiSQL = String.Empty
        検索("1", "")
    End Sub

    Private Function CSV出庫Hader(cnt As Integer)
        Select Case cnt
            Case 1
                CSV出庫Hader = """syori_date"",""syori_date_seq"",""sls_typ"",""xpns_cd"",""ship_wh_cd"",""route_cd"",""fare_typ"",""cst_cd"",""cst_note"",""scnd_dler_tel"",""thrd_dler_tel"",""scst_nm"",""cst_po_no"",""ord_psn_nm"",""ord_psn_nm1"",""slip_rmrks"",""intr_rmrks"",""chrg_dpt_cd"",""bf_no"",""ac_cd"",""fa_no"",""zn_rcv_psn_cd"",""itm_cd"",""qty"",""upri"",""rate"",""cst_dsnt_subno"",""ja_inst_no"",""ja_upri"",""ja_upri_rate"""
            Case 2
                CSV出庫Hader = """処理日"",""順"",""売上区分"",""管理区分"",""出庫倉庫"",""運送便"",""運賃区分"",""得意先"",""得意先記事"",""２次店"",""３次店"",""送り先名"",""発注ＮＯ"",""発注者漢字"",""発注者カナ"",""備考漢字"",""備考カナ"",""負担部門"",""取得申請ＮＯ"",""勘定科目"",""固定資産管理ＮＯ"",""荷受人ＣＤ"",""品コード"",""数量"",""単価"",""売価率"",""枝番"",""明細発注ＮＯ"",""農協価格"",""農協価格率"""
            Case 3
                CSV出庫Hader = "syori_date,syori_date_seq,sls_typ,xpns_cd,ship_wh_cd,route_cd,fare_typ,cst_cd,cst_note,scnd_dler_tel,thrd_dler_tel,scst_nm,cst_po_no,ord_psn_nm,ord_psn_nm1,slip_rmrks,intr_rmrks,chrg_dpt_cd,bf_no,ac_cd,fa_no,zn_rcv_psn_cd,itm_cd,qty,upri,rate,cst_dsnt_subno,ja_inst_no,ja_upri,ja_upri_rate"
            Case 4
                CSV出庫Hader = "処理日,順,売上区分,管理区分,出庫倉庫,運送便,運賃区分,得意先,得意先記事,２次店,３次店,送り先名,発注ＮＯ,発注者漢字,発注者カナ,備考漢字,備考カナ,負担部門,取得申請ＮＯ,勘定科目,固定資産管理ＮＯ,荷受人ＣＤ,品コード,数量,単価,売価率,枝番,明細発注ＮＯ,農協価格,農協価格率"
            Case Else
                CSV出庫Hader = ""
        End Select

    End Function

    Private Sub CSVToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem1.Click
        '出力
        Dim ro As Integer
        Dim buf As String
        Dim fileName As String
        Dim ret As String
        If Me.DataGridView1.Rows.Count < 1 Then
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
            Exit Sub
        End If

        If Me.CheckBox出庫.Checked Then
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Rows(ro).Cells(8).Value = "3" Then
                    Me.DataGridView1.Rows(ro).Cells(0).Value = False
                End If
            Next
        End If

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.ToolStripStatusLabel2.Text = "0件"

        GetIniFile()
        fileName = FileSave(MaserFolder)
        If fileName = "" Then
            Exit Sub
        End If

        Dim sw As System.IO.StreamWriter = Nothing
        Try
            sw = New System.IO.StreamWriter(fileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
            sw.WriteLine(CSV出庫Hader(1))
            sw.WriteLine(CSV出庫Hader(2))

            Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count - 1
            Me.ToolStripProgressBar1.Step = 1

            For ro = 0 To Me.DataGridView1.Rows.Count - 1

                ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
                If ret = "" Then
                    ret = "0"
                End If

                If ret And Me.DataGridView1.Rows(ro).Cells(34).Value.ToString = "0" Then

                    buf = ""

                    buf &= """" & Me.DataGridView1.Rows(ro).Cells(6).Value & """"

                    For cl = 7 To 35 Step 1
                        buf &= ",""" & Me.DataGridView1.Rows(ro).Cells(cl).Value & """"
                    Next
                    sw.WriteLine(buf)

                    If Me.CheckBox出庫.Checked = True Then
                        出庫済み(Me.DataGridView1.Rows(ro).Cells(2).Value.ToString, Me.DataGridView1.Rows(ro).Cells(6).Value.ToString)
                    End If

                    Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) + 1) & "件"
                End If
                Me.ToolStripProgressBar1.Value = ro
            Next
        Catch ex As ArithmeticException
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            Me.ToolStripProgressBar1.Value = 0
            MessageBox.Show("出力しました")

            検索("1", Me.DateTimePicker日.Value)
        End Try
    End Sub

    Private Sub 全ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全ONToolStripMenuItem.Click
        Dim ro As Integer
        Me.DataGridView1.ClearSelection()
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = True
        Next
    End Sub

    Private Sub 全OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全OFFToolStripMenuItem.Click
        Dim ro As Integer
        Me.DataGridView1.ClearSelection()
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(8).Value = "3" Then
                Me.DataGridView1.Rows(ro).Cells(0).Value = False
            Else
                Me.DataGridView1.Rows(ro).Cells(0).Value = False
            End If
        Next
    End Sub

    Private Sub 反転ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転ToolStripMenuItem.Click
        Dim ro As Integer
        Me.DataGridView1.ClearSelection()
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(8).Value = "3" Then
                Me.DataGridView1.Rows(ro).Cells(0).Value = False
            Else
                Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
            End If

        Next
    End Sub
    Private Sub 選択ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択ONToolStripMenuItem.Click
        Dim ro As Integer
        Me.DataGridView1.ClearSelection()
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(8).Value.ToString = "3" Then
                Me.DataGridView1.Rows(ro).Cells(0).Value = False

            Else

                If Me.DataGridView1.Rows(ro).Cells(3).Value.ToString = "停止" Then
                    Me.DataGridView1.Rows(ro).Cells(0).Value = False
                Else
                    Me.DataGridView1.Rows(ro).Cells(0).Value = True
                End If

                If Me.DataGridView1.Rows(ro).Cells(1).Value.ToString = "重" Then
                    Me.DataGridView1.Rows(ro).Cells(0).Value = False
                End If

            End If
        Next

    End Sub
    Private Sub 選択削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択削除ToolStripMenuItem.Click

        Dim strSQL As String
        Dim ro As Integer
        Dim ret As String
        Dim a As String = "20201231"
        Dim b As Integer = Integer.Parse(a)
        Dim result As String = b.ToString("0000/00/00")


        Me.DataGridView1.CurrentCell = Nothing
        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Me.ToolStripStatusLabel2.Text = "0件"
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            If ret = "" Then
                ret = "0"
            End If

            If ret Then

                a = Me.DataGridView1.Rows(ro).Cells(6).Value.ToString()
                b = Integer.Parse(a)
                result = b.ToString("0000/00/00")

                'strSQL = "delete  from " & schema & "t_002 where uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(1).Value.ToString & "' and  entry_date  ='"
                strSQL = "update  " & schema & "t_002    set  entry = 'DELETE'  where uketukeno = '" & Me.DataGridView1.Rows(ro).Cells(2).Value.ToString & "'"
                strSQL &= " and  entry_date  = '" & result & "'"        '20230425 -> 2023/04/05

                ClassPostgeDB.EXEC(strSQL)
                Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) + 1) & "件"
            End If
        Next

        ZenkaiSQL = String.Empty

        検索("1", "")
    End Sub

    Private Sub 入力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 入力ToolStripMenuItem.Click

    End Sub

    Private Sub 削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 削除ToolStripMenuItem.Click

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        Dim ro = e.RowIndex
        Dim co = e.ColumnIndex

        If ro >= 0 And e.Button = MouseButtons.Left Then
            If co = 0 Then
                If Me.DataGridView1.Rows(ro).Cells(8).Value = "3" Then
                    Me.DataGridView1.Rows(ro).Cells(0).Value = False
                End If
            Else
                FormInput.TextBox点検受付番号.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
                FormInput.TextBoxDM番号.Text = GetDMno(Me.DataGridView1.Rows(ro).Cells(2).Value.ToString)

                FormInput.TextBox得意先コード.Text = Me.DataGridView1.Rows(ro).Cells(13).Value.ToString

                FormInput.sls_typ = Me.DataGridView1.Rows(ro).Cells(8).Value.ToString
                FormInput.cst_cd = Me.DataGridView1.Rows(ro).Cells(13).Value.ToString
                FormInput.entry_date = Me.DataGridView1.Rows(ro).Cells(6).Value.ToString

                FormInput.UserID = UserID
                FormInput.UserName = UserName
                FormInput.Kengen = Kengen
                If FormInput.ShowDialog() = DialogResult.OK Then
                    検索("1", "")
                End If
            End If
        End If


    End Sub

    Private Sub 出庫済みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出庫済みToolStripMenuItem.Click
        Dim ro As Integer
        Dim ret As String
        Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count


        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.ToolStripStatusLabel2.Text = "0件"
        Me.DataGridView1.CurrentCell = Nothing
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            If ret = "" Then
                ret = "0"
            End If

            If ret Then

                出庫済み(Me.DataGridView1.Rows(ro).Cells(2).Value.ToString, Me.DataGridView1.Rows(ro).Cells(6).Value.ToString)
                Me.ToolStripProgressBar1.Value = ro
                Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) + 1) & "件"

            End If
        Next

        検索("1", "")
        Me.ToolStripProgressBar1.Value = 0

    End Sub

    Private Sub 未出庫にするToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 未出庫にするToolStripMenuItem.Click
        Dim ro As Integer
        Dim ret As String

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.ToolStripStatusLabel2.Text = "0件"
        Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count

        Me.DataGridView1.CurrentCell = Nothing

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            If ret = "" Then
                ret = "0"
            End If

            If ret Then
                未出庫済み(Me.DataGridView1.Rows(ro).Cells(2).Value.ToString, Me.DataGridView1.Rows(ro).Cells(6).Value.ToString)
                Me.ToolStripProgressBar1.Value = ro
                Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) + 1) & "件"
            End If
        Next
        検索("1", "")
        Me.ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub 出庫済み(CimNo As String, EntDay As String)
        Dim strSQL As String
        strSQL = "update " & schema & "t_002 set out_flg ='1' , nextb  =  to_char(current_timestamp, 'YYYY/MM/DD') where uketukeno ='" & CimNo & "'"
        strSQL &= " AND replace(entry_date,'/','') = '" & EntDay & "'"
        ClassPostgeDB.EXEC(strSQL)
    End Sub

    Private Sub 未出庫済み(CimNo As String, yymm As String)
        Dim strSQL As String
        yymm = yymm.Substring(0, 4) & "/" & yymm.Substring(4, 2) & "/" & yymm.Substring(6, 2)

        strSQL = "update " & schema & "t_002 set out_flg ='0' , nextb  =  '' where uketukeno ='" & CimNo & "' and entry_date = '" & yymm & "' and sls_typ ='1'"

        ClassPostgeDB.EXEC(strSQL)
    End Sub



    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        ZenkaiSQL = String.Empty
        検索("2", Me.TextBox受付番号.Text)
    End Sub

    Private Sub Button検索日_Click(sender As Object, e As EventArgs) Handles Button検索日.Click
        ZenkaiSQL = String.Empty
        検索("3", "")
    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        ZenkaiSQL = String.Empty
        検索("1", "")

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Me.CheckBox出庫.Checked Then
                For ro = 0 To Me.DataGridView1.Rows.Count - 1
                    If Me.DataGridView1.Rows(ro).Cells(8).Value = "3" Then
                        Me.DataGridView1.Rows(ro).Cells(0).Value = False
                    End If





                Next
            End If
            Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            excelOutDataGred4(Me.DataGridView1, True, Me.ToolStripProgressBar1)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If

    End Sub

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'EXCEL 出力
    Public Sub excelOutDataGred4(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar)
        '
        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing


        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 4
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count
        Dim ret As String

        pb.Maximum = 4 + rowMaxNum + columnMaxNum
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        'For i As Integer = 5 To (columnMaxNum) - 2
        'columnList.Add(dgv.Columns(i).HeaderCell.Value)
        'Next
        'Dim str1 As String = CSV出庫Hader(3)
        Dim arr1() As String = CSV出庫Hader(3).Split(",")
        Dim i As Integer

        i = 1
        For Each c In arr1
            Console.WriteLine(c) '
            objWorkBook.Sheets(1).Cells(1, i) = c

            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
            i = i + 1

        Next

        'Dim str2 As String = CSV出庫Hader(4)
        Dim arr2() As String = CSV出庫Hader(4).Split(",")
        i = 1
        For Each c In arr2
            objWorkBook.Sheets(1).Cells(2, i) = c

            objWorkBook.Sheets(1).Cells(2, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(2, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(2, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(2, i).Font.Bold = True
            i = i + 1

        Next
        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum + 1) {}

        Dim row1 As Integer
        row1 = 0
        For row As Integer = 0 To rowMaxNum
            Try
                ret = dgv.Rows(row).Cells(0).Value.ToString
            Catch ex As Exception
                ret = "0"
            End Try
            If ret = "" Then
                ret = "0"
            End If

            If ret Then
                For col As Integer = 2 To columnMaxNum - 1
                    If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                        ' セルに値が入っている場合、二次元配列に格納
                        v(row1, col - 2) = dgv.Rows(row).Cells(col + 4).Value.ToString()
                    End If
                Next
                '出庫済み
                If Me.CheckBox出庫.Checked = True Then
                    出庫済み(dgv.Rows(row).Cells(2).Value.ToString, dgv.Rows(row).Cells(6).Value.ToString)
                End If

                row1 = row1 + 1
            End If

            pb.Value = pb.Value + 1
        Next

        ' EXCELにデータを範囲指定で転送
        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        columnMaxNum = columnMaxNum - 3
        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1)
        End If

        Dim data As String = "A3:" & coln & row1 + 2
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete


        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0
        検索("1", "")

    End Sub

    Private Sub 選択赤作成ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択赤作成ToolStripMenuItem.Click

        Dim ro As Integer
        Dim ret As String
        Dim strSQL As String
        Dim dl As DataTable
        Dim dy As Date
        Dim akakinn As Integer
        Dim seq As String


        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.ToolStripStatusLabel2.Text = "0件"
        Me.DataGridView1.CurrentCell = Nothing

        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            ret = Me.DataGridView1.Rows(ro).Cells(8).Value.ToString

            If ret = "1" Then   'sls_typ = 1 のみ
                ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
                If ret = "" Then
                    ret = "0"
                End If
                If ret Then

                    Dim fm As New FormSub002
                    fm.UserID = UserID
                    fm.Kengen = Kengen
                    fm.UserName = UserName
                    fm.AkaKUro = "1"
                    fm.NumericUpDown金額.Value = Me.DataGridView1.Rows(ro).Cells(30).Value
                    fm.Label発注No.Text = Me.DataGridView1.Rows(ro).Cells(18).Value
                    fm.ShowDialog()
                    If w002Exe = True Then

                        dl = ClassPostgeDB.SetTable("select t.entry_date ,t.nextb ,t.entry from " & schema & "t_002 t where t.uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(2).Value & "' order by t.entry , t.entry_date desc")

                        akakinn = Integer.Parse(w002金額)
                        If akakinn > 0 Then
                            akakinn = akakinn * -1
                        End If

                        seq = GetSeq(Me.DataGridView1.Rows(ro).Cells(2).Value)
                        dy = dl.Rows(0).Item(0).ToString
                        dy = dy.AddDays(-1)

                        strSQL = "INSERT INTO " & schema & "t_002(sls_typ, cst_cd,  cst_po_no,   ord_psn_nm,  slip_rmrks, intr_rmrks,  itm_cd, qty, upri  , uketukeno ,  out_flg , entry_date,  nextb, entry, del_flg,tyoufuku,seq)VALUES("
                        strSQL &= "'3'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(13).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(18).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(19).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(21).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(22).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(28).Value & "'"
                        strSQL &= "," & Me.DataGridView1.Rows(ro).Cells(29).Value & ""


                        'strSQL &= "," & Integer.Parse(Me.DataGridView1.Rows(ro).Cells(30).Value) * -1 & ""
                        strSQL &= "," & akakinn & ""

                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(2).Value & "'"
                        strSQL &= ",'1'"

                        strSQL &= ",'" & dy.ToShortDateString & "'"

                        strSQL &= ",'" & w002伝票発行日 & "'" 'nextb

                        strSQL &= ",'" & dl.Rows(0).Item(2).ToString & "'"

                        strSQL &= ",'0'"

                        If seq = "0" Then
                            strSQL &= ",null,'" & seq & "'"
                        Else
                            strSQL &= ",'重','" & seq & "'"
                        End If

                        strSQL &= ")"
                        ClassPostgeDB.EXEC(strSQL)

                        If seq = "0" Then
                            strSQL = "UPDATE  " & schema & "t_002 SET tyoufuku =null where uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(2).Value & "'"
                        Else
                            strSQL = "UPDATE  " & schema & "t_002 SET tyoufuku ='重' where uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(2).Value & "'"
                        End If
                        ClassPostgeDB.EXEC(strSQL)


                    End If
                End If
            End If
        Next
        検索("1", "")
    End Sub


    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        TeisiColor()
        BackcolorChg()
    End Sub

    Private Sub 選択黒伝票作成ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択黒伝票作成ToolStripMenuItem.Click
        Dim ro As Integer
        Dim ret As String
        Dim strSQL As String
        Dim seq As String
        'Dim dl As DataTable
        'Dim dy As Date

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Me.DataGridView1.CurrentCell = Nothing

        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            ret = Me.DataGridView1.Rows(ro).Cells(8).Value.ToString

            If ret = "1" Then   'sls_typ = 1 のみ
                ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString             'チェック
                If ret = "" Then
                    ret = "0"
                End If
                If ret Then
                    Dim fm As New FormSub002
                    fm.UserID = UserID
                    fm.Kengen = Kengen
                    fm.UserName = UserName
                    fm.AkaKUro = "0"
                    w002得意先 = Me.DataGridView1.Rows(ro).Cells(13).Value
                    fm.NumericUpDown金額.Value = Me.DataGridView1.Rows(ro).Cells(30).Value
                    fm.Label発注No.Text = Me.DataGridView1.Rows(ro).Cells(18).Value
                    fm.ShowDialog()
                    If w002Exe = True Then

                        seq = GetSeq(Me.DataGridView1.Rows(ro).Cells(2).Value)


                        strSQL = "INSERT INTO " & schema & "t_002 (sls_typ, xpns_cd, ship_wh_cd, route_cd, fare_typ, cst_cd, cst_note, scnd_dler_tel, thrd_dler_tel, scst_nm, cst_po_no, ord_psn_nm, ord_psn_nm1, slip_rmrks, intr_rmrks, chrg_dpt_cd, bf_no, ac_cd, fa_no, zn_rcv_psn_cd, itm_cd, qty, upri, rate, cst_dsnt_subno, ja_inst_no, ja_upri, ja_upri_rate"
                        strSQL &= ", uketukeno, out_flg, entry_date, nextb, entry, del_flg, tyoufuku,seq) VALUES("
                        strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(8).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(9).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(10).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(11).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(12).Value & "'"
                        strSQL &= ",'" & w002得意先 & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(14).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(15).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(16).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(17).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(18).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(19).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(20).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(21).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(22).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(23).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(24).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(25).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(26).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(27).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(28).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(29).Value & "'"
                        strSQL &= ",'" & w002金額 & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(31).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(32).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(33).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(34).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(35).Value & "'"

                        strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(2).Value & "'"
                        strSQL &= ",'0'"
                        strSQL &= ",to_char(now(),'YYYY/MM/DD')"
                        strSQL &= ",to_char(now(),'YYYY/MM/DD')"
                        strSQL &= ",''"
                        strSQL &= ",''"
                        If seq = "0" Then
                            strSQL &= ",null,'" & seq & "'"
                        Else
                            strSQL &= ",'重','" & seq & "'"
                        End If
                        strSQL &= ")"

                        ClassPostgeDB.EXEC(strSQL)


                        If seq = "0" Then
                            strSQL = "UPDATE  " & schema & "t_002 SET tyoufuku =null where uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(2).Value & "'"
                        Else
                            strSQL = "UPDATE  " & schema & "t_002 SET tyoufuku ='重' where uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(2).Value & "'"
                        End If
                        ClassPostgeDB.EXEC(strSQL)


                    End If
                End If
            End If
        Next
        検索("1", "")

    End Sub

    Private Sub 選択削除を戻すToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 選択削除を戻すToolStripMenuItem1.Click


        Dim strSQL As String
        Dim ro As Integer
        Dim ret As String
        Dim a As String = "20201231"
        Dim b As Integer = Integer.Parse(a)
        Dim result As String = b.ToString("0000/00/00")


        Me.DataGridView1.CurrentCell = Nothing
        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Me.ToolStripStatusLabel2.Text = "0件"
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
            If ret = "" Then
                ret = "0"
            End If

            If ret Then

                a = Me.DataGridView1.Rows(ro).Cells(6).Value.ToString()
                b = Integer.Parse(a)
                result = b.ToString("0000/00/00")

                'strSQL = "delete  from " & schema & "t_002 where uketukeno ='" & Me.DataGridView1.Rows(ro).Cells(1).Value.ToString & "' and  entry_date  ='"
                strSQL = "update  " & schema & "t_002    set  entry = NULL  where uketukeno = '" & Me.DataGridView1.Rows(ro).Cells(2).Value.ToString & "'"
                strSQL &= " and  entry_date  = '" & result & "'"        '20230425 -> 2023/04/05

                ClassPostgeDB.EXEC(strSQL)
                Me.ToolStripStatusLabel2.Text = (Integer.Parse(Me.ToolStripStatusLabel2.Text.Replace("件", "")) + 1) & "件"
            End If
        Next

        'ZenkaiSQL = String.Empty

        検索("1", "")
    End Sub
    ' 重複の処理
    '
    '
    Private Sub JyuFukuSYori()
        Dim strSQL As String
        Dim dt As New DataTable
        Dim dno As New DataTable
        Dim uno As String
        Dim seq As Integer

        strSQL = "update " & schema & "t_002 set  seq=0  where  uketukeno in ("
        strSQL &= "select a.uketukeno  from " & schema & "t_002 a where a.uketukeno in (select uketukeno from " & schema & "t_002  group by  uketukeno  having count(*) < 2)  and a.tyoufuku = '重')"
        ClassPostgeDB.EXEC(strSQL)

        Return

        strSQL = "update " & schema & "t_002 set tyoufuku ='重' where  uketukeno in ("
        strSQL &= "select a.uketukeno  from " & schema & "t_002 a where a.uketukeno in (select uketukeno from " & schema & "t_002  group by  uketukeno  having count(*) > 1) and a.tyoufuku != '重')"
        ClassPostgeDB.EXEC(strSQL)


        strSQL = "select t.uketukeno from " & schema & "t_002 t  where t.tyoufuku ='重'  and seq=0 group by t.uketukeno  "
        dt = ClassPostgeDB.SetTable(strSQL)
        uno = ""
        seq = 0
        For Each dtrow In dt.Rows
            seq = 0
            uno = dtrow(0).ToString
            strSQL = "select t.uketukeno ,t.entry_date from " & schema & "t_002 t  where t.uketukeno  = '" & uno & "' order by t.entry_date asc"
            dno = ClassPostgeDB.SetTable(strSQL)
            For Each dnorow In dno.Rows
                strSQL = "update " & schema & "t_002 set seq= " & seq & " where uketukeno = '" & dnorow(0).ToString & "' and entry_date ='" & dnorow(1).ToString & "'"
                ClassPostgeDB.EXEC(strSQL)
                seq = seq + 1
            Next
        Next
    End Sub

    Function GetSeq(uno As String)
        Dim strSQL As String
        Dim dt As New DataTable
        strSQL = "SELECT max(seq) +1 from  " & schema & "t_002 WHERE uketukeno = '" & uno & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0).ToString
        Else
            Return "0"
        End If

    End Function

    Private Sub CheckBoxCIM_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCIM.CheckedChanged
        If CheckBoxCIM.Checked Then
            CheckBox出庫.Visible = True
            Label5.Visible = True
        Else
            CheckBox出庫.Visible = False
            Label5.Visible = False
        End If
    End Sub

    ' ///////
End Class