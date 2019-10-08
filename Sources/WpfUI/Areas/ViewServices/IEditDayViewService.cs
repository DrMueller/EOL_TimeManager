using System.Threading.Tasks;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices
{
    public interface IEditDayViewService
    {
        Task<DailyReport> LoadDailyReportAsync(params object[] initParams);
    }
}