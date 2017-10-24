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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=Merve-PC;Initial Catalog=Merve;Integrated Security=True");
        private void VerileriGoster()
        {
            listView1.Items.Clear(); //her defasında verileri listviwi temizleyip öğleri getirir.
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Musteriler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriNo"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["Tc"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerileriGoster();
        }
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text); //id i hafızada tutuyorum şu an
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskTxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtTc.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtOdaNo.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
            DtpGirisTarihi.Text = listView1.SelectedItems[0].SubItems[9].Text;
            DtpCikisTarihi.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

       

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtOdaNo.Text == "101") {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda101", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "102")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda102", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "103")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda103", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "104")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda104", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "105")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda105", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "106")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda106", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "107")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda107", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "108")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda108", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }
            if (TxtOdaNo.Text == "109")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("delete from Oda109", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
                VerileriGoster();
            }

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); //her defasında verileri listviwi temizleyip öğleri getirir.
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Musteriler where Adi like '%"+textBox1.Text+"%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriNo"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["Tc"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Musteriler set Adi='" + TxtAdi.Text + "',Soyadi='" + TxtSoyadi.Text + "',Cinsiyet='" + comboBox1.Text + "',Telefon='" + MskTxtTelefon.Text + "',Mail='" + TxtMail.Text + "',TC='" + TxtTc.Text + "',OdaNo='" + TxtOdaNo.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + DtpGirisTarihi.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "'where MusteriNo=" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            comboBox1.Text = "";
            MskTxtTelefon.Text = "";
            TxtMail.Clear();
            TxtTc.Clear();
            TxtOdaNo.Clear();
            TxtUcret.Clear();
            DtpGirisTarihi.Text = "";
            DtpCikisTarihi.Text = "";
        }
    }

}
//Data Source=Merve-PC;Initial Catalog=Merve;Integrated Security=True
//SqlCommand komut = new SqlCommand("delete from Musteriler where MusteriNo=(" + id + ")", baglan);