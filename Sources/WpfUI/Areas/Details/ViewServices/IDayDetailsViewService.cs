using System.Threading.Tasks;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices
{
    public interface IDayDetailsViewService
    {
        Task<DailyReport> LoadDailyReportAsync(params object[] initParams);
    }
}