using DynamicQueries.Data.Repositories.Abstractions;
using DynamicQueries.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicQueries.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDynamicQueriesContext Context { get; }

        IAuditableRepository<Source> SourceRepository { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
