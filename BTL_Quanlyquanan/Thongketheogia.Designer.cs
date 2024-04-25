
namespace BTL_Quanlyquanan
{
    partial class Thongketheogia
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoadon = new System.Windows.Forms.DataGridView();
            this.txtTongtientruoc = new System.Windows.Forms.TextBox();
            this.txtTongtiensau = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInthongke
            // 
            this.btnInthongke.Location = new System.Drawing.Point(748, 52);
            this.btnInthongke.Name = "btnInthongke";
            this.btnInthongke.Size = new System.Drawing.Size(127, 50);
            this.btnInthongke.TabIndex = 2;
            this.btnInthongke.Text = "In Thông kê";
            this.btnInthongke.UseVisualStyleBackColor = true;
            this.btnInthongke.Click += new System.EventHandler(this.btnInthongke_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng tiền trước";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(365, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tổng tiền sau";
            // 
            // dgvHoadon
            // 
            this.dgvHoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoadon.Location = new System.Drawing.Point(12, 121);
            this.dgvHoadon.Name = "dgvHoadon";
            this.dgvHoadon.RowHeadersWidth = 51;
            this.dgvHoadon.RowTemplate.Height = 24;
            this.dgvHoadon.Size = new System.Drawing.Size(883, 324);
            this.dgvHoadon.TabIndex = 5;
            // 
            // txtTongtientruoc
            // 
            this.txtTongtientruoc.Location = new System.Drawing.Point(227, 79);
            this.txtTongtientruoc.Name = "txtTongtientruoc";
            this.txtTongtientruoc.Size = new System.Drawing.Size(132, 22);
            this.txtTongtientruoc.TabIndex = 6;
            // 
            // txtTongtiensau
            // 
            this.txtTongtiensau.Location = new System.Drawing.Point(551, 79);
            this.txtTongtiensau.Name = "txtTongtiensau";
            this.txtTongtiensau.Size = new System.Drawing.Size(132, 22);
            this.txtTongtiensau.TabIndex = 7;
            // 
            // Thongketheogia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 457);
            this.Controls.Add(this.txtTongtiensau);
            this.Controls.Add(this.txtTongtientruoc);
            this.Controls.Add(this.dgvHoadon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInthongke);
            this.Name = "Thongketheogia";
            this.Text = "Thongketheogia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInthongke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHoadon;
        private System.Windows.Forms.TextBox txtTongtientruoc;
        private System.Windows.Forms.TextBox txtTongtiensau;
    }
}