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
    public class clsClients
    {
        static public DataTable RetrievDataOfClients()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Clients.ID,Persons.Name,Countries.CountryName," +
                "Email,Phone,Balance,DateOfBirth,DateRegister,Ac_Num,Gender,Persons.Status from Clients " +
                "inner join Persons on Persons.ID=Clients.PersonID inner join Countries" +
                " on Countries.CountryID=Persons.CountryID " +
                "inner join Accounts on Accounts.ClientID=Clients.ID where Persons.Status=1;";

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
                    writer.WriteLine("Erorr : " + ex.Message);
                }
            }
            finally
            {

                connection.Close();
            }
            return dt;
        }

        static public DataTable RetrievDataOfClientsByName(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Clients.ID,Persons.Name,Countries.CountryName," +
                "Email,Phone,Balance,DateOfBirth,DateRegister,Ac_Num,Gender,Persons.Status from Clients " +
                "inner join Persons on Persons.ID=Clients.PersonID inner join Countries" +
                " on Countries.CountryID=Persons.CountryID inner join Accounts " +
                " on Accounts.ClientID=Clients.ID where Persons.Status=1 and " +
                " Persons.Name like @Name+'%';";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
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
                    writer.WriteLine("Erorr : " + ex.Message);
                }
            }
            finally
            {

                connection.Close();
            }
            return dt;
        }

        static public bool AddClient(string Name, int CountryID, string Email, string Phone, bool Status, DateTime dateOfBirth, string Ac_Num, char Gender, decimal Balance)
        {
            int EffectedRows = 0;
            int PersonID = -1;
            int ClientID = -1;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "insert into Persons(Name,CountryID,Email,Phone,DateOfBirth,DateRegister,Status)" +
                " values(@Name,@CountryID, @Email," +
                "@Phone,@DateOfBirth," +
                " GETDATE(),@Status) select SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("CountryID", CountryID);
            command.Parameters.AddWithValue("Email", Email);
            command.Parameters.AddWithValue("Phone", Phone);
            command.Parameters.AddWithValue("DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("Status", Status);

            try
            {
                connection.Open();
                object Resault = command.ExecuteScalar();
                if (Resault != null & int.TryParse(Resault.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine(ex.Message);
                }
            }
            finally
            {
                connection.Close();
            }

            SqlConnection connection2 = new SqlConnection(clsConnectionString.ConnectionString);
            string query2 = "insert into Clients(PersonID,Ac_Num,Gender)" +
           " values(@PersonID,@Ac_Num,@Gender) select SCOPE_IDENTITY(); ";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            command2.Parameters.AddWithValue("@Ac_Num", Ac_Num);
            command2.Parameters.AddWithValue("@Gender", Gender);
            command2.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection2.Open();
                object Resault = command2.ExecuteScalar();
                if (Resault != null & int.TryParse(Resault.ToString(), out int InsertedID))
                {
                    ClientID = InsertedID;

                }


            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine(ex.Message);
                }
            }
            finally
            {
                connection2.Close();
            }

            SqlConnection connection3 = new SqlConnection(clsConnectionString.ConnectionString);
            string query3 = "insert into Accounts (ClientID,CurrencyID,Status,Balance,CreatedDate)" +
                "values(@ClientID,1,@Status,@Balance,GetDate());";
            SqlCommand command3 = new SqlCommand(query3, connection3);
            command3.Parameters.AddWithValue("@ClientID", ClientID);
            command3.Parameters.AddWithValue("@Status", Status);
            command3.Parameters.AddWithValue("@Balance", Balance);

            try
            {
                connection3.Open();
                EffectedRows = command3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine(ex.Message);
                }
            }
            finally
            {
                connection3.Close();
            }

            return (EffectedRows > 0);
        }
        static public bool UpdateClient(int ID, string Name, int CountryID, string Email, string Phone, DateTime dateOfBirth, char Gender, decimal Balance)
        {
            int EffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "Begin Transaction;" +
                " begin try" +
                " Update Persons set Name=@Name,CountryID=@CountryID, Phone=@Phone,Email=@Email," +
                " DateOfBirth=@DateOfBirth where ID=(select PersonID from Clients where ID=@ID);" +
                " Update Clients set Gender=@Gender where ID=@ID;" +
                " Commit transaction;" +
                " end try" +
                " begin catch" +
                " Rollback Transaction;" +
                " end catch;";




            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("ID", ID);
            command.Parameters.AddWithValue("CountryID", CountryID);
            command.Parameters.AddWithValue("Email", Email);
            command.Parameters.AddWithValue("Phone", Phone);
            command.Parameters.AddWithValue("DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);


            try
            {
                connection.Open();
                EffectedRows = command.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(clsConnectionString.FileName))
                {
                    writer.WriteLine(ex.Message);
                }
            }
            finally
            {
                connection.Close();
            }


            return (EffectedRows > 0);
        }

        static public DataTable RetrieveForTrasaction()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Accounts.ID, Ac_Num,Balance from Accounts inner join Clients on Accounts.ClientID=Clients.ID;";
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
                    writer.WriteLine(ex.Message);
                }
            }
            finally
            {
                connection.Close();
            }


            return dt;
        }

        static public bool DeleteClients(int ID)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "Update Accounts set Status=0 where ID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
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
                    writer.WriteLine(ex.Message);
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
