using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class PhongDAO
    {
        private static PhongDAO instance;

        public static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return PhongDAO.instance; }
            private set { PhongDAO.instance = value; }
        }
        private PhongDAO() { }
        public List<Phong> GetPhongs(string id)
        {
            List<Phong> list = new List<Phong>();
            string query = "Select  * from dbo.Phong where [Mã Bộ Phận]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
           foreach(DataRow item in data.Rows)
            {
                Phong phong = new Phong(item);
                list.Add(phong);
            }
            
            return list;
        }
    }
}
