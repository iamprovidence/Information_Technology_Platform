﻿using System;
using System.Data.SqlClient;

namespace Task4
{
    class Program
    {
        static readonly string CONNECTION_STRING_RESOURCE_NAME = "NorthwindConnectionString";

        static void Main(string[] args)
        {
            // initialize connection
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTION_STRING_RESOURCE_NAME].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            // initialize commands
            SqlCommand command = connection.CreateCommand();


            // TASK
            // 1
            Console.WriteLine("First Part");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show all info about the employee with ID 8\n");

            command.CommandText = "SELECT * FROM Employees WHERE EmployeeID = 8;";
            throw new NotImplementedException();

            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of first and last names of the employees from London\n");

            command.CommandText = "SELECT FirstName, LastName FROM Employees WHERE City='London';";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader["FirstName"], reader["LastName"]);
                }
            }
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of first and last names of the employees whose first name begins with letter A\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of first, last names and ages of the employees whose age is greater than 55."
                + " The result should be sorted by last name \n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Calculate the count of employees from London\n");

            command.CommandText = "SELECT COUNT(*) AS EmployeesAmount FROM Employees WHERE City='London';";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["EmployeesAmount"]);
                }
            }

            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Calculate the greatest, the smallest and the average age among the employees from London\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Calculate the greatest, the smallest and the average age of the employees for each city\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of cities in which the average age of employees is greater than 60(the average age is also to be shown)\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the first and last name(s) of the eldest employee(s)\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show first, last names and ages of 3 eldest employees\n");

            throw new NotImplementedException();
            Console.ReadLine();

            // 2
            Console.Clear();
            Console.WriteLine("Second part\n\n");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of all cities where the employees are from 0\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show first, last names and dates of birth of the employees who celebrate their birthdays this month\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show first and last names of the employees who used to serve orders shipped to Madrid\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show first and last names of the employees "
                + "as well as the count of orders each of them have received during the year 1997(use left join)\n");

            command.CommandText = string.Concat("SELECT E.FirstName, E.LastName, COUNT(O.EmployeeID) AS OrdersAmount ",
                                                "FROM Employees AS E ",
                                                "LEFT JOIN Orders AS O ON O.EmployeeID = E.EmployeeID ",
                                                "WHERE O.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' ",
                                                "GROUP BY E.FirstName, E.LastName;");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0,-10}{1,-10}{2}", reader["FirstName"], reader["LastName"], reader["OrdersAmount"]);
                }
            }

            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show first and last names of the employees "
                + "as well as the count of orders each of them have received during the year 1997\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show first and last names of the employees "
                + "as well as the count of their orders shipped after required date during the year 1997(use left join)\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the count of orders made by each customer from France\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of french customers’ names who have made more than one order(use grouping)\n");

            command.CommandText = String.Concat("SELECT C.ContactName ",
                                                "FROM Customers AS C, Orders AS O ",
                                                "WHERE C.Country = 'France' ",
                                                "GROUP BY C.ContactName ",
                                                "HAVING COUNT (O.CustomerID) > 1;");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ContactName"]);
                }
            }

            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of french customers’ names who have made more than one order\n");

            throw new NotImplementedException();
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Show the list of customers’ names who used to order the ‘Tofu’ product\n");

            throw new NotImplementedException();
            Console.ReadLine();

            //3
            #region Part 3
            Console.Clear();
            Console.WriteLine("Third part\n\n");
            Console.ReadLine();


            #region Show the list of customers’ names who used to order the ‘Tofu’ product + along with the total amount of the product they have ordered and with the total sum for ordered product calculated
            Console.Clear();
            Console.WriteLine("Show the list of customers’ names who used to order the ‘Tofu’ product,"
                + "along with the total amount of the product they have ordered and with the total sum for ordered product calculated\n");

            command.CommandText = string.Concat("SELECT C.ContactName, COUNT(*) AS Count, SUM(OD.UnitPrice*OD.Quantity) AS PriceSum",
                                                "FROM Customers as C ",
                                                "LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID ",
                                                "JOIN [Oreder Details] AS OD ON AS.OrderId = O.OrderId ",
                                                "WHERE O.ProductName = 'Tofu' ",
                                                "GROUP BY C.ContatcName;");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ContactName"]} {reader["Count"]} {reader["PriceSum"]}");
                }
            }

            Console.ReadLine();
            #endregion

            #region Show the list of french customers’ names who used to order non - french products(use left join)
            Console.Clear();
            Console.WriteLine("Show the list of french customers’ names who used to order non - french products(use left join)\n");

            command.CommandText = string.Concat("SELECT C.ContactName ",
                                                "FROM Customers as C ",
                                                "LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID ",
                                                "WHERE O.ShipCountry <> 'France' AND C.Country ='France'");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ContactName"]);
                }
            }
            Console.ReadLine();
            #endregion

            #region Show the list of french customers’ names who used to order non - french products
            Console.Clear();
            Console.WriteLine("Show the list of french customers’ names who used to order non - french products\n");

            command.CommandText = string.Concat("SELECT C.ContactName ",
                                               "FROM Customers as C ",
                                               "LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID ",
                                               "WHERE O.ShipCountry <> 'France' AND C.Country ='France'");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ContactName"]);
                }
            }

            Console.ReadLine();
            #endregion

            #region Show the list of french customers’ names who used to order french products
            Console.Clear();
            Console.WriteLine("Show the list of french customers’ names who used to order french products\n");

            command.CommandText = string.Concat("SELECT C.ContactName ",
                                                "FROM Customers AS C ",
                                                "LEFT JOIN Orders AS O ON C.CustomerID = O.CustomerID ",
                                                "WHERE O.ShipCountry='France' AND C.Country ='France';");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ContactName"]);
                }
            }

            Console.ReadLine();
            #endregion

            #region Show the total ordering sum calculated for each country of customer
            Console.Clear();
            Console.WriteLine("Show the total ordering sum calculated for each country of customer\n");

            command.CommandText = String.Concat("SELECT C.Country, SUM(OD.UnitPrice) AS TotalPrice ",
                                                "FROM Customers AS C ",
                                                "LEFT JOIN Orders AS O ON O.CustomerID = C.CustomerID ",
                                                "LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID ",
                                                "GROUP BY C.Country;");
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0,-20}{1}", reader["Country"], reader["TotalPrice"]);
                }
            }

            Console.ReadLine();
            #endregion

            #region Show the total ordering sums calculated + for each customer’s country for domestic and non - domestic products separately + e.g.: “France – French products ordered – Non - french products ordered” and so on for each country)
            Console.Clear();
            Console.WriteLine("Show the total ordering sums calculated "
                + "for each customer’s country for domestic and non - domestic products separately"
                + "(e.g.: “France – French products ordered – Non - french products ordered” and so on for each country)\n");

            command.CommandText = string.Concat("SELECT C.ContactName AS Name, SUM(OD.UnitPrice*OD.Quantity) AS Domestic, SUM(OD.UnitPrice*OD.Quantity) AS NonDomestic ",
                "LEFT JOIN Orders AS O ON O.CustomerID = C.CustomerID ",
                "WHERE O.ShipCountry = C.Country ",
                "LEFT JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID ",
                "LEFT JOIN O ON O.CustomerID = C.CustomerID ",
                "WHERE O.ShipCountry <> C.Country ",
                "LEFT JOIN OD ON O.OrderID = OD.OrderID ",
                "GROUP BY Name;");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} {reader["Domestic"]} {reader["NonDomestic"]}");
                }
            }
            Console.ReadLine();
            #endregion

            //not inplemented
            #region Show the list of product categories + along with total ordering sums calculated for the orders made for the products of each category, during the year 1997
            Console.Clear();
            Console.WriteLine("Show the list of product categories "
                + "along with total ordering sums calculated for the orders made for the products of each category, "
                + "during the year 1997\n");

            Console.ReadLine();
            #endregion

            //not inplemented
            #region Show the list of product names along with unit prices + ...
            Console.Clear();
            Console.WriteLine("Show the list of product names along with unit prices "
                + "and the history of unit prices taken from the orders (show ‘Product name – Unit price – Historical price’)."
                + "The duplicate records should be eliminated."
                + "If no orders were made for a certain product, then the result for this product should look like "
                + "‘Product name – Unit price – NULL’."
                + "Sort the list by the product name\n");

            throw new NotImplementedException();
            Console.ReadLine();
            #endregion

            #region Show the list of employees’ names along with names of their chiefs(use left join with the same table)
            Console.Clear();
            Console.WriteLine("Show the list of employees’ names along with names of their chiefs(use left join with the same table)\n");

            command.CommandText = string.Concat("SELECT E.LastName AS Name, E.ReportsTo AS Chief FROM Employess AS E ",
                "LEFT JOIN E ON E.ReportsTo = E.EmployeeID;");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} {reader["Chief"]}");
                }
            }

            Console.ReadLine();
            #endregion

            //not inplemented
            #region Show the list of cities where employees and customers are from and where orders have been made to. Duplicates should be eliminated
            Console.Clear();
            Console.WriteLine("Show the list of cities where employees and customers are from and where orders have been made to."
                + "Duplicates should be eliminated\n");

            throw new NotImplementedException();
            Console.ReadLine();
            #endregion
            #endregion

            // 4
            #region Part 4
            Console.Clear();
            Console.WriteLine("Fourth part\n\n");
            Console.ReadLine();

            #region Insert 5 new records into Employees table
            Console.Clear();
            Console.WriteLine("Insert 5 new records into Employees table."
                + "Fill in the following  fields: LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes."
                + "The Notes field should contain your own name\n");

            command.CommandText = String.Concat(
                "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes) ",
                "VALUES ",
                "('John', 'Doe', '1990-01-01', '2000-01-01', 'Baker Street 221B', 'London', 'United Kingdom', 'Adam'), ",
                "('Jane', 'Doe', '1990-01-01', '2000-01-01', 'Baker Street 221B', 'London', 'United Kingdom', 'Adam'), ",
                "('Mike', 'Ross', '1990-01-01', '2000-01-01', 'Baker Street 221B', 'London', 'United Kingdom', 'Adam'), ",
                "('Cris', 'Freel', '1990-01-01', '2000-01-01', 'Baker Street 221B', 'London', 'United Kingdom', 'Adam'), ",
                "('Beverly', 'Lunsford', '1990-01-01', '2000-01-01', 'Baker Street 221B', 'London', 'United Kingdom', 'Adam');");

            Console.WriteLine($"Inserted {command.ExecuteNonQuery()} rows");

            Console.ReadLine();
            #endregion

            #region Fetch the records you have inserted by the SELECT statement
            Console.Clear();
            Console.WriteLine("Fetch the records you have inserted by the SELECT statement\n");

            command.CommandText = string.Concat("SELECT LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes FROM Employess;");

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["LastName"]} {reader["FirstName"]} {reader["BirthDate"]} {reader["HireDate"]} {reader["Address"]} {reader["City"]} {reader["Country"]} {reader["Notes"]}");
                }
            }
            Console.ReadLine();
            #endregion

            #region Change the City field in one of your records using the UPDATE statement
            Console.Clear();
            Console.WriteLine("Change the City field in one of your records using the UPDATE statement\n");

            command.CommandText = string.Concat("UPDATE Employess ",
                "SET City = 'Lexington' ",
                "WHERE LasTName = 'Mike';");

            Console.WriteLine($"Update {command.ExecuteNonQuery()} row");

            Console.ReadLine();
            #endregion

            #region Change the HireDate field in all your records to current date
            Console.Clear();
            Console.WriteLine("Change the HireDate field in all your records to current date\n");

            command.CommandText = string.Concat("UPDATE Employess ",
                "SET HireDate = '2018-11-18';");

            Console.WriteLine($"Update {command.ExecuteNonQuery()} row");

            Console.ReadLine();
            #endregion

            #region Delete one of your records
            Console.Clear();
            Console.WriteLine("Delete one of your records\n");

            command.CommandText = "DELETE FROM Employees WHERE LastName='John' AND FirstName='Doe';";
            Console.WriteLine("Deleted {0} rows", command.ExecuteNonQuery());

            Console.ReadLine();
            #endregion 
            #endregion

            // dispose
            command.Dispose();
            connection.Close();
        }
    }
}
