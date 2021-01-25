using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class BoPhanDAO
    {
        private static BoPhanDAO instance;

        public static BoPhanDAO Instance 
        { get { if (instance == null) instance = new BoPhanDAO(); return BoPhanDAO.instance; }
            private set { BoPhanDAO.instance = value; } 
        }

        

        private BoPhanDAO()
        {

        }
        public List<BoPhan> GetBoPhans()
        {
            List<BoPhan> list = new List<BoPhan>();
            string query = @"Select * from dbo.BoPhan";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
           foreach(DataRow item in data.Rows)
           {
                BoPhan boPhan = new BoPhan(item);
                list.Add(boPhan);
           }
            return list;
        }
        public List<BoPhan> GetTenBoPhans(string id)
        {
            List<BoPhan> list = new List<BoPhan>();
            string query = @"Select * from dbo.BoPhan where [Mã Bộ Phận]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BoPhan boPhan = new BoPhan(item);
                list.Add(boPhan);
            }
            return list;
        }
    }
}
