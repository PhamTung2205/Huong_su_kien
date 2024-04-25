using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Quanlyquanan
{
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }

        private void btnThongkehoadon_Click(object sender, EventArgs e)
        {
            fThongkehd f = new fThongkehd();
            f.TopLevel = false;
            plThongke.Controls.Add(f);
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }

        private void btnThongketheotien_Click(object sender, EventArgs e)
        {
           Thongketheogia f = new Thongketheogia();
            f.TopLevel = false;
            plThongke.Controls.Add(f);
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            plThongke.Controls.Clear();
        }

        private void btnThongkethoenam_Click(object sender, EventArgs e)
        {
            Thongketaikhoan f = new Thongketaikhoan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
