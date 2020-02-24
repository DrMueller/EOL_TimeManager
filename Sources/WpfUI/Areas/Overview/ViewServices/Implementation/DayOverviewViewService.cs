using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.TimeManager.Domain.Areas.Models.Management;
using Mmu.TimeManager.Domain.Areas.Repositories;
using Mmu.TimeManager.WpfUI.Areas.Overview.ViewData;

namespace Mmu.TimeManager.WpfUI.Areas.Overview.ViewServices.Implementation
{
    public class DayOverviewViewService : IDayOverviewViewService
    {
        private readonly IDailyReportRepository _dailyReportRepository;

        public DayOverviewViewService(IDailyReportRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task<IReadOnlyCollection<DayOverviewViewData>> LoadAllAsync()
        {
            var allDailyReports = await _dailyReportRepository.LoadAllAsync();
            var result = allDailyReports
                .OrderByDescending(f => f.Date)
                .Select(AdaptToOverview).ToList();
            return result;
        }

        private static DayOverviewViewData AdaptToOverview(DailyReport dailyReport)
        {
            return new DayOverviewViewData(
                dailyReport.Date,
                dailyReport.CalculateReportedHours().ToString(),
                dailyReport.Id);
        }
    }
}