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
    public class ProductViewModel : ManagerClass<Product, int>
    {
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProductID", id);
                conn.Open();
                 try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new Exception("Sorry! You can't delete this product!");
                }
                conn.Close();
            }
        }

        public override List<Product> ReadAll()
        {
            string sql = "SELECT * FROM Products";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Product> productList = new List<Product>();
                Product product = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        product = new Product();
                        product.ProductID = (int)reader["ProductID"];
                        product.ProductName = reader["ProductName"].ToString();
                        product.SupplierId = (int)reader["SupplierId"];
                        product.CategoryId = (int)reader["CategoryId"];
                        product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                        product.UnitPrice = (decimal)reader["UnitPrice"];
                        product.UnitsInStock = (Int16)reader["UnitsInStock"];
                        product.UnitsOnOrder = (Int16)reader["UnitsOnOrder"];
                        product.ReorderLevel = (Int16)reader["ReorderLevel"];
                        product.Discontinued = (Boolean)reader["Discontinued"];
                        productList.Add(product);
                    }
                }
                conn.Close();
                return productList;
            }
        }

        public override void Save(Product product)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Products VALUES (@ProductName, @SupplierId, @CategoryId, @QuantityPerUnit, @UnitPrice, " +
                    "@UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                cmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
                cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
                cmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override Product GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT ProductID, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, " +
                    "UnitsOnOrder, ReorderLevel, Discontinued FROM Products WHERE ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProductID", id);
                Product product = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            product = new Product();
                            product.ProductID = (int)reader["ProductID"];
                            product.ProductName = reader["ProductName"].ToString();
                            product.SupplierId = (int)reader["SupplierId"];
                            product.CategoryId = (int)reader["CategoryId"];
                            product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                            product.UnitPrice = (decimal)reader["UnitPrice"];
                            product.UnitsInStock = (Int16)reader["UnitsInStock"];
                            product.UnitsOnOrder = (Int16)reader["UnitsOnOrder"];
                            product.ReorderLevel = (Int16)reader["ReorderLevel"];
                            product.Discontinued = (Boolean)reader["Discontinued"];
                        }
                    }
                }
                return product;
            }
        }

        public override void Update(Product product)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Products SET ProductName=@ProductName, SupplierId=@SupplierId, CategoryId=@CategoryId, " +
                    "QuantityPerUnit=@QuantityPerUnit, UnitPrice=@UnitPrice, UnitsInStock=@UnitsInStock, UnitsOnOrder=@UnitsOnOrder," +
                    "ReorderLevel=@ReorderLevel, Discontinued=@Discontinued WHERE ProductID=@ProductID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                cmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                cmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
                cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
                cmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }    
    }
}