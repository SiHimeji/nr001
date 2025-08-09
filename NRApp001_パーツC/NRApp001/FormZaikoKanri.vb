Imports System.ComponentModel

Public Class FormZaikoKanri
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
    Dim Souko As DataTable

    Private Sub FormZaiko_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ToolStripStatusLabel1.Text = ""
        ClassPostgeDB.SetComboBox(Me.ComboBox倉庫, "select ms.naiyou from m_system ms where ms.kbn ='2' order by ms.seq ")
        Me.ComboBoxJy.Items.Clear()
        Me.ComboBoxJy.Items.Add("")
        Me.ComboBoxJy.Items.Add("一致")
        Me.ComboBoxJy.Items.Add("一部")
        Me.ComboBoxJy.Items.Add("前方")
        Me.ComboBoxJy.Items.Add("後方")
        Me.ComboBoxJy.SelectedIndex = 0

        Dim strSQL As String
        strSQL = "select ms.naiyou ,ms.naiyou2  from m_system ms where ms.kbn ='2'  order by ms.seq "
        Souko = ClassPostgeDB.SetTable(strSQL)


    End Sub

    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click
        Close()
    End Sub
    Private Sub Button希望納期_Click(sender As Object, e As EventArgs) Handles Button希望納期.Click
        Cursor.Current = Cursors.WaitCursor
        Me.ToolStripStatusLabel1.Text = "再計算中"
        System.Windows.Forms.Application.DoEvents()
        SaiKeisan()
        Me.TextBox品コード.Text = ""
        DIsp(1)
        Me.ToolStripStatusLabel1.Text = ""
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub SaiKeisan()
        Dim strSQL As String
        Dim tday As Date = Now

        strSQL = "select sinacd,kijunzaiko,ruuru,kobetu ,inputkbn from " & schema & "m_seihin  where sinacd in ( select sinacd from " & schema & "t_idou_zaiko )"
        Dim dt As DataTable = ClassPostgeDB.SetTable(strSQL)
        For Each dtSeihin In dt.Rows

            strSQL = "UPDATE  " & schema & "t_idou_zaiko  SET "

            If IsNumeric(dtSeihin(1).ToString) Then
                strSQL &= " kijunnzaiko  = '" & dtSeihin(1).ToString & "'"
            Else
                strSQL &= " kijunnzaiko  = '0'"
            End If

            If dtSeihin(3).ToString = "1" Then
                strSQL &= " , ruuru  = '個別'"
            ElseIf dtSeihin(2).ToString <> "" Then
                If dtSeihin(2).ToString = "0" Then
                    strSQL &= " , ruuru  = ''"
                Else
                    strSQL &= " , ruuru  = '" & dtSeihin(2).ToString & "'"

                End If
            Else
                strSQL &= " , ruuru  = ''"
            End If
            strSQL &= " , souko  = '" & dtSeihin(4).ToString & "'"

            strSQL &= " , kibounouki = '" & tday.AddDays(ExSouko(dtSeihin(4).ToString)).ToShortDateString & "'"


            strSQL &= " , updateday  = now()"
            strSQL &= " , updatesya   = '" & UserName & "'"
            strSQL &= " where sinacd ='" & dtSeihin(0).ToString & "'"
            ClassPostgeDB.EXEC(strSQL)

        Next
        strSQL = "update  " & schema & "t_idou_zaiko set  hojyusuu = COALESCE(kijunnzaiko,0)- COALESCE(zaikosuu,0) - COALESCE(jyutyuusuu,0)"
        ClassPostgeDB.EXEC(strSQL)

        KosuuRuuru()

        strSQL = "update  " & schema & "t_idou_zaiko set  hojyusuu = 0 where hojyusuu <0"
        ClassPostgeDB.EXEC(strSQL)
    End Sub

    Private Sub KosuuRuuru()
        Dim strSQL As String
        Dim dt As DataTable
        Dim hojyusuu As Integer = 0
        Dim rurusu As Integer = 0
        Dim jyutyuusu As Integer = 0


        strSQL = " select  sinacd ,ruuru  ,kijunnzaiko,  COALESCE(zaikosuu,0) zaikosuu  ,  COALESCE(jyutyuusuu,0) jyutyuusuu ,  COALESCE(hojyusuu,0)  hojyusuu "
        strSQL &= " FROM " & schema & "t_idou_zaiko "
        strSQL &= " where ruuru  <> '' and ruuru <>'個別' and ruuru <>'0' and hojyusuu >0"
        strSQL &= " order by sinacd "

        dt = ClassPostgeDB.SetTable(strSQL)

        For Each dtrow In dt.Rows

            jyutyuusu = 0
            rurusu = Integer.Parse(dtrow(1).ToString)
            hojyusuu = Integer.Parse(dtrow(5).ToString)

            While jyutyuusu < hojyusuu
                jyutyuusu = jyutyuusu + rurusu
            End While

            strSQL = "UPDATE " & schema & "t_idou_zaiko  SET hojyusuu  =" & jyutyuusu & " WHERE  sinacd = '" & dtrow(0).ToString & "'"
            ClassPostgeDB.EXEC(strSQL)

        Next


    End Sub

    Private Function ExSouko(soukonm As String)
        For Each dd In Souko.Rows
            If dd(0) = soukonm Then
                Return (Integer.Parse(dd(1).ToString()))
            End If
        Next
        Return (0)
    End Function


    Private Sub Button品コード検索_Click(sender As Object, e As EventArgs) Handles Button品コード検索.Click
        FormSelectSeihin.SinaCD = Me.TextBox品コード.Text

        If FormSelectSeihin.ShowDialog() = DialogResult.OK Then
            'MessageBox.Show(Fm.SeihinName)
            Me.TextBox品コード.Text = FormSelectSeihin.SinaCD
            Me.TextBox品名.Text = FormSelectSeihin.SeihinName
            FormSelectSeihin.Dispose()
        End If

        FormSelectSeihin.Dispose()

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        DIsp(1)
    End Sub
    Private Sub DIsp(sw As Integer)
        Dim strSQL As Text.StringBuilder = New Text.StringBuilder
        Dim dt As DataTable
        Dim ro As Integer

        strSQL.Clear()
        strSQL.AppendLine("SELECT sinacd,sinamei,  COALESCE(kijunnzaiko,0)  kijunnzaiko,  COALESCE(zaikosuu,0) zaikosuu, COALESCE(jyutyuusuu,0) jyutyuusuu, COALESCE(hojyusuu,0) hojyusuu ")
        strSQL.AppendLine(" ,souko,bikou,ruuru ")
        strSQL.AppendLine(" ,entryday,entrysya,updateday,updatesya , kibounouki")
        strSQL.AppendLine("  FROM " & schema & "t_idou_zaiko ")


        If sw = 1 Then

            If Me.TextBox品コード.Text = "" Then
                Me.ComboBoxJy.SelectedIndex = 0
            End If

            Select Case Me.ComboBoxJy.Text
                Case "一致"
                    strSQL.AppendLine(" WHERE   sinacd = '" & Me.TextBox品コード.Text & "'")
                Case "一部"
                    strSQL.AppendLine(" WHERE   sinacd  LIKE '%" & Me.TextBox品コード.Text & "%'")
                Case "前方"
                    strSQL.AppendLine(" WHERE   sinacd LIKE '" & Me.TextBox品コード.Text & "%'")
                Case "後方"
                    strSQL.AppendLine(" WHERE   sinacd LIKE '%" & Me.TextBox品コード.Text & "'")
                Case Else
                    'MessageBox.Show("条件を設定して下さい")
                    'Return
            End Select
        ElseIf sw = 2 Then
            strSQL.AppendLine(" WHERE  hojyusuu > 0  ")

        End If
        strSQL.AppendLine(" order by sinacd ")


        If zenkaiSQL = "" Then
            zenkaiSQL = strSQL.ToString
        Else

        End If


        dt = ClassPostgeDB.SetTable(strSQL.ToString)

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.Columns.Clear()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dt


        ro = 0
        ro = SettextColumn(Me.DataGridView1, ro, "sinacd", "品コード", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "sinamei", "品名", 320, True)

        ro = SettextColumn(Me.DataGridView1, ro, "kijunnzaiko", "基準在庫", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "zaikosuu", "在庫数", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "jyutyuusuu", "受注中", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "hojyusuu", "補充数", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "ruuru", "ルール", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "souko", "倉庫", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "kibounouki", "希望納期", 100, True)
        ro = SettextColumn(Me.DataGridView1, ro, "bikou", "備考", 200, True)


        Me.DataGridView1.AllowUserToAddRows = False

    End Sub


    Public Function SettextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean) As Integer

        Dim textColumn As New DataGridViewTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        ro = ro + 1
        Return ro

    End Function

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        Dim strSQL As Text.StringBuilder = New Text.StringBuilder
        Dim dt As DataTable
        strSQL.Clear()
        strSQL.AppendLine("select  count(t.sinacd) from " & schema & "t_idou_zaiko  t where t.sinacd ='" & Me.TextBox品コード.Text & "'")
        dt = ClassPostgeDB.SetTable(strSQL.ToString)

        Dim f_ins As Boolean = True

        If dt.Rows.Count = 0 Then
            f_ins = True
        Else
            If dt.Rows(0).Item(0).ToString = "0" Then
                f_ins = True
            Else
                f_ins = False
            End If
        End If


        strSQL.Clear()
        If f_ins Then

            strSQL.AppendLine("INSERT INTO " & schema & "t_idou_zaiko ")
            strSQL.AppendLine("(sinacd, sinamei, kijunnzaiko, zaikosuu, jyutyuusuu, hojyusuu,  souko, bikou ,entryday,entrysya,updateday,updatesya,kibounouki)VALUES(")
            strSQL.AppendLine("'" & Me.TextBox品コード.Text & "'")
            strSQL.AppendLine(", '" & Me.TextBox品名.Text & "'")
            strSQL.AppendLine(", '" & Me.NumericUpDown基準.Value.ToString & "'")
            strSQL.AppendLine(", '" & Me.NumericUpDown現在庫.Value.ToString & "'")
            strSQL.AppendLine(", '" & Me.NumericUpDown受注中.Value.ToString & "'")
            strSQL.AppendLine(", '" & Me.NumericUpDown補充数.Value.ToString & "'")
            strSQL.AppendLine(", '" & Me.ComboBox倉庫.Text & "'")
            strSQL.AppendLine(", '" & Me.TextBox備考.Text & "'")
            strSQL.AppendLine(", now()")
            strSQL.AppendLine(", '" & UserName & "'")
            strSQL.AppendLine(", now()")
            strSQL.AppendLine(", '" & Me.DateTimePicker希望納期.Value & "'")
            strSQL.AppendLine(", '" & UserName & "'")
            strSQL.AppendLine(")")

        Else

            strSQL.AppendLine("UPDATE " & schema & "t_idou_zaiko ")
            strSQL.AppendLine("SET sinamei='" & Me.TextBox品名.Text & "'")
            strSQL.AppendLine(", kijunnzaiko='" & Me.NumericUpDown基準.Value.ToString & "'")
            strSQL.AppendLine(", zaikosuu='" & Me.NumericUpDown現在庫.Value.ToString & "'")
            strSQL.AppendLine(", jyutyuusuu='" & Me.NumericUpDown受注中.Value.ToString & "'")
            strSQL.AppendLine(", hojyusuu='" & Me.NumericUpDown補充数.Value.ToString & "'")
            strSQL.AppendLine(", souko='" & Me.ComboBox倉庫.Text & "'")
            strSQL.AppendLine(", kibounouki='" & Me.DateTimePicker希望納期.Value & "'")
            strSQL.AppendLine(", bikou='" & Me.TextBox備考.Text & "'")
            strSQL.AppendLine(", updateday= now()")
            strSQL.AppendLine(", updatesya='" & UserName & "'")
            strSQL.AppendLine(" WHERE sinacd='" & Me.TextBox品コード.Text & "'")
        End If
        ClassPostgeDB.EXEC(strSQL.ToString)

        MessageBox.Show("更新しました")
        DIsp(1)
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

        Dim ro As Integer
        Dim co As Integer
        Dim d As Integer

        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            co = Me.DataGridView1.CurrentCell.ColumnIndex

            If ro >= 0 Then
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value.ToString
                Me.TextBox品名.Text = Me.DataGridView1.Rows(ro).Cells(1).Value.ToString
                Me.NumericUpDown基準.Value = Me.DataGridView1.Rows(ro).Cells(2).Value.ToString
                Me.NumericUpDown現在庫.Value = Me.DataGridView1.Rows(ro).Cells(3).Value.ToString

                Me.NumericUpDown受注中.Value = Me.DataGridView1.Rows(ro).Cells(4).Value.ToString
                Me.NumericUpDown補充数.Value = Me.DataGridView1.Rows(ro).Cells(5).Value.ToString

                Me.TextBoxルール.Text = Me.DataGridView1.Rows(ro).Cells(6).Value.ToString
                If Integer.TryParse(Me.TextBoxルール.Text, d) Then
                    If Integer.Parse(Me.TextBoxルール.Text) > 0 Then

                    Else
                        Me.TextBoxルール.Text = ""
                    End If
                End If



                Me.ComboBox倉庫.Text = Me.DataGridView1.Rows(ro).Cells(7).Value.ToString
                If Me.DataGridView1.Rows(ro).Cells(8).Value.ToString = "" Then

                Else
                    Me.DateTimePicker希望納期.Value = Me.DataGridView1.Rows(ro).Cells(8).Value.ToString
                End If


                Me.TextBox備考.Text = Me.DataGridView1.Rows(ro).Cells(9).Value.ToString
            End If
        End If
    End Sub

    Private Sub NEXTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NEXTToolStripMenuItem.Click
        excelOutDataGredV2(Me.DataGridView1)
    End Sub

    Private Sub Button補充数１以上_Click(sender As Object, e As EventArgs) Handles Button補充数１以上.Click
        DIsp(2)
    End Sub


End Class