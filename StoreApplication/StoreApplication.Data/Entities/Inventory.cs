﻿using System;
using System.Collections.Generic;

namespace StoreApplication.Data.Entities
{
    public partial class Inventory
    {
        public int LocationId { get; set; }
        public int? ProductId { get; set; }
        public int? Inventory1 { get; set; }

        public virtual Products Product { get; set; }
    }
}
