using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_DataAccess
{
    public static  class clsGlobalDataAccess
    {
        public static void WriteExceptionInLogFile(Exception ex)
        {
            string sourceName = "HotelsManagementsSystem";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
            EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
        }


    }
}
