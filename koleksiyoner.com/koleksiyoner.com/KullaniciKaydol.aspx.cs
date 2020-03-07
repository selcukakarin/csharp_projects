using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace koleksiyoner.com
{
    public partial class KullaniciKaydol : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KoleksiyonerEmail"] != null)
            {
                Response.Redirect("KullaniciProfilGuncelle.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUploadResim.HasFile)
            {
                string pathName = "Images/" + Path.GetFileName(FileUploadResim.PostedFile.FileName);
                SqlCommand cmd = new SqlCommand("insert into Koleksiyoner(KoleksiyonerAdi,KoleksiyonerSifre,KoleksiyonerResimYolu,KoleksiyonerAdres,KoleksiyonerEmail,KoleksiyonerTelefon) values ('" + txtAd.Text + "','" + txtSifre.Text + "','" + pathName + "','" + txtAdres.Text + "','" + txtEmail.Text + "','" + txtTel.Text + "')", baglan.baglan());
                cmd.ExecuteNonQuery();
                FileUploadResim.SaveAs(Server.MapPath("Images/" + FileUploadResim.FileName));
            }else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('resim boş olamaz')",true);
            }

        
        
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}