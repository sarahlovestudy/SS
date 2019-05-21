using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Delegate_Test {
	class Program {
		static void Main(string[] args) {
			 

			Byte[] bytesToWrite = new Byte[] { 1, 2, 3, 4, 5 };
			FileStream fileStrem = new FileStream("Temp.dat", FileMode.Create);
			fileStrem.Write(bytesToWrite, 00, bytesToWrite.Length);
			
			fileStrem.Dispose();
			File.Delete("Temp.dat");
		
			//DelegateTestClass delegateTestClass = new DelegateTestClass();
			//delegateTestClass.Test1();
			Console.ReadKey();
		}
	}
}
 