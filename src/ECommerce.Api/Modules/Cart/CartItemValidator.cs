using FluentValidation;

namespace ECommerce.Api.Modules.Cart
{
    public class CartItemValidator : AbstractValidator<CartItemDTO>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.Quantity > 0);
        }
    }
}
