using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;　//COM 追加

namespace 緯度経度
{
    static public class ClassEXCEL
    {



        static public void Excel(string filename, System.Windows.Forms.TextBox tx)
        {

            double shop_ido = 0;
            double shop_keido = 0;
            double ido = 0;
            double keido = 0;
            double km = 0;
            int y = 2;
            string buf;
            //' EXCEL関連オブジェクトの定義
            Microsoft.Office.Interop.Excel.Application app = null;
            Microsoft.Office.Interop.Excel.Workbook book = null;
            Microsoft.Office.Interop.Excel.Worksheet sheet = null;
            Microsoft.Office.Interop.Excel.Range Range = null;

            app = new Microsoft.Office.Interop.Excel.Application();
            book=  app.Workbooks.Open(filename);
            sheet = book.Worksheets[1];

            app.Visible = true;        
            buf = sheet.Cells[y, 1].value;

            while (  buf  !="" || buf != null) {

                buf = ( sheet.Cells[y, 4].value).ToString();    
                shop_keido = double.Parse(buf);

                buf = (sheet.Cells[y, 5].value).ToString(); ;
                shop_ido = double.Parse(buf);

                buf = (sheet.Cells[y, 3].value).ToString(); ;
                ido = double.Parse(buf);

                buf = (sheet.Cells[y, 5].value).ToString(); ;
                keido = double.Parse(buf);

                km = Math.Round(ClassDistance.cal_distance4(shop_ido, shop_keido, ido, keido) / 1000, 3);

                sheet.Cells[y, 6].value = km.ToString();

                y++;
                tx.Text=y.ToString();
                System.Windows.Forms.Application.DoEvents();
                buf = sheet.Cells[y, 1].value;
            }

            book.Save();
            book.Close();

            // EXCEL解放
            Marshal.ReleaseComObject(Range);
            Marshal.ReleaseComObject(book);
            Marshal.ReleaseComObject(app);
            Marshal.ReleaseComObject(sheet);
            Range = null;
            sheet = null;
            book = null;
            app = null;
            MessageBox.Show("END");
        }

    }
}
