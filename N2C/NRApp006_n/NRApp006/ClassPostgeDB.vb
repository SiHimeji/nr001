Imports System.Data
Imports System.Diagnostics
Imports Npgsql


Public Class ClassPostgeDB

    Dim Cn As New Npgsql.NpgsqlConnection

    '------------------------------------------------------------------------------------
    'データベースオープン
    '　in   System.Data.SQLite.SQLiteConnection
    '  out   Boolean
    '------------------------------------------------------------------------------------
    Public Function DbOpen() As Boolean

        '接続設定
        '#If DEBUG Then
        '   'Cn.ConnectionString = "Server=localhost;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
        '    Cn.ConnectionString = "Server=192.168.1.216;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
        'Cn.ConnectionString = "Server=172.31.3.167;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
        '#Else
        '================================
        '==== postgres / nr123 ======
        '            Cn.ConnectionString = "Server=172.31.3.167;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
        '================================
        '#End If
        Try
            Cn.ConnectionString = CnString
            Cn.Open()
            DbOpen = True

        Catch ex As Exception
            MessageBox.Show("サーバーと接続でいません！" & ex.Message)
            DbOpen = False
        End Try
    End Function

    '------------------------------------------------------------------------------------
    'データベースクローズ
    '　in   System.Data.SQLite.SQLiteConnection
    '  out   Boolean
    '------------------------------------------------------------------------------------
    Public Function DbClose() As Boolean

        Try
            Cn.Close()
            DbClose = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            DbClose = False
        End Try

    End Function

    '------------------------------------------------------------------------------------
    '
    '
    '
    '------------------------------------------------------------------------------------

    Public Function EXEC(ByVal StrSQL As String) As Boolean


        If StrSQL <> "" Then

            Try
                Dim Cmm As Npgsql.NpgsqlCommand
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Cmm.ExecuteNonQuery()
                Cmm.Dispose()
                EXEC = True
            Catch ex2 As Exception
                MessageBox.Show(StrSQL & vbCrLf & ex2.Message)
                EXEC = False
            Finally
                DbClose()
            End Try
        Else
            EXEC = True
        End If

    End Function
    Public Function EXEC_run(ByVal StrSQL As String) As Boolean

        If StrSQL = "" Then
            EXEC_run = False
        Else
            Try
                Dim Cmm As Npgsql.NpgsqlCommand
                Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Cmm.ExecuteNonQuery()
                Cmm.Dispose()
                EXEC_run = True

            Catch ex2 As Exception
                EXEC_run = False
            Finally

            End Try
        End If

    End Function

    Public Function DbSel_run(ByVal StrSQL As String) As String
        Dim Rs As Npgsql.NpgsqlDataReader = Nothing
        DbSel_run = ""
        If StrSQL <> "" Then
            Try
                Dim Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Rs = Cmm.ExecuteReader()
                If Rs.Read() = True Then
                    DbSel_run = Rs(0).ToString
                Else
                    DbSel_run = ""
                End If
                Cmm.Dispose()
            Catch ex2 As Exception
                DbSel_run = ""
            Finally
                Rs.Close()
            End Try
        End If

    End Function

    Public Function GetConect()
        Return Cn.ConnectionString
    End Function


    Public Function EXECnon(ByVal StrSQL As String) As Boolean
        If StrSQL = "" Then
            EXECnon = False
        Else
            Try
                Dim Cmm As Npgsql.NpgsqlCommand
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Cmm.ExecuteNonQuery()
                EXECnon = True
                Cmm.Dispose()

            Catch ex2 As Exception
                EXECnon = False
            Finally
                DbClose()
            End Try
        End If

    End Function

    '------------------------------------------------------------------------------------
    'DataGridView に結果を表示する
    '
    '
    '------------------------------------------------------------------------------------
    Public Function SetDataGredv(ByVal StrSQL As String, ByVal Dgv As DataGridView) As Boolean
        Dim idx As Integer

        If StrSQL = "" Then
            SetDataGredv = False
        Else
            Try
                Dim Cmm As Npgsql.NpgsqlCommand
                Dim Rs As Npgsql.NpgsqlDataReader
                DbOpen()
                Cmm = Cn.CreateCommand
                Dgv.Rows.Clear()
                idx = 0
                Cmm.CommandText = StrSQL
                Rs = Cmm.ExecuteReader()
                While Rs.Read() = True
                    Dgv.Rows.Add()

                    For index As Integer = 0 To Rs.FieldCount - 1
                        Dgv.Rows(idx).Cells(index).Value = Rs(index).ToString
                    Next
                    idx = idx + 1

                End While

                SetDataGredv = True
                Cmm.Dispose()

            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
                SetDataGredv = False

            Finally
                DbClose()
            End Try
            SetDataGredv = False
            DbClose()
        End If

    End Function

    '------------------------------------------------------------------------------------
    '
    ' 先頭１レコードを取得
    '
    '------------------------------------------------------------------------------------
    Public Function DbSel(ByVal StrSQL As String) As String

        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader
        DbSel = ""
        If StrSQL <> "" Then
            Try
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Rs = Cmm.ExecuteReader()
                If Rs.Read() = True Then
                    DbSel = Rs(0).ToString
                Else
                    DbSel = ""
                End If
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
                DbSel = ""
            Finally
                DbClose()
            End Try
        End If
    End Function

    Public Function DbSelnon(ByVal StrSQL As String) As String

        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader
        DbSelnon = ""
        If StrSQL <> "" Then
            Try
                Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Rs = Cmm.ExecuteReader()
                If Rs.Read() = True Then
                    DbSelnon = Rs(0).ToString
                Else
                    DbSelnon = ""
                End If
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
                DbSelnon = ""
            Finally
                'DbClose()
            End Try
        End If

    End Function

    '------------------------------------------------------------------------------------
    '
    ' 全レコードを取得
    '
    '------------------------------------------------------------------------------------
    Public Function DbALLSel(ByVal StrSQL As String) As String

        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader
        Dim ret As String = String.Empty
        Dim cnt As Integer = 0
        DbALLSel = ""
        If StrSQL <> "" Then
            Try
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = StrSQL
                Rs = Cmm.ExecuteReader()
                cnt = 0
                While Rs.Read()
                    If cnt > 0 Then
                        ret &= ","
                    End If
                    ret &= Rs(0).ToString
                    cnt = cnt + 1
                End While
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            Finally
                DbClose()
                DbALLSel = ret
            End Try
        End If

    End Function
    '------------------------------------------------------------------------------------
    'Listに設定する
    '
    '
    '------------------------------------------------------------------------------------
    Public Sub SetListBox(cb As ListBox, strSQL As String)
        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader

        If strSQL <> "" Then

            cb.Items.Clear()
            Try
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = strSQL
                Rs = Cmm.ExecuteReader()
                While Rs.Read()
                    cb.Items.Add(Rs(0).ToString())
                End While
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            Finally
                DbClose()
            End Try
        End If
    End Sub


    '------------------------------------------------------------------------------------
    'ComboBOXに設定する
    '
    '
    '------------------------------------------------------------------------------------
    Public Sub SetComboBox(cb As ComboBox, strSQL As String, s As String)
        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader

        If strSQL <> "" Then

            cb.Items.Clear()
            cb.Items.Add(s)
            Try
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = strSQL
                Rs = Cmm.ExecuteReader()
                While Rs.Read()
                    cb.Items.Add(Rs(0).ToString())
                End While
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            Finally
                DbClose()
            End Try
        End If

    End Sub
    Public Sub SetComboBox(cb As ToolStripComboBox, strSQL As String)
        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader

        If strSQL <> "" Then

            cb.Items.Clear()
            cb.Items.Add("")

            Try
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = strSQL
                Rs = Cmm.ExecuteReader()
                While Rs.Read()
                    cb.Items.Add(Rs(0).ToString())
                End While
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            Finally
                DbClose()
            End Try
        End If

    End Sub
    Public Sub SetComboBox(cb As ComboBox, strSQL As String)
        Dim Cmm As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader

        If strSQL <> "" Then

            cb.Items.Clear()
            cb.Items.Add("")

            Try
                DbOpen()
                Cmm = Cn.CreateCommand
                Cmm.CommandText = strSQL
                Rs = Cmm.ExecuteReader()
                While Rs.Read()
                    cb.Items.Add(Rs(0).ToString())
                End While
                Cmm.Dispose()
            Catch ex2 As Exception
                MessageBox.Show(ex2.Message)
            Finally
                DbClose()
            End Try
        End If

    End Sub
    '------------------------------------------------------------------------------------
    '
    '　DataTable　に設定する
    '
    '------------------------------------------------------------------------------------
    Public Function SetTable(ByVal strSql As String) As DataTable
        Dim dt As DataTable = New DataTable()

        Try
            DbOpen()

            Dim cmd As NpgsqlCommand = New NpgsqlCommand(strSql, Cn)
            Dim da As NpgsqlDataAdapter = New NpgsqlDataAdapter(cmd)

            da.Fill(dt)
            DbClose()
        Catch ex As Exception

            DbClose()
        End Try
        Return dt
    End Function
    '//
    Private tr As Npgsql.NpgsqlTransaction

    Public Sub BeginTrans()

        tr = Cn.BeginTransaction()

    End Sub
    Public Sub Commit()
        tr.Commit()
    End Sub

    Public Sub Rollback()
        tr.Rollback()
    End Sub

    'トランザクション用(例外は呼び出し先で処理する)
    Public Sub EXEC_tr(ByVal StrSQL As String)
        Dim Cmd As Npgsql.NpgsqlCommand

        Try
            Cmd = Cn.CreateCommand
            Cmd.Transaction = tr
            Cmd.CommandText = StrSQL
            Cmd.ExecuteNonQuery()
            Cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try

    End Sub
    '//

    '先頭1行目のレコードを配列で取得する
    Public Function GetFirstRecords(strSql As String) As String()
        Dim SQLiteCommand As Npgsql.NpgsqlCommand
        Dim dr As Npgsql.NpgsqlDataReader = Nothing

        Dim fields As List(Of String) = New List(Of String)

        Try
            DbOpen()
            SQLiteCommand = Cn.CreateCommand
            SQLiteCommand.CommandText = strSql
            dr = SQLiteCommand.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                For i As Integer = 0 To dr.FieldCount - 1
                    fields.Add(If(IsDBNull(dr(i)), "", dr(i)))
                Next
            End If
            SQLiteCommand.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If dr IsNot Nothing Then
                dr.Close()
            End If
            DbClose()
        End Try

        Return fields.ToArray()
    End Function
End Class
