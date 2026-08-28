using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using clsDataAccessLibrary;

namespace DataAccessLibrary
{
    public static class clsDDatabaseInitializer
    {
        private const string DatabaseName = "MBankDB";

        public static void Initialize()
        {
            // 1. الاتصال بـ SQL Server نفسه وليس بقاعدة MBankDB
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(
                    clsConnectionString.ConnectionString);

            builder.InitialCatalog = "master";

            // 2. إنشاء قاعدة البيانات إذا لم تكن موجودة
            using (SqlConnection connection =
                new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                string createDatabaseQuery = @"
IF DB_ID(N'MBankDB') IS NULL
BEGIN
    CREATE DATABASE [MBankDB]
END";

                using (SqlCommand command =
                    new SqlCommand(createDatabaseQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            // 3. مسار ملف SQL الموجود داخل المشروع
            string scriptPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Database",
                "MBankDB.sql"
            );

            // 4. التأكد أن ملف SQL موجود
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    "لم يتم العثور على ملف قاعدة البيانات: " + scriptPath);
            }

            // 5. الاتصال بقاعدة MBankDB
            builder.InitialCatalog = DatabaseName;

            using (SqlConnection connection =
                new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                // 6. التأكد هل قاعدة البيانات مهيأة مسبقًا
                string checkTableQuery = @"
SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME = 'Accounts'";

                using (SqlCommand checkCommand =
                    new SqlCommand(checkTableQuery, connection))
                {
                    int tableCount =
                        (int)checkCommand.ExecuteScalar();

                    // إذا كان جدول Accounts موجودًا
                    // فهذا يعني أن قاعدة البيانات مهيأة مسبقًا
                    if (tableCount > 0)
                        return;
                }

                // 7. قراءة ملف SQL كاملًا
                string script = File.ReadAllText(scriptPath);

                // 8. تقسيم السكربت عند GO
                string[] batches = Regex.Split(
                    script,
                    @"^\s*GO\s*$",
                    RegexOptions.Multiline |
                    RegexOptions.IgnoreCase
                );

                // 9. تنفيذ كل جزء من السكربت
                foreach (string batch in batches)
                {
                    if (string.IsNullOrWhiteSpace(batch))
                        continue;

                    using (SqlCommand command =
                        new SqlCommand(batch, connection))
                    {
                        command.CommandTimeout = 120;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}