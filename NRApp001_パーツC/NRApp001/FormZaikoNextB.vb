Public Class FormZaikoNextB

    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
    Dim bar As Integer
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

    Private Sub FormZaikoNextB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Me.ToolStripStatusLabel1.Text = ""
        strSQL = "DELETE FROM " & schema & "t_idou_next"
        ClassPostgeDB.EXEC(strSQL)

        KibouNouki()

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub KibouNouki()
        Dim strSQL As String

        strSQL = "select to_char(t.kibounouki,'YYYY/MM/DD')  from " & schema & "t_idou_zaiko t  where t.kibounouki is not null and t.hojyusuu > 0  group by to_char(t.kibounouki,'YYYY/MM/DD')"
        Dim dt As DataTable
        dt = ClassPostgeDB.SetTable(strSQL)
        Me.ComboBox希望納期.Items.Clear()

        If dt.Rows.Count > 0 Then
            For Each dd In dt.Rows
                Me.ComboBox希望納期.Items.Add(dd(0).ToString)
            Next
            Me.Button在庫移動作成.Visible = True
        Else
            MessageBox.Show("希望納期の設定がありません")
            Me.Button在庫移動作成.Visible = False
        End If


    End Sub

    Private Sub Button在庫移動作成_Click(sender As Object, e As EventArgs) Handles Button在庫移動作成.Click
        If Me.ComboBox希望納期.Text <> "" Then
            Me.ToolStripStatusLabel1.Text = "処理中"
            Cursor.Current = Cursors.WaitCursor
            System.Windows.Forms.Application.DoEvents()
            ZaikoSakusei()
            Next出力()
            KibouNouki()
            Cursor.Current = Cursors.Default
            Me.ToolStripStatusLabel1.Text = ""
        End If

    End Sub
    Private Sub ZaikoSakusei()
        Dim dt As DataTable
        Dim strSQL As String
        Dim seqno As Integer = 0
        Dim nouki As Date
        Dim rmrks As String
        Dim cst_po_no As String
        Dim ruuru As String
        Dim itm_cd As String
        Dim ord_qty As String
        Dim rqst_dlv_dt As String
        Dim d As Integer
        Dim jyutyuusuu As Integer


        strSQL = "SELECT sinacd,  hojyusuu,  souko,  ruuru  , COALESCE(m_system.naiyou2,'0') , COALESCE(jyutyuusuu,0) FROM  " & schema & "t_idou_zaiko "
        strSQL &= " left outer join " & schema & "m_system  on t_idou_zaiko.souko= m_system.naiyou and m_system.kbn ='2'"
        strSQL &= " where hojyusuu > 0"
        strSQL &= " and  to_char(kibounouki,'YYYY/MM/DD')  = '" & Me.ComboBox希望納期.Text & "'"

        dt = ClassPostgeDB.SetTable(strSQL)

        For Each dtrow In dt.Rows

            ruuru = dtrow(3).ToString
            If Integer.TryParse(ruuru, d) Then
                If Integer.Parse(ruuru) > 0 Then

                Else
                    ruuru = ""
                End If
            End If

            nouki = Today.AddDays(Integer.Parse(dtrow(4).ToString))

            rmrks = StrConv(Today.ToShortDateString & "ＷＥＢ在庫", vbWide)
            cst_po_no = (Today.ToShortDateString & "_" & dtrow(2).ToString).Replace("/", "") '倉庫番号

            rqst_dlv_dt = nouki.ToShortDateString.Replace("/", "")

            itm_cd = dtrow(0).ToString
            ord_qty = dtrow(1).ToString
            jyutyuusuu = Integer.Parse(dtrow(5).ToString)

            If ruuru = "" Then
                strSQL = CreateSQL(rqst_dlv_dt, cst_po_no, rmrks, itm_cd, ord_qty, seqno)
                ClassPostgeDB.EXEC(strSQL)

                jyutyuusuu = jyutyuusuu + Integer.Parse(ord_qty)

                strSQL = "update " & schema & "t_idou_zaiko set jyutyuusuu =  jyutyuusuu  + " & jyutyuusuu & ", hojyusuu=0 where sinacd ='" & itm_cd & "'"
                ClassPostgeDB.EXEC(strSQL)

                seqno = seqno + 1


            ElseIf ruuru = "個別" Then

                For i As Integer = 1 To Integer.Parse(ord_qty)
                    strSQL = CreateSQL(rqst_dlv_dt, cst_po_no, rmrks, itm_cd, "1", seqno)
                    ClassPostgeDB.EXEC(strSQL)
                    seqno = seqno + 1

                Next

                jyutyuusuu = jyutyuusuu + Integer.Parse(ord_qty)

                strSQL = "update " & schema & "t_idou_zaiko set jyutyuusuu =  jyutyuusuu + " & jyutyuusuu & ", hojyusuu=0 where sinacd ='" & itm_cd & "'"
                ClassPostgeDB.EXEC(strSQL)


            ElseIf Integer.TryParse(ruuru, d) Then
                strSQL = CreateSQL(rqst_dlv_dt, cst_po_no, rmrks, itm_cd, ord_qty, seqno)
                ClassPostgeDB.EXEC(strSQL)
                seqno = seqno + 1
                'If Integer.Parse(ruuru) > 0 Then
                'strSQL = CreateSQL(rqst_dlv_dt, cst_po_no, rmrks, itm_cd, ruuru, seqno)
                'ClassPostgeDB.EXEC(strSQL)
                'seqno = seqno + 1
                'Dim suu As Integer = Integer.Parse(ord_qty)
                'suu = suu - Integer.Parse(ruuru)
                'jyutyuusuu = jyutyuusuu + Integer.Parse(ruuru)
                'Do While suu > 0
                'strSQL = CreateSQL(rqst_dlv_dt, cst_po_no, rmrks, itm_cd, ruuru, seqno)
                'ClassPostgeDB.EXEC(strSQL)
                'seqno = seqno + 1

                'suu = suu - Integer.Parse(ruuru)
                'jyutyuusuu = jyutyuusuu + Integer.Parse(ruuru)
                'Loop

                strSQL = "update " & schema & "t_idou_zaiko set jyutyuusuu =  jyutyuusuu  + " & ord_qty & ", hojyusuu=0 where sinacd ='" & itm_cd & "'"
                ClassPostgeDB.EXEC(strSQL)
                'End If
            Else


            End If
        Next

    End Sub
    Private Function CreateSQL(rqst_dlv_dt As String, cst_po_no As String, rmrks As String, itm_cd As String, ord_qty As String, seqno As String) As String
        Dim strSQL As String = String.Empty
        strSQL = "INSERT INTO " & schema & "t_idou_next (cst_cmp_cd, rqst_dlv_dt, sls_typ, xpns_cd, assort_typ, cst_cd, scnd_dler_cd, thrd_dler_cd, cst_scst_cd, scst_cd, scst_nm, zip_cd, scst_addr1, scst_addr2, cst_po_no, ord_psn_nm, ord_psn_nm1, rmrks, intr_rmrks, prod_fare_typ, fare_typ, fare_subno, fax_needl_typ, cst_itm_cd, itm_cd, ord_qty, dsnt_upri, cst_dsnt_subno, d_rqst_dlv_dt, ja_inst_no, ja_upri, ""zone"", urgent_cntct_tel, urgent_cntct_nm, chrg_dpt_cd, ac_cd, bf_no, entryday, entrysya, updateday, updatesya, outday, outsya, oderno, seq) VALUES("
        strSQL &= "'0000CR'"
        strSQL &= ",'" & rqst_dlv_dt & "'" '""rqst_dlv_dt"
        strSQL &= ",'3'"
        strSQL &= ",'5'"
        strSQL &= ",'3'"
        strSQL &= ",'0000CR'"
        strSQL &= ",''"
        strSQL &= ",''"
        strSQL &= ",''"                    '送り先区分　（相手先送り先ＣＤまたは送り先ＣＤを入力すると「4:送り先」、どちらも空白の場合は「5:現地」）
        strSQL &= ",'079-492-6639'"
        strSQL &= ",''" '   "scst_nm"
        strSQL &= ",''" '   "zip_cd"
        strSQL &= ",''" '   "scst_addr1"
        strSQL &= ",''" '   "scst_addr2"
        strSQL &= ",'" & cst_po_no & "'" '"cst_po_no"
        strSQL &= ",'お客さまパーツＣ'" '"ord_psn_nm"
        strSQL &= ",''" '   ""ord_psn_nm1"
        strSQL &= ",'" & rmrks & "'" '   ""rmrks"
        strSQL &= ",''" '   ""intr_rmrks"
        strSQL &= ",''" '   ""prod_fare_typ"
        strSQL &= ",''" '   ""fare_typ"
        strSQL &= ",''" '   ""fare_subno"
        strSQL &= ",''" '   ""fax_needl_typ"
        strSQL &= ",''" '   ""cst_itm_cd"
        strSQL &= ",'" & itm_cd & "'"        'itm_cd
        strSQL &= ",'" & ord_qty & "'"  '   ""ord_qty"
        strSQL &= ",''" '   ""dsnt_upri"
        strSQL &= ",''" '   ""cst_dsnt_subno"
        strSQL &= ",''" '   ""d_rqst_dlv_dt"
        strSQL &= ",''" '   ""ja_inst_no"
        strSQL &= ",''" '   ""ja_upri"
        strSQL &= ",''" '   ""zone"
        strSQL &= ",''" '   ""urgent_cntct_tel"
        strSQL &= ",''" '   ""urgent_cntct_nm"
        strSQL &= ",''" '   ""chrg_dpt_cd"
        strSQL &= ",''" '   ""ac_cd"
        strSQL &= ",''" '   ""bf_no"

        strSQL &= ",now()"
        strSQL &= ",'" & UserName & "'"
        strSQL &= ",null "
        strSQL &= ",null"
        strSQL &= ",null"
        strSQL &= ",null"
        strSQL &= ",null"
        strSQL &= "," & seqno & ""
        strSQL &= ")"

        Return strSQL
    End Function

    Private Sub ButtonNEXTB出力_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub Next出力()
        Dim strSQL As String
        Dim dt As DataTable

        strSQL = "SELECT cst_cmp_cd, rqst_dlv_dt, sls_typ, xpns_cd, assort_typ, cst_cd, scnd_dler_cd, thrd_dler_cd, cst_scst_cd, scst_cd, scst_nm, zip_cd, scst_addr1, scst_addr2, cst_po_no, ord_psn_nm, ord_psn_nm1, rmrks, intr_rmrks, prod_fare_typ, fare_typ, fare_subno, fax_needl_typ, cst_itm_cd, itm_cd, ord_qty, dsnt_upri, cst_dsnt_subno, d_rqst_dlv_dt, ja_inst_no, ja_upri, zone, urgent_cntct_tel, urgent_cntct_nm, chrg_dpt_cd, ac_cd, bf_no"
        'strSQL &= ", entryday, seq"
        strSQL &= " FROM " & schema & "t_idou_next "
        strSQL &= " WHERE  outday is null"

        dt = ClassPostgeDB.SetTable(strSQL)

        ClassPostgeDB.EXEC("update " & schema & "t_idou_next  set  outday = now() where outday is null")

        ToExcelNext(dt)


    End Sub






End Class