using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.TimeManager.WpfUI.Areas.ViewData;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices
{
    public interface IDayOverviewViewService
    {
        Task<IReadOnlyCollection<DayOverviewViewData>> LoadAllAsync();
    }
}