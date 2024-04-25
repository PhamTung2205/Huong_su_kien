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
    public partial class Hoadon : Form
    {
        private string mahd;
        private string tendangnhap;
        private string maban;
        private int tongtien;
        private float giamgia;
        private Form Datban;

        

        public Hoadon(string mahoadon,string tendnh,string mabn,float giamgia,Form datban)
        {
            this.mahd = mahoadon;
            this.tendangnhap = tendnh;
            this.maban = mabn;
            this.giamgia = giamgia;
            Datban = datban;
            InitializeComponent();
            Hienlismon();
            Hienthongtin();
        }
        string constr = @"Data Source=DESKTOP-N82NSKE\THANHTUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";


        void Hienlismon()
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
                dgvdsmon.DataSource = data;
                int i = data.Rows.Count;
                if (i > 0)
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        int tong = 0;
                        int trunggian = 0;
                        while (reader.Read())
                        {

                            int soluong = int.Parse(reader["Số lượng"].ToString());
                            int giamon = int.Parse(reader["Đơn giá món"].ToString());
                            trunggian = soluong * giamon;
                            tong += trunggian;
                        }

                        this.tongtien = tong;
                        
                    }
                }
                conn.Close();
            }
        }

        void Thanhtoan()
        {
            
            DateTime ngay = DateTime.Now;
            float thanhtien = tongtien- tongtien * (giamgia/100);
            string thoigianra = ngay.ToString("yyyy-MM-dd HH:mm:ss");
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_SuaHoadon";
                comm.Parameters.AddWithValue("@sMahoadon", mahd);
                comm.Parameters.AddWithValue("@dThoigianra", thoigianra);
                comm.Parameters.AddWithValue("@sTrangthai", "Thanh toán");
                comm.Parameters.AddWithValue("@fTongtien", thanhtien);
                comm.Parameters.AddWithValue("@sTendangnhap", tendangnhap);
                comm.Parameters.AddWithValue("@iGiamgia", giamgia);
                comm.ExecuteNonQuery();

                conn.Close();
            }
        }
        string Laytrangthai()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "Select * from tblBan where sMaban = N'" + maban+ "'";
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

                            string trangthai = reader["sTrangthai"].ToString();
                            
                            return trangthai;
                        }

                    }

                }
                return "";
            }
        }
        void Xoanguoira(string maban, string trangthai)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Suatrangthaiban";
                comm.Parameters.AddWithValue("@sMaban", maban);
                if (string.Compare(trangthai, "Có Người", true) == 0)
                {
                    comm.Parameters.AddWithValue("@sTrangthai", "Trống");
                }
                else
                {
                    return;
                }

                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        void Hienthongtin()
        {
            DateTime ngay = DateTime.Now;
            int tong = tongtien;
            string thoigianra = ngay.ToString();
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
                if (i > 0)
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string mahoadon = reader["Mã hóa đơn"].ToString();
                            if (string.Compare(mahd, mahoadon, true) == 0)
                            {
                                txtMabanhoadon.Text = reader["Bàn"].ToString();
                                txtThoigianvao.Text = reader["Thời gian vào"].ToString();
                                txtThoigianra.Text = thoigianra;
                                txtTientruocgiam.Text = tongtien.ToString();
                                txtGiamgia.Text = giamgia+"%";
                                txtTiensaukhigiam.Text = (tong-tong * (giamgia/100)).ToString();
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toán thành công", "Thông báo");
            string trangthai = Laytrangthai();
            Xoanguoira(maban, trangthai);
            Thanhtoan();
            if(Datban is DatMon)
            {
                ((DatMon)Datban).Lammoi();
            }
            Datban.Show();
            this.Close();
        }

       
    }
}
