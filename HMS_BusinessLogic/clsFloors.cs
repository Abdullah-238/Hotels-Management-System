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
    public class clsFloors
    {
       
        public enum enMode { AddNewFloor, UpdateFloor };

        public int FloorID { get; set; }

        public string FloorName { get; set; }


        public enMode Mode = enMode.AddNewFloor;

        public clsFloors()
        {
            this.FloorID = -1;
            this.FloorName = null;
           
            Mode = enMode.AddNewFloor;
        }

        clsFloors(int FloorID, string FloorName)
        {
            this.FloorID = FloorID;
            this.FloorName = FloorName;
          
            Mode = enMode.UpdateFloor;
        }

        public static clsFloors Find(string floorName)
        {
            int floorID = -1;

            bool isFound = clsFloorsData.Find(floorName,ref floorID);

            if (isFound)
                return new clsFloors(floorID, floorName);
            else
                return null;
        }

        public static clsFloors Find(int floorID )
        {
            string floorName = "";

            bool isFound = clsFloorsData.Find(floorID , ref floorName);

            if (isFound)
                return new clsFloors(floorID, floorName);
            else
                return null;
        }

        bool AddNewFloor()
        {
            this.FloorID = clsFloorsData.AddNew(FloorName);

            return FloorID != -1;
        }

        bool UpdateFloor()
        {
            return clsFloorsData.Update(FloorID,FloorName);
        }

        static public bool DeleteFloor(int floorID)
        {
            return clsFloorsData.Delete(floorID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNewFloor:
                    {
                        if (AddNewFloor())
                        {
                            Mode = enMode.UpdateFloor;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdateFloor:
                    return UpdateFloor();
            }

            return false;
        }

        public static DataTable GetAllFloors()
        {
            return clsFloorsData.GetAllFloors();
        }
    }
}
