Public Class FormUriageSub
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ClassPostgeDB As New ClassPostgeDB

    Dim _kekka As String = String.Empty
    Dim _bunrui As String = String.Empty
    Dim _nentuki As String = String.Empty
    Dim _maker As String = String.Empty
    Dim _kanryoutuki As String = String.Empty

    Public Property KanryouTuki As String
        Get
            KanryouTuki = _kanryoutuki
        End Get
        Set(value As String)
            _kanryoutuki = value
        End Set
    End Property


    Public Property Maker As String
        Get
            Maker = _maker
        End Get
        Set(value As String)
            _maker = value
        End Set
    End Property
    Public Property Nentuki As String
        Get
            Nentuki = _nentuki
        End Get
        Set(value As String)
            _nentuki = value
        End Set
    End Property
    Public Property Bunrui As String
        Get
            Bunrui = _bunrui
        End Get
        Set(value As String)
            _bunrui = value
        End Set
    End Property

    Public Property Kekka As String
        Get
            Kekka = _kekka
        End Get
        Set(value As String)
            _kekka = value
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

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub FormUriageSub_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "売り上げ管理　" & " Version[" & Ver & "] " & vAsm.v説明
        Me.ToolStripStatusLabel1.Text = vAsm.v会社情報
        検索()
    End Sub

    Private Sub 検索()
        Dim strSQL As String = String.Empty
        Dim dt As DataTable

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.Columns.Clear()
        Me.DataGridView1.Rows.Clear()

        Select Case Kekka
            Case "請求済"
                Select Case Bunrui
                    Case "別途"
                        strSQL = ""

                        strSQL &= "select  substring(点検受付日,0,11) 点検受付日 , '" & Nentuki & "' 売上年月,'請求済' 結果表,'別途' 分類"
                        strSQL &= " ,t.cst_cd 得意先,t.uketukeno 受付番号, cast(COALESCE( t.upri, '0' ) as numeric ) 売上金額"

                        strSQL &= " from " & schema & "t_002 t , " & schema & "v_yuryo_tenken_syuyaku v"
                        strSQL &= " where t.uketukeno  = v.点検受付番号 "
                        strSQL &= " and left(t.nextb,7) = '" & Nentuki & "'"
                        strSQL &= " and t.out_flg ='1'"
                        strSQL &= " and v.回収完了日 is not null"
                        'strSQL &= " and v.回収区分 in ('NR後日請求')"
                        strSQL &= " and t.cst_cd  in (" & GetCstCD("別途") & ")"

                    Case "直集"

                        strSQL = ""

                        strSQL &= "select  substring(点検受付日,0,11) 点検受付日 , '" & Nentuki & "' 売上年月,'請求済' 結果表,'直集' 分類"
                        strSQL &= " ,t.cst_cd 得意先,t.uketukeno 受付番号, cast(COALESCE( t.upri, '0' ) as numeric ) 売上金額"


                        strSQL &= " from " & schema & "t_002 t , " & schema & "v_yuryo_tenken_syuyaku v"
                        strSQL &= " where t.uketukeno  = v.点検受付番号 "
                        strSQL &= " and left(t.nextb,7) = '" & Nentuki & "'"
                        strSQL &= " and t.out_flg ='1'"
                        strSQL &= " and v.回収完了日 is not null"
                        'strSQL &= " and v.回収区分 in ('SS後日請求','SS現金徴収')"
                        strSQL &= " and t.cst_cd  in (" & GetCstCD("直集") & ")"

                End Select
            Case "受付中"
                Select Case Bunrui
                    Case "別途"
                        strSQL = ""
                        strSQL &= " select  substring(点検受付日,0,11) 点検受付日 ,'' 売上年月,'受付中' 結果表,'別途' 分類"
                        strSQL &= " ,'' 得意先,v.点検受付番号," & SQL4() & " 売上金額"

                        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
                        'strSQL &= " where v.点検受付番号 not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
                        strSQL &= " where v.ステータス名  = '点検受付'"
                        strSQL &= " and v.回収完了日  is not null"
                        strSQL &= " and v.回収区分 in ('NR後日請求')"

                    Case "直集"

                        strSQL = ""
                        strSQL &= " select  substring(点検受付日,0,11) 点検受付日 , '' 売上年月,'受付中' 結果表,'直集' 分類"
                        strSQL &= " ,'' 得意先,v.点検受付番号," & SQL4() & " 売上金額"

                        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
                        'strSQL &= " where v.点検受付番号 not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
                        strSQL &= " where v.ステータス名  = '点検受付'"
                        strSQL &= " and v.回収完了日  is not null"
                        strSQL &= " and v.回収区分 in ('SS後日請求','SS現金徴収')"

                End Select

            Case "点検完了未請求"
                Select Case Bunrui
                    Case "別途"

                        strSQL = " "
                        strSQL &= " select substring(v.点検受付日,0,11) 点検受付日 ,  v.点検完了日 ,'点検完了未請求' 結果表,'別途' 分類"
                        strSQL &= " ,'' 得意先,v.点検受付番号," & SQL4() & " 売上金額"

                        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
                        'strSQL &= " where v.点検受付番号 Not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
                        strSQL &= " where v.ステータス名  = '点検完了'"
                        strSQL &= " and ( v.回収完了日  is  null  or v.回収完了日 ='')"
                        strSQL &= " and v.回収区分 in ('NR後日請求')"
                        strSQL &= " and left(v.点検完了日,7)='" & KanryouTuki() & "' "

                    Case "直集"
                        strSQL = " "
                        strSQL &= " select substring(v.点検受付日,0,11) 点検受付日 , v.点検完了日 ,'点検完了未請求' 結果表,'直集' 分類"
                        strSQL &= " ,'' 得意先,v.点検受付番号," & SQL4() & " 売上金額"

                        strSQL &= " from " & schema & "v_yuryo_tenken_syuyaku v"
                        'strSQL &= " where v.点検受付番号 Not in (select uketukeno from " & schema & "t_002 where out_flg='1')"
                        strSQL &= " where v.ステータス名  = '点検完了'"
                        strSQL &= " and ( v.回収完了日  is  null  or v.回収完了日 ='')"
                        strSQL &= " and v.回収区分 in ('SS後日請求','SS現金徴収')"
                        strSQL &= " and left(v.点検完了日,7)='" & KanryouTuki() & "' "

                End Select

        End Select
        If strSQL = String.Empty Then


        Else
            If Maker = "全部" Then


            Else
                strSQL &= " and v.メーカー ='" & Maker & "'"
            End If
        End If

        dt = ClassPostgeDB.SetTable(strSQL)
        Me.DataGridView1.DataSource = dt
        Me.DataGridView1.Columns(0).Width = 120
        Me.DataGridView1.AllowUserToAddRows = False
        Me.Cursor = System.Windows.Forms.Cursors.Default




    End Sub
    Private Function SQL4() As String

        Return "(v.技術料  + v.出張料 + v.その他料金 +cast(( case when v.サポート料 is null then '0' when v.サポート料 = '' then '0' else v.サポート料 end ) as  numeric) -cast(( case when v.値引き is null then '0'  when v.値引き = '' then '0' else v.値引き end )  as  numeric)) "



    End Function

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        excelOutDataGred2(Me.DataGridView1, True, Me.ToolStripProgressBar1, 0)
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click

    End Sub
End Class