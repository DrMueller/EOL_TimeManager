using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.TimeManager.WpfUI.Areas.Details.Views.DayDetails
{
    public partial class DayDetailsView : UserControl, IViewMap<EditDayViewModel>
    {
        public DayDetailsView()
        {
            InitializeComponent();
        }
    }
}