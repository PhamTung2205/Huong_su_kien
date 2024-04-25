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
    public partial class Ban : Form
    {
        public Ban()
        {
            InitializeComponent();
            dgvBan.DataSource = HienBang("vw_HienBan");
        }
        string constr = @"Data Source=DESKTOP-N82NSKE\THANHTUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";

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
        bool kiemtratontai(string query, string cot, string dieukien)
        {
            object Dldau = 0;
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
                int i = data.Rows.Count;
                if (i > 0)
                {

                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (string.Compare(dieukien, reader[cot].ToString(), true) == 0)
                            {
                                return false;
                            }
                        }

                    }
                }
                conn.Close();
                return true;
            }
        }
        bool kiemtrabantontai()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Xoaban";

                comm.Parameters.AddWithValue("@sMaban", txtMaban.Text);
                comm.Parameters.AddWithValue("@sCheckxoa", 0 + "");

                comm.ExecuteNonQuery();
                return true;
                conn.Close();
            }
        }

        void ThemBan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_NhapBan";
                if (txtMaban.Text == "")
                {
                    MessageBox.Show("Không được để trống các ô", "Thông báo");
                    return;
                }
                if (kiemtratontai("tblBan", "sMaban", txtMaban.Text) == true)
                {
                    comm.Parameters.AddWithValue("@sMaban", txtMaban.Text);
                    comm.Parameters.AddWithValue("@sTrangthai", "Trống");
                }
                else
                {
                    kiemtrabantontai();
                    return;
                }
                if (kiemtratontai("vw_HienBan", "Mã bàn", txtMaban.Text) == false)
                {
                    MessageBox.Show("Mã bàn đã tồn tại mời nhập bàn khác", "Thông báo");
                    return;
                }
                comm.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            ThemBan();
            dgvBan.DataSource = HienBang("vw_HienBan");
        }

        void XoaBan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Xoaban";
                if (txtMaban.Text == "")
                {
                    MessageBox.Show("Không được để trống các ô", "Thông báo");
                    return;
                }
                if (string.Compare(txtTrangthaiban.Text, "Trống", true) == 0)
                {
                    comm.Parameters.AddWithValue("@sMaban", txtMaban.Text);
                    comm.Parameters.AddWithValue("@sCheckxoa", 1 + "");
                }
                else
                {
                    MessageBox.Show("Bàn có người ngồi không thể xóa", "Thông báo");
                    return;
                }

                comm.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            XoaBan();
            dgvBan.DataSource = HienBang("vw_HienBan");
        }

        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvBan.CurrentRow.Index;
            txtMaban.Text = dgvBan.Rows[i].Cells[0].Value.ToString();
            txtTrangthaiban.Text = dgvBan.Rows[i].Cells[1].Value.ToString();
        }

        private void btnLammoiban_Click(object sender, EventArgs e)
        {
            txtTrangthaiban.Text = "";
            txtMaban.Text = "";
            dgvBan.DataSource = HienBang("vw_HienBan");
        }

        
    }
}
