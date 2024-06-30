using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public class Logger
        {
            public delegate void LogAction(string message);

            private LogAction _logAction;

            public Logger(LogAction logAction)
            {
                _logAction = logAction;
            }

            public void Log(string message)
            {
                _logAction(message);
            }
        }

        private static void WriteExceptionInLogFile(string Message)
        {
            string sourceName = "HotelsManagementsSystem";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
            EventLog.WriteEntry(sourceName, Message, EventLogEntryType.Error);
        }

        public static void WriteErrorInFile(string Message)
        {
            string FilePath = "log.txt";

            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(Message);
            }

        }

        public static class clsLog
        {


            public static Logger LogToEventViewer = new Logger(WriteExceptionInLogFile);

            public static Logger LogToFile = new Logger(WriteErrorInFile);

        }

    }
}
