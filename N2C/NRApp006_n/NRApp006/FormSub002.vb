Public Class FormSub002
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB()
    Dim _AkaKuro As String

    '0 =黒　1=赤
    Public Property AkaKUro As String
        Get
            AkaKUro = _AkaKuro
        End Get
        Set(value As String)
            _AkaKuro = value
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

    Private Sub FormSub002_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If AkaKUro = 0 Then '黒
            Dim dt As DataTable
            Me.Label赤黒.Text = "黒伝票"
            Me.Label赤黒.TextAlign = ContentAlignment.MiddleCenter
            Me.Label赤黒.BackColor = Color.Green
            Me.Label得意先コード.Visible = True
            Me.ComboBox得意先.Visible = True
            Me.DateTimePicker伝票発行日.Visible = False

            dt = ClassPostgeDB.SetTable("select cst_cd  from " & schema & "t_002  group by cst_cd order by cst_cd")
            Me.ComboBox得意先.Items.Clear()
            Me.ComboBox得意先.Items.Add("")

            For Each dtrow In dt.Rows
                Me.ComboBox得意先.Items.Add(dtrow(0).ToString)
            Next

            Me.ComboBox得意先.SelectedIndex = -1
            SetComboBox(Me.ComboBox得意先, w002得意先)

        Else
            Me.Label赤黒.Text = "赤伝票"
            Me.DateTimePicker伝票発行日.Visible = True
            Me.Label赤黒.BackColor = Color.Red
            Me.Label赤黒.TextAlign = ContentAlignment.MiddleCenter
            Me.Label得意先コード.Visible = False
            Me.ComboBox得意先.Visible = False
            Me.DateTimePicker伝票発行日.Value = Now.Date

        End If


    End Sub

    Private Sub Buttonキャンセル_Click(sender As Object, e As EventArgs) Handles Buttonキャンセル.Click
        w002Exe = False
        Close()
    End Sub

    Private Sub Button決定_Click(sender As Object, e As EventArgs) Handles Button決定.Click

        If AkaKUro = 0 Then '黒
            If Me.ComboBox得意先.Text <> "" Then
                w002Exe = True
                w002得意先 = Me.ComboBox得意先.Text
                w002金額 = Me.NumericUpDown金額.Value
                Close()
            End If
        Else
            w002Exe = True
            w002得意先 = ""
            w002金額 = Me.NumericUpDown金額.Value
            w002伝票発行日 = Me.DateTimePicker伝票発行日.Value
            Close()
        End If

    End Sub
End Class