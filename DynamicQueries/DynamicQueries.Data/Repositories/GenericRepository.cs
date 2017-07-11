using System;
using System.Data.Entity;
using System.Linq;

using DynamicQueries.Data.Repositories.Abstractions;

namespace DynamicQueries.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbSet<T> DbSet;

        private readonly IDynamicQueriesContext context;

        public GenericRepository(IDynamicQueriesContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.context = context;
            this.DbSet = context.Set<T>();
        }

        public IDynamicQueriesContext Context
        {
            get { return this.context; }
        }

        public virtual IQueryable<T> All()
        {
            return this.DbSet;
        }

        public virtual T GetById(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public virtual T GetById(long id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
