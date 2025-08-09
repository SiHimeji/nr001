Public Class FormHanbaiitiran

    Dim ClassPostgeDB As New ClassPostgeDB

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormHanbaiitiran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridView1.ReadOnly = True
        disp()
    End Sub
    Private Sub disp()
        Dim strSQL As String

        DataGridView1.RowHeadersVisible = False
        strSQL = "SELECT 'false',jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku, "
        strSQL &= "coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
        strSQL &= " FROM " & schema & "t_order where flg ='0' order by seq"
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

        'For i = 0 To i < Me.DataGridView1.Rows.Count - 1
        'Me.DataGridView1.Rows(i).HeaderCell.Value = (i + 1).ToString()
        'Next


    End Sub
    Private Sub ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = True
        Next
    End Sub

    Private Sub OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OFFToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = False
        Next
    End Sub

    Private Sub 反転ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反転ToolStripMenuItem.Click
        Dim ro As Integer
        For ro = 0 To Me.DataGridView1.Rows.Count - 1
            Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
        Next
    End Sub

    Private Sub 実行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 実行ToolStripMenuItem.Click
        Dim strSQL As String
        Dim bRet As Boolean
        Dim syorisuuas As Integer
        Dim syori As Integer

        syori = 0
        syorisuuas = 0
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            bRet = CBool(dr.Cells(0).Value)
            If bRet Then
                If dr.Cells(17).Value <> "" Then
                    syorisuuas = syorisuuas + 1
                End If
            End If
        Next
        FormMeter.MAX = syorisuuas
        FormMeter.Show()

        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            bRet = CBool(dr.Cells(0).Value)
            If bRet Then
                If dr.Cells(17).Value <> "" Then
                    strSQL = "DELETE FROM " & schema & "t_order WHERE seq ='" & dr.Cells(17).Value & "'"
                    ClassPostgeDB.EXEC(strSQL)
                    'strSQL = "UPDATE t_genzaiko SET jyutyuu = jyutyuu - " & dr.Cells(4).Value & "  where sinacd = '" & dr.Cells(3).Value & "'"
                    'ClassPostgeDB.EXEC(strSQL)
                    syori = syori + 1
                End If
            End If

            FormMeter.GEN = syori
            FormMeter.Disp()

        Next
        FormMeter.CLos()
        disp()
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                If e.ColumnIndex = 0 Then
                    Me.DataGridView1.Rows(ro).Cells(0).Value = Not CBool(Me.DataGridView1.Rows(ro).Cells(0).Value)
                End If
            End If
        End If
    End Sub


    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        excelOutDataGred(Me.DataGridView1, False)

    End Sub


End Class