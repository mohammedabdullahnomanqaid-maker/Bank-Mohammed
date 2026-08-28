using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace clsDataAccessLibrary
{
    public class clsTrasaction
    {
        static public DataTable RetrievDataOfTotalBalance()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Persons.Name,Clients.Ac_Num,Accounts.Balance from Persons inner join Clients on Persons.ID=Clients.PersonID inner join Accounts on Accounts.ClientID=Clients.ID";



            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine("Erorr : " + ex + "\n______________________________\n" + dt.Rows.Count);
                }
            }
            finally
            {

                connection.Close();
            }
            return dt;
        }

        static public DataTable RetrievDataOfTransferLog()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Transactions.ID,Transactions.TransactionDate," +
                "Transactions.TransactionType as OpType, ClientSender.Ac_Num as S_Acct," +
                "ClientReceiver.Ac_Num as D_Acct,Vault.VaultName, Transactions.Amount," +
                "AccountSender.Balance as S_Balance, AccountReceiver.Balance as D_Balance," +
                "Users.UserName from Transactions  left join Accounts AccountSender " +
                "on Transactions.FromAccountID = AccountSender.ID left join Accounts AccountReceiver " +
                " on AccountReceiver.ID = Transactions.ToAccountID inner join Users  " +
                " on Users.ID = Transactions.UserID left join Clients as ClientSender " +
                " on AccountSender.ClientID = ClientSender.ID left join Clients as ClientReceiver " +
                "on AccountReceiver.ClientID = ClientReceiver.ID left join Vault " +
                "on Vault.ID=Transactions.VaultID;";



            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine("Erorr : " + ex + "\n______________________________\n");
                }
            }
            finally
            {

                connection.Close();
            }
            return dt;
        }

        static public DataTable Vault()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select *from Vault;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine("Erorr : " + ex);
                }
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        static public bool UpdateAfterTransaction(int ID, decimal Balance)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "Update Accounts set Balance = @Balance where ID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                rowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine("Erorr : " + ex);
                }
            }
            finally
            {
                connection.Close();
            }
            return (rowEffected > 0);
        }

        static public bool UpdateMBankVault(int ID, decimal CurrentBalance)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "Update Vault set CurrentBalance = @CurrentBalance where ID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CurrentBalance", CurrentBalance);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                rowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine("Erorr : " + ex);
                }
            }
            finally
            {
                connection.Close();
            }
            return (rowEffected > 0);
        }
        static public object GetDBNull(object value)
        {
            return value ?? (object)DBNull.Value;
            //?? this mean if value has value return value if it is not has value return DBNull.null
        }
        static public bool AddToTransferLog(int? FromAccountID, int? ToAccountID, decimal Amount, int UserID, int CurrencyID, string TransactionType, int? VaultID)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = " insert into Transactions (TransactionDate,FromAccountID,ToAccountID," +
                           " Amount,UserID,CurrencyID,TransactionType,VaultID)" +
                           " values(GetDate(),@FromAccountID,@ToAccountID,@Amount," +
                           " @UserID,@CurrencyID,@TransactionType,@VaultID);"
                          ;

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FromAccountID", GetDBNull(FromAccountID));
            command.Parameters.AddWithValue("@ToAccountID", GetDBNull(ToAccountID));
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@TransactionType", TransactionType);
            command.Parameters.AddWithValue("@VaultID", GetDBNull(VaultID));
            //command.Parameters.AddWithValue("@FromAccBalance", GetDBNull(FromAccBalance));
            //command.Parameters.AddWithValue("@ToAccBalance", GetDBNull(ToAccBalance));
            //command.Parameters.AddWithValue("@FromAccID", FromAccID);
            //command.Parameters.AddWithValue("@ToAccID", ToAccID);

            try
            {
                connection.Open();
                rowEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine("Erorr : " + ex);
                }
            }
            finally
            {
                connection.Close();
            }
            return (rowEffected > 0);

        }
    }
}
