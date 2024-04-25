using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Quanlyquanan
{
    public partial class Monan : Form
    {
        public Monan()
        {
            InitializeComponent();
            dgvMonan.DataSource = HienBang("vw_HienMonan");
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

        void dieukien()
        {
            int a = 0;
            if (txtTenmon.Text == "" || txtGiamon.Text == "")
            {
                MessageBox.Show("Không được để ô trống", "Thông báo");
                return;
            }

            if (!int.TryParse(txtGiamon.Text, out a))
            {
                MessageBox.Show("Giá món phải nhập số", "Thông báo");
                return;
            }
            if (int.Parse(txtGiamon.Text) < 1)
            {
                MessageBox.Show("Giá món phải Lớn hơn 0", "Thông báo");
                return;
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
        void Themmon()
        {
            
            int i = HienBang("tblMonan").Rows.Count;
            ++i;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_ThemMonan";
                dieukien();
                if (kiemtratontai("vw_HienMonan", "Tên món", txtTenmon.Text) == true)
                {
                    comm.Parameters.AddWithValue("@sMamon", "M" + i + "");
                    comm.Parameters.AddWithValue("@sTenmon", txtTenmon.Text);
                    comm.Parameters.AddWithValue("@iGiamon", int.Parse(txtGiamon.Text));
                }
                else
                {
                    MessageBox.Show("Món ăn đã tồn tại ", "thông báo");
                    return;
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }



        private void btnThemmon_Click(object sender, EventArgs e)
        {
            Themmon();
            dgvMonan.DataSource = HienBang("vw_HienMonan");
        }

        string Laymonan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_LayMonan";
                dieukien();
                comm.Parameters.AddWithValue("@sTenmon", txtTenmon.Text);
                string tenmon = comm.ExecuteScalar().ToString();
                conn.Close();
                return tenmon;
            }
        }

        void Suamon()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_SuaMonan";
                dieukien();
                comm.Parameters.AddWithValue("@sMamon", Laymonan());
                comm.Parameters.AddWithValue("@sTenmon", txtTenmon.Text);
                comm.Parameters.AddWithValue("@iGiamon", int.Parse(txtGiamon.Text));
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnSuamon_Click(object sender, EventArgs e)
        {
            Suamon();
            dgvMonan.DataSource = HienBang("vw_HienMonan");
        }

        private void dgvMonan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvMonan.CurrentRow.Index;
            txtTenmon.Text = dgvMonan.Rows[i].Cells[0].Value.ToString();
            txtGiamon.Text = dgvMonan.Rows[i].Cells[1].Value.ToString();

        }

        void Xoamonan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_XoaMon";
                if (Laymonan() == null)
                {
                    return;
                }
                comm.Parameters.AddWithValue("@sMamon", Laymonan());
                comm.ExecuteReader();
                conn.Close();
            }
        }
        private void btnXoamonan_Click(object sender, EventArgs e)
        {
            Xoamonan();
            dgvMonan.DataSource = HienBang("vw_HienMonan");
        }

        void TimMonan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_TimMonan";
                dieukien();
                comm.Parameters.AddWithValue("@sTenMon", txtTenmon.Text);
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                dgvMonan.DataSource = data;
                conn.Close();
            }
        }

        private void btnTimmonan_Click(object sender, EventArgs e)
        {
            TimMonan();
        }

        private void btnLammoimon_Click(object sender, EventArgs e)
        {
            txtTenmon.Text = "";
            txtGiamon.Text = "";
            dgvMonan.DataSource = HienBang("vw_HienMonan");
        }

        
    }
}
