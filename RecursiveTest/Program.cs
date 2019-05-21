using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveTest {
	class Program {
		static void Main(string[] args) {
			

			Recuresive(10,);
		}
		public int Recuresive(int i,out int result) {
			 result = 0;
			if (i == 0)
				return 0;
			return Recuresive(i-1,out result)+i;
		}
	}
}
