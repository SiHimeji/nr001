Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class FormNext_B
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim zenkaiSQL As String
    '----
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    '-------- In
    Dim proc_grp_no As String
    Dim sts_typ_nm As String
    '---- NEXT-B Out
    Dim sls_typ As String
    Dim xpns_cd As String
    Dim ship_wh_cd As String
    Dim route_cd As String
    Dim fare_typ As String
    Dim cst_cd As String
    Dim cst_note As String
    Dim scnd_dler_tel As String
    Dim thrd_dler_tel As String
    Dim scst_nm As String
    Dim cst_po_no As String
    Dim ord_psn_nm As String
    Dim ord_psn_nm1 As String
    Dim slip_rmrks As String
    Dim intr_rmrks As String
    Dim chrg_dpt_cd As String
    Dim bf_no As String
    Dim ac_cd As String
    Dim fa_no As String
    Dim zn_rcv_psn_cd As String
    Dim itm_cd As String
    Dim qty As String
    Dim upri As String
    Dim rate As String
    Dim cst_dsnt_subno As String
    Dim ja_inst_no As String
    Dim ja_upri As String
    Dim ja_upri_rate As String

    '--------
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
    '-------------------------------------------------------------------------

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        GetIniFile()
        Me.TextBoxFileName1.Text = FileSave(Next2Folder)
        Next2Folder = Me.TextBoxFileName1.Text

    End Sub


    Private Function CSV出庫Hader(cnt As Int16)
        Select Case cnt
            Case 1
                CSV出庫Hader = """sls_typ"",""xpns_cd"",""ship_wh_cd"",""route_cd"",""fare_typ"",""cst_cd"",""cst_note"",""scnd_dler_tel"",""thrd_dler_tel"",""scst_nm"",""cst_po_no"",""ord_psn_nm"",""ord_psn_nm1"",""slip_rmrks"",""intr_rmrks"",""chrg_dpt_cd"",""bf_no"",""ac_cd"",""fa_no"",""zn_rcv_psn_cd"",""itm_cd"",""qty"",""upri"",""rate"",""cst_dsnt_subno"",""ja_inst_no"",""ja_upri"",""ja_upri_rate"""
            Case 2
                CSV出庫Hader = """売上区分"",""管理区分"",""出庫倉庫"",""運送便"",""運賃区分"",""得意先"",""得意先記事"",""2次店"",""3次店"",""送り先名"",""発注NO"",""発注者漢字"",""発注者カナ"",""備考漢字"",""備考カナ"",""負担部門"",""資金予算NO"",""勘定科目"",""固定資産管理NO"",""荷受人ＣＤ"",""品コード"",""数量"",""単価"",""売価率"",""枝番"",""明細発注NO"",""農協価格"",""農協価格率"""
            Case Else
                CSV出庫Hader = ""
        End Select

    End Function

    Private Sub Button出庫出力_Click(sender As Object, e As EventArgs) Handles Button出庫出力.Click
        Dim ClassPostgeDB2 = New ClassPostgeDB2()
        Dim strSQL As String
        Dim dt As DataTable
        Dim ro As Int16
        Dim entryTime As DateTime = DateTime.Now
        Dim Label原価単価 As String
        Dim DateTimePicker処理日 As String
        Dim TextBox備考 As String
        Dim ec送料品コード As String
        Dim FLG送料 As Boolean = False
        Dim 発注NO As String = String.Empty






        'Dim dt1 As DateTime
        If Me.TextBoxFileName1.Text <> "" Then

            SouryouZeo()

            Dim sw As System.IO.StreamWriter = Nothing
            Try
                sw = New System.IO.StreamWriter(Me.TextBoxFileName1.Text, False, System.Text.Encoding.GetEncoding("Shift_JIS"))

                sw.WriteLine(CSV出庫Hader(1))
                sw.WriteLine(CSV出庫Hader(2))

                strSQL = "select to2.cst_cd ,to2.jyutyucd,  to2.sinacd,  to2.kosuu,  to2.nebikitanka ,(select ms3.naiyou from " & schema & "m_system ms3 where ms3.kbn='21') ,to_char(now() ,'yyyymmdd') "
                strSQL &= ", to2.kessaihouhou, to2.syorikubun, to2.nyukinn, to_char(to2.nyukinkakuninbi,'YYYY/MM/DD') , to2.goukei"
                strSQL &= ", to2.coupon_waribiki , to2.tesuuryou , to2.seikyukingaku , to2.coupon_cd"
                strSQL &= ", to2.souryou , to2.seq , to_char(now() ,'yyyy/mm/dd') , ms2.naiyou2 , ms.makerkbn"

                strSQL &= " From " & schema & "t_order to2 ," & schema & "m_seihin ms , " & schema & "m_system ms2 "
                strSQL &= " where to2.sinacd = MS.sinacd  "
                strSQL &= " And ms2.kbn ='6' and ms2.naiyou =to2.cst_cd "
                strSQL &= " And flg = '0'"
                strSQL &= " order by to2.seq"

                dt = ClassPostgeDB.SetTable(strSQL)

                '/// seq = 17

                Dim row As DataRow
                ro = 0
                For Each row In dt.Rows

                    If row(20).ToString() = "2" Then

                        '///// EC処理

                        '2022/06/06
                        If 発注NO <> row(1).ToString() Then
                            発注NO = row(1).ToString()
                            FLG送料 = False
                        End If

                        'フィールドの取得  EC雑貨　出庫
                        sw.Write("""1""")
                        sw.Write(",""""")
                        sw.Write(",""CS""")
                        sw.Write(",""" & row(5).ToString() & """")  '倉庫
                        sw.Write(",""2""")                          '運賃区分
                        sw.Write(",""" & row(0).ToString() & """")  '得意先CD
                        sw.Write(",""""")                           '得意先記事
                        sw.Write(",""""")                           '２次店
                        sw.Write(",""""")                           '３次店
                        sw.Write(",""" & """")                      ' 送り先名
                        sw.Write(",""" & row(1).ToString() & """")          ' 発注NO
                        sw.Write(",""""")                                   ' 発注者漢字
                        sw.Write(",""""")                                   ' 発注者カナ
                        sw.Write(",""" & "ＥＣグッズ" & """")               ' 備考漢字　13, 
                        sw.Write(",""" & """")                              ' 備考カナ　14
                        sw.Write(",""""")                                   ' 負担部門 15
                        sw.Write(",""""")                                   ' 資金予算NO 16
                        sw.Write(",""""")                                   ' 勘定科目 17
                        sw.Write(",""""")                                   ' 固定資産管理NO 18
                        sw.Write(",""""")      '荷受人ＣＤ 19
                        sw.Write(",""" & row(2).ToString() & """")      ' 品コード 20
                        sw.Write(",""" & row(3).ToString() & """")      ' 数量
                        sw.Write(",""" & row(4).ToString() & """")      ' 単価
                        sw.Write(",""""")      '売価率
                        sw.Write(",""""")      '枝番
                        sw.Write(",""""")      '明細発注NO
                        sw.Write(",""""")      '農協価格
                        sw.Write(",""""")      '農協価格率
                        sw.Write(vbCrLf)        '改行



                        strSQL = "INSERT INTO " & schema & "t_uriage(sinacd, route_cd,cst_cd,ord_psn_nm,qty,upri,intr_rmrks"
                        strSQL &= ", kessaihouhou,syorikubun,nyukinn,nyukinkakuninbi,goukei"
                        strSQL &= ", coupon_waribiki , tesuuryou , seikyukingaku , coupon_cd , syouryou"

                        strSQL &= ", entry_day, update_day,seq,ship_wh_cd,cst_po_no,ord_psn_nm1,slip_rmrks"
                        strSQL &= ")VALUES("
                        'strSQL &= " '" & row(6).ToString().Trim & "'" ' seq
                        strSQL &= "'" & row(2).ToString().Trim & "'" '品コード
                        strSQL &= ",'" & row(5).ToString().Trim & "'" '倉庫
                        strSQL &= ",'" & row(0).ToString().Trim & "'" '得意先CD
                        strSQL &= ",'WEB'" '" '
                        strSQL &= ",'" & row(3).ToString().Trim & "'" '数量
                        strSQL &= ",'" & row(4).ToString().Trim & "'" '単価　値引き
                        strSQL &= ",'" & "'" '備考カナ

                        strSQL &= ",'" & row(7).ToString().Trim & "'" '
                        strSQL &= ",'" & row(8).ToString().Trim & "'" '
                        strSQL &= ",'" & row(9).ToString().Trim & "'" '

                        If IsDate(row(10).ToString().Trim, "yyyy/MM/dd") = True Then
                            strSQL &= ",'" & row(10).ToString().Trim & "'" '
                        Else
                            strSQL &= ",NULL"
                        End If

                        strSQL &= ",'" & row(11).ToString().Trim & "'" '
                        strSQL &= ",'" & row(12).ToString().Trim & "'" '
                        strSQL &= ",'" & row(13).ToString().Trim & "'" '
                        strSQL &= ",'" & row(14).ToString().Trim & "'" '

                        strSQL &= ",'" & row(15).ToString().Trim & "'" '
                        strSQL &= ",'" & row(16).ToString().Trim & "'" '
                        strSQL &= ",now()"
                        strSQL &= ",now()"
                        strSQL &= ",nextval('" & schema & "sequriage')"
                        'strSQL &= ",'" & row(17).ToString().Trim & "'" '
                        strSQL &= ",'CR'"
                        strSQL &= ",'" & row(1).ToString().Trim & "'" '
                        strSQL &= ",''" '
                        strSQL &= ",'" & "ＥＣグッズ" & "'"     '備考漢字　13, 
                        strSQL &= ")"

                        If ClassPostgeDB.EXEC(strSQL) = False Then
                            '  sw.Write("ERROR")
                        End If

                        '送料が０円なら処理しない
                        If row(16).ToString() <> "0" Then
                            '======2022/06/16

                            If FLG送料 = False Then
                                FLG送料 = True

                                ec送料品コード = GetSystemMst("23", "1").ToString.Trim()

                                sw.Write("""1""")
                                sw.Write(",""""")
                                sw.Write(",""CS""")
                                sw.Write(",""" & row(5).ToString() & """")  '倉庫
                                sw.Write(",""2""")                          '運賃区分
                                sw.Write(",""" & row(0).ToString() & """")  '得意先CD
                                sw.Write(",""""")                           '得意先記事
                                sw.Write(",""""")                           '２次店
                                sw.Write(",""""")                           '３次店
                                sw.Write(",""" & """")                      ' 送り先名
                                sw.Write(",""" & row(1).ToString() & """")          ' 発注NO
                                sw.Write(",""""")                                   ' 発注者漢字
                                sw.Write(",""""")                                   ' 発注者カナ
                                sw.Write(",""" & "ＥＣグッズ＿送料" & """")         ' 備考漢字　13, 
                                sw.Write(",""" & """")                              ' 備考カナ　14
                                sw.Write(",""""")                                   ' 負担部門 15
                                sw.Write(",""""")                                   ' 資金予算NO 16
                                sw.Write(",""""")                                   ' 勘定科目 17
                                sw.Write(",""""")                                   ' 固定資産管理NO 18
                                sw.Write(",""""")      '荷受人ＣＤ 19
                                sw.Write(",""" & "9000801" & """")                  ' 品コード 20
                                sw.Write(",""" & "1" & """")                        ' 数量
                                sw.Write(",""" & Zeinuki(row(16).ToString()) & """")         ' 単価
                                sw.Write(",""""")                                   '売価率
                                sw.Write(",""""")                   '枝番
                                sw.Write(",""""")                   '明細発注NO
                                sw.Write(",""""")                   '農協価格
                                sw.Write(",""""")                   '農協価格率
                                sw.Write(vbCrLf)                    '改行


                                strSQL = "INSERT INTO " & schema & "t_uriage(sinacd, route_cd,cst_cd,ord_psn_nm,qty,upri,intr_rmrks"
                                strSQL &= ", kessaihouhou,syorikubun,nyukinn,nyukinkakuninbi,goukei"
                                strSQL &= ", coupon_waribiki , tesuuryou , seikyukingaku , coupon_cd , syouryou"

                                strSQL &= ", entry_day, update_day,seq,ship_wh_cd,cst_po_no,ord_psn_nm1,slip_rmrks"
                                strSQL &= ")VALUES("
                                'strSQL &= " '" & row(6).ToString().Trim & "'"  ' seq
                                strSQL &= "'" & ec送料品コード & "'"                '品コード
                                strSQL &= ",'" & row(5).ToString().Trim & "'"       '倉庫
                                strSQL &= ",'" & row(0).ToString().Trim & "'"       ' 得意先CD
                                strSQL &= ",'WEB'"                                  '" '
                                strSQL &= ",'1'"                                    '数量
                                strSQL &= ",'" & Zeinuki(row(16).ToString()) & "'"  '単価　TAXなし
                                strSQL &= ",'" & "'" '備考カナ

                                strSQL &= ",'" & row(7).ToString().Trim & "'" '
                                strSQL &= ",'" & row(8).ToString().Trim & "'" '
                                strSQL &= ",'" & row(9).ToString().Trim & "'" '

                                If IsDate(row(10).ToString().Trim, "yyyy/MM/dd") = True Then
                                    strSQL &= ",'" & row(10).ToString().Trim & "'" '
                                Else
                                    strSQL &= ",NULL"
                                End If

                                strSQL &= ",'" & row(11).ToString().Trim & "'" '
                                strSQL &= ",'" & row(12).ToString().Trim & "'" '
                                strSQL &= ",'" & row(13).ToString().Trim & "'" '
                                strSQL &= ",'" & row(14).ToString().Trim & "'" '

                                strSQL &= ",'" & row(15).ToString().Trim & "'" '
                                strSQL &= ",'" & row(16).ToString().Trim & "'" '
                                strSQL &= ",now()"
                                strSQL &= ",now()"
                                strSQL &= ",nextval('" & schema & "sequriage')"
                                'strSQL &= ",'" & row(17).ToString().Trim & "'" '
                                strSQL &= ",'CR'"
                                strSQL &= ",'" & row(1).ToString().Trim & "'" '
                                strSQL &= ",''" '
                                strSQL &= ",'" & "ＥＣグッズ＿送料" & "'"     '備考漢字　13, 
                                strSQL &= ")"
                                '======2022/06/16


                                If ClassPostgeDB.EXEC(strSQL) = False Then
                                    '  sw.Write("ERROR")
                                End If
                            End If
                            If EC_DENSOU = "1" Then

                                '//雑貨へ更新
                                '//ECサイトへ出庫を入れるなら
                                strSQL = "SELECT genka FROM " & schema2 & "m_seihin WHERE sinacd='" & row(2).ToString().Trim & "'"
                                'Label原価単価 = ClassPostgeDB2.DbSel(strSQL)
                                Label原価単価 = "0"
                                DateTimePicker処理日 = entryTime.ToString("yyyy/MM/dd")
                                TextBox備考 = ""

                                strSQL = ""
                                strSQL &= "INSERT INTO " & schema2 & "t_zaiko(sinacd,syoriday,denpyouno,"
                                strSQL &= "                          insu,outsu,genkakin,genkatanka,"
                                strSQL &= "                          update_day,entry_day,entry_sya,"
                                strSQL &= "                          seq,bikou,keihiflg) "
                                strSQL &= "VALUES('" & row(2).ToString().Trim & "','" & DateTime.Parse(DateTimePicker処理日) & "','" & row(1).ToString() & "',"
                                strSQL &= "       0," & row(3).ToString().Trim & "," & Decimal.Parse(row(3).ToString().Trim) * Decimal.Parse(Label原価単価) & "," & Label原価単価 & ","
                                strSQL &= "       '" & entryTime & "','" & entryTime & "','" & Me.UserName & "',"
                                strSQL &= "      nextval('" & schema2 & "seqzaiko'),'" & TextBox備考 & "',0)"
                                '//// ECサイト出庫更新
                                '//ClassPostgeDB2.EXEC(strSQL)
                                '///
                                '/////
                                '///// EC処理
                            End If
                        End If
                    Else

                        '///// パーツ処理
                        'フィールドの取得
                        sw.Write("""1""")
                            sw.Write(",""""")
                            sw.Write(",""CR""")
                            sw.Write(",""" & row(5).ToString() & """")          '倉庫
                            sw.Write(",""2""")                                  '運賃区分
                            sw.Write(",""" & row(0).ToString() & """")          '得意先CD
                            sw.Write(",""""")                                   '得意先記事
                            sw.Write(",""""")                                   '２次店
                            sw.Write(",""""")                                   '３次店
                            sw.Write(",""" & row(19).ToString() & """")         ' 送り先名
                            sw.Write(",""" & row(6).ToString() & """")          ' 発注NO
                            sw.Write(",""ＷＥＢ""")                             ' 発注者漢字
                            sw.Write(",""""")                                   ' 発注者カナ
                            sw.Write(",""" & StrConv(row(18).ToString(), VbStrConv.Wide) & "ＷＥＢ出荷" & """")      '備考漢字　13, 
                            sw.Write(",""" & row(1).ToString() & """")          ' 備考カナ　14
                            sw.Write(",""""")                           '負担部門 15
                            sw.Write(",""""")                           '資金予算NO 16
                            sw.Write(",""""")                           '勘定科目 17
                            sw.Write(",""""")                           '固定資産管理NO 18
                            sw.Write(",""""")      '荷受人ＣＤ 19
                            sw.Write(",""" & row(2).ToString() & """")      ' 品コード 20
                            sw.Write(",""" & row(3).ToString() & """")      ' 数量
                            sw.Write(",""" & row(4).ToString() & """")      ' 単価
                            sw.Write(",""""")      '売価率
                            sw.Write(",""""")      '枝番
                            sw.Write(",""""")      '明細発注NO
                            sw.Write(",""""")      '農協価格
                            sw.Write(",""""")      '農協価格率
                            sw.Write(vbCrLf)        '改行


                            strSQL = "INSERT INTO " & schema & "t_uriage(sinacd, route_cd,cst_cd,ord_psn_nm,qty,upri,intr_rmrks"
                            strSQL &= ", kessaihouhou,syorikubun,nyukinn,nyukinkakuninbi,goukei"
                            strSQL &= ", coupon_waribiki , tesuuryou , seikyukingaku , coupon_cd , syouryou"

                            strSQL &= ", entry_day, update_day,seq,ship_wh_cd,cst_po_no,ord_psn_nm1,slip_rmrks"
                            strSQL &= ")VALUES("
                            'strSQL &= " '" & row(6).ToString().Trim & "'" ' seq
                            strSQL &= "'" & row(2).ToString().Trim & "'" '品コード
                            strSQL &= ",'" & row(5).ToString().Trim & "'" '倉庫
                            strSQL &= ",'" & row(0).ToString().Trim & "'" '得意先CD
                            strSQL &= ",'WEB'" '" '
                            strSQL &= ",'" & row(3).ToString().Trim & "'" '数量
                            strSQL &= ",'" & row(4).ToString().Trim & "'" '単価　値引き
                            strSQL &= ",'" & row(1).ToString().Trim & "'" '備考カナ

                            strSQL &= ",'" & row(7).ToString().Trim & "'" '
                            strSQL &= ",'" & row(8).ToString().Trim & "'" '
                            strSQL &= ",'" & row(9).ToString().Trim & "'" '

                            If IsDate(row(10).ToString().Trim, "yyyy/MM/dd") = True Then
                                strSQL &= ",'" & row(10).ToString().Trim & "'" '
                            Else
                                strSQL &= ",NULL"
                            End If

                            strSQL &= ",'" & row(11).ToString().Trim & "'" '
                            strSQL &= ",'" & row(12).ToString().Trim & "'" '
                            strSQL &= ",'" & row(13).ToString().Trim & "'" '
                            strSQL &= ",'" & row(14).ToString().Trim & "'" '

                            strSQL &= ",'" & row(15).ToString().Trim & "'" '
                            strSQL &= ",'" & row(16).ToString().Trim & "'" '
                            strSQL &= ",now()"
                            strSQL &= ",now()"
                            strSQL &= ",nextval('" & schema & "sequriage')"
                            'strSQL &= ",'" & row(17).ToString().Trim & "'" '
                            strSQL &= ",'CR'"
                            strSQL &= ",'" & row(6).ToString().Trim & "'" '
                            strSQL &= ",''" '
                            strSQL &= ",'" & StrConv(row(18).ToString(), VbStrConv.Wide) & "ＷＥＢ出荷" & "'"     '備考漢字　13, 
                            strSQL &= ")"


                            If ClassPostgeDB.EXEC(strSQL) = False Then
                                '  sw.Write("ERROR")
                            End If
                            '///// パーツ処理

                        End If

                        '/////
                        strSQL = "UPDATE " & schema & "t_order set flg='1' where  seq = '" & row(17).ToString() & "'"
                    ClassPostgeDB.EXEC(strSQL)

                    ro = ro + 1

                    Me.Label出荷出力.Text = ro & "件　出力"
                    System.Windows.Forms.Application.DoEvents()

                Next

                '閉じる
                sw.Close()

                MessageBox.Show(ro & "件　出力しました")

            Catch ex As Exception
                sw.Close()
                MessageBox.Show(ro & "件目でエラーです")
            End Try

        End If
    End Sub

    '
    '
    '
    '
    Private Sub Button検索２_Click(sender As Object, e As EventArgs) Handles Button検索２.Click
        GetIniFile()
        Me.TextBoxFileName2.Text = Filesentaku(NextBFolder)
        NextBFolder = Me.TextBoxFileName2.Text

    End Sub

    Private Sub ButtonオーダーNo取り込み_Click(sender As Object, e As EventArgs) Handles ButtonオーダーNo取り込み.Click
        Dim ClassPostgeDB2 = New ClassPostgeDB2()
        Dim ro As Int16
        Dim strSQL As String

        Dim sinacd As String
        Dim ord_no As String
        Dim FileFlg As Boolean
        Dim w原価単価 As String

        Dim entryTime As DateTime = DateTime.Now

        If Me.TextBoxFileName2.Text <> "" Then
            Using parser As New TextFieldParser(Me.TextBoxFileName2.Text, Encoding.GetEncoding("Shift_JIS"))
                ' カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",")
                ' フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
                ' フィールドの空白トリム設定
                parser.TrimWhiteSpace = False
                ' ファイルの終端までループ
                ro = 0
                While Not parser.EndOfData
                    ' フィールドを読込
                    Dim row As String() = parser.ReadFields()

                    If ro = 0 Then
                        'ファイルチェック
                        Try

                            FileFlg = True
                            If row.Length <> 37 Then FileFlg = FileFlg
                            If row(0).ToString <> "proc_grp_no" Then FileFlg = FileFlg
                            If row(1).ToString <> "sts_typ_nm" Then FileFlg = FileFlg
                            If row(36).ToString <> "ja_upri_rate" Then FileFlg = FileFlg

                            If FileFlg = False Then
                                MessageBox.Show("ファイルが違います")
                                Return
                            End If

                        Catch ex As Exception
                            MessageBox.Show("ファイルが違います")
                            Return
                        End Try
                    ElseIf ro > 1 Then
                        ord_no = row(2).ToString

                        sinacd = row(27).ToString
                        intr_rmrks = row(21).ToString
                        cst_po_no = row(17).ToString

                        slip_rmrks = row(20).ToString
                        qty = row(29).ToString


                        '====================================================================
                        'sls_typ = row(1).ToString
                        'xpns_cd = row(4).ToString
                        'ship_wh_cd = row(5).ToString
                        'route_cd = row(6).ToString
                        'fare_typ = row(7).ToString
                        'cst_cd = row(9).ToString
                        'cst_note = row(11).ToString
                        'scnd_dler_ten = row(13).ToString
                        'thrd_dler_ten = row(14).ToString
                        'scst_nm = row(16).ToString
                        'cst_po_no = row(17).ToString
                        'ord_psn_nm = row(18).ToString
                        'ord_psn_nm1 = row(19).ToString
                        'slip_rmrks = row(20).ToString
                        'chrg_dpt_cd = row(22).ToString
                        'bf_no = row(23).ToString
                        'ac_cd = row(24).ToString
                        'fa_no = row(25).ToString
                        'zn_rcv_psn_cd = row(26).ToString
                        'qty = row(29).ToString
                        'upri = row(30).ToString
                        'rate = row(31).ToString
                        'cst_dsnt_subno = row(33).ToString
                        'ja_inst_no = row(34).ToString
                        'ja_upri = row(35).ToString
                        'ja_upri_rate = row(36).ToString
                        'sts_typ_nm = row(1).ToString


                        '====================================================================
                        strSQL = "UPDATE " & schema & "t_uriage SET"
                        strSQL &= " ord_no = '" & ord_no & "'"
                        strSQL &= " WHERE sinacd = '" & sinacd & "'"

                        If intr_rmrks <> "" Then
                            strSQL &= " AND  intr_rmrks = '" & intr_rmrks & "'"
                        Else
                            strSQL &= " AND  cst_po_no = '" & cst_po_no & "'"

                        End If

                        strSQL &= " AND (ord_no is null or ord_no='')"

                        ClassPostgeDB.EXEC(strSQL)

                        '//雑貨へ更新
                        '// 伝票番号にNEXT-Bの得伝票番号
                        '// 備考にエビス受注番号
                        '// NEXTB出力時を止める事
                        If intr_rmrks = "" And slip_rmrks = "ＥＣグッズ" Then
                            If EC_DENSOU = "1" Then

                                '//ECサイトへ出庫を入れるなら
                                strSQL = "SELECT genka FROM " & schema2 & "m_seihin WHERE sinacd='" & sinacd & "'"
                                w原価単価 = ClassPostgeDB2.DbSel(strSQL)

                                strSQL = ""
                                strSQL &= "INSERT INTO " & schema2 & "t_zaiko(sinacd,syoriday,denpyouno,"
                                strSQL &= " insu,outsu,genkakin,genkatanka,"
                                strSQL &= " update_day,entry_day,entry_sya,"
                                strSQL &= " seq,bikou,keihiflg)"
                                strSQL &= "VALUES('" & sinacd & "','" & entryTime.ToString("yyyy/MM/dd") & "','" & ord_no & "'"
                                strSQL &= ",0," & qty & "," & Decimal.Parse(qty) * Decimal.Parse(w原価単価) & "," & w原価単価 & ","
                                strSQL &= " now(),now(),'" & Me.UserName & "',"
                                strSQL &= " nextval('" & schema2 & "seqzaiko'),'" & cst_po_no & "',0)"

                                '//// ECサイト出庫更新
                                ClassPostgeDB2.EXEC(strSQL)
                                '///

                            End If
                        End If
                    End If

                    ro = ro + 1
                    Me.Labelオーダー取り込み.Text = (ro - 2).ToString & "件　取り込み"
                    System.Windows.Forms.Application.DoEvents()

                End While
                Me.Labelオーダー取り込み.Text = (ro - 2).ToString & "件　取り込み完了"
                System.Windows.Forms.Application.DoEvents()
                MessageBox.Show((ro - 2).ToString & "件　取り込み完了しました")

            End Using
        End If
    End Sub
    Private Sub SouryouZeo()
        Dim strSQL As String
        'strSQL = ""
        'strSQL &= "update " & schema & "t_order "
        'strSQL &= " set souryou ='0'"
        'strSQL &= " where (jyutyucd) in"
        'strSQL &= " ("
        'strSQL &= " select t.jyutyucd"              '--,max(t.order_d_no)
        'strSQL &= " from  " & schema & "t_order t"
        'strSQL &= " where t.free_item31 <> '2'"
        'strSQL &= " and   t.flg  ='0'"
        'strSQL &= " and   t.souryou  > '0'"
        'strSQL &= " group by t.jyutyucd "
        'strSQL &= " having count(*) > 1 "
        'strSQL &= " )"
        'strSQL &= " and order_d_no <> '1'"
        'strSQL &= " and flg  = '0'"

        ' SHOPが２でない店で販売があればSHOP１の送料を０円にする
        strSQL = ""
        strSQL &= "Update " & schema & "t_order set souryou ='0' "
        strSQL &= " where ( jyutyucd ) in "
        strSQL &= " ( select t.jyutyucd from " & schema & "t_order t where t.free_item31 <> '2' and  t.flg  ='0' group by t.jyutyucd ) "
        strSQL &= " And flg  = '0'"
        strSQL &= " And free_item31 ='2'"
        ClassPostgeDB.EXEC(strSQL)


    End Sub

    Private Sub TextBoxFileName1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFileName1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub FormNext_B_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.StartPosition = FormStartPosition.CenterScreen

    End Sub

    Private Sub FormNext_B_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "6") Then

        End If

    End Sub
End Class