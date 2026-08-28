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
    public class clsLoginRegister
    {
        static public DataTable RetrievDataOfLoginRegister()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "select LoginRegister.LoginRegisterID as LoginID ,Users.UserName,Users.Password," +
                "          Users.Permission,LoginRegister.DateTimeOfRegister from LoginRegister " +
                "inner join Users on Users.ID=LoginRegister.UserID";


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

        static public bool AddLoginRegister(int UserID)
        {
            int RowEffected = 0;
            SqlConnection connection = new SqlConnection(clsConnectionString.ConnectionString);
            string query = "insert into LoginRegister(UserID,DateTimeOfRegister) " +
                "values(@UserID,GETDATE());";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                RowEffected = command.ExecuteNonQuery();
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
            return (RowEffected > 0);
        }
    }

}
