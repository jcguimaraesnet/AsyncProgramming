using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppParallelProgram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cronometro = new Stopwatch();
            cronometro.Start();

            Console.WriteLine($"Iniciando aplicação em {cronometro.ElapsedMilliseconds}");

            var task1 = Task.Run(() => Operacao1());
            var task2 = Task.Run(() => Operacao2());
            var task3 = Task.Run(() => Operacao3());

            await task1;
            await task2;
            await task3;

            //Task.WaitAll(task1, task2, task3);
            //Task.WaitAny(task1, task2, task3);

            cronometro.Stop();
            Console.WriteLine($"Finalizando aplicação em {cronometro.ElapsedMilliseconds}");
        }

        static async Task Operacao1()
        {
            await Task.Delay(2000);
            Console.WriteLine("Operacao 1");
        }

        static async Task Operacao2()
        {
            await Task.Delay(3000);
            Console.WriteLine("Operacao 2");
        }

        static async Task Operacao3()
        {
            await Task.Delay(1000);
            Console.WriteLine("Operacao 3");
        }
    }
}
