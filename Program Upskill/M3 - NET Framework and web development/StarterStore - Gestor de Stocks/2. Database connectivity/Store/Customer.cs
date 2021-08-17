using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store
{
    [PathAttribute("customers.json")]
    public class Customer
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }
        [JsonPropertyName("contactName")]
        public string ContactName { get; set; }
        [JsonPropertyName("contactTitle")]
        public string ContactTitle { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Customer>(this);    
    }      
}