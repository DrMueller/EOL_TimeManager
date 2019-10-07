using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.TimeManager.Domain.Areas.Factories;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;
using Mmu.TimeManager.WpfUI.Areas.ViewData;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class CommandContainer : IViewModelCommandContainer<EditDayViewModel>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IReportEntryFactory _reportEntryFactory;
        private EditDayViewModel _context;

        public ICommand EditEntry
        {
            get
            {
                return new ParametredRelayCommand((object obj) =>
                {
                    var reportEntry = (ReportEntryViewData)obj;
                    _context.SelectedReportEntry = reportEntry.DeepCopy();
                });
            }
        }

        public ICommand Cancel
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _context.RefreshData();
                });
            }
        }

        public ICommand DeleteEntry
        {
            get
            {
                return new ParametredRelayCommand(async (object obj) =>
                {
                    var reportEntry = (ReportEntryViewData)obj;
                    _context.DailyReport.RemoveReportEntry(reportEntry.ReportEntryId);
                    await _dailyReportRepository.SaveAsync(_context.DailyReport);
                    _context.RebindReportEntries();
                });
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var entry = _context.SelectedReportEntry;
                    var reportEntry = _reportEntryFactory.Create(
                        TimeStamp.Parse(entry.BeginTime),
                        TimeStamp.TryParsing(entry.EndTime),
                        entry.WorkDescription,
                        entry.ReportEntryId);

                    _context.DailyReport.UpsertReportEntry(reportEntry);
                    await _dailyReportRepository.SaveAsync(_context.DailyReport);
                    _context.RefreshData();
                }, () => _context.SelectedReportEntry.IsValid);
            }
        }

        public CommandContainer(
            IReportEntryFactory reportEntryFactory,
            IDailyReportRepository dailyReportRepository)
        {
            _reportEntryFactory = reportEntryFactory;
            _dailyReportRepository = dailyReportRepository;
        }

        public Task InitializeAsync(EditDayViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}