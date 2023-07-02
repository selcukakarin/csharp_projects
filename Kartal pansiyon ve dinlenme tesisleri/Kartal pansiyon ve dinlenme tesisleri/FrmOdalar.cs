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
    public partial class FrmOdalar : Form
    {
        public FrmOdalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AC4V746;Initial Catalog=KartalPansiyon;Integrated Security=True");

        private void FrmOdalar_Load(object sender, EventArgs e)
        {
            

            foreach (Button btn in Controls.OfType<Button>()) {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Musteri where OdaNo='" + Convert.ToInt32(btn.Text)+"'",baglanti);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    btn.Text = oku["Adi"].ToString()+"\n"+oku["Soyadi"].ToString();
                    btn.BackColor = Color.Crimson;
                    btn.Enabled = false;
                }
                baglanti.Close();
            }
            
        }
    }
}
