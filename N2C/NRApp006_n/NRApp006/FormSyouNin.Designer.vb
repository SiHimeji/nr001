<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSyouNin
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSyouNin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.検索ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.チェックToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全ONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全OFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.反転ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox期間 = New System.Windows.Forms.GroupBox()
        Me.ComboBox期間 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox品質 = New System.Windows.Forms.CheckBox()
        Me.CheckBox料金 = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NumericUpDownmax = New System.Windows.Forms.NumericUpDown()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox期間.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownmax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.検索ToolStripMenuItem, Me.チェックToolStripMenuItem, Me.出力ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(936, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '検索ToolStripMenuItem
        '
        Me.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem"
        Me.検索ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.検索ToolStripMenuItem.Text = "検索"
        '
        'チェックToolStripMenuItem
        '
        Me.チェックToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.全ONToolStripMenuItem, Me.全OFFToolStripMenuItem, Me.反転ToolStripMenuItem})
        Me.チェックToolStripMenuItem.Name = "チェックToolStripMenuItem"
        Me.チェックToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.チェックToolStripMenuItem.Text = "チェック"
        '
        '全ONToolStripMenuItem
        '
        Me.全ONToolStripMenuItem.Name = "全ONToolStripMenuItem"
        Me.全ONToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.全ONToolStripMenuItem.Text = "全ON"
        '
        '全OFFToolStripMenuItem
        '
        Me.全OFFToolStripMenuItem.Name = "全OFFToolStripMenuItem"
        Me.全OFFToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.全OFFToolStripMenuItem.Text = "全OFF"
        '
        '反転ToolStripMenuItem
        '
        Me.反転ToolStripMenuItem.Name = "反転ToolStripMenuItem"
        Me.反転ToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.反転ToolStripMenuItem.Text = "反転"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CSVToolStripMenuItem, Me.EXCELToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(936, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.NumericUpDownmax)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox期間)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox品質)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBox料金)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(936, 529)
        Me.SplitContainer1.SplitterDistance = 100
        Me.SplitContainer1.TabIndex = 3
        '
        'GroupBox期間
        '
        Me.GroupBox期間.Controls.Add(Me.ComboBox期間)
        Me.GroupBox期間.Controls.Add(Me.Label2)
        Me.GroupBox期間.Controls.Add(Me.DateTimePicker期間2)
        Me.GroupBox期間.Controls.Add(Me.DateTimePicker期間1)
        Me.GroupBox期間.Location = New System.Drawing.Point(202, 16)
        Me.GroupBox期間.Name = "GroupBox期間"
        Me.GroupBox期間.Size = New System.Drawing.Size(464, 54)
        Me.GroupBox期間.TabIndex = 7
        Me.GroupBox期間.TabStop = False
        Me.GroupBox期間.Text = "期間"
        '
        'ComboBox期間
        '
        Me.ComboBox期間.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox期間.FormattingEnabled = True
        Me.ComboBox期間.Location = New System.Drawing.Point(24, 16)
        Me.ComboBox期間.Name = "ComboBox期間"
        Me.ComboBox期間.Size = New System.Drawing.Size(110, 20)
        Me.ComboBox期間.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "～"
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(312, 18)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(123, 19)
        Me.DateTimePicker期間2.TabIndex = 9
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(154, 18)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(123, 19)
        Me.DateTimePicker期間1.TabIndex = 8
        '
        'CheckBox品質
        '
        Me.CheckBox品質.AutoSize = True
        Me.CheckBox品質.Checked = True
        Me.CheckBox品質.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox品質.Location = New System.Drawing.Point(36, 38)
        Me.CheckBox品質.Name = "CheckBox品質"
        Me.CheckBox品質.Size = New System.Drawing.Size(63, 16)
        Me.CheckBox品質.TabIndex = 1
        Me.CheckBox品質.Text = "品質OK"
        Me.CheckBox品質.UseVisualStyleBackColor = True
        '
        'CheckBox料金
        '
        Me.CheckBox料金.AutoSize = True
        Me.CheckBox料金.Checked = True
        Me.CheckBox料金.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox料金.Location = New System.Drawing.Point(36, 16)
        Me.CheckBox料金.Name = "CheckBox料金"
        Me.CheckBox料金.Size = New System.Drawing.Size(63, 16)
        Me.CheckBox料金.TabIndex = 0
        Me.CheckBox料金.Text = "料金OK"
        Me.CheckBox料金.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(936, 425)
        Me.DataGridView1.TabIndex = 0
        '
        'NumericUpDownmax
        '
        Me.NumericUpDownmax.Location = New System.Drawing.Point(36, 60)
        Me.NumericUpDownmax.Name = "NumericUpDownmax"
        Me.NumericUpDownmax.Size = New System.Drawing.Size(120, 19)
        Me.NumericUpDownmax.TabIndex = 8
        '
        'FormSyouNin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 575)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormSyouNin"
        Me.Text = "承認データ"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox期間.ResumeLayout(False)
        Me.GroupBox期間.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownmax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 検索ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CheckBox品質 As CheckBox
    Friend WithEvents CheckBox料金 As CheckBox
    Friend WithEvents GroupBox期間 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents チェックToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全ONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 全OFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 反転ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboBox期間 As ComboBox
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents NumericUpDownmax As NumericUpDown
End Class
