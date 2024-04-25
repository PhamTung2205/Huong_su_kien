
namespace BTL_Quanlyquanan
{
    partial class ThongkenamTaikhoan
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
            this.Crytallthongkenam = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Crytallthongkenam
            // 
            this.Crytallthongkenam.ActiveViewIndex = -1;
            this.Crytallthongkenam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Crytallthongkenam.Cursor = System.Windows.Forms.Cursors.Default;
            this.Crytallthongkenam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Crytallthongkenam.Location = new System.Drawing.Point(0, 0);
            this.Crytallthongkenam.Name = "Crytallthongkenam";
            this.Crytallthongkenam.Size = new System.Drawing.Size(935, 543);
            this.Crytallthongkenam.TabIndex = 0;
            // 
            // ThongkenamTaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 543);
            this.Controls.Add(this.Crytallthongkenam);
            this.Name = "ThongkenamTaikhoan";
            this.Text = "ThongkenamTaikhoan";
            this.Load += new System.EventHandler(this.ThongkenamTaikhoan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Crytallthongkenam;
    }
}