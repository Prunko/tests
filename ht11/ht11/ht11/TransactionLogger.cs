using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ht11
{
    internal class TransactionLogger : IDisposable
    {
        private readonly BlockingCollection<string> _logQueue = new BlockingCollection<string>();

        public TransactionLogger()
        {
            Task.Run(() => ProccessQueue());
        }

        public void AddLog(string message)
        {
            _logQueue.Add($"Transaction: {message} - {DateTime.Now}");
        }

        private void ProccessQueue()
        {
            foreach (var log in _logQueue.GetConsumingEnumerable())
            {
                File.AppendAllText("logs.txt", log + "\n");
            }
        }

        public void Dispose()
        {
            _logQueue.CompleteAdding();
            _logQueue.Dispose();
        }
    }
}
