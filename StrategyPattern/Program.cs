using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Strategy tax1 = new Tax1();
            Operation operation = new Operation(tax1);
            operation.GetTex(1);
        }
    }
}
