using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StarterStore.Models
{
    public class CustomerViewModel : ManagerClass<Customer, string>
    {

        public override void DeleteById(string id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", id);
                conn.Open();
                 try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new Exception("Sorry! You can't delete this customer!");
                }
                conn.Close();
            }
        }

        public override List<Customer> ReadAll()
        {
            string sql = "SELECT * FROM Customers";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Customer> customerList = new List<Customer>();
                Customer customer = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        customer = new Customer();
                        customer.CustomerID = reader["CustomerID"].ToString();
                        customer.CompanyName = reader["CompanyName"].ToString();
                        customer.ContactName = reader["ContactName"].ToString();
                        customer.ContactTitle = reader["ContactTitle"].ToString();
                        customer.Address = reader["Address"].ToString();
                        customer.City = reader["City"].ToString();
                        customer.Region = reader["Region"].ToString();
                        customer.PostalCode = reader["PostalCode"].ToString();
                        customer.Country = reader["Country"].ToString();
                        customer.Phone = reader["Phone"].ToString();
                        customer.Fax = reader["Fax"].ToString();
                        customerList.Add(customer);
                    }
                }
                conn.Close();
                return customerList;
            }
        }

        public override void Save(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Customers VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, " +
                    "@PostalCode, @Country, @Phone, @Fax)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Region", customer.Region);
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Fax", customer.Fax);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }


        public override Customer GetById(string id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, " +
                    "Phone, Fax FROM Customers WHERE CustomerID=@CustomerID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", id);
                Customer customer = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            customer = new Customer();
                            customer.CustomerID = reader["CustomerID"].ToString();
                            customer.CompanyName = reader["CompanyName"].ToString();
                            customer.ContactName = reader["ContactName"].ToString();
                            customer.ContactTitle = reader["ContactTitle"].ToString();
                            customer.Address = reader["Address"].ToString();
                            customer.City = reader["City"].ToString();
                            customer.Region = reader["Region"].ToString();
                            customer.PostalCode = reader["PostalCode"].ToString();
                            customer.Country = reader["Country"].ToString();
                            customer.Phone = reader["Phone"].ToString();
                            customer.Fax = reader["Fax"].ToString();
                        }
                    }
                }
                return customer;
            }
        }

        public override void Update(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Customers SET CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, " +
                    "Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country, Phone=@Phone, " +
                    "Fax=@Fax WHERE CustomerID=@CustomerID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Region", customer.Region);
                cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Fax", customer.Fax);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }   
    }
}