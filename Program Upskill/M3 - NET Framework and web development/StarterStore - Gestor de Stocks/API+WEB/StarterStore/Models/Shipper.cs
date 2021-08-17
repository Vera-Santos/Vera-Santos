using System;
 using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace StarterStore.Models
{
    public class Shipper
    {
        [DisplayName("Shipper ID")]
        public int ShipperID { get; set; }
       
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        
        [Required]
        public string Phone { get; set; }
    }
}