using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace koleksiyoner.com
{
    public class SQLBaglanti
    {
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.; Initial Catalog=koleksiyoner; Integrated Security=True ");
            baglanti.Open();
            SqlConnection.ClearPool(baglanti);
            SqlConnection.ClearAllPools();

            return (baglanti);
        }
    }
}