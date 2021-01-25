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
    public partial class FormDangNhap : Form
    {
       
        public FormDangNhap()
        {
            InitializeComponent();

            //taiKhoanDataGridView.Hide();

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
            SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select Quyền from dbo.TaiKhoan where @a = [Tên Đăng Nhập] and @b = [Mật Khẩu]", con);
            com.Parameters.AddWithValue("@a", textBox1.Text);
            com.Parameters.AddWithValue("@b", textBox2.Text);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox3.Text = reader[0].ToString();
            }     
           
            this.taiKhoanTableAdapter.DangNhap(this.thongTinTaiKhoan.TaiKhoan,textBox1.Text,textBox2.Text);
            if(textBox3.Text == "Admin")
            {
                MessageBox.Show("Đăng Nhập Thành Công !!!");
                MainForm.quyen = "Admin";
                Program.f.MainForm_Load(null,null);
                //MainForm MF = new MainForm();
                //this.Hide();
                this.Close();
                Program.f.Show();
            }
            else if (textBox3.Text == "User")
            {
                MessageBox.Show("Đăng Nhập Thành Công !!!");
                MainForm.quyen = "User";
                Program.f.MainForm_Load(null, null);
                this.Close();
                //MF.ShowDialog();
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
    }
}
