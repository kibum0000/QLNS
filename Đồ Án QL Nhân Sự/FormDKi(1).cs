using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_Án_QL_Nhân_Sự
{
    public partial class FormDKi : Form
    {
        string imgloc = "";
        public FormDKi()
        {
            InitializeComponent();
            LoadBoPhan();
            
        }
        void LoadBoPhan()
        {
            List<BoPhan> listbophan = BoPhanDAO.Instance.GetBoPhans();
            comboBox1.DataSource = listbophan;
            comboBox1.DisplayMember = "Id";

        }
        void LoadChucVu(string id)
        {
            List<BoPhan> listbophan = BoPhanDAO.Instance.GetTenBoPhans(id);
            if (listbophan.Count > 0)
            {
                textBox12.Text = listbophan.First().Name;
            }
            
        }
        void LoadPhong(string id)
        {
            List<Phong> listphong = PhongDAO.Instance.GetPhongs(id);
            comboBox2.DataSource = listphong;
            comboBox2.DisplayMember = "Id";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
           // textBox8.Clear();
            textBox11.Clear();
            textBox12.Clear();
           // textBox14.Clear();
           // textBox15.Clear();
           // textBox19.Clear();
            textBox9.Clear();
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < thongTinDangKyDataGridView.Rows.Count; i++)
            {
                if (thongTinDangKyDataGridView.Rows[i].Cells[2].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            if (textBox3.Text == "" || textBox4.Text == "" || textBox9.Text == "" || textBox11.Text == "" || textBox12.Text == ""  )
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            { 
                int selectRow = GetSelectedRow(textBox3.Text);
                if (selectRow == -1)
                {
                    if (nam.Checked == true)
                    {
                        this.thongTinDangKyTableAdapter.them(comboBox1.Text, comboBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, nam.Text, textBox9.Text, textBox11.Text, textBox12.Text, comboBox3.Text, dateTimePicker3.Text, dateTimePicker4.Text,img);
                    }
                    else
                    {
                        this.thongTinDangKyTableAdapter.them(comboBox1.Text, comboBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, nu.Text, textBox9.Text, textBox11.Text, textBox12.Text, comboBox3.Text, dateTimePicker3.Text, dateTimePicker4.Text, img);
                    }
                     
                    this.thongTinDangKyTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinDangKy);

                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {
                
                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            int selectRow = GetSelectedRow(textBox3.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Mã Nhân Viên Không Tồn Tại");


                
            }
            else
            {
                if (nam.Checked == true)
                {
                    this.thongTinDangKyTableAdapter.Sua(comboBox1.Text, comboBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, nam.Text, textBox9.Text, textBox11.Text, textBox12.Text, comboBox3.Text, dateTimePicker3.Text, dateTimePicker4.Text,img,textBox3.Text);
                }
                else
                {
                    this.thongTinDangKyTableAdapter.Sua(comboBox1.Text, comboBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, nu.Text, textBox9.Text, textBox11.Text, textBox12.Text, comboBox3.Text, dateTimePicker3.Text, dateTimePicker4.Text, img, textBox3.Text);
                }
                this.thongTinDangKyTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinDangKy);
                MessageBox.Show("Cập Nhật Dữ Liệu Thành Công");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(textBox3.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Nhân Viên!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.thongTinDangKyTableAdapter.Xoa(textBox3.Text);
                    this.thongTinDangKyTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinDangKy);
                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void thongTinDangKyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDKi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.ThongTinDangKy' table. You can move, or remove it, as needed.
            this.thongTinDangKyTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinDangKy);

        }

        private void thongTinDangKyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.thongTinDangKyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox1.Text;
            LoadPhong(id);
            LoadChucVu(id);
        }

        private void thongTinDangKyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            comboBox1.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[0].Value.ToString();
            comboBox2.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[2].Value.ToString();
            textBox4.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[3].Value.ToString();
            dateTimePicker1.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[4].Value.ToString();
            if(thongTinDangKyDataGridView.Rows[numrow].Cells[5].Value.ToString() =="Nam")
            {
                nam.Checked = true;
            }
            else
            {
                nu.Checked = true;
            }
            
            textBox9.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[6].Value.ToString();
            textBox11.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[7].Value.ToString();
            textBox12.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[8].Value.ToString();
            comboBox3.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[9].Value.ToString();
            dateTimePicker3.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[10].Value.ToString();
            dateTimePicker4.Text = thongTinDangKyDataGridView.Rows[numrow].Cells[11].Value.ToString();
            byte[] img = (byte[])(thongTinDangKyDataGridView.CurrentRow.Cells[12].Value);
            if (img == null)
            {
                pictureBox1.Image=null;
            }
            else
            {
                MemoryStream ms = new MemoryStream((byte[])thongTinDangKyDataGridView.CurrentRow.Cells[12].Value);
                pictureBox1.Image = Image.FromStream(ms);
            }
            
            
        }

        private void thongTinDangKyBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
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

        private void thongTinDangKyDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources._default;
        }
    }
}
