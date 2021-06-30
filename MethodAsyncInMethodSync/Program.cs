using System;
using System.Threading.Tasks;

namespace MethodAsyncInMethodSync
{
    class Program
    {
        static void Main(string[] args)
        {
            //ERRO
            //await Operacao1();

            //chamadas assíncronas em métodos síncronos
            Operacao1(TimeSpan.FromSeconds(2000)).Wait();
            var seconds = Operacao1(TimeSpan.FromSeconds(2000)).Result;
        }

        static async Task<int> Operacao1(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
            return timeSpan.Seconds;
        }
    }
}
