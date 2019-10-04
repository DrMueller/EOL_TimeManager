using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.TimeManager.WpfUI.Areas.Views.Overview
{
    public class CommandContainer : IViewModelCommandContainer<DaysOverviewViewModel>
    {
        private DaysOverviewViewModel _context;

        public Task InitializeAsync(DaysOverviewViewModel context)
        {
            _context = context;

            //Commands = new CommandsViewData(
            //    SaveIndividual,
            //    Cancel);

            return Task.CompletedTask;
        }
    }
}