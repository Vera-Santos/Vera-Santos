using System;
using System.Collections.Generic;
using System.Linq;
//using CUISTore;



namespace Store
{
    public class CompanyManager
    {
        private static List<Company> companies;

        public CompanyManager()
        {
            companies = new List<Company>();
            //Suppliers(fullName, address, city , postalCode, country, phone, NIF)
            companies.Add(new Suppliers("Danone", "Rua 200", "Lisboa", "1200", "Portugal", "910000000", "508100101"));
            companies.Add(new Suppliers("Mimosa", "Rua 201", "Porto", "2400", "Portugal", "911111111", "508100102"));
            companies.Add(new Suppliers("Compal", "Rua 202", "Aveiro", "1234", "Portugal", "912222222", "508100103"));
            companies.Add(new Suppliers("Sumol", "Rua 203", "Funchal", "3456", "Portugal", "913333333", "508100104"));

            //Shippers(fullName, address, city, postalCode, country, phone, NIF)
            companies.Add(new Shippers("DHL", "Avenida Silva", "Lisboa", "1200", "Portugal", "914444444", "508100105"));
            companies.Add(new Shippers("CTT", "Rua das oliveiras", "Setubal", "1300", "Portugal", "915555555", "508100106"));
            companies.Add(new Shippers("Nacex", "Rua 52", "Alverca", "1400", "Portugal", "916666666", "508100107"));
            companies.Add(new Shippers("Dpd", "Rua do além", "Olivais", "1500", "Portugal", "917777777", "508100108"));
        }


        public void CreateShipper()
        {
            Console.WriteLine("Insert name:");
            string fullName1 = Console.ReadLine();
            Console.WriteLine("Insert address:");
            string address1 = Console.ReadLine();
            Console.WriteLine("Insert city:");
            string city1 = Console.ReadLine();
            Console.WriteLine("Insert postal code:");
            string postalCode1 = Console.ReadLine();
            Console.WriteLine("Insert country:");
            string country1 = Console.ReadLine();
            Console.WriteLine("Insert Phone:");
            string phone1 = Console.ReadLine();
            Console.WriteLine("Insert NIF:");
            string NIF1 = Console.ReadLine();          
            companies.Add(new Shippers(fullName1, address1, city1, postalCode1, country1, phone1, NIF1));
            foreach (Company company in companies)
            {
                if (company is Shippers)
                {
                    Shippers sh = company as Shippers;
                    Console.WriteLine($"{sh.ReadCompany()}");
                    Console.WriteLine();
                }  
            }
            //MenuAdministrador.Menu();

        }

        public void CreateSupplier()
        {
            Console.WriteLine("Insert name:");
            string fullName1 = Console.ReadLine();
            Console.WriteLine("Insert address:");
            string address1 = Console.ReadLine();
            Console.WriteLine("Insert city:");
            string city1 = Console.ReadLine();
            Console.WriteLine("Insert postal code:");
            string postalCode1 = Console.ReadLine();
            Console.WriteLine("Insert country:");
            string country1 = Console.ReadLine();
            Console.WriteLine("Insert Phone:");
            string phone1 = Console.ReadLine();
            Console.WriteLine("Insert NIF:");
            string NIF1 = Console.ReadLine();      
            companies.Add(new Suppliers(fullName1, address1, city1, postalCode1, country1, phone1, NIF1));   
            foreach (Company company in companies)
            {
                if (company is Suppliers)
                {
                    Suppliers su = company as Suppliers;
                    Console.WriteLine($"{su.ReadCompany()}");
                    Console.WriteLine();
                }            
            }
            //MenuAdministrador.Menu();
        }

        public void ReadShipper()
        {
            foreach (Company company in companies)
            {
                if (company is Shippers)
                {
                    Shippers sh = company as Shippers;
                    Console.WriteLine($"{sh.ReadCompany()}");
                    Console.WriteLine();
                }  
            }
        }
        public void ReadSupplier()
        {
            foreach (Company company in companies)
            {
                if (company is Suppliers)
                {
                    Suppliers su = company as Suppliers;
                    Console.WriteLine($"{su.ReadCompany()}");
                    Console.WriteLine();
                }            
            }
        }

        
        public void UpdateShipper()
        {
            string fullNameConmpany;                 
            Console.WriteLine("Inser the name of the company you wish to update:");
            fullNameConmpany = Console.ReadLine();
            Company fsearch = companies.Find(c => c.fullName.Equals(fullNameConmpany));
            if (fsearch != null)
            {
                if (fsearch is Shippers)
                {
                    Shippers sh = fsearch as Shippers;
                    Console.WriteLine("Company found!");
                    Console.WriteLine(fsearch.ReadCompany());
                    Console.WriteLine("Which data do you want to update? \n1- Address \n2- Phone \n3-Back");
                    string numero1 = Console.ReadLine();
                    int a;
                    bool isNumber1 = int.TryParse(numero1, out a);
                    switch (a)
                    {
                        case 1:
                            sh.UpdateAdress();
                            Console.WriteLine(sh.ReadCompany());
                            break;
                        case 2:
                            sh.UpdatePhone();
                            Console.WriteLine(sh.ReadCompany());
                            break;
                        case 3:
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Company not found!");
                }
            }
            else
            {
                Console.WriteLine("Company not found!");
            }
            MenuManager.Menu();
        }
        
        public void UpdateSupplier()
        {
            string fullNameConmpany;
            Console.WriteLine("Inser the name of the company you wish to update:");
            fullNameConmpany = Console.ReadLine();
            Company fsearch = companies.Find(c => c.fullName.Equals(fullNameConmpany));
            if (fsearch != null)
            {
                if (fsearch is Suppliers)
                {
                    Suppliers su = fsearch as Suppliers;
                    Console.WriteLine("Company found!");
                    Console.WriteLine(fsearch.ReadCompany());
                    Console.WriteLine("Which data do you want to update? \n1- Address \n2- Phone \n3- Back");
                    string numero1 = Console.ReadLine();
                    int a;
                    bool isNumber1 = int.TryParse(numero1, out a);
                    switch (a)
                    {
                        case 1:
                            su.UpdateAdress();
                            Console.WriteLine(su.ReadCompany());
                            break;
                        case 2:
                            su.UpdatePhone();
                            Console.WriteLine(su.ReadCompany());
                            break;
                        case 3:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Company not found!");
                }
            }
            else
            {
                Console.WriteLine("Company not found!");
            }
            MenuManager.Menu();
        }

        public void DeleteShipper()
        {
            string search;                 
            Console.WriteLine("Inser the name of the company you wish to delete: ");
            search = Console.ReadLine();
            Company fsearch = companies.Find(sh => sh.fullName.Equals(search));
            if (fsearch != null)
            {
                    if (fsearch is Shippers)
                    {
                    Shippers sh = fsearch as Shippers;
                
                        Console.WriteLine("Company found!");
                        Console.WriteLine(fsearch.ReadCompany());
                        Console.WriteLine("Are you sure you want to delete this company? \n 1- Yes \n 2- No");
                        string numeroR1 = Console.ReadLine();
                        int r1;
                        bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                        switch (r1)
                        {
                            case 1:
                                companies.RemoveAll(sh => sh.fullName.Equals(search));
                                Console.WriteLine("Shipper successfully removed!");
                                break;
                            case 2:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Company not found!");
                    }
            }
            else
            {
                Console.WriteLine("Company not found!");
            }
            MenuManager.Menu();
        }

        public void DeleteSupplier()
        {
            string search;
            Console.WriteLine("Inser the name of the company you wish to delete: ");
            search = Console.ReadLine();
            Company fsearch = companies.Find(sh => sh.fullName.Equals(search));
            if (fsearch != null)
            {
                if (fsearch is Suppliers)
                {
                    Suppliers su = fsearch as Suppliers;
                    if (fsearch != null)
                    {
                        Console.WriteLine("Company found");
                        Console.WriteLine(fsearch.ReadCompany());
                        Console.WriteLine("Are you sure you want to delete this company? \n 1- Yes \n 2- No");
                        string numeroR1 = Console.ReadLine();
                        int r1;
                        bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                        switch (r1)
                        {
                            case 1:
                                companies.RemoveAll(su => su.fullName.Equals(search));
                                Console.WriteLine("Shipper successfully removed!");
                                break;
                            case 2:
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Company not found!");
                }
            }
            else
            {
                Console.WriteLine("Company not found!");
            }
            MenuManager.Menu();

        }
    }
}