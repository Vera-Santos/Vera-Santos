using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store
{
    [PathAttribute("products.json")]
    public class Product
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }
        [JsonPropertyName("productName")]
        public string ProductName { get; set; }
        [JsonPropertyName("supplierId")]
        public string SupplierId { get; set; }
        [JsonPropertyName("unitPrice")]
        public string UnitPrice { get; set; }
        [JsonPropertyName("unitInStock")]
        public string UnitInStock { get; set; }
        [JsonPropertyName("reorderLevel")]
        public string ReorderLevel { get; set; }
       
        

        public override string ToString() => JsonSerializer.Serialize<Product>(this);    
    }      
}