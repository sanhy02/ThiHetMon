using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLBanSach.Models
{
    public class ChuDeDAO : DataProvider
    {
        public List<ChuDe> getAll()
        {
            List<ChuDe> ds = new List<ChuDe>();
            SqlConnection conn = getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from chude", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ds.Add(new ChuDe { MaCD = int.Parse(rd["macd"].ToString()), TenCD = rd["tencd"].ToString() });
            }
            return ds;            
            
        }
    }
}