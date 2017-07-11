using System;
using System.Data.Entity;
using System.Linq;

using DynamicQueries.Data.Repositories.Abstractions;
using DynamicQueries.Models;

namespace DynamicQueries.Data.Repositories
{
    public class AuditableRepository<T> : GenericRepository<T>, IAuditableRepository<T> where T : class, IAuditableEntity
    {
        public AuditableRepository(IDynamicQueriesContext context) : base(context)
        {
        }

        public static IAuditableRepository<T> GetInstance(IDynamicQueriesContext context)
        {
            return (new AuditableRepository<T>(context));
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.Deleted);
        }

        public override void Add(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override T GetById(Guid id)
        {
            var result = base.GetById(id);

            return !result.Deleted ? result : null;
        }

        public override T GetById(long id)
        {
            var result = base.GetById(id);

            return !result.Deleted ? result : null;
        }

        public override void Update(T entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(T entity)
        {
            entity.Deleted = true;
            entity.DeletedOn = DateTime.Now;
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void HardDelete(T entity)
        {
            base.Delete(entity);
        }
    }
}
