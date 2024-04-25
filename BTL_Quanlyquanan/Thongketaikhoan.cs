using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_Quanlyquanan
{
    public partial class Thongketaikhoan : Form
    {
        public Thongketaikhoan()
        {
            InitializeComponent();
            dgvTaikhoan.DataSource=HienBang("vw_HienTaikhoan2");

        }
        string constr = @"Data Source=DESKTOP-RLE8QUC\TUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";
        DataTable HienBang(string query)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select * from " + query;
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                conn.Close();
                return data;

            }
        }

        private void btnInthongke_Click(object sender, EventArgs e)
        {
            ThongkenamTaikhoan f = new ThongkenamTaikhoan(int.Parse(txtnam.Text.ToString()));
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
