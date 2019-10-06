using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.TimeManager.Domain.Areas.Models;
using Mmu.TimeManager.Domain.Areas.Repositories;
using Mmu.TimeManager.WpfUI.Areas.ViewServices;

namespace Mmu.TimeManager.WpfUI.Areas.Views.EditDay
{
    public class EditDayViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly IDayEditViewService _dataService;

        public string HeadingDescription { get; } = "Edit day";
        public string NavigationDescription { get; } = "Edit day";
        public int NavigationSequence { get; } = 0;
        public string DayDateDescription { get; private set; }

        public IReadOnlyCollection<Project> Projects { get; private set; }
        public Project SelectedProject { get; set; }

        public EditDayViewModel(CommandContainer commandContainer, IDayEditViewService dataService)
        {
            _commandContainer = commandContainer;
            _dataService = dataService;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            Projects = new List<Project>();
            var data = await _dataService.LoadAsync(DateTime.Now);
            DayDateDescription = data.ToString();

            await _commandContainer.InitializeAsync(this);
        }
    }
}