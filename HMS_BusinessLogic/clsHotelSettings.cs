using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsHotelSettings
    {

        public byte ArriveTime { get; set; }

        public byte DepartureTime { get; set; }

        public string HotelName { get; set; }

        public string ImagePath { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }



        clsHotelSettings(string HotelName ,byte ArriveTime,
                        byte DepartureTime , string ImagePath,string Address ,string Phone)
        {
            this.ArriveTime = ArriveTime;
            this.DepartureTime = DepartureTime;
            this.HotelName = HotelName;
            this.ImagePath = ImagePath;
            this.Address = Address;
            this.Phone = Phone;

        }

        public static clsHotelSettings Find()
        {
            byte ArriveTime    =1 ;
            byte DepartureTime =1 ;
            string HotelName   ="" ;
            string ImagePath   ="" ;
            string Address     ="" ;
            string Phone = "";

            bool isFound = clsHotelSettingsData.Find(ref  HotelName, ref ArriveTime,
                ref DepartureTime,ref ImagePath , ref Address , ref Phone);

            if (isFound)
                return new clsHotelSettings(HotelName, ArriveTime,  DepartureTime , ImagePath,  Address,  Phone);
            else
                return null;
        }

        public static bool Update(string HotelName , byte arriveTime , byte departureTime, string ImagePath, string Address, string Phone)
        {
            return clsHotelSettingsData.Update(HotelName,arriveTime, departureTime, ImagePath, Address, Phone);
        }

        public static bool AddNew(string hotelName, byte arriveTime, byte departureTime,
            string ImagePath, string Address, string Phone)
        {
            return clsHotelSettingsData.AddNew(hotelName, arriveTime, departureTime,
                ImagePath, Address, Phone);
        }

    }
}
