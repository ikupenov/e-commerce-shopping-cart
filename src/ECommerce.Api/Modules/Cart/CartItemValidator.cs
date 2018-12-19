using FluentValidation;

namespace ECommerce.Api.Modules.Cart
{
    public class CartItemValidator : AbstractValidator<CartItemViewModel>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.Quantity > 0);
        }
    }
}
