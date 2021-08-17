using System;

namespace Store
{
    class Products
    {
        public static int productID;
        public string ID { get; set; }
        public string productName { get; set; }
        public double unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder { get; set; }
        public int reorderLevel { get; set; }
        public int shipperID { get; set; }


        public Products(string productName, double unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, int shipperID)
        {
            this.ID = "P" + GetNextID();
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.unitsInStock = unitsInStock;
            this.unitsOnOrder = unitsOnOrder;
            this.reorderLevel = reorderLevel;
            this.shipperID = shipperID;
        }

        static Products() => productID = 2020000;
        protected int GetNextID() => ++productID;
        
        public string ReadProduct() //Descrição do produto
        {
            return $"ID: {ID} - {productName}  \nUnit Price:{unitPrice}  \nUnits in Stock: {unitsInStock} \nReorder Level: {reorderLevel} \nShipper ID: {shipperID}";
        }

        public string ReadProductForClients() //Descrição do produto para clientes
        {
            return $"ID: {ID} - {productName}  \nUnit Price:{unitPrice}";
        }

        public void UpdateUnitPrice()
        {
            Console.WriteLine("Insert Unit Price!");
            string numero1 = Console.ReadLine();
            double unitPrice;
            bool isNumber1 = Double.TryParse(numero1, out unitPrice);
            this.unitPrice = unitPrice;
            Console.WriteLine("Unit Price successfully Updated!");
        }

        public void UpdateUnitsInStock()
        {
            Console.WriteLine("Insert Units in stock!");
            string numero1 = Console.ReadLine();
            int unitsInStock;
            bool isNumber1 = int.TryParse(numero1, out unitsInStock);
            this.unitsInStock = unitsInStock;
            Console.WriteLine("Unit in stock successfully Updated!");
        }

        public void UpdateUnitsOnOrder()
        {
            Console.WriteLine("Insert Unit in order!");
            string numero1 = Console.ReadLine();
            int unitsOnOrder;
            bool isNumber1 = int.TryParse(numero1, out unitsOnOrder);
            this.unitsOnOrder = unitsOnOrder;
            Console.WriteLine("Unit in order successfully Updated!");
        }

      
    }
}