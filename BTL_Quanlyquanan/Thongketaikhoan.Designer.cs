
namespace BTL_Quanlyquanan
{
    partial class Thongketaikhoan
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
            this.btnInthongke = new System.Windows.Forms.Button();
            this.dgvTaikhoan = new System.Windows.Forms.DataGridView();
            this.txtnam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInthongke
            // 
            this.btnInthongke.Location = new System.Drawing.Point(582, 42);
            this.btnInthongke.Name = "btnInthongke";
            this.btnInthongke.Size = new System.Drawing.Size(122, 68);
            this.btnInthongke.TabIndex = 0;
            this.btnInthongke.Text = "InThongke";
            this.btnInthongke.UseVisualStyleBackColor = true;
            this.btnInthongke.Click += new System.EventHandler(this.btnInthongke_Click);
            // 
            // dgvTaikhoan
            // 
            this.dgvTaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaikhoan.Location = new System.Drawing.Point(12, 116);
            this.dgvTaikhoan.Name = "dgvTaikhoan";
            this.dgvTaikhoan.RowHeadersWidth = 51;
            this.dgvTaikhoan.RowTemplate.Height = 24;
            this.dgvTaikhoan.Size = new System.Drawing.Size(707, 328);
            this.dgvTaikhoan.TabIndex = 2;
            // 
            // txtnam
            // 
            this.txtnam.Location = new System.Drawing.Point(91, 54);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(100, 22);
            this.txtnam.TabIndex = 3;
            // 
            // Thongketaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.txtnam);
            this.Controls.Add(this.dgvTaikhoan);
            this.Controls.Add(this.btnInthongke);
            this.Name = "Thongketaikhoan";
            this.Text = "Thongketaikhoan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaikhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInthongke;
        private System.Windows.Forms.DataGridView dgvTaikhoan;
        private System.Windows.Forms.TextBox txtnam;
    }
}