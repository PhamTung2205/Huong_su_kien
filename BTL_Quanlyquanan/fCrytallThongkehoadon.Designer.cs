
namespace BTL_Quanlyquanan
{
    partial class fCrytallThongkehoadon
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
            this.CrtvThongkehoadon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrtvThongkehoadon
            // 
            this.CrtvThongkehoadon.ActiveViewIndex = -1;
            this.CrtvThongkehoadon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrtvThongkehoadon.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrtvThongkehoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrtvThongkehoadon.Location = new System.Drawing.Point(0, 0);
            this.CrtvThongkehoadon.Name = "CrtvThongkehoadon";
            this.CrtvThongkehoadon.Size = new System.Drawing.Size(892, 707);
            this.CrtvThongkehoadon.TabIndex = 0;
            // 
            // fCrytallThongkehoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 707);
            this.Controls.Add(this.CrtvThongkehoadon);
            this.Name = "fCrytallThongkehoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fCrytallThongkehoadon";
            this.Load += new System.EventHandler(this.fCrytallThongkehoadon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrtvThongkehoadon;
    }
}