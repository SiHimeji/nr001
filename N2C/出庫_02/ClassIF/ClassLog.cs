using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassIF
{
     public class ClassLog
    {
        ClassNpgsql cDB = new ClassNpgsql();

        const string LogTableName = "t_log";
        //const string LogTableName = "t_log";

         public void LogWrite(string log)
        {
            DateTime today = DateTime.Today;
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath) + "\\log\\log_" + today.DayOfWeek.ToString() + ".log";
            StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("shift_jis"));
            sw.WriteLine(log);
            sw.Close();
        }
         public void LogDelete()
        {

            if (!  Directory.Exists(Directory.GetCurrentDirectory()+ "\\log"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\log");
            }

            DateTime today = DateTime.Today;
            System.Reflection.Assembly executionAsm = System.Reflection.Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(new Uri(executionAsm.CodeBase).LocalPath) + "\\log\\log_" + today.DayOfWeek.ToString() + ".log";
            System.IO.File.Delete(path);
        }
         public void LogWriteTB(string tbl, int sousinsu)
        {
            string strSqL = $@"INSERT INTO {cDB.scaima}{LogTableName}(id, nm, mn, entry_day) VALUES('SYSTEM', '{tbl}', '{sousinsu.ToString()}件', now())";
            cDB.EXEC(strSqL);
        }
         public void logwriteErrTB(string tbl)
        {
            string strSqL = $@"INSERT INTO {cDB.scaima}{LogTableName}(id, nm, mn, entry_day) VALUES('SYSTEM', '{tbl}', 'ERROR', now())";
            cDB.EXEC(strSqL);
        }




    }
}
