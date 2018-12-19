using FluentValidation;

namespace ECommerce.Api.Modules.Cart
{
    internal class CartItemValidator : AbstractValidator<CartItemDTO>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.Quantity > 0);
        }
    }
}
