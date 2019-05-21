using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BigDataReleaseTest {
	class Program {
		static void Main(string[] args) {
			
			Foo();
			Console.ReadKey();
		}
		private static void Foo() {
			int n = 100000;
			IntPtr buffer = Marshal.AllocHGlobal(sizeof(int) * n);//从进程的非托管内存中分配内存
			int k = 2;
			IntPtr t = buffer + k * sizeof(int);
			var p = Marshal.PtrToStructure<int>(t);//从非托管到托管
			Console.WriteLine("p" + p);
			p = 2;
			Marshal.StructureToPtr(p, t, false);//从托管到非托管封送
			p = Marshal.PtrToStructure<int>(t);
			Console.WriteLine("p" + p);
			Console.WriteLine("遍历");
			for(int i=0;i<10;i++) {
				t = buffer + i * sizeof(int);
				Console.WriteLine(Marshal.PtrToStructure<int>(t));
			}
			Marshal.FreeHGlobal(buffer);
		}
		 
	}
}
