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

namespace DepandancyProperty_Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			DataContext = this;
            lable.Content = Name;
            Name = "LIN";
			Text = "Test";
        }
		public string Text { get; set; }
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), 
                typeof(MainWindow),
                new PropertyMetadata("sr", OnValueChanged)
                );

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow main = (MainWindow)d;
            Label b = main.lable;
            b.Content = e.NewValue.ToString();
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set {  SetValue(NameProperty, value); }
        }

		private void bt_Click(object sender, RoutedEventArgs e) {

		}
	}
}
