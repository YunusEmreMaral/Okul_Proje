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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-SP67UG4\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       public  void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLKULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO  TBLKULUPLER (KULUPAD) VALUES (@P1)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp listeye eklendi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete FROM TBLKULUPLER WHERE KULUPID=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp silindi");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUPLER SET KULUPAD=@P1 WHERE KULUPID=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", textBox2.Text);
            komut.Parameters.AddWithValue("@P2", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Günnceleme işlemi gerçekleşti.");
            liste();
        }
    }
}
