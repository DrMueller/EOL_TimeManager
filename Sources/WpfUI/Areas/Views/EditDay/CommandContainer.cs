using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.TimeManager.Domain.Areas.Repositories;
using Mmu.TimeManager.WpfUI.Areas.ViewServices;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class CommandContainer : IViewModelCommandContainer<EditDayViewModel>
    {
        private readonly IDayEditViewService _dataService;
        private EditDayViewModel _context;

        public CommandContainer(IDayEditViewService dataService)
        {
            _dataService = dataService;
        }

        public async Task InitializeAsync(EditDayViewModel context)
        {
            _context = context;

            //Commands = new CommandsViewData(
            //    SaveIndividual,
            //    Cancel);

        }
    }
}