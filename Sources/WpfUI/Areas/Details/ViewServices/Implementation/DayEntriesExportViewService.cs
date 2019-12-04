using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Services;
using Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Servants;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class DayEntriesExportViewService : IDayEntriesExportViewService
    {
        private readonly IFileWriter _fileWriter;
        private readonly IExportReportEntryCalculationService _sapEntryCalculationService;

        public DayEntriesExportViewService(
            IExportReportEntryCalculationService sapEntryCalculationService,
            IFileWriter fileWriter)
        {
            _sapEntryCalculationService = sapEntryCalculationService;
            _fileWriter = fileWriter;
        }

        public void ExportToFile(DailyReport report)
        {
            var sapEntries = _sapEntryCalculationService.CalculateEntries(report);
            _fileWriter.WriteAndOpenTextFile(sapEntries);
        }
    }
}