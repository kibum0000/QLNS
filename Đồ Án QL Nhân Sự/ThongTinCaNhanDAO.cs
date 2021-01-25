using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class ThongTinCaNhanDAO
    {
        private static ThongTinCaNhanDAO instance;

        public static ThongTinCaNhanDAO Instance
        {
            get { if (instance == null) instance = new ThongTinCaNhanDAO(); return ThongTinCaNhanDAO.instance; }
            private set { ThongTinCaNhanDAO.instance = value; }
        }



        private ThongTinCaNhanDAO()
        {

        }
        public List<ThongTinCaNhan> GetThongTinCaNhans()
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select * from dbo.ThongTinDangKy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }
        public List<ThongTinCaNhan> GetMaPhongs()
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select  * from dbo.ThongTinDangKy Where [Loại Hợp Đồng]=N'Thử Việc'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }
        public List<ThongTinCaNhan> GetMas(string id)
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select  * from dbo.ThongTinDangKy Where [Loại Hợp Đồng]=N'Thử Việc' and [Mã Phòng]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }
        public List<ThongTinCaNhan> GetMa(string id)
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select  * from dbo.ThongTinDangKy Where [Mã Phòng]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }
        public List<ThongTinCaNhan> GetTenThongTinCaNhans(string id)
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select * from dbo.ThongTinDangKy where [Mã Nhân Viên]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }
        public List<ThongTinCaNhan> GetGioiTinhs(string id)
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select * from dbo.ThongTinDangKy where [Mã Nhân Viên]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }
        public List<ThongTinCaNhan> GetNgaySinhs(string id)
        {
            List<ThongTinCaNhan> list = new List<ThongTinCaNhan>();
            string query = @"Select * from dbo.ThongTinDangKy where [Mã Nhân Viên]='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThongTinCaNhan thongTinCaNhan = new ThongTinCaNhan(item);
                list.Add(thongTinCaNhan);
            }
            return list;
        }

    }
}
