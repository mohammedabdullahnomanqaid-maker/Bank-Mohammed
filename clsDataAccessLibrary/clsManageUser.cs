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
    public class clsUsers
    {
        static public DataTable RetrievDataOfUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Users.ID,Users.UserName,Persons.Name,Password,Countries.CountryName" +
                ",Cities.Name as CityName,Permission,Email,Phone,DateOfBirth,DateRegister from Users inner join Persons" +
                " on Persons.ID=Users.PersonID inner join Countries " +
                "on Countries.CountryID=Persons.CountryID inner join Cities on Cities.ID=Users.CityID where Persons.Status=1;";

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

        static public DataTable RetrievDataOfUsersByName(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Users.ID,Users.UserName,Persons.Name,Password,Countries.CountryName" +
                ",Cities.Name as CityName,Permission,Email,Phone,DateOfBirth,DateRegister from Users inner join Persons" +
                " on Persons.ID=Users.PersonID inner join Countries " +
                "on Countries.CountryID=Persons.CountryID inner join Cities on Cities.ID=Users.CityID where Persons.Status=1 and Persons.Name like @Name+'%';";

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

        static public bool DeleteUser(int ID)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "Update Persons set Status=0 where ID=(select PersonID from Clients where ID=@ID);";//to remmerber the id here is for client not person so chang it
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
        static public bool AddUsers(string Name, int CountryID, int CityID, string Email, string Phone, DateTime dateOfBirth, string UserName, string Password, int Permission)
        {
            int EffectedRows = 0;
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "insert into Persons(Name,CountryID,Email,Phone,DateOfBirth,DateRegister,Status)" +
                " values(@Name,@CountryID, @Email," +
                "@Phone,@DateOfBirth," +
                " GETDATE(),1) select SCOPE_IDENTITY();";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("CountryID", CountryID);
            command.Parameters.AddWithValue("Email", Email);
            command.Parameters.AddWithValue("Phone", Phone);
            command.Parameters.AddWithValue("DateOfBirth", dateOfBirth);

            try
            {
                connection.Open();
                object Resault = command.ExecuteScalar();
                if (Resault != null & int.TryParse(Resault.ToString(), out int InsertedID))
                {
                    EffectedRows = InsertedID;
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
            string query2 = "insert into Users(UserName,Password,Permission,PersonID,CityID)" +
           " values(@UserName,@Password,@Permission,@PersonID,@CityID); ";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            command2.Parameters.AddWithValue("@UserName", UserName);
            command2.Parameters.AddWithValue("@Password", Password);
            command2.Parameters.AddWithValue("@Permission", Permission);
            command2.Parameters.AddWithValue("@PersonID", PersonID);
            command2.Parameters.AddWithValue("@CityID", CityID);
            try
            {
                connection2.Open();
                int Resault = command2.ExecuteNonQuery();

                EffectedRows = Resault;


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

            return (EffectedRows > 0);
        }
        static public bool UpdateUserByID(int ID, int Permission, string Name, int CountryID, string Email, string Phone, string UserName,string Password, int CityID, DateTime DateOfBirth)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "begin Transaction" +
                " begin try " +
                " Update Users set UserName=@UserName,Password=@Password, Permission=@Permission," +
                "CityID=@CityID where ID=@ID;" +
                " Update Persons set Name=@Name,CountryID=@CountryID,Email=@Email,Phone=@Phone," +
                " DateOfBirth=@DateOfBirth where ID=(select PersonID from Users where ID=@ID);" +
                " commit transaction;" +
                " end try" +
                " begin catch" +
                " rollback Transaction" +
                " end catch;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Permission", Permission);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@CityID", CityID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
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
