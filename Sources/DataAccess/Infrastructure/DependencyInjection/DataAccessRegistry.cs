using Mmu.TimeManager.DataAccess.Areas.DataModelRepositories;
using Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Adapters;
using Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Adapters.Implementation;
using Mmu.TimeManager.DataAccess.Areas.DataModelRepositories.Implementation;
using Mmu.TimeManager.DataAccess.Areas.Repositories;
using Mmu.TimeManager.Domain.Areas.Repositories;
using StructureMap;

namespace Mmu.TimeManager.DataAccess.Infrastructure.DependencyInjection
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<DataAccessRegistry>();
                scanner.WithDefaultConventions();
            });

            For<IDailyReportDataModelAdapter>().Use<DailyReportDataModelAdapter>().Singleton();
            For<IDailyReportDataModelRepository>().Use<DailyReportDataModelRepository>().Singleton();
            For<IDailyReportRepository>().Use<DailyReportRepository>().Singleton();
        }
    }
}