using DVLD_Buisness;
using HMS_BusinessLogic;
using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public  class clsBookings
    {
        enum enMode { AddNewBookings, UpdateBookings };
        public int BookID { get; set; }
        public int RoomID { get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public byte BookType { get; set; }
        public decimal BookingPrice { get; set; }
        public int GuestID { get; set; }

        public int EmployeeID { get; set; }

        public clsRooms Room;

        public enStatus Status { get; set; }

        enMode _Mode = enMode.AddNewBookings;

        public clsGuests Guest;
        public enum enStatus { eNew =1 , eCancel =2 , eCompleted =3};

        public clsBookings()
        {
          
            this.BookID = -1;
            this.RoomID = -1;
            this.ArriveDate = DateTime.Now;
            this.DepartureDate = DateTime.Now;
            this.BookType = 1;
            this.Status = enStatus.eNew;
            this.BookingPrice = -1;
            this.GuestID = -1;

            _Mode = enMode.AddNewBookings;
        }

        clsBookings(int BookID, int RoomID, DateTime ArriveDate, DateTime DepartureDate,
            byte BookType, enStatus status, decimal BookingPrice, int gustID, int EmployeeID)
        {

            this.BookID = BookID;
            this.RoomID = RoomID;
            this.ArriveDate = ArriveDate;
            this.DepartureDate = DepartureDate;
            this.BookType = BookType;
            this.Status = status;
            this.BookingPrice = BookingPrice;
            this.GuestID = gustID;
            this.EmployeeID = EmployeeID;
            this.Guest = clsGuests.Find(gustID);
            this.Room = clsRooms.Find(RoomID);

            _Mode = enMode.UpdateBookings;
        }

        public static clsBookings Find(int BookID)
        {

            int RoomID = -1;
            DateTime ArriveDate = DateTime.Now;
            DateTime DepartureDate = DateTime.Now;
            byte BookType = 1;
            byte Status = 1;
            decimal BookingPrice = -1;
            int gustID = -1;
            int EmployeeID = -1;


            bool isFound = clsBookingData.Find( BookID, ref  RoomID, ref  ArriveDate, ref  DepartureDate,
           ref  BookType, ref  Status, ref  BookingPrice, ref  gustID, ref  EmployeeID);

            if (isFound)
            {
                return new clsBookings(BookID,  RoomID,  ArriveDate,  DepartureDate,
            BookType, (enStatus) Status,  BookingPrice,   gustID,  EmployeeID);
            }

            else
                return null;
        }

        public static clsBookings FindByRoom(int RoomID)
        {

            int  BookID = -1;
            DateTime ArriveDate = DateTime.Now;
            DateTime DepartureDate = DateTime.Now;
            byte BookType = 1;
            byte Status = 1;
            decimal BookingPrice = -1;
            int GustID = -1;
            int EmployeeID = -1;


            bool isFound = clsBookingData.FindByRoom(RoomID, ref BookID, ref ArriveDate,
                ref DepartureDate,
           ref BookType, ref Status, ref BookingPrice, ref GustID, ref EmployeeID);

            if (isFound)
            {
                return new clsBookings(BookID, RoomID, ArriveDate, DepartureDate,
            BookType, (enStatus)Status, BookingPrice, GustID, EmployeeID);
            }

            else
                return null;
        }

        private  bool AddNewBook()
        {
            this.BookID = clsBookingData.AddNew(RoomID, ArriveDate, DepartureDate,
            BookType, (byte)enStatus.eNew, BookingPrice, GuestID, EmployeeID);
        
            return BookID != -1;
        }
        
        private  bool UpdateBook()
        {
            return clsBookingData.Update(BookID, RoomID, ArriveDate, DepartureDate,
            BookType, (byte)Status, BookingPrice, GuestID, EmployeeID);
        }
       public bool Save()
        {
           
            switch (_Mode)
            {
                case enMode.AddNewBookings:
                    {
                        if (AddNewBook())
                        {
                            _Mode = enMode.UpdateBookings;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdateBookings:
                    return UpdateBook();
            }

            return false;
        }

        public static bool DeleteBook(int BookID)
        {
            return clsBookingData.Delete(BookID);
        }
       
        public static bool Cancel(int BookID)
        {
            return clsBookingData.Cancel(BookID);
        }
       
        public bool SignOut()
        {
            return clsBookingData.SignOut(RoomID);
        }
       
        public static DataTable GetAllBookings(short pageNumbr, short rowsByPage)
        {
            return clsBookingData.GetAllBookings(pageNumbr, rowsByPage);
        }

        public static List<BookingsDTO> GetAllBookings()
        {
            return clsBookingData.GetAllBookingsShort();
        }


   

}

