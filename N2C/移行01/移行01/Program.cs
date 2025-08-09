using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syuyaku;

namespace 移行01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ikou01();       //承認請求日
        }
        private static void Ikou01()
        {
            LoggerService log = new LoggerService();  
            string sql = $@"
                        select 
                        v_yuryo_tenken_syuyaku.点検受付番号 受付番号
                        ,v_yuryo_tenken_syuyaku.請求番号    請求番号1
                        ,t_smile_meisai.請求番号            請求番号2
                        ,v_yuryo_tenken_syuyaku.無償承認日  承認日1
                        ,t_smile_meisai.承認日              承認日2
                        ,v_yuryo_tenken_syuyaku.請求日      請求日1
                        ,t_smile_meisai.請求日              請求日2
                        from tenken.t_smile_meisai
                        ,tenken.v_yuryo_tenken_syuyaku
                        where t_smile_meisai.受付番号 =v_yuryo_tenken_syuyaku.点検受付番号
                ";
            DataTable dt = new DataTable();
            dt = ClassNpgsql.SetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    ClassNpgsql.DbOpen(1);
                    foreach (DataRow dr in dt.Rows)
                    {
                        sql = $@"";
                        if (dr["請求番号1"].ToString() == "")
                        {
                            if (dr["請求番号2"].ToString() != "")
                            {
                                sql += $@" 請求番号 ='{dr["請求番号2"].ToString().Substring(0,10)}'";
                            }
                        }
                        if (dr["承認日1"].ToString() == "")
                        {
                            if (dr["承認日2"].ToString() != "")
                            {
                                if (sql.Length > 0) sql += $@",";
                                sql += $@" 無償承認日 ='{dr["承認日2"].ToString().Substring(0, 10)}'";
                            }
                        }
                        if (dr["請求日1"].ToString() == "")
                        {
                            if (dr["請求日2"].ToString() != "")
                            {
                                if (sql.Length > 0) sql += $@",";
                                sql += $@" 請求日 ='{dr["請求日2"].ToString()}.Substring(0,10)'";
                            }
                        }
                        if (sql.Length > 0)
                        {
                            System.Console.WriteLine(dr["受付番号"].ToString());
                            log.LogWarning("update tenken.v_yuryo_tenken_syuyaku set" + sql + $@" where 点検受付番号='{dr["受付番号"].ToString()}'");
                            if(!ClassNpgsql._EXEC("update tenken.v_yuryo_tenken_syuyaku set" + sql +$@" where 点検受付番号='{dr["受付番号"].ToString()}'"))
                            {
                                throw new Exception();
                            }
                        }
                    }
                    ClassNpgsql.trans.Commit(); 
                    ClassNpgsql.DbClose();
                }
                catch (Exception ex)
                {
                    log.LogWarning(ex.ToString());
                    ClassNpgsql.trans.Rollback();   
                    ClassNpgsql.DbClose();
                }
            }
        }
    }
}
