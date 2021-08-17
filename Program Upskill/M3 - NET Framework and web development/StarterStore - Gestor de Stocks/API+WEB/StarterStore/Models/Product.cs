using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StarterStore.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        public int ProductID { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Supplier Id")]
        public int SupplierId { get; set; }

        [DisplayName("Category Id")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }

        [Required] 
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Column("UnitPrice", TypeName = "money")]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Units In Stock")]
        public int UnitsInStock { get; set; }

        [DisplayName("Units On Order")]
        public int UnitsOnOrder { get; set; }

        [DisplayName("Reorder Level")]
        public int ReorderLevel { get; set; }

        [Required]
        public Boolean  Discontinued { get; set; }
    }
}