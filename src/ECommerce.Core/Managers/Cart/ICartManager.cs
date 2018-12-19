using System;
using System.Collections.Generic;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Managers.Cart
{
    public interface ICartManager
    {
        Entities.Cart GetCart(Guid cartId);

        Entities.Cart GetCartByUserId(Guid userId);

        CartItem GetCartItem(Guid cartItemId);

        CartItem GetCartItemByProductId(Guid productId);

        void AddToCart(Entities.Cart cart, Guid productId, int quantity);

        void UpdateCartItem(Entities.Cart cart, Guid productId, int quantity);

        void UpdateCartItems(Entities.Cart cart, IEnumerable<CartItem> cartItems);

        void RemoveFromCart(Entities.Cart cart, Guid productId);

        void ClearCart(Entities.Cart cart);

        void ClearCart(Guid cartId);
    }
}
