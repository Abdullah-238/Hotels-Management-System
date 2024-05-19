using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsLoginRecord
    {

        public int UserID { get; set; }
        public string UserName { get; set; }

        public clsLoginRecord()
        {
            this.UserID = -1;
            this.UserName = null;  
        }

        public static bool AddNew(int UserID,string UserName)
        {
            return clsLoginRecordData.AddNewUserLoginRecord(UserID, UserName);
        }

    }
}
