using System;
using System.Collections.Generic;
using System.Text;
using StoreApplication.Library;
using System.IO;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Data.Entities;
using System.Linq;

namespace StoreApplication.Data
{
    public class ProductData
    {

        Product prodData = new Product();
        public int ProductCount { get; set; }

        public void AddProducts(string jsonFilePath, string productName, string productType, string storeLocation, int inventoryForLoc, int storeCount, List<string> storeLocationList, List<int> storeInventoryList)
        {

            Product product = new Product();

            product.ProductName = productName;
            product.ProductType = productType;

            Random random = new Random();
            product.Id = random.Next(1000, 9999);

            for (int i = 0; i < storeCount; i++)
            {
                Location tempLoc = new Location();
                tempLoc.City = storeLocationList[i];
                tempLoc.Inventory = storeInventoryList[i];
                tempLoc.orderSelect = false;
                product.location.Add(tempLoc);
            }

            List<Product> tempProduct = new List<Product>();

            if (File.Exists(jsonFilePath))
            {
                tempProduct.AddRange(prodData.DeserializeJsonFromFile(jsonFilePath));
                tempProduct.Add(product);
            }
            else
            {
                tempProduct.Add(product);
            }
            prodData.SerializeJsonToFile(jsonFilePath, tempProduct);

        }

        public void AddProductsDB(string productName, string productType, string storeLocation, int inventoryForLoc, int storeCount, List<string> storeLocationList, List<int> storeInventoryList)
        {
            string connectionString = SecretConfiguration.configurationString;

            DbContextOptions<GameStoreContext> options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new GameStoreContext(options);

            Products prod = new Products();
            
            prod.ProductName = productName;
            prod.ProductType = productType;

            context.Products.Add(prod);

            context.SaveChanges();

            /*Random random = new Random();
            prod.ProductId = random.Next(1000, 9999);*/

            for (int i = 0; i < storeCount; i++)
            {
                Locations tempLoc = new Locations();
                Inventory tempInv = new Inventory();
                
                tempLoc.City = storeLocationList[i];
                
                var foundName = context.Locations.FirstOrDefault(p => p.City == storeLocationList[i]);

                if (foundName is null)
                {
                    context.Locations.Add(tempLoc);
                    context.SaveChanges();
                }
                else
                {
                    tempLoc.LocationId = foundName.LocationId;
                    tempInv.LocationId = tempLoc.LocationId;
                    tempInv.ProductId = prod.ProductId;
                }

                tempInv.Inventory1 = storeInventoryList[i];
                
                context.Inventory.Add(tempInv);
            }

            context.SaveChanges();
        }

        public void DisplayProductsDB()
        {
            string connectionString = SecretConfiguration.configurationString;

            DbContextOptions<GameStoreContext> options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new GameStoreContext(options);

            foreach (Products product in context.Products)
            {
                Console.WriteLine($"Id: {product.ProductId} | Name: {product.ProductName} | Platform: {product.ProductType}");
            }
        }

        public List<Product> DisplayProducts(string jsonFilePath)
        {
            List<Product> tempData = new List<Product>();
            if (File.Exists(jsonFilePath))
            {
                tempData = prodData.DeserializeJsonFromFile(jsonFilePath);

                ProductCount = tempData.Count;
            }
            return tempData;
        }

    }
}
