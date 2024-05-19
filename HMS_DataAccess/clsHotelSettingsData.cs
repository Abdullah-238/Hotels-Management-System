using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsHotelSettingsData
    {

        public static bool Update(string HotelName, byte ArriveTime,
            byte? DepartureTime , string ImagePath ,string  Address , string Phone )
        {
            int RowAffected = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE HotelSettings
                               SET ArriveTime = @ArriveTime
                                  , HotelName = @HotelName
                                  , ImagePath = @ImagePath
                                  , Address = @Address
                                  , Phone = @Phone
                                  ,DepartureTime = @DepartureTime";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("ArriveTime", ArriveTime);
                        Command.Parameters.AddWithValue("DepartureTime", DepartureTime);
                        Command.Parameters.AddWithValue("HotelName", HotelName);
                        Command.Parameters.AddWithValue("Address", Address);
                        Command.Parameters.AddWithValue("Phone", Phone);

                        if (ImagePath == "")
                            Command.Parameters.AddWithValue("ImagePath", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("ImagePath", ImagePath);



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

        public static bool Find(ref string HotelName , ref byte ArriveTime,ref byte DepartureTime
                                ,ref string ImagePath, ref string Address, ref string Phone)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  HotelSettings ";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("ArriveTime", ArriveTime);
                        Command.Parameters.AddWithValue("DepartureTime", DepartureTime);
                        Command.Parameters.AddWithValue("HotelName", HotelName);
                        Command.Parameters.AddWithValue("ImagePath", ImagePath);
                        Command.Parameters.AddWithValue("Address", Address);
                        Command.Parameters.AddWithValue("Phone", Phone);


                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    ArriveTime = (byte)reader["ArriveTime"];
                                    DepartureTime = (byte)reader["DepartureTime"];
                                    HotelName = (string)reader["HotelName"];
                                    Address = (string)reader["Address"];
                                    Phone = (string)reader["Phone"];

                                    if ((string)reader["ImagePath"] != null)
                                        ImagePath = (string)reader["ImagePath"];
                                    else
                                        ImagePath = ""; 

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

        public static bool AddNew(string HotelName, byte ArriveTime,
            byte DepartureTime, string ImagePath, string Address, string Phone)
        {
            int RowAffected = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"INSERT INTO HotelSettings
                                  (HotelName, ArriveTime ,DepartureTime,ImagePath,Address,Phone)
                                  VALUES
                                  (@HotelName , @ArriveTime , @DepartureTime,@ImagePath,@Address,@Phone);";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("ArriveTime", ArriveTime);
                        Command.Parameters.AddWithValue("DepartureTime", DepartureTime);
                        Command.Parameters.AddWithValue("HotelName", HotelName);
                        Command.Parameters.AddWithValue("Address", Address);
                        Command.Parameters.AddWithValue("Phone", Phone);

                        if (ImagePath == "")
                            Command.Parameters.AddWithValue("ImagePath", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("ImagePath", ImagePath);

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

    }
}
