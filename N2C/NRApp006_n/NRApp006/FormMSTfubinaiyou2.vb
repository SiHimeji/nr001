Public Class FormMSTfubinaiyou2
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
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

    Private Sub FormMSTfubinaiyou2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSystemtoCombo("'100'", Me.ComboBox機器分類, "")

        GetSystemtoCombo("'102','104'", Me.ComboBox点検項目１, "")
        GetSystemtoCombo("'103'", Me.ComboBox判定１, "")
        'GetSystemtoCombo("'102','104'", Me.ComboBox点検項目２, "")
        GetSystemtoCombo("'103'", Me.ComboBox判定２, "")
        ' GetSystemtoCombo("'102','104'", Me.ComboBox点検項目３, "")
        GetSystemtoCombo("'103'", Me.ComboBox判定３, "")

        GetSystemtoCombo("'101'", Me.ComboBox点検製品区分詳細名, "")

        Me.ComboBox条件.Items.Clear()
        Me.ComboBox条件.Items.Add("")
        Me.ComboBox条件.Items.Add("等しい")
        Me.ComboBox条件.Items.Add("以外")

        disp(0)

    End Sub
    Private Sub disp(sw As Integer)
        Dim strSQL As String
        strSQL = "select  seq,naiyou,naiyou2,atai,naiyou3,atai3,naiyou4,atai4,jouken,jouken2,bikou , jun  from " & schema & "m_system  where kbn ='160' "

        Select Case sw
            Case 0
                strSQL &= " order by naiyou,naiyou2,atai,jun"
            Case 1
                strSQL &= " and naiyou  = '" & Me.ComboBox機器分類.Text & "' order by naiyou2,atai,jun"

            Case 2
                strSQL &= " and naiyou  = '" & Me.ComboBox機器分類.Text & "'  and naiyou2 = '" & Me.ComboBox点検項目１.Text & "' order by naiyou,naiyou2,atai,jun"

        End Select

        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.AllowUserToAddRows = False
        setチェック順()
    End Sub


    Private Sub DispClear()

        Me.TextBoxNo.Text = ""
        Me.ComboBox機器分類.Text = ""
        Me.ComboBox点検項目１.Text = ""
        Me.ComboBox判定１.Text = ""
        Me.ComboBox点検項目２.Text = ""
        Me.ComboBox判定２.Text = ""
        Me.ComboBox点検項目３.Text = ""
        Me.ComboBox判定３.Text = ""

        Me.ComboBox点検製品区分詳細名.Text = ""
        Me.ComboBox条件.Text = ""
        Me.TextBox不備内容.Text = ""
    End Sub


    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                If Me.ComboBox機器分類.Text <> Me.DataGridView1.Rows(ro).Cells(1).Value Then
                    Me.ComboBox機器分類.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                    Return
                End If

                If Me.ComboBox点検項目１.Text <> Me.DataGridView1.Rows(ro).Cells(2).Value Then
                    Me.ComboBox点検項目１.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                    Return
                End If

                Me.TextBoxNo.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.ComboBox判定１.Text = Me.DataGridView1.Rows(ro).Cells(3).Value
                Me.ComboBox点検項目２.Text = Me.DataGridView1.Rows(ro).Cells(4).Value
                Me.ComboBox判定２.Text = Me.DataGridView1.Rows(ro).Cells(5).Value
                Me.ComboBox点検項目３.Text = Me.DataGridView1.Rows(ro).Cells(6).Value
                Me.ComboBox判定３.Text = Me.DataGridView1.Rows(ro).Cells(7).Value

                Me.ComboBox点検製品区分詳細名.Text = Me.DataGridView1.Rows(ro).Cells(8).Value
                Me.ComboBox条件.Text = Me.DataGridView1.Rows(ro).Cells(9).Value
                Me.TextBox不備内容.Text = Me.DataGridView1.Rows(ro).Cells(10).Value

                Me.ComboBoxチェック順.Text = Me.DataGridView1.Rows(ro).Cells(11).Value

            End If
            End If

    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim ret As String

        If IsNumeric(Me.TextBoxNo.Text.ToString) Then

            strSQL = "Select  count(*)  from " & schema & "m_system  where kbn ='160'  and seq = '" & Me.TextBoxNo.Text.ToString & "'"
            ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = "INSERT INTO  " & schema & "m_system"
                strSQL &= "(kbn, seq,naiyou,naiyou2,atai,naiyou3,atai3,naiyou4,atai4,jouken,jouken2,bikou  ,entry_day, entry_sya, update_day,jun)"
                strSQL &= "VALUES('160'"
                strSQL &= ", '" & Me.TextBoxNo.Text.ToString & "'"
                strSQL &= ", '" & Me.ComboBox機器分類.Text & "'"

                strSQL &= ", '" & Me.ComboBox点検項目１.Text & "'"
                strSQL &= ", '" & Me.ComboBox判定１.Text & "'"
                strSQL &= ", '" & Me.ComboBox点検項目２.Text & "'"
                strSQL &= ", '" & Me.ComboBox判定２.Text & "'"
                strSQL &= ", '" & Me.ComboBox点検項目３.Text & "'"
                strSQL &= ", '" & Me.ComboBox判定３.Text & "'"
                strSQL &= ", '" & Me.ComboBox点検製品区分詳細名.Text & "'"
                strSQL &= ", '" & Me.ComboBox条件.Text & "'"
                strSQL &= ", '" & Me.TextBox不備内容.Text & "'"

                strSQL &= ", now()"
                strSQL &= ", '" & UserName & "'"
                strSQL &= ", now()"

                strSQL &= ", '" & Me.ComboBoxチェック順.Text & "'"

                strSQL &= ")"

            Else
                Dim result As DialogResult = MessageBox.Show("上書しますか？", "確認",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2)

                If result = DialogResult.OK Then

                    strSQL = "UPDATE  " & schema & "m_system"
                    strSQL &= " SET naiyou= '" & Me.ComboBox機器分類.Text & "'"

                    strSQL &= ", naiyou2 = '" & Me.ComboBox点検項目１.Text & "'"
                    strSQL &= ", atai = '" & Me.ComboBox判定１.Text & "'"
                    strSQL &= ", naiyou3 = '" & Me.ComboBox点検項目２.Text & "'"
                    strSQL &= ", atai3 = '" & Me.ComboBox判定２.Text & "'"
                    strSQL &= ", naiyou4 = '" & Me.ComboBox点検項目３.Text & "'"
                    strSQL &= ", atai4 = '" & Me.ComboBox判定３.Text & "'"
                    strSQL &= ", jouken = '" & Me.ComboBox点検製品区分詳細名.Text & "'"
                    strSQL &= ", jouken2 = '" & Me.ComboBox条件.Text & "'"
                    strSQL &= ", bikou = '" & Me.TextBox不備内容.Text & "'"

                    strSQL &= ", entry_sya= '" & UserName & "'"
                    strSQL &= ", update_day=now()"
                    strSQL &= ", jun = '" & Me.ComboBoxチェック順.Text & "'"

                    strSQL &= " WHERE kbn= '160'  and seq = '" & Me.TextBoxNo.Text.ToString & "'"

                Else
                    Return
                End If
            End If

            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("更新しました")


            Else
                MessageBox.Show("更新エラーです")
            End If
            disp(2)
        Else
            MsgBox("Noが空白です")
        End If

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String
        If IsNumeric(Me.TextBoxNo.Text.ToString) Then
            Dim result As DialogResult = MessageBox.Show("削除しますか？", "確認",
                                             MessageBoxButtons.OKCancel,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)

            If result = DialogResult.OK Then
                strSQL = "Delete  from " & schema & "m_system  where kbn ='160'  and seq = '" & Me.TextBoxNo.Text.ToString & "'"
                ClassPostgeDB.EXEC(strSQL)
                DispClear()
                disp(2)

            End If
        End If

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred2(Me.DataGridView1, False, Me.ToolStripProgressBar1, 0)

    End Sub

    Private Sub ComboBox点検項目１_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox点検項目１.SelectedIndexChanged
        Select Case Me.ComboBox機器分類.Text
            Case "ガス機器"
                Select Case Me.ComboBox点検項目１.Text
                    Case "法１７"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置５")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                        Me.ComboBox点検項目３.Items.Clear()
                        Me.ComboBox点検項目３.Items.Add("安全装置６")
                        Me.ComboBox点検項目３.SelectedIndex = 0
                    Case "法１８"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置５")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                        Me.ComboBox点検項目３.Items.Clear()

                    Case Else
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目３.Items.Clear()

                End Select

            Case "石油機器"
                Select Case Me.ComboBox点検項目１.Text
                    Case "法１７"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置９")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                        Me.ComboBox点検項目３.Items.Clear()

                    Case "法１８"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置１０")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                        Me.ComboBox点検項目３.Items.Clear()
                    Case "自８"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置１")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                        Me.ComboBox点検項目３.Items.Clear()
                    Case Else
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目３.Items.Clear()

                End Select


            Case "ビルトイン式食器洗機"

                Me.ComboBox点検項目２.Items.Clear()
                Me.ComboBox点検項目３.Items.Clear()

        End Select
        Me.TextBox不備内容.Text = ""
        disp(2)

    End Sub

    Private Sub ComboBox機器分類_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox機器分類.SelectedIndexChanged

        Me.ComboBox点検項目２.Items.Clear()
        Me.ComboBox点検項目３.Items.Clear()
        Me.ComboBox点検項目１.SelectedIndex = -1
        Me.ComboBox判定１.SelectedIndex = -1
        Me.ComboBox判定２.SelectedIndex = -1
        Me.ComboBox判定３.SelectedIndex = -1
        Me.ComboBox点検製品区分詳細名.SelectedIndex = -1
        Me.ComboBox条件.SelectedIndex = -1
        Me.TextBox不備内容.Text = ""

        disp(1)


    End Sub

    Private Sub Button新規採番_Click(sender As Object, e As EventArgs) Handles Button新規採番.Click
        Dim strSQL As String
        strSQL = "Select  max(cast(seq as integer) )+1  From " & schema & "m_system  where kbn ='160' "
        Me.TextBoxNo.Text = ClassPostgeDB.DbSel(strSQL)
    End Sub

    Private Sub setチェック順()
        Dim strSQL As String
        Dim x As Integer
        Dim xto As String

        strSQL = "Select  max(COALESCE(jun,0))  + 1  From " & schema & "m_system  where kbn ='160' "
        xto = ClassPostgeDB.DbSel(strSQL)

        Me.ComboBoxチェック順.Items.Clear()
        For x = 1 To Integer.Parse(xto)
            Me.ComboBoxチェック順.Items.Add(x.ToString)
        Next

    End Sub

    Private Sub 出力ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出力ToolStripMenuItem.Click

    End Sub
End Class