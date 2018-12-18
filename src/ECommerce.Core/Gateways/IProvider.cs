using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Gateways
{
    public interface IProvider<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
