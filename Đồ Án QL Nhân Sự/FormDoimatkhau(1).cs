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
    public partial class FormDoimatkhau : Form
    {
        public FormDoimatkhau()
        {
            InitializeComponent();
            taiKhoanDataGridView.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    if (textBox3.Text ==textBox4.Text)
                    {
                        this.taiKhoanTableAdapter.DoiMatKhau(textBox3.Text, textBox1.Text, textBox2.Text, textBox1.Text);
                        this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Nhập Lại Mật Khẩu Không Chính Xác");
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
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
