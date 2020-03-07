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
    public partial class KullaniciUrunSilGuncelle : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        string islem = "";
        string UrunID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UrunID = Request.QueryString["UrunID"];
            islem = Request.QueryString["islem"];
            
            if (islem == "sil")
            {
                SqlCommand cmuSil = new SqlCommand("Delete from Urun where UrunID='"+UrunID+"'", baglan.baglan());
                cmuSil.ExecuteNonQuery();
            }

            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
                SqlDataReader drSession = cmdSession.ExecuteReader();
                DatalistProfilBilgi.DataSource = drSession;
                DatalistProfilBilgi.DataBind();
               

                SqlCommand cmuGetir = new SqlCommand("Select * from Urun where Ekleyen="+0+"", baglan.baglan());
                SqlDataReader druGetir = cmuGetir.ExecuteReader();

                DataListKategoriGetir.DataSource = druGetir;
                DataListKategoriGetir.DataBind();
                SqlCommand cmuGetir1 = new SqlCommand("Select * from Urun where Ekleyen=" + 1 + "", baglan.baglan());
                SqlDataReader druGetir1 = cmuGetir1.ExecuteReader();

                DataList1.DataSource = druGetir1;
                DataList1.DataBind();

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