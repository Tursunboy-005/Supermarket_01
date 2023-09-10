using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_01
{
    internal class CategoryDbService
    {
        public void CreateCategory(string categoryName)
        {
            string command = $"INSERT INTO dbo.Category (Category_Name) VALUES '{categoryName}';";

            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void UpdateCategory(int id, string newName)
        {
            string command = $"Update dbo.Category SET Category_Name = '{newName}'" +
                $"WHERE Id = {id};";

            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void DeleteCategory(int id)
        {
            string command = $"DELETE dbo.Category WHERE Id = {id};";

            DataAccessLayer.ExecuteNonQuery(command);
        }

        public void GetAllCategories()
        {
            string query = "SELECT * FROM dbo.Category;";

            ExecuteQuery(query);
        }

        public void GetCategoryById(int id)
        {
            string query = "SELECT * FROM dbo.Category" +
                $" WHERE Id = {id};";

            ExecuteQuery(query);
        }

        public void GetCategoryByName(string categoryName)
        {
            string query = "SELECT * FROM dbo.Category" +
                $" WHERE Category_Name LIKE '%{categoryName}%';";

            ExecuteQuery(query);
        }

        private static void ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Connection_String))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    ReadCategoryFromDataReader(command.ExecuteReader());
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }

        private static void ReadCategoryFromDataReader(SqlDataReader reader)
        {
            if (reader == null)
            {
                return;
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("No data.");
                return;
            }

            Console.WriteLine("{0}\t{1}\t{2}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2));

            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object name = reader.GetValue(1);
                object numberOfProducts = reader.GetValue(2);

                Console.WriteLine("{0} \t{1} \t{2}", id, name, numberOfProducts);
            }
            reader.Close();
        }
    }
}
