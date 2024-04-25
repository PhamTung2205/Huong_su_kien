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
    public partial class fAdim : Form
    {
        Form Datban;
        public fAdim(Form datban)
        {
            Datban = datban;
            InitializeComponent();
           dgvMonan.DataSource = HienBang("vw_HienMonan");
            dgvBan.DataSource = HienBang("vw_HienBan");
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan");
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

        bool kiemtratontai(string query,string cot,string dieukien)
        {
            object Dldau = 0;
            using(SqlConnection conn = new SqlConnection(constr))
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
                    
                    using(SqlDataReader reader = comm.ExecuteReader())
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
            int i= HienBang("tblMonan").Rows.Count;
            ++i;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_ThemMonan";
                if (txtTenmon.Text == "" || txtGiamon.Text == "")
                {
                    MessageBox.Show("Không được để ô trống", "Thông báo");
                    return;
                }
                if(kiemtratontai("vw_HienMonan","Tên món", txtTenmon.Text)==true)
                {
                    comm.Parameters.AddWithValue("@sMamon", "M"+i+"");
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
            using(SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_LayMonan";
                if (txtTenmon.Text == "" || txtGiamon.Text == "")
                {
                    MessageBox.Show("Không được để ô trống", "Thông báo");
                    return null;
                }
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
                if (txtTenmon.Text == "" || txtGiamon.Text == "")
                {
                    MessageBox.Show("Không được để ô trống", "Thông báo");
                    return;
                }
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
            using(SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_TimMonan";
                if (txtTenmon.Text == "" || txtGiamon.Text == "")
                {
                    MessageBox.Show("Không được để ô trống", "Thông báo");
                    return;
                }
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

        private void fAdim_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Datban is DatMon)
            {
                ((DatMon)Datban).Lammoi();
            }
            Datban.Show();
            this.Close();
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
                if(kiemtratontai("vw_HienBan","Mã bàn", txtMaban.Text)==false)
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
           dgvBan.DataSource= HienBang("vw_HienBan");
        }

        void XoaBan()
        {
            using(SqlConnection conn = new SqlConnection(constr))
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
                    comm.Parameters.AddWithValue("@sCheckxoa", 1+ "");
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

        void Themtaikhoan()
        {
            using(SqlConnection conn = new SqlConnection(constr))
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

                if(txtTendangnhap.Text == "" || txtMatkhau.Text == "")
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
                if (rdbAdmin.Checked==true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbAdmin.Text);
                }
                if (rdbNhanvien.Checked==true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbNhanvien.Text);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnThemtk_Click(object sender, EventArgs e)
        {
            Themtaikhoan();
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan");
        }

        void Suataikhoan()
        {
            using(SqlConnection conn = new SqlConnection(constr))
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
                if (!rdbNhanvien.Checked==false && !rdbAdmin.Checked==false)
                {
                    MessageBox.Show("Vui lòng cấp quyền cho nhân viên", "thông báo");
                    return;
                }

                comm.Parameters.AddWithValue("@sTendangnhap", txtTendangnhap.Text);
                comm.Parameters.AddWithValue("@sMatkhau", txtMatkhau.Text);
                if (rdbAdmin.Checked==true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbAdmin.Text);
                }
                if (rdbNhanvien.Checked==true)
                {
                    comm.Parameters.AddWithValue("@sChucvu", rdbNhanvien.Text);
                }
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnSuatk_Click(object sender, EventArgs e)
        {
            Suataikhoan();
            dgvTaikhoan.DataSource = HienBang("vw_HienTaikhoan");
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
                comm.Parameters.AddWithValue("@sCheckxoa", 1+"");
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

        private void btnThongkehoadon_Click(object sender, EventArgs e)
        {
            fThongkehd f = new fThongkehd();
            f.TopLevel = false;
            plThongke.Controls.Add(f);
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }
    }
}
