using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace StarterStore.Models
{
    public class Order
    {
        [DisplayName("OrderID")]
        public int OrderID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public string CustomerID { get; set; }

        [DisplayName("Employee ID")]
        public int? EmployeeID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Order Date")]
        public DateTime? OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Required Date")]
        public DateTime? RequiredDate { get; set; }

        [DisplayName("Shipped Date")]
        public string ShippedDate { get; set; }
       
        [DisplayName("Ship Via")]
        public int? ShipVia { get; set; }

        [Required] 
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Column("Freight", TypeName = "money")]
        public decimal? Freight { get; set; }
         
        [DisplayName("Ship Name")]
        public string ShipName { get; set; }

        [DisplayName("Ship Address")]
        public string ShipAddress { get; set; }

        [DisplayName("Ship City")]
        public string ShipCity { get; set; }

        [DisplayName("Ship Region")]
        public string ShipRegion { get; set; }

        [DisplayName("Ship Postal Code")]
        public string ShipPostalCode { get; set; }

        [DisplayName("Ship Country")]
        public string ShipCountry { get; set; }
    }
}