
Imports ClassIF
Imports System.IO

Public Class FormSyuko
    Private Sub FormSyuko_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ToolStripStatusLabel1.Text = ""

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

#Region "出庫"

    Private Sub Button検索出庫_Click(sender As Object, e As EventArgs) Handles Button検索出庫.Click
        Dim ret As String = SelectFile()
        If ret.Length > 0 Then
            Me.TextBox出庫.Text = ret
        End If

    End Sub
    Private Sub 出庫ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 出庫ToolStripMenuItem.Click

        Dim cLib As New ClassIF.ClassIF出庫()
        Dim dt As DataTable
        Me.ToolStripStatusLabel1.Text = ""
        '拡張子の取得
        If System.IO.Path.GetExtension(Me.TextBox出庫.Text).ToLower = ".csv" Then
            dt = ClassDataRead.ReadCsv(Me.TextBox出庫.Text)
            Me.DataGridView1.DataSource = dt
            System.Windows.Forms.Application.DoEvents()
            cLib.csvINsert出庫(dt)

        ElseIf System.IO.Path.GetExtension(Me.TextBox出庫.Text).ToLower = ".xlsx" Then
            dt = ClassDataRead.ReadExcel(Me.TextBox出庫.Text, 2)
            System.Windows.Forms.Application.DoEvents()
            Me.DataGridView1.DataSource = dt
            cLib.csvINsert出庫(dt)
        End If

    End Sub
    Private Sub Button訂正_Click(sender As Object, e As EventArgs) Handles Button訂正.Click
        Dim ret As String = SelectFile()
        If ret.Length > 0 Then
            Me.TextBox訂正.Text = ret
        End If
    End Sub
#End Region

#Region "訂正取り込み"

    Private Sub Button訂正取り込み_Click(sender As Object, e As EventArgs) Handles Button訂正取り込み.Click
        Dim cLib As New ClassIF.ClassIF訂正()
        Dim dt As DataTable
        If Me.TextBox訂正.Text.Length > 0 Then
            Me.ToolStripStatusLabel1.Text = ""

            If System.IO.Path.GetExtension(Me.TextBox訂正.Text).ToLower = ".csv" Then
                dt = ClassDataRead.ReadCsv(Me.TextBox訂正.Text)
                Me.DataGridView1.DataSource = dt
                System.Windows.Forms.Application.DoEvents()
                cLib.csvINsert訂正(dt)

            ElseIf System.IO.Path.GetExtension(Me.TextBox訂正.Text).ToLower = ".xlsx" Then
                dt = ClassDataRead.ReadExcel(Me.TextBox訂正.Text, 2)
                Me.DataGridView1.DataSource = dt
                System.Windows.Forms.Application.DoEvents()
                cLib.csvINsert訂正(dt)
            End If
        End If
    End Sub
    Private Function SelectFile()

        Dim openFileDialog As New OpenFileDialog()

        ' ダイアログの設定
        openFileDialog.Title = "ファイルを選択してください"
        openFileDialog.Filter = "EXCEL (*.xlsx)|*.xlsx|テキストファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*"
        'openFileDialog.InitialDirectory = "C:\"
        ' ダイアログを表示し、結果を確認
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' 選択されたファイルパスを取得
            Dim selectedFilePath As String = openFileDialog.FileName
            Return selectedFilePath
        End If
        Return ""
    End Function

#End Region

#Region "オーダー"

    Private Sub Button検索オーダー_Click(sender As Object, e As EventArgs) Handles Button検索オーダー.Click
        Dim ret As String = SelectFile()
        If ret.Length > 0 Then
            Me.TextBoxオーダー.Text = ret
        End If

    End Sub

    Private Sub Buttonオーダー取り込み_Click(sender As Object, e As EventArgs) Handles Buttonオーダー取り込み.Click

        Dim cLib As New ClassIF.ClassIFオーダー()
        Dim dt As DataTable
        If Me.TextBoxオーダー.Text.Length > 0 Then
            Me.ToolStripStatusLabel1.Text = ""

            If System.IO.Path.GetExtension(Me.TextBoxオーダー.Text).ToLower = ".csv" Then
                dt = ClassDataRead.ReadCsv(Me.TextBoxオーダー.Text)
                Me.DataGridView1.DataSource = dt
                System.Windows.Forms.Application.DoEvents()
                cLib.csvINsertオーダー(dt)

            ElseIf System.IO.Path.GetExtension(Me.TextBoxオーダー.Text).ToLower = ".xlsx" Then
                dt = ClassDataRead.ReadExcel(Me.TextBoxオーダー.Text, 3)
                Me.DataGridView1.DataSource = dt
                System.Windows.Forms.Application.DoEvents()
                cLib.csvINsertオーダー(dt)
            End If
        End If
    End Sub
#End Region

End Class
