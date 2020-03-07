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
    public partial class ForumKonuAc : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["KoleksiyonerEmail"] != null)
                {
                    //kategori çek
                    SqlCommand cmd = new SqlCommand("Select * from Kategori", baglan.baglan());
                    SqlDataReader dr = cmd.ExecuteReader();
                    DropDownListKategori.DataTextField = "KategoriAdi";
                    DropDownListKategori.DataValueField = "KategoriID";
                    DropDownListKategori.DataSource = dr;
                    DropDownListKategori.DataBind();

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
            int KatID = ((DropDownListKategori.SelectedIndex) + 1);
            SqlCommand komut = new SqlCommand("insert into ForumKonu(ForumKonuBaslik,ForumKonuIcerik,KategoriAdi,ForumKonuTarihi,Yayin)values('" + txtKonuAdi.Text + "','" + txtKonuIcerik.Text + "','" + KatID + "','" + DateTime.Now.ToString("MM.dd.yyyy") + "'," + 0 + ")", baglan.baglan());
            komut.ExecuteNonQuery();
            Response.Redirect("SiteForum.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}