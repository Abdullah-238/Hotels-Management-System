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
    public class clsUsers : clsPerson
    {

        enum enMode { AddNewUser, UpdateUser };
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        enMode _Mode = enMode.AddNewUser;

        public clsUsers()
        {
            this.UserName = null;
            this.Password = null;
            this.IsActive = false;
            this.UserID = -1;

            _Mode = enMode.AddNewUser;
        }

        clsUsers(int personID, int userID, string userName,
            string password, bool isActive, string name, byte gender,
            string phone, int iDNumber, int countryID)
        {
            this.PersonID = personID;
            this.UserID = userID;
            this.Password = password;
            this.IsActive = isActive;
            this.UserName = userName;
            this.Name = name;
            this.Gender = gender;
            this.Phone = phone;
            this.IDNumber = iDNumber;
            this.CountryID = countryID;

            this.CountryInfo = clsCountry.Find(countryID);

            _Mode = enMode.UpdateUser;
        }

        public static clsUsers Find(int userID)
        {
            int personID = -1;
            string userName = null;
            string password = null;
            bool isActive = false;

            bool isFound = clsUsersData.Find(userID, ref userName, ref password,
                ref isActive, ref personID);

            if (isFound)
            {
                clsPerson Person = clsPerson.Find(personID);

                return new clsUsers(personID, userID, userName, password, isActive,
                    Person.Name, Person.Gender, Person.Phone, Person.IDNumber, Person.CountryID);
            }

            else
                return null;
        }

        bool AddNewUser()
        {
            this.UserID = clsUsersData.AddNew(UserName, Password, IsActive, PersonID);

            return PersonID != -1;
        }

        bool UpdateUser()
        {
            return clsUsersData.Update(UserID, UserName, Password, IsActive, PersonID);
        }

        public static bool DeleteUser(int userID)
        {
            return clsUsersData.Delete(userID);
        }


        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public bool Save()
        {
            base.Mode = (clsPerson.enMode)_Mode;
            if (!base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.AddNewUser:
                    {
                        if (AddNewUser())
                        {
                            _Mode = enMode.UpdateUser;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.UpdateUser:
                    return UpdateUser();
            }

            return false;
        }

        public static bool IsUserNameFound(string UserName)
        {
            return clsUsersData.IsUserFoundByUserName(UserName);
        }

        public static bool IsUserFoundByUserNameAndPassword(string UserName, string Password)
        {
            return clsUsersData.IsUserFoundByUserNameAndPassword(UserName, Password);
        }

        public static clsUsers FindByUserName(string userName)
        {
            int personID = -1;
            int userID = -1;
            string password = "";
            bool isActive = false;


            bool isFound = clsUsersData.FindByUserName(userName, ref userID, ref password,
                ref isActive, ref personID);

            if (isFound)
            {
                clsPerson Person = clsPerson.Find(personID);

                return new clsUsers(personID, userID, userName, password, isActive,
                   Person.Name, Person.Gender, Person.Phone, Person.IDNumber, Person.CountryID);
            }
            else
                return null;
        }

        public static clsUsers FindByUserNameAndPassword(string userName, string password)
        {
            int personID = -1;
            int userID = -1;
            bool isActive = false;


            bool isFound = clsUsersData.FindByUserNameAndPassword(userName, password,
                ref userID, ref isActive, ref personID);

            if (isFound)
            {
                clsPerson Person = clsPerson.Find(personID);

                return new clsUsers(personID, userID, userName, password, isActive,
                  Person.Name, Person.Gender, Person.Phone, Person.IDNumber, Person.CountryID);
            }
            else
                return null;
        }

    }
}
