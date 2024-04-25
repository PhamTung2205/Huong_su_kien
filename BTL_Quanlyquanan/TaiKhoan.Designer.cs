
namespace BTL_Quanlyquanan
{
    partial class TaiKhoan
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbMatkhau = new System.Windows.Forms.CheckBox();
            this.rdbAdmin = new System.Windows.Forms.RadioButton();
            this.rdbNhanvien = new System.Windows.Forms.RadioButton();
            this.btnSuatk = new System.Windows.Forms.Button();
            this.btnTimtk = new System.Windows.Forms.Button();
            this.btnLammoitk = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnXoatk = new System.Windows.Forms.Button();
            this.btnThemtk = new System.Windows.Forms.Button();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvTaikhoan = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtNgaybatdau = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaikhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtNgaybatdau);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbMatkhau);
            this.panel3.Controls.Add(this.rdbAdmin);
            this.panel3.Controls.Add(this.rdbNhanvien);
            this.panel3.Controls.Add(this.btnSuatk);
            this.panel3.Controls.Add(this.btnTimtk);
            this.panel3.Controls.Add(this.btnLammoitk);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnXoatk);
            this.panel3.Controls.Add(this.btnThemtk);
            this.panel3.Controls.Add(this.txtMatkhau);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtTendangnhap);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 572);
            this.panel3.TabIndex = 4;
            // 
            // cbMatkhau
            // 
            this.cbMatkhau.AutoSize = true;
            this.cbMatkhau.Location = new System.Drawing.Point(404, 213);
            this.cbMatkhau.Name = "cbMatkhau";
            this.cbMatkhau.Size = new System.Drawing.Size(18, 17);
            this.cbMatkhau.TabIndex = 16;
            this.cbMatkhau.UseVisualStyleBackColor = true;
            this.cbMatkhau.Click += new System.EventHandler(this.cbMatkhau_Click);
            // 
            // rdbAdmin
            // 
            this.rdbAdmin.AutoSize = true;
            this.rdbAdmin.Location = new System.Drawing.Point(290, 294);
            this.rdbAdmin.Name = "rdbAdmin";
            this.rdbAdmin.Size = new System.Drawing.Size(68, 21);
            this.rdbAdmin.TabIndex = 15;
            this.rdbAdmin.TabStop = true;
            this.rdbAdmin.Text = "Admin";
            this.rdbAdmin.UseVisualStyleBackColor = true;
            // 
            // rdbNhanvien
            // 
            this.rdbNhanvien.AutoSize = true;
            this.rdbNhanvien.Location = new System.Drawing.Point(68, 294);
            this.rdbNhanvien.Name = "rdbNhanvien";
            this.rdbNhanvien.Size = new System.Drawing.Size(93, 21);
            this.rdbNhanvien.TabIndex = 14;
            this.rdbNhanvien.TabStop = true;
            this.rdbNhanvien.Text = "Nhân viên";
            this.rdbNhanvien.UseVisualStyleBackColor = true;
            // 
            // btnSuatk
            // 
            this.btnSuatk.Location = new System.Drawing.Point(162, 366);
            this.btnSuatk.Name = "btnSuatk";
            this.btnSuatk.Size = new System.Drawing.Size(122, 55);
            this.btnSuatk.TabIndex = 13;
            this.btnSuatk.Text = "Sửa";
            this.btnSuatk.UseVisualStyleBackColor = true;
            this.btnSuatk.Click += new System.EventHandler(this.btnSuatk_Click);
            // 
            // btnTimtk
            // 
            this.btnTimtk.Location = new System.Drawing.Point(68, 479);
            this.btnTimtk.Name = "btnTimtk";
            this.btnTimtk.Size = new System.Drawing.Size(122, 55);
            this.btnTimtk.TabIndex = 12;
            this.btnTimtk.Text = "Tìm";
            this.btnTimtk.UseVisualStyleBackColor = true;
            this.btnTimtk.Click += new System.EventHandler(this.btnTimtk_Click);
            // 
            // btnLammoitk
            // 
            this.btnLammoitk.Location = new System.Drawing.Point(280, 479);
            this.btnLammoitk.Name = "btnLammoitk";
            this.btnLammoitk.Size = new System.Drawing.Size(118, 55);
            this.btnLammoitk.TabIndex = 11;
            this.btnLammoitk.Text = "Làm mới";
            this.btnLammoitk.UseVisualStyleBackColor = true;
            this.btnLammoitk.Click += new System.EventHandler(this.btnLammoitk_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(165, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 33);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tài Khoản";
            // 
            // btnXoatk
            // 
            this.btnXoatk.Location = new System.Drawing.Point(322, 366);
            this.btnXoatk.Name = "btnXoatk";
            this.btnXoatk.Size = new System.Drawing.Size(122, 55);
            this.btnXoatk.TabIndex = 8;
            this.btnXoatk.Text = "Xóa";
            this.btnXoatk.UseVisualStyleBackColor = true;
            this.btnXoatk.Click += new System.EventHandler(this.btnXoatk_Click);
            // 
            // btnThemtk
            // 
            this.btnThemtk.Location = new System.Drawing.Point(6, 366);
            this.btnThemtk.Name = "btnThemtk";
            this.btnThemtk.Size = new System.Drawing.Size(118, 55);
            this.btnThemtk.TabIndex = 6;
            this.btnThemtk.Text = "Thêm";
            this.btnThemtk.UseVisualStyleBackColor = true;
            this.btnThemtk.Click += new System.EventHandler(this.btnThemtk_Click);
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(198, 211);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(173, 22);
            this.txtMatkhau.TabIndex = 5;
            this.txtMatkhau.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 24);
            this.label8.TabIndex = 4;
            this.label8.Text = "Mật khẩu";
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.Location = new System.Drawing.Point(198, 134);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.Size = new System.Drawing.Size(173, 22);
            this.txtTendangnhap.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tên đăng nhập";
            // 
            // dgvTaikhoan
            // 
            this.dgvTaikhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaikhoan.Location = new System.Drawing.Point(500, 12);
            this.dgvTaikhoan.Name = "dgvTaikhoan";
            this.dgvTaikhoan.RowHeadersWidth = 51;
            this.dgvTaikhoan.RowTemplate.Height = 24;
            this.dgvTaikhoan.Size = new System.Drawing.Size(469, 572);
            this.dgvTaikhoan.TabIndex = 5;
            this.dgvTaikhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaikhoan_CellClick);
            this.dgvTaikhoan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTaikhoan_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ngày bắt đầu";
            // 
            // dtNgaybatdau
            // 
            this.dtNgaybatdau.Location = new System.Drawing.Point(198, 253);
            this.dtNgaybatdau.Name = "dtNgaybatdau";
            this.dtNgaybatdau.Size = new System.Drawing.Size(246, 22);
            this.dtNgaybatdau.TabIndex = 18;
            // 
            // TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 596);
            this.Controls.Add(this.dgvTaikhoan);
            this.Controls.Add(this.panel3);
            this.Name = "TaiKhoan";
            this.Text = "TaiKhoan";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaikhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbAdmin;
        private System.Windows.Forms.RadioButton rdbNhanvien;
        private System.Windows.Forms.Button btnSuatk;
        private System.Windows.Forms.Button btnTimtk;
        private System.Windows.Forms.Button btnLammoitk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnXoatk;
        private System.Windows.Forms.Button btnThemtk;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvTaikhoan;
        private System.Windows.Forms.CheckBox cbMatkhau;
        private System.Windows.Forms.DateTimePicker dtNgaybatdau;
        private System.Windows.Forms.Label label1;
    }
}