using AutoMapper;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Modules.Products
{
    internal class ProductMappings : Profile
    {
        public ProductMappings()
        {
            base.CreateMap<Product, ProductDTO>();
            base.CreateMap<ProductDTO, Product>();
        }
    }
}
