using System;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace AppSyncDownloadString
{
    class Program
    {
        //chamada síncrona
        static void Main(string[] args)
        {
            var webSiteLista = new[] { "https://oglobo.globo.com", "http://www.folha.com.br" };

            Console.WriteLine("Antes - Chamada download síncrona");
            var webClient = new WebClient();

            var cronometro = new Stopwatch();
            cronometro.Start();

            var stringHtml1 = webClient.DownloadString(webSiteLista.First());
            Console.WriteLine($"download website {webSiteLista.First()} com {stringHtml1.Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");

            var stringHtml2 = webClient.DownloadString(webSiteLista.Last());
            Console.WriteLine($"download website {webSiteLista.Last()} com {stringHtml2.Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");
            
            cronometro.Stop();

            var indexWebSiteMaisPesado = (stringHtml1.Length < stringHtml2.Length) ? 1 : 0;

            Console.WriteLine($"Website mais pesado: {webSiteLista[indexWebSiteMaisPesado]}");

            Console.WriteLine($"App finalizado em {cronometro.ElapsedMilliseconds} ms");
        }
    }
}
