using spClassOracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 緯度経度
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void eXCLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Worksheets|*.xlsx;*.xls";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;

                    ClassEXCEL.Excel(filename,textBoxKyori);
                }
            }
        }

        private void oRACLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double km = 0;
            double shop_keido, shop_ido, keido, ido;
            ClassOracle classOracle = new ClassOracle();
            classOracle.SetDatabe();
            string strSQL = $@"
                        select city_section_cd,
                               j_ido8,
                               j_keido8,
                               shop_keido,
                               shop_ido,
                               km
                      from tb_idokeido2
						where ( km is null or km ='')
						and  j_ido8 is not null
						and shop_cd is not null
					";
            /*
                     where tb_idokeido2.city_section_cd8 is not null
                           and  tb_idokeido2.km is null
                           and  tb_idokeido2.j_ido8 is not null
                           and  tb_idokeido2.j_keido8 is not null
                           and  tb_idokeido2.shop_cd is not null
                           and  substr(tb_idokeido2.city_section_cd,1,2) in ('46','47','48','44','45')
                order by city_section_cd
                           ";
*/
            DataTable dt = null;
            dt = classOracle.SetDataTable(strSQL);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["shop_keido"].ToString().Trim() != "")
                {
                    if ( dr["j_ido8"].ToString().Trim() != "") {

                        shop_keido = double.Parse(dr["shop_keido"].ToString());
                        shop_ido = double.Parse(dr["shop_ido"].ToString());
                        ido = double.Parse(dr["j_ido8"].ToString());
                        keido = double.Parse(dr["j_keido8"].ToString());
                        km = Math.Round(  ClassDistance.cal_distance4(shop_ido, shop_keido,ido, keido) /1000,3);

                    this.textBoxIdoFrom.Text = shop_ido.ToString();
                    this.textBoxKeidoFrom.Text = shop_keido.ToString();
                    this.textBoxKeidoTo.Text = keido.ToString();
                    this.textBoxIdoTo.Text = ido.ToString();


                    strSQL = $@"update tb_idokeido2 set km ='{km.ToString()}' where city_section_cd='{dr["city_section_cd"].ToString()}'";
                    classOracle.execSQL(strSQL);

                    this.textBoxKyori.Text = km.ToString();
                    System.Windows.Forms.Application.DoEvents();

                    }
                }

            }

        }

        private void sLserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double km = 0;
            double shop_keido, shop_ido, keido, ido;

            this.textBoxken.Text = "0";
            this.textBox1.Text = "0";
            string strSQL = $@"
                    select  TB_IDOKEIDO.city_section_cd
                        ,TB_IDOKEIDO.j_ido    j_ido
                        ,TB_IDOKEIDO.j_keido  j_keido
                        ,TB_SHOP_IDO.j_ido    s_ido
                        ,TB_SHOP_IDO.j_keido  s_keido 
                        from TB_IDOKEIDO 
                            left outer join TB_SHOP_IDO on TB_SHOP_IDO.SHOP_CD  = TB_IDOKEIDO.SHOP_cd
                            where TB_SHOP_IDO.j_keido is not null
                            and     trim(TB_IDOKEIDO.j_ido) <> ''
                            and     trim(TB_IDOKEIDO.j_keido) <> ''                            
                            and     trim(TB_SHOP_IDO.j_ido) <> ''
                            and     trim(TB_SHOP_IDO.j_keido) <> ''
                            and     TB_IDOKEIDO.shop_cd  is not null 
                            and     TB_IDOKEIDO.abolition_ym ='000000'
                            and   TB_IDOKEIDO.km2  is null
                        ORDER  by TB_IDOKEIDO.city_section_cd
";

            SqlTransaction trans = null;
            DataTable dt = new DataTable();

            if (SqlSeverControl.DbConnect())
            {
                if (SqlSeverControl.ExecuteSqlSelectQuery(strSQL, ref dt, null))
                {
                    SqlSeverControl.DbDisConnect();
                }
            }
            if (dt.Rows.Count > 0)
            {
                try
                {
                    if (SqlSeverControl.DbConnect())
                    {
                        trans = SqlSeverControl.sCon.BeginTransaction();

                        foreach (DataRow dr in dt.Rows)
                        {

                            shop_keido = double.Parse(dr["s_keido"].ToString());
                            shop_ido = double.Parse(dr["s_ido"].ToString());
                            ido = double.Parse(dr["j_ido"].ToString());
                            keido = double.Parse(dr["j_keido"].ToString());

                            this.textBoxIdoFrom.Text = shop_ido.ToString();
                            this.textBoxKeidoFrom.Text = shop_keido.ToString();
                            this.textBoxKeidoTo.Text = keido.ToString();
                            this.textBoxIdoTo.Text = ido.ToString();



                            if (shop_keido != 0 && shop_ido !=0 && ido!=0 && keido !=0)
                            {
                                //km = Math.Round(ClassDistance.cal_distance4(shop_ido, shop_keido, ido, keido) / 1000, 3);
                                km = Math.Round(ClassDistance.cal_distance6( ido, keido, shop_ido, shop_keido) , 3);
                            }
                            else
                            {
                                km = 0;
                            }
                            this.textBoxKyori.Text = km.ToString();
                            this.textBoxken.Text = (decimal.Parse(this.textBoxken.Text) + 1).ToString();
                            if (this.textBoxken.Text == "10000")
                            {
                                trans.Commit();

                                trans = SqlSeverControl.sCon.BeginTransaction();
                                this.textBox1.Text = (decimal.Parse(this.textBox1.Text) + 1).ToString();
                                this.textBoxken.Text = "0";

                            }

                            strSQL = $@"update TB_IDOKEIDO set km2 ='{km.ToString()}' where city_section_cd ='{dr["city_section_cd"].ToString()}'";
                            SqlSeverControl.ExecuteSqlQuery(strSQL, trans);
                            Application.DoEvents();

                        }
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    trans.Rollback();
                }
                SqlSeverControl.DbDisConnect();
                MessageBox.Show("END");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
