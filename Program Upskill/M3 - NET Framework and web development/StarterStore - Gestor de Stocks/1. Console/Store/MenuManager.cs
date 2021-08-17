using System;
using System.Collections.Generic;
using Store;


namespace Store
{
     class MenuManager
    {
        public static void  Menu()
        {
            Console.WriteLine("\n*****Welcome Manager!*****");
            Console.WriteLine("\n 1- Companies \n 2- Employees \n 3- Customers \n 4- Sales and Reports \n 5- Back");
            string numero1 = Console.ReadLine();
            int a;
            bool isNumber1 = Int32.TryParse(numero1, out a);
            switch (a)
            {
                case 1:
                    Console.WriteLine("*****Company Info*****");
                    Console.WriteLine(" 1- View companies info \n 2- Insert new company \n 3- Delete company  \n 4- Update company data \n 5- Back");
                    string numero11 = Console.ReadLine();
                    int a1;
                    bool isNumber11 = Int32.TryParse(numero11, out a1);
                    switch (a1)
                    {
                        case 1:
                            Console.WriteLine("***View companies info***");
                            Console.WriteLine(" 1- Supplier \n 2- Shipper \n 3- Back");
                            string numero111 = Console.ReadLine();
                            int a11;
                            bool isNumber111 = Int32.TryParse(numero111, out a11);
                            switch (a11)
                            {
                                case 1:
                                    new CompanyManager().ReadSupplier();
                                    break;
                                case 2:
                                    new CompanyManager().ReadShipper();
                                    break;
                                case 3:
                                    MenuManager.Menu();
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("***Create new company***");
                            Console.WriteLine(" 1- Supplier \n 2- Shipper \n 3- Back");
                            string numero112 = Console.ReadLine();
                            int a12;
                            bool isNumber112 = Int32.TryParse(numero112, out a12);
                            switch (a12)
                            {
                                case 1:
                                    new CompanyManager().CreateSupplier();
                                    break;
                                case 2:
                                    new CompanyManager().CreateShipper();
                                    break;
                                case 3:
                                    MenuManager.Menu();
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("***Delete company***");
                            Console.WriteLine(" 1- Supplier \n 2- Shipper \n 3- Back");
                            string numero113 = Console.ReadLine();
                            int a13;
                            bool isNumber113 = Int32.TryParse(numero113, out a13);
                            switch (a13)
                            {
                                case 1:
                                    new CompanyManager().DeleteSupplier();
                                    break;
                                case 2:
                                    new CompanyManager().DeleteShipper();
                                    break;
                                case 3:
                                    MenuManager.Menu();
                                    break;
                            }
                            break;
                        case 4:
                            Console.WriteLine("***Update company data***");
                            Console.WriteLine(" 1- Supplier \n 2- Shipper \n 3- Back");
                            string numero114 = Console.ReadLine();
                            int a14;
                            bool isNumber114 = Int32.TryParse(numero114, out a14);
                            switch (a14)
                            {
                                case 1:
                                    new CompanyManager().UpdateSupplier();
                                    break;
                                case 2:
                                    new CompanyManager().UpdateShipper();
                                    break;
                                case 3:
                                    MenuManager.Menu();
                                    break;
                            }
                            break;
                        case 5:
                            MenuManager.Menu();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("*****Employee Info*****");
                    Console.WriteLine(" 1- View employee info \n 2- Insert new employee \n 3- Delete employee  \n 4- Update employee data \n 5- Back ");
                    string numero12 = Console.ReadLine();
                    int a2;
                    bool isNumber12 = int.TryParse(numero12, out a2);
                    switch (a2)
                    {
                        case 1:
                            Console.WriteLine("***View employee info***");
                            new PeopleManager().ReadEmployee();
                            break;
                        case 2:
                            Console.WriteLine("***Insert new employee***");
                            new PeopleManager().CreateEmployee();
                            break;
                        case 3:
                            Console.WriteLine("***Delete employee***");
                            new PeopleManager().DeleteEmployee();

                            break;
                        case 4:
                            Console.WriteLine("***Update employee data***");
                            new PeopleManager().UpdateEmployees();
                            break;
                        case 5:
                            MenuManager.Menu();
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("*****Customer Info*****");
                    Console.WriteLine(" 1- View customer info \n 2- Back");
                    string numero13 = Console.ReadLine();
                    int a3;
                    bool isNumber13 = Int32.TryParse(numero13, out a3);
                    switch (a3)
                    {
                        case 1:
                            Console.WriteLine("***View customer info***");
                            new PeopleManager().ReadCustomer();
                            break;
                        case 2:
                            MenuManager.Menu();
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("*****Sales & Reports*****");
                    Console.WriteLine(" 1- View Products \n 2- View Sales \n 3- View Stocks \n 4- Ordering \n 5- Back");
                    string numero14 = Console.ReadLine();
                    int a4;
                    bool isNumber14 = Int32.TryParse(numero14, out a4);
                    switch (a4)
                    {
                        case 1:
                            Console.WriteLine("***View Products***");
                            new ProductsManager().ReadProducts();
                            break;
                        case 2:
                            Console.WriteLine("***View Sales***");
                            new OrdersManager().ReadOrders();
                            break;
                        case 3:
                            Console.WriteLine("***View Stocks***");
                            new ProductsManager().ViewStock();
                            break;
                        case 4:
                            Console.WriteLine("***Ordering***");
                            new ProductsManager().Ordering();
                            break;
                        case 5:
                            MenuManager.Menu();
                            break;
                    }
                    break;
                case 5:
                    MenuMain.Menu();
                    break;
            }
            


        }
    }
        
    
}

