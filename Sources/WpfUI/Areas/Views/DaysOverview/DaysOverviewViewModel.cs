using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.TimeManager.WpfUI.Areas.ViewData;
using Mmu.TimeManager.WpfUI.Areas.ViewServices;

namespace Mmu.TimeManager.WpfUI.Areas.Views.DaysOverview
{
    public class DaysOverviewViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IDayOverviewViewService _dayOverviewViewService;
        private IReadOnlyCollection<DayOverviewViewData> _overviewEntries;
        public ICommand EditDay => _commandContainer.EditDay;
        public string HeadingDescription { get; } = "Overview";
        public string NavigationDescription { get; } = "Overview";
        public int NavigationSequence { get; } = 1;

        public IReadOnlyCollection<DayOverviewViewData> OverviewEntries
        {
            get => _overviewEntries;
            set
            {
                if (_overviewEntries != value)
                {
                    _overviewEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        public DaysOverviewViewModel(
            IDayOverviewViewService dayOverviewViewService,
            CommandContainer commandContainer)
        {
            _dayOverviewViewService = dayOverviewViewService;
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            OverviewEntries = await _dayOverviewViewService.LoadAllAsync();
            await _commandContainer.InitializeAsync(this);
        }
    }
}