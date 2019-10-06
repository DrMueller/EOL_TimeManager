using System;
using System.Threading.Tasks;
using Mmu.TimeManager.WpfUI.Areas.ViewData;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices
{
    public interface IDayEditViewService
    {
        Task<DailyReportViewData> LoadAsync(DateTime reportDate);
    }
}