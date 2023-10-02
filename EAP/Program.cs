using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;

namespace EAP
{
    class Program
    {
        private static Dictionary<string, int> webSiteLista =  new() 
            { 
              { "oglobo", 0 }, 
              { "folha", 0 } 
            };

        private static Stopwatch cronometro = new();

        static void Main(string[] args)
        {
            cronometro.Start();

            Console.WriteLine($"Antes - Chamada método assíncrono com padrão EAP em: {cronometro.ElapsedMilliseconds}");
            WebClient webClient1 = new(), webClient2 = new();
            
            webClient1.DownloadStringCompleted += OnDownloadStringCompleted;
            webClient2.DownloadStringCompleted += OnDownloadStringCompleted;
            
            webClient1.DownloadStringAsync(new Uri($"http://www.{webSiteLista.First().Key}.com.br"), webSiteLista.First().Key);
            webClient2.DownloadStringAsync(new Uri($"http://www.{webSiteLista.Last().Key}.com.br"), webSiteLista.Last().Key);

            Console.WriteLine($"Após - Chamada método assíncrono com padrão EAP em: {cronometro.ElapsedMilliseconds}");

            while (webClient1.IsBusy || webClient2.IsBusy)
            {
                Console.WriteLine("Processando...");
                Thread.Sleep(10);
            }

            var indexWebSiteMaisPesado = (webSiteLista.First().Value < webSiteLista.Last().Value) ?
                            webSiteLista.Last().Key :
                            webSiteLista.First().Key;

            Console.WriteLine($"Website mais pesado: {indexWebSiteMaisPesado}");

            cronometro.Stop();

            Console.WriteLine($"App finalizado em {cronometro.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }

        static void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs eventArgs)
        {
            webSiteLista[$"{eventArgs.UserState}"] = eventArgs.Result.Length;
            Console.WriteLine($"download website {eventArgs.UserState} com {eventArgs.Result.Length} bytes, finalizado em {cronometro.ElapsedMilliseconds} ms");
        }
    }
}
