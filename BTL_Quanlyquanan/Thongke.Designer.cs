
namespace BTL_Quanlyquanan
{
    partial class Thongke
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLammoi = new System.Windows.Forms.Button();
            this.btnThongketheotien = new System.Windows.Forms.Button();
            this.btnThongkehoadon = new System.Windows.Forms.Button();
            this.plThongke = new System.Windows.Forms.Panel();
            this.btnThongkethoenam = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnThongkethoenam);
            this.panel4.Controls.Add(this.btnLammoi);
            this.panel4.Controls.Add(this.btnThongketheotien);
            this.panel4.Controls.Add(this.btnThongkehoadon);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(939, 84);
            this.panel4.TabIndex = 10;
            // 
            // btnLammoi
            // 
            this.btnLammoi.Location = new System.Drawing.Point(670, 15);
            this.btnLammoi.Name = "btnLammoi";
            this.btnLammoi.Size = new System.Drawing.Size(118, 55);
            this.btnLammoi.TabIndex = 10;
            this.btnLammoi.Text = "Làm mới";
            this.btnLammoi.UseVisualStyleBackColor = true;
            this.btnLammoi.Click += new System.EventHandler(this.btnLammoi_Click);
            // 
            // btnThongketheotien
            // 
            this.btnThongketheotien.Location = new System.Drawing.Point(279, 15);
            this.btnThongketheotien.Name = "btnThongketheotien";
            this.btnThongketheotien.Size = new System.Drawing.Size(118, 55);
            this.btnThongketheotien.TabIndex = 9;
            this.btnThongketheotien.Text = "Thống kê theo tiền";
            this.btnThongketheotien.UseVisualStyleBackColor = true;
            this.btnThongketheotien.Click += new System.EventHandler(this.btnThongketheotien_Click);
            // 
            // btnThongkehoadon
            // 
            this.btnThongkehoadon.Location = new System.Drawing.Point(50, 15);
            this.btnThongkehoadon.Name = "btnThongkehoadon";
            this.btnThongkehoadon.Size = new System.Drawing.Size(118, 55);
            this.btnThongkehoadon.TabIndex = 8;
            this.btnThongkehoadon.Text = "Thống kê hóa đơn";
            this.btnThongkehoadon.UseVisualStyleBackColor = true;
            this.btnThongkehoadon.Click += new System.EventHandler(this.btnThongkehoadon_Click);
            // 
            // plThongke
            // 
            this.plThongke.Location = new System.Drawing.Point(12, 102);
            this.plThongke.Name = "plThongke";
            this.plThongke.Size = new System.Drawing.Size(939, 504);
            this.plThongke.TabIndex = 11;
            // 
            // btnThongkethoenam
            // 
            this.btnThongkethoenam.Location = new System.Drawing.Point(462, 15);
            this.btnThongkethoenam.Name = "btnThongkethoenam";
            this.btnThongkethoenam.Size = new System.Drawing.Size(118, 55);
            this.btnThongkethoenam.TabIndex = 11;
            this.btnThongkethoenam.Text = "Thống kê Theo Nam";
            this.btnThongkethoenam.UseVisualStyleBackColor = true;
            this.btnThongkethoenam.Click += new System.EventHandler(this.btnThongkethoenam_Click);
            // 
            // Thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 615);
            this.Controls.Add(this.plThongke);
            this.Controls.Add(this.panel4);
            this.Name = "Thongke";
            this.Text = "Thongke";
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnThongkehoadon;
        private System.Windows.Forms.Panel plThongke;
        private System.Windows.Forms.Button btnThongketheotien;
        private System.Windows.Forms.Button btnLammoi;
        private System.Windows.Forms.Button btnThongkethoenam;
    }
}