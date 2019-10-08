using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.TimeManager.Domain.Areas.Factories;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;
using Mmu.TimeManager.WpfUI.Areas.ViewData;
using Mmu.TimeManager.WpfUI.Areas.ViewServices;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class CommandContainer : IViewModelCommandContainer<EditDayViewModel>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IInformationPublisher _informationPublisher;
        private readonly IReportEntryFactory _reportEntryFactory;
        private readonly ISapExportService _sapExportService;
        private EditDayViewModel _context;

        public ICommand Clear
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await _context.ClearSelectionAsync();
                });
            }
        }

        public ICommand CopyText
        {
            get
            {
                return new ParametredRelayCommand((object obj) =>
                {
                    var reportEntry = (ReportEntryViewData)obj;
                    _context.SelectedReportEntry.WorkDescription = reportEntry.WorkDescription;
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
                    _informationPublisher.Publish(InformationEntry.CreateSuccess("Deleted", false, 5));
                    await _context.RefreshReportEntriesAsync();
                });
            }
        }

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

        public ICommand ExportToSap
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _sapExportService.Export(_context.DailyReport);
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

                    var upsertResult = _context.DailyReport.UpsertReportEntry(reportEntry);
                    if (upsertResult.IsSuccess)
                    {
                        await _dailyReportRepository.SaveAsync(_context.DailyReport);
                        await _context.RefreshReportEntriesAsync();
                        _informationPublisher.Publish(InformationEntry.CreateSuccess("Saved", false, 5));
                    }
                    else
                    {
                        _informationPublisher.Publish(InformationEntry.CreateInfo(upsertResult.ErrorMessage, false, 5));
                    }
                }, () => !_context.SelectedReportEntry.HasErrors);
            }
        }

        public CommandContainer(
            ISapExportService sapExportService,
            IReportEntryFactory reportEntryFactory,
            IDailyReportRepository dailyReportRepository,
            IInformationPublisher informationPublisher)
        {
            _sapExportService = sapExportService;
            _reportEntryFactory = reportEntryFactory;
            _dailyReportRepository = dailyReportRepository;
            _informationPublisher = informationPublisher;
        }

        public Task InitializeAsync(EditDayViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}