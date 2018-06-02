﻿using System;
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
    public partial class FrmPersoneller : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");

        private void verileriGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Personel", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["PersonelId"].ToString();
                row.Cells[1].Value = oku["Adi"].ToString();
                row.Cells[2].Value = oku["Soyadi"].ToString();
                row.Cells[3].Value = oku["Cinsiyet"].ToString();
                row.Cells[4].Value = oku["Telefon"].ToString();
                row.Cells[5].Value = oku["Mail"].ToString();
                row.Cells[6].Value = oku["Tc"].ToString();
                row.Cells[7].Value = oku["Adres"].ToString();
                row.Cells[8].Value = oku["Maas"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
        }
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        private void btnVerileriGoster_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            verileriGoster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Personel where PersonelId='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            TxtAdi.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            TxtSoyadi.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            CboxCinsiyet.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            MskTxtTelefon.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            TxtTc.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            TxtAdres.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            TxtMaas.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            MskTxtTelefon.Clear();
            CboxCinsiyet.Text = "";
            TxtMail.Clear();
            TxtTc.Clear();
            TxtAdres.Clear();
            TxtMaas.Clear();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Personel set Adi='" + TxtAdi.Text + "',Soyadi='" +
                                            TxtSoyadi.Text + "',Cinsiyet='" + CboxCinsiyet.Text + "',Telefon='" +
                                            MskTxtTelefon.Text + "',Mail='" + TxtMail.Text + "',Tc='" + TxtTc.Text + "',Adres='" +
                                            TxtAdres.Text + "',Maas='" + Convert.ToInt32(TxtMaas.Text) +"'where PersonelId='" +
                                            dataGridView1.SelectedRows[0].Cells[0].Value + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Personel where Adi like '%" + txtAra.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["PersonelId"].ToString();
                row.Cells[1].Value = oku["Adi"].ToString();
                row.Cells[2].Value = oku["Soyadi"].ToString();
                row.Cells[3].Value = oku["Cinsiyet"].ToString();
                row.Cells[4].Value = oku["Telefon"].ToString();
                row.Cells[5].Value = oku["Mail"].ToString();
                row.Cells[6].Value = oku["Tc"].ToString();
                row.Cells[7].Value = oku["Adres"].ToString();
                row.Cells[8].Value = oku["Maas"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel(Adi,Soyadi,Cinsiyet,Telefon,Mail,Tc,Adres,Maas) values ('" + TxtAdi.Text + "','" + TxtSoyadi.Text + "','" + CboxCinsiyet.Text + "','" + MskTxtTelefon.Text + "','" + TxtMail.Text + "','" + TxtTc.Text + "','" + TxtAdres.Text + "','" + Convert.ToInt32(TxtMaas.Text) + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel kaydı yapıldı.");
            verileriGoster();
        }
    }
}
