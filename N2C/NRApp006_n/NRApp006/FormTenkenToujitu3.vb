Public Class FormTenkenToujitu3
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

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub 検索ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 検索ToolStripMenuItem.Click
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        Select Case Me.ToolStripComboBox1.Text
            Case "当日分のチェック「３」"
                Toujitu()
            Case "チェック「3」の確認完了日のない"
                Check3Mikan()
        End Select
    End Sub

    Private Sub Toujitu()
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL &= "select v.商圏 "
        strSQL &= " ,v.店名略称 "
        strSQL &= " ,t.点検受付番号 "
        strSQL &= " ,t.再訪問指示内容 "
        strSQL &= " from " & schema & "t_check t ," & schema & "v_tenken_kekka v"
        strSQL &= " where t.点検受付番号 = v.""受付ＮＯ"" "
        strSQL &= " and t.チェック ='3'"
        strSQL &= "  And to_char(t.チェック日,'yyyy/MM/dd')  = to_char(now() ,'yyyy/MM/dd')"

        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.AutoGenerateColumns = True
        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.AllowUserToAddRows = False

    End Sub

    Private Sub Check3Mikan()
        Dim strSQL As String = String.Empty
        Dim dt As DataTable
        Dim ro As Integer

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()

        strSQL &= "select v.商圏 "
        strSQL &= " ,v.店名略称 "
        strSQL &= " ,t.点検受付番号 "
        strSQL &= " ,t.チェック "
        strSQL &= " ,t.不備内容 "
        strSQL &= " ,t.再訪問指示日 "
        strSQL &= " ,t.再訪問指示内容 "
        strSQL &= " ,t.確認完了日"
        strSQL &= " from " & schema & "t_check t ," & schema & "v_tenken_kekka v"
        strSQL &= " where t.点検受付番号 = v.""受付ＮＯ"" "
        strSQL &= " and t.チェック ='3'"
        strSQL &= " and t.確認完了日 is null "
        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt
        ro = 0
        ro = settextColumn(Me.DataGridView1, ro, "商圏", "支店", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "店名略称", "SS名", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "点検受付番号", "受け番号", 60, True)
        ro = settextColumn(Me.DataGridView1, ro, "チェック", "チェック", 60, False)
        ro = settextColumn(Me.DataGridView1, ro, "不備内容", "不備内容", 120, True)
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示日", "再訪問指示日", 100, True)
        ro = settextColumn(Me.DataGridView1, ro, "再訪問指示内容", "再訪問指示内容", 120, True)
        ro = settextColumn(Me.DataGridView1, ro, "確認完了日", "確認完了日", 100, "0000/00/00", False)
        Me.DataGridView1.AllowUserToAddRows = False

    End Sub

    Private Sub FormTenkenToujitu3_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DataGridView1.DataSource = Nothing

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 0)
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

        'Dim a As String = e.ToString()

    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()


    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown


        Select Case Me.ToolStripComboBox1.Text
            Case "当日分のチェック「３」"

            Case "チェック「3」の確認完了日のない"

                If e.KeyCode = 7 And Me.DataGridView1.CurrentCell.ColumnIndex = 7 Then

                End If

        End Select

    End Sub

    Private Sub 更新()
        Dim ro As Integer
        Dim strSQL As String
        Dim Chk As String
        Dim Kakunin As String

        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            If Strings.Left(Me.DataGridView1.Rows(ro).Cells(7).Value.ToString, 1).Trim <> "" Or Me.DataGridView1.Rows(ro).Cells(3).Value.ToString <> "3" Then

                Chk = Me.DataGridView1.Rows(ro).Cells(3).Value
                If Chk = "3" Then
                    Chk = "3"
                Else
                    Chk = "1"
                End If

                Kakunin = Strings.Left(Me.DataGridView1.Rows(ro).Cells(7).Value.ToString, 10)
                If Kakunin = "" Then
                    strSQL = "Update " & schema & "t_check set 確認完了日 = null"
                Else
                    strSQL = "Update " & schema & "t_check set 確認完了日 ='" & Kakunin & "'"
                    'Chk = 1
                End If

                strSQL &= ",チェック ='" & Chk & "'"
                strSQL &= ",更新日=now() ,  更新者='" & UserName & "'"
                strSQL &= " Where 点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(2).Value.ToString & "'"
                ClassPostgeDB.EXEC(strSQL)

                If Chk <> "3" Then
                    '出庫停止を解除する
                    strSQL = "Update " & schema & "t_teisei set 出庫 = '0'"
                    strSQL &= ", 更新日=now() , 更新者 = '" & UserName & "'"
                    strSQL &= " Where 点検受付番号 ='" & Me.DataGridView1.Rows(ro).Cells(2).Value.ToString & "'"
                    ClassPostgeDB.EXEC(strSQL)
                End If
            End If
        Next

        MsgBox("更新しました")
        Check3Mikan()

    End Sub
    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        更新()
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        Select Case Me.ToolStripComboBox1.Text
            Case "当日分のチェック「３」"

            Case "チェック「3」の確認完了日のない"

                If e.ColumnIndex = 7 Then
                    If e.Button = MouseButtons.Left Then
                        Dim dt1 As DateTime = DateTime.Now
                        Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value = dt1.ToString("yyyy/MM/dd")
                    End If

                    If e.Button = MouseButtons.Right Then
                        Me.DataGridView1.Rows(e.RowIndex).Cells(7).Value = ""
                    End If
                End If



        End Select


    End Sub
End Class