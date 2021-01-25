using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_Án_QL_Nhân_Sự
{
    public partial class FormQLTaiKhoan : Form
    {
        public FormQLTaiKhoan()
        {
            InitializeComponent();
        }
        string imgloc = "default.jpg";

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.taiKhoanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void FormQLTaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);

        }

        private void taiKhoanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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
        private void button6_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    
                    this.taiKhoanTableAdapter.Them(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text, comboBox1.Text,img);
                    this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);

                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Tên Tài Khoản Đã Tồn Tại");

                }
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Không Tìm Thấy Tên Tài Khoản");
                }
                else
                {
                    this.taiKhoanTableAdapter.Sua(textBox1.Text,textBox2.Text,textBox3.Text,dateTimePicker1.Text,comboBox1.Text,img);
                    this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);
                    MessageBox.Show("Sửa Thành Công");

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Vui Lòng Điền Tên Tài Khoản");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Không Tìm Thấy Tên Tài Khoản");
                }
                else
                {
                    this.taiKhoanTableAdapter.Xoa(textBox1.Text);
                    this.taiKhoanTableAdapter.Fill(this.thongTinTaiKhoan.TaiKhoan);
                    MessageBox.Show("Xóa Thành Công");

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taiKhoanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int numrow = e.RowIndex;
            textBox1.Text = taiKhoanDataGridView.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = taiKhoanDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = taiKhoanDataGridView.Rows[numrow].Cells[2].Value.ToString();
            dateTimePicker1.Text = taiKhoanDataGridView.Rows[numrow].Cells[3].Value.ToString();
            comboBox1.Text = taiKhoanDataGridView.Rows[numrow].Cells[4].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntonkho_Click(object sender, EventArgs e)
        {
            if(textBox2.PasswordChar=='*')
            {
                iconButton6.BringToFront();
                textBox2.PasswordChar='\0';
           
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                btntonkho.BringToFront();
               
                textBox2.PasswordChar = '*';
                

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        private void iconButton7_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                }
            }
            catch (Exception ex)
            {
                //connect.Close();
                MessageBox.Show("Error during insert: " + ex.Message);
            }
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources._default;
        }

        private void taiKhoanDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            textBox1.Text = this.taiKhoanDataGridView.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = this.taiKhoanDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = this.taiKhoanDataGridView.Rows[numrow].Cells[2].Value.ToString();
            dateTimePicker1.Text = this.taiKhoanDataGridView.Rows[numrow].Cells[3].Value.ToString();
            comboBox1.Text = this.taiKhoanDataGridView.Rows[numrow].Cells[4].Value.ToString();
            byte[] img = (byte[])(taiKhoanDataGridView.CurrentRow.Cells[5].Value);
            if (img == null)
            {
                pictureBox1.Image = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream((byte[])taiKhoanDataGridView.CurrentRow.Cells[5].Value);
              pictureBox1.Image = Image.FromStream(ms);
            }

        }
    }
}
