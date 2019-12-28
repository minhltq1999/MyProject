using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Model
{
    public class UserDetailDAO : DAO
    {
        /// <summary>
        /// Check login
        /// </summary>
        /// <param name="Username">string</param>
        /// <param name="Password">string</param>
        /// <returns>UserDetailDTO</returns>
        public UserDetailDTO CheckLogin(string Username, string Password)
        {
            try
            {
                Open();
                string sql = "select role, fullName, phone, email, address, userID, username from tblUserDetail where username=@username and password=@password";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int role = reader.GetInt32(0);
                    string fullName = reader.GetString(1);
                    string phone = reader.GetString(2);
                    string email = reader.GetString(3);
                    string address = reader.GetString(4);
                    int userID = reader.GetInt32(5);
                    string username = reader.GetString(6);
                    UserDetailDTO user = new UserDetailDTO { username = username, fullName = fullName, role = role, phone=phone,email=email,address=address,userID=userID };
                    return user;
                }
            }catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
            return null;
        }

        public bool AddNewUser(UserDetailDTO user)
        {
            try
            {
                Open();
                string sql = "Insert tblUserDetail values (@username,@password,@fullName,@phone,@email,@address,@role)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@fullName", user.fullName);
                cmd.Parameters.AddWithValue("@phone", user.phone);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@role", 3);
                int count = cmd.ExecuteNonQuery();                
                return count > 0;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        public bool CheckDuplicate(string username)
        {
            try
            {
                Open();
                string sql = "Select username from tblUserDetail where username=@username";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username",username);
                reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        public UserDetailDTO GetUserByID(int id)
        {
            try
            {
                Open();
                string select = "select username, password, fullName, phone, email, address from tblUserDetail where userId=@userID";
                cmd = new SqlCommand(select, con);
                cmd.Parameters.AddWithValue("@userId", id);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string userName = reader.GetString(0);
                    string password = reader.GetString(1);
                    string fullName = reader.GetString(2);
                    string phone = reader.GetString(3);
                    string email = reader.GetString(4);
                    string address = reader.GetString(5);
                    UserDetailDTO user = new UserDetailDTO { fullName = fullName, phone = phone, email = email, address = address, username = userName, password= password, userID=id };
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                Close();
            }
            return null;
        }
    }
}
