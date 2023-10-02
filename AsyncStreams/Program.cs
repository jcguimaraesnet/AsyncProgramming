using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Início - Gerar número aleatório - SYNC");
            foreach (var numero in GerarNumeroAleatorio())
            {
                Console.WriteLine($"Imprimindo numero aleatorio (sync): {numero}");
            }
            Console.WriteLine("Fim - Gerar número aleatório - SYNC");

            Console.WriteLine("\n\n");

            Console.WriteLine("Início - Gerar número aleatório - ASYNC");
            await foreach (var numero in GerarNumeroAleatorioAsync())
            {
                Console.WriteLine($"Imprimindo numero aleatorio (sync): {numero}");
            }
            Console.WriteLine("Fim - Gerar número aleatório - ASYNC");
        }

        public static IEnumerable<int> GerarNumeroAleatorio()
        {
            var lista = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                var numero = new Random().Next(1, 100);
                lista.Add(numero);
                Console.WriteLine($"Gerando número aleatório (sync): {numero}");
            }
            return lista;
        }

        //C# 8.0 IAsyncEnumerable / yield
        public static async IAsyncEnumerable<int> GerarNumeroAleatorioAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                var numero = new Random().Next(1, 100);
                Console.WriteLine($"Gerando número aleatório (async): {numero}");
                yield return numero;
            }
        }
    }
}
