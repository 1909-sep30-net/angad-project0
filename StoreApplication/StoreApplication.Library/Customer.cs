﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace StoreApplication.Library 
{
    public class Customer 
    {

        List<Order> customerOrders = new List<Order>();

        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string defaultLocation = "Arlington";
        public int CustomerCount { get; set; }

        public void AddCustomer(string jsonFilePath, string fullName)
        {
            Customer newCustomer = new Customer();

            string[] nameHolder = new string[3];
            nameHolder = fullName.Split(' ');

            if (nameHolder.Length == 2)
            {
                newCustomer.FirstName = nameHolder[0];
                newCustomer.LastName = nameHolder[1];
                Console.WriteLine("Added Customer {0} {1}", newCustomer.FirstName, newCustomer.LastName);
                List<Customer> tempCustomer = new List<Customer>();

                if(File.Exists(jsonFilePath))
                {
                    tempCustomer.AddRange(DeserializeJsonFromFile(jsonFilePath));
                    tempCustomer.Add(newCustomer);
                }
                else
                {
                    tempCustomer.Add(newCustomer);
                }
                SerializeJsonToFile(jsonFilePath, tempCustomer);
                Console.WriteLine("Press Any Key To Continue: ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid Name Entered");
            }
        }

        public void SerializeJsonToFile(string jsonFilePath, List<Customer> data)
        {
            //Need to Append Instead of Creating a New File Everytime
            string json = JsonConvert.SerializeObject(data);

            // exceptions should be handled here
            File.WriteAllText(jsonFilePath, json);

        }
        
        public List<Customer> DeserializeJsonFromFile(string jsonFilePath)
        {
            // exceptions should be handled here
            string json = File.ReadAllText(jsonFilePath);

            var data = JsonConvert.DeserializeObject<List<Customer>>(json);

            return data;
        }
        
        public void DisplayCustomers(string jsonFilePath)
        {
            List<Customer> tempData = new List<Customer>();
            if (File.Exists(jsonFilePath))
            {
                tempData = DeserializeJsonFromFile(jsonFilePath);

                Console.Clear();
                Console.WriteLine("Customer      First Name      Last Name");
                for (int i = 0; i < tempData.Count; i++)
                {
                    Console.WriteLine(" {0}              {1}           {2}", i + 1, tempData[i].FirstName, tempData[i].LastName);
                }
            }
            else
            {
                Console.WriteLine("No Data Present");
            }
        }

        public void SearchByName(string jsonFilePath)
        {
            List<Customer> tempData = new List<Customer>();
            string searchName;
            Console.Clear();
            Console.WriteLine("Please Enter a First or a Last Name To Search");
            searchName = Console.ReadLine();

            if (File.Exists(jsonFilePath))
            {
                int searchCount = 0;
                tempData = DeserializeJsonFromFile(jsonFilePath);
                Console.WriteLine("Customer      First Name      Last Name");
                for (int i = 0; i < tempData.Count; i++)
                {
                    if (tempData[i].FirstName.Equals(searchName) || tempData[i].LastName.Equals(searchName))
                    {
                        Console.WriteLine(" {0}              {1}           {2}", i + 1, tempData[i].FirstName, tempData[i].LastName);                        
                    }
                    else
                    {
                        searchCount++;
                    }
                }
                if(searchCount == tempData.Count)
                {
                    Console.Clear();
                    Console.WriteLine("No Such Record Present");
                }
            }
        }
        
    }
}