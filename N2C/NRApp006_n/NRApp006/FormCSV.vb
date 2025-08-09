Public Class FormCSV
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim strSQL1 As String 'ステータス名
    Dim strSQL2 As String '回収区分
    Dim strSQL31 As String '期間 t
    Dim strSQL32 As String '期間 t1
    Dim strSQL4 As String '点検状態区分名称
    Dim strSQL5 As String　'請求先

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

    Private Sub FormCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " Version[" & Ver & "] "
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報
        Me.ToolStripStatusLabel件数.Text = ""

        Dim dtToday As DateTime = DateTime.Today
        Me.DataGridView1.RowHeadersWidth = 10

        Me.TextBox点検受付番号.Text = ""
        Me.TextBoxDM番号.Text = ""

        Me.DateTimePicker期間1.Value = dtToday.AddMonths(0 - Integer.Parse(GetSystemto("2", "1")))
        Me.DateTimePicker期間2.Value = dtToday

        GetSystemtoCombo("'10'", Me.ComboBox期間, "")
        Me.ComboBox期間.SelectedIndex = 1

        Me.Button集約.Visible = False

        If ChkNewOld() Then
            Me.CheckBoxCIM.Checked = True
        Else
            Me.CheckBoxCIM.Checked = False
        End If
    End Sub

    Private Sub CSV選択ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSV選択ToolStripMenuItem.Click
        Dim strSQL As String = String.Empty
        Dim dt As New DataTable
        Dim fast As Boolean = False

        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        System.Windows.Forms.Application.DoEvents()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        strSQL = "Select "
        strSQL &= SetSQL()

        If Me.CheckBox集約データ.Checked Then

            strSQL &= SetSQLAll()

        End If

        strSQL &= " FROM " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " left OUTER JOIN " & schema & "t_teisei t1"
        strSQL &= " on t.点検受付番号 = t1.点検受付番号 "
        strSQL &= " LEFT OUTER JOIN " & schema & "t_check t2"
        strSQL &= " on t.点検受付番号 =t2.点検受付番号 "


        If Me.TextBox点検受付番号.Text <> "" Or Me.TextBoxDM番号.Text <> "" Then
            If Me.TextBox点検受付番号.Text <> "" Then
                strSQL &= " where t.点検受付番号 = '" & Me.TextBox点検受付番号.Text & "'"
            Else
                strSQL &= " where t.ｄｍ番号 = '" & Me.TextBoxDM番号.Text & "'"
            End If
        Else
            検索条件()

            strSQL &= " where t.点検受付番号 is not null "

            strSQL &= " and t.ステータス名 in (" & strSQL1 & ")"
            strSQL &= " and t.回収区分 in(" & strSQL2 & ")"
            strSQL &= " and t.点検状態区分名称 In (" & strSQL4 & ")"

            strSQL &= strSQL31 'As String '期間 t
            'strSQL &= strSQL32 'As String '期間 t1
            strSQL &= strSQL5 'As String　'請求先

        End If
        If CheckBoxCIM.Checked Then


        Else
            strSQL &= " and t.newflg  >0 "
        End If


        strSQL &= " order by t1.ステータス asc ,t.更新日 desc"


        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.DataSource = dt

        If Me.DataGridView1.Rows.Count > 0 Then

            Me.DataGridView1.Columns(0).Width = 100
            Me.DataGridView1.Columns(1).Width = 120
            Me.DataGridView1.Columns(2).Width = 100
            Me.DataGridView1.Columns(3).Width = 40
            Me.DataGridView1.Columns(4).Width = 40
            Me.DataGridView1.Columns(5).Width = 100
            Me.DataGridView1.Columns(6).Width = 60
            Me.DataGridView1.Columns(7).Width = 80

            'For Each c As DataGridViewColumn In DataGridView1.Columns
            ' c.SortMode = DataGridViewColumnSortMode.Automatic
            ' Next c
            Me.DataGridView1.AllowUserToAddRows = False

            CIM更新チェック()
            Me.Button集約.Visible = True

        End If

        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub
    Private Sub CIM更新チェック()

        If Me.CheckBox集約データ.Checked Then

        Else
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                'CIM更新チェック
                If Me.DataGridView1.Rows(ro).Cells(5).Value.ToString() <> "" Then
                    If Me.DataGridView1.Rows(ro).Cells(5).Value.ToString() < Me.DataGridView1.Rows(ro).Cells(43).Value.ToString() Then
                        Me.DataGridView1.Rows(ro).Cells(0).Style.BackColor = Color.Yellow
                        Me.DataGridView1.Rows(ro).Cells(5).Style.BackColor = Color.Yellow
                    End If
                End If
            Next
        End If
    End Sub

    Private Function 検索条件2()
        Dim strSQL31 As String
        strSQL31 = ""

        If Me.ComboBox期間.Text <> "" Then
            strSQL31 = " where " & Me.ComboBox期間.Text & " BETWEEN '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        Else
            strSQL31 = " where 更新日  BETWEEN '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        End If
        Return strSQL31
    End Function
#Region "検索条件"
    Private Sub 検索条件()
        Dim fast As Boolean

        '--------ステータス
        fast = False
        strSQL1 = ""
        If Me.CheckBox点検受付.Checked Then
            fast = True
            strSQL1 &= " '点検受付'"
        End If
        If Me.CheckBox点検完了.Checked Then
            If fast Then
                strSQL1 &= ","
            End If
            fast = True
            strSQL1 &= "'点検完了'"
        End If
        If Me.CheckBox請求書発行済.Checked Then
            If fast Then
                strSQL1 &= ","
            End If
            fast = True
            strSQL1 &= "'請求書発行済'"
        End If
        If Me.CheckBox回収完了.Checked Then
            If fast Then
                strSQL1 &= ","
            End If
            fast = True
            strSQL1 &= "'回収完了'"
        End If

        If Me.CheckBox受付ｷｬﾝｾﾙ.Checked Then
            If fast Then
                strSQL1 &= ","
            End If
            fast = True
            strSQL1 &= "'受付ｷｬﾝｾﾙ'"
        End If
        If Me.CheckBox訪問前ｷｬﾝｾﾙ.Checked Then
            If fast Then
                strSQL1 &= ","
            End If
            fast = True
            strSQL1 &= "'訪問前ｷｬﾝｾﾙ'"
        End If
        If Me.CheckBox訪問ｷｬﾝｾﾙ.Checked Then
            If fast Then
                strSQL1 &= ","
            End If
            fast = True
            strSQL1 &= "'訪問ｷｬﾝｾﾙ'"
        End If

        strSQL1 &= ""

        '--------回収区分
        fast = False
        strSQL2 = ""
        If Me.CheckBoxSS現金徴収.Checked Then
            fast = True
            strSQL2 &= "'SS現金徴収'"
        End If
        If Me.CheckBoxSS後日請求.Checked Then
            If fast Then
                strSQL2 &= ","
            End If
            fast = True
            strSQL2 &= "'SS後日請求'"
        End If
        If Me.CheckBoxNR後日請求.Checked Then
            If fast Then
                strSQL2 &= ","
            End If
            fast = True
            strSQL2 &= "'NR後日請求'"
        End If
        strSQL2 &= ""
        '--------期間
        strSQL31 = ""
        strSQL32 = ""
        If Me.ComboBox期間.Text <> "" Then
            If Me.ComboBox期間.Text = "点検完了日" Then
                strSQL31 = " and t.修理完了日 BETWEEN '" & Me.DateTimePicker期間1.Value.ToShortDateString() & "' and '" & Me.DateTimePicker期間2.Value.ToShortDateString() & "'"
            Else
                strSQL31 = " and t." & Me.ComboBox期間.Text & " BETWEEN '" & Me.DateTimePicker期間1.Value.ToShortDateString() & "' and '" & Me.DateTimePicker期間2.Value.ToShortDateString() & "'"
            End If
        End If
            '-------点検状態区分
            strSQL4 = ""
        fast = False
        If Me.CheckBox受付完了.Checked Then
            fast = True
            strSQL4 &= "'受付完了'"
        End If
        If Me.CheckBox受付保留.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'受付保留'"
        End If
        If Me.CheckBox受付キャンセル.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'受付キャンセル'"
        End If
        If Me.CheckBoxナンセンスコール.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'ナンセンスコール'"
        End If
        If Me.CheckBox訪問前キャンセル.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'訪問前キャンセル'"
        End If
        If Me.CheckBox再訪問.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'再訪問'"
        End If
        If Me.CheckBox修理完了.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'修理完了'"
        End If
        If Me.CheckBoxモバイル修理完了.Checked Then
            If fast Then
                strSQL4 &= ","
            End If
            fast = True
            strSQL4 &= "'モバイル修理完了'"
        End If

        '-------請求先
        strSQL5 = ""
        If Me.TextBox請求先会社名.Text <> "" Then
            If Me.ComboBoxJy1.Text = "一致" Then
                strSQL5 &= " and (t.請求先会社 = '" & StrConv(Me.TextBox請求先会社名.Text, VbStrConv.Narrow) & "' "
                strSQL5 &= " or   t.請求先会社 = '" & StrConv(Me.TextBox請求先会社名.Text, VbStrConv.Wide) & "') "

            Else
                strSQL5 &= " and ( t.請求先会社 like '%" & StrConv(Me.TextBox請求先会社名.Text.Trim, VbStrConv.Narrow) & "%' "
                strSQL5 &= " or    t.請求先会社 like '%" & StrConv(Me.TextBox請求先会社名.Text.Trim, VbStrConv.Wide) & "%') "

                Me.ComboBoxJy1.SelectedIndex = 1
            End If

        End If
        If Me.TextBox請求先名.Text <> "" Then
            If Me.ComboBoxJy2.Text = "一致" Then
                strSQL5 &= " and ( t.請求先名 = '" & StrConv(Me.TextBox請求先名.Text, VbStrConv.Narrow) & "' "
                strSQL5 &= " or  t.請求先名 = '" & StrConv(Me.TextBox請求先名.Text, VbStrConv.Wide) & "') "
            Else
                strSQL5 &= " and (t.請求先名 like '%" & StrConv(Me.TextBox請求先名.Text.Trim, VbStrConv.Narrow) & "%' "
                strSQL5 &= " or   t.請求先名 like '%" & StrConv(Me.TextBox請求先名.Text.Trim, VbStrConv.Wide) & "%') "
                Me.ComboBoxJy2.SelectedIndex = 1
            End If
        End If
        If Me.TextBox請求先電話.Text <> "" Then
            If Me.ComboBoxJy3.Text = "一致" Then
                strSQL5 &= " and t.請求先電話 = '" & StrConv(Me.TextBox請求先電話.Text.Trim, VbStrConv.Narrow) & "' "
            Else
                strSQL5 &= " and t.請求先電話 like '%" & StrConv(Me.TextBox請求先電話.Text.Trim, VbStrConv.Narrow) & "%' "
                Me.ComboBoxJy3.SelectedIndex = 1
            End If
        End If

    End Sub
#End Region

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 1)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If


    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            OutputCsvFromDataGridView(Me.DataGridView1, Me.ToolStripProgressBar1)
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim strSQL As String
        Dim dt As New DataTable
        Dim ro
        ro = e.RowIndex

        If ro >= 0 And e.Button = MouseButtons.Left Then
            Me.DataGridView1.CurrentCell = Me.DataGridView1(8, ro)
            FormInput.TextBox得意先コード.Text = ""
            FormInput.TextBox点検受付番号.Text = Me.DataGridView1.Rows(ro).Cells(8).Value.ToString
            FormInput.TextBoxDM番号.Text = Me.DataGridView1.Rows(ro).Cells(10).Value.ToString
            FormInput.UserID = UserID
            FormInput.UserName = UserName
            FormInput.Kengen = Kengen
            FormInput.ShowDialog()


            strSQL = "SELECT t1.点検受付番号, t1.訂正依頼内容, t1.ステータス,t1.出庫,t1.完了,t1.更新日,t1.メモ "
            strSQL &= " FROM " & schema & "t_teisei t1"
            strSQL &= " where t1.点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(8).Value.ToString.Trim & "'"

            dt = ClassPostgeDB.SetTable(strSQL)
            If dt.Rows.Count = 1 Then

                Me.DataGridView1.Rows(ro).Cells(0).Value = dt.Rows(0).Item(2).ToString
                Me.DataGridView1.Rows(ro).Cells(1).Value = dt.Rows(0).Item(1).ToString

                If dt.Rows(0).Item(3).ToString = "1" Then
                    Me.DataGridView1.Rows(ro).Cells(3).Value = "停止"
                Else
                    Me.DataGridView1.Rows(ro).Cells(3).Value = ""
                End If

                If dt.Rows(0).Item(4).ToString = "1" Then
                    Me.DataGridView1.Rows(ro).Cells(4).Value = "完了"
                Else
                    Me.DataGridView1.Rows(ro).Cells(4).Value = ""
                End If
                Me.DataGridView1.Rows(ro).Cells(5).Value = dt.Rows(0).Item(5).ToString
                Me.DataGridView1.Rows(ro).Cells(2).Value = dt.Rows(0).Item(6).ToString


            Else
                Me.DataGridView1.Rows(ro).Cells(0).Value = ""
                Me.DataGridView1.Rows(ro).Cells(1).Value = ""
                Me.DataGridView1.Rows(ro).Cells(2).Value = ""
                Me.DataGridView1.Rows(ro).Cells(3).Value = ""
                Me.DataGridView1.Rows(ro).Cells(4).Value = ""
                Me.DataGridView1.Rows(ro).Cells(5).Value = ""

            End If


            strSQL = "SELECT t2.チェック, TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日 "
            strSQL &= " FROM " & schema & "t_check t2"
            strSQL &= " where t2.点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(8).Value.ToString.Trim & "'"

            dt = ClassPostgeDB.SetTable(strSQL)
            If dt.Rows.Count = 1 Then

                Me.DataGridView1.Rows(ro).Cells(6).Value = dt.Rows(0).Item(0).ToString
                Me.DataGridView1.Rows(ro).Cells(7).Value = dt.Rows(0).Item(1).ToString

            Else
                Me.DataGridView1.Rows(ro).Cells(6).Value = ""
                Me.DataGridView1.Rows(ro).Cells(7).Value = ""

            End If

        End If

    End Sub

    Private Sub Button集約_Click(sender As Object, e As EventArgs) Handles Button集約.Click

        If Me.Button集約.Text = "集約データのみ" Then

            Me.DataGridView1.Columns(0).Visible = False
            Me.DataGridView1.Columns(1).Visible = False
            Me.DataGridView1.Columns(2).Visible = False
            Me.DataGridView1.Columns(3).Visible = False
            Me.DataGridView1.Columns(4).Visible = False
            Me.DataGridView1.Columns(5).Visible = False
            Me.DataGridView1.Columns(6).Visible = False
            Me.DataGridView1.Columns(7).Visible = False


            Me.Button集約.Text = "集約データ+ステータス"
        Else

            Me.DataGridView1.Columns(0).Visible = True
            Me.DataGridView1.Columns(1).Visible = True
            Me.DataGridView1.Columns(2).Visible = True
            Me.DataGridView1.Columns(3).Visible = True
            Me.DataGridView1.Columns(4).Visible = True
            Me.DataGridView1.Columns(5).Visible = True
            Me.DataGridView1.Columns(6).Visible = True
            Me.DataGridView1.Columns(7).Visible = True



            Me.Button集約.Text = "集約データのみ"

        End If
    End Sub

    Private Function SetSQL() As String
        Dim strSQL As String = String.Empty

        strSQL &= "  t1.ステータス"
        strSQL &= ", t1.訂正依頼内容"
        strSQL &= ", t1.メモ"
        strSQL &= ", CASE WHEN t1.出庫 = '1' THEN '停止'  ELSE '' END 出庫"
        strSQL &= ", CASE WHEN t1.完了 = '1' THEN '完了'  ELSE '' END 完了"
        strSQL &= ", t1.更新日 as 訂正更新日"
        strSQL &= ", t2. チェック"
        strSQL &= ", TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日"
        strSQL &= ", t.点検受付番号"
        strSQL &= ", t.注文no"
        strSQL &= ", t.ｄｍ番号"

        strSQL &= ", t.ステータス名"
        strSQL &= ", t.点検受付日"
        strSQL &= ", t.修理完了日 点検完了日"
        strSQL &= ", t.都道府県名"
        strSQL &= ", t.市区町村名"
        strSQL &= ", t.町域"
        strSQL &= ", t.番地"
        strSQL &= ", t.建物"
        strSQL &= ", t.部屋"
        strSQL &= ", t.回収区分"
        strSQL &= ", t.技術料"
        strSQL &= ", t.出張料"
        strSQL &= ", t.その他料金"
        strSQL &= ",t.サポート料"
        strSQL &= ",t.値引き"

        strSQL &= ",(t.技術料  + t.出張料 + t.その他料金 +"
        strSQL &= " cast(( case when t.サポート料 Is null then '0' when t.サポート料 = '' then '0' else t.サポート料 end ) as  numeric) -"
        strSQL &= " cast(( case when t.値引き Is null then '0'  when t.値引き = '' then '0' else t.値引き end )  as  numeric)) 点検料金"

        strSQL &= ",t.消費税額"
        strSQL &= ",t.請求合計金額"
        strSQL &= ", t.無償部品代"
        strSQL &= ", t.無償出張料"
        strSQL &= ", t.無償出張料差額"
        strSQL &= ", t.無償技術料"
        strSQL &= ", t.無償その他"
        strSQL &= ", t.無償合計"
        strSQL &= ", t.点検状態区分名称"
        strSQL &= ", t.修理状況"
        strSQL &= ", replace(t.請求先会社,'　','■') 請求先会社"
        strSQL &= ", replace(t.請求先部署,'　','■') 請求先部署"
        strSQL &= ", replace(t.請求先名,'　','■') 請求先名"
        strSQL &= ", t.請求先電話"
        strSQL &= ", replace(t.請求先住所,'　','■') 請求先住所"
        strSQL &= ", replace(t.請求先宛名,'　','■') 請求先宛名"
        strSQL &= ", replace(t.請求先担当,'　','■') 請求先担当"
        strSQL &= ", t.担当shopコード"
        strSQL &= ", t.店略称"
        strSQL &= ", t.担当サービスマン"
        strSQL &= ", t.サービスマン名"
        strSQL &= ", t.更新日"

        Return strSQL
    End Function

    Private Function SetSQLAll() As String
        Dim strSQL As String = String.Empty
        strSQL &= ", t.ステータス as 集約ステータス"

        strSQL &= ", t.所有者登録意思区分"
        strSQL &= ", t.所有者登録意思区分名"
        strSQL &= ", t.点検台帳登録区分"
        strSQL &= ", t.点検台帳登録区分名称"
        strSQL &= ", t.所有者票ブランド"
        strSQL &= ", t.製品名_通知"
        strSQL &= ", t.製造番号_通知"
        strSQL &= ", t.製品名_完了"
        strSQL &= ", t.製造番号_完了"
        strSQL &= ", t.点検開始年月"
        strSQL &= ", t.点検終了年月"
        strSQL &= ", t.点検通知種類"
        strSQL &= ", t.点検通知種類名称"
        strSQL &= ", t.点検通知年月"

        strSQL &= ", t.フロント承認日"
        strSQL &= ", t.受付区分"
        strSQL &= ", t.点検状態区分"
        strSQL &= ", t.顧客id"
        strSQL &= ", t.回収区分コード "
        strSQL &= ", t.未着回数"
        strSQL &= ", t.保証規定区分コード"
        strSQL &= ", t.保証規定区分"
        strSQL &= ", t.承認番号"
        strSQL &= ", t.責任部門分類コード"
        strSQL &= ", t.責任部門分類"
        strSQL &= ", t.責任部門コード"
        strSQL &= ", t.責任部門"
        strSQL &= ", t.設計標準使用期間"
        strSQL &= ", t.システム詳細区分"
        strSQL &= ", t.システム詳細区分名"
        strSQL &= ", t.表示解除区分"
        strSQL &= ", t.表示解除方法通知日"
        strSQL &= ", t.所有者票顧客id"
        strSQL &= ", t.回収金額"
        strSQL &= ", t.集計基準日"
        strSQL &= ", t.メーカーコード"
        strSQL &= ", t.メーカー"
        strSQL &= ", t.点検完了受付日"
        strSQL &= ", t.製造年月"
        strSQL &= ", t.所有者有無"
        strSQL &= ", t.所有者登録有無"
        strSQL &= ", t.故障表示1"
        strSQL &= ", t.依頼区分"
        strSQL &= ", t.依頼区分内容"
        strSQL &= ", t.回収予定日"
        strSQL &= ", t.回収完了日"
        strSQL &= ", t.キャンセル"
        strSQL &= ", t.tc店略称"
        strSQL &= ", t.受付店"
        strSQL &= ", t.受付者 "
        strSQL &= ", t.依頼元名"
        strSQL &= ", t.依頼元カナ"
        strSQL &= ", t.依頼元会社"
        strSQL &= ", t.依頼元電話"
        strSQL &= ", t.請求先カナ"
        strSQL &= ", t.価格指示理由"
        strSQL &= ", t.都道府県コード"
        strSQL &= ", t.市区町村名コード"
        strSQL &= ", t.無償その他内容"
        strSQL &= ", t.無償診断料"
        '-----
        strSQL &= ", t.注文no"
        strSQL &= ", t.サポート料"
        strSQL &= ", t.値引き"
        strSQL &= ", t.消費税額"
        strSQL &= ", t.請求合計金額"
        strSQL &= ", t.請求番号"
        strSQL &= ", t.請求日"
        strSQL &= ", t.請求書印刷日"
        strSQL &= ", t.新ステータス"
        strSQL &= ", t.無償承認区分"

        '----
        strSQL &= ", t.マイページ連携仮id"
        strSQL &= ", t.マイページ連携仮pw"
        strSQL &= ", t.マイページ連携用フラグ"
        strSQL &= ", t.マイページid"
        strSQL &= ", t.出庫伝票データ出力フラグ"
        strSQL &= ", t.代表受付番号"

        '-----
        strSQL &= ",依頼元コード"
        strSQL &= ",受付業務区分名称"
        strSQL &= ",訪問先会社名"
        strSQL &= ",訪問先部署"
        strSQL &= ",訪問先氏名担当者"
        strSQL &= ",訪問先氏名担当者カナ"
        strSQL &= ",訪問先電話番号"
        strSQL &= ",製造番号不明理由"
        strSQL &= ",訪問予定日１"
        strSQL &= ",依頼元fax番号"
        strSQL &= ",無償承認日"
        strSQL &= ",業務区分"
        strSQL &= ",cim番号"
        strSQL &= ",契約_安心プラン"
        strSQL &= ",契約番号"
        strSQL &= ",第１業務区分"
        strSQL &= ",第１業務区分内容"
        strSQL &= ",第２業務区分"
        strSQL &= ",第２業務区分内容"
        strSQL &= ",帳票発行者id"
        strSQL &= ",諸経費"
        strSQL &= ",所有者票ブランド名称"
        strSQL &= ",受付区分名称"
        strSQL &= ",新ステータス名称"
        strSQL &= ",製造番号不明理由内容"
        strSQL &= ",newflg"
        strSQL &= ",承認flg"
        strSQL &= ",点検結果伝票番号"
        strSQL &= ",機器分類"
        strSQL &= ",ｄｍ番号id"
        strSQL &= ",tc店略称id"
        strSQL &= ",受付店id"
        strSQL &= ",受付者id"
        strSQL &= ",請求回収区分変更理由"
        strSQL &= ",修理状況名称"
        strSQL &= ",帳票発行日"
        strSQL &= ",請求書再印刷日"
        strSQL &= ",帳票発行者姓"
        strSQL &= ",帳票発行者名"



        Return strSQL
    End Function

    Private Sub 条件初期ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 条件初期ToolStripMenuItem.Click
        Dim dtToday As DateTime = DateTime.Today

        Me.TextBox点検受付番号.Text = ""
        Me.TextBoxDM番号.Text = ""
        Me.TextBox請求先会社名.Text = ""
        Me.TextBox請求先名.Text = ""
        Me.TextBox請求先電話.Text = ""
        Me.ComboBoxJy1.SelectedIndex = -1
        Me.ComboBoxJy2.SelectedIndex = -1
        Me.ComboBoxJy3.SelectedIndex = -1
        Me.CheckBox点検受付.Checked = True
        Me.CheckBox点検完了.Checked = True
        Me.CheckBox請求書発行済.Checked = False
        Me.CheckBox回収完了.Checked = False
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Checked = False
        Me.CheckBox受付ｷｬﾝｾﾙ.Checked = False
        Me.CheckBox訪問ｷｬﾝｾﾙ.Checked = False

        Me.CheckBox受付完了.Checked = True
        Me.CheckBox修理完了.Checked = True
        Me.CheckBoxモバイル修理完了.Checked = True
        Me.CheckBox再訪問.Checked = True
        Me.CheckBox受付保留.Checked = False
        Me.CheckBox受付キャンセル.Checked = False
        Me.CheckBoxナンセンスコール.Checked = False
        Me.CheckBox訪問前キャンセル.Checked = False

        Me.CheckBoxSS現金徴収.Checked = True
        Me.CheckBoxSS後日請求.Checked = True
        Me.CheckBoxNR後日請求.Checked = True

        Me.CheckBox集約データ.Checked = False

        Me.DateTimePicker期間1.Value = dtToday.AddMonths(0 - Integer.Parse(GetSystemto("2", "1")))
        Me.DateTimePicker期間2.Value = dtToday

        Me.ComboBox期間.SelectedIndex = 1

    End Sub

    Private Sub Button請求先会社名CLEAR_Click(sender As Object, e As EventArgs) Handles Button請求先会社名CLEAR.Click
        Me.TextBox請求先会社名.Text = ""
    End Sub

    Private Sub Button請求先名CLEAR_Click(sender As Object, e As EventArgs) Handles Button請求先名CLEAR.Click
        Me.TextBox請求先名.Text = ""

    End Sub

    Private Sub Button請求先電話CLEAR_Click(sender As Object, e As EventArgs) Handles Button請求先電話CLEAR.Click
        Me.TextBox請求先電話.Text = ""

    End Sub

    Private Sub Button点検受付番号CLEAR_Click(sender As Object, e As EventArgs) Handles Button点検受付番号CLEAR.Click
        Me.TextBox点検受付番号.Text = ""
    End Sub

    Private Sub ButtonDM番号CLEAR_Click(sender As Object, e As EventArgs) Handles ButtonDM番号CLEAR.Click
        Me.TextBoxDM番号.Text = ""
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class