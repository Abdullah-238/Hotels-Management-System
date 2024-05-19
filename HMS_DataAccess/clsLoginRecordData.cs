using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsLoginRecordData
    {
       public static bool AddNewUserLoginRecord (int UserID , string UserName)
        {
            int RowAffected =  0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string Query = @"insert into LoginUsersRecords (UserID , UserName) 
                                values (@UserID , @UserName); 
                                 SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("UserID", UserID);
                        command.Parameters.AddWithValue("UserName", UserName);


                        RowAffected = command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                clsGlobalDataAccess.WriteExceptionInLogFile(ex);
            }

            return (RowAffected > 0);

        }

    }
}
