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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        SQLBaglanti bag = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmdSlider = new SqlCommand("Select Top 5 * from Urun where Yayin=" + 1 + " order by UrunID desc", bag.baglan());
            SqlDataReader drSlider = cmdSlider.ExecuteReader();
            dlSlider.DataSource = drSlider;
            dlSlider.DataBind();

            SqlCommand cmUrun = new SqlCommand("Select * from Kategori", bag.baglan());
            SqlDataReader drUrun = cmUrun.ExecuteReader();
            DatalistKategori.DataSource = drUrun;
            DatalistKategori.DataBind();
        }

        
    }
}