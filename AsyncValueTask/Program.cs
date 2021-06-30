using System;
using System.Threading.Tasks;

namespace AsyncValueTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var timeSpan = TimeSpan.FromSeconds(2000);

            int retornoComTask = await OperacaoComTask(timeSpan);
            int retornoComValueTask = await OperacaoComValueTask(timeSpan);
        }

        //Task (C# 5) => tipo referência => alocação no heap e gerenciamento do GC
        static async Task<int> OperacaoComTask(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
            return timeSpan.Seconds;
        }

        //ValueTask (C# 7) => tipo valor => alocação no stack => desalocação após execução método
        static async ValueTask<int> OperacaoComValueTask(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
            return timeSpan.Seconds;
        }
    }
}
