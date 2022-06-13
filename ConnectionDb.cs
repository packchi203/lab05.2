using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._2
{
    internal class ConnectionDb
    {
        public SqlConnection GetConnection()
        {

            string connectionString = "Data source = localhost;Initial Catalog=;User=;password=";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
