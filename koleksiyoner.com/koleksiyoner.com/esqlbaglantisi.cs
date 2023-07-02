using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace koleksiyoner.com
{
    public class esqlbaglantisi
    {
        //koleksiyoner.com
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.; Initial Catalog=koleksiyoner; Integrated Security=true;");
            baglanti.Open();
            SqlConnection.ClearAllPools();
            SqlConnection.ClearPool(baglanti);
            return (baglanti);
            
        }
    }
}