using System;
using System.Collections.Generic;

namespace StoreApplication.Data.Entities
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            OrderedProducts = new HashSet<OrderedProducts>();
            Orders = new HashSet<Orders>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderedProducts> OrderedProducts { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
