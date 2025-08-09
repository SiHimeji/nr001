using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
///using

namespace Syuyaku
{
    static public class ClassIF
    {
        //テーブル指定
        //const string TableName = "n2c.v_yuryo_tenken_syuyaku";
        const string TableName = "v_yuryo_tenken_syuyaku";

        //取り込みCSV指定
        //const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\Data\\N2OK003T.csv";
        //const string FileName = "C:\\work\\06_点検センター\\70_N2C対応\\ソース\\N2OK003T.csv";
        public static string FileName = $@"D:\work\Densou\N2OK003T.csv";
        static int[] NitiJi = new int[20];
        static int[] Suuji = new int[20];

        //テーブルの列指定
        static string[] retumei = {
                        "帳票発行日"
                        ,"帳票発行者id"
                        ,"請求番号"
                        ,"点検受付番号"
                        ,"点検受付日"
                        ,"点検完了日"
                        ,"請求書印刷日"
                        ,"請求書再印刷日"
                        ,"回収予定日"
                        ,"回収完了日"
                        ,"技術料"
                        ,"出張料"
                        ,"諸経費"
                        ,"サポート料"
                        ,"その他料金"
                        ,"値引き"
                        ,"消費税額"
                        ,"cim番号"
                        ,"請求日"
                        ,"帳票発行者姓"
                        ,"帳票発行者名"
                                  };
        static string csvFileName = string.Empty;

        static int GetField(string mei)
        {
            return Array.IndexOf(retumei, mei);
        }

        static public void csvINsert()
        {
            string sql0 = "";
            string sql1 = "";
            //string ukno = "";
            //string sql1 = "";
            int sousinsuu = 0;
            int x;
            try
            {
                for (x = 0; x < 20; x++)
                {
                    NitiJi[x] = -1;
                    Suuji[x] = -1;
                }

                ClassLog.LogDelete();

                if (!File.Exists(FileName))
                {
                    ClassLog.LogWrite("ファイルが存在しません");
                    return;
                }



                int ukeno = GetHairetu("点検受付番号");
                x = 0;
                NitiJi[x++] = GetHairetu("帳票発行日");
                NitiJi[x++] = GetHairetu("点検受付日");
                NitiJi[x++] = GetHairetu("点検完了日");
                NitiJi[x++] = GetHairetu("請求書印刷日");
                NitiJi[x++] = GetHairetu("請求書再印刷日");
                NitiJi[x++] = GetHairetu("回収予定日");
                NitiJi[x++] = GetHairetu("回収完了日");
                NitiJi[x++] = GetHairetu("請求日");

                x = 0;
                Suuji[x++] = GetHairetu("技術料");
                Suuji[x++] = GetHairetu("出張料");
                Suuji[x++] = GetHairetu("諸経費");
                Suuji[x++] = GetHairetu("サポート料");
                Suuji[x++] = GetHairetu("その他料金");
                Suuji[x++] = GetHairetu("値引き");
                Suuji[x++] = GetHairetu("消費税額");

                ClassNpgsql.DbOpen(1);

                ClassLog.LogWrite(FileName);

                if (!File.Exists(FileName))
                {
                    ClassLog.LogWrite("ファイルが存在しません");
                    return;
                }




                var parser = new TextFieldParser(FileName, System.Text.Encoding.GetEncoding("UTF-8"));
                using (parser)
                {

                    //  区切りの指定
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    // フィールドが引用符で囲まれているか
                    parser.HasFieldsEnclosedInQuotes = true;
                    // フィールドの空白トリム設定
                    parser.TrimWhiteSpace = false;


                    // ファイルの終端までループ
                    var lists = parser.ReadFields();
                    while (!parser.EndOfData)
                    {

                        var line = new List<string>();
                        lists = parser.ReadFields();


                        for (x = 0; NitiJi.Length > x; x++)
                        {
                            if (NitiJi[x] != -1)
                            {
                                lists[NitiJi[x]] = HiHenkan(lists[NitiJi[x]], x, retumei[NitiJi[x]]);
                            }
                        }

                        for (x = 0; Suuji.Length > x; x++)
                        {
                            if (Suuji[x] != -1)
                            {
                                lists[Suuji[x]] = SuujiCheck(lists[Suuji[x]]);
                            }
                        }

                        sql0 = $@"insert into {ClassNpgsql.scima}{TableName}(";
                        sql1 = "values("; 
                        
                        for (int i = 0; i < retumei.Length; i++)
                        {
                            if (retumei[i] != "") {
                                sql0 += $@"{retumei[i]},";
                                sql1 += $@"'{lists[i]}',";
                            }
                        }
                        sql0 += $@"newflg)";
                        sql1 += $@"'100')";                        
                        sql0 = sql0 + sql1+ $@" on conflict(点検受付番号)";

                        sql0 += $@" do update set";
                        for (int i = 0; i < retumei.Length; i++)
                        {
                            if (retumei[i] != "" && ukeno != i)
                            {
                                sql0 += $@" {retumei[i]} = EXCLUDED.{retumei[i]},";
                            }
                        }
                        sql0 += $@" newflg = v_yuryo_tenken_syuyaku.newflg + 100;";

                        ClassLog.LogWrite(sql0);
                        Console.WriteLine(lists[ukeno]);
                        System.Windows.Forms.Application.DoEvents();

                        ClassNpgsql._EXEC(sql0);
                        //
                        sousinsuu++;

                    }
                }

                ClassNpgsql.trans.Commit();
                ClassNpgsql.DbClose();

                ClassLog.LogWriteTB("請求データ",sousinsuu);
            }
            catch (Exception ex)
            {
                ClassLog.LogWrite(ex.Message);
                ClassNpgsql.trans.Rollback();
                ClassNpgsql.DbClose();
                ClassLog.logwriteErrTB("請求データ");
            }
        }
        static private int GetHairetu(string nm)
        {
            List<string> lists = new List<string>();
            lists.AddRange(retumei);
            int num = lists.IndexOf(nm);
            return num;

        }
        /// <summary>
        /// 日付
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        static private string HiHenkan(string buf, int x, string re)
        {
            string ret;
            try
            {
                switch (buf.Length)
                {

                    case 18:
                        buf = buf.Substring(0, 10) + " " + buf.Substring(10, 8);
                        ret = buf.Replace("-", "/");
                        break;
                    default:
                        ret = buf.Replace("-", "/");
                        break;

                }
                //Console.WriteLine(x.ToString() +" : "+re +" : "+ buf +" -> " + ret);

                return ret;
            }
            catch (Exception ex)
            {
                ClassLog.LogWrite(ex.Message); 
                return "";
            }
        }
        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        static private string SuujiCheck(string buf)
        {

            bool isInteger = int.TryParse(buf, out int result);
            if (isInteger)
            {
                return buf;
            }
            return "0";
        }

    }
}
