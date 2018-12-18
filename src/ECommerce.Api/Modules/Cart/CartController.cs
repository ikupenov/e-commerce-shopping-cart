using System.Linq;
using ECommerce.Core.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Cart
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IManager manager;

        public CartController(IManager manager)
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
