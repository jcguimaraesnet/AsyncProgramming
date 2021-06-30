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

            Task<string> firstTask = webClient1.DownloadStringTaskAsync(webSiteLista.First());
            Task<string> lastTask = webClient2.DownloadStringTaskAsync(webSiteLista.Last());

            //var arrayString = await Task.WhenAll(firstTask, lastTask);
            //var taskString = await Task.WhenAny(firstTask, lastTask);

            string stringPageFirst = await firstTask;
            Console.WriteLine($"download website {webSiteLista.First()} com {stringPageFirst.Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");

            string stringPageLast = await lastTask;
            Console.WriteLine($"download website {webSiteLista.Last()} com {stringPageLast.Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");

            cronometro.Stop();

            var indexWebSiteMaisPesado = (stringPageFirst.Length < stringPageLast.Length) ? 1 : 0;

            Console.WriteLine($"Website mais pesado: {webSiteLista[indexWebSiteMaisPesado]}");

            Console.WriteLine($"App finalizado em {cronometro.ElapsedMilliseconds} ms");

        }
    }
}
