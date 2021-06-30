using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace APM
{
    class Program
    {
        private static Dictionary<string, int> webSiteLista = new()
        {
            { "oglobo", 0 },
            { "folha", 0 }
        };

        private static Stopwatch cronometro = new();

        static void Main(string[] args)
        {
            cronometro.Start();

            Console.WriteLine("Antes - Chamada método assíncrono com padrão APM");
            Dns.BeginGetHostAddresses($"www.{webSiteLista.First().Key}.com.br", EndGetIP, webSiteLista.First().Key);
            Dns.BeginGetHostAddresses($"www.{webSiteLista.Last().Key}.com.br", EndGetIP, webSiteLista.Last().Key);
            Console.WriteLine("Após - Chamada método assíncrono com padrão APM");
            
            Console.ReadKey();
        }

        static void EndGetIP(IAsyncResult ar)
        {
            IPAddress[] addresses = Dns.EndGetHostAddresses(ar);
            
            Array.ForEach(addresses, (x) => {
                Console.WriteLine($"Endereço ip '{x}' de '{ar.AsyncState}' em {cronometro.ElapsedMilliseconds} ms");
            });
        }
    }
}
