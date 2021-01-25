using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class ThongTinDangKy
    {
        private string id;
        private string loai;
        public ThongTinDangKy(string id,string loai)
        {
            this.Id = id;
            this.Loai = loai;
            
        }
        public ThongTinDangKy(DataRow row)
        {
            this.Id = row["Mã Phòng"].ToString();
            this.Loai = row["Loại Hợp Đồng"].ToString();
            

        }

        public string Id { get => id; set => id = value; }
        public string Loai { get => loai; set => loai = value; }
    }
}
