using System;
using System.Collections.Generic;
using StoreApplication.Library;

namespace StoreApplication.App
{
    class Application
    {

        static string jsonFilePathCustomers = @"C:\revature\angad-project0\StoreApplication\JSONData\Customers.json";
        static string jsonFilePathProducts = @"C:\revature\angad-project0\StoreApplication\JSONData\Products.json";

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
            Console.WriteLine("3. Exit\n");

            Console.WriteLine("Please Enter Your Choice: ");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CustomersMenu();
                    break;
                case 2:
                    StoreManagementMenu();
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
                Console.WriteLine("2. Place an Order");
                Console.WriteLine("3. View All Customers");
                Console.WriteLine("4. Search Customer By Name");
                Console.WriteLine("5+. Go Back");
                Console.WriteLine("Enter Your Choice: ");
                menuChoice = Int32.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        customer.AddCustomer(jsonFilePathCustomers);
                        break;
                    case 3:
                        customer.DisplayCustomers(jsonFilePathCustomers);
                        break;
                    case 4:
                        customer.SearchByName(jsonFilePathCustomers);
                        break;
                }

            } while (menuChoice < 5);


            //Add an Option to return to the main menu for all
        }

        static void StoreManagementMenu()
        {
            Product product = new Product();
            int menuChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. View All Orders");
                Console.WriteLine("2. Display Order by Index");
                Console.WriteLine("3. Display Order History of a Store Location");
                Console.WriteLine("4. Display Order History of a Customer");
                Console.WriteLine("5. Add New Product");
                Console.WriteLine("6. Display All Products");

                Console.WriteLine("Enter Your Choice: ");
                menuChoice = Int32.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 5:
                        product.AddProducts(jsonFilePathProducts);
                        break;
                    case 6:
                        product.DisplayProducts(jsonFilePathProducts);
                        break;
                }

            } while (menuChoice < 5);

        }

    }
}
