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
    public partial class Thongketheogia : Form
    {
        public Thongketheogia()
        {
            InitializeComponent();
            Hienhoadon();
        }
        string constr = @"Data Source=DESKTOP-RLE8QUC\TUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";
        void Hienhoadon()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select * from vw_HienHoadon";
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                dgvHoadon.DataSource = data;
                conn.Close();
            }
        }
        private void btnInthongke_Click(object sender, EventArgs e)
        {
            fThongketheotongtien f = new fThongketheotongtien(int.Parse(txtTongtientruoc.Text), int.Parse(txtTongtiensau.Text));
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
