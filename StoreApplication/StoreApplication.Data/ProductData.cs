using System;
using System.Collections.Generic;
using System.Text;
using StoreApplication.Library;
using System.IO;

namespace StoreApplication.Data
{
    public class ProductData
    {

        Product prodData = new Product();
        public int ProductCount { get; set; }

        public void AddProducts(string jsonFilePath, string productName, string productType, string storeLocation, int inventoryForLoc, int storeCount)
        {

            Product product = new Product();

            product.ProductName = productName;
            product.ProductType = productType;

            Random random = new Random();
            product.Id = random.Next(1000, 9999);

            for (int i = 0; i < storeCount; i++)
            {
                Location tempLoc = new Location();
                tempLoc.City = storeLocation;
                tempLoc.Inventory = inventoryForLoc;
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
