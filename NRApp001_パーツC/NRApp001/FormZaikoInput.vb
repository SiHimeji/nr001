Public Class FormZaikoInput

    Dim zenkaiSQL As String
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim _FileName As String = String.Empty


    Public Property FileName As String
        Get
            FileName = _FileName
        End Get
        Set(value As String)
            _FileName = value
        End Set
    End Property

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

    Private Sub 更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem.Click
        Me.DataGridView1.Rows.Clear()

        Me.Close()
    End Sub

    Private Sub 更新ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 更新ToolStripMenuItem1.Click
        更新２()
    End Sub

    Private Sub 更新チェックToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub 更新２()
        Dim ClassPostgeDB As New ClassPostgeDB

        Dim strSQL As String

        Dim col As Integer
        Dim rol As Integer

        col = Me.DataGridView1.Columns.Count
        rol = Me.DataGridView1.Rows.Count

        For y = 0 To rol - 1
            strSQL = "update " & schema & "m_seihin  set  "
            strSQL &= "kijunzaiko= '" & DataGridView1.Rows(y).Cells(1).Value.ToString & "'"
            strSQL &= ",update_day= now()"
            strSQL &= ",entry_sya= '" & UserName & "' "
            strSQL &= " where sinacd= '" & DataGridView1.Rows(y).Cells(0).Value.ToString & "'"
            If ClassPostgeDB.EXEC(strSQL) Then
                DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.LightBlue
            Else
                DataGridView1.Rows(y).Cells(0).Style.BackColor = Color.Red
            End If

        Next

        '//
        MessageBox.Show("更新しました")
    End Sub

    Private Sub ファイルToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ファイルToolStripMenuItem.Click
        GetIniFile()
        FileName = Filesentaku(MaserFolder)
        If FileName.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0 Then

            Dim x As Integer
            CSVDataGridInput(Me.DataGridView1, FileName, Me.ToolStripMenuItem1)
            Me.DataGridView1.AllowUserToAddRows = False

            For x = 0 To Me.DataGridView1.Columns.Count - 1
                If Me.DataGridView1.Columns(x).HeaderText.Trim() = "" Then
                    DataGridView1.Columns.RemoveAt(x)
                Else
                    Select Case Me.DataGridView1.Columns(x).HeaderText.Trim()
                        Case "品コード"
                        Case "基準在庫"
                        Case Else
                            MessageBox.Show("ファイルが違います " & vbCrLf & "品コード , 基準在庫 　のCSVで作成してください")
                            Me.Close()
                            Exit Sub
                    End Select
                End If
            Next
        Else
            MessageBox.Show("ＣＳＶではありません")
        End If

    End Sub
End Class