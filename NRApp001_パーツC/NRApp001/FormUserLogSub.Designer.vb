<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUserLogSub
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUserLogSub))
        Me.Buttonログアプト = New System.Windows.Forms.Button()
        Me.ButtonNextB = New System.Windows.Forms.Button()
        Me.Buttonorder = New System.Windows.Forms.Button()
        Me.Button中止 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Buttonログアプト
        '
        resources.ApplyResources(Me.Buttonログアプト, "Buttonログアプト")
        Me.Buttonログアプト.Name = "Buttonログアプト"
        Me.Buttonログアプト.UseVisualStyleBackColor = True
        '
        'ButtonNextB
        '
        resources.ApplyResources(Me.ButtonNextB, "ButtonNextB")
        Me.ButtonNextB.Name = "ButtonNextB"
        Me.ButtonNextB.UseVisualStyleBackColor = True
        '
        'Buttonorder
        '
        resources.ApplyResources(Me.Buttonorder, "Buttonorder")
        Me.Buttonorder.Name = "Buttonorder"
        Me.Buttonorder.UseVisualStyleBackColor = True
        '
        'Button中止
        '
        resources.ApplyResources(Me.Button中止, "Button中止")
        Me.Button中止.Name = "Button中止"
        Me.Button中止.UseVisualStyleBackColor = True
        '
        'FormUserLogSub
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ControlBox = False
        Me.Controls.Add(Me.Button中止)
        Me.Controls.Add(Me.Buttonorder)
        Me.Controls.Add(Me.ButtonNextB)
        Me.Controls.Add(Me.Buttonログアプト)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "FormUserLogSub"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Buttonログアプト As Button
    Friend WithEvents ButtonNextB As Button
    Friend WithEvents Buttonorder As Button
    Friend WithEvents Button中止 As Button
End Class
