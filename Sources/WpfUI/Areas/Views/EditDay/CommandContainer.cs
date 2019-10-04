using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.TimeManager.Domain.Areas.Repositories;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class CommandContainer : IViewModelCommandContainer<EditDayViewModel>
    {
        private readonly IProjectRepository _dailyReportRepository;
        private EditDayViewModel _context;

        public CommandContainer(IProjectRepository dailyReportRepository)
        {
            _dailyReportRepository = dailyReportRepository;
        }

        public async Task InitializeAsync(EditDayViewModel context)
        {
            _context = context;

            //Commands = new CommandsViewData(
            //    SaveIndividual,
            //    Cancel);

            var tra = await _dailyReportRepository.LoadAllAsync();
        }
    }
}