using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderCoffeeDetailDAO:DAO
    {
        public bool InsertToOrderDetail(int quantity, float price, String coffeeID, int orderID)
        {
            try
            {
                Open();
                string sql = "Insert tblOrderCoffeeDetail values (@orderId,@quantity,@coffeeId,@price)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@orderId", orderID);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@coffeeId", coffeeID);
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

        public Cart GetOrderDetail(int orderId)
        {
            Cart cart = new Cart();
            try
            {
                Open();
                string sql = "Select coffeeId, quantity from tblOrderCoffeeDetail where orderId=@orderId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string coffeeId = reader.GetString(0);
                    int quantity = reader.GetInt32(1);
                    cart.Put(coffeeId, quantity);
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
            return cart;
        }
    }
}

