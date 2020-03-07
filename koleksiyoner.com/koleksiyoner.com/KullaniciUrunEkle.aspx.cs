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

//ekrem ekiz

namespace koleksiyoner.com
{
    public partial class KullaniciUrunEkle : System.Web.UI.Page
    {
        SQLBaglanti baglan = new SQLBaglanti();
        SQLBaglanti baglan2 = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLBaglanti bag = new SQLBaglanti();
            if (!Page.IsPostBack)
            {
                if (Session["KoleksiyonerEmail"] != null)
                {
                    //kategori çek
                    SqlCommand cmd = new SqlCommand("Select * from Kategori", bag.baglan());
                    SqlDataReader dr = cmd.ExecuteReader();
                    DropDownListKategori.DataTextField = "KategoriAdi";
                    DropDownListKategori.DataValueField = "KategoriID";
                    DropDownListKategori.DataSource = dr;
                    DropDownListKategori.DataBind();

                    string kEmail = Session["KoleksiyonerEmail"].ToString();
                    SqlCommand cmdSession = new SqlCommand("Select * from Koleksiyoner where KoleksiyonerEmail='" + kEmail + "'", bag.baglan());
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
                //SqlCommand cmUrun = new SqlCommand("Select * from Urun WHERE UrunAdi LIKE '%'"+ txtUrunAdi.Text+ "' %' AND UrunAdi LIKE '%'" + txtFiyat.Text + "' %'AND UrunAdi LIKE '%'" + txtAciklama.Text + "' %'AND UrunAdi LIKE '%'" + txtIlanSuresi.Text + "' %'AND UrunAdi LIKE '%'" + DropDownListKategori.SelectedItem.Text + "' %'", baglan.baglan());
                //SqlDataReader drUrun = cmUrun.ExecuteReader();


                //if ((drUrun.Read() ) )
                //{
                //if (!(txtUrunAdi.Text == "" || txtFiyat.Text == "" || txtAciklama.Text == "" || txtIlanSuresi.Text == "" || DropDownListKategori.SelectedItem.Text == "para"))
                //{
                string pathName1 = "Images/" + Path.GetFileName(FileUploadResim1.PostedFile.FileName);
                string pathName2 = "Images/" + Path.GetFileName(FileUploadResim2.PostedFile.FileName);
                SqlCommand komut = new SqlCommand("insert into Urun(UrunAdi,UrunFiyat,Aciklama,EklenmeTarihi,IhaleSuresi,KategoriAdi,ResimLogo,Resim1,Yayin,Ekleyen)values('" + txtUrunAdi.Text + "','" + txtFiyat.Text + "','" + txtAciklama.Text + "','" + DateTime.Now.ToString("MM.dd.yyyy") + "','" + txtIlanSuresi.Text + "','" + DropDownListKategori.SelectedItem + "','" + pathName1 + "','" + pathName2 + "'," + 0 + "," + 0 + ")", baglan.baglan());
                komut.ExecuteNonQuery();
                FileUploadResim1.SaveAs(Server.MapPath("Images/" + FileUploadResim1.FileName));
                FileUploadResim2.SaveAs(Server.MapPath("Images/" + FileUploadResim2.FileName));

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('Lütfen herşeyi doldurun')", true);
                //}

                //}

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
