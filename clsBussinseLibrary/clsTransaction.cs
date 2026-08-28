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
    public class clsBTransaction
    {
        static public int? FromAccountID { set; get; }
        static public int? ToAccountID { set; get; }
        static public int UserID { set; get; }
        static public int CurrencyID { set; get; }
        static public int? VaultID { set; get; }
        static public decimal LocalAmount { set; get; }
        static public decimal? FromAccBalance { set; get; }
        static public decimal? ToAccBalance { set; get; }
        static public string TransactionType { set; get; }

        public clsBTransaction()
        {
            FromAccountID = -1;
            ToAccountID = -1;
            UserID = -1;
            CurrencyID = -1;
            VaultID = -1;
            LocalAmount = 0;
            FromAccBalance = 0;
            ToAccBalance = 0;
            TransactionType = "";
        }
        static public DataTable RetrievDataOfTotalBalance()
        {
            return clsTrasaction.RetrievDataOfTotalBalance();
        }

        static public DataTable RetrievDataOfTransferLog()
        {
            return clsTrasaction.RetrievDataOfTransferLog();
        }

        static public bool Deposite(string Ac_Num, decimal Amount, bool isTransfer = false)
        {
            foreach (DataRow row in clsClients.RetrieveForTrasaction().Rows)
            {
                string AccountNum = row["Ac_Num"].ToString();
                if (Ac_Num == AccountNum)
                {
                    decimal CurrentBalance = Convert.ToInt32(clsTrasaction.Vault().Rows[0]["CurrentBalance"]);
                    if (Amount < CurrentBalance)
                    {
                        decimal Balance = Convert.ToDecimal(row["Balance"]) + Amount;
                        clsTrasaction.UpdateAfterTransaction(Convert.ToInt32(row["ID"]), Balance);

                        CurrentBalance = CurrentBalance - Amount;
                        clsTrasaction.UpdateMBankVault(1, CurrentBalance);
                        UserSession.Mode = UserSession.enMode.DoneMode;

                        ToAccountID = Convert.ToInt32(row["ID"]);
                        ToAccBalance = Convert.ToDecimal(row["Balance"]);

                        if (!isTransfer)
                        {

                            UserID = Convert.ToInt32(UserSession.UserID);
                            VaultID = Convert.ToInt32(1);
                            TransactionType = "Deposit";
                            FromAccountID = null;
                            FromAccBalance = null;

                            LocalAmount = Amount;

                            _AddToTransferLog();
                        }

                        return true;
                    }
                    else
                    {
                        UserSession.Mode = UserSession.enMode.InsuffisientMode;
                    }
                }
                else
                {
                    UserSession.Mode = UserSession.enMode.NotFoundMode;
                }
            }
            return false;
        }

        static public bool WithDraw(string Ac_Num, decimal Amount, bool IsTransfer = false)
        {
            foreach (DataRow row in clsClients.RetrieveForTrasaction().Rows)
            {
                string AccountNum = row["Ac_Num"].ToString();
                if (Ac_Num == AccountNum)
                {
                    decimal Balance = Convert.ToDecimal(row["Balance"]);
                    decimal CurrentBalance = Convert.ToInt32(clsTrasaction.Vault().Rows[0]["CurrentBalance"]);
                    if (Amount < Balance)
                    {
                        Balance = Convert.ToDecimal(row["Balance"]) - Amount;
                        clsTrasaction.UpdateAfterTransaction(Convert.ToInt32(row["ID"]), Balance);

                        CurrentBalance = CurrentBalance + Amount;
                        clsTrasaction.UpdateMBankVault(1, CurrentBalance);
                        UserSession.Mode = UserSession.enMode.DoneMode;

                        FromAccountID = Convert.ToInt32(row["ID"]);
                        FromAccBalance = Convert.ToDecimal(row["Balance"]);
                        if (!IsTransfer)
                        {
                            UserID = Convert.ToInt32(UserSession.UserID);
                            VaultID = Convert.ToInt32(1);
                            TransactionType = "WithDraw";
                            ToAccountID = null;
                            ToAccBalance = null;

                            LocalAmount = Amount;

                            _AddToTransferLog();

                        }





                        return true;
                    }
                    else
                    {
                        UserSession.Mode = UserSession.enMode.InsuffisientMode;
                        return false;
                    }
                }
                else
                {
                    UserSession.Mode = UserSession.enMode.NotFoundMode;
                    UserSession.Message = Ac_Num;
                }
            }
            return false;
        }

        static public bool checkSender(string S_Acc, decimal Amount)
        {
            foreach (DataRow row in clsClients.RetrieveForTrasaction().Rows)
            {
                string AccountNum = row["Ac_Num"].ToString();
                if (S_Acc == AccountNum)
                {
                    decimal Balance = Convert.ToDecimal(row["Balance"]);
                    decimal CurrentBalance = Convert.ToInt32(clsTrasaction.Vault().Rows[0]["CurrentBalance"]);
                    if (Amount < Balance)
                    {

                        UserSession.Mode = UserSession.enMode.DoneMode;
                        return true;
                    }
                    else
                    {
                        UserSession.Mode = UserSession.enMode.InsuffisientMode;
                        return false;
                    }

                }
                else
                {
                    UserSession.Mode = UserSession.enMode.NotFoundMode;
                }
            }
            return false;

        }

        static public bool checkReceiver(string D_Acc, decimal Amount)
        {
            foreach (DataRow row in clsClients.RetrieveForTrasaction().Rows)
            {
                string AccountNum = row["Ac_Num"].ToString();
                if (D_Acc == AccountNum)
                {

                    UserSession.ETransfer = UserSession.enTransfer.DoneMode;
                    return true;

                }
                else
                {
                    UserSession.ETransfer = UserSession.enTransfer.NotFoundReceiverMode;
                }
            }
            return false;

        }
        static public bool Transfer(string S_Acc, string D_Acc, decimal Amount)
        {


            if (checkSender(S_Acc, Amount) & checkReceiver(D_Acc, Amount))
            {
                if (Deposite(D_Acc, Amount, true) & WithDraw(S_Acc, Amount, true))
                {
                    UserID = Convert.ToInt32(UserSession.UserID);
                    VaultID = null;
                    TransactionType = "Transfer";
                    LocalAmount = Amount;

                    _AddToTransferLog();
                    return true;
                }
            }
            return false;
        }

        static public DataTable VaultMBank()
        {
            return clsTrasaction.Vault();
        }

        public static bool _AddToTransferLog()
        {
            return clsTrasaction.AddToTransferLog(FromAccountID, ToAccountID, LocalAmount, UserID, 1, TransactionType, VaultID);
        }

    }

}
