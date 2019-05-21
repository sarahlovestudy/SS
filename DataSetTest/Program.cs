using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace DataSetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = "Data Source=JSH0056\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
            SqlServer sqlServer = new SqlServer();
            sqlServer.connectToSQL(conString);
            string select = "select * from TblEmployee where Salary=5000 order by asc";
            string delete = "delete from TblEmployee where Salary=5000";
            string insert = "insert into TblEmployee (EmployeeID,FirstName,LastName,Salary) values (1,'sd','sd',55555)";
            sqlServer.handleSql(insert);
        }
    }
}
