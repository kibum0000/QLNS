using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class ThongTinCaNhan
    {
        private string id;
        private string idphong;
        private string name;
        private string gt;
        private DateTime date;
        public ThongTinCaNhan(string id,string idphong, string name,string gt,DateTime date)
        {
            this.Id = id;
            this.Idphong = idphong;
            this.Name = name;
            this.Gt = gt;
            this.Date = date;
        }
        public ThongTinCaNhan(DataRow row)
        {
            this.Id = row["Mã Nhân Viên"].ToString();
            this.Idphong = row["Mã Phòng"].ToString();
            this.Name = row["Họ Tên"].ToString();
            this.Gt = row["Giới Tính"].ToString();
            this.Date = (DateTime)row["Ngày Sinh"];
            
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gt { get => gt; set => gt = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Idphong { get => idphong; set => idphong = value; }
    }
}
