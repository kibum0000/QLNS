using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class HoSoNVDAO
    {
        private static HoSoNVDAO instance;

        public static HoSoNVDAO Instance
        {
            get { if (instance == null) instance = new HoSoNVDAO(); return HoSoNVDAO.instance; }
            private set { HoSoNVDAO.instance = value; }
        }
        private HoSoNVDAO() { }
        public List<HoSoNV> GetHoSoNVs(string id)
        {
            List<HoSoNV> list = new List<HoSoNV>();
            string query = "Select  * from dbo.ThongTinDangKy where [Mã Phòng]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoSoNV hoSoNV = new HoSoNV(item);
                list.Add(hoSoNV);
            }

            return list;
        }

        public List<HoSoNV> GetNVs(string id)
        {
            List<HoSoNV> list = new List<HoSoNV>();
            string query = "Select  * from dbo.ThongTinDangKy where [Mã Nhân Viên]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoSoNV hoSoNV = new HoSoNV(item);
                list.Add(hoSoNV);
            }

            return list;
        }
    }
}
