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
    public class OrderViewModel : ManagerClass<Order, int>
    {
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Orders WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderID", id);
                conn.Open();
                 try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new Exception("Sorry! You can't delete this order!");
                }
                conn.Close();
            }
        }

        public override List<Order> ReadAll()
        {
            string sql = "SELECT * FROM Orders";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Order> orderList = new List<Order>();
                Order order = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        order = new Order();
                        order.OrderID = (int)reader["OrderID"];
                        order.CustomerID = (string)reader["CustomerID"];
                        order.EmployeeID = (int)reader["EmployeeID"];
                        order.OrderDate = (DateTime?)reader["OrderDate"];
                        order.RequiredDate = (DateTime?)reader["RequiredDate"];
                        order.ShippedDate = reader["ShippedDate"].ToString();
                        order.ShipVia = (int)reader["ShipVia"];
                        order.Freight = (decimal)reader["Freight"];
                        order.ShipName = reader["ShipName"].ToString();
                        order.ShipAddress = reader["ShipAddress"].ToString();
                        order.ShipCity = reader["ShipCity"].ToString();
                        order.ShipRegion = reader["ShipRegion"].ToString();
                        order.ShipPostalCode = reader["ShipPostalCode"].ToString();
                        order.ShipCountry = reader["ShipCountry"].ToString();
                        orderList.Add(order);
                    }
                }
                conn.Close();
                return orderList;
            }
        }

        public override void Save(Order order)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Orders VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, " +
                    "@ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                cmd.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                cmd.Parameters.AddWithValue("@ShipVia", order.ShipVia);
                cmd.Parameters.AddWithValue("@Freight", order.Freight);
                cmd.Parameters.AddWithValue("@ShipName", order.ShipName);
                cmd.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                cmd.Parameters.AddWithValue("@ShipCity", order.ShipCity);
                cmd.Parameters.AddWithValue("@ShipRegion", order.ShipRegion);
                cmd.Parameters.AddWithValue("@ShipPostalCode", order.ShipPostalCode);
                cmd.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override Order GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, " +
                    "Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders " +
                    "WHERE OrderID=@OrderID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderID", id);
                Order order = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            order = new Order();
                            order.OrderID = (int)reader["OrderID"];
                            order.CustomerID = (string)reader["CustomerID"];
                            order.EmployeeID = (int)reader["EmployeeID"];
                            order.OrderDate = (DateTime?)reader["OrderDate"];
                            order.RequiredDate = (DateTime?)reader["RequiredDate"];
                            order.ShippedDate = reader["ShippedDate"].ToString();
                            order.ShipVia = (int)reader["ShipVia"];
                            order.Freight = (decimal)reader["Freight"];
                            order.ShipName = reader["ShipName"].ToString();
                            order.ShipAddress = reader["ShipAddress"].ToString();
                            order.ShipCity = reader["ShipCity"].ToString();
                            order.ShipRegion = reader["ShipRegion"].ToString();
                            order.ShipPostalCode = reader["ShipPostalCode"].ToString();
                            order.ShipCountry = reader["ShipCountry"].ToString();
                        }
                    }
                }
                return order;
            }
        }

        public override void Update(Order order)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Orders SET CustomerID=@CustomerID, EmployeeID=@EmployeeID, OrderDate=@OrderDate, " +
                    "RequiredDate=@RequiredDate, ShippedDate=@ShippedDate, ShipVia=@ShipVia, Freight=@Freight," +
                    "ShipName=@ShipName, ShipAddress=@ShipAddress, ShipCity=@ShipCity, ShipRegion=@ShipRegion," +
                    "ShipPostalCode=@ShipPostalCode, ShipCountry=@ShipCountry WHERE OrderID=@OrderID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
                cmd.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
                cmd.Parameters.AddWithValue("@ShipVia", order.ShipVia);
                cmd.Parameters.AddWithValue("@Freight", order.Freight);
                cmd.Parameters.AddWithValue("@ShipName", order.ShipName);
                cmd.Parameters.AddWithValue("@ShipAddress", order.ShipAddress);
                cmd.Parameters.AddWithValue("@ShipCity", order.ShipCity);
                cmd.Parameters.AddWithValue("@ShipRegion", order.ShipRegion);
                cmd.Parameters.AddWithValue("@ShipPostalCode", order.ShipPostalCode);
                cmd.Parameters.AddWithValue("@ShipCountry", order.ShipCountry);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }  
    }
}