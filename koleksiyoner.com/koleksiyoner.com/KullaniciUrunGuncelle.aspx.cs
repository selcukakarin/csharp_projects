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
    public partial class KullaniciUrunGuncelle : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        string UrunID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UrunID = Request.QueryString["UrunID"];
            if (Page.IsPostBack == false)
            {
                if (Session["KoleksiyonerEmail"] != null)
                {
                    //kategori çek
                    SqlCommand cmd = new SqlCommand("Select * from Kategori ", baglan.baglan());
                    SqlDataReader dr = cmd.ExecuteReader();
                    DropDownListKategori.DataTextField = "KategoriAdi";
                    DropDownListKategori.DataValueField = "KategoriID";
                    DropDownListKategori.DataSource = dr;
                    DropDownListKategori.DataBind();

                    SqlCommand cmdUrunGetir = new SqlCommand("Select * from Urun where UrunID='" + UrunID + "'",baglan.baglan());
                    SqlDataReader druGuncelle = cmdUrunGetir.ExecuteReader();

                    DataTable dtuGuncelle = new DataTable("tablo");
                    dtuGuncelle.Load(druGuncelle);
                    DataRow row = dtuGuncelle.Rows[0];
                    txtUrunAdi.Text = row["UrunAdi"].ToString();
                    txtFiyat.Text = row["UrunFiyat"].ToString();
                    txtAciklama.Text = row["Aciklama"].ToString();
                    txtIlanSuresi.Text = row["IhaleSuresi"].ToString();
                    DropDownListKategori.SelectedItem.Text = row["KategoriAdi"].ToString();

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
            if (FileUploadResim1.HasFile && FileUploadResim2.HasFile)
            {
                string pathName1 = "Images/" + Path.GetFileName(FileUploadResim1.PostedFile.FileName);
                string pathName2 = "Images/" + Path.GetFileName(FileUploadResim2.PostedFile.FileName);
                SqlCommand cmd = new SqlCommand("Update Urun set UrunAdi='" + txtUrunAdi.Text + "',UrunFiyat='" + txtFiyat.Text + "',Aciklama='" + txtAciklama.Text + "',EklenmeTarihi='" + DateTime.Now.ToString("MM.dd.yyyy ") + "',IhaleSuresi='" + txtIlanSuresi.Text + "',KategoriAdi='" + DropDownListKategori.SelectedItem.Text + "',ResimLogo='" + pathName1 + "',Resim1='" + pathName2 + "' where UrunID='" + UrunID + "'", baglan.baglan());
                FileUploadResim1.SaveAs(Server.MapPath("images/" + FileUploadResim1.FileName));
                FileUploadResim2.SaveAs(Server.MapPath("images/" + FileUploadResim2.FileName));
                cmd.ExecuteNonQuery();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Resimler Boş geçilemez')", true);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}