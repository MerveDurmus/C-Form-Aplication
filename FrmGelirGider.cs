using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OtelOtomasyonu
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=Merve-PC;Initial Catalog=Merve;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int personel;
            personel = Convert.ToInt32(textBox1.Text);
            lblPersonelMaas.Text = (personel * 1500).ToString();

            int sonuc;
            sonuc = Convert.ToInt32(lblKasaToplam.Text) - (Convert.ToInt32(lblPersonelMaas.Text) + Convert.ToInt32(lblGida.Text) + Convert.ToInt32(lblIcecek.Text) + Convert.ToInt32(lblAtistirmalik.Text) + Convert.ToInt32(lblElektrik.Text) + Convert.ToInt32(lblSu.Text) + Convert.ToInt32(lblInternet.Text));
            lbsonuc.Text = sonuc.ToString();

        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select sum (Ucret) as toplam from Musteriler ",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKasaToplam.Text = oku["toplam"].ToString();
            }
            baglan.Close();

            //Gidalar
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select sum (Gida) as toplam1 from Stoklar", baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                lblGida.Text = oku1["toplam1"].ToString();
            }
            baglan.Close();

            //İÇECEKLER
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("select sum (Icecek) as toplam2 from Stoklar", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblIcecek.Text = oku2["toplam2"].ToString();
            }
            baglan.Close();

            //ATIŞTIRMALIKLAR
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("select sum (Cerezler) as toplam3 from Stoklar", baglan);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblAtistirmalik.Text = oku3["toplam3"].ToString();
            }
            baglan.Close();

            //Elektrik
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("select sum (Elektrik) as toplam4 from Faturalar", baglan);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblElektrik.Text = oku4["toplam4"].ToString();
            }
            baglan.Close();

            //Su
            baglan.Open();
            SqlCommand komut5 = new SqlCommand("select sum (Su) as toplam5 from Faturalar", baglan);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lblSu.Text = oku5["toplam5"].ToString();
            }
            baglan.Close();

            //Internet
            baglan.Open();
            SqlCommand komut6 = new SqlCommand("select sum (Internet) as toplam6 from Faturalar", baglan);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lblInternet.Text = oku6["toplam6"].ToString();
            }
            baglan.Close();

        }
    }
}

