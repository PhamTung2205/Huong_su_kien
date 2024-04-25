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
    public partial class fDangnhap : Form
    {
        
        public fDangnhap()
        {
            InitializeComponent();
        }

        string constr = @"Data Source=DESKTOP-N82NSKE\THANHTUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";

        string Laythongtin()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Laytaikhoan";
                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
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
                            string Chucvu = reader["sChucvu"].ToString();
                            return Chucvu;
                        }
                    }
                }

                conn.Close();
                return "";
            }
        }
        private void fDangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if((MessageBox.Show("Bạn có muốn tắt chương trình không","Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK))
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            
            if (Checktaikhoan()>0)
            {
                
                DatMon f = new DatMon(txtTendangnhap.Text,Laythongtin());
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if (Checktaikhoan() == 0)
            {
                MessageBox.Show("Không được để trống vui lòng kiểm tra lại !", "Thông báo");
            }
            else if(Checktaikhoan()==-1)
            {
                MessageBox.Show("Tài khoản không đúng mời nhập lại !", "Thông báo");
            }
            else if (Checktaikhoan() == -2)
            {
                MessageBox.Show("Mật khẩu không đúng vui lòng kiểm tra lại !", "thông báo");
            }
        }

       

        int Checktaikhoan()
        {
            using(SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Dangnhap";
                if(txtTendangnhap.Text == ""|| txtMatkhau.Text == "")
                {
                    return 0;
                }
                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sMatkhau", txtMatkhau.Text);

                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                int i = data.Rows.Count;
                if (i >0)
                {      
                        using(SqlDataReader reader = comm.ExecuteReader())
                        {
                        while (reader.Read())
                        {
                            i--;
                            string Tendangnhap = reader["sTendangnhap"].ToString();
                            string Matkhau = reader["sMatkhau"].ToString();
                            if (string.Compare(Tendangnhap, txtTendangnhap.Text, true) == 0)
                            {
                                if (string.Compare(Matkhau, txtMatkhau.Text, true) == 0)
                                {
                                    return 1;
                                }
                                else
                                {
                                    
                                    return -2;
                                }
                            }
                            else
                            {
                                if (i < 1)
                                {
                                    return -1;
                                }
                            }
                            
                        }
                        }
                    return -1;
                }
                else
                {
                    return -1;
                }

                conn.Close();
            }
        }
    }
}
