using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Model
{
    public class DAO
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader reader;

        protected void Open()
        {
            con = Connection.MakeConnection();
            con.Open();
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        protected void Close()
        {
            if (reader != null)
            {
                reader.Close();
            }
            if (con != null)
            {
                con.Close();
            }
        }
    }
}
