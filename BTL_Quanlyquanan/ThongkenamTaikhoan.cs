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
    public partial class ThongkenamTaikhoan : Form
    {
        private int nam;
        public ThongkenamTaikhoan(int nam)
        {
            InitializeComponent();
            this.nam = nam;
        }
        string constr = @"Data Source=DESKTOP-RLE8QUC\TUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";

        private void ThongkenamTaikhoan_Load(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Thongketaikhoan";
                comm.Parameters.AddWithValue("@sNamset", nam);

                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);

                CrystalReport1 crtThongke = new CrystalReport1();
                crtThongke.SetDataSource(data);
                Crytallthongkenam.ReportSource = crtThongke;
                Crytallthongkenam.Refresh();
                conn.Close();
            }
        }
    }
}
