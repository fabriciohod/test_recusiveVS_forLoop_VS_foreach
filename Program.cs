using System.Diagnostics;
using System;

namespace App1
{
    class Program
    {
        static void Main()
        {
            Int16[] array = new short[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            // BenchMark[0] = Recursive function
            // BenchMark[1] = ForLoop
            // BenchMark[2] = Foreach
            Stopwatch[] BenchMark = new Stopwatch[3];

            // instanciando os obj´s
            for (Int16 i = 0; i < BenchMark.Length; i++)
            {
                BenchMark[i] = new Stopwatch();
            }

            #region Recursive
            BenchMark[0].Start();
            LoopRecursive(array, 0);
            BenchMark[0].Stop();
            System.Console.WriteLine($"Tempo recursivo: {BenchMark[0].Elapsed} | {BenchMark[0].ElapsedTicks}");
            #endregion

            #region ForLoop
            BenchMark[1].Start();
            ForLoop(array);
            BenchMark[1].Stop();
            System.Console.WriteLine($"Tempo com o for: {BenchMark[1].Elapsed} | {BenchMark[1].ElapsedTicks}");
            #endregion

            #region Foreach
            BenchMark[2].Start();
            ForeachLoop(array);
            BenchMark[2].Stop();
            System.Console.WriteLine($"Tempo com o foreach: {BenchMark[2].Elapsed} | {BenchMark[2].ElapsedTicks}");
            #endregion
        }

        static Int16 LoopRecursive(Int16[] array, Int16 n)
        {
            if (array[n] % 2 == 0)
            {
                return array[n];
            }
            n++;
            bool b = n >= array.Length ? true : false;
            if (b == false)
            {
                LoopRecursive(array, n);
            }
            return 0;
        }

        static int ForLoop(Int16[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    //System.Console.Write(" | " + array[i] + " | ");
                    return array[i];
                }
            }
            return 0;
        }

        static int ForeachLoop(Int16[] array)
        {
            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    return item;
                }
            }
            return 0;
        }
    }
}