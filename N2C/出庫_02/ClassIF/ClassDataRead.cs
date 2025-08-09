using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
//using Microsoft.Office.Core;
//using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using Npgsql.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
namespace ClassIF
{
    public static class ClassDataRead
    {
        public static System.Data.DataTable ReadCsv(string FileName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            var parser = new TextFieldParser(FileName, System.Text.Encoding.GetEncoding("UTF-8"));
            //var parser = new TextFieldParser(FileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            using (parser)
            {
                //  区切りの指定
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                // フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = true;
                // フィールドの空白トリム設定
                parser.TrimWhiteSpace = false;
                // ファイルの終端までループ
                //var lists = parser.ReadFields();
                string[] headers = parser.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                } 
                while (!parser.EndOfData) {

                    string[] rows = parser.ReadLine().Split(',');
                    DataRow dataRow = dt.NewRow();

                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataRow[i] = rows[i];
                    }

                    dt.Rows.Add(dataRow);

                }
            }
            return dt;
        }
        //
        //
        public static System.Data.DataTable ReadExcel(string FileName ,int retu)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            int ro = 1;
            int cl = 1;

            using (var workbook = new XLWorkbook(FileName))
            {
                IXLCell cell;
                var worksheet = workbook.Worksheet(1); // 最初のシート
                while (worksheet.Cell(ro++, 1).GetValue<string>() != "") {}
                while (worksheet.Cell(1, cl++).GetValue<string>() != ""){}

                for (int c = 1; c < cl-1; c++)
                {
                    string header = worksheet.Cell(1, c).GetValue<string>();
                    dt.Columns.Add(header);
                }

                for (int row = retu; row <= ro-1; row++)
                {
                    DataRow dataRow = dt.NewRow();

                    for (int c = 1; c < cl-1; c++)
                    {
                        if ((worksheet.Cell(row, c).GetValue<string>()) != null)
                        {
                            cell=worksheet.Cell(row, c);

                            if (String.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dataRow[c-1] = "";

                            }
                            else
                            {
                                dataRow[c-1]=cell.Value;
                            }

                            //dataRow[c] = worksheet.Cell(row, c).GetValue<string>();
                        }
                    }
                    dt.Rows.Add(dataRow);
                }
            }
            return dt;
        }
    }
}
