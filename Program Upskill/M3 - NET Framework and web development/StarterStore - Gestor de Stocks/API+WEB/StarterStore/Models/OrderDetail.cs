using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace StarterStore.Models
{
   public class OrderDetail
   {
        [Key]
        [Column(Order = 0)]
        [DisplayName("Order ID")]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DisplayName("Product ID")]
        public int ProductID { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        public Int16 Quantity { get; set; }

        [Required]
        public Single Discount { get; set; }    
   }
}