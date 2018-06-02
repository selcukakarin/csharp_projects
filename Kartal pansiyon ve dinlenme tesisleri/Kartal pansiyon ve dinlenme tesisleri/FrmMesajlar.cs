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
    
    public partial class FrmMesajlar : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");

        private void verileriGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Mesajlar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            this.dataGridView1.Rows.Clear();
            while (oku.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = oku["MesajId"].ToString();
                row.Cells[1].Value = oku["AdSoyad"].ToString();
                row.Cells[2].Value = oku["Mesaj"].ToString();
                dataGridView1.Rows.Add(row);
            }
            baglanti.Close();
        }
        public FrmMesajlar()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Mesajlar(AdSoyad,Mesaj)values('"+txtAdSoyad.Text+"','"+RtxtMesaj.Text+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verileriGoster();
        }

        private void FrmMesajlar_Load(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtAdSoyad.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            RtxtMesaj.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
        }
    }
}
