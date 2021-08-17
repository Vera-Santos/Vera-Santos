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
    public class SupplierViewModel : ManagerClass<Supplier, int>
    {
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SupplierID", id);
                conn.Open();
                 try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new Exception("Sorry! You can't delete this supplier!");
                }
                conn.Close();
            }
        }

        public override List<Supplier> ReadAll()
        {
            string sql = "SELECT * FROM Suppliers";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Supplier> supplierList = new List<Supplier>();
                Supplier supplier = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        supplier = new Supplier();
                        supplier.SupplierID = (int)reader["SupplierID"];
                        supplier.CompanyName = reader["CompanyName"].ToString();
                        supplier.ContactName = reader["ContactName"].ToString();
                        supplier.ContactTitle = reader["ContactTitle"].ToString();
                        supplier.Address = reader["Address"].ToString();
                        supplier.City = reader["City"].ToString();
                        supplier.Region = reader["Region"].ToString();
                        supplier.PostalCode = reader["PostalCode"].ToString();
                        supplier.Country = reader["Country"].ToString();
                        supplier.Phone = reader["Phone"].ToString();
                        supplier.Fax = reader["Fax"].ToString();
                        supplier.HomePage = reader["HomePage"].ToString();
                        supplierList.Add(supplier);
                    }
                }
                conn.Close();
                return supplierList;
            }
        }

        public override void Save(Supplier supplier)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Suppliers VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, " +
                    "@PostalCode, @Country, @Phone, @Fax, @HomePage)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", supplier.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@City", supplier.City);
                cmd.Parameters.AddWithValue("@Region", supplier.Region);
                cmd.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
                cmd.Parameters.AddWithValue("@Country", supplier.Country);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Fax", supplier.Fax);
                cmd.Parameters.AddWithValue("@HomePage", supplier.HomePage);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override Supplier GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, " +
                    "Phone, Fax, HomePage FROM Suppliers WHERE SupplierID=@SupplierID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SupplierID", id);
                Supplier supplier = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            supplier = new Supplier();
                            supplier.SupplierID = (int)reader["SupplierID"];
                            supplier.CompanyName = reader["CompanyName"].ToString();
                            supplier.ContactName = reader["ContactName"].ToString();
                            supplier.ContactTitle = reader["ContactTitle"].ToString();
                            supplier.Address = reader["Address"].ToString();
                            supplier.City = reader["City"].ToString();
                            supplier.Region = reader["Region"].ToString();
                            supplier.PostalCode = reader["PostalCode"].ToString();
                            supplier.Country = reader["Country"].ToString();
                            supplier.Phone = reader["Phone"].ToString();
                            supplier.Fax = reader["Fax"].ToString();
                            supplier.HomePage = reader["HomePage"].ToString();
                        }
                    }
                }
                return supplier;
            }
        }

        public override void Update(Supplier supplier)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Suppliers SET CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, " +
                    "Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country, Phone=@Phone, " +
                    "Fax=@Fax, HomePage=@HomePage WHERE SupplierID=@SupplierID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", supplier.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@City", supplier.City);
                cmd.Parameters.AddWithValue("@Region", supplier.Region);
                cmd.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
                cmd.Parameters.AddWithValue("@Country", supplier.Country);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Fax", supplier.Fax);
                cmd.Parameters.AddWithValue("@HomePage", supplier.HomePage);
                cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }    
    }
}