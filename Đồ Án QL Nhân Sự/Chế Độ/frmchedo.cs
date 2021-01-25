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
    public partial class frmchedo : Form
    {
        public frmchedo()
        {
            InitializeComponent();
            LoadThongTinCaNhan();
        }
        void LoadThongTinCaNhan()
        {
            List<ThongTinCaNhan> listthongtincanhan = ThongTinCaNhanDAO.Instance.GetThongTinCaNhans();
            comboBox1.DataSource = listthongtincanhan;
            comboBox1.DisplayMember = "Id";
        }
        void LoadTenNhanVien(string id)
        {
            List<ThongTinCaNhan> listtennv = ThongTinCaNhanDAO.Instance.GetTenThongTinCaNhans(id);

            if (listtennv.Count > 0)
            {
                textBox2.Text = listtennv.First().Name;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void baoHiemBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.baoHiemBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void frmchedo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.BaoHiem' table. You can move, or remove it, as needed.
            this.baoHiemTableAdapter.Fill(this.thongTinTaiKhoan.BaoHiem);

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();

        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < baoHiemDataGridView.Rows.Count; i++)
            {
                if (baoHiemDataGridView.Rows[i].Cells[1].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox1.Text);
                if (selectRow == -1)
                {
                    
                    this.baoHiemTableAdapter.Them(comboBox1.Text,textBox2.Text,dateTimePicker1.Text,textBox1.Text,textBox3.Text,dateTimePicker2.Text,richTextBox1.Text);

                    this.baoHiemTableAdapter.Fill(this.thongTinTaiKhoan.BaoHiem);

                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(textBox1.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Nhân Viên!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.baoHiemTableAdapter.Xoa(textBox1.Text);
                    this.baoHiemTableAdapter.Fill(this.thongTinTaiKhoan.BaoHiem);

                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }
        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(textBox3.Text);
                if (selectRow == -1)
                {

                     this.baoHiemTableAdapter.Sua(comboBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox1.Text, textBox3.Text, dateTimePicker2.Text, richTextBox1.Text);

                    this.baoHiemTableAdapter.Fill(this.thongTinTaiKhoan.BaoHiem);

                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.Text;

            LoadTenNhanVien(id);
        }

        private void baoHiemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            comboBox1.Text = baoHiemDataGridView.Rows[numrow].Cells[0].Value.ToString();
            textBox1.Text = baoHiemDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox2.Text = baoHiemDataGridView.Rows[numrow].Cells[2].Value.ToString();
            dateTimePicker1.Text = baoHiemDataGridView.Rows[numrow].Cells[3].Value.ToString();
            dateTimePicker2.Text = baoHiemDataGridView.Rows[numrow].Cells[4].Value.ToString();
            textBox3.Text = baoHiemDataGridView.Rows[numrow].Cells[5].Value.ToString();
            richTextBox1.Text = baoHiemDataGridView.Rows[numrow].Cells[6].Value.ToString();
        }
    }
}
