using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ArrayGenerator
{
    /// <summary>
    /// класс генератора массива случайных числе
    /// </summary>
    public class ArrayGenerator
    {
        /// <summary>
        /// рандомайзер
        /// </summary>
        static Random rand;

        /// <summary>
        /// статический конструктор генератора массивов случайных чисел
        /// </summary>
        static ArrayGenerator()
        {
            rand = new Random();
        }

        /// <summary>
        /// генерация файла представляющего собой массив случайных чисел
        /// </summary>
        /// <param name="n">количество элементов массива</param>
        /// <param name="max">максимальное значение элемента массива входящее в диапазон рандомайзера</param>
        /// <param name="filename">имя файла куда записываются значения элементов массива</param>
        /// <param name="txtLog">текстовой лог работы функции</param>
        /// <returns></returns>
        private bool GenerateArrayFile( uint n, int max, string filename, out string txtLog )
        {
            try
            {
                TextWriter tw = File.CreateText( filename );

                for (int i = 0; i < n; i++)
                {
                    int r = rand.Next( max + 1 );
                    tw.WriteLine( r );
                }

                tw.Close();
                txtLog = $"Создан файл: {filename}";
                return true;
            }
            catch (Exception e)
            {
                txtLog = e.Message;
                return false;
            }
        }

        /// <summary>
        /// чтение файла с элементами массива
        /// если файла нет - предварительная генерация файла
        /// </summary>
        /// <param name="n">количество элементов массива</param>
        /// <param name="filename">имя файла</param>
        /// <param name="txtLog">текстовой лог работы функции</param>
        /// <returns></returns>
        public int[] ReadArrayFile(uint n, string filename, out string txtLog )
        {
            int[] res = null;

            try
            {
                if (!(File.Exists(filename)))
                {
                    GenerateArrayFile( 100000, 100000, filename, out txtLog );
                }

                res = new int[n];

                TextReader tr = File.OpenText( filename );
                for (int i = 0; i < n; i++)
                {
                    res[i] = int.Parse( tr.ReadLine() );
                }

                tr.Close();
                txtLog = $"Прочитан файл: {filename}";
                return res;
            }
            catch (Exception e)
            {
                txtLog = e.Message;
                return res;
            }
        }

        /// <summary>
        /// вывод в консоль значений массива
        /// </summary>
        /// <param name="arr">массив</param>
        public void PrintArr( ref int[] arr )
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}