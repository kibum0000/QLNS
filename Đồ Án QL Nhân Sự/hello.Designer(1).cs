
namespace Đồ_Án_QL_Nhân_Sự
{
    partial class hello
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
            this.lbngay = new System.Windows.Forms.Label();
            this.lbthu = new System.Windows.Forms.Label();
            this.lbgio = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbngay
            // 
            this.lbngay.AutoSize = true;
            this.lbngay.BackColor = System.Drawing.Color.Transparent;
            this.lbngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbngay.Location = new System.Drawing.Point(192, 285);
            this.lbngay.Name = "lbngay";
            this.lbngay.Size = new System.Drawing.Size(97, 42);
            this.lbngay.TabIndex = 5;
            this.lbngay.Text = "label";
            // 
            // lbthu
            // 
            this.lbthu.AutoSize = true;
            this.lbthu.BackColor = System.Drawing.Color.Transparent;
            this.lbthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthu.Location = new System.Drawing.Point(192, 181);
            this.lbthu.Name = "lbthu";
            this.lbthu.Size = new System.Drawing.Size(97, 42);
            this.lbthu.TabIndex = 4;
            this.lbthu.Text = "label";
            // 
            // lbgio
            // 
            this.lbgio.AutoSize = true;
            this.lbgio.BackColor = System.Drawing.Color.Transparent;
            this.lbgio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgio.Location = new System.Drawing.Point(192, 85);
            this.lbgio.Name = "lbgio";
            this.lbgio.Size = new System.Drawing.Size(84, 37);
            this.lbgio.TabIndex = 3;
            this.lbgio.Text = "label";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Đồ_Án_QL_Nhân_Sự.Properties.Resources._462d8b297f3fbaf4277a1df62bbf1f52;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.lbngay);
            this.Controls.Add(this.lbthu);
            this.Controls.Add(this.lbgio);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "hello";
            this.Text = "hello";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbngay;
        private System.Windows.Forms.Label lbthu;
        private System.Windows.Forms.Label lbgio;
        private System.Windows.Forms.Timer timer1;
    }
}