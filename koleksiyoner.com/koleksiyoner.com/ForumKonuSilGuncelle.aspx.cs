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
    public partial class ForumKonuSilGuncelle : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        string islem = "";
        string ForumKonuID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ForumKonuID = Request.QueryString["ForumKonuID"];
            islem = Request.QueryString["islem"];

            if (islem == "sil")
            {
                SqlCommand cmuSil = new SqlCommand("Delete from ForumKonu where ForumKonuID='" + ForumKonuID + "'", baglan.baglan());
                cmuSil.ExecuteNonQuery();
            }
            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
                SqlDataReader drSession = cmdSession.ExecuteReader();
                DatalistProfilBilgi.DataSource = drSession;
                DatalistProfilBilgi.DataBind();
                SqlCommand cmForumKonuGetir = new SqlCommand("Select * from ForumKonu", baglan.baglan());
                SqlDataReader drForumKonuGetir = cmForumKonuGetir.ExecuteReader();

                DataListKonuGetir.DataSource = drForumKonuGetir;
                DataListKonuGetir.DataBind();
            }
            else
            {
                Response.Redirect("KullaniciGiris.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}