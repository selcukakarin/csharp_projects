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
    public partial class SiteForum : System.Web.UI.Page
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
                    SqlCommand cmdForum = new SqlCommand("Select * from ForumKonu ", bag.baglan());
                    DropdownForumKonu.DataSource = cmdForum.ExecuteReader(); ;
                    DropdownForumKonu.DataTextField = "ForumKonuBaslik";
                    DropdownForumKonu.DataValueField = "ForumKonuID";
                    DropdownForumKonu.DataBind();
                    SqlCommand cmdForum1 = new SqlCommand("Select * from ForumKonu where KategoriAdi='" + DropdownForumKonu.SelectedItem.Text + "' ", bag.baglan());
                    SqlDataReader drForum = cmdForum1.ExecuteReader();
                    DataListForumKonuGetir.DataSource = drForum;
                    DataListForumKonuGetir.DataBind();
                }
                else
                {
                    Response.Redirect("KullaniciGiris.aspx");
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DropdownForumKonu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmdForum1 = new SqlCommand("Select * from ForumKonu where KategoriAdi='" + DropdownForumKonu.SelectedItem.Text + "' ", bag.baglan());
            SqlDataReader drForum = cmdForum1.ExecuteReader();
            DataListForumKonuGetir.DataSource = drForum;
            DataListForumKonuGetir.DataBind();
        }
    }
}