using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cronometro = new Stopwatch();
            cronometro.Start();

            Console.WriteLine($"Iniciando aplicação em {cronometro.ElapsedMilliseconds}");

            var task1 = Operacao1(); //1 ns -> start task
            var task2 = Operacao2(); //1 ns -> start task
            var task3 = Operacao3(); //1 ns -> start task

            await task1; //2 seconds
            await task2; //1 seconds
            await task3; //0 seconds

            cronometro.Stop();
            Console.WriteLine($"Finalizando aplicação em {cronometro.ElapsedMilliseconds}");
        }




        static async Task Operacao1()
        {
            //Console.WriteLine("Operacao 1");
            await Task.Delay(2000);
            Console.WriteLine("Operacao 1");
        }

        static async Task Operacao2()
        {
            Console.WriteLine("Operacao 2");
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
