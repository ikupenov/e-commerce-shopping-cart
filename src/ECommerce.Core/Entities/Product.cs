﻿namespace ECommerce.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Inventory { get; set; }
    }
}
