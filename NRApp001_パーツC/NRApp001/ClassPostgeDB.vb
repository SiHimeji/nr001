
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
        Try
            '---------------------------- ModuleApp で設定
            '#If DEBUG Then
            '        'Cn.ConnectionString = "Server=localhost;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
            '        'Cn.ConnectionString = "Server=localhost;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"0
            '         Cn.ConnectionString = "Server=192.168.1.216;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true"
            '        'Cn.ConnectionString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
            '#Else
            '           '================================
            '          '==== postgres / nr123 ======
            '         Cn.ConnectionString = "Server=172.31.3.166;Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true"
            '        '================================
            '#End If

            Cn.ConnectionString = CnString
            'SQLiteコネクションオープン
            Cn.Open()
            DbOpen = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
    '   トランザクション処理
    '
    '
    '------------------------------------------------------------------------------------

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
        Dim SQLiteCommand As Npgsql.NpgsqlCommand
        SQLiteCommand = Cn.CreateCommand
        Try
            '登録
            SQLiteCommand.CommandText = StrSQL
            SQLiteCommand.ExecuteNonQuery()
        Finally
            '破棄
            SQLiteCommand.Dispose()
        End Try
    End Sub

    '------------------------------------------------------------------------------------
    '
    '
    '
    '------------------------------------------------------------------------------------
    Public Function GetCone()
        Return Cn.ConnectionString
    End Function

    Public Function EXEC(ByVal StrSQL As String) As Boolean
        If StrSQL = "" Then
            MessageBox.Show("SQL文が空です")
            End
        End If
        Try
            Dim SQLiteCommand As Npgsql.NpgsqlCommand
            'SQLコマンド設定
            DbOpen()
            SQLiteCommand = Cn.CreateCommand
            Try
                '登録
                SQLiteCommand.CommandText = StrSQL
                SQLiteCommand.ExecuteNonQuery()
                EXEC = True

            Catch ex2 As Exception
                MessageBox.Show(StrSQL & vbCrLf & ex2.Message)
                EXEC = False

            Finally
                '破棄
                SQLiteCommand.Dispose()

            End Try

        Catch ex As Exception
            MessageBox.Show(StrSQL & vbCrLf & ex.Message)
            EXEC = False

        End Try
        DbClose()


    End Function

    Public Function DbSel_run(ByVal StrSQL As String) As String
        Dim Rs As Npgsql.NpgsqlDataReader

        If StrSQL = "" Then
            MessageBox.Show("SQL文が空です")
            End
        End If

        'SQLコマンド設定
        Dim SQLiteCommand = Cn.CreateCommand
        Try
            '検索
            SQLiteCommand.CommandText = StrSQL
            Rs = SQLiteCommand.ExecuteReader()
            If Rs.Read() = True Then
                DbSel_run = Rs(0).ToString
            Else
                DbSel_run = ""
            End If
        Catch ex2 As Exception
            DbSel_run = ""
        Finally
            '破棄
            SQLiteCommand.Dispose()
        End Try

    End Function



    Public Function DbSelnon(ByVal StrSQL As String) As String
        Dim Rs As Npgsql.NpgsqlDataReader

        If StrSQL = "" Then
            DbSelnon = True
            End
        End If
        Try
            Dim SQLiteCommand As Npgsql.NpgsqlCommand
            'SQLコマンド設定
            DbOpen()
            SQLiteCommand = Cn.CreateCommand
            Try
                '登録
                SQLiteCommand.CommandText = StrSQL
                Rs = SQLiteCommand.ExecuteReader()
                If Rs.Read() = True Then
                    DbSelnon = Rs(0).ToString
                Else
                    DbSelnon = ""
                End If


            Catch ex2 As Exception
                DbSelnon = False
            Finally
                '破棄
                SQLiteCommand.Dispose()
            End Try
        Catch ex As Exception
            DbSelnon = False
        End Try
        DbClose()

    End Function

    Public Function EXECnon(ByVal StrSQL As String) As Boolean
        If StrSQL = "" Then
            Return True
        End If
        Try
            Dim SQLiteCommand As Npgsql.NpgsqlCommand
            'SQLコマンド設定
            DbOpen()
            SQLiteCommand = Cn.CreateCommand
            Try
                '登録
                SQLiteCommand.CommandText = StrSQL
                SQLiteCommand.ExecuteNonQuery()
                EXECnon = True

            Catch ex2 As Exception
                EXECnon = False
            Finally
                '破棄
                SQLiteCommand.Dispose()
            End Try
        Catch ex As Exception
            EXECnon = False
        End Try
        DbClose()
    End Function

    '------------------------------------------------------------------------------------
    'DataGridView に結果を表示する
    '
    '
    '------------------------------------------------------------------------------------
    Public Function SetDataGredv(ByVal StrSQL As String, ByVal Dgv As DataGridView) As Boolean
        Dim idx As Integer

        If StrSQL = "" Then
            Return (False)
        End If
        Try
            Dim SQLiteCommand As Npgsql.NpgsqlCommand
            Dim Rs As Npgsql.NpgsqlDataReader

            If DbOpen() = False Then
                SetDataGredv = False
                Exit Function
            End If
            'SQLコマンド設定
            SQLiteCommand = Cn.CreateCommand
            Dgv.Rows.Clear()
            idx = 0
            ' Dgv.Rows.Add()
            Try
                '検索
                SQLiteCommand.CommandText = StrSQL
                Rs = SQLiteCommand.ExecuteReader()
                While Rs.Read() = True

                    Dgv.Rows.Add()

                    For index As Integer = 0 To Rs.FieldCount - 1
                        Dgv.Rows(idx).Cells(index).Value = Rs(index).ToString
                    Next
                    idx = idx + 1

                End While

                SetDataGredv = True
                DbClose()

            Catch ex2 As Exception
                MessageBox.Show(StrSQL & vbCrLf & ex2.Message)
                SetDataGredv = False

            Finally
                '破棄
                SQLiteCommand.Dispose()

            End Try
        Catch ex As Exception
            MessageBox.Show(StrSQL & vbCrLf & ex.Message)
            SetDataGredv = False

        End Try

        SetDataGredv = False
        DbClose()
        Dgv.AllowUserToAddRows = False
    End Function

    '------------------------------------------------------------------------------------
    '
    ' 先頭１レコードを取得
    '
    '------------------------------------------------------------------------------------
    Public Function DbSel(ByVal StrSQL As String) As String

        Dim SQLiteCommand As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader
        If StrSQL = "" Then
            End
        End If
        If DbOpen() = False Then
            DbSel = ""
            Exit Function
        End If

        'SQLコマンド設定
        SQLiteCommand = Cn.CreateCommand

        Try
            '検索
            SQLiteCommand.CommandText = StrSQL
            Rs = SQLiteCommand.ExecuteReader()
            If Rs.Read() = True Then
                DbSel = Rs(0).ToString
            Else
                DbSel = ""
            End If
        Catch ex2 As Exception
            MessageBox.Show(StrSQL & vbCrLf & ex2.Message)
            DbSel = ""
        Finally
            '破棄
            SQLiteCommand.Dispose()
            DbClose()
        End Try

    End Function


    '------------------------------------------------------------------------------------
    '
    ' 全レコードを取得
    '
    '------------------------------------------------------------------------------------
    Public Function DbALLSel(ByVal StrSQL As String) As String

        Dim SQLiteCommand As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader
        Dim ret As String
        Dim cnt As Integer

        ret = ""
        If StrSQL = "" Then
            End
        End If
        If DbOpen() = False Then
            DbALLSel = ""
            Exit Function
        End If

        'SQLコマンド設定
        SQLiteCommand = Cn.CreateCommand
        Try
            '検索
            SQLiteCommand.CommandText = StrSQL
            Rs = SQLiteCommand.ExecuteReader()
            cnt = 0
            While Rs.Read()
                If cnt > 0 Then
                    ret &= ","
                End If
                ret &= Rs(0).ToString
                cnt = cnt + 1
            End While

        Catch ex2 As Exception
            MessageBox.Show(StrSQL & vbCrLf & ex2.Message)
            ret = ""
        Finally
            '破棄
            DbClose()
            DbALLSel = ret
        End Try

    End Function



    '------------------------------------------------------------------------------------
    'ComboBOXに設定する
    '
    '
    '------------------------------------------------------------------------------------
    Public Sub SetComboBox(cb As ComboBox, strSQL As String)
        Dim SQLiteCommand As Npgsql.NpgsqlCommand
        Dim Rs As Npgsql.NpgsqlDataReader

        If strSQL <> "" Then

            cb.Items.Clear()
            cb.Items.Add("")

            If DbOpen() = False Then
                Exit Sub
            End If

            'SQLコマンド設定
            SQLiteCommand = Cn.CreateCommand

            Try
                '検索
                SQLiteCommand.CommandText = strSQL
                Rs = SQLiteCommand.ExecuteReader()
                While Rs.Read()
                    cb.Items.Add(Rs(0).ToString())
                End While
            Catch ex2 As Exception
                MessageBox.Show(strSQL & vbCrLf & ex2.Message)
                'DbSel = vbNull
            Finally
                '破棄
                SQLiteCommand.Dispose()
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
        'データベースオープン
        'conn.Open()
        If DbOpen() = False Then
            SetTable = Nothing
            Exit Function
        End If
        Try
            Dim cmd As NpgsqlCommand = New NpgsqlCommand(strSql, Cn)
            Dim da As NpgsqlDataAdapter = New NpgsqlDataAdapter(cmd)

            da.Fill(dt)
            DbClose()
        Catch ex As Exception
            DbClose()
        End Try
        'データベースクローズ
        Return dt
    End Function
    '
    '//



End Class
