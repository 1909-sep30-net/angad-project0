using System;
using System.IO;
using System.Collections.Generic;
using StoreApplication.Library;

namespace StoreApplication.Data
{
    public class CustomerData
    {
        private bool addedCustomer;

        Customer customer = new Customer();
        public string[] nameHolder = new string[3];
        public int searchCount = 0;

        public int CustomerCount { get; set; }

        public void AddCustomer(string jsonFilePath, string fullName)
        {

            Customer newCustomer = new Customer();
            nameHolder = fullName.Split(' ');

            if (nameHolder.Length == 2)
            {
                newCustomer.FirstName = nameHolder[0];
                newCustomer.LastName = nameHolder[1];

                List<Customer> tempCustomer = new List<Customer>();
                
                //If the file already exists (i.e. Not the first time Adding a customer) It deserializes the already input data and adds that to the tempCustomer
                //The tempCustomer is then appended with the newCustomer
                if (File.Exists(jsonFilePath))
                {
                    tempCustomer.AddRange(customer.DeserializeJsonFromFile(jsonFilePath));
                    tempCustomer.Add(newCustomer);
                }
                else
                {
                    tempCustomer.Add(newCustomer);
                }
                addedCustomer = true;
                customer.SerializeJsonToFile(jsonFilePath, tempCustomer);
                
            }
            else
            {
                addedCustomer = false;
            }

        }

        public List<Customer> DisplayCustomers(string jsonFilePath)
        {
            List<Customer> tempData = new List<Customer>();
            if (File.Exists(jsonFilePath))
            {
                tempData = customer.DeserializeJsonFromFile(jsonFilePath);

                CustomerCount = tempData.Count;
            }
            return tempData;
        }

    }
}
