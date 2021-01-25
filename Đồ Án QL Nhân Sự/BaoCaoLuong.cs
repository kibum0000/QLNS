using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_Án_QL_Nhân_Sự
{
    public class BaoCaoLuong
    {
        private string mabophan;
        private string maphong;
        private string manv;
        private string tennv;
        private double tongluong;
        private int songaynghi;
        private int sogiothem;
        private string kyluat;
        private string loai;
        private int thang;
        private int nam;

        public string Mabophan { get => mabophan; set => mabophan = value; }
        public string Maphong { get => maphong; set => maphong = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        
        public int Songaynghi { get => songaynghi; set => songaynghi = value; }
        public int Sogiothem { get => sogiothem; set => sogiothem = value; }
        public string Kyluat { get => kyluat; set => kyluat = value; }
        public string Loai { get => loai; set => loai = value; }
        public double Tongluong { get => tongluong; set => tongluong = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
    }
}
