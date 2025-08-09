
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Net


Module ModuleApp

    Public Const menu_bar As String = "点検請求管理"


    Public Now_Ver As String = GetVer().ToString()          '"0.0.0.1"'==== m_ver とバージョンをわせる
    Public Cmp_day As String = vAsm.v説明      ' "2021/12/17"
    Public NextVer As String = NextVersion(Now_Ver)

    Public appdir As String = System.Windows.Forms.Application.StartupPath
    Private Const iniFile As String = "App006.ini"
    Public SystemMsg As String
    Public UketukeNo As String
    Public Coment As String
    Public 点検項目名 As String

    Public w002金額 As Integer
    Public w002得意先 As String
    Public w002Exe As Boolean
    Public w002伝票発行日 As String


    Private BtnColorDT As New DataTable

#If DEBUG Then
    Public Ver As String = "" & Now_Ver
    ' Public Const dns As String = "partsc-test.noritz.co.jp"
    Public Const dns As String = "partsc.noritz.co.jp"
    Public Const schema As String = "tenken."
    'Public Const schema As String = "n2c."

    'Public Const CnString = "Server=localhost;Port=5432;User ID=postgres;Database=postgres;Password=12345;Enlist=true"
    '-----SI ALMA LINUX 
    Public Const CnString = "Server=192.168.1.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true;ConnectionLifeTime=3000"
    ' SI - win10 
    'Public Const CnString = "Server=192.168.1.217;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true;ConnectionLifeTime=3000"
    '------
    'NR IDC
    'Public Const CnString = "Server=192.168.99.51;Port=5432;User ID=postgres;Database=postgres;Password=12345;Enlist=true"
    '------
    'AWS 
    'Public Const CnString = "Server=" & dns & ";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    '------
    Public Const autoverup As String = "1"  ' 自動バージョンアップ　OFF
#Else
    Public Ver As String = "" & Now_Ver
    Public Const dns As String = "partsc.noritz.co.jp"
    Public Const schema As String = "tenken."
    '================================
    '==== 点検C　172.17.69.135 DiskTop  【call532a / call 】 
    'Public Const CnString = "Server=172.17.69.135;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    '==== postgres / nr123 ======
    'Public Const CnString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    Public Const CnString = "Server=" & dns & ";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    '================================
#End If

    Public Function get_dns()
        get_dns = dns
    End Function

    Public Function GetDbVer()
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim dt As New DataTable
        Dim strSQL As String
        Dim New_Var As String = String.Empty
        Try

            strSQL = "SELECT ver ,exe FROM " & schema & "m_ver"
            dt = ClassPostgeDB.SetTable(strSQL)

            If dt.Rows.Count > 0 Then
                New_Var = dt.Rows(0).Item(0).ToString
            Else
                MessageBox.Show("データベースに接続できません")
                Application.Exit()
            End If
            'New_Var = ClassPostgeDB.DbSel(strSQL)
            If New_Var = "" Then
                MessageBox.Show("バージョンが取得できません")
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show("データベースに接続できません")
            Application.Exit()
        End Try
        Return New_Var
    End Function



#Region "初期フォルダ"

    Public StockFolder As String
    Public OrderFolder As String
    Public NextBFolder As String
    Public Next2Folder As String
    Public NextHanyou As String
    Public Orde1Folder As String
    Public ZaikoFolder As String
    Public UriagFolder As String
    Public MaserFolder As String

    Public Function chgsuji(buf As String)
        Dim reg As New Regex("[^\d]")   '--- [^0-9]でもよい
        Return reg.Replace(buf, "")
    End Function



    Public Function Chksuji(s As String) As Boolean
        '        Dim r As New System.Text.RegularExpressions.Regex(“^[a-zA-Z0-9]+$”)
        Dim r As New System.Text.RegularExpressions.Regex(“^[0-9.]+$”)
        If r.IsMatch(s) = False Then
            Chksuji = False
        Else
            Chksuji = True
        End If
    End Function

    Public Function Leftstring(s As String, x As Integer, sp As String)
        Dim buf As String = String.Concat(Enumerable.Repeat(sp, x))
        s &= buf
        Leftstring = Strings.Left(s, x)

    End Function

#End Region


#Region "アセンブリ情報取得"


#End Region

#Region "日時間関数"

    Public Function TimeRead(ByVal StrDate As String) As Date
        Dim datBuff As Date
        datBuff = Date.FromOADate(StrDate)
        Return datBuff
    End Function
    Public Function GetVersion() As String
        GetVersion = Now_Ver
    End Function

    Public Function Getcmpday() As String
        Getcmpday = Cmp_day
    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 日付型のチェック
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function IsDate(ByVal pVal As String, Optional ByVal pFormat As String = "yyyy/MM/dd") As Boolean
        IsDate = False
        Dim result As DateTime
        If DateTime.TryParseExact(pVal, pFormat, Nothing, Globalization.DateTimeStyles.None, result) = False Then Exit Function
        IsDate = True
    End Function

    Public Function IsDate2(ByVal pVal As String, Optional ByVal pFormat As String = "yyyy/MM/dd hh:mi:ss") As Boolean
        IsDate2 = False
        Dim result As DateTime
        If DateTime.TryParseExact(pVal, pFormat, Nothing, Globalization.DateTimeStyles.None, result) = False Then Exit Function
        IsDate2 = True
    End Function
    Public Function DateKata(ByVal pVal As String)
        If IsDate(pVal) Then
            DateKata = "'" & pVal & "'"
        Else
            DateKata = "NULL"
        End If
    End Function
    Public Function DateKata2(ByVal pVal As String)
        If IsDate(pVal) Then
            DateKata2 = "'" & pVal & "'"
        Else
            DateKata2 = "''"
        End If
    End Function
    Public Function DateKata3(ByVal pVal As String)
        Dim d As DateTime
        If DateTime.TryParse(pVal, d) Then
            DateKata3 = "'" & pVal & "'"
        Else
            DateKata3 = "NULL"
        End If
    End Function


    Public Function yyyyTo(inDay) As String

        If IsNumeric(inDay) Then
            '日付文字列をInteger型へ変換する
            Dim outDay As Integer = Integer.Parse(inDay)
            'yyyy/mm/dd型式にする
            Return outDay.ToString("0000/00/00")
        Else

            Return ""

        End If

    End Function
    Public Function DateFormat(inDay) As String

        If inDay.trim <> "" Then
            'yyyy/mm/dd型式にする
            Return DateTime.Parse(inDay).ToString("yyyy/MM/dd")
        Else
            Return ""
        End If

    End Function
#End Region

#Region "IsDecimal メソッド"

    ''' ------------------------------------------------------------------------------
    ''' <summary>
    '''     指定した値が小数を含むかどうかを返します。</summary>
    ''' <param name="dValue">
    '''     検査対象となる値。</param>
    ''' <returns>
    '''     小数を含む場合は True。それ以外は False。</returns>
    ''' ------------------------------------------------------------------------------
    Public Function IsDecimal(ByVal dValue As Double) As Boolean
        If dValue - System.Math.Floor(dValue) <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region "レジストリ"
    '
    '
    Public Function WriteRegKey(ss As String, buf As String) As Boolean
        Dim regkey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\si", False)
        'レジストリに書き込み
        Try
            regkey.SetValue(ss, buf, Microsoft.Win32.RegistryValueKind.String)
            regkey.Close()

            WriteRegKey = True

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            WriteRegKey = False
        End Try

    End Function
    Public Function ReadRegKey(ss As String) As String

        'キー（HKEY_CURRENT_USER\Software\test\sub）を読み取り専用で開く
        Dim regkey As Microsoft.Win32.RegistryKey =
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\si", False)
        'キーが存在しないときは null が返される
        If regkey Is Nothing Then
            Return False
        End If
        '文字列を読み込む
        Dim reg = regkey.GetValue(ss)
        regkey.Close()
        Return (reg)
        'Dim intValue As Integer = CInt(regkey.GetValue("string"))
        'Return CStr(intValue)
    End Function

#End Region


#Region "初期ファイル"
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' ファイル選択の初期値を保存　読み込み
    '
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Sub SetIniFile()
        'Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
        Dim stCurrentDir As String = Path.GetTempPath()
        Dim sw As New System.IO.StreamWriter(stCurrentDir & "\\" & iniFile, False, System.Text.Encoding.GetEncoding("shift_jis"))
        sw.WriteLine("StockFolder=" & StockFolder)
        sw.WriteLine("OrderFolder=" & OrderFolder)
        sw.WriteLine("NextBFolder=" & OrderFolder)
        sw.WriteLine("Next2Folder=" & OrderFolder)
        sw.WriteLine("NextHanyou=" & OrderFolder)
        sw.WriteLine("Orde1Folder=" & OrderFolder)
        sw.WriteLine("ZaikoFolder=" & OrderFolder)
        sw.WriteLine("UriagFolder=" & OrderFolder)
        sw.WriteLine("MaserFolder=" & OrderFolder)

        sw.Close()
    End Sub
    Public Sub GetIniFile()
        'Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
        Dim stCurrentDir As String = Path.GetTempPath()

        Try
            Using sr As New System.IO.StreamReader(stCurrentDir & "\\" & iniFile, System.Text.Encoding.GetEncoding("shift_jis"))
                Do While Not sr.EndOfStream
                    Dim variable As String = sr.ReadLine
                    Select Case variable
                        Case variable.Contains("StockFolder=")
                            StockFolder = variable.Replace("StockFolder=", "")
                        Case variable.Contains("OrderFolder=")
                            OrderFolder = variable.Replace("OrderFolder=", "")
                        Case variable.Contains("NextBFolder=")
                            OrderFolder = variable.Replace("NextBFolder=", "")
                        Case variable.Contains("Next2Folder=")
                            OrderFolder = variable.Replace("Next2Folder=", "")
                        Case variable.Contains("NextHanyou=")
                            OrderFolder = variable.Replace("NextHanyou=", "")
                        Case variable.Contains("Orde1Folder=")
                            Orde1Folder = variable.Replace("Orde1Folder=", "")
                        Case variable.Contains("ZaikoFolder=")
                            Orde1Folder = variable.Replace("ZaikoFolder=", "")
                        Case variable.Contains("UriagFolder=")
                            Orde1Folder = variable.Replace("UriagFolder=", "")
                        Case variable.Contains("MaserFolder=")
                            Orde1Folder = variable.Replace("MaserFolder=", "")
                    End Select
                Loop
            End Using

        Catch ex As Exception
            StockFolder = ""
            OrderFolder = ""
        Finally


        End Try
    End Sub
#End Region


#Region "ファイル選択"

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' ファイルを選択
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Function Filesentaku(nm As String) As String

        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = nm
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = nm
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "CSVファイル(*.CSV;*.csv)|*.CSV;*.csv|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 2
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Filesentaku = ofd.FileName
        Else
            Filesentaku = ""
        End If
    End Function
    Public Function FilesentakuEXELS(nm As String) As String

        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = nm
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = nm
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "EXLEファイル(*.XLSX;*.xlsx)|*.XLSX;*.elsx|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 2
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True
        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            FilesentakuEXELS = ofd.FileName
        Else
            FilesentakuEXELS = ""
        End If
    End Function

    Public Function FileSave(nm As String) As String

        Dim sfd As New SaveFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        sfd.FileName = nm
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        sfd.InitialDirectory = nm
        '[ファイルの種類]に表示される選択肢を指定する
        sfd.Filter = "CSVファイル(*.CSV;*.csv)|*.CSV;*.csv|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        sfd.FilterIndex = 2
        'タイトルを設定する
        sfd.Title = "保存先のファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            FileSave = sfd.FileName
        Else
            FileSave = ""

        End If
    End Function
#End Region


#Region "ユーザーステータス"

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' USERステータス
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Function Logent(UserID As String, UserName As String, MenuId As String) As Boolean
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = ""
        If UserID <> "SYSTEM" Then
            Select Case MenuId
                Case "0"
                    MenuId = "ログアウト"
                Case "1"
                    MenuId = "[" & Ver & " - " & GetIpAddress() & "]"
                Case "2"
                    MenuId = "点検集約"
                Case "3"
                    MenuId = "チェック"
                Case "4"
                    MenuId = "売上管理"
                Case "5"
                    MenuId = "請求管理"
                Case "6"
                    MenuId = "システムマスタ"
                Case "7"
                    MenuId = "ユーザー管理"
                Case "8"
                    MenuId = "出庫"
                Case "9"
                    MenuId = "不備"
                Case "10"
                    MenuId = "パスワード変更"
                Case "11"
                    MenuId = "物件管理"
                Case "12"
                    MenuId = "技術"
                Case "13"
                    MenuId = "点検メニュー"
                Case "14"
                    MenuId = "マスタ不備内容”
                Case "15"
                    MenuId = "マスタコマンド"
                Case "16"
                    MenuId = "マスタ不備内容２"
                Case "17"
                    MenuId = "点検チェック"
                Case "18"
                    MenuId = "チェック数日計表"
                Case "19"
                    MenuId = "点検結果表チェック3"
                Case "20"
                    MenuId = "点検結果表チェック不備"
                Case "21"
                    MenuId = "点検結果表明細"
                Case "25"
                    MenuId = "承認"
                Case "30"
                    MenuId = "回収管理"
                Case "99"
                    MenuId = "メッセージ"
            End Select

            strSQL = "INSERT INTO " & schema & "t_log(id, nm, mn, entry_day)VALUES('" & UserID & "', '" & UserName & "', '" & MenuId & "', now())"
            If ClassPostgeDB.EXECnon(strSQL) Then

            End If
        End If

        Logent = True

    End Function


    Private Function GetIpAddress() As String

        Dim hostName As String = System.Net.Dns.GetHostName()
        Dim ipAdList As System.Net.IPAddress() = System.Net.Dns.GetHostAddresses(hostName)

        Dim rec As String = ""
        For Each address As System.Net.IPAddress In ipAdList
            rec = address.ToString()
        Next address
        Return (rec)
    End Function

#End Region

#Region "関数"
    Public Function GetHeaderColNo(head As String, dgv As DataGridView) As Integer
        Dim ret As Integer = 0

        For Each column As DataGridViewColumn In dgv.Columns
            If column.HeaderText = head Then
                Return ret
            End If
            ret = ret + 1
        Next
        Return -1
    End Function

    Public Function DataTableSwapXY(ByVal src As DataTable, ByVal newColName As String) As DataTable

        Dim ret As New DataTable(src.TableName)

        '列の追加
        ret.Columns.Add(newColName)
        For y As Integer = 0 To src.Rows.Count - 1
            ret.Columns.Add(src.Rows(y)(0))
        Next

        '列を行に変換
        For x As Integer = 1 To src.Columns.Count - 1

            Dim dr As DataRow = ret.NewRow()

            dr(newColName) = src.Columns(x).ColumnName

            For y As Integer = 0 To src.Rows.Count - 1
                dr(ret.Columns(y + 1).ColumnName) = src.Rows(y)(x)
            Next

            ret.Rows.Add(dr)
        Next

        DataTableSwapXY = ret

    End Function


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' コンボボックスに指定された内容を選択表示する
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Sub SetComboBox(cmb As ComboBox, buf As String)
        Dim idx As Integer

        ' For idx = 0 To cmb.Items.Count - 1
        'cmb.SelectedIndex = idx
        'If cmb.Text = buf Then
        'Return
        'End If
        'Next
        'cmb.SelectedIndex = -1
        'Return

        idx = 0
        For Each d As String In cmb.Items
            If d.Contains(buf) Then
                cmb.SelectedIndex = idx
                Return
            End If
            idx = idx + 1
        Next
        cmb.SelectedIndex = -1
        Return
    End Sub


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=＝＝＝＝＝＝
    ' 
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function Notcrlf(buf As String)
        If buf <> "" Then

            Notcrlf = buf.Replace(vbCrLf, "\n")
        Else
            Notcrlf = ""
        End If

    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function Oncrlf(buf As String)

        If buf <> "" Then
            Oncrlf = buf.Replace("\n", vbCrLf)
        Else
            Oncrlf = ""
        End If
    End Function
#End Region

#Region "DB関係"

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' システムマスタの内容を ComboBox セット
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Sub GetSystemtoListBox(ku As String, cmb As ListBox)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select ms.naiyou from " & schema & "m_system ms where ms.kbn ='" & ku & "' order by seq "
        ClassPostgeDB.SetListBox(cmb, strSQL)

    End Sub

    Public Sub GetSystemtoListBox(ku As String, cmb As ListBox, jyoken As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select ms.naiyou from " & schema & "m_system ms where ms.kbn ='" & ku & "' and naiyou2 like '%" & jyoken & "%' order by seq "
        ClassPostgeDB.SetListBox(cmb, strSQL)

    End Sub

    '
    '過去データを含めるか　
    '　含める場合　TRUE
    '
    Public Function ChkNewOld() As Boolean

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        Dim dt As New DataTable

        strSQL = "select ms.naiyou from " & schema & "m_system ms where ms.kbn ='3' and  ms.seq ='0'"

        dt = ClassPostgeDB.SetTable(strSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString() = "1" Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function



    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' システムマスタの内容を ComboBox セット
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Sub GetSystemtoCombo(ku As String, cmb As ComboBox, s As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select ms.naiyou from " & schema & "m_system ms where ms.kbn  in (" & ku & ") order by kbn, seq "
        ClassPostgeDB.SetComboBox(cmb, strSQL, s)

    End Sub
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' システムマスタの内容を 取得
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Function GetSystemto(ku As String, seq As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select ms.naiyou from " & schema & "m_system ms where ms.kbn ='" & ku & "' and seq ='" & seq & "'"
        Return ClassPostgeDB.DbSel(strSQL)

    End Function

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' システムマスタの備考を 取得
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Function GetSystemMSG(nai1 As String, nai2 As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select m.bikou  from " & schema & "m_system m where m.naiyou = '" & nai1 & "' and m.naiyou2  = '" & nai2 & "'  and  m.kbn ='140'"
        Return ClassPostgeDB.DbSel(strSQL)

    End Function



    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' DM番号を 取得
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Function GetDMno(uketukeno As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select t.ｄｍ番号 from " & schema & "v_yuryo_tenken_syuyaku t where  t.点検受付番号 ='" & uketukeno & "'"
        Return ClassPostgeDB.DbSel(strSQL)

    End Function


    Public Sub LogDelete()

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "DELETE FROM " & schema & "t_log WHERE entry_day < CURRENT_DATE -   (select  cast(  naiyou  as  int ) from " & schema & "m_system  where kbn ='99' and seq ='0')"
        ClassPostgeDB.EXEC(strSQL)

    End Sub

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '更新時間チェック
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '
    Public Function GetUpdateTime(table As String)
        Dim strSQL As String
        Dim ClassPostgeDB As New ClassPostgeDB
        strSQL = "SELECT update_day FROM " & schema & table

        GetUpdateTime = ClassPostgeDB.DbSel(strSQL)

    End Function


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 現在庫を取得
    '
    Public Function Get_genzaiko(sinacd As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT genzaiko FROM " & schema & "t_genzaiko where  sinacd = '" & sinacd & "'"
        Get_genzaiko = ClassPostgeDB.DbSel(strSQL)

    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 注残を取得
    '
    Public Function Get_tyuuzan(sinacd As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT tyuuzan FROM " & schema & "t_genzaiko where  sinacd = '" & sinacd & "'"
        Get_tyuuzan = ClassPostgeDB.DbSel(strSQL)
    End Function

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 受注を取得
    '
    Public Function Get_jyutyusu(sinacd As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT jyutyuu FROM " & schema & "t_genzaiko where  sinacd = '" & sinacd & "'"
        Get_jyutyusu = ClassPostgeDB.DbSel(strSQL)
    End Function

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 基準庫を取得
    '
    Public Function Get_kijun(sinacd As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT kijunzaiko FROM " & schema & "m_seihin where  sinacd = '" & sinacd & "'"
        Get_kijun = ClassPostgeDB.DbSel(strSQL)

    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '商品名を取得
    '
    Public Function Get_syouhinmei(sinacd As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT seihinmei FROM " & schema & "m_seihin where  sinacd = '" & sinacd & "'"
        Get_syouhinmei = ClassPostgeDB.DbSel(strSQL)

    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '得意先コードを取得
    ' in     直集 / 別途
    ' out  
    Public Function GetCstCD(kbn As String) As String
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        Dim kbndt As DataTable
        Dim ret As String = String.Empty

        strSQL = "Select naiyou2  from " & schema & "m_system where kbn ='180' and naiyou='" & kbn & "'"
        kbndt = ClassPostgeDB.SetTable(strSQL)

        For Each drow As DataRow In kbndt.Rows
            If ret.Length > 0 Then
                ret &= ","
            End If
            ret &= "'" & drow(0).ToString & "'"
        Next

        Return ret
    End Function

    Public Sub GetBtnColorDT()
        Dim strSQL As String
        Dim ClassPostgeDB As New ClassPostgeDB

        strSQL = "select ms.naiyou ,COALESCE(ms.naiyou2,'Pink')  from  " & schema & "m_system ms  where kbn='190' order by cast(ms.seq  as integer) "
        BtnColorDT = ClassPostgeDB.SetTable(strSQL)

    End Sub

    Public Function GetBtnColorDT(btn As String) As Color

        GetBtnColorDT = Color.FromKnownColor(System.Drawing.KnownColor.Control)
        For Each drow As DataRow In BtnColorDT.Rows

            If drow(0) = btn Then
                Return Color.FromName(drow(1))
            End If
        Next
    End Function

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' システムマスタの内容を 取得 　回収管理（色、日数）
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function GetSystemtoKaisyuu(ku As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "select ms.naiyou2, ms.bikou from " & schema & "m_system as ms where ms.kbn ='" & ku & "' Order by cast( ms.seq as integer) asc"
        Return ClassPostgeDB.SetTable(strSQL)

    End Function

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 数値のチェック
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function IsInteger(ByVal pval As Object) As Boolean
        IsInteger = False
        Dim result As Integer
        If Integer.TryParse(pval.ToString, result) = False Then Exit Function
        IsInteger = True
    End Function

    '--------------------------------------------
    'DBNullセット
    '--------------------------------------------
    Public Function SetDBNull(dtstr As String) As Object
        If dtstr = "" Then
            SetDBNull = DBNull.Value
        Else
            SetDBNull = dtstr
        End If
    End Function

    '--------------------------------------------
    '安心プランの消費税率
    '　　Oraclの施工年月日　<　 2019年10月1日　8％
    '　　Oraclの施工年月日　>=　2019年10月1日　10％
    '--------------------------------------------
    Public Function GetZeiRitu(kaisibi As String)
        Dim dy As Date

        GetZeiRitu = 8
        If kaisibi = "" Then
            Return GetZeiRitu
        End If
        dy = Date.Parse(kaisibi)
        If dy < "2014/04/01" Then
            GetZeiRitu = 5
        ElseIf dy < "2019/10/01" Then
            GetZeiRitu = 8
        Else
            GetZeiRitu = 10
        End If
    End Function

#End Region


End Module