Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection
Imports System.Text


'------------------------------------------------------------------
'  アプリダウンロード　　アプリ名-1.0.0.0.zip　→　　アプリ名.exe
'
'------------------------------------------------------------------
Public Class ClassTransV4
    Dim appdir As String = System.Windows.Forms.Application.StartupPath
    Dim windir As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows)
    Dim tmpdir As String = "C:\noritz" 'System.Environment.GetFolderPath(System.Environment.SpecialFolder.Templates)
    Dim url As String
    Private Const vbs As String = "tvb.vbs"

    Dim BatFile As String

    '----------------------------------------------------------
    ' APをダウンロード実行
    ' ap名    = 
    'varsion  = 3
    '----------------------------------------------------------
    '現在のバージョンをダウンロードする
    Public Sub TransExecV3()
        TransExecV3(Get製品(), NextVersion(GetVer()))
    End Sub
    '次のバージョンをダウンロードする
    Public Sub TransExecV3(ap As String)
        TransExecV3(ap, GetVer())
    End Sub
    '指定のバージョンをダウンロードする
    Public Sub TransExecV3(ap As String, var As String)

#If DEBUG Then
        'Return
#End If

        Dim appPath As String = System.Windows.Forms.Application.StartupPath
        Dim kil As String
        Dim exe As String
        Dim exe2 As String
        Dim crentdir As String

        url = "http://" & get_dns() & "/dl/"
        BatFile = ap & "c.bat"

        '存在チェック
        If ChkHTTP(url & ap & "-" & var & ".zip") Then

            If MsgBox("最新バージョンにアップしますか", vbOKCancel) = vbCancel Then
                Exit Sub
            End If
            Dim w As New FormWait
            w.Show()

            If DownloadEXE_HTTP_V3(ap, var) Then
                crentdir = appPath.Replace("\", "\\")
                ' Copy Exe
                kil = "taskkill /im " & ap & ".exe /t /f"
                exe = "copy /Y """ & tmpdir & "\si\solution\*.*"" " & crentdir & "\"
                exe2 = "start " & crentdir & "\" & ap & ".exe"
                'TextBox1.Textの内容を書き込む
                Dim sw As New System.IO.StreamWriter(tmpdir & "\si\" & BatFile, False, System.Text.Encoding.GetEncoding("shift_jis"))
                sw.WriteLine("@echo off")
                'sw.WriteLine("mode con lines=1 cols=20")
                'sw.WriteLine("timeout /t 2 /nobreak >nul")
                sw.WriteLine(kil)
                sw.WriteLine(exe)
                sw.WriteLine(exe2)
                sw.WriteLine("EXIT")
                sw.Close()

                sw = New StreamWriter(tmpdir + "\si" & "\" & vbs, False, Encoding.GetEncoding("shift_jis"))

                sw.WriteLine("Option Explicit")
                sw.WriteLine("Const vbHide = 0                           'ウィンドウを非表示")
                sw.WriteLine("Const vbNormalFocus = 1                '通常のウィンドウ、かつ最前面のウィンドウ")
                sw.WriteLine("Const vbMinimizedFocus = 2            '最小化、かつ最前面のウィンドウ")
                sw.WriteLine("Const vbMaximizedFocus = 3           '最大化、かつ最前面のウィンドウ")
                sw.WriteLine("Const vbNormalNoFocus = 4           '通常のウィンドウ、ただし、最前面にはならない")
                sw.WriteLine("Const vbMinimizedNoFocus = 6      '最小化、ただし、最前面にはならない")

                sw.WriteLine("Dim objWShell")
                sw.WriteLine("Set objWShell = CreateObject(""WScript.Shell"")")
                sw.WriteLine("objWShell.Run ""cmd /c " + BatFile + """, vbMinimizedNoFocus, False")
                sw.WriteLine("Set objWShell = Nothing")
                sw.Close()

                execvbs(tmpdir + "\si" & "\" & vbs)


                Application.Exit()
            End If
        End If
    End Sub
    Public Sub TransExecV3_2(ap As String)

#If DEBUG Then
        Return
#End If

        Dim appPath As String = System.Windows.Forms.Application.StartupPath
        Dim kil As String
        Dim exe As String
        Dim exe2 As String
        Dim crentdir As String

        url = "http://" & get_dns() & "/dl/"
        BatFile = ap & "c.bat"

        '存在チェック
        If ChkHTTP(url & ap & ".zip") Then

            If MsgBox("最新バージョンにアップしますか", vbOKCancel) = vbCancel Then
                Exit Sub
            End If
            Dim w As New FormWait
            w.Show()

            If DownloadEXE_HTTP_V3(ap) Then
                crentdir = appPath.Replace("\", "\\")
                ' Copy Exe
                kil = "taskkill /im " & ap & ".exe /t /f"
                exe = "copy /Y """ & tmpdir & "\si\solution\*.*"" " & crentdir & "\"
                exe2 = "start " & crentdir & "\" & ap & ".exe"
                'TextBox1.Textの内容を書き込む
                Dim sw As New System.IO.StreamWriter(tmpdir & "\si\" & BatFile, False, System.Text.Encoding.GetEncoding("shift_jis"))
                sw.WriteLine("@echo off")
                'sw.WriteLine("mode con lines=1 cols=20")
                'sw.WriteLine("timeout /t 2 /nobreak >nul")
                sw.WriteLine(kil)
                sw.WriteLine(exe)
                sw.WriteLine(exe2)
                sw.WriteLine("EXIT")
                sw.Close()

                sw = New StreamWriter(tmpdir + "\si" & "\" & vbs, False, Encoding.GetEncoding("shift_jis"))

                sw.WriteLine("Option Explicit")
                sw.WriteLine("Const vbHide = 0                           'ウィンドウを非表示")
                sw.WriteLine("Const vbNormalFocus = 1                '通常のウィンドウ、かつ最前面のウィンドウ")
                sw.WriteLine("Const vbMinimizedFocus = 2            '最小化、かつ最前面のウィンドウ")
                sw.WriteLine("Const vbMaximizedFocus = 3           '最大化、かつ最前面のウィンドウ")
                sw.WriteLine("Const vbNormalNoFocus = 4           '通常のウィンドウ、ただし、最前面にはならない")
                sw.WriteLine("Const vbMinimizedNoFocus = 6      '最小化、ただし、最前面にはならない")

                sw.WriteLine("Dim objWShell")
                sw.WriteLine("Set objWShell = CreateObject(""WScript.Shell"")")
                sw.WriteLine("objWShell.Run ""cmd /c " + BatFile + """, vbMinimizedNoFocus, False")
                sw.WriteLine("Set objWShell = Nothing")
                sw.Close()

                execvbs(tmpdir + "\si" & "\" & vbs)


                Application.Exit()
            End If
        End If
    End Sub
    '
    '
    Private Sub execvbs(vbsFilePath As String)


        Dim sPos As Integer = vbsFilePath.LastIndexOf("\")
        Dim sdir As String = vbsFilePath.Substring(0, sPos)
        Dim fn As String = vbsFilePath.Substring(sPos + 1, vbsFilePath.Length - sPos - 1)

        Using proc As Process = New Process()
            proc.StartInfo.FileName = "cscript.exe"
            proc.StartInfo.WorkingDirectory = sdir          '//Path.GetDirectory(vbsFilePath);では失敗するかも
            proc.StartInfo.Arguments = "//B //Nologo " + fn     '; //Path.GetFileName(vbsFilePath);では失敗するかも
            'proc.StartInfo.Argments = "//B //Nologo " + fn'; //Path.GetFileName(vbsFilePath);では失敗するかも
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            proc.StartInfo.CreateNoWindow = True
            proc.Start()
            proc.WaitForExit()
            proc.Close()
        End Using


    End Sub


    '------------------------------------------------------------------------
    '   HTTP で取得
    '
    'Private Declare Function DeleteUrlCacheEntry Lib "wininet" Alias "DeleteUrlCacheEntryA" (ByVal lpszUrlName As String) As Long
    Private Function DownloadEXE_HTTP_V3(exen As String, var As String) As Boolean
        Try
            CreateDirectory(tmpdir)
            DeleteTmp(tmpdir & "\si\solution")
            DeleteTmp(tmpdir & "\si")

            System.IO.Directory.CreateDirectory(tmpdir & "\si")
            System.IO.Directory.CreateDirectory(tmpdir & "\si\solution")

            'Dim lngResult As Long
            '指定のファイルのキャッシュを削除
            'lngResult = DeleteUrlCacheEntry(url)
            'Process.Start("RunDll32", "InetCpl.cpl,ClearMyTracksByProcess 8")

            Dim wc As New System.Net.WebClient()
            wc.DownloadFile(url & exen & "-" & var & ".zip", tmpdir & "\si\" & exen & ".zip")
            wc.Dispose()

            Dim zipPath As String = tmpdir & "\si\" & exen & ".zip"
            Dim extractPath As String = tmpdir & "\si\solution\"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            Return True
        Catch ex As Exception
            'DeleteTmp(tmpdir & "\si")
            Return False
        End Try

    End Function
    Private Function DownloadEXE_HTTP_V3(exen As String) As Boolean
        Try
            CreateDirectory(tmpdir)
            DeleteTmp(tmpdir & "\si\solution")
            DeleteTmp(tmpdir & "\si")

            System.IO.Directory.CreateDirectory(tmpdir & "\si")
            System.IO.Directory.CreateDirectory(tmpdir & "\si\solution")

            'Dim lngResult As Long
            '指定のファイルのキャッシュを削除
            'lngResult = DeleteUrlCacheEntry(url)
            'Process.Start("RunDll32", "InetCpl.cpl,ClearMyTracksByProcess 8")

            Dim wc As New System.Net.WebClient()
            wc.DownloadFile(url & exen & ".zip", tmpdir & "\si\" & exen & ".zip")
            wc.Dispose()

            Dim zipPath As String = tmpdir & "\si\" & exen & ".zip"
            Dim extractPath As String = tmpdir & "\si\solution\"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            Return True
        Catch ex As Exception
            'DeleteTmp(tmpdir & "\si")
            Return False
        End Try

    End Function


    Private Sub DeleteTmp(wPath As String)
        Dim result

        result = Dir(wPath, vbDirectory)

        If result <> "" Then
            Try
                '指定フォルダ内の全ファイルを取得
                Dim arrFiles() As String = System.IO.Directory.GetFiles(wPath)

                '全ファイル削除
                For Each strFile As String In arrFiles
                    System.IO.File.Delete(strFile)
                Next
            Catch ex As Exception
                'エラー処理が必要な場合は、ここに記述する
            End Try
            System.IO.Directory.Delete(wPath)
        Else
            Exit Sub
        End If
    End Sub
    '---------------------------------------------------------------
    ' URLの存在チェック
    '
    '---------------------------------------------------------------
    Private Function ChkHTTP(url As String) As Boolean

        WebRequest.DefaultWebProxy = Nothing ' プロキシ未使用を明示

        Dim statusCode As HttpStatusCode = GetStatusCode(url)

        ' 列挙体の値を数値に変換
        Dim code As Integer = CType(statusCode, Integer)

        If code >= 400 Then  ' 4xx、5xxはアクセス失敗とする
            Return False
        Else
            Return True
        End If

        Return False
    End Function
    '---------------------------------------------------------------
    ' urlにアクセスしてステータス・コードを返す
    Private Function GetStatusCode(ByVal url As String) As HttpStatusCode

        Dim req As HttpWebRequest =
                    CType(WebRequest.Create(url), HttpWebRequest)
        Dim res As HttpWebResponse = Nothing
        Dim statusCode As HttpStatusCode
        req.Timeout = 500

        Try
            res = CType(req.GetResponse(), HttpWebResponse)
            statusCode = res.StatusCode
        Catch ex As WebException
            res = CType(ex.Response, HttpWebResponse)
            If Not res Is Nothing Then
                statusCode = res.StatusCode
            Else
                'Throw ' サーバ接続不可などの場合は再スロー
                statusCode = 999
            End If
        Finally
            If Not res Is Nothing Then
                res.Close()
            End If
        End Try
        Return statusCode
    End Function

    '---------------------------------------------------------------- 追加
    Private Function NextVersion(nVER As String)
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
    Private Function GetVer()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Return Info.ProductVersion
    End Function
    Private Function Get製品()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Get製品 = Info.ProductName

    End Function
    Private Sub CreateDirectory(wPath As String)
        Dim result
        result = Dir(wPath, vbDirectory)

        If result <> "" Then

        Else
            System.IO.Directory.CreateDirectory(wPath)
        End If
    End Sub
    'Private Function get_dns()
    '   get_dns = "scimpv01.noritz.co.jp"
    'End Function

End Class
