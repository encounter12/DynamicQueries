using DynamicQueries.Models;
using System;
using System.Linq;

namespace DynamicQueries.Data.Repositories.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        IDynamicQueriesContext Context { get; }

        IQueryable<T> All();

        T GetById(long id);

        T GetById(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
