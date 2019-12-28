using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Model
{
    public class CoffeeDAO : DAO
    {
        public bool CheckDuplicate(string id)
        {
            try
            {
                Open();
                string sql = "Select coffeeId from tblCoffee where coffeeId=@coffeeId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coffeeId",id);
                reader = cmd.ExecuteReader();
                return reader.HasRows;
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

        public List<CoffeeDTO> GetCoffeeByName(string name)
        {
            List<CoffeeDTO> result = new List<CoffeeDTO>();
            try
            {
                Open();
                string sql = "Select coffeeId, name, description, typeId, price from tblCoffee where name like @name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@name", string.Format("%{0}%", name)));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string fullName = reader.GetString(1);
                        string description = reader.GetString(2);
                        int typeID = reader.GetInt32(3);
                        float price = (float) reader.GetDouble(4);

                        CoffeeTypeDAO dao = new CoffeeTypeDAO();
                        CoffeeTypeDTO type = dao.GetCofffeeTypeByID(typeID);

                        CoffeeDTO coffee = new CoffeeDTO
                        {
                            coffeeID = id,
                            name = fullName,
                            description = description,
                            price = price,
                            typeName = type.typeName
                        };
                        result.Add(coffee);
                    }
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

        public CoffeeDTO GetCoffeeByID(string id)
        {
            try
            {
                Open();
                string sql = "select name, description, typeId, price from tblCoffee where coffeeId=@coffeeId";
                cmd = new SqlCommand(sql, con);               
                cmd.Parameters.AddWithValue("@coffeeId", id);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader.GetString(0);
                    string description = reader.GetString(1);
                    int typeID = reader.GetInt32(2);
                    float price = float.Parse(reader["price"].ToString());
                    return new CoffeeDTO { coffeeID = id, name=name,description=description,type=typeID,price=price};
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
            return null;
        }

        public bool AddNewCoffee(CoffeeDTO coffee)
        {
            try
            {
                Open();
                string sql = "Insert tblCoffee values (@coffeeId,@name,@description,@typeId,@price)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coffeeId",coffee.coffeeID);
                cmd.Parameters.AddWithValue("@name", coffee.name);
                cmd.Parameters.AddWithValue("@description", coffee.description);
                cmd.Parameters.AddWithValue("@typeId", coffee.type);
                cmd.Parameters.AddWithValue("@price", coffee.price);
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

        public bool CheckDuplicateForUpdate(string id, string name)
        {
            try
            {
                Open();
                string sql = "Select name from tblCoffee where coffeeId!=@coffeeId and name=@name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coffeeId", id);
                cmd.Parameters.AddWithValue("@name", name);
                reader = cmd.ExecuteReader();
                return reader.HasRows;
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

        public bool UpdateCoffee(CoffeeDTO coffee)
        {
            try
            {
                Open();
                string sql = "Update tblCoffee set name=@name, description=@description," +
                    "typeId=@typeId, price=@price where coffeeId=@coffeeId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coffeeId", coffee.coffeeID);
                cmd.Parameters.AddWithValue("@name", coffee.name);
                cmd.Parameters.AddWithValue("@description", coffee.description);
                cmd.Parameters.AddWithValue("@typeId", coffee.type);
                cmd.Parameters.AddWithValue("@price", coffee.price);
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

        public bool DeleteCoffee(string id)
        {
            try
            {
                Open();
                string sql = "Delete tblCoffee where coffeeId=@coffeeId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@coffeeId", id);
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

        public DataTable GetCoffeeByType(int typeID)
        {
            try
            {
                Open();
                string sql = "Select coffeeId,name,description,price from tblCoffee where typeId=@typeId ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("typeId", typeID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
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
