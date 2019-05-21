using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Brush> ColorsList { get; set; }
        public Brush SelectedColor { get; set; }
        Test t = new Test();

        public MainWindow()
        {
            InitializeComponent();
            ColorsList = new List<Brush>
            {
                Brushes.Red,
                Brushes.Green,  Brushes.Blue,  Brushes.White,  Brushes.Black
            };
            DataContext = this;
            tb.DataContext = t;
			IsShow = true;
			colorPicker.IsOpen = IsShow;
			
        }

		public static readonly DependencyProperty IsShowProperty =
		      DependencyProperty.Register ("IsShow", typeof(bool), typeof(MainWindow));

       public bool IsShow 
			{ 
			get { return (bool)GetValue(IsShowProperty);				 
			}
			set {  SetValue(IsShowProperty,value); }
		   }

    }
    class Test:ViewModelBase
    {
        private int text = 30;
        public int Size
        {
            get => text;
            set { text = value; }
        }
        private string _text = "text||";
        public string Text
        {
            get => _text;
            set { _text = value; }
        }
    }
    class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Mumbers    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
