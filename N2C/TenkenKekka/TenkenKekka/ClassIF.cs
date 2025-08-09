using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.LinkLabel;
using TenkenKekka;

//#define n2c

namespace Syuyaku
{
    static public class ClassIF
    {
        //テーブル指定
        const string TableName = "v_tenken_kekka";

        //取り込みCSV指定
        //const string FileName = @"D:\01_Work\04_NR\06_点検センター\70_N2C対応\Data\N2OK001T.CSV";
        //const string FileName = @"C:\work\06_点検センター\70_N2C対応\Data\N2OK001T.CSV";
        public static string FileName = @"D:\work\Densou\N2OK001T.CSV";
        //

        //テーブルの列指定
        static string[] retumei =
        {
            "ＤＭ番号",
            "点検結果伝票番号",
            "受付ＮＯ",
            "メーカーＣＤ",
            "メーカー名",
            "製品名",
            "製造番号",
            "機器分類",
            "機器分類名",
                    "点検製品区分","点検製品区分名",
                    "点検製品区分詳細","点検製品区分詳細名",
                    "廃棄延長識別","廃棄延長識別名",
                    "点検項目ＣＤ＿法１","点検項目名＿法１","点検結果＿法１","点検結果名＿法１","点検説明＿法１",
                    "点検項目ＣＤ＿法２","点検項目名＿法２","点検結果＿法２","点検結果名＿法２","点検説明＿法２",
                    "点検項目ＣＤ＿法３","点検項目名＿法３","点検結果＿法３","点検結果名＿法３","点検説明＿法３",
                    "点検項目ＣＤ＿法４","点検項目名＿法４","点検結果＿法４","点検結果名＿法４","点検説明＿法４",
                    "点検項目ＣＤ＿法５","点検項目名＿法５","点検結果＿法５","点検結果名＿法５","点検説明＿法５",
                    "点検項目ＣＤ＿法６","点検項目名＿法６","点検結果＿法６","点検結果名＿法６","点検説明＿法６",
                    "点検項目ＣＤ＿法７","点検項目名＿法７","点検結果＿法７","点検結果名＿法７","点検説明＿法７",
                    "点検項目ＣＤ＿法８","点検項目名＿法８","点検結果＿法８","点検結果名＿法８","点検説明＿法８",
                    "点検項目ＣＤ＿法９","点検項目名＿法９","点検結果＿法９","点検結果名＿法９","点検説明＿法９",
                    "点検項目ＣＤ＿法１０","点検項目名＿法１０","点検結果＿法１０","点検結果名＿法１０","点検説明＿法１０",
                    "点検項目ＣＤ＿法１１","点検項目名＿法１１","点検結果＿法１１","点検結果名＿法１１","点検説明＿法１１",
                    "点検項目ＣＤ＿法１２","点検項目名＿法１２","点検結果＿法１２","点検結果名＿法１２","点検説明＿法１２",
                    "点検項目ＣＤ＿法１３","点検項目名＿法１３","点検結果＿法１３","点検結果名＿法１３","点検説明＿法１３",
                    "点検項目ＣＤ＿法１４","点検項目名＿法１４","点検結果＿法１４","点検結果名＿法１４","点検説明＿法１４",
                    "点検項目ＣＤ＿法１５","点検項目名＿法１５","点検結果＿法１５","点検結果名＿法１５","点検説明＿法１５",
                    "点検項目ＣＤ＿法１６","点検項目名＿法１６","点検結果＿法１６","点検結果名＿法１６","点検説明＿法１６",
                    "点検項目ＣＤ＿法１７","点検項目名＿法１７","点検結果＿法１７","点検結果名＿法１７","点検説明＿法１７",
                    "点検項目ＣＤ＿法１８","点検項目名＿法１８","点検結果＿法１８","点検結果名＿法１８","点検説明＿法１８",
                    "点検項目ＣＤ＿法１９","点検項目名＿法１９","点検結果＿法１９","点検結果名＿法１９","点検説明＿法１９",
                    "点検項目ＣＤ＿法２０","点検項目名＿法２０","点検結果＿法２０","点検結果名＿法２０","点検説明＿法２０",
                    "点検項目ＣＤ＿法２１","点検項目名＿法２１","点検結果＿法２１","点検結果名＿法２１","点検説明＿法２１",
                    "点検項目ＣＤ＿法２２","点検項目名＿法２２","点検結果＿法２２","点検結果名＿法２２","点検説明＿法２２",
                    "点検項目ＣＤ＿自１","点検項目名＿自１","点検結果＿自１","点検結果名＿自１","点検説明＿自１",
                    "点検項目ＣＤ＿自２","点検項目名＿自２","点検結果＿自２","点検結果名＿自２","点検説明＿自２",
                    "点検項目ＣＤ＿自３","点検項目名＿自３","点検結果＿自３","点検結果名＿自３","点検説明＿自３",
                    "点検項目ＣＤ＿自４","点検項目名＿自４","点検結果＿自４","点検結果名＿自４","点検説明＿自４",
                    "点検項目ＣＤ＿自５","点検項目名＿自５","点検結果＿自５","点検結果名＿自５","点検説明＿自５",
                    "点検項目ＣＤ＿自６","点検項目名＿自６","点検結果＿自６","点検結果名＿自６","点検説明＿自６",
                    "点検項目ＣＤ＿自７","点検項目名＿自７","点検結果＿自７","点検結果名＿自７","点検説明＿自７",
                    "点検項目ＣＤ＿自８","点検項目名＿自８","点検結果＿自８","点検結果名＿自８","点検説明＿自８",
                    "点検項目ＣＤ＿自９","点検項目名＿自９","点検結果＿自９","点検結果名＿自９","点検説明＿自９",
                    "点検項目ＣＤ＿自１０","点検項目名＿自１０","点検結果＿自１０","点検結果名＿自１０","点検説明＿自１０",
                    "点検項目ＣＤ＿自１１","点検項目名＿自１１","点検結果＿自１１","点検結果名＿自１１","点検説明＿自１１",
                    "点検項目ＣＤ＿自１２","点検項目名＿自１２","点検結果＿自１２","点検結果名＿自１２","点検説明＿自１２",
                    "点検項目ＣＤ＿自１３","点検項目名＿自１３","点検結果＿自１３","点検結果名＿自１３","点検説明＿自１３",
                    "点検項目ＣＤ＿自１４","点検項目名＿自１４","点検結果＿自１４","点検結果名＿自１４","点検説明＿自１４",
                    "点検項目ＣＤ＿自１５","点検項目名＿自１５","点検結果＿自１５","点検結果名＿自１５","点検説明＿自１５",
                    "点検項目ＣＤ＿自１６","点検項目名＿自１６","点検結果＿自１６","点検結果名＿自１６","点検説明＿自１６",
                    "点検項目ＣＤ＿清掃１","点検項目名＿清掃１","点検結果＿清掃１","点検結果名＿清掃１","点検説明＿清掃１",
                    "一酸化炭素濃度＿給湯","一酸化炭素濃度＿ふろ",
                    "一酸化炭素濃度＿給湯＿暖房",
                    "一酸化炭素濃度未測定理由",
                    "ＣＯ燃焼時間",
                    "燃焼回数",
                    "燃焼時間",
                    "運転時間",
                    "運転回数",
                    "安全装置１有無","安全装置１名",
                    "安全装置２有無","安全装置２名",
                    "安全装置３有無","安全装置３名",
                    "安全装置４有無","安全装置４名",
                    "安全装置５有無","安全装置５名",
                    "安全装置６有無","安全装置６名",
                    "安全装置７有無","安全装置７名",
                    "安全装置８有無","安全装置８名",
                    "安全装置９有無","安全装置９名",
                    "安全装置１０有無","安全装置１０名",
                    "安全装置１１有無","安全装置１１名",
                    "安全装置１２有無","安全装置１２名",
                    "安全装置１３有無","安全装置１３名",
                    "安全装置１４有無","安全装置１４名",
                    "安全装置１５有無","安全装置１５名",
                    "フィルタ付パッキンの交換有無",
                    "フィルタ付パッキンの交換名",
                    "点検お知らせ機能有無",
                    "点検お知らせ機能名",
                    "点検済みシール貼り付け有無",
                    "点検済みシール貼り付け名",
                    "総合判定種別",
                    "総合判定名",
                    "修理受付有無種別",
                    "修理受付有無名",
                    "使用禁止ラベル貼付識別",
                    "使用禁止ラベル貼付名",
                    "使用禁止説明実施種別",
                    "使用禁止説明実施名",
                    "使用禁止処置無し理由",
                    "受付日","点検完了日",
                    "店コード","サービスマンコード","サービスマン名","資格番号",
                    "業務区分","業務区分名","第２業務区分","第２業務区分名",
                    "特定製造事業者コード","特定製造事業者名",
                    "製造年月"
        };
        //static string csvFileName = string.Empty;

        static public void csvINsert()
        {
            string sql1 = "";
            string sql2 = "";
            string sql3 = "";
            //string ukno = "";
            int cnt;
            int sousinsuu = 0;


            Console.WriteLine(FileName); 
            System.Windows.Forms.Application.DoEvents();

            try
            {
                if (!File.Exists(FileName))
                {
                    ClassLog.LogWrite("ファイルが存在しません");
                    return;
                }
                  ClassLog.LogDelete();
                int ukeno = GetHairetu("受付ＮＯ");

                int cimno1 = GetHairetu("点検完了日");

                ClassNpgsql.DbOpen(1);

                var parser = new TextFieldParser(FileName, System.Text.Encoding.GetEncoding("UTF-8"));
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
                    var lists = parser.ReadFields();
                    while (!parser.EndOfData)
                    {

                        var line = new List<string>();
                        lists = parser.ReadFields();
                        /* */

                        lists[cimno1] = HiHenkan(lists[cimno1]);

                        cnt = 0;
                        sql1 = $@"insert into {ClassNpgsql.scima}{TableName} (";
                        sql2 = $@")values( ";
                        sql3 = $@")ON CONFLICT(受付ＮＯ) DO UPDATE SET ";
                        foreach (string value in lists)
                        {
                            if (retumei[cnt] != "")
                            {
                                if (cnt == 0)
                                {
                                    sql1 += retumei[cnt];
                                    sql2 += "'" + value.Trim() + "'";
                                    sql3 += retumei[cnt] + " = EXCLUDED." + retumei[cnt];
                                }
                                else
                                {       
                                    sql1 += "," + retumei[cnt];
                                    sql2 += ",'" + value.Trim() + "'";
                                    if (cnt != ukeno )
                                    {
                                        sql3 += "," + retumei[cnt] + " = EXCLUDED." + retumei[cnt];
                                    }
                                }
                            }
                            cnt++;
                        }
                        sql1 += ",newflg";
                        sql2 += ",1";
                        sql3 += ",newflg = v_tenken_kekka.newflg + 1 ;";

                        ClassLog.LogWrite(""  + sql1 );
                        ClassLog.LogWrite(" " + sql2 );
                        ClassLog.LogWrite(" " + sql3 + "\n");
                        Console.WriteLine(lists[ukeno].ToString());
                        System.Windows.Forms.Application.DoEvents();

                        ClassNpgsql._EXEC(sql1 + sql2 + sql3);
                        //
                        sousinsuu++;

                    }
                }
                ClassNpgsql.trans.Commit();
                ClassNpgsql.DbClose();
                ClassLog.LogWriteTB("点検結果", sousinsuu);

            }
            catch (Exception ex)
            {
                ClassLog.LogWrite(ex.Message);
                ClassNpgsql.trans.Rollback();
                ClassNpgsql.DbClose();
                ClassLog.logwriteErrTB("点検結果");
            }
        }
        //
        static private int GetHairetu(string nm)
        {
            List<string> lists = new List<string>();
            lists.AddRange(retumei);
            int num = lists.IndexOf(nm);
            return num;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        static private string HiHenkan(string buf)
        {
            DateTime dy;
            try
            {
                switch (buf.Length)
                {
                    case 18:
                        buf = buf.Substring(0, 10) + " " + buf.Substring(10, 8);
                        dy = DateTime.Parse(buf);
                        return dy.ToString("yyyy/MM/dd HH:mm:ss");

                    case 10:
                        buf = buf.Substring(0, 10);
                        dy = DateTime.Parse(buf);
                        return dy.ToString("yyyy/MM/dd");
                }
                return buf;
            }
            catch (Exception ex)
            {

                return buf;
            }
        }
    }
}
