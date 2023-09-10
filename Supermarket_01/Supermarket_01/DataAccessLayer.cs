using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_01
{
    internal static class DataAccessLayer
    {
        public const string Connection_String = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=Supermarket;Integrated Security=True";

        public static void ExecuteNonQuery(string command)
        {
            SqlConnection connection = new SqlConnection(Connection_String);

            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
