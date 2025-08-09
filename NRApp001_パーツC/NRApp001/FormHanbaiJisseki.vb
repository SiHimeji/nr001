Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class FormHanbaiJisseki
    Dim ClassPostgeDB As New ClassPostgeDB
    Dim _UserID As String = String.Empty
    Dim _UserName As String = String.Empty
    Dim _Kengen As String = String.Empty
    Dim ErrSyoriKaistyy As Integer = 0
    Dim SyoriFlg As Boolean
    Dim CsvFormat As String = String.Empty

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
    Private Sub FormHanbaiJisseki_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        'Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.DataGridView1.RowHeadersVisible = False

        ErrSyoriKaistyy = 0

    End Sub

    Private Sub Button検索_Click(sender As Object, e As EventArgs) Handles Button検索.Click
        GetIniFile()
        Me.TextBoxFileName.Text = Filesentaku(OrderFolder)
        OrderFolder = Me.TextBoxFileName.Text
        Me.DataGridView1.Rows.Clear()
        Me.ListBox1.Items.Clear()

    End Sub

    Private Sub 終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 終了ToolStripMenuItem.Click

        If SyoriFlg Then
            MessageBox.Show("確定処理が実行されていません")
        Else
            Me.Close()
        End If

    End Sub
    '
    '
    '販売実績を加算
    '
    Public Sub SetJiseki(sinacd As String, kosuu As String)
        Dim strSQL As String
        Dim ret As String
        Dim moto As Integer
        Dim kousin As Integer


        strSQL = "SELECT jyutyuu FROM " & schema & "t_genzaiko where sinacd = '" & sinacd & "'"

        ret = ClassPostgeDB.DbSel(strSQL)

        If ret = "" Then
            strSQL = "INSERT INTO " & schema & "t_genzaiko (sinacd, genzaiko, tyuuzan, entry_day, entry_sya, jyutyuu) VALUES('" & sinacd & "', 0, 0, now(), '" & UserName & "', " & kosuu & ")"

        Else

            moto = Integer.Parse(ret)

            kousin = Integer.Parse(kosuu)

            moto = moto + kousin

            strSQL = "UPDATE " & schema & "t_genzaiko SET  entry_day = now(), entry_sya = '" & UserName & "', jyutyuu = '" & moto.ToString & "' WHERE sinacd='" & sinacd & "'"

        End If

        ClassPostgeDB.EXEC(strSQL)
    End Sub

    Private Function 販売CSV取り込み() As Boolean

        Dim strSQL As String
        Dim rw As Int16
        Dim fileFlg As Boolean


        Me.LabelMSG.Text = "取り込み開始"
        System.Windows.Forms.Application.DoEvents()

        Using parser As New TextFieldParser(Me.TextBoxFileName.Text,
                                               Encoding.GetEncoding("Shift_JIS"))

            ' カンマ区切りの指定
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",")

            ' フィールドが引用符で囲まれているか
            parser.HasFieldsEnclosedInQuotes = True
            ' フィールドの空白トリム設定
            parser.TrimWhiteSpace = False

            ' ファイルの終端までループ
            strSQL = "DELETE FROM " & schema & "t_hanbai"
            ClassPostgeDB.EXEC(strSQL)
            strSQL = "DELETE FROM " & schema & "t_hanbai_err"
            ClassPostgeDB.EXEC(strSQL)

            rw = 0
            While Not parser.EndOfData
                ' フィールドを読込
                Dim row As String() = parser.ReadFields()
                If rw = 0 Then
                    fileFlg = True
                    Try
                        If row.Length = 25 Then
                            CsvFormat = "25"
                            If row(1).IndexOf("受注番号") < 0 Then fileFlg = False
                            If row(2).IndexOf("受注明細") < 0 Then fileFlg = False
                            If row(3).IndexOf("商品") < 0 Then fileFlg = False
                            If row(5).IndexOf("受注明細") < 0 Then fileFlg = False
                            If row(8).IndexOf("請求合計金額") < 0 Then fileFlg = False
                            If row(12).IndexOf("クーポン割引額") < 0 Then fileFlg = False
                            If row(24).IndexOf("宅配伝票番号") < 0 Then fileFlg = False
                        ElseIf row.Length = 28 Then
                            CsvFormat = "28"
                            If row(1).IndexOf("受注番号") < 0 Then fileFlg = False
                            If row(2).IndexOf("受注明細") < 0 Then fileFlg = False
                            If row(3).IndexOf("商品") < 0 Then fileFlg = False
                            If row(5).IndexOf("受注明細") < 0 Then fileFlg = False
                            If row(8).IndexOf("請求合計金額") < 0 Then fileFlg = False
                            If row(12).IndexOf("クーポン割引額") < 0 Then fileFlg = False
                            If row(24).IndexOf("宅配伝票番号") < 0 Then fileFlg = False

                            If row(25).IndexOf("まとめ買い割引コード") < 0 Then fileFlg = False
                            If row(26).IndexOf("まとめ買い割引名") < 0 Then fileFlg = False
                            If row(27).IndexOf("まとめ買い割引額") < 0 Then fileFlg = False
                        Else
                            fileFlg = False
                        End If
                    Catch ex As Exception
                        MessageBox.Show("ファイルが違います")
                        Return False
                    End Try

                    If fileFlg = False Then
                        MessageBox.Show("ファイルが違います")
                        Return False

                    End If
                Else

                    strSQL = "INSERT INTO " & schema & "t_hanbai(torihiki_id, order_disp_no, order_d_no, free_item31, item_cd, item_name, quantity"
                    strSQL &= ",order_date, seikyu, syokei, teika_sum, teika, coupon_waribiki, coupon_name, coupon_cd, soryo, daibiki, kessai_id, payment_date"
                    strSQL &= ",l_name, f_name, send_addr1, send_addr2, send_addr3, ship_slip_no,seq"
                    If CsvFormat = "28" Then
                        strSQL &= ",sale_cd ,sale_name,waribiki "
                    End If

                    strSQL &= ")VALUES("
                    strSQL &= "'" & row(0) & "',"
                    strSQL &= "'" & row(1) & "',"
                    strSQL &= "'" & row(2) & "',"
                    strSQL &= "'" & row(3) & "',"
                    strSQL &= "'" & row(4) & "',"
                    strSQL &= "'" & row(5) & "',"
                    strSQL &= "'" & row(6) & "',"
                    strSQL &= "'" & row(7) & "',"
                    strSQL &= "'" & row(8) & "',"
                    strSQL &= "'" & row(9) & "',"
                    strSQL &= "'" & row(10) & "',"
                    strSQL &= "'" & row(11) & "',"
                    strSQL &= "'" & row(12) & "',"
                    strSQL &= "'" & row(13) & "',"
                    strSQL &= "'" & row(14) & "',"
                    strSQL &= "'" & row(15) & "',"
                    strSQL &= "'" & row(16) & "',"
                    strSQL &= "'" & row(17) & "',"
                    strSQL &= "'" & row(18) & "',"
                    strSQL &= "'" & row(19) & "',"
                    strSQL &= "'" & row(20) & "',"
                    strSQL &= "'" & row(21) & "',"
                    strSQL &= "'" & row(22) & "',"
                    strSQL &= "'" & row(23) & "',"
                    strSQL &= "'" & row(24) & "',"
                    strSQL &= "'" & rw.ToString() & "'"       'SEQ '2021/09/19
                    If CsvFormat = "28" Then
                        strSQL &= ",'" & row(25) & "',"
                        strSQL &= "'" & row(26) & "',"
                        strSQL &= "'" & row(27) & "'"
                    End If
                    strSQL &= ")"

                    ClassPostgeDB.EXEC(strSQL)

                End If
                rw = rw + 1
            End While
            parser.Close()

            Return True
        End Using
        Return False

    End Function



    Private Sub Button取込み_Click(sender As Object, e As EventArgs) Handles Button取込み.Click

        Me.DataGridView1.Rows.Clear()
        Me.DataGridView2.Rows.Clear()
        SyoriFlg = True
        Me.Button確定.BackColor = Color.Red


        If Me.TextBoxFileName.Text <> "" Then
            SetIniFile()
            Me.ListBox1.Items.Clear()
            If 販売CSV取り込み() Then
                取込み処理()
            End If
        End If
    End Sub
    '----------------------------------------------------------------------
    'クーポンチェック
    '2021/09/30
    '----------------------------------------------------------------------
    Private Function chkCoopon(order_disp_no As String) As Boolean
        Dim strSQL As String
        Dim dt As DataTable

        strSQL = "select th.coupon_cd"
        strSQL &= " from " & schema & "t_hanbai th "
        strSQL &= " where th.coupon_cd <> ''"
        strSQL &= " and th.order_disp_no ='" & order_disp_no & "'"
        strSQL &= " group by th.coupon_cd"
        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count = 1 Then Return True
        Return False

    End Function
    '----------------------------------------------------------------------
    'まとめ購入の値引き
    '2022/09/20
    '----------------------------------------------------------------------
    Private Function GetMatomeKazu(order As String, sinacd As String, sals_cd As String) As Integer
        Dim strSQL As String
        Dim dt As New DataTable

        strSQL = ""
        strSQL &= "select mmc.matomecd ,  sum( cast( th.quantity as numeric(10) ))"
        strSQL &= " from " & schema & "t_hanbai th , " & schema & "m_matomewari_cd mmc "
        strSQL &= " where th.item_cd  = mmc.sinacd "
        strSQL &= " and th.order_disp_no  = '" & order & "'"
        strSQL &= " and  mmc.matomecd  in (select mmc2.matomecd  from " & schema & "m_matomewari_cd mmc2 where mmc2.sinacd = '" & sinacd & "' and mmc2.matomeno = '" & sals_cd & "')"

        strSQL &= "group by mmc.matomecd "

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Return Integer.Parse(row(1).ToString())
            Next

        Else
            Return 0
        End If
        Return 0
    End Function




    '----------------------------------------------------------------------
    'まとめ購入の値引き
    '2022/09/20
    '----------------------------------------------------------------------
    Private Function GetMatomeWari(itemcd As String, kazu As String, tanka As String, sals_cd As String)
        Dim strSQL As String
        Dim dt As New DataTable
        Dim Rtabka As String = "0"

        strSQL = "select a.sinacd , b.*"
        strSQL &= " From " & schema & "m_matomewari_cd a, " & schema & "m_matomewari_seq b"
        strSQL &= " where a.matomecd  = b.matomecd "
        strSQL &= " and a.sinacd  = '" & itemcd & "'"
        strSQL &= " and a.matomeno ='" & sals_cd & "'"
        strSQL &= " and b.syurui <> '' "
        strSQL &= " order by b.kazu ,b.syurui  desc"

        dt = ClassPostgeDB.SetTable(strSQL)

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If row("syurui").ToString() = "個" Then
                    If row("kazu").ToString() = kazu Then
                        If row("tani").ToString() = "％" Then
                            Rtabka = Math.Round(Integer.Parse(tanka) - (Integer.Parse(tanka) * Integer.Parse(row("waribiki").ToString())) / 100).ToString
                        Else
                            Rtabka = Math.Round(Integer.Parse(tanka) - Integer.Parse(row("waribiki").ToString())).ToString
                        End If
                        'Exit For
                    End If
                Else
                    If Integer.Parse(row("kazu").ToString()) <= Integer.Parse(kazu) Then
                        If row("tani").ToString() = "％" Then
                            Rtabka = Math.Round(Integer.Parse(tanka) - (Integer.Parse(tanka) * Integer.Parse(row("waribiki").ToString())) / 100).ToString
                        Else
                            Rtabka = Math.Round(Integer.Parse(tanka) - Integer.Parse(row("waribiki").ToString())).ToString
                        End If
                    End If
                End If
            Next
        Else
            tanka = "0"
            Me.ListBox1.Items.Add("【" & itemcd & "】台数割引マスタに存在しません。単価を0円にします")

        End If

        Return Rtabka
    End Function


    '----------------------------------------------------------------------
    '総計　単価　クーポン計算
    '2021/09/19
    '----------------------------------------------------------------------
    Private Function CalcTankla() As Boolean
        Dim strSQL As String
        Dim dt1 As DataTable
        Dim dt2 As DataTable

        Dim coupon_cd As String
        Dim tyumonbi As String
        Dim order_disp_no As String
        Dim syouhizei As String

        Dim tanka As String
        Dim soukei As String
        Dim goukei As String
        Dim seq As String
        Dim nebikitanka_d As Double
        Dim nebikitanka As String

        Dim sinacd As String
        Dim off As String
        Dim teikasum As String
        Dim nebikisum As String
        Dim nebikiritu As Double

        Dim sale_Cd As String
        Dim item_cd As String
        Dim quantity As String
        Dim kazusum As Integer


        '送料と手数料をマイナス
        strSQL = "Update " & schema & "t_hanbai set soukei = cast(seikyu as numeric) -cast(soryo as numeric)-cast(daibiki as numeric)"
        ClassPostgeDB.EXEC(strSQL)
        '単価計算 消費税をマイナス 
        syouhizei = GetTax()
        'strSQL = "Update " & schema & "t_hanbai set tanka = round(cast(teika as numeric) -(cast(teika as numeric) / ((" & syouhizei & "+100)/10) ),0) where teika_sum = soukei"
        strSQL = "Update " & schema & "t_hanbai set tanka = round(((cast(teika As numeric) * 100) / (" & syouhizei & " + 100)), 0) where teika_sum = soukei"

        ClassPostgeDB.EXEC(strSQL)

        '定価合計 != 総計の　値引き処理
        strSQL = ""
        strSQL &= "select t.order_disp_no ,t.coupon_cd ,t.order_date, t.sale_cd "
        strSQL &= " From " & schema & "t_hanbai t "
        strSQL &= " where t.tanka is null  "
        strSQL &= " and (t.coupon_cd <>'')"
        strSQL &= " union "
        strSQL &= " select th.order_disp_no ,th.coupon_cd ,th.order_date, th.sale_cd "
        strSQL &= " From " & schema & "t_hanbai th  "
        strSQL &= " where th.tanka is null  "
        strSQL &= " and (th.sale_cd is null or  th.sale_cd <>'')"
        strSQL &= " group by coupon_cd,order_date, sale_cd ,order_disp_no"
        strSQL &= " order by coupon_cd desc,sale_cd  ,order_disp_no "

        dt1 = ClassPostgeDB.SetTable(strSQL)

        For Each row As DataRow In dt1.Rows

            Try
                order_disp_no = row(0).ToString     '
                coupon_cd = row(1).ToString         'クーポン番号
                tyumonbi = row(2).ToString          '注文日
                sale_Cd = row(3).ToString          'まとめ買いセールコード


                If sale_Cd <> "" And CsvFormat = "28" Then
                    '---------------まとめ買い------------------------------->>
                    strSQL = "Select th.teika ,th.soukei ,th.teika_sum ,th.seq , th.item_cd , th.sale_cd , th.quantity"
                    strSQL &= " From " & schema & "t_hanbai th  "
                    strSQL &= " Where th.tanka Is null"
                    strSQL &= " And th.order_disp_no ='" & order_disp_no & "'"
                    dt2 = ClassPostgeDB.SetTable(strSQL)
                    For Each row2 As DataRow In dt2.Rows
                        tanka = row2(0).ToString
                        soukei = row2(1).ToString
                        goukei = row2(2).ToString
                        seq = row2(3).ToString
                        item_cd = row2(4).ToString          '品コード
                        sale_Cd = row2(5).ToString          'まとめ買いセールコード
                        quantity = row2(6).ToString         '個数 
                        If sale_Cd = "" Then
                            '対象でない品コード
                            '消費税を外す
                            tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()

                            strSQL = "update " & schema & "t_hanbai  set tanka ='" & tanka & "' where seq ='" & seq & "'"
                            ClassPostgeDB.EXEC(strSQL)
                        Else


                            '割引対象の行
                            '消費税を外す
                            tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                            'マスタから割引をする
                            kazusum = GetMatomeKazu(order_disp_no, item_cd, sale_Cd)

                            tanka = GetMatomeWari(item_cd, kazusum.ToString, tanka, sale_Cd)

                            strSQL = "update " & schema & "t_hanbai  set tanka ='" & tanka & "' where seq ='" & seq & "'"
                            ClassPostgeDB.EXEC(strSQL)

                        End If
                    Next
                    '<<---------------まとめ買い-------------------------------
                Else
                    '---------------従来のクーポン------------------------------->>
                    If chkCoopon(order_disp_no) = False Then
                        MessageBox.Show("【" & order_disp_no & "】でクーポン重複です")
                        Return False
                    End If

                    If GetCoopon1(coupon_cd, tyumonbi) = "" Then
                        'クーポンない： 定価合計 と 総計の差　から割引率計算
                        strSQL = "Select th.teika ,th.soukei ,th.teika_sum ,th.seq "
                        strSQL &= " From " & schema & "t_hanbai th  "
                        strSQL &= " Where th.tanka Is null"
                        strSQL &= " And th.order_disp_no ='" & order_disp_no & "'"
                        dt2 = ClassPostgeDB.SetTable(strSQL)
                        For Each row2 As DataRow In dt2.Rows

                            tanka = row2(0).ToString
                            soukei = row2(1).ToString
                            goukei = row2(2).ToString
                            seq = row2(3).ToString

                            soukei = Math.Round((Integer.Parse(soukei) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                            goukei = Math.Round((Integer.Parse(goukei) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                            tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()

                            nebikitanka_d = (soukei / Integer.Parse(goukei)) * Integer.Parse(tanka)
                            tanka = Math.Round(nebikitanka_d, MidpointRounding.AwayFromZero).ToString() '四捨五入

                            strSQL = "update " & schema & "t_hanbai  set tanka ='" & tanka & "' where seq ='" & seq & "'"

                            ClassPostgeDB.EXEC(strSQL)
                        Next

                    Else 'クーポンあり
                        '値引き％　又は　金額
                        '2022/07/06 Add
                        tyumonbi = tyumonbi.Substring(0, 10)
                        '======
                        strSQL = "select offkin From " & schema & "m_coupon"
                        strSQL &= " where couponno = '" & coupon_cd & "'"
                        strSQL &= " and  offkin > '0'"
                        strSQL &= " and  kikanfrom  <='" & DateTime.Parse(tyumonbi) & "'"
                        strSQL &= " and  kikanto    >='" & DateTime.Parse(tyumonbi) & "'"

                        off = ClassPostgeDB.DbSel(strSQL)

                        If off = "" Then
                            '%値引き
                            strSQL = "Select th.teika ,th.item_cd ,th.seq "
                            strSQL &= " From " & schema & "t_hanbai th  "
                            strSQL &= " Where th.tanka Is null"
                            strSQL &= " And th.order_disp_no ='" & order_disp_no & "'"
                            strSQL &= " And th.coupon_cd ='" & coupon_cd & "'"

                            dt2 = ClassPostgeDB.SetTable(strSQL)
                            For Each row3 As DataRow In dt2.Rows

                                tanka = row3(0).ToString
                                sinacd = row3(1).ToString
                                seq = row3(2).ToString

                                strSQL = "select coalesce(offpar,'0') From " & schema & "m_coupon"
                                strSQL &= " where couponno = '" & coupon_cd & "'"
                                strSQL &= " and offkin = '0'"
                                strSQL &= " and sinacd = '" & sinacd & "'"
                                strSQL &= " and kikanfrom  <='" & DateTime.Parse(tyumonbi) & "'"
                                strSQL &= " and kikanto    >='" & DateTime.Parse(tyumonbi) & "'"
                                off = ClassPostgeDB.DbSel(strSQL)
                                If off = "" Then off = "0"

                                tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                                nebikitanka = Math.Round((Integer.Parse(tanka) * Integer.Parse(off)) / 100).ToString()
                                tanka = Math.Round((Integer.Parse(tanka)) - Integer.Parse(nebikitanka)).ToString()

                                strSQL = "update " & schema & "t_hanbai  set tanka ='" & tanka & "' where seq ='" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                            Next
                        Else
                            '金額値引き
                            strSQL = "select sum(cast(th.teika as integer))"
                            strSQL &= " From " & schema & "t_hanbai th  "
                            strSQL &= " Where th.tanka Is null"
                            strSQL &= " And th.order_disp_no ='" & order_disp_no & "'"
                            strSQL &= " And th.coupon_cd ='" & coupon_cd & "'"
                            strSQL &= " And th.item_cd in (select sinacd from " & schema & "m_coupon where couponno = '" & coupon_cd & "')"
                            teikasum = ClassPostgeDB.DbSel(strSQL)
                            nebikisum = (Integer.Parse(teikasum) - Integer.Parse(off)).ToString
                            '値引き率 'off = 合計値引き金額
                            'nebikiritu = (Math.Round((Integer.Parse(nebikisum) / Integer.Parse(teikasum)), 2, MidpointRounding.AwayFromZero) * 100).ToString
                            nebikiritu = (Math.Round(((Integer.Parse(nebikisum) * 100) / (Integer.Parse(teikasum) * 100)), 4, MidpointRounding.AwayFromZero) * 10000).ToString

                            strSQL = "Select th.teika ,th.item_cd ,th.seq "
                            strSQL &= " From " & schema & "t_hanbai th  "
                            strSQL &= " Where th.tanka Is null"
                            strSQL &= " And th.order_disp_no ='" & order_disp_no & "'"
                            strSQL &= " And th.coupon_cd ='" & coupon_cd & "'"

                            dt2 = ClassPostgeDB.SetTable(strSQL)
                            For Each row4 As DataRow In dt2.Rows
                                tanka = row4(0).ToString
                                sinacd = row4(1).ToString
                                seq = row4(2).ToString
                                off = GetCoopon2(coupon_cd, tyumonbi, sinacd)
                                If off = "" Then
                                    tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                                    strSQL = "update " & schema & "t_hanbai  set tanka ='" & tanka & "' where seq ='" & seq & "'"
                                    ClassPostgeDB.EXEC(strSQL)
                                Else
                                    tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                                    'tanka = Math.Round(((Integer.Parse(tanka) * Integer.Parse(nebikiritu))) / 100).ToString()
                                    tanka = Math.Round(((Integer.Parse(tanka) * Integer.Parse(nebikiritu))) / 10000).ToString()
                                    'tanka = Math.Round((Integer.Parse(tanka)) - Integer.Parse(nebikitanka)).ToString()

                                    strSQL = "update " & schema & "t_hanbai  set tanka ='" & tanka & "' where seq ='" & seq & "'"
                                    ClassPostgeDB.EXEC(strSQL)
                                End If
                            Next
                        End If
                    End If
                    '---------------従来のクーポン------------------------------->>
                End If

            Catch ex As Exception
                MessageBox.Show("単価計算でエラー発生")
                Return False
            End Try
        Next
        Return True
    End Function

    '----------------------------------------------------------------------


    Private Sub 取込み処理()
        Dim dt As DateTime
        'Dim order_disp_no As String
        Dim jyutyucd As String
        Dim tyumonbi As String
        Dim sinacd As String
        Dim kosuu As String
        Dim teika As String
        Dim tanka As String
        Dim kessaihouhou As String
        Dim goukei As String
        Dim coupon_waribiki As String
        Dim tesuuryou As String
        Dim seikyukingaku As String
        Dim coupon_cd As String
        Dim syorikubun As String
        Dim nyukinn As String
        Dim nyukinkakuninbi As String
        Dim torikomibi As String
        Dim cst_cd As String
        Dim souryou As String
        Dim strSQL As String
        Dim rw As Int16
        Dim msg As String
        Dim syouhizei As String
        'Dim maxRowNum As Integer
        Dim ErrFlag As Boolean
        Dim order_d_no As String
        Dim shop As String
        Dim syoi As String

        Dim order_disp_no As New DataTable
        Dim order_disp As New DataTable
        Dim oderno As String
        'Dim i As Integer
        Dim seihinmei As String
        Dim order_tbale As String
        Dim seq As String
        Dim syukko As String
        Dim seqorder As String
        'Dim off As String
        'Dim nebikitanka As String
        'Dim nebikitanka_d As Double
        'Dim soukei As Integer
        'Dim tanka_d As Double

        If CalcTankla() = False Then
            MessageBox.Show("販売実績取り込み処理でエラーがありました")
            Return
        End If

        syouhizei = GetTax()


        '引き当てを先に抽出する-------------------------

        'strSQL = "Select Case t.sinacd ,th.item_name  ,th.quantity ,th.tanka ,th.soryo ,th.daibiki ,th.soukei ,th.order_disp_no,t.oderno ,t.renraku,t.seq "
        'strSQL &= " From " & schema & "t_m_zaiko t , " & schema & "t_hanbai th "
        'strSQL &= " Where t.syori_flg ='0'"
        'strSQL &= " And t.sinacd = th.item_cd"
        'strSQL &= " And   cast (t.zaikosuu as text ) = th.quantity "
        'strSQL &= " And   t.upri = th.tanka "


        '-----------------------------------------------
        strSQL = "SELECT  order_disp_no FROM " & schema & "t_hanbai GROUP BY order_disp_no"　'元CSVデータ
        order_disp_no = ClassPostgeDB.SetTable(strSQL)
        msg = ""

        rw = 1
        For Each r As DataRow In order_disp_no.Rows
            ' 送付先へ登録




            ' フィールドを読込
            strSQL = "SELECT torihiki_id, order_disp_no, order_d_no, free_item31, item_cd, item_name, quantity, order_date, seikyu, syokei"
            strSQL &= ", teika_sum, teika, coupon_waribiki, coupon_name, coupon_cd, soryo, daibiki, kessai_id, payment_date"
            strSQL &= ", l_name, f_name, send_addr1, send_addr2, send_addr3, ship_slip_no ,tanka"
            strSQL &= " From " & schema & "t_hanbai where order_disp_no = '" + r(0).ToString + "'  order by  order_d_no"
            jyutyucd = ""
            order_disp = ClassPostgeDB.SetTable(strSQL)
            For Each row As DataRow In order_disp.Rows
                ErrFlag = True
                order_d_no = ""
                jyutyucd = ""           '受注コード・備考カナ
                tyumonbi = ""           '注文日
                sinacd = ""             '品コード
                kosuu = ""              '数量・数量
                tanka = ""              '単価・単価
                teika = ""
                kessaihouhou = ""       '決裁方法
                goukei = ""             '合計
                coupon_waribiki = ""    '消費税→クーポン割引額
                tesuuryou = ""          '手数料
                seikyukingaku = ""      '請求金額
                coupon_cd = ""          'コンビニ番号→クーポン名
                syorikubun = ""         '処理区分→宅配伝票番号
                nyukinn = 0             'row(89).ToString  '入金
                nyukinkakuninbi = ""    'row(90).ToString  '入金日
                torikomibi = ""         '取り込み日
                souryou = 0           '送料
                shop = ""
                Try
                    shop = row(3).ToString
                    jyutyucd = row(1).ToString      '受注コード・備考カナ
                    order_d_no = row(2).ToString
                    tyumonbi = row(7).ToString      '注文日
                    sinacd = row(4).ToString        '品コード
                    kosuu = row(6).ToString         '数量・数量
                    teika = row(11).ToString        '単価・単価
                    kessaihouhou = row(17).ToString '決裁方法
                    goukei = row(10).ToString       '合計
                    coupon_waribiki = row(12).ToString  '消費税→クーポン割引額
                    tesuuryou = row(16).ToString        '手数料
                    seikyukingaku = row(8).ToString     '請求金額
                    coupon_cd = row(14).ToString        'コンビニ番号→クーポン名
                    syorikubun = row(24).ToString       '処理区分→宅配伝票番号
                    nyukinn = 0                         'row(89).ToString          '入金
                    nyukinkakuninbi = ""                 'row(90).ToString  '入金日
                    torikomibi = Now().ToString         '取り込み日
                    souryou = row(15).ToString          '送料

                    tanka = row(25).ToString        '単価・単価

                Catch ex As Exception
                    ErrFlag = False
                End Try

                '単価計算---------------------------------------------------------------------------------------
                'soukei = Integer.Parse(seikyukingaku) - Integer.Parse(tesuuryou) - Integer.Parse(souryou)
                ' If soukei.ToString <> goukei Then   '値引きあり

                '                    off = GetCoopon(coupon_cd, sinacd, tyumonbi)        '--クーポン有無チェック
                '
                '                    If off = "" Then
                '                        '2021/02/17　定価ー合計金額　からの差額から割引計算
                '                        soukei = Math.Round((Integer.Parse(soukei) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                '                        goukei = Math.Round((Integer.Parse(goukei) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                '                        tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                '
                '                        nebikitanka_d = (soukei / Integer.Parse(goukei)) * Integer.Parse(tanka)
                '
                '                        nebikitanka = Math.Round(nebikitanka_d, MidpointRounding.AwayFromZero).ToString() '四捨五入
                '
                '                        If IsDecimal(nebikitanka) Then
                '                            'MessageBox.Show("小数を含みます")
                '                            ErrFlag = False
                '                            msg = "受注番号:" & jyutyucd & " 明細番号:" & order_d_no & " の値引き単価エラー"
                '                            Me.ListBox1.Items.Add(msg)
                '                        Else
                '                            tanka = nebikitanka
                '                        End If
                '                    Else
                '                        '
                '                        '2021/09/09
                '                        '
                '                        If 0 <= off.IndexOf("%") Then
                '                            '"％文字列が含まれています" %を空白へ置換
                '                            '%割引計算
                '                            off = off.Replace("%", "")
                '                            tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                '                            nebikitanka = Math.Round((Integer.Parse(tanka) * Integer.Parse(off)) / 100).ToString()
                '                            tanka = Math.Round((Integer.Parse(tanka)) - Integer.Parse(nebikitanka)).ToString()
                '
                '                        Else
                '                            '値引き計算
                '                            tanka = Math.Round((Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100)).ToString()
                '
                '                            If Integer.Parse(tanka) > Integer.Parse(off) Then
                '                                tanka = Math.Round((Integer.Parse(tanka) - Integer.Parse(off))).ToString()
                '                            Else
                '                                tanka = "0.1"
                '                            End If
                '
                '                        End If
                '
                '                        If IsDecimal(tanka) Then
                '                            'MessageBox.Show("小数を含みます")
                '                            ErrFlag = False
                '                            msg = "受注番号:" & jyutyucd & " 明細番号:" & order_d_no & " の値引き単価エラー"
                '                            Me.ListBox1.Items.Add(msg)
                '                        End If
                '                    End If
                '                Else
                '                    '2021/02/17　定価のまま
                '                    tanka_d = (Integer.Parse(tanka) * 100) / (Integer.Parse(syouhizei) + 100).ToString()
                '                    tanka = Math.Round(tanka_d, MidpointRounding.AwayFromZero).ToString() '四捨五入　2021/03/16
                '
                '                    If IsDecimal(tanka) Then
                '                        'MessageBox.Show("小数を含みます")
                '                        ErrFlag = False
                '                        msg = "受注番号:" & jyutyucd & " 明細番号:" & order_d_no & " の単価エラー"
                '                        Me.ListBox1.Items.Add(msg)
                '                    End If
                '                End If
                '                '単価計算---------------------------------------------------------------------------------------
                '仮在庫チェック---------------------------------------------------------------------------------------

                strSQL = "SELECT seq FROM " & schema & "t_m_zaiko WHERE  sinacd = '" & sinacd & "' and zaikosuu = '" + kosuu + "' and syori_flg in('0')"
                strSQL &= " and upri = '" & tanka & "'"
                strSQL &= " LIMIT 1"
                'strSQL &= " and syouryou  = '" & souryou & "'"
                'strSQL &= " and tesuuryou = '" & tesuuryou & "'"
                'strSQL &= " and goukei    = '" & goukei & "'"

                seq = ClassPostgeDB.DbSel(strSQL) '仮在庫 SEQ

                '仮在庫チェック---------------------------------------------------------------------------------------

                syukko = ""
                strSQL = "select nextval( '" & schema & "seqorder')"
                seqorder = ClassPostgeDB.DbSel(strSQL) 'SEQ

                If seq <> "" Then '仮在庫あり

                    strSQL = "SELECT oderno FROM " & schema & "t_m_zaiko WHERE  seq = '" & seq & "'"
                    oderno = ClassPostgeDB.DbSel(strSQL) '仮在庫　オーダーNO

                    strSQL = "SELECT syukoflg  FROM " & schema & "t_m_zaiko WHERE  seq = '" & seq & "'"
                    syukko = ClassPostgeDB.DbSel(strSQL) '仮在庫　出庫フラグ

                    Select Case syukko
                        Case "出庫不要"
                            syukko = "引当しない(不)"
                        Case "出庫必要"
                            syukko = "引当しない(必)"
                    End Select



                    seihinmei = Get_syouhinmei(sinacd)

                    Me.DataGridView2.Rows.Add(syukko, sinacd, seihinmei, kosuu, teika, souryou, tesuuryou, goukei, jyutyucd, oderno, seq, seqorder)


                    strSQL = "UPDATE  " & schema & "t_m_zaiko SET syori_flg = '2' WHERE  seq = '" & seq & "' and syori_flg = '0'"
                    ClassPostgeDB.EXEC(strSQL)

                    '----------
                    order_tbale = "" & schema & "t_order_mz"
                    '----------
                Else

                    '----------
                    order_tbale = "" & schema & "t_order"
                    '----------
                End If

                '得意先コード----------------------------------------------------------------------
                strSQL = "select ms.tokuisakicd from " & schema & "m_seihin ms where ms.sinacd = '" & sinacd & "'"
                cst_cd = ClassPostgeDB.DbSel(strSQL) '得意先
                '得意先コード----------------------------------------------------------------------

                If cst_cd <> "" Then
                    Try

                        strSQL = "INSERT INTO " & order_tbale & "(jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, "
                        strSQL &= "seikyukingaku, coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, nebikitanka,torikomibi,cst_cd,seq,flg,entry_day,souryou,free_item31,order_d_no)VALUES("
                        strSQL &= "'" & jyutyucd & "'"

                        If DateTime.TryParse(tyumonbi, dt) Then
                            strSQL &= ",'" & tyumonbi & "'"
                        Else
                            strSQL &= ",NULL"
                        End If

                        strSQL &= ",'" & sinacd & "'"

                        If IsNumeric(kosuu) = True Then
                            strSQL &= ",'" & kosuu & "'"
                        Else
                            strSQL &= ",'0'"

                        End If

                        If IsNumeric(tanka) = True Then
                            strSQL &= ",'" & tanka & "'"
                        Else
                            strSQL &= ",'0'"
                            tanka = 0
                        End If

                        strSQL &= ",'" & kessaihouhou & "'"

                        If IsNumeric(goukei) = True Then
                            strSQL &= ",'" & goukei & "'"
                        Else
                            strSQL &= ",'0'"
                            goukei = 0

                        End If

                        If IsNumeric(coupon_waribiki) = True Then
                            strSQL &= ",'" & coupon_waribiki & "'"
                        Else
                            strSQL &= ",'0'"

                        End If

                        If IsNumeric(tesuuryou) = True Then
                            strSQL &= ",'" & tesuuryou & "'"
                        Else
                            strSQL &= ",'0'"

                        End If
                        If IsNumeric(seikyukingaku) = True Then
                            strSQL &= ",'" & seikyukingaku & "'"
                        Else
                            strSQL &= ",'0'"
                            seikyukingaku = 0
                        End If

                        strSQL &= ",'" & coupon_cd & "'"
                        strSQL &= ",'" & syorikubun & "'"
                        strSQL &= ",'" & nyukinn & "'"

                        If DateTime.TryParse(nyukinkakuninbi, dt) Then
                            strSQL &= ",'" & nyukinkakuninbi & "'"
                        Else
                            strSQL &= ",NULL"
                        End If
                        strSQL &= ",'" & tanka & "'"
                        strSQL &= ",'" & torikomibi & "'"
                        strSQL &= ",'" & cst_cd & "'"
                        strSQL &= "," & seqorder & ""                  'nextval( '" & schema & "seqorder')"
                        strSQL &= ",'0'"
                        strSQL &= ",now()"

                        If IsNumeric(souryou) = True Then
                            strSQL &= ",'" & souryou & "'"
                        Else
                            strSQL &= ",'0'"
                        End If
                        strSQL &= ",'" & shop & "'"
                        strSQL &= ",'" & order_d_no & "'"
                        strSQL &= ")"

                        If ErrFlag Then
                            ClassPostgeDB.EXEC(strSQL)
                            SetJiseki(sinacd, kosuu)

                            If order_tbale = "" & schema & "t_order_mz" And syukko = "出庫必用" Then
                                '002も作成する                                '
                                strSQL = "insert into " & schema & "t_order select * from " & schema & "t_order_mz where t_order_mz.seq =" & seqorder & ""
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "delete from " & schema & "t_order_mz where t_order_mz.seq =" & seqorder & ""
                                ClassPostgeDB.EXEC(strSQL)

                            End If
                        Else
                            ErrFlag = False
                        End If
                    Catch ex As Exception
                        ErrFlag = False
                        'MessageBox.Show("(" & jyutyucd & " - " & sinacd & " )で取り込みエラーです")
                    End Try
                Else
                    'errorを表示
                    ErrFlag = False
                    msg = "受注番号:" & jyutyucd & " 明細番号:" & order_d_no & " の品コード(得意先コード)エラー"
                    Me.ListBox1.Items.Add(msg)

                End If
                'End If

                rw = rw + 1
                Me.LabelMSG.Text = rw.ToString & "件　取り込み"
                System.Windows.Forms.Application.DoEvents()

                If ErrFlag = False Then
                    Exit For
                End If

            Next
            '2021/09/19
            If ErrFlag = False Then
                strSQL = "DELETE FROM " & schema & "t_order WHERE jyutyucd = '" & jyutyucd & "' and flg ='0'"
                ClassPostgeDB.EXEC(strSQL)
                strSQL = "insert into " & schema & "t_hanbai_err select torihiki_id, order_disp_no, order_d_no, free_item31"
                strSQL &= ", item_cd, item_name, quantity, order_date, seikyu, syokei, teika_sum, teika, coupon_waribiki, coupon_name"
                strSQL &= ", coupon_cd, soryo, daibiki, kessai_id, payment_date, l_name, f_name, send_addr1, send_addr2, send_addr3, ship_slip_no,soukei,tanka,seq"
                strSQL &= " from " & schema & "t_hanbai where order_disp_no = '" & jyutyucd & "'"
                ClassPostgeDB.EXEC(strSQL)

            End If
            order_disp.Clear()
        Next
        order_disp_no.Clear()

        strSQL = "SELECT '削除',torihiki_id, order_disp_no, order_d_no, free_item31, item_cd, item_name, quantity, order_date, seikyu, syokei, teika_sum, teika "
        strSQL &= ",coupon_waribiki, coupon_name, coupon_cd, soryo, daibiki, kessai_id, payment_date, l_name, f_name, send_addr1, send_addr2, send_addr3, ship_slip_no"
        strSQL &= ",soukei,tanka,seq"
        strSQL &= " From " & schema & "t_hanbai_ERR  order by order_disp_no , order_d_no"

        Me.DataGridView1.Rows.Clear()

        ClassPostgeDB.SetDataGredv(strSQL, Me.DataGridView1)

        '=============================

        strSQL = "SELECT count(*) from " & schema & "t_hanbai"
        syoi = ClassPostgeDB.DbSel(strSQL)
        rw = Integer.Parse(syoi) - (DataGridView1.Rows.Count - 1)

        Me.ListBox1.Items.Add(syoi & "件処理しました")
        Me.ListBox1.Items.Add(GetTorikomiKen() & "件取り込みできました")
        Me.ListBox1.Items.Add((DataGridView1.Rows.Count).ToString & "件取り込みできませんでした")

        MessageBox.Show("販売実績取り込み処理が完了しました")

    End Sub


    Private Function GetTorikomiKen()
        Dim strSQL As String
        strSQL = "SELECT count(*)"
        strSQL &= " FROM " & schema & "t_order where flg ='0'"
        Return ClassPostgeDB.DbSel(strSQL)

    End Function

    Private Sub 取り込みToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取り込みToolStripMenuItem.Click
        FormHanbaiitiran.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ro As Integer
        Dim cl As Integer
        SyoriFlg = True
        Me.Button確定.BackColor = Color.Red


        ro = e.RowIndex
        cl = e.ColumnIndex
        If ro >= 0 Then
            If Me.DataGridView1.Rows(ro).Cells(0).Value = "削除" Then
                If cl = 0 Then
                    DataGridView1.Rows.RemoveAt(ro)
                End If
            End If
        End If

    End Sub

    Private Sub CSVToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem1.Click
        GetIniFile()
        UriagFolder = FileSave(UriagFolder)
        If UriagFolder <> "" Then

            csvOutDataGred(Me.DataGridView1, UriagFolder, 1, False)

        End If
    End Sub
    Private Sub CSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSVToolStripMenuItem.Click
        Dim strSQL As String
        Dim ro As Integer
        ErrSyoriKaistyy = ErrSyoriKaistyy + 1
        Me.ListBox1.Items.Add("")
        Me.ListBox1.Items.Add("-------　エラー再処理 ( " & ErrSyoriKaistyy.ToString("00") & "回目 )　-------")

        strSQL = "DELETE FROM " & schema & "t_hanbai"
        ClassPostgeDB.EXEC(strSQL)
        strSQL = "DELETE FROM " & schema & "t_hanbai_err"
        ClassPostgeDB.EXEC(strSQL)

        For ro = 0 To Me.DataGridView1.Rows.Count - 1

            If Me.DataGridView1.Rows(ro).Cells(2).Value <> "" Then

                strSQL = "INSERT INTO " & schema & "t_hanbai(torihiki_id, order_disp_no, order_d_no, free_item31, item_cd, item_name, quantity"
                strSQL &= ", order_date, seikyu, syokei, teika_sum, teika, coupon_waribiki, coupon_name, coupon_cd, soryo, daibiki, kessai_id"
                strSQL &= ", payment_date, l_name, f_name, send_addr1, send_addr2, send_addr3, ship_slip_no,seq)VALUES("
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(1).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(2).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(3).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(4).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(5).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(6).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(7).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(8).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(9).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(10).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(11).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(12).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(13).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(14).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(15).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(16).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(17).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(18).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(19).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(20).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(21).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(22).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(23).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(24).Value & "',"
                strSQL &= "'" & Me.DataGridView1.Rows(ro).Cells(25).Value & "',"
                strSQL &= "'" & ro & "'"
                strSQL &= ")"


                ClassPostgeDB.EXEC(strSQL)
            End If

        Next
        取込み処理()
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub EXCELToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem1.Click
        excelOutDataGred(Me.DataGridView2, False)
    End Sub
    Private Sub EXCELToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click
        excelOutDataGred(Me.DataGridView1, False)
    End Sub
    Private Sub DataGridView2_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        '仮在庫を002への処理とするボタン

        Dim ro As Integer
        Dim cl As Integer

        Dim sinacd As String
        Dim kosuu As String
        Dim tanka As String
        Dim souryou As String
        Dim tesuuryou As String
        Dim goukei As String
        Dim motoseq As String
        Dim seq As String
        Dim cnt As Integer
        Dim strSQL As String

        SyoriFlg = True
        Me.Button確定.BackColor = Color.Red

        ro = e.RowIndex
        cl = e.ColumnIndex
        If ro >= 0 Then
            If cl = 0 Then
                If Me.DataGridView2.Rows(ro).Cells(0).Value = "引当しない(必)" Then
                    Dim result As DialogResult = MessageBox.Show("キャンセル引当待品を中止しますか？",
                                             "質問",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)

                    If result = vbYes Then

                        sinacd = Me.DataGridView2.Rows(ro).Cells(1).Value
                        kosuu = Me.DataGridView2.Rows(ro).Cells(3).Value
                        tanka = Me.DataGridView2.Rows(ro).Cells(4).Value
                        souryou = Me.DataGridView2.Rows(ro).Cells(5).Value
                        tesuuryou = Me.DataGridView2.Rows(ro).Cells(6).Value
                        goukei = Me.DataGridView2.Rows(ro).Cells(7).Value
                        motoseq = Me.DataGridView2.Rows(ro).Cells(10).Value
                        seq = Me.DataGridView2.Rows(ro).Cells(11).Value
                        DataGridView2.Rows.RemoveAt(ro)

                        cnt = GetCooponZan(motoseq)


                        Select Case cnt
                            Case 0

                                strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '0' ,  update_day= now(), update_sya='" & UserID & "'  where seq = '" & motoseq & "'" ' and syori_flg in('1','2')"
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "INSERT INTO " & schema & "t_order "
                                strSQL &= " Select jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku"
                                strSQL &= ", coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
                                strSQL &= " FROM " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "DELETE FROM  " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                            Case 1

                                strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '0' ,  update_day= now(), update_sya='" & UserID & "'  where seq = '" & motoseq & "'" ' and syori_flg in('1','2')"
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "INSERT INTO " & schema & "t_order "
                                strSQL &= " Select jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku"
                                strSQL &= ", coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
                                strSQL &= " FROM " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & GetCooponZanSeq(motoseq) & "'"
                                ClassPostgeDB.EXEC(strSQL)


                                strSQL = "INSERT INTO " & schema & "t_order "
                                strSQL &= " Select jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku"
                                strSQL &= ", coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
                                strSQL &= " FROM " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "DELETE FROM  " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                            Case Else

                                strSQL = "INSERT INTO " & schema & "t_order "
                                strSQL &= " Select jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku"
                                strSQL &= ", coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
                                strSQL &= " FROM " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "DELETE FROM  " & schema & "t_order_mz"
                                strSQL &= " where seq = '" & seq & "'"
                                ClassPostgeDB.EXEC(strSQL)

                                strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '2' ,  update_day= now(), update_sya='" & UserID & "'  where seq = '" & motoseq & "'" ' and syori_flg in('1','2')"
                                ClassPostgeDB.EXEC(strSQL)

                        End Select
                        Exit Sub
                    End If
                End If
                '////
                If Me.DataGridView2.Rows(ro).Cells(0).Value = "引当しない(不)" Then
                    Dim result As DialogResult = MessageBox.Show("キャンセル引当待品を中止ししますか？",
                                             "質問",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)

                    If result = vbYes Then
                        sinacd = Me.DataGridView2.Rows(ro).Cells(1).Value
                        kosuu = Me.DataGridView2.Rows(ro).Cells(3).Value
                        tanka = Me.DataGridView2.Rows(ro).Cells(4).Value
                        souryou = Me.DataGridView2.Rows(ro).Cells(5).Value
                        tesuuryou = Me.DataGridView2.Rows(ro).Cells(6).Value
                        goukei = Me.DataGridView2.Rows(ro).Cells(7).Value
                        motoseq = Me.DataGridView2.Rows(ro).Cells(10).Value
                        seq = Me.DataGridView2.Rows(ro).Cells(11).Value

                        DataGridView2.Rows.RemoveAt(ro)
                        cnt = GetCooponZan(motoseq)


                        If cnt = 1 Then

                            strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '0' ,  update_day= now(), update_sya='" & UserID & "'  where seq = '" & motoseq & "'"   ' and syori_flg in('1','2')"
                            ClassPostgeDB.EXEC(strSQL)

                        Else
                            strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '0' ,  update_day= now(), update_sya='" & UserID & "'  where seq = '" & motoseq & "'"
                            ClassPostgeDB.EXEC(strSQL)

                        End If
                        strSQL = "INSERT INTO " & schema & "t_order "
                        strSQL &= " Select jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku"
                        strSQL &= ", coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
                        strSQL &= " FROM " & schema & "t_order_mz"
                        strSQL &= " where seq = '" & seq & "'"
                        ClassPostgeDB.EXEC(strSQL)

                        strSQL = "DELETE FROM  " & schema & "t_order_mz"
                        strSQL &= " where seq = '" & seq & "'"
                        ClassPostgeDB.EXEC(strSQL)


                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    Private Function GetCooponZanSeq(motoseq As String) As String
        Dim ro As Integer
        Dim cnt As Integer = 0
        Dim seq As String = "0"
        For ro = 0 To Me.DataGridView2.Rows.Count - 1
            If Me.DataGridView2.Rows(ro).Cells(10).Value = motoseq Then
                cnt = cnt + 1
                seq = Me.DataGridView2.Rows(ro).Cells(11).Value
            End If
        Next
        Return seq
    End Function

    Private Function GetCooponZan(motoseq As String) As Integer
        Dim ro As Integer
        Dim cnt As Integer = 0
        For ro = 0 To Me.DataGridView2.Rows.Count - 1
            If Me.DataGridView2.Rows(ro).Cells(10).Value = motoseq Then
                cnt = cnt + 1
            End If
        Next
        Return cnt
    End Function


    Private Sub FormHanbaiJisseki_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Logent(UserID, UserName, "6") Then
        End If

    End Sub
    Public Function GetCoopon1(iCoopn As String, tyumonb As String)
        Dim strSQL As String
        Dim nm As String

        tyumonb = tyumonb.Substring(0, 10)

        strSQL = "select sinacd  from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & iCoopn.Trim & "'"
        strSQL &= " and   kikanfrom  <='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   kikanto    >='" & DateTime.Parse(tyumonb) & "'"
        nm = ClassPostgeDB.DbSel(strSQL)
        If nm = "" Then Return ""
        Return nm
    End Function

    Public Function GetCoopon2(iCoopn As String, tyumonb As String, sinacd As String)
        Dim strSQL As String
        Dim nm As String

        tyumonb = tyumonb.Substring(0, 10)

        strSQL = "select sinacd  from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & iCoopn.Trim & "'"
        strSQL &= " and   sinacd  ='" & sinacd.Trim & "'"
        strSQL &= " and   kikanfrom  <='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   kikanto    >='" & DateTime.Parse(tyumonb) & "'"
        nm = ClassPostgeDB.DbSel(strSQL)
        If nm = "" Then Return ""
        Return nm
    End Function

    Public Function GetCoopon(iCoopn As String, iSinacd As String, tyumonb As String)
        Dim strSQL As String
        Dim nm As String

        tyumonb = tyumonb.Substring(0, 10)

        strSQL = "select sinacd  from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & iCoopn.Trim & "'"
        nm = ClassPostgeDB.DbSel(strSQL)

        If nm = "" Then
            Return ""
        End If

        strSQL = "select sinacd  from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & iCoopn.Trim & "'"
        strSQL &= " and   kikanfrom  <='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   kikanto    >='" & DateTime.Parse(tyumonb) & "'"
        nm = ClassPostgeDB.DbSel(strSQL)
        If nm = "" Then
            Return ""
        End If

        strSQL = "select offpar  from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & iCoopn.Trim & "'"
        strSQL &= " and   kikanfrom  <='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   kikanto    >='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   sinacd  ='" & iSinacd.Trim & "'"
        nm = ClassPostgeDB.DbSel(strSQL)
        If nm = "" Then
            Return "0%"
        End If
        If nm <> "0" Then
            Return nm & "%"
        End If

        strSQL = "select offkin  from " & schema & "m_coupon "
        strSQL &= " where couponno ='" & iCoopn.Trim & "'"
        strSQL &= " and   kikanfrom  <='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   kikanto    >='" & DateTime.Parse(tyumonb) & "'"
        strSQL &= " and   sinacd  ='" & iSinacd.Trim & "'"
        nm = ClassPostgeDB.DbSel(strSQL)

        Return (nm)

    End Function

    Private Sub FormHanbaiJisseki_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If SyoriFlg Then
                MessageBox.Show("確定処理が実行されていません")
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Button確定_Click(sender As Object, e As EventArgs) Handles Button確定.Click
        Dim strSQL As String
        Dim seq As String
        Dim motoseq As String
        Dim ro As Integer
        Dim cn As Integer


        For ro = 0 To Me.DataGridView2.Rows.Count - 1

            motoseq = Me.DataGridView2.Rows(ro).Cells(10).Value
            cn = GetCooponZan(motoseq)
            If cn = 1 Then
                If Me.DataGridView2.Rows(ro).Cells(0).Value = "引当しない(必)" Then

                    seq = Me.DataGridView2.Rows(ro).Cells(11).Value

                    strSQL = "INSERT INTO " & schema & "t_order "
                    strSQL &= " Select jyutyucd, tyumonbi, sinacd, kosuu, tanka, kessaihouhou, goukei, coupon_waribiki, tesuuryou, seikyukingaku"
                    strSQL &= ", coupon_cd, syorikubun, nyukinn, nyukinkakuninbi, torikomibi, cst_cd, seq, flg, entry_day, souryou, nebikitanka "
                    strSQL &= " FROM " & schema & "t_order_mz"
                    strSQL &= " where seq = '" & seq & "'"
                    ClassPostgeDB.EXEC(strSQL)

                    strSQL = "DELETE FROM  " & schema & "t_order_mz"
                    strSQL &= " where seq = '" & seq & "'"
                    ClassPostgeDB.EXEC(strSQL)

                    'seq = Me.DataGridView2.Rows(ro).Cells(10).Value
                    'strSQL = "DELETE  FROM " & schema & "t_m_zaiko  where seq = '" & seq & "'"
                    'ClassPostgeDB.EXEC(strSQL)

                End If

                If Me.DataGridView2.Rows(ro).Cells(0).Value = "引当しない(不)" Then
                    seq = Me.DataGridView2.Rows(ro).Cells(10).Value
                    strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '1' ,  update_day= now(), update_sya='" & UserID & "'  where syori_flg ='2' and seq ='" & seq & "'"
                    'strSQL = "DELETE  FROM " & schema & "t_m_zaiko  where seq = '" & seq & "'"
                    ClassPostgeDB.EXEC(strSQL)

                End If
            Else
                    MessageBox.Show("確定できません")
                Exit Sub
            End If
        Next

        strSQL = "UPDATE " & schema & "t_m_zaiko set syori_flg = '1' ,  update_day= now(), update_sya='" & UserID & "'  where syori_flg = '2'"
        ClassPostgeDB.EXEC(strSQL)

        SyoriFlg = False
        Me.Button確定.BackColor = Color.Lime

        MessageBox.Show("確定しました")

    End Sub


End Class