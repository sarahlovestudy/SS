using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
			 
			Race human = new Race(new HumanPartFactory());
			Console.WriteLine(human.Head.name);
			Console.WriteLine(human.Skin.name);
			Console.WriteLine(human.Stature.name);
			Console.ReadKey();
        }
    }
}
