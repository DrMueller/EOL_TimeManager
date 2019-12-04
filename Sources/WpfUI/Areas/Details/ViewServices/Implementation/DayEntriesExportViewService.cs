using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Services;
using Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Servants;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class DayEntriesExportViewService : IDayEntriesExportViewService
    {
        private readonly IFileWriter _fileWriter;
        private readonly IExportReportEntryCalculationService _exportCalculationService;

        public DayEntriesExportViewService(
            IExportReportEntryCalculationService exportCalculationService,
            IFileWriter fileWriter)
        {
            _exportCalculationService = exportCalculationService;
            _fileWriter = fileWriter;
        }

        public void ExportToFile(DailyReport report)
        {
            var entries = _exportCalculationService.CalculateEntries(report);
            _fileWriter.WriteAndOpenTextFile(entries);
        }
    }
}