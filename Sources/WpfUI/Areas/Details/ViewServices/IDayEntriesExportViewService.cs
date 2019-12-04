using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices
{
    public interface IDayEntriesExportViewService
    {
        void ExportToFile(DailyReport report);
    }
}