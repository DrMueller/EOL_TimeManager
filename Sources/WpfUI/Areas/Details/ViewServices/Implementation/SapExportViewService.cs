using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Services;
using Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Servants;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class SapExportViewService : ISapExportViewService
    {
        private readonly IFileWriter _fileWriter;
        private readonly ISapEntryCalculationService _sapEntryCalculationService;
        private readonly ISapNavigator _sapNavigtor;

        public SapExportViewService(
            ISapEntryCalculationService sapEntryCalculationService,
            IFileWriter fileWriter,
            ISapNavigator sapNavigtor)
        {
            _sapEntryCalculationService = sapEntryCalculationService;
            _fileWriter = fileWriter;
            _sapNavigtor = sapNavigtor;
        }

        public void Export(DailyReport report)
        {
            var sapEntries = _sapEntryCalculationService.CalculateEntries(report);
            _sapNavigtor.NavigateToDay(report.Date);
            _fileWriter.WriteAndOpenTextFile(sapEntries);
        }
    }
}