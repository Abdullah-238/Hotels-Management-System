using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public class clsDataAccessSettings
    {

            public static string ConnectionString 
            = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        /*"Server=.;DataBase=HotelsManagementSystem;User Id=sa;Password=sa123456";*/

    }
}
