<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSQL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSQL))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.実行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ファイルからToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQL実行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.アクセスログToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersinUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxSQL = New System.Windows.Forms.TextBox()
        Me.TextBoxFileName1 = New System.Windows.Forms.TextBox()
        Me.Button検索 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBoxSQL = New System.Windows.Forms.ListBox()
        Me.TESTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了ToolStripMenuItem, Me.実行ToolStripMenuItem, Me.SQLToolStripMenuItem, Me.アクセスログToolStripMenuItem, Me.VersinUpToolStripMenuItem, Me.TESTToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(763, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '終了ToolStripMenuItem
        '
        Me.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem"
        Me.終了ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.終了ToolStripMenuItem.Text = "終了"
        '
        '実行ToolStripMenuItem
        '
        Me.実行ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルからToolStripMenuItem, Me.SQL実行ToolStripMenuItem})
        Me.実行ToolStripMenuItem.Name = "実行ToolStripMenuItem"
        Me.実行ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.実行ToolStripMenuItem.Text = "実行"
        '
        'ファイルからToolStripMenuItem
        '
        Me.ファイルからToolStripMenuItem.Name = "ファイルからToolStripMenuItem"
        Me.ファイルからToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ファイルからToolStripMenuItem.Text = "ファイルから実行"
        '
        'SQL実行ToolStripMenuItem
        '
        Me.SQL実行ToolStripMenuItem.Name = "SQL実行ToolStripMenuItem"
        Me.SQL実行ToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SQL実行ToolStripMenuItem.Text = "SQL実行"
        '
        'SQLToolStripMenuItem
        '
        Me.SQLToolStripMenuItem.Name = "SQLToolStripMenuItem"
        Me.SQLToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.SQLToolStripMenuItem.Text = "バージョン"
        '
        'アクセスログToolStripMenuItem
        '
        Me.アクセスログToolStripMenuItem.Name = "アクセスログToolStripMenuItem"
        Me.アクセスログToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.アクセスログToolStripMenuItem.Text = "アクセスログ"
        '
        'VersinUpToolStripMenuItem
        '
        Me.VersinUpToolStripMenuItem.Name = "VersinUpToolStripMenuItem"
        Me.VersinUpToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.VersinUpToolStripMenuItem.Text = "VersinUp"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxSQL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxFileName1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button検索)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListBoxSQL)
        Me.SplitContainer1.Size = New System.Drawing.Size(763, 332)
        Me.SplitContainer1.SplitterDistance = 68
        Me.SplitContainer1.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 12)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "SQL"
        '
        'TextBoxSQL
        '
        Me.TextBoxSQL.Location = New System.Drawing.Point(68, 35)
        Me.TextBoxSQL.Name = "TextBoxSQL"
        Me.TextBoxSQL.Size = New System.Drawing.Size(445, 19)
        Me.TextBoxSQL.TabIndex = 24
        '
        'TextBoxFileName1
        '
        Me.TextBoxFileName1.Location = New System.Drawing.Point(68, 10)
        Me.TextBoxFileName1.Name = "TextBoxFileName1"
        Me.TextBoxFileName1.Size = New System.Drawing.Size(445, 19)
        Me.TextBoxFileName1.TabIndex = 23
        '
        'Button検索
        '
        Me.Button検索.Location = New System.Drawing.Point(519, 10)
        Me.Button検索.Name = "Button検索"
        Me.Button検索.Size = New System.Drawing.Size(75, 19)
        Me.Button検索.TabIndex = 22
        Me.Button検索.Text = "検索"
        Me.Button検索.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "ファイル"
        '
        'ListBoxSQL
        '
        Me.ListBoxSQL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxSQL.FormattingEnabled = True
        Me.ListBoxSQL.ItemHeight = 12
        Me.ListBoxSQL.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxSQL.Name = "ListBoxSQL"
        Me.ListBoxSQL.Size = New System.Drawing.Size(763, 260)
        Me.ListBoxSQL.TabIndex = 22
        '
        'TESTToolStripMenuItem
        '
        Me.TESTToolStripMenuItem.Name = "TESTToolStripMenuItem"
        Me.TESTToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.TESTToolStripMenuItem.Text = "TEST"
        '
        'FormSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 356)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormSQL"
        Me.Text = "SQL実行"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 実行ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TextBoxFileName1 As TextBox
    Friend WithEvents Button検索 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBoxSQL As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxSQL As TextBox
    Friend WithEvents SQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents アクセスログToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ファイルからToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SQL実行ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VersinUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TESTToolStripMenuItem As ToolStripMenuItem
End Class
