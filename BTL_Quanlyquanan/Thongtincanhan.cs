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
    public partial class Thongtincanhan : Form
    {
        private string tendangnhap;
        private string chucvu;
        public Thongtincanhan(string tendangnhap,string chucvu)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.chucvu = chucvu;
            txtTendangnhap.Text = tendangnhap;
        }

        string constr = @"Data Source=DESKTOP-RLE8QUC\TUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";

        string kiemtramkcu()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * from vw_HienTaikhoan";
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                int i = data.Rows.Count;
               
                if (i > 0)
                {
                    using(SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tendn = reader["Tên đăng nhập"].ToString();
                            if (string.Compare(tendangnhap, tendn, true) == 0)
                            {
                                string matkhau = reader["Mật khẩu"].ToString();
                                return matkhau;
                            }
                        }
                    }
                }
                return "";

            }
        }
        void Doimatkhau()
        {
            using(SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_SuaTaikhoan";
                if (string.Compare(kiemtramkcu(), txtMatkhaucu.Text, true) != 0)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng !", "Thông báo");
                    return;
                }
                if (string.Compare(txtNlmatkhaumoi.Text, txtMatkhaumoi.Text, true) != 0)
                {
                    MessageBox.Show("Mật khẩu nhập lại bị sai !", "Thông báo");
                    return;
                }
                comm.Parameters.AddWithValue("@sTendangnhap",tendangnhap);
                comm.Parameters.AddWithValue("@sMatkhau",txtMatkhaumoi.Text);
                comm.Parameters.AddWithValue("@sChucvu", chucvu);
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnDoimk_Click(object sender, EventArgs e)
        {
            Doimatkhau();
            MessageBox.Show("Mật khẩu bạn đã được cập nhật !", "Thông báo");
            txtNlmatkhaumoi.Text = "";
            txtMatkhaumoi.Text = "";
            txtMatkhaucu.Text = "";
            txtNlmatkhaumoi.UseSystemPasswordChar= true;
            txtMatkhaumoi.UseSystemPasswordChar = true;
            txtMatkhaucu.UseSystemPasswordChar = true;
            cbmatkhaucu.Checked = false;
            cbmatkhaumoi.Checked = false;
            cbnlmatkhaumoi.Checked = false;

        }

     

        private void cbmatkhaucu_Click(object sender, EventArgs e)
        {
            string mkcu = txtMatkhaucu.Text;
            if (txtMatkhaucu.UseSystemPasswordChar == true)
            {
                txtMatkhaucu.Text = "";
                txtMatkhaucu.UseSystemPasswordChar = false;
                txtMatkhaucu.Text = mkcu;
                return;
            }
            if (txtMatkhaucu.UseSystemPasswordChar == false)
            {
                txtMatkhaucu.Text = "";
                txtMatkhaucu.UseSystemPasswordChar = true;
                txtMatkhaucu.Text = mkcu;
                return;
            }
        }

        private void cbmatkhaumoi_Click(object sender, EventArgs e)
        {
            string mkmoi = txtMatkhaumoi.Text;
            if (txtMatkhaumoi.UseSystemPasswordChar == true)
            {
                txtMatkhaumoi.Text = "";
                txtMatkhaumoi.UseSystemPasswordChar = false;
                txtMatkhaumoi.Text = mkmoi;
                return;
            }
            if (txtMatkhaumoi.UseSystemPasswordChar == false)
            {
                txtMatkhaumoi.Text = "";
                txtMatkhaumoi.UseSystemPasswordChar = true;
                txtMatkhaumoi.Text = mkmoi;
                return;
            }
        }

        private void cbnlmatkhaumoi_Click(object sender, EventArgs e)
        {
            string nlmkmoi = txtNlmatkhaumoi.Text;
            if (txtNlmatkhaumoi.UseSystemPasswordChar == true)
            {
                txtNlmatkhaumoi.Text = "";
                txtNlmatkhaumoi.UseSystemPasswordChar = false;
                txtNlmatkhaumoi.Text = nlmkmoi;
                return;
            }
            if (txtNlmatkhaumoi.UseSystemPasswordChar == false)
            {
                txtNlmatkhaumoi.Text = "";
                txtNlmatkhaumoi.UseSystemPasswordChar = true;
                txtNlmatkhaumoi.Text = nlmkmoi;
                return;
            }
        }
    }
}
