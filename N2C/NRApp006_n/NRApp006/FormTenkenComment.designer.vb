<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTenkenComment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTenkenComment))
        Me.ComboBoxComent = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'ComboBoxComent
        '
        Me.ComboBoxComent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxComent.FormattingEnabled = True
        Me.ComboBoxComent.Location = New System.Drawing.Point(4, 2)
        Me.ComboBoxComent.Name = "ComboBoxComent"
        Me.ComboBoxComent.Size = New System.Drawing.Size(271, 20)
        Me.ComboBoxComent.TabIndex = 0
        '
        'FormTenkenComment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 27)
        Me.Controls.Add(Me.ComboBoxComent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(124, 189)
        Me.Name = "FormTenkenComment"
        Me.Text = "コメント"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBoxComent As ComboBox
End Class
