Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO
Module ModuleEXCEL
    '===================
    '
    '
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    ' Excel出力
    '
    Public Sub ExcelOut(dt As DataTable, filename As String, savefaine As String)

        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet

        Dim strPath As String
        Dim rowloop As Integer
        Dim colloop As Integer

        'Dim FormMeter As New FormMeter
        'FormMeter.MAX = dt.Rows.Count
        'FormMeter.Show()

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
            'FormMeter.GEN = rowloop
            'FormMeter.Disp()
        Next
        '保存する
        If savefaine <> "" Then
            book.SaveAs(savefaine)
        End If

        'FormMeter.CLos()
        app.Visible = True

        'Catch ex As Exception
        'Throw ex

        'Finally
        'オブジェクト解放
        'app.Quit()
        'End Try
    End Sub
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'EXCEL 出力
    Public Sub excelOutDataGred2(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar, sw As Integer)
        '

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing


        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        pb.Maximum = 4 + rowMaxNum + columnMaxNum
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
            pb.Value = pb.Value + 1

        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
            pb.Value = pb.Value + 1
        Next

        ' EXCELにデータを範囲指定で転送
        Dim coln As String

        coln = ExcelCel(columnMaxNum)

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "A2:" & coln & dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete


        Select Case sw
            Case 0

            Case 1 'FormCSV
                objWorkBook.Sheets(1).Columns("B:B").ColumnWidth = 129
                objWorkBook.Sheets(1).Columns("C:C").ColumnWidth = 60
                objWorkBook.Sheets(1).Columns("A:" & coln).RowHeight = 33
            Case 2




        End Select

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0

    End Sub
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'EXCEL 出力
    Dim classPostgeDB As New ClassPostgeDB
    Private Sub SyouninOUT(uno As String)
        Dim strSQL = "update " & schema & "t_teisei  set 承認出力日 = now() where 点検受付番号 = '" & uno & "'"
        classPostgeDB.EXEC_tr(strSQL)
    End Sub

    Public Function excelOutDataGredSyounin(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar)
        Dim ret As Boolean = False
        Dim chk As Object
        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing
        Try

            classPostgeDB.DbOpen()
            classPostgeDB.BeginTrans()

            'シートの最大表示列項目数
            Dim columnMaxNum As Integer = dgv.Columns.Count - 1
            'シートの最大表示行項目数
            Dim rowMaxNum As Integer = dgv.Rows.Count - 1

            pb.Maximum = dgv.Rows.Count + 1
            pb.Step = 1
            pb.Value = 1

            '項目名格納用リストを宣言
            Dim columnList As New List(Of String)
            '項目名を取得
            For i As Integer = 1 To (columnMaxNum)
                columnList.Add(dgv.Columns(i).HeaderCell.Value)
            Next


            'セルのデータ取得用二次元配列を宣言
            Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}
            Dim ro As Integer
            ro = 0
            For row As Integer = 0 To rowMaxNum

                Try
                    chk = dgv.Rows(row).Cells(0).Value
                Catch ex As Exception
                    chk = ""
                End Try

                If chk = Nothing Then
                    chk = "0"
                End If
                If chk Then
                    For col As Integer = 1 To columnMaxNum
                        If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                            ' セルに値が入っている場合、二次元配列に格納
                            v(ro, col - 1) = dgv.Rows(row).Cells(col).Value.ToString()
                        End If
                    Next
                    SyouninOUT(dgv.Rows(row).Cells(1).Value.ToString())
                    ro = ro + 1
                End If
                pb.Value = pb.Value + 1
            Next


            ' EXCELに項目名を転送
            For i As Integer = 1 To dgv.Columns.Count - 1
                ' シートの一行目に項目を挿入
                objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

                ' 罫線を設定
                objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
                ' 項目の表示行に背景色を設定
                objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
                ' 文字のフォントを設定
                objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
                objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
            Next

            ' EXCELにデータを範囲指定で転送
            Dim coln As String

            coln = ExcelCel(columnMaxNum - 1)

            ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
            Dim data As String = "A2:" & coln & ro + 1
            objWorkBook.Sheets(1).Range(data) = v
            ' データの表示範囲に罫線を設定
            objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

            'Dim data1 As String = "A:" & coln
            objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

            classPostgeDB.Commit()
            classPostgeDB.DbClose()
            ret = True
        Catch ex As Exception
            classPostgeDB.Rollback()
            classPostgeDB.DbClose()
            ret = False
        End Try

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0


        Return ret
    End Function

    '--------------- 不備リスト
    'EXCEL 出力 
    Public Sub excelOutDataGred2a(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar)
        '

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing


        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        pb.Maximum = 4 + rowMaxNum + columnMaxNum
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
            pb.Value = pb.Value + 1

        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
            pb.Value = pb.Value + 1
        Next

        ' EXCELにデータを範囲指定で転送
        Dim coln As String
        coln = ExcelCel(columnMaxNum)

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "A2:" & coln & dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1


        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete
        '高さ33　　Gr列の幅129に設定する
        objWorkBook.Sheets(1).Columns("G:G").ColumnWidth = 129
        objWorkBook.Sheets(1).Columns("A:" & coln).RowHeight = 33

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0

    End Sub


    '------------------------------------------------------
    '当日チェック数集計
    '------------------------------------------------------
    Public Sub excelOutDataGred3(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar)

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing


        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        pb.Maximum = 4 + rowMaxNum + columnMaxNum
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next
        '
        Dim RowList As New List(Of String)
        For r As Integer = 0 To (rowMaxNum)
            RowList.Add(dgv.Rows(r).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
            pb.Value = pb.Value + 1

        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i + 1) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i + 1).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i + 1).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i + 1).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i + 1).Font.Bold = True
            pb.Value = pb.Value + 1
        Next

        For r As Integer = 1 To dgv.Rows.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(r + 1, 1) = RowList(r - 1)
            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(r + 1, 1).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(r + 1, 1).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(r + 1, 1).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(r + 1, 1).Font.Bold = True
            'pb.Value = pb.Value + 1
        Next

        objWorkBook.Sheets(1).Cells(1, 1).Borders.LineStyle = True
        ' 項目の表示行に背景色を設定
        objWorkBook.Sheets(1).Cells(1, 1).Interior.Color = RGB(140, 140, 140)
        ' 文字のフォントを設定
        objWorkBook.Sheets(1).Cells(1, 1).Font.Color = RGB(255, 255, 255)
        objWorkBook.Sheets(1).Cells(1, 1).Font.Bold = True


        ' EXCELにデータを範囲指定で転送
        Dim coln As String
        coln = ExcelCel(columnMaxNum + 1)


        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "B2:" & coln & dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1

        objWorkBook.Sheets(1).Range("A4:A6").Merge

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0

    End Sub

    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    'EXCEL 出力
    '（回収管理用）
    'sw=2：入金連絡用（数値書式セット）
    'sw=3：回収チェック、売上明細、残明細用、売上明細
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    Public Sub excelOutDataGred4(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar, sw As Integer)
        '

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing


        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        pb.Maximum = 4 + rowMaxNum + dgv.Columns.Count
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next

            pb.Value = pb.Value + 1
        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True

            pb.Value = pb.Value + 1
        Next

        ' EXCELにデータを範囲指定で転送
        Dim coln As String

        coln = ExcelCel(columnMaxNum)

        Dim data As String = "A2:" & coln & dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1
        'セル幅調整
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        Select Case sw
            Case 0

            Case 1 'FormCSV
                objWorkBook.Sheets(1).Columns("B:B").ColumnWidth = 129
                objWorkBook.Sheets(1).Columns("C:C").ColumnWidth = 60
                objWorkBook.Sheets(1).Columns("A:" & coln).RowHeight = 33
            Case 2
                '文字列を数値に変換（請求合計金額）
                objWorkBook.Sheets(1).Range("D:D").Value = objWorkBook.Sheets(1).Range("D:D").Value
                objWorkBook.Sheets(1).Range("D:D").NumberFormatLocal = "#,##0;[赤]-#,##0"
            Case 3
                '文字列を数値に変換（回収金額）
                objWorkBook.Sheets(1).Range("N:N").Value = objWorkBook.Sheets(1).Range("N:N").Value
                objWorkBook.Sheets(1).Range("N:N").NumberFormatLocal = "#,##0;[赤]-#,##0"
                '文字列を数値に変換（請求合計金額）
                objWorkBook.Sheets(1).Range("O:O").Value = objWorkBook.Sheets(1).Range("O:O").Value
                objWorkBook.Sheets(1).Range("O:O").NumberFormatLocal = "#,##0;[赤]-#,##0"
            Case 4
                '文字列を数値に変換（未入金、入金済、回収金額）
                objWorkBook.Sheets(1).Range("B:D").Value = objWorkBook.Sheets(1).Range("B:D").Value
                objWorkBook.Sheets(1).Range("B:D").NumberFormatLocal = "#,##0;[赤]-#,##0"
        End Select

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0

    End Sub

    Public Sub excelOutDataGred2U(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar, shname As String)

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        pb.Maximum = 4 + rowMaxNum + columnMaxNum
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
            pb.Value = pb.Value + 1

        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i).Font.Bold = True
            pb.Value = pb.Value + 1
        Next

        ' EXCELにデータを範囲指定で転送
        Dim coln As String
        coln = ExcelCel(columnMaxNum)

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "A2:" & coln & dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete

        rowMaxNum = rowMaxNum + 2
        '文字列を数値に変換
        objWorkBook.Sheets(1).Range("D1:E" & rowMaxNum.ToString() & "").Value = objWorkBook.Sheets(1).Range("D1:E" & rowMaxNum.ToString() & "").Value
        objWorkBook.Sheets(1).Range("D1:E" & rowMaxNum.ToString() & "").NumberFormatLocal = "#,##0;[赤]-#,##0"
        objWorkBook.Sheets(1).Name = shname

        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0

    End Sub


    Public Sub excelOutDataGred(dt As DataGridView, crls As Boolean, pb As ToolStripProgressBar, sw As Integer)

        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Range As Microsoft.Office.Interop.Excel.Range
        Dim rowloop As Integer
        Dim colloop As Integer

        pb.Maximum = dt.Rows.Count
        pb.Step = 1
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

                    Range.Value = dt.Rows(rowloop).Cells(colloop).Value.ToString()
                End If
                'sheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Cells(colloop).Value.ToString()

            Next
            pb.Value = rowloop
            'System.Windows.Forms.Application.DoEvents()


        Next

        Select Case sw
            Case 1



        End Select

        app.Visible = True
        pb.Value = 0

        Marshal.ReleaseComObject(app)
        Marshal.ReleaseComObject(book)
        Marshal.ReleaseComObject(sheet)
        Marshal.ReleaseComObject(Range)

    End Sub
    Public Sub OutputExcelFromDataGridView(ByVal dgv As DataGridView)
        Dim xlsApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlsBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlsSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

        Try
            xlsApp = New Microsoft.Office.Interop.Excel.Application
            xlsBook = xlsApp.Workbooks.Add
            xlsSheet = xlsBook.Worksheets(1)

            Dim xlsValue(dgv.Rows.Count, dgv.Columns.Count - 1) As Object
            Dim xlsRow As Integer = 1

            For dgvCol As Integer = 0 To dgv.Columns.Count - 1
                xlsValue(xlsRow - 1, dgvCol) = dgv.Columns(dgvCol).HeaderCell.Value
            Next
            xlsRow += 1

            For dgvRow As Integer = 0 To dgv.Rows.Count - 1
                For dgvCol As Integer = 0 To dgv.Columns.Count - 1
                    xlsValue(xlsRow - 1, dgvCol) = dgv.Rows(dgvRow).Cells(dgvCol).Value
                Next
                xlsRow += 1
            Next
            xlsSheet.Range(xlsSheet.Cells(1, 1), xlsSheet.Cells(dgv.Rows.Count + 1, dgv.Columns.Count)).NumberFormatLocal = "@"
            xlsSheet.Range(xlsSheet.Cells(1, 1), xlsSheet.Cells(dgv.Rows.Count + 1, dgv.Columns.Count)).Value = xlsValue

            xlsApp.Visible = True
        Catch ex As Exception
            If xlsBook IsNot Nothing Then
                xlsBook.Close()
            End If
            If xlsApp IsNot Nothing Then
                xlsApp.Quit()
            End If
            MessageBox.Show(ex.Message)
        Finally
            If xlsSheet IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsSheet)
            End If
            If xlsBook IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsBook)
            End If
            If xlsApp IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp)
            End If
        End Try
    End Sub

    Public Sub ExcelDataGridInput(dt As DataGridView, filename As String)

        Dim excelApp As New Excel.Application()
        Dim excelBooks As Excel.Workbooks
        excelBooks = excelApp.Workbooks

        Dim rowloop As Integer
        'Dim colloop As Integer
        Dim sinacd As String
        Dim hojyu As String
        Dim ordr As String
        Dim yotei As String
        'Dim strSQL As String
        'Dim seq As String


        Dim excelBook As Excel.Workbook = excelBooks.Open(filename)
        Dim sheet As Excel.Worksheet = excelBook.Worksheets(1)


        Try
            excelApp.Visible = True
            rowloop = 2
            While (sheet.Cells(rowloop, 4).ToString()) <> ""
                Try

                    sinacd = sheet.Cells(rowloop, 1).value

                    If sinacd = "" Then Exit While

                    hojyu = sheet.Cells(rowloop, 5).value
                    ordr = sheet.Cells(rowloop, 8).value
                    yotei = sheet.Cells(rowloop, 9).value



                Catch ex As Exception
                    MessageBox.Show("取り込みエラーです")
                    excelApp.Quit()
                    Return
                End Try
                System.Windows.Forms.Application.DoEvents()
                rowloop = rowloop + 1
            End While

        Catch ex As Exception
            Throw ex
        Finally
            'オブジェクト解放
            excelApp.Quit()
        End Try

    End Sub
    Public Sub excelOutDataGred5(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar, ByRef strBuff As String, ByVal strShiten As String)
        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application
        Dim objWorkBook As Excel.Workbook
        Dim objWBs As Excel.Workbooks
        Dim objSheet As Excel.Worksheet = Nothing

        If strBuff = "" Then
            objExcel = New Excel.Application
            objWorkBook = objExcel.Workbooks.Add
            objWorkBook.Sheets(1).name = strShiten
        Else
            objExcel = GetObject(, "Excel.Application")
            objWBs = objExcel.Workbooks
            objWorkBook = objWBs(strBuff)
            objSheet = objWorkBook.Sheets.Add()
            objSheet.Name = strShiten
        End If

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        pb.Maximum = 4 + rowMaxNum + columnMaxNum
        pb.Step = 1
        pb.Value = 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(i).HeaderCell.Value)
        Next
        '
        Dim RowList As New List(Of String)
        For r As Integer = 0 To (rowMaxNum)
            RowList.Add(dgv.Rows(r).HeaderCell.Value)
        Next

        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                If dgv.Rows(row).Cells(col).Value Is Nothing = False Then
                    ' セルに値が入っている場合、二次元配列に格納
                    v(row, col) = dgv.Rows(row).Cells(col).Value.ToString()
                End If
            Next
            pb.Value = pb.Value + 1

        Next

        ' EXCELに項目名を転送
        For i As Integer = 1 To dgv.Columns.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(1, i + 1) = columnList(i - 1)

            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(1, i + 1).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(1, i + 1).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(1, i + 1).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(1, i + 1).Font.Bold = True
            pb.Value = pb.Value + 1
        Next

        For r As Integer = 1 To dgv.Rows.Count
            ' シートの一行目に項目を挿入
            objWorkBook.Sheets(1).Cells(r + 1, 1) = RowList(r - 1)
            ' 罫線を設定
            objWorkBook.Sheets(1).Cells(r + 1, 1).Borders.LineStyle = True
            ' 項目の表示行に背景色を設定
            objWorkBook.Sheets(1).Cells(r + 1, 1).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objWorkBook.Sheets(1).Cells(r + 1, 1).Font.Color = RGB(255, 255, 255)
            objWorkBook.Sheets(1).Cells(r + 1, 1).Font.Bold = True
            'pb.Value = pb.Value + 1
        Next

        objWorkBook.Sheets(1).Cells(1, 1).Borders.LineStyle = True
        ' 項目の表示行に背景色を設定
        objWorkBook.Sheets(1).Cells(1, 1).Interior.Color = RGB(140, 140, 140)
        ' 文字のフォントを設定
        objWorkBook.Sheets(1).Cells(1, 1).Font.Color = RGB(255, 255, 255)
        objWorkBook.Sheets(1).Cells(1, 1).Font.Bold = True

        ' EXCELにデータを範囲指定で転送
        Dim coln As String
        coln = ExcelCel(columnMaxNum)
        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1
        Dim data As String = "B2:" & coln & dgv.Rows.Count + 1
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True
        pb.Value = pb.Value + 1

        objWorkBook.Sheets(1).Range("A4:A6").Merge

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit

        'objWorkBook.Sheets(1).Range("A:E").Delete

        ' エクセル表示
        objExcel.Visible = True

        strBuff = objWorkBook.Name


        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
        pb.Value = 0

    End Sub
    Public Function ExcelCel(columnMaxNum As Integer) As String

        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            If abc1 = 0 Then abc1 = 25
            coln = Chr(Asc("A") + abc1)
        End If

        Return coln

    End Function
    Public Sub excelOutDataGred(dt As DataGridView)

        Dim app As Microsoft.Office.Interop.Excel.Application
        Dim book As Microsoft.Office.Interop.Excel.Workbook
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim Range As Microsoft.Office.Interop.Excel.Range


        Dim rowloop As Integer
        Dim colloop As Integer

        Dim columnMaxNum As Integer = dt.Columns.Count - 1

        app = New Microsoft.Office.Interop.Excel.Application
        app.Visible = False

        app.Workbooks.Add()
        book = app.Workbooks(1)
        sheet = CType(book.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
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
                Range.Value = dt.Rows(rowloop).Cells(colloop).Value.ToString()

                'sheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Cells(colloop).Value.ToString()

            Next
        Next
        Dim coln As String
        coln = ExcelCel(columnMaxNum)

        For x As Integer = 1 To 2
            Range = sheet.Range("A:A")
            Range.Delete()
        Next

        book.Sheets(1).Columns("A:" & coln).AutoFit

        app.Visible = True

        Marshal.ReleaseComObject(app)
        Marshal.ReleaseComObject(book)
        Marshal.ReleaseComObject(sheet)
        Marshal.ReleaseComObject(Range)

    End Sub
End Module
