using System;
using System.Collections.Generic;



namespace Store
{
    class MenuCustomer
    {
        public static void MenuLogIN()
        {
            Console.WriteLine("Bem vindo Cliente! \n 1- Log In \n 2- Subscribe \n 3- Back");
            string numero3 = Console.ReadLine();
            int c;
            bool isNumber3 = Int32.TryParse(numero3, out c);
            switch (c)
            {
                case 1:
                    Console.WriteLine("Log In:");
                    new PeopleManager().LogInCustomer();
                    break;
                case 2:
                    new PeopleManager().NewCreateCustomer();
                    //MenuCliente.Menu();
                    break;
                case 3:
                    MenuMain.Menu();
                    break;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("\n 1- Personal Info \n 2- My shop \n 3- Back");
            string numero311 = Console.ReadLine();
            int d;
            bool isNumber311 = Int32.TryParse(numero311, out d);
            switch (d)
            {
                case 1:
                    Console.WriteLine("*****Personal Info*****");
                    Console.WriteLine(" 1- View Personal info \n 2- Update Personal data \n 3- Delete my acount  \n 4- Back ");
                    string numero12 = Console.ReadLine();
                    int d1;
                    bool isNumber12 = int.TryParse(numero12, out d1);
                    switch (d1)
                    {
                        case 1:
                            Console.WriteLine("***View Personal info***");
                            new PeopleManager().ReadCustomer();
                            MenuCustomer.Menu();
                            break;
                        case 2:
                            Console.WriteLine("***Update Personal data***");
                            new PeopleManager().UpdateCustomer();
                            MenuCustomer.Menu();
                            break;
                        case 3:
                            Console.WriteLine("***Delete my acount***");
                            new PeopleManager().DeleteCustomer();
                            MenuCustomer.Menu();
                            break;
                        case 4:
                            MenuCustomer.Menu();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("***** My Shop:*****");
                    Console.WriteLine(" 1- View Products \n 2- My Shoping Cart \n 3- Back ");
                    string numero13 = Console.ReadLine();
                    int d2;
                    bool isNumber13 = int.TryParse(numero13, out d2);
                    switch (d2)
                    {
                        case 1:
                            Console.WriteLine("***View Products***");
                            new ProductsManager().ReadProductsForClients();
                            MenuCustomer.Menu();
                            break;
                        case 2:
                            Console.WriteLine("***My Shoping Cart***");
                            Console.WriteLine(" 1- Add Products \n 2- Remove Products \n 3- Back ");
                            string numero131 = Console.ReadLine();
                            int d21;
                            bool isNumber131 = int.TryParse(numero131, out d21);
                            switch (d21)
                            {
                                case 1:
                                    Console.WriteLine("***Add Products***");
                                    MenuCustomer.Menu();
                                    break;
                                case 2:
                                    Console.WriteLine("***Remove Products***");
                                    MenuCustomer.Menu();
                                    break;
                                case 3:
                                    MenuCustomer.Menu();
                                    break;
                            }
                            break;
                        case 3:
                            MenuCustomer.Menu();
                            break;
                    }
                    break;
                case 3:
                    MenuMain.Menu();
                    break;
            }
        }
    }
}

