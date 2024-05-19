using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsRoomsData
    {

        public static int AddNew(string RoomName , int RoomTypeID, decimal RoomPrice , bool IsAvailable , int FloorID
                                 , byte Persons ,byte Beds )
        {
            int RoomID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"INSERT INTO Rooms
                           (RoomName
                           ,RoomTypeID
                           ,RoomPrice
                           ,IsAvailable
                           ,FloorID
                           ,Persons
                           ,Beds)
                           VALUES
                           (@RoomName
                           ,@RoomTypeID
                           ,@RoomPrice
                           ,@IsAvailable
                           ,@FloorID
                           ,@Persons
                           ,@Beds);
                           SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomName", RoomName);
                        Command.Parameters.AddWithValue("RoomTypeID", RoomTypeID);
                        Command.Parameters.AddWithValue("RoomPrice", RoomPrice);
                        Command.Parameters.AddWithValue("IsAvailable", IsAvailable);
                        Command.Parameters.AddWithValue("FloorID", FloorID);
                        Command.Parameters.AddWithValue("Persons", Persons);
                        Command.Parameters.AddWithValue("Beds", Beds);


                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                        {
                            RoomID = CoulmnInserted;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return RoomID;
        }
        public static bool Update(int RoomID ,string RoomName, int RoomTypeID , decimal RoomPrice, 
                                   bool IsAvailable, int FloorID , byte Persons, byte Beds)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE Rooms
                               SET RoomTypeID = @RoomTypeID
                                  ,RoomName = @RoomName
                                  ,RoomPrice = @RoomPrice 
                                  , IsAvailable = @IsAvailable
                                  , FloorID = @FloorID
                                  , Persons = @Persons
                                  , Beds = @Beds
                                   WHERE RoomID = @RoomID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("RoomID", RoomID);
                        Command.Parameters.AddWithValue("RoomName", RoomName);
                        Command.Parameters.AddWithValue("RoomTypeID", RoomTypeID);
                        Command.Parameters.AddWithValue("RoomPrice", RoomPrice);
                        Command.Parameters.AddWithValue("IsAvailable", IsAvailable);
                        Command.Parameters.AddWithValue("FloorID", FloorID);
                        Command.Parameters.AddWithValue("Persons", Persons);
                        Command.Parameters.AddWithValue("Beds", Beds);

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
        public static bool Delete(int RoomID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"Delete Rooms
                                 WHERE RoomID = @RoomID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomID", RoomID);

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

        public static bool Find( int RoomID ,ref string RoomName,  ref int RoomTypeID, ref decimal RoomPrice,
                                ref bool IsAvailable, ref int FloorID, ref byte Persons, ref byte Beds)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  Rooms WHERE RoomID = @RoomID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomID", RoomID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    RoomTypeID = (int)reader["RoomTypeID"];
                                    RoomName = (string)reader["RoomName"];
                                    RoomPrice = (decimal)reader["RoomPrice"];
                                    IsAvailable = (bool)reader["IsAvailable"];
                                    FloorID = (int)reader["FloorID"];
                                    Persons = (byte)reader["Persons"];
                                    Beds = (byte)reader["Beds"];
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
        public static DataTable GetAllRooms()
        {
            DataTable dtFloors = new DataTable();
            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from Rooms";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                dtFloors.Load(reader);
                            else
                                Console.WriteLine("Thers is no rows");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dtFloors;
        }

        public static int GetAllAvalibaleRooms()
        {
            int NumbersOfAvalibaleRooms = 0; 

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select count(roomId) from rooms  where isAvailable = 1 ;";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                            object result = Command.ExecuteScalar();

                            if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                            {
                                NumbersOfAvalibaleRooms = CoulmnInserted;
                            }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return NumbersOfAvalibaleRooms;
        }

        public static bool IsRoomExsist( string RoomName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  Rooms WHERE RoomName = @RoomName";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomName", RoomName);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                    isFound = true;
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

        public static bool IsRoomExsist(int RoomID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  Rooms WHERE RoomID = @RoomID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomID", RoomID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isFound = true;
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

        public static bool IsRoomAvalibale(int RoomID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select found =1 from rooms  where isAvailable = 1 and roomid = @RoomID;";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomID", RoomID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                isFound = true;
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

        public static int GetNumbersOfRooms()
        {
            int NumbersRooms = 0;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select count(*) from	Rooms ;";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                        {
                            NumbersRooms = CoulmnInserted;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return NumbersRooms;
        }

        public static bool SetRoomUnAvailable(int RoomID)
        {
            int RowAffected = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE Rooms
                               SET IsAvailable = 0
                                   WHERE RoomID = @RoomID;";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("RoomID", RoomID);

                        RowAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (RowAffected >0) ;
        }

        public static bool SetRoomAvailable(int RoomID)
        {
            int RowAffected = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE Rooms
                               SET IsAvailable = 1
                                   WHERE RoomID = @RoomID;";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("RoomID", RoomID);

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





        //public static int GetAllAvalibaleRoomsToday()
        //{
        //    int NumbersOfAvalibaleRooms = 0;

        //    try
        //    {

        //        using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //        {
        //            Connection.Open();

        //            string query = @"select count(roomId) from rooms  where isAvailable = 1 ;";

        //            using (SqlCommand Command = new SqlCommand(query, Connection))
        //            {

        //                object result = Command.ExecuteScalar();

        //                if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
        //                {
        //                    NumbersOfAvalibaleRooms = CoulmnInserted;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return NumbersOfAvalibaleRooms;
        //}


    }
}
