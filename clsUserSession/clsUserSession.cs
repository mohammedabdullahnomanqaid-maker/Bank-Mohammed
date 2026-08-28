using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsUserSessionLibrary
{
    public static class UserSession
    {
        public static int UserID { set; get; }
        public static string UserName { set; get; }
        public static string FullName { set; get; }
        public static int Permission { set; get; }
        public static string Password { set; get; }
        public static string Message { set; get; }
        public static string Message2 { set; get; }
        public static DateTime DateRegister { set; get; }

        public enum enMode { NotFoundMode,InsuffisientMode,DoneMode};
       static public enMode Mode = enMode.NotFoundMode;
        public enum enTransfer { NotFoundSenderMode,NotFoundReceiverMode,NotFoundSenderAndReceiverMode,InsuffisientMode, InsuffisientVaultMode, DoneMode}
        static public enTransfer ETransfer = enTransfer.NotFoundSenderAndReceiverMode;
    }
}