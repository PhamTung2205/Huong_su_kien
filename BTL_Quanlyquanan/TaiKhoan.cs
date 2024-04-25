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
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan2");
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
        void Themtaikhoan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_NhapTaikhoan";
                if (!kiemtratontai("tblTaikhoan", "sTendangnhap", txtTendangnhap.Text))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại mời nhập tên khác", "thông báo");
                    return;
                }

                if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
                {
                    MessageBox.Show("Không được để trống ô, vui lòng kiểm tra lại", " thông báo");
                    return;
                }
                if (!rdbNhanvien.Checked == false && !rdbAdmin.Checked == false)
                {
                    MessageBox.Show("Vui lòng cấp quyền cho nhân viên", "thông báo");
                    return;
                }

                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sMatkhau", txtMatkhau.Text);
                if (rdbAdmin.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbAdmin.Text);
                }
                if (rdbNhanvien.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbNhanvien.Text);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        //new
        void Themtaikhoan2()
        {
            DateTime ngay = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_NhapTaikhoan2";
                if (!kiemtratontai("tblTaikhoan", "sTendangnhap", txtTendangnhap.Text))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại mời nhập tên khác", "thông báo");
                    return;
                }

                if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
                {
                    MessageBox.Show("Không được để trống ô, vui lòng kiểm tra lại", " thông báo");
                    return;
                }
                if (!rdbNhanvien.Checked == false && !rdbAdmin.Checked == false)
                {
                    MessageBox.Show("Vui lòng cấp quyền cho nhân viên", "thông báo");
                    return;
                }

                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sMatkhau", txtMatkhau.Text);
                comm.Parameters.AddWithValue("@dNgaybatdau", dtNgaybatdau.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                comm.Parameters.AddWithValue("@sNam", int.Parse((ngay.Year - dtNgaybatdau.Value.Year).ToString()));
                
                if (rdbAdmin.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbAdmin.Text);
                }
                if (rdbNhanvien.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbNhanvien.Text);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnThemtk_Click(object sender, EventArgs e)
        {
            Themtaikhoan2();
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan2");
            MessageBox.Show("Thêm thành công");
        }

        void Suataikhoan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_SuaTaikhoan";
                if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
                {
                    MessageBox.Show("Không được để trống ô, vui lòng kiểm tra lại", " thông báo");
                    return;
                }
                if (!rdbNhanvien.Checked == false && !rdbAdmin.Checked == false)
                {
                    MessageBox.Show("Vui lòng cấp quyền cho nhân viên", "thông báo");
                    return;
                }

                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sMatkhau", txtMatkhau.Text);
                if (rdbAdmin.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbAdmin.Text);
                }
                if (rdbNhanvien.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbNhanvien.Text);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        //new
        void Suataikhoan2()
        {
            DateTime ngay = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_SuaTaikhoan2";
                if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
                {
                    MessageBox.Show("Không được để trống ô, vui lòng kiểm tra lại", " thông báo");
                    return;
                }
                if (!rdbNhanvien.Checked == false && !rdbAdmin.Checked == false)
                {
                    MessageBox.Show("Vui lòng cấp quyền cho nhân viên", "thông báo");
                    return;
                }

                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sMatkhau", txtMatkhau.Text);
                comm.Parameters.AddWithValue("@dNgaybatdau", dtNgaybatdau.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                comm.Parameters.AddWithValue("@sNam", int.Parse((ngay.Year - dtNgaybatdau.Value.Year).ToString()));
                if (rdbAdmin.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbAdmin.Text);
                }
                if (rdbNhanvien.Checked == true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbNhanvien.Text);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void btnSuatk_Click(object sender, EventArgs e)
        {
            Suataikhoan2();
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan2");
            MessageBox.Show("Sửa thành công");
        }

        void Xoataikhoan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_XoaTaikhoan";
                if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
                {
                    MessageBox.Show("Không được để trống ô, vui lòng kiểm tra lại", " thông báo");
                    return;
                }
                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sCheckxoa", 1 + "");
                comm.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void btnXoatk_Click(object sender, EventArgs e)
        {
            Xoataikhoan();
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan");
        }

        void Timkiemtaikhoa()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_TimTaikhoan";
                if (txtTendangnhap.Text == "" || txtMatkhau.Text == "")
                {
                    MessageBox.Show("Không được để trống ô, vui lòng kiểm tra lại", " thông báo");
                    return;
                }
                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                dgvTaikhoan.DataSource = data;
                conn.Close();
            }
        }

        private void btnTimtk_Click(object sender, EventArgs e)
        {
            Timkiemtaikhoa();
        }

        private void btnLammoitk_Click(object sender, EventArgs e)
        {
            txtTendangnhap.Text = "";
            txtMatkhau.Text = "";
            rdbAdmin.Checked = false;
            rdbAdmin.Checked = false;
            txtTendangnhap.ReadOnly = false;
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan");
            txtMatkhau.UseSystemPasswordChar = true;
            cbMatkhau.Checked = false;
        }

        private void dgvTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTaikhoan.CurrentRow.Index;
            txtTendangnhap.Text = dgvTaikhoan.Rows[i].Cells[0].Value.ToString();
            txtMatkhau.Text = dgvTaikhoan.Rows[i].Cells[1].Value.ToString();
            if (string.Compare(dgvTaikhoan.Rows[i].Cells[2].Value.ToString(), "Admin", true) == 0)
            {
                rdbAdmin.Checked = true;
            }

            if (string.Compare(dgvTaikhoan.Rows[i].Cells[2].Value.ToString(), "Nhân viên", true) == 0)
            {
                rdbNhanvien.Checked = true;
            }
            txtTendangnhap.ReadOnly = true;
        }

        private void dgvTaikhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra xem cột hiện tại có phải là cột "Mật khẩu" không và giá trị của cột không phải là null
            if (dgvTaikhoan.Columns[e.ColumnIndex].Name == "Mật khẩu" && e.Value != null)
            {
                // Chuyển giá trị của cột "Mật khẩu" sang dạng string
                string password = e.Value.ToString();

                // Tạo một chuỗi mới với độ dài bằng với độ dài của mật khẩu và gán các ký tự '*' vào
                string maskedPassword = new string('*', password.Length);

                // Thiết lập giá trị hiển thị của ô cụ thể thành chuỗi đã được thay thế
                e.Value = maskedPassword;
            }
        }

        private void cbMatkhau_Click(object sender, EventArgs e)
        {
            string matkhau = txtMatkhau.Text;
            if (txtMatkhau.UseSystemPasswordChar == true)
            {
                txtMatkhau.Text = "";
                txtMatkhau.UseSystemPasswordChar = false;
                txtMatkhau.Text = matkhau;
                return;
            }
            if (txtMatkhau.UseSystemPasswordChar == false)
            {
                txtMatkhau.Text = "";
                txtMatkhau.UseSystemPasswordChar = true;
                txtMatkhau.Text = matkhau;
                return;
            }
        }
    }
}
