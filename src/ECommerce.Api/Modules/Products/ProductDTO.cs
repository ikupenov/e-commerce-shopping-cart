using System;

namespace ECommerce.Api.Modules.Products
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
