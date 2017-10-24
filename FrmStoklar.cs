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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=Merve-PC;Initial Catalog=Merve;Integrated Security=True");
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            Veriler();
        }

        private void Veriler()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from  Stoklar", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Gida"].ToString();
                ekle.SubItems.Add(oku["Icecek"].ToString());
                ekle.SubItems.Add(oku["Cerezler"].ToString());
                listView1.Items.Add(ekle);
                
            }
            baglan.Close();
        }

        private void Veriler2()
        {
            listView2.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from  Faturalar", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Elektrik"].ToString();
                ekle.SubItems.Add(oku["Su"].ToString());
                ekle.SubItems.Add(oku["Internet"].ToString());
                listView2.Items.Add(ekle);

            }
            baglan.Close();

        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Stoklar(Gida,Icecek,Cerezler) values('" + txtGidaTutar.Text + "','" + txtIcecekTutar.Text + "','" + txtAtistirmalikTutar.Text + "')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Veriler();
        }

        private void btnKaydet2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Faturalar(Elektrik,Su,Internet) values('" + txtElektrik.Text + "','" + txtSu.Text + "','" + txtInternet.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Veriler2();
        }
    }
}
