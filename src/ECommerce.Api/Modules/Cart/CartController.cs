using System.Linq;
using ECommerce.Core.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Cart
{
    public class CartController : ApiControllerBase
    {
        private readonly IProviderManager manager;

        public CartController(IProviderManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public ActionResult<CartViewModel> Index()
        {
            var cartProvider = this.manager.GetProvider<Core.Entities.Cart>();
            var carts = cartProvider.GetAll().ToList();

            return new OkObjectResult(new CartViewModel());
        }
    }
}
