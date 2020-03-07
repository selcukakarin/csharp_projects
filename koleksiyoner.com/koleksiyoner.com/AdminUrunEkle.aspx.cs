using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;


namespace koleksiyoner.com
{
    public partial class AdminUrunEkle : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminAdi"] != null)
            {
                //kategori çek
                SqlCommand cmd = new SqlCommand("Select * from Kategori", baglan.baglan());
                SqlDataReader dr = cmd.ExecuteReader();
                DropDownList1.DataTextField = "KategoriAdi";
                DropDownList1.DataValueField = "KategoriID";
                DropDownList1.DataSource = dr;
                DropDownList1.DataBind();

                //string AdminAdi = Session["AdminAdi"].ToString();
                //SqlCommand cmdSession = new SqlCommand("Select * from Admin where AdminAdi='" + AdminAdi + "'", baglan.baglan());
                //SqlDataReader drSession = cmdSession.ExecuteReader();
                //datalist.DataSource = drSession;
                //dtlist.DataBind();
            }
            else
            {
                Response.Redirect("AdminGiris.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pathName1 = "Images/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
            string pathName2 = "Images/" + Path.GetFileName(FileUpload2.PostedFile.FileName);
            SqlCommand komut = new SqlCommand("insert into Urun(UrunAdi,UrunFiyat,Aciklama,EklenmeTarihi,IhaleSuresi,KategoriAdi,ResimLogo,Resim1,Yayin,Ekleyen)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "','" + DateTime.Now.ToString("MM.dd.yyyy") + "','" + TextBox3.Text + "','" + DropDownList1.SelectedItem + "','" + pathName1 + "','" + pathName2 + "'," + 1 + ","+1+")", baglan.baglan());
            komut.ExecuteNonQuery();
            FileUpload1.SaveAs(Server.MapPath("Images/" + FileUpload1.FileName));
            FileUpload2.SaveAs(Server.MapPath("Images/" + FileUpload2.FileName));
        }
    }

}