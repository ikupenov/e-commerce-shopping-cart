using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Gateways
{
    public class EntityFrameworkProvider<TEntity> : IProvider<TEntity>
        where TEntity : Entity
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> set;

        public EntityFrameworkProvider(DbContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll() => this.set;

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression) => this.set.Where(expression);

        public void Create(TEntity entity) => this.set.Add(entity);

        public void Update(TEntity entity) => this.set.Update(entity);

        public void Delete(TEntity entity) => this.set.Remove(entity);
    }
}
