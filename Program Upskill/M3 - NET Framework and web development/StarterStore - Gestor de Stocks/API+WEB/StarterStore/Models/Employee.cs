using System;
using System.IO;
 using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarterStore.Models
{
    public class Employee
    {
        
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
       
        public string Title { get; set; }
       
        [DisplayName("Title of Courtesy")]
        public string TitleOfCourtesy { get; set; }
       
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string Region { get; set; }
        
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        
        public string Country { get; set; }
        
        [DisplayName("HomePhone")]
        public string HomePhone { get; set; }
        
        public string Extension { get; set; }
       
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; } 
        
        [Column(TypeName = "ntext")]
        public string Notes { get; set; } 
        
        [DisplayName("Reports To")]
        public string ReportsTo { get; set; } 
        
        [DisplayName("Photo Path")]
        public string PhotoPath { get; set; } 
        
        [NotMapped]
        public string Base64String
        {
            get
            {
                var base64Str = string.Empty;
                using (var ms = new MemoryStream())
                {
                    int offset = 78;
                     ms.Write(Photo, offset, Photo.Length - offset);
                    if(Photo.Equals(DBNull.Value) || Photo == null)
                     {
                        base64Str = "Log1.jpg";
                     }
                     else
                     {
                       
                        var bmp = new System.Drawing.Bitmap(ms);
                        using (var jpegms = new MemoryStream())
                        {
                            bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            base64Str = Convert.ToBase64String(jpegms.ToArray());
                        }
                     }
                }
                return base64Str;
            }
        }
    }
}