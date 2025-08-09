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

namespace ClassIF
{
    public   class ClassNpgsql
    {
        ///Postgres
        ///   Npgsql  8.0.7
        ///
        //SI
        //private string conn_str = "Server=192.168.1.217;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true";
        //旧
        private  string conn_str = "Server=192.168.1.166;Port=5432;User ID=postgres;Database=postgres;Password=123456;Enlist=true";
        //AWS
        //private static string conn_str = "Server="+"partsc.noritz.co.jp"+";Port=5432;User ID=nr;Database=postgres;Password=nr123;Enlist=true";

        public string scaima = "tenken.";
        //public string scaima = "n2c.";

        public NpgsqlConnection cn = new NpgsqlConnection();
        public  NpgsqlCommand cm = new NpgsqlCommand();
        public  NpgsqlDataReader rs;
        public  NpgsqlTransaction trans;
        ////
        /// <summary>
        /// 
        // sw=1  NpgsqlTransaction
        //
        public   Boolean DbOpen(int sw = 0)
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
        public  void DbClose()
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

        public  string EXECSQL(string strSQL)
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

        public  Boolean EXEC(string strSQL)
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
        public  void _EXEC(String StrSQL)
        {
            Npgsql.NpgsqlCommand NpgsqlCommand;
            NpgsqlCommand = cn.CreateCommand();
        
            try
            {
                NpgsqlCommand.CommandText = StrSQL;
                NpgsqlCommand.ExecuteNonQuery();
            }
            catch
            {
                //NpgsqlCommand.Dispose();
                throw new Exception();
            }
        }
        /// /
        /// 
        public  DataTable SetDataTable(string strSQL)
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

        public  DataTable _SetDataTable(string strSQL)
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
