using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using StoreApplication.Library;

namespace StoreApplication.Data
{
    public class OrderData
    {

        Order order = new Order();

        Product product = new Product();
        Customer customer = new Customer();

        ProductData dataProduct = new ProductData();
        CustomerData dataCustomer = new CustomerData();

        public List<Customer> tempCustData = new List<Customer>();
        public List<Product> tempProdData = new List<Product>();


        //ADD FOR MULTIPLE PRODUCTS
        public void CreateOrder(string jsonFilePath, string jsonFilePathCustomer, string jsonFilePathProducts, int selectProd, int selectCust, int citySelect, int quant, string dateString)
        {

            Random random = new Random();
            order.OrderId = random.Next(10000, 99999);

            tempProdData[selectProd - 1].location[citySelect - 1].Inventory -= quant;
            product.SerializeJsonToFile(jsonFilePathProducts, tempProdData);

            order.orderQuantity = quant;
            
            tempProdData[selectProd - 1].location[citySelect - 1].orderSelect = true;

            order.product = tempProdData[selectProd - 1];
            order.customer = tempCustData[selectCust - 1];

            //EXCEPTION HANDLING
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);
            order.OrderDate = date;

            List<Order> tempOrder = new List<Order>();

            if (File.Exists(jsonFilePath))
            {
                tempOrder.AddRange(order.DeserializeJsonFromFile(jsonFilePath));
                tempOrder.Add(order);
            }
            else
            {
                tempOrder.Add(order);
            }
            order.SerializeJsonToFile(jsonFilePath, tempOrder);

        }

        public List<Order> DisplayOrders(string jsonFilePath)
        {
            List<Order> tempData = new List<Order>();
            if (File.Exists(jsonFilePath))
            {
                tempData = order.DeserializeJsonFromFile(jsonFilePath);
            }
            
            return tempData;
        }

    }
}
