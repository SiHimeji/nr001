Public Class FormMstFubinaiyou
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

    Private Sub FormMstFubinaiyou_Load(sender As Object, e As EventArgs) Handles Me.Load

        GetSystemtoCombo("'100'", Me.ComboBox機器分類, "")
        GetSystemtoCombo("'102','104'", Me.ComboBox点検項目１, "")
        GetSystemtoCombo("'103'", Me.ComboBox判定１, "")
        'GetSystemtoCombo("'102','104'", Me.ComboBox点検項目２, "")
        GetSystemtoCombo("'103'", Me.ComboBox判定２, "")

        Me.TextBoxNo.Text = ""
        DispCler()
        disp()
    End Sub
    Private Sub disp()
        Dim strSQL As String

        strSQL = "select  seq,naiyou,jouken,naiyou2,atai,naiyou3,atai3,bikou   from " & schema & "m_system  where kbn ='150'  order by seq"
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
        Me.DataGridView1.AllowUserToAddRows = False


    End Sub
    Private Sub disp(kiki As String)
        Dim strSQL As String

        If kiki <> "" Then
            strSQL = "select  seq,naiyou,jouken,naiyou2,atai,naiyou3,atai3,bikou   from " & schema & "m_system  where kbn ='150' and naiyou = '" & kiki & "'  order by seq"
            ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
            Me.DataGridView1.AllowUserToAddRows = False
        End If


    End Sub
    Private Sub disp(kiki As String, kou As String)
        Dim strSQL As String

        If kiki <> "" Or kou <> "" Then
            strSQL = "select  seq,naiyou,jouken,naiyou2,atai,naiyou3,atai3,bikou   from " & schema & "m_system  where kbn ='150' and naiyou = '" & kiki & "'  and naiyou2 = '" & kou & "'order by seq"
            ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
            Me.DataGridView1.AllowUserToAddRows = False
        End If


    End Sub


    Private Sub DispCler()
        Me.TextBoxNo.Text = ""
        Me.ComboBox機器分類.Text = ""
        Me.ComboBox点検項目１.Text = ""
        Me.ComboBox点検項目２.Text = ""
        Me.TextBox製品名.Text = ""
        Me.ComboBox判定１.Text = ""
        Me.ComboBox判定２.Text = ""
        Me.TextBox不備内容.Text = ""
    End Sub


    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String
        Dim Ret As String

        If IsNumeric(Me.TextBoxNo.Text.ToString) Then

            strSQL = "Select  count(*)  from " & schema & "m_system  where kbn ='150'  and seq = '" & Me.TextBoxNo.Text.ToString & "'"
            Ret = ClassPostgeDB.DbSel(strSQL)
            If Ret = "0" Then
                strSQL = "INSERT INTO  " & schema & "m_system"
                strSQL &= "(kbn, seq, naiyou,naiyou2, bikou, entry_day, entry_sya, update_day,  atai, naiyou3,atai3, jouken)"
                strSQL &= "VALUES('150'"
                strSQL &= ", '" & Me.TextBoxNo.Text.ToString & "'"
                strSQL &= ", '" & Me.ComboBox機器分類.Text & "'"
                strSQL &= ", '" & Me.ComboBox点検項目１.Text & "'"

                strSQL &= ", '" & Me.TextBox不備内容.Text & "'"
                strSQL &= ", now()"
                strSQL &= ", '" & UserName & "'"
                strSQL &= ", now()"
                strSQL &= ", '" & Me.ComboBox判定１.Text & "'"
                strSQL &= ", '" & Me.ComboBox点検項目２.Text & "'"
                strSQL &= ", '" & Me.ComboBox判定２.Text & "'"

                strSQL &= ", '" & StrConv(Me.TextBox製品名.Text, vbNarrow) & "');"

            Else
                Dim result As DialogResult = MessageBox.Show("上書しますか？", "確認",
                     MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Exclamation,
                     MessageBoxDefaultButton.Button2)

                If result = DialogResult.OK Then

                    strSQL = "UPDATE  " & schema & "m_system"
                    strSQL &= " SET naiyou= '" & Me.ComboBox機器分類.Text & "'"
                    strSQL &= ", naiyou2 = '" & Me.ComboBox点検項目１.Text & "'"
                    strSQL &= ", bikou= '" & Me.TextBox不備内容.Text & "'"
                    'strSQL &= ", entry_day=''"
                    strSQL &= ", entry_sya= '" & UserName & "'"
                    strSQL &= ", update_day=now()"
                    strSQL &= ", atai= '" & Me.ComboBox判定１.Text & "'"

                    strSQL &= ", naiyou3 = '" & Me.ComboBox点検項目２.Text & "'"
                    strSQL &= ", atai3 ='" & Me.ComboBox判定２.Text & "'"

                    strSQL &= ", jouken= '" & StrConv(Me.TextBox製品名.Text, vbNarrow) & "'"
                    strSQL &= " WHERE kbn= '150'  and seq = '" & Me.TextBoxNo.Text.ToString & "'"
                Else
                    Return
                End If
            End If

            If ClassPostgeDB.EXEC(strSQL) Then
                MessageBox.Show("更新しました")
                DispCler()
            Else
                MessageBox.Show("更新エラーです")
            End If
            disp()
        Else
            MsgBox("Noが空白です")
        End If

    End Sub


    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then

                Me.TextBoxNo.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.ComboBox機器分類.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBox製品名.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                Me.ComboBox点検項目１.Text = Me.DataGridView1.Rows(ro).Cells(3).Value
                Me.ComboBox判定１.Text = Me.DataGridView1.Rows(ro).Cells(4).Value

                Me.ComboBox点検項目２.Text = Me.DataGridView1.Rows(ro).Cells(5).Value
                Me.ComboBox判定２.Text = Me.DataGridView1.Rows(ro).Cells(6).Value

                Me.TextBox不備内容.Text = Me.DataGridView1.Rows(ro).Cells(7).Value

            End If
        End If

    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred2(Me.DataGridView1, False, Me.ToolStripProgressBar1, 0)
    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String

        If IsNumeric(Me.TextBoxNo.Text.ToString) Then

            Dim result As DialogResult = MessageBox.Show("削除しますか？", "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2)

            If result = DialogResult.OK Then

                strSQL = "Delete from " & schema & "m_system  where kbn ='150'  and seq = '" & Me.TextBoxNo.Text.ToString & "'"
                ClassPostgeDB.EXEC(strSQL)
                disp()
                DispCler()

            End If
        End If
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button新規採番_Click(sender As Object, e As EventArgs) Handles Button新規採番.Click
        Dim strSQL As String
        strSQL = "Select  max(cast(seq as integer) )+1  From " & schema & "m_system  where kbn ='150' "
        Me.TextBoxNo.Text = ClassPostgeDB.DbSel(strSQL)

    End Sub

    Private Sub ComboBox機器分類_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox機器分類.SelectedIndexChanged
        Me.ComboBox点検項目２.Items.Clear()
        Me.ComboBox点検項目１.SelectedIndex = -1
        Me.ComboBox判定１.SelectedIndex = -1
        Me.ComboBox判定２.SelectedIndex = -1
        disp(Me.ComboBox機器分類.Text)
    End Sub

    Private Sub ComboBox点検項目１_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox点検項目１.SelectedIndexChanged

        Chg点検項目()
        disp(Me.ComboBox機器分類.Text, Me.ComboBox点検項目１.Text)

    End Sub
    Private Sub Chg点検項目()

        Select Case Me.ComboBox機器分類.Text
            Case "ガス機器"
                Select Case Me.ComboBox点検項目１.Text
                    Case "法１７"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置５")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                    Case "法１８"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置５")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                    Case Else
                        Me.ComboBox点検項目２.Items.Clear()

                End Select

            Case "石油機器"
                Select Case Me.ComboBox点検項目１.Text
                    Case "法１７"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置９")
                        Me.ComboBox点検項目２.SelectedIndex = 0

                    Case "法１８"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置１０")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                    Case "自８"
                        Me.ComboBox点検項目２.Items.Clear()
                        Me.ComboBox点検項目２.Items.Add("安全装置１")
                        Me.ComboBox点検項目２.SelectedIndex = 0
                    Case Else
                        Me.ComboBox点検項目２.Items.Clear()
                End Select


            Case "ビルトイン式食器洗機"
                Me.ComboBox点検項目２.Items.Clear()

        End Select

    End Sub




End Class