using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIF
{
    public class ClassIFオーダー
    {

        ClassLog cLog = new ClassLog();
        ClassNpgsql cDB = new ClassNpgsql();

        //テーブル指定
        const string TableName = "t_002";
        //テーブルの列指定
        string[] retumei = {
                "ord_no",
                "cst_po_no_d"
        };

        public void csvINsertオーダー(DataTable dat)
        {
            int ukeyuke = GetHairetu("cst_po_no_d", dat);
            int order = GetHairetu("ord_no", dat);
            string strSQL;

            cLog.LogDelete();
            cDB.DbOpen(1);
            try
            {
                foreach (DataRow row in dat.Rows)
                {
                    strSQL = $@"update {cDB.scaima}{TableName} set ord_no='{row[order]}' where uketukeno ='{row[ukeyuke]}'";

                    cDB._EXEC(strSQL);
                }
                cDB.trans.Commit();
                cDB.DbClose();
                cLog.LogWriteTB("オーダー更新", 0);
            }
            catch (Exception e)
            {
                cLog.LogWrite(e.Message);
                cDB.trans.Rollback();
                cDB.DbClose();
                cLog.logwriteErrTB("オーダー更新");
            }
        }
        private int GetHairetu(string nm, DataTable dt)
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