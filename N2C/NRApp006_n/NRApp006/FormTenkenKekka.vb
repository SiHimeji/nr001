Public Class FormTenkenKekka
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim ZenkaiSQL As String = String.Empty
    Dim flg As Boolean = True
    Dim ro1a As Integer
    Dim ro1b As Integer
    Dim ro1c As Integer
    Dim ro1d As Integer

    Dim ro1as As String
    Dim ro1bs As String
    Dim ro1cs As String
    Dim ro1ds As String

    Dim hanei As Integer  '反映フラグ

    Dim rosyousai As Integer


    Dim Dts As DataTable  '不備内容マスタ製品
    Dim Dtr As DataTable  '不備内容マスタ結果
    Dim ColorDt As DataTable 'カラー
    Dim fubicolor As String '不備色（　　131　）
    Dim ColorDt2 As DataTable '点検項目カラー


    Dim rokrkka As Integer
    Dim tyuicoment As Integer
    Dim saihoumin As Integer
    Dim saihouminDay As Integer
    Dim seihinmeicol As Integer

    Dim datavFlag As Integer
    Dim kensakuFlg As Boolean = False



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

    Private Sub FormTenkenKekka_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String

        Me.Text &= "       Version [" & Ver & "]"

        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報

        Dim dtToday As DateTime = DateTime.Today
        Me.DateTimePicker期間1.Value = dtToday.AddDays(-1)        ' AddMonths(0 - Integer.Parse(GetSystemto("2", "3")))
        Me.DateTimePicker期間2.Value = dtToday.AddDays(-1)
        Me.TextBoxMSG.Text = ""

        GetSystemtoCombo("'90'", Me.ComboBox期間, "未チェック")
        Me.ComboBox期間.Items.Add("未更新")

        Me.ComboBox期間.SelectedIndex = 0
        Me.ToolStripStatusLabel件.Text = "     "

        Me.ToolStripStatusLabel5.Text = ""

        Me.TextBoxMSG.Visible = False

        GetSystemtoListBox("100", Me.ListBox機器分類名)
        GetSystemtoListBox("101", Me.ListBox点検製品区分詳細名)
        GetSystemtoListBox("102", Me.ListBox点検項目名)
        GetSystemtoListBox("103", Me.ListBox点検結果)


        Me.ComboBox含む.Items.Clear()
        Me.ComboBox含む.Items.Add("")
        Me.ComboBox含む.Items.Add("含まない")
        Me.ComboBox含む.Items.Add("含む")
        Me.ComboBox含む.SelectedIndex = 0

        Me.Button更新1.Visible = False
        Me.Button本日分結果決定.Visible = False
        Me.DataGridView1.DataSource = Nothing

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Me.ToolStripStatusLabel点検項目名.Text = ""

        Me.ToolStripComboBox条件.Items.Clear()
        Me.ToolStripComboBox条件.Items.Add("本日作業分含まない")
        Me.ToolStripComboBox条件.Items.Add("本日作業分含む")
        Me.ToolStripComboBox条件.SelectedIndex = 0

        strSQL = "Select  naiyou ,naiyou2,bikou From " & schema & "m_system  Where  kbn  ='170'" '点検　文字色
        ColorDt2 = ClassPostgeDB.SetTable(strSQL)

    End Sub
    Private Sub ComboBox期間_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox期間.SelectedIndexChanged

        If Me.ComboBox期間.Text = "未チェック" Then
            Me.DateTimePicker期間1.Visible = False
            Me.DateTimePicker期間2.Visible = False
            Me.Labelから.Visible = False

        ElseIf Me.ComboBox期間.Text = "未更新" Then
            Me.DateTimePicker期間1.Visible = False
            Me.DateTimePicker期間2.Visible = False
            Me.Labelから.Visible = False

        Else

            Me.DateTimePicker期間1.Visible = True
            Me.DateTimePicker期間2.Visible = True
            Me.Labelから.Visible = True

        End If
    End Sub
    Private Sub DataGridViewSet()
        Me.DataGridView1.DataSource = Nothing

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

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

#Region "検索"
    Private Sub 検索2()

        Dim strSQL As String = String.Empty
        Dim strSQL1 As String = String.Empty
        Dim dt As New DataTable
        'Dim ro As Integer

        flg = True
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        'Me.DataGridView1.DataSource = Nothing
        System.Windows.Forms.Application.DoEvents()
        Me.ToolStripStatusLabel件.Text = "     "

        DataGridViewSet()

        If Me.ComboBox期間.Text = "" Then flg = False
        If Me.ListBox機器分類名.SelectedIndex = -1 Then flg = False
        'If Me.ListBox点検製品区分詳細名.SelectedIndex = -1 Then flg = False
        If Me.ListBox点検項目名.SelectedIndex = -1 Then flg = False
        If Me.ListBox点検結果.SelectedIndex = -1 Then flg = False

        strSQL = SetSQL()
        strSQL &= 検索条件()

        If Me.CheckBox過去を含む.Checked Then
            'strSQL &= " union  ALL " & SetSQL()
            'strSQL &= 検索条件2()
        End If
        strSQL &= " order by 受付ＮＯ"

        ' strSQL = SetSQL()
        'strSQL &= 検索条件() & " order by 受付ＮＯ"



        If flg Then
            Me.TextBoxMSG.Visible = False

            Me.TextBoxMSG.Text = GetSystemMSG(Me.ListBox機器分類名.SelectedItem.ToString, Me.ListBox点検項目名.SelectedItem.ToString)
            If Me.TextBoxMSG.Text <> "" Then
                Me.TextBoxMSG.Visible = True
            End If


            dt = ClassPostgeDB.SetTable(strSQL)
            Get件数()
            Kekkadisp(dt)
        Else
            Me.DataGridView1.DataSource = Nothing
        End If

    End Sub


    Private Sub Kekkadisp(dt As DataTable)
        Dim ro As Integer
        DataGridViewSet()

        If dt.Rows.Count > 0 Then
            Me.ToolStripStatusLabel件.Text = dt.Rows.Count & "件"
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = dt


            seihinmeicol = -1   '製品名
            rosyousai = -1      '点検製品区分詳細名
            saihoumin = -1     '再訪問指示内容
            saihouminDay = -1 '再訪問指示日
            rokrkka = -1        '不備内容
            tyuicoment = -1     '注意事項コメント

            ro1a = -1       '点検結果
            ro1b = -1       '安全装置
            ro1c = -1       '安全装置
            ro1d = -1

            ro1as = ""
            ro1bs = ""
            ro1cs = ""
            ro1ds = ""


            ro = 0
            Dim CheckBoxColumn As New DataGridViewCheckBoxColumn()
            'データソースの"Column1"をバインドする
            CheckBoxColumn.DataPropertyName = "ﾁｪｯｸ"
            '名前とヘッダーを設定する
            CheckBoxColumn.Name = "Column1"
            CheckBoxColumn.HeaderText = "ﾁｪｯｸ"
            '列を追加する
            Me.DataGridView1.Columns.Add(CheckBoxColumn)
            Me.DataGridView1.Columns(ro).Width = 60
            ro = ro + 1

            ro = settextColumn(Me.DataGridView1, ro, "受付ＮＯ", "受付ＮＯ", 80, True)
            ro = settextColumn(Me.DataGridView1, ro, "製品名", "製品名", 120, True)
            seihinmeicol = ro - 1

            ro = settextColumn(Me.DataGridView1, ro, "機器分類名", "機器分類名", 80, True)
            ro = settextColumn(Me.DataGridView1, ro, "点検製品区分詳細名", "点検製品区分詳細名", 0, True)
            rosyousai = ro - 1

            Select Case Me.ListBox機器分類名.SelectedItem.ToString
                Case "ガス機器"
                    Select Case Me.ListBox点検項目名.SelectedItem.ToString
                        Case "法１２"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)

                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１２"
                            ro1a = ro - 1

                            If Chk結果("4") Then
                                ro = settextColumn(Me.DataGridView1, ro, "一酸化炭素濃度未測定理由", "一酸化炭素濃度未測定理由", 120, True)
                            End If


                        Case "法１７"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１７"
                            ro1a = ro - 1

                            ro = settextColumn(Me.DataGridView1, ro, "安全装置５有無", "安全装置５有無", 20, True)
                            ro1bs = "安全装置５"
                            ro1b = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置６有無", "安全装置６有無", 20, True)
                            ro1cs = "安全装置６"
                            ro1c = ro - 1

                        Case "法１８"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１８"
                            ro1a = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置５有無", "安全装置５有無", 20, True)
                            ro1bs = "安全装置５"
                            ro1b = ro - 1

                        Case Else
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = Me.ListBox点検項目名.SelectedItem.ToString
                            ro1a = ro - 1

                    End Select
                Case "石油機器"
                    Select Case Me.ListBox点検項目名.SelectedItem.ToString
                        Case "法１７"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１７"
                            ro1a = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置９有無", "安全装置９有無", 20, True)
                            ro1bs = "安全装置９"
                            ro1b = ro - 1

                        Case "法１８"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１８"
                            ro1a = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置１０有無", "安全装置１０有無", 20, True)
                            ro1bs = "安全装置１０"
                            ro1b = ro - 1
                        Case "自８"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)

                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = Me.ListBox点検項目名.SelectedItem.ToString
                            ro1a = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置１有無", "安全装置１有無", 20, True)

                            ro1bs = "安全装置１"
                            ro1b = ro - 1
                        Case Else
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = Me.ListBox点検項目名.SelectedItem.ToString
                            ro1a = ro - 1
                    End Select

                Case "ビルトイン式食器洗機"
                    ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                    ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                    ro1as = Me.ListBox点検項目名.SelectedItem.ToString
                    ro1a = ro - 1

                Case "ハイブリッド機器"
                    Select Case Me.ListBox点検項目名.SelectedItem.ToString
                        Case "法１２"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)

                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１２"
                            ro1a = ro - 1

                            If Chk結果("4") Then
                                ro = settextColumn(Me.DataGridView1, ro, "一酸化炭素濃度未測定理由", "一酸化炭素濃度未測定理由", 120, True)
                            End If


                        Case "法１７"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１７"
                            ro1a = ro - 1

                            ro = settextColumn(Me.DataGridView1, ro, "安全装置５有無", "安全装置５有無", 20, True)
                            ro1bs = "安全装置５"
                            ro1b = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置６有無", "安全装置６有無", 20, True)
                            ro1cs = "安全装置６"
                            ro1c = ro - 1

                        Case "法１８"
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = "法１８"
                            ro1a = ro - 1
                            ro = settextColumn(Me.DataGridView1, ro, "安全装置５有無", "安全装置５有無", 20, True)
                            ro1bs = "安全装置５"
                            ro1b = ro - 1

                        Case Else
                            ro = settextColumn(Me.DataGridView1, ro, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検項目名＿" & Me.ListBox点検項目名.SelectedItem.ToString, 40, True)
                            ro = settextColumn(Me.DataGridView1, ro, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, "点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString, 20, True)
                            ro1as = Me.ListBox点検項目名.SelectedItem.ToString
                            ro1a = ro - 1

                    End Select


            End Select

        End If

        ro = settextColumn(Me.DataGridView1, ro, "注意事項コメント", "注意事項コメント", 160, True)
        tyuicoment = ro - 1
        ro = settextColumn(Me.DataGridView1, ro, "不備内容", "不備内容", 160, True)
        rokrkka = ro - 1
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示内容", "再訪問指示内容", 100, True)
        saihoumin = ro - 1
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示日", "再訪問指示日", 100, "0000/00/00", True)
        saihouminDay = ro - 1

        ro = settextColumn(Me.DataGridView1, ro, "反映フラグ", "反映フラグ", 10, True)
        hanei = ro - 1

        Me.DataGridView1.AllowUserToAddRows = False

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Private Function SetSQL()
        Dim strSQL As String = String.Empty
        If flg Then

            strSQL = "select 'false' as ﾁｪｯｸ, v_tenken_kekka.""受付ＮＯ"" ,v_tenken_kekka.製品名 ,v_tenken_kekka.機器分類名  ,v_tenken_kekka.点検製品区分詳細名 "


            If Me.ListBox点検項目名.SelectedIndex = -1 Then
                flg = False
            Else
                Select Case Me.ListBox機器分類名.SelectedItem.ToString
                    Case "ガス機器"
                        Select Case Me.ListBox点検項目名.SelectedItem.ToString
                            Case "法１２"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１２,v_tenken_kekka.点検結果＿法１２, v_tenken_kekka.一酸化炭素濃度未測定理由  "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１２,'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント"
                            Case "法１７"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１７,v_tenken_kekka.点検結果＿法１７, v_tenken_kekka.安全装置５有無 , v_tenken_kekka.安全装置６有無 "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１７,'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "
                            Case "法１８"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１８,v_tenken_kekka.点検結果＿法１８,  v_tenken_kekka.安全装置５有無 "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１８,'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント"
                            Case Else
                                strSQL &= ",v_tenken_kekka.点検項目名＿" & ListBox点検項目名.SelectedItem.ToString & ",v_tenken_kekka.点検結果＿" & ListBox点検項目名.SelectedItem.ToString & " "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿" & ListBox点検項目名.SelectedItem.ToString & ",'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "



                        End Select
                    Case "石油機器"
                        Select Case Me.ListBox点検項目名.SelectedItem.ToString
                            Case "法１７"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１７,v_tenken_kekka.点検結果＿法１７, v_tenken_kekka.安全装置９有無 "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１７'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント"
                            Case "法１８"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１８,v_tenken_kekka.点検結果＿法１８, v_tenken_kekka.安全装置１０有無 "
                                'Case "自１", "自２", "自３", "自４", "自５", "自６", "自７"
                                '   strSQL &= ",v_tenken_kekka.点検項目名＿" & ListBox点検項目名.SelectedItem.ToString & ",v_tenken_kekka.点検結果＿" & ListBox点検項目名.SelectedItem.ToString & ", "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１８'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "
                            Case "自８"
                                strSQL &= ",v_tenken_kekka.点検項目名＿自８,v_tenken_kekka.点検結果＿自８, v_tenken_kekka.安全装置１有無 "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿自８'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "

                            Case Else
                                strSQL &= ",v_tenken_kekka.点検項目名＿" & ListBox点検項目名.SelectedItem.ToString & ",v_tenken_kekka.点検結果＿" & ListBox点検項目名.SelectedItem.ToString & " "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿" & ListBox点検項目名.SelectedItem.ToString & ",'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "
                        End Select

                    Case "ビルトイン式食器洗機"
                        strSQL &= ",v_tenken_kekka.点検項目名＿" & ListBox点検項目名.SelectedItem.ToString & ",v_tenken_kekka.点検結果＿" & ListBox点検項目名.SelectedItem.ToString & " "
                        strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿" & ListBox点検項目名.SelectedItem.ToString & ",'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "

                    Case "ハイブリッド機器"
                        Select Case Me.ListBox点検項目名.SelectedItem.ToString
                            Case "法１２"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１２,v_tenken_kekka.点検結果＿法１２, v_tenken_kekka.一酸化炭素濃度未測定理由  "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１２,'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント"
                            Case "法１７"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１７,v_tenken_kekka.点検結果＿法１７, v_tenken_kekka.安全装置５有無 , v_tenken_kekka.安全装置６有無 "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿１７,'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "
                            Case "法１８"
                                strSQL &= ",v_tenken_kekka.点検項目名＿法１８,v_tenken_kekka.点検結果＿法１８,  v_tenken_kekka.安全装置５有無 "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿法１８,'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "
                            Case Else
                                strSQL &= ",v_tenken_kekka.点検項目名＿" & ListBox点検項目名.SelectedItem.ToString & ",v_tenken_kekka.点検結果＿" & ListBox点検項目名.SelectedItem.ToString & " "
                                strSQL &= ",COALESCE(v_tenken_kekka.点検説明＿" & ListBox点検項目名.SelectedItem.ToString & ",'') ||  COALESCE(v_tenken_kekka.注意事項コメント,'') as 注意事項コメント "
                        End Select
                End Select

            End If

            'strSQL &= "v_tenken_kekka.注意事項コメント  ,t_tenken_fubi.不備内容 ,t_tenken_fubi.再訪問指示内容 ,to_char(t_tenken_fubi.再訪問指示日,'yyyy/mm/dd') 再訪問指示日"
            strSQL &= " ,t_tenken_fubi.不備内容 ,t_tenken_fubi.再訪問指示内容 ,to_char(t_tenken_fubi.再訪問指示日,'yyyy/mm/dd') 再訪問指示日"
            strSQL &= ", COALESCE(t_tenken_fubi.反映フラグ,' ')  反映フラグ"


            strSQL &= " ,t.点検製品区分詳細 , t.点検製品区分詳細名"

            strSQL &= " FROM " & schema & "v_tenken_kekka"
            strSQL &= " Left OUTER join  " & schema & "t_tenken_fubi on v_tenken_kekka.""受付ＮＯ""  = t_tenken_fubi.点検受付番号  "

            strSQL &= " And t_tenken_fubi.点検  = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'"
        End If

        Return strSQL

    End Function

    Private Function Set結果()
        Dim strSQL As String = String.Empty
        Dim cnt As Integer = 0

        If Me.CheckBox過去を含む.Checked = True Then

            strSQL &= " And ( 点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString & " "
        Else
            strSQL &= " And 点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString & " "

        End If


        strSQL &= " IN ("
        For Each idx In ListBox点検結果.SelectedIndices
            If cnt > 0 Then
                strSQL &= ","
            End If
            strSQL &= "'" & idx & "'"
            cnt = cnt + 1
        Next
        strSQL &= ")"

        If Me.CheckBox過去を含む.Checked = True Then

            strSQL &= "  OR  点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString & " = '')"

        End If






        Return strSQL
    End Function

    '
    '画面選択の結果でNoが選択されているか？
    '
    Private Function Chk結果(No As String) As Boolean

        For Each idx In ListBox点検結果.SelectedIndices
            If idx.ToString = No Then
                Return True
            End If
        Next
        Return False

    End Function


    Private Function 検索条件()
        Dim strSQL As String = String.Empty
        Dim hanmoji As String = String.Empty
        Dim zenmoji As String = String.Empty
        If flg Then
            If Me.ComboBox期間.Text = "未チェック" Then
                strSQL = " where v_tenken_kekka.endflag  = '0'"
            ElseIf Me.ComboBox期間.Text = "未更新" Then
                strSQL = " where v_tenken_kekka.endflag  = '0'"
            Else
                strSQL = " where  LEFT(" + Me.ComboBox期間.Text + ",10) BETWEEN '" + Me.DateTimePicker期間1.Value + "' AND '" + Me.DateTimePicker期間2.Value + "'"
                'strSQL &= " and  COALESCE(v_tenken_kekka.endflag ,'0') <> '1'"
                strSQL &= " and  v_tenken_kekka.endflag  = '0'"
            End If
            '2025/06/23
            strSQL &= " And 機器分類名  like'%" & Me.ListBox機器分類名.SelectedItem.ToString & "'"



            If Me.ListBox点検製品区分詳細名.SelectedIndex <> -1 Then
                strSQL &= " And 点検製品区分詳細名 = '" & Me.ListBox点検製品区分詳細名.SelectedItem.ToString & "'"
            End If
            strSQL &= Set結果()
            If Trim(Me.ComboBox含む.Text) <> "" Then
                If Me.ComboBox含む.Text = "含む" Then

                    zenmoji = Replace(StrConv(Me.ComboBox注意事項コメント.Text, VbStrConv.Wide), "＊", "%")
                    hanmoji = Replace(StrConv(Me.ComboBox注意事項コメント.Text, VbStrConv.Narrow), "*", "%")
                    strSQL &= " And   ( v_tenken_kekka.注意事項コメント  LIKE '%" & zenmoji & "%'"
                    strSQL &= " Or    v_tenken_kekka.注意事項コメント    LIKE '%" & hanmoji & "%' )"

                End If
                If Me.ComboBox含む.Text = "含まない" Then

                    zenmoji = Replace(StrConv(Me.ComboBox注意事項コメント.Text, VbStrConv.Wide), "＊", "%")
                    hanmoji = Replace(StrConv(Me.ComboBox注意事項コメント.Text, VbStrConv.Narrow), "*", "%")
                    strSQL &= " And  ( v_tenken_kekka.注意事項コメント NOT LIKE '%" & zenmoji & "%'"
                    strSQL &= " And    v_tenken_kekka.注意事項コメント NOT LIKE '%" & hanmoji & "%' )"

                End If
            End If
            If Me.CheckBox本日作業分を含む.Checked = False Then
                strSQL &= " And   受付ＮＯ  NOT IN  (SELECT 点検受付番号 FROM  " & schema & "t_tenken_fubi  WHERE 点検 = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'  and ( 反映フラグ = '0' or 反映フラグ = '1' ))   "
            Else
                strSQL &= " And   受付ＮＯ  NOT IN  (SELECT 点検受付番号 FROM  " & schema & "t_tenken_fubi  WHERE 点検 = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'  and ( 反映フラグ = '1' ))   "
            End If
        End If

        'strSQL &= " And   受付ＮＯ  Not IN  (SELECT  点検受付番号 FROM " & schema & "t_check  where チェック in ('1','2','3') )"
        ' strSQL &= "order by v_tenken_kekka.受付ＮＯ"


        Return strSQL

    End Function

    Private Function 検索条件2()
        Dim strSQL As String = String.Empty
        Dim hanmoji As String = String.Empty
        Dim zenmoji As String = String.Empty

        strSQL = " where  受付ＮＯ  IN (select tc.点検受付番号  from  " & schema & "t_check tc  where tc.チェック not in ('1','2','3') group by tc.点検受付番号)"
        strSQL &= " And 機器分類名 = '" & Me.ListBox機器分類名.SelectedItem.ToString & "'"
        strSQL &= Set結果()


        Return strSQL

    End Function




    Private Sub Get件数()
        Dim strSQL As String = String.Empty
        Dim dtm As New DataTable
        Dim msg As String = String.Empty
        Dim ro As Integer


        strSQL = "Select v_tenken_kekka.点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString & ", count(*)"
        strSQL &= " FROM " & schema & "v_tenken_kekka"
        If Me.ComboBox期間.Text = "未チェック" Then
            strSQL &= " where  v_tenken_kekka.endflag  = '0'"
        Else
            strSQL &= " where left(" + Me.ComboBox期間.Text + ",10) BETWEEN '" + Me.DateTimePicker期間1.Value + "' AND '" + Me.DateTimePicker期間2.Value + "'"
            strSQL &= " and  v_tenken_kekka.endflag  = '0'"
        End If

        strSQL &= " And 機器分類名 = '" & Me.ListBox機器分類名.SelectedItem.ToString & "'"

        If Me.ToolStripComboBox条件.Text = "本日作業分含まない" Then

            strSQL &= " And   受付ＮＯ  NOT IN  (SELECT 点検受付番号 FROM  " & schema & "t_tenken_fubi  WHERE 点検 = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'  and ( 反映フラグ = '0' or 反映フラグ = '1' ))   "
        Else
            strSQL &= " And   受付ＮＯ  NOT IN  (SELECT 点検受付番号 FROM  " & schema & "t_tenken_fubi  WHERE 点検 = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'  and ( 反映フラグ = '1' ))   "

        End If
        'strSQL &= " And   受付ＮＯ  Not IN  (SELECT  点検受付番号 FROM tenken.t_check  where チェック in ('1','2','3') )"
        strSQL &= " Group By  v_tenken_kekka.点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString & ""
        strSQL &= " order by v_tenken_kekka.点検結果＿" & Me.ListBox点検項目名.SelectedItem.ToString
        dtm = ClassPostgeDB.SetTable(strSQL)

        msg = Me.ListBox点検項目名.SelectedItem.ToString & "  "

        If dtm.Rows.Count > 0 Then
            For ro = 0 To dtm.Rows.Count - 1
                If dtm.Rows(ro).Item(0).ToString = "" Then
                    msg &= "▲" & ":"
                Else
                    msg &= dtm.Rows(ro).Item(0).ToString & ":"
                End If

                msg &= dtm.Rows(ro).Item(1).ToString & "件  "
            Next
        End If
        Me.ToolStripStatusLabel5.Text = msg
    End Sub

#End Region

#Region "チェック"
    Private Sub Get不備内容マスタ()
        Dim strSQL As String
        strSQL = "select coalesce(naiyou2,'') naiyou2,coalesce(atai,'') atai ,coalesce(naiyou3,'') naiyou3,coalesce(atai3,'') atai3,coalesce(naiyou4,'') naiyou4,coalesce(atai4,'') atai4,coalesce(jouken,'') jouken,coalesce(jouken2,'') jouken2, coalesce(bikou,'')  bikou FROM " & schema & "m_system  where  kbn ='150'"
        strSQL = strSQL & " and naiyou = '" & Me.ListBox機器分類名.SelectedItem.ToString & "'"
        strSQL = strSQL & " and naiyou2 = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'"

        Dts = ClassPostgeDB.SetTable(strSQL)

        strSQL = "select coalesce(naiyou2,'') naiyou2,coalesce(atai,'') atai ,coalesce(naiyou3,'') naiyou3,coalesce(atai3,'') atai3,coalesce(naiyou4,'') naiyou4,coalesce(atai4,'') atai4,coalesce(jouken,'') jouken,coalesce(jouken2,'') jouken2, coalesce(bikou,'')  bikou FROM " & schema & "m_system  where  kbn ='160'"
        strSQL = strSQL & " and naiyou = '" & Me.ListBox機器分類名.SelectedItem.ToString & "'"
        strSQL = strSQL & " and naiyou2 = '" & Me.ListBox点検項目名.SelectedItem.ToString & "'"
        strSQL = strSQL & "order by jun"

        Dtr = ClassPostgeDB.SetTable(strSQL)

        strSQL = "Select  naiyou ,naiyou2 From " & schema & "m_system  Where  kbn  ='130'"
        ColorDt = ClassPostgeDB.SetTable(strSQL)

        strSQL = "Select  naiyou  From " & schema & "m_system  Where  kbn  ='131' and  seq ='1'"

        fubicolor = ClassPostgeDB.DbSel(strSQL)

    End Sub
    Private Sub ChkData()

        Dim ro As Integer
        If flg Then
            Get不備内容マスタ()
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Rows(ro).Cells(hanei).Value.ToString = "0" Then
                    Me.DataGridView1.Rows(ro).Cells(1).Style.BackColor = ColorTranslator.FromHtml(fubicolor)

                    If Me.DataGridView1.Rows(ro).Cells(ro1a).Value = "0" Or Me.DataGridView1.Rows(ro).Cells(ro1a).Value = "5" Then
                        Me.DataGridView1.Rows(ro).Cells(0).Value = True
                    End If

                    If Me.DataGridView1.Rows(ro).Cells(rokrkka).Value.ToString.Trim <> "" Then


                    Else
                        RowsChk(ro)
                        ChkFubinaiyou(ro)
                        ChgBackColor(ro)

                    End If
                Else
                    RowsChk(ro)
                    ChkFubinaiyou(ro)
                    ChgBackColor(ro)
                End If
            Next
        End If

    End Sub
    Private Sub DataGridView1_Sorted(sender As Object, e As EventArgs) Handles DataGridView1.Sorted
        ChkData()
    End Sub

    'チェック
    '製品名からチェック　システムマスタ 160
    '               
    '             seihinmeicol = -1   '製品名
    '            rosyousai = -1      '点検製品区分詳細名
    '            saihoumin = -1     '再訪問指示内容
    '            saihouminDay = -1 '再訪問指示日
    '            rokrkka = -1        '不備内容
    '            tyuicoment = -1     '注意事項コメント
    '
    '             ro1a = -1       '点検結果
    '             ro1b = -1       '安全装置
    '             ro1c = -1       '安全装置
    '  Dts
    '      colom 0 　点検名
    '               1   点検結果
    '               2　 安全装置１
    '               3　 安全装置１結果
    '               4　 安全装置２
    '               5　 安全装置２結果
    '               6　 点検製品区分詳細名
    '               7　 製品条件
    '               8   不備内容
    '
    Private Sub RowsChk(ro As Integer)
        Dim x As Integer

        Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = ""
        'If Me.DataGridView1.Rows(ro).Cells(rokrkka).Value.ToString <> "" Then
        'Return
        'End If
        'チェックを入れる
        If Me.DataGridView1.Rows(ro).Cells(ro1a).Value = "0" Or Me.DataGridView1.Rows(ro).Cells(ro1a).Value = "5" Then
            Me.DataGridView1.Rows(ro).Cells(0).Value = True
        End If

        For x = 0 To Dtr.Rows.Count - 1
            RowsChk2(ro, x)
        Next
    End Sub
    Private Sub RowsChk2(ro As Integer, x As Integer)

        '結果3
        '
        If ro1a <> -1 And ro1b <> -1 And ro1c <> -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
                Me.DataGridView1.Rows(ro).Cells(ro1b).Value.ToString = Dtr.Rows(x).Item(3).ToString And ro1bs = Dtr.Rows(x).Item(2).ToString And Dtr.Rows(x).Item(3).ToString <> "" And
                    Me.DataGridView1.Rows(ro).Cells(ro1c).Value.ToString = Dtr.Rows(x).Item(5).ToString And ro1cs = Dtr.Rows(x).Item(4).ToString And Dtr.Rows(x).Item(5).ToString <> "" Then
                RowsChk3(ro, x)
            End If
        End If

        If ro1a <> -1 And ro1b <> -1 And ro1c <> -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
                Dtr.Rows(x).Item(3).ToString = "" And
                    Me.DataGridView1.Rows(ro).Cells(ro1c).Value.ToString = Dtr.Rows(x).Item(5).ToString And ro1cs = Dtr.Rows(x).Item(4).ToString And Dtr.Rows(x).Item(5).ToString <> "" Then
                RowsChk3(ro, x)
            End If
        End If

        If ro1a <> -1 And ro1b <> -1 And ro1c <> -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
                Me.DataGridView1.Rows(ro).Cells(ro1b).Value.ToString = Dtr.Rows(x).Item(3).ToString And ro1bs = Dtr.Rows(x).Item(2).ToString And Dtr.Rows(x).Item(3).ToString <> "" And
                    Dtr.Rows(x).Item(5).ToString = "" Then
                RowsChk3(ro, x)
            End If
        End If

        If ro1a <> -1 And ro1b <> -1 And ro1c <> -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
                Me.DataGridView1.Rows(ro).Cells(ro1b).Value.ToString = Dtr.Rows(x).Item(3).ToString And ro1bs = Dtr.Rows(x).Item(2).ToString And Dtr.Rows(x).Item(3).ToString <> "" And
                     Dtr.Rows(x).Item(5).ToString = "" Then
                RowsChk3(ro, x)
            End If
        End If


        '結果２
        If ro1a <> -1 And ro1b <> -1 And ro1c = -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
                Me.DataGridView1.Rows(ro).Cells(ro1b).Value.ToString = Dtr.Rows(x).Item(3).ToString And ro1bs = Dtr.Rows(x).Item(2).ToString And Dtr.Rows(x).Item(3).ToString <> "" And
                    Dtr.Rows(x).Item(5).ToString = "" Then
                RowsChk3(ro, x)
            End If
        End If

        If ro1a <> -1 And ro1b <> -1 And ro1c = -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
                    Dtr.Rows(x).Item(3).ToString = "" And Dtr.Rows(x).Item(5).ToString = "" Then
                RowsChk3(ro, x)
            End If
        End If


        If ro1a <> -1 And ro1b = -1 And ro1c = -1 Then
            If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dtr.Rows(x).Item(1).ToString And ro1as = Dtr.Rows(x).Item(0).ToString And Dtr.Rows(x).Item(1).ToString <> "" And
            Dtr.Rows(x).Item(3).ToString = "" And Dtr.Rows(x).Item(5).ToString = "" Then
                RowsChk3(ro, x)
            End If
        End If

    End Sub

    Private Sub RowsChk3(ro As Integer, x As Integer)
        If Dtr.Rows(x).Item(6).ToString <> "" And Dtr.Rows(x).Item(7).ToString <> "" Then  '点検製品区分詳細名 設定あり
            If Dtr.Rows(x).Item(7).ToString = "以外" Then
                If Dtr.Rows(x).Item(6).ToString <> Me.DataGridView1.Rows(ro).Cells(rosyousai).Value.ToString Then  '
                    Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dtr.Rows(x).Item(8).ToString
                End If
            Else
                If Dtr.Rows(x).Item(6).ToString = Me.DataGridView1.Rows(ro).Cells(rosyousai).Value.ToString Then  '
                    Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dtr.Rows(x).Item(8).ToString
                End If
            End If
        Else
            Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dtr.Rows(x).Item(8).ToString
        End If

    End Sub



    Private Sub ChgBackColor(ro As Integer)
        Dim co As Integer
        Dim x As Integer

        For x = 0 To ColorDt.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(4).Value = ColorDt.Rows(x).Item(1).ToString Then
                For co = 0 To Me.DataGridView1.ColumnCount - 1
                    DataGridView1.Rows(ro).Cells(co).Style.BackColor = ColorTranslator.FromHtml(ColorDt.Rows(x).Item(0).ToString)
                Next
            End If
        Next
    End Sub
    '================================================
    '製品名からチェック　システムマスタ 150
    '               
    '             seihinmeicol = -1   '製品名
    '            rosyousai = -1      '点検製品区分詳細名
    '            saihoumin = -1     '再訪問指示内容
    '            saihouminDay = -1 '再訪問指示日
    '            rokrkka = -1        '不備内容
    '            tyuicoment = -1     '注意事項コメント
    '
    '             ro1a = -1       '点検結果
    '             ro1b = -1       '安全装置
    '             ro1c = -1       '安全装置
    '  Dts
    '      colom 0 　点検名
    '               1   点検結果
    '               2　 安全装置１
    '               3　 安全装置１結果
    '               4　 安全装置２
    '               5　 安全装置２結果
    '               6　 製品名
    '               7　 製品条件（未使用）
    '               8   不備内容
    '
    Private Sub ChkFubinaiyou(ro As Integer)
        Dim x As Integer

        For x = 0 To Dts.Rows.Count - 1
            '製品
            If Chk製品名(StrConv(Me.DataGridView1.Rows(ro).Cells(seihinmeicol).Value, vbNarrow), StrConv(Dts.Rows(x).Item(6).ToString, vbNarrow)) Then
                '結果
                If Me.DataGridView1.Rows(ro).Cells(ro1a).Value.ToString = Dts.Rows(x).Item(1).ToString And ro1as = Dts.Rows(x).Item(0).ToString Then

                    If ro1bs = Dts.Rows(x).Item(2).ToString And ro1bs <> "" Then
                        If Me.DataGridView1.Rows(ro).Cells(ro1b).Value.ToString = Dts.Rows(x).Item(3).ToString Then
                            Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dts.Rows(x).Item(8).ToString

                        End If
                    End If
                    If ro1bs = Dts.Rows(x).Item(4).ToString And ro1bs <> "" Then
                        If Me.DataGridView1.Rows(ro).Cells(ro1b).Value.ToString = Dts.Rows(x).Item(5).ToString Then
                            Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dts.Rows(x).Item(8).ToString


                        End If
                    End If

                    If ro1cs = Dts.Rows(x).Item(2).ToString And ro1cs <> "" Then
                        If Me.DataGridView1.Rows(ro).Cells(ro1c).Value.ToString = Dts.Rows(x).Item(3).ToString Then
                            Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dts.Rows(x).Item(8).ToString


                        End If
                    End If
                    If ro1cs = Dts.Rows(x).Item(4).ToString And ro1cs <> "" Then
                        If Me.DataGridView1.Rows(ro).Cells(ro1c).Value.ToString = Dts.Rows(x).Item(5).ToString Then
                            Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dts.Rows(x).Item(8).ToString

                        End If
                    End If
                    '結果だけで判断
                    If Dts.Rows(x).Item(2).ToString = "" And Dts.Rows(x).Item(4).ToString = "" Then
                        Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Dts.Rows(x).Item(8).ToString
                    End If
                End If
            End If
        Next

    End Sub


    Private Function Chk製品名(dat As String, mst As String) As Boolean
        Chk製品名 = False
        Chk製品名 = dat Like mst

    End Function


    Private Sub 検索Main()
        If Me.ListBox点検項目名.SelectedIndex = -1 Then
            Return
        End If
        If Me.ListBox機器分類名.SelectedIndex = -1 Then
            Return
        End If
        If Me.ListBox点検結果.SelectedIndex = -1 Then
            Return
        End If



        Me.TextBoxRow.Text = ""
        datavFlag = 1
        検索2()
        Me.ToolStripStatusLabel条件.Text = Me.ToolStripComboBox条件.Text

        ChkData()

        Me.DataGridView1.Columns(rokrkka).SortMode = DataGridViewColumnSortMode.NotSortable 'ソート無効

        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Button更新1.Visible = True
        Else
            Me.Button更新1.Visible = False
        End If

        Me.Button本日分結果決定.Visible = False
        Me.TextBox確認完了日.Visible = False
        Me.Label確認完了日.Visible = False
        Me.DateTimePicker確認完了日.Visible = False
        Me.TextBox不備内容.Text = ""
        Me.TextBox再訪問指示内容.Text = ""

    End Sub


    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click

        If kensakuFlg Then
            Dim result As DialogResult = MessageBox.Show("検索しても良いですか？", "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2)
            If result <> DialogResult.OK Then
                Return
            End If
        End If
        検索Main()
        kensakuFlg = False
    End Sub


#End Region
#Region "DataGridViewクリック"

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Dim ro As Integer
        Dim co As Integer


        Dim dgvScreenLocation As Point = Me.DataGridView1.PointToScreen(DataGridView1.Location)
        Dim tempX As Integer = DataGridView.MousePosition.X - dgvScreenLocation.X + DataGridView1.Left
        Dim tempY As Integer = DataGridView.MousePosition.Y - dgvScreenLocation.Y + DataGridView1.Top
        Dim hit As DataGridView.HitTestInfo = Me.DataGridView1.HitTest(tempX, tempY)

        co = hit.ColumnIndex
        ro = hit.RowIndex


        If e.Button = MouseButtons.Left Then
            Select Case datavFlag
                Case 1
                    co = Me.DataGridView1.CurrentCell.ColumnIndex
                    If co = 1 Then
                        UketukeNo = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString

                        FormTenkenMeisai.UserID = UserID
                        FormTenkenMeisai.Kengen = Kengen
                        FormTenkenMeisai.UserName = UserName
                        FormTenkenMeisai.ShowDialog()
                    End If

                    'End If
                    'If e.Button = MouseButtons.Right Then
                    'co = Me.DataGridView1.CurrentCell.ColumnIndex

                    If co = rokrkka Then
                        Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position

                        点検項目名 = Me.ListBox点検項目名.SelectedItem.ToString
                        FormTenkenComment.Left = sp.X - 250
                        FormTenkenComment.Top = sp.Y
                        FormTenkenComment.StartPosition = FormStartPosition.Manual
                        FormTenkenComment.ShowDialog()


                        For ro = 0 To Me.DataGridView1.Rows.Count - 1
                            If Me.DataGridView1.Rows(ro).Cells(rokrkka).Selected Then
                                Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Coment
                                Me.DataGridView1.Rows(ro).Cells(0).Value = True

                            End If
                        Next
                    End If

                    If co = saihoumin Then
                        Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position

                        点検項目名 = Me.ListBox点検項目名.SelectedItem.ToString
                        FormTenkenComment.Left = sp.X - 250
                        FormTenkenComment.Top = sp.Y
                        FormTenkenComment.StartPosition = FormStartPosition.Manual
                        FormTenkenComment.ShowDialog()

                        For ro = 0 To Me.DataGridView1.Rows.Count - 1
                            If Me.DataGridView1.Rows(ro).Cells(saihoumin).Selected Then
                                Me.DataGridView1.Rows(ro).Cells(saihoumin).Value = Coment
                                Me.DataGridView1.Rows(ro).Cells(0).Value = True
                            End If
                        Next
                    End If

                Case 2
                    If ro >= 0 Then



                    End If

            End Select

        End If
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro As Integer
        Dim co As Integer

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            co = Me.DataGridView1.CurrentCell.ColumnIndex

            Select Case datavFlag
                Case 1
                    Me.TextBoxRow.Text = ""
                    If ro >= 0 Then
                        kensakuFlg = True

                        Me.TextBoxRow.Text = ro

                        Me.TextBox受付番号.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
                        Me.TextBox製品名.Text = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
                        Me.TextBox機器分類.Text = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString
                        Me.TextBox点検製品区分詳細名.Text = Me.DataGridView1.Rows(ro).Cells(4).Value.ToString

                        Me.TextBox注意事項コメント1.Text = Me.DataGridView1.Rows(ro).Cells(tyuicoment).Value.ToString
                        Me.TextBox不備内容.Text = Me.DataGridView1.Rows(ro).Cells(rokrkka).Value.ToString
                        Me.TextBox再訪問指示内容.Text = Me.DataGridView1.Rows(ro).Cells(saihoumin).Value.ToString

                        If Me.DataGridView1.Rows(ro).Cells(saihouminDay).Value Is Nothing Then
                            Me.TextBox再訪問指示日.Text = ""
                        Else
                            Me.TextBox再訪問指示日.Text = Me.DataGridView1.Rows(ro).Cells(saihouminDay).Value.ToString
                        End If

                    End If
                Case 2
                    If ro >= 0 Then

                        Me.TextBoxRow.Text = ro
                        Me.TextBox受付番号.Text = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString
                        Me.TextBox不備内容.Text = Me.DataGridView1.Rows(ro).Cells(4).Value.ToString
                        Me.TextBox再訪問指示内容.Text = Me.DataGridView1.Rows(ro).Cells(6).Value.ToString
                        Me.TextBox再訪問指示日.Text = Me.DataGridView1.Rows(ro).Cells(5).Value.ToString
                        Me.TextBox確認完了日.Text = Me.DataGridView1.Rows(ro).Cells(7).Value.ToString
                    End If

            End Select

        End If

    End Sub
#End Region

    Private Sub ButtonCLEAR_Click(sender As Object, e As EventArgs) Handles ButtonCLEAR.Click
        Me.ListBox点検製品区分詳細名.SelectedIndex = -1
    End Sub


    Private Sub 全ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全ONToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = True
        Next

    End Sub

    Private Sub 全OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全OFFToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = False
        Next

    End Sub

    Private Sub 反転ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転ToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
        Next
    End Sub
#Region "更新"

    Private Sub Button更新1_Click(sender As Object, e As EventArgs) Handles Label確認完了日.Click, Button更新1.Click
        Dim ro As Integer
        Dim strSQL As String
        Dim ret As String
        Dim Ken As Integer = 0

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count
        Me.ToolStripProgressBar1.Minimum = 0
        Me.ToolStripProgressBar1.Step = 1

        Ken = 0
        ClassPostgeDB.DbOpen()
        ClassPostgeDB.BeginTrans()

        Try
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.ToolStripProgressBar1.PerformStep()

                ret = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString

                If ret = "" Then
                    ret = "0"
                End If

                If ret Then

                    strSQL = "DELETE FROM " & schema & "t_tenken_fubi WHERE 点検受付番号='" & Me.DataGridView1.Rows(ro).Cells(1).Value & "'"
                    strSQL &= " AND 点検 = '" & Me.ListBox点検項目名.SelectedItem.ToString() & "'"
                    ClassPostgeDB.EXEC_tr(strSQL)

                    strSQL = "INSERT INTO " & schema & "t_tenken_fubi (点検受付番号, 点検, 不備内容, 再訪問指示内容, 再訪問指示日, 確認完了日, 作成日, 更新日, 更新者, 反映フラグ) VALUES("
                    strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(1).Value.ToString & "'"
                    strSQL &= ",'" & Me.ListBox点検項目名.SelectedItem.ToString() & "'"
                    strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(rokrkka).Value.ToString & "'"

                    strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(saihoumin).Value.ToString & "'"


                    If Me.DataGridView1.Rows(ro).Cells(saihoumin).Value.ToString = "" Then
                        strSQL &= ",null"
                    Else
                        If Me.DataGridView1.Rows(ro).Cells(saihouminDay).Value.ToString = "" Then
                            strSQL &= ",now() "
                        Else
                            strSQL &= ",'" & DataGridView1.Rows(ro).Cells(saihouminDay).Value.ToString & "'"
                        End If
                    End If
                    strSQL &= ",null"
                    strSQL &= ",now()"
                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",0)"

                    ClassPostgeDB.EXEC_tr(strSQL)
                    Ken = Ken + 1

                End If

            Next

            ClassPostgeDB.Commit()
            ClassPostgeDB.DbClose()
            検索Main()

        Catch ex As Exception
            ClassPostgeDB.Rollback()
            ClassPostgeDB.DbClose()
            MessageBox.Show(ex.Message)
        Finally

            Me.ToolStripProgressBar1.Value = 0
            kensakuFlg = False
            MsgBox(Ken.ToString() & "件　更新しました")
        End Try
    End Sub
#End Region

#Region "本日分結果決定"
    '
    '
    Private Sub Button本日分結果決定_Click(sender As Object, e As EventArgs) Handles Button本日分結果決定.Click

        Dim ro As Integer
        Dim strSQL As String
        Dim ret As String

        Me.ToolStripProgressBar1.Maximum = Me.DataGridView1.Rows.Count
        Me.ToolStripProgressBar1.Minimum = 0
        Me.ToolStripProgressBar1.Step = 1

        Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        ClassPostgeDB.DbOpen()
        ClassPostgeDB.BeginTrans()

        Try
            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                Me.ToolStripProgressBar1.PerformStep()

                strSQL = "update " & schema & "v_tenken_kekka set endflag ='1' where ""受付ＮＯ"" ='" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                ClassPostgeDB.EXEC_tr(strSQL)

                strSQL = "update  " & schema & "t_tenken_fubi set 反映フラグ ='1' where 点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                ClassPostgeDB.EXEC_tr(strSQL)


                strSQL = "DELETE FROM  " & schema & "t_check  WHERE  点検受付番号 = '" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                ClassPostgeDB.EXEC_tr(strSQL)


                strSQL = "INSERT INTO " & schema & "t_check (点検受付番号, チェック, 確認完了日, 更新者, 更新日,不備内容,再訪問指示内容,再訪問指示日,チェック日) VALUES("
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(8).Value & "'"

                If Me.DataGridView1.Rows(ro).Cells(7).Value.ToString <> "" Then
                    strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(7).Value & "'"
                Else
                    strSQL &= ",null"
                End If

                strSQL &= ",'" & UserName & "'"
                strSQL &= ",now()"
                strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(4).Value & "'"
                strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(6).Value & "'"
                If Me.DataGridView1.Rows(ro).Cells(5).Value.ToString <> "" Then
                    strSQL &= ",'" & Me.DataGridView1.Rows(ro).Cells(5).Value & "'"
                Else
                    strSQL &= ",null"
                End If
                strSQL &= ",now()"

                strSQL &= ")"

                ClassPostgeDB.EXEC_tr(strSQL)

            Next

            ClassPostgeDB.Commit()
            ClassPostgeDB.DbClose()


            For ro = 0 To Me.DataGridView1.Rows.Count - 1
                '再訪問時の処理
                If Me.DataGridView1.Rows(ro).Cells(8).Value = "3" Then
                    strSQL = "select   count(*)  from " & schema & "t_teisei  "
                    strSQL &= " where  点検受付番号 = '" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                    ret = ClassPostgeDB.DbSel(strSQL)
                    If ret = "0" Then
                        strSQL = "insert into " & schema & "t_teisei(点検受付番号,作成日, 更新日, 更新者, 出庫 )VALUES( "
                        strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                        strSQL &= ", now()"
                        strSQL &= ", now()"
                        strSQL &= ",  '" & UserName & "'"
                        strSQL &= ",'1'"
                        strSQL &= ")"
                    Else
                        strSQL = "update " & schema & "t_teisei  set  出庫 ='1' , 更新日 = now() , 更新者 = '" & UserName & "'"
                        strSQL &= " where  点検受付番号 = '" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
                    End If
                    ClassPostgeDB.EXEC(strSQL)
                End If
            Next




            'strSQL = "update " & schema & "v_tenken_kekka set endflag ='1' where ""受付ＮＯ"" ='" & Me.DataGridView1.Rows(ro).Cells(3).Value & "'"
            'ClassPostgeDB.EXEC(strSQL)


            本日分検索()

        Catch ex As Exception
            ClassPostgeDB.Rollback()
            MessageBox.Show(ex.Message)
            ClassPostgeDB.DbClose()

        Finally
            Me.Button本日分結果決定.Visible = False
            Me.ToolStripProgressBar1.Value = 0
            MsgBox("更新しました")
        End Try

    End Sub
#End Region
#Region "本日分検索"

    Private Sub 本日分検索()
        Dim strSQL As String = String.Empty
        Dim dtSrc As DataTable
        'Dim dt As DataTable
        Dim ro As Integer
        Dim No1 As Integer = 0
        Dim No2 As Integer = 0
        Dim No3 As Integer = 0


        Me.Button本日分結果決定.Visible = True

        Me.TextBox確認完了日.Visible = True
        Me.Label確認完了日.Visible = True
        Me.DateTimePicker確認完了日.Visible = True

        datavFlag = 2

        strSQL &= "select "
        strSQL &= " a.商圏 "
        strSQL &= ",a.店名略称 "
        strSQL &= ",a.サービスマン名 "
        strSQL &= ",b.点検受付番号 "
        strSQL &= ",COALESCE(b.不備内容,' ') 不備内容"
        strSQL &= ",to_char(b.再訪問指示日,'yyyy/mm/dd')  再訪問指示日"
        strSQL &= ",COALESCE(b.再訪問指示内容,'')  再訪問指示内容"
        strSQL &= ",to_char(b.確認完了日,'yyyy/mm/dd') 確認完了日 "
        strSQL &= " from " & schema & "v_tenken_kekka a ," & schema & "t_tenken_fubi b"
        strSQL &= " where a.受付ＮＯ  = b.点検受付番号 "
        strSQL &= " and b.反映フラグ ='0'"
        strSQL &= " order by b.点検受付番号"

        dtSrc = ClassPostgeDB.SetTable(strSQL)
        Me.ToolStripStatusLabel件.Text = dtSrc.Rows.Count & "件"

        DataGridViewSet()
        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "商圏", "支店", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "店名略称", "ｻｰﾋﾞｽｼｮｯﾌﾟ", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "サービスマン名", "ｻｰﾋﾞｽﾏﾝ", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "受付番号", "受付番号", 80, True)
        ro = settextColumn(Me.DataGridView1, ro, "不備内容", "不備内容", 200, False)
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示日", "再訪問指示日", 100, "0000/00/00", False)
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示内容", "再訪問指示内容", 100, False)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 100, "0000/00/00", False)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 40, False)

        ro = 0
        For Each data1 As DataRow In dtSrc.Rows
            If ro > 0 Then
                If Me.DataGridView1.Rows(ro - 1).Cells(3).Value.ToString.Trim = data1("点検受付番号").ToString.Trim Then

                    Me.DataGridView1.Rows(ro - 1).Cells(4).Value = Me.DataGridView1.Rows(ro - 1).Cells(4).Value.ToString & "" & data1("不備内容").ToString.Trim

                    If Me.DataGridView1.Rows(ro - 1).Cells(5).Value.ToString.Trim = "" Then
                        Me.DataGridView1.Rows(ro - 1).Cells(5).Value = data1("再訪問指示日").ToString.Trim
                        Me.DataGridView1.Rows(ro - 1).Cells(6).Value = data1("再訪問指示内容").ToString.Trim


                    End If

                Else
                    Me.DataGridView1.Rows.Add(data1("商圏").ToString, data1("店名略称").ToString, data1("サービスマン名").ToString, data1("点検受付番号").ToString, data1("不備内容").ToString.Trim _
                , data1("再訪問指示日").ToString, data1("再訪問指示内容").ToString, data1("確認完了日").ToString)
                    ro = ro + 1
                End If
            Else
                Me.DataGridView1.Rows.Add(data1("商圏").ToString, data1("店名略称").ToString, data1("サービスマン名").ToString, data1("点検受付番号").ToString, data1("不備内容").ToString.Trim _
                , data1("再訪問指示日").ToString, data1("再訪問指示内容").ToString, data1("確認完了日").ToString)
                ro = ro + 1
            End If
        Next
        Me.DataGridView1.AllowUserToAddRows = False

        '
        'チェックの追加
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Select Case Check(ro)
                Case "1"
                    No1 = No1 + 1
                Case "2"
                    No2 = No2 + 1
                Case "3"
                    No3 = No3 + 1
            End Select
        Next
        Me.ToolStripStatusLabel条件.Text = ""
        Me.ToolStripStatusLabel件.Text = DataGridView1.Rows.Count & "件"
        Me.ToolStripStatusLabel5.Text = "１＝" & No1.ToString() & "件　２＝" & No2.ToString() & "件　３＝" & No3.ToString() & "件"

        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Button本日分結果決定.Visible = True
        Else
            Me.Button本日分結果決定.Visible = False
        End If

    End Sub
    Private Function Check(ro As Integer)
        If Me.DataGridView1.Rows(ro).Cells(5).Value.ToString.Trim <> "" Then
            Me.DataGridView1.Rows(ro).Cells(8).Value = "3"
        Else
            If Me.DataGridView1.Rows(ro).Cells(4).Value.ToString.Trim <> "" Then
                Me.DataGridView1.Rows(ro).Cells(8).Value = "2"
            Else
                Me.DataGridView1.Rows(ro).Cells(8).Value = "1"
            End If
        End If
        Return Me.DataGridView1.Rows(ro).Cells(8).Value
    End Function
    Private Sub Button本日作業分呼出_Click(sender As Object, e As EventArgs) Handles Button本日作業分呼出.Click
        本日分検索()
        Me.TextBoxRow.Text = ""
        Me.Button更新1.Visible = False
        flg = False

    End Sub
#End Region

#Region "カレンダー"

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Me.TextBox再訪問指示日.Text = Me.DateTimePicker1.Value

    End Sub

    Private Sub DateTimePicker確認完了日_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker確認完了日.ValueChanged
        Me.TextBox確認完了日.Text = Me.DateTimePicker確認完了日.Value
    End Sub
#End Region

    Private Sub TextBox不備内容_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox不備内容.MouseDoubleClick
        Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position

        If e.Button = MouseButtons.Left And Me.ListBox点検項目名.SelectedIndex <> -1 Then

            点検項目名 = Me.ListBox点検項目名.SelectedItem.ToString
            FormTenkenComment.Left = sp.X - 250
            FormTenkenComment.Top = sp.Y
            FormTenkenComment.StartPosition = FormStartPosition.Manual
            FormTenkenComment.ShowDialog()

            Me.TextBox不備内容.Text &= Coment
            Me.TextBox不備内容.Select(Me.TextBox不備内容.Text.Length, 0)
        End If

    End Sub

    Private Sub TextBox再訪問指示内容_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox再訪問指示内容.MouseDoubleClick
        Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position
        If e.Button = MouseButtons.Left And Me.ListBox点検項目名.SelectedIndex <> -1 Then

            点検項目名 = Me.ListBox点検項目名.SelectedItem.ToString

            FormTenkenComment.Left = sp.X - 250
            FormTenkenComment.Top = sp.Y
            FormTenkenComment.StartPosition = FormStartPosition.Manual
            FormTenkenComment.ShowDialog()
            Me.TextBox再訪問指示内容.Text &= Coment
            Me.TextBox再訪問指示内容.Select(Me.TextBox再訪問指示内容.Text.Length, 0)
        End If

    End Sub

    Private Sub ListBox点検項目名_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox点検項目名.SelectedIndexChanged
        Dim strSQL As String
        Me.ToolStripStatusLabel点検項目名.Text = ""

        Try
            If Me.ListBox点検項目名.SelectedItem.ToString <> "" And Me.ListBox機器分類名.SelectedItem.ToString <> "" Then

                点検項目名 = Me.ListBox点検項目名.SelectedItem.ToString
                strSQL = "select t.点検項目名＿" & 点検項目名 & " from  " & schema & "v_tenken_kekka t where  t.機器分類名 ='" & Me.ListBox機器分類名.SelectedItem.ToString & "'  and  t.点検項目名＿" & 点検項目名 & " <> ''   LIMIT 1"

                Me.ToolStripStatusLabel点検項目名.Text = ClassPostgeDB.DbSel(strSQL)


                strSQL = "select naiyou2  from " & schema & "m_system  where kbn ='110' and bikou = '" & Me.ListBox点検項目名.SelectedItem.ToString & "' order by seq "
                ClassPostgeDB.SetComboBox(Me.ComboBox注意事項コメント, strSQL)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button反映_Click(sender As Object, e As EventArgs) Handles Button反映.Click

        '注意コメント
        '不備内容
        '再訪問指示内容
        Dim ro As Integer
        If Me.TextBoxRow.Text.Trim <> "" Then
            ro = Me.TextBoxRow.Text

            Select Case datavFlag
                Case 1
                    'チェック

                    Me.DataGridView1.Rows(ro).Cells(tyuicoment).Value = Me.TextBox注意事項コメント1.Text
                    Me.DataGridView1.Rows(ro).Cells(rokrkka).Value = Me.TextBox不備内容.Text
                    Me.DataGridView1.Rows(ro).Cells(saihoumin).Value = Me.TextBox再訪問指示内容.Text

                    If IsDate(Me.TextBox再訪問指示日.Text) Then
                        Me.DataGridView1.Rows(ro).Cells(saihouminDay).Value = Me.TextBox再訪問指示日.Text
                    Else
                        Me.DataGridView1.Rows(ro).Cells(saihouminDay).Value = ""
                    End If
                    Me.TextBoxRow.Text = ""

                    Me.TextBox受付番号.Text = ""
                    Me.TextBox製品名.Text = ""
                    Me.TextBox機器分類.Text = ""
                    Me.TextBox点検製品区分詳細名.Text = ""

                    Me.TextBox注意事項コメント1.Text = ""
                    Me.TextBox不備内容.Text = ""
                    Me.TextBox再訪問指示内容.Text = ""
                    Me.TextBox再訪問指示日.Text = ""

                Case 2
                    '本日分

                    Me.DataGridView1.Rows(ro).Cells(4).Value = Me.TextBox不備内容.Text
                    Me.DataGridView1.Rows(ro).Cells(6).Value = Me.TextBox再訪問指示内容.Text

                    If IsDate(Me.TextBox再訪問指示日.Text) Then
                        Me.DataGridView1.Rows(ro).Cells(5).Value = Me.TextBox再訪問指示日.Text
                    Else
                        Me.DataGridView1.Rows(ro).Cells(5).Value = ""

                    End If

                    If IsDate(Me.TextBox確認完了日.Text) Then
                        Me.DataGridView1.Rows(ro).Cells(7).Value = Me.TextBox確認完了日.Text
                    Else
                        Me.DataGridView1.Rows(ro).Cells(7).Value = ""
                    End If

                    Me.TextBoxRow.Text = ""
                    Me.TextBox受付番号.Text = ""
                    Me.TextBox製品名.Text = ""
                    Me.TextBox機器分類.Text = ""
                    Me.TextBox点検製品区分詳細名.Text = ""

                    Me.TextBox注意事項コメント1.Text = ""
                    Me.TextBox不備内容.Text = ""
                    Me.TextBox再訪問指示内容.Text = ""
                    Me.TextBox再訪問指示日.Text = ""
            End Select
        End If
    End Sub

    Private Sub ListBox機器分類名_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox機器分類名.SelectedIndexChanged
        ListBox点検項目名.DrawMode = DrawMode.OwnerDrawFixed
        GetSystemtoListBox("102", Me.ListBox点検項目名, Me.ListBox機器分類名.SelectedItem.ToString())
    End Sub

    Private Sub Button本日分取消_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ToolStripComboBox条件_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox条件.SelectedIndexChanged
        If Me.ToolStripComboBox条件.Text = "本日作業分含まない" Then
            Me.ToolStripStatusLabel条件.Text = "本日作業分含まない->"
        Else
            Me.ToolStripStatusLabel条件.Text = "本日作業分含む ->"
        End If
    End Sub

    Private Sub Label5_MouseClick(sender As Object, e As MouseEventArgs) Handles Label5.MouseClick
        Dim i As Integer

        If Me.ListBox点検結果.SelectedIndex <> -1 Then
            Me.ListBox点検結果.SelectedIndex = -1
        Else

            If e.Button = MouseButtons.Right Then
                For i = 0 To Me.ListBox点検結果.Items.Count - 1
                    Me.ListBox点検結果.SetSelected(i, True)
                Next
                Me.ListBox点検結果.SetSelected(0, False)
                Me.ListBox点検結果.SetSelected(5, False)

            Else
                For i = 0 To Me.ListBox点検結果.Items.Count - 1
                    Me.ListBox点検結果.SetSelected(i, True)
                Next
            End If
        End If

    End Sub

    Private Sub Label5_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Label5.MouseDoubleClick
        Me.ListBox点検結果.SelectedIndex = -1
        Me.ListBox点検結果.SetSelected(0, True)
        Me.ListBox点検結果.SetSelected(5, True)

    End Sub

    Private Sub 本日分取り消しToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 本日分取り消しToolStripMenuItem.Click
        Dim strSQL As String
        Dim ret As String

        If Me.ListBox点検項目名.SelectedIndex = -1 Then
            MsgBox("点検項目名を設定してください")
            Return
        End If
        If Me.ListBox機器分類名.SelectedIndex = -1 Then
            MsgBox("機器分類名を設定してください")
            Return
        End If

        strSQL = "SELECT COUNT(*) FROM " & schema & "t_tenken_fubi where 反映フラグ ='0'  And  点検 ='" & Me.ListBox点検項目名.SelectedItem.ToString & "'"
        ret = ClassPostgeDB.DbSel(strSQL)

        Dim result As DialogResult = MessageBox.Show("本日分　" & ret & "件を　取消_しますか？",
                                                     "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2)
        If result = DialogResult.OK Then
            strSQL = "DELETE FROM " & schema & "t_tenken_fubi where 反映フラグ ='0'  And  点検 ='" & Me.ListBox点検項目名.SelectedItem.ToString & "'"
            ClassPostgeDB.EXEC(strSQL)
            DataGridViewSet()

        End If

    End Sub

    Private Function GetColor(kiki As String, tenken As String) As Color
        GetColor = Color.Black

        For Each drow As DataRow In ColorDt2.Rows
            If drow(0) = kiki Then
                If drow(1) = tenken Then
                    Return Color.FromName(drow(2))
                End If
            End If

        Next

    End Function

    Private Sub ListBox点検項目名_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox点検項目名.DrawItem
        '背景を描画する
        '項目が選択されている時は強調表示される
        e.DrawBackground()

        'ListBoxが空のときにListBoxが選択されるとe.Indexが-1になる
        If e.Index > -1 Then
            '文字を描画する色の選択
            Dim b As Brush = Nothing
            If (e.State And DrawItemState.Selected) <> DrawItemState.Selected Then
                '選択されていない時

                b = New SolidBrush(GetColor(Me.ListBox機器分類名.SelectedItem.ToString, sender.items(e.Index).ToString))

            Else
                '選択されている時はそのままの前景色を使う
                b = New SolidBrush(e.ForeColor)
            End If
            '描画する文字列の取得
            Dim txt As String = CType(sender, ListBox).Items(e.Index).ToString()
            '文字列の描画
            e.Graphics.DrawString(txt, e.Font, b, e.Bounds.X, e.Bounds.Y)
            '後始末
            b.Dispose()
        End If

        'フォーカスを示す四角形を描画
        e.DrawFocusRectangle()

    End Sub


End Class