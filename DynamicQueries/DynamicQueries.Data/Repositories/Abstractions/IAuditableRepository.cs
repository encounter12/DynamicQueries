using DynamicQueries.Models;
using System.Linq;

namespace DynamicQueries.Data.Repositories.Abstractions
{
    public interface IAuditableRepository<T> : IGenericRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);
    }
}
