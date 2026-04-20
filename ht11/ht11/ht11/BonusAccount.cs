using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ht11
{
    internal class BonusAccount
    {
        public int _bonuses = 0;
        private readonly TransactionLogger _logger = new TransactionLogger();
        private readonly static object _locker = new object();

        public async Task RunBonuses()
        {
            var taskList = new List<Task>();

            for (int i = 0; i < 100;  i++)
            {
                var t = Task.Run(() => AddBonuses());
                taskList.Add(t);
            }

            await Task.WhenAll(taskList);

            Console.WriteLine($"Bonuses: {_bonuses}");
        }

        private void AddBonuses()
        {
            // lock is more expensive for CPU than Interlocked.Increment(ref _bonuses), 
            // but it was used here for better understanding how it works
            lock (_locker)
            {
                for (int i = 0; i < 1000; i++)
                {
                    int currentBonuses = _bonuses;
                    _bonuses++;
                    _logger.AddLog($"added {_bonuses - currentBonuses} to account");
                }
            }
        }
    }
}