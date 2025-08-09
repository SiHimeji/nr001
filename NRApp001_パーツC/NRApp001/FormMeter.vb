Public Class FormMeter

    Dim _MAX As Integer = 0
    Dim _GEN As Integer = 0

    Public Property MAX As Integer
        Get
            MAX = _MAX
        End Get
        Set(value As Integer)
            _MAX = value
        End Set
    End Property

    Public Property GEN As Integer
        Get
            GEN = _GEN
        End Get
        Set(value As Integer)
            _GEN = value
        End Set
    End Property



    Public Sub Disp()
        Me.ProgressBar1.Value = GEN
        System.Windows.Forms.Application.DoEvents()
        Me.TopMost = Not Me.TopMost
    End Sub
    Public Sub CLos()
        Me.Close()
    End Sub


    Private Sub FormMeter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Maximum = MAX()
        Me.ProgressBar1.Step = 1
    End Sub
End Class