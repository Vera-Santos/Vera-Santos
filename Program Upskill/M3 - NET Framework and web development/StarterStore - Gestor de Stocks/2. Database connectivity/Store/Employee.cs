using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store
{
    [PathAttribute("employees.json")]
    public class Employee
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("titleOfCourtesy")]
        public string TitleOfCourtesy { get; set; }
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }
        [JsonPropertyName("hireDate")]
        public string HireDate { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("homePhone")]
        public string HomePhone { get; set; }


        public override string ToString() => JsonSerializer.Serialize<Employee>(this);

       
    }
}