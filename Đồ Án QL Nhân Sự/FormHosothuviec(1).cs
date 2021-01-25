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
    public partial class FormHosothuviec : Form
    {
        public FormHosothuviec()
        {
            InitializeComponent();
            LoadPhong();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == ""||  comboBox2.Text == "" || txt2.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "" || txt7.Text == "" || txt8.Text == "" )
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox1.Text);
                if (selectRow == -1)
                {
                    this.hoSoThuViecTableAdapter.Them(comboBox1.Text, comboBox2.Text, txt2.Text, txt4.Text, dateTimePicker1.Text, txt5.Text, txt8.Text, dateTimePicker2.Text, txt6.Text, txt7.Text, txt11.Text);
                    this.hoSoThuViecTableAdapter.Fill(this.thongTinTaiKhoan.HoSoThuViec);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {
                    
                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }
        void LoadPhong()
        {
            List<ThongTinDangKy> listphong = ThongTinDangKyDAO.Instance.GetMaPhongs();
            comboBox1.DataSource = listphong;
            comboBox1.DisplayMember = "Id";
        }
        void LoadMa(string id)
        {
            List<ThongTinCaNhan> listmanv = ThongTinCaNhanDAO.Instance.GetMas(id);
            comboBox2.DataSource = listmanv;
            comboBox2.DisplayMember = "Id";
        }
        void LoadTen(string id)
        {
            List<ThongTinCaNhan> listten = ThongTinCaNhanDAO.Instance.GetTenThongTinCaNhans(id);

            if (listten.Count > 0)
            {
                txt2.Text = listten.First().Name;
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
        void LoadGT(string id)
        {
            List<ThongTinCaNhan> listten = ThongTinCaNhanDAO.Instance.GetTenThongTinCaNhans(id);

            if (listten.Count > 0)
            {
                txt4.Text = listten.First().Gt;
            }
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < hoSoThuViecDataGridView.Rows.Count; i++)
            {
                if (hoSoThuViecDataGridView.Rows[i].Cells[1].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            txt11.Clear(); txt2.Clear(); txt4.Clear(); txt5.Clear(); txt6.Clear(); txt7.Clear(); txt8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" ||  comboBox2.Text == "" || txt2.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "" || txt7.Text == "" || txt8.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox1.Text);
                if (selectRow == -1)
                {             
                    MessageBox.Show("Mã Nhân Viên Không Tồn Tại");
                }
                else
                {
                    this.hoSoThuViecTableAdapter.Sua(comboBox1.Text, comboBox2.Text, txt2.Text, txt4.Text, dateTimePicker1.Text, txt5.Text, txt8.Text, dateTimePicker2.Text, txt6.Text, txt7.Text, txt11.Text, comboBox2.Text);
                    this.hoSoThuViecTableAdapter.Fill(this.thongTinTaiKhoan.HoSoThuViec);
                    MessageBox.Show("Cập Nhật Hồ Sơ Thành Công");

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(comboBox2.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Nhân Viên!");
               
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.hoSoThuViecTableAdapter.Xoa(comboBox2.Text);
                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void hoSoThuViecBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hoSoThuViecBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void FormHosothuviec_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.HoSoThuViec' table. You can move, or remove it, as needed.
            this.hoSoThuViecTableAdapter.Fill(this.thongTinTaiKhoan.HoSoThuViec);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.Text;
            LoadMa(id);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox2.Text;
            LoadTen(id);
            LoadGT(id);
            LoadNS(id);
        }

        private void hoSoThuViecDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            comboBox1.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[0].Value.ToString();
            comboBox2.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[1].Value.ToString();
            txt2.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[2].Value.ToString();
            txt4.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[3].Value.ToString();
            dateTimePicker1.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[4].Value.ToString();
            txt5.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[5].Value.ToString();
            txt8.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[6].Value.ToString();
            dateTimePicker2.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[7].Value.ToString();
            txt6.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[8].Value.ToString();
            txt7.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[9].Value.ToString();
            txt11.Text = hoSoThuViecDataGridView.Rows[numrow].Cells[10].Value.ToString();
           
           
        }
    }
}
