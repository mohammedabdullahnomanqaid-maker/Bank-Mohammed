using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using clsDataAccessLibrary;
using clsUserSessionLibrary;

namespace clsBussinseLibrary
{
    public class clsBUsers
    {
        public int ID { set; get; }
        public int CountryID { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public int CityID { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public int Permission { set; get; }
        public enum enMode { AddMode, UpdateMode };
        enMode Mode = enMode.AddMode;
        public clsBUsers()
        {
            Name = "";
            Email = "";
            Phone = "";
            UserName = "";
            Password = "";
            CityID = -1;
            Permission = 0;
            CountryID = -1;
            DateOfBirth = DateTime.Now;
            Mode = enMode.AddMode;
        }

        public clsBUsers(int ID, string Name, string Email, string Phone, int CityID, string UserName, string Password, int Permission, int CountryID, DateTime DateOfBirth)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.Permission = Permission;
            this.CountryID = CountryID;
            this.UserName = UserName;
            this.DateOfBirth = DateOfBirth;
            this.CityID = CityID;
            Mode = enMode.UpdateMode;
        }
        static public DataTable RetrieveDataOfUsers()
        {
            return clsUsers.RetrievDataOfUsers();
        }

        private bool _AddUser()
        {
            return clsUsers.AddUsers(Name, CountryID, CityID, Email, Phone, DateOfBirth, UserName, Password, Permission);
        }

        static public bool DeleteUser(int ID)
        {
            return clsUsers.DeleteUser(ID);
        }
        static public DataTable SearchUserByName(string Name)
        {
            return clsUsers.RetrievDataOfUsersByName(Name);
        }

        private bool _UpdateUser()
        {
            return clsUsers.UpdateUserByID(ID, Permission, Name, CountryID, Email, Phone, UserName,Password, CityID, DateOfBirth);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddUser())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return !_UpdateUser();
            }
            return false;
        }
    }

}
