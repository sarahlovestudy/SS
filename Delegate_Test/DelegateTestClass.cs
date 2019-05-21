using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Delegate_Test {
	class DelegateTestClass {

		Mutex mutex;
	 
		void Release() {
			
		}
		
		private string _name="summer";
		public string Name { get => _name; set { _name = value; } }
		public delegate void OnSalesHandler();
		public event OnSalesHandler Back;
		public Action action;
		public Func<int> func;
		public Func<int, string, int> func2;
		public DelegateTestClass() {
			//Test1();
			action += Go;
			Back += Go;
			func += Come;
			 
		}
		public void Test1() {
			if (Name.Equals("summer")) {
				action?.Invoke();
				Back?.Invoke();
			 int? result = func?.Invoke();
			}
		}
		public void Go() {
			Name = "summer";
		}
		 public int Come() {
			return 0;
		}
	}
}
