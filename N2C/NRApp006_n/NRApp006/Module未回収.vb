Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO

Module Module未回収
    Dim objExcel As Excel.Application
    Dim objWorkBook As Excel.Workbook

    Public Sub MikaiOpen()

        objExcel = New Excel.Application
        objWorkBook = objExcel.Workbooks.Add
        objExcel.Visible = True

    End Sub

    Public Sub MkaiAdd(dt As DataTable, SiTen As String)
        Dim objSheet As Excel.Worksheet = Nothing
        Dim rowloop As Integer
        Dim colloop As Integer

        objSheet = objWorkBook.Sheets.Add()
        objSheet.Name = SiTen

        For colloop = 0 To dt.Columns.Count - 1
            objSheet.Cells(1, colloop + 1) = dt.Columns(colloop).ColumnName.ToString.Replace("tc店略称", "支店")

            ' 項目の表示行に背景色を設定
            objSheet.Cells(1, colloop + 1).Interior.Color = RGB(140, 140, 140)
            ' 文字のフォントを設定
            objSheet.Cells(1, colloop + 1).Font.Color = RGB(255, 255, 255)
            objSheet.Cells(1, colloop + 1).Font.Bold = True

        Next

        For rowloop = 0 To dt.Rows.Count - 1
            For colloop = 0 To dt.Columns.Count - 1
                objSheet.Cells(rowloop + 2, colloop + 1) = dt.Rows(rowloop).Item(colloop).ToString
            Next
        Next
        Dim coln As String
        coln = ExceCelll(dt.Columns.Count)
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit



    End Sub

    Public Sub MikaiClose()
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub






End Module
