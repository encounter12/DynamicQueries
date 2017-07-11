using Ninject;
using DynamicQueries.Data;
using DynamicQueries.Data.Repositories.Abstractions;
using DynamicQueries.Data.Repositories;
using DynamicQueries.Data.UnitOfWork;

namespace DynamicQueries.IoC
{
    public static class DynamicQueriesContainer
    {
        public static IKernel GetNinjectKernel
        {
            get
            {
                IKernel kernel = null;

                if (kernel == null)
                {
                    kernel = new StandardKernel();
                    RegisterServices(kernel);
                }

                return kernel;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDynamicQueriesContext>().To<DynamicQueriesContext>().InSingletonScope();

            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind(typeof(IAuditableRepository<>)).To(typeof(AuditableRepository<>));

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
