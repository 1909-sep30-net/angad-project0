using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace StoreApplication.Library 
{
    public class Order 
    {

        public Customer customer = new Customer();

        public Product product = new Product();

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = new DateTime();

        public int orderQuantity { get; set; }

        //public void CreateOrder(string jsonFilePath, string jsonFilePathCustomer, string jsonFilePathProducts)
        //{

        //    Order order = new Order();
        //    Random random = new Random();
        //    order.OrderId = random.Next(10000, 99999);

        //    Console.Clear();

        //    int selectCust = 0, selectProd = 0, citySelect = 0;

        //    List<Customer> tempCustData = new List<Customer>();
        //    List<Product> tempProdData = new List<Product>();

        //    bool allowedCity = true, allowedQuant = true, allowedProduct = true, allowedCustomer = true;

        //    while (allowedProduct)
        //    {
        //        if (File.Exists(jsonFilePathProducts))
        //        {
        //            tempProdData.AddRange(product.DeserializeJsonFromFile(jsonFilePathProducts));

        //            product.DisplayProducts(jsonFilePathProducts);
        //            Console.WriteLine("Please Select Product: ");
                    
        //            selectProd = Int32.Parse(Console.ReadLine());
        //            if (selectProd < product.ProductCount + 1)
        //            {
        //                allowedProduct = false;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Please Select a Valid Product\nPress Any Key To Try Again");
        //                Console.ReadKey();
        //                allowedProduct = true;
        //            }
        //        }
        //    }

        //    while (allowedCustomer)
        //    {
        //        if (File.Exists(jsonFilePathCustomer))
        //        {
        //            tempCustData.AddRange(customer.DeserializeJsonFromFile(jsonFilePathCustomer));

        //            customer.DisplayCustomers(jsonFilePathCustomer);
        //            Console.WriteLine("Please Select Customer: ");
                    
        //            selectCust = Int32.Parse(Console.ReadLine());

        //            if(selectCust < customer.CustomerCount + 1)
        //            {
        //                allowedCustomer = false;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Please Select A Valid Customer\nPress Any Key To Try Again");
        //                Console.ReadKey();
        //                allowedCity = true;
        //            }
        //        }
        //    }

        //    while (allowedCity)
        //    {
        //        for (int i = 0; i < tempProdData[selectProd - 1].location.Count; i++)
        //        {
        //            Console.WriteLine("{0}. {1} ({2})", i + 1, tempProdData[selectProd - 1].location[i].City, tempProdData[selectProd - 1].location[i].Inventory);
        //        }

        //        Console.WriteLine("Select The Location: ");
        //        citySelect = Int32.Parse(Console.ReadLine());
        //        if(citySelect < tempProdData[selectProd - 1].location.Count + 1)
        //        {
        //            allowedCity = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Please Select a Valid City");
        //            allowedCity = true;
        //        }
        //    }

        //    while (allowedQuant)
        //    {
        //        int quant = 0;
        //        Console.WriteLine("Enter the Quantity: ");
        //        quant = Int32.Parse(Console.ReadLine());
        //        order.orderQuantity = quant;

        //        if (quant < tempProdData[selectProd - 1].location[citySelect - 1].Inventory && quant < 5)
        //        {
        //            tempProdData[selectProd - 1].location[citySelect - 1].Inventory -= quant;
        //            product.SerializeJsonToFile(jsonFilePathProducts, tempProdData); // To Serialize the Changes made to the particular product
        //            allowedQuant = false;
        //        }
        //        else
        //        {
        //            if (quant > tempProdData[selectProd - 1].location[citySelect - 1].Inventory)
        //            {
        //                Console.WriteLine("Not Enough Copies left in the Inventory");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Enter a Valid Quantity [Order Limit: 5]");
        //            }
        //            allowedQuant = true;
        //        }
        //    }

        //    tempProdData[selectProd - 1].location[citySelect - 1].orderSelect = true;

        //    order.product = tempProdData[selectProd - 1];
        //    order.customer = tempCustData[selectCust - 1];

        //    string dateString;
        //    Console.WriteLine("Enter Date and Time for the Order: ");
        //    dateString = Console.ReadLine();

        //    //EXCEPTION HANDLING
        //    DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);

        //    order.OrderDate = date;

        //    List<Order> tempOrder = new List<Order>();

        //    if (File.Exists(jsonFilePath))
        //    {
        //        tempOrder.AddRange(DeserializeJsonFromFile(jsonFilePath));
        //        tempOrder.Add(order);
        //    }
        //    else
        //    {
        //        tempOrder.Add(order);
        //    }
        //    SerializeJsonToFile(jsonFilePath, tempOrder);
        //    Console.WriteLine("Order Created");
        //    Console.ReadKey();

        //}

        public void SerializeJsonToFile(string jsonFilePath, List<Order> data)
        {

            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here
            File.WriteAllText(jsonFilePath, json);

        }
        public List<Order> DeserializeJsonFromFile(string jsonFilePath)
        {
            // exceptions should be handled here
            string json = File.ReadAllText(jsonFilePath);

            var data = JsonConvert.DeserializeObject<List<Order>>(json);

            return data;
        }

    }
}
