using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;
using System;
using System.Threading.Tasks;

namespace Mmu.TimeManager.DataAccess.Areas.Repositories
{
    internal class DailyReportRepository : RepositoryBase<DailyReport, DailyReportDataModel, string>, IDailyReportRepository
    {
        private readonly IDataModelAdapter<DailyReportDataModel, DailyReport, string> _dataModelAdapter;
        private readonly IDataModelRepository<DailyReportDataModel, string> _dataModelRepository;

        public DailyReportRepository(
            IDataModelRepository<DailyReportDataModel, string> dataModelRepository,
            IDataModelAdapter<DailyReportDataModel, DailyReport, string> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task<DailyReport> LoadByDateAsync(DateTime date)
        {
            var dataModel = await _dataModelRepository.LoadSingleAsync(f => f.Date == date);
            var result = _dataModelAdapter.Adapt(dataModel);
            return result;
        }
    }
}