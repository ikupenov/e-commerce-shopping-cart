using System;
using ECommerce.Core.Managers;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Cart
{
    [ApiController]
    [Route("api/users/{userId}/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;

        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }

        [HttpGet]
        public IActionResult GetCart(Guid userId)
        {
            return Ok($"Getting cart with user's ID {userId}");
        }

        [HttpPut]
        public IActionResult UpdateCart(Guid userId)
        {
            return Ok($"Adding to user's cart with ID {userId}");
        }

        [HttpDelete]
        public IActionResult ClearCart(Guid userId)
        {
            return Ok();
        }
    }
}
