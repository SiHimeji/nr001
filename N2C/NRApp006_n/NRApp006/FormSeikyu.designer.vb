<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSeikyu
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSeikyu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.検索ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.出力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OFFToolStripMenuItem = New System.Windows.Forms.ToolStripComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel件数 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListBoxステータス = New System.Windows.Forms.ListBox()
        Me.Labelステータス = New System.Windows.Forms.Label()
        Me.GroupBox期間 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker期間2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker期間1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBoxリスト = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox期間.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.検索ToolStripMenuItem, Me.出力ToolStripMenuItem, Me.ToolStripMenuItem1, Me.OFFToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1030, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '検索ToolStripMenuItem
        '
        Me.検索ToolStripMenuItem.Name = "検索ToolStripMenuItem"
        Me.検索ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.検索ToolStripMenuItem.Text = "検索"
        '
        '出力ToolStripMenuItem
        '
        Me.出力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem, Me.CSVToolStripMenuItem})
        Me.出力ToolStripMenuItem.Name = "出力ToolStripMenuItem"
        Me.出力ToolStripMenuItem.Size = New System.Drawing.Size(43, 23)
        Me.出力ToolStripMenuItem.Text = "出力"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(52, 23)
        Me.ToolStripMenuItem1.Text = "完了を"
        '
        'OFFToolStripMenuItem
        '
        Me.OFFToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OFFToolStripMenuItem.Items.AddRange(New Object() {"含めない", "含める"})
        Me.OFFToolStripMenuItem.Name = "OFFToolStripMenuItem"
        Me.OFFToolStripMenuItem.Size = New System.Drawing.Size(80, 23)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel件数, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 517)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1030, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel件数
        '
        Me.ToolStripStatusLabel件数.Name = "ToolStripStatusLabel件数"
        Me.ToolStripStatusLabel件数.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel件数.Text = "ToolStripStatusLabel2"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(200, 16)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 27)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBoxステータス)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Labelステータス)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox期間)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxリスト)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1030, 490)
        Me.SplitContainer1.SplitterDistance = 95
        Me.SplitContainer1.TabIndex = 2
        '
        'ListBoxステータス
        '
        Me.ListBoxステータス.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ListBoxステータス.FormattingEnabled = True
        Me.ListBoxステータス.ItemHeight = 15
        Me.ListBoxステータス.Location = New System.Drawing.Point(277, 15)
        Me.ListBoxステータス.Name = "ListBoxステータス"
        Me.ListBoxステータス.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxステータス.Size = New System.Drawing.Size(173, 64)
        Me.ListBoxステータス.TabIndex = 4
        '
        'Labelステータス
        '
        Me.Labelステータス.AutoSize = True
        Me.Labelステータス.Location = New System.Drawing.Point(221, 18)
        Me.Labelステータス.Name = "Labelステータス"
        Me.Labelステータス.Size = New System.Drawing.Size(50, 12)
        Me.Labelステータス.TabIndex = 3
        Me.Labelステータス.Text = "ステータス"
        '
        'GroupBox期間
        '
        Me.GroupBox期間.Controls.Add(Me.Label2)
        Me.GroupBox期間.Controls.Add(Me.DateTimePicker期間2)
        Me.GroupBox期間.Controls.Add(Me.DateTimePicker期間1)
        Me.GroupBox期間.Location = New System.Drawing.Point(510, 15)
        Me.GroupBox期間.Name = "GroupBox期間"
        Me.GroupBox期間.Size = New System.Drawing.Size(303, 48)
        Me.GroupBox期間.TabIndex = 1
        Me.GroupBox期間.TabStop = False
        Me.GroupBox期間.Text = "点検完了日期間"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "から"
        '
        'DateTimePicker期間2
        '
        Me.DateTimePicker期間2.CustomFormat = "yyyy年 MM月"
        Me.DateTimePicker期間2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker期間2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker期間2.Location = New System.Drawing.Point(180, 13)
        Me.DateTimePicker期間2.Name = "DateTimePicker期間2"
        Me.DateTimePicker期間2.ShowUpDown = True
        Me.DateTimePicker期間2.Size = New System.Drawing.Size(107, 23)
        Me.DateTimePicker期間2.TabIndex = 1
        '
        'DateTimePicker期間1
        '
        Me.DateTimePicker期間1.CustomFormat = "yyyy年 MM月"
        Me.DateTimePicker期間1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DateTimePicker期間1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker期間1.Location = New System.Drawing.Point(34, 13)
        Me.DateTimePicker期間1.Name = "DateTimePicker期間1"
        Me.DateTimePicker期間1.ShowUpDown = True
        Me.DateTimePicker期間1.Size = New System.Drawing.Size(107, 23)
        Me.DateTimePicker期間1.TabIndex = 0
        '
        'ComboBoxリスト
        '
        Me.ComboBoxリスト.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxリスト.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ComboBoxリスト.FormattingEnabled = True
        Me.ComboBoxリスト.Location = New System.Drawing.Point(77, 15)
        Me.ComboBoxリスト.Name = "ComboBoxリスト"
        Me.ComboBoxリスト.Size = New System.Drawing.Size(121, 23)
        Me.ComboBoxリスト.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "リスト"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(1030, 391)
        Me.DataGridView1.TabIndex = 1
        '
        'FormSeikyu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 539)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormSeikyu"
        Me.Text = "請求管理"
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents 出力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 検索ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStripStatusLabel件数 As ToolStripStatusLabel
    Friend WithEvents ComboBoxリスト As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents GroupBox期間 As GroupBox
    Friend WithEvents DateTimePicker期間2 As DateTimePicker
    Friend WithEvents DateTimePicker期間1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OFFToolStripMenuItem As ToolStripComboBox
    Friend WithEvents Labelステータス As Label
    Friend WithEvents ListBoxステータス As ListBox
    Friend WithEvents DataGridView1 As DataGridView
End Class
