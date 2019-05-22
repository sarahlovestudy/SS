using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern2 {
	class Program {
		static void Main(string[] args) {
			Order order = new Order();
			order.Minute = 9;
			order.Action();
			 Console.ReadKey();
		}
	}
}
