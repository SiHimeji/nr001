Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection
Imports System.Text
Public Class ChkVerUp
    Dim appdir As String = System.Windows.Forms.Application.StartupPath
    'Dim windir As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows)
    'Dim tmpdir As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Templates)
    Dim ctemp As String = "c:\si"
    Dim url As String
    Private Const vbs As String = "tvb.vbs"
    Dim fileName As String
    Dim ap As String
    Dim tmp As String
    '/////
    Private Const dnsadres As String = "partsc.noritz.co.jp/dl/"

    Dim BatFile As String

    Private Sub ChkVerUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 10
        Me.Height = 10
        Me.LabelMsg.Text = ""

        If chkVersion() Then

            If MsgBox("最新バージョンにアップしますか", vbOKCancel) = vbOK Then

                Dim task1 As Task = Task.Run(Sub() msg())
                Dim task2 As Task = Task.Run(Sub() exeCopy())
            End If
        Else
            'Me.Hide()
            Me.Close()
        End If
    End Sub
    Private Sub msg()
        MsgBox(" しらばくお待ちください ")
        System.Windows.Forms.Application.DoEvents()
    End Sub


    'ファイルをコピーする
    Private Sub exeCopy()
        Dim appPath As String = System.Windows.Forms.Application.StartupPath
        Dim kil As String
        Dim exe As String
        Dim exe2 As String
        Dim exe0 As String
        Dim crentdir As String
        If DownloadEXE_HTTP() Then '　ダウンロードOK

            BatFile = ap & "c.bat"
            crentdir = appPath.Replace("\", "\\")
            exe0 = "timeout /t 1"
            kil = "taskkill /im " & ap & ".exe /t /f"
            exe = "copy /Y """ & tmp & "\work\*.*"" " & crentdir & "\"
            exe2 = "start " & crentdir & "\" & ap & ".exe"

            Dim sw As New System.IO.StreamWriter(tmp & "\" & BatFile, False, System.Text.Encoding.GetEncoding("shift_jis"))
            sw.WriteLine("@echo off")
            sw.WriteLine(kil)
            sw.WriteLine(exe0)
            sw.WriteLine(exe)
            sw.WriteLine(exe2)
            sw.WriteLine("EXIT")
            sw.Close()

            sw = New StreamWriter(tmp & "\" & vbs, False, Encoding.GetEncoding("shift_jis"))
            sw.WriteLine("Option Explicit")
            sw.WriteLine("Const vbHide = 0               'ウィンドウを非表示")
            sw.WriteLine("Const vbNormalFocus = 1        '通常のウィンドウ、かつ最前面のウィンドウ")
            sw.WriteLine("Const vbMinimizedFocus = 2     '最小化、かつ最前面のウィンドウ")
            sw.WriteLine("Const vbMaximizedFocus = 3     '最大化、かつ最前面のウィンドウ")
            sw.WriteLine("Const vbNormalNoFocus = 4      '通常のウィンドウ、ただし、最前面にはならない")
            sw.WriteLine("Const vbMinimizedNoFocus = 6   '最小化、ただし、最前面にはならない")

            sw.WriteLine("Dim objWShell")
            sw.WriteLine("Set objWShell = CreateObject(""WScript.Shell"")")
            sw.WriteLine("objWShell.Run ""cmd /c " & tmp & "\" & BatFile & """, vbMinimizedNoFocus, False")
            sw.WriteLine("Set objWShell = Nothing")
            sw.Close()

            execvbs(tmp & "\" & vbs)
            Application.Exit()
        End If

    End Sub

    'VBSを実行
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


    'ダウンロード＆解凍
    Private Function DownloadEXE_HTTP() As Boolean

        If System.IO.File.Exists(ctemp) Then
        Else
            System.IO.Directory.CreateDirectory(ctemp)
        End If

        tmp = ctemp & "\sitemp"

        Try
            For Each pathFrom As String In IO.Directory.EnumerateFiles(tmp, "*", SearchOption.AllDirectories)
                IO.File.Delete(pathFrom)
            Next
            System.IO.Directory.Delete(tmp & "\work")
            System.IO.Directory.Delete(tmp)

        Catch ex As Exception

        End Try

        Try
            System.IO.Directory.CreateDirectory(tmp)
            System.IO.Directory.CreateDirectory(tmp & "\work")

            'Dim lngResult As Long
            '指定のファイルのキャッシュを削除
            'lngResult = DeleteUrlCacheEntry(url)
            'Process.Start("RunDll32", "InetCpl.cpl,ClearMyTracksByProcess 8")

            Dim wc As New System.Net.WebClient()
            wc.DownloadFile(url & fileName, tmp & "\siapp.zip")
            wc.Dispose()

            Dim zipPath As String = tmp & "\siapp.zip"
            Dim extractPath As String = tmp & "\work"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    '次のバージョンが存在するかのチェック
    Private Function chkVersion() As Boolean
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        fileName = Info.ProductName & "-" & NextVersion(Info.ProductVersion.ToString) & ".zip"
        ap = Info.ProductName

        url = "http://" & dnsadres & ""
        chkVersion = False
        If ChkHTTP(url & fileName) Then
            chkVersion = True
        End If

    End Function

    '---------------------------------------------------------------
    ' URLの存在チェック
    '
    '---------------------------------------------------------------
    Private Function ChkHTTP(url As String) As Boolean

        WebRequest.DefaultWebProxy = Nothing ' プロキシ未使用を明示

        Dim statusCode As HttpStatusCode = GetStatusCode(url)

        ' 列挙体の値を数値に変換
        Dim code As Integer = CType(statusCode, Integer)

        If code >= 400 Then             ' 4xx、5xxはアクセス失敗とする
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
                statusCode = 1000
            End If
        Finally
            If Not res Is Nothing Then
                res.Close()
            End If
        End Try
        Return statusCode
    End Function

    ' 次のバージョンを求める
    Private Function NextVersion(nVER As String) As String
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

End Class