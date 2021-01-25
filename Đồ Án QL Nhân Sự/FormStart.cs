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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Quenmatkhau q = new Quenmatkhau();
            //this.Hide();
            Program.f.Hide();
            q.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            FormDangNhap dn = new FormDangNhap();
            this.Hide();
            Program.f.Hide();
            dn.ShowDialog();
        }
    }
}
