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
    public class EmployeeViewModel : ManagerClass<Employee, int>
    {
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new Exception("Sorry! You can't delete this employee!");
                }                conn.Close();
            }
        }

        public override List<Employee> ReadAll()
        {
            string sql = "SELECT * FROM Employees";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Employee> employeeList = new List<Employee>();
                Employee employee = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        employee = new Employee();
                        employee.EmployeeID = (int)reader["EmployeeID"];
                        employee.LastName = reader["LastName"].ToString();
                        employee.FirstName = reader["FirstName"].ToString();
                        employee.Title = reader["Title"].ToString();
                        employee.TitleOfCourtesy = reader["TitleOfCourtesy"].ToString();
                        employee.BirthDate = (DateTime)reader["BirthDate"];
                        employee.HireDate = (DateTime)reader["HireDate"];
                        employee.Address = reader["Address"].ToString();
                        employee.City = reader["City"].ToString();
                        employee.Region = reader["Region"].ToString();
                        employee.PostalCode = reader["PostalCode"].ToString();
                        employee.Country = reader["Country"].ToString();
                        employee.HomePhone = reader["HomePhone"].ToString();
                        employee.Extension = reader["Extension"].ToString();
                        employee.Photo = (byte[])reader["Photo"];
                        employee.Notes = reader["Notes"].ToString();
                        employee.ReportsTo = reader["ReportsTo"].ToString();
                        employee.PhotoPath = reader["PhotoPath"].ToString();
                        employeeList.Add(employee);
                    }
                }
                conn.Close();
                return employeeList;
            }
        }

        public override void Save(Employee employee)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Employees VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address," +
                    " @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@Title", employee.Title);
                cmd.Parameters.AddWithValue("@TitleOfCourtesy", employee.TitleOfCourtesy);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Region", employee.Region);
                cmd.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                cmd.Parameters.AddWithValue("@Country", employee.Country);
                cmd.Parameters.AddWithValue("@HomePhone", employee.HomePhone);
                cmd.Parameters.AddWithValue("@Extension", employee.Extension);
                cmd.Parameters.AddWithValue("@Photo", employee.Photo);
                //cmd.Parameters.AddWithValue("@Photo", DBNull.Value);
                //SqlParameter noImage = new SqlParameter("@Photo", SqlDbType.Image);
                //noImage.Value = DBNull.Value;
               // cmd.Parameters.Add(noImage);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                cmd.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);
                cmd.Parameters.AddWithValue("@PhotoPath", employee.PhotoPath);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override Employee GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address," +
                    " City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath FROM Employees " +
                    "WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                Employee employee = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            employee = new Employee();
                            employee.EmployeeID = (int)reader["EmployeeID"];
                            employee.LastName = reader["LastName"].ToString();
                            employee.FirstName = reader["FirstName"].ToString();
                            employee.Title = reader["Title"].ToString();
                            employee.TitleOfCourtesy = reader["TitleOfCourtesy"].ToString();
                            employee.BirthDate = (DateTime)reader["BirthDate"];
                            employee.HireDate = (DateTime)reader["HireDate"];
                            employee.Address = reader["Address"].ToString();
                            employee.City = reader["City"].ToString();
                            employee.Region = reader["Region"].ToString();
                            employee.PostalCode = reader["PostalCode"].ToString();
                            employee.Country = reader["Country"].ToString();
                            employee.HomePhone = reader["HomePhone"].ToString();
                            employee.Extension = reader["Extension"].ToString();
                            employee.Photo = (byte[])reader["Photo"];
                            employee.Notes = reader["Notes"].ToString();
                            employee.ReportsTo = reader["ReportsTo"].ToString();
                            employee.PhotoPath = reader["PhotoPath"].ToString();
                        }
                    }
                }
                return employee;
            }
        }

        public override void Update(Employee employee)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Employees SET LastName=@LastName, FirstName=@FirstName, Title=@Title, TitleOfCourtesy=@TitleOfCourtesy, " +
                    "BirthDate=@BirthDate, HireDate=@HireDate, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, " +
                    "Country=@Country, HomePhone=@HomePhone, Extension=@Extension, Photo=@Photo, Notes=@Notes, ReportsTo=@ReportsTo," +
                    "PhotoPath=@PhotoPath WHERE EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@Title", employee.Title);
                cmd.Parameters.AddWithValue("@TitleOfCourtesy", employee.TitleOfCourtesy);
                cmd.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Region", employee.Region);
                cmd.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                cmd.Parameters.AddWithValue("@Country", employee.Country);
                cmd.Parameters.AddWithValue("@HomePhone", employee.HomePhone);
                cmd.Parameters.AddWithValue("@Extension", employee.Extension);
                cmd.Parameters.AddWithValue("@Photo", employee.Photo);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                cmd.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);
                cmd.Parameters.AddWithValue("@PhotoPath", employee.PhotoPath);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }     
    }
}