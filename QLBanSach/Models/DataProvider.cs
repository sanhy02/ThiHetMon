using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLBanSach.Models
{
    public class DataProvider
    {
        public SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString);
            return conn;
        }
    }
}