using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using Ninject;

using DynamicQueries.ConsoleApp.Models;
using DynamicQueries.Data;
using DynamicQueries.Data.Migrations;
using DynamicQueries.Data.Repositories.Abstractions;
using DynamicQueries.Data.UnitOfWork;
using DynamicQueries.IoC;
using DynamicQueries.Models;

namespace DynamicQueries.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = DynamicQueriesContainer.GetNinjectKernel;

            IUnitOfWork unitOfWork = kernel.Get<IUnitOfWork>();

            SetupDatabase(unitOfWork);

            string interfaceName = "IAuditableRepository";
            string tableName = "Source";

            IAuditableRepository<INomenclatureEntity> repository = 
                GetRepositoryByTableName(unitOfWork, interfaceName, tableName);

            var nomenclatureTableValues = new List<NomenclatureTableViewModel>();

            if (repository != null)
            {
                nomenclatureTableValues = repository.All().Select(r => new NomenclatureTableViewModel
                {
                    Id = r.GetNomenclatureId(),
                    Name = r.GetNomenclatureName()
                })
                .ToList();
            }

            PrintNomenclatureValues(nomenclatureTableValues);
        }

        private static void SetupDatabase(IUnitOfWork unitOfWork)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DynamicQueriesContext, Configuration>());
            unitOfWork.SourceRepository.All().FirstOrDefault();
        }

        private static IAuditableRepository<INomenclatureEntity> GetRepositoryByTableName(IUnitOfWork unitOfWork, string interfaceName, string tableName)
        {
            IAuditableRepository<INomenclatureEntity> repository = null;

            PropertyInfo[] propertiesInfo = unitOfWork.GetType().GetProperties();

            foreach (var propertyInfo in propertiesInfo)
            {
                if (propertyInfo.PropertyType.FullName.Contains(interfaceName) && propertyInfo.PropertyType.FullName.Contains(tableName))
                {
                    repository = (IAuditableRepository<INomenclatureEntity>)propertyInfo.GetValue(unitOfWork);
                    break;
                }
            }

            return repository;
        }

        private static void PrintNomenclatureValues(List<NomenclatureTableViewModel> nomenclatureValues)
        {
            foreach (var item in nomenclatureValues)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
