using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.TimeManager.WpfUI.Areas.Views.Edit
{
    public class EditDayViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public string HeadingDescription { get; } = "Edit day";

        public EditDayViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}