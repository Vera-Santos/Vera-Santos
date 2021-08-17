using System;

namespace Store
{
    class Order
    {
        public static int ordersID;
        public string ID { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeId { get; set; }
        public string OrderDate { get; set; }
        public string ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string ShipperID { get; set; }



        public Order(string CustomerID, string EmployeeId, string OrderDate, string ProductId, double UnitPrice, int Quantity, string ShipperID)
        {
            this.ID = "O" + GetNextID();
            this.CustomerID = CustomerID;
            this.EmployeeId = EmployeeId;
            this.OrderDate = OrderDate;
            this.ProductId = ProductId;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.TotalPrice = UnitPrice * Quantity;
            this.ShipperID = ShipperID;
        }

        static Order() => ordersID = 2020000;
        protected int GetNextID() => ++ordersID;
        
        public string ReadOrder() //Descrição do produto
        {
            return $"ID: {ID} - Customer - {CustomerID}  Employee - {EmployeeId}  \nOrderDate:{OrderDate}  \nProduct Id: {ProductId}, Unit Price:{UnitPrice} Quantity:{Quantity} TotalPrice: {TotalPrice} \nShipperID: {ShipperID}";
        }

        public string ReadOrderForClient() //Descrição do produto
        {
            return $"ID: {ID} - Customer - {CustomerID}  \nOrderDate:{OrderDate}  \nProduct Id: {ProductId}, Unit Price:{UnitPrice} Quantity:{Quantity} TotalPrice: {TotalPrice}";
        }

        public void UpdateUnitPrice()
        {
            Console.WriteLine("Insert Unit Price!");
            string numero1 = Console.ReadLine();
            double UnitPrice;
            bool isNumber1 = Double.TryParse(numero1, out UnitPrice);
            this.UnitPrice = UnitPrice;
            Console.WriteLine("Unit Price successfully Updated!");
        }

        public void UpdateQuantity()
        {
            Console.WriteLine("Insert Quantity:");
            string numero1 = Console.ReadLine();
            int Quantity;
            bool isNumber1 = int.TryParse(numero1, out Quantity);
            this.Quantity = Quantity;
            Console.WriteLine("Quantity successfully Updated!");
        }

      
      
    }
}