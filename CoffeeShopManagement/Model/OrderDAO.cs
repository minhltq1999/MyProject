using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDAO : DAO
    {
        public bool InsertToOrder(int userID, float total, String time)
        {
            try
            {
                Open();
                string sql = "Insert tblOrder values (@userID,@time,@total)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@total", total);
                int count = cmd.ExecuteNonQuery();
                return count > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        public int GetOrderID(string time, int userID)
        {
            try
            {
                Open();
                string sql = "SELECT orderId FROM tblOrder WHERE time=@time AND userId=@userID";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@userID", userID);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return -1;
        }

        public List<OrderDTO>  GetAllOrder()
        {
            List<OrderDTO> result = new List<OrderDTO>();
            try
            {
                Open();
                string sql = "Select orderId, userId, time, total from tblOrder";
                cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int orderid = reader.GetInt32(0);
                    int userid = reader.GetInt32(1);
                    UserDetailDAO userDAO = new UserDetailDAO();
                    UserDetailDTO user = userDAO.GetUserByID(userid);
                    DateTime time = reader.GetDateTime(2);
                    float total = (float)reader.GetDouble(3);
                    result.Add(new OrderDTO {OrderID=orderid,User=user,Time=time,Total= total});
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return result ;
        }

        public List<OrderDTO> GetAllOrderByDate(DateTime time1, DateTime time2)
        {
            List<OrderDTO> result = new List<OrderDTO>();
            try
            {
                Open();
                string sql = "Select orderId, userId, time, total from tblOrder where time between @time1 and @time2";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@time1", time1);
                cmd.Parameters.AddWithValue("@time2", time2);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int orderid = reader.GetInt32(0);
                    int userid = reader.GetInt32(1);
                    UserDetailDAO userDAO = new UserDetailDAO();
                    UserDetailDTO user = userDAO.GetUserByID(userid);
                    DateTime time = reader.GetDateTime(2);
                    float total = (float)reader.GetDouble(3);
                    result.Add(new OrderDTO { OrderID = orderid, User = user, Time = time, Total = total });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
            return result;
        }

        public List<OrderDTO> GetOrderByUserID(int userID)
        {
            try
            {
                List<OrderDTO> data = new List<OrderDTO>();
                Open();
                string sql = "SELECT orderId,time,total FROM tblOrder WHERE userId=@userID";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderDTO dto = new OrderDTO 
                    { 
                        OrderID = reader.GetInt32(0), 
                        Time = reader.GetDateTime(1), 
                        Total = float.Parse(reader.GetDouble(2).ToString()) 
                    };
                    data.Add(dto);
                }
                return data;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }

        }
    }
}
