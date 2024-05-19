using DVLD_Buisness;
using HMS_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_BusinessLogic
{
    public class clsPerson
    {
      
        public enum enMode { AddNewPerson, UpdatePerson };

        public int PersonID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int IDNumber  { get; set; }

        public byte Gender { get; set; }

        public int CountryID { get; set; }

        public clsCountry CountryInfo; 

        public enMode Mode = enMode.AddNewPerson;


        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = null;
            this.IDNumber = -1;
            this.Phone = null;
            this.CountryID = -1;
            this.Gender = 0;

            Mode = enMode.AddNewPerson;
        }

        clsPerson(int personID, string name, byte gender,
            string phone, int  iDNumber, int countryID)
        {
            this.PersonID = personID;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.IDNumber = iDNumber;
            this.CountryID = countryID;

            this.CountryInfo = clsCountry.Find(countryID);

            Mode = enMode.UpdatePerson;
        }

        public static clsPerson Find(int personID)
        {
             string name = ""; byte gender = 0;

            string phone = "";  int iDNumber = -1;  int countryID = -1; 

            bool isFound = clsPersonsData.Find(personID, ref name, ref gender,
                ref phone,ref iDNumber ,ref countryID);

            if (isFound)
                return new clsPerson(personID,  name,  gender,
                 phone,  iDNumber,  countryID);
            else
                return null;
        }

        bool AddNewPerson()
        {
            this.PersonID = clsPersonsData.AddNew(Name, Gender, Phone, IDNumber, CountryID);

            return PersonID != -1;
        }

        bool UpdatePerson()
        {
            return clsPersonsData.Update(PersonID, Name, Gender, Phone, IDNumber, CountryID);
        }

        public bool DeletePerson(int personID)
        {
            return clsPersonsData.Delete(personID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNewPerson:
                    {
                        if (AddNewPerson())
                        {
                            Mode = enMode.UpdatePerson;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdatePerson:
                    return UpdatePerson();
            }

            return false;
        }


    }
}
