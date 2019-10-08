using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace StoreApplication.Library
{
    public class Product
    {
        //GameStore
        public string ProductName { get; set; }
        public int Id { get; set; }
        public string ProductType { get; set; }

        public List<Location> location = new List<Location>();

        public void AddProducts(string jsonFilePath)
        {
            Console.Clear();

            string productName;
            string productType;
            string storeLocation;
            int inventoryForLoc;
            int storeCount;

            Console.WriteLine("Enter Product Name: ");
            productName = Console.ReadLine();

            Console.WriteLine("Enter Product Type: ");
            productType = Console.ReadLine();

            Console.WriteLine("How many Stores? ");
            storeCount = Int32.Parse(Console.ReadLine());
            
            Product product = new Product();

            product.ProductName = productName;
            product.ProductType = productType;

            Random random = new Random();
            product.Id = random.Next(1000, 9999);

            Console.WriteLine(storeCount);

            for (int i = 0; i < storeCount; i++)
            {
                Console.WriteLine("Store Location {0}: ", i + 1);
                storeLocation = Console.ReadLine();
                Console.WriteLine("Inventory for the {0} Store", storeLocation);
                inventoryForLoc = Int32.Parse(Console.ReadLine());

                Location tempLoc = new Location();
                tempLoc.City = storeLocation;
                tempLoc.Inventory = inventoryForLoc;
                tempLoc.orderSelect = false;
                product.location.Add(tempLoc);
            }

            Console.WriteLine("Added Product {0} of type {1} with ID {2} to {3} stores", product.ProductName, product.ProductType, product.Id, storeCount);
            List<Product> tempProduct = new List<Product>();

            if (File.Exists(jsonFilePath))
            {
                tempProduct.AddRange(DeserializeJsonFromFile(jsonFilePath));
                tempProduct.Add(product);
            }
            else
            {
                tempProduct.Add(product);
            }
            SerializeJsonToFile(jsonFilePath, tempProduct);
            Console.ReadKey();

        }

        public void SerializeJsonToFile(string jsonFilePath, List<Product> data)
        {
            //Need to Append Instead of Creating a New File Everytime
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here
            File.WriteAllText(jsonFilePath, json);

        }
        public List<Product> DeserializeJsonFromFile(string jsonFilePath)
        {
            // exceptions should be handled here
            string json = File.ReadAllText(jsonFilePath);

            var data = JsonConvert.DeserializeObject<List<Product>>(json);

            return data;
        }

        public void DisplayProducts(string jsonFilePath)
        {
            List<Product> tempData = new List<Product>();
            if (File.Exists(jsonFilePath))
            {
                tempData = DeserializeJsonFromFile(jsonFilePath);

                Console.Clear();
                Console.WriteLine("Product      Name      ID");
                for (int i = 0; i < tempData.Count; i++)
                {
                    Console.WriteLine(" {0}          {1}           {2}", i + 1, tempData[i].ProductName, tempData[i].Id);
                }
                ProductCount = tempData.Count;
            }
            else
            {
                Console.WriteLine("No Data Present");
            }
        }

        public int ProductCount { get; set; }

    }
}