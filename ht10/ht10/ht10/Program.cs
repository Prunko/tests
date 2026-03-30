using System;
using System.Diagnostics;

namespace ht10
{
    class Program
    {
        static Random rnd = new Random();

        static async Task Main(string[] args)
        {
            int choice;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("1. Get all prices" +
                    "\n2. Quick deal (get one price)" +
                    "\n0. Exit");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Wrong input");
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        await GetAllPricesAsync();
                        isWorking = false;
                        break;
                    case 2:
                        Console.Clear();
                        await GetOnePriceAsync();
                        isWorking = false;
                        break;
                    case 0:

                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        Console.ReadKey();
                        continue;
                }
            }
        }

        static async Task<int> GetBinancePriceAsync(CancellationToken cancellationToken)
        {
            int binancePrice = rnd.Next(60000, 65001);

            int delay = rnd.Next(500, 4000);
            await Task.Delay(delay, cancellationToken);

            return binancePrice;
        }

        static async Task<int> GetCoinbasePriceAsync(CancellationToken cancellationToken)
        {
            int coinbasePrice = rnd.Next(60000, 65001);

            int delay = rnd.Next(500, 4000);
            await Task.Delay(delay, cancellationToken);

            return coinbasePrice;
        }

        static async Task<int> GetKrakenPriceAsync(CancellationToken cancellationToken)
        {
            int krakenPrice = rnd.Next(60000, 65001);

            int delay = rnd.Next(500, 4000);
            await Task.Delay(delay, cancellationToken);

            return krakenPrice; 
        }

        static async Task GetAllPricesAsync()
        {
            var tokenSource = new CancellationTokenSource();

            var sw = new Stopwatch();

            sw.Start();
            Console.WriteLine("Search in progress... Press 'S' to cancel");

            _ = Task.Run(() =>
            {
                if (Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    tokenSource.Cancel();
                    Console.WriteLine("\nOperation cancelled by user");
                }
            });

            try
            {
                var task1 = GetBinancePriceAsync(tokenSource.Token);
                var task2 = GetCoinbasePriceAsync(tokenSource.Token);
                var task3 = GetKrakenPriceAsync(tokenSource.Token);
                var timeoutTask = Task.Delay(2500);

                Task<int[]> allPricesTask = Task.WhenAll(task1, task2, task3);

                if (await Task.WhenAny(allPricesTask, timeoutTask) == timeoutTask)
                {
                    tokenSource.Cancel();
                    Console.WriteLine("\nTimeout: no response");
                }

                int[] prices = await allPricesTask;
                Console.Clear();
                sw.Stop();

                Console.WriteLine($"Average price: {prices.Average()}");
                Console.WriteLine($"Completion time: {sw.ElapsedMilliseconds} ms");
            }
            catch (OperationCanceledException)
            {
            }
        }

        static async Task GetOnePriceAsync()
        {
            var tokenSource = new CancellationTokenSource();

            var sw = new Stopwatch();

            sw.Start();
            Console.WriteLine("Search in progress... Press 'S' to cancel");

            _ = Task.Run(() =>
            {
                if (Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    tokenSource.Cancel();
                    Console.WriteLine("\nOperation cancelled by user");
                }
            });

            try
            {
                var taskDict = new Dictionary<Task<int>, string>();

                var task1 = GetBinancePriceAsync(tokenSource.Token);
                var task2 = GetCoinbasePriceAsync(tokenSource.Token);
                var task3 = GetKrakenPriceAsync(tokenSource.Token);
                var timeoutTask = Task.Delay(2500);

                taskDict.Add(task1, "Binance");
                taskDict.Add(task2, "Coinbase");
                taskDict.Add(task3, "Kraken");

                Task winner = await Task.WhenAny(task1, task2, task3, timeoutTask);

                Task<int> firstTask;

                if (winner == timeoutTask)
                {
                    Console.WriteLine("\nTimeout: no response");
                    tokenSource.Cancel();
                }
                else
                {
                    firstTask = (Task<int>)winner;

                    string firstTaskName = taskDict[firstTask];
                    int price = await firstTask;
                    Console.Clear();
                    sw.Stop();

                    Console.WriteLine($"{firstTaskName} price: {price}");
                    Console.WriteLine($"Completion time: {sw.ElapsedMilliseconds} ms");
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}