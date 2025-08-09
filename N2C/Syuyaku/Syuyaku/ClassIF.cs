using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using static System.Windows.Forms.LinkLabel;
using System.Security.AccessControl;
using TenkenKekka;
namespace Syuyaku
{
    static public class ClassIF
    {
        //テーブル指定
        const string TableName = "v_yuryo_tenken_syuyaku";

        //取り込みCSV指定
        //const string FileName = "D:\\01_Work\\04_NR\\06_点検センター\\70_N2C対応\\Data\\N2OK002T.csv";
        //const string FileName = "C:\\work\\06_点検センター\\70_N2C対応\\ソース\\N2OK002T.csv";
        public static string FileName =  $@"D:\work\Densou\N2OK002T.csv";
        //
        //テーブルの列指定
        static string[] retumei = {
 "所有者登録意思区分"
,"所有者登録意思区分名"
,"ｄｍ番号"
,"点検台帳登録区分"
,"点検台帳登録区分名称"
,"所有者票ブランド"
,"所有者票ブランド名称"
,"製品名_通知"
,"製品名_完了"
,"製造番号_通知"
,"製造番号_完了"
,"点検開始年月"
,"点検終了年月"
,"点検通知種類"
,"点検通知種類名称"
,"点検通知年月"
,"ステータス"
,"ステータス名"
,"点検受付番号"
,"点検受付日"
,"点検完了日"
,"フロント承認日"
,"受付区分"
,"受付区分名称"
,"点検状態区分"
,"点検状態区分名称"
,"顧客id"
,"都道府県名"
,"市区町村名"
,"技術料"
,"出張料"
,"その他料金"
,""
,""
,"未着回数"
,"保証規定区分コード"
,"保証規定区分"
,"承認番号"
,"責任部門コード"
,"責任部門"
,"設計標準使用期間"
,"システム詳細区分"
,"システム詳細区分名"
,"表示解除区分"
,"表示解除方法通知日"
,"担当shopコード"
,"担当サービスマン"
,"所有者票顧客id"
,"回収金額"
,"集計基準日"
,"メーカーコード"
,"メーカー"
,"点検完了受付日"
,"製造年月"
,"所有者有無"
,"故障表示1"
,"回収予定日"
,"回収完了日"
,"tc店略称"
,"店略称"
,"キャンセル"
,"受付店"
,"受付者"
,"修理状況"
,"修理状況名称"
,"サポート料"
,"付帯金額"
,"値引き"
,"消費税額"
,"請求合計金額"
,"点検結果伝票番号"
,"機器分類"
,"回収区分コード"
,"回収区分"
,"請求回収区分変更理由"
,"契約_安心プラン"
,"契約番号"
,"開始日"
,"第１業務区分"
,"第１業務区分内容"
,"第２業務区分"
,"第２業務区分内容"
,"無償部品代"
,"無償出張料"
,"無償技術料"
,"無償出張料差額"
,"メーカー保証諸経費"
,"メーカー負担諸経費"
,"無償合計"
,"依頼元名"
,"依頼元カナ"
,"依頼元会社"
,"依頼元電話"
,"請求先名"
,"請求先カナ"
,"請求先会社"
,"請求先電話"
,"価格指示理由"
,"都道府県コード"
,"市区町村名コード"
,"更新日"
,"請求先部署"
,"請求先宛名"
,"請求先担当"
,"請求先住所"
,"サービスマン名"
,"注文no"
,"修理完了日"
,"新ステータス"
,"新ステータス名称"
,"マイページ連携仮id"
,"マイページ連携仮pw"
,"マイページid"
,"依頼元コード"
,"訪問先会社名"
,"訪問先部署"
,"訪問先氏名担当者"
,"訪問先氏名担当者カナ"
,"訪問先電話番号"
,"製造番号不明理由"
,"製造番号不明理由内容"
,"訪問予定日１"
,"依頼元fax番号"
,"無償承認日"
,"町域"
,"番地"
,"建物"
,"部屋"
,"cim番号"
,"ｄｍ番号id"
,"tc店略称id"
,"受付店Id"
,"受付者Id"
,"伝達事項"
                };

        static int[] NitiJi = new int[20];
        static int[] Suuji = new int[20];

        static public void csvINsert()
        {

            ClassLog.LogDelete();

            if (!File.Exists(FileName))
            {
                ClassLog.LogWrite("ファイルが存在しません");
                return;
            }


            int x;
            for (x = 0; x < 20; x++)
            {
                NitiJi[x] = -1;
                Suuji[x] = -1;
            }
            ////
            
            string sql0 = "";
            string sql1 = "";
            string sql2 = "";
            int cnt;
            int sousinsu=0;
            try
            {
                int ukeno = GetHairetu("点検受付番号");
                int goukei= GetHairetu("請求合計金額");
                int tax = GetHairetu("消費税額");

                x = 0;
                NitiJi[x++] = GetHairetu("製造年月");
                NitiJi[x++] = GetHairetu("更新日");
                NitiJi[x++] = GetHairetu("修理完了日");
                NitiJi[x++] = GetHairetu("無償承認日");
                NitiJi[x++] = GetHairetu("点検通知年月");

                NitiJi[x++]= GetHairetu("点検開始年月");
                NitiJi[x++] = GetHairetu("点検終了年月");
                NitiJi[x++] = GetHairetu("点検受付日");
                NitiJi[x++] = GetHairetu("点検完了日");
                NitiJi[x++] = GetHairetu("フロント承認日");
                NitiJi[x++] = GetHairetu("表示解除方法通知日");
                NitiJi[x++] = GetHairetu("集計基準日");
                NitiJi[x++] = GetHairetu("点検完了受付日");
                NitiJi[x++] = GetHairetu("訪問予定日１");
                NitiJi[x++] = GetHairetu("開始日");
                NitiJi[x++] = GetHairetu("回収予定日");
                NitiJi[x++] = GetHairetu("回収完了日");

                
                x = 0;
                Suuji[x++] = GetHairetu("技術料");
                Suuji[x++] = GetHairetu("出張料");
                Suuji[x++] = GetHairetu("その他料金");
                Suuji[x++] = GetHairetu("サポート料");
                Suuji[x++] = GetHairetu("値引き");
                Suuji[x++] = GetHairetu("付帯金額");

                Suuji[x++] = GetHairetu("消費税額");
                Suuji[x++] = GetHairetu("請求合計金額");


                Suuji[x++] = GetHairetu("無償部品代");
                Suuji[x++] = GetHairetu("無償出張料");
                Suuji[x++] = GetHairetu("無償技術料");
                Suuji[x++] = GetHairetu("無償出張料差額");
                Suuji[x++] = GetHairetu("無償合計");
                Suuji[x++] = GetHairetu("メーカー保証諸経費");
                Suuji[x++] = GetHairetu("メーカー負担諸経費");

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

                    //GetHairetu("点検受付番号");
                    // ファイルの終端までループ
                    var lists = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        var line = new List<string>();
                        lists = parser.ReadFields();

                        for (x = 0; NitiJi.Length > x; x++)
                        {
                            if (NitiJi[x] != -1)
                            {
                                lists[NitiJi[x]] = HiHenkan(lists[NitiJi[x]], x, retumei[NitiJi[x]]);
                            }
                        }

                        for (x = 0; Suuji.Length > x; x++)
                        {
                            if (Suuji[x] != -1) 
                            {
                                lists[Suuji[x]] = SuujiCheck(lists[Suuji[x]]);                                
                            }
                        }

                        cnt = 0;
                        sql1 = $@"insert into {ClassNpgsql.scima}{TableName} (";
                        sql2 = $@")values( ";
                        foreach (string value in lists)
                        {
                            if (retumei[cnt] != "")
                            {
                                if (cnt == 0)
                                {
                                    sql1 += retumei[cnt];
                                    sql2 += "'" + value.Trim() + "'"; //.Replace("　", "").Replace(" ", "")
                                }
                                else
                                {
                                    sql1 += "," + retumei[cnt];
                                    sql2 += ",'" + value.Trim()+ "'"; //.Replace("　", "").Replace(" ", "") 
                                }
                            }
                            cnt++;
                        }
                        sql1 += ",点検料金,newflg";

                        sql2 += $@",{lists[goukei]}-{lists[tax]} ,'1'";
                        sql0 = sql1 + sql2 + ")";
                        sql0 += " ON CONFLICT (点検受付番号) ";
                        sql0 += " DO UPDATE SET ";
                        cnt = 0;
                        foreach (string value in lists)
                        {
                            if (retumei[cnt] != "")
                            {
                                if (cnt == 0)
                                {
                                    //sql0 += retumei[cnt] + "= '" + value.Trim().Replace("　", "").Replace(" ", "") + "'";
                                    sql0 += retumei[cnt] + " = EXCLUDED." + retumei[cnt] + "";
                                }
                                else
                                {
                                    if (cnt != ukeno)
                                    {
                                        //sql0 += "," + retumei[cnt] + "= '" + value.Trim().Replace("　", "").Replace(" ", "") + "'";
                                        sql0 += "," + retumei[cnt] + "= EXCLUDED." + retumei[cnt] + "";
                                    }
                                }
                            }
                            cnt++;
                        }
                        sql0 += $@",点検料金 ={lists[goukei]}-{lists[tax]}, newflg = v_yuryo_tenken_syuyaku.newflg + 1 ;";
                    ClassLog.LogWrite(sql0);
                    Console.WriteLine(lists[ukeno].ToString());
                    System.Windows.Forms.Application.DoEvents();

                    ClassNpgsql._EXEC(sql0);
                    sousinsu++;
                    //
                    }
                }

                ClassNpgsql.trans.Commit();
                ClassNpgsql.DbClose();
                //ClassLog.LogWriteTB("集約データ", sousinsu);
            }
            catch (Exception ex)
            {
                ClassLog.LogWrite(ex.Message);
                ClassNpgsql.trans.Rollback();
                ClassNpgsql.DbClose();
                ClassLog.logwriteErrTB("集約データ");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nm"></param>
        /// <returns></returns>
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
        static private string HiHenkan(string buf,int x,string re)
        {
            string ret;
            try
            {
                switch (buf.Length)
                {

                    case 18:
                        buf = buf.Substring(0, 10) + " " + buf.Substring(10, 8);
                        ret = buf.Replace("-", "/");
                        break;
                    default:
                        ret = buf.Replace("-", "/");
                        break;

                }
                //Console.WriteLine(x.ToString() +" : "+re +" : "+ buf +" -> " + ret);

                return ret;
            }
            catch (Exception ex) {
                ClassLog.LogWrite(ex.Message);

                return "";
            }
        }

        static private string SuujiCheck(string buf)
        {

            bool isInteger = int.TryParse(buf, out int result);
            if (isInteger)
            {
                return buf;
            }
            return "0";
        }

    }
}
