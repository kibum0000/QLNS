using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class Phong
    {
        private string id;
        

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        

        private string name;
        public Phong(string id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Phong(DataRow row)
        {
            this.Id = row["Mã Phòng"].ToString();
            this.Name = row["Tên Phòng"].ToString();

        }


    }
}
