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
    public class clsBLoginRegister
    {

        public int UserID { set; get; }

        public enum enMode { AddMode, UpdateMode };
        enMode Mode = enMode.AddMode;

        public clsBLoginRegister()
        {
            UserID = -1;
            Mode = enMode.AddMode;
        }
        public clsBLoginRegister(int UserID)
        {
            this.UserID = UserID;
            Mode = enMode.UpdateMode;
        }
        static public DataTable RetrievDataOfLoginRegister()
        {
            return clsLoginRegister.RetrievDataOfLoginRegister();
        }

        static public bool IsPassed(string Password, string UserName)
        {
            foreach (DataRow rows in clsBUsers.RetrieveDataOfUsers().Rows)
            {

                if (Password == rows["Password"].ToString() && UserName == rows["UserName"].ToString())
                {
                    DateTime Date = DateTime.Now;
                    string Time = Date.ToString("dd/M/yyyy-hh:mm:ss:tt");

                    UserSession.UserName = rows["UserName"].ToString();
                    UserSession.FullName = rows["Name"].ToString();
                    UserSession.Permission = (int)rows["Permission"];
                    UserSession.UserID = (int)rows["ID"];

                    clsLoginRegister.AddLoginRegister((int)rows["ID"]);



                    return true;


                }



            }
            return false;
        }

        private bool _AddLoginRegister()
        {
            return clsLoginRegister.AddLoginRegister(UserID);
        }

        public static bool CheckPermission(int permission)
        {

            if (Convert.ToInt32(UserSession.Permission) == -1)
                return true;

            if ((Convert.ToInt32(UserSession.Permission) & permission) == permission)
            {
                return true;
            }

            return false;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddLoginRegister())
                    {
                        Mode = enMode.AddMode;
                        return true;
                    }
                    break;

                case enMode.UpdateMode:
                    return false;
            }
            return false;
        }
    }

}
