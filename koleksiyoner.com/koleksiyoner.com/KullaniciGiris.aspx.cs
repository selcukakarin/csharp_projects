using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace koleksiyoner.com
{
    public partial class KullaniciGiris : System.Web.UI.Page
    {
        esqlbaglantisi baglan = new esqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KoleksiyonerEmail"] != null)
            {
                Response.Redirect("KullaniciProfilGuncelle.aspx");
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlCommand cmgiris = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + TextBox1.Text + "' and KoleksiyonerSifre='" + TextBox2.Text + "'", baglan.baglanti());
            SqlDataReader drgiris = cmgiris.ExecuteReader();

            if (drgiris.Read())
            {
                Session.Add("KoleksiyonerEmail", TextBox1.Text);
                Response.Redirect("KullaniciProfilGuncelle.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('HATALI GİRİŞ')", true);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}