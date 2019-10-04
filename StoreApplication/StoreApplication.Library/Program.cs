using System;

namespace StoreApplication.Library {
    class Program {
        static void Main(string[] args) {

            int userChoice = 0;

            do {
                MainMenu(userChoice);
            } while (userChoice != 3);

        }

        static void MainMenu(int choice) {
            Console.Clear();
            Console.WriteLine("Welcome To The Video Game Store");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("The Video Game Store\n");

            Console.WriteLine("1. Customer Login");
            Console.WriteLine("2. Store Login");
            Console.WriteLine("3. Exit\n");

            Console.WriteLine("Please Enter Your Choice: ");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice) {
                case 1:
                    CustomerLoginMenu();
                    break;
                case 2:
                    StoreLoginMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Choice Entered");
                    Console.ReadKey();
                    break;
            }

        }

        static void CustomerLoginMenu() {
            Console.Clear();
            Console.WriteLine("1. Place an Order");
            //Add an Option to return to the main menu for all
        }
        static void StoreLoginMenu() {
            Console.Clear();
            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Orders");
        }

        static void StoreLoginCustomersMenu() {            
            Console.Clear();
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. Search Customer By Name");
        }

        static void StoreLoginOrdersMenu() {
            Console.Clear();
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Display Order by Index");
            Console.WriteLine("3. Display Order History of a Store Location");
            Console.WriteLine("4. Display Order History of a Customer");
        }
    }
}
