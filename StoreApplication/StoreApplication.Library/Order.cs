using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace StoreApplication.Library 
{
    public class Order 
    {

        //Validation to make sure there is no order with unreasonably high quantities
        //Add some additional business Rules

        public Customer customer = new Customer();

        public Product product = new Product();

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = new DateTime();

        public int orderQuantity { get; set; }

        public void CreateOrder(string jsonFilePath, string jsonFilePathCustomer, string jsonFilePathProducts)
        {

            //To add a new order, I'll display all customers, user will select one and the order will be placed under him in JSON

            Order order = new Order();
            Random random = new Random();
            order.OrderId = random.Next(10000, 99999);

            Console.Clear();

            int selectCust = 0, selectProd = 0;

            List<Customer> tempCustData = new List<Customer>();
            List<Product> tempProdData = new List<Product>();

            if (File.Exists(jsonFilePathProducts))
            {
                tempProdData.AddRange(product.DeserializeJsonFromFile(jsonFilePathProducts));
                
                product.DisplayProducts(jsonFilePathProducts);
                Console.WriteLine("Please Select Product: ");
                //WHILE NO INVALID VALUE
                selectProd = Int32.Parse(Console.ReadLine());
            }

            if (File.Exists(jsonFilePathCustomer))
            {
                tempCustData.AddRange(customer.DeserializeJsonFromFile(jsonFilePathCustomer));
                
                customer.DisplayCustomers(jsonFilePathCustomer);
                Console.WriteLine("Please Select Customer: ");
                //WHILE NO INVALID VALUE
                selectCust = Int32.Parse(Console.ReadLine());
            }
            for(int i = 0; i < tempProdData[selectProd - 1].location.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, tempProdData[selectProd - 1].location[i].City);
            }
            int citySelect;
            Console.WriteLine("Select The Location: ");
            citySelect = Int32.Parse(Console.ReadLine());

            //ADD Inventory Decrement and Validation
            int quant = 0;
            Console.WriteLine("Enter the Quantity: ");
            quant = Int32.Parse(Console.ReadLine());
            order.orderQuantity = quant;
            tempProdData[selectProd - 1].location[citySelect].Inventory -= quant;
            //Update the Inventory Change in the serialized JSON File


            tempProdData[selectProd - 1].location[citySelect].orderSelect = true;

            //ADD PRODUCT
            order.product = tempProdData[selectProd - 1];
            order.customer = tempCustData[selectCust - 1];

            string dateString;
            Console.WriteLine("Enter Date and Time for the Order: ");
            dateString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);

            order.OrderDate = date;

            List<Order> tempOrder = new List<Order>();

            if (File.Exists(jsonFilePath))
            {
                tempOrder.AddRange(DeserializeJsonFromFile(jsonFilePath));
                tempOrder.Add(order);
            }
            else
            {
                tempOrder.Add(order);
            }
            SerializeJsonToFile(jsonFilePath, tempOrder);
            Console.ReadKey();

        }

        public void SerializeJsonToFile(string jsonFilePath, List<Order> data)
        {
            //Need to Append Instead of Creating a New File Everytime
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

        public void DisplayOrders(string jsonFilePath)
        {
            List<Order> tempData = new List<Order>();
            if (File.Exists(jsonFilePath))
            {
                tempData = DeserializeJsonFromFile(jsonFilePath);
                string storeLocation = "";

                Console.Clear();
                Console.WriteLine("OrderID      Name      Store      Quantity");
                for (int i = 0; i < tempData.Count; i++)
                {
                    for(int j = 0; j < tempData[i].product.location.Count; j++)
                    {
                        if(tempData[i].product.location[j].orderSelect == true)
                        {
                            storeLocation = tempData[i].product.location[j].City;
                        }
                    }
                    Console.WriteLine(" {0}          {1}           {2}          {3}", i + 1, tempData[i].OrderId, tempData[i].product.ProductName, storeLocation, tempData[i].orderQuantity);
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No Data Present\nPress Any Key To Continue");
                Console.ReadKey();
            }
        }

    }
}
