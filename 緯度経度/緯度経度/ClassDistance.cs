using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Device.Location;

namespace 緯度経度
{
    /// <summary>
    /// EXCEL
    ///  = 6371 * ACOS(COS(A2*PI()/180) * COS(A3*PI()/180) * COS(B3*PI()/180-B2*PI()/180) + SIN(A2*PI()/180) * SIN(A3*PI()/180) )
    /// </summary>
    static class ClassDistance
    {
        ///  <summary>
        /// 2点間の位置情報から距離を求める ///
        /// </summary>
        /// <returns></returns>
        static public double cal_distance5(double y1, double x1, double y2, double x2)
        {
            double RX = 6378.137; // 回転楕円体の長半径（赤道半径）[km]
            double RY = 6356.752; // 回転楕円体の短半径（極半径) [km]

            double p1 = Math.Atan(RY / RX * Math.Tan(y1)); // 地点Aの化成緯度
            double p2 = Math.Atan(RY / RX * Math.Tan(y2)); // 地点Bの化成緯度
            double X = Math.Acos(Math.Sin(p1) * Math.Sin(p2) + Math.Cos(p1) * Math.Cos(p2) * Math.Cos(x1 - x2)); // 球面上の距離
            double F = (RX - RY) / RX; // 扁平率
                                       // 距離補正量
            double dr = F / 8 * ((Math.Sin(X) - X) * Math.Pow((Math.Sin(p1)
                        + Math.Sin(p2)), 2.0) / Math.Pow(Math.Cos(X / 2), 2.0) - (Math.Sin(X) + X)
                        * Math.Pow((Math.Sin(p1) - Math.Sin(p2)), 2.0) / Math.Pow(Math.Sin(X / 2), 2.0));

            return RX * (X + dr); // 距離[km]
        }


        //double deg2rad(double deg)
        //{
        //    return deg * M_PI / 180.0;
        //  x1 :緯度
        //  x2 :経度
        //}
        static public double cal_distance2(double x1, double y1, double x2, double y2)
        {

            double RX = 6378.137; // 回転楕円体の長半径（赤道半径）[km]
            double RY = 6356.752; // 回転楕円体の短半径（極半径) [km]

            double p1 = Math.Atan(RY / RX * Math.Tan(y1)); // 地点Aの化成緯度
            double p2 = Math.Atan(RY / RX * Math.Tan(y2)); // 地点Bの化成緯度
            double X = Math.Acos(Math.Sin(p1) * Math.Sin(p2) + Math.Cos(p1) * Math.Cos(p2) * Math.Cos(x1 - x2)); // 球面上の距離
            double F = (RX - RY) / RX; // 扁平率
                                       // 距離補正量
            double dr = F / 8 * ((Math.Sin(X) - X) * Math.Pow((Math.Sin(p1) + Math.Sin(p2)), 2.0) / Math.Pow(Math.Cos(X / 2), 2.0) - (Math.Sin(X) + X) * Math.Pow((Math.Sin(p1) - Math.Sin(p2)), 2.0) / Math.Pow(Math.Sin(X / 2), 2.0));
            return RX * (X + dr); // 距離[km]

        }


        static public double cal_distance3(double x1, double y1, double x2, double y2)
        {
            double EARTH_RAD = 6378.137;
            return EARTH_RAD * Math.Acos(Math.Sin(y1) * Math.Sin(y2) + Math.Cos(y1) * Math.Cos(y2) * Math.Cos(x2 - x1));

        }
        static public double cal_distance4(double x1, double y1, double x2, double y2)
        {
            var distance = new GeoCoordinate(x1, y1).GetDistanceTo(new GeoCoordinate(x2, y2));
            return distance;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        static public double cal_distance6(double A2, double B2, double A3, double B3)
        {
            double ret;
            //ret = 6371 * Math.Acos(Math.Cos(x1 * Math.PI / 180) * Math.Cos(x2 * Math.PI / 180) * Math.Cos(y2 * Math.PI / 180 - y1 * Math.PI / 180) + Math.Sin(x1 * Math.PI / 180) * Math.Sin(y1 * Math.PI / 180));
            ret = 6371 * Math.Acos(Math.Cos(A2 * Math.PI / 180) * Math.Cos(A3 * Math.PI / 180) * Math.Cos(B3 * Math.PI / 180 - B2 * Math.PI / 180) + Math.Sin(A2 * Math.PI / 180) * Math.Sin(A3 * Math.PI / 180));
            return ret;
            
        }
    }
}