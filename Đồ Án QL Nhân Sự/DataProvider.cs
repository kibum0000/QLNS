using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    class DataProvider
    {
        
        private static DataProvider instance;
       // private string STR = @"Data Source=LAPTOP-5P7QBBMI\KIRITOLONG;Initial Catalog=quanlynhanvien;Integrated Security=True";
        private string STR = @"Data Source=LAPTOP-5P7QBBMI\KIRITOLONG;Initial Catalog=ThongTinNS;Integrated Security=True";

        public static DataProvider Instance
        { get { if (instance == null) instance = new DataProvider(); return  DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        
        public DataTable ExecuteQuery(string query,object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(STR))
               {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                if(parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            com.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection con = new SqlConnection(STR))
            {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            com.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = com.ExecuteNonQuery();
               
                con.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection con = new SqlConnection(STR))
            {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            com.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = com.ExecuteScalar();

                con.Close();
            }
            return data;
        }
    }
}
