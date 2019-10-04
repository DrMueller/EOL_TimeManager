using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class EditDayViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IProjectRepository _projectRepository;

        public string HeadingDescription { get; } = "Edit day";
        public string NavigationDescription { get; } = "Edit day";
        public int NavigationSequence { get; } = 0;

        public IReadOnlyCollection<Project> Projects { get; private set; }
        public Project SelectedProject { get; set; }

        public EditDayViewModel(CommandContainer commandContainer, IProjectRepository projectRepository)
        {
            _commandContainer = commandContainer;
            _projectRepository = projectRepository;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            Projects = await _projectRepository.LoadAllAsync();
            await _commandContainer.InitializeAsync(this);
        }
    }
}