using System;

namespace ht11
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var semaphore = new SemaphoreSlim(3);

            var bonusAccount1 = new BonusAccount();
            await bonusAccount1.RunBonuses();

            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(1000);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}