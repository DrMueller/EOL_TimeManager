using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.TimeManager.WpfUI.Areas.ViewData;
using Mmu.TimeManager.WpfUI.Areas.Views.EditDay;

namespace Mmu.TimeManager.WpfUI.Areas.Views.DaysOverview
{
    public class CommandContainer : IViewModelCommandContainer<DaysOverviewViewModel>
    {
        private readonly IViewModelDisplayService _displayService;

        public ICommand EditDay
        {
            get
            {
                return new ParametredRelayCommand((object obj) =>
                {
                    var overviewEntry = (DayOverviewViewData)obj;
                    _displayService.DisplayAsync<EditDayViewModel>(overviewEntry.Date);
                });
            }
        }

        public CommandContainer(IViewModelDisplayService displayService)
        {
            _displayService = displayService;
        }

        public Task InitializeAsync(DaysOverviewViewModel context)
        {
            return Task.CompletedTask;
        }
    }
}