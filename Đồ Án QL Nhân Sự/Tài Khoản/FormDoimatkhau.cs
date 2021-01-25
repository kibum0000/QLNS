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
    public partial class FormDoimatkhau : Form
    {
        public FormDoimatkhau()
        {
            InitializeComponent();
            taiKhoanDataGridView.Hide();
            textBox5.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select [Mật Khẩu] from dbo.TaiKhoan where @a = [Tên Đăng Nhập] ", con);
            com.Parameters.AddWithValue("@a", textBox1.Text);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox5.Text = reader[0].ToString();
            }

            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Thông Tin Không Chính Xác");
                }
                else
                {
                    if (textBox2.Text == textBox5.Text)
                    {
                        if(textBox2.Text==textBox3.Text)
                        {
                            MessageBox.Show("Mật Khẩu Đang Sử Dụng");
                        }
                        else
                        {
                            if (textBox3.Text == textBox4.Text)
                            {
                                this.taiKhoanTableAdapter.DoiMatKhau(textBox3.Text, textBox1.Text, textBox2.Text);
                                this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);
                                MessageBox.Show("Đổi Mật Khẩu Thành Công");
                            }
                            else
                            {
                                MessageBox.Show("Nhập Lại Mật Khẩu Không Chính Xác");
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Không Chính Xác");
                    }
                       
                    
                   

                }
            }
            
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < taiKhoanDataGridView.Rows.Count; i++)
            {
                if (taiKhoanDataGridView.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taiKhoanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void FormDoimatkhau_Load(object sender, EventArgs e)
        {
           this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
