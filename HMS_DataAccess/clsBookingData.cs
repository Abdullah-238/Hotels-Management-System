using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Data.SqlClient;


namespace HMS_DataAccess
{
    public class BookingsDTO
    {
        public int BookID { get; set; }
        public int RoomID { get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public BookingsDTO(int bookID, int roomID, DateTime arriveDate, DateTime departureDate)
        {
            BookID = bookID;
            RoomID = roomID;
            ArriveDate = arriveDate;
            DepartureDate = departureDate;
        }
    }


    public class clsBookingData
    {

        public static List<BookingsDTO> GetAllBookingsShort()
        {
            var studentList = new List<BookingsDTO>();

            try
            {

                using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetAllBookings", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                studentList.Add(new BookingsDTO
                                (
                                   reader.GetInt32(reader.GetOrdinal("BookID")),
                                    reader.GetInt32(reader.GetOrdinal("RoomID")),
                                    reader.GetDateTime(reader.GetOrdinal("ArriveDate")),
                                    reader.GetDateTime(reader.GetOrdinal("DepartureDate"))
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
            return studentList;
        }


        public static DataTable GetAllBookings(short pageNumbr , short rowsByPage)
        {
            DataTable dtUsers = new DataTable();
            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"exec SP_GetPageByNumber 
                                    @PageNumbr = @pageNumbr,
                                    @RowsByPage = @rowsByPage";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("pageNumbr", pageNumbr);
                        Command.Parameters.AddWithValue("rowsByPage", rowsByPage);

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
                Console.WriteLine(ex.Message);
            }
            return dtUsers;
        }

        public static int AddNew(int RoomID, DateTime ArriveDate,DateTime DepartureDate ,
            byte BookType , byte Status , decimal BookingPrice , int GuestID , int EmployeeID)
        {
            int BookID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"INSERT INTO Bookings
                           (RoomID
                           ,ArriveDate
                           ,DepartureDate
                           ,BookType
                           ,Status
                           ,BookingPrice
                           ,GuestID
                           ,EmployeeID)
                           VALUES
                           (@RoomID
                           ,@ArriveDate
                           ,@DepartureDate
                           ,@BookType
                           ,@Status
                           ,@BookingPrice
                           ,@GuestID
                           ,@EmployeeID);
                             SELECT SCOPE_IDENTITY();";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomID", RoomID);
                        Command.Parameters.AddWithValue("ArriveDate", ArriveDate);
                        Command.Parameters.AddWithValue("DepartureDate", DepartureDate);
                        Command.Parameters.AddWithValue("BookType", BookType);
                        Command.Parameters.AddWithValue("Status", Status);
                        Command.Parameters.AddWithValue("BookingPrice", BookingPrice);
                        Command.Parameters.AddWithValue("GuestID", GuestID);
                        Command.Parameters.AddWithValue("EmployeeID", EmployeeID);


                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CoulmnInserted))
                        {
                            BookID = CoulmnInserted;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }

            return BookID;
        }

        public static bool Update(int BookID , int RoomID, DateTime ArriveDate, DateTime DepartureDate,
            byte BookType, byte Status, decimal BookingPrice, int GuestID, int EmployeeID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"UPDATE Bookings
                               SET RoomID = @RoomID
                                  ,ArriveDate = @ArriveDate
                                  ,DepartureDate = @DepartureDate
                                  ,BookType = @BookType
                                  ,Status = @Status
                                  ,BookingPrice = @BookingPrice
                                  ,GuestID = @GuestID
                                  ,EmployeeID = @EmployeeID
                             WHERE BookID = @BookID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("BookID", BookID);
                        Command.Parameters.AddWithValue("RoomID", RoomID);
                        Command.Parameters.AddWithValue("ArriveDate", ArriveDate);
                        Command.Parameters.AddWithValue("DepartureDate", DepartureDate);
                        Command.Parameters.AddWithValue("BookType", BookType);
                        Command.Parameters.AddWithValue("Status", Status);
                        Command.Parameters.AddWithValue("BookingPrice", BookingPrice);
                        Command.Parameters.AddWithValue("GuestID", GuestID);
                        Command.Parameters.AddWithValue("EmployeeID", EmployeeID);


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

        public static bool Delete(int BookID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"Delete Bookings
                                 WHERE BookID = @BookID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("BookID", BookID);

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

        public static bool Find(int BookID, ref int RoomID, ref DateTime ArriveDate, ref DateTime DepartureDate,
           ref byte BookType, ref byte Status, ref decimal BookingPrice, ref int GuestID,ref int EmployeeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"select * from Bookings WHERE BookID  = @BookID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("BookID", BookID);

                        Connection.Open();

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    RoomID = (int)reader["RoomID"];
                                    ArriveDate = (DateTime)reader["ArriveDate"];
                                    DepartureDate = (DateTime)reader["DepartureDate"];
                                    BookType = (byte)reader["BookType"];
                                    Status = (byte)reader["Status"];
                                    BookingPrice = (decimal)reader["BookingPrice"];
                                    GuestID = (int)reader["GuestID"];
                                    EmployeeID = (int)reader["EmployeeID"];


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

        public static bool FindByRoom( int RoomID,ref int BookID, ref DateTime ArriveDate, ref DateTime DepartureDate,
           ref byte BookType, ref byte Status, ref decimal BookingPrice, ref int GuestID, ref int EmployeeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"select * from Bookings WHERE RoomID  = @RoomID";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {

                        Command.Parameters.AddWithValue("RoomID", RoomID);

                        Connection.Open();

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    isFound = true;
                                    BookID = (int)reader["BookID"];
                                    ArriveDate = (DateTime)reader["ArriveDate"];
                                    DepartureDate = (DateTime)reader["DepartureDate"];
                                    BookType = (byte)reader["BookType"];
                                    Status = (byte)reader["Status"];
                                    BookingPrice = (decimal)reader["BookingPrice"];
                                    GuestID = (int)reader["GuestID"];
                                    EmployeeID = (int)reader["EmployeeID"];


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

        public static bool Cancel(int BookID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"Update Bookings
                                     set Status = 2
                                 WHERE BookID = @BookID";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("BookID", BookID);

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

        public static bool SignOut(int RoomID)
        {
            int RowAffected = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string query = @"Update Bookings
                                     set Status = 3
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

    }
}
