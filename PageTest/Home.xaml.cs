using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PageTest {
	public class BasePage : Page {
		#region 父窗体
		private MainWindow _parentWin;
		public MainWindow ParentWindow {
			get { return _parentWin; }
			set { _parentWin = value; }
		}
		#endregion

	} 
	/// <summary>
	/// Home.xaml 的交互逻辑
	/// </summary>
	public partial class Home : BasePage {
		public Home() {
			InitializeComponent();
		}

		private void btnCall_Click(object sender, RoutedEventArgs e) {
			string param = txtParam.Text;
			ParentWindow.CallFromChild(param);
		}
	}
}
