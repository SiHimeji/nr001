using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace Syuyaku
{
    public static  class ClassNpgsql
    {
        ///Postgres
        ///Npgsql.4.1.4
        ///     Npgsql.5.0.5
        //SI
        //private string conn_str = "Server=192.168.1.217;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true";
        //旧
        private static string conn_str = "Server=192.168.1.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true";
        //AWS
        //private string conn_str = "Server="+"partsc.noritz.co.jp"+";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true";

        public static NpgsqlConnection cn = new NpgsqlConnection();
        public static NpgsqlCommand cm = new NpgsqlCommand();
        public static NpgsqlDataReader rs;
        public static NpgsqlTransaction trans;
        ////
        /// <summary>
        /// 
        // sw=1  NpgsqlTransaction
        //
        public static  Boolean DbOpen(int sw = 0)
        {
            cn.ConnectionString = conn_str;
            try
            {
                cn.Open();
                if(sw==1)trans = cn.BeginTransaction();

                return (true);
            }
            catch
            {
                return (false);

            }
        }
        public static void DbClose()
        {
            cn.Close();
            
        }
        ////
        /// <summary>
        /// 
        // </summary>
        // <param name="strSQL"></param>
        // <param name="dg"></param>
        // <returns></returns>
        //

        public static string EXECSQL(string strSQL)
        {
            string ret = "";
            if (DbOpen())
            {
                cm.Connection = cn;
                cm.CommandText = strSQL;

                rs = cm.ExecuteReader();

                if (rs.HasRows == false)
                {
                    // この処理はなくてもOK
                }
                while (rs.Read())
                {
                    //ret = rs.GetFieldType(0).ToString();
                    ret = rs.GetString(0).Trim();
                }
                rs.Close();
                cm.Clone();
                DbClose();
                return ( ret );
            }

            return ("");
        }

        public static Boolean EXEC(string strSQL)
        {
            //if (DbOpen())
            //{
                try
                {
                    cn.ConnectionString = conn_str;
                    cn.Open();
                    cm = cn.CreateCommand();
                    cm.CommandText = strSQL;
                    cm.ExecuteNonQuery();
                    cm.Clone();
                    cn.Close();
                    return (true);
                }
                catch
                {
                cn.Close();
                return (false);
                }
            //}
           // return (false);
        }
        //トランザクション用(例外は呼び出し先で処理する)
        // trans = conn.BeginTransaction();
        //
        //
        public static bool _EXEC(String StrSQL)
        {
            Npgsql.NpgsqlCommand NpgsqlCommand;
            NpgsqlCommand = cn.CreateCommand();
        
            try
            {
                NpgsqlCommand.CommandText = StrSQL;
                NpgsqlCommand.ExecuteNonQuery();
                return (true);  
            }
            catch
            {
                NpgsqlCommand.Dispose();
                return (false);
            }
        }
        /// /
        /// 
        public static DataTable SetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();
            if (DbOpen())
            {

                NpgsqlCommand cmd = new NpgsqlCommand(strSQL, cn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

                da.Fill(dt);

                DbClose();

            }

            return dt;
        }

        public static DataTable _SetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand(strSQL, cn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        //
    }
}
