using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syuyaku;


namespace Syuyaku
{
    static public class ClassLog
    {
        //const string LogTableName = "tenken.t_log";
        const string LogTableName = "n2c.t_log";

        static public void LogWrite(string log)
        {
            DateTime today = DateTime.Today;
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath) + "\\log\\log_" + today.DayOfWeek.ToString() + ".log";
            StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("shift_jis"));
            sw.WriteLine(log);
            sw.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        static public void LogDelete()
        {

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\log"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\log");
            }


            DateTime today = DateTime.Today;
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath) + "\\log\\log_" + today.DayOfWeek.ToString() + ".log";
            System.IO.File.Delete(path);


        }
        /// <summary>
        /// LOGWITE
        /// </summary>
        static public void LogWriteTB(string tbl, int sousinsu)
        {
            string strSqL = $@"INSERT INTO {LogTableName}(id, nm, mn, entry_day) VALUES('SYSTEM', '{tbl}', '{sousinsu.ToString()}件', now())";
            ClassNpgsql.EXEC(strSqL);
        }
        static public void logwriteErrTB(string tbl)
        {
            string strSqL = $@"INSERT INTO {LogTableName}(id, nm, mn, entry_day) VALUES('SYSTEM', '{tbl}', 'ERROR', now())";
            ClassNpgsql.EXEC(strSqL);
        }

    }
}
