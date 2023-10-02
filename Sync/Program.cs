using System;
using System.Diagnostics;
using System.Threading;

namespace Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            var cronometro = new Stopwatch();
            cronometro.Start();

            Console.WriteLine($"Iniciando aplicação em {cronometro.ElapsedMilliseconds}");

            Operacao1(); //2 sec
            Operacao2(); //3 sec
            Operacao3(); //1 sec

            cronometro.Stop();
            Console.WriteLine($"Finalizando aplicação em {cronometro.ElapsedMilliseconds}");

        }

        static void Operacao1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Sync - Operacao 1");
        }

        static void Operacao2()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Sync - Operacao 2");
        }

        static void Operacao3()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Sync - Operacao 3");
        }
    }
}
