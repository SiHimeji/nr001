Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices

Public Class Form物件管理
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB()
    Dim ZednkaiSQL As String = String.Empty

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
    Private Sub Form物件管理_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = Me.Text & " Version[" & Ver & "] " & vAsm.v説明
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報

        GetSystemtoCombo("'30'", Me.ComboBoxJy, "")
        GetSystemtoCombo("'40'", Me.ComboBox請求方法, "")
        GetSystemtoCombo("'50'", Me.ComboBox点検結果表請求書同封, "")
        GetSystemtoCombo("'60'", Me.ComboBox点検時写真, "")
        GetSystemtoCombo("'70'", Me.ComboBox点検結果票変更, "")
        GetSystemtoCombo("'80'", Me.ComboBox請求書, "")

    End Sub
    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click


        Dim excelApp As New Excel.Application()
        Dim excelBooks As Excel.Workbooks
        excelBooks = excelApp.Workbooks

        Dim colloop As Integer
        Dim rowloop As Integer

        Dim strSQL As String

        Dim clburando As Integer = 0
        Dim cl入力日 As Integer = 0
        Dim cl入力者 As Integer = 0
        Dim cl依頼元会社名 As Integer = 0
        Dim cl依頼元部署名 As Integer = 0
        Dim cl依頼元担当者名 As Integer = 0
        Dim cl依頼元電話番号 As Integer = 0
        Dim cl依頼元FAX番号 As Integer = 0
        Dim cl請求書送付先名 As Integer = 0
        Dim cl請求書送付先住所 As Integer = 0
        Dim cl請求書宛名 As Integer = 0
        Dim cl台数 As Integer = 0
        Dim cl工期開始日 As Integer = 0
        Dim cl工期終了日 As Integer = 0
        Dim cl請求備考 As Integer = 0
        Dim cl請求方法 As Integer = 0
        Dim cl請求締日 As Integer = 0
        Dim cl請求書 As Integer = 0
        Dim cl業務完了届 As Integer = 0
        Dim cl点検結果表請求書同封 As Integer = 0
        Dim cl点検時写真 As Integer = 0
        Dim cl請求書納期 As Integer = 0
        Dim clメモ As Integer = 0
        Dim cl請求書送付先会社名 As Integer = 0
        Dim cl請求書送付先担当者 As Integer = 0
        Dim cl請求送付先郵便番号 As Integer = 0
        Dim cl請求送付先電話番号 As Integer = 0
        Dim cl点検結果票変更 As Integer = 0
        Dim cl点検時写真メモ As Integer = 0
        Dim cl完了 As Integer = 0
        Dim cl完了登録日 As Integer


        Dim wburando As String

        Dim ret As String

        Dim TextBoxFileName1 As String

        GetIniFile()
        TextBoxFileName1 = FilesentakuEXELS(ZaikoFolder)

        If TextBoxFileName1 = "" Then Exit Sub
        ZaikoFolder = TextBoxFileName1

        Dim excelBook As Excel.Workbook = excelBooks.Open(TextBoxFileName1)
        Dim sheet As Excel.Worksheet = excelBook.Worksheets(1)
#If DEBUG Then
        excelApp.Visible = True
#Else
        excelApp.Visible = false
#End If
        Try
            colloop = 1
            While sheet.Cells(1, colloop).value <> Nothing
                Select Case sheet.Cells(1, colloop).value
                    Case "NO"
                        clburando = colloop
                    Case "入力日"
                        cl入力日 = colloop
                    Case "入力者"
                        cl入力者 = colloop
                    Case "依頼元会社名"
                        cl依頼元会社名 = colloop
                    Case "依頼元部署名"
                        cl依頼元部署名 = colloop
                    Case "依頼元担当者名"
                        cl依頼元担当者名 = colloop
                    Case "依頼元電話番号"
                        cl依頼元電話番号 = colloop
                    Case "依頼元fax番号"
                        cl依頼元FAX番号 = colloop

                    Case "請求書送付先名"
                        cl請求書送付先名 = colloop
                    Case "請求書送付先会社名"
                        cl請求書送付先会社名 = colloop


                    Case "請求書送付先住所"
                        cl請求書送付先住所 = colloop
                    Case "請求書宛名"
                        cl請求書宛名 = colloop
                    Case "台数"
                        cl台数 = colloop

                    Case "工期（開始日）"
                        cl工期開始日 = colloop
                    Case "工期開始日"
                        cl工期開始日 = colloop
                    Case "工期（終了日）"
                        cl工期終了日 = colloop
                    Case "工期終了日"
                        cl工期終了日 = colloop

                    Case "請求備考"
                        cl請求備考 = colloop
                    Case "請求方法"
                        cl請求方法 = colloop
                    Case "請求締日"
                        cl請求締日 = colloop
                    Case "請求書"
                        cl請求書 = colloop
                    Case "業務完了届"
                        cl業務完了届 = colloop
                    Case "点検結果表請求書同封"
                        cl点検結果表請求書同封 = colloop
                    Case "点検時写真"
                        cl点検時写真 = colloop
                    Case "請求書納期"
                        cl請求書納期 = colloop
                    Case "メモ"
                        clメモ = colloop
                    Case "請求書送付先担当者"
                        cl請求書送付先担当者 = colloop
                    Case "請求送付先郵便番号"
                        cl請求送付先郵便番号 = colloop
                    Case "請求送付先電話番号"
                        cl請求送付先電話番号 = colloop
                    Case "点検結果票変更"
                        cl点検結果票変更 = colloop
                    Case "点検時写真メモ"
                        cl点検時写真メモ = colloop
                    Case "完了"
                        cl完了 = colloop
                    Case "完了登録日"
                        cl完了登録日 = colloop
                End Select
                colloop = colloop + 1
            End While


            If cl請求書送付先会社名 <> 0 Then
                cl請求書送付先名 = cl請求書送付先会社名
            End If


            If cl入力日 = 0 Or clburando = 0 Then
                MessageBox.Show("フォーマットが違います")
                Exit Sub
            End If

            rowloop = 2
            While sheet.Cells(rowloop, clburando).value <> Nothing
                rowloop = rowloop + 1
            End While
            Me.ToolStripProgressBar1.Maximum = rowloop
            Me.ToolStripProgressBar1.Step = 1

            rowloop = 2
            While sheet.Cells(rowloop, clburando).value <> Nothing
                Try
                    If sheet.Cells(rowloop, clburando).value Then
                        wburando = sheet.Cells(rowloop, clburando).value

                        strSQL = "delete from " & schema & "t_bukken where burando= '" & wburando & "'"
                        ClassPostgeDB.EXEC(strSQL)
                    Else
                        wburando = ""
                    End If

                    strSQL = ""
                    strSQL &= "INSERT INTO " & schema & "t_bukken (burando, 入力日, 入力者"

                    strSQL &= ", 依頼元会社名, 依頼元部署名, 依頼元担当者名, 依頼元電話番号, 依頼元fax番号"
                    strSQL &= ", 請求書送付先会社名, 請求書送付先担当者, 請求書送付先住所, 請求書宛名, 請求送付先郵便番号, 請求送付先電話番号"
                    strSQL &= ", 台数, 工期開始日, 工期終了日, 請求方法, 請求書納期, 請求締日, 請求書, 請求備考, メモ, 点検結果表請求書同封"
                    strSQL &= ", 点検結果票変更, 点検時写真, 点検時写真メモ, 完了,完了登録日, entry_day, update_day, entry_sya, del_flg) VALUES("

                    If wburando <> "" Then
                        strSQL &= "'" & wburando & "'"
                    Else
                        strSQL &= "nextval('" & schema & "seqbukken')"
                    End If
                    If cl入力日 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl入力日).value & "'" Else strSQL &= ",''"
                    If cl入力者 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl入力者).value & "'" Else strSQL &= ",''"

                    If cl依頼元会社名 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl依頼元会社名).value & "'" Else strSQL &= ",''"
                    If cl依頼元部署名 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl依頼元部署名).value & "'" Else strSQL &= ",''"
                    If cl依頼元担当者名 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl依頼元担当者名).value & "'" Else strSQL &= ",''"
                    If cl依頼元電話番号 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl依頼元電話番号).value & "'" Else strSQL &= ",''"
                    If cl依頼元FAX番号 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl依頼元FAX番号).value & "'" Else strSQL &= ",''"

                    If cl請求書送付先名 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求書送付先名).value & "'" Else strSQL &= ",''"
                    If cl請求書送付先担当者 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求書送付先担当者).value & "'" Else strSQL &= ",''"

                    If cl請求書送付先住所 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求書送付先住所).value & "'" Else strSQL &= ",''"
                    If cl請求書宛名 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求書宛名).value & "'" Else strSQL &= ",''"
                    If cl請求送付先郵便番号 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求送付先郵便番号).value & "'" Else strSQL &= ",''"
                    If cl請求送付先電話番号 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求送付先電話番号).value & "'" Else strSQL &= ",''"

                    If cl台数 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl台数).value & "'" Else strSQL &= ",''"
                    If cl工期開始日 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl工期開始日).value & "'" Else strSQL &= ",''"
                    If cl工期終了日 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl工期終了日).value & "'" Else strSQL &= ",''"

                    If cl請求方法 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求方法).value & "'" Else strSQL &= ",''"
                    If cl請求書納期 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求書納期).value & "'" Else strSQL &= ",''"
                    If cl請求締日 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求締日).value & "'" Else strSQL &= ",''"
                    If cl請求書 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求書).value & "'" Else strSQL &= ",''"
                    If cl請求備考 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl請求備考).value & "'" Else strSQL &= ",''"
                    If clメモ <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, clメモ).value & "'" Else strSQL &= ",''"
                    If cl点検結果表請求書同封 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl点検結果表請求書同封).value & "'" Else strSQL &= ",''"
                    If cl点検結果票変更 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl点検結果票変更).value & "'" Else strSQL &= ",''"

                    If cl点検時写真 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl点検時写真).value & "'" Else strSQL &= ",''"
                    If cl点検時写真メモ <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl点検時写真メモ).value & "'" Else strSQL &= ",''"
                    If cl完了 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl完了).value & "'" Else strSQL &= ",'0'"
                    If cl完了登録日 <> 0 Then strSQL &= ",'" & sheet.Cells(rowloop, cl完了登録日).value & "'" Else strSQL &= ",''"


                    strSQL &= ",now()"
                    strSQL &= ",now()"
                    strSQL &= ",'" & UserName & "'"
                    strSQL &= ",'0'"
                    strSQL &= ")"

                    ClassPostgeDB.EXEC(strSQL)

                Catch ex As Exception
                    excelApp.Visible = True
                    MessageBox.Show("取り込みエラーです")
                    excelApp.Quit()
                    Return
                End Try

                rowloop = rowloop + 1
                Me.ToolStripProgressBar1.Value = rowloop
                System.Windows.Forms.Application.DoEvents()
            End While

            excelApp.Visible = True

            strSQL = "select max(burando)+1 from " & schema & "t_bukken "
            ret = ClassPostgeDB.DbSel(strSQL)
            strSQL = "ALTER SEQUENCE tenken.seqbukken RESTART " & ret & ""
            ClassPostgeDB.EXEC(strSQL)

            Using f As New Form()
                f.TopMost = True ' 親フォームを常に最前面に表示する
                MessageBox.Show(f, "取り込み完了しました")
                f.TopMost = False
            End Using

        Catch ex As Exception
            Throw ex
        Finally
            'オブジェクト解放
            excelApp.Quit()
            Marshal.ReleaseComObject(excelApp)
            Marshal.ReleaseComObject(excelBooks)
        End Try
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        Dim strSQL As String
        Dim dt As DataTable
        Dim x As Integer
        If Me.ComboBoxJy.Text = "" Then
            MessageBox.Show("条件が未入力です")
            Exit Sub
        End If
        If Me.ComboBoxJy1.Text = "" Then
            Me.ComboBoxJy1.Text = "一致"
        End If

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Columns.Clear()
        Me.DataGridView1.Rows.Clear()

        dt = Nothing
        strSQL = "Select naiyou"


        strSQL &= " From " & schema & "m_system"
        strSQL &= " where kbn ='30' order by seq"

        dt = ClassPostgeDB.SetTable(strSQL)

        strSQL = ""
        strSQL &= "Select burando as No"

        strSQL &= ", CASE 完了 WHEN '1' THEN '完了' ELSE '' END  完了"

        For x = 0 To dt.Rows.Count - 1
            strSQL &= "," & dt.Rows(x).Item(0).ToString & ""
        Next
        strSQL &= " From " & schema & "t_bukken"
        strSQL &= " where 1=1"

        strSQL &= Set条件()

        strSQL &= " order by burando"


        dt = Nothing
        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = dt
        If Me.DataGridView1.Rows.Count > 0 Then
            Me.DataGridView1.Columns(0).Width = 50
            Me.DataGridView1.Columns(1).Width = 30
            Me.DataGridView1.AllowUserToAddRows = False
        End If

    End Sub
    Private Function Set条件() As String
        Dim strSQL As String

        strSQL = " And (" & Me.ComboBoxJy.Text
        Select Case Me.ComboBoxJy1.Text
            Case "一致"
                strSQL &= " = '" & StrConv(Me.TextBox条件１.Text, VbStrConv.Narrow) & "'"
            Case "部分"
                strSQL &= " like '%" & StrConv(Me.TextBox条件１.Text, VbStrConv.Narrow) & "%'"
            Case "前方"
                strSQL &= " like '" & StrConv(Me.TextBox条件１.Text, VbStrConv.Narrow) & "%'"
            Case "後方"
                strSQL &= " like '%" & StrConv(Me.TextBox条件１.Text, VbStrConv.Narrow) & "'"
        End Select

        strSQL &= " or " & Me.ComboBoxJy.Text
        Select Case Me.ComboBoxJy1.Text
            Case "一致"
                strSQL &= " = '" & StrConv(Me.TextBox条件１.Text, VbStrConv.Wide) & "'"
            Case "部分"
                strSQL &= " like '%" & StrConv(Me.TextBox条件１.Text, VbStrConv.Wide) & "%'"
            Case "前方"
                strSQL &= " like '" & StrConv(Me.TextBox条件１.Text, VbStrConv.Wide) & "%'"
            Case "後方"
                strSQL &= " like '%" & StrConv(Me.TextBox条件１.Text, VbStrConv.Wide) & "'"
        End Select

        strSQL &= " ) "


        If Me.CheckBox完了.Checked Then
            'strSQL &= " and 完了 in('0','1') "
        Else
            strSQL &= " and ( 完了 ='0'  or 完了 ='' or 完了 is null)"
        End If

        Return strSQL
    End Function

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro

        ro = e.RowIndex

        If ro >= 0 And e.Button = MouseButtons.Left Then
            検索No(Me.DataGridView1.Rows(ro).Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub 検索No(NO As String)
        Dim strSQL As String

        strSQL = ""

        strSQL &= "SELECT burando, 入力日, 入力者"
        strSQL &= ", 依頼元会社名, 依頼元部署名, 依頼元担当者名, 依頼元電話番号, 依頼元fax番号"
        strSQL &= ", 請求書送付先会社名, 請求書送付先担当者, 請求書送付先住所, 請求書宛名, 請求送付先郵便番号, 請求送付先電話番号"
        strSQL &= ", 台数, 工期開始日, 工期終了日, 請求方法, 請求書納期, 請求締日, 請求書, 請求備考, メモ, 点検結果表請求書同封"
        strSQL &= ", 点検結果票変更, 点検時写真, 点検時写真メモ, 完了"
        strSQL &= ",entry_day,update_day,entry_sya,完了登録日"

        strSQL &= " From " & schema & "t_bukken"
        strSQL &= " where burando = " & NO & ""

        検索(strSQL)
    End Sub


    Private Sub 検索(strSQL As String)
        Dim dt As New DataTable

        ZednkaiSQL = strSQL

        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count = 1 Then
            Me.TextBoxNo.Text = dt.Rows(0).Item(0).ToString
            Me.TextBox入力日.Text = dt.Rows(0).Item(1).ToString
            Me.TextBox入力者.Text = dt.Rows(0).Item(2).ToString


            Me.TextBox依頼元会社名.Text = dt.Rows(0).Item(3).ToString
            Me.TextBox依頼元部署名.Text = dt.Rows(0).Item(4).ToString
            Me.TextBox依頼元担当者名.Text = dt.Rows(0).Item(5).ToString
            Me.TextBox依頼元電話番号.Text = dt.Rows(0).Item(6).ToString
            Me.TextBox依頼元fax番号.Text = dt.Rows(0).Item(7).ToString

            Me.TextBox請求先送付先会社名.Text = dt.Rows(0).Item(8).ToString
            Me.TextBox請求書送付先担当者.Text = dt.Rows(0).Item(9).ToString
            Me.TextBox請求書送付先住所.Text = dt.Rows(0).Item(10).ToString
            Me.TextBox請求書宛名.Text = dt.Rows(0).Item(11).ToString

            Me.TextBox請求送付先郵便番号.Text = dt.Rows(0).Item(12).ToString
            Me.TextBox請求送付先電話番号.Text = dt.Rows(0).Item(13).ToString

            Me.TextBox台数.Text = dt.Rows(0).Item(14).ToString
            Me.TextBox工期開始日.Text = dt.Rows(0).Item(15).ToString
            Me.TextBox工期終了日.Text = dt.Rows(0).Item(16).ToString

            SetComboBox(Me.ComboBox請求方法, dt.Rows(0).Item(17).ToString)
            Me.TextBox請求書納期.Text = dt.Rows(0).Item(18).ToString

            Me.TextBox請求締日.Text = dt.Rows(0).Item(19).ToString
            SetComboBox(Me.ComboBox請求書, dt.Rows(0).Item(20).ToString)
            Me.TextBox請求備考.Text = dt.Rows(0).Item(21).ToString
            Me.TextBoxメモ.Text = dt.Rows(0).Item(22).ToString

            SetComboBox(Me.ComboBox点検結果表請求書同封, dt.Rows(0).Item(23).ToString)
            SetComboBox(Me.ComboBox点検結果票変更, dt.Rows(0).Item(24).ToString)
            SetComboBox(Me.ComboBox点検時写真, dt.Rows(0).Item(25).ToString)
            Me.TextBox点検時写真メモ.Text = dt.Rows(0).Item(26).ToString

            If dt.Rows(0).Item(27).ToString = "1" Then
                Me.CheckBox完了１.Checked = True
                Me.TextBox完了日.Text = dt.Rows(0).Item(31).ToString
            Else
                Me.CheckBox完了１.Checked = False
                Me.TextBox完了日.Text = ""
            End If
            '//
            Me.ToolStripTextBox更新時間.Text = dt.Rows(0).Item(29).ToString


        End If

    End Sub

    Private Sub 新規ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新規ToolStripMenuItem.Click
        Me.TextBoxNo.Text = ""
        Me.TextBox入力日.Text = DateTime.Now.ToString("yyyy/MM/dd")
        Me.TextBox入力者.Text = UserName

        Me.ToolStripTextBox更新時間.Text = ""
        Me.CheckBox完了１.Checked = False
        Me.TextBox完了日.Text = ""

        Clear()
    End Sub
    Private Sub Clear()

        Me.TextBox依頼元会社名.Text = ""
        Me.TextBox依頼元部署名.Text = ""
        Me.TextBox依頼元担当者名.Text = ""
        Me.TextBox依頼元電話番号.Text = ""
        Me.TextBox依頼元fax番号.Text = ""

        Me.TextBox請求先送付先会社名.Text = ""
        Me.TextBox請求書送付先担当者.Text = ""
        Me.TextBox請求送付先郵便番号.Text = ""
        Me.TextBox請求書送付先住所.Text = ""
        Me.TextBox請求書宛名.Text = ""
        Me.TextBox請求送付先電話番号.Text = ""

        Me.TextBox台数.Text = ""
        Me.TextBox工期開始日.Text = ""
        Me.TextBox工期終了日.Text = ""

        Me.ComboBox請求方法.SelectedIndex = -1
        Me.TextBox請求書納期.Text = ""

        Me.TextBox請求締日.Text = ""
        Me.ComboBox請求書.SelectedIndex = -1
        Me.TextBox請求備考.Text = ""
        Me.TextBoxメモ.Text = ""
        Me.ComboBox点検結果表請求書同封.SelectedIndex = -1
        Me.ComboBox点検結果票変更.SelectedIndex = -1
        Me.TextBox点検時写真メモ.Text = ""
        Me.ComboBox点検時写真.SelectedIndex = -1

        Me.TextBox完了日.Text = ""
        Me.CheckBox完了１.Checked = False

    End Sub


    Private Sub CLERAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLERAToolStripMenuItem.Click

        Clear()

        '//
    End Sub

    Private Sub Button更新_Click(sender As Object, e As EventArgs) Handles Button更新.Click
        If Me.TextBoxNo.Text = "" Then
            追加()
        Else
            更新()
        End If
    End Sub
    Private Sub 追加()
        Dim strSQL As String
        strSQL = ""
        'strSQL &= "Select max(burando)+1  From " & schema & "t_bukken "
        strSQL &= "Select nextval('" & schema & "seqbukken') "

        Me.TextBoxNo.Text = ClassPostgeDB.DbSel(strSQL)

        strSQL = ""
        strSQL &= "INSERT INTO " & schema & "t_bukken (burando, 入力日, 入力者"
        strSQL &= ", 依頼元会社名, 依頼元部署名, 依頼元担当者名, 依頼元電話番号, 依頼元fax番号"
        strSQL &= ", 請求書送付先会社名, 請求書送付先担当者, 請求書送付先住所, 請求書宛名, 請求送付先郵便番号, 請求送付先電話番号"
        strSQL &= ", 台数, 工期開始日, 工期終了日, 請求方法, 請求書納期, 請求締日, 請求書, 請求備考, メモ, 点検結果表請求書同封"
        strSQL &= ", 点検結果票変更, 点検時写真, 点検時写真メモ, 完了,完了登録日, entry_day, update_day, entry_sya, del_flg) VALUES("

        strSQL &= " " & Me.TextBoxNo.Text & ""
        strSQL &= ",'" & Me.TextBox入力日.Value & "'"
        strSQL &= ",'" & Me.TextBox入力者.Text & "'"

        strSQL &= ",'" & Me.TextBox依頼元会社名.Text & "'"
        strSQL &= ",'" & Me.TextBox依頼元部署名.Text & "'"
        strSQL &= ",'" & Me.TextBox依頼元担当者名.Text & "'"
        strSQL &= ",'" & Me.TextBox依頼元電話番号.Text & "'"
        strSQL &= ",'" & Me.TextBox依頼元fax番号.Text & "'"

        strSQL &= ",'" & Me.TextBox請求先送付先会社名.Text & "'"
        strSQL &= ",'" & Me.TextBox請求書送付先担当者.Text & "'"
        strSQL &= ",'" & Me.TextBox請求書送付先住所.Text & "'"
        strSQL &= ",'" & Me.TextBox請求書宛名.Text & "'"
        strSQL &= ",'" & Me.TextBox請求送付先郵便番号.Text & "'"
        strSQL &= ",'" & Me.TextBox請求送付先電話番号.Text & "'"

        strSQL &= ",'" & Me.TextBox台数.Text & "'"
        strSQL &= ",'" & Me.TextBox工期開始日.Text & "'"
        strSQL &= ",'" & Me.TextBox工期終了日.Text & "'"
        strSQL &= ",'" & Me.ComboBox請求方法.Text & "'"
        strSQL &= ",'" & Me.TextBox請求書納期.Text & "'"
        strSQL &= ",'" & Me.TextBox請求締日.Text & "'"
        strSQL &= ",'" & Me.ComboBox請求書.Text & "'"
        strSQL &= ",'" & Me.TextBox請求備考.Text & "'"
        strSQL &= ",'" & Me.TextBoxメモ.Text & "'"
        strSQL &= ",'" & Me.ComboBox点検結果表請求書同封.Text & "'"
        strSQL &= ",'" & Me.ComboBox点検結果票変更.Text & "'"
        strSQL &= ",'" & Me.ComboBox点検時写真.Text & "'"
        strSQL &= ",'" & Me.TextBox点検時写真メモ.Text & "'"
        If Me.CheckBox完了１.Checked = True Then
            strSQL &= ",'1',now()"
        Else
            strSQL &= ",'0',null"
        End If

        strSQL &= ",now()"
        strSQL &= ",now()"
        strSQL &= ",'" & UserName & "'"
        strSQL &= ",'0'"
        strSQL &= ")"
        ClassPostgeDB.EXEC(strSQL)
        MessageBox.Show("更新しました")
        検索No(Me.TextBoxNo.Text)

    End Sub
    Private Sub 更新()
        Dim strSQL As String
        Dim tim As String
        strSQL = "Select update_day  "
        strSQL &= " From " & schema & "t_bukken"
        strSQL &= " where burando = " & Me.TextBoxNo.Text & ""

        tim = ClassPostgeDB.DbSel(strSQL)
        If tim = Me.ToolStripTextBox更新時間.Text Then
            strSQL = ""
            strSQL &= "UPDATE " & schema & "t_bukken SET "

            strSQL &= " 入力日 ='" & Me.TextBox入力日.Value & "'"
            strSQL &= ",入力者 ='" & Me.TextBox入力者.Text & "'"

            strSQL &= ",依頼元会社名 ='" & Me.TextBox依頼元会社名.Text & "'"
            strSQL &= ",依頼元部署名 ='" & Me.TextBox依頼元部署名.Text & "'"
            strSQL &= ",依頼元担当者名 = '" & Me.TextBox依頼元担当者名.Text & "'"
            strSQL &= ",依頼元電話番号 = '" & Me.TextBox依頼元電話番号.Text & "'"
            strSQL &= ",依頼元fax番号 = '" & Me.TextBox依頼元fax番号.Text & "'"

            strSQL &= ",請求書送付先会社名 = '" & Me.TextBox請求先送付先会社名.Text & "'"
            strSQL &= ",請求書送付先担当者 = '" & Me.TextBox請求書送付先担当者.Text & "'"
            strSQL &= ",請求書送付先住所 = '" & Me.TextBox請求書送付先住所.Text & "'"
            strSQL &= ",請求書宛名 = '" & Me.TextBox請求書宛名.Text & "'"
            strSQL &= ",請求送付先郵便番号 = '" & Me.TextBox請求送付先郵便番号.Text & "'"
            strSQL &= ",請求送付先電話番号 ='" & Me.TextBox請求送付先電話番号.Text & "'"

            strSQL &= ",台数 = '" & Me.TextBox台数.Text & "'"
            strSQL &= ",工期開始日 = '" & Me.TextBox工期開始日.Text & "'"
            strSQL &= ",工期終了日 = '" & Me.TextBox工期終了日.Text & "'"
            strSQL &= ",請求方法 = '" & Me.ComboBox請求方法.Text & "'"
            strSQL &= ",請求書納期 = '" & Me.TextBox請求書納期.Text & "'"
            strSQL &= ",請求締日 ='" & Me.TextBox請求締日.Text & "'"
            strSQL &= ",請求書 = '" & Me.ComboBox請求書.Text & "'"
            strSQL &= ",請求備考 = '" & Me.TextBox請求備考.Text & "'"
            strSQL &= ",メモ= '" & Me.TextBoxメモ.Text & "'"
            strSQL &= ",点検結果表請求書同封 = '" & Me.ComboBox点検結果表請求書同封.Text & "'"
            strSQL &= ",点検結果票変更= '" & Me.ComboBox点検結果票変更.Text & "'"
            strSQL &= ",点検時写真 = '" & Me.ComboBox点検時写真.Text & "'"
            strSQL &= ",点検時写真メモ = '" & Me.TextBox点検時写真メモ.Text & "'"

            If Me.CheckBox完了１.Checked = True Then
                strSQL &= ", 完了 = '1'"
                strSQL &= ", 完了登録日= now()"
            Else
                strSQL &= ", 完了 = '0'"
                strSQL &= ", 完了登録日= null"
            End If

            'strSQL &= ", entry_day=''"
            strSQL &= ", update_day = now()"
            strSQL &= ", entry_sya='" & UserName & "'"

            strSQL &= " where burando=" & Me.TextBoxNo.Text & ""

            ClassPostgeDB.EXEC(strSQL)

            MessageBox.Show("更新しました")
            検索No(Me.TextBoxNo.Text)
        Else
            MessageBox.Show("データが更新されています。再度検索してください")
        End If
    End Sub
    Private Function outSQL()
        Dim strSQL As String

        strSQL = ""
        strSQL &= "SELECT burando ""NO"", 入力日, 入力者"
        strSQL &= ", 依頼元会社名, 依頼元部署名, 依頼元担当者名, 依頼元電話番号, 依頼元fax番号"
        strSQL &= ", 請求書送付先会社名, 請求書送付先担当者, 請求書送付先住所, 請求書宛名, 請求送付先郵便番号, 請求送付先電話番号"
        strSQL &= ", 台数, 工期開始日, 工期終了日, 請求方法, 請求書納期, 請求締日, 請求書, 請求備考, メモ, 点検結果表請求書同封"
        strSQL &= ", 点検結果票変更, 点検時写真, 点検時写真メモ, 完了,完了登録日"
        strSQL &= ",entry_day,update_day,entry_sya"

        strSQL &= " From " & schema & "t_bukken"
        strSQL &= " where 1=1"


        If Me.CheckBox完了.Checked Then
            'strSQL &= " and 完了 in('0','1') "
        Else
            strSQL &= " and ( 完了 ='0'  or 完了 ='' or 完了 is null)"
        End If

        strSQL &= Set条件()
        strSQL &= " order by burando"

        Return strSQL

    End Function

    Private Sub EXCELToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem1.Click
        Dim dt As New DataTable
        dt = Nothing
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.DataGridView2.DataSource = Nothing

        dt = ClassPostgeDB.SetTable(outSQL())
        Me.DataGridView2.DataSource = dt
        Me.DataGridView2.AllowUserToAddRows = False

        excelOutDataGred(Me.DataGridView2, False, Me.ToolStripProgressBar1, 1)
        dt = Nothing
        Me.DataGridView2.DataSource = Nothing
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click

        Dim dt As New DataTable
        dt = Nothing
        Me.DataGridView2.DataSource = Nothing

        dt = ClassPostgeDB.SetTable(outSQL())
        Me.DataGridView2.DataSource = dt
        Me.DataGridView2.AllowUserToAddRows = False

        OutputCsvFromDataGridView(Me.DataGridView2, Me.ToolStripProgressBar1)

        dt = Nothing
        Me.DataGridView2.DataSource = Nothing

    End Sub

#Region "TEXT CLEAR"
    Private Sub Button依頼元会社名CLEAR_Click(sender As Object, e As EventArgs) Handles Button依頼元会社名CLR.Click
        Me.TextBox依頼元会社名.Text = ""
    End Sub
    Private Sub Button依頼元部署名CLR_Click(sender As Object, e As EventArgs) Handles Button依頼元部署名CLR.Click
        Me.TextBox依頼元部署名.Text = ""
    End Sub

    Private Sub Button依頼元担当者名CLR_Click(sender As Object, e As EventArgs) Handles Button依頼元担当者名CLR.Click
        Me.TextBox依頼元担当者名.Text = ""
    End Sub

    Private Sub Button依頼元電話番号CLR_Click(sender As Object, e As EventArgs) Handles Button依頼元電話番号CLR.Click
        Me.TextBox依頼元電話番号.Text = ""
    End Sub

    Private Sub Button依頼元fax番号CLR_Click(sender As Object, e As EventArgs) Handles Button依頼元fax番号CLR.Click
        Me.TextBox依頼元fax番号.Text = ""
    End Sub

    Private Sub Button請求先送付先会社名CLR_Click(sender As Object, e As EventArgs) Handles Button請求先送付先会社名CLR.Click
        Me.TextBox請求先送付先会社名.Text = ""
    End Sub

    Private Sub Button請求書送付先担当者CLR_Click(sender As Object, e As EventArgs) Handles Button請求書送付先担当者CLR.Click
        Me.TextBox請求書送付先担当者.Text = ""
    End Sub

    Private Sub Button請求送付先郵便番号CLR_Click(sender As Object, e As EventArgs) Handles Button請求送付先郵便番号CLR.Click
        Me.TextBox請求送付先郵便番号.Text = ""
    End Sub

    Private Sub Button請求書送付先住所CLR_Click(sender As Object, e As EventArgs) Handles Button請求書送付先住所CLR.Click
        Me.TextBox請求書送付先住所.Text = ""
    End Sub

    Private Sub Button請求書宛名CLR_Click(sender As Object, e As EventArgs) Handles Button請求書宛名CLR.Click
        Me.TextBox請求書宛名.Text = ""
    End Sub

    Private Sub Button請求送付先電話番号CLR_Click(sender As Object, e As EventArgs) Handles Button請求送付先電話番号CLR.Click
        Me.TextBox請求送付先電話番号.Text = ""
    End Sub

    Private Sub Button台数CLR_Click(sender As Object, e As EventArgs) Handles Button台数CLR.Click
        Me.TextBox台数.Text = ""
    End Sub

    Private Sub Button工期開始日CLR_Click(sender As Object, e As EventArgs) Handles Button工期開始日CLR.Click
        Me.TextBox工期開始日.Text = ""
    End Sub

    Private Sub Button工期終了日CLR_Click(sender As Object, e As EventArgs) Handles Button工期終了日CLR.Click
        Me.TextBox工期終了日.Text = ""
    End Sub

    Private Sub Button請求締日CLR_Click(sender As Object, e As EventArgs) Handles Button請求締日CLR.Click
        Me.TextBox請求締日.Text = ""
    End Sub

    Private Sub Button請求備考CLR_Click(sender As Object, e As EventArgs) Handles Button請求備考CLR.Click
        Me.TextBox請求備考.Text = ""
    End Sub

    Private Sub ButtonメモCLR_Click(sender As Object, e As EventArgs) Handles ButtonメモCLR.Click
        Me.TextBoxメモ.Text = ""
    End Sub

    Private Sub Button点検時写真メモCLR_Click(sender As Object, e As EventArgs) Handles Button点検時写真メモCLR.Click
        Me.TextBox点検時写真メモ.Text = ""
    End Sub

    Private Sub Button請求書納期CLR_Click(sender As Object, e As EventArgs) Handles Button請求書納期CLR.Click
        Me.TextBox請求書納期.Text = ""
    End Sub

    Private Sub Button条件１CLR_Click(sender As Object, e As EventArgs) Handles Button条件１CLR.Click
        Me.TextBox条件１.Text = ""
    End Sub
#End Region

End Class