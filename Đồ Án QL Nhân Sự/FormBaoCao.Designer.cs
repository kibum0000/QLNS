
namespace Đồ_Án_QL_Nhân_Sự
{
    partial class FormBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.LuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ThongTinLuongDataSet = new Đồ_Án_QL_Nhân_Sự.ThongTinLuongDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.LuongTableAdapter = new Đồ_Án_QL_Nhân_Sự.ThongTinLuongDataSetTableAdapters.LuongTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LuongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThongTinLuongDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // LuongBindingSource
            // 
            this.LuongBindingSource.DataMember = "Luong";
            this.LuongBindingSource.DataSource = this.ThongTinLuongDataSet;
            // 
            // ThongTinLuongDataSet
            // 
            this.ThongTinLuongDataSet.DataSetName = "ThongTinLuongDataSet";
            this.ThongTinLuongDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ThongTinhLuong";
            reportDataSource1.Value = this.LuongBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Đồ_Án_QL_Nhân_Sự.BaoCaoLuong.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 110);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 328);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(161, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(439, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bảng Báo Cáo Lương";
            // 
            // LuongTableAdapter
            // 
            this.LuongTableAdapter.ClearBeforeFill = true;
            // 
            // FormBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Đồ_Án_QL_Nhân_Sự.Properties.Resources._462d8b297f3fbaf4277a1df62bbf1f521;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaoCao";
            this.Text = "FormBaoCao";
            this.Load += new System.EventHandler(this.FormBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThongTinLuongDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource LuongBindingSource;
        private ThongTinLuongDataSet ThongTinLuongDataSet;
        private ThongTinLuongDataSetTableAdapters.LuongTableAdapter LuongTableAdapter;
    }
}