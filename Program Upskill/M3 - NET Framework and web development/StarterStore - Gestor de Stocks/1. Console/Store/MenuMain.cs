using System;
using System.Collections.Generic;


namespace Store
{
    public class MenuMain
    {
        public static void Menu()
        {
                Console.WriteLine("Welcome at StarterStore! \n------------------------ \n 1- Manager \n 2- Employee \n 3- Customer \n 4- Quit");
                string numero1 = Console.ReadLine();
                int a;
                bool isNumber1 = Int32.TryParse(numero1, out a);
                switch (a)
                {
                    case 1:
                        Console.WriteLine("*****Log in:*****");
                        new PeopleManager().LogInManager();
                        //new MenuAdministrador().Menu();
                        break;
                    case 2:
                        Console.WriteLine("*****Log in:*****");
                        new PeopleManager().LogInEmployee();
                        //MenuColaborador.Menu();
                    break;
                    case 3:
                        Console.WriteLine("*****Log in:*****");
                        MenuCustomer.MenuLogIN();
                        break;
                    case 4:
                        Console.WriteLine("See you soon!");
                        break;
                } 
        }
    }
}

