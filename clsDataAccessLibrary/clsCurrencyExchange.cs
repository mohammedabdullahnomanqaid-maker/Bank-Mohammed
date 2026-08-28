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
    public class clsCurrencies
    {
        static public DataTable RetrievDataOfCurrencies()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select Currencies.ID,Countries.ImagePath,Countries.CountryName," +
                "Currencies.CurrencyName,Countries.Code,Currencies.SellRate,Currencies.BuyRate," +
                "Currencies.LastUpdate from Currencies inner join Countries " +
                "on Countries.CountryID=Currencies.CountryID where Status=1;";



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
                    writer.WriteLine("Erorr : " + ex);
                }
            }
            finally
            {

                connection.Close();
            }
            return dt;
        }
        static public DataTable RetreiveCities(int CountryID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select ID,Name from Cities where CountryID=@CountryID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
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
        static public bool AddCurrency(string CountryName, string Code,string PhoneFormat,string CityName, string PinCode, string ImagePath, string CurrencyName, double SellRate, double BuyRate)
        {
            int CountryID = -1;
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "insert into Countries(CountryName,Code,PinCode,ImagePath,PhoneFormat,Status) " +
                " values(@CountryName, @Code, @PinCode, @ImagePath,@PhoneFormat,1)" +
                " select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@PhoneFormat",PhoneFormat);

            try
            {
                connection.Open();
                object Resault = command.ExecuteScalar();
                int.TryParse(Resault.ToString(), out CountryID); //out as you said if the operation done put in CountryID 

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
            string query2 = "insert into Currencies(CountryID, CurrencyName, SellRate, BuyRate, LastUpdate)" +
                " values(@CountryID, @CurrencyName, @sellRate, @BuyRate, Getdate());" +
                "insert into Cities(CountryID,Name)" +
                "values(@CountryID,@CityName); ";
            SqlCommand command2 = new SqlCommand(query2, connection2);
            command2.Parameters.AddWithValue("@CountryID", CountryID);
            command2.Parameters.AddWithValue("@CurrencyName", CurrencyName);
            command2.Parameters.AddWithValue("@sellRate", SellRate);
            command2.Parameters.AddWithValue("@BuyRate", BuyRate);
            command2.Parameters.AddWithValue("@CityName", CityName);

            try
            {
                connection2.Open();
                rowEffected = command2.ExecuteNonQuery();
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
            return (rowEffected > 0);
        }
        static public bool UpdateCurrencies(int ID, double SellRate, double BuyRate)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "update Currencies set SellRate=@SellRate,BuyRate=@BuyRate where ID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@SellRate", SellRate);
            command.Parameters.AddWithValue("@BuyRate", BuyRate);

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
        static public bool DeleteCountries(int ID)
        {
            int rowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "update Countries set Countries.Status=0 " +
                "where CountryID=(select CountryID from Currencies where ID=@ID);";
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
        static public DataTable RetrieveDataOfCountry()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select CountryID,CountryName,Code,PhoneFormat,PinCode from Countries " +
                "where Status=1;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader =command.ExecuteReader();
               
                if(reader.HasRows)
                {
                    dt.Load(reader);

                }
            }
            catch(Exception ex)
            {
                using(StreamWriter writer=new StreamWriter(clsConnectionString.FileName))
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
    }

}
