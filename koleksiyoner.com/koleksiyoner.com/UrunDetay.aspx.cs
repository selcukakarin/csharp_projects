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
    public partial class urunDetay : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        string UrunID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UrunID = Request.QueryString["UrunID"];
            

            SqlCommand cmuGetir = new SqlCommand("Select * from Urun where UrunID='" + UrunID + "'", baglan.baglan());
            SqlDataReader druGetir = cmuGetir.ExecuteReader();
            Datalist1.DataSource = druGetir;
            Datalist1.DataBind();
            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
                SqlDataReader drSession = cmdSession.ExecuteReader();
                DatalistProfilBilgi.DataSource = drSession;
                DatalistProfilBilgi.DataBind();
                Panel1.Visible = false;
                //SqlCommand cmYorumGetir = new SqlCommand("Select * from ForumKonuYorum where ForumKonuID=" + ForumKonuID + "", baglan.baglan());
                //SqlDataReader drYorumGetir = cmYorumGetir.ExecuteReader();
                //DatalistMesajGetir.DataSource = drYorumGetir;
                //DatalistMesajGetir.DataBind();
            }
            else
            {
                
                Panel2.Visible = false;
                
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}