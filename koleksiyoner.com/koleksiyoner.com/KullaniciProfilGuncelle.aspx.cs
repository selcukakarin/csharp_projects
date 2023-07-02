using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace koleksiyoner.com
{
    public partial class KullaniciProfil : System.Web.UI.Page
    {
        SQLBaglanti bag = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                if (Session["KoleksiyonerEmail"] != null)
                {
                    string kEmail = Session["KoleksiyonerEmail"].ToString();
                    SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", bag.baglan());
                    SqlDataReader drSession = cmdSession.ExecuteReader();
                    DatalistProfilBilgi.DataSource = drSession;
                    DatalistProfilBilgi.DataBind();
                    SqlCommand cmdKoleksiyoner = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", bag.baglan());
                    cmdKoleksiyoner.ExecuteNonQuery();
                    SqlDataReader drKoleksiyoner = cmdKoleksiyoner.ExecuteReader();

                    DataTable dtKGuncelle = new DataTable("tablo");
                    dtKGuncelle.Load(drKoleksiyoner);
                    DataRow row = dtKGuncelle.Rows[0];
                    txtAd.Text = row["KoleksiyonerAdi"].ToString();
                    txtEmail.Text = row["KoleksiyonerEmail"].ToString();
                    txtSifre.Text = row["KoleksiyonerSifre"].ToString();
                    txtTel.Text = row["KoleksiyonerTelefon"].ToString();
                    txtAdres.Text = row["KoleksiyonerAdres"].ToString();
                }
                else
                {
                    Response.Redirect("KullaniciGiris.aspx");
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                if (fuFoto.HasFile)
                {
                    string pathName = "Images/" + Path.GetFileName(fuFoto.PostedFile.FileName);
                    SqlCommand cmd = new SqlCommand("Update Koleksiyoner Set KoleksiyonerAdi='" + txtAd.Text + "',KoleksiyonerSifre='" + txtSifre.Text + "',KoleksiyonerResimYolu='" + pathName + "',KoleksiyonerAdres='" + txtAdres.Text + "',KoleksiyonerEmail='" + txtEmail.Text + "',KoleksiyonerTelefon='" + txtTel.Text + "' where KoleksiyonerEmail='" + kEmail + "' ", bag.baglan());
                    fuFoto.SaveAs(Server.MapPath("Images/" + fuFoto.FileName));
                    cmd.ExecuteNonQuery();
                    
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Update Koleksiyoner Set KoleksiyonerAdi='" + txtAd.Text + "',KoleksiyonerSifre='" + txtSifre.Text + "',KoleksiyonerAdres='" + txtAdres.Text + "',KoleksiyonerEmail='" + txtEmail.Text + "',KoleksiyonerTelefon='" + txtTel.Text + "' where KoleksiyonerEmail='" + kEmail + "'  ", bag.baglan());
                    cmd.ExecuteNonQuery();
                }
                Response.Redirect("KullaniciProfilGuncelle.aspx");
            }
            else
            {
                Response.Redirect("SiteAnasayfa.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}