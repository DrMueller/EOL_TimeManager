using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.TimeManager.Domain.Areas.Models.Management;
using Mmu.TimeManager.WpfUI.Areas.Details.ViewData;
using Mmu.TimeManager.WpfUI.Areas.Details.ViewServices;

namespace Mmu.TimeManager.WpfUI.Areas.Details.Views.DayDetails
{
    public class EditDayViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IDayDetailsViewService _viewService;
        private IReadOnlyCollection<ReportEntryViewData> _reportEntries;
        private ReportEntryViewData _selectedReportEntry;
        public CommandContainer CommandContainer { get; }
        public DailyReport DailyReport { get; private set; }
        public string DayDateDescription => DailyReport.Date.ToShortDateString();
        public string HeadingDescription { get; } = "Edit day";
        public string NavigationDescription { get; } = "Today";
        public int NavigationSequence { get; } = 0;
        public string ReportedTimeDescription => DailyReport.CalculateReportedHours().ToString();

        public IReadOnlyCollection<ReportEntryViewData> ReportEntries
        {
            get => _reportEntries;
            set
            {
                if (!Equals(_reportEntries, value))
                {
                    _reportEntries = value;
                    OnPropertyChanged();
                }
            }
        }

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
            IDayDetailsViewService viewService,
            CommandContainer commandContainer,
            IViewModelFactory viewModelFactory)
        {
            _viewService = viewService;
            CommandContainer = commandContainer;
            _viewModelFactory = viewModelFactory;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await CommandContainer.InitializeAsync(this);
            DailyReport = await _viewService.LoadDailyReportAsync(initParams);
            await RefreshReportEntriesAsync();
        }

        internal async Task ClearSelectionAsync()
        {
            SelectedReportEntry = await _viewModelFactory.CreateAsync<ReportEntryViewData>();
        }

        internal async Task RefreshReportEntriesAsync()
        {
            var adaptTasks = DailyReport.SortedReportEntries.Select(AdaptViewEntryAsync).ToArray();
            var viewData = await Task.WhenAll(adaptTasks);
            ReportEntries = viewData.ToList();
            await ClearSelectionAsync();
            OnPropertyChanged(nameof(ReportedTimeDescription));
        }

        private async Task<ReportEntryViewData> AdaptViewEntryAsync(ReportEntry reportEntry)
        {
            var viewData = await _viewModelFactory.CreateAsync<ReportEntryViewData>();
            viewData.BeginTime = reportEntry.BeginTime.Description;
            viewData.EndTime = reportEntry.EndTime.Evaluate(to => to.Description, () => string.Empty);
            viewData.WorkDescription = reportEntry.WorkDescription;
            viewData.ReportEntryId = reportEntry.Id;

            return viewData;
        }
    }
}