using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_Án_QL_Nhân_Sự
{
    public partial class Quenmatkhau : Form
    {
        public Quenmatkhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select [Mật Khẩu] from dbo.TaiKhoan where @a = [Tên Đăng Nhập] and @b = [Họ Tên]", con);
            com.Parameters.AddWithValue("@a", textBox1.Text);
            com.Parameters.AddWithValue("@b", textBox2.Text);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = reader[0].ToString();
            }
        }

        private void Quenmatkhau_Load(object sender, EventArgs e)
        {
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select [Mật Khẩu] from dbo.TaiKhoan where @a = [Tên Đăng Nhập] and @b = [Họ Tên]", con);
            com.Parameters.AddWithValue("@a", textBox1.Text);
            com.Parameters.AddWithValue("@b", textBox2.Text);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
 
            while (reader.Read())
            {
                    textBox3.Text = reader[0].ToString();
                if (textBox3.Text != null)
                {
                    MessageBox.Show("Mật Khẩu của bạn là  "+textBox3.Text);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mật khẩu");
                }
            }
            
            
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FormDangNhap dn = new FormDangNhap();
            this.Hide();
            dn.ShowDialog();
           
            
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void Quenmatkhau_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Tài Khoản";
            textBox2.Text = "Họ Tên";
        }
    }
}
