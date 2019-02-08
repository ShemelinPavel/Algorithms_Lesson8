/*

Shemelin Pavel

2

Реализовать быструю сортировку

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    using ArrayGenerator;

    class Program
    {
        /*
        int pivot = array[p];
        int i = p - 1;
        int j = r + 1;

        while (true) {

            do {
                i++;
            }
            while (array[i] < pivot);

            do {
                j--;
            }
            while (array[j] > pivot);

            if (i<j) {
                swap( array, i, j);
            } else {
                return j;
            }
        }
        */
        
        /// <summary>
        /// разбиение Хоара
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="loIndex">начальный индекс</param>
        /// <param name="hiIndex">конечный индекс</param>
        /// <returns>индекс опорного элемента</returns>
        static int SeparateHoare( ref int[] arr, int loIndex, int hiIndex )
        {
            int part = arr[loIndex];
            int i = loIndex - 1;
            int j = hiIndex + 1;

            void Swap( ref int[] a, int x, int y )
            {
                int tmp = a[x];
                a[x] = a[y];
                a[y] = tmp;
            }

            while (true)
            {

                do
                {
                    i++;
                } while (arr[i] < part);

                do
                {
                    j--;
                } while (arr[j] > part);

                if (i >= j)
                {
                    return j;
                }
                Swap( ref arr, i, j );
            }

        }

        /// <summary>
        /// быстрая сортировка
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="loIndex">начальный индекс</param>
        /// <param name="hiIndex">конечный индекс</param>
        static void QuickSort( ref int[] arr, int loIndex, int hiIndex )
        {
            if (loIndex < hiIndex)
            {
                int partMemberIndex = SeparateHoare( ref arr, loIndex, hiIndex );
                QuickSort( ref arr, loIndex, partMemberIndex );
                QuickSort( ref arr, partMemberIndex + 1, hiIndex );
            }
        }

        static void Main( string[] args )
        {

            ArrayGenerator ar = new ArrayGenerator();

            int[] arr = ar.ReadArrayFile( 100000, "array.txt", out string log );

            DateTime dateStart = DateTime.Now;

            QuickSort( ref arr, 0, arr.Length - 1 );

            DateTime dateFinish = DateTime.Now;

            TimeSpan interval = dateFinish - dateStart;

            Console.WriteLine();
            Console.WriteLine( interval.TotalMilliseconds );

            Console.ReadKey();
        }
    }
}
