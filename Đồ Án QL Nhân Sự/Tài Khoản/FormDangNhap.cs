using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_Án_QL_Nhân_Sự
{
    public partial class FormDangNhap : Form
    {
       
        public FormDangNhap()
        {
            InitializeComponent();

            //taiKhoanDataGridView.Hide();
            pictureBox1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        /* private int GetQuyen(string studentID)
         {
               for (int i = 0; i < taiKhoanDataGridView.Rows.Count; i++)
               {
                   if (taiKhoanDataGridView.Rows[i].Cells[0].Value.ToString() == studentID)
                   {
                       return i;
                   }
               }
              return -1;
          }*/

        private void button1_Click(object sender, EventArgs e)
        {
            //var regexItem = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.\d)[a-zA-Z\d]{8,}*$");

            //if (regexItem.IsMatch(textBox2.Text)) 
            
            //{
            //    MessageBox.Show("alo");
            //}
            
            SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select Quyền,[Họ Tên],[Hình Ảnh] from dbo.TaiKhoan where @a = [Tên Đăng Nhập] and @b = [Mật Khẩu]", con);
            //SqlCommand com2 = new SqlCommand(@"Select [Họ Tên] from dbo.TaiKhoan where @a = [Tên Đăng Nhập] and @b = [Mật Khẩu]", con);
            com.Parameters.AddWithValue("@a", textBox1.Text);
            com.Parameters.AddWithValue("@b", textBox2.Text);
           // com2.Parameters.AddWithValue("@a", textBox1.Text);
           // com2.Parameters.AddWithValue("@b", textBox2.Text);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                textBox3.Text = reader[0].ToString();
                textBox4.Text = reader[1].ToString();
                byte[] img = (byte[])(reader[2]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
                
            }
            hello.Ten = textBox4.Text;
            hello.HinhAnh = pictureBox1.Image;


            this.taiKhoanTableAdapter.DangNhap(this.thongTinTaiKhoan.TaiKhoan,textBox1.Text,textBox2.Text);
            if(textBox3.Text == "Admin")
            {

                MessageBox.Show("Đăng Nhập Thành Công !!!");
                MainForm.quyen = "Admin";
                
                
                Program.f.MainForm_Load(null,null);
                this.Close();
                Program.f.Show();
            }
            else if (textBox3.Text == "User")
            {
                MessageBox.Show("Đăng Nhập Thành Công !!!");
                MainForm.quyen = "User";
                
                Program.f.MainForm_Load(null, null);
                this.Close();
                Program.f.Show();
            }
            else
                MessageBox.Show("Đăng Nhập Thất Bại\nMật Khẩu Không Đúng");

            
            
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);

        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taiKhoanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Quenmatkhau q = new Quenmatkhau();
            //this.Hide();
            this.Hide();
            q.ShowDialog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void FormDangNhap_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Tài Khoản";
            textBox2.Text = "Mật Khẩu";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                iconButton6.BringToFront();
                textBox2.PasswordChar = '\0';

            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                iconButton4.BringToFront();

                textBox2.PasswordChar = '*';


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
