using System.Data.Entity;
using System.Data.Entity.Validation;

using DynamicQueries.Models;

namespace DynamicQueries.Data
{
    public class DynamicQueriesContext : DbContext, IDynamicQueriesContext
    {
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbEntityValidationException(ex.Message);
            }
        }

        public DbSet<Source> Sources { get; set; }
    }
}
