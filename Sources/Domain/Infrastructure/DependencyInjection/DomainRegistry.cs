using Mmu.TimeManager.Domain.Areas.Factories;
using Mmu.TimeManager.Domain.Areas.Factories.Implementation;
using StructureMap;

namespace Mmu.TimeManager.Domain.Infrastructure.DependencyInjection
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            For<IDailyReportFactory>().Use<DailyReportFactory>().Singleton();
            For<IReportEntryFactory>().Use<ReportEntryFactory>().Singleton();
        }
    }
}