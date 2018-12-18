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
        private readonly DbSet<TEntity> entities;

        public EntityFrameworkProvider(DbContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll() => this.entities;

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression) => this.entities.Where(expression);

        public void Create(TEntity entity) => this.entities.Add(entity);

        public void Update(TEntity entity) => this.entities.Update(entity);

        public void Delete(TEntity entity) => this.entities.Remove(entity);
    }
}
