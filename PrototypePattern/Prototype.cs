using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public abstract class Prototype
    {
        public string Id { get; set; }
        public Prototype(string id)
        {
            this.Id = id;
        }
        public abstract Prototype Clone();
    }
    public class Monkey:Prototype
    {
        public Monkey(string id) : base(id) { }

        //浅拷贝
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
    public class Client
    {
        static void Main(string[] args)
        {
            Prototype prototype = new Monkey("MonkeyKing");
            Prototype clone1 = prototype.Clone() as Monkey;
            Console.WriteLine(clone1.Id);
             
        } 
    }
}
