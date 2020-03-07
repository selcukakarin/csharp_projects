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
    public partial class ForumKonuGuncelle : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        SQLBaglanti baglan1 = new SQLBaglanti();
        string ForumKonuID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ForumKonuID = Request.QueryString["ForumKonuID"];
            if (Page.IsPostBack == false)
            {
                if (Session["KoleksiyonerEmail"] != null)
                {
                    //kategori çek
                    SqlCommand cmd = new SqlCommand("Select * from Kategori ", baglan.baglan());
                    SqlDataReader dr = cmd.ExecuteReader();
                    DropDownListKonu.DataTextField = "KategoriAdi";
                    DropDownListKonu.DataValueField = "KategoriID";
                    DropDownListKonu.DataSource = dr;
                    DropDownListKonu.DataBind();

                    SqlCommand cmdKonuGetir = new SqlCommand("Select * from ForumKonu where ForumKonuID='" + ForumKonuID + "'", baglan.baglan());
                    SqlDataReader drKonuGuncelle = cmdKonuGetir.ExecuteReader();
                    DataTable dtKonuGuncelle = new DataTable("tablo");
                    dtKonuGuncelle.Load(drKonuGuncelle);
                    DataRow row = dtKonuGuncelle.Rows[0];
                    
                    txtKonuAdi.Text = row["ForumKonuBaslik"].ToString();
                    txtIcerik.Text = row["ForumKonuIcerik"].ToString();
                    SqlCommand cmd2 = new SqlCommand("Select * from Kategori where KategoriAdi='"+row["KategoriAdi"].ToString()+"'", baglan.baglan());
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    DataTable dt2 = new DataTable("tablo");
                    dt2.Load(dr2);
                    DataRow row2 = dt2.Rows[0];

                    DropDownListKonu.SelectedIndex = (Convert.ToInt32(row2["KategoriID"])-1);


                    string kEmail = Session["KoleksiyonerEmail"].ToString();
                    SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
                    SqlDataReader drSession = cmdSession.ExecuteReader();
                    DatalistProfilBilgi.DataSource = drSession;
                    DatalistProfilBilgi.DataBind();

                }
                else
                {
                    Response.Redirect("KullaniciGiris.aspx");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update ForumKonu set ForumKonuBaslik='" + txtKonuAdi.Text + "',ForumKonuIcerik='" + txtIcerik.Text + "',ForumKonuTarihi='" + DateTime.Now.ToString("MM.dd.yyyy ") + "',KategoriAdi='" + DropDownListKonu.SelectedItem.Text + "' where ForumKonuID='" + ForumKonuID + "'", baglan.baglan());
            cmd.ExecuteNonQuery();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}