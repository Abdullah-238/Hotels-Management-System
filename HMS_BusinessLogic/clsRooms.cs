using DVLD_Buisness;
using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsRooms
    {
       
        public enum enMode { AddNewRoom, UpdateRoom };

        public int RoomID { get; set; }

        public int RoomTypeID { get; set; }

        public string RoomName { get; set; }

        public decimal RoomPrice { get; set; }
        public bool IsAvailable { get; set; }

        public int FloorID { get; set; }

        public byte Persons { get; set; }

        public byte Beds { get; set; }

        public clsRoomTypes RoomTypes;

        public clsFloors Floor;

        public enMode Mode = enMode.AddNewRoom;


        public clsRooms()
        {

            this.RoomID = -1;
            this.RoomName = "";
            this.RoomTypeID = -1;
            this.RoomPrice = -1;
            this.IsAvailable = false;
            this.FloorID = -1;
            this.Persons = 1;
            this.Beds = 1;

            Mode = enMode.AddNewRoom;
        }

        clsRooms(int roomID,string roomName , int roomTypeID, decimal RoomPrice,
            bool IsAvailable, int floorID, byte persons,byte beds)
        {
            this.RoomID = roomID;
            this.RoomName = roomName;
            this.RoomTypeID = roomTypeID;
            this.RoomPrice = RoomPrice;
            this.IsAvailable = IsAvailable;
            this.FloorID = floorID;
            this.Persons = persons;
            this.Beds = beds;

            this.RoomTypes = clsRoomTypes.Find(roomTypeID);
            this.Floor = clsFloors.Find(FloorID);    

            Mode = enMode.UpdateRoom;
        }

        public static clsRooms Find(int RoomID)
        {
            string roomName = "";
            int RoomTypeID = -1;
            decimal RoomPrice = -1;
            bool IsAvailable = false;
            int floorID = -1;
            byte Persons = 1;
            byte Beds = 1;

            bool isFound = clsRoomsData.Find(RoomID,ref roomName, ref RoomTypeID, ref RoomPrice,ref IsAvailable,
                ref floorID, ref Persons, ref Beds);

            if (isFound)
                return new clsRooms(RoomID, roomName , RoomTypeID,  RoomPrice,  IsAvailable,
                 floorID,  Persons,    Beds);
            else
                return null;
        }

        bool AddNewRoom()
        {
            this.RoomID = clsRoomsData.AddNew(RoomName , RoomTypeID, RoomPrice, IsAvailable,
                 FloorID, Persons, Beds);

            return RoomID != -1;
        }

        bool UpdateRoom()
        {
            return clsRoomsData.Update(RoomID, RoomName, RoomTypeID, RoomPrice, IsAvailable,
                 FloorID, Persons, Beds);
        }

        public bool SetRoomUnAvailable()
        {
            return clsRoomsData.SetRoomUnAvailable(RoomID);
        }
        public static bool SetRoomUnAvailable(int RoomID)
        {
            return clsRoomsData.SetRoomUnAvailable(RoomID);
        }

        public bool SetRoomAvailable()
        {
            return clsRoomsData.SetRoomAvailable(RoomID);
        }
        public static bool SetRoomAvailable(int RoomID)
        {
            return clsRoomsData.SetRoomAvailable(RoomID);
        }


        public static bool DeleteRoom(int RoomID)
        {
            return clsRoomsData.Delete(RoomID);
        }

        public static bool IsRoomExsist(string RomName)
        {
            return clsRoomsData.IsRoomExsist(RomName);
        }
        public static bool IsRoomExsist(int RoomID)
        {
            return clsRoomsData.IsRoomExsist(RoomID);
        }
        public static bool IsRoomAvalibale(int RoomID)
        {
            return clsRoomsData.IsRoomAvalibale(RoomID);
        }
        public  bool IsRoomAvalibale()
        {
            return clsRoomsData.IsRoomAvalibale(RoomID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNewRoom:
                    {
                        if (AddNewRoom())
                        {
                            Mode = enMode.UpdateRoom;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdateRoom:
                    return UpdateRoom();
            }

            return false;
        }

        public static DataTable GetAllRooms()
        {
            return clsRoomsData.GetAllRooms();
        }

        public static int GetAllAvalibaleRooms()
        {
            return clsRoomsData.GetAllAvalibaleRooms();
        }

        public static int GetNumbersOfRooms()
        {
            return clsRoomsData.GetNumbersOfRooms();
        }

    }
}
