using System;
using System.Collections.Generic;



namespace Store
{
    class MenuEmployee
    {
        public static void Menu()
        {
            
            Console.WriteLine(" \n 1- Customers \n 2- Products \n 3- Orders \n 4- Back");
            string numero2 = Console.ReadLine();
            int b;
            bool isNumber2 = Int32.TryParse(numero2, out b);
            switch (b)
            {
                case 1:
                    Console.WriteLine("*****Customer Info*****");
                    Console.WriteLine(" 1- View Customer info \n 2- Insert new Customer \n 3- Delete Customer  \n 4- Update Customer data \n 5- Back ");
                    string numero21 = Console.ReadLine();
                    int b1;
                    bool isNumber21 = Int32.TryParse(numero21, out b1);
                    switch (b1)
                    {
                        case 1:
                            Console.WriteLine("***View Customer info***");
                            new PeopleManager().ReadCustomer();
                            break;
                        case 2:
                            Console.WriteLine("***Insert new Customer***");
                            new PeopleManager().CreateCustomer();
                            break;
                        case 3:
                            Console.WriteLine("***Delete Customer***");
                            new PeopleManager().DeleteCustomer();
                            break;
                        case 4:
                            Console.WriteLine("***Update Customer data***");
                            new PeopleManager().UpdateCustomer();
                            break;
                        case 5:
                            MenuEmployee.Menu();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("*****Products Info*****");
                    Console.WriteLine(" 1- View Product info \n 2- Insert new Product \n 3- Delete Product  \n 4- Update Product data \n 5- Back ");
                    string numero22 = Console.ReadLine();
                    int b2;
                    bool isNumber22 = Int32.TryParse(numero22, out b2);
                    switch (b2)
                    {
                        case 1:
                            Console.WriteLine("***View Product info***");
                            new ProductsManager().ReadProducts();
                            break;
                        case 2:
                            Console.WriteLine("***Insert new Product***");
                            new ProductsManager().CreateProduct();
                            break;
                        case 3:
                            Console.WriteLine("***Delete Product***");
                            new ProductsManager().DeleteProduct();
                            break;
                        case 4:
                            Console.WriteLine("***Update Product data***");
                            new ProductsManager().UpdateProduct();
                            break;
                        case 5:
                            MenuEmployee.Menu();
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("*****Orders Info*****");
                    Console.WriteLine(" 1- View Orders list \n 2- Validate Order \n 3- Delete Order \n 4- Update Order \n 5- Back");
                    string numero23 = Console.ReadLine();
                    int b3;
                    bool isNumber23 = Int32.TryParse(numero23, out b3);
                    switch (b3)
                    {
                        case 1:
                            Console.WriteLine("***View Orders Info***");
                            new OrdersManager().ReadOrders();
                            break;
                        case 2:
                            Console.WriteLine("***Validate Order***");
                            new OrdersManager().CreateOrder();
                            break;
                        case 3:
                            Console.WriteLine("***Delete Order***");
                            new OrdersManager().DeleteOrder();
                            break;
                        case 4:
                            Console.WriteLine("***Update Order***");
                            new OrdersManager().UpdateOrder();
                            break;
                        case 5:
                            MenuEmployee.Menu();
                            break;
                    }
                    break;

                case 4:
                    MenuMain.Menu();
                    break;
            }
           
        }
        

    }
}

