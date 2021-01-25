using Đồ_Án_QL_Nhân_Sự.ThuMucLuong;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_Án_QL_Nhân_Sự
{
    public partial class FormBaoCao : Form
    {
        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ThongTinLuongDataSet.Luong' table. You can move, or remove it, as needed.
           
            LuongDataBase context = new LuongDataBase();
            List<Luong> listluong = context.Luongs.ToList();
            List<BaoCaoLuong> listreport = new List<BaoCaoLuong>();
            foreach (Luong i in listluong)
            {
                BaoCaoLuong temp = new BaoCaoLuong();
                temp.Mabophan = i.Mã_Bộ_Phận;
                temp.Maphong = i.Mã_Phòng;
                temp.Manv = i.Mã_Nhân_Viên;
                temp.Tennv = i.Tên_Nhân_Viên;
                temp.Tongluong = i.Tổng_Lương;
                temp.Songaynghi = i.Số_Ngày_Nghỉ;
                temp.Sogiothem = i.Số_Giờ_Làm_Thêm;
                temp.Kyluat = i.Kỷ_Luật;
                temp.Loai = i.Loại_Nhân_Viên;

                listreport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "BaoCaoLuong.rdlc";
            var reportDataSource = new ReportDataSource("BaoCaoLuongDataSet", listreport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
