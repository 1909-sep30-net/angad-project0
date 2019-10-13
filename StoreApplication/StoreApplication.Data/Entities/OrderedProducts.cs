using System;
using System.Collections.Generic;

namespace StoreApplication.Data.Entities
{
    public partial class OrderedProducts
    {
        public int CustomerId { get; set; }
        public int? ProductId { get; set; }

        public virtual Products Product { get; set; }
    }
}
