using System;
using System.Collections.Generic;


namespace Store
{
    public class Customers : People
  
    {
        public static int customersID;
        public string ID { get; set; }
        public string fax { get; set; }


        public Customers(string fullName, string address, string city, string postalCode, string country, string phone, string NIF, string title,
                         string birthDate, string CC, string fax) : base(fullName, address, city, postalCode, country, phone, NIF, title, birthDate, CC)
        {
            this.ID = "C" + GetNextID();
            this.fax = fax;
        }

        
        static Customers() => customersID = 2020000;
        protected int GetNextID() => ++customersID;
        
        
             
        public override string ReadPeople()//Descrição do cliente
        {
            return $"Customer n.º{ID}, Full Name:{title} {fullName} \nBirth Date:{birthDate} CC:{CC} NIF:{NIF} \nAddress: {address}, {city}, {postalCode}, {country} \nPhone: {phone} Fax:{fax} ";
        }

        public void UpdateFax()
        {
            Console.WriteLine("Insert the new fax:");
            string fax = Console.ReadLine();
            this.fax = fax;
            Console.WriteLine("Fax successfully Updated!");
        }

    }
        
       
}