using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class BoPhan
    {
        public BoPhan (string id,string name,DateTime date,string ghichu)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
            this.Ghichu = ghichu;

        }
        public BoPhan(DataRow row)
        {
            this.Id = row["Mã Bộ Phận"].ToString();
            this.Name = row["Tên Bộ Phận"].ToString();
            this.Date = (DateTime)row["Ngày Thành Lập"];
            this.Ghichu = row["Ghi Chú"].ToString(); ;
        }
        private string id;
        private string name;
        private DateTime date;
        private string ghichu;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Id
        { get { return id; }
            set { id = value; } 
        }

        public DateTime Date { get => date; set => date = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
    }
}
 