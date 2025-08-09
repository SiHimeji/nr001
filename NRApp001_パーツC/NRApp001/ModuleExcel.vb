'Imports System.Text
'Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
'Imports System.Reflection
'Imports System.Text.RegularExpressions
'Imports System.IO

Module ModuleExcel
    '＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    '高速版
    '　EXCEL 出力
    '
    Public Sub excelOutDataGredV2(dgv As DataGridView)

        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing
        '現在日時を取得
        'Dim timestanpText As String = Format(Now, "yyyyMMddHHmmss")
        '保存ディレクトリとファイル名を設定
        'Dim saveFileName As String
        'saveFileName = objExcel.GetSaveAsFilename(
        'InitialFilename:=EXCEL_SAVE_PATH & "ファイル名_" & timestanpText,
        'FileFilter:="Excel File (*.xlsx),*.xlsx")

        '保存先ディレクトリの設定が有効の場合はブックを保存
        'If saveFileName <> "False" Then
        'objWorkBook.SaveAs(Filename:=saveFileName)
        'End If

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dgv.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dgv.Rows.Count - 1

        '項目名格納用リストを宣言
        Dim columnList As New List(Of String)
        '項目名を取得
        For i = 0 To (columnMaxNum)
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
        Next

        ' EXCELに項目名を転送
        For i = 1 To dgv.Columns.Count
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
        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1)
        End If

        ' Dim data As String = "A2:" & Chr(Asc("A") + columnMaxNum) & dgv.Rows.Count + 1 	'列A-Zまで対応
        Dim data As String = "A2:" & coln & dgv.Rows.Count + 1              '列A・・まで拡張
        objWorkBook.Sheets(1).Range(data) = v
        ' データの表示範囲に罫線を設定
        objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit
        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing

    End Sub
    '
    ' NextB用EXCEL出力
    '
    Public Sub ToExcelNext(dt As DataTable)
        ' EXCEL関連オブジェクトの定義
        Dim objExcel As Excel.Application = New Excel.Application
        Dim objWorkBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim objSheet As Excel.Worksheet = Nothing
        Dim i As Integer

        'シートの最大表示列項目数
        Dim columnMaxNum As Integer = dt.Columns.Count - 1
        'シートの最大表示行項目数
        Dim rowMaxNum As Integer = dt.Rows.Count - 1
        Dim heaf1() As String = {"cst_cmp_cd", "rqst_dlv_dt", "sls_typ", "xpns_cd", "assort_typ", "cst_cd", "scnd_dler_cd", "thrd_dler_cd", "cst_scst_cd", "scst_cd", "scst_nm", "zip_cd", "scst_addr1", "scst_addr2", "cst_po_no", "ord_psn_nm", "ord_psn_nm1", "rmrks", "intr_rmrks", "prod_fare_typ", "fare_typ", "fare_subno", "fax_needl_typ", "cst_itm_cd", "itm_cd", "ord_qty", "dsnt_upri", "cst_dsnt_subno", "d_rqst_dlv_dt", "ja_inst_no", "ja_upri", "zone", "urgent_cntct_tel", "urgent_cntct_nm", "chrg_dpt_cd", "ac_cd", "bf_no"}
        Dim heaf2() As String = {"得意先企業ＣＤ", "到着希望日", "売上区分", "経費管理区分", "出荷区分", "得意先ＣＤ", "２次店ＣＤ", "３次店ＣＤ", "相手先送り先ＣＤ", "送り先ＣＤ", "送り先名", "郵便番号", "送り先住所１", "送り先住所２", "得意先発注ＮＯ", "得意先発注者", "得意先発注者（カナ）", "備考", "備考２", "製品運賃区分", "運賃区分", "運賃枝番", "ＦＡＸ配信不要区分", "相手先品ＣＤ", "品ＣＤ", "受注数", "指定単価", "得意先指定枝番", "明細到着希望日", "農協指図ＮＯ", "農協価格", "ゾーン", "緊急連絡先ＴＥＬ", "緊急連絡先名", "負担部門ＣＤ", "勘定科目ＣＤ", "資金予算ＮＯ"}


        'セルのデータ取得用二次元配列を宣言
        Dim v As String(,) = New String(rowMaxNum, columnMaxNum) {}

        For row As Integer = 0 To rowMaxNum
            For col As Integer = 0 To columnMaxNum
                'If dt.Rows(row).Item(col).Value Is Nothing = False Then
                ' セルに値が入っている場合、二次元配列に格納
                v(row, col) = dt.Rows(row).Item(col).ToString()
                'End If
            Next
        Next

        ' EXCELにデータを範囲指定で転送
        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columnMaxNum > 26 Then
            abc1 = Int(columnMaxNum / 26) - 1
            abc2 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columnMaxNum Mod 26)
            coln = Chr(Asc("A") + abc1)
        End If

        i = 1
        For Each s In heaf1
            objWorkBook.Sheets(1).Cells(1, i) = s
            i = i + 1
        Next
        i = 1
        For Each s In heaf2
            objWorkBook.Sheets(1).Cells(2, i) = s
            i = i + 1
        Next

        Dim data As String = "A3:" & coln & dt.Rows.Count + 2              '列A・・まで拡張
        objWorkBook.Sheets(1).Range(data) = v


        'データの表示範囲に罫線を設定
        'objWorkBook.Sheets(1).Range(data).Borders.LineStyle = True

        'Dim data1 As String = "A:" & coln
        objWorkBook.Sheets(1).Columns("A:" & coln).AutoFit


        ' エクセル表示
        objExcel.Visible = True

        ' EXCEL解放
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        objWorkBook = Nothing
        objExcel = Nothing
    End Sub



End Module
