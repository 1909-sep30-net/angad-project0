using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library 
{
    public class Location 
    {

        public int Inventory { get; set; }
        public string City { get; set; }

        //Decrease inventory when orders are accepted

        //If the order can't be fulfilled with the remaining inventory in the store, REJECT order

    }
}
