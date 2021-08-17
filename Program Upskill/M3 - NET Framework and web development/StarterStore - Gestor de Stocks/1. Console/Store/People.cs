using System;
using System.Collections.Generic;


namespace Store
{
     public abstract class People : Contacts 
    // Instâncias comuns a Clientes e Empregados
    {
        public string title { get; set; }
        public string birthDate { get; set; }
        public string CC { get; set; }
        

        public People(string fullName, string address, string city, string postalCode, string country, string phone, string NIF, string title, 
                      string birthDate, string CC) : base( fullName,  address,  city,  postalCode,  country,  phone,  NIF)
        {
            this.title = title;
            this.birthDate = birthDate;
            this.CC = CC;
        }

               
        public abstract string ReadPeople(); 
        
    }
}

