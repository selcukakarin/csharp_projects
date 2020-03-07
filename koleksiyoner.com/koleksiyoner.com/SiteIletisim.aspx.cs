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
    public partial class SiteIletisim : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KoleksiyonerEmail"] != null)
            {
                string kEmail = Session["KoleksiyonerEmail"].ToString();
                SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", baglan.baglan());
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert Into AdminMesaj (AdSoyad, mail, mesaj) Values ('"+TextBox1.Text+ "','" + TextBox2.Text + "','" + TextBox3.Text + "')", baglan.baglan());
            try
            {
                komut.ExecuteNonQuery();
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "İletildi", "<script>alert('Mesajınız Başarılı Bir Şekilde İletilmiştir');</script>");
            }
            catch
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata!!!", "<script>alert('Mesajınız İletilemedi');</script>");
            }

        }
    }
}