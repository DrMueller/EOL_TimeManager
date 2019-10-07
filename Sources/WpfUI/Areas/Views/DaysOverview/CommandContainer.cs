using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.TimeManager.WpfUI.Areas.Views.EditDay;

namespace Mmu.TimeManager.WpfUI.Areas.Views.DaysOverview
{
    public class CommandContainer : IViewModelCommandContainer<DaysOverviewViewModel>
    {
        private readonly IViewModelDisplayService _displayService;
        private DaysOverviewViewModel _context;

        public ICommand EditDay
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _displayService.DisplayAsync<EditDayViewModel>(_context.SelectedOverviewEntry.Date);
                }, () => _context.SelectedOverviewEntry != null);
            }
        }

        public CommandContainer(IViewModelDisplayService displayService)
        {
            _displayService = displayService;
        }

        public Task InitializeAsync(DaysOverviewViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }
    }
}