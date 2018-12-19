using System.Collections.Generic;
using AutoMapper;
using ECommerce.Core.Entities;
using ECommerce.Core.Managers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductManager productManager;

        public ProductsController(IMapper mapper, IProductManager productManager)
        {
            this.mapper = mapper;
            this.productManager = productManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = this.productManager.GetProducts();

            var productsViewModel = this.mapper.Map<IEnumerable<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }
    }
}
