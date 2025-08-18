Public Class FormCheck
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim strSQL1 As String 'ステータス名
    Dim strSQL2 As String '回収区分
    Dim strSQL31 As String '期間 t
    Dim strSQL32 As String '期間 t1
    Dim strSQL4 As String '点検状態区分名称
    Dim strSQL5 As String '請求先
    Dim dt As New DataTable

    Dim fast As Boolean

    Dim KomaneDay As String

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

    Public Function Getarray料金チェック(koumoku As String) As Integer

        'Return Array.IndexOf(array料金チェック, koumoku)
        Return GetHeaderColNo(koumoku, Me.DataGridView1)
    End Function

    Public Function Getarray安心プラン(koumoku As String) As Integer

        'Return Array.IndexOf(array安心プラン, koumoku)
        Return GetHeaderColNo(koumoku, Me.DataGridView1)

    End Function

    Public Function Getarray出張料重複(koumoku As String) As Integer

        'Return Array.IndexOf(array出張料重複, koumoku)
        Return GetHeaderColNo(koumoku, Me.DataGridView1)

    End Function

    Public Function Getarray未回収(koumoku As String) As Integer
        'Return Array.IndexOf(array未回収, koumoku)
        Return GetHeaderColNo(koumoku, Me.DataGridView1)
    End Function

    Public Function Getarray2024(koumoku As String) As Integer
        'Return Array.IndexOf(arrary2024, koumoku)
        Return GetHeaderColNo(koumoku, Me.DataGridView1)
    End Function

    Public Function Getarray2025(koumoku As String) As Integer
        'Return Array.IndexOf(arrary2025, koumoku)
        Return GetHeaderColNo(koumoku, Me.DataGridView1)
    End Function


    Private Sub FormCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " Version[" & Ver & "] "
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報
        Me.ToolStripStatusLabel件数.Text = ""

        Dim dtToday As DateTime = DateTime.Today
        Me.DateTimePicker期間1.Value = dtToday.AddMonths(0 - Integer.Parse(GetSystemto("2", "2")))
        Me.DateTimePicker期間2.Value = dtToday
        GetSystemtoCombo("'10'", Me.ComboBox期間, "")
        Me.ComboBox期間.SelectedIndex = 1

        Me.CheckBox建物.Visible = False
        Me.CheckBox物件重複を外す.Visible = False

        Me.DataGridView1.RowHeadersWidth = 10
        Me.GroupBox請求先.Visible = False
        Me.Label条件.Text = ""

        Me.ComboBox項目.Items.Clear()
        Me.ComboBox項目.Items.Add("出張料重複チェック")
        Me.ComboBox項目.Items.Add("料金チェック")
        Me.ComboBox項目.Items.Add("安心プランチェック")
        Me.ComboBox項目.Items.Add("未回収チェック")
        Me.ComboBox項目.Items.Add("キャンペーン2024")
        Me.ComboBox項目.Items.Add("キャンペーン2025")
        Me.Button正常を削除.Text = ""
        Me.Button正常を削除.Visible = False
        Me.CheckBox回収対象外.Visible = False
        Me.EXCEL未回収ToolStripMenuItem.Visible = False

        If ChkNewOld() Then
            Me.CheckBoxCIM.Checked = True
        Else
            Me.CheckBoxCIM.Checked = False
        End If

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub defCheck()

        Me.CheckBox点検受付.Checked = True
        Me.CheckBox点検完了.Checked = True
        Me.CheckBox請求書発行済.Checked = False
        Me.CheckBox回収完了.Checked = False

        Me.CheckBoxSS現金徴収.Checked = True
        Me.CheckBoxSS後日請求.Checked = True
        Me.CheckBoxNR後日請求.Checked = True

        Me.CheckBox受付完了.Checked = False
        Me.CheckBox受付保留.Checked = False
        Me.CheckBox受付キャンセル.Checked = False
        Me.CheckBoxナンセンスコール.Checked = False
        Me.CheckBox修理完了.Checked = True
        Me.CheckBoxモバイル修理完了.Checked = True
        Me.CheckBox再訪問.Checked = False
        Me.CheckBox訪問前キャンセル.Checked = False
        Me.CheckBox回収対象外.Visible = False
        Me.CheckBox物件重複を外す.Visible = False
        Me.EXCEL未回収ToolStripMenuItem.Visible = False

    End Sub
    Private Sub ComboBox項目_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox項目.SelectedIndexChanged

        defCheck()

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.GroupBox請求先.Visible = False
        Select Case Me.ComboBox項目.Text
            Case "料金チェック"
                Me.GroupBox請求先.Visible = True
                Me.Label条件.Text = "【含む】"
                Me.CheckBox建物.Visible = True
                Me.Button正常を削除.Visible = True
                Me.Button正常を削除.Text = "正常を非表示"
                Me.CheckBox回収対象外.Visible = False
                Me.CheckBox物件重複を外す.Visible = True
                Me.CheckBox建物.Checked = True
                Me.CheckBox物件重複を外す.Checked = True
                Me.EXCEL未回収ToolStripMenuItem.Visible = False
                Me.CheckBoxZero.Visible = False

            Case "安心プランチェック"
                Me.Label条件.Text = "【含む】"
                Me.CheckBox建物.Visible = False
                Me.Button正常を削除.Visible = True
                Me.Button正常を削除.Text = "正常を非表示"
                Me.CheckBox回収対象外.Visible = False
                Me.CheckBox物件重複を外す.Visible = False
                Me.EXCEL未回収ToolStripMenuItem.Visible = False
                Me.CheckBoxZero.Visible = False

            Case "出張料重複チェック"
                Me.Label条件.Text = "【含む】"
                Me.CheckBox建物.Visible = True
                Me.Button正常を削除.Visible = False
                Me.CheckBox回収対象外.Visible = False
                Me.CheckBox物件重複を外す.Visible = False
                Me.EXCEL未回収ToolStripMenuItem.Visible = False
                Me.CheckBoxZero.Visible = False

            Case "未回収チェック"
                Me.Button正常を削除.Visible = False
                Me.CheckBox建物.Visible = False
                Me.CheckBox回収対象外.Visible = True

                Me.CheckBox点検受付.Checked = False
                Me.CheckBox点検完了.Checked = True
                Me.CheckBox請求書発行済.Checked = True
                Me.CheckBox回収完了.Checked = True

                Me.CheckBoxSS現金徴収.Checked = False
                Me.CheckBoxSS後日請求.Checked = True
                Me.CheckBoxNR後日請求.Checked = False

                Me.CheckBox受付完了.Checked = True
                Me.CheckBox受付保留.Checked = False
                Me.CheckBox受付キャンセル.Checked = True
                Me.CheckBoxナンセンスコール.Checked = True
                Me.CheckBox修理完了.Checked = False
                Me.CheckBoxモバイル修理完了.Checked = False
                Me.CheckBox再訪問.Checked = False
                Me.CheckBox訪問前キャンセル.Checked = True
                Me.Label条件.Text = "【含まない】"

                Me.Button正常を削除.Visible = False
                Me.CheckBox物件重複を外す.Visible = False
                Me.EXCEL未回収ToolStripMenuItem.Visible = True
                Me.CheckBoxZero.Visible = False


            Case "キャンペーン2024"
                Me.Button正常を削除.Visible = True
                Me.Button正常を削除.Text = "正常を非表示"

                Me.CheckBox建物.Visible = False
                Me.CheckBox点検受付.Checked = True
                Me.CheckBox点検完了.Checked = True
                Me.DateTimePicker期間1.Value = "2024/04/01"
                Me.CheckBoxZero.Visible = True
            Case "キャンペーン2025"
                Me.CheckBoxZero.Visible = True
                Me.Button正常を削除.Visible = True
                Me.Button正常を削除.Text = "正常を非表示"


        End Select
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim strSQL As String
        Dim dtst As New DataTable

        Dim ro
        ro = e.RowIndex
        If ro >= 0 And e.Button = MouseButtons.Left Then


            FormInput.TextBox点検受付番号.Text = Me.DataGridView1.Rows(ro).Cells(GetHeaderColNo("点検受付番号", Me.DataGridView1)).Value.ToString
            FormInput.TextBoxDM番号.Text = Me.DataGridView1.Rows(ro).Cells(GetHeaderColNo("ｄｍ番号", Me.DataGridView1)).Value.ToString


            FormInput.sls_typ = ""
            FormInput.cst_cd = ""
            FormInput.entry_date = ""

            FormInput.TextBox得意先コード.Text = ""
            FormInput.UserID = UserID
            FormInput.UserName = UserName
            FormInput.Kengen = Kengen
            FormInput.ShowDialog()
            Me.DataGridView1.CurrentCell = Me.DataGridView1(Getarray出張料重複("点検受付番号"), ro)

            strSQL = "SELECT t.点検受付番号, t.ステータス, t.訂正依頼内容,t.出庫,t.完了,t.更新日,メモ FROM " & schema & "t_teisei t"
            strSQL &= " where t.点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検受付番号")).Value.ToString.Trim & "'"

            dtst = ClassPostgeDB.SetTable(strSQL)
            If dtst.Rows.Count = 1 Then

                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ステータス")).Value = dtst.Rows(0).Item(1).ToString
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正依頼内容")).Value = dtst.Rows(0).Item(2).ToString

                If dtst.Rows(0).Item(3).ToString = "1" Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出庫")).Value = "停止"
                Else
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出庫")).Value = ""
                End If

                If dtst.Rows(0).Item(4).ToString = "1" Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("完了")).Value = "完了"
                Else
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("完了")).Value = ""
                End If

                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正更新日")).Value = dtst.Rows(0).Item(5).ToString
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("メモ")).Value = dtst.Rows(0).Item(6).ToString

            Else
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ステータス")).Value = ""
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正依頼内容")).Value = ""
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("メモ")).Value = ""
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出庫")).Value = ""
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("完了")).Value = ""
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正更新日")).Value = ""

            End If

            dtst = Nothing
            strSQL = "SELECT t2.チェック,TO_CHAR(t2.確認完了日,'yyyy/mm/dd') FROM " & schema & "t_check t2"
            strSQL &= " where t2.点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(7).Value.ToString.Trim & "'"

            dtst = ClassPostgeDB.SetTable(strSQL)
            If dtst.Rows.Count = 1 Then

                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("チェック")).Value = dtst.Rows(0).Item(0).ToString
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("確認完了日")).Value = dtst.Rows(0).Item(1).ToString

            Else
                'Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("チェック")).Value = ""
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("確認完了日")).Value = ""
            End If

        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro
        Dim cl
        ro = e.RowIndex
        cl = e.ColumnIndex

        If cl = 0 Then
            Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = Not Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value

        End If


    End Sub

    Private Sub 実行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 実行ToolStripMenuItem.Click
        KenSaku()

    End Sub

    Private Sub KenSaku()

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.ToolStripProgressBar1.Value = 0

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        System.Windows.Forms.Application.DoEvents()

        Me.Button正常を削除.Text = "正常を非表示"

        Select Case Me.ComboBox項目.Text
            Case "出張料重複チェック"
                出張料重複チェック()

            Case "料金チェック"
                料金チェック()

            Case "安心プランチェック"
                安心プランチェック()

            Case "未回収チェック"
                未回収チェック()

            Case "キャンペーン2024"
                キャンペーン2024()

            Case "キャンペーン2025"
                キャンペーン2025()

        End Select
        Me.Cursor = System.Windows.Forms.Cursors.Default


    End Sub




    Private Sub チェックToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles チェックToolStripMenuItem.Click
        再チェック()
    End Sub
    Private Sub 再チェック()
        Me.ToolStripProgressBar1.Value = 0
        Select Case Me.ComboBox項目.Text
            Case "出張料重複チェック"
                出張料重複チェック1()
            Case "料金チェック"
                料金チェック1()
            Case "安心プランチェック"
                安心プランチェック1()
            Case "キャンペーン2024"
                Check2024()
            Case "キャンペーン2025"
                Check2025()
        End Select

    End Sub
#Region "キャンペーン2024"
    Private Sub キャンペーン2024()
        Dim strSQL As String
        Dim ro As Integer = 0
        dt = Nothing
        Me.DataGridView1.DataSource = Nothing

        検索条件()

        strSQL = ""
        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t1.訂正依頼内容 "
        strSQL &= ",t1.メモ "
        strSQL &= ",case when t1.出庫 = '1' then '停止'  else '' end 出庫 "
        strSQL &= ",case when t1.完了 = '1' then '完了'  else '' end 完了 "
        strSQL &= ",t1.更新日 as 訂正更新日"

        'strSQL &= ",t2.チェック , TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日"
        strSQL &= ", case when t2.チェック ='1'  then 'OK' else '' end チェック"
        strSQL &= " , to_char(t2.確認完了日,'yyyy/mm/dd') 確認完了日"


        strSQL &= ",t.点検受付番号 "
        strSQL &= ",t.ｄｍ番号 "

        strSQL &= ",t.ステータス名 "
        strSQL &= ",t.回収区分"
        strSQL &= ",t.点検受付日"
        strSQL &= ",t.修理完了日 点検完了日 "
        strSQL &= ",t.フロント承認日 "
        strSQL &= ", left(t.回収完了日,10) 回収完了日 "

        strSQL &= ",t.技術料 "
        strSQL &= ",t.出張料 "
        strSQL &= ",t.その他料金 "
        strSQL &= ",t.点検料金 "
        strSQL &= ",t.無償部品代 "
        strSQL &= ",t.無償出張料 "
        strSQL &= ",t.無償技術料 "
        strSQL &= ",t.無償その他 "
        strSQL &= ",t.無償出張料差額 "
        strSQL &= ",t.無償合計 "
        strSQL &= ",t.点検状態区分名称 "
        strSQL &= ",t.保証規定区分 "
        strSQL &= ",t.承認番号 "
        strSQL &= ",t.請求先電話 "
        strSQL &= ",t.更新日 "

        strSQL &= ",t.受付区分 "
        strSQL &= ",t.依頼区分内容 "
        strSQL &= ",t.値引き "

        strSQL &= ",t.マイページ連携仮id "
        strSQL &= ",t.マイページ連携用フラグ "
        strSQL &= ",t.マイページid "


        If Me.ComboBox期間.Text <> "" Then
            If (Me.ComboBox期間.Text = "フロント承認日" Or Me.ComboBox期間.Text = "回収予定日" Or Me.ComboBox期間.Text = "点検受付日") Then
                strSQL &= ",t." & Me.ComboBox期間.Text
            End If
        End If
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " left outer join " & schema & "t_teisei  t1 on t.点検受付番号 =t1.点検受付番号 "
        strSQL &= " left outer join " & schema & "t_check t2  on t.点検受付番号 =t2.点検受付番号 "

        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and   t.回収区分 in (" & strSQL2 & ")"
        strSQL &= " and   t.点検状態区分名称 in (" & strSQL4 & ")"
        strSQL &= strSQL31

        'If Me.ComboBox期間.Text <> "点検受付日" Then

        strSQL &= "and  ((t.点検受付日 between  '2024/04/01' and '2024/10/01'"
        strSQL &= "and    t.修理完了日 between  '2024/04/01' and '2025/05/01')"
        'strSQL &= "or (t.点検受付日 >'2024/09/30' and  cast(t.値引き as numeric(10,0)) > 0 ) )"
        strSQL &= ")"

        'strSQL &= "　AND ( t.点検受付日 BETWEEN  '2024/04/01' AND '2024/12/31'"
        'strSQL &= "　AND   t.修理完了日 BETWEEN  '2024/04/01' AND '2025/04/30' )"
        'End If

        strSQL &= " and  t.依頼区分内容 not in ('ＴＳ契約/ＳＰ付点検２回目','ＴＳ契約/ＳＰ付点検３回目','ＰＴ契約/ＳＰ付点検２回目','ＰＴ契約/ＳＰ付点検３回目') "

        If Me.CheckBoxZero.Checked Then

        Else
            strSQL &= " and t.値引き <> '0'"

        End If

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
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

        ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "訂正依頼内容", 120, False) '1
        ro = settextColumn(Me.DataGridView1, ro, "メモ", "メモ", 110, False)
        ro = settextColumn(Me.DataGridView1, ro, "出庫", "出庫", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "完了", "完了", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正更新日", "訂正更新日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 60, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 140, False)                 '----9
        ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 100, False)             '10
        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 120, False)

        ro = settextColumn(Me.DataGridView1, ro, "受付区分", "受付区分", 120, False)                 '-----12
        ro = settextColumn(Me.DataGridView1, ro, "依頼区分内容", "依頼区分内容", 140, False)     '----13

        ro = settextColumn(Me.DataGridView1, ro, "点検受付日", "点検受付日", 130, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検完了日", "点検完了日", 130, False)
        ro = settextColumn(Me.DataGridView1, ro, "フロント承認日", "フロント承認日", 130, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収完了日", "回収完了日", 130, False)

        ro = settextColumn(Me.DataGridView1, ro, "技術料", "技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "その他料金", "その他料金", 80, False)   '20
        ro = settextColumn(Me.DataGridView1, ro, "値引き", "値引き", 80, False)                   '----- 21

        ro = settextColumn(Me.DataGridView1, ro, "点検料金", "点検料金", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "無償部品代", "無償部品代", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料", "無償出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償技術料", "無償技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他", "無償その他", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料差額", "無償出張料差額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償合計", "無償合計", 80, False)                 '28

        ro = settextColumn(Me.DataGridView1, ro, "点検状態区分名称", "点検状態区分名称", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "承認番号", "承認番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 130, False)

        ro = settextColumn(Me.DataGridView1, ro, "マイページ連携仮id", "マイページ連携仮id", 80, False)             '34
        ro = settextColumn(Me.DataGridView1, ro, "マイページ連携用フラグ", "マイページ連携用フラグ", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "マイページid", "マイページid", 80, False)

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

        If dt.Rows.Count > 0 Then
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
            Next
            Check2024()
        End If


    End Sub
    Private Sub Check2024()
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(ro).Cells(Getarray2024("ｄｍ番号")).Value.ToString.Contains("AH") Then


            Else
                If Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付日")).Value.ToString >= "2024/10/01" Then
                    If Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Value.ToString = "0" Then
                        'ok
                    Else
                        Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付番号")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Style.BackColor = Color.Red
                    End If
                Else
                    If Me.DataGridView1.Rows(ro).Cells(Getarray2024("受付区分")).Value.ToString.Contains("E-mail受付") Then
                        If Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Value.ToString = "2500" Then
                            'ok
                        Else
                            Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付番号")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Style.BackColor = Color.Red
                        End If
                    Else
                        If Me.DataGridView1.Rows(ro).Cells(Getarray2024("マイページ連携仮id")).Value.ToString <> "" Then
                            If Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Value.ToString = "500" Then
                                Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Style.BackColor = Color.Red
                                If Me.DataGridView1.Rows(ro).Cells(Getarray2024("無償その他")).ToString <> "500" Then
                                    Me.DataGridView1.Rows(ro).Cells(Getarray2024("無償その他")).Style.BackColor = Color.Red
                                End If
                            Else
                                'ok
                            End If
                        Else
                            'ok
                        End If

                        If Me.DataGridView1.Rows(ro).Cells(Getarray2024("依頼区分内容")).Value.ToString.Contains("ＴＳ契約") Then
                            If Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Value.ToString = "2500" Then
                                'ok
                            Else
                                Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Style.BackColor = Color.Red
                            End If
                        End If

                        If Me.DataGridView1.Rows(ro).Cells(Getarray2024("依頼区分内容")).Value.ToString.Contains("ＰＴ契約") Then
                            If Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Value.ToString = "2500" Then
                                'ok
                            Else

                                Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Style.BackColor = Color.Red
                            End If

                        End If
                        If Not Me.DataGridView1.Rows(ro).Cells(Getarray2024("依頼区分内容")).Value.ToString.Contains("ＴＳ契約") Then
                            If Not Me.DataGridView1.Rows(ro).Cells(Getarray2024("依頼区分内容")).Value.ToString.Contains("ＰＴ契約") Then

                                If Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Value.ToString = "2500" Then
                                    Me.DataGridView1.Rows(ro).Cells(Getarray2024("点検受付番号")).Style.BackColor = Color.Red
                                    Me.DataGridView1.Rows(ro).Cells(Getarray2024("値引き")).Style.BackColor = Color.Red
                                End If

                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub


#End Region


#Region "キャンペーン2025"

    Dim dt2025Nebiki As New DataTable
    Dim dt2025Uketuke As New DataTable
    Dim dt2025Kanryou As New DataTable
    Dim dt2025Kin As New DataTable

    Private Sub キャンペーン2025()
        Dim strSQL As String
        Dim ro As Integer = 0
        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        GetMaster2025()

        検索条件()

        strSQL = ""
        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t1.訂正依頼内容 "
        strSQL &= ",t1.メモ "
        strSQL &= ",CASE WHEN t1.出庫 = '1' THEN '停止'  ELSE '' END 出庫 "
        strSQL &= ",CASE WHEN t1.完了 = '1' THEN '完了'  ELSE '' END 完了 "
        strSQL &= ",t1.更新日 as 訂正更新日"

        'strSQL &= ",t2.チェック , TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日"
        strSQL &= ", CASE WHEN t2.チェック ='1'  THEN 'OK' ELSE '' END チェック"
        strSQL &= " , TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日"

        strSQL &= ",t.点検受付番号 "
        strSQL &= ",t.ｄｍ番号 "

        strSQL &= ",t.ステータス名 "
        strSQL &= ",t.回収区分"
        strSQL &= ",t.点検受付日"
        strSQL &= ",t.修理完了日 点検完了日 "
        strSQL &= ",t.フロント承認日 "
        strSQL &= ", left(t.回収完了日,10) 回収完了日 "

        strSQL &= ",t.技術料 "
        strSQL &= ",t.出張料 "
        strSQL &= ",t.その他料金 "
        strSQL &= ",t.点検料金 "
        strSQL &= ",t.無償部品代 "
        strSQL &= ",t.無償出張料 "
        strSQL &= ",t.無償技術料 "
        strSQL &= ",t.無償その他 "
        strSQL &= ",t.無償出張料差額 "
        strSQL &= ",t.無償合計 "
        strSQL &= ",t.点検状態区分名称 "
        strSQL &= ",t.保証規定区分 "
        strSQL &= ",t.承認番号 "
        strSQL &= ",t.請求先電話 "
        strSQL &= ",t.更新日 "

        strSQL &= ",t.受付区分 "
        strSQL &= ",t.依頼区分内容 "
        strSQL &= ",t.値引き "

        strSQL &= ",t.マイページ連携仮id "
        'strSQL &= ",t.マイページ連携用フラグ "
        'strSQL &= ",t.マイページid "


        If Me.ComboBox期間.Text <> "" Then
            If (Me.ComboBox期間.Text = "フロント承認日" Or Me.ComboBox期間.Text = "回収予定日" Or Me.ComboBox期間.Text = "点検受付日") Then
                strSQL &= ",t." & Me.ComboBox期間.Text
            End If
        End If
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " left outer join " & schema & "t_teisei  t1 on t.点検受付番号 =t1.点検受付番号 "
        strSQL &= " left outer join " & schema & "t_check t2  on t.点検受付番号 =t2.点検受付番号 "

        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and   t.回収区分 in (" & strSQL2 & ")"
        strSQL &= " and   t.点検状態区分名称 in (" & strSQL4 & ")"
        strSQL &= strSQL31

        '///
        strSQL &= "and  ("
        ro = 0
        For Each uke In dt2025Uketuke.Rows
            If ro > 0 Then strSQL &= " or "
            strSQL &= "( t.点検受付日 between '" & uke("naiyou").ToString & "' and '" & uke("naiyou2").ToString & "' ) "
            ro = ro + 1
        Next
        strSQL &= ")"

        strSQL &= "and  ("
        ro = 0
        For Each uke In dt2025Kanryou.Rows
            If ro > 0 Then strSQL &= " or "
            strSQL &= "( t.修理完了日 between '" & uke("naiyou").ToString & "' and '" & uke("naiyou2").ToString & "' ) "
            ro = ro + 1
        Next
        strSQL &= ")"
        'strSQL &= "or (t.点検受付日 >'2024/09/30' and  cast(t.値引き as numeric(10,0)) > 0 ) )"
        strSQL &= " and  t.依頼区分内容 not in ('ＴＳ契約/ＳＰ付点検２回目','ＴＳ契約/ＳＰ付点検３回目','ＰＴ契約/ＳＰ付点検２回目','ＰＴ契約/ＳＰ付点検３回目') "

        If Me.CheckBoxZero.Checked Then

        Else
            strSQL &= " and ( t.値引き <> '0' or (t.マイページ連携仮id like '%２０２５年ＣＰ%'))"
        End If


        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.RowHeadersVisible = False
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

        ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "訂正依頼内容", 120, False) '1
        ro = settextColumn(Me.DataGridView1, ro, "メモ", "メモ", 110, False)
        ro = settextColumn(Me.DataGridView1, ro, "出庫", "出庫", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "完了", "完了", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正更新日", "訂正更新日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 60, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 140, False)                 '----9
        ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 100, False)         '10
        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 120, False)

        ro = settextColumn(Me.DataGridView1, ro, "受付区分", "受付区分", 120, False)                '-----12
        ro = settextColumn(Me.DataGridView1, ro, "依頼区分内容", "依頼区分内容", 140, False)        '----13

        ro = settextColumn(Me.DataGridView1, ro, "点検受付日", "点検受付日", 130, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検完了日", "点検完了日", 130, False)
        ro = settextColumn(Me.DataGridView1, ro, "フロント承認日", "フロント承認日", 130, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収完了日", "回収完了日", 130, False)

        ro = settextColumn(Me.DataGridView1, ro, "技術料", "技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "その他料金", "その他料金", 80, False)   '20
        ro = settextColumn(Me.DataGridView1, ro, "値引き", "値引き", 80, False)                   '----- 21

        ro = settextColumn(Me.DataGridView1, ro, "点検料金", "点検料金", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "無償部品代", "無償部品代", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料", "無償出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償技術料", "無償技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他", "無償その他", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料差額", "無償出張料差額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償合計", "無償合計", 80, False)                 '28

        ro = settextColumn(Me.DataGridView1, ro, "マイページ連携仮id", "備考", 400, False)             '34


        ro = settextColumn(Me.DataGridView1, ro, "点検状態区分名称", "点検状態区分名称", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "承認番号", "承認番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 130, False)

        'ro = settextColumn(Me.DataGridView1, ro, "マイページ連携用フラグ", "マイページ連携用フラグ", 80, False)
        'ro = settextColumn(Me.DataGridView1, ro, "マイページid", "マイページid", 80, False)

        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Font = New Font(“MS UI Gothic”, 14)

        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

        If dt.Rows.Count > 0 Then
            'For ro = 0 To Me.DataGridView1.Rows.Count - 1
            '    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
            'Next
            Check2025()
        End If


    End Sub
    Private Sub Check2025()
        Dim ro As Integer
        Dim flg As Boolean

        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(ro).Cells(Getarray2025("ｄｍ番号")).Value.ToString.Contains("AH") Then


            Else


                flg = chk2025(ro)

                If flg = True Then

                Else
                    Me.DataGridView1.Rows(ro).Cells(Getarray2025("点検受付番号")).Style.BackColor = Color.Red
                    Me.DataGridView1.Rows(ro).Cells(Getarray2025("値引き")).Style.BackColor = Color.Red
                    Me.DataGridView1.Rows(ro).Cells(Getarray2025("備考")).Style.BackColor = Color.Red
                End If
            End If
        Next
    End Sub

    Private Function chk2025(ro As Integer) As Boolean

        Dim buf As String
        Dim flg As Boolean

        buf = Me.DataGridView1.Rows(ro).Cells(Getarray2025("備考")).Value.ToString
        If Me.DataGridView1.Rows(ro).Cells(Getarray2025("値引き")).Value.ToString = "0" Then
            If buf.IndexOf("２０２５年ＣＰ") = -1 Then
                Return True
            End If
        End If


        chk2025 = False

        For Each nebiki In dt2025Nebiki.Rows
            flg = False

            If nebiki("bikou").ToString <> "" Then
                If 0 <= buf.IndexOf(nebiki("bikou").ToString) Then
                    flg = True
                End If
            End If
            If nebiki("bikou2").ToString <> "" Then
                If 0 <= buf.IndexOf(nebiki("bikou2").ToString) Then
                    flg = True
                End If
            End If


            If flg = True Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray2025("値引き")).Value.ToString = nebiki("kin").ToString Then
                    chk2025 = True
                End If
            End If

        Next

    End Function

    Private Sub GetMaster2025()
        Dim strSQL As String = "select m.naiyou bikou ,t.naiyou  kin ,m.naiyou2 bikou2  from " & schema & "m_system m inner join " & schema & "m_system t on t.kbn='330' and m.seq =t.seq where m.kbn = '300' order by m.seq"

        dt2025Nebiki = ClassPostgeDB.SetTable(strSQL)
        strSQL = "select kbn,seq,naiyou ,naiyou2  from " & schema & "m_system  where kbn = '310' order by kbn  ,seq"
        dt2025Uketuke = ClassPostgeDB.SetTable(strSQL)
        strSQL = "select kbn,seq,naiyou ,naiyou2  from " & schema & "m_system  where kbn = '320' order by kbn  ,seq"
        dt2025Kanryou = ClassPostgeDB.SetTable(strSQL)
    End Sub

#End Region


#Region "安心プランチェック"

    Private Sub 安心プランチェック()

        Dim strSQL As String
        Dim ro As Integer = 0

        'Dim dt As New DataTable
        dt = Nothing
        Me.DataGridView1.DataSource = Nothing

        '--------
        検索条件()
        '-------
        strSQL = ""
        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t1.訂正依頼内容 "
        strSQL &= ",t1.メモ "
        strSQL &= ",CASE WHEN t1.出庫 = '1' THEN '停止'  ELSE '' END 出庫 "
        strSQL &= ",CASE WHEN t1.完了 = '1' THEN '完了'  ELSE '' END 完了 "
        strSQL &= ",t1.更新日 as 訂正更新日"

        'strSQL &= ",t2.チェック , TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日"
        strSQL &= ", case when  t2.チェック ='1'  then 'OK' else '' end チェック"
        strSQL &= " , to_char(t2.確認完了日,'yyyy/mm/dd') 確認完了日"

        strSQL &= ",t.点検受付番号 "
        strSQL &= ",t.ｄｍ番号 "

        strSQL &= ",t.ステータス名 "
        strSQL &= ",t.回収区分"
        strSQL &= ",t.点検受付日"
        strSQL &= ",t.修理完了日 点検完了日 "
        strSQL &= ",t.フロント承認日 "
        strSQL &= ", left(t.回収完了日,10) 回収完了日 "

        strSQL &= ",t.技術料 "
        strSQL &= ",t.出張料 "
        strSQL &= ",t.その他料金 "
        strSQL &= ",t.点検料金 "
        strSQL &= ",t.無償部品代 "
        strSQL &= ",t.無償出張料 "
        strSQL &= ",t.無償技術料 "
        strSQL &= ",t.無償その他 "
        strSQL &= ",t.無償出張料差額 "
        strSQL &= ",t.無償合計 "
        strSQL &= ",t.点検状態区分名称 "
        strSQL &= ",t.保証規定区分 "
        strSQL &= ",t.承認番号 "
        strSQL &= ",t.請求先電話 "
        strSQL &= ",t.更新日 "
        If Me.ComboBox期間.Text <> "" Then
            If (Me.ComboBox期間.Text = "フロント承認日" Or Me.ComboBox期間.Text = "回収予定日" Or Me.ComboBox期間.Text = "点検受付日") Then
                strSQL &= ",t." & Me.ComboBox期間.Text
            End If
        End If
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " left outer join " & schema & "t_teisei t1"
        strSQL &= " on t.点検受付番号 =t1.点検受付番号 "
        strSQL &= " left outer join " & schema & "t_check t2"
        strSQL &= " on t.点検受付番号 =t2.点検受付番号 "

        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and   t.回収区分 in (" & strSQL2 & ")"
        strSQL &= " and   t.点検状態区分名称 in (" & strSQL4 & ")"
        strSQL &= strSQL31
        strSQL &= " and ( t.保証規定区分 = '安心プラン'"
        strSQL &= " or    t.ｄｍ番号 LIKE 'AH%'"
        strSQL &= " or    t.請求先電話='0789224902'"
        strSQL &= " )"


        If CheckBoxCIM.Checked Then

        Else
            strSQL &= " and t.newflg  > 0"
        End If

        dt = ClassPostgeDB.SetTable(strSQL)

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

        ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "訂正依頼内容", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "メモ", "メモ", 110, False)
        ro = settextColumn(Me.DataGridView1, ro, "出庫", "出庫", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "完了", "完了", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正更新日", "訂正更新日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 60, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検受付日", "点検受付日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検完了日", "点検完了日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "フロント承認日", "フロント承認日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収完了日", "回収完了日", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "技術料", "技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "その他料金", "その他料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検料金", "点検料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償部品代", "無償部品代", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "無償出張料", "無償出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償技術料", "無償技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他", "無償その他", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料差額", "無償出張料差額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償合計", "無償合計", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検状態区分名称", "点検状態区分名称", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "承認番号", "承認番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 80, False)

        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

        If dt.Rows.Count > 0 Then
            'For ro = 0 To Me.DataGridView1.Rows.Count - 1
            'Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("Column1")).Value = False
            'Next
            安心プランチェック1()
        End If

    End Sub
    Private Sub 安心プランチェック1()


        For ro = 0 To Me.DataGridView1.Rows.Count - 2


            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("訂正更新日")).Value.ToString() <> "" Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("訂正更新日")).Value.ToString() <Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("更新日")).Value.ToString() Then
                    'Me.DataGridView1.Rows(ro).Cells(0).Style.BackColor = Color.Yellow
                                                                                                    Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("訂正更新日")).Style.BackColor = Color.Yellow
                End If
            End If

            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("無償部品代")).Value.ToString() = "0" Then
                'Me.DataGridView1.Rows(ro).Cells(0).Style.BackColor = Color.Cyan
                'Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Cyan
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("無償部品代")).Style.BackColor = Color.Cyan
            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("無償出張料")).Value.ToString() = "0" Then
                'Me.DataGridView1.Rows(ro).Cells(0).Style.BackColor = Color.Cyan
                'Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Cyan
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("無償出張料")).Style.BackColor = Color.Cyan
            End If

            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("技術料")).Value.ToString() <> "0" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("技術料")).Style.BackColor = Color.Red

            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("出張料")).Value.ToString() <> "0" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("出張料")).Style.BackColor = Color.Red

            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("その他料金")).Value.ToString() <> "0" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("その他料金")).Style.BackColor = Color.Red

            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検料金")).Value.ToString() <> "0" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検料金")).Style.BackColor = Color.Red
            End If

            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("回収区分")).Value.ToString() <> "NR後日請求" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("回収区分")).Style.BackColor = Color.Red
            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("保証規定区分")).Value.ToString() <> "安心プラン" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("保証規定区分")).Style.BackColor = Color.Red
            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("請求先電話")).Value.ToString() <> "0789224902" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("請求先電話")).Style.BackColor = Color.Red
            End If

            If Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("保証規定区分")).Value.ToString() = "" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray安心プラン("保証規定区分")).Style.BackColor = Color.Red
            End If

        Next

    End Sub
#End Region

#Region "料金チェック"
    Private Sub 料金チェック()
        Dim strSQL As String
        Dim ro As Integer = 0
        dt = Nothing
        Me.DataGridView1.DataSource = Nothing

        '--------
        検索条件()
        '-------
        strSQL = ""

        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t1.訂正依頼内容 "
        strSQL &= ",t1.メモ "
        strSQL &= ",case when t1.出庫 = '1' then '停止'  else '' end 出庫 "
        strSQL &= ",case when t1.完了 = '1' then '完了'  else '' end 完了 "
        strSQL &= ",t1.更新日 as 訂正更新日"

        'strSQL &= ",t1.技術チェック as チェック, TO_CHAR(t1.技術確認完了日,'yyyy/mm/dd') 確認完了日"
        strSQL &= ", case when t2.チェック ='1'  then 'OK' else '' end チェック"
        strSQL &= " , to_char(t2.確認完了日,'yyyy/mm/dd') 確認完了日"

        strSQL &= ",t.点検受付番号 "
        strSQL &= ",t.ｄｍ番号 "
        strSQL &= ",t.ステータス名 "
        strSQL &= ",t.回収区分"
        strSQL &= ",t.点検受付日"
        strSQL &= ",t.修理完了日 点検完了日 "
        strSQL &= ",t.フロント承認日 "
        strSQL &= ", left(t.回収完了日,10) 回収完了日 "
        strSQL &= ",t.技術料 "
        strSQL &= ",t.出張料 "
        strSQL &= ",t.その他料金 "

        strSQL &= ",t.サポート料"
        strSQL &= ",t.値引き"
        strSQL &= ",t.点検料金 "
        strSQL &= ",t.消費税額"
        strSQL &= ",t.請求合計金額"

        strSQL &= ",t.無償部品代 "
        strSQL &= ",t.無償出張料 "
        strSQL &= ",t.無償技術料 "
        strSQL &= ",t.無償その他内容 "
        strSQL &= ",t.無償その他 "
        strSQL &= ",t.無償出張料差額 "
        strSQL &= ",t.無償診断料 "
        strSQL &= ",t.無償合計 "



        strSQL &= ",t.点検状態区分名称 "
        strSQL &= ",t.修理状況"
        strSQL &= ",t.保証規定区分 "
        strSQL &= ", replace(t.請求先会社,'　','■') 請求先会社"
        strSQL &= ", replace(t.請求先名,'　','■') 請求先名"
        strSQL &= ",t.請求先電話"
        strSQL &= ",t.回収金額 "
        strSQL &= ",t.価格指示理由 "


        strSQL &= ",t.更新日 "
        strSQL &= ",coalesce(t.製品名_完了,t.製品名_通知) 製品名"

        If Me.ComboBox期間.Text <> "" Then
            If Not (Me.ComboBox期間.Text = "フロント承認日" Or Me.ComboBox期間.Text = "点検完了日" Or Me.ComboBox期間.Text = "回収完了日" Or Me.ComboBox期間.Text = "更新日") Then
                strSQL &= ",t." & Me.ComboBox期間.Text
            End If
        End If

        'strSQL &= ",t.点検受付番号"
        'strSQL &= ",t. 点検完了日 "
        'strSQL &= ",t.回収区分"
        'strSQL &= ",t.回収予定日"
        'strSQL &= ",t.回収完了日"
        'strSQL &= ",t.tc店略称"
        'strSQL &= ",t.店略称"
        strSQL &= ",t.マイページ連携仮id "

        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " left outer join " & schema & "t_teisei t1"
        strSQL &= " on t.点検受付番号 =t1.点検受付番号 "
        strSQL &= " left outer join " & schema & "t_check t2"
        strSQL &= " on t.点検受付番号 =t2.点検受付番号 "

        If Me.CheckBox完了を除く.Checked Then
            strSQL &= " and t1.完了 <> '1' "
        Else

        End If


        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and   t.回収区分 in(" & strSQL2 & ")"
        strSQL &= " and   t.点検状態区分名称 in(" & strSQL4 & ")"
        strSQL &= " and   t.修理状況 <> '訪問キャンセル'"
        strSQL &= strSQL31
        strSQL &= strSQL5

        If Me.CheckBox物件重複を外す.Checked Then
            strSQL &= " and t.点検受付番号  Not in ( " & SetSQL物件重複() & ")"
        End If

        strSQL &= " and ( t.ｄｍ番号 not like 'A%'  )"
        If CheckBoxCIM.Checked Then

        Else
            strSQL &= " and t.newflg  > 0"

        End If

        strSQL &= " order by t1.ステータス asc ,t.更新日 desc"


        dt = ClassPostgeDB.SetTable(strSQL)

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


        ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "訂正依頼内容", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "メモ", "メモ", 110, False)
        ro = settextColumn(Me.DataGridView1, ro, "出庫", "出庫", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "完了", "完了", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正更新日", "訂正更新日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 60, False)   '7

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検受付日", "点検受付日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検完了日", "点検完了日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "フロント承認日", "フロント承認日", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "回収完了日", "回収完了日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "技術料", "技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "その他料金", "その他料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "サポート料", "サポート料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "値引き", "値引き", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検料金", "点検料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "消費税額", "消費税額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求合計金額", "請求合計金額", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "無償部品代", "無償部品代", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料", "無償出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償技術料", "無償技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他内容", "無償その他内容", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他", "無償その他", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料差額", "無償出張料差額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償診断料", "無償診断料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償合計", "無償合計", 80, False)


        ro = settextColumn(Me.DataGridView1, ro, "点検状態区分名称", "点検状態区分名称", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "修理状況", "修理状況", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先会社", "請求先会社", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先名", "請求先名", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "価格指示理由", "価格指示理由", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "製品名", "製品名", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "マイページ連携仮id", "備考", 400, False)             '34

        Me.DataGridView1.AllowUserToAddRows = False
        If Me.DataGridView1.Rows.Count > 0 Then
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
            Next

            料金チェック1()
        End If
        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

    End Sub

    Private Function chk2025A(ro As Integer) As Boolean

        Dim buf As String
        Dim flg As Boolean
        Dim dt1 As DateTime
        Dim dt2 As DateTime
        Dim dt3 As DateTime

        chk2025A = False
        Try

            buf = Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("備考")).Value.ToString

            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Value.ToString = "0" Then Return False

            dt1 = DateTime.Parse(Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付日")).Value.ToString)
            dt2 = DateTime.Parse(dt2025Uketuke.Rows(0).Item("naiyou").ToString)
            dt3 = DateTime.Parse(dt2025Uketuke.Rows(0).Item("naiyou2").ToString)

            If dt2 <= dt1 And dt1 <= dt3 Then

            Else
                Return False
            End If

            dt1 = DateTime.Parse(Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検完了日")).Value.ToString)
            dt2 = DateTime.Parse(dt2025Kanryou.Rows(0).Item("naiyou").ToString)
            dt3 = DateTime.Parse(dt2025Kanryou.Rows(0).Item("naiyou2").ToString)
            If dt2 <= dt1 And dt1 <= dt3 Then

            Else
                Return False
            End If

            For Each nebiki In dt2025Nebiki.Rows

                flg = False

                If nebiki("bikou").ToString <> "" Then
                    If 0 <= buf.IndexOf(nebiki("bikou").ToString) Then
                        flg = True
                    End If
                End If

                If nebiki("bikou2").ToString <> "" Then
                    If 0 <= buf.IndexOf(nebiki("bikou2").ToString) Then
                        flg = True
                    End If
                End If

                If flg Then
                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Value.ToString = nebiki("kin").ToString Then
                        chk2025A = True
                    End If
                End If

            Next
        Catch ex As Exception
            chk2025A = False
        End Try

    End Function
    Private Function chk2025B(ro As Integer) As Boolean

        Dim buf As String
        Dim flg As Boolean
        Dim dt1 As DateTime
        Dim dt2 As DateTime
        Dim dt3 As DateTime
        chk2025B = False
        Try

            buf = Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("備考")).Value.ToString

            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Value.ToString = "0" Then Return False


            dt1 = DateTime.Parse(Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付日")).Value.ToString)
            dt2 = DateTime.Parse(dt2025Uketuke.Rows(0).Item("naiyou").ToString)
            dt3 = DateTime.Parse(dt2025Uketuke.Rows(0).Item("naiyou2").ToString)

            If dt2 <= dt1 And dt1 <= dt3 Then

            Else
                Return False
            End If

            dt1 = DateTime.Parse(Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検完了日")).Value.ToString)
            dt2 = DateTime.Parse(dt2025Kanryou.Rows(0).Item("naiyou").ToString)
            dt3 = DateTime.Parse(dt2025Kanryou.Rows(0).Item("naiyou2").ToString)
            If dt2 <= dt1 And dt1 <= dt3 Then

            Else
                Return False
            End If


            For Each nebiki In dt2025Nebiki.Rows

                flg = False

                If nebiki("bikou").ToString <> "" Then
                    If 0 <= buf.IndexOf(nebiki("bikou").ToString) Then
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("備考")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                        flg = True
                    End If
                End If

                If nebiki("bikou2").ToString <> "" Then
                    If 0 <= buf.IndexOf(nebiki("bikou2").ToString) Then
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("備考")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                        flg = True
                    End If
                End If

                If flg Then
                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Value.ToString = nebiki("kin").ToString Then
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                        chk2025B = True
                    End If
                End If

            Next
            If chk2025B = False Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
            End If

        Catch ex As Exception
            chk2025B = False

        End Try

    End Function

    Private Sub Getこまめな点検変更日()
        Dim dt As DataTable
        Dim strSQL As String = "select naiyou from " & schema & "m_system  where kbn ='340' and seq ='0'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            KomaneDay = dt.Rows(0).Item(0).ToString & " 00:00:00"
        Else
            KomaneDay = "2020/01/01 00:00:00"
        End If
    End Sub

    '====
    '0 : こまめな点検ではない
    '1: こまめな点検でOK
    '2:こまめな点検でERROR
    Private Function chk2025こまめ(ro As Integer) As Integer
        Dim ret = 0
        Dim buf As String
        buf = Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("依頼区分内容")).Value.ToString
        If buf = "こまめな点検" Then
            ret = 1
            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("依頼区分内容")).Style.BackColor = Color.Green

            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Value.ToString <> "3000" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Style.BackColor = Color.Red
                ret = 2
            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償出張料")).Value.ToString <> "3000" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償出張料")).Style.BackColor = Color.Red
                ret = 2
            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("技術料")).Value.ToString <> "5000" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("技術料")).Style.BackColor = Color.Red
                ret = 2
            End If
            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償技術料")).Value.ToString <> "2100" Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償技術料")).Style.BackColor = Color.Red
                ret = 2
            End If

            If KomaneDay >= Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検完了日")).Value.ToString Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償診断料")).Value.ToString <> "300" Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償診断料")).Style.BackColor = Color.Red
                    ret = 2
                End If
            Else
                If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償診断料")).Value.ToString <> "500" Then            '2025/08/18 変更
                    Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償診断料")).Style.BackColor = Color.Red
                    ret = 2
                End If
            End If

            If ret = 2 Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("依頼区分内容")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red

            End If
        End If
        Return ret
    End Function






    Private Sub 料金チェック1()

        GetMaster2025()


        For ro = 0 To Me.DataGridView1.Rows.Count - 2

            'CIMが更新された
            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("訂正更新日")).Value.ToString() <> "" Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("訂正更新日")).Value.ToString() < Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("更新日")).Value.ToString() Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Yellow
                    Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("訂正更新日")).Style.BackColor = Color.Yellow
                End If
            End If

            If chk2025A(ro) = True Then
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.GreenYellow
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Style.BackColor = Color.GreenYellow
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("備考")).Style.BackColor = Color.GreenYellow
            Else


                If chk2025B(ro) Then


                Else


                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Value.ToString() <>
                    Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償その他")).Value.ToString() Then     'その他料金

                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償その他")).Style.BackColor = Color.Red


                    End If

                    '出張料
                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Value.ToString() <> Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償出張料")).Value.ToString() Then
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償出張料")).Style.BackColor = Color.Red
                    End If
                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Value.ToString() = "0" Then               'その他料金
                        If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償出張料")).Value.ToString() = "0" Then
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償出張料")).Style.BackColor = Color.Red
                        End If
                    End If

                    '値引き
                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Value.ToString() <> "0" Then      '値引き
                        If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付日")).Value.ToString() > "2024/10/01" Then      '値引き
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                            'Me.DataGridView1.Rows(ro).Cells(20).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Style.BackColor = Color.Gold
                        Else
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("値引き")).Style.BackColor = Color.Cyan
                        End If
                    End If


                    Select Case Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("保証規定区分")).Value.ToString()                '保証規定区分
                        Case "安心プラン"
                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ｄｍ番号")).Value.ToString.Substring(0, 2) <> "AH" Then   'ｄｍ番号
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ｄｍ番号")).Style.BackColor = Color.Yellow
                            End If

                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("技術料")).Value.ToString() <> "0" Then     '技術料
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("技術料")).Style.BackColor = Color.Red
                            End If

                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Value.ToString() <> "0" Then
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Style.BackColor = Color.Red
                            End If

                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Value.ToString() <> "0" Then     'その他料金
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Style.BackColor = Color.Red
                            End If

                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検料金")).Value.ToString() <> "0" Then     '点検料金
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検料金")).Style.BackColor = Color.Red
                            End If

                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("回収金額")).Value.ToString() <> "0" Then     '回収金額
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("回収金額")).Style.BackColor = Color.Red
                            End If

                        Case "法定点検"
                            Chkその他料金(ro)

                        Case "あんしん点検"
                            Chkその他料金(ro)


                        Case Else

                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                            Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("保証規定区分")).Style.BackColor = Color.Red

                    End Select
                End If
            End If
        Next

    End Sub

    Private Sub Chkその他料金(ro As Integer)

        If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Value.ToString() <> "0" Then     'その他料金
            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償その他内容")).Value.ToString() <> "0" Then '無償その他内容

            Else
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償その他内容")).Style.BackColor = Color.Red

            End If
        End If

        If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償その他")).Value.ToString() <> "0" Then
            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Value.ToString() <> "0" Then

            Else
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("ステータス")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("その他料金")).Style.BackColor = Color.Red
                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("無償その他")).Style.BackColor = Color.Red
            End If
        End If

        If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付日")).Value.ToString() >= "2022/04/01" And
           Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付日")).Value.ToString() < "2022/07/01" Then

            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検完了日")).Value.ToString() >= "2022/04/01" And
               Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検完了日")).Value.ToString() < "2022/09/01" Then

                If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("製品名")).Value.ToString <> "" Then
                    If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("製品名")).Value.ToString.Length > 4 Then
                        If Not (Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("製品名")).Value.ToString.Substring(0, 3) = "Ｆ４５" Or
                        Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("製品名")).Value.ToString.Substring(0, 3) = "ＦＢ４") Then
                            'Ｆ４５  or ＦＢ４ 
                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Value <> "0" Then

                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Style.BackColor = Color.Red

                            End If
                        Else
                            If Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Value = "0" Then

                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("点検受付番号")).Style.BackColor = Color.Red
                                Me.DataGridView1.Rows(ro).Cells(Getarray料金チェック("出張料")).Style.BackColor = Color.Red

                            End If

                        End If
                    End If
                End If
            End If
        End If

    End Sub
#End Region

#Region "未回収チェック"

    Private Sub 未回収チェック()
        Dim strSQL As String
        Dim ro As Integer = 0

        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        '--------
        検索条件()
        '-------
        strSQL = ""

        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t1.訂正依頼内容 "
        strSQL &= ",t1.メモ "
        strSQL &= ",case when t1.出庫 = '1' then '停止'  else '' end 出庫 "
        strSQL &= ",case when t1.完了 = '1' then '完了'  else '' end 完了 "
        strSQL &= ",t1.更新日 as 訂正更新日"

        'strSQL &= ",t1.技術チェック as チェック, TO_CHAR(t1.技術確認完了日,'yyyy/mm/dd') 確認完了日"
        ' strSQL &= ",t2.チェック , TO_CHAR(t2.確認完了日,'yyyy/mm/dd') 確認完了日"
        strSQL &= ", case when t2.チェック ='1'  then 'OK' else '' end チェック"
        strSQL &= " , to_char(t2.確認完了日,'yyyy/mm/dd') 確認完了日"

        strSQL &= ",t.点検受付番号 "
        strSQL &= ",t.ｄｍ番号 "
        strSQL &= ",t.ステータス名 "
        strSQL &= ",t.回収区分"
        strSQL &= ",t.点検受付日"
        strSQL &= ",t.修理完了日 点検完了日 "

        strSQL &= ",t.フロント承認日 "
        strSQL &= ", left(t.回収予定日,10) 回収予定日 "
        strSQL &= ", left(t.回収完了日,10) 回収完了日 "
        strSQL &= ",t.技術料 "
        strSQL &= ",t.出張料 "
        strSQL &= ",t.値引き "
        strSQL &= ",t.その他料金 "
        strSQL &= ",t.点検料金 "
        strSQL &= ", cast (COALESCE(NULLIF(TRIM(t.消費税額), ''), '0') as integer) 消費税額"
        strSQL &= ",t.点検料金 - cast (COALESCE(NULLIF(TRIM(t.値引き), ''), '0') as integer)  金額税抜き"
        strSQL &= ",t.点検料金 - cast (COALESCE(NULLIF(TRIM(t.値引き), ''), '0') as integer) + cast (COALESCE(NULLIF(TRIM(t.消費税額), ''), '0') as integer) 金額税込み"

        strSQL &= ",t.無償部品代 "
        strSQL &= ",t.無償出張料 "
        strSQL &= ",t.無償技術料 "
        strSQL &= ",t.無償その他 "
        strSQL &= ",t.無償出張料差額 "
        strSQL &= ",t.無償合計 "
        strSQL &= ",t.点検状態区分名称 "
        strSQL &= ",t.修理状況"
        strSQL &= ",t.保証規定区分 "
        strSQL &= ",t.請求先会社 "
        strSQL &= ",t.請求先名 "
        strSQL &= ",t.請求先電話"
        strSQL &= ",t.回収金額 "
        strSQL &= ",t.更新日 "

        If Me.ComboBox期間.Text <> "" Then
            If Not (Me.ComboBox期間.Text = "フロント承認日" Or Me.ComboBox期間.Text = "点検完了日" Or Me.ComboBox期間.Text = "回収完了日" Or Me.ComboBox期間.Text = "更新日") Then
                strSQL &= ",t." & Me.ComboBox期間.Text
            End If
        End If

        strSQL &= " From " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " Left outer join " & schema & "t_teisei t1"
        strSQL &= " on t.点検受付番号 = t1.点検受付番号 "
        If Me.CheckBox回収対象外.Checked Then
            'strSQL &= " and  t1.ステータス not  in ( Select naiyou from " & schema & "m_system  where kbn ='20'and naiyou2 ='1' ) )"
        End If

        strSQL &= " left outer join  " & schema & "t_check t2 on t.点検受付番号 =t2.点検受付番号 "

        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and t.回収区分 in (" & strSQL2 & ")"
        strSQL &= " and t.回収完了日 = ''"
        strSQL &= " and t.点検状態区分名称 not In(" & strSQL4 & ")"
        strSQL &= " and t.修理状況 Not In('訪問キャンセル','受付キャンセル') "
        strSQL &= " and t.保証規定区分 In('法定点検','あんしん点検','') "
        '            修理空振り料 営業指示 技術指示 法定点検修理優遇 点検センター指示 無償保証延長


        strSQL &= strSQL31
        strSQL &= strSQL5

        If Me.CheckBox回収対象外.Checked Then
            strSQL &= " and t.点検受付番号 not in (select  tt.点検受付番号 from " & schema & "t_teisei tt where tt.ステータス  in ( Select naiyou from " & schema & "m_system  where kbn ='20'and naiyou2 ='1' ) )"
        End If

        If CheckBoxCIM.Checked Then

        Else
            strSQL &= " and t.newflg  ='1' "
        End If



        strSQL &= " order by t.更新日 asc"

        dt = ClassPostgeDB.SetTable(strSQL)
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

        ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "訂正依頼内容", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "メモ", "メモ", 110, False)
        ro = settextColumn(Me.DataGridView1, ro, "出庫", "出庫", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "完了", "完了", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正更新日", "訂正更新日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 60, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検受付日", "点検受付日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検完了日", "点検完了日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "フロント承認日", "フロント承認日", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "回収予定日", "回収予定日", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収完了日", "回収完了日", 80, False)


        ro = settextColumn(Me.DataGridView1, ro, "技術料", "技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "その他料金", "その他料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "値引き", "値引き", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検料金", "点検料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "消費税額", "消費税額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "金額税込み", "請求金額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "無償部品代", "無償部品代", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料", "無償出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償技術料", "無償技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他", "無償その他", 80, False)


        ro = settextColumn(Me.DataGridView1, ro, "無償出張料差額", "無償出張料差額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償合計", "無償合計", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検状態区分名称", "点検状態区分名称", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "修理状況", "修理状況", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "保証規定区分", "保証規定区分", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先会社", "請求先会社", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "請求先名", "請求先名", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "請求先電話", "請求先電話", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "回収金額", "回収金額", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 80, False)


        Me.DataGridView1.AllowUserToAddRows = False
        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

        If Me.DataGridView1.Rows.Count > 0 Then
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
            Next

            未回収チェック１()
        End If
    End Sub
    Private Sub 未回収チェック１()
        For ro = 0 To Me.DataGridView1.Rows.Count - 2
            'CIM更新チェック
            If Me.DataGridView1.Rows(ro).Cells(Getarray未回収("訂正更新日")).Value.ToString() <> "" Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray未回収("訂正更新日")).Value.ToString() < Me.DataGridView1.Rows(ro).Cells(Getarray未回収("更新日")).Value.ToString() Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray未回収("ステータス")).Style.BackColor = Color.Yellow
                    Me.DataGridView1.Rows(ro).Cells(Getarray未回収("訂正更新日")).Style.BackColor = Color.Yellow
                End If
            End If
        Next
    End Sub

#End Region

#Region "出張料重複チェック"

    Private Sub 出張料重複チェック()
        Dim strSQL As String
        Dim ro As Integer = 0
        'Dim dt As New DataTable
        dt = Nothing
        Me.DataGridView1.DataSource = Nothing

        検索条件()
        '-------
        strSQL = ""
        strSQL &= "select "
        strSQL &= " t2.ステータス"
        strSQL &= ",t2.訂正依頼内容 "
        strSQL &= ",t2.メモ "
        strSQL &= ",case when t2.出庫 = '1' then '停止'  else '' end 出庫 "
        strSQL &= ",case when t2.完了 = '1' then '完了'  else '' end 完了 "
        strSQL &= ",t2.更新日 as 訂正更新日"

        'strSQL &= ",t2.技術チェック as チェック, TO_CHAR(t2.技術確認完了日,'yyyy/mm/dd') 確認完了日"
        'strSQL &= ",t3.チェック , TO_CHAR(t3.確認完了日,'yyyy/mm/dd') 確認完了日"

        strSQL &= " , case when t3.チェック ='1'  then 'OK' else '' end チェック"
        strSQL &= " , to_char(t3.確認完了日,'yyyy/mm/dd') 確認完了日"

        strSQL &= ",t1.点検受付番号"
        strSQL &= ",t1.ｄｍ番号 "
        strSQL &= ",t1.ステータス名"
        strSQL &= ",t1.点検受付日"
        strSQL &= ",t1.修理完了日 点検完了日"
        strSQL &= ",t1.都道府県名"
        strSQL &= ",t1.市区町村名"
        strSQL &= ",t1.町域"
        strSQL &= ",replace(replace(t1.番地,'　',''),' ','') 番地"
        strSQL &= ",replace(replace(t1.建物,'　',''),' ','') 建物"
        strSQL &= ",t1.部屋"
        strSQL &= ",t1.回収区分"
        strSQL &= ",t1.技術料"
        strSQL &= ",t1.出張料"
        strSQL &= ",t1.その他料金"
        strSQL &= ",t1.点検料金"
        strSQL &= ",t1.無償出張料"
        strSQL &= ",t1.無償技術料"
        strSQL &= ",t1.無償その他"
        strSQL &= ",t1.修理状況"
        strSQL &= ",t1.担当shopコード "
        strSQL &= ",t1.店略称 "
        strSQL &= ",t1.担当サービスマン "
        strSQL &= ",t1.サービスマン名 "
        strSQL &= ",t1.価格指示理由 価格指示理由"
        strSQL &= ",t1.更新日"

        If Me.ComboBox期間.Text <> "" Then
            If Not (Me.ComboBox期間.Text = "点検完了日" Or Me.ComboBox期間.Text = "更新日") Then
                strSQL &= ",t1." & Me.ComboBox期間.Text
            End If
        End If

        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t1 "

        strSQL &= " left outer join " & schema & "t_teisei t2  on t1.点検受付番号 = t2.点検受付番号 "
        strSQL &= " left outer join " & schema & "t_check t3 on t1.点検受付番号 = t3.点検受付番号 "

        strSQL &= " where ("
        strSQL &= " t1.都道府県名 "
        strSQL &= ",t1.市区町村名"
        strSQL &= ",t1.町域"
        strSQL &= ",replace(replace(t1.番地,'　',''),' ','')"
        If Me.CheckBox建物.Checked Then strSQL &= ",replace(replace(t1.建物,'　',''),' ','')"
        strSQL &= ",t1.担当サービスマン"
        strSQL &= ", left (t1.点検完了日,10)"
        strSQL &= ") in ("
        strSQL &= " select "
        strSQL &= " t.都道府県名 "
        strSQL &= ",t.市区町村名"
        strSQL &= ",t.町域"
        strSQL &= ",replace(replace(t.番地,'　',''),' ','')"
        If Me.CheckBox建物.Checked Then strSQL &= ",replace(replace(t.建物,'　',''),' ','')"
        strSQL &= ",t.担当サービスマン"
        strSQL &= ",left (t.点検完了日,10)"
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and   t.回収区分 in(" & strSQL2 & ")"
        strSQL &= " and   t.点検状態区分名称 in(" & strSQL4 & ")"
        strSQL &= " and left (t.点検完了日,10)  <> '' "

        strSQL &= strSQL31
        strSQL &= " group by "
        strSQL &= " t.都道府県名"
        strSQL &= ",t.市区町村名"
        strSQL &= ",t.町域"
        strSQL &= ",replace(replace(t.番地,'　',''),' ','')"
        If Me.CheckBox建物.Checked Then strSQL &= ",replace(replace(t.建物,'　',''),' ','')"
        strSQL &= ",t.担当サービスマン"
        strSQL &= ",left (点検完了日,10)"
        strSQL &= " having count(*) > 1"
        strSQL &= ")"
        strSQL &= " and t1.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and t1.回収区分 in(" & strSQL2 & ")"
        strSQL &= " and t1.点検状態区分名称 in(" & strSQL4 & ")"
        strSQL &= " and t1.修理状況 Not in ('訪問キャンセル')"
        strSQL &= strSQL32


        If CheckBoxCIM.Checked Then

        Else
            strSQL &= " "

        End If



        strSQL &= " order by "
        strSQL &= " t1.担当サービスマン"
        strSQL &= ",t1.都道府県名 "
        strSQL &= ",t1.市区町村名"
        strSQL &= ",t1.町域"
        strSQL &= ",replace(replace(t1.番地,'　',''),' ','')"
        strSQL &= ",replace(replace(t1.建物,'　',''),' ','')"
        strSQL &= ",t1.修理完了日"
        strSQL &= ",t1.出張料"
        strSQL &= ",t1.無償出張料"



        dt = ClassPostgeDB.SetTable(strSQL)

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


        ro = settextColumn(Me.DataGridView1, ro, "ステータス", "ステータス", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正依頼内容", "訂正依頼内容", 120, False)
        ro = settextColumn(Me.DataGridView1, ro, "メモ", "メモ", 110, False)
        ro = settextColumn(Me.DataGridView1, ro, "出庫", "出庫", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "完了", "完了", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "訂正更新日", "訂正更新日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 100, False)

        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "点検受付番号", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "ｄｍ番号", "ｄｍ番号", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "ステータス名", "ステータス名", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検受付日", "点検受付日", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検完了日", "点検完了日", 100, False)

        ro = settextColumn(Me.DataGridView1, ro, "都道府県名", "都道府県名", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "市区町村名", "市区町村名", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "町域", "町域", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "番地", "番地", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "建物", "建物", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "部屋", "部屋", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "回収区分", "回収区分", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "技術料", "技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "出張料", "出張料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "その他料金", "その他料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "点検料金", "点検料金", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償出張料", "無償出張料", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "無償技術料", "無償技術料", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "無償その他", "無償その他", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "修理状況", "修理状況", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "担当shopコード", "担当shopコード", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "店略称", "店略称", 80, False)

        ro = settextColumn(Me.DataGridView1, ro, "担当サービスマン", "担当サービスマン", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "サービスマン名", "サービスマン名", 80, False)
        ro = settextColumn(Me.DataGridView1, ro, "価格指示理由", "価格指示理由", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "更新日", "更新日", 100, False)

        Me.DataGridView1.AllowUserToAddRows = False
        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

        If Me.DataGridView1.Rows.Count > 0 Then

            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
            Next

            出張料重複チェック1()

        End If
    End Sub

    Private Sub 出張料重複チェック1()

        '----- 色を変える
        Dim ro As Integer
        Dim colr As Color = Color.Aqua  'Color.Wheat
        Dim colr15 As Color = Color.Aqua  'Color.Wheat
        Dim col30 As String = ""
        Dim col3 As String = ""
        Dim col4 As String = ""
        Dim col5 As String = ""
        Dim col6 As String = ""
        Dim col7 As String = ""
        Dim col8 As String = ""
        Dim col19 As String = ""
        Dim col20 As String = ""
        Dim x As Integer


        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            col30 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検完了日")).Value.ToString
            If col30 <> "" Then
                col30 = col30.Substring(0, 10)
            End If

            If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("都道府県名")).Value.ToString = col4 _
                And Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("市区町村名")).Value.ToString = col5 _
                And Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("町域")).Value.ToString = col6 _
                And Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("番地")).Value.ToString = col7 _
                And Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("建物")).Value.ToString = col8 _
                And Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("担当shopコード")).Value.ToString = col19 _
                And Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("担当サービスマン")).Value.ToString = col20 _
                And col3 = col30 _
                Then

            Else
                If colr = Color.Aqua Then
                    colr = Color.White
                Else
                    colr = Color.Aqua
                End If

                col3 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検完了日")).Value.ToString
                col4 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("都道府県名")).Value.ToString
                col5 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("市区町村名")).Value.ToString
                col6 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("町域")).Value.ToString
                col7 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("番地")).Value.ToString
                col8 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("建物")).Value.ToString
                col19 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("担当shopコード")).Value.ToString
                col20 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("担当サービスマン")).Value.ToString

                If col3 <> "" Then
                    col3 = col3.Substring(0, 10)
                End If

            End If

            For x = 0 To Me.DataGridView1.Columns.Count - 1
                Me.DataGridView1.Rows(ro).Cells(x).Style.BackColor = colr
            Next
            'System.Windows.Forms.Application.DoEvents()

        Next

        '出張料のチェック
        Dim syutyou As String = ""
        colr = Color.AliceBlue
        Dim syutyou15 As String = ""
        '        colr15 = Color.AliceBlue

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検完了日")).Style.BackColor = colr Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出張料")).Value.ToString() <> "0" Then
                    If syutyou = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出張料")).Value.ToString() Then
                        Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検受付番号")).Style.BackColor = Color.Red
                        'Me.DataGridView1.Rows(ro).Cells(1).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出張料")).Style.BackColor = Color.Red
                    End If
                End If

                If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("無償出張料")).Value.ToString() <> "0" Then
                    If syutyou15 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("無償出張料")).Value.ToString() Then
                        Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検受付番号")).Style.BackColor = Color.Red
                        Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("無償出張料")).Style.BackColor = Color.Red
                    Else
                        syutyou15 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("無償出張料")).Value.ToString()
                    End If
                Else
                    syutyou15 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("無償出張料")).Value.ToString()
                End If

            Else
                colr = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検完了日")).Style.BackColor
                syutyou = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出張料")).Value.ToString()
                syutyou15 = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("無償出張料")).Value.ToString()
            End If


            'CIM更新チェック
            If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正更新日")).Value.ToString() <> "" Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正更新日")).Value.ToString() < Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("更新日")).Value.ToString() Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ステータス")).Style.BackColor = Color.Yellow
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("訂正更新日")).Style.BackColor = Color.Yellow
                End If
            End If
            'System.Windows.Forms.Application.DoEvents()
        Next

    End Sub
#End Region

#Region "検索条件"
    Private Sub 検索条件()

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
                strSQL31 = " and t.修理完了日" & " between '" & Me.DateTimePicker期間1.Value.ToShortDateString() & "' and '" & Me.DateTimePicker期間2.Value.ToShortDateString() & "'"
                strSQL32 = " and t1.修理完了日" & " between '" & Me.DateTimePicker期間1.Value.ToShortDateString() & "' and '" & Me.DateTimePicker期間2.Value.ToShortDateString() & "'"

            Else
                strSQL31 = " and t." & Me.ComboBox期間.Text & " between '" & Me.DateTimePicker期間1.Value.ToShortDateString() & "' and '" & Me.DateTimePicker期間2.Value.ToShortDateString() & "'"
                strSQL32 = " and t1." & Me.ComboBox期間.Text & " between '" & Me.DateTimePicker期間1.Value.ToShortDateString() & "' and '" & Me.DateTimePicker期間2.Value.ToShortDateString() & "'"
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
                strSQL5 &= " and (t.請求先会社 like '%" & StrConv(Me.TextBox請求先会社名.Text, VbStrConv.Narrow) & "%' "
                strSQL5 &= " or   t.請求先会社 like '%" & StrConv(Me.TextBox請求先会社名.Text, VbStrConv.Wide) & "%') "
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


    Private Function SetSQL物件重複()
        Dim strSQL As String

        検索条件()
        '-------
        strSQL = ""

        strSQL &= "select t1.点検受付番号"

        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t1 "

        strSQL &= " where ("
        strSQL &= " t1.都道府県名 "
        strSQL &= ",t1.市区町村名"
        strSQL &= ",t1.町域"
        strSQL &= ",replace(replace(t1.番地,'　',''),' ','')"
        If Me.CheckBox建物.Checked Then strSQL &= ",replace(replace(t1.建物,'　',''),' ','')"
        strSQL &= ",t1.担当サービスマン"
        strSQL &= ", left (t1.点検完了日,10)"
        strSQL &= ") in ("
        strSQL &= " select "
        strSQL &= " t.都道府県名 "
        strSQL &= ",t.市区町村名"
        strSQL &= ",t.町域"
        strSQL &= ",replace(replace(t.番地,'　',''),' ','')"
        If Me.CheckBox建物.Checked Then strSQL &= ",replace(replace(t.建物,'　',''),' ','')"
        strSQL &= ",t.担当サービスマン"
        strSQL &= ",left (t.点検完了日,10)"
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and   t.回収区分 in(" & strSQL2 & ")"
        strSQL &= " and   t.点検状態区分名称 in(" & strSQL4 & ")"
        strSQL &= " and  left(t.点検完了日,10)  <> '' "

        strSQL &= strSQL31
        strSQL &= " group by "
        strSQL &= " t.都道府県名"
        strSQL &= ",t.市区町村名"
        strSQL &= ",t.町域"
        strSQL &= ",replace(replace(t.番地,'　',''),' ','')"
        If Me.CheckBox建物.Checked Then strSQL &= ",replace(replace(t.建物,'　',''),' ','')"
        strSQL &= ",t.担当サービスマン"
        strSQL &= ",left(点検完了日,10)"
        strSQL &= " having count(*) > 1"
        strSQL &= ")"


        strSQL &= " and t1.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and t1.回収区分 in(" & strSQL2 & ")"
        strSQL &= " and t1.点検状態区分名称 in(" & strSQL4 & ")"
        strSQL &= " and t1.修理状況 Not in ('訪問キャンセル')"
        strSQL &= strSQL32
        If CheckBoxCIM.Checked Then

        Else
            strSQL &= " and t.newflg  ='1'"

        End If


        strSQL &= " group by t1.点検受付番号"

        Return strSQL

    End Function



#End Region

#Region "非表示"
    Private Sub Button正常を削除_Click(sender As Object, e As EventArgs) Handles Button正常を削除.Click
        Dim ro As Integer
        Dim co As Integer

        Select Case Me.ComboBox項目.Text
            Case "キャンペーン2024"
                co = 8
            Case "キャンペーン2025"
                co = 8
            Case Else
                co = 0

        End Select


        If Me.DataGridView1.Rows.Count > 1 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Try
                If Me.Button正常を削除.Text = "正常を非表示" Then

                    Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count - 2
                    Me.ToolStripProgressBar1.Step = 1


                    For ro = 0 To Me.DataGridView1.Rows.Count - 2
                        Me.ToolStripProgressBar1.Value = ro


                        If Me.DataGridView1.Rows(ro).Cells(co).Style.BackColor = Color.Red Or Me.DataGridView1.Rows(ro).Cells(0).Value.ToString <> "" Then


                        Else
                            If Me.DataGridView1.Rows.Count > ro + 1 Then
                                Me.DataGridView1.CurrentCell = Me.DataGridView1(7, ro + 1)
                                Me.DataGridView1.Rows(ro).Visible = False

                            Else
                                MessageBox.Show("これ以上非表示にできません")
                                Me.ToolStripProgressBar1.Value = 0
                                Return

                            End If
                        End If
                    Next

                    Me.ToolStripProgressBar1.Value = 0

                    Me.Button正常を削除.Text = "元に戻す"
                Else
                    Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count - 2
                    Me.ToolStripProgressBar1.Step = 1
                    For ro = 0 To Me.DataGridView1.Rows.Count - 2
                        Me.ToolStripProgressBar1.Value = ro

                        If Me.DataGridView1.Rows(ro).Cells(co).Style.BackColor = Color.Red Or Me.DataGridView1.Rows(ro).Cells(0).Value.ToString <> "" Then

                        Else
                            Me.DataGridView1.Rows(ro).Visible = True
                        End If
                    Next
                    Me.ToolStripProgressBar1.Value = 0
                    Me.Button正常を削除.Text = "正常を非表示"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
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

    Private Sub 条件初期ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 条件初期ToolStripMenuItem.Click

        Dim dtToday As DateTime = DateTime.Today
        Me.DateTimePicker期間1.Value = dtToday.AddMonths(0 - Integer.Parse(GetSystemto("2", "2")))
        Me.DateTimePicker期間2.Value = dtToday

        Me.ComboBox項目.SelectedIndex = -1
        Me.ComboBox期間.SelectedIndex = -1

        Me.CheckBox完了を除く.Checked = True
        Me.TextBox請求先会社名.Text = ""
        Me.TextBox請求先名.Text = ""
        Me.TextBox請求先電話.Text = ""
        Me.CheckBox点検受付.Checked = True
        Me.CheckBox点検完了.Checked = True
        Me.CheckBox請求書発行済.Checked = False
        Me.CheckBox回収完了.Checked = False
        Me.CheckBox受付ｷｬﾝｾﾙ.Checked = False
        Me.CheckBox訪問前ｷｬﾝｾﾙ.Checked = False
        Me.CheckBox訪問ｷｬﾝｾﾙ.Checked = False

        Me.CheckBox受付完了.Checked = False
        Me.CheckBox受付保留.Checked = False
        Me.CheckBox受付キャンセル.Checked = False
        Me.CheckBoxナンセンスコール.Checked = False
        Me.CheckBox訪問前キャンセル.Checked = False

        Me.CheckBox修理完了.Checked = True
        Me.CheckBoxモバイル修理完了.Checked = True
        Me.CheckBox再訪問.Checked = False

        Me.CheckBoxSS現金徴収.Checked = True
        Me.CheckBoxSS後日請求.Checked = True
        Me.CheckBoxNR後日請求.Checked = True

        Me.CheckBox建物.Checked = True

        Me.Label条件.Text = ""

    End Sub

    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        Select Case Me.ComboBox項目.Text
            Case "出張料重複チェック"


            Case "料金チェック"
                料金チェック1()

            Case "安心プランチェック"
                安心プランチェック1()

            Case "未回収チェック"
                未回収チェック１()

        End Select

    End Sub
#End Region


    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 1)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("出力しました")
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            OutputCsvFromDataGridView(Me.DataGridView1, Me.ToolStripProgressBar1)
            MessageBox.Show("出力しました")
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        再チェック()
    End Sub

#Region "未回収EXCEL"

    Private Function 未回収チェック2ListSQL()
        Dim strSQL As String

        '--------
        検索条件()
        '-------
        strSQL = ""

        strSQL &= "select "
        strSQL &= " t.tc店略称 "
        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " Left outer join " & schema & "t_teisei t1"
        strSQL &= " on t.点検受付番号 = t1.点検受付番号 "

        strSQL &= " Left outer join " & schema & "t_check t2"
        strSQL &= " on t.点検受付番号 =t2.点検受付番号 "

        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and t.回収区分 in (" & strSQL2 & ")"
        strSQL &= " and t.回収完了日 = ''"
        strSQL &= " and t.点検状態区分名称 not In(" & strSQL4 & ")"
        strSQL &= " and t.修理状況 Not In('訪問キャンセル','受付キャンセル') "
        strSQL &= " and t.保証規定区分 In('法定点検','あんしん点検','') "

        strSQL &= strSQL31
        strSQL &= strSQL5

        If Me.CheckBox回収対象外.Checked Then
            strSQL &= " and t.点検受付番号 not in (select  tt.点検受付番号 from " & schema & "t_teisei tt where tt.ステータス  in ( Select naiyou from " & schema & "m_system  where kbn ='20'and naiyou2 ='1' ) )"
        End If

        strSQL &= " group by t.tc店略称 order by t.tc店略称 asc"

        Return strSQL

    End Function

    Private Function 未回収チェック2ListSQL(syou As String)
        Dim strSQL As String

        '--------
        検索条件()
        '-------
        strSQL = ""

        strSQL &= "select "
        strSQL &= " t.点検受付番号"
        strSQL &= ",t.点検完了日"
        strSQL &= ",t.回収区分"
        strSQL &= ",t.回収予定日"
        strSQL &= ",t.回収完了日"

        strSQL &= ", t.点検料金 - cast (COALESCE(NULLIF(TRIM(t.値引き), ''), '0')as integer)  金額税抜き"
        strSQL &= ", t.点検料金 - cast (COALESCE(NULLIF(TRIM(t.値引き), ''), '0')as integer) + cast (COALESCE(NULLIF(TRIM(t.消費税額), ''), '0')as integer)    金額税込み"

        strSQL &= ",t.tc店略称"
        strSQL &= ",t.店略称"

        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " Left outer join " & schema & "t_teisei t1"
        strSQL &= " on t.点検受付番号 = t1.点検受付番号 "

        strSQL &= " left outer join " & schema & "t_check t2"
        strSQL &= " on t.点検受付番号 =t2.点検受付番号 "

        strSQL &= " where t.ステータス名 in (" & strSQL1 & ")"
        strSQL &= " and t.回収区分 in (" & strSQL2 & ")"
        strSQL &= " and t.回収完了日 = ''"
        strSQL &= " and t.点検状態区分名称 not In(" & strSQL4 & ")"
        strSQL &= " and t.修理状況 Not In('訪問キャンセル','受付キャンセル') "
        strSQL &= " and t.保証規定区分 In('法定点検','あんしん点検','') "

        strSQL &= strSQL31
        strSQL &= strSQL5

        If Me.CheckBox回収対象外.Checked Then
            strSQL &= " and t.点検受付番号 not in (select  tt.点検受付番号 from " & schema & "t_teisei tt where tt.ステータス  in ( Select naiyou from " & schema & "m_system  where kbn ='20'and naiyou2 ='1' ) )"
        End If

        If syou <> "" Then
            strSQL &= " and t.tc店略称 ='" & syou & "'"
        End If
        strSQL &= " order by t.店略称 asc ,  t.点検受付番号"

        Return strSQL

    End Function

    Private Sub EXCEL未回収ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCEL未回収ToolStripMenuItem.Click
        Dim syouken As DataTable = New DataTable
        Dim mise As DataTable = New DataTable
        Dim soy As String

        syouken = ClassPostgeDB.SetTable(未回収チェック2ListSQL())

        If syouken.Rows.Count > 0 Then
            MikaiOpen()
            For Each row As DataRow In syouken.Rows

                soy = row.Item(0).ToString()
                mise = ClassPostgeDB.SetTable(未回収チェック2ListSQL(soy))
                MkaiAdd(mise, soy.Replace("NR", ""))
            Next

            mise = ClassPostgeDB.SetTable(未回収チェック2ListSQL(""))
            MkaiAdd(mise, "全国")

            MikaiClose()
            MessageBox.Show("出力しました")
        Else
            MessageBox.Show("出力するデータがありません。")
        End If
    End Sub
#End Region
#Region "チェック更新"

    Private Sub ALLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ALLToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = True
        Next

    End Sub

    Private Sub 全OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全OFFToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
        Next

    End Sub

    Private Sub 反転ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転ToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value)
        Next
    End Sub
    Private Sub チェックToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles チェックToolStripMenuItem1.Click

        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("完了")).Value = "" Then
                If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("出庫")).Value = "" Then
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = True
                Else
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
                End If
            Else
                Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
            End If
        Next

    End Sub

    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        Dim ro As Integer
        Dim strSQL As String
        Dim ret As String
        Dim Ken As Integer = 0
        Dim flg As String

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count
        Me.ToolStripProgressBar1.Minimum = 0
        Me.ToolStripProgressBar1.Step = 1
        Me.ToolStripProgressBar1.Value = 0


        ClassPostgeDB.DbOpen()
        ClassPostgeDB.BeginTrans()

        Try
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.ToolStripProgressBar1.PerformStep()

                ret = Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value.ToString

                If ret = "" Then
                    ret = "0"
                End If

                If ret Then
                    flg = "1"
                    If Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("完了")).Value.ToString = "" Then
                        flg = "1"
                    Else
                        flg = "0"
                    End If
                    strSQL = "insert into tenken.t_teisei  (点検受付番号, 完了, 完了日) values ('" & Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("点検受付番号")).Value.ToString & "', '" & flg & "',now())"
                    strSQL &= " on conflict on constraint t_teisei_pk"
                    strSQL &= " do update set 完了='" & flg & "' , 完了日 = now()"


                    ClassPostgeDB.EXEC_tr(strSQL)

                        Ken = Ken + 1
                    Me.DataGridView1.Rows(ro).Cells(Getarray出張料重複("ﾁｪｯｸ")).Value = False
                End If

            Next

            ClassPostgeDB.Commit()
            ClassPostgeDB.DbClose()
            KenSaku()

        Catch ex As Exception
            ClassPostgeDB.Rollback()
            ClassPostgeDB.DbClose()
            MessageBox.Show(ex.Message)

        End Try


    End Sub



#End Region

End Class