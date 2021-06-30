using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMonitoringTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Operacao(TimeSpan.FromSeconds(10));
            while (!task.IsCompleted)
            {
                Console.WriteLine($"Processando... Task status: {task.Status}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Task status: {task.Status}");
        }

        static async Task<int> Operacao(TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
            return (int)timeSpan.TotalMilliseconds;
        }
    }
}
