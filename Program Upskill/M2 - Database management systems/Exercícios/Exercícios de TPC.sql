USE Northwind2016

-- 1 - Which shippers do we have? We have a table called Shippers. 
-- Return all the fields from all the shippers.
Select * From shippers;

--2 - In the Categories table, selecting all the fields using this SQL: "Select * from Categories" will return 4 columns. 
-- We only want to see two columns, CategoryName and Description.
Select Categoryname, Description From Categories; 

--3 - We’d like to see just the FirstName, LastName, and HireDate of all the employees with the Title of Sales Representative. 
--Write a SQL statement that returns only those employees.
Select FirstName, LastName, HireDate  From Employees 
Where Title = 'Sales Representative';

--4 - Now we’d like to see the same columns as above, but only for those employees that both have the title of Sales Representative, and also are in the United States.
Select FirstName, LastName, HireDate  From Employees 
Where Title = 'Sales Representative' and country = 'USA';

--5 - Show all the orders placed by a specific employee. The EmployeeID for this Employee (Steven Buchanan) is 5.
Select Orderid From Orders 
Where EmployeeID = 5;

--6 - In the Suppliers table, show the SupplierID, ContactName, and ContactTitle for those Suppliers whose ContactTitle is not Marketing Manager.
Select SupplierID, ContactName, ContactTitle From Suppliers 
Where contacTtitle != 'Marketing Manager';

--7 - In the products table, we’d like to see the ProductID and ProductName for those products where the ProductName includes the string “queso”.
Select ProductId, ProductName From Products 
Where ProductName like '%queso%';

--8 - Looking at the Orders table, there’s a field called ShipCountry. 
--Write a query that shows the OrderID, CustomerID, and ShipCountry for the orders where the ShipCountry is either France or Belgium. 
Select Orderid, CustomerId, ShipCountry From Orders 
Where ShipCountry = 'France' or  ShipCountry = 'Belgium';

--9 - Now, instead of just wanting to return all the orders from France of Belgium, we want to show all the orders from any Latin American country. 
--But we don’t have a list of Latin American countries in a table in the Northwind database. So, we’re going to just use this list of Latin American countries that happen to be in the Orders table:
--Brazil
--Mexico
--Argentina
--Venezuela It doesn’t make sense to use multiple Or statements anymore, it would get too convoluted. Use the In statement.
--select id, CustomerId, ShipCountry from [Order] where ShipCountry = "Brazil" or  ShipCountry = "Mexico" or  ShipCountry = "Argentina" or  ShipCountry ="Venezuela"
Select orderid, CustomerId, ShipCountry From Orders 
Where ShipCountry in ('Brazil','Mexico','Argentina', 'Venezuela');

--10 - For all the employees in the Employees table, show the FirstName, LastName, Title, and BirthDate. 
-- Order the results by BirthDate, so we have the oldest employees first.
Select FirstName, LastName, Title, BirthDate From Employees 
Order by BirthDate asc;

--11 - In the output of the query above, showing the Employees in order of BirthDate, we see the time of the BirthDate field, which we don’t want. 
--Show only the date portion of the BirthDate field.
Select FirstName, LastName, Title, convert(Date, BirthDate) as BirthDate From Employees 
Order by BirthDate asc;

--12 - Show the FirstName and LastName columns from the Employees table, and then create a new column called FullName, showing FirstName and LastName 
--joined together in one column, with a space in-between.
Select FirstName, LastName, FirstName + ' ' + LastName as Fullname From Employees; 

--13 - In the OrderDetails table, we have the fields UnitPrice and Quantity. Create a new field, TotalPrice, that multiplies these two together. 
--We’ll ignore the Discount field for now. In addition, show the OrderID, ProductID, UnitPrice, and Quantity. Order by OrderID and ProductID.
Select OrderID, ProductID, UnitPrice, Quantity, UnitPrice * Quantity as TotalPrice From [OrderDetails] 
Order by OrderID, ProductID;

-- 14 - How many customers do we have in the Customers table? Show one value only, and don’t rely on getting the recordcount at the end of a resultset.
Select COUNT(CustomerID) as NumberOfCustomer From Customers;

--15 - Show the date of the first order ever made in the Orders table.
--Select Top 1 OrderDate  From Orders;
Select Min(Orderdate) From Orders;

--16 - Show a list of countries where the Northwind company has customers.
Select Distinct Country From Customers;

--17 - Show a list of all the different values in the Customers table for ContactTitles. Also include a count for each ContactTitle. 
--This is similar in concept to the previous question “Countries where there are customers”, except we now want a count for each ContactTitle.
Select Distinct ContactTitle, Count(1) as Occurs From  Customers 
Group by ContactTitle;

--18 - We’d like to show, for each product, the associated Supplier. Show the ProductID, ProductName, and the CompanyName of the Supplier. Sort by ProductID.
Select Products.ProductId, ProductName, CompanyName From  Products 
Inner Join Suppliers
On Products.SupplierId = Suppliers.SupplierId
Order by ProductId;

--19 - We’d like to show a list of the Orders that were made, including the Shipper that was used. Show the OrderID, OrderDate (date only), and CompanyName of the Shipper, 
--and sort by OrderID. In order to not show all the orders (there’s more than 800), show only those rows with an OrderID of less than 10300.
Select OrderID, convert(Date, OrderDate) as OrderDate, CompanyName From Orders 
Inner Join Shippers 
On Orders.ShipVia = Shippers.ShipperID
Where OrderId < 10300
Order by OrderID 

--20 - For this problem, we’d like to see the total number of products in each category. Sort the results by the total number of products, in descending order.
Select  Count(1) as ContagemPorCategoria From  Products 
Group by CategoryID 
Order by count (1) desc;

--21 - In the Customers table, show the total number of customers per Country and City.
Select distinct Country, City, Count(1) as Occurs From  Customers 
Group by Country, city;
--Order by Country, city;

--22 - What products do we have in our inventory that should be reordered? For now, just use the fields UnitsInStock and ReorderLevel, 
--where UnitsInStock is less than the ReorderLevel, ignoring the fields UnitsOnOrder and Discontinued. Order the results by ProductID.
Select ProductID, ProductName as ProductsNeedReording,  ReorderLevel, UnitsInStock From Products 
Where UnitsInStock < ReorderLevel
Order by ProductID;

--23 - Now we need to incorporate these fields—UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued—into our calculation. We’ll define “products that need reordering” with the following:
--UnitsInStock plus UnitsOnOrder are less than or equal to ReorderLevel
--The Discontinued flag is false (0).
Select ProductID, ProductName as ProductsNeedReording From Products 
Where UnitsInStock + UnitsOnOrder <= ReorderLevel and Discontinued = 0
Order by ProductID;

--24 - A salesperson for Northwind is going on a business trip to visit customers, and would like to see a list of all customers, sorted by region, alphabetically. 
--However, he wants the customers with no region (null in the Region field) to be at the end, instead of at the top, where you’d normally find the null values. 
--Within the same region, companies should be sorted by CustomerID.
 Select CustomerID, CompanyName, Region From Customers
 Order by Case When Region is null then 1 
          Else 0
 End,Region, CustomerID;


--25 - Some of the countries we ship to have very high freight charges. We'd like to investigate some more shipping options for our customers, 
--to be able to offer them lower freight charges. Return the three ship countries with the highest average freight overall, in descending order by average freight.
Select Top 3 ShipCountry, AverageFreight = Avg(Freight)  From Orders
Group by ShipCountry
Order by AverageFreight Desc;

--26 - We're continuing on the question above on high freight charges. Now, instead of using all the orders we have, we only want to see orders from the year 2015.
Select Top 3 ShipCountry, AverageFreight = Avg(Freight)  From Orders
Where OrderDate LIKE '%2015%'
Group by ShipCountry
Order by AverageFreight Desc;

--27 - Another (incorrect) answer to the problem above is this:
--Select Top 3
--    ShipCountry
--    ,AverageFreight = avg(freight)
--From Orders
--Where
--    OrderDate between '1/1/2015' and '12/31/2015'
--Group By ShipCountry
--Order By AverageFreight desc;
--Notice when you run this, it gives Sweden as the ShipCountry with the third highest freight charges. However, this is wrong - it should be France. 
--What is the OrderID of the order that the (incorrect) answer above is missing?
Select Top 3 ShipCountry, AverageFreight = Avg(Freight)  From Orders
Where OrderDate LIKE '%2015%'
Group by ShipCountry
Order by AverageFreight Desc;
-- The OrderDate between '1/1/2015' and '12/31/2015' don´t select the two orders from the day: 12/31/2015

--28 - We're continuing to work on high freight charges. We now want to get the three ship countries with the highest average freight charges. 
--But instead of filtering for a particular year, we want to use the last 12 months of order data, using as the end date the last OrderDate in Orders.
Select Top 3 ShipCountry, AverageFreight = Avg(Freight)  From Orders
Where orderdate >= '06/05/2015' and  orderdate <=  '06/05/2016'
Group by ShipCountry
Order by AverageFreight Desc;

--Tentativa falhada:
--Select Top 3 ShipCountry, AverageFreight = Avg(Freight)  from Orders
--Where orderdate >= (select max(orderdate),'-12 month') and  orderdate <=  (select max(orderdate) from Orders)
--Group by ShipCountry
--Order by AverageFreight Desc



--29 - We're doing inventory, and need to show information like the below, for all orders. Sort by OrderID and Product ID.
Select  Employees.EmployeeId, LastName, Orders.OrderID, ProductName, Quantity From Orderdetails
Inner Join Products
On Products.ProductID = Orderdetails.ProductID
Inner Join Orders
On Orderdetails.OrderId = Orders.OrderId
Inner Join Employees
On Employees.EmployeeId = Orders.EmployeeId
Order by OrderID, Products.ProductID;

--30 - There are some customers who have never actually placed an order. Show these customers.
Select Customers.ContactName, Orders.OrderID From Customers
Full Outer Join Orders
On Orders.CustomerID = Customers.CustomerID
Where OrderID is null;

--31 - One employee (Margaret Peacock, EmployeeID 4) has placed the most orders. However, there are some customers who've never placed an order with her. 
--Show only those customers who have never placed an order with her.
Select ContactName as CustomerName, OrderID,  Employees.EmployeeID, FirstName +' ' + LastName as EmployeesName From Orders
Inner Join Customers
On Orders.CustomerID = Customers.CustomerID
Inner Join Employees
On  Orders.EmployeeID = Employees.EmployeeID
Where Employees.EmployeeID !=4;
