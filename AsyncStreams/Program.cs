using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Início - Gerar número aleatório");
            await foreach (var number in GerarNumeroAleatorio())
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Fim - Gerar número aleatório");
        }

        //C# 8.0 IAsyncEnumerable / yield
        public static async IAsyncEnumerable<int> GerarNumeroAleatorio()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                yield return new Random().Next(1, 100);
            }
        }
    }
}
