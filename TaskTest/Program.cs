using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
       static Task t;
        static void Main(string[] args)
        {
            t = Task.Run(() =>
            {
                while(true)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("task1");
                }               
            });
            t = Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(150);
                    Console.WriteLine("task2");
                }
            });
            Thread.Sleep(10000);
            Console.WriteLine("Hello World!");
        }
    }
}
