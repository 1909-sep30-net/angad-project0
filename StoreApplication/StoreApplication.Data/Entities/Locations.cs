using System;
using System.Collections.Generic;

namespace StoreApplication.Data.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Inventory = new HashSet<Inventory>();
        }

        public int LocationId { get; set; }
        public string City { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
