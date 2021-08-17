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
    public class OrderDetailViewModel : ManagerClass<OrderDetail, int>
    {
        public override void DeleteById(int orderid) {}
        
        public override List<OrderDetail> ReadAll()
        {
            string sql = "SELECT * FROM OrderDetails";
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<OrderDetail> orderDetailList = new List<OrderDetail>();
                OrderDetail orderDetail = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        orderDetail = new OrderDetail();
                        orderDetail.OrderID = (int)reader["OrderID"];
                        orderDetail.ProductID = (int)reader["ProductID"];
                        orderDetail.UnitPrice = (decimal)reader["UnitPrice"];
                        orderDetail.Quantity = (Int16)reader["Quantity"];
                        orderDetail.Discount = (Single)reader["Discount"];
                        orderDetailList.Add(orderDetail);
                    }
                }
                conn.Close();
                return orderDetailList;
            }
        }

        public override void Save(OrderDetail orderDetail)  {}

        public override OrderDetail GetById(int orderid)  
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM OrderDetails WHERE OrderID=@OrderID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderid);
                OrderDetail orderDetail = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            orderDetail = new OrderDetail();
                            orderDetail.OrderID = (int)reader["OrderID"];
                            orderDetail.ProductID = (int)reader["ProductID"];
                            orderDetail.UnitPrice = (decimal)reader["UnitPrice"];
                            orderDetail.Quantity = (Int16)reader["Quantity"];
                            orderDetail.Discount = (Single)reader["Discount"];
                        }
                    }
                }
                return orderDetail;
            }
        }
        
        public override void Update(OrderDetail orderDetail)  {}
        
    }
}