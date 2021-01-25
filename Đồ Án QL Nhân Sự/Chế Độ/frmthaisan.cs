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
    public partial class frmthaisan : Form
    {
        public frmthaisan()
        {
            InitializeComponent();
            LoadBoPhan();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        void LoadPhong(string id)
        {
            List<Phong> listphong = PhongDAO.Instance.GetPhongs(id);
            comboBox2.DataSource = listphong;
            comboBox2.DisplayMember = "Id";
        }

        void LoadBoPhan()
        {
            List<BoPhan> listbophan = BoPhanDAO.Instance.GetBoPhans();
            comboBox1.DataSource = listbophan;
            comboBox1.DisplayMember = "Id";

        }
        void LoadMa(string id)
        {
            List<ThongTinCaNhan> listmanv = ThongTinCaNhanDAO.Instance.GetMa(id);
            comboBox3.DataSource = listmanv;
            comboBox3.DisplayMember = "Id";
        }
        void LoadTen(string id)
        {
            List<ThongTinCaNhan> listten = ThongTinCaNhanDAO.Instance.GetTenThongTinCaNhans(id);

            if (listten.Count > 0)
            {
                textBox6.Text = listten.First().Name;
            }
        }
        
        void LoadNS(string id)
        {
            List<ThongTinCaNhan> listten = ThongTinCaNhanDAO.Instance.GetTenThongTinCaNhans(id);

            if (listten.Count > 0)
            {
                dateTimePicker1.Value = listten.First().Date;
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void thaiSanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.thaiSanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void frmthaisan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.ThaiSan' table. You can move, or remove it, as needed.
            this.thaiSanTableAdapter.Fill(this.thongTinTaiKhoan.ThaiSan);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.Text;
            LoadPhong(id);
            
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
           
            textBox6.Clear();
            textBox4.Clear();
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < thaiSanDataGridView.Rows.Count; i++)
            {
                if (thaiSanDataGridView.Rows[i].Cells[2].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox6.Text == "" )
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox3.Text);
                if (selectRow == -1)
                {
                    
                    this.thaiSanTableAdapter.Them(comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox6.Text, dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, dateTimePicker4.Text, textBox4.Text);
                    this.thaiSanTableAdapter.Fill(this.thongTinTaiKhoan.ThaiSan);

                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox3.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Không Tìm Thấy Mã Nhân Viên");
                }
                else
                {
                    this.thaiSanTableAdapter.Sua(comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox6.Text, dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, dateTimePicker4.Text, textBox4.Text, comboBox3.Text);
                    this.thaiSanTableAdapter.Fill(this.thongTinTaiKhoan.ThaiSan);
                    MessageBox.Show("Sửa Thông Tin Thành Công");

                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(comboBox3.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Nhân Viên!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.thaiSanTableAdapter.Xoa(comboBox3.Text);
                    this.thaiSanTableAdapter.Fill(this.thongTinTaiKhoan.ThaiSan);
                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Clear();
            string id = comboBox2.Text;
            LoadMa(id);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox3.Text;
            LoadTen(id);
            LoadNS(id);
        }

        private void thaiSanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thaiSanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            comboBox1.Text = thaiSanDataGridView.Rows[numrow].Cells[0].Value.ToString();
            comboBox2.Text = thaiSanDataGridView.Rows[numrow].Cells[1].Value.ToString();
            comboBox3.Text = thaiSanDataGridView.Rows[numrow].Cells[2].Value.ToString();
            textBox6.Text = thaiSanDataGridView.Rows[numrow].Cells[3].Value.ToString();
            dateTimePicker1.Text = thaiSanDataGridView.Rows[numrow].Cells[4].Value.ToString();
            dateTimePicker2.Text = thaiSanDataGridView.Rows[numrow].Cells[5].Value.ToString();
            dateTimePicker3.Text = thaiSanDataGridView.Rows[numrow].Cells[6].Value.ToString();
            dateTimePicker4.Text = thaiSanDataGridView.Rows[numrow].Cells[7].Value.ToString();
            textBox4.Text = thaiSanDataGridView.Rows[numrow].Cells[8].Value.ToString();
        }
    }
}
