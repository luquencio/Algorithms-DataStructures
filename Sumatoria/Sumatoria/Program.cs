using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumatoria
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> L = new List<int>();

            for (int i = 1; i < 100; i++)
            {
                L.Add(i);
            }

            int[] s = new int[100];
                
               s = L.ToArray();

            Console.Write("{0}", s[100]);


            Console.ReadKey();
        }
    }
}
