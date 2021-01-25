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
    public partial class FormPhongbankhoa : Form
    {
        public FormPhongbankhoa()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select [Mã Bộ Phận] from dbo.BoPhan ", con);
            
            //com.Parameters.AddWithValue("@kq", textBox3.Text);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                mã_Bộ_PhậnComboBox.Items.Add(reader[0].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear(); textBox3.Clear(); 
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < phongDataGridView.Rows.Count; i++)
            {
                if (phongDataGridView.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectRow)
        {
            phongDataGridView.Rows[selectRow].Cells[0].Value = mã_Bộ_PhậnComboBox.Text;
            phongDataGridView.Rows[selectRow].Cells[1].Value = textBox2.Text;
            phongDataGridView.Rows[selectRow].Cells[2].Value = textBox3.Text;
            phongDataGridView.Rows[selectRow].Cells[3].Value = dateTimePicker1.Text;
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(mã_Bộ_PhậnComboBox.Text);
                if (selectRow == -1)
                {
                    selectRow = phongDataGridView.Rows.Add();
                    InsertUpdate(selectRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Phòng Ban Đã Tồn Tại");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(mã_Bộ_PhậnComboBox.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Mã Phòng Ban Không Tồn Tại");
                }
                else
                {
                    InsertUpdate(selectRow);
                    MessageBox.Show("Cập Nhật Hồ Sơ Thành Công");

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(mã_Bộ_PhậnComboBox.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Phòng!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    phongDataGridView.Rows.RemoveAt(selectRow);
                    MessageBox.Show("Xóa Phòng Ban Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phongBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phongBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void FormPhongbankhoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.BoPhan' table. You can move, or remove it, as needed.
            //this.boPhanTableAdapter.Fill(this.thongTinTaiKhoan.BoPhan);
            FormBophan fbp = new FormBophan();
            fbp.load();
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.Phong' table. You can move, or remove it, as needed.
            this.phongTableAdapter.Fill(this.thongTinTaiKhoan.Phong);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void phongDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            mã_Bộ_PhậnComboBox.Text = phongDataGridView.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = phongDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = phongDataGridView.Rows[numrow].Cells[2].Value.ToString();
            dateTimePicker1.Text = phongDataGridView.Rows[numrow].Cells[3].Value.ToString();
            
        }

        private void mã_Bộ_PhậnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

