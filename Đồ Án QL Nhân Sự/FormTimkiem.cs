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
    public partial class FormTimkiem : Form
    {
        public FormTimkiem()
        {
            InitializeComponent();
        }

        private void FormTimkiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'thongTinTaiKhoan.ThongTinDayDu' table. You can move, or remove it, as needed.
            this.thongTinDayDuTableAdapter.Fill(this.thongTinTaiKhoan.ThongTinDayDu);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == true)
            {
                this.thongTinDayDuTableAdapter.TimMNV(this.thongTinTaiKhoan.ThongTinDayDu, textBox1.Text);
                
            }
            if (radioButton2.Checked == true)
            {
                this.thongTinDayDuTableAdapter.TimHoTen(this.thongTinTaiKhoan.ThongTinDayDu, textBox1.Text);

            }
            if (radioButton3.Checked == true)
            {
                this.thongTinDayDuTableAdapter.TimCM(this.thongTinTaiKhoan.ThongTinDayDu, textBox1.Text);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < thongTinDayDuDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = thongTinDayDuDataGridView.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < thongTinDayDuDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < thongTinDayDuDataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = thongTinDayDuDataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }
        }
    }
}
