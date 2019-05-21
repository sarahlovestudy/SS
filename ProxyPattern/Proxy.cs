using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public abstract class Person
    {
        public abstract void BuyProduct();

    }
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("buy mac");
        }
    }

    public class Proxy:Person
    {
        RealBuyPerson realBuyPerson;
        public override void BuyProduct()
        {
            ProBuy();
            if(realBuyPerson == null)
                realBuyPerson = new RealBuyPerson();
            realBuyPerson.BuyProduct();
        }
        public void ProBuy()
        {
            Console.WriteLine("pre buy");
        }

    }
}
