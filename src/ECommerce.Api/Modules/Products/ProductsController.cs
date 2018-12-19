using System.Collections.Generic;
using System.Net;
using AutoMapper;
using ECommerce.Core.Managers.Products;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly IMapper mapper;

        public ProductsController(IProductManager productManager, IMapper mapper)
        {
            this.productManager = productManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProductDTO>))]
        public IActionResult GetProducts()
        {
            var products = this.productManager.GetProducts();
            var productsDto = this.mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productsDto);
        }
    }
}
