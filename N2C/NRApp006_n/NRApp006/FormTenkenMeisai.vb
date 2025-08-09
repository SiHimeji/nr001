Public Class FormTenkenMeisai
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

    Private Sub FormTenkenMeisai_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.ListBoxチェック.SelectedIndex = -1
        Me.MaskedTextBox確認日.Text = ""
        Me.MaskedTextBox再訪問指示日.Text = ""
        Me.TextBox不備内容.Text = ""
        Me.TextBox再訪問指示内容.Text = ""
        検索()
    End Sub

    Private Sub 検索()


        Dim dt As DataTable
        Dim strSQL As String
        Me.TextBox受付番号.Text = UketukeNo

        strSQL = ""
        strSQL &= "SELECT ""ＤＭ番号"", 点検結果伝票番号, ""メーカーＣＤ"", メーカー名, 製品名, 製造番号, 機器分類"
        strSQL &= ", 機器分類名, 点検製品区分, 点検製品区分名, 点検製品区分詳細, 点検製品区分詳細名, 廃棄延長識別"
        strSQL &= ", 廃棄延長識別名, ""点検項目ＣＤ＿法１"", ""点検項目名＿法１"", ""点検結果＿法１"", ""点検結果名＿法１"""
        strSQL &= ", ""点検項目ＣＤ＿法２"", ""点検項目名＿法２"", ""点検結果＿法２"", ""点検結果名＿法２"", ""点検項目ＣＤ＿法３"""
        strSQL &= ", ""点検項目名＿法３"", ""点検結果＿法３"", ""点検結果名＿法３"", ""点検項目ＣＤ＿法４"", ""点検項目名＿法４"""
        strSQL &= ", ""点検結果＿法４"", ""点検結果名＿法４"", ""点検項目ＣＤ＿法５"", ""点検項目名＿法５"", ""点検結果＿法５"""
        strSQL &= ", ""点検結果名＿法５"", ""点検項目ＣＤ＿法６"", ""点検項目名＿法６"", ""点検結果＿法６"", ""点検結果名＿法６"""
        strSQL &= ", ""点検項目ＣＤ＿法７"", ""点検項目名＿法７"", ""点検結果＿法７"", ""点検結果名＿法７"", ""点検項目ＣＤ＿法８"""
        strSQL &= ", ""点検項目名＿法８"", ""点検結果＿法８"", ""点検結果名＿法８"", ""点検項目ＣＤ＿法９"", ""点検項目名＿法９"""
        strSQL &= ", ""点検結果＿法９"", ""点検結果名＿法９"", ""点検項目ＣＤ＿法１０"", ""点検項目名＿法１０"", ""点検結果＿法１０"""
        strSQL &= ", ""点検結果名＿法１０"", ""点検項目ＣＤ＿法１１"", ""点検項目名＿法１１"", ""点検結果＿法１１"", ""点検結果名＿法１１"""
        strSQL &= ", ""点検項目ＣＤ＿法１２"", ""点検項目名＿法１２"", ""点検結果＿法１２"", ""点検結果名＿法１２"", ""点検項目ＣＤ＿法１３"""
        strSQL &= ", ""点検項目名＿法１３"", ""点検結果＿法１３"", ""点検結果名＿法１３"", ""点検項目ＣＤ＿法１４"", ""点検項目名＿法１４"""
        strSQL &= ", ""点検結果＿法１４"", ""点検結果名＿法１４"", ""点検項目ＣＤ＿法１５"", ""点検項目名＿法１５"", ""点検結果＿法１５"""
        strSQL &= ", ""点検結果名＿法１５"", ""点検項目ＣＤ＿法１６"", ""点検項目名＿法１６"", ""点検結果＿法１６"", ""点検結果名＿法１６"""
        strSQL &= ", ""点検項目ＣＤ＿法１７"", ""点検項目名＿法１７"", ""点検結果＿法１７"", ""点検結果名＿法１７"", ""点検項目ＣＤ＿法１８"""
        strSQL &= ", ""点検項目名＿法１８"", ""点検結果＿法１８"", ""点検結果名＿法１８"", ""点検項目ＣＤ＿法１９"", ""点検項目名＿法１９"""
        strSQL &= ", ""点検結果＿法１９"", ""点検結果名＿法１９"", ""点検項目ＣＤ＿法２０"", ""点検項目名＿法２０"", ""点検結果＿法２０"""
        strSQL &= ", ""点検結果名＿法２０"", ""点検項目ＣＤ＿法２１"", ""点検項目名＿法２１"", ""点検結果＿法２１"", ""点検結果名＿法２１"""
        strSQL &= ", ""点検項目ＣＤ＿法２２"", ""点検項目名＿法２２"", ""点検結果＿法２２"", ""点検結果名＿法２２"", ""点検項目ＣＤ＿自１"""
        strSQL &= ", ""点検項目名＿自１"", ""点検結果＿自１"", ""点検結果名＿自１"", ""点検項目ＣＤ＿自２"", ""点検項目名＿自２"", ""点検結果＿自２"""
        strSQL &= ", ""点検結果名＿自２"", ""点検項目ＣＤ＿自３"", ""点検項目名＿自３"", ""点検結果＿自３"", ""点検結果名＿自３"", ""点検項目ＣＤ＿自４"""
        strSQL &= ", ""点検項目名＿自４"", ""点検結果＿自４"", ""点検結果名＿自４"", ""点検項目ＣＤ＿自５"", ""点検項目名＿自５"", ""点検結果＿自５"""
        strSQL &= ", ""点検結果名＿自５"", ""点検項目ＣＤ＿自６"", ""点検項目名＿自６"", ""点検結果＿自６"", ""点検結果名＿自６"", ""点検項目ＣＤ＿自７"""
        strSQL &= ", ""点検項目名＿自７"", ""点検結果＿自７"", ""点検結果名＿自７"", ""点検項目ＣＤ＿自８"", ""点検項目名＿自８"", ""点検結果＿自８"""
        strSQL &= ", ""点検結果名＿自８"", ""点検項目ＣＤ＿自９"", ""点検項目名＿自９"", ""点検結果＿自９"", ""点検結果名＿自９"", ""点検項目ＣＤ＿自１０"""
        strSQL &= ", ""点検項目名＿自１０"", ""点検結果＿自１０"", ""点検結果名＿自１０"", ""点検項目ＣＤ＿自１１"", ""点検項目名＿自１１"", ""点検結果＿自１１"""
        strSQL &= ", ""点検結果名＿自１１"", ""点検項目ＣＤ＿清掃１"", ""点検項目名＿清掃１"", ""点検結果＿清掃１"", ""点検結果名＿清掃１"", ""一酸化炭素濃度＿給湯"""
        strSQL &= ", ""一酸化炭素濃度＿ふろ"", ""一酸化炭素濃度＿給湯＿暖房"", 一酸化炭素濃度未測定理由, ""ＣＯ燃焼時間"", 燃焼回数, 燃焼時間, 安全装置１有無"
        strSQL &= ", 安全装置１名, 安全装置２有無, 安全装置２名, 安全装置３有無, 安全装置３名, 安全装置４有無, 安全装置４名, 安全装置５有無, 安全装置５名"
        strSQL &= ", 安全装置６有無, 安全装置６名, 安全装置７有無, 安全装置７名, 安全装置８有無, 安全装置８名, 安全装置９有無, 安全装置９名, 安全装置１０有無"
        strSQL &= ", 安全装置１０名, 安全装置１１有無, 安全装置１１名, 安全装置１２有無, 安全装置１２名, 安全装置１３有無, 安全装置１３名, 安全装置１４有無"
        strSQL &= ", 安全装置１４名, 安全装置１５有無, 安全装置１５名, フィルタ付パッキンの交換有無, フィルタ付パッキンの交換名, 点検お知らせ機能有無"
        strSQL &= ", 点検お知らせ機能名, 点検済みシール貼り付け有無, 点検済みシール貼り付け名, 点検注意事項１チェック有無, 点検注意事項１名, 点検注意事項２チェック有無"
        strSQL &= ", 点検注意事項２名, 点検注意事項３チェック有無, 点検注意事項３名, 点検注意事項４チェック有無, 点検注意事項４名, 点検注意事項５チェック有無"
        strSQL &= ", 点検注意事項５名, 点検注意事項６チェック有無, 点検注意事項６名, 点検注意事項７チェック有無, 点検注意事項７名, 点検注意事項８チェック有無"
        strSQL &= ", 点検注意事項８名, 点検注意事項９チェック有無, 点検注意事項９名, 点検注意事項１０チェック有無, 点検注意事項１０名, 注意事項コメント"
        strSQL &= ", 総合判定種別, 総合判定名, 修理受付有無種別, 修理受付有無名, 使用禁止ラベル貼付識別, 使用禁止ラベル貼付名, 使用禁止説明実施種別"
        strSQL &= ", 使用禁止説明実施名, 使用禁止処置無し理由, 受付日, 点検完了日, 店コード, サービスマンコード, サービスマン名, 資格番号, 業務区分"
        strSQL &= ", 業務区分名, 特定製造事業者コード, 特定製造事業者名, 製造年月, 点検結果入力日, データ修正日, モバイル新ステータス, モバイル新ステータス名称, 店名略称, 商圏, endflag"
        strSQL &= " FROM " & schema & "v_tenken_kekka where ""受付ＮＯ"" ='" & Me.TextBox受付番号.Text & "'"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then

            Me.TextBox製品名.Text = dt.Rows(0).Item("製品名")
            Me.TextBox業務区分名.Text = dt.Rows(0).Item("業務区分名")
            Me.TextBox総合判定種別.Text = dt.Rows(0).Item("総合判定種別")
            Me.TextBox法１.Text = dt.Rows(0).Item("点検結果＿法１")
            Me.TextBox法２.Text = dt.Rows(0).Item("点検結果＿法２")
            Me.TextBox法３.Text = dt.Rows(0).Item("点検結果＿法３")
            Me.TextBox法４.Text = dt.Rows(0).Item("点検結果＿法４")
            Me.TextBox法５.Text = dt.Rows(0).Item("点検結果＿法５")
            Me.TextBox法６.Text = dt.Rows(0).Item("点検結果＿法６")
            Me.TextBox法７.Text = dt.Rows(0).Item("点検結果＿法７")
            Me.TextBox法８.Text = dt.Rows(0).Item("点検結果＿法８")
            Me.TextBox法９.Text = dt.Rows(0).Item("点検結果＿法９")
            Me.TextBox法１０.Text = dt.Rows(0).Item("点検結果＿法１０")

            Me.TextBox法１１.Text = dt.Rows(0).Item("点検結果＿法１１")
            Me.TextBox法１２.Text = dt.Rows(0).Item("点検結果＿法１２")
            Me.TextBox法１３.Text = dt.Rows(0).Item("点検結果＿法１３")
            Me.TextBox法１４.Text = dt.Rows(0).Item("点検結果＿法１４")
            Me.TextBox法１５.Text = dt.Rows(0).Item("点検結果＿法１５")
            Me.TextBox法１６.Text = dt.Rows(0).Item("点検結果＿法１６")
            Me.TextBox法１７.Text = dt.Rows(0).Item("点検結果＿法１７")
            Me.TextBox法１８.Text = dt.Rows(0).Item("点検結果＿法１８")
            Me.TextBox法１９.Text = dt.Rows(0).Item("点検結果＿法１９")

            Me.TextBox法２０.Text = dt.Rows(0).Item("点検結果＿法２０")
            Me.TextBox法２１.Text = dt.Rows(0).Item("点検結果＿法２１")
            Me.TextBox法２２.Text = dt.Rows(0).Item("点検結果＿法２２")
            'Me.TextBox注意事項コメント.Text = dt.Rows(0).Item("注意事項コメント")

            Me.TextBox自１.Text = dt.Rows(0).Item("点検結果＿自１")
            Me.TextBox自２.Text = dt.Rows(0).Item("点検結果＿自２")
            Me.TextBox自３.Text = dt.Rows(0).Item("点検結果＿自３")
            Me.TextBox自４.Text = dt.Rows(0).Item("点検結果＿自４")
            Me.TextBox自５.Text = dt.Rows(0).Item("点検結果＿自５")
            Me.TextBox自６.Text = dt.Rows(0).Item("点検結果＿自６")
            Me.TextBox自７.Text = dt.Rows(0).Item("点検結果＿自７")
            Me.TextBox自８.Text = dt.Rows(0).Item("点検結果＿自８")
            Me.TextBox自９.Text = dt.Rows(0).Item("点検結果＿自９")
            Me.TextBox自１０.Text = dt.Rows(0).Item("点検結果＿自１０")
            Me.TextBox自１１.Text = dt.Rows(0).Item("点検結果＿自１１")

            Me.TextBox安１.Text = dt.Rows(0).Item("安全装置１有無")
            Me.TextBox安２.Text = dt.Rows(0).Item("安全装置２有無")
            Me.TextBox安３.Text = dt.Rows(0).Item("安全装置３有無")
            Me.TextBox安４.Text = dt.Rows(0).Item("安全装置４有無")
            Me.TextBox安５.Text = dt.Rows(0).Item("安全装置５有無")
            Me.TextBox安６.Text = dt.Rows(0).Item("安全装置６有無")
            Me.TextBox安７.Text = dt.Rows(0).Item("安全装置７有無")
            Me.TextBox安８.Text = dt.Rows(0).Item("安全装置８有無")
            Me.TextBox安９.Text = dt.Rows(0).Item("安全装置９有無")
            Me.TextBox安１０.Text = dt.Rows(0).Item("安全装置１０有無")
            Me.TextBox安１１.Text = dt.Rows(0).Item("安全装置１１有無")
            Me.TextBox安１２.Text = dt.Rows(0).Item("安全装置１２有無")
            Me.TextBox安１３.Text = dt.Rows(0).Item("安全装置１３有無")
            Me.TextBox安１４.Text = dt.Rows(0).Item("安全装置１４有無")
            Me.TextBox安１５.Text = dt.Rows(0).Item("安全装置１５有無")

            Me.TextBox点１.Text = dt.Rows(0).Item("点検注意事項１チェック有無")
            Me.TextBox点２.Text = dt.Rows(0).Item("点検注意事項２チェック有無")
            Me.TextBox点３.Text = dt.Rows(0).Item("点検注意事項３チェック有無")
            Me.TextBox点４.Text = dt.Rows(0).Item("点検注意事項４チェック有無")
            Me.TextBox点５.Text = dt.Rows(0).Item("点検注意事項５チェック有無")
            Me.TextBox点６.Text = dt.Rows(0).Item("点検注意事項６チェック有無")
            Me.TextBox点７.Text = dt.Rows(0).Item("点検注意事項７チェック有無")
            Me.TextBox点８.Text = dt.Rows(0).Item("点検注意事項８チェック有無")
            Me.TextBox点９.Text = dt.Rows(0).Item("点検注意事項９チェック有無")
            Me.TextBox点１０.Text = dt.Rows(0).Item("点検注意事項１0チェック有無")
            Me.TextBox清掃１.Text = dt.Rows(0).Item("点検結果＿清掃１")

            Me.TextBox一酸化炭素濃度＿給湯.Text = dt.Rows(0).Item("一酸化炭素濃度＿給湯")
            Me.TextBox一酸化炭素濃度＿ふろ.Text = dt.Rows(0).Item("一酸化炭素濃度＿ふろ")
            Me.TextBox一酸化炭素濃度＿給湯＿暖房.Text = dt.Rows(0).Item("一酸化炭素濃度＿給湯＿暖房")
            Me.TextBox一酸化炭素濃度未測定理由.Text = dt.Rows(0).Item("一酸化炭素濃度未測定理由")
            Me.TextBoxｃｏ燃焼時間.Text = dt.Rows(0).Item("ＣＯ燃焼時間")
            Me.TextBox燃焼回数.Text = dt.Rows(0).Item("燃焼回数")
            Me.TextBox燃焼時間.Text = dt.Rows(0).Item("燃焼時間")

            Me.TextBox点検完了日.Text = dt.Rows(0).Item("点検完了日")

            Me.TextBox商圏.Text = dt.Rows(0).Item("商圏")
            Me.TextBox店名略称.Text = dt.Rows(0).Item("店名略称")
            Me.TextBoxサービスマン名.Text = dt.Rows(0).Item("サービスマン名")
            Me.TextBox点検結果入力日.Text = dt.Rows(0).Item("点検結果入力日")

        Else

            MsgBox("データが存在しません")
        End If

    End Sub

    Private Sub 更新(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As String

        If Me.ListBoxチェック.SelectedIndex = -1 Then
            MsgBox("チェックが入っていません")
            Exit Sub

        End If

        ClassPostgeDB.DbOpen()
        ClassPostgeDB.BeginTrans()

        strSQL = "DELETE FROM  " & schema & "t_check  WHERE  点検受付番号 = '" & Me.TextBox受付番号.Text & "'"
        ClassPostgeDB.EXEC_tr(strSQL)


        strSQL = "INSERT INTO " & schema & "t_check (点検受付番号, チェック, 確認完了日, 更新者, 更新日,不備内容,再訪問指示内容,再訪問指示日,チェック日) VALUES("
        strSQL &= "'" & Me.TextBox受付番号.Text & "'"

        If Me.ListBoxチェック.SelectedIndex <> -1 Then
            strSQL &= ",'" & Me.ListBoxチェック.SelectedItem.ToString & "'"
        Else
            strSQL &= ",''"
        End If

        If Strings.Left(Me.MaskedTextBox確認日.Text, 1).Trim <> "" Then
            strSQL &= ",'" & Me.MaskedTextBox確認日.Text & "'"
        Else
            strSQL &= ",null"
        End If

        strSQL &= ",'" & UserName & "'"
        strSQL &= ",now()"
        strSQL &= ",'" & Me.TextBox不備内容.Text & "'"
        strSQL &= ",'" & Me.TextBox再訪問指示内容.Text & "'"
        If Strings.Left(Me.MaskedTextBox再訪問指示日.Text, 1).Trim <> "" Then
            strSQL &= ",'" & Me.MaskedTextBox再訪問指示日.Text & "'"
        Else
            strSQL &= ",null"
        End If
        strSQL &= ",now()"

        strSQL &= ")"

        ClassPostgeDB.EXEC_tr(strSQL)

        ClassPostgeDB.Commit()
        ClassPostgeDB.DbClose()
        MsgBox("更新しました")

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Me.MaskedTextBox再訪問指示日.Text = Me.DateTimePicker1.Value
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Me.MaskedTextBox確認日.Text = Me.DateTimePicker2.Value
    End Sub
End Class