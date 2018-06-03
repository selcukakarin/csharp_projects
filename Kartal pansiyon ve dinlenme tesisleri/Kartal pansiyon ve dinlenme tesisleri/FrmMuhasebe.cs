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
    public partial class FrmMuhasebe : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");

        private void verileriGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from SatinAlinanUrunler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["UrunId"].ToString();
                row.Cells[1].Value = oku["UrunAdi"].ToString();
                row.Cells[2].Value = oku["UrunAdet"].ToString();
                row.Cells[3].Value = oku["PersonelId"].ToString();
                row.Cells[4].Value = oku["SaticiFirma"].ToString();
                row.Cells[5].Value = oku["SaticiFirmaTel"].ToString();
                row.Cells[6].Value = oku["EkAciklama"].ToString();
                row.Cells[7].Value = oku["SatinAlmaTarihi"].ToString();
                row.Cells[8].Value = oku["BirimFiyat"].ToString();
                row.Cells[9].Value = oku["UrunKod"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
        }
        private void verileriGosterIsletmeGider()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from IsletmeGider", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView2.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                row.Cells[0].Value = oku["GiderId"].ToString();
                row.Cells[1].Value = oku["GiderAdi"].ToString();
                row.Cells[2].Value = oku["GiderFiyat"].ToString();
                row.Cells[3].Value = oku["SorumluPersonelId"].ToString();
                row.Cells[4].Value = oku["EkAciklama"].ToString();
                row.Cells[5].Value = oku["OdenmeTarihi"].ToString();
                dataGridView2.Rows.Add(row);
            }
            baglanti.Close();
        }
        private void verileriGosterPersonel()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Personel", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView3.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[0].Clone();
                row.Cells[0].Value = oku["PersonelId"].ToString();
                row.Cells[1].Value = oku["Adi"].ToString();
                row.Cells[2].Value = oku["Soyadi"].ToString();
                row.Cells[3].Value = oku["Cinsiyet"].ToString();
                row.Cells[4].Value = oku["Telefon"].ToString();
                row.Cells[5].Value = oku["Mail"].ToString();
                row.Cells[6].Value = oku["Tc"].ToString();
                row.Cells[7].Value = oku["Adres"].ToString();
                row.Cells[8].Value = oku["Maas"].ToString();
                dataGridView3.Rows.Add(row);
            }
            baglanti.Close();
        }
        private void verileriGosterStok()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Stok", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView4.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView4.Rows[0].Clone();
                row.Cells[0].Value = oku["StokId"].ToString();
                row.Cells[1].Value = oku["StokAdet"].ToString();
                row.Cells[2].Value = oku["UrunKod"].ToString();
                dataGridView4.Rows.Add(row);
            }
            baglanti.Close();
        }

        public FrmMuhasebe()
        {
            InitializeComponent();
        }




        private void btnVerileriGoster_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            verileriGoster();
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update Stok set StokAdet=StokAdet-" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                + "where UrunKod=(SELECT Top 1 UrunKod from SatinAlinanUrunler ORDER BY UrunId DESC)", baglanti);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from SatinAlinanUrunler where UrunId='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            
            verileriGoster();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            TxtUrunAdi.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            TxtUrunAdet.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            CboxSAPersonel.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            TxtSaticiFirma.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            MskTxtSaticiFirmaTelefon.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            TxtEkAciklama.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            DtpAlimTarihi.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtBirimFiyat.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txtUrunKod.Text= dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            TxtUrunAdi.Clear();
            TxtUrunAdet.Clear();
            MskTxtSaticiFirmaTelefon.Clear();
            CboxSAPersonel.Text = "";
            MskTxtSaticiFirmaTelefon.Clear();
            TxtSaticiFirma.Clear();
            DtpAlimTarihi.Text = "";
            txtBirimFiyat.Clear();
            txtUrunKod.Clear();
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update Stok set StokAdet=StokAdet-" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
            + "where UrunKod=(SELECT Top 1 UrunKod from SatinAlinanUrunler ORDER BY UrunId DESC)", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update SatinAlinanUrunler set UrunAdi='" + TxtUrunAdi.Text + "',UrunAdet='" +
                                            Convert.ToInt32(TxtUrunAdet.Text) + "',PersonelId='" + Convert.ToInt32(CboxSAPersonel.Text) + "',SaticiFirma='" + TxtSaticiFirma.Text
                                            + "',SaticiFirmaTel='" + MskTxtSaticiFirmaTelefon.Text + "',EkAciklama='" + TxtEkAciklama.Text
                                            + "',SatinAlmaTarihi='" + DtpAlimTarihi.Value.ToString("yyyy-MM-dd") + "',BirimFiyat='" + Convert.ToInt32(txtBirimFiyat.Text) 
                                            + "',UrunKod='"+ Convert.ToInt32(txtUrunKod.Text)+"' where UrunId='" +
                                            dataGridView1.SelectedRows[0].Cells[0].Value + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
                SqlCommand komut4 = new SqlCommand("update Stok set StokAdet=StokAdet+" + Convert.ToInt32(TxtUrunAdet.Text)
                    + "where UrunKod=(SELECT Top 1 UrunKod from SatinAlinanUrunler ORDER BY UrunId DESC)", baglanti);
                komut4.ExecuteNonQuery();
                baglanti.Close();
            
            verileriGoster();
        }

        private void btnAra_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from SatinAlinanUrunler where UrunAdi like '%" + txtAra.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["UrunId"].ToString();
                row.Cells[1].Value = oku["UrunAdi"].ToString();
                row.Cells[2].Value = oku["UrunAdet"].ToString();
                row.Cells[3].Value = oku["PersonelId"].ToString();
                row.Cells[3].Value = oku["SaticiFirma"].ToString();
                row.Cells[4].Value = oku["SaticiFirmaTel"].ToString();
                row.Cells[5].Value = oku["EkAciklama"].ToString();
                row.Cells[6].Value = oku["SatinAlmaTarihi"].ToString();
                row.Cells[7].Value = oku["BirimFiyat"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into SatinAlinanUrunler(UrunAdi,UrunAdet,PersonelId,SaticiFirma,SaticiFirmaTel,EkAciklama,SatinAlmaTarihi,BirimFiyat,UrunKod)values('" + TxtUrunAdi.Text + "','" + Convert.ToInt32(TxtUrunAdet.Text) + "','" + Convert.ToInt32(CboxSAPersonel.Text) + "','" + TxtSaticiFirma.Text + "','" + MskTxtSaticiFirmaTelefon.Text + "','" + TxtEkAciklama.Text + "','" + DtpAlimTarihi.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToInt32(txtBirimFiyat.Text) + "','" + Convert.ToInt32(txtUrunKod.Text) + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            SqlCommand komut2 = new SqlCommand("Select * from Stok where Stok.UrunKod=(Select Top 1 SatinAlinanUrunler.UrunKod from SatinAlinanUrunler Order by UrunId desc)", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut2);

            da.Fill(dt);
            if (dt.Rows.Count ==0)
            {
                baglanti.Close();
                
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("insert into Stok(StokAdet,UrunKod)values('" + Convert.ToInt32(TxtUrunAdet.Text) + "',(SELECT Top 1 UrunKod from SatinAlinanUrunler ORDER BY UrunId DESC )) ", baglanti);
                komut3.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {

                baglanti.Close();
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("update Stok set StokAdet=StokAdet+" + Convert.ToInt32(TxtUrunAdet.Text)
                    + ",UrunKod='" + Convert.ToInt32(txtUrunKod.Text) + "'where UrunKod=(SELECT Top 1 UrunKod from SatinAlinanUrunler ORDER BY UrunId DESC)", baglanti);
                komut4.ExecuteNonQuery();
                baglanti.Close();
            }

            baglanti.Close();
            MessageBox.Show("Ürün alım kaydı yapıldı.");
            verileriGoster();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            verileriGosterIsletmeGider();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update IsletmeGider set GiderAdi='" + txtGider.Text + "',GiderFiyat='" +
                                            Convert.ToInt32(txtGiderFiyat.Text) + "',SorumluPersonelId='" + Convert.ToInt32(cBoxSorumluPersonel.Text) +
                                            "',EkAciklama='" + txtEkAciklamaIsletme.Text + "',OdenmeTarihi='" + DTPOdenmeTarihi.Value.ToString("yyyy-MM-dd") + "'where GiderId = '" +
                                            dataGridView2.SelectedRows[0].Cells[0].Value + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGosterIsletmeGider();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from IsletmeGider where GiderId='" + dataGridView2.SelectedRows[0].Cells[0].Value + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGosterIsletmeGider();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtGider.Clear();
            txtGiderFiyat.Clear();
            cBoxSorumluPersonel.Text = "";
            txtEkAciklamaIsletme.Clear();
            DTPOdenmeTarihi.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into IsletmeGider(GiderAdi,GiderFiyat,SorumluPersonelId,EkAciklama,OdenmeTarihi)values('" + txtGider.Text + "','" + Convert.ToInt32(txtGiderFiyat.Text) + "','" + Convert.ToInt32(cBoxSorumluPersonel.Text) + "','" + txtEkAciklamaIsletme.Text + "','" + DTPOdenmeTarihi.Value.ToString("yyyy-MM-dd") + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşletme gider kaydı yapıldı.");
            verileriGosterIsletmeGider();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from IsletmeGider where GiderAdi like '%" + txtGider.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView2.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                row.Cells[0].Value = oku["GiderId"].ToString();
                row.Cells[1].Value = oku["GiderAdi"].ToString();
                row.Cells[2].Value = oku["GiderFiyat"].ToString();
                row.Cells[3].Value = oku["SorumluPersonelId"].ToString();
                row.Cells[3].Value = oku["EkAciklama"].ToString();
                row.Cells[4].Value = oku["OdenmeTarihi"].ToString();
                dataGridView2.Rows.Add(row);
            }
            baglanti.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.dataGridView3.Rows.Clear();
            verileriGosterPersonel();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Personel where Adi like '%" + textBox1.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView3.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[0].Clone();
                row.Cells[0].Value = oku["PersonelId"].ToString();
                row.Cells[1].Value = oku["Adi"].ToString();
                row.Cells[2].Value = oku["Soyadi"].ToString();
                row.Cells[3].Value = oku["Cinsiyet"].ToString();
                row.Cells[4].Value = oku["Telefon"].ToString();
                row.Cells[5].Value = oku["Mail"].ToString();
                row.Cells[6].Value = oku["Tc"].ToString();
                row.Cells[7].Value = oku["Adres"].ToString();
                row.Cells[8].Value = oku["Maas"].ToString();
                dataGridView3.Rows.Add(row);
            }
            baglanti.Close();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            txtGider.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            txtGiderFiyat.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            cBoxSorumluPersonel.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
            txtEkAciklamaIsletme.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
            DTPOdenmeTarihi.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(Ucret) as toplam from Musteri", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            int kazanc = 0, maaslar = 0, giderler = 0, urunGider = 0;
            while (oku.Read())
            {
                kazanc = Convert.ToInt32(oku["toplam"].ToString());
                lblToplamKazanc.Text = oku["toplam"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select sum(Maas) as toplamMaas from Personel", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                maaslar = Convert.ToInt32(oku2["toplamMaas"].ToString());
                lblPersonelMaas.Text = oku2["toplamMaas"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select sum(GiderFiyat) as toplamGider from IsletmeGider", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                giderler = Convert.ToInt32(oku3["toplamGider"].ToString());
                lblIsletmeGider.Text = oku3["toplamGider"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select sum(UrunAdet*BirimFiyat) as toplamUrunGider from SatinAlinanUrunler", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                urunGider = Convert.ToInt32(oku4["toplamUrunGider"].ToString());
                lblUrunGider.Text = oku4["toplamUrunGider"].ToString();
            }
            baglanti.Close();
            lblKasadakiToplamTutar.Text = (kazanc - (maaslar + giderler + urunGider)).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.dataGridView4.Rows.Clear();
            verileriGosterStok();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Personel where Adi like '%" + textBox2.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView4.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView4.Rows[0].Clone();
                row.Cells[0].Value = oku["StokId"].ToString();
                row.Cells[1].Value = oku["StokAdet"].ToString();
                row.Cells[2].Value = oku["UrunId"].ToString();
                dataGridView4.Rows.Add(row);
            }
            baglanti.Close();
        }

        private void dataGridView4_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
