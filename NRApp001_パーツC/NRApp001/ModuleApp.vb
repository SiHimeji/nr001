Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection


Module ModuleApp
    Public New_Var As String
    Public Now_Var As String
    Public Cmp_day As String




#If DEBUG Then

    Public Const dns As String = "partsc.noritz.co.jp"
    Public Const dns2 As String = "nrdays.noritz.co.jp"

    Public Const EC_DENSOU As String = "1"

    Public Const autoverup As String = "0"



    '=====SIテスト
    Public Const CnString = "Server=192.168.1.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    Public Const schema As String = "public."
    'Public Const testdb As String = ""

    Public Const CnString2 = "Server=192.168.1.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    Public Const schema2 As String = "burando."

    '===NRサーバーテスト
    'Public Const CnString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema As String = "test01."
    'Public Const testdb As String = "TEST"


    '===NRサーバー 本番DEBUG
    ' Public Const CnString = "Server=172.31.3.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    'Public Const schema As String = "public."
    'Public Const testdb As String = ""

    'Public Const CnString2 = "Server=172.31.3.167;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema2 As String = "burando."

    'Public Const CnString2 = "Server=172.31.3.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    'Public Const schema As String = "public."
    'Public Const testdb As String = ""

    'Public Const CnString2 = "Server=172.31.3.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    'Public Const schema2 As String = "burando."

    '/////
    '    Public Const CnString = "Server=" & dns & ";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema As String = "public."
    ''/////
    '   Public Const CnString2 = "Server=" & dns2 & ";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema2 As String = "burando."


    '===PCローカル
    'Public Const CnString = "Server=localhost;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
    'Public Const CnString = "Server=localhost;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"0
    '====TEST=====
    'Public Const CnString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema As String = "test01."

    'Public Const EC_DENSOU As String = "0" ' 1=On
    'Public Const CnString2 = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema2 As String = "test02."
    '====TEST=====


#Else
    Public Const autoverup As String = "1"

    Public Const dns As String = "partsc.noritz.co.jp"
    Public Const dns2 As String = "nrdays.noritz.co.jp"

    '=====NR本番
    'Public Const testdb As String = ""
    '================================
    '==== postgres / nr123 ======NR本番
    ' Public Const CnString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    Public Const CnString = "Server=" & dns & ";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    Public Const schema As String = "public."
    '/////
    Public Const EC_DENSOU As String = "1" ' 1=On
    'Public Const CnString2 = "Server=172.31.3.167;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    Public Const CnString2 = "Server=" & dns2 & ";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    Public Const schema2 As String = "burando."

    '================================


    '====TEST=====
    'Public Const CnString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema As String = "test01."

    'Public Const EC_DENSOU As String = "0" ' 1=On
    'Public Const CnString2 = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
    'Public Const schema2 As String = "test02."
    '====TEST=====

#End If

    '==============================
    Private Const iniFile As String = "App01.ini"
    Public kenken As String

#Region "アセンブリ情報取得"
    Public Sub GetAsm()

        Now_Var = GetVer()
        Cmp_day = Getasmdc()
        New_Var = NextVersion(Now_Var)

    End Sub
    Public Function get_dns()
        get_dns = dns
    End Function

    Public Function NextVersion(nVER As String)
        '1.0.0.0 →　1.0.0.1　 →　1.0.0.99　 →　1.0.1.0
        Dim Nextver(4) As Integer
        Dim NowVer() As String = nVER.Split(".")

        Nextver(0) = Integer.Parse(NowVer(0))
        Nextver(1) = Integer.Parse(NowVer(1))
        Nextver(2) = Integer.Parse(NowVer(2))
        Nextver(3) = Integer.Parse(NowVer(3)) + 1
        If Nextver(3) > 99 Then
            Nextver(3) = 0
            Nextver(2) = Nextver(2) + 1
            If Nextver(2) > 99 Then
                Nextver(2) = 0
                Nextver(1) = Nextver(1) + 1
                If Nextver(1) > 99 Then
                    Nextver(1) = 0
                    Nextver(0) = Nextver(0) + 1
                End If
            End If
        End If
        Return Nextver(0).ToString() & "." & Nextver(1).ToString() & "." & Nextver(2).ToString() & "." & Nextver(3).ToString()
    End Function


    '-------------------------------------
    'アセンブリ情報を取得
    Public Function GetVer()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        'Info.CompanyName
        'Info.ProductName
        Return Info.ProductVersion
        'Info.Comments
        'Info.FileDescription
        'Info.LegalCopyright
        'Info.LegalTrademarks
        'Return Info.ProductVersion
    End Function

    Public Function getasmttl() 'タイトル
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        'Info.CompanyName
        'Info.ProductName
        'Info.ProductVersion
        'Info.Comments
        Return Info.FileDescription
        'Info.LegalCopyright
        'Info.LegalTrademarks
    End Function



    Public Function Getasmdc() '説明
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        'Info.CompanyName
        'Info.ProductName
        'Info.ProductVersion
        Return Info.Comments
        'Info.FileDescription
        'Info.LegalCopyright
        'Info.LegalTrademarks

    End Function

    Public Function Getasmcmp() '会社情報
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Return Info.CompanyName
        'Info.ProductName
        'Info.ProductVersion
        'Info.Comments
        'Info.FileDescription
        'Info.LegalCopyright
        'Info.LegalTrademarks

    End Function


    Public Function Getasmprd() '製品
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        'Return Info.CompanyName
        Return Info.ProductName
        'Info.ProductVersion
        'Info.Comments
        'Info.FileDescription
        'Info.LegalCopyright
        'Info.LegalTrademarks

    End Function

    Public Function Getasmcpy() '著作権
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        'Info.CompanyName
        'Info.ProductName
        'Info.ProductVersion
        'Info.Comments
        'Info.FileDescription
        Return Info.LegalCopyright
        'Info.LegalTrademarks

    End Function


    Public Function Getasmtmk() '商標
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        'Info.CompanyName
        'Info.ProductName
        'Info.ProductVersion
        Return Info.Comments
        'Info.FileDescription
        'Info.LegalCopyright
        'Info.LegalTrademarks
    End Function
#End Region

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


    Public Function Chksuji(s As String) As Boolean
        '        Dim r As New System.Text.RegularExpressions.Regex(“^[a-zA-Z0-9]+$”)
        Dim r As New System.Text.RegularExpressions.Regex(“^[0-9]+$”)
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

#Region "日時間関数"

    Public Function TimeRead(ByVal StrDate As String) As Date
        Dim datBuff As Date
        datBuff = Date.FromOADate(StrDate)
        Return datBuff
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

    Public Function IsDate3(ByVal pVal As String) As String

        If IsDate2(pVal) Then
            IsDate3 = pVal
        Else
            IsDate3 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        End If
    End Function

    Public Function DateKata(ByVal pVal As String)
        If IsDate(pVal) Then
            DateKata = "'" & pVal & "'"
        Else
            DateKata = "NULL"
        End If
    End Function

    Public Function IsDateExpression(inputDate As String) As Boolean

        Const Regular As String = "^(?<year>[0-9]{4}|[0-9]{2})(?<datesep>\/|-|\.)(?<month>0?[1-9]|1[012])\k<datesep>(?<day>0?[1-9]|[12][0-9]|3[01])$"

        If System.Text.RegularExpressions.Regex.IsMatch(inputDate, Regular) Then
            Return True
        End If

        Return False

    End Function
#End Region

#Region "IsDecimal メソッド　"

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

    Public Function IsDecimal2(ByVal dValue As String) As String
        If IsNumeric(dValue) = False Then
            Return "0"
        Else
            Return dValue
        End If
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

#Region "DBチェック"

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 品コードの存在チェック
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function ChkSinaCd(sinacd As String) As Boolean
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT sinacd FROM " & schema & "m_seihin where sinacd ='" & sinacd & "'"

        If ClassPostgeDB.DbSel(strSQL) = sinacd Then
            ChkSinaCd = True
        Else
            MessageBox.Show("[ " & sinacd & " ]が製品マスタに存在しません")
            ChkSinaCd = False
        End If
    End Function
    Public Function ChkSinaCd1(sinacd As String) As Boolean
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        If sinacd = "" Then
            ChkSinaCd1 = False
        Else

            strSQL = "SELECT sinacd FROM " & schema & "m_seihin where sinacd ='" & sinacd & "'"

            If ClassPostgeDB.DbSel(strSQL) = sinacd Then
                ChkSinaCd1 = True
            Else
                ChkSinaCd1 = False
            End If
        End If
    End Function

    Public Function GetSinaNm(sinacd As String) As String
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        Dim nm As String

        strSQL = "SELECT seihinmei FROM " & schema & "m_seihin where sinacd ='" & sinacd & "'"
        nm = ClassPostgeDB.DbSel(strSQL)

        If nm <> "" Then
            GetSinaNm = nm
        Else
            GetSinaNm = ""
        End If
    End Function


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' SHOPの存在チェック
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function ChkShop(sinacd As String) As Boolean
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT sinacd FROM " & schema & "m_seihin where sinacd ='" & sinacd & "'"

        If ClassPostgeDB.DbSel(strSQL) = sinacd Then
            ChkShop = True
        Else
            MessageBox.Show("[ " & sinacd & " ]が 存在しません")
            ChkShop = False
        End If
    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' カテゴリマスタを返す
    '
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Function GetKry(ibuf As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        Dim nm As String

        strSQL = "SELECT  seq  FROM " & schema & "m_system where kbn = '9' and naiyou = '" & ibuf & "'"
        nm = ClassPostgeDB.DbSel(strSQL)

        Return (nm)

    End Function

#End Region

#Region "初期ファイル"
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' ファイル選択の初期値を保存　読み込み
    '
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Sub SetIniFile()
        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
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
        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()

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

#Region "CSV"


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' CSVファイルをINPUT
    '未使用
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    Public Sub CSVInput(FileName As String)

        Using parser As New TextFieldParser(FileName,
                                            Encoding.GetEncoding("Shift_JIS"))
            ' カンマ区切りの指定
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            ' フィールドが引用符で囲まれているか
            parser.HasFieldsEnclosedInQuotes = True
            ' フィールドの空白トリム設定
            parser.TrimWhiteSpace = False

            ' ファイルの終端までループ
            While Not parser.EndOfData
                ' フィールドを読込
                Dim row As String() = parser.ReadFields()
                For Each field As String In row
                    ' タブ区切りで出力
                    Console.Write(field + vbTab)
                Next
                Console.WriteLine()
            End While
        End Using
        Console.ReadKey()
    End Sub


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' CSV横込み
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Sub ReadCSV(ByVal dt As DataTable, ByVal hasHeader As Boolean, ByVal fileName As String, ByVal separator As String, ByVal quote As Boolean)
        'CSVを便利に読み込んでくれるTextFieldParserを使います。
        Dim parser As TextFieldParser = New TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"))
        'これは可変長のフィールドでフィールドの区切りのマーカーが使われている場合です。
        'フィールドが固定長の場合は
        'parser.TextFieldType = FieldType.FixedWidth;
        parser.TextFieldType = FieldType.Delimited
        '区切り文字を設定します。
        parser.SetDelimiters(separator)
        'クォーテーションがあるかどうか。
        '但しダブルクォーテーションにしか対応していません。シングルクォーテーションは認識しません。
        parser.HasFieldsEnclosedInQuotes = quote
        Dim data() As String
        'ここのif文では、DataTableに必要なカラムを追加するために最初に1行だけ読み込んでいます。
        'データがあるか確認します。
        If Not parser.EndOfData Then
            'CSVファイルから1行読み取ります。
            data = parser.ReadFields()
            'カラムの数を取得します。
            Dim cols As Integer = data.Length
            If hasHeader Then
                For i As Integer = 0 To cols - 1 Step 1
                    dt.Columns.Add(New DataColumn(data(i)))
                Next i
            Else
                For i As Integer = 0 To cols - 1 Step 1
                    'カラム名にダミーを設定します。
                    dt.Columns.Add(New DataColumn())
                Next i
                'DataTableに追加するための新規行を取得します。
                Dim row As DataRow = dt.NewRow()
                For i As Integer = 0 To cols - 1 Step 1
                    'カラムの数だけデータをうつします。
                    row(i) = data(i)
                Next i
                'DataTableに追加します。
                dt.Rows.Add(row)
            End If
        End If
        'ここのループがCSVを読み込むメインの処理です。
        '内容は先ほどとほとんど一緒です。
        While Not parser.EndOfData
            data = parser.ReadFields()
            Dim row As DataRow = dt.NewRow()
            For i As Integer = 0 To dt.Columns.Count - 1 Step 1
                row(i) = data(i)
            Next i
            dt.Rows.Add(row)
        End While
    End Sub

    '    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
    '   Dim quote As Boolean = False
    '  Dim separator As String = ""
    ' Select Case Me.cmbQuote.SelectedIndex
    'Case 0 To 1
    '           'クォーテーションあり
    '          quote = True
    'Case 2
    '           'クォーテーションなし
    '          quote = False
    'End Select
    'Select Case Me.cmbSeparator.SelectedIndex
    'Case 0
    '           'カンマ区切り
    '          separator = ","
    'Case 1
    '           'タブ区切り
    '          separator = "\t"
    'Case 2
    '           'スペース区切り
    '          separator = " "
    'End Select
    'If Me.openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    'Me.dt.Columns.Clear()
    'Me.dt.Clear()
    '       ReadCSV(Me.dt, Me.ckOutputColumnName.Checked, Me.OpenFileDialog1.FileName, separator, quote)
    'Me.DataGridView1.DataSource = Me.dt
    'End If
    'End Sub


    Public Sub ReadExcel(ByVal dt As DataTable, ByVal hasHeader As Boolean, ByVal fileName As String)


    End Sub
    ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' DataGridViewからCSVファイルへの書込処理
        ''' （WriteCsv:CSVファイルの書込処理の利用による）
        ''' </summary>
        ''' <param name="dgv">DataGridView</param>
        ''' <param name="astrFileName">ファイル名</param>
        ''' -----------------------------------------------------------------------------
    Public Function WriteCsvFromDGV(ByVal dgv As DataGridView, ByVal astrFileName As String) As Boolean

        WriteCsvFromDGV = False
        Try
            'DataGridView全体のデータ領域
            Dim arrData()() As String = Nothing

            '1行分を読込
            Dim arrHead As String() = Nothing
            '列ヘッダの名称取得

            For col As Integer = 0 To dgv.Columns.Count - 1
                '1列分の領域拡張
                ReDim Preserve arrHead(col)
                '列のヘッダデータ退避
                arrHead(col) = CStr(dgv.Columns(col).HeaderCell.Value)
            Next
            '1行分の領域拡張
            ReDim Preserve arrData(0)
            '列ヘッダ名退避
            arrData(0) = arrHead


            'データ行数分の処理
            For row As Integer = 0 To dgv.Rows.Count - 1
                '新規行は処理しない
                If dgv.Rows(row).IsNewRow Then
                    Continue For
                End If

                '1行分を読込
                Dim arrLine As String() = Nothing
                '列数分の処理
                For col As Integer = 0 To dgv.Columns.Count - 1
                    '1列分の領域拡張
                    ReDim Preserve arrLine(col)
                    '列データ退避
                    arrLine(col) = CStr(dgv.Rows(row).Cells(col).Value)
                Next

                '1行分の領域拡張
                ReDim Preserve arrData(row + 1)
                '1行データ退避
                arrData(row + 1) = arrLine
            Next

            '実際のCSVファイルの書込み
            Return WriteCsv(astrFileName, arrData)

        Catch ex As Exception
            'エラー
            MsgBox(ex.Message)
        End Try
    End Function

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

    Public Function Logent(i As String, nm As String, ss As String) As Boolean
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        Dim Msg As String
        Dim SqlExexc As Boolean
        Dim Nam As String
        SqlExexc = True

        If i = "SYSTEM" Then Return True

        strSQL = ""
        Select Case ss
            Case "0" 'logout
                strSQL = "DELETE FROM " & schema & "t_user_log WHERE id ='" & i & "'"
                Msg = ""
            Case "1" 'Login
                strSQL = "INSERT INTO " & schema & "t_user_log(id, nm, mn, nextb, ordr, entry_day)VALUES('" & i & "', '" & nm & "', 'ログイン', '0', '0', now())"
                Msg = "ユーザーIDが使用中です"
            Case "10" 'Menu
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='メニー表示' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（１０）"
            Case "2" 'SHOP
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='SHOP画面' ,entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（２）"
            Case "3" '機種
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='機種画面', entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（３）"
            Case "4" 'スペック
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='スペック画面',  entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（４）"

            Case "5" '在庫
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='在庫メニー' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５）"

            Case "5Z" '在庫
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='在庫メニー' , ordr='0', entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５）"
            Case "50" '在庫
                strSQL = "SELECT nm  FROM " & schema & "t_user_log where ordr= '1'"
                Nam = ClassPostgeDB.DbSel(strSQL)
                If Nam = "" Then
                    strSQL = "UPDATE " & schema & "t_user_log SET  mn='在庫メ戻',  ordr='1', entry_day = now() WHERE id='" & i & "'"
                    Msg = "権限エラーです（５１）"
                Else
                    SqlExexc = False
                    Msg = Nam & "さんが在庫管理を使用中です"
                End If

            Case "51" '在庫
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='在庫メ戻', entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５１）"

            Case "52" '発注書
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='発注書' ,  entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５２）"
            Case "53" '在庫
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='在庫画面' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５３）"

            Case "54" 'オーダーNo取り込み
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='オーダー取' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５４）"
            Case "55" 'ストック残
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='ストック' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（５５）"


            Case "6" '  売上
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='売上画面',  entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６）"
            Case "6Z" '  売上
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='売上画面', nextb='0',  entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６）"

            Case "60" '  販売実績

                strSQL = "SELECT nm  FROM " & schema & "t_user_log where nextb= '1'"
                Nam = ClassPostgeDB.DbSel(strSQL)
                If Nam = "" Then
                    strSQL = "UPDATE " & schema & "t_user_log SET  mn='戻' ,nextb='1',entry_day = now() WHERE id='" & i & "'"
                    Msg = "権限エラーです（６１）"
                Else
                    SqlExexc = False
                    Msg = Nam & "さんが売上管理を使用中です"
                End If
            Case "61" '  販売実績
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='戻' ,entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６１）"

            Case "62" '  NEXT-B
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='ＮＥＸＴ',entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６２）"

            Case "63" '  伝票
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='伝票画面', entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６３）"

            Case "64" '  伝票
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='キャンセル' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６４）"
            Case "65" '  伝票
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='キャンセル' , entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（６５）"

            Case "7" '  帳票
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='帳票画面',  entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（７）"
            Case "8" '  マスタ
                strSQL = "UPDATE " & schema & "t_user_log SET  mn='マスタＭ', entry_day = now() WHERE id='" & i & "'"
                Msg = "権限エラーです（８）"

            Case Else
                strSQL = ""
                Msg = ""
        End Select

        If SqlExexc Then
            If ClassPostgeDB.EXECnon(strSQL) Then
                If i <> "SYSTEM" Then
                    Select Case ss
                        Case "0"
                            ss = "ログアウト"
                        Case "1"
                            ss = "[" & Now_Var & " - " & GetIpAddress() & "]"
                        Case "2"
                            ss = "ショップ画面"
                        Case "3"
                            ss = "機種画面"
                        Case "4"
                            ss = "スペ画面"
                        Case "5"
                            ss = "在庫メニュー"
                        Case "50"
                            ss = "在庫メニュー"
                        Case "5Z"
                            ss = "在庫"
                        Case "51"
                            ss = "ストック取込"
                        Case "52"
                            ss = "発注書出力"
                        Case "53"
                            ss = "在庫画面"
                        Case "54"
                            ss = "オーダー取込"
                        Case "54"
                            ss = "ストック残表示"
                        Case "6"
                            ss = "売上メニュー"
                        Case "60"
                            ss = "売上"
                        Case "61"
                            ss = "販売実績取込"
                        Case "62"
                            ss = "NEXTB出庫出力"
                        Case "63"
                            ss = "伝票画面"
                        Case "64"
                            ss = "キャンセル在"
                        Case "65"
                            ss = "残明細"
                        Case "6Z"
                            ss = "売上閉"
                        Case "7"
                            ss = "帳票出力"
                        Case "8"
                            ss = "マスタメニュー"
                        Case "81"
                            ss = "製品マスタ"
                        Case "10"
                            ss = "メインメニュー"
                    End Select


                    strSQL = "INSERT INTO " & schema & "t_log(id, nm, mn, entry_day)VALUES('" & i & "', '" & nm & "', '" & ss & "', now())"
                    If ClassPostgeDB.EXECnon(strSQL) Then
                    End If
                End If

                Logent = True
            Else
                MessageBox.Show(Msg)
                Logent = False
            End If
        Else
            MessageBox.Show(Msg)
            Logent = False

        End If

    End Function


    Private Function GetIpAddress() As String

        Dim HostName As String = System.Net.Dns.GetHostName()

        Return HostName

        'Dim HostIP() As System.Net.IPAddress
        'Dim HostIPAdress As String = ""
        'HostIP = System.Net.Dns.GetHostEntry(HostName).AddressList

    End Function

#End Region

#Region "関数"

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' コンボボックスに指定された内容を選択表示する
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Sub SetComboBox(cmb As ComboBox, buf As String)
        Dim idx As Integer

        For idx = 1 To cmb.Items.Count - 1
            cmb.SelectedIndex = idx
            If cmb.Text = buf Then
                Return
            End If
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

#Region "セレクト"

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '更新時間チェック
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '
    Public Function GetUpdateTime(table As String)
        Dim strSQL As String
        Dim ClassPostgeDB As New ClassPostgeDB
        strSQL = "SELECT update_day FROM " & schema & "" & table

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
    Public Function Get_nounyusu(sinacd As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "SELECT nouhinsu FROM " & schema & "t_genzaiko where  sinacd = '" & sinacd & "'"
        Get_nounyusu = ClassPostgeDB.DbSel(strSQL)

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
    '現在庫更新
    '
    Public Sub Set_genzaiko_jyutyuu(sinacd As String, genzaiko As Integer, jyutyuu As Integer, entry_sya As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim ret As String
        Dim strSQL As String


        strSQL = "SELECT jyutyuu  FROM " & schema & "t_genzaiko where sinacd ='" & sinacd & "'"
        ret = ClassPostgeDB.DbSel(strSQL)

        If ret = "" Then
            strSQL = "INSERT INTO " & schema & "t_genzaiko(sinacd, genzaiko, tyuuzan, jyutyuu,entry_day, entry_sya)VALUES("
            strSQL &= "'" & sinacd & "'"
            strSQL &= ",'" & genzaiko.ToString & "'"
            strSQL &= ",'" & jyutyuu.ToString & "'"
            strSQL &= ",0"
            strSQL &= ",now()"
            strSQL &= ",'" & entry_sya & "'"
            strSQL &= ")"
        Else

            strSQL = "UPDATE " & schema & "t_genzaiko SET "
            'strSQL &= " tyuuzan  =  tyuuzan "
            strSQL &= " jyutyuu  = " & jyutyuu.ToString & ""
            strSQL &= ", entry_day = now()"
            strSQL &= ", entry_sya ='" & entry_sya & "'"
            strSQL &= "  WHERE sinacd ='" & sinacd & "'"

        End If

        ClassPostgeDB.EXEC(strSQL)
    End Sub
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 在庫入庫処理
    '
    Public Sub SetNyuko(sinacd As String, genzaiko As Integer, tyuuzan As Integer, entry_sya As String)

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim ret As String
        Dim strSQL As String

        strSQL = "SELECT tyuuzan FROM " & schema & "t_genzaiko where sinacd ='" & sinacd & "'"
        ret = ClassPostgeDB.DbSel(strSQL)
        If ret = "" Then
            genzaiko = genzaiko + tyuuzan
            tyuuzan = 0

            strSQL = "INSERT INTO " & schema & "t_genzaiko(sinacd, genzaiko, tyuuzan, entry_day, entry_sya)VALUES("
            strSQL &= "'" & sinacd & "'"
            strSQL &= ",'" & genzaiko.ToString & "'"
            strSQL &= ",'" & tyuuzan.ToString & "'"
            strSQL &= ",now()"
            strSQL &= ",'" & entry_sya & "'"
            strSQL &= ")"

        Else

            tyuuzan = Integer.Parse(ret) - tyuuzan
            genzaiko = genzaiko + tyuuzan

            strSQL = "UPDATE " & schema & "t_genzaiko SET "
            strSQL &= " genzaiko ='" & genzaiko.ToString & "'"
            strSQL &= ",tyuuzan  ='" & tyuuzan.ToString & "'"
            strSQL &= ",entry_day = now()"
            strSQL &= ",entry_sya ='" & entry_sya & "'"

            strSQL &= " WHERE sinacd ='" & sinacd & "'"

        End If
        ClassPostgeDB.EXEC(strSQL)
    End Sub

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' 消費税を取得
    '
    Public Function GetTax() As String

        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String

        strSQL = "SELECT naiyou FROM " & schema & "m_system where kbn='0' and seq > to_char( now() ,'yyyy/mm/dd') order by seq LIMIT 1" '消費税
        Return ClassPostgeDB.DbSel(strSQL)

    End Function


    Public Function Zeinuki(kingaku As String)
        Dim tax As String
        Dim tankla As Double

        tax = GetTax()

        tankla = Double.Parse(kingaku) / ((Double.Parse(tax) / 100) + 1)

        Return tankla.ToString("0")

    End Function





    Public Function GetSystemMst(ku As String, seq As String) 'システム設定マスタ
        Dim ClassPostgeDB As New ClassPostgeDB
        Dim strSQL As String
        strSQL = "Select  naiyou From " & schema & "m_system  Where kbn ='" & ku & "' And seq ='" & seq & "'"
        GetSystemMst = ClassPostgeDB.DbSel(strSQL)

    End Function





#End Region

#Region "入力"
    Public Sub CSVDataGridInput(dt As DataGridView, filename As String, obj As Object)

        Dim con_str As String 'データ保持用
        Try
            '書き込むファイルを開く

            Dim SR As New System.IO.StreamReader(filename, System.Text.Encoding.GetEncoding("shift_jis")) 'StreamReader文字化け防止


            ' データをすべてクリア
            dt.Columns.Clear()
            con_str = SR.ReadLine()
            If con_str = Nothing Then Exit Sub
            con_str = con_str.Replace(""",""", ",")
            con_str = con_str.Replace(""",", ",")
            con_str = con_str.Replace("""", "")

            Dim ColPlus() As String = con_str.Split(",")
            For Each da In ColPlus
                dt.Columns.Add(da, da)
            Next

            Do
                con_str = SR.ReadLine() 'csvファイルの2行目以降を読み込む
                If con_str = Nothing Then Exit Do 'データが無ければループ終了
                con_str = con_str.Replace(""",""", ",")
                con_str = con_str.Replace(""",", ",")
                con_str = con_str.Replace("""", "")
                Dim RowPlus() As String = con_str.Split(",")
                If RowPlus(0) = "" Then '品コードがなければ飛ばす
                Else
                    dt.Rows.Add(RowPlus) 'DataGrid行を追加
                    System.Windows.Forms.Application.DoEvents()

                    obj.text = Integer.Parse(obj.text) + 1
                    System.Windows.Forms.Application.DoEvents()
                End If


            Loop
            SR.Close()
            dt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception


        End Try
    End Sub

    Public Sub ExcelDataGridInput(dt As DataGridView, filename As String)

        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim strPath As String
        Dim rowloop As Integer
        Dim colloop As Integer

        strPath = filename

        app = New Microsoft.Office.Interop.Excel.Application
        book = app.Workbooks.Open(strPath)
        sheet = book.Sheets(1)

        app.Visible = False

        For rowloop = 0 To dt.Rows.Count - 1
            For colloop = 0 To dt.Columns.Count - 1
                'sheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Item(colloop).ToString
            Next
        Next

        app.Visible = True

    End Sub

#End Region

#Region "出力"

    ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' CSVファイルの書込処理
        ''' </summary>
        ''' <param name="astrFileName">ファイル名</param>
        ''' <param name="aarrData">書込データ文字列の2次元配列</param>
        ''' <returns>True:結果OK, False:NG</returns>
        ''' <remarks>カラム名をファイルに出力したい場合は、書込データの先頭に設定すること</remarks>
        ''' -----------------------------------------------------------------------------
    Private Function WriteCsv(ByVal astrFileName As String, ByVal aarrData As String()()) As Boolean
        WriteCsv = False
        'ファイルStreamWriter
        Dim sw As System.IO.StreamWriter = Nothing

        Try
            'CSVファイルに書込に使うEncoding
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            '書き込むファイルを開く
            sw = New System.IO.StreamWriter(astrFileName, False, enc)

            For Each arrLine() As String In aarrData
                Dim blnFirst As Boolean = True
                Dim strLIne As String = ""
                For Each str As String In arrLine
                    If blnFirst = False Then
                        '「,」(カンマ)の書込
                        sw.Write(",")
                    End If
                    blnFirst = False
                    '1カラムデータの書込
                    str = """" & str & """"
                    sw.Write(str)
                Next
                '改行の書込
                sw.Write(vbCrLf)
            Next

            '正常終了
            Return True

        Catch ex As Exception
            'エラー
            MsgBox(ex.Message)
        Finally
            '閉じる
            If sw IsNot Nothing Then
                sw.Close()
            End If
        End Try
    End Function
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' Excel出力
    '
    Public Sub ExcelOout2(dt As DataTable)
        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Range As Microsoft.Office.Interop.Excel.Range
        Dim rowloop As Integer
        Dim colloop As Integer

        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        'strPath = System.Windows.Forms.Application.StartupPath & "\excel\" & filename

        app = New Microsoft.Office.Interop.Excel.Application

        app.Workbooks.Add()
        book = app.Workbooks(1)
        sheet = CType(book.Worksheets(1), Excel.Worksheet)
        'app.Visible = True
        Range = sheet.Cells(1, 1)
        Range.NumberFormatLocal = "@"

        app.Visible = False

        For colloop = 0 To dt.Columns.Count - 1
            Range = sheet.Cells(1, colloop + 1)
            Range.NumberFormatLocal = "@"
            Range.Value = dt.Columns(colloop).ColumnName

            'sheet.Cells(1, colloop + 1) = dt.Columns(colloop).HeaderText.ToString()
        Next

        For rowloop = 0 To dt.Rows.Count - 1
            For colloop = 0 To dt.Columns.Count - 1
                sheet.Cells(rowloop + 2, colloop + 1).NumberFormatLocal = "@"
                sheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Item(colloop).ToString
            Next
            FormMeter.GEN = rowloop
            FormMeter.Disp()
        Next

        FormMeter.CLos()
        app.Visible = True


        Marshal.ReleaseComObject(app)
        Marshal.ReleaseComObject(book)
        Marshal.ReleaseComObject(sheet)
        Marshal.ReleaseComObject(Range)

    End Sub
    '
    '　コンロ用
    '　横展開用
    '
    Public Sub ExcelOout3(dt As DataTable, savefaine As String)


        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Range As Microsoft.Office.Interop.Excel.Range
        Dim rowloop As Integer
        Dim colloop As Integer
        Dim nm As String
        Dim x As Integer
        Dim y As Integer
        Dim maxcol As Integer
        Dim wmaxcol As Integer



        maxcol = 0
        wmaxcol = 0
        nm = ""
        For rowloop = 0 To dt.Rows.Count - 1
            If nm = dt.Rows(rowloop).Item(0).ToString Then
                wmaxcol = wmaxcol + 1
            Else
                If maxcol < wmaxcol Then
                    maxcol = wmaxcol
                End If
                wmaxcol = 0
            End If
            nm = dt.Rows(rowloop).Item(0).ToString
        Next


        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        'strPath = System.Windows.Forms.Application.StartupPath & "\excel\" & filename

        app = New Microsoft.Office.Interop.Excel.Application

        app.Workbooks.Add()
        book = app.Workbooks(1)
        sheet = CType(book.Worksheets(1), Excel.Worksheet)
        'app.Visible = True
        Range = sheet.Cells(1, 1)
        Range.NumberFormatLocal = "@"

        app.Visible = False

        For colloop = 0 To dt.Columns.Count - 1
            Range = sheet.Cells(1, colloop + 1)
            Range.NumberFormatLocal = "@"
            Range.Value = dt.Columns(colloop).ColumnName

            'sheet.Cells(1, colloop + 1) = dt.Columns(colloop).HeaderText.ToString()
        Next

        For colloop = 0 To maxcol
            Range = sheet.Cells(1, 3 + colloop)
            Range.NumberFormatLocal = "@"
            Range.Value = "パーツ部品" & colloop + 1
        Next



        nm = ""
        y = -1
        For rowloop = 0 To dt.Rows.Count - 1

            If nm = dt.Rows(rowloop).Item(0).ToString Then
                x = x + 1
                sheet.Cells(y + 2, x).NumberFormatLocal = "@"
                sheet.Cells(y + 2, x) = dt.Rows(rowloop).Item(2).ToString

            Else
                y = y + 1
                nm = dt.Rows(rowloop).Item(0).ToString
                x = 3
                sheet.Cells(y + 2, 1).NumberFormatLocal = "@"
                sheet.Cells(y + 2, 1) = StrConv(dt.Rows(rowloop).Item(0).ToString, VbStrConv.Narrow)

                sheet.Cells(y + 2, 2).NumberFormatLocal = "@"
                sheet.Cells(y + 2, 2) = dt.Rows(rowloop).Item(1).ToString

                sheet.Cells(y + 2, 3).NumberFormatLocal = "@"
                sheet.Cells(y + 2, 3) = dt.Rows(rowloop).Item(2).ToString

            End If


            FormMeter.GEN = rowloop
            FormMeter.Disp()
        Next

        Try
            '保存する
            If savefaine <> "" Then
                book.SaveAs(savefaine)
            End If
        Catch ex As Exception
            MsgBox("ファイル名が不正です")
        End Try


        FormMeter.CLos()
        app.Visible = True

        Marshal.ReleaseComObject(app)
        Marshal.ReleaseComObject(book)
        Marshal.ReleaseComObject(sheet)
        Marshal.ReleaseComObject(Range)

    End Sub


    Public Sub ExcelOut(dt As DataTable, filename As String, savefaine As String)

        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim strPath As String
        Dim rowloop As Integer
        Dim colloop As Integer

        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        strPath = System.Windows.Forms.Application.StartupPath & "\excel\" & filename

        app = New Microsoft.Office.Interop.Excel.Application

        book = app.Workbooks.Open(strPath)
        sheet = book.Sheets(1)

        'Try
        app.Visible = False

        For rowloop = 0 To dt.Rows.Count - 1
            For colloop = 0 To dt.Columns.Count - 1
                sheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Item(colloop).ToString
            Next
            FormMeter.GEN = rowloop
            FormMeter.Disp()
        Next
        '保存する
        Try
            '保存する
            If savefaine <> "" Then
                book.SaveAs(savefaine)
            End If
        Catch ex As Exception
            MsgBox("ファイル名が不正です")
        End Try


        FormMeter.CLos()
        app.Visible = True

        'Catch ex As Exception
        'Throw ex

        'Finally
        'オブジェクト解放
        'app.Quit()
        'End Try
    End Sub


    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'CSV出力
    '
    Public Sub CSVOut2(dt As DataTable, filename As String)
        Dim rowloop As Integer
        Dim colloop As Integer

        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        Dim sw As System.IO.StreamWriter = Nothing
        Try
            sw = New System.IO.StreamWriter(filename, False, System.Text.Encoding.GetEncoding("Shift_JIS"))

            'For colloop = 0 To dt.Columns.Count - 1
            '    If colloop > 0 Then
            '        sw.Write(",")
            '    End If
            '    sw.Write("""")
            '    sw.Write(dt.Columns(colloop).ColumnName)
            '    sw.Write("""")
            'Next

            sw.Write(vbCrLf)
            For rowloop = 0 To dt.Rows.Count - 1
                For colloop = 0 To dt.Columns.Count - 1
                    If colloop > 0 Then
                        sw.Write(",")
                    End If
                    'sw.Write("""")
                    sw.Write("")
                    sw.Write(dt.Rows(rowloop).Item(colloop).ToString)
                    'sw.Write("""")
                    sw.Write("")
                Next
                sw.Write(vbCrLf)
                FormMeter.GEN = rowloop
                FormMeter.Disp()
            Next
        Catch
            FormMeter.CLos()
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            FormMeter.CLos()
            MessageBox.Show("出力しました")
        End Try

    End Sub
    '
    'コンロ用
    '
    Public Sub CSVOut3(dt As DataTable, filename As String)
        Dim rowloop As Integer
        ' Dim colloop As Integer
        Dim nm As String = ""
        Dim maxcol As Integer
        Dim wmaxcol As Integer


        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        Dim sw As System.IO.StreamWriter = Nothing
        Try
            maxcol = 0
            wmaxcol = 0
            nm = ""
            For rowloop = 0 To dt.Rows.Count - 1
                If nm = dt.Rows(rowloop).Item(0).ToString Then
                    wmaxcol = wmaxcol + 1
                Else
                    If maxcol < wmaxcol Then
                        maxcol = wmaxcol
                    End If
                    wmaxcol = 0
                End If
                nm = dt.Rows(rowloop).Item(0).ToString
            Next

            sw = New System.IO.StreamWriter(filename, False, System.Text.Encoding.GetEncoding("Shift_JIS"))

            nm = ""
            'For colloop = 0 To dt.Columns.Count - 1
            '    If colloop > 0 Then
            '        sw.Write(",")
            '    End If
            '    sw.Write("""")
            '    sw.Write(dt.Columns(colloop).ColumnName)
            '    sw.Write("""")
            'Next

            'For colloop = 0 To maxcol - 1
            '    sw.Write(",""")
            '    sw.Write("パーツ品番" & colloop + 2)
            '    sw.Write("""")
            'Next

            'sw.Write(vbCrLf)
            For rowloop = 0 To dt.Rows.Count - 1

                If nm = dt.Rows(rowloop).Item(0).ToString Then
                    'sw.Write(",""")
                    sw.Write(",")
                    sw.Write(dt.Rows(rowloop).Item(2).ToString)
                    'sw.Write("""")
                    sw.Write("")


                Else
                    If nm <> "" Then
                        sw.Write(vbCrLf)
                    End If

                    nm = dt.Rows(rowloop).Item(0).ToString

                    'sw.Write("""")
                    sw.Write("")
                    sw.Write(StrConv(dt.Rows(rowloop).Item(0).ToString, VbStrConv.Narrow))
                    'sw.Write("""")
                    sw.Write("")

                    'sw.Write(",""")
                    sw.Write(",")
                    sw.Write(dt.Rows(rowloop).Item(1).ToString)
                    'sw.Write("""")
                    sw.Write("")

                    'sw.Write(",""")
                    sw.Write(",")
                    sw.Write(dt.Rows(rowloop).Item(2).ToString)
                    'sw.Write("""")
                    sw.Write("")

                End If


                FormMeter.GEN = rowloop
                FormMeter.Disp()
            Next
        Catch
            FormMeter.CLos()
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            FormMeter.CLos()
            MessageBox.Show("出力しました")
        End Try

    End Sub

    Public Sub CSVOut(dt As DataTable, filename As String, header As String)
        Dim rowloop As Integer
        Dim colloop As Integer

        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        Dim sw As System.IO.StreamWriter = Nothing
        Try
            sw = New System.IO.StreamWriter(filename, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
            sw.WriteLine(header)




            For rowloop = 0 To dt.Rows.Count - 1
                For colloop = 0 To dt.Columns.Count - 1
                    sw.Write("""")
                    sw.Write(dt.Rows(rowloop).Item(colloop).ToString)
                    sw.Write("""")
                    sw.Write(",")
                Next
                sw.Write(vbCrLf)
                FormMeter.GEN = rowloop
                FormMeter.Disp()
            Next
        Catch
            FormMeter.CLos()
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            FormMeter.CLos()
            MessageBox.Show("出力しました")
        End Try
    End Sub
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'EXCEL 出力
    '
    Public Sub excelOutDataGred(dt As DataGridView, crls As Boolean)

        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Range As Microsoft.Office.Interop.Excel.Range
        Dim rowloop As Integer
        Dim colloop As Integer

        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        'strPath = System.Windows.Forms.Application.StartupPath & "\excel\" & filename

        app = New Microsoft.Office.Interop.Excel.Application
        app.Visible = False

        app.Workbooks.Add()
        book = app.Workbooks(1)
        sheet = CType(book.Worksheets(1), Excel.Worksheet)
        'app.Visible = True
        Range = sheet.Cells(1, 1)
        Range.NumberFormatLocal = "@"

        For colloop = 0 To dt.Columns.Count - 1
            Range = sheet.Cells(1, colloop + 1)
            Range.NumberFormatLocal = "@"
            Range.Value = dt.Columns(colloop).HeaderText.ToString()

            'sheet.Cells(1, colloop + 1) = dt.Columns(colloop).HeaderText.ToString()
        Next


        For rowloop = 0 To dt.Rows.Count - 1
            For colloop = 0 To dt.Columns.Count - 1

                Range = sheet.Cells(rowloop + 2, colloop + 1)
                Range.NumberFormatLocal = "@"
                If (crls) Then
                    Range.Value = Oncrlf(dt.Rows(rowloop).Cells(colloop).Value.ToString())
                Else
                    Try
                        Range.Value = dt.Rows(rowloop).Cells(colloop).Value.ToString()

                    Catch ex As Exception

                    End Try
                End If
                'sheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Cells(colloop).Value.ToString()

            Next
            FormMeter.GEN = rowloop
            FormMeter.Disp()
        Next
        FormMeter.CLos()
        app.Visible = True

        Marshal.ReleaseComObject(app)
        Marshal.ReleaseComObject(book)
        Marshal.ReleaseComObject(sheet)
        Marshal.ReleaseComObject(Range)


    End Sub


    Public Sub csvOutDataGred(dt As DataGridView, fileName As String, StartCol As Integer, crls As Boolean)
        Dim rowloop As Integer
        Dim colloop As Integer
        Dim FormMeter As New FormMeter

        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()

        Dim sw As System.IO.StreamWriter = Nothing
        Try
            sw = New System.IO.StreamWriter(fileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))

            For colloop = StartCol To dt.Columns.Count - (1)
                If colloop > 0 Then
                    sw.Write(",")

                End If
                sw.Write("""")
                sw.Write(dt.Columns(colloop).HeaderText.ToString())
                sw.Write("""")
            Next
            sw.Write(vbCrLf)
            For rowloop = 0 To dt.Rows.Count - 2
                For colloop = StartCol To dt.Columns.Count - (1)
                    If colloop > 0 Then
                        sw.Write(",")
                    End If
                    sw.Write("""")
                    If (crls) Then
                        sw.Write(Oncrlf(dt.Rows(rowloop).Cells(colloop).Value))
                    Else
                        sw.Write(dt.Rows(rowloop).Cells(colloop).Value)
                    End If
                    sw.Write("""")
                Next
                sw.Write(vbCrLf)
                FormMeter.GEN = rowloop
                FormMeter.Disp()
            Next
        Catch
            FormMeter.CLos()
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            FormMeter.CLos()
            MessageBox.Show("出力しました")
        End Try

    End Sub

    '============================
    'EXCELファイルオープン
    '23.12.07 k.s
    '============================
    Public Sub OpenExcel(filename As String)
        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet

        Try
            app = New Microsoft.Office.Interop.Excel.Application
            book = app.Workbooks.Open(filename)
            sheet = book.Sheets(1)

            ' Excel を表示する
            app.Visible = True

            Marshal.ReleaseComObject(app)
            Marshal.ReleaseComObject(book)
            Marshal.ReleaseComObject(sheet)
        Catch ex As Exception
            MessageBox.Show("ファイルオープンでエラーです")
        End Try

    End Sub

    '============================
    '外部アプリケーションのオープン
    '23.12.07 k.s
    '============================
    Public Sub OpenProcess(FileName As String)
        Try
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(FileName)
        Catch ex As Exception
            MessageBox.Show("ファイルオープンでエラーです")
        End Try
    End Sub
#End Region

#Region "DataGridView"


    Public Function SettextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean, midol As DataGridViewContentAlignment) As Integer
        Dim textColumn As New DataGridViewTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).DefaultCellStyle.Alignment = midol '

        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        If wid = 0 Then
            dgv.Columns(ro).Visible = False
        End If

        ro = ro + 1
        Return ro
    End Function




#End Region

End Module
