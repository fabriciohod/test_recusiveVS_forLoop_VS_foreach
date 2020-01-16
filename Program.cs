using System.Diagnostics;
using System;
namespace App1
{
    class Program
    {
        static void Main()
        {
            #region array de Input
            // Criando o array
            int[] array = new int[10];
            // preenchendo o array com numeros de -999 ate +999
            // E imprimindo os valores do array na tela 
            for (int i = 0; i < array.Length; i++)
            {
                Random rdn = new Random();
                array[i] = rdn.Next(-999, 999);
                Console.Write($"| {array[i]} |");
            }
            // Dividindo o Input dos resultados
            Console.WriteLine("\n");
            #endregion

            #region BenchMark
            // BenchMark[0] = Recursive function
            // BenchMark[1] = ForLoop
            // BenchMark[2] = Foreach
            Stopwatch[] BenchMark = new Stopwatch[3];
            // instanciando os obj´s
            for (int i = 0; i < BenchMark.Length; i++)
            {
                BenchMark[i] = new Stopwatch();
            }
            #endregion

            #region Recursive
            BenchMark[0].Start();
            LoopRecursive(array);
            BenchMark[0].Stop();
            Console.WriteLine($" Tempo recursivo: {BenchMark[0].ElapsedTicks}");
            #endregion

            #region ForLoop
            BenchMark[1].Start();
            ForLoop(array);
            BenchMark[1].Stop();
            Console.WriteLine($" Tempo com o for: {BenchMark[1].ElapsedTicks}");
            #endregion

            #region Foreach
            BenchMark[2].Start();
            ForeachLoop(array);
            BenchMark[2].Stop();
            Console.WriteLine($" Tempo com o foreach: {BenchMark[2].ElapsedTicks}");
            #endregion
        }
        static int LoopRecursive(int[] array, int n = 0)
        {
            if (n >= array.Length)
            {
                return -1;
            }
            else if (array[n] % 2 == 0 && n <= array.Length)
            {
                Console.Write($"| {array[n]} |");
                LoopRecursive(array, n + 1);
            }
            else
            {
                LoopRecursive(array, n + 1);
            }
            return -2;
        }
        static int ForLoop(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    Console.Write($"| {array[i]} |");
                }
            }
            return -4;
        }
        static int ForeachLoop(int[] array)
        {
            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"| {item} |");
                }
            }
            return -8;
        }
    }
}
