using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsStatistic
    {
        public static DataTable GetAllStatistic()
        {
            return clsStatisticData.GetAllStatistic();
        }


    }
}
