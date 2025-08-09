Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO
Module ModuleGetuji

    '=====================================================================
    Public Sub excelOutDataGred8(dt As DataTable, crls As Boolean, pb As ToolStripProgressBar, ByRef yyyy As String)

        'excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1)
        Dim objExcel As Excel.Application
        Dim objWorkBook As Excel.Workbook
        'Dim objWBs As Excel.Workbooks
        Dim objSheet As Excel.Worksheet = Nothing
        Dim SiTen As String = String.Empty
        Dim ro As Integer = 0
        Dim col As Integer
        Dim ey As Integer
        Dim coln As String
        Dim r As Integer


        If dt.Rows.Count = 0 Then
            MsgBox("データがありません")
            Exit Sub
        End If

        objExcel = New Excel.Application
        objWorkBook = objExcel.Workbooks.Add
        objExcel.Visible = True
        ey = 1
        For ro = 0 To dt.Rows.Count - 1
            If dt.Rows(ro).Item(0).ToString = SiTen Then
                ey = ey + 1
            Else
                SiTen = dt.Rows(ro).Item(0).ToString
                objSheet = objWorkBook.Sheets.Add()
                objSheet.Name = SiTen
                ey = 1
                For col = 1 To dt.Columns.Count - 1
                    objSheet.Cells(ey, col) = dt.Columns(col).ColumnName
                Next

                For r = 1 To dt.Columns.Count - 1
                    ' 項目の表示行に背景色を設定
                    objWorkBook.Sheets(1).Cells(1, r).Interior.Color = RGB(140, 140, 140)
                    ' 文字のフォントを設定
                    objWorkBook.Sheets(1).Cells(1, r).Font.Color = RGB(255, 255, 255)
                    objWorkBook.Sheets(1).Cells(1, r).Font.Bold = True
                Next


                ey = ey + 1
            End If

            For col = 1 To dt.Columns.Count - 1
                objSheet.Cells(ey, col) = dt.Rows(ro).Item(col)
            Next

            coln = ExceCelll(dt.Columns.Count)
            objSheet.Columns("A:" & coln).AutoFit

        Next

        objSheet = objWorkBook.Sheets("Sheet1")
        objSheet.Delete()


    End Sub
    '=====================================================================
    Public Sub excelOutDataGred6(dgv As DataGridView, crls As Boolean, pb As ToolStripProgressBar, ByRef yyyy As String)
        Dim ClassPostgeDB As New ClassPostgeDB
        ' EXCEL関連オブジェクトの定義

        Dim dt As DataTable
        Dim dt2 As DataTable
        Dim strShiten As String
        Dim strBuff As String

        Dim objExcel As Excel.Application
        Dim objWorkBook As Excel.Workbook
        'Dim objWBs As Excel.Workbooks
        Dim objSheet As Excel.Worksheet = Nothing

        dt = ClassPostgeDB.SetTable(GetSQLShiten(yyyy))
        If dt.Rows.Count = 0 Then
            MsgBox("表示するデータがありません。", MsgBoxStyle.Critical)
            Exit Sub
        End If

        objExcel = New Excel.Application
        objWorkBook = objExcel.Workbooks.Add

        dt2 = dt.Clone
        dt2.ImportRow(dt.Rows(0))

        strShiten = dt(0)(1).ToString
        'objWorkBook.Sheets(1).name = strShiten

        dgv.AllowUserToAddRows = False
        'dgv.ReadOnly = True

        strBuff = ""
        For ia As Integer = 1 To dt.Rows.Count - 1
            If strShiten = dt(ia)(1).ToString Then
                dt2.ImportRow(dt.Rows(ia))
            Else
                dt2 = DataTableSwapXY2(dt2, yyyy)

                dgv.DataSource = dt2
                For col = 1 To dgv.ColumnCount - 1
                    dgv.Columns(col).HeaderText = dgv.Columns(col).HeaderText & "月計"
                    dgv.Rows(4).Cells(col).Value = Math.Round(Double.Parse(dgv.Rows(4).Cells(col).Value), 2, MidpointRounding.AwayFromZero).ToString & "%"
                Next
                dgv.Rows(0).HeaderCell.Value = "チェック総数"
                dgv.Rows(1).HeaderCell.Value = "不備総数"
                dgv.Rows(2).HeaderCell.Value = "技術不備数"


                '======Excel出力
                strBuff = Excel6(dgv, objSheet, objWorkBook, pb, strShiten)
                objExcel.Visible = True

                '=======
                dgv.DataSource = Nothing
                dt2.Clear()
                dt2 = dt.Clone

                dt2.ImportRow(dt.Rows(ia))
                strShiten = dt(ia)(1).ToString
            End If
        Next
        '-----
        dt2 = DataTableSwapXY2(dt2, yyyy)

        dgv.DataSource = Nothing
        dgv.DataSource = dt2


        For col = 1 To dgv.ColumnCount - 1
            dgv.Columns(col).HeaderText = dgv.Columns(col).HeaderText & "月計"
            dgv.Rows(4).Cells(col).Value = Math.Round(Double.Parse(dgv.Rows(4).Cells(col).Value), 2, MidpointRounding.AwayFromZero).ToString & "%"
        Next

        dgv.Rows(0).HeaderCell.Value = "チェック総数"
        dgv.Rows(1).HeaderCell.Value = "不備総数"
        dgv.Rows(2).HeaderCell.Value = "技術不備数"

        'Excel出力
        strBuff = Excel6(dgv, objSheet, objWorkBook, pb, strShiten)
        objExcel.Visible = True
        '
        dgv.DataSource = Nothing
        dt2.Clear()

        '======================
        dt = ClassPostgeDB.SetTable(GetSQLZensya(yyyy))
        dt = DataTableSwapXY(dt, yyyy)

        dgv.DataSource = Nothing
        dgv.DataSource = dt

        For col = 1 To dgv.ColumnCount - 1
            dgv.Columns(col).HeaderText = dgv.Columns(col).HeaderText & "月計"
            dgv.Rows(4).Cells(col).Value = Math.Round(Double.Parse(dgv.Rows(4).Cells(col).Value), 2, MidpointRounding.AwayFromZero).ToString & "%"
        Next
        dgv.Rows(0).HeaderCell.Value = "チェック総数"
        dgv.Rows(1).HeaderCell.Value = "不備総数"
        dgv.Rows(2).HeaderCell.Value = "技術不備数"

        strShiten = "全体"

        'Excel出力
        strBuff = Excel6(dgv, objSheet, objWorkBook, pb, strShiten)
        objExcel.Visible = True

        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'excelOutDataGred5(Me.DataGridView1, True, Me.ToolStripProgressBar1, strBuff, strShiten)
        'Me.Cursor = System.Windows.Forms.Cursors.Default

        strBuff = ""

        '列のソートを不可にする
        'For Each c As DataGridViewColumn In dgv.Columns
        'c.SortMode = DataGridViewColumnSortMode.NotSortable
        'Next c

        objSheet = objWorkBook.Sheets("Sheet1")
        objSheet.Delete()

        dgv.DataSource = Nothing


    End Sub

    Private Function Excel6(dgv As DataGridView, objSheet As Excel.Worksheet, objWorkBook As Excel.Workbook, pb As ToolStripProgressBar, strShiten As String) As String
        Dim strBuff As String

        objSheet = objWorkBook.Sheets.Add()
        objSheet.Name = strShiten

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
        For ii As Integer = 0 To (columnMaxNum)
            columnList.Add(dgv.Columns(ii).HeaderCell.Value)
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
        'Dim abc1 As Integer
        'Dim abc2 As Integer
        Dim coln As String
        columnMaxNum = columnMaxNum + 1
        'If columnMaxNum > 26 Then
        'abc1 = Int(columnMaxNum / 26) - 1
        'abc2 = (columnMaxNum Mod 26)
        'coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        'Else
        'abc1 = (columnMaxNum Mod 26)
        'coln = Chr(Asc("A") + abc1)
        'End If
        coln = ExceCelll(columnMaxNum)
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

        strBuff = objWorkBook.Name
        pb.Value = 0
        Return strBuff

    End Function

    Public Function ExceCelll(columNum As Integer)
        Dim abc1 As Integer
        Dim abc2 As Integer
        Dim coln As String

        If columNum > 26 Then
            abc1 = Int(columNum / 26) - 1
            abc2 = (columNum Mod 26)
            coln = Chr(Asc("A") + abc1) & Chr(Asc("A") + abc2)
        Else
            abc1 = (columNum Mod 26)
            coln = Chr(Asc("A") + abc1)
        End If
        Return coln
    End Function

    Private Function GetSQLShiten(yy As String) As String
        Dim strSql As String = String.Empty
        Dim YYYY As String

        YYYY = DateTime.ParseExact(yy & "01月01日", "yyyy年MM月dd日", Nothing).ToString("yyyy")

        strSql &= "select Zen.Mo 月 "
        strSql &= " ,Zen.商圏 "
        strSql &= " ,COALESCE(Zen.kazu,0) 品質チェック件数 "
        strSql &= " ,COALESCE(Furyo.kazu,0) 不備件数 "
        strSql &= " ,COALESCE(Saihoumon.kazu,0) 内再訪問件数 "
        strSql &= " ,COALESCE(Keibi.kazu,0) 内軽微 "
        strSql &= " ,CASE COALESCE(Furyo.kazu,0) WHEN 0 THEN 0 else (cast(Furyo.kazu as float)/cast(Zen.kazu as float) ) * 100 end 不備率 "
        strSql &= " from "
        strSql &= " (select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= " ,count(*) kazu "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " ) Zen "
        strSql &= " left outer join ( "
        strSql &= " select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= " ,count(*) kazu "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "'"
        strSql &= " and t_check.チェック <>'1' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " ) Furyo on Zen.Mo = Furyo.Mo and Zen.商圏 = Furyo.商圏 "
        strSql &= " left outer join ( "
        strSql &= " select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= " ,count(*) kazu "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "' "
        strSql &= " and t_check.チェック ='3' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " ) Saihoumon on Zen.Mo = Saihoumon.Mo and Zen.商圏 = Saihoumon.商圏 "
        strSql &= " left outer join ( "
        strSql &= " select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= " ,count(*) kazu "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "' "
        strSql &= " and t_check.チェック ='2' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= " ,v_tenken_kekka.商圏 "
        strSql &= " ) Keibi on Zen.Mo = Keibi.Mo and Zen.商圏 = Keibi.商圏 "
        strSql &= " ORDER BY zen.商圏,zen.Mo "

        Return strSql

    End Function

    Private Function GetSQLZensya(yy As String) As String
        Dim strSql As String = String.Empty
        Dim YYYY As String

        YYYY = DateTime.ParseExact(yy & "01月01日", "yyyy年MM月dd日", Nothing).ToString("yyyy")

        strSql &= "select Zen.Mo 月 "
        strSql &= ",COALESCE(Zen.kazu,0) 品質チェック件数 "
        strSql &= ",COALESCE(Furyo.kazu,0) 不備件数 "
        strSql &= ",COALESCE(Saihoumon.kazu,0) 内再訪問件数 "
        strSql &= ",COALESCE(Keibi.kazu,0) 内軽微 "
        strSql &= ",CASE COALESCE(Furyo.kazu,0) WHEN 0 THEN 0 else (cast(Furyo.kazu as float)/cast(Zen.kazu as float) ) * 100 end 不備率 "
        strSql &= " from "
        strSql &= " (select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= ",count(*) kazu "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= " ) Zen "
        strSql &= " left outer join ( "
        strSql &= " select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= ",count(*) kazu "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "'"
        strSql &= " and t_check.チェック <>'1' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= ") Furyo on Zen.Mo = Furyo.Mo "
        strSql &= " left outer join ( "
        strSql &= " select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= ",count(*) kazu "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "' "
        strSql &= " and t_check.チェック ='3' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= ") Saihoumon on Zen.Mo = Saihoumon.Mo "
        strSql &= " left outer join ( "
        strSql &= " select to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') Mo "
        strSql &= ",count(*) kazu "
        strSql &= " from " & schema & "t_check ," & schema & "v_tenken_kekka "
        strSql &= " where to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'yyyy')='" & YYYY & "' "
        strSql &= " and t_check.チェック ='2' "
        strSql &= " and v_tenken_kekka.""受付ＮＯ"" = " & schema & "t_check.点検受付番号 "
        strSql &= " group by to_char(to_date(v_tenken_kekka.点検完了日,'yyyy/MM/dd'),'MM') "
        strSql &= " ) Keibi on Zen.Mo = Keibi.Mo "
        strSql &= "ORDER BY zen.Mo "

        Return strSql

    End Function
    Private Function DataTableSwapXY2(ByVal src As DataTable, ByVal newColName As String) As DataTable

        Dim ret As New DataTable(src.TableName)

        '列の追加
        ret.Columns.Add(newColName)
        For y As Integer = 0 To src.Rows.Count - 1
            ret.Columns.Add(src.Rows(y)(0))
        Next

        '列を行に変換
        For x As Integer = 2 To src.Columns.Count - 1

            Dim dr As DataRow = ret.NewRow()

            dr(newColName) = src.Columns(x).ColumnName

            For y As Integer = 0 To src.Rows.Count - 1
                dr(ret.Columns(y + 1).ColumnName) = src.Rows(y)(x)
            Next

            ret.Rows.Add(dr)
        Next

        DataTableSwapXY2 = ret
    End Function





End Module
