using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{

    public class DTORoomType
    {
        public int RoomTypeID { get; set; }

        public string RoomTypeName { get; set; }


        public DTORoomType(int roomTypeID, string roomTypeName)
        {
            this.RoomTypeID = roomTypeID;
            this.RoomTypeName = roomTypeName;
        }
    }

    public class clsRoomTypesData
    {
      
        public static List<DTORoomType> GetAllRoomsTypeDTO()
        {
            var AllRoomsType = new List<DTORoomType>();

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from RoomTypes";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AllRoomsType.Add(new DTORoomType
                                (
                                    reader.GetInt32(reader.GetOrdinal("RoomTypeID")),
                                    reader.GetString(reader.GetOrdinal("RoomTypeName"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return AllRoomsType;
        }


        public static int AddNew(string RoomTypeName)
        {
            int FloorID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"INSERT INTO RoomTypes
                           (RoomTypeName)
                           VALUES
                           (@RoomTypeName)
                             SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomTypeName", RoomTypeName);

                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                        {
                            FloorID = CoulmnInserted;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return FloorID;
        }
     
        public static bool Find (int RoomTypeID, ref string RoomTypeName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  RoomTypes WHERE RoomTypeID = @RoomTypeID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomTypeID", RoomTypeID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    RoomTypeName = (string)reader["RoomTypeName"];
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

        public static DataTable GetAllRoomTypes()
        {
            DataTable dtFloors = new DataTable();
            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from RoomTypes";

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

        public static bool Update(int RoomTypeID,  string RoomTypeName)
        {
            int RowAffected = -1;

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE RoomTypes
                               SET RoomTypeName = @RoomTypeName
                                   WHERE RoomTypeID = @RoomTypeID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomTypeID", RoomTypeID);
                        Command.Parameters.AddWithValue("RoomTypeName", RoomTypeName);


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

        public static bool Find(string RoomTypeName , ref int RoomTypeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"select * from  RoomTypes WHERE RoomTypeName = @RoomTypeName";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomTypeName", RoomTypeName);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    RoomTypeID = (int)reader["RoomTypeID"];
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
