using System;
using System.Collections.Generic;



namespace Store
{
    public class OrdersManager
    {
        private static List<Order> orders;

        public OrdersManager()
        {
            orders = new List<Order>();
            //Order( string CustomerID, string EmployeeId, string OrderDate, string ProductId, double UnitPrice, int Quantity, string ShipperID)
            orders.Add(new Order("C2020001", "E2020001", "10-12-2020", "P2020001", 1.00, 5, "SH2020001"));
            orders.Add(new Order("C2020001", "E2020002", "13-12-2020", "P2020001", 1.00, 12, "SH2020001"));
            orders.Add(new Order("C2020002", "E2020001", "10-12-2020", "P2020003", 3.50, 5, "SH2020002"));
        }


        public void CreateOrder()
        {
            Console.WriteLine("Insert Customer ID:");
            string CustomerID1 = Console.ReadLine();
            Console.WriteLine("Insert Employee Id:");
            string EmployeeId1 = Console.ReadLine();
            Console.WriteLine("Insert Order Date:");
            string OrderDate1 = Console.ReadLine();
            Console.WriteLine("Insert Product Id:");
            string ProductId1 = Console.ReadLine();
            Console.WriteLine("Insert unit price:");
            string numero1 = Console.ReadLine();
            double a;
            bool isNumber1 = Double.TryParse(numero1, out a);
            double unitPrice1 = a;
            Console.WriteLine("Insert Quantity:");
            string numero2 = Console.ReadLine();
            int b;
            bool isNumber2 = Int32.TryParse(numero2, out b);
            int Quantity1 = b;
            Console.WriteLine("Insert Shipper ID:");
            string ShipperID1 = Console.ReadLine();
            
            orders.Add(new Order(CustomerID1, EmployeeId1, OrderDate1, ProductId1, unitPrice1, Quantity1, ShipperID1));
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.ReadOrder()} \n");
            }
            MenuEmployee.Menu();

        }

        public void ReadOrders()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.ReadOrder()} \n");
            }
            MenuEmployee.Menu();
        }


        public void ReadProductsForClients()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.ReadOrderForClient()} \n");
            }
            MenuEmployee.Menu();
        }

        public void UpdateOrder()
        {
            string OrdersID;
            Console.WriteLine("Insert the Order ID of which order do you want to update info:");
            OrdersID = Console.ReadLine();
            Order fsearch = orders.Find(o => o.ID.Equals(OrdersID));
                if (fsearch != null)
                {
                    Order o = fsearch as Order;
                    Console.WriteLine("ID found!");
                    Console.WriteLine(fsearch.ReadOrder());
                    Console.WriteLine("Which info do you want to update? \n1- Unit Price \n2- Quantity \n3- Back ");
                    string numero1 = Console.ReadLine();
                    int a;
                    bool isNumber1 = int.TryParse(numero1, out a);
                    switch (a)
                    {
                        case 1:
                            o.UpdateUnitPrice();
                            Console.WriteLine(o.ReadOrder());
                            break;
                        case 2:
                            o.UpdateQuantity();
                            Console.WriteLine(o.ReadOrder());
                            break;
                        case 3:
                            MenuEmployee.Menu();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("ID not found!");
                }
                MenuEmployee.Menu();
        }

        public void DeleteOrder()
        {
            string OrdersID;
            Console.WriteLine("Insert the Order ID");
            OrdersID = Console.ReadLine();
            Order fsearch = orders.Find(o => o.ID.Equals(OrdersID));
            if (fsearch != null)
            {
                if (fsearch is Order)
                {
                    Order o = fsearch as Order;
                    Console.WriteLine("Order ID found!");
                    Console.WriteLine(fsearch.ReadOrder());
                    Console.WriteLine("Are you sure that you want to delete this Order? \n 1- Yes \n 2- No");
                    string numeroR1 = Console.ReadLine();
                    int r1;
                    bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                    switch (r1)
                    {
                        case 1:
                            orders.RemoveAll(o => o.ID.Equals(OrdersID));
                            Console.WriteLine("Order successfully removed!");
                            MenuEmployee.Menu();
                            break;
                        case 2:
                            MenuEmployee.Menu();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Order not found");
            }
            MenuEmployee.Menu();
        }


       
    }
}