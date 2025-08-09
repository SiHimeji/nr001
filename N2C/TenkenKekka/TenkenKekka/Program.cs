using Syuyaku;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace TenkenKekka
{

    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ClassIF.FileName = args[0]; 
            }
            ClassIF.csvINsert();
        }
    }
}
