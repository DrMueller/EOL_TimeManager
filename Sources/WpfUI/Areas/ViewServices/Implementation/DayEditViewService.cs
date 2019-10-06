using Mmu.TimeManager.Domain.Areas.Repositories;
using Mmu.TimeManager.WpfUI.Areas.ViewData;
using System;
using System.Threading.Tasks;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices.Implementation
{
    public class DayEditViewService : IDayEditViewService
    {
        private readonly IDailyReportRepository _dailyReportRepo;

        public DayEditViewService(IDailyReportRepository dailyReportRepo)
        {
            _dailyReportRepo = dailyReportRepo;
        }

        public async Task<DailyReportViewData> LoadAsync(DateTime reportDate)
        {
            var model = await _dailyReportRepo.LoadByDateAsync(reportDate);
            if (model == null)
            {
                return new DailyReportViewData
                {
                    Date = reportDate,
                    Id = string.Empty
                };
            }

            var viewData = new DailyReportViewData
            {
                Date = model.Date,
                Id = model.Id
            };

            return viewData;
        }
    }
}