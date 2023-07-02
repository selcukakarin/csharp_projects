using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kartal_pansiyon_ve_dinlenme_tesisleri
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kartal pansiyon ve dinlenme tesisleri uygulaması / 2016 Maribor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmYeniMusteri fr = new FrmYeniMusteri();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMusteriler frm = new FrmMusteriler();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmPersoneller frm = new FrmPersoneller();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmOdalar frm = new FrmOdalar();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongDateString();
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMuhasebe_Click(object sender, EventArgs e)
        {
            FrmMuhasebe frm = new FrmMuhasebe();
            frm.Show();
        }

        private void btnStoklar_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriMesajlar_Click(object sender, EventArgs e)
        {
            FrmMesajlar frm = new FrmMesajlar();
            frm.Show();
        }

        private void btnRadyoDinle_Click(object sender, EventArgs e)
        {
            FrmRadyo frm = new FrmRadyo();
            frm.Show();
        }

        private void btnGazeteler_Click(object sender, EventArgs e)
        {
            FrmGazeteler frm = new FrmGazeteler();
            frm.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FrmAdmin frm = new FrmAdmin();
            frm.Show();
        }
    }
}
