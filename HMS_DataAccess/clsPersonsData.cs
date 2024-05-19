using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsPersonsData
    {

        public static int AddNew(string Name  , byte Gender, string Phone,
            int IDNumber, int CountryID)
        {
            int PersonID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"INSERT INTO People
                           (Name
                           ,Gender
                           ,Phone
                           ,IDNumber
                           ,CountryID)
                           VALUES
                           (@Name,@Gender ,@Phone
                            ,@IDNumber ,@CountryID)
                             SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("Name", Name);
                        Command.Parameters.AddWithValue("Gender", Gender);
                        Command.Parameters.AddWithValue("Phone", Phone);
                        Command.Parameters.AddWithValue("IDNumber", IDNumber);
                        Command.Parameters.AddWithValue("CountryID", CountryID);

                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                        {
                            PersonID = CoulmnInserted;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return PersonID;
        }

        public static bool Update(int PersonID, string Name, byte Gender,
            string Phone, int IDNumber, int CountryID)
        {
            int RowAffected = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE People
                               SET Name = @Name
                                  ,Gender = @Gender
                                  ,Phone = @Phone
                                  ,IDNumber = @IDNumber
                                  ,CountryID = @CountryID
                             WHERE PersonID = @PersonID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("PersonID", PersonID);
                        Command.Parameters.AddWithValue("Name", Name);
                        Command.Parameters.AddWithValue("Gender", Gender);
                        Command.Parameters.AddWithValue("Phone", Phone);
                        Command.Parameters.AddWithValue("IDNumber", IDNumber);
                        Command.Parameters.AddWithValue("CountryID", CountryID);

                        RowAffected = Command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (RowAffected > 0);
        }

        public static bool Delete(int PersonID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"Delete People
                                 WHERE PersonID = @PersonID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("PersonID", PersonID);

                        RowAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (RowAffected > 0);
        }    

        public static bool Find(int PersonID,ref string Name,ref byte Gender,
            ref string Phone, ref int IDNumber,ref int CountryID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  People WHERE PersonID = @PersonID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("PersonID", PersonID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    Name = (string)reader["Name"];
                                    Gender = (byte)reader["Gender"];
                                    IDNumber = (int)reader["IDNumber"];
                                    CountryID = (int)reader["CountryID"];
                                    Phone = (string)reader["Phone"];
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
                Console.WriteLine(ex.Message);
            }
            return isFound;

        }

    }
}
