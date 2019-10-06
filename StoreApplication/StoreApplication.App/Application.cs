using System;

namespace StoreApplication.App {
    class Application {
        static void Main(string[] args) {

            int userChoice = 0;

            do {
                MainMenu(userChoice);
            } while (userChoice != 3);

        }

        static void MainMenu(int choice) {
            Console.Clear();

            Console.WriteLine("The Video Game Store\n");

            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Store Management");
            Console.WriteLine("3. Exit\n");

            Console.WriteLine("Please Enter Your Choice: ");
            choice = Int32.Parse(Console.ReadLine());

            switch (choice) {
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
                    Console.ReadKey();
                    break;
            }

        }

        static void CustomersMenu() {
            Console.Clear();
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Place an Order");
            Console.WriteLine("3. View All Customers");
            Console.WriteLine("4. Search Customer By Name");
            //Add an Option to return to the main menu for all
        }

        static void StoreManagementMenu() {
            Console.Clear();
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Display Order by Index");
            Console.WriteLine("3. Display Order History of a Store Location");
            Console.WriteLine("4. Display Order History of a Customer");
        }
    }
}
