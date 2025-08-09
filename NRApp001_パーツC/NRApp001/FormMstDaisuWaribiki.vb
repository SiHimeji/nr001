Imports System.Text
Imports System.Windows.Forms
Imports System
'--- 23.11.30 k.s start ---
Imports Microsoft.VisualBasic.FileIO
'--- 23.11.30 k.s end ---

Public Class FormMstDaisuWaribiki
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    Dim T As NumericUpDown()
    Dim R As NumericUpDown()
    Dim W As Label()
    Dim C As ComboBox()


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

    Private Sub RadioButton割引率_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton割引率.Click
        Me.LabelW1.Text = "％"
        Me.LabelW2.Text = "％"
        Me.LabelW3.Text = "％"
        Me.LabelW4.Text = "％"
        Me.LabelW5.Text = "％"
        Me.LabelW6.Text = "％"
        Me.LabelW7.Text = "％"
        Me.LabelW8.Text = "％"
        Me.LabelW9.Text = "％"
        Me.LabelW10.Text = "％"
    End Sub

    Private Sub RadioButton割引額_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton割引額.Click
        Me.LabelW1.Text = "円"
        Me.LabelW2.Text = "円"
        Me.LabelW3.Text = "円"
        Me.LabelW4.Text = "円"
        Me.LabelW5.Text = "円"
        Me.LabelW6.Text = "円"
        Me.LabelW7.Text = "円"
        Me.LabelW8.Text = "円"
        Me.LabelW9.Text = "円"
        Me.LabelW10.Text = "円"
    End Sub
    Private Function ChkSeihin(seihin As String) As Boolean

        Dim strSQL As String
        Dim Ret
        strSQL = "select count(*) from " & schema & "m_seihin where sinacd ='" & seihin & "'"
        Ret = ClassPostgeDB.DbSel(strSQL)
        If Ret = "0" Then
            ChkSeihin = False
        Else
            ChkSeihin = True
        End If
    End Function

    Private Sub Button製品検索_Click(sender As Object, e As EventArgs) Handles Button製品検索.Click
        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text

        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox漢字名称.Text = FormSelectSeihin.SeihinName
        End If

        FormSelectSeihin.Dispose()
    End Sub

    Private Function tourokuchk(ByVal TextBox品コード As String) As Boolean
        Dim cd As String
        'Dim strSQL As String
        tourokuchk = True
        For Each cd In Me.ListBox1.Items
            If cd = TextBox品コード Then
                tourokuchk = False
                Exit Function
            End If
        Next
        '------ マスタ全体の重複チェック
        'strSQL = "SELECT count(sinacd)  FROM " & schema & "m_matomewari_cd where sinacd = '" & TextBox品コード & "'"
        'cd = ClassPostgeDB.DbSel(strSQL)
        'If cd = "0" Then
        'Else
        'tourokuchk = False
        'End If
        '------ マスタ全体の重複チェック
    End Function


    Private Sub Button追加_Click(sender As Object, e As EventArgs) Handles Button追加.Click

        If Me.TextBox品コード.Text.ToString.Length = 7 Then
            If ChkSeihin(Me.TextBox品コード.Text.ToString) = False Then
                MessageBox.Show("製品マスタに存在しません")
            Else
                If tourokuchk(Me.TextBox品コード.Text) Then
                    Me.ListBox1.Items.Add(Me.TextBox品コード.Text)
                Else
                    MessageBox.Show("登録されています")

                End If
            End If
        Else
            MessageBox.Show("製品マスタに存在しません")
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick, ListBox1.MouseClick

        ' 選択されているインデックスを取得する
        Dim idx As Integer = Me.ListBox1.SelectedIndex
        If idx >= 0 Then
            Dim result As DialogResult = MessageBox.Show("削除して良いですか ？",
                         "削除確認",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button2)

            If result = vbYes Then
                Me.ListBox1.Items.RemoveAt(idx)
            End If

        End If
        'Debug.Print(idx)
    End Sub

    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        Dim strSQL As String
        Dim i As Integer

        If Me.TextBoxまとめ買い割引コード.Text = "" Then
            MessageBox.Show("割引コードを入力してください")
            Return
        End If

        If Me.ListBox1.Items.Count = 0 Then
            MessageBox.Show("品コードが選択されていません")
            Return
        End If



        '新規の場合
        If Me.ToolStripMenuItem1.Text = "0" Then
            strSQL = "select coalesce(max(matomecd),'0')  from " & schema & "m_matomewari_cd "
            Me.ToolStripMenuItem1.Text = ClassPostgeDB.DbSel(strSQL)
            Me.ToolStripMenuItem1.Text = Integer.Parse(Me.ToolStripMenuItem1.Text) + 1
        End If

        strSQL = "delete from " & schema & "m_matomewari_seq where matomecd ="
        strSQL &= "'" & Me.ToolStripMenuItem1.Text & "'"
        ClassPostgeDB.EXEC(strSQL)

        'For i = 1 To 10
        '         strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui) VALUES("
        '        strSQL &= "" & i.ToString & ""
        '       strSQL &= "." & DirectCast(Me.Controls("NumericUpDownT" & CStr(i)), NumericUpDown).Value & ""
        '      strSQL &= "." & DirectCast(Me.Controls("NumericUpDownR" & CStr(i)), NumericUpDown).Value & ""
        '     strSQL &= "." & DirectCast(Me.Controls("LabelW" & CStr(i)), Label).Text & ""
        '    strSQL &= "." & DirectCast(Me.Controls("ComboBoxC" & CStr(i)), ComboBox).Text & ""
        '   strSQL &= ")"
        '  ClassPostgeDB.EXEC(strSQL)
        'Next

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "1"
        strSQL &= "," & NumericUpDownT1.Value & ""
        strSQL &= "," & NumericUpDownR1.Value & ""
        strSQL &= ",'" & LabelW1.Text & "'"
        strSQL &= ",'" & ComboBoxC1.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "2"
        strSQL &= "," & NumericUpDownT2.Value & ""
        strSQL &= "," & NumericUpDownR2.Value & ""
        strSQL &= ",'" & LabelW2.Text & "'"
        strSQL &= ",'" & ComboBoxC2.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "3"
        strSQL &= "," & NumericUpDownT3.Value & ""
        strSQL &= "," & NumericUpDownR3.Value & ""
        strSQL &= ",'" & LabelW3.Text & "'"
        strSQL &= ",'" & ComboBoxC3.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "4"
        strSQL &= "," & NumericUpDownT4.Value & ""
        strSQL &= "," & NumericUpDownR4.Value & ""
        strSQL &= ",'" & LabelW4.Text & "'"
        strSQL &= ",'" & ComboBoxC4.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "5"
        strSQL &= "," & NumericUpDownT5.Value & ""
        strSQL &= "," & NumericUpDownR5.Value & ""
        strSQL &= ",'" & LabelW5.Text & "'"
        strSQL &= ",'" & ComboBoxC5.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "6"
        strSQL &= "," & NumericUpDownT6.Value & ""
        strSQL &= "," & NumericUpDownR6.Value & ""
        strSQL &= ",'" & LabelW6.Text & "'"
        strSQL &= ",'" & ComboBoxC6.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "7"
        strSQL &= "," & NumericUpDownT7.Value & ""
        strSQL &= "," & NumericUpDownR7.Value & ""
        strSQL &= ",'" & LabelW7.Text & "'"
        strSQL &= ",'" & ComboBoxC7.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)


        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "8"
        strSQL &= "," & NumericUpDownT8.Value & ""
        strSQL &= "," & NumericUpDownR8.Value & ""
        strSQL &= ",'" & LabelW8.Text & "'"
        strSQL &= ",'" & ComboBoxC8.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "9"
        strSQL &= "," & NumericUpDownT9.Value & ""
        strSQL &= "," & NumericUpDownR9.Value & ""
        strSQL &= ",'" & LabelW9.Text & "'"
        strSQL &= ",'" & ComboBoxC9.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)

        strSQL = "INSERT INTO  " & schema & "m_matomewari_seq (seq, kazu, waribiki, tani, syurui , matomecd) VALUES("
        strSQL &= "10"
        strSQL &= "," & NumericUpDownT10.Value & ""
        strSQL &= "," & NumericUpDownR10.Value & ""
        strSQL &= ",'" & LabelW10.Text & "'"
        strSQL &= ",'" & ComboBoxC10.Text & "'"
        strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"

        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)


        strSQL = "delete from " & schema & "m_matomewari_cd where  matomecd = "
        strSQL &= "'" & Me.ToolStripMenuItem1.Text & "'"
        ClassPostgeDB.EXEC(strSQL)

        For i = 0 To ListBox1.Items.Count - 1

            strSQL = "INSERT INTO " & schema & "m_matomewari_cd (sinacd , matomeno, matomecd ) VALUES('" & ListBox1.Items(i) & "'"
            strSQL &= ",'" & Me.TextBoxまとめ買い割引コード.Text & "'"
            strSQL &= ",'" & Me.ToolStripMenuItem1.Text & "'"
            strSQL &= ")"

            ClassPostgeDB.EXEC(strSQL)
        Next

        MessageBox.Show("更新しました")
        ObjClera()
        matomecd()

    End Sub

    Private Sub ObjClera()
        Me.RadioButton割引率.Checked = True

        NumericUpDownT1.Value = "0"
        NumericUpDownR1.Value = "0"
        LabelW1.Text = "％"
        ComboBoxC1.SelectedIndex = -1

        NumericUpDownT2.Value = "0"
        NumericUpDownR2.Value = "0"
        LabelW2.Text = "％"
        ComboBoxC2.SelectedIndex = -1

        NumericUpDownT3.Value = "0"
        NumericUpDownR3.Value = "0"
        LabelW3.Text = "％"
        ComboBoxC3.SelectedIndex = -1

        NumericUpDownT4.Value = "0"
        NumericUpDownR4.Value = "0"
        LabelW4.Text = "％"
        ComboBoxC4.SelectedIndex = -1

        NumericUpDownT5.Value = "0"
        NumericUpDownR5.Value = "0"
        LabelW5.Text = "％"
        ComboBoxC5.SelectedIndex = -1

        NumericUpDownT6.Value = "0"
        NumericUpDownR6.Value = "0"
        LabelW6.Text = "％"
        ComboBoxC6.SelectedIndex = -1

        NumericUpDownT7.Value = "0"
        NumericUpDownR7.Value = "0"
        LabelW7.Text = "％"
        ComboBoxC7.SelectedIndex = -1

        NumericUpDownT8.Value = "0"
        NumericUpDownR8.Value = "0"
        LabelW8.Text = "％"
        ComboBoxC8.SelectedIndex = -1

        NumericUpDownT9.Value = "0"
        NumericUpDownR9.Value = "0"
        LabelW9.Text = "％"
        ComboBoxC9.SelectedIndex = -1

        NumericUpDownT10.Value = "0"
        NumericUpDownR10.Value = "0"
        LabelW10.Text = "％"
        ComboBoxC10.SelectedIndex = -1

        ListBox1.Items.Clear()
        '--- 23.11.30 k.s start ---
        Me.Label品コード取込み.Text = ""
        '--- 23.11.30 k.s end ---
    End Sub

    Private Sub SetDIsp(i As Integer, row As DataRow)
        Select Case i
            Case 1
                NumericUpDownT1.Value = row(1)
                NumericUpDownR1.Value = row(2)
                LabelW1.Text = row(3)
                ComboBoxC1.Text = row(4)
                If LabelW1.Text = "％" Then
                    Me.RadioButton割引率.Checked = True
                Else
                    Me.RadioButton割引額.Checked = True
                End If
            Case 2
                NumericUpDownT2.Value = row(1)
                NumericUpDownR2.Value = row(2)
                LabelW2.Text = row(3)
                ComboBoxC2.Text = row(4)

            Case 3
                NumericUpDownT3.Value = row(1)
                NumericUpDownR3.Value = row(2)
                LabelW3.Text = row(3)
                ComboBoxC3.Text = row(4)
            Case 4
                NumericUpDownT4.Value = row(1)
                NumericUpDownR4.Value = row(2)
                LabelW4.Text = row(3)
                ComboBoxC4.Text = row(4)
            Case 5
                NumericUpDownT5.Value = row(1)
                NumericUpDownR5.Value = row(2)
                LabelW5.Text = row(3)
                ComboBoxC5.Text = row(4)
            Case 6
                NumericUpDownT6.Value = row(1)
                NumericUpDownR6.Value = row(2)
                LabelW6.Text = row(3)
                ComboBoxC6.Text = row(4)
            Case 7
                NumericUpDownT7.Value = row(1)
                NumericUpDownR7.Value = row(2)
                LabelW7.Text = row(3)
                ComboBoxC7.Text = row(4)
            Case 8
                NumericUpDownT8.Value = row(1)
                NumericUpDownR8.Value = row(2)
                LabelW8.Text = row(3)
                ComboBoxC8.Text = row(4)
            Case 9
                NumericUpDownT9.Value = row(1)
                NumericUpDownR9.Value = row(2)
                LabelW9.Text = row(3)
                ComboBoxC9.Text = row(4)
            Case 10
                NumericUpDownT10.Value = row(1)
                NumericUpDownR10.Value = row(2)
                LabelW10.Text = row(3)
                ComboBoxC10.Text = row(4)

        End Select
    End Sub

    Private Sub disp()
        Dim strSQL As String
        Dim dt As New DataTable
        Dim i As Integer

        Me.ListBox1.Items.Clear()
        '--- 23.11.30 k.s start ---
        Me.Label品コード取込み.Text = ""
        '--- 23.11.30 k.s end ---

        strSQL = "Select * from " & schema & "m_matomewari_cd where  matomecd = '" & Me.ToolStripMenuItem1.Text & "' order by  sinacd"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Me.ListBox1.Items.Add(row("sinacd").ToString)
            Next
        End If

        strSQL = "Select * from " & schema & "m_matomewari_seq  where matomecd = '" & Me.ToolStripMenuItem1.Text & "' order by seq asc"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            i = 1
            For Each row As DataRow In dt.Rows
                SetDIsp(i, row)
                i = i + 1
            Next
        End If

    End Sub
    Private Sub matomecd()
        Dim strSQL As String
        Dim dt As New DataTable

        Me.ListBox2.Items.Clear()

        strSQL = "SELECT  matomeno, matomecd FROM  " & schema & "m_matomewari_cd group by matomeno, matomecd  order by matomecd asc"
        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Me.ListBox2.Items.Add(row(0))
            Next
        End If

        '--- 23.11.30 k.s start ---
        Me.Label品コード取込み.Text = ""
        '--- 23.11.30 k.s end ---

    End Sub

    Private Sub FormMstDaisuWaribiki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        matomecd()
    End Sub

    Private Sub ListBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDown
        Dim strSQL As String
        ' 選択されているインデックスを取得する
        Dim idx As Integer = Me.ListBox2.SelectedIndex
        If idx >= 0 Then
            Me.TextBoxまとめ買い割引コード.Text = Me.ListBox2.SelectedItem.ToString
            strSQL = "SELECT matomecd FROM " & schema & "m_matomewari_cd where matomeno= '" & Me.TextBoxまとめ買い割引コード.Text & "' limit 1"
            Me.ToolStripMenuItem1.Text = ClassPostgeDB.DbSel(strSQL)
            disp()
        End If

    End Sub
    Private Sub 削除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 削除ToolStripMenuItem.Click
        Dim strSQL As String
        If Me.ToolStripMenuItem1.Text <> "0" Then
            strSQL = "DELETE FROM " & schema & "m_matomewari_cd WHERE matomecd='" & Me.ToolStripMenuItem1.Text & "' "
            ClassPostgeDB.EXEC(strSQL)
            strSQL = "DELETE FROM " & schema & "m_matomewari_seq WHERE matomecd='" & Me.ToolStripMenuItem1.Text & "' "
            ClassPostgeDB.EXEC(strSQL)
            ObjClera()
            matomecd()
        End If
    End Sub

    Private Sub 新規ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新規ToolStripMenuItem.Click
        Me.ToolStripMenuItem1.Text = "0"
        '--- 23.11.30 k.s start ---
        Me.ListBox1.Items.Clear()
        Me.TextBoxまとめ買い割引コード.Text = ""
        '--- 23.11.30 k.s end ---
    End Sub


    '============================
    '品コード取込み
    '23.11.30 k.s
    '============================
    Private Sub Button取込み_Click(sender As Object, e As EventArgs) Handles Button取込み.Click
        Dim filename As String
        Dim rw As Integer

        filename = Filesentaku(MaserFolder)

        If filename <> "" Then
            Me.ListBox1.Items.Clear()
            Me.Label品コード取込み.Text = ""
            Using parser As New TextFieldParser(filename, Encoding.GetEncoding("Shift_JIS"))
                ' カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")
                ' フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
                ' フィールドの空白トリム設定
                parser.TrimWhiteSpace = False

                Try
                    rw = 0
                    While Not parser.EndOfData
                        'フィールドを読込
                        Dim row As String() = parser.ReadFields()
                        If rw > 0 Then
                            '1行目はヘッダー、2行目のからリストボックスへ
                            Me.ListBox1.Items.Add(row(0).ToString)
                        End If
                        rw = rw + 1
                    End While
                    Me.Label品コード取込み.Text = rw - 1 & "件　取り込み"
                Catch ex As Exception
                    MessageBox.Show("取り込みエラーです")
                    Return
                End Try
                parser.Close()

            End Using
        End If
    End Sub
End Class