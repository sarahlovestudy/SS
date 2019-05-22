using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newfunctionforcsharp7 {
	class Program {
		static void Main(string[] args) {
			//int x;
			Test(out int x);
			Console.WriteLine("x= " + x);
			Console.ReadKey();
		}

		public static void Test(out int x) {
			x = 10;
		}
		class Point {
			int x;
			int y;
			public void GetCoordinates(out int x,out int y) {
				this.x = x = 0; 
				this.y = y=0;
			}
		}
	}
}
