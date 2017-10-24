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
    public partial class FrmSifreGuncelle : Form
    {
        public FrmSifreGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=Merve-PC;Initial Catalog=Merve;Integrated Security=True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update AdminGiris set Kullanici='" + txtKullaniciAdi.Text + "',Parola='" + txtSifre.Text + "'",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
           
        }
    }
}
