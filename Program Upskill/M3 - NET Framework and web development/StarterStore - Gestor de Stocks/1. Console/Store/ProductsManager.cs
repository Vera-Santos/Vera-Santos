using System;
using System.Collections.Generic;



namespace Store
{
    public class ProductsManager
    {
        private static List<Products> products;

        public ProductsManager()
        {
            products = new List<Products>();
            //Products(productName, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, shipperID)
            products.Add(new Products("Danone", 1.00, 0, 100, 5, 1));
            products.Add(new Products("Mimosa", 1.00, 5, 100, 5, 2));
            products.Add(new Products("Luso", 3.50, 100, 100, 5, 3));
        }


        public void CreateProduct()
        {
            Console.WriteLine("Insert the product name:");
            string productName1 = Console.ReadLine();
            Console.WriteLine("Insert unit price:");
            string numero1 = Console.ReadLine();
            double a;
            bool isNumber1 = Double.TryParse(numero1, out a);
            double unitPrice1 = a;
            Console.WriteLine("Insert units is stock:");
            string numero2 = Console.ReadLine();
            int b;
            bool isNumber2 = Int32.TryParse(numero2, out b);
            int unitsInStock1 = b;
            Console.WriteLine("Insert units is order:");
            string numero3 = Console.ReadLine();
            int c;
            bool isNumber3 = Int32.TryParse(numero3, out c);
            int unitsOnOrder1 = c;
            Console.WriteLine("Insert reorder level:");
            string numero4 = Console.ReadLine();
            int d;
            bool isNumber4 = Int32.TryParse(numero4, out d);
            int reorderLevel1 = d;
            Console.WriteLine("Insert Shipper ID:");
            string numero5 = Console.ReadLine();
            int e;
            bool isNumber5 = Int32.TryParse(numero5, out e);
            int shipperID1 = e;
            products.Add(new Products(productName1, unitPrice1, unitsInStock1, unitsOnOrder1, reorderLevel1, shipperID1));          
            foreach (Products product in products)
            {
                Console.WriteLine($"{product.ReadProduct()} \n");
            }
            MenuEmployee.Menu();
            
        }
        
        public void ReadProducts()
        {
            foreach (Products product in products)
            {
                Console.WriteLine($"{product.ReadProduct()} \n");
            }
            MenuEmployee.Menu();
        }


        public void ReadProductsForClients()
        {
            foreach (Products product in products)
            {
                Console.WriteLine($"{product.ReadProductForClients()} \n");
            }
        }

        public void UpdateProduct()
        {
            string fullNameProduct;
            Console.WriteLine("Insert the fullname of which product do you want to update info:");
            fullNameProduct = Console.ReadLine();
            Products fsearch = products.Find(p => p.productName.Equals(fullNameProduct));
               if (fsearch != null)
               {
                    Products p = fsearch as Products;
                    Console.WriteLine("Name found!");
                    Console.WriteLine(fsearch.ReadProduct());
                    Console.WriteLine("Which info do you want to update? \n1- Unit Price \n2- Units in Stock \n3- Units in Order \n4- Back ");
                    string numero1 = Console.ReadLine();
                    int a;
                    bool isNumber1 = int.TryParse(numero1, out a);
                        switch (a)
                        {
                            case 1:
                                p.UpdateUnitPrice();
                                Console.WriteLine(p.ReadProduct());
                                break;
                            case 2:
                                p.UpdateUnitsInStock();
                                Console.WriteLine(p.ReadProduct());
                                break;
                            case 3:
                                p.UpdateUnitsOnOrder();
                                Console.WriteLine(p.ReadProduct());
                                break;
                            case 4:
                                MenuEmployee.Menu();
                            break;
                    } 
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }
                MenuEmployee.Menu();
        }

        public void DeleteProduct()
        {
            string fullNameProduct;
            Console.WriteLine("Insert the Product name");
            fullNameProduct = Console.ReadLine();
            Products fsearch = products.Find(p => p.productName.Equals(fullNameProduct));
            if (fsearch != null)
            {
                if (fsearch is Products)
                {
                    Products p = fsearch as Products;
                    Console.WriteLine("Product found!");
                    Console.WriteLine(fsearch.ReadProduct());
                    Console.WriteLine("Are you sure that you want to delete this Product? \n 1- Yes \n 2- No");
                    string numeroR1 = Console.ReadLine();
                    int r1;
                    bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                    switch (r1)
                    {
                        case 1:
                            products.RemoveAll(p => p.productName.Equals(fullNameProduct));
                            Console.WriteLine("Product  successfully removed!");
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
                    Console.WriteLine("Product not found");
            }
            MenuEmployee.Menu();
        }


        public void ViewStock()
        {
            foreach (Products product in products)
            {
                 if (product.unitsInStock <= product.reorderLevel)
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine("----->This product needs to be reorder!<-----");  
                    Console.WriteLine($"{product.ReadProduct()} \n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("----->This product doesn´t need to be reorder!<-----"); 
                    Console.WriteLine($"{product.ReadProduct()} \n");
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
            MenuManager.Menu();
        }

        public void Ordering()
        {
            foreach (Products product in products)
            {
                if (product.unitsInStock <= product.reorderLevel)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("----->This product needs to be reorder!<-----");
                    Console.WriteLine($"{product.ReadProduct()} \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Do you want to order this products? \n 1- Yess \n 2- No");
                    string numeroR1 = Console.ReadLine();
                    int r1;
                    bool isNumberR1 = Int32.TryParse(numeroR1, out r1);
                    switch (r1)
                    {
                        case 1:
                            Console.WriteLine($"Please check the contact of this ShipperID:{ product.shipperID} ");
                            break;
                        case 2:
                            break;
                    }
                }
            }
            MenuManager.Menu();
        }
    }
}