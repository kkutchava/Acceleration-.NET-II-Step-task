using System;

class Program
{
    static async Task Main(string[] args) {
        SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // continuous output 
        var continuousTask = Task.Run(() => continuous(semaphore)); // every 5 seconds => 5000 ms
        var periodicTask = Task.Run(() => every5sec(semaphore));
        await Task.WhenAll(continuousTask, periodicTask);
    }

    static async Task continuous(SemaphoreSlim s) {
        while (true) { // infinite loop
            await s.WaitAsync();
            try {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1");
                await Task.Delay(60); // Adjust delay based on your requirement
                Console.Write("0");
            }
            finally {
                s.Release();
            }
        }
    }

    static async Task every5sec(SemaphoreSlim s) {
        while (true) { // infinite loop
            await Task.Delay(5000); // 5 seconds

            await s.WaitAsync();
            try {
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Console.WriteLine("\n");
                Console.Write("Neo, you are the chosen one");
            }
            finally {
                s.Release();
            }
        }
    }
}
