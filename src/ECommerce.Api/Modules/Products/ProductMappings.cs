using AutoMapper;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Modules.Products
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            base.CreateMap<ProductViewModel, Product>();
        }
    }
}
