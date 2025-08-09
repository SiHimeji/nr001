using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syuyaku;

namespace Seikyu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                {
                    ClassIF.FileName = args[0];
                }
                ClassIF.csvINsert();
            }
        }
    }
}
