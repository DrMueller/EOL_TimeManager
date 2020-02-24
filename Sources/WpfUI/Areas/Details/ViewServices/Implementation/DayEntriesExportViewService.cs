using Mmu.TimeManager.Domain.Areas.Factories;
using Mmu.TimeManager.Domain.Areas.Models.Management;
using Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Servants;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class DayEntriesExportViewService : IDayEntriesExportViewService
    {
        private readonly IDayExportFactory _dayExportFactory;
        private readonly IFileWriter _fileWriter;

        public DayEntriesExportViewService(
            IDayExportFactory dayExportFactory,
            IFileWriter fileWriter)
        {
            _dayExportFactory = dayExportFactory;
            _fileWriter = fileWriter;
        }

        public void ExportToFile(DailyReport report)
        {
            var dayExport = _dayExportFactory.Create(report);
            _fileWriter.WriteAndOpenTextFile(dayExport);
        }
    }
}