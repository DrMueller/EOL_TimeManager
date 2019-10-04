using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;

namespace Mmu.TimeManager.DataAccess.Areas.Repositories
{
    internal class DailyReportRepository : RepositoryBase<DailyReport, DailyReportDataModel, string>, IDailyReportRepository
    {
        public DailyReportRepository(
            IDataModelRepository<DailyReportDataModel, string> dataModelRepository,
            IDataModelAdapter<DailyReportDataModel, DailyReport, string> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}