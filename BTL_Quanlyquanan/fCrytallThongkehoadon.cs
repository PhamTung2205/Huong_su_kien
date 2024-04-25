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
    public partial class fCrytallThongkehoadon : Form
    {
        private string Tgvao;
        private string Tgra;
        private string Maban;
        public fCrytallThongkehoadon(string Thoigianvao,string Thoigianra,string maban = null)
        {
            this.Tgvao = Thoigianvao;
            this.Tgra = Thoigianra;
            this.Maban = maban;
            InitializeComponent();
        }
        
        string constr = @"Data Source=DESKTOP-RLE8QUC\TUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";
        private void fCrytallThongkehoadon_Load(object sender, EventArgs e)
        {
            if (Maban == null)
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "sp_Thongkehdtheongay";

                    comm.Parameters.AddWithValue("@dThoigianvao", Tgvao);
                    comm.Parameters.AddWithValue("@dThoigianra", Tgra);



                    SqlDataAdapter adt = new SqlDataAdapter(comm);
                    DataTable data = new DataTable();
                    adt.Fill(data);

                    crystalThongke crtThongke = new crystalThongke();
                    crtThongke.SetDataSource(data);
                    CrtvThongkehoadon.ReportSource = crtThongke;
                    CrtvThongkehoadon.Refresh();

                    conn.Close();
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "sp_Thongketheongayban";

                    comm.Parameters.AddWithValue("@dThoigianvao", Tgvao);
                    comm.Parameters.AddWithValue("@dThoigianra", Tgra);
                    comm.Parameters.AddWithValue("@sMaban", Maban);



                    SqlDataAdapter adt = new SqlDataAdapter(comm);
                    DataTable data = new DataTable();
                    adt.Fill(data);

                    crystalThongke crtThongke = new crystalThongke();
                    crtThongke.SetDataSource(data);
                    CrtvThongkehoadon.ReportSource = crtThongke;
                    CrtvThongkehoadon.Refresh();

                    conn.Close();
                }
            }
            
        }

       
    }
}
