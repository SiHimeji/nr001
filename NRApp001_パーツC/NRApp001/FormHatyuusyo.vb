Imports System
Imports System.IO

Public Class FormHatyuusyo
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
    Dim dt As DataTable
    Dim kouainFLG As Boolean

    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty

    Public Property UserID As String
        Get
            UserID = _UserID
        End Get
        Set(value As String)
            _UserID = value
        End Set
    End Property

    Public Property Kengen As String
        Get
            Kengen = _Kengen
        End Get
        Set(value As String)
            _Kengen = value
        End Set
    End Property
    Public Property UserName As String
        Get
            UserName = _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        If kouainFLG Then
            If MsgBox("確定処理を実行していません。実行しますか", vbYesNo + vbQuestion) = vbYes Then
                KakuteiSyori()
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub

    Private Sub FormHatyuusyo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String


        strSQL = "SELECT t_goodsstock.sinacd"
        strSQL &= ",m_seihin.seihinmei "
        strSQL &= ",t_goodsstock.zaiko "
        strSQL &= ",m_seihin.kijunzaiko "
        strSQL &= ",m_seihin.kijunzaiko - t_goodsstock.zaiko - t_genzaiko.tyuuzan  tyumon"
        strSQL &= ",m_seihin.souko "
        strSQL &= ",t_genzaiko.tyuuzan "
        strSQL &= ",'','',''"

        strSQL &= " FROM  " & schema & "t_goodsstock ," & schema & "m_seihin , " & schema & "t_genzaiko"
        strSQL &= " where t_goodsstock.sinacd  =  m_seihin.sinacd "
        strSQL &= " and  t_goodsstock.sinacd   =  t_genzaiko.sinacd "
        strSQL &= " and  t_goodsstock.flg = '0'"
        'strSQL &= " and  m_seihin.souko = '通常在庫'"
        strSQL &= " and  m_seihin.souko  in (Select substr(naiyou, 3, 20) from " & schema & "m_system where kbn ='3' and naiyou2 ='1')"
        strSQL &= " And (m_seihin.kijunzaiko - t_goodsstock.zaiko - t_genzaiko.tyuuzan) > 0 "

        dt = ClassPostgeDB.SetTable(strSQL)

        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.Columns(0).HeaderText = "品コード"
        Me.DataGridView1.Columns(1).HeaderText = "品名"
        Me.DataGridView1.Columns(2).HeaderText = "EC在庫数"
        Me.DataGridView1.Columns(3).HeaderText = "基準在庫"
        Me.DataGridView1.Columns(4).HeaderText = "補充数"
        Me.DataGridView1.Columns(5).HeaderText = "在庫種類"
        Me.DataGridView1.Columns(6).HeaderText = "注残"

        Me.DataGridView1.Columns(7).HeaderText = "処理"
        Me.DataGridView1.Columns(8).HeaderText = "オーダー番号"
        Me.DataGridView1.Columns(9).HeaderText = "入庫予定日"
        DataGridView1.DefaultCellStyle.NullValue = "-"
        '補充チェック()

    End Sub

    Private Sub 補充チェック()
        Dim rowloop As Integer

        For rowloop = 0 To Me.DataGridView1.Rows.Count - 2
            If Me.DataGridView1.Rows(rowloop).Cells(5).Value.ToString() = "通常在庫" Then
                Me.DataGridView1.Rows(rowloop).Cells(6).Value = ""

            End If
        Next

    End Sub


    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        Dim dt1 As DateTime = DateTime.Now
        ExcelOut(dt, "在庫移動.xlsx", Path.GetTempPath() & dt1.ToString("yyyyMMddHHmmss") & "在庫移動.xlsx")
        kouainFLG = True
    End Sub

    Private Sub 確定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 確定ToolStripMenuItem.Click

        If kouainFLG Then
            If MsgBox("確定処理を実行しますか", vbYesNo + vbQuestion) = vbYes Then

                KakuteiSyori()
                ' Me.DataGridView1.Rows.Clear()

                Me.Close()

            End If
        Else
            MessageBox.Show("EXCEL出力していません")
        End If
    End Sub

    '在庫移動確定処理
    Private Sub KakuteiSyori()
        Dim rowloop As Integer
        Dim strSQL As String
        Dim w_品コード As String
        Dim w_現在庫 As String
        Dim w_補充数 As String
        Dim w_商品名 As String


        Dim FormMeter As New FormMeter
        FormMeter.MAX = dt.Rows.Count
        FormMeter.Show()


        For rowloop = 0 To dt.Rows.Count - 1
            w_品コード = dt.Rows(rowloop).Item(0).ToString
            w_現在庫 = dt.Rows(rowloop).Item(2).ToString
            w_補充数 = dt.Rows(rowloop).Item(4).ToString

            w_商品名 = Get_syouhinmei(w_品コード)

            strSQL = "INSERT INTO " & schema & "t_zaiko(sinacd,syouhinmei,hituke,goukei,entry_day, entry_sya, update_day, seq , orderno)VALUES("
            strSQL &= " '" & w_品コード & "'"
            strSQL &= ",'" & w_商品名 & "'"
            strSQL &= ",current_date"
            strSQL &= ",'" & w_補充数 & "'"
            strSQL &= ",now()"
            strSQL &= ",'" & UserName & "'"
            strSQL &= ",now()"
            strSQL &= ",nextval('" & schema & "seqzaiko')"
            strSQL &= ",''"
            strSQL &= ")"
            ClassPostgeDB.EXEC(strSQL)

            strSQL = "UPDATE " & schema & "t_goodsstock SET flg = '1',kousinbi=now()"
            strSQL &= " WHERE sinacd ='" & w_品コード & "'"
            strSQL &= " And flg  = '0' "
            ClassPostgeDB.EXEC(strSQL)

            Set_genzaiko_jyutyuu(w_品コード, Integer.Parse(w_現在庫), Integer.Parse(w_補充数), UserName)

            FormMeter.GEN = rowloop
            FormMeter.Disp()

        Next

        FormMeter.CLos()
        kouainFLG = False
        MessageBox.Show("確定処理を完了しました")
    End Sub

    Private Sub FormHatyuusyo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If kouainFLG Then
            If MsgBox("確定処理を実行していません。実行しますか", vbYesNo + vbQuestion) = vbYes Then
                KakuteiSyori()
            End If
        End If

    End Sub
End Class