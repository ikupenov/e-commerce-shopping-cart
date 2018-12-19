using System;
using AutoMapper;
using ECommerce.Core.Managers.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Modules.Cart
{
    [ApiController]
    [Route("api/users/{userId}/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;
        private readonly IMapper mapper;

        public CartController(ICartManager cartManager, IMapper mapper)
        {
            this.cartManager = cartManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CartDTO> GetCart(Guid userId)
        {
            var cart = this.cartManager.GetCartByUserId(userId);
            var cartDto = this.mapper.Map<CartDTO>(cart);

            return Ok(cartDto);
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
