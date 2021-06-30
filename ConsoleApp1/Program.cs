using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cronometro = new Stopwatch();
            cronometro.Start();

            Console.WriteLine($"Iniciando aplicação em {cronometro.ElapsedMilliseconds}");

            Operacao1();
            Operacao2();
            Operacao3();

            cronometro.Stop();
            Console.WriteLine($"Finalizando aplicação em {cronometro.ElapsedMilliseconds}");
            
        }

        static void Operacao1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Operacao 1");
        }

        static void Operacao2()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Operacao 2");
        }

        static void Operacao3()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Operacao 3");
        }

    }
}
