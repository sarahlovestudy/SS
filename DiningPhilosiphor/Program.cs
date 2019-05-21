using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosiphor
{
    class Program
    {
        static Random random = new Random();
        public static readonly int MAX_PHILOSOPHERS_NUM = 5;
        static List<Semaphore> forks = new List<Semaphore>();
        private static List<Thread> philosophers = new List<Thread>();
        public static void WaitLeftFork(int number)
        {
            forks[number].WaitOne();
            Console.WriteLine("哲学家" + number + "取得左侧叉子");
        }
        public static void WaitRightFork(int number)
        {
            forks[(number + 1) % MAX_PHILOSOPHERS_NUM].WaitOne();
            Console.WriteLine("哲学家" + number + "取得右侧叉子");
        }
        public static void Eat(int number)
        {
            Console.WriteLine("哲学家" + number + "开始进食");
            Thread.Sleep(TimeSpan.FromSeconds(random.Next(2, 3)));
        }
        public static void TakeARest(int number)
        {
            Console.WriteLine("哲学家" + number + "开始休息");
            Thread.Sleep(TimeSpan.FromSeconds(random.Next(1, 5)));
        }
        public static void ReleaseTwoForks(int number)
        {
            forks[number].Release();
            forks[(number + 1) % MAX_PHILOSOPHERS_NUM].Release();
        }
        static void Main(string[] args)
        {
             for(int i=0;i<MAX_PHILOSOPHERS_NUM;i++)
            {
                forks.Add(new Semaphore(1, 1));
                philosophers.Add(new Thread(Philosopher4));
            }
             for(int i=0;i<MAX_PHILOSOPHERS_NUM;i++)
            {
                philosophers[i].Start(i.ToString() as object);
            }
        }
      
        static void Philosopher(object num)
        {
            int number = int.Parse(num.ToString());
            while(true)
            {
                WaitLeftFork(number);
                WaitRightFork(number);
                Eat(number);
                ReleaseTwoForks(number);
                TakeARest(number);
            }

        }
        public static Semaphore eating = new Semaphore(MAX_PHILOSOPHERS_NUM - 1, MAX_PHILOSOPHERS_NUM - 1);
        static void Philosopher2(object num)
        {
            int number = int.Parse(num.ToString());
            while (true)
            {
                eating.WaitOne();
                WaitLeftFork(number);
                WaitRightFork(number);
                Eat(number);
                ReleaseTwoForks(number);
                eating.Release();
                TakeARest(number);
            }
        }
        public static Mutex middle = new Mutex();
        static void Philosopher3(object num)
        {
            int number = int.Parse(num.ToString());
            while (true)
            {
                middle.WaitOne();
                WaitLeftFork(number);
                WaitRightFork(number);
                middle.ReleaseMutex();
                Eat(number);
                ReleaseTwoForks(number);
               
                TakeARest(number);
            }
        }
        private static object lockobj = new object();
        static void Philosopher4(object num)
        {
            int number = int.Parse(num.ToString());
            while (true)
            {
               lock(lockobj)
                {
                    WaitLeftFork(number);
                    WaitRightFork(number);
                }   
                Eat(number);
                ReleaseTwoForks(number);
                TakeARest(number);
            }
        }
    }
    

    
}
