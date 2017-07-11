using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using DynamicQueries.Models;

namespace DynamicQueries.Data
{
    public interface IDynamicQueriesContext
    {
        DbSet<Source> Sources { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
