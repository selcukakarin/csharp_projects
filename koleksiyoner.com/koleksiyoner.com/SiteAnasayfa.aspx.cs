using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace koleksiyoner.com
{
    public partial class anasayfa : System.Web.UI.Page
    {
        esqlbaglantisi baglan = new esqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmUrun = new SqlCommand("Select * from Urun where Yayin=" + 1 + "", baglan.baglanti());
            SqlDataReader drUrun = cmUrun.ExecuteReader();
            DataListUrun.DataSource = drUrun;
            DataListUrun.DataBind();
            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglanti());
                SqlDataReader drSession = cmdSession.ExecuteReader();
                DatalistProfilBilgi.DataSource = drSession;
                DatalistProfilBilgi.DataBind();
                Panel1.Visible = false;
            }
            else
            {
                DatalistProfilBilgi.Visible = false;
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