using System;
using System.Collections.Generic;
using StoreApplication.Library;

namespace StoreApplication.App
{
    class Application
    {

        static string jsonFilePathCustomers = @"C:\revature\angad-project0\StoreApplication\JSONData\Customers.json";
        static string jsonFilePathProducts = @"C:\revature\angad-project0\StoreApplication\JSONData\Products.json";
        static string jsonFilePathOrders = @"C:\revature\angad-project0\StoreApplication\JSONData\Orders.json";

        static void Main(string[] args)
        {

            int userChoice = 0;

            do
            {
                MainMenu(userChoice);
            } while (userChoice != 3);

        }

        static void MainMenu(int choice)
        {
            Console.Clear();

            Console.WriteLine("The Video Game Store\n");

            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Store Management");
            Console.WriteLine("3. Exit");

            Console.WriteLine("\nPlease Enter Your Choice: ");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CustomersMenu();
                    break;
                case 2:
                    //StoreManagementMenu();
                    StoreManagement();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Choice Entered");
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    break;
            }

        }

        static void CustomersMenu()
        {
            Customer customer = new Customer();

            int menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View All Customers");
                Console.WriteLine("3. Search Customer By Name");
                Console.WriteLine("4+. Go Back");

                Console.WriteLine("\nEnter Your Choice: ");
                menuChoice = Int32.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        customer.AddCustomer(jsonFilePathCustomers);
                        break;
                    case 2:
                        customer.DisplayCustomers(jsonFilePathCustomers);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        customer.SearchByName(jsonFilePathCustomers);
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ReadKey();
                        break;
                }

            } while (menuChoice < 4);

        }

        static void StoreManagement()
        {
            int menuChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Manage Orders");
                Console.WriteLine("2. Manage Products");
                Console.WriteLine("3+. Go Back");

                Console.WriteLine("\nEnter Your Choice: ");
                menuChoice = Int32.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        ManageOrdersMenu();
                        break;
                    case 2:
                        ManageProductsMenu();
                        break;

                }
            } while (menuChoice < 3);
        }

        static void ManageProductsMenu()
        {
            int menuChoice = 0;
            Product product = new Product();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Display All Products");
                Console.WriteLine("3+. Go Back");

                Console.WriteLine("\nEnter Your Choice: ");
                menuChoice = Int32.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        product.AddProducts(jsonFilePathProducts);
                        break;
                    case 2:
                        product.DisplayProducts(jsonFilePathProducts);
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ReadKey();
                        break;
                }
            } while (menuChoice < 3);
        }

        static void ManageOrdersMenu()
        {
            Product product = new Product();
            Order order = new Order();
            int menuChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create an Order");
                Console.WriteLine("2. View All Orders");
                Console.WriteLine("3. Display Order by Index");
                Console.WriteLine("4. Display Order History of a Store Location");
                Console.WriteLine("5. Display Order History of a Customer");
                Console.WriteLine("6+. Go Back");

                Console.WriteLine("\nEnter Your Choice: ");
                menuChoice = Int32.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        order.CreateOrder(jsonFilePathOrders, jsonFilePathCustomers, jsonFilePathProducts);
                        break;
                    case 2:
                        order.DisplayOrders(jsonFilePathOrders);
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ReadKey();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                }

            } while (menuChoice < 6);

        }

    }
}
