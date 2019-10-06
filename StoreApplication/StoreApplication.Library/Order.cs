using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library 
{
    public class Order 
    {

        public Customer customer = new Customer();

        public Location newLocation = new Location();

        public DateTime OrderTime { get; set; } = new DateTime();

        public List<string> orderType = new List<string>();

        //Validation to make sure there is no order with unreasonably high quantities
        //Add some additional business Rules

    }
}
