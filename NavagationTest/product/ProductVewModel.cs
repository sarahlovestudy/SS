using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavagationTest {
	class ProductVewModel :ViewModelBase,PageViewModel{
		public string Name {
			get { return "Product Page"; }
		}
	}
}
