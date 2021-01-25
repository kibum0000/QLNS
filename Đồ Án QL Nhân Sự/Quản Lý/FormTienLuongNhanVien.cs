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
    public partial class FormTienLuongNhanVien : Form
    {
        public FormTienLuongNhanVien()
        {
            InitializeComponent();
            /*SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            SqlCommand com = new SqlCommand(@"Select [Mã Bộ Phận] from dbo.Phong ", con);
            SqlCommand cm = new SqlCommand(@"Select [Mã Phòng] from dbo.Phong ", con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
                
            }*/
           


           
            LoadBoPhan();
            

        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < luongDataGridView.Rows.Count; i++)
            {
                if (luongDataGridView.Rows[i].Cells[2].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        void LoadBoPhan()
        {
            List<BoPhan> listbophan = BoPhanDAO.Instance.GetBoPhans();
            comboBox1.DataSource = listbophan;
            comboBox1.DisplayMember = "Id";

        }
        void LoadPhong(string id)
        {
           List<Phong> listphong = PhongDAO.Instance.GetPhongs(id);
            comboBox3.DataSource = listphong;
            comboBox3.DisplayMember = "Id";
        }

        private void luongBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.luongBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }
        void LoadHoSo(string id)
        {
            List<HoSoNV> listhoso = HoSoNVDAO.Instance.GetHoSoNVs(id);
            comboBox2.DataSource = listhoso;
            comboBox2.DisplayMember = "Id";
        }

        void LoadNhanVien(string id)
        {
            List<HoSoNV> listhoso = HoSoNVDAO.Instance.GetNVs(id);

            if (listhoso.Count > 0)
            {
                textBox1.Text = listhoso.First().Name;
            }
        }
        void LoadLoaiNhanVien(string id)
        {
            List<ThongTinDangKy> listhoso = ThongTinDangKyDAO.Instance.GetLoais(id);

            if (listhoso.Count > 0)
            {
                textBox3.Text = listhoso.First().Loai;
            }
        }


        private void FormTienLuongNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.Luong' table. You can move, or remove it, as needed.
            this.luongTableAdapter.Fill(this.thongTinTaiKhoan.Luong);

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = comboBox2.Text;

            LoadNhanVien(id);
            LoadLoaiNhanVien(id);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           // ComboBox cb = sender as ComboBox;
            //if (cb.SelectedItem == null)
             //   return;
            
            //BoPhan selected = cb.SelectedItem as BoPhan;

            string id = comboBox1.Text;
            
            LoadPhong(id);
            /*SqlConnection con = new SqlConnection(global::Đồ_Án_QL_Nhân_Sự.Properties.Settings.Default.ThongTinNSConnectionString);
            string t = @"Select [Mã Phòng]from dbo.BoPhan,dbo.Phong where dbo.BoPhan.[Mã Bộ Phận] = dbo.Phong.[Mã Bộ Phận] and dbo.Phong.[Mã Bộ Phận]= "+ comboBox1.Text;
            //DataTable data = DataProvider.Instance.ExecuteQuery(t);
            SqlDataAdapter dt = new SqlDataAdapter(t,con);
            DataSet dts = new DataSet();
            dt.Fill(dts);
            comboBox2.DataSource = dts;*/
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            string id = comboBox3.Text;
            LoadHoSo(id);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox1.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox14.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox2.Text);
                if (selectRow == -1)
                {
                    if(textBox2.Text=="")
                    {
                        textBox2.Text = "Không";
                    }
                    this.luongTableAdapter.Them(comboBox1.Text,comboBox3.Text,comboBox2.Text,textBox1.Text, double.Parse(textBox11.Text),int.Parse(textBox14.Text),int.Parse(textBox12.Text),textBox2.Text,textBox3.Text,int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                    this.luongTableAdapter.Fill(this.thongTinTaiKhoan.Luong);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }

        private void luongDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            comboBox1.Text = luongDataGridView.Rows[numrow].Cells[0].Value.ToString();
            comboBox3.Text = luongDataGridView.Rows[numrow].Cells[1].Value.ToString();
            comboBox2.Text = luongDataGridView.Rows[numrow].Cells[2].Value.ToString();
            textBox1.Text = luongDataGridView.Rows[numrow].Cells[3].Value.ToString();
            textBox11.Text = luongDataGridView.Rows[numrow].Cells[4].Value.ToString();
            textBox14.Text = luongDataGridView.Rows[numrow].Cells[5].Value.ToString();
            textBox12.Text = luongDataGridView.Rows[numrow].Cells[6].Value.ToString();
            textBox2.Text = luongDataGridView.Rows[numrow].Cells[7].Value.ToString();
            textBox3.Text = luongDataGridView.Rows[numrow].Cells[8].Value.ToString();
            textBox4.Text = luongDataGridView.Rows[numrow].Cells[9].Value.ToString();
            textBox5.Text =luongDataGridView.Rows[numrow].Cells[10].Value.ToString();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox1.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox14.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(comboBox2.Text);
                if (selectRow == -1)
                {
                    
                    MessageBox.Show("Không tim thấy mã nhân viên");
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        textBox2.Text = "Không";
                    }
                    this.luongTableAdapter.Sua(comboBox1.Text, comboBox3.Text, comboBox2.Text, textBox1.Text, double.Parse(textBox11.Text), int.Parse(textBox14.Text), int.Parse(textBox12.Text), textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), int.Parse(textBox5.Text), comboBox2.Text);
                    this.luongTableAdapter.Fill(this.thongTinTaiKhoan.Luong);
                    MessageBox.Show("Sửa dử liệu thành công");

                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(textBox12.Text=="")
            {       
                    textBox12.Text = "0";
            }
            if(textBox14.Text=="")
            {
                textBox14.Text = "0";
            }
           
            if (comboBox6.Text == "")
            {
                comboBox6.Text = "0";
            }
            if (comboBox5.Text == "")
            {
                comboBox5.Text = "0";
            }
            if (comboBox5.Text == "0")
            {
                
                double n2 = Convert.ToDouble(comboBox6.Text);
                double n3 = 40000 * Convert.ToDouble(textBox12.Text);
                double n4 = 150000 * Convert.ToDouble(textBox14.Text);

                textBox11.Text = (n2 + n3 - n4).ToString();
            }
            else
            {
                comboBox6.Text = "0";
                double n1 = Convert.ToDouble(comboBox5.Text);
                double n3 = 40000 * Convert.ToDouble(textBox12.Text);
                double n4 = 150000 * Convert.ToDouble(textBox14.Text);

                textBox11.Text = (n1 + n3 - n4).ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(comboBox2.Text);
            if (selectRow == -1)
            {
                throw new Exception("Không Tìm Thấy Mã Nhân Viên!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.luongTableAdapter.Xoa(comboBox2.Text);
                    this.luongTableAdapter.Fill(this.thongTinTaiKhoan.Luong);
                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void luongDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
