Public Class FormSEIHINInput

    Dim zenkaiSQL As String
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim _FileName As String = String.Empty


    Public Property FileName As String
        Get
            FileName = _FileName
        End Get
        Set(value As String)
            _FileName = value
        End Set
    End Property


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


    Private Sub 更新２()
        Dim ClassPostgeDB As New ClassPostgeDB

        Dim strSQL As String
        Dim ret As String

        Dim col As Integer
        Dim rol As Integer
        Dim sinacol As Integer = -1
        Dim t_parts_center_seihinmei As Integer = -1
        Dim t_buhin_spec_seihinmei As Integer = -1
        Dim t_parts_center_categori As Integer = -1
        Dim t_buhin_spec_categori As Integer = -1
        Dim t_parts_center_haisibi As Integer = -1
        Dim t_buhin_spec_aitesakihinban As Integer = -1
        Dim t_buhin_spec As Boolean = False
        Dim t_parts_center As Boolean = False

        Dim Fl(50) As String
        Me.ToolStripMenuItem3.Text = "0"
        Me.MSGToolStripMenuItem.Text = "更新中"
        Me.MSGToolStripMenuItem.BackColor = Color.Yellow

        col = Me.DataGridView1.Columns.Count
        rol = Me.DataGridView1.Rows.Count

        'FormMeter.MAX = rol + 1
        'FormMeter.Show()

        For x = 0 To col - 1
            Select Case Me.DataGridView1.Columns(x).HeaderText.Trim()
                Case "品コード"
                    Fl(x) = "sinacd"
                    sinacol = x
                Case "商品名"                      't_parts_center t_buhin_spec
                    Fl(x) = "seihinmei"
                    t_parts_center_seihinmei = x
                    t_buhin_spec_seihinmei = x
                    't_buhin_spec = True
                    't_parts_center = True
                Case "カテゴリ"                     't_parts_center t_buhin_spec
                    Fl(x) = "categori"
                    t_parts_center_categori = x
                    t_buhin_spec_categori = x
                    't_buhin_spec = True
                    't_parts_center = True
                Case "倉庫"
                    Fl(x) = "inputkbn"
                Case "メーカー"
                    Fl(x) = "makerkbn"
                Case "ショップ"
                    Fl(x) = "makerkbn"
                Case "入力振分"
                    Fl(x) = "furikae"
                Case "得意先コード"
                    Fl(x) = "tokuisakicd"
                Case "ガス種"
                    Fl(x) = "gas"
                Case "基準在庫"
                    Fl(x) = "kijunzaiko"
                Case "AS供給停止日"                  'date
                    Fl(x) = "askyoukyuu"
                Case "廃止予定日"                    'date
                    Fl(x) = "haisiyotei"
                Case "廃止日"                       'date 't_parts_center
                    Fl(x) = "haisibi"
                    t_parts_center_haisibi = x
                    't_parts_center = True
                Case "在庫種類"
                    Fl(x) = "souko"
                Case "販売価格"
                    Fl(x) = "hanbai"
                Case "製品フラグ"
                    Fl(x) = "seihinflg"
                Case "原価"
                    Fl(x) = "genka"
                Case "保有年"
                    Fl(x) = "hoyunen"
                Case "相手先品番"                    't_buhin_spec
                    Fl(x) = "aitesakihinban"
                    t_buhin_spec_aitesakihinban = x
                    't_buhin_spec = True
                Case "SHOP"                        '0/1
                    Fl(x) = "shop"
                Case "BUHIN"                        '0/1
                    Fl(x) = "buhin"
                Case "更新日"                        'Date
                    Fl(x) = "update_day"
                Case "更新者"
                    Fl(x) = "entry_sya"
            End Select
        Next
        If sinacol = -1 Then
            MessageBox.Show("品コード項目が存在しません")
            Return
        End If

        '///////////////////////// m_seihin
        For y = 0 To rol - 1
            If Me.DataGridView1.Rows(y).Cells(sinacol).Value <> "" Then
                '品コードの存在
                strSQL = "Select sinacd FROM " & schema & "m_seihin WHERE sinacd ='" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                ret = ClassPostgeDB.DbSel(strSQL)

                If ret = "" Then 'INSERT
                    strSQL = "INSERT INTO " & schema & "m_seihin("
                    For x = 0 To col - 1
                        If x > 0 Then strSQL &= ","
                        strSQL &= "" & Fl(x) & ""
                    Next
                    strSQL &= ",entry_day)VALUES("
                    For x = 0 To col - 1

                        If x > 0 Then strSQL &= ","
                        If Fl(x) = "askyoukyuu" Or Fl(x) = "haisiyotei" Or Fl(x) = "haisibi" Then
                            strSQL &= DateKata(Me.DataGridView1.Rows(y).Cells(x).Value)

                        ElseIf Fl(x) = "update_day" Then
                            strSQL &= "now()"
                        ElseIf Fl(x) = "kijunzaiko" Or Fl(x) = "hanbai" Or Fl(x) = "genka" Or Fl(x) = "hoyunen" Then
                            If IsNumeric(Me.DataGridView1.Rows(y).Cells(x).Value) = True Then
                                strSQL &= Me.DataGridView1.Rows(y).Cells(x).Value
                            Else
                                strSQL &= "0"
                            End If
                        ElseIf Fl(x) = "entry_sya" Then
                            strSQL &= "'" & UserName & "'"
                        ElseIf Fl(x) = "shop" Then
                            If Me.DataGridView1.Rows(y).Cells(x).Value = "1" Then
                                strSQL &= "'1'"
                                t_parts_center = True
                            Else
                                strSQL &= "'0'"
                                t_parts_center = False

                            End If
                        ElseIf Fl(x) = "buhin" Then
                            If Me.DataGridView1.Rows(y).Cells(x).Value = "1" Then
                                strSQL &= "'1'"
                                t_buhin_spec = True
                            Else
                                strSQL &= "'0'"
                                t_buhin_spec = False
                            End If
                        Else
                            strSQL &= "'" & Me.DataGridView1.Rows(y).Cells(x).Value & "'"
                        End If
                    Next
                    strSQL &= ",now())"
                Else    'UPDATE
                    strSQL = "UPDATE " & schema & "m_seihin SET"
                    strSQL &= " entry_day = now()"

                    For x = 0 To col - 1
                        If Fl(x) <> "sinacd" Then
                            strSQL &= ","
                            If Fl(x) = "askyoukyuu" Or Fl(x) = "haisiyotei" Or Fl(x) = "haisibi" Then
                                strSQL &= Fl(x) & " = " & DateKata(Me.DataGridView1.Rows(y).Cells(x).Value)
                            ElseIf Fl(x) = "update_day" Then
                                strSQL &= "update_day = now()"
                            ElseIf Fl(x) = "kijunzaiko" Or Fl(x) = "hanbai" Or Fl(x) = "genka" Or Fl(x) = "hoyunen" Then
                                If IsNumeric(Me.DataGridView1.Rows(y).Cells(x).Value) = True Then
                                    strSQL &= Fl(x) & "=" & Me.DataGridView1.Rows(y).Cells(x).Value
                                Else
                                    strSQL &= Fl(x) & "= 0"
                                End If
                            ElseIf Fl(x) = "entry_sya" Then
                                strSQL &= "entry_sya = '" & UserName & "'"
                            ElseIf Fl(x) = "shop" Then
                                If Me.DataGridView1.Rows(y).Cells(x).Value = "1" Then
                                    strSQL &= Fl(x) & "='1'"
                                    t_parts_center = True
                                Else
                                    strSQL &= Fl(x) & "='0'"
                                    t_parts_center = False

                                End If
                            ElseIf Fl(x) = "buhin" Then
                                If Me.DataGridView1.Rows(y).Cells(x).Value = "1" Then
                                    strSQL &= Fl(x) & "='1'"
                                    t_buhin_spec = True
                                Else
                                    strSQL &= Fl(x) & "='0'"
                                    t_buhin_spec = False
                                End If

                            Else
                                strSQL &= Fl(x) & "= '" & Me.DataGridView1.Rows(y).Cells(x).Value & "'"
                            End If
                        End If
                    Next
                    strSQL &= " WHERE sinacd ='" + Me.DataGridView1.Rows(y).Cells(sinacol).Value + "'"
                End If
                Try
                    If ClassPostgeDB.EXEC(strSQL) Then
                        Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.GreenYellow
                    Else
                        Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Yellow
                    End If
                Catch ex As Exception
                    Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Yellow
                End Try
                '/////

                't_buhin_spec
                't_parts_center
                '///////////////////////// t_buhin_spec
                If t_buhin_spec = True Then
                    '品コードの存在
                    strSQL = "SELECT sinacd FROM " & schema & "t_buhin_spec WHERE sinacd ='" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                    ret = ClassPostgeDB.DbSel(strSQL)
                    If ret = "" Then 'INSERT
                        strSQL = ""


                        strSQL = "INSERT INTO " & schema & "t_buhin_spec (sinacd, syouhinmei,categori, oem , entry_day, entry_sya,  update_day)VALUES("
                        strSQL &= "'" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(y).Cells(t_buhin_spec_seihinmei).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(y).Cells(t_buhin_spec_categori).Value & "'"
                        strSQL &= ",'" & Me.DataGridView1.Rows(y).Cells(t_buhin_spec_aitesakihinban).Value & "'"

                        strSQL &= ",now()"
                        strSQL &= ",'" & UserName & "'"
                        strSQL &= ",now()"
                        strSQL &= ")"


                    Else

                        strSQL = "UPDATE " & schema & "t_buhin_spec SET "
                        strSQL &= " update_day =now()"
                        If t_buhin_spec_seihinmei <> -1 Then
                            strSQL &= ", syouhinmei = '" & Me.DataGridView1.Rows(y).Cells(t_buhin_spec_seihinmei).Value & "'"
                        End If
                        If t_buhin_spec_categori <> -1 Then
                            strSQL &= ", categori = '" & Me.DataGridView1.Rows(y).Cells(t_buhin_spec_categori).Value & "'"
                        End If

                        If t_buhin_spec_aitesakihinban <> -1 Then
                            strSQL &= ", oem ='" & Me.DataGridView1.Rows(y).Cells(t_buhin_spec_aitesakihinban).Value & "'"
                        End If

                        strSQL &= ", entry_sya ='" & UserName & "'"
                        strSQL &= " WHERE sinacd "
                        strSQL &= " = '" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                    End If

                    Try
                        If ClassPostgeDB.EXEC(strSQL) Then
                            Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Honeydew
                        End If
                    Catch ex As Exception
                        Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Red
                    End Try
                Else
                    strSQL = "DELETE FROM " & schema & "t_buhin_spec WHERE sinacd ='" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                    Try
                        If ClassPostgeDB.EXEC(strSQL) Then
                            Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Honeydew
                        End If
                    Catch ex As Exception
                        Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Red
                    End Try


                End If
                '///////////////////////// t_parts_center
                If t_parts_center = True Then
                    '品コードの存在
                    strSQL = "SELECT sinacd FROM " & schema & "t_parts_center WHERE sinacd ='" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                    ret = ClassPostgeDB.DbSel(strSQL)
                    If ret = "" Then 'INSERT
                        strSQL = "INSERT INTO " & schema & "t_parts_center("
                        strSQL &= "entry_sya "
                        If t_parts_center_seihinmei <> -1 Then
                            strSQL &= ",s_kanjimei"
                        End If
                        If t_parts_center_categori <> -1 Then
                            strSQL &= ",s_categori"
                        End If
                        If t_parts_center_haisibi <> -1 Then
                            strSQL &= ",s_haisi_bi "
                        End If
                        strSQL &= ",update_day,sinacd)VALUES("
                        strSQL &= "'" & UserName & "'"
                        If t_parts_center_seihinmei <> -1 Then
                            strSQL &= ",'" & Me.DataGridView1.Rows(y).Cells(t_parts_center_seihinmei).Value & "'"
                        End If
                        If t_parts_center_categori <> -1 Then
                            strSQL &= ",'" & Me.DataGridView1.Rows(y).Cells(t_parts_center_categori).Value & "'"
                        End If
                        If t_parts_center_haisibi <> -1 Then
                            strSQL &= "," & DateKata(Me.DataGridView1.Rows(y).Cells(t_parts_center_haisibi).Value)
                        End If
                        strSQL &= ",now()"
                        strSQL &= ",'" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "')"
                    Else
                        strSQL = "UPDATE  " & schema & "t_parts_center SET"
                        strSQL &= " entry_sya = '" & UserName & "'"
                        If t_parts_center_seihinmei <> -1 Then
                            strSQL &= ",s_kanjimei = '" & Me.DataGridView1.Rows(y).Cells(t_parts_center_seihinmei).Value & "'"
                        End If
                        If t_parts_center_categori <> -1 Then
                            strSQL &= ",s_categori = '" & Me.DataGridView1.Rows(y).Cells(t_parts_center_categori).Value & "'"
                        End If
                        If t_parts_center_haisibi <> -1 Then
                            strSQL &= ",s_haisi_bi = " & DateKata(Me.DataGridView1.Rows(y).Cells(t_parts_center_haisibi).Value)
                        End If
                        strSQL &= ",update_day = now()"
                        strSQL &= " WHERE sinacd ='" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"
                    End If
                    Try
                        If ClassPostgeDB.EXEC(strSQL) Then
                            Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Green
                        End If
                    Catch ex As Exception
                        Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Red
                    End Try
                Else
                    strSQL = "DELETE FROM " & schema & "t_parts_center WHERE sinacd ='" & Me.DataGridView1.Rows(y).Cells(sinacol).Value & "'"

                    Try
                        If ClassPostgeDB.EXEC(strSQL) Then
                            Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Green
                        End If
                    Catch ex As Exception
                        Me.DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Red
                    End Try

                End If
                '///////////////////////////////////////
            End If
            'FormMeter.GEN = y
            'FormMeter.Disp()
            Me.DataGridView1.FirstDisplayedScrollingRowIndex = y
            Me.ToolStripMenuItem3.Text = Integer.Parse(Me.ToolStripMenuItem3.Text) + 1
            System.Windows.Forms.Application.DoEvents()
        Next
        'FormMeter.GEN = rol
        'FormMeter.Disp()
        '//
        'FormMeter.CLos()
        Me.MSGToolStripMenuItem.Text = "更新終了"
        Me.MSGToolStripMenuItem.BackColor = Color.Blue

        MessageBox.Show("更新しました")
        Me.Close()

    End Sub


    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        更新２()
    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MSGToolStripMenuItem.Text = "CSVを選択してください"

    End Sub

    Private Sub Check()

        Dim x As Integer
        Dim cl As Integer

        Dim errcnt As Integer = 0
        cl = Me.DataGridView1.Columns.Count - 1
        Me.ToolStripMenuItem3.Text = "0"
        Me.MSGToolStripMenuItem.BackColor = Color.Yellow

        Me.MSGToolStripMenuItem.Text = "更新チェック中"

        For Each dg As DataGridViewRow In Me.DataGridView1.Rows
            If dg.Cells(0).Value <> "" Then
                dg.Cells(0).Style.BackColor = Color.White

                For x = 0 To cl
                    Select Case Me.DataGridView1.Columns(x).HeaderText.Trim()
                        Case "品コード"
                        Case "商品名"
                        Case "カテゴリ"
                        Case "倉庫"
                        Case "メーカー"
                        Case "ショップ"
                        Case "入力振分"
                        Case "得意先コード"
                        Case "ガス種"
                        Case "基準在庫"
                            If dg.Cells(x).Value = "" Then
                                dg.Cells(x).Value = "0"
                            Else
                                If IsNumeric(dg.Cells(x).Value) = False And dg.Cells(x).Value <> "" Then
                                    errcnt = errcnt + 1
                                    dg.Cells(x).Style.BackColor = Color.Red
                                Else
                                    dg.Cells(x).Style.BackColor = Color.LightBlue
                                End If
                            End If

                        Case "AS供給停止日"          'date
                            If dg.Cells(x).Value <> "" Then
                                dg.Cells(x).Value = yymm(dg.Cells(x).Value)
                                If IsDate(dg.Cells(x).Value) = False And dg.Cells(x).Value <> "" Then
                                    errcnt = errcnt + 1
                                    dg.Cells(x).Style.BackColor = Color.Red
                                Else
                                    dg.Cells(x).Style.BackColor = Color.LightBlue
                                End If
                            End If
                        Case "廃止予定日"            'date
                            If dg.Cells(x).Value <> "" Then
                                dg.Cells(x).Value = yymm(dg.Cells(x).Value)
                                If IsDate(dg.Cells(x).Value) = False And dg.Cells(x).Value <> "" Then
                                    errcnt = errcnt + 1
                                    dg.Cells(x).Style.BackColor = Color.Red
                                Else
                                    dg.Cells(x).Style.BackColor = Color.LightBlue
                                End If
                            End If
                        Case "廃止日"                'date
                            If dg.Cells(x).Value <> "" Then
                                dg.Cells(x).Value = yymm(dg.Cells(x).Value)
                                If IsDate(dg.Cells(x).Value) = False And dg.Cells(x).Value <> "" Then
                                    errcnt = errcnt + 1
                                    dg.Cells(x).Style.BackColor = Color.Red
                                Else
                                    dg.Cells(x).Style.BackColor = Color.LightBlue
                                End If
                            End If
                        Case "在庫種類"
                        Case "販売価格"
                            If dg.Cells(x).Value = "" Then
                                dg.Cells(x).Value = "0"
                            Else
                                If IsNumeric(dg.Cells(x).Value) = False And dg.Cells(x).Value <> "" Then
                                    errcnt = errcnt + 1
                                    dg.Cells(x).Style.BackColor = Color.Red
                                Else
                                    dg.Cells(x).Style.BackColor = Color.LightBlue
                                End If
                            End If

                        Case "製品フラグ"
                        Case "原価"
                            If dg.Cells(x).Value = "" Then
                                dg.Cells(x).Value = "0"
                            Else
                                If IsNumeric(dg.Cells(x).Value) = False And dg.Cells(x).Value <> "" Then
                                    errcnt = errcnt + 1
                                    dg.Cells(x).Style.BackColor = Color.Red
                                Else
                                    dg.Cells(x).Style.BackColor = Color.LightBlue
                                End If
                            End If

                        Case "相手先品番"

                        Case "SHOP"     '//2022/01/26
                        Case "BUHIN"    '//2022/01/26

                        Case "保有年"
                        Case "更新日"              'Date
                        Case "更新者"

                    End Select
                Next
            End If
            Me.ToolStripMenuItem3.Text = Integer.Parse(Me.ToolStripMenuItem3.Text) + 1
            System.Windows.Forms.Application.DoEvents()
        Next
        If errcnt > 0 Then
            MessageBox.Show(errcnt & "のエラー箇所があります")
            Me.MSGToolStripMenuItem.Text = errcnt & "のエラー  更新チェック完了"
            Me.MSGToolStripMenuItem.BackColor = Color.Red

        Else
            Me.MSGToolStripMenuItem.BackColor = Color.Green

            Me.MSGToolStripMenuItem.Text = "更新チェック完了"
        End If
    End Sub
    Private Function yymm(dy)
        Return Strings.Left(dy, 4) & "/" & Strings.Right("0" & Replace(Mid(dy, 6, 2), "/", ""), 2) & "/" & Strings.Right("0" & Replace(Strings.Right(dy, 2), "/", ""), 2)
    End Function


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Check()
    End Sub

    Private Sub FormSEIHINInput_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub ファイルToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ファイルToolStripMenuItem.Click
        GetIniFile()
        Me.ToolStripMenuItem2.Text = "0"

        FileName = Filesentaku(MaserFolder)
        If FileName <> "" Then
            If FileName.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Dim x As Integer
                CSVDataGridInput(Me.DataGridView1, FileName, Me.ToolStripMenuItem2)
                For x = 0 To Me.DataGridView1.Columns.Count - 1
                    If Me.DataGridView1.Columns(x).HeaderText.Trim() = "" Then
                        DataGridView1.Columns.RemoveAt(x)
                    Else
                        Select Case Me.DataGridView1.Columns(x).HeaderText.Trim()
                            Case "品コード"
                            Case "商品名"
                            Case "カテゴリ"
                            Case "倉庫"
                            Case "メーカー"
                            Case "ショップ"
                            Case "入力振分"
                            Case "得意先コード"
                            Case "ガス種"
                            Case "基準在庫"
                            Case "AS供給停止日"
                            Case "廃止予定日"
                            Case "廃止日"
                            Case "在庫種類"
                            Case "販売価格"
                            Case "製品フラグ"
                            Case "原価"
                            Case "相手先品番"
                            Case "保有年"
                            Case "SHOP"     '//2022/01/26
                            Case "BUHIN"    '//2022/01/26
                            Case "更新日"
                            Case "更新者"
                            Case Else
                                MessageBox.Show("ファイルが違います")
                                Me.Close()
                                Exit Sub
                        End Select
                    End If
                Next
                DataGridView1.AllowUserToAddRows = False
                Check()
            Else
                MessageBox.Show("ＣＳＶではありません")
            End If
        End If

    End Sub
End Class