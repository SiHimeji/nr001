Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO

Module ModuleCSV
    Public Sub CSVDataGridInput(dt As DataGridView, filename As String)

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
                dt.Rows.Add(RowPlus) 'DataGrid行を追加
            Loop
            SR.Close()
            dt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception


        End Try
    End Sub


    Public Function CSVDataTableInput(filename As String) As DataTable

        Dim dt As New DataTable
        Dim con_str As String 'データ保持用
        Try
            '書き込むファイルを開く

            Dim SR As New System.IO.StreamReader(filename, System.Text.Encoding.GetEncoding("shift_jis")) 'StreamReader文字化け防止

            ' データをすべてクリア
            'dt.Columns.Clear()
            con_str = SR.ReadLine()
            If con_str = Nothing Then
                Return dt
            End If
            con_str = con_str.Replace(""",""", ",")
            con_str = con_str.Replace(""",", ",")
            con_str = con_str.Replace("""", "")

            Dim ColPlus() As String = con_str.Split(",")
            For Each da In ColPlus
                dt.Columns.Add(da)
            Next

            Do
                con_str = SR.ReadLine() 'csvファイルの2行目以降を読み込む
                If con_str = Nothing Then Exit Do 'データが無ければループ終了
                con_str = con_str.Replace(""",""", ",")
                con_str = con_str.Replace(""",", ",")
                con_str = con_str.Replace("""", "")
                Dim RowPlus() As String = con_str.Split(",")
                dt.Rows.Add(RowPlus) 'DataGrid行を追加
            Loop
            SR.Close()
            'dt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Catch ex As Exception


        End Try

        Return dt

    End Function


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
    Public Function ReadCSV(dt As DataTable, ByVal hasHeader As Boolean, ByVal fileName As String, ByVal separator As String, ByVal quote As Boolean, tp As ToolStripStatusLabel) As DataTable
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
        'ここのループがCSVを読み込むメインの処理です。
        '内容は先ほどとほとんど一緒です。
        data = parser.ReadFields()

        Dim cols As Integer = data.Length

        For i As Integer = 0 To cols - 1 Step 1
            dt.Columns.Add(New DataColumn(data(i)))
        Next i
        tp.Text = (Integer.Parse(tp.Text.Replace("件", "")) + 1) & "件"

        While Not parser.EndOfData
            data = parser.ReadFields()
            dt.Rows.Add(data)
            tp.Text = (Integer.Parse(tp.Text.Replace("件", "")) + 1) & "件"
        End While
        Return dt

    End Function

    Dim classPostgeDB As New ClassPostgeDB


    Private Sub SyouninOUT(uno As String)
        Dim strSQL = "update " & schema & "t_teisei  set 承認出力日 = now() where 点検受付番号 = '" & uno & "'"
        classPostgeDB.EXEC_tr(strSQL)


    End Sub

    Public Function CsvOut(dgv As DataGridView, pb As ToolStripProgressBar, writeHeader As Boolean)
        Dim FileName As String = GetFileName("csv")
        If FileName = "" Then Return False

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")

        pb.Maximum = dgv.Rows.Count + 1
        pb.Step = 1
        pb.Value = 1

        '書き込むファイルを開く
        Dim sr As New System.IO.StreamWriter(FileName, False, enc)
        Dim colCount As Integer = dgv.Columns.Count
        Dim lastColIndex As Integer = colCount - 1
        Dim i As Integer
        Dim ret As Object

        'ヘッダを書き込む
        If writeHeader Then
            For i = 1 To colCount - 1
                'ヘッダの取得
                Dim field As String = dgv.Columns(i).HeaderCell.Value
                '"で囲む
                field = EncloseDoubleQuotesIfNeed(field)
                'フィールドを書き込む
                sr.Write(field)
                'カンマを書き込む
                If lastColIndex > i Then
                    sr.Write(","c)
                End If
            Next
            '改行する
            sr.Write(vbCrLf)
        End If

        Try

            classPostgeDB.DbOpen()
            classPostgeDB.BeginTrans()

            'レコードを書き込む

            For row As Integer = 0 To rowMaxNum

                Try
                    ret = dgv.Rows(row).Cells(0).Value
                Catch ex As Exception
                    ret = ""
                End Try

                If ret = Nothing Then
                    ret = "0"
                End If
                If ret Then
                    For col As Integer = 1 To columnMaxNum
                        Dim field As String = dgv.Rows(row).Cells(col).Value.ToString()
                        '"で囲む
                        field = EncloseDoubleQuotesIfNeed(field)
                        'フィールドを書き込む
                        sr.Write(field)
                        'カンマを書き込む
                        If lastColIndex > col Then
                            sr.Write(","c)
                        End If
                    Next
                    '改行する
                    sr.Write(vbCrLf)

                    SyouninOUT(dgv.Rows(row).Cells(1).Value.ToString())

                End If
                pb.Value = pb.Value + 1
            Next
            pb.Value = 0
            '閉じる
            classPostgeDB.Commit()
            classPostgeDB.DbClose()

            sr.Close()
        Catch ex As Exception
            classPostgeDB.Rollback()
            classPostgeDB.DbClose()
            sr.Close()
            Return False
        End Try
        Return True
    End Function
    ''' <summary>
    ''' 必要ならば、文字列をダブルクォートで囲む
    ''' </summary>
    Private Function EncloseDoubleQuotesIfNeed(field As String) As String
        If NeedEncloseDoubleQuotes(field) Then
            Return EncloseDoubleQuotes(field)
        End If
        Return field
    End Function

    ''' <summary>
    ''' 文字列をダブルクォートで囲む
    ''' </summary>
    Private Function EncloseDoubleQuotes(field As String) As String
        If field.IndexOf(""""c) > -1 Then
            '"を""とする
            field = field.Replace("""", """""")
        End If
        Return """" & field & """"
    End Function
    ''' <summary>
    ''' 文字列をダブルクォートで囲む必要があるか調べる
    ''' </summary>
    Private Function NeedEncloseDoubleQuotes(field As String) As Boolean
        Return field.IndexOf(""""c) > -1 OrElse
        field.IndexOf(","c) > -1 OrElse
        field.IndexOf(ControlChars.Cr) > -1 OrElse
        field.IndexOf(ControlChars.Lf) > -1 OrElse
        field.StartsWith(" ") OrElse
        field.StartsWith(vbTab) OrElse
        field.EndsWith(" ") OrElse
        field.EndsWith(vbTab)
    End Function
    Public Function GetFileName(ext As String)

        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = "default." & ext & ""
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = "C:\"
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = ext & "ファイル(*." & ext & ";*." & ext & ")|*." & ext & ";*." & ext & "|すべてのファイル(*.*)|*.*"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        ofd.FilterIndex = 2
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = False
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Return (ofd.FileName)
        End If
        Return ""

    End Function

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
    'CSV出力
    '
    Public Sub CSVOut(dt As DataTable, filename As String, header As String)
        Dim rowloop As Integer
        Dim colloop As Integer

        'Dim FormMeter As New FormMeter
        'FormMeter.MAX = dt.Rows.Count
        'FormMeter.Show()

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
                'FormMeter.GEN = rowloop
                'FormMeter.Disp()
            Next
        Catch
            'FormMeter.CLos()
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            'FormMeter.CLos()
            MessageBox.Show("出力しました")
        End Try
    End Sub


    Public Sub csvOutDataGred(dt As DataGridView, fileName As String, StartCol As Integer, crls As Boolean)
        Dim rowloop As Integer
        Dim colloop As Integer
        'Dim FormMeter As New FormMeter

        'FormMeter.MAX = dt.Rows.Count
        'FormMeter.Show()

        Dim sw As System.IO.StreamWriter = Nothing
        Try
            sw = New System.IO.StreamWriter(fileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))

            For colloop = StartCol To dt.Columns.Count - (1)
                sw.Write("""")
                sw.Write(dt.Columns(colloop).HeaderText.ToString())
                sw.Write("""")
                sw.Write(",")
            Next
            sw.Write(vbCrLf)
            For rowloop = 0 To dt.Rows.Count - 2
                For colloop = StartCol To dt.Columns.Count - (1)
                    sw.Write("""")
                    If (crls) Then
                        sw.Write(Oncrlf(dt.Rows(rowloop).Cells(colloop).Value))
                    Else
                        sw.Write(dt.Rows(rowloop).Cells(colloop).Value)
                    End If

                    sw.Write("""")
                    sw.Write(",")
                Next
                sw.Write(vbCrLf)
                'FormMeter.GEN = rowloop
                'FormMeter.Disp()
            Next
        Catch
            'FormMeter.CLos()
            MessageBox.Show("CSV出力でエラーです")
        Finally
            sw.Close()
            'FormMeter.CLos()
            MessageBox.Show("出力しました")
        End Try

    End Sub


    Public Sub OutputCsvFromDataGridView(ByVal dgv As DataGridView, pb As ToolStripProgressBar)
        Dim fileName As String = ""

        Using sfd As SaveFileDialog = New SaveFileDialog
            sfd.FileName = "*.csv"
            sfd.InitialDirectory = "C:\"
            sfd.Title = "出力先を選択してください"
            sfd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
            sfd.FilterIndex = 2
            sfd.RestoreDirectory = True
            If sfd.ShowDialog() = DialogResult.OK Then
                fileName = sfd.FileName
            End If
        End Using

        If fileName = "" Then
            Exit Sub
        End If

        If Path.GetExtension(fileName).Length = 0 Then
            fileName = fileName & ".csv"
        End If

        pb.Maximum = dgv.Rows.Count
        pb.Step = 1

        Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(fileName, False, System.Text.Encoding.GetEncoding("Shift_JIS"))
            For dgvCol As Integer = 0 To dgv.Columns.Count - 1
                If dgvCol > 0 Then
                    sw.Write(",")
                End If
                sw.Write("""" & dgv.Columns(dgvCol).HeaderCell.Value & """")
            Next
            sw.WriteLine()

            For dgvRow As Integer = 0 To dgv.Rows.Count - 1
                For dgvCol As Integer = 0 To dgv.Columns.Count - 1
                    If dgvCol > 0 Then
                        sw.Write(",")
                    End If
                    sw.Write("""" & dgv.Rows(dgvRow).Cells(dgvCol).Value & """")
                Next
                sw.WriteLine()
                pb.Value = dgvRow
            Next
        End Using
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

End Module
