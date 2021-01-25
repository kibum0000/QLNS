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
    public partial class FormBophan : Form
    {
        public FormBophan()
        {
            InitializeComponent();
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < boPhanDataGridView.Rows.Count; i++)
            {
                if (boPhanDataGridView.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectRow)
        {
            boPhanDataGridView.Rows[selectRow].Cells[0].Value = textBox1.Text;
            boPhanDataGridView.Rows[selectRow].Cells[1].Value = textBox2.Text;
            boPhanDataGridView.Rows[selectRow].Cells[2].Value = dateTimePicker1.Text;
            boPhanDataGridView.Rows[selectRow].Cells[3].Value = textBox3.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    this.boPhanTableAdapter.Them(textBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox3.Text);
                    this.boPhanTableAdapter.Fill(this.thongTinTaiKhoan.BoPhan);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Bộ Phận Đã Tồn Tại");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Mã Bộ Phận Không Tồn Tại");
                }
                else
                {
                    this.boPhanTableAdapter.Sua(textBox2.Text, dateTimePicker1.Text, textBox3.Text, textBox1.Text, textBox1.Text);
                    this.boPhanTableAdapter.Fill(this.thongTinTaiKhoan.BoPhan);
                    MessageBox.Show("Cập Nhật Bộ Phận Thành Công");

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(textBox1.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Bộ Phận!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.boPhanTableAdapter.Xoa(textBox1.Text);
                    this.boPhanTableAdapter.Fill(this.thongTinTaiKhoan.BoPhan);
                    MessageBox.Show("Xóa Bộ Phận Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void boPhanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.boPhanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void FormBophan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.BoPhan' table. You can move, or remove it, as needed.
            this.boPhanTableAdapter.Fill(this.thongTinTaiKhoan.BoPhan);

        }
        public void load()
        {
            this.boPhanTableAdapter.Fill(this.thongTinTaiKhoan.BoPhan);
        }

        private void boPhanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            textBox1.Text = boPhanDataGridView.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = boPhanDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = boPhanDataGridView.Rows[numrow].Cells[3].Value.ToString();
            dateTimePicker1.Text = boPhanDataGridView.Rows[numrow].Cells[2].Value.ToString();
            
        }
    }
}
