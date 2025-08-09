Imports System.IO
Imports System.Windows.Forms

Module Module2
    Dim cPs As New ClassPostgeDB()
    Dim Tday As Date
    Dim TdayS As Date
    Dim TdayE As Date
    Dim sw1 As StreamWriter
    Const schema As String = "tenken"


    Public Sub MainSyori()

        GetMeisai()

        If Zengetusyo() Then
            Dim tday1 As Date = Now.AddMonths(-1)                           '今日の１月前
            Dim firstDate = New DateTime(tday1.Year, tday1.Month, 1)        '１月前の１日
            Dim lastDate As Date = firstDate.AddMonths(1).AddDays(-1)       '１月前の末日
            ZengetuSyukei(firstDate.ToShortDateString, lastDate.ToShortDateString, Now.ToShortDateString)


        End If
        Dim tday2 As Date = Now.AddMonths(0)                             '今日
        Dim firstDayOfMonth = New DateTime(tday2.Year, tday2.Month, 1)　 '今月の１日
        ZengetuSyukei(firstDayOfMonth.ToShortDateString, tday2.ToShortDateString, tday2.ToShortDateString)

        KakogetuSyukei(Now().ToShortDateString())

        'LOG削除
        LogDelete()
    End Sub
    '
    '
    Private Sub GetMeisai()

        Dim strSQL As String = GetSQL()
        Dim dt As DataTable
        Try

            TdayS = New DateTime(Tday.Year, Tday.Month, 1)          '    の１日
            TdayE = TdayS.AddMonths(1).AddDays(0)                  '    の末日

            strSQL &= "And e_sagyo_hokoku.shonin_date between '" & TdayS.ToShortDateString & "' and '" & TdayE.ToShortDateString & "'"

            'sw1.WriteLine(strSQL)

            dt = cPs.SetTable(strSQL)

            For Each dtrow In dt.Rows


                strSQL = "INSERT INTO " & schema & ".t_smile_meisai(受付番号, 集計基準日, 請求番号, ＤＭ番号, 受付日, 点検完了, 承認日, 請求日, 結果１, 結果2)VALUES("
                strSQL &= "'" & dtrow(0) & "'"
                strSQL &= "," & ChkDate(dtrow(1).ToString) & ""
                strSQL &= ",'" & dtrow(2) & "'"
                strSQL &= ",'" & dtrow(3) & "'"

                strSQL &= "," & ChkDate(dtrow(4).ToString) & ""
                strSQL &= "," & ChkDate(dtrow(5).ToString) & ""
                strSQL &= "," & ChkDate(dtrow(6).ToString) & ""
                strSQL &= "," & ChkDate(dtrow(7).ToString) & ""

                strSQL &= ",'" & dtrow(8) & "'"
                strSQL &= ",'" & dtrow(9) & "'"
                strSQL &= ")"
                strSQL &= " ON CONFLICT (受付番号)  "
                strSQL &= " DO UPDATE SET"
                strSQL &= "  集計基準日 = '" & ChkDate(dtrow(1).ToString) & ""
                strSQL &= " ,請求番号 = '" & dtrow(2) & "'"
                strSQL &= " ,ＤＭ番号 = '" & dtrow(3) & "'"
                strSQL &= " ,受付日 = " & ChkDate(dtrow(4).ToString) & ""
                strSQL &= " ,点検完了 = " & ChkDate(dtrow(5).ToString) & ""
                strSQL &= " ,承認日 = " & ChkDate(dtrow(6).ToString) & ""
                strSQL &= " ,請求日 = " & ChkDate(dtrow(7).ToString) & ""
                strSQL &= " ,結果１ = '" & dtrow(8) & "'"
                strSQL &= " ,結果１ = '" & dtrow(9) & "'"
                strSQL &= ";"


                cPs.EXEC(strSQL)

                Console.WriteLine("受付番号:" & dtrow(0) & "    承認日： " & dtrow(6))
                'sw1.WriteLine("受付番号:" & dtrow(0) & "    承認日： " & dtrow(6))

            Next
            LogWrite("ｽﾏｲﾙ明細", "")

        Catch ex As Exception
            LogWrite("ｽﾏｲﾙ明細", "ERROR")
        End Try

    End Sub

    '
    '　日チェック　日でないとNULLを返す
    Private Function ChkDate(dat As String) As String
        If IsDate(dat) Then
            Return "'" & dat & "'"
        End If
        Return "NULL"

    End Function

    '集計
    Private Sub ZengetuSyukei(st As String, et As String, seteihi As String)
        Dim strSQL As String
        Dim dt As DataTable
        Dim v_集計日 As String = seteihi
        Dim v_無償承認月 As String = st.Substring(0, 7)
        Dim v_請求数 As String = "0"
        Dim v_未請求数 As String = "0"
        Dim v_不備待ち数 As String = "0"
        Dim v_物件待ち数 As String = "0"
        Dim v_平均無請 As String = "0"
        Dim v_平均修請 As String = "0"
        Dim v_前回差 As String = "0"

        Try

            strSQL = "select "
            strSQL &= "to_char(t.承認日,'yyyy/MM')"
            strSQL &= ", sum( case when COALESCE(m.待ちフラグ,'9')='9' then 1 else  0 end )　未発行"
            strSQL &= ", sum( case when COALESCE(m.待ちフラグ,'')='0'  then 1 else  0 end )　物件待ち"
            strSQL &= ", sum( case when COALESCE(m.待ちフラグ,'')='1'  then 1 else  0 end )　不備待ち"
            strSQL &= "	from  " & schema & ".v_yuryo_tenken_syuyaku v"
            strSQL &= "	inner join      " & schema & ".t_smile_meisai t on t.受付番号   = v.点検受付番号  and t.請求日 is null"
            strSQL &= "	left outer join " & schema & ".t_smile_machi m  on m.点検受付番号 = v.点検受付番号 and m.待ちフラグ in ('0','1')"
            strSQL &= "	where v.請求日 =''"
            strSQL &= "	and  to_char(t.承認日,'yyyy/MM')='" & v_無償承認月 & "'"
            strSQL &= "	group by to_char(t.承認日,'yyyy/MM')"


            dt = cPs.SetTable(strSQL)
            For Each dtrow In dt.Rows
                v_未請求数 = dtrow(0).ToString
                v_物件待ち数 = dtrow(1).ToString
                v_不備待ち数 = dtrow(2).ToString
            Next


            strSQL = "select  count(*),  round(AVG(t_smile_meisai.結果１),1) ,round(AVG(t_smile_meisai.結果2),1)"
            strSQL &= " from " & schema & ".t_smile_meisai "
            strSQL &= " left outer join " & schema & ".t_smile_machi  on t_smile_meisai.受付番号 =t_smile_machi.点検受付番号  and t_smile_machi.待ちフラグ <>'0'"
            strSQL &= " where t_smile_meisai.承認日 between '" & st & "' and '" & et & "'"
            strSQL &= " And t_smile_meisai.請求日  Is Not null"


            dt = cPs.SetTable(strSQL)
            For Each dtrow In dt.Rows
                v_請求数 = dtrow(0).ToString
                v_平均無請 = dtrow(1).ToString
                v_平均修請 = dtrow(2).ToString
            Next


            strSQL = "select t.請求数 "
            strSQL &= " from " & schema & ".t_smile_kanri  t "
            strSQL &= " where t.無償承認月  = '" & v_無償承認月 & "' "
            strSQL &= " order by t.集計日 asc"
            dt = cPs.SetTable(strSQL)

            For Each dtrow In dt.Rows
                v_前回差 = dtrow(0).ToString
            Next

            If v_前回差 > 0 Then
                v_前回差 = Integer.Parse(v_請求数) - Integer.Parse(v_前回差)

            End If

            strSQL = "INSERT INTO " & schema & ".t_smile_kanri(集計日, 無償承認月, 請求数, 未請求数, 不備待ち数, 物件待ち数, 平均無請, 平均修請, 前回差, 更新日, 更新者"
            strSQL &= ")VALUES("
            strSQL &= "'" & v_集計日 & "'"
            strSQL &= ", '" & v_無償承認月 & "'"
            strSQL &= ", " & v_請求数 & ""

            strSQL &= ", " & v_未請求数 & ""

            strSQL &= ", " & v_不備待ち数 & ""
            strSQL &= ", " & v_物件待ち数 & ""
            strSQL &= ", " & v_平均無請 & ""
            strSQL &= ", " & v_平均修請 & ""

            strSQL &= ", " & v_前回差 & ""
            strSQL &= ", now()"
            strSQL &= ", 'SYSTEM'"
            strSQL &= ")"
            strSQL &= " ON CONFLICT (集計日, 無償承認月)  "
            strSQL &= " DO UPDATE SET"
            strSQL &= "  請求数 = " & v_請求数 & ""
            strSQL &= ", 未請求数 =" & v_未請求数 & ""

            strSQL &= ", 不備待ち数 =" & v_不備待ち数 & ""
            strSQL &= ", 物件待ち数 =" & v_物件待ち数 & ""
            strSQL &= ", 平均無請   =" & v_平均無請 & ""
            strSQL &= ", 平均修請  = " & v_平均修請 & ""

            strSQL &= ", 前回差   =" & v_前回差 & ""
            strSQL &= ", 更新日 = now()"
            strSQL &= ", 更新者 = 'SYSTEM';"


            sw1.WriteLine(strSQL)

            cPs.EXEC(strSQL)

            LogWrite("ｽﾏｲﾙ前月", "OK")

        Catch ex As Exception
            LogWrite("ｽﾏｲﾙ前月", "ERROR")

        End Try



    End Sub


    Private Sub KakogetuSyukei(dy As String)

        Dim strSQL As String
        Dim dt As DataTable
        Dim dt0 As DataTable
        Dim v_未請求数 As String = "0"
        Dim v_集計日 As String
        Dim v_無償承認月 As String

        Dim v_請求数 As String = "0"
        'Dim v_未請求数 As String
        Dim v_不備待ち数 As String = "0"
        Dim v_物件待ち数 As String = "0"
        Dim v_平均無請 As String = "0"
        Dim v_平均修請 As String = "0"
        Dim v_前回差 As String = "0"
        Try

            strSQL = "SELECT 集計日, 無償承認月, 請求数, 未請求数, 不備待ち数, 物件待ち数, 平均無請, 平均修請, 前回差"
            strSQL &= " FROM " & schema & ".t_smile_kanri "
            strSQL &= "  where (集計日 ,無償承認月)in ("
            strSQL &= " select max(t.集計日) ,t.無償承認月  from  " & schema & ".t_smile_kanri t"
            strSQL &= " where t.未請求数  > 0 or t.不備待ち数 > 0 or 物件待ち数 >0"
            strSQL &= " group by t.無償承認月"
            strSQL &= ")"
            strSQL &= " and  無償承認月<> '" & dy.Substring(0, 7) & "'"
            strSQL &= " order by 無償承認月 asc"

            dt0 = cPs.SetTable(strSQL)

            For Each dtrow0 In dt0.Rows

                v_集計日 = Now.ToShortDateString
                v_無償承認月 = dtrow0(1).ToString

                strSQL = " select to_char(now(),'yyyy/MM/dd') "
                strSQL &= " ,to_char(t.承認日,'yyyy/MM')	"
                strSQL &= " , COALESCE(sum( case when COALESCE(m.待ちフラグ,'9')='9' then 1 else  0 end ),0)"
                strSQL &= " , COALESCE(sum( case when COALESCE(m.待ちフラグ,'')='0'  then 1 else  0 end ),0)"
                strSQL &= " , COALESCE(sum ( case when COALESCE(m.待ちフラグ,'') ='1'then 1 else  0 end ),0)"
                strSQL &= " from  " & schema & ".v_yuryo_tenken_syuyaku v	"
                strSQL &= " inner join      " & schema & ".t_smile_meisai t on t.受付番号   = v.点検受付番号  and t.請求日 is null   "
                strSQL &= " 	and  to_char(t.承認日,'yyyy/MM') = '" & dtrow0(1).ToString & "'	"
                strSQL &= " 	left outer join " & schema & ".t_smile_machi m  on m.点検受付番号 = v.点検受付番号 and m.待ちフラグ in ('0','1')	where v.請求日 =''	group by to_char(t.承認日,'yyyy/MM')"


                dt = cPs.SetTable(strSQL)

                If dt.Rows.Count = 0 Then


                    v_未請求数 = 0
                    v_不備待ち数 = 0
                    v_物件待ち数 = 0


                    v_平均無請 = dtrow0(6).ToString
                    v_平均修請 = dtrow0(7).ToString
                    v_前回差 = dtrow0(8).ToString
                Else
                    For Each dtrow In dt.Rows

                        v_未請求数 = dtrow(2).ToString
                        v_不備待ち数 = dtrow(3).ToString
                        v_物件待ち数 = dtrow(4).ToString


                    Next
                End If

                strSQL = "INSERT INTO " & schema & ".t_smile_kanri(集計日, 無償承認月, 請求数, 未請求数, 不備待ち数, 物件待ち数, 平均無請, 平均修請, 前回差, 更新日, 更新者)VALUES("
                strSQL &= "'" & v_集計日 & "'"
                strSQL &= ",'" & v_無償承認月 & "'"
                strSQL &= ",'" & v_請求数 & "'"
                strSQL &= ",'" & v_未請求数 & "'"
                strSQL &= ",'" & v_不備待ち数 & "'"
                strSQL &= ",'" & v_物件待ち数 & "'"
                strSQL &= ",'" & v_平均無請 & "'"
                strSQL &= ",'" & v_平均修請 & "'"
                strSQL &= ",'" & v_前回差 & "'"
                strSQL &= ", now()"
                strSQL &= ", 'SYSTEM'"
                strSQL &= ")"
                strSQL &= " ON CONFLICT (集計日, 無償承認月)  "
                strSQL &= " DO UPDATE SET"
                strSQL &= "  請求数 = " & v_請求数 & ""
                strSQL &= ", 未請求数 =" & v_未請求数 & ""
                strSQL &= ", 不備待ち数 =" & v_不備待ち数 & ""
                strSQL &= ", 物件待ち数 =" & v_物件待ち数 & ""
                strSQL &= ", 平均無請   =" & v_平均無請 & ""
                strSQL &= ", 平均修請  = " & v_平均修請 & ""
                strSQL &= ", 前回差   =" & v_前回差 & ""
                strSQL &= ", 更新日 = now()"
                strSQL &= ", 更新者 = 'SYSTEM')"



                cPs.EXEC(strSQL)
            Next
            LogWrite("ｽﾏｲﾙ過去", "OK")
        Catch ex As Exception
            LogWrite("ｽﾏｲﾙ過去", "ERROR")
        End Try

    End Sub

    Private Function Get物件待ち(tim As String)
        Dim strSQL As String
        Dim dt As DataTable
        Dim v_物件待ち数 As String = "0"

        strSQL = "select count(t_smile_machi.待ちフラグ)"
        strSQL &= " from " & schema & ".t_smile_meisai "
        strSQL &= " left outer join " & schema & ".t_smile_machi  on t_smile_meisai.受付番号 =t_smile_machi.点検受付番号  and t_smile_machi.待ちフラグ ='0'"
        strSQL &= " where to_char(t_smile_meisai.承認日,'yyyy/MM') =  '" & tim & "'"
        strSQL &= " and t_smile_meisai.請求日  is null"
        dt = cPs.SetTable(strSQL)
        For Each dtrow In dt.Rows
            v_物件待ち数 = dtrow(0).ToString
        Next
        Return v_物件待ち数


    End Function

    Private Function Get請求数(tim As String)
        Dim strSQL As String
        Dim dt As DataTable
        Dim v_請求数 As String = "0"

        strSQL = "select  count(*),  round(AVG(t_smile_meisai.結果１),1) ,round(AVG(t_smile_meisai.結果2),1)"
        strSQL &= " from " & schema & ".t_smile_meisai "
        strSQL &= " left outer join " & schema & ".t_smile_machi  on t_smile_meisai.受付番号 =t_smile_machi.点検受付番号  and t_smile_machi.待ちフラグ <>'0'"
        strSQL &= " where to_char(t_smile_meisai.承認日,'yyyy/MM') =  '" & tim & "'"
        strSQL &= " And t_smile_meisai.請求日  Is Not null"

        dt = cPs.SetTable(strSQL)
        For Each dtrow In dt.Rows
            v_請求数 = dtrow(0).ToString
        Next
        Return v_請求数


    End Function


    Private Sub LogOpen()
    End Sub
    Private Sub LogClose()
    End Sub
    Private Sub LogWrite(syori As String, ken As String)
        Dim strSQL As String = String.Empty
        strSQL = "INSERT INTO " & schema & ".t_smile_log(id, nm, mn, entry_day) VALUES('SYSTEM', '" & syori & "', '" & ken & "', now()) "
        cPs.EXEC(strSQL)
    End Sub
    Private Sub LogDelete()
        Dim strSQL As String = String.Empty
        strSQL = "DELETE FROM " & schema & ".t_smile_log WHERE entry_day < CURRENT_DATE -   (select  cast(  naiyou  as  int ) from " & schema & "m_system  where kbn ='99' and seq ='0')"
        cPs.EXEC(strSQL)
    End Sub


    Private Function GetSQL() As String
        Dim Text As String
        Text = "select"
        Text &= "点検受付番号 ""受付番号"""
        Text &= ",集計基準日"
        Text &= ",請求番号"
        Text &= ",ｄｍ番号"
        Text &= ",点検受付日 ""受付日"""
        Text &= ",点検完了日 ""点検完了"""
        Text &= ",無償承認日 ""承認日"""
        Text &= ",登録日時   ""請求日"""
        Text &= ",cast( 登録日時 as date) - cast(無償承認日 as date)  ""結果１"""
        Text &= ",cast(登録日時 As Date) -  cast(点検完了日 As Date)  ""結果2"""
        Text &= " From " & schema & ".v_yuryo_tenken_syuyaku"
        Text &= " where 登録日時    <> ''"
        Text &= " And   無償承認日 <> ''"
        Text &= " And   点検完了日  <> ''"
        Text &= " And   cast( 登録日時 as date) > '2025/01/01'"

        Return Text
    End Function
    '/////////////////////////////////////////////////
    '  今日の一週間前は前月かのチェック
    '　true = 前月である
    '　false = 今月
    '////////////////////////////////////////////////
    Private Function Zengetusyo() As Boolean
        Dim today1 As Date = Now.Date
        Dim today2 As Date = Now.Date.AddDays(-7)
        If today1.Month = today2.Month Then
            Return False
        End If
        Return True
    End Function

End Module
