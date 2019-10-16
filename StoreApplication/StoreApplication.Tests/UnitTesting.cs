using System;
using System.Collections.Generic;
using StoreApplication.App;
using StoreApplication.Data;
using StoreApplication.Data.Entities;
using Xunit;


namespace StoreApplication.Tests
{
    public class UnitTesting
    {

        [Theory]
        [InlineData("")]
        public void AddCustomerShouldAdd(string fullName)
        {
            //Arrange
            CustomerData customer = new CustomerData();

            //Act
            Action act = () => customer.AddCustomerDB(fullName);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);

        }
        [Theory]
        [InlineData("")]
        public void AddProdcutShouldAdd(string test)
        {
            //Arrange
            ProductData product = new ProductData();

            //Act
            Action act = () => product.AddProductsDBTest(test);

            //Assert
            Assert.Throws<FormatException>(act);

        }

        [Theory]
        [InlineData(0, 0, 0, 0, "")]
        public void AddOrdersShouldAdd(int selectProd, int selectCust, int citySelect, int quant, string dateString)
        {
            //Arrange
            OrderData order = new OrderData();

            //Act
            Action act = () => order.CreateOrderDB(selectProd, selectCust, citySelect, quant, dateString);

            //Assert
            Assert.Throws<FormatException>(act);

        }

        [Theory]
        [InlineData(99,99)]
        [InlineData(98, 99)]
        [InlineData(97, 96)]
        public void GetInventoryTest(int location, int product)
        {
            //Arrange
            LocationData loc = new LocationData();

            //Act
            int test = loc.GetInventoryDB(location, product);

            //Assert
            Assert.Equal(0, test);

        }

        [Theory]
        [InlineData("")]
        public void GetOrdersTest(string json)
        {
            OrderData order = new OrderData();
            List<Orders> ord = new List<Orders>(); 

            //Act
            Action act = () => Assert.Equal(ord[0].Quantity, order.DisplayOrders(json)[0].orderQuantity);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);

        }

    }
}
