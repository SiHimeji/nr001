Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System

Public Class ClassFTP


#If DEBUG Then
    Const user As String = "admin"
    Const pas As String = "0251"
    Const ftpadd As String = "ftp://192.168.1.166/%2fhome/admin/UpFile/"        '絶対パスにするために %2f をつける

#Else

    Const user As String = "Administrator" '"ftpuser" '
    Const pas As String = "okykss01@2009" '"ftp123" '
    Const ftpadd As String = "ftp://partsc.noritz.co.jp/web/UpFile/"
    'ftpuser / ftp123

#End If

    Public code As String = String.Empty
    Public msg As String = String.Empty


    '-----------------------------
    'アップロード
    '-----------------------------
    Public Sub Send(FtpFile As String, inFileName As String)
        msg = String.Empty

        Dim wc As System.Net.WebClient = Nothing
        Try
            ' アップロード用の WEB クライアント
            wc = New System.Net.WebClient()
            ' アップロード用の ユーザー・パスワード
            wc.Credentials = New System.Net.NetworkCredential(user, pas)

            wc.UploadFile(ftpadd & FtpFile, inFileName)

            wc.Dispose()
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

    Public Sub Send2(inFileName As String)
        Dim ftpadres As String
        'アップロードするファイル
        Dim fileName As String = inFileName

        ftpadres = ftpadd & fileName
        'アップロード先のURI
        Dim reqUri As New Uri(ftpadres)

        Dim ftpReq As FtpWebRequest = FtpWebRequest.Create(reqUri)

        'アップロードに設定
        ftpReq.Method = WebRequestMethods.Ftp.UploadFile

        'ユーザー名とパスワードを設定
        ftpReq.Credentials = New NetworkCredential(user, pas)

        '要求の完了後に接続を閉じる
        ftpReq.KeepAlive = False

        'ASCIIモードで転送する
        ftpReq.UseBinary = False

        'PASVモードを無効にする
        ftpReq.UsePassive = False

        'HTTP Proxy
        ftpReq.Proxy = Nothing
        WebRequest.DefaultWebProxy = Nothing
        'ファイルをアップロードするためのStreamを取得
        Try
            Using reqStrm As Stream = ftpReq.GetRequestStream()

                'アップロードするファイルを開く
                Using fStrm As New FileStream(fileName, FileMode.Open, FileAccess.Read)
                    'アップロードStreamに書き込む
                    Dim buffer(1023) As Byte
                    While True
                        Dim bSize As Integer = fStrm.Read(buffer, 0, buffer.Length)
                        If bSize = 0 Then
                            Exit While
                        End If
                        reqStrm.Write(buffer, 0, bSize)
                    End While
                End Using

            End Using
        Catch ex As Exception
            msg = ex.Message
        End Try

        'code = ftpRes.StatusCode.ToString

    End Sub

    '-----------------------------
    'ダウンロード
    '-----------------------------
    Public Sub Send3(FtpFile As String, outFileName As String)
        msg = String.Empty

        Dim wc As System.Net.WebClient = Nothing
        Try
            ' ダウンロード用の WEB クライアント
            wc = New System.Net.WebClient()
            ' ダウンロード用の ユーザー・パスワード
            wc.Credentials = New System.Net.NetworkCredential(user, pas)

            wc.DownloadFile(ftpadd & FtpFile, outFileName)

            wc.Dispose()
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

    '-----------------------------
    'サーバー上のファイルの削除
    '-----------------------------
    Public Sub Send4(FtpFile As String)
        msg = String.Empty

        '削除するファイルのURI
        Dim reqUri As New Uri(ftpadd & FtpFile)
        Dim ftpReq As FtpWebRequest = FtpWebRequest.Create(reqUri)

        '要求の完了後に接続を閉じる
        ftpReq.KeepAlive = True

        Try
            'ファイルの削除に設定
            ftpReq.Method = WebRequestMethods.Ftp.DeleteFile
            'ユーザー名とパスワードを設定
            ftpReq.Credentials = New NetworkCredential(user, pas)
            Using ftpRes As FtpWebResponse = ftpReq.GetResponse()
            End Using
        Catch ex As Exception
            msg = ex.Message
        End Try
    End Sub

End Class
