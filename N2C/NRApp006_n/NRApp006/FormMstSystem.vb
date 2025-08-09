Public Class FormMstSystem

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
    '-------------------------------------------------------------------------

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String
        Dim jyo As String

        strSQL = "select naiyou from " & schema & "m_system where kbn ='0' and seq='0'"
        jyo = ClassPostgeDB.DbSel(strSQL)


        strSQL = "SELECT kbn, seq, naiyou,naiyou2, koumoku, atai, jouken, bikou, entry_day, entry_sya FROM " & schema & "m_system where entry_day is not null   "

        If Cob.Text = "" Then Cob.Text = "一致"

        Select Case Cob.Text
            Case "一致"
                strSQL = strSQL & " and " & jy & "  = '" & txt.Text.Trim.ToString & "'"
            Case "一部"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "%'"
            Case "前方"
                strSQL = strSQL & " and " & jy & " like '" & txt.Text.Trim.ToString & "%'"
            Case "後方"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "'"
            Case Else

                MessageBox.Show("条件を選択してください")
                Exit Sub


                Exit Sub
        End Select


        strSQL = strSQL & " And kbn not in (" & jyo & ")"


        strSQL = strSQL & " order by kbn, seq  ,naiyou"

        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

        '        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ReadOnly = True

    End Sub

    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "kbn", Me.TextBox区分)
        Clear("1")


    End Sub

    Private Sub Clear(sw As String)
        Select Case sw
            Case "1"
                Me.TextBox区分.Text = ""
            Case Else

                Me.TextBox区分.Text = ""

        End Select

        Me.TextBox内容２.Text = ""
        Me.TextBox備考.Text = ""
        Me.TextBox内容.Text = ""
        Me.TextBoxSEQ.Text = ""

        Me.TextBox値.Text = ""
        Me.ComboBox条件.SelectedIndex = 1
        JyoukenDisp(False)

    End Sub


    Private Function ChkKbnZero(kbn As String) As Boolean
        Dim strSQL As String
        Dim jyo As String
        Dim tmp As String()
        ChkKbnZero = True

        strSQL = "select naiyou from " & schema & "m_system where kbn ='0' and seq='0'"
        jyo = ClassPostgeDB.DbSel(strSQL)
        tmp = Split(jyo.Replace("'", ""), ",")
        For Each buf In tmp
            If buf = kbn Then ChkKbnZero = False
        Next

    End Function




    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click

        Dim strSQL As String
        Dim Ret


        If Me.TextBox区分.Text.Trim <> "" And Me.TextBoxSEQ.Text.TrimEnd.ToString <> "" And Me.TextBox内容.Text.TrimEnd.ToString <> "" Then


            If ChkKbnZero(Me.TextBox区分.Text.Trim) Then

            Else
                MsgBox("区分コード( " & Me.TextBox区分.Text.Trim & " )は別画面で更新してください")
                Return
            End If


            strSQL = "SELECT count(kbn) FROM " & schema & "m_system WHERE  kbn ='" & Me.TextBox区分.Text.TrimEnd.ToString & "' and seq = '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'" '''' and naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
                Ret = ClassPostgeDB.DbSel(strSQL)
                If Ret = "0" Then
                    strSQL = "INSERT INTO " & schema & "m_system (kbn, seq, naiyou, naiyou2,bikou ,koumoku,atai, jouken, entry_day,update_day, entry_sya) VALUES("
                    strSQL &= " '" & Me.TextBox区分.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.TextBox内容２.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.TextBox備考.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.TextBox項目.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.TextBox値.Text.TrimEnd.ToString & "'"
                    strSQL &= " ,'" & Me.ComboBox条件.Text.TrimEnd.ToString & "'"

                    strSQL &= " ,now()"
                    strSQL &= " ,now()"
                    strSQL &= " ,'" & UserName & "'"
                    strSQL &= " )"

                Else
                    strSQL = "UPDATE " & schema & "m_system SET "
                    strSQL &= " naiyou2 = '" & Me.TextBox内容２.Text.TrimEnd.ToString & "'"
                    strSQL &= ",naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"
                    strSQL &= ",bikou = '" & Me.TextBox備考.Text.TrimEnd.ToString & "'"
                    strSQL &= ",koumoku = '" & Me.TextBox項目.Text.TrimEnd.ToString & "'"
                    strSQL &= ",atai  = '" & Me.TextBox値.Text.TrimEnd.ToString & "'"
                    strSQL &= ",jouken ='" & Me.ComboBox条件.Text.TrimEnd.ToString & "'"

                    strSQL &= ",update_day = now() "
                    strSQL &= ",entry_sya = '" & UserName & "'"
                    strSQL &= " WHERE  kbn ='" & Me.TextBox区分.Text.TrimEnd.ToString & "' and seq = '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
                End If

                If ClassPostgeDB.EXEC(strSQL) Then
                    MessageBox.Show("更新しました")
                    ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)
                Else
                    MessageBox.Show("更新エラーです")
                End If

            End If

    End Sub
    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String

        strSQL = "DELETE FROM  " & schema & "m_system "
        strSQL &= " WHERE  kbn ='" & Me.TextBox区分.Text.TrimEnd.ToString & "' and seq = '" & Me.TextBoxSEQ.Text.TrimEnd.ToString & "'"
        strSQL &= " and naiyou = '" & Me.TextBox内容.Text.TrimEnd.ToString & "'"

        ClassPostgeDB.EXEC(strSQL)
        Clear("")
        ClassPostgeDB.SetDataGredv(zenkaiSQL, Me.DataGridView1)

    End Sub
    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then

                Me.TextBox区分.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBoxSEQ.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
                Me.TextBox内容.Text = Me.DataGridView1.Rows(ro).Cells(2).Value
                Me.TextBox内容２.Text = Me.DataGridView1.Rows(ro).Cells(3).Value
                Me.TextBox項目.Text = Me.DataGridView1.Rows(ro).Cells(4).Value
                Me.TextBox値.Text = Me.DataGridView1.Rows(ro).Cells(5).Value

                SetComboBox(Me.ComboBox条件, Me.DataGridView1.Rows(ro).Cells(6).Value)

                Me.TextBox備考.Text = Me.DataGridView1.Rows(ro).Cells(7).Value

                '//検索条件項目
                If Strings.Left(Me.TextBox区分.Text, 1) = "A" Then
                    JyoukenDisp(True)
                Else
                    JyoukenDisp(False)
                End If

                If Me.TextBox区分.Text = "140" Then
                    Me.Buttonマルチ.Visible = True
                Else
                    Me.Buttonマルチ.Visible = False
                End If


            Else
                Clear("")

            End If

        End If

    End Sub

    Private Sub FormMstSystem_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 10


        JyoukenDisp(False)

    End Sub

    Private Sub JyoukenDisp(sw As Boolean)

        Me.Label値.Visible = sw
        Me.Label条件.Visible = sw
        Me.Label項目.Visible = sw

        Me.TextBox値.Visible = sw
        Me.TextBox項目.Visible = sw
        Me.ComboBox条件.Visible = sw

    End Sub



    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred2(Me.DataGridView1, False, Me.ToolStripProgressBar1, 0)

    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        OutputCsvFromDataGridView(Me.DataGridView1, Me.ToolStripProgressBar1)
    End Sub

    Private Sub TextBox内容_TextChanged(sender As Object, e As EventArgs) Handles TextBox内容.TextChanged

    End Sub

    Private Sub TextBoxSEQ_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSEQ.TextChanged

    End Sub

    Private Sub Buttonマルチ_Click(sender As Object, e As EventArgs) Handles Buttonマルチ.Click

        SystemMsg = Me.TextBox備考.Text
        FormSystemMult.ShowDialog()
        Me.TextBox備考.Text = SystemMsg


    End Sub
End Class