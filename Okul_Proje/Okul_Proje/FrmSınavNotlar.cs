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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-SP67UG4\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        int notid;
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));

        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;
            baglanti.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid=int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Txtsinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Txtsinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            Txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            Txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;

        private void BtnHesap_Click(object sender, EventArgs e)
        {
           
            string durum;
            sinav1 = Convert.ToInt16(Txtsinav1.Text);
            sinav2 = Convert.ToInt16(Txtsinav2.Text);
            sinav3 = Convert.ToInt16(Txtsinav3.Text);
            proje = Convert.ToInt16(Txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            Txtort.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                Txtdurum.Text = "True";
            }
            else
            {
                Txtdurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()),int.Parse(txtid.Text),byte.Parse(Txtsinav1.Text),byte.Parse(Txtsinav2.Text),byte.Parse(Txtsinav3.Text),byte.Parse(Txtproje.Text),byte.Parse(Txtort.Text),bool.Parse(Txtdurum.Text),notid);
        }
    }
}
