using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsCurrencies
    {
        public string Code { get; set; }

        public double Rate { get; set; }

     
        public clsCurrencies(string code , double rate)
        {
            this.Code = code;

            this.Rate = rate;

        }
        public static clsCurrencies Find(string Code)
        {       
            double rate = -1;

            bool isFound = clsCurrenciesData.Find(Code,ref rate);

            if (isFound)
                return new clsCurrencies(Code, rate);
            else
                return null;
        }

        public static DataTable GetAllCurrencies()
        {
            return clsCurrenciesData.GetAllCurrencies();
        }
    }
}
