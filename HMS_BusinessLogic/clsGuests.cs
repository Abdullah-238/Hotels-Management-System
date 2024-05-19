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
    public class clsGuests : clsPerson
    {
        public enum enMode { AddNewGuest, UpdateGuest };

        public int GuestID { get; set; }

        public enMode Mode = enMode.AddNewGuest;

        public clsGuests()
        {
            this.GuestID = -1;

            Mode = enMode.AddNewGuest;
        }

        clsGuests(int GuestID, int personID, string name, byte gender,
            string phone, int iDNumber, int countryID)
        {
            this.GuestID = GuestID;
            this.PersonID = personID;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.IDNumber = iDNumber;
            this.CountryID = countryID;
            this.CountryInfo = clsCountry.Find(countryID);

            Mode = enMode.UpdateGuest;
        }

        public static clsGuests Find(int GuestID)
        {
            int PersonID = -1;

            bool isFound = clsGuestsData.Find(GuestID, ref PersonID);

            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);

                return new clsGuests(GuestID, PersonID, person.Name, person.Gender,
                                     person.Phone, person.IDNumber, person.CountryID);

            }
            else
                return null;
        }

        public static clsGuests FindByPersonID(int PersonID)
        {
            int GuestID = -1;

            bool isFound = clsGuestsData.FindByPersonID(PersonID, ref GuestID);

            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);

                return new clsGuests(GuestID, PersonID, person.Name, person.Gender,
                                     person.Phone, person.IDNumber, person.CountryID);

            }
            else
                return null;
        }

        bool AddNewGuest()
        {
            this.GuestID = clsGuestsData.AddNew(PersonID);

            return GuestID != -1;
        }

        bool UpdateGuest()
        {
            return clsGuestsData.Update(GuestID, PersonID);
        }

        static public bool DeleteGuest(int GuestID)
        {
            return clsGuestsData.Delete(GuestID);
        }

        public bool Save()
        {
            base.Mode = (clsPerson.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNewGuest:
                    {
                        if (AddNewGuest())
                        {
                            Mode = enMode.UpdateGuest;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdateGuest:
                    return UpdateGuest();
            }

            return false;
        }

        public static DataTable GetAllGuests()
        {
            return clsGuestsData.GetAlGuests();
        }

    }
}
