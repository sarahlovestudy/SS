using System;
using System.Windows;
using System.Reflection;
using PlugIn1;

namespace ShowPlugIn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PlugIn1.Class1.Show
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            String path = this.GetType().Assembly.Location;
            String filePath = System.IO.Path.GetDirectoryName(path) +"\\PlugIn1.dll";
            Assembly ass = Assembly.LoadFrom(filePath);
            Type[] t = ass.GetTypes();
            var plugin1 = Activator.CreateInstance(ass.GetType(t[0].FullName)) as PlugInInterfaceTest.Test;
            plugin1.Show();

            
        }
    }
}
