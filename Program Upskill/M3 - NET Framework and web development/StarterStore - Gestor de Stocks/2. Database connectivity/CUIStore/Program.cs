using System;
using Store;

namespace CUIStore
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            SqlServer.ConnectToSqlServer();
            
            
            /*Manager<Customer> customerList = Manager<Customer>.Instance;

                
            foreach (Customer c in customerList)
            {
                Console.WriteLine(c);
            }*/
            
            //*****************************************************
           
            /*Manager<Employee> employeeList = Manager<Employee>.Instance;


            foreach (Employee e in employeeList)
            {
                Console.WriteLine(e);
            }*/
            
            //*****************************************************
           
            /*Manager<Supplier> supplierList = Manager<Supplier>.Instance;


            foreach (Supplier s in supplierList)
            {
                Console.WriteLine(s);
            }*/

             //*****************************************************
           
            /*Manager<Product> productList = Manager<Product>.Instance;


            foreach (Product p in productList)
            {
                Console.WriteLine(p);
            }*/

            //Manager<Employee>.Create(Employee, t);
        }
    }
}


