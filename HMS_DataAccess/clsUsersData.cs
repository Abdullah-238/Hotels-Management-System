using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static HMS_DataAccess.clsGlobalDataAccess;

namespace HMS_DataAccess
{
    public class clsUsersData
    {
        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();
            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select UserID ,Name, UserName   , CountryName ,Gender = 
                                    case 
                                    when Gender = 1 then 'Male' 
                                    ELSE 'Female' 
                                    end , isActive from users
                                    join People on People.PersonID = users.PersonID   
                                    join Countries on Countries.CountryID = People.CountryID ";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                dtUsers.Load(reader);
                            else
                                Console.WriteLine("Thers is no rows");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }
            return dtUsers;
        }

        public static int AddNew(string UserName, string Password, bool IsActive, int PersonID)
        {
            int userID = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"INSERT INTO Users
                           (UserName
                           ,Password
                           ,IsActive
                           ,PersonID)
                           VALUES
                           (@UserName,@Password,@IsActive,@PersonID);
                             SELECT SCOPE_IDENTITY();";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("UserName", UserName);
                        Command.Parameters.AddWithValue("Password", Password);
                        Command.Parameters.AddWithValue("IsActive", IsActive);
                        Command.Parameters.AddWithValue("PersonID", PersonID);

                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                        {
                            userID = CoulmnInserted;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }

            return userID;
        }

        public static bool Update(int UserID, string UserName, string Password, bool IsActive, int PersonID)
        {
            int RowAffected = -1;


            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE Users
                               SET UserName = @UserName
                                  ,Password = @Password
                                  ,IsActive = @IsActive
                                  ,PersonID = @PersonID
                             WHERE UserID = @UserID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("PersonID", PersonID);
                        Command.Parameters.AddWithValue("UserName", UserName);
                        Command.Parameters.AddWithValue("Password", Password);
                        Command.Parameters.AddWithValue("IsActive", IsActive);
                        Command.Parameters.AddWithValue("UserID", UserID);

                        RowAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }

            return (RowAffected > 0);
        }

        public static bool Delete(int UserID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"Delete Users
                                 WHERE UserID = @UserID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("UserID", UserID);

                        RowAffected = Command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }

            return (RowAffected > 0);
        }

        public static bool Find(int UserID, ref string UserName, ref
            string Password, ref bool IsActive, ref int PersonID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"select * from Users WhERE UserID  = @UserID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("UserID", UserID);

                        Connection.Open();

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    UserName = (string)reader["UserName"];
                                    Password = (string)reader["Password"];
                                    IsActive = (bool)reader["IsActive"];
                                    PersonID = (int)reader["PersonID"];

                                }
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }
            return isFound;
        }

        public static bool FindByUserName(string UserName, ref int UserID, ref
            string Password, ref bool IsActive, ref int PersonID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users WHERE UserName  = @UserName";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("UserName", UserName);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    PersonID = (int)reader["PersonID"];

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;

        }

        public static bool FindByUserNameAndPassword(string UserName, string Password, ref int UserID
         , ref bool IsActive, ref int PersonID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users WHERE UserName  = @UserName and Password = @Password";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);


            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    IsActive = (bool)reader["IsActive"];
                    PersonID = (int)reader["PersonID"];

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                clsLog.LogToEventViewer.Log(ex.Message);
                clsLog.LogToFile.Log(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;

        }

        public static bool IsUserFoundByUserNameAndPassword(string UserName, string Password)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users
                             WHERE UserName = @UserName and Password = @Password";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = true;
                }

            }
            catch (Exception ex)
            {
                clsLog.LogToEventViewer.Log(ex.Message);
                clsLog.LogToFile.Log(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool IsUserFoundByUserName(string UserName)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users
                             WHERE UserName = @UserName";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("UserName", UserName);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    isFound = true;
                }

            }
            catch (Exception ex)
            {
                clsLog.LogToEventViewer.Log(ex.Message);
                clsLog.LogToFile.Log(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }


    }
}
