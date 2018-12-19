using System;

namespace ECommerce.Core.Managers.Cart
{
    public interface ICartManager
    {
        Entities.Cart GetCartByUserId(Guid userId);
    }
}
