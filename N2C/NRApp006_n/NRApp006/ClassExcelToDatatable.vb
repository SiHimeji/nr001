Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO

Public Class ClassExcelToDataTable
    Public Function ExcelToDataTable(ExcelFileNamse As String, SheetName As String, KeyCol As Integer) As DataTable
        Dim SheetNo As Integer = 1
        Dim dt As New DataTable

        Dim ExcelApplication As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim Workbooks As Microsoft.Office.Interop.Excel.Workbook
        Dim Sheets As Microsoft.Office.Interop.Excel.Worksheet

        Try

            ExcelApplication = New Microsoft.Office.Interop.Excel.Application
            Workbooks = ExcelApplication.Workbooks.Open(ExcelFileNamse)

            If SheetName = "" Then
                SheetNo = 1
            Else
                For SheetNo = 1 To Workbooks.Sheets.Count

                    If Workbooks.Sheets(SheetNo).Name.ToString = SheetName Then
                        Exit For
                    End If
                Next

            End If

            Sheets = Workbooks.Sheets(SheetNo)

            Dim col As Integer = 1
            Dim ro As Integer = 2
            Dim co As Integer = 1

            Try
                Do While Sheets.Cells(1, col).value <> ""
                    dt.Columns.Add(Sheets.Cells(1, col).value)
                    col = col + 1
                Loop
            Catch ex As Exception

            End Try

            ro = 2
            Do While Sheets.Cells(ro, KeyCol).value <> ""
                Debug.WriteLine(Sheets.Cells(ro, KeyCol).value)

                Dim dtRow As DataRow
                dtRow = dt.NewRow
                For co = 1 To col - 1
                    dtRow(co - 1) = Sheets.Cells(ro, co).value
                    Debug.WriteLine(Sheets.Cells(ro, co).value)
                Next
                dt.Rows.Add(dtRow)
                ro = ro + 1
            Loop

            ExcelApplication.Quit()

            Marshal.ReleaseComObject(ExcelApplication)
            ExcelApplication = Nothing

        Catch ex As Exception
            Marshal.ReleaseComObject(ExcelApplication)
            ExcelApplication = Nothing

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return dt
    End Function

    '------------------------------------------------------
    '  EXCEL ファイルをDatatableへ入れる（入金連絡取込み用）
    '　引数　ExcelFileNamse　　EXCELファイル名
    '　　　　SheetName　　　   シート名  NULL なら　０
    '　　　　KeyCol　　　　  　キーになるカラム １... （キーカラムは空白であってはいけない）
    '---2024/09/04 k.s---
    '　F列（請求日）が空欄行のデータは取込まない
    '------------------------------------------------------
    Public Function ExcelToDataTable1(ExcelFileNamse As String, SheetName As String, KeyCol As Integer) As DataTable
        Dim SheetNo As Integer = 1
        Dim dt As New DataTable

        Dim ExcelApplication As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim Workbooks As Microsoft.Office.Interop.Excel.Workbook
        Dim Sheets As Microsoft.Office.Interop.Excel.Worksheet

        Try

            ExcelApplication = New Microsoft.Office.Interop.Excel.Application
            Workbooks = ExcelApplication.Workbooks.Open(ExcelFileNamse)

            If SheetName = "" Then
                SheetNo = 1
            Else
                For SheetNo = 1 To Workbooks.Sheets.Count

                    If Workbooks.Sheets(SheetNo).Name.ToString = SheetName Then
                        Exit For
                    End If
                Next

            End If

            Sheets = Workbooks.Sheets(SheetNo)

            Dim col As Integer = 1
            Dim ro As Integer = 2
            Dim co As Integer = 1

            Try
                Do While Sheets.Cells(1, col).value <> ""
                    dt.Columns.Add(Sheets.Cells(1, col).value)
                    col = col + 1
                Loop
            Catch ex As Exception

            End Try

            ro = 2

            Dim eflag As Integer = 0        'ENDフラグ
            'NothingのセルをToStringするとエラーになる為
            'Do While Sheets.Cells(ro, KeyCol).value.ToString <> ""
            Do While eflag = 0
                Debug.WriteLine(Sheets.Cells(ro, KeyCol).value)

                '請求日が空欄・日付以外は取込まない
                If IsDate(Sheets.Cells(ro, 6).value) Then
                    Dim dtRow As DataRow
                    dtRow = dt.NewRow
                    For co = 1 To col - 1
                        dtRow(co - 1) = Sheets.Cells(ro, co).value
                        Debug.WriteLine(Sheets.Cells(ro, co).value)
                    Next
                    dt.Rows.Add(dtRow)
                End If
                ro = ro + 1

                If Sheets.Cells(ro, KeyCol).value = Nothing Then
                    eflag = 1               'データの最後の時ENDフラグを1にする
                End If
            Loop

            ExcelApplication.Quit()

            Marshal.ReleaseComObject(ExcelApplication)
            ExcelApplication = Nothing

        Catch ex As Exception
            Marshal.ReleaseComObject(ExcelApplication)
            ExcelApplication = Nothing

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return dt
    End Function

    '------------------------------------------------------
    '  EXCEL ファイルをDatatableへ入れる（ss請求書用）
    '　引数　ExcelFileNamse　　EXCELファイル名
    '　　　　SheetName　　　   シート名  NULL なら　０
    '　　　　KeyCol　　　　  　キーになるカラム １... （キーカラムは空白であってはいけない）
    '------------------------------------------------------
    Public Function ExcelToDataTable2(ExcelFileNamse As String, SheetName As String, KeyCol As Integer) As DataTable
        Dim SheetNo As Integer = 1
        Dim dt As New DataTable

        Dim ExcelApplication As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim Workbooks As Microsoft.Office.Interop.Excel.Workbook
        Dim Sheets As Microsoft.Office.Interop.Excel.Worksheet


        Try
            ExcelApplication = New Microsoft.Office.Interop.Excel.Application
            Workbooks = ExcelApplication.Workbooks.Open(ExcelFileNamse)

            If SheetName = "" Then
                SheetNo = 1
            Else
                For SheetNo = 1 To Workbooks.Sheets.Count

                    If Workbooks.Sheets(SheetNo).Name.ToString = SheetName Then
                        Exit For
                    End If
                Next

            End If

            'ExcelApplication.Visible = True

            Sheets = Workbooks.Sheets(SheetNo)

            Dim col As Integer = 1
            Dim ro As Integer = 9
            Dim co As Integer = 1

            'ヘッダーを読み込み
            Try
                dt.Columns.Add("作成年月") 　　　'作成年月（セル：S1）
                Do While Sheets.Cells(9, col).value <> ""
                    dt.Columns.Add(Sheets.Cells(9, col).value.ToString.Trim)
                    col = col + 1
                Loop
            Catch ex As Exception

            End Try

            '--- '2024/07/10 k.s start ---
            'If Sheets.Cells(3, 1).value <> "有料点検＿請求明細" Then
            '      Return dt
            '      Exit Function
            'End If
            If Sheets.Cells(3, 1).value.ToString.IndexOf("有料点検＿請求明細") >= 0 Then
            Else
                ExcelApplication.Quit()
                Marshal.ReleaseComObject(ExcelApplication)
                ExcelApplication = Nothing
                Return dt
                Exit Function
            End If
            '--- 2024/07/10 k.s end ---

            'データを読み込み
            ro = 11
            Do While Sheets.Cells(ro, KeyCol).value <> ""
                Debug.WriteLine(Sheets.Cells(ro, KeyCol).value)

                Dim dtRow As DataRow
                dtRow = dt.NewRow
                '作成年月
                dtRow(0) = Sheets.Cells(1, 19).value.ToString.Trim.Substring(4, 4) & Sheets.Cells(1, 19).value.ToString.Trim.Substring(9, 2)  '作成年月（セル：S1）
                For co = 1 To col - 1
                    dtRow(co) = Sheets.Cells(ro, co).value
                    Debug.WriteLine(Sheets.Cells(ro, co).value)
                Next
                dt.Rows.Add(dtRow)
                ro = ro + 1
            Loop

            ExcelApplication.Quit()

            Marshal.ReleaseComObject(ExcelApplication)
            ExcelApplication = Nothing

        Catch ex As Exception

            Marshal.ReleaseComObject(ExcelApplication)
            ExcelApplication = Nothing

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return dt
    End Function


End Class
