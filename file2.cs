using System;

namespace file2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! What is current time?");
            DateTime time = new DateTime();
            time = DateTime.UtcNow;
            Console.WriteLine("Hello! Current time is " + time.ToString());
        }
    }
}