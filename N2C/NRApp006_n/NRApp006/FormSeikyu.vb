Public Class FormSeikyu
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB


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

    Private Sub FormSeikyu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " Version[" & Ver & "] " &
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報
        Me.ToolStripStatusLabel件数.Text = ""
        Me.DataGridView1.RowHeadersWidth = 10

        Me.ComboBoxリスト.Items.Clear()
        Me.ComboBoxリスト.Items.Add("不備リスト")
        Me.ComboBoxリスト.Items.Add("請求保留")
        Me.ComboBoxリスト.Items.Add("SS別不備リスト")
        Me.ComboBoxリスト.Items.Add("支店別不備リスト")
        Me.ComboBoxリスト.SelectedIndex = -1


        Me.ListBoxステータス.Items.Clear()


        'ClassPostgeDB.SetComboBox(Me.ComboBoxステータス, "select ms.naiyou  from " & schema & "m_system ms where ms.kbn ='20' order by ms.seq")
        'Me.ComboBoxステータス.SelectedIndex = -1
        ClassPostgeDB.SetListBox(Me.ListBoxステータス, "select ms.naiyou  from " & schema & "m_system ms where ms.kbn ='20' and  naiyou2 <> '1' order by ms.seq")


        Me.GroupBox期間.Visible = False
        Me.DateTimePicker期間1.Value = Me.DateTimePicker期間1.Value.AddMonths(-120)
        Me.OFFToolStripMenuItem.SelectedIndex = 0

    End Sub
    Private Sub ComboBoxリスト_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxリスト.SelectedIndexChanged
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.Rows.Clear()
            Me.DataGridView1.Columns.Clear()
        End If

        Select Case Me.ComboBoxリスト.Text
            Case "不備リスト"
                Me.ListBoxステータス.Visible = False
                Me.Labelステータス.Visible = False
            Case "請求保留"
                Me.ListBoxステータス.Visible = False
                Me.Labelステータス.Visible = False
            Case Else
                Me.ListBoxステータス.Visible = True
                Me.Labelステータス.Visible = True
        End Select

    End Sub
    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DataGridView1.DataSource = Nothing
        'System.Windows.Forms.Application.DoEvents()

        EXE("0")
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub EXE(sw As String)
        Dim i As Integer
        Dim stat As String = String.Empty

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Me.DataGridView1.ScrollBars = ScrollBars.Both

        Select Case Me.ComboBoxリスト.Text
            Case "不備リスト"
                不備リスト()
            Case "請求保留"
                請求保留()
            Case "支店別不備リスト"
                If sw = "0" Then
                    For i = 0 To Me.ListBoxステータス.SelectedItems.Count - 1
                        If i <> 0 Then
                            stat &= ","
                        End If
                        stat &= "'" & ListBoxステータス.SelectedItems(i) & "'"
                    Next

                    支店別ステータスリスト(stat)
                End If
            Case "SS別不備リスト"
                If sw = "0" Then

                    For i = 0 To Me.ListBoxステータス.SelectedItems.Count - 1
                        If i <> 0 Then
                            stat &= ","
                        End If
                        stat &= "'" & ListBoxステータス.SelectedItems(i) & "'"
                    Next

                    SS別ステータスリスト(stat)

                End If
        End Select

        ' Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ScrollBars = ScrollBars.Vertical
    End Sub


    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub 不備リスト()
        Dim strSQL As String
        Dim dt As New DataTable
        Dim Horyu As String
        Dim sumi As String

        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()


        sumi = GetSystemto("20", "0")
        Horyu = GetSystemto("20", "1")

        strSQL = ""
        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t.点検受付番号 "
        strSQL &= ",t.店略称 "
        strSQL &= ",t.tc店略称 as 支店 "
        strSQL &= ",t.点検完了日 "
        strSQL &= ",t.回収区分 "
        strSQL &= ",t1.訂正依頼内容 "

        strSQL &= ",t1.更新日 as 訂正更新日"
        strSQL &= ",t.更新日 "
        strSQL &= ",t.ｄｍ番号 "

        'strSQL &= ",CASE WHEN t1.出庫 = '1' THEN '停止' ELSE '' END 出庫 "
        'strSQL &= ",CASE WHEN t1.完了 = '1' THEN '完了' ELSE '' END 完了 "
        'strSQL &= ",t.ステータス名 "
        'strSQL &= ",t.技術料 "
        'strSQL &= ",t.出張料 "
        'strSQL &= ",t.その他料金 "
        'strSQL &= ",t.点検料金 "
        'strSQL &= ",t.請求先会社 "
        'strSQL &= ",t.請求先名 "
        'strSQL &= ",t.請求先電話 "
        'strSQL &= ",t.回収金額 "
        'strSQL &= ",t.価格指示理由 "

        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " ," & schema & "t_teisei t1"
        strSQL &= " where t.点検受付番号 = t1.点検受付番号 "

        strSQL &= " and t1.ステータス <> '" & Horyu & "'"
        strSQL &= " and t1.ステータス <> ''"

        If Me.OFFToolStripMenuItem.Text = "含める" Then
            strSQL &= " and  t.点検完了日 between '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        Else
            strSQL &= " and  t1.完了 = '0'"
        End If
        strSQL &= " order by t1.更新日"

        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Columns(6).Width = 300


        Me.DataGridView1.Columns(7).Visible = False
        Me.DataGridView1.Columns(8).Visible = False
        Me.DataGridView1.Columns(9).Visible = False
        Me.DataGridView1.ScrollBars = ScrollBars.Vertical

        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"

        不備リスト1()

    End Sub

    Private Sub 不備リスト1()

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(ro).Cells(7).Value = Nothing Then

            Else
                '更新日チェック
                If Me.DataGridView1.Rows(ro).Cells(7).Value.ToString() < Me.DataGridView1.Rows(ro).Cells(8).Value.ToString() Then
                    Me.DataGridView1.Rows(ro).Cells(0).Style.BackColor = Color.Yellow
                End If
            End If
        Next

    End Sub

    Private Sub 請求保留()

        Dim strSQL As String
        Dim dt As New DataTable
        Dim Horyu As String

        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Horyu = GetSystemto("20", "1")

        strSQL = ""
        strSQL &= "select "
        strSQL &= " t1.ステータス"
        strSQL &= ",t1.訂正依頼内容 "
        strSQL &= ",CASE WHEN t1.出庫 = '1' THEN '停止'  ELSE '' END 出庫 "
        strSQL &= ",CASE WHEN t1.完了 = '1' THEN '完了'  ELSE '' END 完了 "
        strSQL &= ",t1.更新日 as 訂正更新日"

        strSQL &= ",c.チェック as 技術チェック"
        strSQL &= ",c.確認完了日 as 技術確認完了日"

        strSQL &= " ,t.点検受付番号 "
        strSQL &= " ,t.ｄｍ番号 "
        strSQL &= " ,t.ステータス名 "
        strSQL &= " ,t.点検完了日 "
        strSQL &= " ,t.都道府県名 "
        strSQL &= " ,t.市区町村名 "
        strSQL &= " ,t.町域 "
        strSQL &= " ,t.番地 "
        strSQL &= " ,t.建物 "
        strSQL &= " ,t.部屋 "
        strSQL &= " ,t.回収区分 "
        strSQL &= " ,t.技術料 "
        strSQL &= " ,t.出張料 "
        strSQL &= " ,t.その他料金 "
        strSQL &= " ,t.点検料金 "
        strSQL &= " ,t.無償部品代"
        strSQL &= " ,t.無償出張料 "
        strSQL &= " ,t.無償出張料差額 "
        strSQL &= " ,t.無償技術料 "
        strSQL &= " ,t.無償その他 "
        strSQL &= " ,t.無償合計 "
        strSQL &= " ,t.修理状況 "
        strSQL &= " ,replace(t.請求先会社,'　','■') 請求先会社"
        strSQL &= " ,replace(t.請求先部署,'　','■') 請求先部署"
        strSQL &= " ,replace(t.請求先名,'　','■') 請求先名"
        strSQL &= " ,t.請求先電話 "
        strSQL &= " ,t.請求先住所 "
        strSQL &= " ,replace(t.請求先宛名,'　','■') 請求先宛名"
        strSQL &= " ,replace(t.請求先担当,'　','■') 請求先担当"
        strSQL &= " ,t.担当shopコード "
        strSQL &= " ,t.店略称 "
        strSQL &= " ,t.担当サービスマン "
        strSQL &= " ,t.更新日 "

        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku t"
        strSQL &= " ," & schema & "t_teisei t1"
        strSQL &= " Left outer join " & schema & "t_check c on c.点検受付番号  = t1.点検受付番号  "
        strSQL &= " where t.点検受付番号 =t1.点検受付番号 "
        strSQL &= " and  t1.ステータス ='" & Horyu & "'"
        If Me.OFFToolStripMenuItem.Text = "ON" Then
            strSQL &= " and  t.点検完了日 between '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        Else
            strSQL &= " and  t1.完了 = '0'"
        End If
        strSQL &= " order by t.請求先電話"

        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.DataSource = dt
        If dt.Rows.Count > 0 Then


            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.Columns(0).Width = 100
            Me.DataGridView1.Columns(1).Width = 120
            Me.DataGridView1.Columns(2).Width = 40
            Me.DataGridView1.Columns(3).Width = 40
            Me.DataGridView1.Columns(4).Width = 100

            'Me.DataGridView1.Enabled = False

        Else

        End If

        Me.ToolStripStatusLabel件数.Text = Me.DataGridView1.Rows.Count & "件"
        請求保留1()
    End Sub
    Private Sub 請求保留1()


        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            '更新日チェック
            If Me.DataGridView1.Rows(ro).Cells(4).Value.ToString() < Me.DataGridView1.Rows(ro).Cells(39).Value.ToString() Then
                Me.DataGridView1.Rows(ro).Cells(0).Style.BackColor = Color.Yellow
                Me.DataGridView1.Rows(ro).Cells(4).Style.BackColor = Color.Yellow
                Me.DataGridView1.Rows(ro).Cells(39).Style.BackColor = Color.Yellow
            End If

        Next


    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.RowIndex = -1 Then Exit Sub
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        Dim ro

        ro = e.RowIndex
        Try

            If ro >= 0 And e.Button = MouseButtons.Left Then

                Select Case Me.ComboBoxリスト.Text
                    Case "不備リスト"
                        FormInput.TextBox点検受付番号.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
                        FormInput.TextBoxDM番号.Text = Me.DataGridView1.Rows(ro).Cells(9).Value.ToString
                    Case "請求保留"
                        FormInput.TextBox点検受付番号.Text = Me.DataGridView1.Rows(ro).Cells(5 + 2).Value.ToString
                        FormInput.TextBoxDM番号.Text = Me.DataGridView1.Rows(ro).Cells(6 + 1).Value.ToString
                    Case "支店別不備リスト"
                        Exit Sub
                    Case "SS別不備リスト"
                        Exit Sub
                End Select

                FormInput.UserID = UserID
                FormInput.UserName = UserName
                FormInput.Kengen = Kengen
                If FormInput.ShowDialog() = DialogResult.OK Then
                    EXE("1")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            If ComboBoxリスト.Text = "不備リスト" Then
                excelOutDataGred2a(Me.DataGridView1, True, Me.ToolStripProgressBar1)
            Else
                excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 0)
            End If

            Me.Cursor = System.Windows.Forms.Cursors.Default
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If

    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        If Me.DataGridView1.Rows.Count > 0 Then
            OutputCsvFromDataGridView(Me.DataGridView1, Me.ToolStripProgressBar1)
        Else
            MessageBox.Show("出力するデータがありません。検索してから行ってください")
        End If
    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        Select Case Me.ComboBoxリスト.Text
            Case "不備リスト"
                不備リスト1()
            Case "請求保留"


        End Select
    End Sub

    Private Sub 支店別ステータスリスト(stat As String)
        Dim strSQL As String
        Dim dt As New DataTable
        Dim ro As Integer
        Dim x As Integer
        Dim xx As Integer
        Dim y As Integer

        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = ""
        strSQL &= "Select "
        strSQL &= " Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end 点検完了日"
        strSQL &= " From " & schema & "v_yuryo_tenken_syuyaku t , " & schema & "t_teisei tt "
        strSQL &= " Where tt.点検受付番号 = t.点検受付番号"
        If stat <> "" Then
            strSQL &= " And  tt.ステータス in (" & stat & ") "
        End If
        strSQL &= " And  tt.ステータス <> '' "
        strSQL &= " And  t.ステータス名 not in('受付ｷｬﾝｾﾙ','訪問前ｷｬﾝｾﾙ','訪問ｷｬﾝｾﾙ')  "

        If Me.OFFToolStripMenuItem.Text = "ON" Then
            strSQL &= " And  t.点検完了日 between '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        Else
            strSQL &= " And  tt.完了 ='0' "

        End If
        strSQL &= " group by Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end "
        strSQL &= " order by Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end "

        'strSQL &= " group by left(t.点検完了日, 7)"
        'strSQL &= " order by left(t.点検完了日, 7)"
        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.ColumnCount = 1 + dt.Rows.Count
        Me.DataGridView1.Columns(0).HeaderText = ""

        For ro = 0 To dt.Rows.Count - 1
            Me.DataGridView1.Columns(ro + 1).HeaderText = dt.Rows(ro).Item(0).ToString
        Next

        strSQL = ""
        strSQL &= "Select  "
        strSQL &= " Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else left(t.点検完了日, 7) end 点検完了日"
        strSQL &= ",tt.点検受付番号 ,t.tc店略称  "

        strSQL &= " From " & schema & "v_yuryo_tenken_syuyaku t , " & schema & "t_teisei tt "
        strSQL &= " Where tt.点検受付番号 = t.点検受付番号"
        If stat <> "" Then
            strSQL &= " And  tt.ステータス in (" & stat & ") "
        End If
        strSQL &= " And  tt.ステータス <> '' "
        strSQL &= " And  t.ステータス名 not in('受付ｷｬﾝｾﾙ','訪問前ｷｬﾝｾﾙ','訪問ｷｬﾝｾﾙ')  "

        If Me.OFFToolStripMenuItem.Text = "ON" Then
            strSQL &= " And  t.点検完了日 between '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        Else
            strSQL &= " And  tt.完了 ='0' "

        End If
        strSQL &= " order by t.tc店略称  ,left(t.点検完了日, 7)"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then

            Me.DataGridView1.Rows.Clear()
            For ro = 0 To dt.Rows.Count - 1
                x = yoko(dt.Rows(ro).Item(0).ToString)
                y = tate(dt.Rows(ro).Item(2).ToString, 0)
                If y = -1 Then
                    Me.DataGridView1.Rows.Add(dt.Rows(ro).Item(2).ToString)
                    y = tate(dt.Rows(ro).Item(2).ToString, 0)

                    For xx = 1 To Me.DataGridView1.ColumnCount - 1
                        Me.DataGridView1.Rows(y).Cells(xx).Value = "0"
                    Next
                End If

                Me.DataGridView1.Rows(y).Cells(x).Value = Integer.Parse(Me.DataGridView1.Rows(y).Cells(x).Value) + 1
            Next

            'Me.DataGridView1.Enabled = False
            'Me.DataGridView1.ScrollBars = ScrollBars.Vertical

        End If

    End Sub

    Private Sub SS別ステータスリスト(stat As String)
        Dim strSQL As String
        Dim dt As New DataTable
        Dim ro As Integer
        Dim x As Integer
        Dim xx As Integer
        Dim y As Integer

        dt = Nothing
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL = ""
        strSQL &= "Select "
        strSQL &= " Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end 点検完了日"
        strSQL &= " From " & schema & "v_yuryo_tenken_syuyaku t , " & schema & "t_teisei tt "
        strSQL &= " Where tt.点検受付番号 = t.点検受付番号"
        If stat <> "" Then
            strSQL &= " And  tt.ステータス in (" & stat & ") "
        End If
        strSQL &= " And  tt.ステータス <> '' "
        strSQL &= " And  t.ステータス名 not in('受付ｷｬﾝｾﾙ','訪問前ｷｬﾝｾﾙ','訪問ｷｬﾝｾﾙ')  "
        If Me.OFFToolStripMenuItem.Text = "ON" Then
            strSQL &= " And  t.点検完了日 between '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
        Else
            strSQL &= " And  tt.完了 ='0' "

        End If

        strSQL &= " group by Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end "
        strSQL &= " order by Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end "


        'strSQL &= " group by left(t.点検完了日, 7)"
        'strSQL &= " order by left(t.点検完了日, 7)"
        dt = ClassPostgeDB.SetTable(strSQL)



        Me.DataGridView1.ColumnCount = 2 + dt.Rows.Count
        Me.DataGridView1.Columns(0).HeaderText = ""
        Me.DataGridView1.Columns(1).HeaderText = ""
        For ro = 0 To dt.Rows.Count - 1
            Me.DataGridView1.Columns(ro + 2).HeaderText = dt.Rows(ro).Item(0).ToString
        Next

        strSQL = ""
        strSQL &= "Select "
        strSQL &= " Case when  t.点検完了日 ='' then to_char(CURRENT_DATE,'yyyy/MM') else   left(t.点検完了日, 7) end 点検完了日"
        strSQL &= ",tt.点検受付番号 ,t.tc店略称 ,t.店略称 "
        strSQL &= " From " & schema & "v_yuryo_tenken_syuyaku t , " & schema & "t_teisei tt "
        strSQL &= " Where tt.点検受付番号 = t.点検受付番号"
        If stat <> "" Then
            strSQL &= " And  tt.ステータス in (" & stat & ") "
        End If
        strSQL &= " And  tt.ステータス <> '' "
        strSQL &= " And  t.ステータス名 not in('受付ｷｬﾝｾﾙ','訪問前ｷｬﾝｾﾙ','訪問ｷｬﾝｾﾙ')  "

        If Me.OFFToolStripMenuItem.Text = "ON" Then
                strSQL &= " And  t.点検完了日 between '" & Me.DateTimePicker期間1.Value & "' and '" & Me.DateTimePicker期間2.Value & "'"
            Else
                strSQL &= " And  tt.完了 ='0' "

        End If
        strSQL &= " order by t.tc店略称 ,t.店略称 ,left(t.点検完了日, 7)"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            '描画を止める  
            'Me.DataGridView1.ResumeLayout(False)
            '縦スクロールの不具合解消の為、一旦行クリア  
            Me.DataGridView1.Rows.Clear()
            For ro = 0 To dt.Rows.Count - 1
                x = yoko(dt.Rows(ro).Item(0).ToString)
                y = tate(dt.Rows(ro).Item(3).ToString, 1)
                If y = -1 Then
                    Me.DataGridView1.Rows.Add(dt.Rows(ro).Item(2).ToString, dt.Rows(ro).Item(3).ToString)
                    y = tate(dt.Rows(ro).Item(3).ToString, 1)

                    For xx = 2 To Me.DataGridView1.ColumnCount - 1
                        Me.DataGridView1.Rows(y).Cells(xx).Value = "0"
                    Next

                End If
                Me.DataGridView1.Rows(y).Cells(x).Value = Integer.Parse(Me.DataGridView1.Rows(y).Cells(x).Value) + 1
            Next

            'Me.DataGridView1.Enabled = False
            'Me.DataGridView1.ScrollBars = ScrollBars.Vertical
            'Me.DataGridView1.Rows(1).Frozen = True
            'Me.DataGridView1.ResumeLayout(True)
        End If

    End Sub
    Private Function yoko(buf As String) As Integer
        Dim x
        For x = 1 To Me.DataGridView1.ColumnCount - 1
            If Me.DataGridView1.Columns(x).HeaderText = buf Then
                Return x
            End If
        Next
        Return -1
    End Function

    Private Function tate(buf As String, x As Integer) As Integer
        Dim y
        If Me.DataGridView1.Rows.Count = 0 Then Return -1

        For y = 0 To Me.DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(y).Cells(x).Value = Nothing Then Return -1
            If Me.DataGridView1.Rows(y).Cells(x).Value.ToString() = buf Then
                Return y
            End If
        Next
        Return -1
    End Function

    Private Sub OFFToolStripMenuItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OFFToolStripMenuItem.SelectedIndexChanged
        Select Case Me.OFFToolStripMenuItem.Text
            Case "ON"
                Me.GroupBox期間.Visible = True
            Case Else
                Me.GroupBox期間.Visible = False
        End Select

    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub


End Class