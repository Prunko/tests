using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class StationLog : IDisposable
    {
        private StreamWriter _writer;

        public StationLog() 
        {
            _writer = new StreamWriter("log.txt", append: true);
        }

        public void Write(string message)
        {
            _writer.WriteLine($"{DateTime.Now}: {message}");
        }

        public void Dispose()
        {
            _writer.Dispose(); 
        }
    }
}
