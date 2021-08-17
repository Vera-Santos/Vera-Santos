using System;
using System.IO;
using System.Web;
using System.Data;
using System.Data.SqlTypes;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StarterStore.Models
{
    public class CategoryViewModel : ManagerClass<Category, int>
    {        
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryID", id);
                conn.Open();
                 try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new Exception("Sorry! You can't delete this shipper!");
                }
                conn.Close();
                
            }
        }

        public override List<Category> ReadAll()
        {
            string sql = "SELECT * FROM Categories";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Category> categoryList = new List<Category>();
                Category category = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        category = new Category();
                        category.CategoryID = (int)reader["CategoryID"];
                        category.CategoryName = reader["CategoryName"].ToString();
                        category.Description = reader["Description"].ToString();
                        category.Picture = (byte[])reader["Picture"];
                        categoryList.Add(category);
                    }
                }
                conn.Close();
                return categoryList;
            }
        }


        public override void Save(Category category)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Categories VALUES (@CategoryName, @Description, @Picture)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Description", category.Description);
                byte[] imageData = File.ReadAllBytes(@"StarterStore\wwwroot\images\Log1.jpg");
                cmd.Parameters.AddWithValue("@Picture", imageData);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
       
        public override Category GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT CategoryID, CategoryName, Description, Picture FROM Categories WHERE CategoryID=@CategoryID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryID", id);
                Category category = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            category = new Category();
                            category.CategoryID = (int)reader["CategoryID"];
                            category.CategoryName = reader["CategoryName"].ToString();
                            category.Description = reader["Description"].ToString();
                            category.Picture = (byte[])reader["Picture"];
                        }
                    }
                }
                return category;
            }
        }

        public override void Update(Category category)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Categories SET CategoryName=@CategoryName, Description=@Description, Picture=@Picture WHERE CategoryID=@CategoryID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                cmd.Parameters.AddWithValue("@Description", category.Description);
                cmd.Parameters.AddWithValue("@Picture", category.Picture);
                cmd.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    
    }
}