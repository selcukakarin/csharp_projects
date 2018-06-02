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
using System.Web;

namespace Kartal_pansiyon_ve_dinlenme_tesisleri
{
    public partial class FrmYeniMusteri : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");

        public FrmYeniMusteri()
        {
            InitializeComponent();
        }


        private void BtnDoluOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı renkli butonlar dolu odaları gösterir.");
        }

        private void BtnBosOda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bej renkli butonlar boş odaları gösterir.");
        }

        private void DtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            int ucret;
            DateTime girisTarih = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime cikisTarih = Convert.ToDateTime(DtpCikisTarihi.Text);
            TimeSpan sonuc;
            sonuc = cikisTarih - girisTarih;
            String toplamGunSayisi = sonuc.TotalDays.ToString();
            ucret = Convert.ToInt32(toplamGunSayisi) * 50;
            TxtUcret.Text = ucret.ToString();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Musteri(Adi,Soyadi,Cinsiyet,Telefon,Mail,Tc,OdaNo,Ucret,GirisTarihi,CikisTarihi) values ('" + TxtAdi.Text+"','"+TxtSoyadi.Text+"','"+CboxCinsiyet.Text+"','"+MskTxtTelefon.Text+"','"+TxtMail.Text+"','"+TxtTc.Text+"','"+TxtOdaNo.Text+"','"+Convert.ToInt32(TxtUcret.Text)+"','"+DtpGirisTarihi.Value.ToString("yyyy-MM-dd")+"','"+DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri kaydı yapıldı.");
        }

        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            foreach (Button btn in Controls.OfType<Button>())
            {
                int n;
                bool isNumeric = int.TryParse(btn.Text, out n);
                if (isNumeric)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("select * from Musteri where OdaNo='" + Convert.ToInt32(btn.Text) + "'", baglanti);
                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        btn.Text = oku["Adi"].ToString() + "\n" + oku["Soyadi"].ToString();
                        btn.BackColor = Color.Crimson;
                        btn.Enabled = false;
                    }
                    baglanti.Close();
                }
            }
        }

        private void BtnOda101_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "101";
        }

        private void BtnOda102_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "102";
        }

        private void BtnOda103_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "103";
        }

        private void BtnOda104_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "104";
        }

        private void BtnOda105_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "105";
        }

        private void BtnOda106_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "106";
        }

        private void BtnOda107_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "107";
        }

        private void BtnOda108_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "108";
        }

        private void BtnOda109_Click_1(object sender, EventArgs e)
        {
            TxtOdaNo.Text = "109";
        }

        private void DtpGirisTarihi_ValueChanged(object sender, EventArgs e)
        {
            int ucret;
            DateTime girisTarih = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime cikisTarih = Convert.ToDateTime(DtpCikisTarihi.Text);
            TimeSpan sonuc;
            sonuc = cikisTarih - girisTarih;
            String toplamGunSayisi = sonuc.TotalDays.ToString();
            ucret = Convert.ToInt32(toplamGunSayisi) * 50;
            TxtUcret.Text = ucret.ToString();
        }
    }
}
// Data Source=DESKTOP-AC4V746;Integrated Security=True