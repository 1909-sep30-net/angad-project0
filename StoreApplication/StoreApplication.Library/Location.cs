using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library {    
    class Location {

        public int inventory = 0;

        public string Address { get; set; }

        public Product product = new Product();

        //Decrease inventory when orders are accepted

        //If the order can't be fulfilled with the remaining inventory in the store, REJECT order

    }
}
