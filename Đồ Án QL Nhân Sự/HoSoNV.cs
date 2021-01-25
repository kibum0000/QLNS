using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class HoSoNV
    {
        private string id;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }


        private string name;
        public HoSoNV(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public HoSoNV(DataRow row)
        {
            
            this.Id = row["Mã Nhân Viên"].ToString();
            this.Name = row["Họ Tên"].ToString();
        }

    }
}
