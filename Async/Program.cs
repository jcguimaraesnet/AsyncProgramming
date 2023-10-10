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
            await task1;
            await task2;
            await task3;

            //o trecho acima equivale ao método abaixo Task.WhenAll
            //await Task.WhenAll(Operacao1(), Operacao2(), Operacao3());

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
