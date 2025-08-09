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

namespace ClassIF
{
     public class ClassIF訂正
    {
        ClassLog cLog = new ClassLog();
        ClassNpgsql cDB = new ClassNpgsql();

        //テーブル指定
        const string TableName = "t_002";
        //テーブルの列指定
         string[] retumei = {
                //"sls_typ",
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
        //const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\ソース\\YURYO_SEIKYU_HAKKO.csv";
        //ClassNpgsql cNpgsql =new ClassNpgsql();
         string csvFileName = string.Empty;

         int GetField(string mei)
        {
            return Array.IndexOf(retumei, mei);
        }

         public void csvINsert訂正(DataTable dat)
        {
            DataTable dt = new DataTable();
            string sql0 = "";
            string sql1 = "";
            try
            {

                cLog.LogDelete();
                int ukeno = GetHairetu("uketukeno",dat);
                int nextb = GetHairetu("nextb",dat);

                cDB.DbOpen(1);
                foreach (DataRow dr in dat.Rows) 
                {


                    sql0 = $@"insert into {cDB.scaima}{TableName}(";
                    sql1 = "values("; 
                        
                    for (int i = 0; i < retumei.Length; i++)
                    {
                        if (retumei[i] != "") {
                            sql0 += $@"{retumei[i]},";
                            sql1 += $@"'{dr[GetHairetu(retumei[i], dat)]}',";
                        }
                    }

                    sql0 += ",sls_typ";
                    sql0 += ",out_flg";
                    sql0 += ",entry_date";
                    sql0 += ",entry";
                    sql0 += ",del_flg";
                    sql0 += ",tyoufuku";
                    sql0 += ",seq";
                    sql0 += ",newflg";

                    sql1 += ",'1'";
                    sql1 += ",'0'";
                    sql1 += ",to_char(now(),'YYYY/MM/DD')";
                    sql1 += ",null";
                    sql1 += ",null";
                    sql1 += ",null";
                    sql1 += $@",(select COALESCE(max(seq) + 1,0 )  from {cDB.scaima}{TableName} where  uketukeno ='{dr[ukeno]}')";
                    sql1 += ",'1'";

                    sql0 = sql0 + sql1;

                    sql1 = $@"select count(*) from {cDB.scaima}{TableName} where  uketukeno ='{dr[ukeno]}' and nextb ='{dr[nextb]}';";


                    dt = cDB._SetDataTable(sql1);
                       
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        cLog.LogWrite(sql0);
                            ///Console.WriteLine(lists[ukeno]);
                           //System.Windows.Forms.Application.DoEvents();

                        cDB._EXEC(sql0);
                    }
                    else
                    {
                        cLog.LogWrite("PASS : " + sql0);
                            //Console.WriteLine("PASS : "+lists[ukeno]);
                            //System.Windows.Forms.Application.DoEvents();
                    }
                        //

                }
                cDB.trans.Commit();
                cDB.DbClose();
                cLog.LogWriteTB("出庫訂正", 0);
            }
            catch (Exception ex)
            {
                cLog.LogWrite(ex.Message);
                cDB.trans.Rollback();
                cDB.DbClose();
                cLog.logwriteErrTB("出庫訂正");
            }
        }
         private int GetHairetu(string nm,DataTable dt)
         {
            for (int x = 0; x < dt.Columns.Count - 1; x++)
            {
                if (dt.Columns[x].ColumnName == nm)
                {
                    return x;
                }
            }
            return -1;

        }
    }
}
