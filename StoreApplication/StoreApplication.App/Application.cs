using System;
using System.Collections.Generic;
using StoreApplication.Library;
using StoreApplication.Data;

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
            CustomerData custData = new CustomerData();

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
                        
                        Console.Clear();
                        string fullName;
                        Console.WriteLine("Add Customer\n");
                        Console.WriteLine("Enter The Name: ");
                        fullName = Console.ReadLine();

                        custData.AddCustomer(jsonFilePathCustomers, fullName);

                        if (custData.nameHolder.Length == 2)
                        {
                            Console.WriteLine("Added Customer {0}", fullName);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Name Entered");
                        }
                        Console.WriteLine("Press Any Key To Continue: ");
                        Console.ReadKey();
                        break;
                    case 2:

                        Console.Clear();
                        List<Customer> tempData = new List<Customer>();
                        tempData = custData.DisplayCustomers(jsonFilePathCustomers);

                        Console.Clear();
                        Console.WriteLine("Customers");
                        if (tempData.Count != 1)
                        {
                            for (int i = 0; i < tempData.Count; i++)
                            {
                                Console.WriteLine(" {0}. {1} {2}", i + 1, tempData[i].FirstName, tempData[i].LastName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Data Present");
                        }

                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:

                        Console.Clear();
                        string searchName;
                        Console.WriteLine("Please Enter a First or a Last Name To Search");
                        searchName = Console.ReadLine();

                        List<Customer> tempDisplay = new List<Customer>();

                        tempDisplay = custData.DisplayCustomers(jsonFilePathCustomers);

                        for (int i = 0; i < tempDisplay.Count; i++)
                        {
                            if (tempDisplay[i].FirstName.Equals(searchName) || tempDisplay[i].LastName.Equals(searchName))
                            {
                                Console.WriteLine(" {0}. {1} {2}", i + 1, tempDisplay[i].FirstName, tempDisplay[i].LastName);
                            }
                            else
                            {
                                custData.searchCount++;
                            }
                        }

                        if (custData.searchCount == tempDisplay.Count)
                        {
                            Console.Clear();
                            Console.WriteLine("No Such Record Present");
                        }

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
            ProductData prodData = new ProductData();

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
                        Console.Clear();

                        string productName, productType, storeLocation = "";
                        int storeCount, inventoryForLoc = 0;
                        List<string> storeLocationList = new List<string>();
                        List<int> storeInventoryList = new List<int>();

                        Console.WriteLine("Enter Product Name: ");
                        productName = Console.ReadLine();

                        Console.WriteLine("Enter Product Type: ");
                        productType = Console.ReadLine();

                        Console.WriteLine("How many Stores? ");
                        storeCount = Int32.Parse(Console.ReadLine());

                        for (int i = 0; i < storeCount; i++) // NEED TO FIX SINCE IT'S ONLY INPUTTING THE LAST VALUE
                        {
                            Console.WriteLine("Store Location {0}: ", i + 1);
                            storeLocation = Console.ReadLine();
                            storeLocationList.Add(storeLocation);
                            Console.WriteLine("Inventory for the {0} Store", storeLocation);
                            inventoryForLoc = Int32.Parse(Console.ReadLine());
                            storeInventoryList.Add(inventoryForLoc);
                        }

                        prodData.AddProducts(jsonFilePathProducts, productName, productType, storeLocation, inventoryForLoc, storeCount, storeLocationList, storeInventoryList);

                        Console.WriteLine("Added Product {0} of type {1} to {2} stores", productName, productType, storeCount);
                        Console.ReadKey();

                        break;
                    case 2:
                        List<Product> tempDisplayProduct = new List<Product>();
                        tempDisplayProduct = prodData.DisplayProducts(jsonFilePathProducts);
                        Console.Clear();
                        Console.WriteLine("Products");
                        if (tempDisplayProduct.Count != 0)
                        {
                            for (int i = 0; i < tempDisplayProduct.Count; i++)
                            {
                                Console.WriteLine(" {0}. {1} | ID: {2}", i + 1, tempDisplayProduct[i].ProductName, tempDisplayProduct[i].Id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Data Present");
                        }
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ReadKey();
                        break;
                }
            } while (menuChoice < 3);
        }

        static void ManageOrdersMenu()
        {
            Order order = new Order();
            OrderData orderData = new OrderData();
            ProductData dataProduct = new ProductData();
            CustomerData dataCustomer = new CustomerData();

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

                        int selectProd, selectCust, citySelect;
                        int quant = 0;
                        string dateString;

                        bool allowedCity = true, allowedQuant = true, allowedProduct = true, allowedCustomer = true;

                        Console.Clear();

                        #region Display+Select Product

                        List<Product> tempDisplayProduct = new List<Product>();
                        tempDisplayProduct = dataProduct.DisplayProducts(jsonFilePathProducts);
                        Console.Clear();
                        Console.WriteLine("Products");
                        if (tempDisplayProduct.Count != 0)
                        {
                            for (int i = 0; i < tempDisplayProduct.Count; i++)
                            {
                                Console.WriteLine(" {0}. {1} | ID: {2}", i + 1, tempDisplayProduct[i].ProductName, tempDisplayProduct[i].Id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Data Present");
                        }

                        Console.WriteLine("Please Select Product: ");
                        selectProd = Int32.Parse(Console.ReadLine());
                        
                        if(selectProd > dataProduct.ProductCount + 1)
                        {
                            Console.WriteLine("Selected an Invalid Product. Press any key to Try Again.");
                            Console.ReadKey();
                        }

                        #endregion

                        Console.Clear();

                        #region Display+Select Customer
                        Console.Clear();
                        List<Customer> tempData = new List<Customer>();
                        tempData = dataCustomer.DisplayCustomers(jsonFilePathCustomers);

                        Console.Clear();
                        Console.WriteLine("Please Select a Customer");
                        if (tempData.Count != 1)
                        {
                            for (int i = 0; i < tempData.Count; i++)
                            {
                                Console.WriteLine(" {0}. {1} {2}", i + 1, tempData[i].FirstName, tempData[i].LastName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Data Present");
                        }

                        Console.WriteLine("Please Select Customer: ");
                        selectCust = Int32.Parse(Console.ReadLine());

                        if (selectCust > dataCustomer.CustomerCount + 1)
                        {
                            Console.WriteLine("Selected an Invalid Customer. Press any key to Try Again.");
                            Console.ReadKey();
                        }
                        #endregion

                        Console.Clear();

                        #region Display+Select Location
                        for (int i = 0; i < tempDisplayProduct[selectProd - 1].location.Count; i++)
                        {
                            Console.WriteLine("{0}. {1} ({2})", i + 1, tempDisplayProduct[selectProd - 1].location[i].City, tempDisplayProduct[selectProd - 1].location[i].Inventory);
                        }

                        Console.WriteLine("Select The Location: ");
                        citySelect = Int32.Parse(Console.ReadLine());

                        if (citySelect > tempDisplayProduct[selectProd - 1].location.Count + 1)
                        {
                            Console.WriteLine("Please Select a Valid City");
                        }
                        #endregion

                        Console.Clear();

                        #region  Enter Quantity
                        Console.WriteLine("Enter the Quantity: ");
                        quant = Int32.Parse(Console.ReadLine());

                        if (quant > tempDisplayProduct[selectProd - 1].location[citySelect - 1].Inventory)
                        {
                            Console.WriteLine("Not Enough Copies left in the Inventory");
                        }
                        else if (quant > 5)
                        {
                            Console.WriteLine("Enter a Valid Quantity [Order Limit: 5]");
                        }
                        #endregion

                        Console.Clear();

                        #region Enter Date
                        Console.WriteLine("Enter Date and Time for the Order: ");
                        dateString = Console.ReadLine();
                        #endregion

                        Console.Clear();

                        orderData.tempProdData = tempDisplayProduct;
                        orderData.tempCustData = tempData;

                        orderData.CreateOrder(jsonFilePathOrders, jsonFilePathCustomers, jsonFilePathProducts, selectProd, selectCust, citySelect, quant, dateString);

                        Console.WriteLine("Order Created");
                        Console.ReadKey();
                        break;

                    case 2:

                        List<Order> displayOrder = new List<Order>();
                        string storeLocation = "";

                        displayOrder = orderData.DisplayOrders(jsonFilePathOrders);

                        Console.Clear();
                        Console.WriteLine("Orders");
                        if (displayOrder.Count != 0)
                        {
                            for (int i = 0; i < displayOrder.Count; i++)
                            {
                                for (int j = 0; j < displayOrder[i].product.location.Count; j++)
                                {
                                    if (displayOrder[i].product.location[j].orderSelect == true)
                                    {
                                        storeLocation = displayOrder[i].product.location[j].City;
                                    }
                                }
                                Console.WriteLine(" {0}. ID: {1} | Name: {2} | Location: {3} | Quantity: {4}", i + 1, displayOrder[i].OrderId, displayOrder[i].product.ProductName, storeLocation, displayOrder[i].orderQuantity, displayOrder[i].orderQuantity);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Data Present");
                        }

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
