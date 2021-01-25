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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeComponent();
            timer1.Start();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQLTaiKhoan qltk = new FormQLTaiKhoan();
            panel1.Show();
            panel1.Controls.Clear();
            qltk.TopLevel = false;
            qltk.Dock = DockStyle.Fill;
            panel1.Controls.Add(qltk);
            qltk.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap dn = new FormDangNhap();
            this.Hide();
            dn.ShowDialog();
            //this.Show();
        }
        public static string quyen;
        public void MainForm_Load(object sender, EventArgs e)
        {
            if (quyen == null)
            {
                FormStart ft = new FormStart();
                panel1.Show();
                panel1.Controls.Clear();
                ft.TopLevel = false;
                ft.Dock = DockStyle.Fill;
                panel1.Controls.Add(ft);
                ft.Show();
            }
            else
            {
                hello hl = new hello();
                panel1.Show();
                panel1.Controls.Clear();
                hl.TopLevel = false;
                hl.Dock = DockStyle.Fill;
                panel1.Controls.Add(hl);
                hl.Show();
            }
            
            if (quyen == "Admin")
            {

                DanhMuc.Enabled = true;
                ChucNang.Enabled = true;
                QuanLy.Enabled = true;
                qladmin.Enabled = true;
            }
            else if (quyen == "User")
            {
                DanhMuc.Enabled = true;
                ChucNang.Enabled = false;
                QuanLy.Enabled = false;
                qladmin.Enabled = false;
            }
        }

        private void QuanLy_Click(object sender, EventArgs e)
        {

        }

        private void nhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDKi fdk = new FormDKi();
            panel1.Show();
            panel1.Controls.Clear();
            fdk.TopLevel = false;
            fdk.Dock = DockStyle.Fill;
            panel1.Controls.Add(fdk);
            fdk.Show();
        }

        private void thôngTinhCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongtincanhan ftt = new FormThongtincanhan();
            panel1.Show();
            panel1.Controls.Clear();
            ftt.TopLevel = false;
            ftt.Dock = DockStyle.Fill;
            panel1.Controls.Add(ftt);
            ftt.Show();
        }

        private void chếĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hồSơThửViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHosothuviec ftv = new FormHosothuviec();
            panel1.Show();
            panel1.Controls.Clear();
            ftv.TopLevel = false;
            ftv.Dock = DockStyle.Fill;
            panel1.Controls.Add(ftv);
            ftv.Show();
            
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhongbankhoa fpb = new FormPhongbankhoa();
            panel1.Show();
            panel1.Controls.Clear();
            fpb.TopLevel = false;
            fpb.Dock = DockStyle.Fill;
            panel1.Controls.Add(fpb);
            fpb.Show();
        }

        private void bộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBophan fbp = new FormBophan();
            panel1.Show();
            panel1.Controls.Clear();
            fbp.TopLevel = false;
            fbp.Dock = DockStyle.Fill;
            panel1.Controls.Add(fbp);
            fbp.Show();
        }

        private void lươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTienLuongNhanVien tl = new FormTienLuongNhanVien();
            panel1.Show();
            panel1.Controls.Clear();
            tl.TopLevel = false;
            tl.Dock = DockStyle.Fill;
            panel1.Controls.Add(tl);
            tl.Show();
        }

        

        private void traCứuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimkiem ftk = new FormTimkiem();
            panel1.Show();
            panel1.Controls.Clear();
            ftk.TopLevel = false;
            ftk.Dock = DockStyle.Fill;
            panel1.Controls.Add(ftk);
            ftk.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoimatkhau dmk = new FormDoimatkhau();
            panel1.Show();
            panel1.Controls.Clear();
            dmk.TopLevel = false;
            dmk.Dock = DockStyle.Fill;
            panel1.Controls.Add(dmk);
            dmk.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBaoCao fcb = new FormBaoCao();
            panel1.Show();
            panel1.Controls.Clear();
            fcb.TopLevel = false;
            fcb.Dock = DockStyle.Fill;
            panel1.Controls.Add(fcb);
            fcb.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label1.Text = datetime.ToString("dd/MM/yyyy HH:mm:ss");
            
        }
    }
}
