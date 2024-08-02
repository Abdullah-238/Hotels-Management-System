using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsRoomTypes
    {

        public enum enMode { AddNewRoomType, UpdateRoomType };

        public int RoomTypeID { get; set; }

        public string RoomTypeName { get; set; }


        public enMode Mode = enMode.AddNewRoomType;

        public clsRoomTypes()
        {
            this.RoomTypeID = -1;
            this.RoomTypeName = "";

            Mode = enMode.AddNewRoomType;
        }

        clsRoomTypes(int roomTypeID, string roomTpeName)
        {
            this.RoomTypeID = roomTypeID;
            this.RoomTypeName = roomTpeName;

            Mode = enMode.UpdateRoomType;
        }

        public static clsRoomTypes Find(int RoomTypeID)
        {
            string RoomyTypeName = "";

            bool isFound = clsRoomTypesData.Find(RoomTypeID, ref RoomyTypeName);

            if (isFound)
                return new clsRoomTypes(RoomTypeID, RoomyTypeName);
            else
                return null;
        }


        public static clsRoomTypes Find(string RoomyTypeName )
        {
            int RoomTypeID = -1; 

            bool isFound = clsRoomTypesData.Find(RoomyTypeName , ref RoomTypeID);

            if (isFound)
                return new clsRoomTypes(RoomTypeID, RoomyTypeName);
            else
                return null;
        }

        bool AddNewRoomType()
        {
            this.RoomTypeID = clsRoomTypesData.AddNew(RoomTypeName);

            return RoomTypeID != -1;
        }

        bool UpdateRoomType()
        {
            return clsRoomTypesData.Update(RoomTypeID, RoomTypeName);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNewRoomType:
                    {
                        if (AddNewRoomType())
                        {
                            Mode = enMode.UpdateRoomType;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdateRoomType:
                    return UpdateRoomType();
            }

            return false;
        }

        public static DataTable GetAllRoomTypes()
        {
            return clsRoomTypesData.GetAllRoomTypes();
        }

        public static List<DTORoomType> GetAllRoomsTypeDTO()
        {
            return clsRoomTypesData.GetAllRoomsTypeDTO();
        }

    }
}
