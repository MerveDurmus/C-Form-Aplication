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
    public partial class FrmMesajlar : Form
    {
        public FrmMesajlar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=Merve-PC;Initial Catalog=Merve;Integrated Security=True");
        private void VerileriGoster()
        {
            listView1.Items.Clear(); //her defasında verileri listviwi temizleyip öğleri getirir.
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Mesajlar1", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MesajID"].ToString();
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Mesaj"].ToString());
                

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Mesajlar1(AdSoyad,Mesaj) values('" + textBox1.Text + "','" + richTextBox1.Text + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VerileriGoster();
        }

        private void FrmMesajlar_Load(object sender, EventArgs e)
        {
            VerileriGoster();
        }
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            richTextBox1.Text=listView1.SelectedItems[0].SubItems[2].Text;

        }
    }
}
