using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//
// NuGet
// Oracle.ManagedDataAccess
//
namespace spClassOracle
{
    /// <summary>
    ///  Oracle.ManagedDataAccess
    /// </summary>
    public class ClassOracle
    {
        //
        public Boolean login;
        public OracleConnection cnn = new OracleConnection();
        public OracleCommand cmd = new OracleCommand();
        public OracleDataReader rs ;
        public string SQL;
        public string ErrorMSg;        
        public int SQLCNT;
        public string DBMS;
        public string conStr;

        //        public ClassOracle(string DB, string User, string Pass)
        public ClassOracle()
        {
            login = false;
       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DB"></param>
        public void SetDatabe()
        {
            conStr = //"user id=bbuser;password=bbuser;data source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.217)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = BBX61)))";
                        "user id=CRMSYU;password=E46XPWGW;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.31.37.179)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=NRDB.WORLD)))";
                // "user id=CRMKEN;password=MP8TA24M;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.31.37.169)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=GQLDB.WORLD)))";
                //"user id=CRMSYU;password=E46XPWGW;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.31.37.179)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=NRDB.WORLD)))";
                //"user id=CRMKEN;password=MP8TA24M;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=172.31.37.179)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=GQLDB.WORLD)))";
            DBMS = conStr.Substring(0, conStr.IndexOf(";"));

        }
        /// <summary>
        /// 
        /// </summary>
        public void DatabeLogin()
        {
            if (! login)
            {
                try
                {
                    cnn.ConnectionString = conStr;
                    cnn.Open();
                    login = true;
                }
                catch (Exception e)
                {
                    ErrorMSg = e.Message;
                    login = false;
                    //MessageBox.Show("Oracle 接続エラー");
                    ErrorMSg = e.Message;
                }
            }
        }
        //****************************************************************
        // 
        //  Logout
        //
        //****************************************************************
        public void DatabeLogout()
        {
            if (login)
            {
                cnn.Close();
                login = false;
            }
        }
        //****************************************************************
        // 
        //  SQL実行
        //
        //****************************************************************
        public Boolean execSQL(string iSQL)
        {
            try
            {
                if (! login ) DatabeLogin();
                cmd.Connection = cnn;
                cmd.CommandText = iSQL;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "COMMIT";
                cmd.ExecuteNonQuery();
                return (true);
            }
            catch (Exception e)
            {
                cmd.CommandText = "ROLLBACK";
                cmd.ExecuteNonQuery();

                ErrorMSg = e.Message;
                return (false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public Boolean execSQL(string[] strSQL)
        {
            try
            {
                if (!login) DatabeLogin();
                cmd.Connection = cnn;

                foreach (string i in strSQL)
                {
                    cmd.CommandText = i;
                    cmd.ExecuteNonQuery();  
                }
                cmd.CommandText = "COMMIT";
                cmd.ExecuteNonQuery();
                return (true);
            }
            catch (Exception e)
            {
                cmd.CommandText = "ROLLBACK";
                cmd.ExecuteNonQuery();

                ErrorMSg = e.Message;
                return (false);
            }
        }
        /// <summary>
        ///  SQL実行
        /// </summary>
        /// <param name="iSQL"></param>
        /// <returns></returns>
        public Boolean SelectSQL(string iSQL)
        {
            if (!login) DatabeLogin();
            try
            {
                cmd.CommandText = iSQL;
                rs = cmd.ExecuteReader();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                return (false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void SQLClose()
        {
            rs.Close();
            if (login) DatabeLogout();
        }
        //****************************************************************
        // 
        //ComboBox に値を入れる
        //
        //****************************************************************
        public Boolean SetCombo(string strSQL, ComboBox cmb)
        {
            cmb.Items.Clear();
            try
            {
                if (! login) DatabeLogin();

                if (SelectSQL(strSQL)){
                    while (rs.Read())
                    {
                        cmb.Items.Add(rs[0].ToString());
                    }
                    SQLClose();
                }
                DatabeLogout();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //****************************************************************
        // 
        // DataGridView に値を入れる
        //
        //****************************************************************
        public Boolean SetGredData(string strSQL, DataGridView dgv,int x)
        {

            int i;
            dgv.Rows.Clear();
            try
            {
                if (! login ) DatabeLogin();

                if (SelectSQL(strSQL))
                {
                    while (rs.Read())
                    {
                        DataGridViewRow item = new DataGridViewRow();
                        item.CreateCells(dgv);
                        for(i =0 ; i < x ;i++){
                            item.Cells[i].Value = rs.GetString(i).ToString();
                        }
                        //item.Cells[1].Value = rs.GetString(1).ToString();
                        dgv.Rows.Add(item);
                        System.Windows.Forms.Application.DoEvents();
                    }
                    SQLClose();
                }
                DatabeLogout();

                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //****************************************************************
        // 
        // TEXT に結果を入れる
        //
        //****************************************************************
        public Boolean SetTXT(string strSQL, TextBox txt)
        {
            txt.Text = "";
            try
            {
                if (!login) DatabeLogin();
                if (SelectSQL(strSQL))
                {
                    
                    if (rs.Read())
                    {
                        txt.Text = rs[0].ToString();
                    }
                    SQLClose();
                }
                DatabeLogout();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //****************************************************************
        // 
        // TEXT に結果を入れる
        //
        //****************************************************************
        public Boolean SetTXT(string strSQL, TextBox txt,int x)
        {
            txt.Text = "";
            try
            {
                if (!login) DatabeLogin();
                if (SelectSQL(strSQL))
                {
                    if (rs.Read())
                    {
                        txt.Text = rs[x].ToString();
                    }
                    SQLClose();
                }
                DatabeLogout();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //****************************************************************
        // 
        // ListBox に結果を入れる
        //
        //****************************************************************
        //
        public Boolean SetListBox(string strSQL, ListBox  box,int x)
        {
            string ln;
            box.Items.Clear();

            try
            {
                if (!login) DatabeLogin();
                if (SelectSQL(strSQL))
                {
                    while (rs.Read())
                    {
                        ln = "";
                        for(int y=0; y<x ; y++)
                        {
                            ln = ln + rs[y].ToString() + " ";
                        }
                        box.Items.Add(ln);
                    }
                    SQLClose();
                }
                DatabeLogout();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //
        //****************************************************************
        // 
        // 結果をファイルに書き込み
        //
        //****************************************************************
        //
        public Boolean FileOutPut(string strSQL, string FileName, int x)
        {
            string ln;

            try
            {
                if (!login) DatabeLogin();
                if (SelectSQL(strSQL))
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(FileName);
                    while (rs.Read())
                    {
                        ln = "";
                        for (int y = 0; y < x; y++)
                        {
                            ln = ln + rs[y].ToString() + ",";

                        }

                        file.WriteLine(ln);
                    }
                    SQLClose();
                    file.Close();
                }
                DatabeLogout();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //

        //****************************************************************
        // 
        // 結果をListに追加する
        //
        //****************************************************************
        //
        public Boolean GetListAdd(string strSQL, List<string> DataList )
        {
            //string ln;
            int x;
            int y;
            try
            {
                if (!login) DatabeLogin();
                if (SelectSQL(strSQL))
                {
                    y = rs.FieldCount;
                    if (rs.Read())
                    {

                        DataList.Clear();
                        for (x = 0; x < y; x++)
                        {
                            DataList.Add(rs[x].ToString());
                        }
                    }

                }
                SQLClose();
                DatabeLogout();
                return (true);
            }
            catch (Exception e)
            {
                ErrorMSg = e.Message;
                DatabeLogout();
                return (false);
            }
        }
        //
        //
        //
        public DataTable SetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();
            if (!login) DatabeLogin();
            using (OracleCommand cmd = new OracleCommand(strSQL, cnn))
            {
                // DataAdapterの生成
                OracleDataAdapter da = new OracleDataAdapter(cmd);

                // データベースからデータを取得
                da.Fill(dt);

            }
            return dt;
        }
        //
        //


    }
}
