using System.Diagnostics;
using System.IO;
using System;
namespace App1
{
    class Program
    {
        static void Main()
        {
            #region Input Array
            int[] array = new int[10];
            // Preenchendo o array com numeros de -999 ate +999
            // E imprimindo os valores do array na tela

            // Filling the array with numbers from -999 to +999
            // And printing array values on screen
            for (int i = 0; i < array.Length; i++)
            {
                Random rdn = new Random();
                array[i] = rdn.Next(-999, 999);
                Console.Write($"|{array[i]}");
            }
            // Formatando o resultado
            // Formatting the result
            Console.WriteLine("\n");
            #endregion

            #region BenchMark
            // BenchMark[0] = Recursive function
            // BenchMark[1] = ForLoop
            // BenchMark[2] = Foreach
            Stopwatch[] BenchMark = new Stopwatch[3];
            // instanciando os obj´s
            //instantiating the obj´s
            for (int i = 0; i < BenchMark.Length; i++)
            {
                BenchMark[i] = new Stopwatch();
            }
            #endregion

            #region Recursive
            BenchMark[0].Start();
            LoopRecursive(array);
            Console.Write(" -> Recursive\n");
            BenchMark[0].Stop();
            #endregion

            #region ForLoop
            BenchMark[1].Start();
            ForLoop(array);
            Console.Write(" -> ForLoop\n");
            BenchMark[1].Stop();
            #endregion

            #region Foreach
            BenchMark[2].Start();
            ForeachLoop(array);
            Console.Write(" -> Foreach\n");
            BenchMark[2].Stop();
            #endregion

            Console.WriteLine(
                $"-> Recursive time: {BenchMark[0].ElapsedTicks}" +
                "\n" +
                $"-> Time with the for: {BenchMark[1].ElapsedTicks}" +
                "\n" +
                $"-> Time with foreach: {BenchMark[2].ElapsedTicks}"
                + "\n"
            );

            #region Calculating Average
            // Local arquivo
            //File Location
            string path = @"F:\GitHub\teste_recusiveVS_forLoop_VS_foreach\resultados.txt";

            // Armazenado os valores das medias
            //Stored average values
            Int64 mediaR = 0;
            Int64 mediaF = 0;
            Int64 mediaFF = 0;

            // Lendo todas as linhas do documento txt
            // Reading all lines of txt document
            foreach (var line in File.ReadLines(path))
            {
                int[] count = new int[3];

                if (line.Contains("-> Tempo recursivo: "))
                {
                    count[0]++;
                    mediaR += (BenchMark[0].ElapsedTicks + BenchMark[0].ElapsedTicks) / count[0];
                }
                else if (line.Contains("-> Tempo com o for: "))
                {
                    count[1]++;
                    mediaF += (BenchMark[1].ElapsedTicks + BenchMark[1].ElapsedTicks) / count[1];
                }
                else if (line.Contains("-> Tempo com o foreach: "))
                {
                    count[2]++;
                    mediaFF += (BenchMark[2].ElapsedTicks + BenchMark[2].ElapsedTicks) / count[2];
                }
            }
            #endregion

            #region Writing on file
            using (StreamWriter txt = File.AppendText(path))
            {
                // Escrevendo os Resultados do teste
                // Writing Test Results
                txt.WriteLine(
                    $"-> Tempo recursivo: {BenchMark[0].ElapsedTicks}" +
                    "\n" +
                    $"-> Tempo com o for: {BenchMark[1].ElapsedTicks}" +
                    "\n" +
                    $"-> Tempo com o foreach: {BenchMark[2].ElapsedTicks}"
                    + "\n"
                );
                // Escrevendo os Resultados das medias
                // Writing Average Results
                txt.WriteLine(
                    $"*media* recursivo: {mediaR}" +
                    "\n" +
                    $"*media* com o for: {mediaF}" +
                    "\n" +
                    $"*media* com o foreach: {mediaFF}"
                    + "\n"
                );
            }
            #endregion

        }
        static int LoopRecursive(int[] array, int n = 0)
        {
            if (n >= array.Length)
            {
                return 1;
            }
            else
            {
                if (array[n] % 2 == 0 && n <= array.Length)
                {
                    Console.Write($"|{array[n]}");
                    LoopRecursive(array, n + 1);
                }
                else
                {
                    LoopRecursive(array, n + 1);
                }
            }
            return 0;
        }
        static int ForLoop(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    Console.Write($"|{array[i]}");
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
                    Console.Write($"|{item}");
                }
            }
            return 0;
        }
    }
}
