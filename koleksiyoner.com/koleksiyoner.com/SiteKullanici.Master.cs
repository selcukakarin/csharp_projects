﻿using System;
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
    public partial class SiteKullanici : System.Web.UI.MasterPage
    {
        SQLBaglanti bag = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlCommand cmdSlider = new SqlCommand("Select Top 5 * from Urun where Yayin="+1+" order by UrunID desc", bag.baglan());
            SqlDataReader drSlider = cmdSlider.ExecuteReader();
            dlSlider.DataSource = drSlider;
            dlSlider.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("SiteAnasayfa.aspx");
        }
    }
}