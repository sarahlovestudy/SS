using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern {
	class Program {
		static void Main(string[] args) {
			RedDiamond redDiamond = new RedDiamond(null);
			Type t = redDiamond.GetType();
			PropertyInfo p = t.GetProperty("name");
		}
	}
}
