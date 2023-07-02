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
    public partial class FrmAdminGiris : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");

        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BtnAdminGiris_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string sql = "select * from Admin where Adi='" + TxtKullaniciAdi.Text.Trim() + "' AND Sifre='" + TxtSifre.Text.Trim() + "'";
            SqlCommand komut = new SqlCommand(sql, baglanti);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                baglanti.Close();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş!!!");
                baglanti.Close();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }
    }
}

