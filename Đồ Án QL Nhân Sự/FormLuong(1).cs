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
    public partial class FormLuong : Form
    {
        public FormLuong()
        {
            InitializeComponent();
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private int GetSelectedRow1(string studentID)
        {
            for (int i = 0; i < dg2.Rows.Count; i++)
            {
                if (dg2.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectRow)
        {
            dataGridView1.Rows[selectRow].Cells[0].Value = txt1.Text;
            dataGridView1.Rows[selectRow].Cells[1].Value = txt4.Text;
            dataGridView1.Rows[selectRow].Cells[2].Value = txt5.Text;
            dataGridView1.Rows[selectRow].Cells[3].Value = dateTimePicker1.Text;
            dataGridView1.Rows[selectRow].Cells[4].Value = txt6.Text;
            dataGridView1.Rows[selectRow].Cells[5].Value = dateTimePicker2.Text;
            dataGridView1.Rows[selectRow].Cells[6].Value = txt8.Text;
            dataGridView1.Rows[selectRow].Cells[7].Value = dateTimePicker3.Text;
            dataGridView1.Rows[selectRow].Cells[8].Value = txt7.Text;
            dataGridView1.Rows[selectRow].Cells[9].Value = txt9.Text;
        }
        private void InsertUpdate1(int selectRow)
        {
            dg2.Rows[selectRow].Cells[0].Value = comboBox1.Text;
            dg2.Rows[selectRow].Cells[1].Value = txt10.Text;
            if (radioButton1.Checked == true)
                dg2.Rows[selectRow].Cells[2].Value = radioButton1.Text;
            else
                dg2.Rows[selectRow].Cells[2].Value = radioButton2.Text;
            dg2.Rows[selectRow].Cells[3].Value = txt12.Text;
            dg2.Rows[selectRow].Cells[4].Value = textBox1.Text;
            dg2.Rows[selectRow].Cells[5].Value = txt15.Text;
            dg2.Rows[selectRow].Cells[6].Value = dateTimePicker6.Text;
            dg2.Rows[selectRow].Cells[7].Value = txt18.Text;       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt1.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "" || txt8.Text == "" || txt7.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(txt1.Text);
                if (selectRow == -1)
                {
                    selectRow = dataGridView1.Rows.Add();
                    InsertUpdate(selectRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Lương Đã Tồn Tại");

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt1.Clear(); txt4.Clear(); txt5.Clear(); txt6.Clear(); txt7.Clear(); txt8.Clear(); txt9.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt1.Text == "" || txt4.Text == "" || txt5.Text == "" || txt6.Text == "" || txt8.Text == "" || txt7.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow(txt1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Mã Lương Không Tồn Tại");
                }
                else
                {
                    InsertUpdate(selectRow);
                    MessageBox.Show("Cập Nhật Thông Tin Thành Công");

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow(txt1.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Lương!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(selectRow);
                    MessageBox.Show("Xóa Lương Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt10.Clear(); txt12.Clear(); txt15.Clear(); txt18.Clear(); textBox1.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txt10.Text == "" || txt12.Text == "" || txt15.Text == "" || txt18.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow1(comboBox1.Text);
                if (selectRow == -1)
                {
                    selectRow = dg2.Rows.Add();
                    InsertUpdate1(selectRow);
                    MessageBox.Show("Thêm mới dữ liệu thành công");
                }
                else
                {

                    MessageBox.Show("Mã Nhân Viên Đã Tồn Tại");

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txt10.Text == "" || txt12.Text == "" || txt15.Text == "" || txt18.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
            }
            else
            {
                int selectRow = GetSelectedRow1(comboBox1.Text);
                if (selectRow == -1)
                {
                    MessageBox.Show("Mã Nhân Viên Không Tồn Tại");
                }
                else
                {
                    InsertUpdate1(selectRow);
                    MessageBox.Show("Cập Nhật Hồ Sơ Thành Công");

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int selectRow = GetSelectedRow1(comboBox1.Text);
            if (selectRow == -1)
            {
                MessageBox.Show("Không Tìm Thấy Mã Nhân Viên!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "YES/NO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    dg2.Rows.RemoveAt(selectRow);
                    MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
