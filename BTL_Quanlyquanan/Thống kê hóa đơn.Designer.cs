
namespace BTL_Quanlyquanan
{
    partial class fThongkehd
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
            this.dgvHoadon = new System.Windows.Forms.DataGridView();
            this.dtNgaytruoc = new System.Windows.Forms.DateTimePicker();
            this.dtNgaysau = new System.Windows.Forms.DateTimePicker();
            this.cbBan = new System.Windows.Forms.ComboBox();
            this.Inthongke = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoadon
            // 
            this.dgvHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoadon.Location = new System.Drawing.Point(12, 100);
            this.dgvHoadon.Name = "dgvHoadon";
            this.dgvHoadon.RowHeadersWidth = 51;
            this.dgvHoadon.RowTemplate.Height = 24;
            this.dgvHoadon.Size = new System.Drawing.Size(897, 345);
            this.dgvHoadon.TabIndex = 0;
            // 
            // dtNgaytruoc
            // 
            this.dtNgaytruoc.Location = new System.Drawing.Point(21, 54);
            this.dtNgaytruoc.Name = "dtNgaytruoc";
            this.dtNgaytruoc.Size = new System.Drawing.Size(230, 22);
            this.dtNgaytruoc.TabIndex = 1;
            // 
            // dtNgaysau
            // 
            this.dtNgaysau.Location = new System.Drawing.Point(294, 56);
            this.dtNgaysau.Name = "dtNgaysau";
            this.dtNgaysau.Size = new System.Drawing.Size(231, 22);
            this.dtNgaysau.TabIndex = 2;
            // 
            // cbBan
            // 
            this.cbBan.FormattingEnabled = true;
            this.cbBan.Location = new System.Drawing.Point(598, 56);
            this.cbBan.Name = "cbBan";
            this.cbBan.Size = new System.Drawing.Size(112, 24);
            this.cbBan.TabIndex = 3;
            // 
            // Inthongke
            // 
            this.Inthongke.Location = new System.Drawing.Point(771, 25);
            this.Inthongke.Name = "Inthongke";
            this.Inthongke.Size = new System.Drawing.Size(120, 55);
            this.Inthongke.TabIndex = 13;
            this.Inthongke.Text = "In thống kê";
            this.Inthongke.UseVisualStyleBackColor = true;
            this.Inthongke.Click += new System.EventHandler(this.Inthongke_Click);
            // 
            // fThongkehd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 457);
            this.Controls.Add(this.Inthongke);
            this.Controls.Add(this.cbBan);
            this.Controls.Add(this.dtNgaysau);
            this.Controls.Add(this.dtNgaytruoc);
            this.Controls.Add(this.dgvHoadon);
            this.Name = "fThongkehd";
            this.Text = "Thống kê hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoadon;
        private System.Windows.Forms.DateTimePicker dtNgaytruoc;
        private System.Windows.Forms.DateTimePicker dtNgaysau;
        private System.Windows.Forms.ComboBox cbBan;
        private System.Windows.Forms.Button Inthongke;
    }
}