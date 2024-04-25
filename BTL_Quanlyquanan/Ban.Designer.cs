
namespace BTL_Quanlyquanan
{
    partial class Ban
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLammoiban = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaBan = new System.Windows.Forms.Button();
            this.btnThemBan = new System.Windows.Forms.Button();
            this.txtTrangthaiban = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaban = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBan = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLammoiban);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnXoaBan);
            this.panel2.Controls.Add(this.btnThemBan);
            this.panel2.Controls.Add(this.txtTrangthaiban);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtMaban);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 563);
            this.panel2.TabIndex = 3;
            // 
            // btnLammoiban
            // 
            this.btnLammoiban.Location = new System.Drawing.Point(345, 366);
            this.btnLammoiban.Name = "btnLammoiban";
            this.btnLammoiban.Size = new System.Drawing.Size(118, 55);
            this.btnLammoiban.TabIndex = 11;
            this.btnLammoiban.Text = "Làm mới";
            this.btnLammoiban.UseVisualStyleBackColor = true;
            this.btnLammoiban.Click += new System.EventHandler(this.btnLammoiban_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 33);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bàn ăn";
            // 
            // btnXoaBan
            // 
            this.btnXoaBan.Location = new System.Drawing.Point(171, 366);
            this.btnXoaBan.Name = "btnXoaBan";
            this.btnXoaBan.Size = new System.Drawing.Size(122, 55);
            this.btnXoaBan.TabIndex = 8;
            this.btnXoaBan.Text = "Xóa";
            this.btnXoaBan.UseVisualStyleBackColor = true;
            this.btnXoaBan.Click += new System.EventHandler(this.btnXoaBan_Click);
            // 
            // btnThemBan
            // 
            this.btnThemBan.Location = new System.Drawing.Point(9, 366);
            this.btnThemBan.Name = "btnThemBan";
            this.btnThemBan.Size = new System.Drawing.Size(118, 55);
            this.btnThemBan.TabIndex = 6;
            this.btnThemBan.Text = "Thêm";
            this.btnThemBan.UseVisualStyleBackColor = true;
            this.btnThemBan.Click += new System.EventHandler(this.btnThemBan_Click);
            // 
            // txtTrangthaiban
            // 
            this.txtTrangthaiban.Location = new System.Drawing.Point(171, 211);
            this.txtTrangthaiban.Name = "txtTrangthaiban";
            this.txtTrangthaiban.ReadOnly = true;
            this.txtTrangthaiban.Size = new System.Drawing.Size(132, 22);
            this.txtTrangthaiban.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Trạng thái bàn";
            // 
            // txtMaban
            // 
            this.txtMaban.Location = new System.Drawing.Point(173, 134);
            this.txtMaban.Name = "txtMaban";
            this.txtMaban.Size = new System.Drawing.Size(132, 22);
            this.txtMaban.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 24);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mã Bàn";
            // 
            // dgvBan
            // 
            this.dgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBan.Location = new System.Drawing.Point(500, 12);
            this.dgvBan.Name = "dgvBan";
            this.dgvBan.RowHeadersWidth = 51;
            this.dgvBan.RowTemplate.Height = 24;
            this.dgvBan.Size = new System.Drawing.Size(402, 563);
            this.dgvBan.TabIndex = 4;
            this.dgvBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBan_CellClick);
            // 
            // Ban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 587);
            this.Controls.Add(this.dgvBan);
            this.Controls.Add(this.panel2);
            this.Name = "Ban";
            this.Text = "Ban";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLammoiban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoaBan;
        private System.Windows.Forms.Button btnThemBan;
        private System.Windows.Forms.TextBox txtTrangthaiban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaban;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBan;
    }
}