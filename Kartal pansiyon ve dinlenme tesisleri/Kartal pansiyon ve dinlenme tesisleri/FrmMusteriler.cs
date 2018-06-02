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

namespace Kartal_pansiyon_ve_dinlenme_tesisleri
{
    public partial class FrmMusteriler : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");
        private void verileriGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Musteri", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["MusteriId"].ToString();
                row.Cells[1].Value = oku["Adi"].ToString();
                row.Cells[2].Value = oku["Soyadi"].ToString();
                row.Cells[3].Value = oku["Cinsiyet"].ToString();
                row.Cells[4].Value = oku["Telefon"].ToString();
                row.Cells[5].Value = oku["Mail"].ToString();
                row.Cells[6].Value = oku["Tc"].ToString();
                row.Cells[7].Value = oku["OdaNo"].ToString();
                row.Cells[8].Value = oku["Ucret"].ToString();
                row.Cells[9].Value = oku["GirisTarihi"].ToString();
                row.Cells[10].Value = oku["CikisTarihi"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
        }
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            verileriGoster();
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {

        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Musteri where MusteriId='" + dataGridView1.SelectedRows[0].Cells[0].Value+ "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }



        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            TxtAdi.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            TxtSoyadi.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            CboxCinsiyet.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            MskTxtTelefon.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            TxtTc.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            TxtOdaNo.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            TxtUcret.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            DtpGirisTarihi.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            DtpCikisTarihi.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            MskTxtTelefon.Clear();
            CboxCinsiyet.Text = "";
            TxtMail.Clear();
            TxtTc.Clear();
            TxtOdaNo.Clear();
            TxtUcret.Clear();
            DtpGirisTarihi.Text = "";
            DtpCikisTarihi.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Musteri set Adi='" + TxtAdi.Text + "',Soyadi='" + 
                                            TxtSoyadi.Text + "',Cinsiyet='" + CboxCinsiyet.Text + "',Telefon='" + 
                                            MskTxtTelefon.Text + "',Mail='"+TxtMail.Text+"',Tc='"+TxtTc.Text+"',OdaNo='"+
                                            TxtOdaNo.Text+"',Ucret='"+Convert.ToInt32(TxtUcret.Text)+"',GirisTarihi='"+
                                            DtpGirisTarihi.Value.ToString("yyyy-MM-dd")+"',CikisTarihi='"+
                                            DtpCikisTarihi.Value.ToString("yyyy-MM-dd") + "' where MusteriId='"+
                                            dataGridView1.SelectedRows[0].Cells[0].Value + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            baglanti.Open(); 
            SqlCommand komut = new SqlCommand("select * from Musteri where Adi like '%"+txtAra.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["MusteriId"].ToString();
                row.Cells[1].Value = oku["Adi"].ToString();
                row.Cells[2].Value = oku["Soyadi"].ToString();
                row.Cells[3].Value = oku["Cinsiyet"].ToString();
                row.Cells[4].Value = oku["Telefon"].ToString();
                row.Cells[5].Value = oku["Mail"].ToString();
                row.Cells[6].Value = oku["Tc"].ToString();
                row.Cells[7].Value = oku["OdaNo"].ToString();
                row.Cells[8].Value = oku["Ucret"].ToString();
                row.Cells[9].Value = oku["GirisTarihi"].ToString();
                row.Cells[10].Value = oku["CikisTarihi"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
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
