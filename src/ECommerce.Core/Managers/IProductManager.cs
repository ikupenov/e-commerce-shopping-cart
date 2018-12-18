using System.Collections.Generic;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Managers
{
    public interface IProductManager
    {
        IEnumerable<Product> GetProducts();
    }
}
