using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.TimeManager.WpfUI.Areas.Overview.ViewData;

namespace Mmu.TimeManager.WpfUI.Areas.Overview.ViewServices
{
    public interface IDayOverviewViewService
    {
        Task<IReadOnlyCollection<DayOverviewViewData>> LoadAllAsync();
    }
}