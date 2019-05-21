using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataSetTest
{
    class SqlServer
    {
        private SqlConnection Con = null;
        public SqlConnection con { get; private set; }

        //Dataset和SQLserver之间的桥梁DataAdapter
        public readonly SqlDataAdapter sda = new SqlDataAdapter();
        //本地数据集合
        //dataset是不依赖于数据库的独立数据集合
        //填充数据checkToDataSet()；//填充数据到DataSet
        private DataSet Ds = new DataSet();
        public DataSet ds { get => Ds; }
        //查询的数据保存到dt表格中
        private DataTable Dt = new DataTable();
        public DataTable dt { get => Dt; }

        public int connectToSQL(string connStr)
        {
            try
            {
                con = new SqlConnection(connStr);
            }
            catch(SqlException e)
            {
                string s = e.Message;
            }
            return 0;
        }
        //增删改
        public int handleSql(string com)
        {
            if (null == con)
            {
               // ShowError("未初始化数据库连接");
                return -2;
            }

            try
            {
                SqlCommand commad = new SqlCommand(com, con);
                con.Open();
                commad.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
               // ShowError(e.Message);
                return -1;
            }
             


            return 0;
        }
 
         
        public int checkToDataSet(string sql)
        {
            SqlCommand myCommand = new SqlCommand(sql, con);
            sda.SelectCommand = myCommand;//设置操作指令
            con.Open();
            sda.SelectCommand.ExecuteNonQuery();
            sda.Fill(Ds);
            con.Close();
            return 0;
        }
        public int checkToDataTable(string sql)
        {
            int re = checkToDataSet(sql);
            if(re==0)Dt = Ds.Tables[0];
            return re;
        }

    }
}
