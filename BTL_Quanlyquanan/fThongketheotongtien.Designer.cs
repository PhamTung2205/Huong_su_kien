
namespace BTL_Quanlyquanan
{
    partial class fThongketheotongtien
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
            this.cryptallThongketheotien = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cryptallThongketheotien
            // 
            this.cryptallThongketheotien.ActiveViewIndex = -1;
            this.cryptallThongketheotien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryptallThongketheotien.Cursor = System.Windows.Forms.Cursors.Default;
            this.cryptallThongketheotien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptallThongketheotien.Location = new System.Drawing.Point(0, 0);
            this.cryptallThongketheotien.Name = "cryptallThongketheotien";
            this.cryptallThongketheotien.Size = new System.Drawing.Size(956, 571);
            this.cryptallThongketheotien.TabIndex = 0;
            // 
            // fThongketheotongtien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 571);
            this.Controls.Add(this.cryptallThongketheotien);
            this.Name = "fThongketheotongtien";
            this.Text = "fThongketheotongtien";
            this.Load += new System.EventHandler(this.fThongketheotongtien_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cryptallThongketheotien;
    }
}