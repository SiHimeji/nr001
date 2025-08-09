Public Class FormSelectSeihin
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim _Seihn As String = String.Empty
    Dim _SinaCD As String = String.Empty
    Dim zenkaiSQL As String

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
    '-------------------------------------------------------------------------
    Public Property SinaCD As String
        Get
            Return _SinaCD
        End Get
        Set(value As String)
            _SinaCD = value
        End Set
    End Property
    Public Property SeihinName As String
        Get
            Return _Seihn
        End Get
        Set(value As String)
            _Seihn = value
        End Set
    End Property

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        SinaCD = Me.TextBox品コード.Text
        SeihinName = Me.TextBox商品名.Text

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
    Private Sub キャンセルToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles キャンセルToolStripMenuItem.Click
        SeihinName = ""
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub 検索(Cob As ComboBox, jy As String, txt As TextBox)
        Dim strSQL As String

        If Cob.SelectedIndex = -1 Then
            Cob.SelectedIndex = 0
        End If
        strSQL = "SELECT  sinacd, seihinmei, categori FROM " & schema & "m_seihin where entry_day is not null"
        Select Case Cob.Text
            Case "一致"
                strSQL = strSQL & " and " & jy & "  = '" & txt.Text.Trim.ToString & "'"
            Case "一部"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "%'"
            Case "前方"
                strSQL = strSQL & " and " & jy & " like '" & txt.Text.Trim.ToString & "%'"
            Case "後方"
                strSQL = strSQL & " and " & jy & " like '%" & txt.Text.Trim.ToString & "'"
            Case Else
                MessageBox.Show("条件を選択してください")
                Exit Sub

        End Select
        If Me.RadioButton全部.Checked = False Then
            If Me.RadioButton機種.Checked Then
                strSQL = strSQL & " and seihinflg = '1' "
            Else
                strSQL = strSQL & " and seihinflg = '0' "
            End If
        End If

        zenkaiSQL = strSQL
        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)
    End Sub

    Private Sub Button検索１_Click(sender As Object, e As EventArgs) Handles Button検索１.Click
        Call 検索(Me.ComboBoxJy1, "sinacd", Me.TextBox品コード)

    End Sub

    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        Call 検索(Me.ComboBoxJy2, "seihinmei", Me.TextBox商品名)

    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        Dim ro
        If e.Button = MouseButtons.Left Then
            ro = e.RowIndex
            If ro >= 0 Then
                Me.TextBox品コード.Text = Me.DataGridView1.Rows(ro).Cells(0).Value
                Me.TextBox商品名.Text = Me.DataGridView1.Rows(ro).Cells(1).Value
            End If
        End If

    End Sub

    Private Sub FormSelectSeihin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridView1.ReadOnly = True
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        If SinaCD <> "" Then
            Me.TextBox品コード.Text = SinaCD
            Me.ComboBoxJy1.SelectedIndex = 1

        End If
    End Sub

    Private Sub Button決定_Click(sender As Object, e As EventArgs) Handles Button決定.Click

        SinaCD = Me.TextBox品コード.Text
        SeihinName = Me.TextBox商品名.Text

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class