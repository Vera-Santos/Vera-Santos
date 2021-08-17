using System;
using System.Collections;

namespace Store
{
    public class Employees : People
    {
        public static int employeesID;
        public string ID { get; set; } 
        public string function { get; set; } 
        public string photo { get; set; }
        public string hireDate { get; set; }
        public string NIB { get; set; }

        public Employees(string fullName, string address, string city, string postalCode, string country, string phone, string NIF, string title, string birthDate, 
                         string CC, string function, string photo, string hireDate, string NIB) : base(fullName, address, city, postalCode, country, phone, NIF, title, birthDate, CC)
        {    
            this.ID = "E" + GetNextID();
            this.function = function;
            this.photo = photo;
            this.hireDate = hireDate;
            this.NIB = NIB;
        }

        static Employees() => employeesID = 2020000;
        protected int GetNextID() => ++employeesID;

              
        public override string ReadPeople()//Descrição do empregado
        {
            return $"Employee n.º{ID}, Full Name:{title} {fullName} - {function} \nBirth Date {birthDate} \nAddress: {address}, {city}, {postalCode}, {country} " +
                   $"\nNIF: {NIF}, NIB: {NIB} \nPhone: {phone} \nIn Starter^Store Since:{hireDate} ";        
        }
        
        public void UpdateFunction()
        {
            Console.WriteLine("Insert new function:");
            string function = Console.ReadLine();
            this.function = function;
            Console.WriteLine("Função successfully updated!");
        }

        public void UpdateNIB()
        {
            Console.WriteLine("Insert new NIB:");
            string NIB = Console.ReadLine();
            this.NIB = NIB;
            Console.WriteLine("NIB successfully updated!");
        }

         
    }
}