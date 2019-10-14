using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Data.Entities;
using System.Linq;

namespace StoreApplication.Data
{
    public class LocationData
    {
        public void DisplayLocationsDB(int product)
        {
            string connectionString = SecretConfiguration.configurationString;

            DbContextOptions<GameStoreContext> options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new GameStoreContext(options);
            using var context2 = new GameStoreContext(options);

            var foundName = context.Inventory.FirstOrDefault(p => p.ProductId == product);
            var foundCity = context.Locations.FirstOrDefault(p => p.LocationId == foundName.LocationId);
            var foundLoc = context.Inventory.Where(p => p.ProductId == product);

            if (foundName is null)
            {
                Console.WriteLine("No Record Found");
                return;
            }

            //Console.WriteLine($"Id: {foundName.LocationId} | City: {foundCity.City}");
            foreach (Inventory loc in context.Inventory)
            {
                if (loc.ProductId == product)
                {
                    foreach (Locations location in context2.Locations)
                        if (loc.ProductId == product)
                            Console.WriteLine($"Id: {location.LocationId} | City: {location.City}");
                    break;
                }
            }
        }

        public int GetInventoryDB(int location)
        {
            string connectionString = SecretConfiguration.configurationString;

            DbContextOptions<GameStoreContext> options = new DbContextOptionsBuilder<GameStoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            using var context = new GameStoreContext(options);

            var foundName = context.Inventory.FirstOrDefault(p => p.LocationId == location);

            if (foundName is null)
            {
                return 0;
            }

            return (int)foundName.Inventory1;
        }


    }
}
