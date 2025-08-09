using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
//using Npgsql.NameTranslation;
using static System.Net.Mime.MediaTypeNames;
using System.Data;

namespace ConsoleApp1
{
    static public class ClassIF
    {
        //テーブル指定
        //const string TableName = "n2c.v_yuryo_tenken_syuyaku";
        const string TableName = "t_002";
        //テーブルの列指定
        static string[] retumei = {
                "sls_typ",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "cst_cd",
                "scnd_dler_tel",
                "thrd_dler_tel",
                "cst_po_no",
                "ord_psn_nm",
                "ord_psn_nm1",
                "slip_rmrks",
                "intr_rmrks",
                "zn_rcv_psn_cd",
                "itm_cd",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "qty",
                "upri",
                "rate",
                "cst_dsnt_subno",
                "ja_inst_no",
                "ja_upri",
                "ja_upri_rate",
                "",
                "",
                "nextb",
                "uketukeno",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                ""
                };
        //取り込みCSV指定
        const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\ソース\\YURYO_SEIKYU_HAKKO.csv";
        //ClassNpgsql cNpgsql =new ClassNpgsql();
        static string csvFileName = string.Empty;

        static int GetField(string mei)
        {
            return Array.IndexOf(retumei, mei);
        }

        static public void csvINsert()
        {
            DataTable dt = new DataTable();
            string sql0 = "";
            string sql1 = "";
            try
            {

                ClassLog.LogDelete();
                int ukeno = GetHairetu("uketukeno");
                int nextb = GetHairetu("nextb");

                ClassNpgsql.DbOpen(1);

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

                        sql0 = $@"insert into {ClassNpgsql.scima}{TableName}(";
                        sql1 = "values("; 
                        
                        for (int i = 0; i < retumei.Length; i++)
                        {
                            if (retumei[i] != "") {
                                sql0 += $@"{retumei[i]},";
                                sql1 += $@"'{lists[i]}',";
                            }
                        }

                        sql0 += ",out_flg";
                        sql0 += ",entry_date";
                        sql0 += ",entry";
                        sql0 += ",del_flg";
                        sql0 += ",tyoufuku";
                        sql0 += ",seq";

                        sql1 += ",'0'";
                        sql1 += ",to_char(now(),'YYYY/MM/DD')";
                        sql1 += ",null";
                        sql1 += ",nll";
                        sql1 += ",null";
                        sql1 += $@",(select max(COALESCE(seq,0)) + 1 from {ClassNpgsql.scima}{TableName} where  uketukeno ='{lists[ukeno]}')";
                        sql0 = sql0 + sql1;

                        sql1 = $@"select count(*) from {ClassNpgsql.scima}{TableName} where  uketukeno ='{lists[ukeno]}' and nextb ='{lists[nextb]}';";


                        dt = ClassNpgsql._SetDataTable(sql1);
                        
                        if (dt.Rows[0][0].ToString() == "0")
                        {
                            ClassLog.LogWrite(sql0);
                            Console.WriteLine(lists[ukeno]);
                            System.Windows.Forms.Application.DoEvents();

                            ClassNpgsql._EXEC(sql0);
                        }
                        else
                        {
                            ClassLog.LogWrite("PASS : " + sql0);
                            Console.WriteLine("PASS : "+lists[ukeno]);
                            System.Windows.Forms.Application.DoEvents();
                        }
                        //

                    }
                }
                ClassNpgsql.trans.Commit();
                ClassNpgsql.DbClose();
                ClassLog.LogWriteTB("出庫訂正", 0);
            }
            catch (Exception ex)
            {
                ClassLog.LogWrite(ex.Message);
                ClassNpgsql.trans.Rollback();
                ClassNpgsql.DbClose();
                ClassLog.logwriteErrTB("出庫訂正");
            }
        }
        static private int GetHairetu(string nm)
        {
            List<string> lists = new List<string>();
            lists.AddRange(retumei);
            int num = lists.IndexOf(nm);
            return num;

        }
    }
}
