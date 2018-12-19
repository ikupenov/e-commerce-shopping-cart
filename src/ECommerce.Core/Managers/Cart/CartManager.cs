using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;

namespace ECommerce.Core.Managers.Cart
{
    public class CartManager : Manager, ICartManager
    {
        private readonly IProvider<Entities.Cart> cartProvider;
        private readonly IProvider<CartItem> cartItemProvider;
        private readonly IProvider<Product> productProvider;

        public CartManager(IProviderManager providerManager) : base(providerManager)
        {
            this.cartProvider = this.ProviderManager.GetProvider<Entities.Cart>();
            this.cartItemProvider = this.ProviderManager.GetProvider<CartItem>();
            this.productProvider = this.ProviderManager.GetProvider<Product>();
        }

        public Entities.Cart GetCart(Guid cartId)
        {
            return this.cartProvider.GetBy(c => c.Id == cartId).SingleOrDefault();
        }

        public Entities.Cart GetCartByUserId(Guid userId)
        {
            return this.cartProvider.GetBy(c => c.User.Id == userId).SingleOrDefault();
        }

        public CartItem GetCartItem(Guid cartItemId)
        {
            return this.cartItemProvider.GetBy(i => i.Id == cartItemId).SingleOrDefault();
        }

        public CartItem GetCartItemByProductId(Guid productId)
        {
            return this.cartItemProvider.GetBy(i => i.Product.Id == productId).SingleOrDefault();
        }

        public void AddToCart(Entities.Cart cart, Guid productId, int quantity)
        {
            var cartItem = this.GetCartItemByProductId(productId);

            if (cartItem == null)
            {
                var product = this.productProvider.GetBy(p => p.Id == productId).SingleOrDefault();

                if (product == null)
                {
                    throw new ArgumentException("Product not found.");
                }

                cartItem = this.CreateCartItem(product, quantity);
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            this.SaveChanges();
        }

        public void UpdateCartItem(Entities.Cart cart, Guid productId, int quantity)
        {
            var cartItem = this.GetCartItemByProductId(productId);

            if (cartItem == null)
            {
                this.AddToCart(cart, productId, quantity);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            this.SaveChanges();
        }

        public void UpdateCartItems(Entities.Cart cart, IEnumerable<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                var persistedCartItem = cart.CartItems.First(i => i.Id == cartItem.Id);

                if (persistedCartItem == null)
                {
                    continue;
                }

                persistedCartItem.Product = cartItem.Product;
                persistedCartItem.Quantity = cartItem.Quantity;
            }

            this.SaveChanges();
        }

        public void RemoveFromCart(Entities.Cart cart, Guid productId)
        {
            var cartItem = this.GetCartItemByProductId(productId);

            if (cartItem != null)
            {
                this.cartItemProvider.Delete(cartItem);
                this.SaveChanges();
            }
        }

        public void ClearCart(Entities.Cart cart)
        {
            foreach (var cartItem in cart.CartItems)
            {
                this.cartItemProvider.Delete(cartItem);
            }

            this.SaveChanges();
        }

        public void ClearCart(Guid cartId)
        {
            var cart = this.GetCart(cartId);
            this.ClearCart(cart);
        }

        private CartItem CreateCartItem(Product product, int quantity)
        {
            var cartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                Product = product,
                Quantity = quantity
            };

            this.cartItemProvider.Create(cartItem);

            return cartItem;
        }
    }
}
