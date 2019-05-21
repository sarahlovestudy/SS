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

namespace DepandancyProperty_Test {
	/// <summary>
	/// UserControl1.xaml 的交互逻辑
	/// </summary>
	public partial class UserControl1 : UserControl {
		public UserControl1() {
			InitializeComponent();
			DataContext = this;
			///ChangedCommand = new RelayCommand<string>(AutoPaging);// new ICommand(AutoPaging);
		}
		void AutoPaging(string s) {
			MessageBox.Show(s);
		}
		static UserControl1() {

		}
		public ICommand ButtonCommand {
			get { return (ICommand)GetValue(ButtonCommandProperty); }
			set { SetValue(ButtonCommandProperty, value); }
		}
		public ICommand ChangedCommand {
			get { return (ICommand)GetValue(ChangedCommandProperty); }
			set { SetValue(ChangedCommandProperty,value); }
		}
		public static readonly DependencyProperty ChangedCommandProperty =
			DependencyProperty.Register("ChangedCommand", typeof(ICommand), typeof(UserControl1));
		public static readonly DependencyProperty inputNameProperty =
			DependencyProperty.Register("inputName", typeof(string), typeof(UserControl1));
		public static readonly DependencyProperty ButtonCommandProperty =
			DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(UserControl1));
		public string inputName {
			get => (string)GetValue(inputNameProperty);
			set { SetValue(inputNameProperty, value); }
		}
		private static void PropertyInputNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			UserControl1 userControl1 = (UserControl1)d;
			string str = (string)e.NewValue;
			if (str != "" && str != null)
				userControl1.id.Text = str.ToString();
		}
	}

	
}
