/*

Shemelin Pavel

1

Реализовать сортировку подсчетом

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace Task1
{
    using ArrayGenerator;

    class Program
    {
        static void Main( string[] args )
        {
            ArrayGenerator ar = new ArrayGenerator();

            const int maxNum = 100001;

            int[] arr = ar.ReadArrayFile( 100000, "array.txt", out string log );

            //вспомогательный массив
            int[] supportArr = new int[maxNum];

            DateTime dateStart = DateTime.Now;

            for (int i = 0; i < arr.Length; i++)
            {
                supportArr[arr[i]] = supportArr[arr[i]] + 1;
            }

            int b = 0;
            for (int j = 0; j < maxNum; j++)
            {
                for (int i = 0; i < supportArr[j]; i++)
                {
                    arr[b] = j;
                    b++;
                }
            }

            DateTime dateFinish = DateTime.Now;

            TimeSpan interval = dateFinish - dateStart;

            Console.WriteLine();
            Console.WriteLine( interval.TotalMilliseconds );

            Console.ReadKey();
        }
    }
}
