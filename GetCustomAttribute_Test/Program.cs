using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCustomAttribute_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAuthorInfo(typeof(FirstClass));
            PrintAuthorInfo(typeof(SecondClass));
            PrintAuthorInfo(typeof(ThridClass));
            Console.ReadKey();
        }
        static void PrintAuthorInfo(Type t)
        {
            Console.WriteLine("Author information for{0}", t);
            Attribute[] attrs = Attribute.GetCustomAttributes(t);
            foreach(Attribute attr in attrs)
            {
                if(attr is Author)
                {
                    Author a = (Author)attr;
                    Console.WriteLine("{0},version {1:f}", a.GetName(), a.version);
                }
                   
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct,AllowMultiple =true)]
    public class Author : System.Attribute
    {
        string name;
        public double version;
        public Author(string name)
        {
            this.name = name;
            version = 1.0;
        }
        public string GetName()
        {
            return name;
        }
    }
    [Author("Lin.Liu")]
    class FirstClass
    {

    }
    class SecondClass
    {

    }
    [Author("Lin.Liu"),Author("M.Knott",version =2.0)]
    class ThridClass
    {
        public string name = "sarah"; 
    }
    
}
