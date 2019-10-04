using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.TimeManager.WpfUI.Areas.Views.DaysOverview
{
    public class DaysOverviewViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        public string HeadingDescription { get; } = "Overview";
        public string NavigationDescription { get; } = "Overview";
        public int NavigationSequence { get; } = 1;

        public DaysOverviewViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}