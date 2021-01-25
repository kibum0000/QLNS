using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class ThongTinDangKyDAO
    {
        private static ThongTinDangKyDAO instance;

        public static ThongTinDangKyDAO Instance
        {
            get { if (instance == null) instance = new ThongTinDangKyDAO(); return ThongTinDangKyDAO.instance; }
            private set { ThongTinDangKyDAO.instance = value; }
        }



        private ThongTinDangKyDAO()
        {

        }
        public List<ThongTinDangKy> GetLoais(string id)
        {
            List<ThongTinDangKy> list = new List<ThongTinDangKy>();
            string query = @"Select  [Mã Phòng],[Loại Hợp Đồng] from dbo.ThongTinDangKy where [Mã Nhân Viên]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinDangKy thongTindangky = new ThongTinDangKy(item);
                list.Add(thongTindangky);
            }
            return list;
        }
        public List<ThongTinDangKy> GetMaPhongs()
        {
            List<ThongTinDangKy> list = new List<ThongTinDangKy>();
            string query = @"Select  [Mã Phòng],[Loại Hợp Đồng] from dbo.ThongTinDangKy Where [Loại Hợp Đồng]=N'Thử Việc'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinDangKy thongTindangky = new ThongTinDangKy(item);
                list.Add(thongTindangky);
            }
            return list;
        }
    }
}
