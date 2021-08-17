using System;

namespace Store
{
    abstract class Company : Contacts
    // Instâncias comuns a Fornecedores e Transportadores 
    {

        public Company(string fullName, string address, string city, string postalCode, string country, string phone, string NIF) : base( fullName, 
                       address, city, postalCode, country, phone, NIF) { }
   


         public abstract string ReadCompany(); 
    
    }
}