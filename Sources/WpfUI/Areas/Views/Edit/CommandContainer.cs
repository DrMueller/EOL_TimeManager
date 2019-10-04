using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;

namespace Mmu.TimeManager.WpfUI.Areas.Views.Edit
{
    public class CommandContainer : IViewModelCommandContainer<EditDayViewModel>
    {
        private EditDayViewModel _context;

        public Task InitializeAsync(EditDayViewModel context)
        {
            _context = context;

            //Commands = new CommandsViewData(
            //    SaveIndividual,
            //    Cancel);

            return Task.CompletedTask;
        }
    }
}