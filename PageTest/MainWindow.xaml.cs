using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			 InitializeComponent();
			 
		}

		private void btnA_Click(object sender, RoutedEventArgs e) {
			Button btn = sender as Button;		
			//this.frmMain.Navigate(new Uri(btn.Tag.ToString()+".xaml", UriKind.Relative));

			//Page1 a = new Page1();
			//this.frmMain.Content = a;
			//a.ParentWindow = this;
			Navigate(btn.Tag.ToString());
		}
		public void CallFromChild(string name) {
			MessageBox.Show("Hello" + name + "!");
		}
		 private void Navigate(string path) {
			string uri = "PageTest." + path;
			Type type = Type.GetType(uri);
			if(type!=null) {
				//实例化Page页
				object obj = type.Assembly.CreateInstance(uri);
				Page control = obj as Page;
				this.frmMain.Content = control;
				PropertyInfo[] infors = type.GetProperties();
				foreach (PropertyInfo info in infors) {
					if (info.Name == "ParentWindow") {
						info.SetValue(control, this, null);
						break;
					}
				}
			}
			
		}

		private void btnB_Click(object sender, RoutedEventArgs e) {
			this.frmMain.GoBack();
		}
	}
	
}
