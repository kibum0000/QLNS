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
    public partial class hello : Form
    {
        public hello()
        {
            InitializeComponent();
            pictureBox1.Image = HinhAnh;
            label1.Text ="Chào Mừng Bạn Trở Lại "+ Ten;
            timer1.Start();
        }
        public static string Ten;
        public static Image HinhAnh;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            
            this.lbgio.Text = datetime.ToString("HH:mm:ss");
            this.lbngay.Text = datetime.ToString("dd/MM/yyyy");
            this.lbthu.Text = datetime.ToString("dddd");
        }

        private void hello_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
