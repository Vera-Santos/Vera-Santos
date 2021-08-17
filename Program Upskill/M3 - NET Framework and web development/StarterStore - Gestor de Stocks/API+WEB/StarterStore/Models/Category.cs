using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarterStore.Models
{
    public class Category
    {
        
        [DisplayName("Category ID")]
        public int CategoryID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

     
        [Column(TypeName = "image")]
        public byte[]  Picture { get; set; }
         
        [NotMapped]
        public string Base64String
        {
            get
            {
                var base64Str = string.Empty;
                using (var ms = new MemoryStream())
                {
                    int offset = 78;
                    ms.Write(Picture, offset, Picture.Length - offset);
                    var bmp = new System.Drawing.Bitmap(ms);
                    using (var jpegms = new MemoryStream())
                    {
                        bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        base64Str = Convert.ToBase64String(jpegms.ToArray());
                    }
                }
                return base64Str;
            }
        }
    }
}