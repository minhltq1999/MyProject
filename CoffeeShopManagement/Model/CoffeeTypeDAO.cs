using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Model
{
    public class CoffeeTypeDAO: DAO
    {
        public DataTable GetAllCoffeeType()
        {
            try
            {
                Open();
                string sql = "Select typeId, name from tblType";
                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
                DataTable data = new DataTable();
                adapter.Fill(data);
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
        
        public bool CheckDupplicate(string name)
        {
            try
            {
                Open();
                string sql = "Select name from tblType where name=@name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", name);
                reader = cmd.ExecuteReader();
                return reader.HasRows;
            }catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        public bool AddNewType(CoffeeTypeDTO type)
        {
            try
            {
                Open();
                string sql = "Insert tblType values (@name)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", type.typeName);
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

        public bool DeleteType(int id)
        {
            try
            {
                Open();
                string sql = "Delete tblType where typeId=@typeId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@typeId", id);
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

        public CoffeeTypeDTO GetCofffeeTypeByID(int id)
        {
            try
            {
                Open();
                string sql = "Select name from tblType where typeID=@typeID";
                this.cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@typeID", id);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = reader.GetString(0);
                    return new CoffeeTypeDTO { typeID = id, typeName = name };                        
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return null;
        }

        public bool CheckDupplicateForUpdate(string name, int id)
        {
            try
            {
                Open();
                string sql = "Select name from tblType where name=@name and typeId!=@typeId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@typeId", id);
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

        public bool UpdateType(CoffeeTypeDTO type)
        {
            try
            {
                Open();
                string sql = "Update tblType set name=@name where typeId=@typeId";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", type.typeName);
                cmd.Parameters.AddWithValue("@typeId", type.typeID);
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

        public DataTable GetCoffeeTypeByName(string name)
        {
            try
            {
                Open();
                string sql = "Select typeId, name from tblType where name like @name";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@name",string.Format("%{0}%", name)));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch(SqlException ex)
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
