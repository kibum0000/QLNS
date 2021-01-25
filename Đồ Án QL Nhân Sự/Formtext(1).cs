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
    public partial class Formtext : Form
    {
        string imgloc = "";
        public Formtext()
        {
            InitializeComponent();
            LoadBoPhan();
           
        }
        void LoadBoPhan()
        {
           // List<BoPhan> listbophan = BoPhanDAO.Instance.GetBoPhans();
           // comboBox1.DataSource = listbophan;
           // comboBox1.DisplayMember = "Name";
        }
        void LoadPhong(int id)
        {
            //List<Phong> listphong = PhongDAO.Instance.GetPhongs(id);
           // comboBox2.DataSource = listphong;
           // comboBox2.DisplayMember = "Name";
        }
        private void Formtext_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.ThongTinDangKy' table. You can move, or remove it, as needed.
            this.thongTinDangKyTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinDangKy);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            BoPhan selected = cb.SelectedItem as BoPhan;
          //  id = selected.Id;

            
            LoadPhong(id);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            this.thongTinDangKyTableAdapter.themhinhanh(img, textBox1.Text);
        }

        private void thongTinDangKyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.thongTinDangKyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.thongTinTaiKhoan);

        }
    }
}
