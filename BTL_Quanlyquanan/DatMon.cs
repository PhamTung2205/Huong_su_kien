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
    public partial class DatMon : Form
    {
        private string tendangnhap;
        private string Chucvu;
        public DatMon(string tendn, string chucvu)
        {
            this.tendangnhap = tendn;
            this.Chucvu = chucvu;
            InitializeComponent();

            HiendsBan();
            Monan();

        }

        string constr = @"Data Source=DESKTOP-N82NSKE\THANHTUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";


        void HiendsBan()
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
                        int a = 1;
                        while (reader.Read())
                        {

                            string Maban = reader["Mã bàn"].ToString();
                            string trangthai = reader["Trạng thái"].ToString();
                            Button btn = new Button();
                            btn.Text = "" + Maban + "";
                            btn.Size = new Size(100, 50);
                            btn.Name = "btnBan" + a + "";
                            if (string.Compare(trangthai, "Có Người", true) == 0)
                            {
                                btn.BackColor = Color.CadetBlue;
                            }
                            if (string.Compare(trangthai, "Trống", true) == 0)
                            {
                                btn.BackColor = Color.AliceBlue;
                            }
                            btn.Click += Btn_Click;

                            flpBan.Controls.Add(btn);
                            a++;
                        }
                    }
                }
                conn.Close();
            }
        }


        int Hooadonco()
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
                int i = data.Rows.Count;
                conn.Close();
                return i;

            }
        }

        void Themhoadon(int i, string maban)
        {
            string mahd = "HD" + i + "";
            DateTime ngay = DateTime.Now;
            string thoigianvao = ngay.ToString("yyyy-MM-dd HH:mm:ss");

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_NhapHoadon";

                comm.Parameters.AddWithValue("@sMahoadon", mahd);
                comm.Parameters.AddWithValue("@dThoigianvao", thoigianvao);
                comm.Parameters.AddWithValue("@sTrangthai", "Chưa thanh toán");
                comm.Parameters.AddWithValue("@sMaban", maban);
                comm.Parameters.AddWithValue("@sTendangnhap", tendangnhap);

                comm.ExecuteNonQuery();

                conn.Close();
            }
        }

        string Layhoadon(string maban)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Layhoadon";
                comm.Parameters.AddWithValue("@sMaban", maban);
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
                            string mahd = reader["sMahoadon"].ToString();
                            return mahd;
                        }
                    }
                }
                return "";
                conn.Close();
            }
        }

        void Hiendatmon(string mahd)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Hiendatmon";
                comm.Parameters.AddWithValue("@sMahoadon", mahd);
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                dgvDatmon.DataSource = data;
                conn.Close();
            }
        }
        void Themnguoivao(string maban, string trangthai)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Suatrangthaiban";
                comm.Parameters.AddWithValue("@sMaban", maban);
                if (string.Compare(trangthai, "Trống", true) == 0)
                {
                    comm.Parameters.AddWithValue("@sTrangthai", "Có Người");
                    int i = Hooadonco();
                    i++;
                    Themhoadon(i, maban);
                }
                else
                {
                    return;
                }

                comm.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_ChonBan";
                comm.Parameters.AddWithValue("@sMaban", btn.Text);
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
                            string Maban = reader["Mã bàn"].ToString();
                            string trangthai = reader["Trạng thái"].ToString();
                            Themnguoivao(Maban, trangthai);
                            flpBan.Controls.Clear();
                            HiendsBan();
                            string mahd = Layhoadon(Maban);
                            Hiendatmon(mahd);
                            txtMabndatmon.Text = Maban;

                        }

                    }
                }
                conn.Close();
            }
        }

        void Monan()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select * from vw_HienMonan";

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
                            string Tenmonan = reader["Tên món"].ToString();

                            cbDatmon.Items.Add(Tenmonan);
                        }
                    }
                }

                conn.Close();
            }
        }

        string Laymamon()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Laymon";
                comm.Parameters.AddWithValue("@sTenmon", cbDatmon.Text);
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
                            string Mamon = reader["sMamon"].ToString();
                            return Mamon;
                        }
                    }
                }
                return "";
                conn.Close();
            }
        }

        void Themmonmoi()
        {
            string mamon = Laymamon();
            string mahd = Layhoadon(txtMabndatmon.Text);

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_ThemDatmon";
                if (mahd == "" || mamon == "")
                {
                    MessageBox.Show("Món ăn chưa được nhập mời kiểm tra lại", "Thông báo");
                    return;
                }
                if (nmslmon.Value < 1)
                {
                    MessageBox.Show("Só lượng phải lớn hơn 0 , kiểm tra lại");
                    return;
                }
                else
                {
                    comm.Parameters.AddWithValue("@sMahoadon", mahd);
                    comm.Parameters.AddWithValue("@sMamon", mamon);
                    comm.Parameters.AddWithValue("@iSoluong", nmslmon.Value);
                    comm.ExecuteNonQuery();
                    Hiendatmon(mahd);

                }
                conn.Close();
            }
        }

        void Suamon(int soluong)
        {
            string mamon = Laymamon();
            string mahd = Layhoadon(txtMabndatmon.Text);
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_SuaDatmon";
                if (mahd == "" || mamon == "")
                {
                    MessageBox.Show("Món ăn chưa được nhập mời kiểm tra lại", "Thông báo");
                    return;
                }
                if (nmslmon.Value < 1)
                {
                    MessageBox.Show("Só lượng phải lớn hơn 0 , kiểm tra lại");
                    return;
                }

                else
                {
                    comm.Parameters.AddWithValue("@sMahoadon", mahd);
                    comm.Parameters.AddWithValue("@sMamon", mamon);
                    comm.Parameters.AddWithValue("@iSoluong", soluong);
                    comm.ExecuteNonQuery();
                    Hiendatmon(mahd);

                }

                conn.Close();

            }
        }
        void Datmon()
        {
            string mahd = Layhoadon(txtMabndatmon.Text);
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Hiendatmon";
                comm.Parameters.AddWithValue("@sMahoadon", mahd);

                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);
                int i = data.Rows.Count;
                if (i > 0)
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        int soluongmoi = 0;
                        while (reader.Read())
                        {
                            string tenmon = reader["Tên món"].ToString();

                            int soluong = int.Parse(reader["Số lượng"].ToString());
                            if (string.Compare(tenmon, cbDatmon.Text, true) == 0)
                            {

                                soluongmoi = soluong + int.Parse(nmslmon.Value.ToString());
                                Suamon(soluongmoi);
                                return;
                            }

                        }
                        Themmonmoi();
                        return;

                    }
                }
                if (i == 0)
                {
                    Themmonmoi();
                    return;

                }
                conn.Close();

            }
        }
        private void btnThemmon_Click(object sender, EventArgs e)
        {
            Datmon();
        }


        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

            string mhd = Layhoadon(txtMabndatmon.Text);
            Hoadon f = new Hoadon(mhd, tendangnhap, txtMabndatmon.Text, float.Parse(nmGiamgia.Value.ToString()), this);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        public void Lammoi()
        {
            flpBan.Controls.Clear();
            HiendsBan();
            dgvDatmon.DataSource = null;
            txtMabndatmon.Text = "";
            cbDatmon.Items.Clear();
            nmGiamgia.Value = 0;
            nmslmon.Value = 0;
            Monan();
        }

        private void MonAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(Chucvu, "Admin", true) == 0)
            {
                Monan f = new Monan();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải là Admin", "Thông báo");
            }
        }

        private void TaikhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(Chucvu, "Admin", true) == 0)
            {
                TaiKhoan f = new TaiKhoan();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải là Admin", "Thông báo");
            }
        }

        private void BanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(Chucvu, "Admin", true) == 0)
            {
                Ban f = new Ban();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải là Admin", "Thông báo");
            }
        }

        private void ThongKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(Chucvu, "Admin", true) == 0)
            {
                Thongke f = new Thongke();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không phải là Admin", "Thông báo");
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongtincanhan f = new Thongtincanhan(tendangnhap,Chucvu);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
