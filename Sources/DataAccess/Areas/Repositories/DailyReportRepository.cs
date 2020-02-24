using System;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.TimeManager.DataAccess.Areas.DataModels;
using Mmu.TimeManager.Domain.Areas.Models.Management;
using Mmu.TimeManager.Domain.Areas.Repositories;

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

        public async Task<Maybe<DailyReport>> LoadByDateAsync(DateTime date)
        {
            var dataModel = await _dataModelRepository.LoadSingleAsync(f => f.Date.Date == date.Date);
            if (dataModel == null)
            {
                return Maybe.CreateNone<DailyReport>();
            }

            var result = _dataModelAdapter.Adapt(dataModel);
            return result;
        }
    }
}