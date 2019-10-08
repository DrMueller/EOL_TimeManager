using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.WpfUI.Areas.ViewData;
using Mmu.TimeManager.WpfUI.Areas.ViewServices;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class EditDayViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IEditDayViewService _viewService;
        private ReportEntryViewData _selectedReportEntry;
        public ICommand Cancel => _commandContainer.Cancel;
        public DailyReport DailyReport { get; private set; }
        public string DayDateDescription => DailyReport.Date.ToShortDateString();
        public ICommand DeleteEntry => _commandContainer.DeleteEntry;
        public ICommand EditEntry => _commandContainer.EditEntry;
        public ICommand ExportToSap => _commandContainer.ExportToSap;
        public string HeadingDescription { get; } = "Edit day";
        public string NavigationDescription { get; } = "Edit day";
        public int NavigationSequence { get; } = 0;
        public string ReportedTimeDescription => DailyReport.CalculateReportedHours().ToString();

        public IReadOnlyCollection<ReportEntryViewData> ReportEntries
        {
            get
            {
                return DailyReport.ReportEntries.Select(re => new ReportEntryViewData(re.Id)
                {
                    BeginTime = re.BeginTime.Description,
                    EndTime = re.EndTime.Evaluate(to => to.Description, () => string.Empty),
                    WorkDescription = re.WorkDescription
                }).ToList();
            }
        }

        public ICommand Save => _commandContainer.Save;

        public ReportEntryViewData SelectedReportEntry
        {
            get => _selectedReportEntry;
            set
            {
                if (_selectedReportEntry != value)
                {
                    _selectedReportEntry = value;
                    OnPropertyChanged();
                }
            }
        }

        public EditDayViewModel(
            IEditDayViewService viewService,
            CommandContainer commandContainer)
        {
            SelectedReportEntry = new ReportEntryViewData(string.Empty);
            _viewService = viewService;
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
            DailyReport = await _viewService.LoadDailyReportAsync(initParams);
        }

        internal void RebindReportEntries()
        {
            OnPropertyChanged(nameof(ReportEntries));
            OnPropertyChanged(nameof(ReportedTimeDescription));
        }

        internal void RefreshData()
        {
            SelectedReportEntry = new ReportEntryViewData(string.Empty);
            RebindReportEntries();
        }
    }
}