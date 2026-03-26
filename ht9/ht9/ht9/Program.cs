using System;
using System.Collections;
using System.Diagnostics;

namespace ht9
{
    class Program
    {
        static void Main(string[] args)
        {
            var goodsLoad = new Queue<string>();
            var goodsUnload = new Stack<string>();
            var goodsCatalogue = new Dictionary<int, string>();
            var vipClients = new SortedList<int, string>();
            var valuableGoods = new LinkedList<string>();

            SpeedMemoryTest();
        }

        static void AddInsideOfLinkedList(string leftEl, string El, LinkedList<string> linkedList)
        {
            var leftNode = linkedList.Find(leftEl);
            linkedList.AddAfter(leftNode, El);
        }

        static void SpeedMemoryTest()
        {
            var arrayList = new ArrayList();
            var list = new List<int>();

            long memoryBefore1 = GC.GetTotalMemory(true);

            var sw1 = new Stopwatch();

            sw1.Start();

            for (int i = 0; i < 1000000; i++)
            {
                arrayList.Add(i);
            }

            sw1.Stop();

            long memoryAfter1 = GC.GetTotalMemory(true);

            Console.WriteLine("===ArrayList results===" +
                $"\nTime: {sw1.ElapsedMilliseconds} ms" +
                $"\nMemory: {memoryAfter1 - memoryBefore1} bytes\n");

            long memoryBefore2 = GC.GetTotalMemory(true);

            var sw2 = new Stopwatch();

            sw2.Start();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i);
            }

            sw2.Stop();

            long memoryAfter2 = GC.GetTotalMemory(true);

            Console.WriteLine("===List results===" +
                $"\nTime: {sw2.ElapsedMilliseconds} ms" +
                $"\nMemory: {memoryAfter2 - memoryBefore2} bytes");
        }
    }
}