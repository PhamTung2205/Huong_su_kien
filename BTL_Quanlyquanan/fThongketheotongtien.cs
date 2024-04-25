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
    public partial class fThongketheotongtien : Form
    {
        private int tientruoc;
        private int tiensau;
        public fThongketheotongtien( int tientruoc , int tiensau)
        {
            InitializeComponent();
            this.tientruoc = tientruoc;
            this.tiensau = tiensau;
        }
        string constr = @"Data Source=DESKTOP-RLE8QUC\TUNGSQL;Initial Catalog=Quanlyquanan;Integrated Security=True";



        private void fThongketheotongtien_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "sp_Thongkehoadontheotien";
                comm.Parameters.AddWithValue("@fTongtientruoc", tientruoc);
                comm.Parameters.AddWithValue("@fTongtiensau", tiensau);
                SqlDataAdapter adt = new SqlDataAdapter(comm);
                DataTable data = new DataTable();
                adt.Fill(data);

                CrystalThongketheogia crtThongke = new CrystalThongketheogia();
                crtThongke.SetDataSource(data);
                cryptallThongketheotien.ReportSource = crtThongke;
                cryptallThongketheotien.Refresh();
                conn.Close();

            }
        }
    }
}
