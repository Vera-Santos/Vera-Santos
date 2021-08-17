using System;
using System.Collections.Generic;
using System.Linq;
//using CUIStore;



namespace Store
{
    public class PeopleManager 
    {
        public static List<People> people;

        public  PeopleManager()
        {
            people = new List<People>();
            //Customer (fullName, address, city, postalCode, country, phone, NIF, title, birthDate, CC, fax)
            people.Add(new Customers("Vera Santos", "Rua 123", "Lisboa", "1234", "Portugal", "132456789", "132456789", "Sra.", "16-12-1982", "123456789", "123456789"));
            people.Add(new Customers("Rui Dias", "Rua 123", "Lisboa", "1234", "Portugal", "13245678", "13245678", "Sra.", "16-12-1982", "12345678", "12345678"));
            people.Add(new Customers("Ana Silva", "Rua 123", "Lisboa", "1234", "Portugal", "1324567890", "1324567890", "Sra.", "16-12-1982", "1234567890", "1234567890"));

            //Employee (fullName, address, city, postalCode, country, phone, NIF, title, birthDate, CC, function, photo, hireDate, NIB)
            people.Add(new Employees("Rui Andrade", "Rua da Moda", "Lisboa", "1234", "Portugal", "912345678", "123456789", "Sr.", "20-10-1990", "123456789", "Gerente", "N/A", "20-01-2020",
                       "123456789"));
            people.Add(new Employees("Eva Mendes", "Rua da Moda", "Lisboa", "1234", "Portugal", "91234567", "12345678", "Sra.", "20-10-1990", "12345678", "Operadora", "N/A", "20-01-2020",
                       "12345678"));
            people.Add(new Employees("Ivo Alves", "Rua da Moda", "Lisboa", "1234", "Portugal", "9123456780", "1234567890", "Sr.", "20-10-1990", "1234567890", "Operador", "N/A", "20-01-2020",
                       "1234567890"));
        }

        public void CreateCustomer()
        {
            Console.WriteLine("Insert fullname:");
            string fullName1 = Console.ReadLine();
            Console.WriteLine("Insert adress:");
            string address1 = Console.ReadLine();
            Console.WriteLine("Insert city:");
            string city1 = Console.ReadLine();
            Console.WriteLine("Insert postal code:");
            string postalCode1 = Console.ReadLine();
            Console.WriteLine("Insert country:");
            string country1 = Console.ReadLine();
            Console.WriteLine("Insert phone:");
            string phone1 = Console.ReadLine();
            Console.WriteLine("Insert NIF:");
            string NIF1 = Console.ReadLine();
            Console.WriteLine("Insert title:");
            string title1 = Console.ReadLine();
            Console.WriteLine("Insert birth date:");
            string birthDate1 = Console.ReadLine();
            Console.WriteLine("Insert CC:");
            string CC1 = Console.ReadLine();
            Console.WriteLine("Insert Fax:");
            string fax1 = Console.ReadLine();
            
            people.Add(new Customers(fullName1, address1, city1, postalCode1, country1, phone1, NIF1, title1, birthDate1, CC1, fax1));
            foreach(People person in people)
            { 
                if (person is Customers)
                {
                    Customers c = person as Customers;
                    Console.WriteLine($"{c.ReadPeople()} \n");
                }
                
            }
        }
        public void NewCreateCustomer()
        {
            Console.WriteLine("Insert fullname:");
            string fullName1 = Console.ReadLine();
            Console.WriteLine("Insert adress:");
            string address1 = Console.ReadLine();
            Console.WriteLine("Insert city:");
            string city1 = Console.ReadLine();
            Console.WriteLine("Insert postal code:");
            string postalCode1 = Console.ReadLine();
            Console.WriteLine("Insert country:");
            string country1 = Console.ReadLine();
            Console.WriteLine("Insert phone:");
            string phone1 = Console.ReadLine();
            Console.WriteLine("Insert NIF:");
            string NIF1 = Console.ReadLine();
            Console.WriteLine("Insert title:");
            string title1 = Console.ReadLine();
            Console.WriteLine("Insert birth date:");
            string birthDate1 = Console.ReadLine();
            Console.WriteLine("Insert CC:");
            string CC1 = Console.ReadLine();
            Console.WriteLine("Insert Fax:");
            string fax1 = Console.ReadLine();

            
            people.Add(new Customers(fullName1, address1, city1, postalCode1, country1, phone1, NIF1, title1, birthDate1, CC1, fax1));

            string user;
            string password;
            for (int attempts = 3; attempts != 0; attempts--)
            {
                user = fullName1;
                password = CC1;
                int attemptsleft = attempts - 1;
                //Console.Clear();
                Console.Write("Username: ");
                string userIntroduction = Console.ReadLine();
                Console.Write("Password: ");
                string passwordIntroduction = Console.ReadLine();
                if (user == userIntroduction && password == passwordIntroduction)
                {
                    MenuCustomer.Menu();
                    break;
                }
                else
                {
                    Console.WriteLine($"Username and/or password are wrong! \n {attemptsleft} attempts  left.");
                    if (attemptsleft == 0)
                    {
                        Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                        MenuCustomer.MenuLogIN();
                    }
                }
            }
        }

        public void CreateEmployee()
        {
            Console.WriteLine("Insert fullname:");
            string fullName1 = Console.ReadLine();
            Console.WriteLine("Insert address:");
            string address1 = Console.ReadLine();
            Console.WriteLine("Insert city:");
            string city1 = Console.ReadLine();
            Console.WriteLine("insert postal code");
            string postalCode1 = Console.ReadLine();
            Console.WriteLine("Insert country:");
            string country1 = Console.ReadLine();
            Console.WriteLine("Insert phone:");
            string phone1 = Console.ReadLine();
            Console.WriteLine("Insert NIF:");
            string NIF1 = Console.ReadLine();
            Console.WriteLine("Insert Title:");
            string title1 = Console.ReadLine();
            Console.WriteLine("Insert birth date:");
            string birthDate1 = Console.ReadLine();
            Console.WriteLine("Insert CC:");
            string CC1 = Console.ReadLine();
            Console.WriteLine("Insert function:");
            string function1 = Console.ReadLine();
            Console.WriteLine("Insert photo:");
            string photo1 = Console.ReadLine();
            Console.WriteLine("Insert hire date:");
            string hireDate1 = Console.ReadLine();
            Console.WriteLine("Insert NIB:");
            string NIB1 = Console.ReadLine();
            people.Add(new Employees(fullName1, address1, city1, postalCode1,country1, phone1,  NIF1, title1, birthDate1, CC1, function1, 
                    photo1, hireDate1, NIB1));          
            foreach (People person in people)
            {
                if (person is Employees)
                {
                    Employees e = person as Employees;
                    Console.WriteLine($"{e.ReadPeople()} \n");
                }
            }
        }
        
        
        public void ReadEmployee()
        {
            foreach (People person in people)
            { 
                if (person is Employees)
                {
                    Employees e = person as Employees;
                    Console.WriteLine($"{e.ReadPeople()} \n");
                }
            }
        }
        

        public void ReadCustomer()
        {
            foreach(People person in people)
            { 
                if (person is Customers)
                {
                    Customers c = person as Customers;
                    Console.WriteLine($"{c.ReadPeople()} \n");
                }
            }
        }
        
        

         public void UpdateEmployees()
        {
            string fullNamePeople;                 
            Console.WriteLine("Insert the fullname of which person do you want to update info:");
            fullNamePeople = Console.ReadLine();
            People fsearch = people.Find(p => p.fullName.Equals(fullNamePeople));
            if (fsearch != null)
            {
                if (fsearch is Employees)
                {
                        Employees e = fsearch as Employees;
                        Console.WriteLine("Name found!");
                        Console.WriteLine(fsearch.ReadPeople());
                        Console.WriteLine("Which info do you want to update? \n1- Address \n2- Phone \n3- Function \n4- NIB ");
                        string numero1 = Console.ReadLine();
                        int a;
                        bool isNumber1 = int.TryParse(numero1, out a);
                        switch (a)
                        {
                            case 1:
                                e.UpdateAdress();
                                Console.WriteLine(e.ReadPeople());
                                break;
                            case 2:
                                e.UpdatePhone();
                                Console.WriteLine(e.ReadPeople());
                                break;
                            case 3:
                                e.UpdateFunction();
                                Console.WriteLine(e.ReadPeople());
                                break;
                            case 4:
                                e.UpdateNIB();
                                Console.WriteLine(e.ReadPeople());
                                break;
                        }
                }
                else
                {
                    Console.WriteLine("Name not found!");
                }
            }
            else
            {
                Console.WriteLine("Name not found!");
            }
            MenuManager.Menu();

        }
        public void UpdateCustomer()
        {
            string fullNamePeople;
            Console.WriteLine("Insert the fullname of which person do you want to update info:");
            fullNamePeople = Console.ReadLine();
            People fsearch = people.Find(p => p.fullName.Equals(fullNamePeople));
            if (fsearch != null)
            {
                if (fsearch is Customers)
                {
                    Customers c = fsearch as Customers;
                    if (fsearch != null)
                    {
                        Console.WriteLine("Name found!");
                        Console.WriteLine(fsearch.ReadPeople());
                        Console.WriteLine("Which info do you want to update? \n1- Address \n2- Phone \n3- Fax ");
                        string numero1 = Console.ReadLine();
                        int a;
                        bool isNumber1 = int.TryParse(numero1, out a);
                        switch (a)
                        {
                            case 1:
                                c.UpdateAdress();
                                Console.WriteLine(c.ReadPeople());
                                break;
                            case 2:
                                c.UpdatePhone();
                                Console.WriteLine(c.ReadPeople());
                                break;
                            case 3:
                                c.UpdateFax();
                                Console.WriteLine(c.ReadPeople());
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Name not found!");
                }
            }
            else
            {
                Console.WriteLine("Name not found!");
            }
            MenuCustomer.Menu();
        }



        public void DeleteEmployee()
        {
            string search;                 
            Console.WriteLine("Insert the fullname");
            search = Console.ReadLine();
            People fsearch = people.Find(e => e.fullName.Equals(search));
            if (fsearch != null)
            {
                if (fsearch is Employees)
                {
                    Employees e = fsearch as Employees;
                    Console.WriteLine("Name found!");
                    Console.WriteLine(fsearch.ReadPeople());
                    Console.WriteLine("Are you sure that you want to delete this employee? \n 1- Yess \n 2- No");
                    string numeroR1 = Console.ReadLine();
                    int r1;
                    bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                    switch (r1)
                    {
                        case 1:
                            people.RemoveAll(e => e.fullName.Equals(search));
                            Console.WriteLine("Employee  successfully removed!");
                            break;
                        case 2:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Name not found");
                }
            }            
            else
            {
                Console.WriteLine("Name not found");
            }
            MenuManager.Menu();
        }

        public void DeleteCustomer()
        {
            string search;
            Console.WriteLine("Insert the fullname");
            search = Console.ReadLine();
            People fsearch = people.Find(e => e.fullName.Equals(search));
            if (fsearch != null)
            {
                if (fsearch is Customers)
                {
                    Customers c = fsearch as Customers;
                    Console.WriteLine("Name found!");
                    Console.WriteLine(fsearch.ReadPeople());
                    Console.WriteLine("Are you sure that you want to delete this employee? \n 1- Yess \n 2- No");
                    string numeroR1 = Console.ReadLine();
                    int r1;
                    bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                    switch (r1)
                    {
                        case 1:
                            people.RemoveAll(c => c.fullName.Equals(search));
                            Console.WriteLine("Employee  successfully removed!");
                            break;
                        case 2:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Name not found");
                }
            }
            else
            {
                Console.WriteLine("Name not found");
            }
            MenuEmployee.Menu();
        }

        public void LogInManager()
        {
            string user;
            string password;
            for (int attempts = 3; attempts != 0; attempts--)
            {
                user = "1";
                password = "3";
                int attemptsleft = attempts - 1;
                //Console.Clear();
                Console.Write("Username: ");
                string userIntroduction = Console.ReadLine();
                Console.Write("Password: ");
                string passwordIntroduction = Console.ReadLine();
                if (user == userIntroduction && password == passwordIntroduction)
                {
                    MenuManager.Menu();
                    break;
                }
                else
                {
                    Console.WriteLine($"Username and/or password are wrong! \n {attemptsleft} attempts  left.");
                    if (attemptsleft == 0)
                    {
                        Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                        MenuMain.Menu();
                    }
                }
            }
        }

        public void LogInEmployee()
        {
            string user;
            string password;
            for (int attempts = 3; attempts != 0; attempts--)
            {
                int attemptsleft = attempts - 1;
                string userIntroduction;
                Console.WriteLine("Username: ");
                userIntroduction = Console.ReadLine();
                People fuserIntroduction = people.Find(e1 => e1.fullName.Equals(userIntroduction));
                if (fuserIntroduction != null)
                {
                    if (fuserIntroduction is Employees)
                    {
                        Employees e = fuserIntroduction as Employees;
                        user = e.fullName;
                        password = e.CC;
                        if (user == userIntroduction)
                        {
                            string passwordIntroduction;
                            Console.WriteLine("Password: ");
                            passwordIntroduction = Console.ReadLine();
                            People fpasswordIntroduction = people.Find(e2 => e2.CC.Equals(passwordIntroduction));
                            if (password == passwordIntroduction)
                            {
                                Console.WriteLine($"Welcome {e.fullName}!");
                                MenuEmployee.Menu();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid Password! \n {attemptsleft} attempts  left.");
                                if (attemptsleft == 0)
                                {
                                    Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                                    MenuMain.Menu();
                                }
                            }
                        }
                        else
                        {
                            Console.Write($"Invalid Username!\n {attemptsleft} attempts  left.");
                            if (attemptsleft == 0)
                            {
                                Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                                MenuMain.Menu();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Username and/or password are wrong! \n {attemptsleft} attempts  left.");
                    if (attemptsleft == 0)
                    {
                        Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                        MenuMain.Menu();
                    }
                }
            }
        }

        public void LogInCustomer()
        {
            string user;
            string password;
            for (int attempts = 3; attempts != 0; attempts--)
            {

                int attemptsleft = attempts - 1;
                string userIntroduction;
                Console.WriteLine("Username: ");
                userIntroduction = Console.ReadLine();
                People fuserIntroduction = people.Find(c1 => c1.fullName.Equals(userIntroduction));


                if (fuserIntroduction != null)
                {
                    if (fuserIntroduction is Customers)
                    {
                        Customers c = fuserIntroduction as Customers;
                        user = c.fullName;
                        password = c.CC;
                        if (user == userIntroduction)
                        {
                            string passwordIntroduction;
                            Console.WriteLine("Password: ");
                            passwordIntroduction = Console.ReadLine();
                            People fpasswordIntroduction = people.Find(c2 => c2.CC.Equals(passwordIntroduction));
                            if (password == passwordIntroduction)
                            {
                                Console.WriteLine($"Welcome {c.fullName}!");
                                MenuCustomer.Menu();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid Password! \n {attemptsleft} attempts  left.");
                                if (attemptsleft == 0)
                                {
                                    Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                                    MenuMain.Menu();
                                }
                            }
                        }
                        else
                        {
                            Console.Write($"Invalid Username!\n {attemptsleft} attempts  left.");
                            if (attemptsleft == 0)
                            {
                                Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                                MenuMain.Menu();
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Username and/or password are wrong! \n {attemptsleft} attempts  left.");
                    if (attemptsleft == 0)
                    {
                        Console.WriteLine("\nNumber of attempts exceeded ! \nTry again later.");
                        MenuMain.Menu();
                    }
                
                }
            }
        }
    }          
}
