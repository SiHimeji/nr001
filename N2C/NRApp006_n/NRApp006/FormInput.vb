Public Class FormInput
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

    Public sls_typ As String
    Public cst_cd As String
    Public entry_date As String


    Private Sub FormInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim dt As New DataTable

        Me.CheckBox出庫停止.Checked = False
        Me.Label更新時間.Text = ""
        Me.Label完了日.Text = ""

        Me.TextBox訂正依頼内容.Text = ""
        GetSystemtoCombo("'20'", Me.ComboBoxステータス, "")

        strSQL = "SELECT 点検受付番号, 訂正依頼内容, ステータス, 作成日, 更新日, 更新者,出庫 ,完了日,メモ FROM " & schema & "t_teisei "
        strSQL &= " where 点検受付番号 ='" & Me.TextBox点検受付番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            Me.TextBox訂正依頼内容.Text = dt.Rows(0).Item(1).ToString
            SetComboBox(Me.ComboBoxステータス, dt.Rows(0).Item(2).ToString)
            Me.Label更新時間.Text = dt.Rows(0).Item(4).ToString
            If dt.Rows(0).Item(6).ToString = "1" Then
                Me.CheckBox出庫停止.Checked = True
            Else
                Me.CheckBox出庫停止.Checked = False
            End If
            Me.Label完了日.Text = dt.Rows(0).Item(7).ToString
            Me.TextBoxメモ.Text = dt.Rows(0).Item(8).ToString

        Else
            Me.TextBox訂正依頼内容.Text = ""
            Me.Label更新時間.Text = ""
            Me.ComboBoxステータス.SelectedIndex = -1
            Me.CheckBox出庫停止.Checked = False
            Me.TextBoxメモ.Text = ""
        End If


        strSQL = "SELECT チェック,TO_CHAR(確認完了日,'yyyy/mm/dd'),TO_CHAR(チェック日,'yyyy/mm/dd') FROM " & schema & "t_check "
        strSQL &= " where 点検受付番号 ='" & Me.TextBox点検受付番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            Me.TextBox技術チェック.Text = dt.Rows(0).Item(0).ToString
            Me.MaskedTextBox技術確認完了日.Text = DateKata(dt.Rows(0).Item(1).ToString())
            Me.TextBoxチェック日.Text = dt.Rows(0).Item(2).ToString()

        Else
            Me.TextBox技術チェック.Text = ""
            Me.MaskedTextBox技術確認完了日.Text = ""
            Me.TextBoxチェック日.Text = ""
        End If


        strSQL = "select entry_date ,out_flg   FROM " & schema & "t_002 "
        strSQL &= " where uketukeno ='" & Me.TextBox点検受付番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            Me.Button出庫.Visible = True
            If dt.Rows(0).Item(1).ToString = "1" Then
                Me.TextBox出庫.Text = dt.Rows(0).Item(0).ToString & "作成:NEXT転送済み"
                Me.Button出庫.Text = "送信未"
            Else
                Me.TextBox出庫.Text = dt.Rows(0).Item(0).ToString & "作成:NEXT未転送"
                Me.Button出庫.Text = "送信済"
            End If
        Else
            Me.Button出庫.Visible = False

            Me.TextBox出庫.Text = "002作成"
        End If

    End Sub
    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        更新()
    End Sub
    Private Sub 更新()
        Dim strSQL As String
        Dim dt As New DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        strSQL = "SELECT 点検受付番号, 訂正依頼内容, ステータス, 作成日, 更新日, 更新者,出庫  FROM " & schema & "t_teisei "
        strSQL &= " where 点検受付番号 ='" & Me.TextBox点検受付番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then

            If Me.Label更新時間.Text = dt.Rows(0).Item(4).ToString Then

                strSQL = "UPDATE " & schema & "t_teisei "
                strSQL &= " SET 訂正依頼内容='" & Me.TextBox訂正依頼内容.Text & "'"
                strSQL &= " ,メモ='" & Me.TextBoxメモ.Text & "'"
                strSQL &= " ,ステータス='" & Me.ComboBoxステータス.Text & "'"
                strSQL &= " ,完了 = '0'"
                strSQL &= " ,更新日=now()"
                strSQL &= " ,更新者='" & UserID & "'"

                If Me.CheckBox出庫停止.Checked Then
                    strSQL &= " ,出庫='1'"
                Else
                    strSQL &= " ,出庫='0'"
                End If
                strSQL &= ",完了日 = null"

                strSQL &= " WHERE 点検受付番号='" & Me.TextBox点検受付番号.Text & "'"

                ClassPostgeDB.EXEC(strSQL)

                If sls_typ = "1" Then


                    entry_date = entry_date.Substring(0, 4) & "/" & entry_date.Substring(4, 2) & "/" & entry_date.Substring(6, 2)


                    strSQL = "UPDATE " & schema & "t_002 "
                    If Me.CheckBox出庫停止.Checked Then
                        strSQL &= " set del_flg = '1'"
                    Else
                        strSQL &= " set del_flg = '0'"
                    End If
                    strSQL &= " where sls_typ ='1'"
                    strSQL &= " and cst_cd ='" & cst_cd & "'"
                    strSQL &= " and uketukeno ='" & TextBox点検受付番号.Text & "'"
                    strSQL &= " and entry_date ='" & entry_date & "'"

                    ClassPostgeDB.EXEC(strSQL)
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("データが更新されています")
            End If
        Else
            strSQL = "INSERT INTO " & schema & "t_teisei (点検受付番号, 訂正依頼内容,メモ, ステータス, 出庫,完了,作成日, 更新日, 更新者,完了日) VALUES("
            strSQL &= " '" & Me.TextBox点検受付番号.Text & "'"
            strSQL &= " ,'" & Me.TextBox訂正依頼内容.Text & "'"
            strSQL &= " ,'" & Me.TextBoxメモ.Text & "'"
            strSQL &= " ,'" & Me.ComboBoxステータス.Text & "'"
            If Me.CheckBox出庫停止.Checked Then
                strSQL &= " ,'1'"
            Else
                strSQL &= " ,'0'"
            End If
            strSQL &= " ,'0'"
            strSQL &= " ,now()"
            strSQL &= " ,now()"
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ,null"
            strSQL &= " )"

            ClassPostgeDB.EXEC(strSQL)

        End If

        dt = Nothing
        strSQL = "SELECT チェック,確認完了日 FROM " & schema & "t_check "
        strSQL &= " where 点検受付番号 ='" & Me.TextBox点検受付番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then

            strSQL = "UPDATE " & schema & "t_check "
            strSQL &= " Set チェック = '" & Me.TextBox技術チェック.Text & "'"
            strSQL &= ",確認完了日 = " & DateKata(Me.MaskedTextBox技術確認完了日.Text) & ""
            strSQL &= ",更新日 = now()"
            strSQL &= ",更新者 ='" & UserID & "'"
            strSQL &= " WHERE 点検受付番号 ='" & Me.TextBox点検受付番号.Text & "'"
            ClassPostgeDB.EXEC(strSQL)

        Else

            strSQL = "INSERT INTO " & schema & "t_check (点検受付番号, チェック, 確認完了日, 更新者, 更新日) VALUES("
            strSQL &= " '" & Me.TextBox点検受付番号.Text & "'"
            strSQL &= ",'" & Me.TextBox技術チェック.Text & "'"
            strSQL &= " ," & DateKata(Me.MaskedTextBox技術確認完了日.Text) & ""
            strSQL &= " ,'" & UserID & "'"
            strSQL &= " ,now()"
            strSQL &= " )"
            ClassPostgeDB.EXEC(strSQL)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button済_Click(sender As Object, e As EventArgs) Handles Button済.Click
        Dim strSQL As String
        Dim dt As New DataTable

        If MsgBox("訂正完了とします", vbOKCancel) = vbOK Then


            更新()

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            strSQL = "SELECT 点検受付番号, 訂正依頼内容, ステータス, 作成日, 更新日, 更新者,出庫 FROM " & schema & "t_teisei "
            strSQL &= " where 点検受付番号 ='" & Me.TextBox点検受付番号.Text.Trim & "'"
            dt = ClassPostgeDB.SetTable(strSQL)
            If dt.Rows.Count = 1 Then
                'If Me.Label更新時間.Text = dt.Rows(0).Item(4).ToString Then
                strSQL = "UPDATE " & schema & "t_teisei "
                strSQL &= " SET 訂正依頼内容='" & Me.TextBox訂正依頼内容.Text & "'"
                strSQL &= " ,完了 = '1'"
                strSQL &= " ,完了日 = now()"
                strSQL &= " ,更新日 = now()"
                strSQL &= " ,更新者 = '" & UserID & "'"
                strSQL &= " WHERE 点検受付番号='" & Me.TextBox点検受付番号.Text & "'"
                ClassPostgeDB.EXEC(strSQL)

                Me.DialogResult = DialogResult.OK
                Me.Close()
                'Else
                'MessageBox.Show("データが更新されています")
                'End If
            Else

            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub Button削除_Click(sender As Object, e As EventArgs) Handles Button削除.Click
        Dim strSQL As String
        If MsgBox("訂正データを削除します", vbOKCancel) = vbOK Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            strSQL = "Delete From " & schema & "t_teisei "
            strSQL &= " WHERE 点検受付番号='" & Me.TextBox点検受付番号.Text & "'"
            ClassPostgeDB.EXEC(strSQL)


            Me.DialogResult = DialogResult.OK

            Me.Close()
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub Button出庫_Click(sender As Object, e As EventArgs) Handles Button出庫.Click
        Dim strSQL As String
        Dim dt As DataTable

        If Me.TextBox出庫.Text = "" Then

        End If
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Select Case Me.Button出庫.Text
            Case "送信未"
                strSQL = "update " & schema & "t_002 set out_flg ='0', nextb = '' where uketukeno ='" & Me.TextBox点検受付番号.Text & "'"
                ClassPostgeDB.EXEC(strSQL)
            Case "送信済"
                strSQL = "update " & schema & "t_002 set out_flg ='1' ,nextb = to_char(CURRENT_TIMESTAMP,'yyyy/MM/dd') where uketukeno ='" & Me.TextBox点検受付番号.Text & "'"
                ClassPostgeDB.EXEC(strSQL)
        End Select

        strSQL = "select entry_date ,out_flg   FROM " & schema & "t_002 "
        strSQL &= " where uketukeno ='" & Me.TextBox点検受付番号.Text.Trim & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            Me.Button出庫.Visible = True
            If dt.Rows(0).Item(1).ToString = "1" Then
                Me.TextBox出庫.Text = dt.Rows(0).Item(0).ToString & "作成:NEXT転送済み"
                Me.Button出庫.Text = "送信未"
            Else
                Me.TextBox出庫.Text = dt.Rows(0).Item(0).ToString & "作成:NEXT未転送"
                Me.Button出庫.Text = "送信済"
            End If
        Else
            Me.Button出庫.Visible = False

            Me.TextBox出庫.Text = "002作成"
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

        Me.MaskedTextBox技術確認完了日.Text = Me.DateTimePicker1.Value

    End Sub

    Private Sub Button削除CHECK_Click(sender As Object, e As EventArgs) Handles Button削除CHECK.Click
        Dim strSQL As String

        Dim result As DialogResult = MessageBox.Show("チェックを全て削除して良いですか？", "確認",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Exclamation,
                                 MessageBoxDefaultButton.Button2)
        If result <> DialogResult.OK Then
            Return
        End If


        strSQL = "Delete From " & schema & "t_check "
        strSQL &= " WHERE 点検受付番号='" & Me.TextBox点検受付番号.Text & "'"
        ClassPostgeDB.EXEC(strSQL)

        '------- 点検チェック
        strSQL = "Update " & schema & "v_tenken_kekka set endflag = '0' where ""受付ＮＯ"" ='" & Me.TextBox点検受付番号.Text & "'"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "Update  " & schema & "t_tenken_fubi set 反映フラグ = NULL where 点検受付番号 ='" & Me.TextBox点検受付番号.Text & "'"
        ClassPostgeDB.EXEC(strSQL)


        Me.DialogResult = DialogResult.OK

        Me.TextBox技術チェック.Text = ""
        Me.MaskedTextBox技術確認完了日.Text = ""

    End Sub


End Class