using FluentValidation;

namespace ECommerce.Api.Modules.Cart
{
    public class CartValidator : AbstractValidator<CartDTO>
    {
        public CartValidator()
        {
            RuleForEach(c => c.CartItems).SetValidator(new CartItemValidator());
        }
    }
}
