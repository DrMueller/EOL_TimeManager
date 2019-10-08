using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices
{
    public interface ISapExportService
    {
        void Export(DailyReport report);
    }
}