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
    public class ShipperViewModel : ManagerClass<Shipper, int>
    {
        public override void DeleteById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Shippers WHERE ShipperID = @ShipperID"; 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ShipperID", id);
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


        public override List<Shipper> ReadAll()
        {
            string sql = "SELECT * FROM Shippers"; 
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Shipper> shipperList = new List<Shipper>();
                Shipper shipper = null;
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        shipper = new Shipper();
                        shipper.ShipperID = (int)reader["ShipperID"];
                        shipper.CompanyName = reader["CompanyName"].ToString();
                        shipper.Phone = reader["Phone"].ToString();
                        shipperList.Add(shipper);
                    }
                }
                conn.Close();
                return shipperList;
            }
        }

       
        public override void Save(Shipper shipper)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Shippers VALUES (@companyName, @phone)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@companyName", shipper.CompanyName);
                cmd.Parameters.AddWithValue("@phone", shipper.Phone);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public override Shipper GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT ShipperID, CompanyName, Phone FROM Shippers WHERE ShipperID=@ShipperID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ShipperID", id);
                Shipper shipper = null;
               conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                shipper = new Shipper();
                                shipper.ShipperID = (int)reader["ShipperID"];
                                shipper.CompanyName = reader["CompanyName"].ToString();
                                shipper.Phone = reader["Phone"].ToString();
                            }
                        }
                    }
                return shipper;
            }
        }

       public override void Update(Shipper shipper)
       {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Shippers SET CompanyName=@CompanyName, Phone=@Phone WHERE ShipperID=@ShipperID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                 
                cmd.Parameters.AddWithValue("@companyName", shipper.CompanyName);
                cmd.Parameters.AddWithValue("@phone", shipper.Phone);
                cmd.Parameters.AddWithValue("@ShipperID", shipper.ShipperID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
       }  
        
        
    }
}