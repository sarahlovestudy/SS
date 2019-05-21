using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bow_deadlock
{
    public  class Friend
    {
        private String name;
        public Friend(String name)
        {
            this.name = name;
        }
        private static object obj = new object();
        public String getName() { return this.name; }
        public void bow (Friend bower)
        { 
            lock(obj)
            {
                String str = bower.getName() + "bow to me";
                Console.WriteLine(str);
                bowback(this);
                str = string.Empty;
            }            
        }
        public void bowback(Friend bower)
        {
            String str = bower.getName() + "bow back to me";
            Console.WriteLine(str);
            str = string.Empty;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            float? test1;
            float test2;

            //Friend friend = new Friend("wang");
            //Friend friend2 = new Friend("ming");
            //Task t, t2;            
            //t = Task.Run(() => {
            //    while(true)
            //        friend.bow(friend2);
            //});
            //t2 = Task.Run(() => {
            //    while(true)
            //        friend2.bow(friend);
            //});
            //while (true) ;
  
        }
         
    }
}
