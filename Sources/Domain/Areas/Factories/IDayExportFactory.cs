using Mmu.TimeManager.Domain.Areas.Models.Export;
using Mmu.TimeManager.Domain.Areas.Models.Management;

namespace Mmu.TimeManager.Domain.Areas.Factories
{
    public interface IDayExportFactory
    {
        DayExport Create(DailyReport report);
    }
}