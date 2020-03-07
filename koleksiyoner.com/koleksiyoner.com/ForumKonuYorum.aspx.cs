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
    public partial class ForumKonuYorum : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        string ForumKonuID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ForumKonuID = Request.QueryString["ForumKonuID"];
            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
                SqlDataReader drSession = cmdSession.ExecuteReader();
                DatalistProfilBilgi.DataSource = drSession;
                DatalistProfilBilgi.DataBind();
                SqlCommand cmuGetir = new SqlCommand("Select * from ForumKonu where ForumKonuID=" + ForumKonuID + "", baglan.baglan());
                SqlDataReader druGetir = cmuGetir.ExecuteReader();
                DataListForumKonuGetir.DataSource = druGetir;
                DataListForumKonuGetir.DataBind();
                SqlCommand cmYorumGetir = new SqlCommand("Select * from ForumKonuYorum where ForumKonuID=" + ForumKonuID + "", baglan.baglan());
                SqlDataReader drYorumGetir = cmYorumGetir.ExecuteReader();
                DatalistMesajGetir.DataSource = drYorumGetir;
                DatalistMesajGetir.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {

                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdKullaniciGetir = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
                SqlDataReader drKullaniciGuncelle = cmdKullaniciGetir.ExecuteReader();
                DataTable dtKullaniciGuncelle = new DataTable("tablo1");
                dtKullaniciGuncelle.Load(drKullaniciGuncelle);
                DataRow row = dtKullaniciGuncelle.Rows[0];
                string KullaniciAdi = row["KoleksiyonerAdi"].ToString();
                SqlCommand komut = new SqlCommand("Insert Into ForumKonuYorum(KullaniciAdi, ForumYorumIcerik, ForumKonuID) Values ('" + KullaniciAdi.ToString() + "','" + TextBox3.Text + "','" + ForumKonuID + "')", baglan.baglan());
                try
                {
                    komut.ExecuteNonQuery();
                    TextBox3.Text = "";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "İletildi", "<script>alert('Mesajınız Başarılı Bir Şekilde İletilmiştir');</script>");
                }
                catch
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata!!!", "<script>alert('Mesajınız İletilemedi');</script>");
                }
                Response.Redirect("ForumKonuYorum.aspx?ForumKonuID="+ForumKonuID+"");
            
        }
    }
}