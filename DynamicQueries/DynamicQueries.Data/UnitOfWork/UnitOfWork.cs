using System;
using System.Threading.Tasks;

using DynamicQueries.Data.Repositories;
using DynamicQueries.Data.Repositories.Abstractions;
using DynamicQueries.Models;

namespace DynamicQueries.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAuditableRepository<Source> sourceRepository;

        public UnitOfWork(IDynamicQueriesContext context)
        {
            this.Context = context;
        }

        public IDynamicQueriesContext Context { get; private set; }

        public IAuditableRepository<Source> SourceRepository
        {
            get
            {
                return this.sourceRepository ?? (this.sourceRepository = AuditableRepository<Source>.GetInstance(this.Context));
            }
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
