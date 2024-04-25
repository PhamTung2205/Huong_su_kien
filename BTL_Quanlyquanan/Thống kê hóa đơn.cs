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
    public partial class fThongkehd : Form
    {
        public fThongkehd()
        {
            InitializeComponent();
            Hienhoadon();
            Hienban();
        }
        string constr = @"Data Source=DESKTOP-N82NSKE\THANHTUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True;Trust Server Certificate=True";

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

        void Hienban()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select * from vw_HienBan";
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                int i = data.Rows.Count;
                if (i > 0)
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            string ban = reader["Mã bàn"].ToString();
                            cbBan.Items.Add(ban);
                        }
                        
                    }
                }
                conn.Close();
            }
        }
        

        private void Inthongke_Click(object sender, EventArgs e)
        {
            if (cbBan.Text == "")
            {
                fCrytallThongkehoadon f = new fCrytallThongkehoadon(dtNgaytruoc.Value.ToString("yyyy-MM-dd 00:00:00"), dtNgaysau.Value.ToString("yyyy-MM-dd 23:59:59"));
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                fCrytallThongkehoadon f = new fCrytallThongkehoadon(dtNgaytruoc.Value.ToString("yyyy-MM-dd 00:00:00"), dtNgaysau.Value.ToString("yyyy-MM-dd 23:59:59"),cbBan.Text);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }
    }
}
