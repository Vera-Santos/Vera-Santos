
using System;

namespace Store
{
    public class Contacts 
    // Instâncias comuns a Pessoas e Empresas
    {
        public string fullName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string NIF { get; set; }

        public Contacts(string fullName, string address, string city, string postalCode, string country, string phone, string NIF)
        {
            this.fullName = fullName;
            this.address = address;
            this.city = city;
            this.postalCode = postalCode;
            this.country = country;
            this.phone = phone;
            this.NIF = NIF;
        }  

        public void UpdateAdress()
        {
            Console.WriteLine("Insira morada!");
            string address = Console.ReadLine();
            this.address = address;
            Console.WriteLine("Insira cidade!");
            string city = Console.ReadLine();
            this.city = city;
            Console.WriteLine("Insira código postal!");
            string postalCode = Console.ReadLine();
            this.postalCode = postalCode;
            Console.WriteLine("Insira país!");
            string country = Console.ReadLine();
            this.country = country;
            Console.WriteLine("Morada atualizada com Sucesso!");
        }

        public void UpdatePhone()
        {
            Console.WriteLine("Insira Telemovel!");
            string phone = Console.ReadLine();
            this.phone = phone;
            Console.WriteLine("Telemovel atualizada com Sucesso!");
        }
    }
}


