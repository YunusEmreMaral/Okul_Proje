using Okul_Proje.DataSet1TableAdapters;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Okul_Proje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-SP67UG4\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void label3_Click(object sender, EventArgs e)
        {

        }
        DataSet1TableAdapters.TBLOGRENCILERTableAdapter ds = new DataSet1TableAdapters.TBLOGRENCILERTableAdapter();

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKULUPLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KULUPAD";
            cmbkulup.ValueMember = "KULUPID";
            cmbkulup.DataSource = dt;
            baglanti.Close();


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        string c = "";
        private void button3_Click(object sender, EventArgs e)
        {
       
           
            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("Ögrenci Eklendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void txtsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtid.Text));
            MessageBox.Show("Ogrenci Silindi");

        }
        string cinsiyet="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (cinsiyet == "Kız")
            {
                kiz.Checked = true;
                erkek.Checked = false;

            }
            if (cinsiyet == "Erkek")
            {
                kiz.Checked = false;
                erkek.Checked = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c, int.Parse(txtid.Text));

            MessageBox.Show("Öğrenci Güncellendi");
        }

        private void kiz_CheckedChanged(object sender, EventArgs e)
        {
            
            if (kiz.Checked == true)
            {
                c = "Kız";
            }
        }

        private void erkek_CheckedChanged(object sender, EventArgs e)
        {
            if (erkek.Checked == true)
            {
                c = "Erkek";

            }
              
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrenciGetir(txtara.Text);

        }
    }
}
