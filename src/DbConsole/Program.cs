using System;
using System.Data.SqlClient;
using System.Data;

namespace DbConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "'; DROP TABLE Users; --";
            string connectionString = "your_connection_string_here";
            string query = "SELECT * FROM Users WHERE Name = '" + userInput + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }
        }
    }
}
