using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppAsyncTAPDownloadString
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WebClient webClient1 = new(), webClient2 = new();
            Stopwatch cronometro = new();

            var webSiteLista = new[] { "http://www.oglobo.com.br", "http://www.folha.com.br" };

            cronometro.Start();

            Console.WriteLine($"Antes - Chamada método assíncrono com padrão TAP em: {cronometro.ElapsedMilliseconds}");

            Task<string> firstTask = webClient1.DownloadStringTaskAsync(webSiteLista.First());
            Task<string> lastTask = webClient2.DownloadStringTaskAsync(webSiteLista.Last());

            Console.WriteLine($"Após - Chamada método assíncrono com padrão TAP em: {cronometro.ElapsedMilliseconds}");

            Console.WriteLine($"ANTES Task.WhenAll em: {cronometro.ElapsedMilliseconds}");
            var arrayString = await Task.WhenAll(firstTask, lastTask);
            Console.WriteLine($"APOS Task.WhenAll em: {cronometro.ElapsedMilliseconds}");

            Console.WriteLine($"download website {webSiteLista.First()} com {arrayString.First().Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");
            Console.WriteLine($"download website {webSiteLista.Last()} com {arrayString.Last().Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");

            cronometro.Stop();

            var indexWebSiteMaisPesado = (arrayString.First().Length < arrayString.Last().Length) ? 1 : 0;

            Console.WriteLine($"Website mais pesado: {webSiteLista[indexWebSiteMaisPesado]}");

            Console.WriteLine($"App finalizado em {cronometro.ElapsedMilliseconds} ms");

        }
    }
}
