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
    public class clsBClients
    {
        public int ID { set; get; }
        public int CountryID { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public DateTime DateOfBirth { set; get; }
        public char Gender { set; get; }
        public string Ac_Num { set; get; }
        public bool Status { set; get; }
        public decimal Balance { set; get; }

        public enum enMode { AddMode, UpdateMode };
        enMode Mode = enMode.AddMode;

        public clsBClients()
        {
            Name = "";
            CountryID = -1;
            Email = "";
            Phone = "";
            Ac_Num = "";
            Status = false;
            DateOfBirth = DateTime.Now;
            Gender = ' ';
            Balance = 0;
            Mode = enMode.AddMode;
        }

        public clsBClients(int ID, string Name, int CountryID, string Email, string Phone, DateTime DateOfBirth, string Ac_Num, char Gender, decimal Balance)
        {
            this.ID = ID;
            this.Name = Name;
            this.CountryID = CountryID;
            this.Email = Email;
            this.Phone = Phone;
            this.Ac_Num = Ac_Num;
            this.Status = Status;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.Balance = Balance;
            Mode = enMode.UpdateMode;
        }

        static public DataTable RetrievDataOfClients()
        {
            return clsClients.RetrievDataOfClients();
        }

        private bool _UpdateClient()
        {
            return clsClients.UpdateClient(ID, Name, CountryID, Email, Phone, DateOfBirth, Gender, Balance); ;
        }

        static public bool DeleteClients(int ID)
        {
            return clsUsers.DeleteUser(ID);
        }
        private bool _AddClients()
        {
            return clsClients.AddClient(Name, CountryID, Email, Phone, Status, DateOfBirth, Ac_Num, Gender, Balance);
        }

        static public DataTable SearchClientByName(string Name)
        {
            return clsClients.RetrievDataOfClientsByName(Name);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddClients())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    break;

                case enMode.UpdateMode:
                    return !_UpdateClient();

            }
            return false;

        }
    }

}
