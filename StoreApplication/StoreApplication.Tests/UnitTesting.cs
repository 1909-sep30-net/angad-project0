using System;
using System.Collections.Generic;
using StoreApplication.Library;
using Xunit;


namespace StoreApplication.Tests
{
    public class UnitTesting
    {

        //[Theory]
        //[InlineData(@"C:\revature\angad-project0\StoreApplication\JSONData\Customers.json")]
        [Fact]
        //public void AddShouldAdd(string jsonFilePath)
        public void AddShouldAdd()
        {
            //Arrange
            Customer customer = new Customer();

            //Act
            //customer.AddCustomer(jsonFilePath);
            ///customer.AddCustomer(@"C:\revature\angad-project0\StoreApplication\JSONData\Customers.json");

            //Assert
            //Assert.Equal(true, customer.CustomerAdded());

        }
    }
}
