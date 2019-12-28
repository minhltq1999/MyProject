using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Model
{
    public class Connection
    {
        public static SqlConnection MakeConnection()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Coffee_Management;User ID=sa; Password=Quangminh1999";
            return new SqlConnection(connectionString);
        }

    }
}
