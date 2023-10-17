using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_Proje
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-SP67UG4\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM from TBLNOTLAR \r\nINNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID=TBLDERSLER.DERSID WHERE OGRENCIID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
