Imports System
Imports System.Text.RegularExpressions

Public Class CsvFileReader
    Implements IDisposable

    Private disposedValue As Boolean

    Private sr As System.IO.StreamReader

    Public Sub New(ByVal path As String, ByVal enc As Text.Encoding)
        sr = New IO.StreamReader(path, enc)
    End Sub

    Public Function ReadFields() As String()
        Dim fields As List(Of String) = New List(Of String)
        Dim inEnclosure As Boolean = False

        Do Until sr.EndOfStream
            Dim line As String = sr.ReadLine()
            Dim field As Text.StringBuilder = New Text.StringBuilder()
            Dim nextChar As String = ""

            For i As Integer = 0 To line.Length - 1
                nextChar = line.Substring(i, 1)

                Select Case nextChar
                    Case ","
                        If inEnclosure Then
                            field.Append(nextChar)
                        Else
                            Dim m As Match

                            field = New Text.StringBuilder(field.ToString().Trim())
                            m = Regex.Match(field.ToString(), "^=?""(?<field>.*)""$")
                            If m.Success Then
                                field = New Text.StringBuilder(m.Groups("field").Value.Replace("""""", """"))
                            End If
                            fields.Add(field.ToString())
                            field.Clear()
                        End If
                    Case """"
                        inEnclosure = Not inEnclosure
                        field.Append(nextChar)
                    Case Else
                        field.Append(nextChar)
                End Select
            Next

            If inEnclosure Then
                field.AppendLine(nextChar)
            Else
                Dim m As Match

                field = New Text.StringBuilder(field.ToString().Trim())
                m = Regex.Match(field.ToString(), "^=?""(?<field>.*)""$")
                If m.Success Then
                    field = New Text.StringBuilder(m.Groups("field").Value.Replace("""""", """"))
                End If
                fields.Add(field.ToString())
                field.Clear()
                Exit Do
            End If
        Loop

        Return fields.ToArray()
    End Function

    Public Function EndOfStream() As Boolean
        Return sr.EndOfStream
    End Function

    Public Sub Close()
        If sr IsNot Nothing Then
            sr.Close()
        End If
    End Sub

#Region "IDisposableインターフェイスの実装"

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: マネージド状態を破棄します (マネージド オブジェクト)
                Me.Close()
            End If

            ' TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
            ' TODO: 大きなフィールドを null に設定します
            disposedValue = True
        End If
    End Sub

    ' ' TODO: 'Dispose(disposing As Boolean)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
    ' Protected Overrides Sub Finalize()
    '     ' このコードを変更しないでください。クリーンアップ コードを 'Dispose(disposing As Boolean)' メソッドに記述します
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを 'Dispose(disposing As Boolean)' メソッドに記述します
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
