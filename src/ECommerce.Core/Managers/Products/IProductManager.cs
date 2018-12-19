using System.Collections.Generic;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Managers.Products
{
    public interface IProductManager
    {
        IEnumerable<Product> GetProducts();
    }
}
