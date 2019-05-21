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
 

namespace NoteBook
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void AddPlugInsToMenu()
        {
            String assPath = this.GetType().Assembly.Location;
            String assDirPath = System.IO.Path.GetDirectoryName(assPath);
            //插件文件夹路径
            String plugInDir = assDirPath + "\\plugs";
            //扫描插件文件夹中的所有的程序集文件名 all .dll
            String[] dllFiles = System.IO.Directory.GetFiles(plugInDir, "*.dll");
            foreach(String strDll in dllFiles)
            {
                //根据程序集路径 加载程序集到内存
                Assembly ass = Assembly.LoadFrom(strDll);
                //判断程序集中是否有插件类
                //获取程序集中的Public class
                Type[] types = ass.GetExportedTypes();

                var test = Activator.CreateInstance(ass.GetType(types[0].FullName)) as MyNoteBookPlugInterfaceProject.IPlugIn;
                txt.Text=test.ProcessText(txt.Text);

                //Type notebookInterfaceType = typeof(MyNoteBookPlugInterfaceProject.IPlugIn);
                ////判断是否实现了记事本接口
                //foreach (Type t in types)
                //{
                //    // 判断t是否实现了 notebookInterfaceType 接口
                //  //  if (t.IsAssignableFrom(notebookInterfaceType))
                //    {
                //        // 根据插件类，创建menuitem，并添加到menu中  
                //        PlugInMenuItem.Items.Add(new MenuItem { Header = t.Name });

                //    }
                // }
            }
        }

        private void PlugInMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddPlugInsToMenu();
        }
    }
}
 
 