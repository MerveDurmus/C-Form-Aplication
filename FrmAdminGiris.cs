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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source = Merve - PC; Initial Catalog = Merve; Integrated Security = True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {

            try
            {
                baglan.Open();
                string sql = "select * from AdminGiris where Kullanici=@KullaniciAdi AND Parola=@Sifresi"; //parametre
                SqlParameter prm1 = new SqlParameter("KullaniciAdi", txtKullaniciAdi.Text.Trim());
                SqlParameter prm2 = new SqlParameter("Sifresi", txtSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglan);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    baglan.Close();
                    FrmAnaForm fr = new FrmAnaForm();
                    fr.Show();
                    this.Hide();
                }
                


            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı giriş");
            }  
        }
    }
}
