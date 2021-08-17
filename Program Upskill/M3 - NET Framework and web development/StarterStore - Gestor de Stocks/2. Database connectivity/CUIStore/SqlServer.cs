using System;
using Microsoft.Data.SqlClient;

namespace CUIStore
{
    public class SqlServer
    {
        public static void ConnectToSqlServer()
        {
            string connectionString = "Server=.;Database=Northwind2016;User Id=sa; Password=upskills2021;";
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                SqlCommand selectCommand = new SqlCommand("SELECT CategoryName, Description from Categories", db);
                SqlDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Console.WriteLine($"Hello {query.GetString(0)} {query.GetString(1)} !");
                }
                db.Close();
            }
        }
    }

}