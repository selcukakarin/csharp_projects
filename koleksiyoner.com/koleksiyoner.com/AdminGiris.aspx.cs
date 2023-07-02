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

    public partial class AdminGiris : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminAdi"] != null)
            {
                Response.Redirect("adminprofil.aspx");
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Admin where AdminAdi='" + TextBox1.Text + "' and AdminSifre='" + TextBox2.Text + "' ", baglan.baglan());
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Session.Add("AdminAdi", TextBox1.Text);
                Response.Redirect("AdminUrunEkle.aspx");
            }
            else
            {
                Label1.Text = "Kullanıcı Adı veya Şifre Hatalı";
            }
        }
    }
}
