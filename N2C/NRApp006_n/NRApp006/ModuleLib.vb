Imports System.IO.Compression
Imports System.Net
Imports System.IO
Imports System
Imports System.Reflection

Module ModuleLib
    Structure ASM
        Public Version As String
        Public vタイトル As String
        Public v説明 As String
        Public v会社情報 As String
        Public v製品 As String
        Public v著作権 As String
        Public v商標 As String
    End Structure


    Public vAsm As New ASM

    Public Sub GetAsm()

        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        vAsm.Version = Info.ProductVersion 'GetVerAsn().ToString
        vAsm.vタイトル = Info.LegalTrademarks
        vAsm.v会社情報 = Info.CompanyName
        vAsm.v商標 = Info.FileDescription
        vAsm.v著作権 = Info.LegalCopyright
        vAsm.v製品 = Info.ProductName
        vAsm.v説明 = Info.Comments
    End Sub

#Region "アセンブリ情報取得"
    '-------------------------------------
    Public Function GetVer()
        Dim Info As FileVersionInfo
        Info = Process.GetCurrentProcess.MainModule.FileVersionInfo
        Return Info.ProductVersion
    End Function

#End Region



    Public Function settextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, rdonry As Boolean) As Integer

        Dim textColumn As New DataGridViewTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        ro = ro + 1
        Return ro

    End Function

    Public Function settextColumn(dgv As DataGridView, ro As Integer, DataPropertyName As String, HeaderText As String, wid As Integer, Mask As String, rdonry As Boolean) As Integer

        Dim textColumn As New DataGridViewMaskedTextBoxColumn()
        textColumn.DataPropertyName = DataPropertyName
        textColumn.Name = "Column" & ro.ToString
        textColumn.HeaderText = HeaderText
        textColumn.Mask = Mask
        dgv.Columns.Add(textColumn)
        dgv.Columns(ro).Width = wid
        dgv.Columns(ro).ReadOnly = rdonry
        ro = ro + 1
        Return ro

    End Function

    '********************************************************
    Public Function NextVersion(nVER As String)
        '1.0.0.0 →　1.0.0.1　 →　1.0.0.99　 →　1.0.1.0
        Dim Nextver(4) As Integer
        Dim NowVer() As String = nVER.Split(".")

        Nextver(0) = Integer.Parse(NowVer(0))
        Nextver(1) = Integer.Parse(NowVer(1))
        Nextver(2) = Integer.Parse(NowVer(2))
        Nextver(3) = Integer.Parse(NowVer(3)) + 1
        If Nextver(3) > 99 Then
            Nextver(3) = 0
            Nextver(2) = Nextver(2) + 1
            If Nextver(2) > 99 Then
                Nextver(2) = 0
                Nextver(1) = Nextver(1) + 1
                If Nextver(1) > 99 Then
                    Nextver(1) = 0
                    Nextver(0) = Nextver(0) + 1
                End If
            End If
        End If
        Return Nextver(0).ToString() & "." & Nextver(1).ToString() & "." & Nextver(2).ToString() & "." & Nextver(3).ToString()
    End Function


End Module
