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
using System.Configuration;
using System.Data.SqlClient; 
using System.Data;

namespace DataGrid_DataBase {
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			FillGrid();
		}
		public void FillGrid() {
			string MyConString ="Data Source=JSH0056\\SQLEXPRESS;Initial Catalog=ModelFirst;Integrated Security=True";
			string CmdString = string.Empty;
			using (SqlConnection con = new SqlConnection(MyConString)) {
				CmdString = "SELECT * FROM Employee2";
				SqlCommand cmd = new SqlCommand(CmdString, con);
				SqlDataAdapter sda = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable("Employee2");
				sda.Fill(dt);
				dataGrid.ItemsSource = dt.DefaultView;

				SqlDataReader sqlDataReader = cmd.ExecuteReader();
				if(sqlDataReader.Read()) {
					var id = (int)sqlDataReader["id"];
					
				}
			}

		}
	}
}
