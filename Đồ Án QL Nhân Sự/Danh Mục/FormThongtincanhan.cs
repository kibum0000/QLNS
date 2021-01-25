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
    public partial class FormThongtincanhan : Form
    {
        
        public FormThongtincanhan()
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
                textBox1.Text = listtennv.First().Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox12.Clear();
            textBox17.Clear();
            
        }
        private int GetSelectedRow(string studentID)
        {
             for (int i = 0; i < thongTinCaNhanDataGridView.Rows.Count; i++)
             {
                 if (thongTinCaNhanDataGridView.Rows[i].Cells[0].Value.ToString() == studentID)
                 {
                     return i;
                 }
             }
            return -1;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" ||  textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox12.Text == "" )
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Không tìm thấy Mã Nhân Viên");

                }
                else
                {

                    
                    if (textBox4.Text == "")
                    {
                        // textBox4.Text = "Không";
                        this.thongTinCaNhanTableAdapter.Sua(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, "Không", textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text, comboBox1.Text);
                        // this.thongTinCaNhanTableAdapter.Them(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, "Không", textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text);
                        this.thongTinCaNhanTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinCaNhan);
                        MessageBox.Show("Thêm mới dữ liệu thành công");
                    }
                    else
                    {
                        this.thongTinCaNhanTableAdapter.Sua(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text, comboBox1.Text);

                        // this.thongTinCaNhanTableAdapter.Them(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text);
                        this.thongTinCaNhanTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinCaNhan);
                        MessageBox.Show("Thêm mới dữ liệu thành công");
                    }

                }
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(comboBox1.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Nhân Viên!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.thongTinCaNhanTableAdapter.Xoa(comboBox1.Text);
                    this.thongTinCaNhanTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinCaNhan);
                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void thông_Tin_Nhân_ViênBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.thông_Tin_Nhân_ViênBindingSource.EndEdit();
          //  this.tableAdapterManager.UpdateAll(this.thongTinNhanVien);

        }

        private void FormThongtincanhan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.ThongTinCaNhan' table. You can move, or remove it, as needed.
            this.thongTinCaNhanTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinCaNhan);
            // TODO: This line of code loads data into the 'thongTinNhanVien.Thông_Tin_Nhân_Viên' table. You can move, or remove it, as needed.
            // this.thông_Tin_Nhân_ViênTableAdapter.Fill(this.thongTinNhanVien.Thông_Tin_Nhân_Viên);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.Text;

            LoadTenNhanVien(id);
        }

        private void thongTinCaNhanBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void thongTinCaNhanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            comboBox1.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[0].Value.ToString();
            textBox1.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox2.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[2].Value.ToString();
            textBox3.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[3].Value.ToString();
            textBox4.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[4].Value.ToString();
            textBox5.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[5].Value.ToString();
            textBox6.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[6].Value.ToString();
            textBox7.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[7].Value.ToString();
            textBox8.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[8].Value.ToString();
            textBox9.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[9].Value.ToString();
            textBox12.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[10].Value.ToString();
            textBox17.Text = thongTinCaNhanDataGridView.Rows[numrow].Cells[11].Value.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox1.Text);
                if (selectRow == -1)
                {
                   
                    if (textBox4.Text == "")
                    {
                        // textBox4.Text = "Không";
                        //this.thongTinCaNhanTableAdapter.Sua(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, "Không", textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text, comboBox1.Text);
                        this.thongTinCaNhanTableAdapter.Them(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, "Không", textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text);
                        this.thongTinCaNhanTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinCaNhan);
                        MessageBox.Show("Thêm mới dữ liệu thành công");
                    }
                    else
                    {
                        //this.thongTinCaNhanTableAdapter.Sua(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text, comboBox1.Text);

                        this.thongTinCaNhanTableAdapter.Them(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, int.Parse(textBox12.Text), textBox17.Text);
                        this.thongTinCaNhanTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinCaNhan);
                        MessageBox.Show("Thêm mới dữ liệu thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }
    }
}
