using System;
using System.IO;
using System.Collections.Generic;
using StoreApplication.Library;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Data.Entities;
using System.Linq;

namespace StoreApplication.Data
{
    public class CustomerData
    {
        private bool addedCustomer;

        Library.Customer customer = new Library.Customer();
        public string[] nameHolder = new string[3];
        public int searchCount = 0;

        public int CustomerCount { get; set; }

        public void AddCustomer(string jsonFilePath, string fullName)
        {

            Library.Customer newCustomer = new Library.Customer();
            nameHolder = fullName.Split(' ');

            if (nameHolder.Length == 2)
            {
                newCustomer.FirstName = nameHolder[0];
                newCustomer.LastName = nameHolder[1];

                List<Library.Customer> tempCustomer = new List<Library.Customer>();
                
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

        public void AddCustomerDB(string fullName)
        {

            string connectionString = SecretConfiguration.configurationString;

            DbContextOptions<GameStoreContext> options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new GameStoreContext(options);

            // check if already exists
            Entities.Customer newCust = new Entities.Customer();
            string[] name = fullName.Split(' ');

            newCust.CustomerId = 3; //NEEDS TO BE TURNED INTO IDENTITY (NO INPUT)
            newCust.FirstName = name[0];
            newCust.LastName = name[1];

            context.Customer.Add(newCust);

            context.SaveChanges();
        }

        public void DisplayCustomersDB()
        //public void DisplayCustomersDB(GameStoreContext context)
        {

            string connectionString = SecretConfiguration.configurationString;

            DbContextOptions<GameStoreContext> options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new GameStoreContext(options);

            foreach (Entities.Customer customer in context.Customer)
            {
                Console.WriteLine($"Id: {customer.CustomerId}. Name: {customer.FirstName} {customer.LastName}");
            }

        }

        public List<Library.Customer> DisplayCustomers(string jsonFilePath)
        {
            List<Library.Customer> tempData = new List<Library.Customer>();
            if (File.Exists(jsonFilePath))
            {
                tempData = customer.DeserializeJsonFromFile(jsonFilePath);

                CustomerCount = tempData.Count;
            }
            return tempData;
        }

    }
}
