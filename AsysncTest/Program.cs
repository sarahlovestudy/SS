using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsysncTest {
	class Program {
		static void Main(string[] args) {
			//Method1();
			//Method2();

			callMethod();

			//Console.WriteLine("执行GetReturnResult方法前的时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
			//var strRes = Task.Run<string>(() => { return GetReturnResult(); });//启动Task执行方法
			//Console.WriteLine("执行GetReturnResult方法后的时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
			//Console.WriteLine(strRes.Result);//得到方法的返回值
			//Console.WriteLine("得到结果后的时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss"));
			Console.ReadKey();
		}

		//public static async Task Method1() {
		//	await Task.Run(() =>
		//	{
		//		for (int i = 0; i < 100; i++) {
		//			Console.WriteLine(" Method 1");
		//		}
		//	});
		//}
		//public static void Method2() {
		//	for (int i = 0; i < 25; i++) {
		//		Console.WriteLine(" Method 2");
		//	}
		//}

		public static async void callMethod() {
			Task<int> task = Method1();
			Method2();
			//int count = await task;
			var result = task.GetAwaiter();
			int countt = result.GetResult();
			
			Method3(countt);
		}
		public static async Task<int> Method1() {
			int count = 0;
			await Task.Run(() => {
				for (int i = 0; i < 100; i++) {
					Console.WriteLine("Method 1");
					count += 1;
				}
			});
			
			return count;
		}
		public static void Method2() {
			for (int i = 0; i < 25; i++) {
				Console.WriteLine("Method 2");
			}
		}
		public static void Method3(int count) {
			Console.WriteLine("Total count is " + count);
		}

		static string GetReturnResult() {
			System.Threading.Thread.Sleep(2000);
			return "I am back";
		}
	}
}
