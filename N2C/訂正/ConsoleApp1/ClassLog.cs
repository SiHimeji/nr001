using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp1
{
    static public class ClassLog
    {
        const string LogTableName = "tenken.t_log";

        static public void LogWrite(string log)
        {
            DateTime today = DateTime.Today;
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath) + "\\log\\log_" + today.DayOfWeek.ToString() + ".log";
            StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("shift_jis"));
            sw.WriteLine(log);
            sw.Close();
        }
        static public void LogDelete()
        {
            DateTime today = DateTime.Today;
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath) + "\\log\\log_" + today.DayOfWeek.ToString() + ".log";
            System.IO.File.Delete(path);
        }
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
