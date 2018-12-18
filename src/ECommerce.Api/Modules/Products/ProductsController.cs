using System.Collections.Generic;
using ECommerce.Core.Entities;
using ECommerce.Core.Managers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Products
{
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductManager productManager;

        public ProductsController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Index()
        {
            var products = this.productManager.GetProducts();

            return Ok(products);
        }
    }
}
