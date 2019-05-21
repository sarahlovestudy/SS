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
    /// ShowNumberControl.xaml 的交互逻辑
    /// </summary>
    public partial class ShowNumberControl : UserControl
    {
        public ShowNumberControl()
        {
            InitializeComponent();
        }
        public int CurrentNumber
        {
            get { return (int)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        //依赖属性
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber", typeof(int), typeof(ShowNumberControl),
            new UIPropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged)),
            new ValidateValueCallback(ValidateCurrentNumber)
            );

        //验证依赖属性值
        public static bool ValidateCurrentNumber(object value)
        {
            if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500)
                return true;
            else
                return false;
        }
        //当依赖属性更改后，将用户控件中的Label设置最新依赖属性的值。
        public static void CurrentNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ShowNumberControl c = (ShowNumberControl)d;
            Label theLabel = c.numberDisplay;
            theLabel.Content = e.NewValue.ToString();
        }
    }
}
